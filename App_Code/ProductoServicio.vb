Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace tienda
    Public Class ProductoServicio
        Inherits DBObject

        Public idProductoServicio As Integer
        Public idProducto As Integer
        Public idServicio As Integer
        Public precioComponenteBase As Decimal
        Public costoSetup As Decimal
        Public cantidadMinima As Integer
        Public precioCantidadMinima As Decimal
        Public existe As Boolean = False

        Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT* FROM ProductosServicios WHERE idProductoServicio=@idProductoServicio"
            Dim parametros As SqlParameter() = {New SqlParameter("@idProductoServicio", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idProductoServicio = CInt(dr("idProductoServicio"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.idServicio = CInt(dr("idServicio"))
                Me.precioComponenteBase = CDec(dr("precioComponenteBase"))
                Me.costoSetup = CDec(dr("costoSetup"))
                Me.cantidadMinima = CInt(dr("cantidadMinima"))
                Me.precioCantidadMinima = CDec(dr("precioCantidadMinima"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveProducto As Integer, ByVal claveServicio As Integer)
            Dim queryString As String = "SELECT* FROM ProductosServicios WHERE idProducto=@idProducto AND idServicio = @idServicio"
            Dim parametros As SqlParameter() = {New SqlParameter("@idProducto", claveProducto), New SqlParameter("@idServicio", claveServicio)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idProductoServicio = CInt(dr("idProductoServicio"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.idServicio = CInt(dr("idServicio"))
                Me.precioComponenteBase = CDec(dr("precioComponenteBase"))
                Me.costoSetup = CDec(dr("costoSetup"))
                Me.cantidadMinima = CInt(dr("cantidadMinima"))
                Me.precioCantidadMinima = CDec(dr("precioCantidadMinima"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO ProductosServicios (idProducto, idServicio, precioComponenteBase, costoSetup, cantidadMinima, precioCantidadMinima) " _
            & "VALUES (@idProducto, @idServicio, @precioComponenteBase, @costoSetup, @cantidadMinima, @precioCantidadMinima)"

            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idProducto", Me.idProducto), _
            New SqlParameter("@idServicio", Me.idServicio), _
             New SqlParameter("@precioComponenteBase", Me.precioComponenteBase), _
            New SqlParameter("@costoSetup", Me.costoSetup), _
            New SqlParameter("@cantidadMinima", Me.cantidadMinima), _
            New SqlParameter("@precioCantidadMinima", Me.precioCantidadMinima)}

            Me.idProductoServicio = Me.ExecuteNonQuery(queryString, parametros, True)
            Me.existe = True
            Return 1
        End Function

        Public Function Update() As Integer
            Dim queryString As String = "UPDATE ProductosServicios SET costoSetup=@costoSetup, precioComponenteBase=@precioComponenteBase, " _
            & "cantidadMinima=@cantidadMinima, precioCantidadMinima=@precioCantidadMinima WHERE idProductoServicio=@idProductoServicio"

            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idProductoServicio", Me.idProductoServicio), _
             New SqlParameter("@precioComponenteBase", Me.precioComponenteBase), _
            New SqlParameter("@costoSetup", Me.costoSetup), _
            New SqlParameter("@cantidadMinima", Me.cantidadMinima), _
            New SqlParameter("@precioCantidadMinima", Me.precioCantidadMinima)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Function Remove() As Integer
            Dim queryString As String = "DELETE FROM ProductosServicios WHERE idProductoServicio = @idProductoServicio"
            Dim parametros As SqlParameter() = {New SqlParameter("@idProductoServicio", Me.idProductoServicio)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Function Remove(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad) As Integer
            Dim queryString As String
            Select Case tipoDeEntidad
                Case TipoEntidad.Producto
                    queryString = "DELETE FROM ProductosServicios WHERE idProducto = @idEntidad"
                Case TipoEntidad.Servicio
                    queryString = "DELETE FROM ProductosServicios WHERE idServicio = @idEntidad"
                Case Else
                    Return 0
            End Select

            Dim parametros As SqlParameter() = {New SqlParameter("@idEntidad", claveEntidad)}
            Me.ExecuteNonQuery(queryString, parametros)

            Return 1
        End Function

        Public Function GetDR(ByVal claveProducto As Integer, ByVal claveIdioma As Integer) As SqlDataReader
            Dim queryString As String = "SELECT 1 as cantidadComponenteBase, aux.idProductoServicio, aux.idProducto, aux.idServicio, aux.costoSetup, aux.cantidadMinima, aux.precioCantidadMinima, si.nombre, sv.tipo, " _
             & "aux.precioComponenteBase, ISNULL(si.componenteBase, '') AS componenteBase FROM (SELECT 0 AS idProductoServicio, 0 AS idProducto, idServicio, costoSetup, cantidadMinima, " _
             & "precioCantidadMinima, precioComponenteBase FROM Servicios WHERE idServicio NOT IN (SELECT idServicio FROM ProductosServicios WHERE idProducto = @idProducto) " _
             & "UNION SELECT idProductoServicio, idProducto, idServicio, costoSetup, cantidadMinima, precioCantidadMinima, precioComponenteBase FROM ProductosServicios AS ps " _
             & "WHERE idProducto = @idProducto) AS aux INNER JOIN ServiciosIdiomas AS si ON aux.idServicio = si.idServicio AND si.idIdioma = @idIdioma INNER JOIN Servicios AS sv " _
             & "ON aux.idServicio = sv.idServicio ORDER BY aux.idServicio"

            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveProducto), New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteReader(queryString, params)
        End Function

        Public Function GetDR(ByVal claveOrdendetalle As Integer, ByVal claveProducto As Integer, ByVal claveIdioma As Integer, Optional ByVal impresion As Byte = 1) As SqlDataReader
            Dim queryString As String = "SELECT aux.idProducto, aux.idServicio, aux.costoSetup, aux.cantidadMinima, aux.precioCantidadMinima, si.nombre, sv.tipo, " _
             & "aux.precioComponenteBase, ISNULL(odps.idOrdendetalleProductoServicio, 0) AS idOrdendetalleProductoServicio, " _
             & "ISNULL(odps.cantidadComponenteBase, 1) AS cantidadComponenteBase FROM (SELECT 0 AS idProducto, idServicio, " _
             & "costoSetup, cantidadMinima, precioCantidadMinima, precioComponenteBase FROM Servicios WHERE idServicio NOT IN (SELECT idServicio FROM ProductosServicios " _
             & "WHERE idProducto = @idProducto) UNION SELECT idProducto, idServicio, costoSetup, cantidadMinima, precioCantidadMinima, precioComponenteBase " _
             & "FROM ProductosServicios AS ps WHERE idProducto = @idProducto) AS aux INNER JOIN ServiciosIdiomas AS si ON aux.idServicio = si.idServicio " _
             & "AND si.idIdioma = @idIdioma INNER JOIN Servicios AS sv ON aux.idServicio = sv.idServicio LEFT OUTER JOIN OrdenesdetallesProductosServicios AS odps " _
             & "ON odps.idProducto = @idProducto AND aux.idServicio = odps.idServicio AND odps.idOrdendetalle = @idOrdendetalle AND numeroImpresion = @numeroImpresion ORDER BY aux.idServicio"

            Dim params As SqlParameter() = { _
            New SqlParameter("@idOrdendetalle", claveOrdendetalle), _
            New SqlParameter("@idProducto", claveProducto), _
            New SqlParameter("@idIdioma", claveIdioma), _
            New SqlParameter("@numeroImpresion", impresion)}

            Return Me.ExecuteReader(queryString, params)
        End Function
    End Class
End Namespace
