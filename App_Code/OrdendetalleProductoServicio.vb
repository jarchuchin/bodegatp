Imports System.Data.SqlClient
Imports System.Data

Namespace tienda
    Public Class OrdendetalleProductoServicio
        Inherits DBObject

        Public idOrdendetalleProductoServicio As Integer
        Public idOrdendetalle As Integer
        Public idProducto As Integer
        Public idServicio As Integer
        Public cantidadProductos As Integer
        Public cantidadComponenteBase As Integer
        Public costoSetup As Decimal
        Public costoComponenteBase As Decimal
        Public total As Decimal
        Public numeroImpresion As Byte
        Public costoFinal As Decimal
        Public descuento As Decimal

        Public existe As Boolean = False

        Sub New()
        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "SELECT * FROM OrdenesdetallesProductosServicios WHERE idOrdendetalleProductoServicio=@idOrdendetalleProductoServicio"
            Dim params As SqlParameter() = {New SqlParameter("@idOrdendetalleProductoServicio", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idOrdendetalleProductoServicio = CInt(dr("idOrdendetalleProductoServicio"))
                Me.idOrdendetalle = CInt(dr("idOrdendetalle"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.idServicio = CInt(dr("idServicio"))
                Me.cantidadProductos = CInt(dr("cantidadProductos"))
                Me.cantidadComponenteBase = CInt(dr("cantidadComponenteBase"))
                Me.costoSetup = CDec(dr("costoSetup"))
                Me.costoComponenteBase = CDec(dr("costoComponenteBase"))
                Me.total = CDec(dr("total"))
                Me.numeroImpresion = CByte(dr("numeroImpresion"))
                Me.costoFinal = CDec(dr("costoFinal"))
                Me.descuento = CDec(dr("descuento"))

                Me.existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveOrdendetalle As Integer, ByVal claveProducto As Integer, ByVal claveServicio As Integer, Optional ByVal impresion As Byte = 1)
            Dim sql As String = "SELECT * FROM OrdenesdetallesProductosServicios WHERE idOrdendetalle=@idOrdendetalle AND idProducto=@idProducto " _
             & "AND idServicio = @idServicio AND numeroImpresion = @numeroImpresion"
            Dim params As SqlParameter() = { _
             New SqlParameter("@idOrdendetalle", claveOrdendetalle), _
             New SqlParameter("@idProducto", claveProducto), _
             New SqlParameter("@idServicio", claveServicio), _
             New SqlParameter("@numeroImpresion", impresion)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idOrdendetalleProductoServicio = CInt(dr("idOrdendetalleProductoServicio"))
                Me.idOrdendetalle = CInt(dr("idOrdendetalle"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.idServicio = CInt(dr("idServicio"))
                Me.cantidadProductos = CInt(dr("cantidadProductos"))
                Me.cantidadComponenteBase = CInt(dr("cantidadComponenteBase"))
                Me.costoSetup = CDec(dr("costoSetup"))
                Me.costoComponenteBase = CDec(dr("costoComponenteBase"))
                Me.total = CDec(dr("total"))
                Me.numeroImpresion = CByte(dr("numeroImpresion"))
                Me.costoFinal = CDec(dr("costoFinal"))
                Me.descuento = CDec(dr("descuento"))

                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim sql As String = "INSERT INTO OrdenesdetallesProductosServicios (idOrdendetalle, idProducto, idServicio, cantidadProductos, cantidadComponenteBase, " _
             & "costoSetup, costoComponenteBase, total, numeroImpresion, costoFinal, descuento) VALUES (@idOrdendetalle, @idProducto, @idServicio, @cantidadProductos, @cantidadComponenteBase, @costoSetup, " _
             & "@costoComponenteBase, @total, @numeroImpresion, @costoFinal, @descuento)"

            Dim params As SqlParameter() = { _
              New SqlParameter("@idOrdendetalle", idOrdendetalle), _
              New SqlParameter("@idProducto", idProducto), _
              New SqlParameter("@idServicio", idServicio), _
              New SqlParameter("@cantidadProductos", cantidadProductos), _
              New SqlParameter("@cantidadComponenteBase", cantidadComponenteBase), _
              New SqlParameter("@costoSetup", costoSetup), _
              New SqlParameter("@costoComponenteBase", costoComponenteBase), _
              New SqlParameter("@total", total), _
              New SqlParameter("@numeroImpresion", Me.numeroImpresion), _
              New SqlParameter("@costoFinal", Me.costoFinal), _
              New SqlParameter("@descuento", Me.descuento)}

            Me.idOrdendetalleProductoServicio = Me.ExecuteNonQuery(sql, params, True)

            Me.existe = True
            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "UPDATE OrdenesdetallesProductosServicios SET cantidadProductos=@cantidadProductos, " _
             & "cantidadComponenteBase=@cantidadComponenteBase, costoSetup=@costoSetup, costoComponenteBase=@costoComponenteBase, " _
             & "total=@total, costoFinal=@costoFinal, descuento=@descuento WHERE idOrdendetalleProductoServicio=@idOrdendetalleProductoServicio"

            Dim params As SqlParameter() = { _
              New SqlParameter("@cantidadProductos", cantidadProductos), _
              New SqlParameter("@cantidadComponenteBase", cantidadComponenteBase), _
              New SqlParameter("@costoSetup", costoSetup), _
              New SqlParameter("@costoComponenteBase", costoComponenteBase), _
              New SqlParameter("@total", total), _
              New SqlParameter("@idOrdendetalleProductoServicio", idOrdendetalleProductoServicio), _
              New SqlParameter("@costoFinal", Me.costoFinal), _
              New SqlParameter("@descuento", Me.descuento)}

            Me.ExecuteNonQuery(sql, params)

            Return 1
        End Function


        Public Function Remove() As Integer
            Dim queryString As String = "DELETE OrdenesdetallesProductosServicios WHERE idOrdendetalleProductoServicio=@idOrdendetalleProductoServicio"
            Dim parametro As SqlParameter() = {New SqlParameter("@idOrdendetalleProductoServicio", Me.idOrdendetalleProductoServicio)}

            Return Me.ExecuteNonQuery(queryString, parametro)
        End Function

        Public Function Remove(ByVal claveOrdenDetalle As Integer) As Integer
            Dim queryString As String = "DELETE OrdenesdetallesProductosServicios WHERE idOrdendetalle=@idOrdendetalle"
            Dim parametros As SqlParameter() = {New SqlParameter("@idOrdendetalle", claveOrdenDetalle)}

            Return Me.ExecuteNonQuery(queryString, parametros)

        End Function

        Public Function Remove(ByVal claveOrdendetalle As Integer, ByVal claveProducto As Integer) As Decimal
            Dim cantidadEliminada As Decimal = getTotalServicios(claveOrdendetalle, claveProducto)

            Dim queryString As String = "DELETE OrdenesdetallesProductosServicios WHERE idOrdendetalle=@idOrdendetalle AND idProducto = @idProducto"
            Dim parametros As SqlParameter() = {New SqlParameter("@idOrdendetalle", claveOrdendetalle), New SqlParameter("@idProducto", claveProducto)}

            Me.ExecuteNonQuery(queryString, parametros)

            Return cantidadEliminada
        End Function

        Public Function Remove(ByVal claveOrdendetalle As Integer, ByVal claveProducto As Integer, ByVal impresion As Byte) As Decimal
            Dim cantidadEliminada As Decimal = getTotalServicios(claveOrdendetalle, claveProducto, impresion)

            Dim queryString As String = "DELETE OrdenesdetallesProductosServicios WHERE idOrdendetalle=@idOrdendetalle AND idProducto = @idProducto " _
             & "AND numeroImpresion = @numeroImpresion"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idOrdendetalle", claveOrdendetalle), _
             New SqlParameter("@idProducto", claveProducto), _
             New SqlParameter("@numeroImpresion", impresion)}

            Me.ExecuteNonQuery(queryString, parametros)

            Return cantidadEliminada
        End Function

        Public Function GetDS(ByVal claveOrdenDetalle As Integer) As DataSet
            Dim sql As String = "select s.*, d.idorden from OrdenesdetallesProductosServicios s, ordenesdetalles d where  s.idOrdenDetalle=d.idOrdendetalle and s.idOrdenDetalle = @idOrdenDetalle"
            Dim parametro As SqlParameter() = {New SqlParameter("@idOrdenDetalle", claveOrdenDetalle)}

            Return Me.ExecuteDataSet(sql, parametro)
        End Function

        Public Function GetDR(ByVal claveOrdenDetalle As Integer) As SqlDataReader
            Dim sql As String = "select s.*, d.idorden from OrdenesdetallesProductosServicios s, ordenesdetalles d where  s.idOrdenDetalle=d.idOrdendetalle and s.idOrdenDetalle = @idOrdenDetalle"
            Dim parametro As SqlParameter() = {New SqlParameter("@idOrdenDetalle", claveOrdenDetalle)}

            Return Me.ExecuteReader(sql, parametro)
        End Function


        Public Function Count(ByVal claveOrdenDetalle As Integer) As Integer
            Dim sql As String = "select count(idOrdenDetalleProductoServicio) as num from OrdenesdetallesProductosServicios s where  s.idOrdenDetalle = @idOrdenDetalle"
            Dim parametro As SqlParameter() = {New SqlParameter("@idOrdenDetalle", claveOrdenDetalle)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, parametro)
            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso
        End Function


        Public Function getTotalServicios(ByVal claveOrdenDetalle As Integer) As Decimal
            Dim sql As String = "select sum(total) as num  from OrdenesdetallesProductosServicios where idOrdenDetalle = @idOrdenDetalle"
            Dim parametro As SqlParameter() = {New SqlParameter("@idOrdenDetalle", claveOrdenDetalle)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, parametro)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function

        Public Function getTotalServiciosDescuentos(ByVal claveOrdenDetalle As Integer) As Decimal
            Dim sql As String = "select sum(descuento) as num  from OrdenesdetallesProductosServicios where idOrdenDetalle = @idOrdenDetalle"
            Dim parametro As SqlParameter() = {New SqlParameter("@idOrdenDetalle", claveOrdenDetalle)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, parametro)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso

        End Function


        Public Function GetTotalServicios(ByVal claveOrdendetalle As Integer, ByVal claveProducto As Integer) As Decimal
            Dim queryString As String = "SELECT SUM(total) as suma FROM OrdenesdetallesProductosServicios WHERE idOrdendetalle=@idOrdendetalle AND idProducto=@idProducto"
            Dim parametros As SqlParameter() = {New SqlParameter("@idOrdendetalle", claveOrdendetalle), New SqlParameter("@idProducto", claveProducto)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim suma As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("suma")) Then
                    suma = CDec(dr("suma"))
                End If
            End If
            dr.Close()

            Return suma
        End Function

        Public Function GetTotalServicios(ByVal claveOrdendetalle As Integer, ByVal claveProducto As Integer, ByVal impresion As Byte) As Decimal
            Dim queryString As String = "SELECT SUM(total) as suma FROM OrdenesdetallesProductosServicios WHERE idOrdendetalle=@idOrdendetalle AND idProducto=@idProducto " _
             & "AND numeroImpresion = @numeroImpresion"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idOrdendetalle", claveOrdendetalle), _
             New SqlParameter("@idProducto", claveProducto), _
             New SqlParameter("@numeroImpresion", impresion)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim suma As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("suma")) Then
                    suma = CDec(dr("suma"))
                End If
            End If

            dr.Close()

            Return suma
        End Function


     

        Public Function GrabaOrdendetalleProductoServicio(ByRef objOrdenDetalle As tienda.OrdenDetalle, ByVal idServicio As Integer, ByVal selected As Boolean, _
         ByVal impresion As Byte, ByVal cantidadComponenteBase As Integer) As Decimal

            Dim objOPS As New tienda.OrdendetalleProductoServicio(objOrdenDetalle.idOrdendetalle, objOrdenDetalle.idProducto, idServicio, impresion)

            If selected Then

                If Not objOPS.existe Then
                    objOPS.idOrdendetalle = objOrdenDetalle.idOrdendetalle
                    objOPS.idProducto = objOrdenDetalle.idProducto
                    objOPS.idServicio = idServicio
                    objOPS.numeroImpresion = impresion
                End If

                objOPS.cantidadProductos = objOrdenDetalle.cantidad
                objOPS.cantidadComponenteBase = cantidadComponenteBase

                Dim objProductoServicio As New tienda.ProductoServicio(objOrdenDetalle.idProducto, idServicio)
                If objProductoServicio.existe Then
                    objOPS.costoSetup = objProductoServicio.costoSetup
                    objOPS.costoComponenteBase = objProductoServicio.precioComponenteBase
                Else
                    Dim objServicio As New tienda.Servicio(idServicio)
                    objOPS.costoSetup = objServicio.costoSetup
                    objOPS.costoComponenteBase = objServicio.precioComponenteBase
                End If

                objOPS.total = (objOPS.cantidadProductos * objOPS.cantidadComponenteBase * objOPS.costoComponenteBase) + objOPS.costoSetup

                If objOPS.existe Then
                    objOPS.Update()
                Else
                    objOPS.Add()
                End If

                Return objOPS.total
            Else
                If objOPS.existe Then
                    Return objOPS.total
                Else
                    Return 0
                End If
            End If

        End Function

        Public Function GetListaImpresiones(ByVal claveOrdendetalle As Integer, ByVal claveProducto As Integer) As SqlDataReader
            Dim queryString As String = "SELECT DISTINCT numeroImpresion FROM OrdenesdetallesProductosServicios WHERE idOrdendetalle = @idOrdendetalle " _
             & "AND idProducto = @idProducto ORDER BY numeroImpresion"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idOrdendetalle", claveOrdendetalle), _
             New SqlParameter("@idProducto", claveProducto)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function getOrdenDetalleProductoServicio(ByVal claveOrdendetalleProductoServicio As Integer) As DataSet
            Dim queryString As String = "SELECT* FROM OrdenesdetallesProductosServicios WHERE idOrdendetalleProductoServicio=@idOrdendetalleProductoServicio"
            Dim parametros As SqlParameter() = {New SqlParameter("@idOrdendetalleProductoServicio", claveOrdendetalleProductoServicio)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        '=========================== 20091222 ==============================================
        Public Function GetDetallesServicios(ByVal claveOrdendetalle As Integer, ByVal claveIdioma As Integer) As SqlDataReader
            Dim queryString As String = "SELECT odps.cantidadComponenteBase, odps.costoSetup, odps.costoComponenteBase, odps.total, odps.numeroImpresion, " _
             & "si.nombre AS servicio, odps.cantidadProductos FROM OrdenesdetallesProductosServicios AS odps INNER JOIN ServiciosIdiomas AS si " _
             & "ON odps.idServicio = si.idServicio WHERE odps.idOrdendetalle = @idOrdendetalle AND si.idIdioma = @idIdioma"

            Dim parametro As SqlParameter() = {New SqlParameter("@idOrdenDetalle", claveOrdendetalle), New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteReader(queryString, parametro)
        End Function

        '=========================================== 2010 ============================= START
        Public Function GetServiciosCotizados(ByVal claveOrdendetalle As Integer, ByVal claveIdioma As Integer) As SqlDataReader
            Dim querystring As String = "SELECT si.nombre, ods.CantidadComponenteBase, si.componenteBase FROM OrdenesdetallesProductosServicios AS ods INNER JOIN " _
             & "ServiciosIdiomas AS si ON ods.idServicio = si.idServicio WHERE ods.idOrdendetalle = @idOrdenDetalle AND si.idIdioma = @idIdioma"
            Dim parametros As SqlParameter() = {New SqlParameter("@idOrdendetalle", claveOrdendetalle), New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteReader(querystring, parametros)
        End Function
        '=========================================== 2010 ============================= END

        '================================== 20091222 =========================
        Public Function UpdateCantidadServicios(ByVal claveOrdendetalle As Integer, ByVal claveProducto As Integer, ByVal nuevaCantidadProductos As Integer) As Decimal
            Dim queryString As String = "UPDATE OrdenesdetallesProductosServicios SET idOrdendetalle=@idOrdenDetalle, cantidadProductos=@cantidadProductos, " _
             & "total= (@cantidadProductos * cantidadComponenteBase * costoComponenteBase) + costoSetup WHERE idOrdendetalle=@idOrdendetalle AND idProducto=@idProducto"

            Dim parametros As SqlParameter() = { _
              New SqlParameter("@idOrdendetalle", claveOrdendetalle), _
              New SqlParameter("@idProducto", claveProducto), _
              New SqlParameter("@cantidadProductos", nuevaCantidadProductos)}

            Me.ExecuteNonQuery(queryString, parametros)

            Return getTotalServicios(claveOrdendetalle, claveProducto)
        End Function
    End Class

End Namespace
