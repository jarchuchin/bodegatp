Imports System.Globalization
Imports System.Threading


Partial Class Login
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("idioma")

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)


        MyBase.initializeculture()

    End Sub

 



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '  txtpassword.Attributes.Add("onKeyUp", "enterText")
            '  txtpassword.Attributes.Add("onKeyPress", "enterText(event)")
            colocardatos()
        End If


	End Sub


    Sub colocardatos()
        '      Dim myr As New tienda.EdadRango
        '      drpRango.DataSource = myr.GetDS()
        '      drpRango.DataBind()

        '      drpRango.SelectedValue = 3

        'Dim myei As New tienda.EstadoIdioma
        '      drpEstados.DataSource = myei.GetDS(1, 5)
        '      drpEstados.DataBind()

        '      Dim myli As New ListItem("Selecciona un estado", "")
        '      drpEstados.Items.Insert(0, myli)

        lnkRegistro.NavigateUrl = "~/adduser.aspx?ReturnUrl=" & Server.HtmlEncode(Request("ReturnUrl"))

        If CInt(Session("idUserProfile")) > 0 Then
			Response.Redirect("~/sec/HistorialCotizaciones.aspx")
		Else
			hiddenValidation.Value = 0
		End If

		Try
			hiddenRed.Value = Request("red").ToString
		Catch ex As Exception
		End Try
		Try
			hiddenReturnURL.Value = Request("ReturnUrl").ToString
		Catch ex As Exception
		End Try
	End Sub



    'Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
    '    Dim myu As New tienda.UserProfile(txtlogin0.Text)
    '    If myu.existe Then
    '        args.IsValid = False
    '    Else
    '        args.IsValid = True
    '    End If
    'End Sub


    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Page.IsValid Then

            If txtlogin.Text <> String.Empty And txtpassword.Text <> String.Empty Then

                Dim myu As New tienda.UserProfile(txtlogin.Text)
                If myu.existe Then

                    If myu.password = txtpassword.Text Then
                        Session("idUserProfile") = myu.idUserProfile
                        Session("nombre") = myu.nombre
                        Session("email") = myu.email
                        myu.ultimoacceso = Date.Now
						myu.Update()

						getProductosRecientes(CInt(Session("idIdioma")), myu.idUserProfile)

                        Dim myru As New tienda.RolesUser
                        If myru.PrivilegiosEspeciales(myu.idUserProfile) Then
                            Session("esAdmin") = True
                        End If

                        If Request.QueryString("ReturnUrl") <> "" Then
                            FormsAuthentication.RedirectFromLoginPage(txtlogin.Text.ToString, False)
                        Else
                            FormsAuthentication.SetAuthCookie(txtlogin.Text, False)

                            If Request("red") = 1 Then
                                'cadenaredireccion &= "sec/seleccionardireccion.aspx?red=1"
                                'Response.Redirect(cadenaredireccion)
                            Else

                            End If
                            'cadenaredireccion &= "sec/HistorialCotizaciones.aspx"
                            Response.Redirect("~/sec/HistorialCotizaciones.aspx")
                        End If

                        hiddenValidation.Value = 1
                    Else

                        lblMensajeerror.Visible = True  'falla password
                    End If

                Else
                    lblMensajeerror.Visible = True  'falla login
                End If

            Else
                lblMensajeerror.Visible = True  'falta login o password
            End If

        End If
    End Sub

    'Protected Sub lnkBtnRegistrarse_Click(sender As Object, e As EventArgs) Handles lnkBtnRegistrarse.Click
    '	If Page.IsValid Then

    '		If txtlogin0.Text = String.Empty Or
    '			txtpassword0.Text = String.Empty Or
    '			txtNombre.Text = String.Empty Or
    '			txtapellidos.Text = String.Empty Or
    '			txtnombreempresa.Text = String.Empty Or
    '			txttelefono.Text = String.Empty Then
    '			Exit Sub
    '		End If

    '		Dim myu As New tienda.UserProfile()
    '		myu.idEdadRango = CInt(drpRango.SelectedValue)
    '		myu.idIdioma = CInt(Session("idIdioma"))
    '		myu.idRol = 1
    '		myu.email = txtlogin0.Text
    '		myu.password = txtpassword0.Text
    '		myu.nombre = txtNombre.Text
    '		myu.apellidos = txtapellidos.Text
    '		myu.activo = True
    '		myu.sexo = rdbsexo.SelectedValue
    '		myu.fechaRegistro = Date.Now
    '		myu.vencimiento = Date.Now.AddYears(10)
    '		myu.ultimoacceso = Date.Now
    '		myu.nombreEmpresa = txtnombreempresa.Text
    '		myu.idEstado = CInt(drpEstados.SelectedValue)
    '		myu.telefono = txttelefono.Text

    '		myu.Add()



    '		Session("idUserProfile") = myu.idUserProfile
    '		Session("nombre") = myu.nombre & " " & myu.apellidos
    '		Session("email") = myu.email

    '		Dim homes As String = "~/sec/HistorialCotizaciones.aspx"


    '		If Request("ReturnUrl") <> "" Then
    '			'FormsAuthentication.RedirectFromLoginPage(txtlogin.Text.ToString, False)
    '		Else
    '			FormsAuthentication.SetAuthCookie(txtlogin.Text, False)
    '			'Response.Redirect(homes)
    '		End If

    '		hiddenValidation.Value = 2
    '	End If
	'End Sub

	Private Sub getProductosRecientes(idIdioma As Integer, idUserProfile As Integer)
		Dim objRecientes As New tienda.Productoreciente()
		If Session("listaRecientes") Is Nothing Then
			Session("listaRecientes") = objRecientes.getListaRecientes(idIdioma, idUserProfile)
		Else
			Dim listaEnSesion As List(Of tienda.Productoreciente) = CType(Session("listaRecientes"), List(Of tienda.Productoreciente))
			Session("listaRecientes") = objRecientes.mergeListasProductos(idIdioma, idUserProfile, listaEnSesion)
		End If

	End Sub
End Class
