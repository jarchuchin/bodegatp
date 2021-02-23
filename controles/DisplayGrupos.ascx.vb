Imports System.Data

Partial Class controles_DisplayGrupos
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If

    End Sub

    Public carpetafiles As String = String.Empty

    Sub colocardatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"

        Dim myg As New tienda.GrupoIdioma
        Repeater1.DataSource = myg.GetDSHome(CInt(Session("ididioma")), 1)
        Repeater1.DataBind()


    End Sub

  
End Class
