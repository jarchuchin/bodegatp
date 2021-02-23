Imports System.Globalization
Imports System.Threading

Partial Class AddUser
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

    Sub colocardatos()
        Dim myr As New tienda.EdadRango
        drpRango.DataSource = myr.GetDS()
        drpRango.DataBind()

        Dim myli2 As New ListItem("Selecciona un rango", "")
        drpRango.Items.Insert(0, myli2)

        Dim myei As New tienda.EstadoIdioma
        drpEstados.DataSource = myei.GetDS(1, 5)
        drpEstados.DataBind()

        Dim myli As New ListItem("Selecciona un estado", "")
        drpEstados.Items.Insert(0, myli)





    End Sub


    Protected Sub lnkBtnRegistrarse_Click(sender As Object, e As EventArgs) Handles btnRegistro.Click
        If Page.IsValid Then

            If txtlogin0.Text = String.Empty Or
                txtpassword0.Text = String.Empty Or
                txtNombre.Text = String.Empty Or
                txtapellidos.Text = String.Empty Or
                txtnombreempresa.Text = String.Empty Or
                txttelefono.Text = String.Empty Then
                Exit Sub
            End If

            Dim myu As New tienda.UserProfile()
            myu.idEdadRango = CInt(drpRango.SelectedValue)
            myu.idIdioma = CInt(Session("idIdioma"))
            myu.idRol = 1
            myu.email = txtlogin0.Text.Trim
            myu.password = txtpassword0.Text
            myu.nombre = txtNombre.Text
            myu.apellidos = txtapellidos.Text
            myu.activo = True
            myu.sexo = rdbsexo.SelectedValue
            myu.fechaRegistro = Date.Now
            myu.vencimiento = Date.Now.AddYears(10)
            myu.ultimoacceso = Date.Now
            myu.nombreEmpresa = txtnombreempresa.Text
            myu.idEstado = CInt(drpEstados.SelectedValue)
            myu.telefono = txttelefono.Text
            myu.sitio = 1
            myu.Add()



            Session("idUserProfile") = myu.idUserProfile
            Session("nombre") = myu.nombre & " " & myu.apellidos
            Session("email") = myu.email

            Dim homes As String = "~/sec/AddUserConfirmacion.aspx?ReturnUrl=" & Request("ReturnUrl")


            'If Request("ReturnUrl") <> "" Then
            '    FormsAuthentication.RedirectFromLoginPage(txtlogin0.Text.ToString, False)
            'Else
            FormsAuthentication.SetAuthCookie(txtlogin0.Text, False)
            Response.Redirect(homes)
            'End If

            '   hiddenValidation.Value = 2
        End If
    End Sub

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        Dim myu As New tienda.UserProfile(txtlogin0.Text)
        If myu.existe Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If
    End Sub

    Protected Sub btnPrivacidad_Click(sender As Object, e As EventArgs) Handles btnPrivacidad.Click
        Response.Redirect("~/Privacidad.aspx")
    End Sub
    Protected Sub CustomValidator2_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CustomValidator2.ServerValidate
        If txtlogin0.Text.Trim.Contains("@") Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub
End Class
