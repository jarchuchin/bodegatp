Imports System.Threading
Imports System.Globalization
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page




    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Page.Title = "Articulos Promocionales | TodoPromocional.com"
        '     Master.displaySlider = True


        If CInt(Session("idUserProfile")) = 0 Then
            Response.Redirect("Login.aspx")
        End If
    End Sub







End Class
