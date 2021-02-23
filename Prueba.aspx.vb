Imports System.Globalization
Imports System.Threading
Imports System.Data
Imports System.Net
Imports System.Net.Mail

Partial Class Prueba
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        EnviarMailClient(4979)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'smtpout.secureserver.net
    End Sub


    Function EnviarMailClient(ByVal claveorden As Integer) As Integer
        Dim myu As New tienda.UserProfile(CInt(Session("idUserProfile")))

        Dim myo As New tienda.Orden(claveorden)


        Dim subject As String = "Hemos recibido su orden #: " & myo.idOrden
        Dim cadena As String = "<font style=""font-size:12px;font-family:Arial;"">¡Gracias por preferir a Todopromocional!: <br><br> " & vbCrLf
        cadena = cadena & "Hemos recibido la cotización que usted realizó y la estamos revisando," & vbCrLf
        cadena = cadena & "pronto le enviaremos la cotización en PDF a este correo.<br><br>" & vbCrLf
        cadena = cadena & "Puede ver las cotizaciones que ha realizado en el siguiente link: <br>" & vbCrLf

        cadena = cadena & "<a href=""http://www.todopromocional.com/sec/historialCotizaciones.aspx?idOrden=" & myo.idOrden & """>http://www.todopromocional.com/sec/historialCotizaciones.aspx?idOrden=" & myo.idOrden & "</a> "


        cadena = cadena & "<br><br>" & vbCrLf & vbCrLf
        cadena = cadena & "<br><br>Cotización generada el: " & myo.fechaOrden.ToLongDateString & " - " & myo.fechaOrden.ToLongTimeString & vbCrLf & vbCrLf & vbCrLf
        cadena = cadena & "</font>"




        SendMail("jesus.alvarado@edcont.com", cadena, subject)

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


            f.Send(MailMsg)

            numero = 1
        Catch ex As Exception
            '  txtComment.Text = ex.Message & " " & ex.InnerException.Message & " " & ex.InnerException.Source
        End Try


        Return numero
    End Function
End Class
