
Partial Class Distribuidor
    Inherits System.Web.UI.Page

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As System.EventArgs) Handles btnRegistrar.Click
        Dim myd As New tienda.Distribuidor
        myd.Nombre = txtNombre.Text
        myd.Email = txtEmail.Text
        myd.Password = txtContraseña.Text
        myd.Telefono = txtTelefono.Text
        myd.idEstado = CInt(drpestados.SelectedValue)
        myd.RazonSocial = txtRazonSocial.Text
        myd.Giro = drpgiro.SelectedItem.Text
        myd.RFC = txtRFC.Text
        myd.Direccion = txtDireccion.Text
        myd.PaginaWeb = txtPaginaWeb.Text
        myd.Comentarios = txtComentarios.Text
        myd.FechaRegistro = Date.Now
        myd.Add()

        Response.Redirect("DistribuidorConfirmacion.aspx?idDistribuidor=" & myd.idDistribuidor)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Response.Redirect("AddUserDistribuidor.aspx")
        If Not IsPostBack Then
            llenardrop()
        End If
    End Sub

    Sub llenardrop()
        Dim myestados As New tienda.EstadoIdioma()
        drpestados.DataSource = myestados.GetDS(1, 5)
        drpestados.DataTextField = "Nombre"
        drpestados.DataValueField = "idEstado"
        drpestados.DataBind()



    End Sub
End Class
