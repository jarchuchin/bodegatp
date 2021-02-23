Imports System.Data

Partial Class Controles_Footer
    Inherits System.Web.UI.UserControl

    Dim varMostrar2 As Boolean = False
    Public Property Mostrar2 As Boolean
        Set(value As Boolean)
            varMostrar2 = value
        End Set
        Get
            Return varMostrar2
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim myc As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))
            'lblfooter.Text = myc.footer


            '  lblRegion.Text = Session("region")


            Dim url As String = HttpContext.Current.Request.Url.AbsolutePath.Substring(HttpContext.Current.Request.Url.AbsolutePath.LastIndexOf("/") + 1).ToLower
            Select Case url
                Case "default.aspx"
                    divRegistroFooter.Visible = True
                Case Else
                    divRegistroFooter.Visible = False
            End Select



            Select Case url
                Case "compras.aspx"
                    footer1.Visible = False
                    footer2.Visible = True
                Case "login.aspx"
                    footer1.Visible = False
                    footer2.Visible = True
                Case "editarordendatos.aspx"
                    footer1.Visible = False
                    footer2.Visible = True
                Case "agregarimagen.aspx"
                    footer1.Visible = False
                    footer2.Visible = True


            End Select

        End If
    End Sub


    Public Function getCategos(ByVal clavecatego As Integer) As DataSet
        Dim myc As New tienda.CategoriaIdioma()
        Return myc.GetDS(CInt(Session("idIdioma")), clavecatego)
    End Function
    Public Function getTags(ByVal clavetags As String) As String
        Dim cadena As String = clavetags.Replace(",", " ")
        cadena = cadena.Replace(" ", "-")

        Return cadena.ToLower


    End Function

	Protected Sub lnkBtnSuscripcion_Click(sender As Object, e As EventArgs) Handles lnkBtnSuscripcion.Click
		Dim regex As Regex = New Regex("\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase)
		Dim match As Match = regex.Match(txtSuscripcion.Text)
		If match.Success Then
			Dim objSuscripcion As New tienda.Suscripcion(txtSuscripcion.Text)

			If Not objSuscripcion.existe Then
				With objSuscripcion
					.email = txtSuscripcion.Text
					.enviarmail = True
					.fecha = Date.Now
					.Add()

					Response.Redirect("~/ConfirmarSuscripcion.aspx?email=" & .email)
				End With
			End If
		End If

	End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim regex As Regex = New Regex("\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase)
        Dim match As Match = regex.Match(TextBox1.Text)
        If match.Success Then
            Dim objSuscripcion As New tienda.Suscripcion(TextBox1.Text)

            If Not objSuscripcion.existe Then
                With objSuscripcion
                    .email = TextBox1.Text
                    .enviarmail = True
                    .fecha = Date.Now
                    .Add()

                    Response.Redirect("~/ConfirmarSuscripcion.aspx?email=" & .email)
                End With
            End If
        End If
    End Sub
End Class
