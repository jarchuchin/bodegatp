
Partial Class DistribuidorConfirmacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblfecha.Text = Date.Now.ToLongDateString
    End Sub
End Class
