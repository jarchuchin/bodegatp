Imports System.Data
Imports System.Windows.Forms
Imports System.Math

Partial Class sec_grabarOrden
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If CInt(Session("idUserProfile")) > 0 Then
                Dim myup As New tienda.UserProfile(CInt(Session("idUserProfile")))
                Dim myorden As tienda.Orden
                If IsNothing(Session("idOrden")) Then
                    myorden = CreateOrden()
                    Session("idOrden") = myorden.idOrden
                Else

                    If CInt(Session("idOrden")) > 0 Then
                        myorden = New tienda.Orden(CInt(Session("idOrden")))
                    Else
                        myorden = CreateOrden()
                        Session("idOrden") = myorden.idOrden
                    End If
                End If

                crearDetalles(myorden.idOrden)

                '  Response.Flush()
                Response.Redirect("~/sec/compras.aspx?idOrden=" & myorden.idOrden)
            Else
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If


        End If
    End Sub


    Private Function crearDetalles(claveOrden As Integer) As Integer



        Dim mytabla As DataTable = CType(Session("tabla"), DataTable)
        Dim claveProducto As Integer = 0
        Dim objOrdendetalle As tienda.OrdenDetalle



        For Each mydr As DataRow In mytabla.Rows
            claveProducto = mydr.Item("idProducto")
            If claveProducto > 0 Then
                objOrdendetalle = New tienda.OrdenDetalle(claveOrden, claveProducto)
                objOrdendetalle.idOrden = claveOrden
                objOrdendetalle.idProducto = claveProducto
                objOrdendetalle.cantidad = CInt(mydr.Item("Cantidad"))
                objOrdendetalle.costoUnitario = Round(CDec(mydr.Item("costoUnitario")), 2)
                objOrdendetalle.total = Round(CDec(mydr.Item("total")), 2)
                objOrdendetalle.costoEnvio = 0
                objOrdendetalle.descuento = 0
                objOrdendetalle.color = mydr.Item("color")
                objOrdendetalle.costoFinal = Round(CDec(mydr.Item("costoFinal")), 2)
                If objOrdendetalle.existe Then
                    objOrdendetalle.Update()
                Else
                    objOrdendetalle.Add()
                End If
            End If

        Next

       

        Dim myo As New tienda.Orden(claveOrden)
        myo.Update()

        Return 1


    End Function


    Private Function CreateOrden() As tienda.Orden
        Dim objOrden As New tienda.Orden
        Dim myu As New tienda.UserProfile(CInt(Session("iduserProfile")))
        objOrden.idUserProfile = myu.idUserProfile
        objOrden.status = tienda.StatusOrden.AgregandoProductos
        objOrden.idTipoTarjeta = 0
        objOrden.numeroCuenta = String.Empty
        objOrden.mes = String.Empty
        objOrden.year = String.Empty
        objOrden.nombre = myu.nombre & " " & myu.apellidos
        objOrden.numeroExtra = String.Empty
        objOrden.nombreE = myu.nombre & " " & myu.apellidos
        objOrden.direccionE = String.Empty
        objOrden.ciudadE = String.Empty
        objOrden.idPaisE = 1
        objOrden.idEstadoE = myu.idEstado
        objOrden.cpE = ""
        objOrden.telefonoE = myu.telefono
        objOrden.subtotal = 0
        objOrden.impuesto = 0
        objOrden.costoEnvio = 0
        objOrden.descuento = 0
        objOrden.costoAdicional = 0
        objOrden.total = 0
        objOrden.tipoCambio = 0
        objOrden.totalDollar = 0
        objOrden.fechaOrden = Now
        objOrden.fechaUltimaActualizacion = Now
        objOrden.idTipoEnvio = 0
        objOrden.nombreF = myu.nombre & " " & myu.apellidos
        objOrden.rfc = String.Empty
        objOrden.direccionF = String.Empty
        objOrden.ciudadF = String.Empty
        objOrden.idPaisF = 1
        objOrden.idEstadoF = myu.idEstado
        objOrden.cpF = ""
        objOrden.telefonoF = ""
        objOrden.facturar = False
        objOrden.folio = 0
        objOrden.tipoPago = 0
        objOrden.respuesta = String.Empty
        objOrden.eliminado = False
        objOrden.tempid = ""
        objOrden.fechaEntrega = Date.Now.AddDays(10)
        objOrden.requiereFacturacion = False
        objOrden.NombreEmpresa = myu.nombreEmpresa
        objOrden.Observaciones = ""
        objOrden.Condiciones = ""
        objOrden.Descuentoservicios = 0
        objOrden.email = myu.email
        objOrden.proyectoEnTramite = False
        objOrden.proyectoEnTramiteClave = ""
        objOrden.proyectoEnTramiteFecha = Date.Now
        objOrden.fechaCompromiso = Date.Now.AddDays(10)
        objOrden.envioGuia = ""
        objOrden.envioFecha = Date.Now
        objOrden.mercanciaLista = False
        objOrden.mercanciaListaFecha = Date.Now
        objOrden.tempidFecha = Date.Now
        objOrden.costoExpress = 0
        objOrden.FormaContacto = "Orden"
        objOrden.ComoConocio = "Internet"
        objOrden.TipoCliente = "N/A"
        objOrden.TipoEvento = "N/A"
        objOrden.Add()

        Return objOrden
    End Function

End Class
