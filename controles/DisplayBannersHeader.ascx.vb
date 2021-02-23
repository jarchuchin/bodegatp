Imports System.Data.SqlClient

Partial Class controles_DisplayBannersHeader
	Inherits System.Web.UI.UserControl

	Public WriteOnly Property pagina() As tienda.PaginaAnuncio
		Set(ByVal value As tienda.PaginaAnuncio)
			hiddenPag.Value = value
		End Set
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Llenado()
	End Sub

	Private Sub Llenado()
		Dim pagina As tienda.PaginaAnuncio = GetPagina()
		Dim idIdioma As Integer = 1
		Dim dirPath As String = ConfigurationManager.AppSettings("carpetafiles").ToString & "Anuncios/"

		Dim dr As SqlDataReader = New tienda.AnuncioIdioma().GetDR(idIdioma, pagina, 1)
		If dr.Read Then
			lnkHeader.NavigateUrl = dr("url")
			lnkHeader.Target = dr("target")
			lnkHeader.ToolTip = dr("tooltip")
			imgHeader.ImageUrl = dirPath & dr("nombreArchivo")
			imgHeader.ToolTip = dr("tooltip")

			Dim newSize As System.Drawing.Size = tienda.ProductoFoto.GetSize(CInt(dr("width")), CInt(dr("height")), 450, 90)
			imgHeader.Width = newSize.Width
			imgHeader.Height = newSize.Height
		End If
		dr.Close()
	End Sub

	Private Function GetPagina() As Byte
		Dim pagina As Byte = 0
		Try
			pagina = CInt(hiddenPag.Value)
		Catch ex As Exception
		End Try

		Return pagina
	End Function
End Class
