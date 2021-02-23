Imports System.Globalization
Imports System.Threading
Imports System.Net
Imports System.Net.Mail


Partial Class Contacto
    Inherits System.Web.UI.Page
    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("idioma")

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)


        MyBase.InitializeCulture()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim myct As New tienda.ConfiguracionIdioma(1, Session("idIdioma"))
            'LitContacto.Text = myct.formasContacto


            Dim mypais As New tienda.Pais("mx")
            Dim mye As New tienda.EstadoIdioma()
            drpestados.DataSource = mye.GetDS(CInt(Session("idIdioma")), mypais.idPais)
            drpestados.DataValueField = "Nombre"
            drpestados.DataTextField = "Nombre"
            drpestados.DataBind()

            Dim myli As New ListItem("Selecciona un estado", "")
            drpestados.Items.Insert(0, myli)


            txtContacto.Focus()



        End If
    End Sub




    Function EnviarMailOwner() As Integer
        Dim myct As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))




        Dim subject As String = "Solicitud de contacto: " & txtContacto.Text
        Dim cadena As String = "Nombre del contacto: " & txtContacto.Text & vbCrLf & "<br>"
        cadena = cadena & "Correo: " & txtCorreo.Text & vbCrLf & "<br>"
        cadena = cadena & "Telefono: " & txtTelefono.Text & vbCrLf & "<br>"
        cadena = cadena & "Fax: " & txtFax.Text & vbCrLf & "<br>"
        cadena = cadena & "Ciudad: " & txtCiudad.Text & vbCrLf & "<br>"
        cadena = cadena & "Estado: " & drpestados.SelectedItem.Text & vbCrLf & "<br>"
        'cadena = cadena & Label9.Text & ": " & txtEmpresa.Text & vbCrLf & vbCrLf 
        cadena = cadena & "###############################################" & vbCrLf & vbCrLf & "<br>"
        cadena = cadena & "Motivo: " & txtmotivo.Text & vbCrLf & vbCrLf & vbCrLf & "<br>"


        cadena = cadena & myct.nombre & vbCrLf & "<br>"

        SendMail(myct.email, cadena)

        Dim destinatario As String = dropDirigidoA.SelectedValue
        Select Case destinatario
            Case "ventas"
                SendMail("contacto@todopromocional.com", cadena)
            Case "compras"
                SendMail("compras@todopromocional.com", cadena)
            Case "webmaster"
                SendMail("jesus.alvarado@edcont.com", cadena)
            Case "direccion"
                SendMail("direccion@todopromocional.com", cadena)
        End Select
        'SendMail("contacto@todopromocional.com", cadena)
        Return 1
    End Function

    Public Function SendMail(ByVal correo As String, ByRef body As String) As Integer
        Dim MailMsg As New MailMessage("contacto@todopromocional.com", correo)
        MailMsg.CC.Add("contacto@todopromocional.com")



        With MailMsg
            .Subject = "Centro de contacto - Todopromocional"
            .Body = body
            .IsBodyHtml = True



        End With

        Dim numero As Integer = 0
        Try
            Dim aCred As New System.Net.NetworkCredential("websystem@todopromocional.com", "NaguaVENnafta17")

            Dim f As New System.Net.Mail.SmtpClient("smtpout.secureserver.net")
            f.EnableSsl = False
            f.UseDefaultCredentials = False
            f.Credentials = aCred


            f.Send(MailMsg)

            '    numero = 1
        Catch ex As Exception
            '  txtComment.Text = ex.Message & " " & ex.InnerException.Message & " " & ex.InnerException.Source
        End Try



        Return numero
    End Function

    Protected Sub lnkBtnEnviar_Click(sender As Object, e As EventArgs) Handles lnkBtnEnviar.Click
        EnviarMailOwner()
        Response.Redirect("ContactoConfirmacion.aspx")
    End Sub

End Class
