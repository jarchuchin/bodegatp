
Partial Class olvidoConfirmacion
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargardatos()

        End If
    End Sub


    Sub cargardatos()
        '   litgoogle.Text = getGoogle()

        lblfecha.Text = Format(Date.Now, "dd \de MMMM yyyy")
        'lnkCategoActual.Text = "Cotizacion # " & Request("idOrden")
        'lnkCategoActual.NavigateUrl = "verCompras.aspx?idOrden" & Request("idOrden")



    End Sub
End Class
