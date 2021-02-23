Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

	Public Class ProductoCaracteristica
		Inherits DBObject

		Public idProductoCaracteristica As Integer
		Public idProducto As Integer
		Public idCaracteristica As Integer
		Public idIdioma As Integer
		Public valor As String
		Public existe As Boolean = False

		Sub New()
		End Sub

		Sub New(ByVal claveprincipal As Integer)
			Dim sql As String = "select * from ProductosCaracteristicas where  idProductoCaracteristica=@idProductoCaracteristica"
			Dim params() As SqlParameter = {New SqlParameter("@idProductoCaracteristica", claveprincipal)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
			If dr.Read Then
				Me.idProductoCaracteristica = CInt(dr("idProductoCaracteristica"))
				Me.idProducto = CInt(dr("idProducto"))
				Me.idCaracteristica = CInt(dr("idCaracteristica"))
				Me.idIdioma = CInt(dr("ididioma"))
				Me.valor = dr("valor")
				Me.existe = True
			End If

			dr.Close()
		End Sub

		Sub New(ByVal claveproducto As Integer, ByVal claveidioma As Integer, ByVal clavecaracteristica As Integer)
			Dim sql As String = "select * from ProductosCaracteristicas where idProducto=@idProducto and idIdioma=@idIdioma and idCaracteristica=@idCaracteristica"
			Dim params() As SqlParameter = {New SqlParameter("@idProducto", claveproducto), New SqlParameter("@idIdioma", claveidioma), New SqlParameter("@idCaracteristica", clavecaracteristica)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
			If dr.Read Then
				Me.idProductoCaracteristica = CInt(dr("idProductoCaracteristica"))
				Me.idProducto = CInt(dr("idProducto"))
				Me.idCaracteristica = CInt(dr("idCaracteristica"))
				Me.idIdioma = CInt(dr("ididioma"))
				Me.valor = dr("valor")
				Me.existe = True
			End If

			dr.Close()
		End Sub

		Public Function Add() As Integer
			Dim sql As String = "insert into ProductosCaracteristicas (idproducto, idcaracteristica, ididioma, valor) values (@idproducto, @idcaracteristica, @ididioma, @valor)"
			Dim params() As SqlParameter = {New SqlParameter("@idproducto", idProducto), _
			  New SqlParameter("@idcaracteristica", idCaracteristica), _
			  New SqlParameter("@ididioma", idIdioma), _
			  New SqlParameter("@valor", valor)}

			Me.idProductoCaracteristica = Me.ExecuteNonQuery(sql, params, True)

			Return 1
		End Function

		Public Function Update() As Integer
			Dim sql As String = "update ProductosCaracteristicas set idproducto=@idproducto, idcaracteristica=@idcaracteristica, ididioma=@ididioma, valor=@valor where idProductoCaracteristica=@idProductoCaracteristica "

			Dim params() As SqlParameter = {New SqlParameter("@idproducto", idProducto), _
			   New SqlParameter("@idcaracteristica", idCaracteristica), _
			   New SqlParameter("@ididioma", idIdioma), _
			   New SqlParameter("@valor", valor), _
			   New SqlParameter("@idProductoCaracteristica", idProductoCaracteristica)}


			Me.ExecuteNonQuery(sql, params)
			Return 1

		End Function

		Public Function Remove() As Integer
			Dim sql As String = "delete ProductosCaracteristicas where idProductoCaracteristica=@idProductoCaracteristica"
			Dim params() As SqlParameter = {New SqlParameter("@idProductoCaracteristica", idProductoCaracteristica)}
			Return Me.ExecuteNonQuery(sql, params)
		End Function

	End Class
End Namespace
