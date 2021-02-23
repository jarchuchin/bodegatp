
Partial Class sec_EditarOrdenDatos
    Inherits System.Web.UI.Page

    
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not CInt(Session("idUserProfile")) > 0 Then
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If
		Catch ex As Exception
		End Try

		If Not IsPostBack Then
			cargarestados()
			colocardatos()
		End If
    End Sub

    Sub cargarestados()
        Dim mypais As New tienda.Pais("mx")
        Dim mye As New tienda.EstadoIdioma()
        drpestadosE.DataSource = mye.GetDS(CInt(Session("idIdioma")), mypais.idPais)
        drpestadosE.DataValueField = "idEstado"
        drpestadosE.DataTextField = "nombre"
        drpestadosE.DataBind()



        drpestadosF.DataSource = mye.GetDS(CInt(Session("idIdioma")), mypais.idPais)
        drpestadosF.DataValueField = "idEstado"
        drpestadosF.DataTextField = "Nombre"
        drpestadosF.DataBind()



    End Sub

    Sub colocardatos()
        Dim myo As New tienda.Orden(CInt(Request("idOrden")))
        dgNombre.Text = myo.nombreE
        dgEmpresa.Text = myo.NombreEmpresa
        dgfechaevento.Text = myo.fechaOrden.ToShortDateString
        dgTelefono.Text = myo.telefonoE
        dgDireccion.Text = myo.direccionE
        dgCiudadE.Text = myo.ciudadE
        drpestadosE.SelectedValue = myo.idEstadoE
        dgcpE.Text = myo.cpE
        dfNombre.Text = myo.nombreF
        dfRFC.Text = myo.rfc
        dfDireccion.Text = myo.direccionF
        dFCiudad.Text = myo.ciudadF
        drpestadosF.SelectedValue = myo.idEstadoF
        dgcpF.Text = myo.cpF
        dfTelefono.Text = myo.telefonoF
        dgEmail.Text = myo.email

        'lnkCategoActual.NavigateUrl = "~/sec/compras.aspx?idOrden=" & myo.idOrden
        'lnkCategoActual.Text = "Cotización # " & myo.idOrden

        lblfecha.Text = Format(Date.Now, "dd \de MMMM yyyy")


    End Sub

    
    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Dim myo As New tienda.Orden(CInt(Request("idOrden")))
        myo.nombreE = dgNombre.Text
        myo.NombreEmpresa = dgEmpresa.Text
        myo.fechaOrden = CDate(dgfechaevento.Text)
        myo.telefonoE = dgTelefono.Text
        myo.direccionE = dgDireccion.Text
        myo.ciudadE = dgCiudadE.Text
        myo.idEstadoE = CInt(drpestadosE.SelectedValue)
        myo.cpE = dgcpE.Text

        myo.nombreF = dfNombre.Text
        myo.rfc = dfRFC.Text
        myo.direccionF = dfDireccion.Text
        myo.ciudadF = dFCiudad.Text
        myo.idEstadoF = CInt(drpestadosF.SelectedValue)
        myo.cpF = dgcpF.Text
        myo.telefonoF = dfTelefono.Text
        myo.email = dgEmail.Text
        myo.Update()

        Response.Redirect("Compras.aspx?idOrden=" & myo.idOrden)


    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("Compras.aspx?idOrden=" & Request("idOrden"))
    End Sub
End Class
