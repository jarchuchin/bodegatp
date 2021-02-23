Imports System.Data.SqlClient
Imports System.Data

Namespace tienda
	Public Class ProductoGrupo
		Inherits DBObject

		Public idProductoGrupo As Integer
		Public idProducto As Integer
		Public idGrupo As Integer
		Public existe As Boolean = False

		Sub New()
		End Sub

		Sub New(ByVal claveprincipal As Integer)
			Dim sql As String = "SELECT * FROM ProductosGrupos WHERE idProductoGrupo=@idProductoGrupo"
			Dim params As SqlParameter() = {New SqlParameter("@idProductoGrupo", claveprincipal)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

			If dr.Read Then
				Me.idProductoGrupo = CInt(dr("idProductoGrupo"))
				Me.idProducto = CInt(dr("idProducto"))
				Me.idGrupo = CInt(dr("idGrupo"))
				Me.existe = True
			End If
			dr.Close()

		End Sub

		Sub New(ByVal claveProducto As Integer, ByVal claveGrupo As Integer)
			Dim sql As String = "SELECT * FROM ProductosGrupos WHERE idProducto=@idProducto and idGrupo=@idGrupo"
			Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveProducto), New SqlParameter("@idGrupo", claveGrupo)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

			If dr.Read Then
				Me.idProductoGrupo = CInt(dr("idProductoGrupo"))
				Me.idProducto = CInt(dr("idProducto"))
				Me.idGrupo = CInt(dr("idGrupo"))
				Me.existe = True
			End If
			dr.Close()

		End Sub

		Public Function Add() As Integer
			Dim sql As String = "INSERT INTO ProductosGrupos (idProducto, idGrupo) VALUES (@idProducto, @idGrupo)"
			Dim params As SqlParameter() = {New SqlParameter("@idProducto", idProducto), New SqlParameter("@idGrupo", idGrupo)}

			Me.idProductoGrupo = Me.ExecuteNonQuery(sql, params, True)

			Me.existe = True
			Return 1
		End Function

		Public Function Remove() As Integer
			Dim queryString As String = "DELETE ProductosGrupos WHERE idProductoGrupo=@idProductoGrupo"
			Dim parametro As SqlParameter() = {New SqlParameter("@idProductoGrupo", Me.idProductoGrupo)}

			Return Me.ExecuteNonQuery(queryString, parametro)
		End Function

		Public Function GetDS(ByVal claveIdioma As Integer) As DataSet
            Dim sql As String = "SELECT pg.idProductoGrupo, pg.idGrupo, p.*, " & _
            " isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=p.idproducto and pf.principal=1), 'default.jpg') as imagen, " & _
             " isnull((select top 1 pp.precio from precios pp where pp.idEntidad=p.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio, " & _
            " pi.ididioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags, g.orden, " _
    & "gi.nombre AS grupo FROM ProductosGrupos AS pg INNER JOIN Productos AS p ON pg.idProducto = p.idProducto INNER JOIN " _
    & "ProductosIdiomas AS pi ON p.idProducto = pi.idProducto INNER JOIN Grupos AS g ON pg.idGrupo = g.idGrupo INNER JOIN " _
    & "GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo WHERE gi.idIdioma = @ididioma AND pi.idIdioma = @ididioma " _
    & "AND p.eliminado = 0 AND g.eliminado = 0 ORDER BY g.orden"

            Dim parametro As SqlParameter() = {New SqlParameter("@ididioma", claveIdioma)}

			Return Me.ExecuteDataSet(sql, parametro)
		End Function

		Public Function GetDR(ByVal claveIdioma As Integer) As SqlDataReader
            Dim sql As String = "SELECT pg.idProductoGrupo, pg.idGrupo, p.*, pi.ididioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags, g.orden, " _
    & "gi.nombre AS grupo FROM ProductosGrupos AS pg INNER JOIN Productos AS p ON pg.idProducto = p.idProducto INNER JOIN " _
    & "ProductosIdiomas AS pi ON p.idProducto = pi.idProducto INNER JOIN Grupos AS g ON pg.idGrupo = g.idGrupo INNER JOIN " _
    & "GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo WHERE gi.idIdioma = @ididioma AND pi.idIdioma = @ididioma " _
    & "AND p.eliminado = 0 AND g.eliminado = 0 ORDER BY g.orden"

            Dim parametro As SqlParameter() = {New SqlParameter("@ididioma", claveIdioma)}

			Return Me.ExecuteReader(sql, parametro)
		End Function

		Public Function GetDS(ByVal claveIdioma As Integer, ByVal claveGrupo As Integer) As DataSet
            Dim sql As String = "SELECT pg.idProductoGrupo, pg.idGrupo, p.*, pi.ididioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags, " _
             & " isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=pg.idproducto and pf.principal=1), 'default.jpg') as imagen, " _
             & " isnull((select top 1 pp.precio from precios pp where pp.identidad=pg.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio, " _
            & " g.orden, gi.nombre AS grupo FROM ProductosGrupos AS pg INNER JOIN Productos AS p ON pg.idProducto = p.idProducto INNER JOIN " _
            & " ProductosIdiomas AS pi ON p.idProducto = pi.idProducto INNER JOIN Grupos AS g ON pg.idGrupo = g.idGrupo INNER JOIN " _
            & " GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo WHERE gi.idIdioma = @ididioma AND pi.idIdioma = @ididioma " _
            & " AND p.eliminado = 0 AND g.eliminado = 0 AND g.idGrupo = @idGrupo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idGrupo", claveGrupo), New SqlParameter("@ididioma", claveIdioma)}

			Return Me.ExecuteDataSet(sql, parametros)
        End Function


        Public Function GetDSFull(ByVal claveIdioma As Integer, ByVal claveGrupo As Integer) As DataSet
            Dim sql As String = "SELECT pg.idProductoGrupo, pg.idGrupo, p.*, pi.ididioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags, " _
             & " isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=pg.idproducto and pf.principal=1), 'default.jpg') as imagen, " _
             & " isnull((select top 1 pp.precio from precios pp where pp.identidad=pg.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio, " _
            & " g.orden, gi.nombre AS grupo FROM ProductosGrupos AS pg INNER JOIN Productos AS p ON pg.idProducto = p.idProducto INNER JOIN " _
            & " ProductosIdiomas AS pi ON p.idProducto = pi.idProducto INNER JOIN Grupos AS g ON pg.idGrupo = g.idGrupo INNER JOIN " _
            & " GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo WHERE gi.idIdioma = @ididioma AND pi.idIdioma = @ididioma " _
            & " AND p.eliminado = 0 AND g.eliminado = 0 AND g.idGrupo = @idGrupo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idGrupo", claveGrupo), New SqlParameter("@ididioma", claveIdioma)}

            Return Me.ExecuteDataSet(sql, parametros)
        End Function


		Public Function GetDR(ByVal claveIdioma As Integer, ByVal claveGrupo As Integer) As SqlDataReader
            Dim sql As String = "SELECT pg.idProductoGrupo, pg.idGrupo, p.*, pi.ididioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags," _
             & " isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=pg.idproducto and pf.principal=1), 'default.jpg') as imagen, " _
             & " isnull((select top 1 pp.precio from precios pp where pp.identidad=pg.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio, " _
            & "g.orden, gi.nombre AS grupo FROM ProductosGrupos AS pg INNER JOIN Productos AS p ON pg.idProducto = p.idProducto INNER JOIN " _
    & " ProductosIdiomas AS pi ON p.idProducto = pi.idProducto INNER JOIN Grupos AS g ON pg.idGrupo = g.idGrupo INNER JOIN " _
    & " GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo WHERE gi.idIdioma = @ididioma AND pi.idIdioma = @ididioma " _
    & " AND p.eliminado = 0 AND g.eliminado = 0 AND g.idGrupo = @idGrupo"

            Dim parametros As SqlParameter() = {New SqlParameter("@idGrupo", claveGrupo), New SqlParameter("@ididioma", claveIdioma)}

			Return Me.ExecuteReader(sql, parametros)
		End Function

		Public Function GetDR(ByVal claveIdioma As Integer, ByVal textoBusqueda As String, ByVal claveGrupoExcluido As Integer) As SqlDataReader
			Dim sql As String = "SELECT * FROM (SELECT p.idProducto, p.clave, pf.imagen, pi.nombre, pi.descripcion, ISNULL(pg.idGrupo, 0) AS idGrupo " _
			 & "FROM Productos AS p INNER JOIN ProductosIdiomas AS pi ON p.idProducto = pi.idProducto INNER JOIN ProductosFotos AS pf " _
			 & "ON p.idProducto = pf.idProducto LEFT OUTER JOIN ProductosGrupos AS pg ON p.idProducto = pg.idProducto LEFT OUTER JOIN " _
			 & "GruposIdiomas AS gi ON pg.idGrupo = gi.idGrupo WHERE pi.idIdioma = @ididioma AND p.eliminado = 0 AND (pi.nombre LIKE '%' + @textoBusqueda + '%' " _
			 & "OR p.clave LIKE '%' + @textoBusqueda + '%')) AS aux WHERE idGrupo <> @idGrupo"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idGrupo", claveGrupoExcluido), _
			 New SqlParameter("@idIdioma", claveIdioma), _
			 New SqlParameter("@textoBusqueda", textoBusqueda)}

			Return Me.ExecuteReader(sql, parametros)
		End Function
	End Class

End Namespace
