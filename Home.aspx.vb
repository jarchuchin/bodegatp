
Partial Class Home
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			colocardatos()
		End If
	End Sub

    Sub colocardatos()
        Dim myct As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))
        Page.Title = myct.nombre
	End Sub
End Class
