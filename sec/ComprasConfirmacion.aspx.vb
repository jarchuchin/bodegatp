
Partial Class sec_ComprasConfirmacion
    Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not CInt(Session("idUserProfile")) > 0 Then
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If
		Catch ex As Exception
		End Try

		If Not IsPostBack Then
			cargardatos()
		End If
	End Sub


    Sub cargardatos()
		Dim myo As New tienda.Orden(CInt(Request("idOrden")))
		Dim myup As New tienda.UserProfile(CInt(myo.tempid))
		Dim myUser As New tienda.UserProfile(myo.idUserProfile)

        'litgoogle.Text = getGoogle(myo)

        lblUsuario.Text &= myUser.nombre & " " & myUser.apellidos
		lblfecha.Text &= myo.fechaOrden.ToShortDateString
		lblNumOrden.Text &= myo.idOrden
        'lnkCategoActual.Text = "Cotizacion # " & Request("idOrden")
        'lnkCategoActual.NavigateUrl = "verCompras.aspx?idOrden" & Request("idOrden")

        Dim myi As New tienda.Instancia(myo.idInstancia)
        lblSucursal.Text = myi.Nombre

        lblVendedor.Text = "Vendedor asignado: " & myup.nombre & " " & myup.apellidos
        lblVendedorEmail.Text = myup.email
        lblVendedorExtension.Text = "<b>Teléfono Directo</b>:  <b>" & myup.telefono & "</b>"

        Label2.Text = "<b>" & myup.nombre & " " & myup.apellidos & "</b> se pondrá en contacto contigo."

    End Sub

	Public Function getGoogle(myo As tienda.Orden) As String
		Dim cadena As String = "<!-- Google Code for Cotización Levantada Conversion Page -->" & vbCrLf & _
		"<script language='JavaScript' type='text/javascript'> " & vbCrLf & _
		"<!--" & vbCrLf & _
		"var google_conversion_id = 1052814348;" & vbCrLf & _
		"var google_conversion_language =" & """es""" & ";" & vbCrLf & _
		"var google_conversion_format =  " & """1""" & ";" & vbCrLf & _
		"var google_conversion_color = " & """ffffff""" & ";" & vbCrLf & _
		"var google_conversion_label = " & """nyPFCJ66TRCM2IL2Aw""" & ";" & vbCrLf & _
		"if (" & myo.total & ") { " & vbCrLf & _
		"var google_conversion_value = " & myo.total & "; " & vbCrLf & _
		"}" & vbCrLf & _
		"-->" & vbCrLf & _
		"</script>" & vbCrLf & _
		"<script language=" & """JavaScript""" & " src=" & """http://www.googleadservices.com/pagead/conversion.js""" & "> " & vbCrLf & _
		"</script>" & vbCrLf & _
		"<noscript>" & vbCrLf & _
		"<img height='1' width='1' border='0' src='http://www.googleadservices.com/pagead/conversion/1052814348/?value=" & myo.total & "&label=nyPFCJ66TRCM2IL2Aw&script=0'/> " & vbCrLf & _
		"</noscript>"


		Return cadena
	End Function
End Class
