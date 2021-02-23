Imports System.Data

Partial Class controles_DisplayBanners
	Inherits System.Web.UI.UserControl

	Public WriteOnly Property posicion() As Integer
		Set(ByVal value As Integer)
			hiddenPos.Value = value
		End Set
	End Property

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
		Dim posicion As Integer = GetPosicion()
		Dim idIdioma As Integer = 1
		Dim dirPath As String = ConfigurationManager.AppSettings("carpetafiles").ToString & "Anuncios/"

		Select Case posicion
			Case 2
				Dim dr As SqlClient.SqlDataReader = New tienda.AnuncioIdioma().GetDR(idIdioma, pagina, 2)

				If pagina <> tienda.PaginaAnuncio.Categorias Then
					panelLateral.Visible = False
					panelBody.Visible = True

					Do While dr.Read
						Select Case CByte(dr("orden"))
							Case 1
								DisplayImagen(HyperLink1, Image1, dirPath & dr("nombreArchivo"), dr("url"), dr("target"), dr("tooltip"))
							Case 2
								DisplayImagen(HyperLink2, Image2, dirPath & dr("nombreArchivo"), dr("url"), dr("target"), dr("tooltip"))
							Case 3
								DisplayImagen(HyperLink3, Image3, dirPath & dr("nombreArchivo"), dr("url"), dr("target"), dr("tooltip"))
							Case 4
								DisplayImagen(HyperLink4, Image4, dirPath & dr("nombreArchivo"), dr("url"), dr("target"), dr("tooltip"))
							Case 5
								DisplayImagen(HyperLink5, Image5, dirPath & dr("nombreArchivo"), dr("url"), dr("target"), dr("tooltip"))
							Case 6
								DisplayImagen(HyperLink6, Image6, dirPath & dr("nombreArchivo"), dr("url"), dr("target"), dr("tooltip"))
						End Select
					Loop
					dr.Close()

				Else
					panelBody.Visible = False
					panelLateral.Visible = True

					dataListAnuncios.DataSource = dr
					dataListAnuncios.DataBind()
				End If

			Case 3
				Me.Visible = False
		End Select

	End Sub

	Private Function GetPagina() As Byte
		Dim pagina As Byte = 0
		Try
			pagina = CInt(hiddenPag.Value)
		Catch ex As Exception
		End Try

		Return pagina
	End Function

	Private Function GetPosicion() As Integer
		Dim posicion As Integer = 1
		Try
			posicion = CInt(hiddenPos.Value)
		Catch ex As Exception
			Return 0
		End Try

		If posicion < 1 Or posicion > 3 Then Return 0

		Return posicion
	End Function

	Protected Function GetImagen(ByVal nombreArchivo As String) As String
		Return ConfigurationManager.AppSettings("carpetafiles").ToString & "Anuncios/" & nombreArchivo
	End Function

	Private Sub DisplayImagen(ByRef lnk As HyperLink, ByVal img As Image, ByVal fullFilePath As String, ByVal url As String, ByVal target As String, ByVal tooltip As String)
		lnk.NavigateUrl = url
		lnk.Target = target
		lnk.ToolTip = tooltip
		lnk.Visible = True
		img.ImageUrl = fullFilePath
		img.ToolTip = tooltip
		img.Visible = True
	End Sub
End Class
