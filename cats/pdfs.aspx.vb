Imports System.Data
Partial Class cats_pdfs
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If

    End Sub

    Public carpetafiles As String = String.Empty
    Public categoria As Integer = 0
    Public tags As String


    Sub colocardatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "catalogosPDF/"

        Dim myc As New tienda.CatalogoPDF()

        Dim ds As DataSet = myc.GetDS(1)

        'rptCatalogos.DataSource = myc.GetDS()
        'rptCatalogos.DataBind()


        DataList1.DataSource = ds
        DataList1.DataBind()

        DataList2.DataSource = ds
        DataList2.DataBind()

        DataList3.DataSource = ds
        DataList3.DataBind()

    End Sub


End Class
