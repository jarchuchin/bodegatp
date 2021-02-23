
Partial Class sec_SolicitarFacturaConfirmar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub


    Sub colocarDatos()
        lblCodigo.Text = Request("clave")


        litNumOrden.Text = Request("idOrden")

    End Sub
End Class
