Imports System.Globalization
Imports System.Threading
Imports System.Data
Imports System.Net
Imports System.Net.Mail
Imports System.Math


Partial Class olvido
    Inherits System.Web.UI.Page

    Protected Sub btnRecuperar_Click(sender As Object, e As EventArgs) Handles btnRecuperar.Click
        Dim myu As New tienda.UserProfile(txtlogin.Text)
        If myu.existe Then
            EnviarMailClient(myu)

            Response.Redirect("olvidoConfirmacion.aspx")
        Else
            lblMensajeerror.Visible = True
        End If
    End Sub




    Function EnviarMailClient(objUser As tienda.UserProfile) As Integer





        Dim subject As String = "Recuperación de contraseña"
        Dim cadena As String = "<font style=""font-size:12px;font-family:Arial;"">¡Gracias por preferir a Todopromocional!: <br><br> " & vbCrLf
        cadena = cadena & "Hemos recibido la solicitud para recuperar la contraseña ligada a tu correo: " & objUser.email & vbCrLf
        cadena = cadena & "Los datos para ingresar a tu cuenta son:<br><br>" & vbCrLf
        cadena = cadena & "Usuario:<strong>" & objUser.email & "</strong> <br>" & vbCrLf
        cadena = cadena & "Contraseña:<strong>" & objUser.password & "</strong> <br>" & vbCrLf

        cadena = cadena & "<a href=""http://www.todopromocional.com/login.aspx"">http://www.todopromocional.com/login.aspx</a> "


        cadena = cadena & "<br><br>" & vbCrLf & vbCrLf
        cadena = cadena & "<br><br>Datos Solicitado el: " & Date.Now.ToLongDateString & " - " & Date.Now.ToLongTimeString & vbCrLf & vbCrLf & vbCrLf
        cadena = cadena & "</font>"




        SendMail(objUser.email, cadena, subject)

        Return 1
    End Function




    Public Function SendMail(ByVal correo As String, ByRef body As String, ByVal subject As String) As Integer
        Dim MailMsg As New MailMessage("contacto@todopromocional.com", correo)



        With MailMsg
            .Subject = subject
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
            f.Port = 3535

            f.Send(MailMsg)

            '    numero = 1
        Catch ex As Exception
            '  txtComment.Text = ex.Message & " " & ex.InnerException.Message & " " & ex.InnerException.Source
        End Try



        Return numero
    End Function
End Class
