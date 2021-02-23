Imports System.Globalization
Imports System.Threading

Partial Class sec_Direccion
    Inherits System.Web.UI.Page

	Protected Overrides Sub initializeculture()
		Dim culture As String = Session("idioma")

		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
		Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)

		MyBase.InitializeCulture()
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not CInt(Session("idUserProfile")) > 0 Then
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If
		Catch ex As Exception
		End Try


		If Not IsPostBack Then
			llenardrops()
			colocardatos()
		End If
	End Sub


    Sub llenardrops()
        Dim myp As New tienda.PaisIdioma
        drppaises.DataSource = myp.GetDS(CInt(Session("idIdioma")))
        drppaises.DataBind()

        drppaises.SelectedValue = 5

        If drppaises.Items.Count > 0 Then
            Dim myestados As New tienda.EstadoIdioma
            drpEstado.DataSource = myestados.GetDS(1, 5)
            drpEstado.DataBind()

        End If
    End Sub

    Sub colocardatos()
        If Request("idDireccion") <> "" Then
            Dim myd As New tienda.Direccion(CInt(Request("idDireccion")))
            If myd.iduserProfile <> CInt(Session("idUserProfile")) Then
				Response.Redirect("HistorialCotizaciones.aspx")
            End If
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

    Protected Sub drppaises_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drppaises.SelectedIndexChanged
        Dim myestados As New tienda.EstadoIdioma
        drpEstado.DataSource = myestados.GetDS(CInt(Session("idIdioma")), CInt(drppaises.SelectedValue))
        drpEstado.DataBind()
    End Sub

    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar.Click

        Dim num As Integer = 0
        If Request("idDireccion") <> "" Then
            num = editar()
        Else
            num = grabar()

        End If

        If Request("red") = "1" Then
            Response.Redirect("seleccionarDireccion.aspx?idDireccion=" & num)
        End If

        Response.Redirect("Direcciones.aspx")


    End Sub

    Function editar() As Integer
        Dim myd As New tienda.Direccion(CInt(Request("idDireccion")))
        myd.direccion = txtdireccion.Text
        myd.ciudad = txtciudad.Text
        myd.telefono = txttelefono.Text
        myd.cp = txtcp.Text
        myd.idPais = CInt(drppaises.SelectedValue)
        myd.idEstado = CInt(drpEstado.SelectedValue)
        myd.Update()
        Return myd.idDireccion
    End Function

    Function grabar() As Integer
        Dim myd As New tienda.Direccion()
        myd.nombre = ""
        myd.apellidos = ""
        myd.direccion = txtdireccion.Text
        myd.iduserProfile = CInt(Session("idUserProfile"))
        myd.ciudad = txtciudad.Text
        myd.telefono = txttelefono.Text
        myd.cp = txtcp.Text
        myd.idPais = CInt(drppaises.SelectedValue)
        myd.idEstado = CInt(drpEstado.SelectedValue)
        myd.tipo = "direccion"
        myd.Add()
        Return myd.idDireccion

    End Function
End Class
