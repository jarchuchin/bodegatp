Imports System.Globalization
Imports System.Threading
Imports System.Data
Imports System.Data.SqlClient

Partial Class ProductoWizard
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("idioma")

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)


        MyBase.initializeculture()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not CInt(Session("idUserProfile")) > 0 Then
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If
		Catch ex As Exception
		End Try

		If Not IsPostBack Then
			Llenado()
		End If
    End Sub

    Sub Llenado()
     

        Dim claveProducto As Integer = Request("idProducto")

        Dim imagePath As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/gde/"

        'Imagen
        Dim objProductoFoto As New tienda.ProductoFoto(claveProducto, True)
        imgProducto.ImageUrl = imagePath & objProductoFoto.imagen

        'Datos producto
        Dim objProductoidioma As New tienda.ProductoIdioma(claveProducto, CInt(Session("idIdioma")))
        lblNombreProducto.Text = objProductoIdioma.nombre
        Page.Title = objProductoIdioma.nombre
        lblClave.Text = objProductoidioma.clave


        If Request("color") <> "" Then
            Dim myc As New tienda.Color(CInt(Request("color")))
            Dim mycc As New tienda.Codigocolor(myc.idCodigocolor)
            lblColor.Text = mycc.idioma1
        End If

        Dim myod As tienda.OrdenDetalle
        If Request("idOrdenDetalle") <> "" Then
            myod = New tienda.OrdenDetalle(CInt(Request("idOrdenDetalle")))
            lblCantidad.Text = myod.cantidad
            lblColor.Text = myod.color
        Else
            myod = New tienda.OrdenDetalle(crearOrdenYDetalles())
            lblCantidad.Text = myod.cantidad
            lblColor.Text = myod.color
        End If

        'temporal
        Response.Redirect("Compras.aspx?idOrden=" & myod.idOrden)

        lblCostoUnitario.Text = New tienda.Precio().GetPrecioUnitario(objProductoidioma.idProducto, tienda.TipoEntidad.Producto, CInt(Request("cantidad"))).ToString("c")


        Dim mysi As New tienda.ServicioIdioma()
        gridServicios.DataSource = mysi.GetDR(CInt(Session("idIdioma")), claveProducto)
        gridServicios.DataBind()

        btnGrabar.Visible = False

    End Sub





    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim claveorden As Integer = 0
        If Request.QueryString("idOrden") <> "" Then
            claveorden = CInt(Request.QueryString("idOrden"))
        Else
            claveorden = CInt(Session("idOrden"))
        End If


        If gridServicios.SelectedIndex > -1 Then


            Dim claveproducto As Integer = CInt(Request("idProducto"))

            Dim objOrdendetalle As New tienda.OrdenDetalle(claveorden, claveproducto)
            Dim idIdioma As Integer = 1
            Dim idProducto As Integer = claveproducto
            Dim cantidad As Integer = CInt(lblCantidad.Text)
            Dim data As DataKey = gridServicios.DataKeys(gridServicios.SelectedIndex)
            Dim cantidadComponenteBase As Integer = 1
            Dim vueltas As Integer = 1

            Try
                Dim row As GridViewRow = gridServicios.Rows(gridServicios.SelectedIndex)
                Dim dropCantidadComponente As DropDownList = CType(row.FindControl("dropCantidadComponente"), DropDownList)
                vueltas = CInt(dropCantidadComponente.SelectedValue)
            Catch ex As Exception
                vueltas = 1
            End Try

            Dim objServicioIdioma As New tienda.ServicioIdioma(CInt(data.Values("idServicio")), idIdioma)

            Dim i As Integer = 0

            For i = 0 To vueltas - 1
                Dim myodps As New tienda.OrdendetalleProductoServicio()
                myodps.idOrdendetalle = objOrdendetalle.idOrdendetalle
                myodps.idProducto = idProducto
                myodps.idServicio = objServicioIdioma.idServicio
                If cantidad < objServicioIdioma.cantidadMinima Then
                    myodps.cantidadProductos = objServicioIdioma.cantidadMinima
                Else
                    myodps.cantidadProductos = cantidad
                End If
                myodps.cantidadComponenteBase = cantidadComponenteBase
                myodps.costoSetup = objServicioIdioma.costoSetup
                myodps.costoComponenteBase = objServicioIdioma.precioComponenteBase
                myodps.costoFinal = myodps.costoComponenteBase
                myodps.descuento = 0
                myodps.total = myodps.costoSetup + (myodps.costoFinal * myodps.cantidadProductos)
                myodps.numeroImpresion = 0

                myodps.Add()
            Next


            Dim myo As New tienda.Orden(objOrdendetalle.idOrden)
            myo.Update()

            Response.Redirect("Compras.aspx?idOrden=" & claveorden)
         
        End If


    End Sub




    Private Function crearOrdenYDetalles() As Integer
        Dim claveorden As Integer = 0


        Dim claveProducto As Integer = CInt(Request("idProducto"))

        If Session("idOrden") = 0 Then
            claveorden = CreateOrden().idOrden
            Session("idOrden") = claveorden
        Else
            If Request.QueryString("idOrden") <> "" Then
                claveorden = CInt(Request.QueryString("idOrden"))
            Else
                claveorden = Session("idOrden")
            End If

        End If



        Dim objOrdendetalle As New tienda.OrdenDetalle(claveorden, claveProducto)
        objOrdendetalle.idOrden = claveorden
        objOrdendetalle.idProducto = claveProducto
        objOrdendetalle.cantidad = CInt(Request("Cantidad"))
        objOrdendetalle.costoUnitario = New tienda.Precio().GetPrecioUnitario(objOrdendetalle.idProducto, tienda.TipoEntidad.Producto, objOrdendetalle.cantidad)
        objOrdendetalle.total = objOrdendetalle.cantidad * objOrdendetalle.costoUnitario
        objOrdendetalle.costoEnvio = 0
        objOrdendetalle.descuento = 0
        objOrdendetalle.color = Request("color")
        objOrdendetalle.costoFinal = objOrdendetalle.costoUnitario
        If objOrdendetalle.existe Then
            objOrdendetalle.Update()
        Else
            objOrdendetalle.Add()
        End If

        Dim myo As New tienda.Orden(claveorden)
        myo.Update()

        Return objOrdendetalle.idOrdendetalle


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



    Public Function BorrarCookies() As Integer
        Dim aCookie As New HttpCookie("cookOrden")
        aCookie.Expires = Date.Now
        Response.Cookies.Clear()

    End Function



    Protected Sub gridServicios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridServicios.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hiddenUnidadComponente As HiddenField = CType(e.Row.FindControl("hiddenUnidadComponente"), HiddenField)
            Dim unidadComponente As Integer = CInt(hiddenUnidadComponente.Value)
            Dim dropCantidadComponente As DropDownList = CType(e.Row.FindControl("dropCantidadComponente"), DropDownList)

            For i As Integer = 1 To 5
                dropCantidadComponente.Items.Add(New ListItem((unidadComponente * i).ToString("#,##0"), i))
            Next
        End If

    End Sub

    Protected Sub rptServicios_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridServicios.SelectedIndexChanging

        Dim clave As Integer
        Dim data As DataKey = gridServicios.DataKeys(e.NewSelectedIndex)
        clave = CInt(data.Values("idServicio"))
        Dim mysi As New tienda.ServicioIdioma(clave, CInt(Session("idIdioma")))

        lblServicio.Text = mysi.nombre & " " & mysi.unidadComponenteBase & " " & mysi.componenteBase
        btnGrabar.Visible = True

    End Sub
End Class
