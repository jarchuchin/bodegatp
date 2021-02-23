Imports System.Globalization
Imports System.Threading
Imports System.Net.Mail
Imports System.Net

Partial Class sec_checkout
    Inherits System.Web.UI.Page
    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("idioma")

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)


        MyBase.initializeculture()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Dim objDT As System.Data.DataTable
    Dim objDR As System.Data.DataRow

    Sub colocardatos()

        'validacion carrito
        If IsNothing(Session("Carrito")) Then
			Response.Redirect("~/sec/HistorialCotizaciones.aspx")
        End If

        If Request("error") = "1" Then
            lblMensaje.Visible = True
        End If


        'Direccion de envio 
        Dim myd As New tienda.Direccion(CInt(Request("idDireccion")))
        If myd.iduserProfile <> CInt(Session("idUserProfile")) Then
            Response.Redirect("~/logout.aspx")
        End If
        lbldireccion.Text = myd.direccion
        lblciudad.Text = myd.ciudad
        Dim mypais As New tienda.PaisIdioma(myd.idPais, CInt(Session("idIdioma")))
        Dim myestado As New tienda.EstadoIdioma(myd.idEstado, CInt(Session("idIdioma")))

        lblestado.Text = myestado.nombre
        lblpais.Text = mypais.nombre
        lblcp.Text = myd.cp
        lbltelefono.Text = myd.telefono
        'termina Direccion de envio ' 

       




        Dim cadenaOrden As String = System.Configuration.ConfigurationManager.AppSettings("HttpRedirect") & HttpUtility.UrlEncode(Request.ServerVariables("SERVER_NAME")) & Request.ApplicationPath



        objDT = Session("Carrito")
        dtgbolsita.DataSource = objDT
        dtgbolsita.DataBind()


        Dim subtotal As Decimal = GetSubTotal()
        lblsubtotal.Text = String.Format("{0:#.00}", subtotal)
        lblDescuentos.Text = "0.00"
        Dim impuesto As Decimal = 0

        Dim myci As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))

        If myci.activarImpuesto Then
            impuesto = (myestado.impuesto / 100) * subtotal
            lblImpuesto.Text = String.Format("{0:#.00}", impuesto)
        Else
            lblImpuesto.Text = "0.00"
        End If

        Dim gastoenvio As Decimal = 0
        lblgastosenvio.Text = String.Format("{0:#.00}", gastoenvio)

        lblTotal.Text = String.Format("{0:#.00}", impuesto + subtotal + gastoenvio)


        drppaises.DataSource = mypais.GetDS(Session("idIdioma"))
        drppaises.DataBind()


        'colocardatos datos de facturación
        Dim mydfact As New tienda.Direccion(CInt(Session("idUserProfile")), "facturacion")
        If mydfact.existe Then
            txtnombredireccion.Text = mydfact.nombre

            txtdireccion.Text = mydfact.direccion
            txtciudad.Text = mydfact.ciudad
            txtcp.Text = mydfact.cp
            txttelefono.Text = mydfact.telefono
            txtrfc.Text = mydfact.rfc


            drppaises.SelectedValue = mydfact.idPais

            Dim mye As New tienda.EstadoIdioma()
            drpEstado.DataSource = mye.GetDS(CInt(Session("idIdioma")), mydfact.idPais)
            drpEstado.DataBind()


            drpEstado.SelectedValue = mydfact.idEstado
        Else
            Dim myusuario As New tienda.UserProfile(CInt(Session("idUserProfile")))
            txtnombredireccion.Text = myusuario.nombre & " " & myusuario.apellidos

            txtdireccion.Text = myd.direccion
            txtciudad.Text = myd.ciudad
            txtcp.Text = myd.cp
            txttelefono.Text = myd.telefono


            drppaises.SelectedValue = myd.idPais

            Dim mye As New tienda.EstadoIdioma()
            drpEstado.DataSource = mye.GetDS(CInt(Session("idIdioma")), myd.idPais)
            drpEstado.DataBind()


            drpEstado.SelectedValue = myd.idEstado

        End If



    End Sub



    Private Function GetSubTotal() As Decimal
        objDT = Session("Carrito")
        Dim cantidadTotal As Decimal = 0
        Dim i As Integer
        For i = 0 To objDT.Rows.Count - 1
            cantidadTotal = cantidadTotal + CType(objDT.Rows(i).Item("CostoTotal"), Decimal)
        Next

        Return cantidadTotal
    End Function


    Protected Sub btnchkout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnchkout.Click
        If Page.IsValid Then
            generarOrden()
        End If

    End Sub


    Private Function generarOrden() As Integer

        Dim myo As tienda.Orden

        ' guardar direccion facturación
        If Request("idOrden") = "" Then
            Dim myd As New tienda.Direccion(CInt(Session("idUserProfile")), "facturacion")
            myd.nombre = txtnombredireccion.Text
            myd.apellidos = ""
            myd.direccion = txtdireccion.Text
            myd.iduserProfile = CInt(Session("idUserProfile"))
            myd.ciudad = txtciudad.Text
            myd.telefono = txttelefono.Text
            myd.cp = txtcp.Text
            myd.idPais = CInt(drppaises.SelectedValue)
            myd.idEstado = CInt(drpEstado.SelectedValue)
            myd.tipo = "facturacion"
            myd.rfc = txtrfc.Text
            If myd.existe Then
                myd.Update()
            Else
                myd.Add()
            End If

            myo = New tienda.Orden
            myo.idUserProfile = CInt(Session("idUserprofile"))
            myo.Status = "1"
            myo.idTipoTarjeta = CInt(drpTipoTarjeta.SelectedValue)
            myo.NumeroCuenta = txtNumeroCuenta.Text
            myo.Mes = CInt(drpMes.SelectedValue)
            myo.year = CInt(drpAno.SelectedValue)
            myo.Nombre = txtnombre.Text
            myo.NumeroExtra = txtNumeroExtra.Text

            Dim mydireccionE As New tienda.Direccion(CInt(Request("idDireccion")))
            myo.NombreE = ""
            myo.DireccionE = mydireccionE.direccion
            myo.CiudadE = mydireccionE.ciudad
            myo.idPaisE = mydireccionE.idPais
            myo.idEstadoE = mydireccionE.idEstado
            myo.cpE = mydireccionE.cp
            myo.TelefonoE = mydireccionE.telefono

            myo.Subtotal = CType(lblsubtotal.Text, Decimal)
            myo.Impuesto = CType(lblImpuesto.Text, Decimal)
            myo.CostoEnvio = CType(lblgastosenvio.Text, Decimal)
            myo.Descuento = CType(lblDescuentos.Text, Decimal)
            myo.CostoAdicional = 0
            myo.TotalDollar = CType(lblTotal.Text, Decimal)


            '##################### tipo cambio
            Dim myvalordollar As New tienda.ValorDollar()
            myo.TipoCambio = myvalordollar.valordollar
            myo.Total = myo.TotalDollar * myvalordollar.valordollar

            myo.FechaOrden = Date.Now
            myo.FechaUltimaActualizacion = Date.Now
            myo.idTipoEnvio = 1


            '###################### direccion de facturación
            myo.NombreF = myd.nombre
            myo.RFC = myd.rfc
            myo.DireccionF = myd.direccion
            myo.CiudadF = myd.ciudad
            myo.idPaisF = myd.idPais
            myo.cpF = myd.cp
            myo.TelefonoF = myd.telefono
            myo.Facturar = True
            myo.Folio = 0
            myo.TipoPago = 1
            myo.respuesta = ""

            myo.Add()


            objDT = Session("Carrito")

            Dim i As Integer
            Dim myod As tienda.OrdenDetalle
            For i = 0 To objDT.Rows.Count - 1
                myod = New tienda.OrdenDetalle
                myod.idOrden = myo.idOrden
                myod.idProducto = CType(objDT.Rows(i).Item("idproducto"), Integer)
                myod.Cantidad = CType(objDT.Rows(i).Item("Cantidad"), Integer)
                myod.CostoUnitario = CType(objDT.Rows(i).Item("CostoUnitario"), Decimal)
                myod.Total = CType(objDT.Rows(i).Item("CostoTotal"), Decimal)
                myod.CostoEnvio = 0
                myod.Descuento = 0

                myod.Add()
            Next

           

        Else
            myo = New tienda.Orden(CInt(Request("idOrden")))

        End If


        Dim myu As New tienda.UserProfile(myo.idUserProfile)

        Dim expirationdate As String = drpAno.SelectedValue.Substring(2)
        If CInt(drpMes.SelectedValue) > 9 Then
            expirationdate = expirationdate & drpMes.SelectedValue
        Else
            expirationdate = expirationdate & "0" & drpMes.SelectedValue
        End If

        'pago en linea umpay
        Dim myumpay As New umpay.StoreBeanService
        'sell(String clerk, String comment, String accountNumber, String expirationDate, String amount, String postalCode, String address, String securityCode);

        Try
            Dim regreso As String = myumpay.sell("Adventus21", "Adventus." & myo.Folio & "." & txtnombre.Text, txtNumeroCuenta.Text, expirationdate, String.Format("{0:#.00}", myo.Total), txtcp.Text, txtdireccion.Text, txtNumeroExtra.Text)

            If regreso.Substring(1, 1) = "Y" Then
                myo.Status = 1
            Else
                myo.Status = 2
            End If

            myo.respuesta = regreso
        Catch ex As Exception
            myo.Status = 2
        End Try

        myo.Update()


        If myo.Status = 1 Then
            Session("Carrito") = Nothing

            EnviarMailOwner(myo)

            Response.Redirect("confirmacion.aspx?idOrden=" & myo.idOrden)
        Else
            Response.Redirect("checkout.aspx?error=1&idOrden=" & myo.idOrden)
        End If

    End Function

    Protected Sub drppaises_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drppaises.SelectedIndexChanged
        Dim myestados As New tienda.EstadoIdioma
        drpEstado.DataSource = myestados.GetDS(CInt(Session("idIdioma")), CInt(drppaises.SelectedValue))
        drpEstado.DataBind()
    End Sub


    Public Function getClave(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
        Return mypi.clave

    End Function


    Public Function getNombre(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
        Return mypi.nombre

    End Function

    Public Function getFoto(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoFoto(claveproducto, True)
        Return System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/min/" & mypi.imagen

    End Function

    Public Function getventaminima(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
        Return mypi.ventaMinima

    End Function



    Function EnviarMailOwner(ByVal orden As tienda.Orden) As Integer
        Dim myct As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))

        Dim myu As New tienda.UserProfile(orden.idUserProfile)


        Dim subject As String = "New order in process: " & orden.Folio
        Dim cadena As String = "Order number: " & orden.Folio & " ----- " & vbCrLf & vbCrLf



        cadena = cadena & "####################################" & vbCrLf

        Dim myod As New tienda.OrdenDetalle
        Dim dr As System.Data.SqlClient.SqlDataReader = myod.getDR(orden.idOrden)
        Dim mypi As tienda.ProductoIdioma
        While dr.Read
            mypi = New tienda.ProductoIdioma(CInt(dr("idProducto")), CInt(Session("idIdioma")))
            cadena = cadena & dr("Cantidad") & " ---- " & mypi.nombre & " ---- " & String.Format("{0:#.00}", dr("Total")) & " Dls" & vbCrLf

        End While


        cadena = cadena & vbCrLf
        cadena = cadena & "Order total : " & String.Format("{0:C}", orden.TotalDollar) & vbCrLf
        cadena = cadena & vbCrLf
        cadena = cadena & "Client name: " & myu.nombre & " " & myu.apellidos & vbCrLf
        cadena = cadena & "Client Email: " & myu.email & vbCrLf
        cadena = cadena & vbCrLf
        cadena = cadena & "####################################" & vbCrLf
        cadena = cadena & vbCrLf
        cadena = cadena & vbCrLf
        cadena = cadena & "To view the order details go to our website www.adventus21.com   " & vbCrLf
        cadena = cadena & vbCrLf
        cadena = cadena & "Status of the order: " & orden.Status & vbCrLf
        cadena = cadena & "Email generated in www.adventus21.com mail system" & vbCrLf


        SendMail(myu.email, myct.email, cadena, subject)
        SendMail("ecommerce@adventus21.com", myu.email, cadena, subject)

        Return 1
    End Function



    Public Function SendMail(ByVal mailfrom As String, ByVal mailto As String, ByVal mensaje As String, ByVal asunto As String) As Integer

        Dim MailMsg1 As New MailMessage("j.alvarado@um.edu.mx", mailto)

        With MailMsg1
            .From = New MailAddress(mailfrom)
            .Subject = asunto
            .Body = mensaje & vbCrLf & vbCrLf & "Mail from: " & mailfrom
            .IsBodyHtml = False
        End With

        Dim f As New System.Net.Mail.SmtpClient()
        f.Host = "smtp.gmail.com"
        f.Credentials = New System.Net.NetworkCredential("j.alvarado@um.edu.mx", "chuchin")
        f.EnableSsl = True
        f.Send(MailMsg1)


    End Function

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        Dim myip As New tienda.InformacionPago

        If myip.validarTarjeta(CInt(drpMes.SelectedValue), CInt(drpAno.SelectedValue), txtNumeroCuenta.Text, CInt(drpTipoTarjeta.SelectedValue)) Then
            args.IsValid = True
        Else
            args.IsValid = False

        End If

    End Sub
End Class
