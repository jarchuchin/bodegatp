Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

	Public Class Anuncio
		Inherits DBObject

		Public idAnuncio As Integer
		Public Posicion As Integer
		Public FechaInicio As DateTime
		Public FechaFin As DateTime
		Public url As String
		Public target As String
		Public PImpresiones As Integer
		Public eliminado As Boolean
		Public orden As Byte
		Public pagina As PaginaAnuncio
		Public existe As Boolean = False

		Sub New()
		End Sub

		Sub New(ByVal claveprincipal As Integer)
			Dim sql As String = "select * from Anuncios where idAnuncio=@idAnuncio"
			Dim params As SqlParameter() = {New SqlParameter("@idAnuncio", claveprincipal)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

			If dr.Read Then
				Me.idAnuncio = CInt(dr("idAnuncio"))
				Me.Posicion = CInt(dr("Posicion"))
				Me.FechaInicio = CType(dr("FechaInicio"), DateTime)
				Me.FechaFin = CType(dr("FechaFin"), DateTime)
				Me.url = dr("url")
				Me.target = dr("target")
				Me.PImpresiones = CInt(dr("PImpresiones"))
				Me.eliminado = CBool(dr("eliminado"))
				Me.orden = CByte(dr("orden"))
				Me.pagina = CType([Enum].Parse(GetType(PaginaAnuncio), dr("pagina")), PaginaAnuncio)
				Me.existe = True
			End If
			dr.Close()

		End Sub

		Sub New(ByVal paginaUbicacion As PaginaAnuncio, ByVal posicionEnPagina As Integer, ByVal ordenEnPosicion As Byte)
			Dim queryString As String = "SELECT * FROM Anuncios WHERE pagina = @pagina AND posicion = @posicion AND orden = @orden"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@pagina", paginaUbicacion.ToString), _
			 New SqlParameter("@posicion", posicionEnPagina), _
			 New SqlParameter("@orden", ordenEnPosicion)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)

			If dr.Read Then
				Me.idAnuncio = CInt(dr("idAnuncio"))
				Me.Posicion = CInt(dr("Posicion"))
				Me.FechaInicio = CType(dr("FechaInicio"), DateTime)
				Me.FechaFin = CType(dr("FechaFin"), DateTime)
				Me.url = dr("url")
				Me.target = dr("target")
				Me.PImpresiones = CInt(dr("PImpresiones"))
				Me.eliminado = CBool(dr("eliminado"))
				Me.orden = CByte(dr("orden"))
				Me.pagina = CType([Enum].Parse(GetType(PaginaAnuncio), dr("pagina")), PaginaAnuncio)
				Me.existe = True
			End If
			dr.Close()

		End Sub

		Protected Function Add() As Integer
			Dim sql As String = "INSERT INTO Anuncios ( Posicion, FechaInicio, FechaFin, url, target, PImpresiones, eliminado, orden, pagina) VALUES (@Posicion, " _
			 & "@FechaInicio, @FechaFin, @url, @target, @PImpresiones, @eliminado, @orden, @pagina)"

			Dim params As SqlParameter() = { _
			 New SqlParameter("@Posicion", Me.Posicion), _
			 New SqlParameter("@FechaInicio", Me.FechaInicio), _
			 New SqlParameter("@FechaFin", Me.FechaFin), _
			 New SqlParameter("@url", Me.url), _
			 New SqlParameter("@target", Me.target), _
			 New SqlParameter("@PImpresiones", Me.PImpresiones), _
			 New SqlParameter("@eliminado", Me.eliminado), _
			 New SqlParameter("@orden", Me.orden), _
			 New SqlParameter("@pagina", Me.pagina.ToString)}

			Me.idAnuncio = Me.ExecuteNonQuery(sql, params, True)
			Me.existe = True
			Return 1
		End Function

		Protected Function Update() As Integer
			Dim sql As String = "update Anuncios set Posicion=@Posicion, FechaInicio=@FechaInicio, FechaFin=@FechaFin, url=@url, target=@target, " _
			& "PImpresiones=@PImpresiones, eliminado=@eliminado, orden=@orden, pagina=@pagina where idAnuncio=@idAnuncio"
			Dim params As SqlParameter() = { _
			  New SqlParameter("@Posicion", Posicion), _
			  New SqlParameter("@FechaInicio", FechaInicio), _
			  New SqlParameter("@FechaFin", FechaFin), _
			  New SqlParameter("@url", url), _
			  New SqlParameter("@target", target), _
			  New SqlParameter("@PImpresiones", PImpresiones), _
			  New SqlParameter("@eliminado", eliminado), _
			  New SqlParameter("@orden", Me.orden), _
			  New SqlParameter("@pagina", Me.pagina.ToString), _
			  New SqlParameter("@idAnuncio", idAnuncio)}

			Return Me.ExecuteNonQuery(sql, params)
		End Function

		Protected Function Remove() As Integer
			Me.recorrerGrupos(Me.pagina, Me.Posicion, Me.orden)
			Me.orden = 0
			Me.eliminado = True
			Me.Update()
		End Function

		Public Function subir() As Boolean
			If Me.orden > 1 Then
				Dim objAnuncioVecino As New Anuncio(Me.pagina, Me.Posicion, Me.orden - 1)
				objAnuncioVecino.orden = Me.orden
				objAnuncioVecino.Update()

				Me.orden = Me.orden - 1
				Me.Update()

				Return True
			End If

			Return False
		End Function

		Public Function bajar() As Boolean
			Dim objAnuncioVecino As New Anuncio(Me.pagina, Me.Posicion, Me.orden + 1)
			If objAnuncioVecino.existe Then
				objAnuncioVecino.orden = Me.orden
				objAnuncioVecino.Update()

				Me.orden = Me.orden + 1
				Me.Update()

				Return True
			End If

			Return False
		End Function

		Private Sub recorrerGrupos(ByVal paginaUbicacion As PaginaAnuncio, ByVal posicionEnPagina As Integer, ByVal ordenEliminado As Byte)
			Dim queryString As String = "UPDATE Anuncios SET orden = orden - 1 WHERE pagina = @pagina AND posicion = @posicion AND orden > @ordenEliminado " _
			 & "AND eliminado = 0"

			Dim parametros As SqlParameter() = { _
			New SqlParameter("@pagina", paginaUbicacion.ToString), _
			New SqlParameter("@posicion", posicionEnPagina), _
			New SqlParameter("@ordenEliminado", ordenEliminado)}

			Me.ExecuteNonQuery(queryString, parametros)

		End Sub

		Public Function GetLastOrden(ByVal paginaUbicacion As PaginaAnuncio, ByVal posicionEnPagina As Integer) As Integer
			Dim lastOrden As Integer = 0

			Dim queryString As String = "SELECT TOP (1) ISNULL(orden, 0) AS orden FROM Anuncios WHERE pagina = @pagina AND posicion = @posicion AND eliminado = 0 " _
			 & "AND orden > 0 ORDER BY orden DESC"

			Dim parametros As SqlParameter() = {New SqlParameter("@pagina", paginaUbicacion.ToString), New SqlParameter("@posicion", posicionEnPagina)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
			If dr.Read Then
				lastOrden = CInt(dr("orden"))
			End If
			dr.Close()

			Return lastOrden
		End Function
	End Class

End Namespace
