Imports System.Data
Imports System.Data.SqlClient


Namespace tienda


    Public Class CompraDetalle
        Inherits DBObject

        Public idCompraDetalle As Integer
        Public idCompra As Integer
        Public idOrdenDetalle As Integer
        Public Costo As Decimal
        Public Margen As Decimal
        Public MargenPorcentaje As Decimal
        Public MargenDiferencia As Decimal
        Public TotalconDescuento As Decimal
        Public TotalsinDescuento As Decimal
        Public Estatus As String
        Public DescripcionExtra As String = ""
        Public Observaciones As String = ""
        Public Entregado As Boolean = False
        Public EntregadoFecha As DateTime
        Public EntregadoUsuario As Integer = 0
        Public EntregadoObservaciones As String = ""

        Public Taller As String = ""
        Public CantidadRecibida As Integer

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from ComprasDetalles where idCompraDetalle=@idCompraDetalle"
            Dim params As SqlParameter() = { _
New SqlParameter("@idCompraDetalle", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idCompraDetalle = CInt(dr("idCompraDetalle"))
                Me.idCompra = CInt(dr("idCompra"))
                Me.idOrdenDetalle = CInt(dr("idOrdenDetalle"))
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

                If Not Convert.IsDBNull(dr("Taller")) Then
                    Me.Taller = dr("Taller")
                End If

                If Not Convert.IsDBNull(dr("CantidadRecibida")) Then
                    Me.CantidadRecibida = CInt(dr("CantidadRecibida"))
                End If

                Me.existe = True
            End If
            dr.Close()
        End Sub


        Sub New(ByVal clavePrincipalOrdenDetalle As Integer, ByVal clave As Boolean)
            Dim sql As String = "select * from ComprasDetalles where idOrdenDetalle=@idOrdenDetalle"
            Dim params As SqlParameter() = { _
New SqlParameter("@idOrdenDetalle", clavePrincipalOrdenDetalle)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idCompraDetalle = CInt(dr("idCompraDetalle"))
                Me.idCompra = CInt(dr("idCompra"))
                Me.idOrdenDetalle = CInt(dr("idOrdenDetalle"))
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

                If Not Convert.IsDBNull(dr("Taller")) Then
                    Me.Taller = dr("Taller")
                End If

                If Not Convert.IsDBNull(dr("CantidadRecibida")) Then
                    Me.CantidadRecibida = CInt(dr("CantidadRecibida"))
                End If

                Me.existe = True
            End If

            dr.Close()
        End Sub


        Public Function Add() As Integer
            Dim sql As String = "insert into comprasdetalles (idCompra, idOrdenDetalle, Costo, Margen, MargenPorcentaje, MargenDiferencia, TotalconDescuento, TotalsinDescuento, Estatus, DescripcionExtra, Observaciones, Entregado, EntregadoFecha, EntregadoUsuario, EntregadoObservaciones, Taller, CantidadRecibida) values (@idCompra, @idOrdenDetalle, @Costo, @Margen, @MargenPorcentaje, @MargenDiferencia, @TotalconDescuento, @TotalsinDescuento, @Estatus, @DescripcionExtra, @Observaciones, @Entregado, @EntregadoFecha, @EntregadoUsuario, @EntregadoObservaciones, @Taller, @CantidadRecibida)"


            Dim params As SqlParameter() = { _
   New SqlParameter("@idCompra", Me.idCompra), _
   New SqlParameter("@idOrdenDetalle", Me.idOrdenDetalle), _
   New SqlParameter("@Costo", Me.Costo), _
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
    New SqlParameter("@Taller", Me.Taller), _
    New SqlParameter("@CantidadRecibida", Me.CantidadRecibida)}


            If Me.EntregadoFecha = Date.MinValue Then
                params(12).Value = DBNull.Value
            End If

            Me.idCompraDetalle = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1


        End Function

        Public Function Update() As Integer
            Dim sql As String = "Update ComprasDetalles set idCompra=@idCompra, idOrdenDetalle=@idOrdenDetalle, Costo=@Costo, Margen=@Margen, MargenPorcentaje=@MargenPorcentaje, MargenDiferencia=@MargenDiferencia, TotalconDescuento=@TotalconDescuento, Estatus=@Estatus, DescripcionExtra=@DescripcionExtra, Observaciones=@Observaciones, Entregado=@Entregado, EntregadoFecha=@EntregadoFecha, EntregadoUsuario=@EntregadoUsuario, EntregadoObservaciones=@EntregadoObservaciones, Taller=@Taller, CantidadRecibida=@CantidadRecibida where idCompraDetalle=@idCompraDetalle"

            Dim params As SqlParameter() = { _
New SqlParameter("@idCompra", Me.idCompra), _
New SqlParameter("@idOrdenDetalle", Me.idOrdenDetalle), _
New SqlParameter("@Costo", Me.Costo), _
New SqlParameter("@Margen", Me.Margen), _
New SqlParameter("@MargenPorcentaje", Me.MargenPorcentaje), _
New SqlParameter("@MargenDiferencia", Me.MargenDiferencia), _
New SqlParameter("@TotalconDescuento", Me.TotalconDescuento), _
New SqlParameter("@TotalsinDescuento", Me.TotalsinDescuento), _
New SqlParameter("@Estatus", Me.Estatus), _
   New SqlParameter("@DescripcionExtra", Me.DescripcionExtra), _
New SqlParameter("@idCompraDetalle", Me.idCompraDetalle), _
   New SqlParameter("@Observaciones", Me.Observaciones), _
    New SqlParameter("@Entregado", Me.Entregado), _
    New SqlParameter("@EntregadoFecha", Me.EntregadoFecha), _
    New SqlParameter("@EntregadoUsuario", Me.EntregadoUsuario), _
    New SqlParameter("@EntregadoObservaciones", Me.EntregadoObservaciones), _
    New SqlParameter("@Taller", Me.Taller), _
    New SqlParameter("@CantidadRecibida", Me.CantidadRecibida)}

            If Me.EntregadoFecha = Date.MinValue Then
                params(13).Value = DBNull.Value
            End If



            Return Me.ExecuteNonQuery(sql, params, True)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete comprasdetalles where idCompraDetalle=@idCompraDetalle"
            Dim params As SqlParameter() = { _
New SqlParameter("@idCompraDetalle", Me.idCompraDetalle)}

            Return Me.ExecuteNonQuery(sql, params)
        End Function

        Public Function GetDS(ByVal claveCompra As Integer) As DataSet
            Dim sql As String = "select cd.*, od.cantidad, od.idProducto, od.idOrden, od.costoFinal  from ComprasDetalles cd, Ordenesdetalles od where cd.idOrdenDetalle=od.idOrdenDetalle and cd.idCompra=@idCompra"

            Dim params As SqlParameter() = { _
New SqlParameter("@idCompra", claveCompra)}

            Return Me.ExecuteDataSet(sql, params)


        End Function


        Public Function GetDR(ByVal claveCompra As Integer) As SqlDataReader
            Dim sql As String = "select cd.*, od.cantidad, od.idProducto, od.idOrden, od.costoFinal  from ComprasDetalles cd, Ordenesdetalles od where cd.idOrdenDetalle=od.idOrdenDetalle and cd.idCompra=@idCompra"

            Dim params As SqlParameter() = { _
New SqlParameter("@idCompra", claveCompra)}

            Return Me.ExecuteReader(sql, params)


        End Function


        Public Function GetDROrdenDetalle(ByVal claveidOrdenDetalle As Integer) As SqlDataReader
            Dim sql As String = "select cd.*, od.cantidad, od.idProducto, od.idOrden, od.costoFinal, c.Fecha, c.Entregado, c.FechaCompromiso, c.EntregadoFecha, c.EntregadoUsuario, c.EntregadoObservaciones, c.idFabricante, pi.Nombre  from ComprasDetalles cd, Ordenesdetalles od, Compras c, ProductosIdiomas pi where cd.idOrdenDetalle=od.idOrdenDetalle and cd.idCompra=c.idCompra and od.idProducto=pi.idProducto and pi.idIdioma=1 and cd.idOrdenDetalle=@idOrdenDetalle"

            Dim params As SqlParameter() = { _
New SqlParameter("@idOrdenDetalle", claveidOrdenDetalle)}

            Return Me.ExecuteReader(sql, params)


        End Function

        Public Function GetSumaCompra(ByVal claveCompra As Integer) As Decimal
            Dim sql As String = "select sum(cd.totalcondescuento) as num from comprasdetalles cd where cd.idCompra=@idCompra"

            Dim params As SqlParameter() = { _
New SqlParameter("@idCompra", claveCompra)}

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



        Public Function GetOrdenesDiferentesEnCompra(claveCompra As Integer) As SqlDataReader
            Dim sql As String = "select distinct  od.idOrden    from comprasdetalles  cd left outer join OrdenesDetalles od on cd.idOrdenDetalle = od.idOrdenDetalle where idCompra=@idCompra"
            Dim params As SqlParameter() = { _
New SqlParameter("@idCompra", claveCompra)}

            Return Me.ExecuteReader(sql, params)

        End Function

    End Class




End Namespace
