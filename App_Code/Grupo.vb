Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

	Public Class Grupo
		Inherits DBObject

		Public idGrupo As Integer
		Public display As Boolean
		Public orden As Integer
		Public eliminado As Boolean
        Public existe As Boolean = False
        Public sitio As Integer = 1

        Sub New()
		End Sub

		Sub New(ByVal parametro As Integer, Optional ByVal parametroEsClave As Boolean = True)
			Dim queryString As String
			If parametroEsClave Then
				queryString = "SELECT * FROM Grupos WHERE idGrupo=@parametro"
			Else
				queryString = "SELECT * FROM Grupos WHERE orden=@parametro"
			End If
			Dim params As SqlParameter() = {New SqlParameter("@parametro", parametro)}
			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, params)

			If dr.Read Then
				Me.idGrupo = CInt(dr("idGrupo"))
				Me.display = CBool(dr("display"))
				Me.orden = CInt(dr("orden"))
                Me.eliminado = CBool(dr("eliminado"))
                If Not Convert.IsDBNull(dr("sitio")) Then
                    Me.sitio = CInt(dr("sitio"))
                End If
                Me.existe = True
			End If
			dr.Close()
		End Sub

		Protected Function Add() As Integer
			Dim sql As String = "INSERT INTO grupos (display, orden, eliminado) VALUES (@display, @orden, @eliminado)"
			Dim params As SqlParameter() = { _
			New SqlParameter("@display", display), _
			New SqlParameter("@orden", orden), _
			New SqlParameter("@eliminado", eliminado)}

			Me.idGrupo = Me.ExecuteNonQuery(sql, params, True)
			Me.existe = True
			Return 1
		End Function

		Protected Function Update() As Integer
			Dim queryString As String = "UPDATE Grupos SET display=@display, orden=@orden, eliminado=@eliminado WHERE idGrupo=@idGrupo"
			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idGrupo", idGrupo), _
			 New SqlParameter("@display", display), _
			 New SqlParameter("@orden", orden), _
			 New SqlParameter("@eliminado", eliminado)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Protected Function Remove() As Integer
			recorrerGrupos(Me.orden)

			Me.display = False
			Me.orden = 0
			Me.eliminado = True
			Me.Update()
		End Function

		Public Sub subir()
			If Me.orden > 1 Then
				Dim objGrupoVecino As New Grupo(Me.orden - 1, False)
				objGrupoVecino.orden = Me.orden
				objGrupoVecino.Update()

				Me.orden = Me.orden - 1
				Me.Update()
			End If
		End Sub

		Public Sub bajar()
			Dim objGrupoVecino As New Grupo(Me.orden + 1, False)
			If objGrupoVecino.existe Then
				objGrupoVecino.orden = Me.orden
				objGrupoVecino.Update()

				Me.orden = Me.orden + 1
				Me.Update()
			End If
		End Sub

		Private Sub recorrerGrupos(ByVal ordenEliminado As Integer)
			Dim queryString As String = "UPDATE Grupos SET orden = orden - 1 WHERE orden > @ordenEliminado"
			Dim parametros As SqlParameter() = {New SqlParameter("@ordenEliminado", ordenEliminado)}

			Me.ExecuteNonQuery(queryString, parametros)

		End Sub

		Public Function GetLastOrden() As Integer
			Dim lastOrden As Integer = 0
			Dim queryString As String = "SELECT TOP (1) ISNULL(orden, 0) AS orden FROM Grupos WHERE eliminado = 0 AND orden > 0 ORDER BY orden DESC"
			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, Nothing)
			If dr.Read Then
				lastOrden = CInt(dr("orden"))
			End If
			dr.Close()

			Return lastOrden
		End Function
	End Class
End Namespace
