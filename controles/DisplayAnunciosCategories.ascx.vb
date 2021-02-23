
Partial Class controles_DisplayAnunciosCategories
    Inherits System.Web.UI.UserControl
    Public carpetafiles As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "Anuncios/"
        If Not IsPostBack Then

         
            colocardatos3()
        End If
    End Sub

  
    Sub colocardatos3()
        Dim mya As New tienda.AnuncioIdioma
        DataList3.DataSource = mya.GetDR(1, tienda.PaginaAnuncio.Home, 2)
        DataList3.DataBind()

    End Sub

   
End Class
