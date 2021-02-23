Imports System.Globalization
Imports System.Threading


Partial Class sec_personalInfo
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
			colocardatos()
		End If
    End Sub

    Sub colocardatos()
        Dim myr As New tienda.EdadRango
        drpRango.DataSource = myr.GetDS()
        drpRango.DataBind()

        Dim myci As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))
        lblTienda1.Text = myci.nombre
        lblTienda2.Text = myci.nombre


        Dim myei As New tienda.CatalogoEntidad
        drpEstados.DataSource = myei.GetDS(1)
        drpEstados.DataBind()

        Dim myu As New tienda.UserProfile(CInt(Session("idUserProfile")))
        txtlogin.Text = myu.email
        txtpassword.Attributes.Add("value", myu.password)
        txtconfirmar.Attributes.Add("value", myu.password)
        txtapellidos.Text = myu.apellidos
        txtNombre.Text = myu.nombre

        rdbsexo.SelectedValue = myu.sexo
        drpEstados.SelectedValue = myu.idEstado
        drpRango.SelectedValue = myu.idEdadRango
        txtnombreempresa.Text = myu.nombreEmpresa

        txttelefono.Text = myu.telefono


    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Page.IsValid Then
            grabar()
        End If
    End Sub

    Sub grabar()
        Dim myu As New tienda.UserProfile(CInt(Session("idUserProfile")))
        myu.idEdadRango = CInt(drpRango.SelectedValue)
        myu.idIdioma = CInt(Session("idIdioma"))
        myu.idRol = 1
        myu.email = txtlogin.Text
        myu.password = txtpassword.Text
        myu.nombre = txtNombre.Text
        myu.apellidos = txtapellidos.Text
        myu.activo = True
        myu.sexo = rdbsexo.SelectedValue
        ' myu.fechaRegistro = Date.Now
        '  myu.vencimiento = Date.Now.AddYears(10)
        '     myu.ultimoacceso = Date.Now
        myu.nombreEmpresa = txtnombreempresa.Text
        myu.idEstado = CInt(drpEstados.SelectedValue)
        myu.telefono = txttelefono.Text
        myu.Update()



        Session("idUserProfile") = myu.idUserProfile
        Session("nombre") = myu.nombre & " " & myu.apellidos
        Session("email") = myu.email

		Dim homes As String = "~/sec/HistorialCotizaciones.aspx"

            Response.Redirect(homes)
  


    End Sub

  
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
		Response.Redirect("~/sec/HistorialCotizaciones.aspx")

    End Sub
End Class
