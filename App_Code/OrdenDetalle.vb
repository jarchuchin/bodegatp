Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Math


Namespace tienda


    Public Class OrdenDetalle
        Inherits DBObject


        Public idOrdendetalle As Integer
        Public idOrden As Integer
        Public idProducto As Integer
        Public cantidad As Integer
        Public costoUnitario As Decimal
        Public total As Decimal
        Public costoEnvio As Decimal
        Public descuento As Decimal
        Public color As String
        Public costoFinal As Decimal

        Public Logotipo As String = String.Empty
        Public Ancho As String = String.Empty
        Public Largo As String = String.Empty
        Public MetodoImpresion As String = String.Empty
        Public Autorizado As Boolean = False
        Public AutorizadoFecha As DateTime = Date.MinValue
        Public Pantone1 As String = String.Empty
        Public Pantone2 As String = String.Empty
        Public Pantone3 As String = String.Empty
        Public Pantone4 As String = String.Empty
        Public EntroTaller As Boolean = False
        Public EntroTallerFecha As DateTime = Date.MinValue
        Public SalirTaller As Boolean = False
        Public SalirTallerFecha As DateTime = Date.MinValue
        Public idMaquina As Integer = 0
        Public imagen As String = String.Empty
        Public vector As String = String.Empty
        Public responsable As Integer = 0
        Public observacionesTaller As String = String.Empty

        Public imagen2 As String = String.Empty
        Public imagen3 As String = String.Empty

        Public vector2 As String = String.Empty
        Public vector3 As String = String.Empty

        Public merma As Integer = 0
        Public mermaMotivo As String = String.Empty
        Public fechaRegistro As DateTime = Date.MinValue

        Public mermaObservacion As String = ""

        Public Tipo As String = "Orden"

        Public existe As Boolean = False

        Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT* FROM Ordenesdetalles WHERE idOrdendetalle = @idOrdendetalle"
            Dim parametros As SqlParameter() = {New SqlParameter("@idOrdendetalle", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idOrdendetalle = CInt(dr("idOrdendetalle"))
                Me.idOrden = CInt(dr("idOrden"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.cantidad = CInt(dr("cantidad"))
                Me.costoUnitario = Round(CDec(dr("costoUnitario")), 2)
                Me.total = Round(CDec(dr("total")), 2)
                Me.costoEnvio = Round(CDec(dr("costoEnvio")), 2)
                Me.descuento = Round(CDec(dr("descuento")), 2)
                Me.total = Round(CDec(dr("total")), 2)
                Me.color = dr("color")
                Me.costoFinal = Round(CDec(dr("costoFinal")), 2)
                If Not Convert.IsDBNull(dr("Logotipo")) Then
                    Me.Logotipo = dr("Logotipo")
                End If
                If Not Convert.IsDBNull(dr("Ancho")) Then
                    Me.Ancho = dr("Ancho")
                End If
                If Not Convert.IsDBNull(dr("Largo")) Then
                    Me.Largo = dr("Largo")
                End If
                If Not Convert.IsDBNull(dr("MetodoImpresion")) Then
                    Me.MetodoImpresion = dr("MetodoImpresion")
                End If
                If Not Convert.IsDBNull(dr("Autorizado")) Then
                    Me.Autorizado = CBool(dr("Autorizado"))
                End If
                If Not Convert.IsDBNull(dr("AutorizadoFecha")) Then
                    Me.AutorizadoFecha = CType(dr("AutorizadoFecha"), DateTime)
                End If
                If Not Convert.IsDBNull(dr("Pantone1")) Then
                    Me.Pantone1 = dr("Pantone1")
                End If
                If Not Convert.IsDBNull(dr("Pantone2")) Then
                    Me.Pantone2 = dr("Pantone2")
                End If
                If Not Convert.IsDBNull(dr("Pantone3")) Then
                    Me.Pantone3 = dr("Pantone3")
                End If
                If Not Convert.IsDBNull(dr("Pantone4")) Then
                    Me.Pantone4 = dr("Pantone4")
                End If
                If Not Convert.IsDBNull(dr("EntroTaller")) Then
                    Me.EntroTaller = CBool(dr("EntroTaller"))
                End If
                If Not Convert.IsDBNull(dr("EntroTallerFecha")) Then
                    Me.EntroTallerFecha = CType(dr("EntroTallerFecha"), DateTime)
                End If
                If Not Convert.IsDBNull(dr("SalirTaller")) Then
                    Me.SalirTaller = CBool(dr("SalirTaller"))
                End If
                If Not Convert.IsDBNull(dr("SalirTallerFecha")) Then
                    Me.SalirTallerFecha = CType(dr("SalirTallerFecha"), DateTime)
                End If
                If Not Convert.IsDBNull(dr("idMaquina")) Then
                    Me.idMaquina = CInt(dr("idMaquina"))
                End If
                If Not Convert.IsDBNull(dr("imagen")) Then
                    Me.imagen = dr("imagen")
                End If
                If Not Convert.IsDBNull(dr("vector")) Then
                    Me.vector = dr("vector")
                End If

                If Not Convert.IsDBNull(dr("responsable")) Then
                    Me.responsable = CInt(dr("responsable"))
                End If
                If Not Convert.IsDBNull(dr("observacionesTaller")) Then
                    Me.observacionesTaller = dr("observacionesTaller")
                End If

                If Not Convert.IsDBNull(dr("imagen2")) Then
                    Me.imagen2 = dr("imagen2")
                End If
                If Not Convert.IsDBNull(dr("imagen3")) Then
                    Me.imagen3 = dr("imagen3")
                End If
                If Not Convert.IsDBNull(dr("vector2")) Then
                    Me.vector2 = dr("vector2")
                End If
                If Not Convert.IsDBNull(dr("vector3")) Then
                    Me.vector3 = dr("vector3")
                End If

                If Not Convert.IsDBNull(dr("merma")) Then
                    Me.merma = CInt(dr("merma"))
                End If
                If Not Convert.IsDBNull(dr("mermaMotivo")) Then
                    Me.mermaMotivo = dr("mermaMotivo")
                End If
                If Not Convert.IsDBNull(dr("fechaRegistro")) Then
                    Me.fechaRegistro = CDate(dr("fechaRegistro"))
                End If
                If Not Convert.IsDBNull(dr("Tipo")) Then
                    Me.Tipo = dr("Tipo")
                End If
                If Not Convert.IsDBNull(dr("mermaObservacion")) Then
                    Me.mermaObservacion = dr("mermaObservacion")
                End If
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveOrden As Integer, ByVal claveProducto As Integer)
            Dim queryString As String = "SELECT* FROM Ordenesdetalles WHERE idOrden=@idOrden AND idProducto = @idProducto"
            Dim parametros As SqlParameter() = {New SqlParameter("@idOrden", claveOrden), New SqlParameter("@idProducto", claveProducto)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idOrdendetalle = CInt(dr("idOrdendetalle"))
                Me.idOrden = CInt(dr("idOrden"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.cantidad = CInt(dr("cantidad"))
                Me.costoUnitario = Round(CDec(dr("costoUnitario")), 2)
                Me.total = Round(CDec(dr("total")), 2)
                Me.costoEnvio = Round(CDec(dr("costoEnvio")), 2)
                Me.descuento = Round(CDec(dr("descuento")), 2)
                Me.total = Round(CDec(dr("total")), 2)
                Me.color = dr("color")
                Me.costoFinal = Round(CDec(dr("costoFinal")), 2)
                If Not Convert.IsDBNull(dr("Logotipo")) Then
                    Me.Logotipo = dr("Logotipo")
                End If
                If Not Convert.IsDBNull(dr("Ancho")) Then
                    Me.Ancho = dr("Ancho")
                End If
                If Not Convert.IsDBNull(dr("Largo")) Then
                    Me.Largo = dr("Largo")
                End If
                If Not Convert.IsDBNull(dr("MetodoImpresion")) Then
                    Me.MetodoImpresion = dr("MetodoImpresion")
                End If
                If Not Convert.IsDBNull(dr("Autorizado")) Then
                    Me.Autorizado = CBool(dr("Autorizado"))
                End If
                If Not Convert.IsDBNull(dr("AutorizadoFecha")) Then
                    Me.AutorizadoFecha = CType(dr("AutorizadoFecha"), DateTime)
                End If
                If Not Convert.IsDBNull(dr("Pantone1")) Then
                    Me.Pantone1 = dr("Pantone1")
                End If
                If Not Convert.IsDBNull(dr("Pantone2")) Then
                    Me.Pantone2 = dr("Pantone2")
                End If
                If Not Convert.IsDBNull(dr("Pantone3")) Then
                    Me.Pantone3 = dr("Pantone3")
                End If
                If Not Convert.IsDBNull(dr("Pantone4")) Then
                    Me.Pantone4 = dr("Pantone4")
                End If
                If Not Convert.IsDBNull(dr("EntroTaller")) Then
                    Me.EntroTaller = CBool(dr("EntroTaller"))
                End If
                If Not Convert.IsDBNull(dr("EntroTallerFecha")) Then
                    Me.EntroTallerFecha = CType(dr("EntroTallerFecha"), DateTime)
                End If
                If Not Convert.IsDBNull(dr("SalirTaller")) Then
                    Me.SalirTaller = CBool(dr("SalirTaller"))
                End If
                If Not Convert.IsDBNull(dr("SalirTallerFecha")) Then
                    Me.SalirTallerFecha = CType(dr("SalirTallerFecha"), DateTime)
                End If
                If Not Convert.IsDBNull(dr("idMaquina")) Then
                    Me.idMaquina = CInt(dr("idMaquina"))
                End If
                If Not Convert.IsDBNull(dr("imagen")) Then
                    Me.imagen = dr("imagen")
                End If
                If Not Convert.IsDBNull(dr("vector")) Then
                    Me.vector = dr("vector")
                End If

                If Not Convert.IsDBNull(dr("responsable")) Then
                    Me.responsable = CInt(dr("responsable"))
                End If
                If Not Convert.IsDBNull(dr("observacionesTaller")) Then
                    Me.observacionesTaller = dr("observacionesTaller")
                End If

                If Not Convert.IsDBNull(dr("imagen2")) Then
                    Me.imagen2 = dr("imagen2")
                End If
                If Not Convert.IsDBNull(dr("imagen3")) Then
                    Me.imagen3 = dr("imagen3")
                End If
                If Not Convert.IsDBNull(dr("vector2")) Then
                    Me.vector2 = dr("vector2")
                End If
                If Not Convert.IsDBNull(dr("vector3")) Then
                    Me.vector3 = dr("vector3")
                End If

                If Not Convert.IsDBNull(dr("merma")) Then
                    Me.merma = CInt(dr("merma"))
                End If
                If Not Convert.IsDBNull(dr("mermaMotivo")) Then
                    Me.mermaMotivo = dr("mermaMotivo")
                End If
                If Not Convert.IsDBNull(dr("fechaRegistro")) Then
                    Me.fechaRegistro = CDate(dr("fechaRegistro"))
                End If
                If Not Convert.IsDBNull(dr("Tipo")) Then
                    Me.Tipo = dr("Tipo")
                End If
                If Not Convert.IsDBNull(dr("mermaObservacion")) Then
                    Me.mermaObservacion = dr("mermaObservacion")
                End If
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim sql As String = "INSERT INTO OrdenesDetalles (idOrden, idProducto, cantidad, costoUnitario, total, costoEnvio, descuento, color, costoFinal, Logotipo, Ancho, Largo, MetodoImpresion, Autorizado, AutorizadoFecha, Pantone1, Pantone2, Pantone3, Pantone4, EntroTaller, EntroTallerFecha, SalirTaller, SalirTallerFecha, idMaquina, imagen, vector, responsable, observacionesTaller, imagen2, imagen3, vector2, vector3, merma, mermaMotivo, fechaRegistro, Tipo, mermaObservacion) VALUES (@idOrden, " _
             & "@idProducto, @cantidad, @costoUnitario, @total, @costoEnvio, @descuento, @color, @costoFinal, @Logotipo, @Ancho, @Largo, @MetodoImpresion, @Autorizado, @AutorizadoFecha, @Pantone1, @Pantone2, @Pantone3, @Pantone4, @EntroTaller, @EntroTallerFecha, @SalirTaller, @SalirTallerFecha, @idMaquina, @imagen, @vector, @responsable, @observacionesTaller, @imagen2, @imagen3, @vector2, @vector3, @merma, @mermaMotivo, @fechaRegistro, @Tipo, @mermaObservacion)"

            Dim params As SqlParameter() = {
             New SqlParameter("@idOrden", Me.idOrden),
             New SqlParameter("@idProducto", Me.idProducto),
             New SqlParameter("@cantidad", Me.cantidad),
             New SqlParameter("@costoUnitario", Round(Me.costoUnitario, 2)),
             New SqlParameter("@total", Round(Me.total, 2)),
             New SqlParameter("@costoEnvio", Round(Me.costoEnvio, 2)),
             New SqlParameter("@descuento", Round(Me.descuento, 2)),
             New SqlParameter("@color", Me.color),
             New SqlParameter("@costoFinal", Round(Me.costoFinal, 2)),
             New SqlParameter("@Logotipo", Me.Logotipo),
             New SqlParameter("@Ancho", Me.Ancho),
             New SqlParameter("@Largo", Me.Largo),
             New SqlParameter("@MetodoImpresion", Me.MetodoImpresion),
             New SqlParameter("@Autorizado", Me.Autorizado),
             New SqlParameter("@AutorizadoFecha", Me.AutorizadoFecha),
             New SqlParameter("@Pantone1", Me.Pantone1),
             New SqlParameter("@Pantone2", Me.Pantone2),
             New SqlParameter("@Pantone3", Me.Pantone3),
             New SqlParameter("@Pantone4", Me.Pantone4),
             New SqlParameter("@EntroTaller", Me.EntroTaller),
            New SqlParameter("@EntroTallerFecha", Me.EntroTallerFecha),
             New SqlParameter("@SalirTaller", Me.SalirTaller),
             New SqlParameter("@SalirTallerFecha", Me.SalirTallerFecha),
             New SqlParameter("@idMaquina", Me.idMaquina),
             New SqlParameter("@imagen", Me.imagen),
             New SqlParameter("@vector", Me.vector),
             New SqlParameter("@responsable", Me.responsable),
             New SqlParameter("@observacionesTaller", Me.observacionesTaller),
             New SqlParameter("@imagen2", Me.imagen2),
             New SqlParameter("@imagen3", Me.imagen3),
             New SqlParameter("@vector2", Me.vector2),
             New SqlParameter("@vector3", Me.vector3),
             New SqlParameter("@merma", Me.merma),
             New SqlParameter("@mermaMotivo", Me.mermaMotivo),
             New SqlParameter("@fechaRegistro", Me.fechaRegistro),
             New SqlParameter("@Tipo", Me.Tipo),
             New SqlParameter("@mermaObservacion", Me.mermaObservacion)}

            If Me.AutorizadoFecha = Date.MinValue Then
                params(14).Value = DBNull.Value
            End If
            If Me.EntroTallerFecha = Date.MinValue Then
                params(20).Value = DBNull.Value
            End If
            If Me.SalirTallerFecha = Date.MinValue Then
                params(22).Value = DBNull.Value
            End If
            If Me.fechaRegistro = Date.MinValue Then
                params(34).Value = DBNull.Value
            End If

            Me.idOrdendetalle = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True

            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "UPDATE OrdenesDetalles SET cantidad=@cantidad, costoUnitario=@costoUnitario, total=@total, costoEnvio=@costoEnvio, " _
             & "descuento=@descuento, color=@color, costoFinal=@costoFinal, Logotipo=@Logotipo, Ancho=@Ancho, Largo=@Largo, MetodoImpresion=@MetodoImpresion, Autorizado=@Autorizado, AutorizadoFecha=@AutorizadoFecha, Pantone1=@Pantone1, Pantone2=@Pantone2, Pantone3=@Pantone3, Pantone4=@Pantone4, EntroTaller=@EntroTaller, EntroTallerFecha=@EntroTallerFecha, SalirTaller=@SalirTaller, SalirTallerFecha=@SalirTallerFecha, idMaquina=@idMaquina, imagen=@imagen, vector=@vector, responsable=@responsable, observacionesTaller=@observacionesTaller, imagen2=@imagen2, imagen3=@imagen3, vector2=@vector2, vector3=@vector3, merma=@merma, mermaMotivo=@mermaMotivo, fechaRegistro=@fechaRegistro, Tipo=@Tipo, mermaObservacion=@mermaObservacion  WHERE idOrdendetalle=@idOrdendetalle"


            Dim params As SqlParameter() = {
             New SqlParameter("@idOrdendetalle", Me.idOrdendetalle),
               New SqlParameter("@cantidad", Me.cantidad),
             New SqlParameter("@costoUnitario", Round(Me.costoUnitario, 2)),
             New SqlParameter("@total", Round(Me.total, 2)),
             New SqlParameter("@costoEnvio", Round(Me.costoEnvio, 2)),
             New SqlParameter("@descuento", Round(Me.descuento, 2)),
             New SqlParameter("@color", Me.color),
             New SqlParameter("@costoFinal", Round(Me.costoFinal, 2)),
             New SqlParameter("@Logotipo", Me.Logotipo),
             New SqlParameter("@Ancho", Me.Ancho),
             New SqlParameter("@Largo", Me.Largo),
             New SqlParameter("@MetodoImpresion", Me.MetodoImpresion),
             New SqlParameter("@Autorizado", Me.Autorizado),
             New SqlParameter("@AutorizadoFecha", Me.AutorizadoFecha),
             New SqlParameter("@Pantone1", Me.Pantone1),
             New SqlParameter("@Pantone2", Me.Pantone2),
             New SqlParameter("@Pantone3", Me.Pantone3),
             New SqlParameter("@Pantone4", Me.Pantone4),
             New SqlParameter("@EntroTaller", Me.EntroTaller),
            New SqlParameter("@EntroTallerFecha", Me.EntroTallerFecha),
             New SqlParameter("@SalirTaller", Me.SalirTaller),
             New SqlParameter("@SalirTallerFecha", Me.SalirTallerFecha),
             New SqlParameter("@idMaquina", Me.idMaquina),
             New SqlParameter("@imagen", Me.imagen),
             New SqlParameter("@vector", Me.vector),
             New SqlParameter("@responsable", Me.responsable),
             New SqlParameter("@observacionesTaller", Me.observacionesTaller),
             New SqlParameter("@imagen2", Me.imagen2),
             New SqlParameter("@imagen3", Me.imagen3),
             New SqlParameter("@vector2", Me.vector2),
             New SqlParameter("@vector3", Me.vector3),
             New SqlParameter("@merma", Me.merma),
             New SqlParameter("@mermaMotivo", Me.mermaMotivo),
             New SqlParameter("@fechaRegistro", Me.fechaRegistro),
             New SqlParameter("@Tipo", Me.Tipo),
             New SqlParameter("@mermaObservacion", Me.mermaObservacion)}


            If Me.AutorizadoFecha = Date.MinValue Then
                params(13).Value = DBNull.Value
            End If
            If Me.EntroTallerFecha = Date.MinValue Then
                params(19).Value = DBNull.Value
            End If
            If Me.SalirTallerFecha = Date.MinValue Then
                params(21).Value = DBNull.Value
            End If
            If Me.fechaRegistro = Date.MinValue Then
                params(33).Value = DBNull.Value
            End If

            Me.ExecuteNonQuery(sql, params)

            ActualizaServicios(Me.idOrdendetalle, Me.cantidad)

            Return 1
        End Function



        Public Function Remove() As Integer
            Dim queryString As String = "DELETE FROM OrdenesDetalles WHERE idOrdendetalle = @idOrdendetalle"
            Dim parametros As SqlParameter() = {New SqlParameter("@idOrdendetalle", Me.idOrdendetalle)}

            Me.ExecuteNonQuery(queryString, parametros)
            Dim myodps As New OrdendetalleProductoServicio
            myodps.Remove(Me.idOrdendetalle)
            Dim myo As New tienda.Orden(Me.idOrden)
            myo.Update()

            Return 1
        End Function

        

        Public Function getDR(ByVal claveOrden As Integer) As SqlDataReader
            Dim myq As String = "select o.* from OrdenesDetalles o  where  idOrden = @idOrden and Tipo='Orden'"
            Dim parameters As SqlParameter() = {New SqlParameter("@idOrden", SqlDbType.Int)}

            parameters(0).Value = claveOrden
            Return Me.ExecuteReader(myq, parameters)
        End Function

		Public Function getDS(ByVal claveOrden As Integer) As DataSet
            Dim myq As String = "select o.* from OrdenesDetalles o  where  idOrden = @idOrden and Tipo='Orden'"
			Dim parameters As SqlParameter() = {New SqlParameter("@idOrden", SqlDbType.Int)}

			parameters(0).Value = claveOrden
			Return Me.ExecuteDataSet(myq, parameters)

		End Function


		'======================= 2010 ============================= START
		Public Function GetDR(ByVal claveOrden As Integer, ByVal claveIdioma As Integer) As SqlDataReader
			Dim queryString As String = "SELECT p.idProducto, p.clave, pi.nombre, p.ventaMinima, od.costoUnitario AS precio, od.total, od.idOrden, od.cantidad, " _
			 & "od.descuento, od.costoFinal, ISNULL(aux2.servicios, 0) AS servicios, od.idOrdendetalle, od.color FROM Productos AS p INNER JOIN ProductosIdiomas AS pi ON p.idProducto = pi.idProducto " _
			 & "AND pi.idIdioma = @idIdioma INNER JOIN Ordenesdetalles AS od ON p.idProducto = od.idProducto AND od.idOrden = @idOrden LEFT OUTER JOIN " _
			 & "(SELECT idOrdendetalle, SUM(total) AS servicios FROM OrdenesdetallesProductosServicios GROUP BY idOrdendetalle) AS aux2 " _
			 & "ON od.idOrdendetalle = aux2.idOrdendetalle ORDER BY od.idOrdendetalle"

			Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idOrden", claveOrden)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function
		'======================= 2010 ============================= END





		Public Function Count(ByVal claveProducto As Integer) As Integer
            Dim myq As String = "select count(o.idOrdendetalle) as num from OrdenesDetalles o where idProducto = @idProducto and Tipo='Orden'"
			Dim parameters As SqlParameter() = {New SqlParameter("@idProducto", SqlDbType.Int)}

			parameters(0).Value = claveProducto
			Dim dr As SqlDataReader = Me.ExecuteReader(myq, parameters)
			Dim num As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    num = CType(dr("num"), Integer)
                End If
            End If
            dr.Close()

            Return num
		End Function

		Private Function ActualizaServicios(ByVal claveOrdenDetalle As Integer, ByVal claveCantidad As Integer) As Integer
			Dim myodps As New tienda.OrdendetalleProductoServicio
			Dim drservicios As SqlDataReader = myodps.GetDR(claveOrdenDetalle)
			Dim myodpsTemp As tienda.OrdendetalleProductoServicio
			Dim myservicio As tienda.Servicio
			Do While drservicios.Read
				myodpsTemp = New tienda.OrdendetalleProductoServicio(CInt(drservicios("idOrdenDetalleProductoServicio")))
				myservicio = New Servicio(CInt(drservicios("idServicio")))
				If claveCantidad < myservicio.cantidadMinima Then
					myodpsTemp.cantidadProductos = myservicio.cantidadMinima
				Else
					myodpsTemp.cantidadProductos = cantidad
				End If
				myodpsTemp.cantidadComponenteBase = 1
				myodpsTemp.costoSetup = myservicio.costoSetup
				myodpsTemp.costoComponenteBase = myservicio.precioComponenteBase
				If myodpsTemp.costoFinal > myservicio.precioComponenteBase Then
					myodpsTemp.costoFinal = myservicio.precioComponenteBase
				End If
				Dim descuento As Decimal = (myodpsTemp.costoComponenteBase - myodpsTemp.costoFinal) * myodpsTemp.cantidadProductos
				myodpsTemp.descuento = descuento
				myodpsTemp.total = myodpsTemp.costoSetup + (myodpsTemp.costoFinal * myodpsTemp.cantidadProductos)
				myodpsTemp.numeroImpresion = 0
				myodpsTemp.Update()
			Loop
			drservicios.Close()





		End Function

		Public Function getOrdenDetalle(ByVal claveOrdendetalle As Integer) As DataSet
			Dim queryString As String = "SELECT* FROM Ordenesdetalles WHERE idOrdendetalle=@idOrdendetalle"
			Dim parametros As SqlParameter() = {New SqlParameter("@idOrdendetalle", claveOrdendetalle)}

			Return Me.ExecuteDataSet(queryString, parametros)
		End Function

		'============================ 2010 ========================== START
		Public Function GetDRColores(ByVal claveOrden As Integer, ByVal claveProducto As Integer) As SqlDataReader
            Dim queryString As String = "SELECT * FROM Ordenesdetalles WHERE idOrden=@idOrden AND idProducto = @idProducto and Tipo='Orden'"
			Dim parametros As SqlParameter() = {New SqlParameter("@idOrden", claveOrden), New SqlParameter("@idProducto", claveProducto)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function
		'============================ 2010 ========================== END


	End Class

End Namespace
