Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class ProductoSeleccionado
        Inherits DBObject

        Public idProductoSeleccionado As Integer
        Public SessionID As String
        Public idProducto As Integer
        Public idUserProfile As Integer
        Public fecha As DateTime

        Public existe As Boolean = False

        Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from ProductosSeleccionados where idProductoSeleccionado=@idProductoSeleccionado"
            Dim params As SqlParameter() = {New SqlParameter("@idProductoSeleccionado", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idProductoSeleccionado = CInt(dr("idProductoSeleccionado"))
                Me.SessionID = dr("SessionID")
                Me.idProducto = CInt(dr("idProducto"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.fecha = CType(dr("fecha"), DateTime)
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveSession As String, ByVal claveProducto As Integer)
            Dim sql As String = "select * from ProductosSeleccionados where SessionID=@SessionID and idProducto=@idProducto"
            Dim params As SqlParameter() = {New SqlParameter("@SessionID", claveSession), New SqlParameter("@idProducto", claveProducto)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idProductoSeleccionado = CInt(dr("idProductoSeleccionado"))
                Me.SessionID = dr("SessionID")
                Me.idProducto = CInt(dr("idProducto"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.fecha = CType(dr("fecha"), DateTime)
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            'Dim sql As String = "INSERT INTO ProductosSeleccionados ( SessionID, idProducto, idUserProfile, fecha) VALUES (@SessionID, @idProducto, @idUserProfile, @fecha)"

            'Dim params As SqlParameter() = { _
            ' New SqlParameter("@SessionID", Me.SessionID), _
            ' New SqlParameter("@idProducto", Me.idProducto), _
            ' New SqlParameter("@idUserProfile", Me.idUserProfile), _
            ' New SqlParameter("@fecha", Date.Now)}

            'Dim mypstem As New tienda.ProductoSeleccionado(Me.SessionID, Me.idProducto)
            'If Not mypstem.existe Then
            '    Me.idProductoSeleccionado = Me.ExecuteNonQuery(sql, params, True)
            '    Me.existe = True
            'End If

            Return 1
        End Function

        Public Function GetDSSugeridos(ByVal claveproducto As Integer) As DataSet

            Dim sql As String = "select  top 50 ps.*, p.clave, pi.idIdioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags,  " & _
    "isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=ps.idproducto and pf.principal=1), 'default.jpg') as imagen,   " & _
    "isnull((select top 1 pp.precio from precios pp where pp.identidad=ps.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio  " & _
    "from ProductosSeleccionados ps, Productos p, ProductosIdiomas pi  " & _
    "where ps.idProducto=p.idProducto and p.idproducto=pi.idproducto and  p.eliminado=0 and p.online=1 and " & _
    "ps.idProducto<>@idproducto and " & _
    "ps.SessionID  in (select distinct px.SessionID  from ProductosSeleccionados px where px.idProducto = @idproducto)  ORDER BY NEWID()"

            Dim params As SqlParameter() = { _
            New SqlParameter("@idproducto", claveproducto)}

            Return Me.ExecuteDataSet(sql, params)

        End Function
    End Class


End Namespace