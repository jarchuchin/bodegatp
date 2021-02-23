
Partial Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("Nombre") = Nothing
        Session("idUserProfile") = Nothing
        Session("email") = Nothing
        Session("Carrito") = Nothing
        Session("esAdmin") = False
        System.Web.Security.FormsAuthentication.SignOut()


        Response.Redirect("~/default.aspx")
    End Sub
End Class
