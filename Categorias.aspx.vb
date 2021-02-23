
Partial Class Categorias
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub


    Sub colocardatos()

        Dim myci As New tienda.CategoriaIdioma

        drpcategorias.DataSource = myci.GetCategorias(CInt(Session("idIdioma")))
        drpcategorias.DataValueField = "idCategoria"
        drpcategorias.DataTextField = "Nombre"
        drpcategorias.DataBind()

        Dim myli As New System.Web.UI.WebControls.ListItem("todas las categorias", "0")
        drpcategorias.Items.Insert(0, myli)



    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Response.Redirect("buscaravanzada.aspx?text=" & txtbuscar.Text & "&idCategoria=" & drpcategorias.SelectedValue & "&desde=" & txtdesde.Text & "&hasta=" & txthasta.Text)

    End Sub
End Class
