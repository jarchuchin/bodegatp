
Imports System.Data
Imports System.Data.SqlClient


Namespace tienda

    Public Class DepositoVenta
        Inherits DBObject


        Public idDepositoVenta As Integer
        Public idOrden As Integer
        Public Fecha As Date
        Public Factura As String
        Public Cliente As String
        Public Sucursal As String
        Public Referencia As String
        Public Monto As Decimal
        Public Eliminado As Boolean
        Public ValidadoPor As Integer
        Public TipoDeposito As String
        Public Estatus As String
        Public idComprobante As Integer = 0
        Public idDeposito As Integer = 0

        Public SolicitaFactura As String = ""

        Public Imagen As String = ""

        Public existe As Boolean = False

        Sub New()

        End Sub


        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from depositosVentas where idDepositoVenta=@idDepositoVenta"
            Dim params As SqlParameter() = {New SqlParameter("@idDepositoVenta", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idDepositoVenta = CInt(dr("idDepositoVenta"))
                Me.idOrden = CInt(dr("idOrden"))
                Me.Fecha = CDate(dr("Fecha"))
                Me.Factura = dr("Factura")
                Me.Cliente = dr("Cliente")
                Me.Sucursal = dr("Sucursal")
                Me.Referencia = dr("Referencia")
                Me.Monto = CDec(dr("Monto"))
                Me.Eliminado = CBool(dr("eliminado"))
                If Convert.IsDBNull(dr("ValidadoPor")) Then
                    Me.ValidadoPor = 0
                Else
                    Me.ValidadoPor = CInt(dr("ValidadoPor"))
                End If

                If Convert.IsDBNull(dr("TipoDeposito")) Then
                    Me.TipoDeposito = ""
                Else
                    Me.TipoDeposito = dr("TipoDeposito")
                End If
                If Convert.IsDBNull(dr("Estatus")) Then
                    Me.Estatus = ""
                Else
                    Me.Estatus = dr("Estatus")
                End If
                If Convert.IsDBNull(dr("idComprobante")) Then
                    Me.idComprobante = 0
                Else
                    Me.idComprobante = CInt(dr("idComprobante"))
                End If
                If Not Convert.IsDBNull(dr("Imagen")) Then
                    Me.Imagen = dr("Imagen")
                End If
                If Not Convert.IsDBNull(dr("idDeposito")) Then
                    Me.idDeposito = CInt(dr("idDeposito"))
                End If
                If Not Convert.IsDBNull(dr("SolicitaFactura")) Then
                    Me.SolicitaFactura = dr("SolicitaFactura")
                End If
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveAutorizacion As String, claveEntrada As Integer)
            Dim sql As String = "select * from depositosVentas where Referencia=@Referencia"
            Dim params As SqlParameter() = {New SqlParameter("@Referencia", claveAutorizacion)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idDepositoVenta = CInt(dr("idDepositoVenta"))
                Me.idOrden = CInt(dr("idOrden"))
                Me.Fecha = CDate(dr("Fecha"))
                Me.Factura = dr("Factura")
                Me.Cliente = dr("Cliente")
                Me.Sucursal = dr("Sucursal")
                Me.Referencia = dr("Referencia")
                Me.Monto = CDec(dr("Monto"))
                Me.Eliminado = CBool(dr("eliminado"))
                If Convert.IsDBNull(dr("ValidadoPor")) Then
                    Me.ValidadoPor = 0
                Else
                    Me.ValidadoPor = CInt(dr("ValidadoPor"))
                End If

                If Convert.IsDBNull(dr("TipoDeposito")) Then
                    Me.TipoDeposito = ""
                Else
                    Me.TipoDeposito = dr("TipoDeposito")
                End If
                If Convert.IsDBNull(dr("Estatus")) Then
                    Me.Estatus = ""
                Else
                    Me.Estatus = dr("Estatus")
                End If
                If Convert.IsDBNull(dr("idComprobante")) Then
                    Me.idComprobante = 0
                Else
                    Me.idComprobante = CInt(dr("idComprobante"))
                End If
                If Not Convert.IsDBNull(dr("Imagen")) Then
                    Me.Imagen = dr("Imagen")
                End If
                If Not Convert.IsDBNull(dr("idDeposito")) Then
                    Me.idDeposito = CInt(dr("idDeposito"))
                End If
                If Not Convert.IsDBNull(dr("SolicitaFactura")) Then
                    Me.SolicitaFactura = dr("SolicitaFactura")
                End If
                Me.existe = True
            End If
            dr.Close()

        End Sub


        Public Function Add() As Integer
            Dim sql As String = "insert into depositosVentas (idOrden, Fecha, Factura, Cliente, Sucursal, Referencia, Monto, eliminado, ValidadoPor, TipoDeposito, Estatus, idComprobante, Imagen, idDeposito, SolicitaFactura) values (@idOrden, @Fecha, @Factura, @Cliente, @Sucursal, @Referencia, @Monto, @eliminado, @ValidadoPor, @TipoDeposito, @Estatus, @idComprobante, @Imagen, @idDeposito, @SolicitaFactura)"
            Dim params As SqlParameter() = {
 New SqlParameter("@idOrden", Me.idOrden),
 New SqlParameter("@Fecha", Me.Fecha),
 New SqlParameter("@Factura", Me.Factura),
 New SqlParameter("@Cliente", Me.Cliente),
 New SqlParameter("@Sucursal", Me.Sucursal),
 New SqlParameter("@Referencia", Me.Referencia),
 New SqlParameter("@Monto", Me.Monto),
 New SqlParameter("@eliminado", Me.Eliminado),
 New SqlParameter("@ValidadoPor", Me.ValidadoPor),
 New SqlParameter("@TipoDeposito", Me.TipoDeposito),
 New SqlParameter("@Estatus", Me.Estatus),
            New SqlParameter("@idComprobante", Me.idComprobante),
            New SqlParameter("@Imagen", Me.Imagen),
            New SqlParameter("@idDeposito", Me.idDeposito),
            New SqlParameter("@SolicitaFactura", Me.SolicitaFactura)}

            Me.idDepositoVenta = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1


        End Function

        Public Function Update() As Integer
            Dim sql As String = "Update depositosVentas set idOrden=@idOrden, Fecha=@Fecha, Factura=@Factura, Cliente=@Cliente, Sucursal=@Sucursal, Referencia=@Referencia, Monto=@Monto, Eliminado=@Eliminado, ValidadoPor=@ValidadoPor, TipoDeposito=@TipoDeposito, Estatus=@Estatus, idComprobante=@idComprobante, Imagen=@Imagen, idDeposito=@idDeposito, SolicitaFactura=@SolicitaFactura where idDepositoVenta=@idDepositoVenta"

            Dim params As SqlParameter() = {
New SqlParameter("@idOrden", Me.idOrden),
New SqlParameter("@Fecha", Me.Fecha),
New SqlParameter("@Factura", Me.Factura),
New SqlParameter("@Cliente", Me.Cliente),
New SqlParameter("@Sucursal", Me.Sucursal),
New SqlParameter("@Referencia", Me.Referencia),
New SqlParameter("@Monto", Me.Monto),
New SqlParameter("@idDepositoVenta", Me.idDepositoVenta),
New SqlParameter("@Eliminado", Me.Eliminado),
 New SqlParameter("@ValidadoPor", Me.ValidadoPor),
 New SqlParameter("@TipoDeposito", Me.TipoDeposito),
 New SqlParameter("@Estatus", Me.Estatus),
            New SqlParameter("@idComprobante", Me.idComprobante),
            New SqlParameter("@Imagen", Me.Imagen),
            New SqlParameter("@idDeposito", Me.idDeposito),
            New SqlParameter("@SolicitaFactura", Me.SolicitaFactura)}


            Return Me.ExecuteNonQuery(sql, params)
        End Function

        Public Function Remove() As Integer
            Me.Eliminado = True
            Return Me.Update()
        End Function

        Public Function GetDS() As DataSet

            Dim sql As String = "select d.*, o.proyectoEnTramiteClave, u.nombre + ' ' + u.apellidos as nombreCompleto from depositosVentas d, ordenes o, userprofiles u  where o.idOrden=d.idOrden and u.idUserProfile=o.tempid and  d.eliminado=0 and d.Estatus='No registrado' order by d.fecha desc "
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function
        Public Function GetDS(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataSet
            claveFechaHasta = claveFechaHasta.AddDays(1)

            Dim sql As String = "select d.*, o.proyectoEnTramiteClave, u.nombre + ' ' + u.apellidos as nombreCompleto from depositosVentas d, ordenes o, userprofiles u  where o.idOrden=d.idOrden and u.idUserProfile=o.tempid and  d.eliminado=0 and d.Estatus='No registrado' and d.Fecha >= @FechaDesde and d.Fecha < @FechaHasta  order by d.fecha desc"
            Dim params As SqlParameter() = {New SqlParameter("@FechaDesde", claveFechaDesde), New SqlParameter("@FechaHasta", claveFechaHasta)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetDSOrden(ByVal claveOrden As Integer) As DataSet
            Dim sql As String = "select d.*, o.proyectoentramiteclave from depositosVentas d, ordenes o  where o.idOrden=d.idOrden and d.eliminado=0 and d.idOrden=@idOrden"
            Dim params As SqlParameter() = {
New SqlParameter("@idOrden", claveOrden)}
            Return Me.ExecuteDataSet(sql, params)


        End Function

        Public Function GetDSOrdenTodos(ByVal claveOrden As Integer) As DataSet
            Dim sql As String = "select d.*, o.proyectoentramiteclave from depositosVentas d, ordenes o  where o.idOrden=d.idOrden and d.idOrden=@idOrden and d.estatus='No registrado'"
            Dim params As SqlParameter() = {
New SqlParameter("@idOrden", claveOrden)}
            Return Me.ExecuteDataSet(sql, params)


        End Function

        Public Function GetTotalDepositos(ByVal claveOrden As Integer) As Decimal
            Dim sql As String = "select sum(d.monto) as num from depositosVentas d  where d.eliminado=0 and d.idOrden=@idOrden"
            Dim params As SqlParameter() = {
New SqlParameter("@idOrden", claveOrden)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function

        Public Function GetDepositosSinAsignar() As DataSet
            Dim sql As String = "select * from depositosVentas where idComprobante = 0 order by fecha asc"
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function

        Public Function GetDepositosFacturables(claveorden As Integer) As DataSet
            Dim sql As String = "select * from depositosventas where idOrden=@idOrden and Estatus='Registrado' and idDeposito>0 and SolicitaFactura<>'' and eliminado=0"
            Dim params As SqlParameter() = {
New SqlParameter("@idOrden", claveorden)}
            Return Me.ExecuteDataSet(sql, params)

        End Function


    End Class


End Namespace
