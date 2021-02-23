
Partial Class sec_controles_Menu
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNumeric(Session("iduserprofile")) Then
            If CInt(Session("iduserprofile")) = 0 Then
                Response.Redirect("~/login.aspx")
            End If
        Else
            Response.Redirect("~/login.aspx")
        End If

    End Sub
End Class
