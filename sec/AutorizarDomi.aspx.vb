Imports System.Net.Mail

Partial Class sec_AutorizarDomi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()

        Dim carpetafiles As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles")


        Dim myo As New tienda.Orden(CInt(Request("idOrden")))
        Dim myod As New tienda.OrdenDetalle(CInt(Request("idOrdenDetalle")))
        Dim mypi As New tienda.ProductoIdioma(myod.idProducto, 1)

        litNumOrden.Text = myo.idOrden

        lblObservacionesvendedor.Text = myo.DomiSolicitarObservaciones



        lblProyecto.Text = myo.idOrden
        lblProyectoFecha.Text = myo.proyectoEnTramiteFecha

        If myo.tempid <> "" Then
            Dim myu As New tienda.UserProfile(CInt(myo.tempid))
            lblVendedor.Text = myu.nombre & " " & myu.apellidos
        End If



        lblClave.Text = mypi.clave
        lblNombre.Text = mypi.nombre

        Dim mypf As New tienda.ProductoFoto(mypi.idProducto, True)
        ImagenProducto.ImageUrl = carpetafiles & "productos\images\gde\" & mypf.imagen

        lblColor.Text = GetColor(myod.color)
        txtLogotipo.Text = myod.Logotipo
        txtancho.Text = myod.Ancho
        txtAlto.Text = myod.Largo

        txtimpresion.Text = myod.MetodoImpresion

        txtPantone1.Text = myod.Pantone1
        txtPantone2.Text = myod.Pantone2
        txtPantone3.Text = myod.Pantone3
        txtPantone4.Text = myod.Pantone4

        If myod.imagen <> "" Then
            ImageDomi.ImageUrl = carpetafiles & "domis\" & myod.imagen
            ImageDomi.Width = System.Web.UI.WebControls.Unit.Pixel(300)
        Else
            ImageDomi.ImageUrl = "~/images/unax.png"
        End If
        If myod.imagen2 <> "" Then
            ImageDomi2.ImageUrl = carpetafiles & "domis\" & myod.imagen2
            ImageDomi2.Width = System.Web.UI.WebControls.Unit.Pixel(300)
        Else
            ImageDomi2.ImageUrl = "~/images/unax.png"
            ImageDomi2.Visible = False
        End If
        If myod.imagen3 <> "" Then
            ImageDomi3.ImageUrl = carpetafiles & "domis\" & myod.imagen3
            ImageDomi3.Width = System.Web.UI.WebControls.Unit.Pixel(300)
        Else
            ImageDomi3.ImageUrl = "~/images/unax.png"
            ImageDomi3.Visible = False
        End If


        If myod.vector <> "" Then
            lnkVector.NavigateUrl = carpetafiles & "domis\" & myod.vector
            lnkVector.Visible = True
        Else
            lnkVector.Visible = False
        End If
        If myod.vector2 <> "" Then
            lnkVector2.NavigateUrl = carpetafiles & "domis\" & myod.vector2
            lnkVector2.Visible = True
        Else
            lnkVector2.Visible = False
        End If
        If myod.vector3 <> "" Then
            lnkVector3.NavigateUrl = carpetafiles & "domis\" & myod.vector3
            lnkVector3.Visible = True
        Else
            lnkVector3.Visible = False
        End If




        imgAutorizacion.ImageUrl = getImagenDomi(myod.Autorizado)
        If myod.Autorizado Then
            lblAutorizacionFecha.Text = myod.AutorizadoFecha

            tableAutorizacion.Visible = True
            panelAutorizar.Visible = False

            btnGrabar.Visible = False
        Else
            panelAutorizar.Visible = True
            btnGrabar.Visible = True
        End If
    End Sub



    Public Function getImagenDomi(autorizacion As Boolean) As String

        If autorizacion Then
            Return "~/images/t-mini_icon_ok.png"
        Else
            Return "~/images/t-mini_icon_x.png"
        End If

    End Function


    Public Function GetColor(ByVal claveColor As String) As String
        If IsNumeric(claveColor) Then
            Dim myc As New tienda.Color(CInt(claveColor))
            Dim mycc As New tienda.Codigocolor(myc.idCodigocolor)
            Return mycc.idioma1
        Else
            Return claveColor
        End If

    End Function

    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Response.Redirect("verCompras.aspx?idOrden=" & Request("idOrden"))
    End Sub
    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim myod As New tienda.OrdenDetalle(Request("idOrdenDetalle"))
        Dim myo As New tienda.Orden(myod.idOrden)
        autorizar(myo)

        myod.Autorizado = True
        myod.AutorizadoFecha = Date.Now
        myod.Update()


        SendMailVendedor("Autorizado", myo.idOrden)
        SendMailCliente("Autorizado", myo.idOrden)

        Response.Redirect("verCompras.aspx?idOrden=" & myod.idOrden)

    End Sub


    Sub autorizar(myo As tienda.Orden)
        If myo.idUserProfile <> CInt(Session("idUserProfile")) Then
            Response.Redirect("verCompras.aspx?idOrden=" & Request("idOrden"))
        End If
    End Sub


    Public Function SendMailCliente(ByRef body As String, ByVal claveCotizacion As Integer) As Integer


        Dim myo As New tienda.Orden(claveCotizacion)
        Dim myod As New tienda.OrdenDetalle(CInt(Request("idOrdenDetalle")))

        Dim myuserActual As New tienda.UserProfile(CInt(Session("idUserProfile")))
        '   Dim myuserVendedor As New tienda.UserProfile(CInt(myo.tempid))
        Dim MailMsg As New MailMessage("websystem@todopromocional.com", myuserActual.email)

        With MailMsg
            If myo.proyectoEnTramite Then
                .Subject = "Proyecto # " & claveCotizacion & " -- Domi " & body
            Else
                .Subject = "Cotizacion # " & claveCotizacion & " -- Domi " & body
            End If

            .Body = "El cliente " & myo.nombreE & " ha autorizado los domis a traves del portal del cliente. Se adjuntan los archivos necesarios para mostrar al cliente . " & myo.nombreE & "<br> Se informa al centro de atención para continuar con el proceso de producción<br><br><br> "
            .IsBodyHtml = True

            'If body = "Autorizado" Then
            '    '  .cc  = New MailAddress("diseno@todopromocional.com")
            'End If
        End With


        If myod.imagen <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.imagen
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If

        If myod.imagen2 <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.imagen2
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If

        If myod.imagen3 <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.imagen3
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If


        If myod.vector <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.vector
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If

        If myod.vector2 <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.vector2
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If

        If myod.vector3 <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.vector3
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If


        Dim numero As Integer = 0
        Try
            Dim aCred As New System.Net.NetworkCredential("websystem@todopromocional.com", "NaguaVENnafta17")

            Dim f As New System.Net.Mail.SmtpClient("smtpout.secureserver.net")
            f.EnableSsl = False
            f.UseDefaultCredentials = False
            f.Credentials = aCred
            f.Port = 3535

            f.Send(MailMsg)

            numero = 1
        Catch ex As Exception
            lblComments.Text = ex.Message
        End Try


        Return numero
    End Function


    Public Function SendMailVendedor(ByRef body As String, ByVal claveCotizacion As Integer) As Integer


        Dim myo As New tienda.Orden(claveCotizacion)
        Dim myod As New tienda.OrdenDetalle(CInt(Request("idOrdenDetalle")))

        Dim myuserActual As New tienda.UserProfile(CInt(Session("idUserProfile")))
        Dim myuserVendedor As New tienda.UserProfile(CInt(myo.tempid))
        Dim mailvendedor = "contacto@todopromocional.com"
        If myuserVendedor.existe Then
            mailvendedor = myuserVendedor.email
        End If
        Dim MailMsg As New MailMessage(myuserActual.email, mailvendedor)

        With MailMsg
            If myo.proyectoEnTramite Then
                .Subject = "Proyecto # " & claveCotizacion & " -- Domi " & body
            Else
                .Subject = "Cotizacion # " & claveCotizacion & " -- Domi " & body
            End If

            .Body = "El cliente " & myo.nombreE & " ha autorizado los domis a traves del portal del cliente. Se adjuntan los archivos necesarios para mostrar al cliente . " & myo.nombreE & "<br> Se informa al centro de atención para continuar con el proceso de producción<br><br><br> "
            .IsBodyHtml = True

            'If body = "Autorizado" Then
            '    '  .cc  = New MailAddress("diseno@todopromocional.com")
            'End If
        End With


        If myod.imagen <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.imagen
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If

        If myod.imagen2 <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.imagen2
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If

        If myod.imagen3 <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.imagen3
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If


        If myod.vector <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.vector
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If

        If myod.vector2 <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.vector2
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If

        If myod.vector3 <> "" Then
            Dim claveAtach As String = System.Configuration.ConfigurationManager.AppSettings("files") & "domis\" & myod.vector3
            Dim Attach As New Attachment(claveAtach)
            MailMsg.Attachments.Add(Attach)
        End If


        Dim numero As Integer = 0
        Try
            Dim aCred As New System.Net.NetworkCredential("websystem@todopromocional.com", "NaguaVENnafta17")

            Dim f As New System.Net.Mail.SmtpClient("smtpout.secureserver.net")
            f.EnableSsl = False
            f.UseDefaultCredentials = False
            f.Credentials = aCred
            f.Port = 3535

            f.Send(MailMsg)

            numero = 1
        Catch ex As Exception
            lblComments.Text = ex.Message
        End Try


        Return numero
    End Function



End Class
