
Partial Class controles_DisplayBannersDefault
    Inherits System.Web.UI.UserControl

    Public carpetafiles As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "Anuncios/"
        If Not IsPostBack Then

            colocardatos2()
            colocardatos3()
        End If
    End Sub

   
    Sub colocardatos2()
        Dim mya As New tienda.AnuncioIdioma
        DataList2.DataSource = mya.GetDS(1, tienda.PaginaAnuncio.Home, 1)
        DataList2.DataBind()

    End Sub

    Sub colocardatos3()
        Dim mya As New tienda.AnuncioIdioma
        DataList3.DataSource = mya.GetDR(1, tienda.PaginaAnuncio.Home, 2)
        DataList3.DataBind()

    End Sub

    Protected Sub DataList2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles DataList2.PageIndexChanging
        DataList2.PageIndex = e.NewPageIndex

        colocardatos2()

    End Sub
End Class
