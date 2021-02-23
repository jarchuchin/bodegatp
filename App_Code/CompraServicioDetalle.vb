Imports System.Data
Imports System.Data.SqlClient


Namespace tienda


    Public Class CompraServicioDetalle
        Inherits DBObject

        Public idCompraServicioDetalle As Integer
        Public idCompraServicio As Integer
        Public idOrdenDetalle As Integer
        Public Costo As Decimal
        Public CostoSetup As Decimal
        Public Margen As Decimal
        Public MargenPorcentaje As Decimal
        Public MargenDiferencia As Decimal
        Public TotalconDescuento As Decimal
        Public TotalsinDescuento As Decimal
        Public Estatus As String
        Public DescripcionExtra As String
        Public Observaciones As String = ""
        Public Entregado As Boolean = False
        Public EntregadoFecha As DateTime
        Public EntregadoUsuario As Integer = 0
        Public EntregadoObservaciones As String = ""

        Public TallerFechaIngreso As DateTime
        Public TallerLogo As String = ""
        Public TallerFechaTerminado As DateTime
        Public TallerImpresor As String = ""
        Public TallerModoImpresion As String = ""
        Public TallerTintas As String = ""


        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from ComprasServiciosDetalles where idCompraServicioDetalle=@idCompraServicioDetalle"
            Dim params As SqlParameter() = { _
New SqlParameter("@idCompraServicioDetalle", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idCompraServicioDetalle = CInt(dr("idCompraServicioDetalle"))
                Me.idCompraServicio = CInt(dr("idCompraServicio"))
                Me.idOrdenDetalle = CInt(dr("idOrdenDetalle"))
                Me.CostoSetup = CDec(dr("CostoSetup"))
                Me.Costo = CDec(dr("Costo"))
                Me.Margen = CDec(dr("Margen"))
                Me.MargenPorcentaje = CDec(dr("MargenPorcentaje"))
                Me.MargenDiferencia = CDec(dr("MargenDiferencia"))
                Me.TotalconDescuento = CDec(dr("TotalconDescuento"))
                Me.TotalsinDescuento = CDec(dr("TotalsinDescuento"))
                Me.Estatus = dr("Estatus")
                Me.DescripcionExtra = dr("DescripcionExtra")
                If Convert.IsDBNull(dr("Observaciones")) Then
                    Me.Observaciones = ""
                Else
                    Me.Observaciones = dr("Observaciones")
                End If
                If Convert.IsDBNull(dr("Entregado")) Then
                    Me.Entregado = False
                Else
                    Me.Entregado = CType(dr("Entregado"), Boolean)
                End If
                If Convert.IsDBNull(dr("EntregadoFecha")) Then
                    Me.EntregadoFecha = DateTime.MinValue
                Else
                    Me.EntregadoFecha = CType(dr("EntregadoFecha"), DateTime)
                End If
                If Convert.IsDBNull(dr("EntregadoUsuario")) Then
                    Me.EntregadoUsuario = 0
                Else
                    Me.EntregadoUsuario = CType(dr("EntregadoUsuario"), Integer)
                End If
                If Convert.IsDBNull(dr("EntregadoObservaciones")) Then
                    Me.EntregadoObservaciones = ""
                Else
                    Me.EntregadoObservaciones = dr("EntregadoObservaciones")
                End If


                If Convert.IsDBNull(dr("TallerFechaIngreso")) Then
                    Me.TallerFechaIngreso = DateTime.MinValue
                Else
                    Me.TallerFechaIngreso = CType(dr("TallerFechaIngreso"), DateTime)
                End If
                If Convert.IsDBNull(dr("TallerLogo")) Then
                    Me.TallerLogo = ""
                Else
                    Me.TallerLogo = dr("TallerLogo")
                End If
                If Convert.IsDBNull(dr("TallerFechaTerminado")) Then
                    Me.TallerFechaTerminado = DateTime.MinValue
                Else
                    Me.TallerFechaTerminado = CType(dr("TallerFechaTerminado"), DateTime)
                End If
                If Convert.IsDBNull(dr("TallerImpresor")) Then
                    Me.TallerImpresor = ""
                Else
                    Me.TallerImpresor = dr("TallerImpresor")
                End If
                If Convert.IsDBNull(dr("TallerModoImpresion")) Then
                    Me.TallerModoImpresion = ""
                Else
                    Me.TallerModoImpresion = dr("TallerModoImpresion")
                End If
                If Convert.IsDBNull(dr("TallerTintas")) Then
                    Me.TallerTintas = ""
                Else
                    Me.TallerTintas = dr("TallerTintas")
                End If


                Me.existe = True
            End If
            dr.Close()
        End Sub


        Sub New(ByVal clavePrincipalOrdenDetalle As Integer, ByVal clave As Boolean)
            Dim sql As String = "select * from ComprasServiciosDetalles where idOrdenDetalle=@idOrdenDetalle"
            Dim params As SqlParameter() = { _
New SqlParameter("@idOrdenDetalle", clavePrincipalOrdenDetalle)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idCompraServicioDetalle = CInt(dr("idCompraServicioDetalle"))
                Me.idCompraServicio = CInt(dr("idCompraServicio"))
                Me.idOrdenDetalle = CInt(dr("idOrdenDetalle"))
                Me.Costo = CDec(dr("Costo"))
                Me.CostoSetup = CDec(dr("CostoSetup"))
                Me.Margen = CDec(dr("Margen"))
                Me.MargenPorcentaje = CDec(dr("MargenPorcentaje"))
                Me.MargenDiferencia = CDec(dr("MargenDiferencia"))
                Me.TotalconDescuento = CDec(dr("TotalconDescuento"))
                Me.TotalsinDescuento = CDec(dr("TotalsinDescuento"))
                Me.Estatus = dr("Estatus")
                Me.DescripcionExtra = dr("DescripcionExtra")
                If Convert.IsDBNull(dr("Observaciones")) Then
                    Me.Observaciones = ""
                Else
                    Me.Observaciones = dr("Observaciones")
                End If
                If Convert.IsDBNull(dr("Entregado")) Then
                    Me.Entregado = False
                Else
                    Me.Entregado = CType(dr("Entregado"), Boolean)
                End If
                If Convert.IsDBNull(dr("EntregadoFecha")) Then
                    Me.EntregadoFecha = DateTime.MinValue
                Else
                    Me.EntregadoFecha = CType(dr("EntregadoFecha"), DateTime)
                End If
                If Convert.IsDBNull(dr("EntregadoUsuario")) Then
                    Me.EntregadoUsuario = 0
                Else
                    Me.EntregadoUsuario = CType(dr("EntregadoUsuario"), Integer)
                End If
                If Convert.IsDBNull(dr("EntregadoObservaciones")) Then
                    Me.EntregadoObservaciones = ""
                Else
                    Me.EntregadoObservaciones = dr("EntregadoObservaciones")
                End If


                If Convert.IsDBNull(dr("TallerFechaIngreso")) Then
                    Me.TallerFechaIngreso = DateTime.MinValue
                Else
                    Me.TallerFechaIngreso = CType(dr("TallerFechaIngreso"), DateTime)
                End If
                If Convert.IsDBNull(dr("TallerLogo")) Then
                    Me.TallerLogo = ""
                Else
                    Me.TallerLogo = dr("TallerLogo")
                End If
                If Convert.IsDBNull(dr("TallerFechaTerminado")) Then
                    Me.TallerFechaTerminado = DateTime.MinValue
                Else
                    Me.TallerFechaTerminado = CType(dr("TallerFechaTerminado"), DateTime)
                End If
                If Convert.IsDBNull(dr("TallerImpresor")) Then
                    Me.TallerImpresor = ""
                Else
                    Me.TallerImpresor = dr("TallerImpresor")
                End If
                If Convert.IsDBNull(dr("TallerModoImpresion")) Then
                    Me.TallerModoImpresion = ""
                Else
                    Me.TallerModoImpresion = dr("TallerModoImpresion")
                End If
                If Convert.IsDBNull(dr("TallerTintas")) Then
                    Me.TallerTintas = ""
                Else
                    Me.TallerTintas = dr("TallerTintas")
                End If


                Me.existe = True
            End If

            dr.Close()
        End Sub


        Public Function Add() As Integer
            Dim sql As String = "insert into ComprasServiciosDetalles (idCompraServicio, idOrdenDetalle, Costo, CostoSetup, Margen, MargenPorcentaje, MargenDiferencia, TotalconDescuento, TotalsinDescuento, Estatus, DescripcionExtra, Observaciones, Entregado, EntregadoFecha, EntregadoUsuario, EntregadoObservaciones, TallerFechaIngreso, TallerLogo, TallerFechaTerminado, TallerImpresor, TallerModoImpresion, TallerTintas) values (@idCompraServicio, @idOrdenDetalle, @Costo, @CostoSetup, @Margen, @MargenPorcentaje, @MargenDiferencia, @TotalconDescuento, @TotalsinDescuento, @Estatus, @DescripcionExtra, @Observaciones, @Entregado, @EntregadoFecha, @EntregadoUsuario, @EntregadoObservaciones, @TallerFechaIngreso, @TallerLogo, @TallerFechaTerminado, @TallerImpresor, @TallerModoImpresion, @TallerTintas)"


            Dim params As SqlParameter() = { _
   New SqlParameter("@idCompraServicio", Me.idCompraServicio), _
   New SqlParameter("@idOrdenDetalle", Me.idOrdenDetalle), _
   New SqlParameter("@Costo", Me.Costo), _
   New SqlParameter("@CostoSetup", Me.CostoSetup), _
   New SqlParameter("@Margen", Me.Margen), _
   New SqlParameter("@MargenPorcentaje", Me.MargenPorcentaje), _
   New SqlParameter("@MargenDiferencia", Me.MargenDiferencia), _
   New SqlParameter("@TotalconDescuento", Me.TotalconDescuento), _
   New SqlParameter("@TotalsinDescuento", Me.TotalsinDescuento), _
   New SqlParameter("@DescripcionExtra", Me.DescripcionExtra), _
   New SqlParameter("@Estatus", Me.Estatus), _
   New SqlParameter("@Observaciones", Me.Observaciones), _
    New SqlParameter("@Entregado", Me.Entregado), _
    New SqlParameter("@EntregadoFecha", Me.EntregadoFecha), _
    New SqlParameter("@EntregadoUsuario", Me.EntregadoUsuario), _
    New SqlParameter("@EntregadoObservaciones", Me.EntregadoObservaciones), _
    New SqlParameter("@TallerFechaIngreso", Me.TallerFechaIngreso), _
    New SqlParameter("@TallerLogo", Me.TallerLogo), _
    New SqlParameter("@TallerFechaTerminado", Me.TallerFechaTerminado), _
    New SqlParameter("@TallerImpresor", Me.TallerImpresor), _
   New SqlParameter("@TallerModoImpresion", Me.TallerModoImpresion), _
   New SqlParameter("@TallerTintas", Me.TallerTintas)}

            If Me.EntregadoFecha = Date.MinValue Then
                params(13).Value = DBNull.Value
            End If
            If Me.TallerFechaIngreso = Date.MinValue Then
                params(16).Value = DBNull.Value
            End If
            If Me.TallerFechaTerminado = Date.MinValue Then
                params(18).Value = DBNull.Value
            End If


            Dim mycsd As New tienda.CompraServicioDetalle(Me.idOrdenDetalle, True)
            If mycsd.existe Then
                Me.idCompraServicioDetalle = mycsd.idCompraServicioDetalle
            Else
                Me.idCompraServicioDetalle = Me.ExecuteNonQuery(sql, params, True)
            End If


            Me.existe = True
            Return 1


        End Function

        Public Function Update() As Integer
            Dim sql As String = "Update ComprasServiciosDetalles set idCompraServicio=@idCompraServicio, idOrdenDetalle=@idOrdenDetalle, Costo=@Costo, CostoSetup=@CostoSetup, Margen=@Margen, MargenPorcentaje=@MargenPorcentaje, MargenDiferencia=@MargenDiferencia, TotalconDescuento=@TotalconDescuento, Estatus=@Estatus, DescripcionExtra=@DescripcionExtra, Observaciones=@Observaciones, Entregado=@Entregado, EntregadoFecha=@EntregadoFecha, EntregadoUsuario=@EntregadoUsuario, EntregadoObservaciones=@EntregadoObservaciones, TallerFechaIngreso=@TallerFechaIngreso, TallerLogo=@TallerLogo, TallerFechaTerminado=@TallerFechaTerminado, TallerImpresor=@TallerImpresor, TallerModoImpresion=@TallerModoImpresion, TallerTintas=@TallerTintas where idCompraServicioDetalle=@idCompraServicioDetalle"

            Dim params As SqlParameter() = { _
New SqlParameter("@idCompraServicio", Me.idCompraServicio), _
New SqlParameter("@idOrdenDetalle", Me.idOrdenDetalle), _
New SqlParameter("@Costo", Me.Costo), _
New SqlParameter("@CostoSetup", Me.CostoSetup), _
New SqlParameter("@Margen", Me.Margen), _
New SqlParameter("@MargenPorcentaje", Me.MargenPorcentaje), _
New SqlParameter("@MargenDiferencia", Me.MargenDiferencia), _
New SqlParameter("@TotalconDescuento", Me.TotalconDescuento), _
New SqlParameter("@TotalsinDescuento", Me.TotalsinDescuento), _
New SqlParameter("@Estatus", Me.Estatus), _
   New SqlParameter("@DescripcionExtra", Me.DescripcionExtra), _
New SqlParameter("@idCompraServicioDetalle", Me.idCompraServicioDetalle), _
   New SqlParameter("@Observaciones", Me.Observaciones), _
    New SqlParameter("@Entregado", Me.Entregado), _
    New SqlParameter("@EntregadoFecha", Me.EntregadoFecha), _
    New SqlParameter("@EntregadoUsuario", Me.EntregadoUsuario), _
    New SqlParameter("@EntregadoObservaciones", Me.EntregadoObservaciones), _
    New SqlParameter("@TallerFechaIngreso", Me.TallerFechaIngreso), _
    New SqlParameter("@TallerLogo", Me.TallerLogo), _
    New SqlParameter("@TallerFechaTerminado", Me.TallerFechaTerminado), _
    New SqlParameter("@TallerImpresor", Me.TallerImpresor), _
   New SqlParameter("@TallerModoImpresion", Me.TallerModoImpresion), _
   New SqlParameter("@TallerTintas", Me.TallerTintas)}

            If Me.EntregadoFecha = Date.MinValue Then
                params(14).Value = DBNull.Value
            End If
            If Me.TallerFechaIngreso = Date.MinValue Then
                params(17).Value = DBNull.Value
            End If
            If Me.TallerFechaTerminado = Date.MinValue Then
                params(19).Value = DBNull.Value
            End If

            Return Me.ExecuteNonQuery(sql, params, True)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete ComprasServiciosDetalles where idCompraServicioDetalle=@idCompraServicioDetalle"
            Dim params As SqlParameter() = { _
New SqlParameter("@idCompraServicioDetalle", Me.idCompraServicioDetalle)}

            Return Me.ExecuteNonQuery(sql, params)
        End Function

        Public Function GetDS(ByVal claveCompraServicio As Integer) As DataSet
            Dim sql As String = "select csd.*,odps.CantidadProductos, odps.idProducto, odps.idServicio , odps.costoFinal, odps.Total, odps.idOrdenDetalleProductoServicio, od.idOrden  from ComprasServiciosDetalles  csd , OrdenesDetallesProductosServicios odps, OrdenesDetalles od where csd.idOrdenDetalle=odps.idOrdenDetalleProductoServicio  and odps.idOrdenDetalle=od.idOrdenDetalle  and csd.idCompraServicio=@idCompraServicio order by od.idOrden desc"

            Dim params As SqlParameter() = { _
New SqlParameter("@idCompraServicio", claveCompraServicio)}

            Return Me.ExecuteDataSet(sql, params)


        End Function


        Public Function GetDR(ByVal claveCompraServicio As Integer) As SqlDataReader
            Dim sql As String = "select csd.*,odps.CantidadProductos, odps.idProducto, odps.idServicio , odps.costoFinal, odps.Total, odps.idOrdenDetalleProductoServicio, od.idOrden  " & _
"from ComprasServiciosDetalles  csd , OrdenesDetallesProductosServicios odps, OrdenesDetalles od " & _
"where csd.idOrdenDetalle=odps.idOrdenDetalleProductoServicio  and odps.idOrdenDetalle=od.idOrdenDetalle  and csd.idCompraServicio=@idCompraServicio order by od.idOrden desc"


            Dim params As SqlParameter() = { _
New SqlParameter("@idCompraServicio", claveCompraServicio)}

            Return Me.ExecuteReader(sql, params)


        End Function

        Public Function GetSumaCompra(ByVal claveCompraServicio As Integer) As Decimal
            Dim sql As String = "select sum(cd.totalcondescuento) as num from comprasServiciosdetalles cd where cd.idCompraServicio=@idCompraServicio"

            Dim params As SqlParameter() = { _
New SqlParameter("@idCompraServicio", claveCompraServicio)}

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



        Public Function GetDSListaServiciosEnTaller() As DataSet
            Dim sql As String = "select csd.*, odps.CantidadProductos, odps.idOrdenDetalle as claveOrden, od.idOrden,  o.proyectoEnTramiteClave, o.fechaCompromiso, o.tempid, pid.nombre as nombreProducto,  p.clave, si.nombre as nombreServicio, isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=p.idproducto and pf.principal=1), 'default.jpg') as imagen     from ComprasServiciosDetalles csd, OrdenesDetallesProductosServicios odps, OrdenesDetalles od, Ordenes o, ProductosIdiomas pid, Productos p, ServiciosIdiomas si  where odps.idOrdenDetalleProductoServicio=csd.idOrdenDetalle and odps.idOrdenDetalle=od.idOrdenDetalle and o.idOrden=od.idOrden  and pid.idProducto=od.idProducto and pid.idIdioma=1 and p.idProducto=pid.idProducto and si.idServicio=odps.idServicio and si.idIdioma=1 and csd.idCompraServicio = 0"

           
            Return Me.ExecuteDataSet(sql, Nothing)


        End Function


        



    End Class




End Namespace
