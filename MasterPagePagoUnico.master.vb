
Partial Class MasterPagePagoUnico
    Inherits System.Web.UI.MasterPage

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		If Not IsPostBack Then
			colocarTags()
		End If
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			litScript.Text = GetScripts()
		End If
	End Sub

	Private Sub colocarTags()

		Page.Title = "Articulos Promocionales | TodoPromocional.com"
		Dim head As HtmlHead = CType(Page.Header, HtmlHead)
		Dim hm2 As New HtmlMeta()
		Dim hm3 As New HtmlMeta()

		hm3.Name = "Description"
		hm3.Content = "El Catálogo Más Grande de Articulos Promocionales. Servicio de Entrega Inmediata a toda la República Mexicana. Somos Importadores Directos"

		hm2.Name = "Keywords"
		hm2.Content = "artículos promocionales, articulos promocionales, artículos publicitarios, articulos publicitarios, regalos promocionales, todopromocional, todo promocional, promocional, promocionales"

		Dim path As String = Request.Path.ToLower
		If path.Contains("monterrey/default.aspx") Then
			Page.Title = "Articulos Promocionales | Monterrey | TodoPromocional.com"

			hm3.Name = "Description"
			hm3.Content = "El Catálogo Más Grande de Articulos Promocionales en monterrey, Servicio de Entrega Inmediata en la ciudad de monterrey. Somos Importadores Directos, visita nuestra sala de exibición"

			hm2.Name = "Keywords"
			hm2.Content = "articulos promocionales en monterrey, promocionales monterrey, promocionales en monterrey, Promocionales impresos en monterrey, promocionales en mty, articulos publicitarios, promocionales mty"
		End If

		If HttpContext.Current.Items("idProducto") <> "" Then
			Dim mypi As New tienda.ProductoIdioma(CInt(HttpContext.Current.Items("idProducto")), 1)
			Dim descripcionProducto As String = Replace(mypi.descripcion, "<br />", "")
			Dim keywordsProducto As String = ""
			Dim cadenatemp As String = mypi.nombre.ToLower.Replace(" ", ",")
			Dim constructor As String() = cadenatemp.Split(",")
			For i = 0 To constructor.Length - 1
				If keywordsProducto = "" Then
					If constructor(i).Length > 3 Then
						keywordsProducto = keywordsProducto & constructor(i).Trim & " promocional"
					End If
				Else
					If constructor(i).Length > 3 Then
						keywordsProducto = keywordsProducto & ", " & constructor(i).Trim & " promocional"
					End If
				End If
			Next


			hm2.Content = keywordsProducto & " " & mypi.nombre

			Dim descripcionmeta As String = descripcionProducto & ", Acabados disponibles, "
			Dim mysi As New tienda.ServicioIdioma
			Dim drServicios As System.Data.SqlClient.SqlDataReader = mysi.GetDR(1, mypi.idProducto)

			Do While drServicios.Read
				descripcionmeta = descripcionmeta & drServicios("Nombre") & ", "
			Loop
			drServicios.Close()

			descripcionmeta = descripcionmeta & " "
			Dim myci As New tienda.CaracteristicaIdioma
			Dim drFeatures As System.Data.SqlClient.SqlDataReader = myci.GetDR(1)
			Do While drFeatures.Read
				Dim cadenaFeatures As String = getfeature(CInt(drFeatures("idCaracteristica")), mypi.idProducto)
				If cadenaFeatures <> "" Then
					descripcionmeta = descripcionmeta & ", " & drFeatures("Nombre") & ", " & cadenaFeatures & ", "
				End If
			Loop
			drFeatures.Close()

			hm3.Content = keywordsProducto & ", " & descripcionmeta & "artículos promocionales, articulos promocionales, artículos publicitarios, articulos publicitarios promocional, promocionales"


			Dim carpetafilesbig As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/gde/"
			Dim mypf As New tienda.ProductoFoto(mypi.idProducto, True)


			Dim cadenaGoogle As New StringBuilder
			cadenaGoogle.AppendLine("<meta itemprop=""name"" content=""" & mypi.nombre & """>")
			cadenaGoogle.AppendLine("<meta itemprop=""description"" content=""" & mypi.descripcion & """>")
			cadenaGoogle.AppendLine("<meta itemprop=""image"" content=""" & carpetafilesbig & mypf.imagen & """>")
			litGoogleH.Text = cadenaGoogle.ToString

			Dim cadenaFacebook As New StringBuilder
			cadenaFacebook.AppendLine("<meta property=""og:title"" content=""" & mypi.nombre & """/>")
			cadenaFacebook.AppendLine("<meta property=""og:type"" content=""product""/>")
			cadenaFacebook.AppendLine("<meta property=""og:url"" content=""" & Request.Url.AbsoluteUri & """/>")
			cadenaFacebook.AppendLine("<meta property=""og:image"" content=""" & carpetafilesbig & mypf.imagen & """/>")
			cadenaFacebook.AppendLine("<meta property=""og:site_name"" content=""todopromocional.com""/>")
			cadenaFacebook.AppendLine("<meta property=""og:admins"" content=""todopromocional""/>")
			cadenaFacebook.AppendLine("<meta property=""og:description"" content=""" & mypi.descripcion & """/>")
			cadenaFacebook.AppendLine("<meta property=""og:title"" content=""The Rock""/>")
			litFacebook.Text = cadenaFacebook.ToString
		End If



		If HttpContext.Current.Items("idCategoria") <> "" Then
			Dim myci As New tienda.CategoriaIdioma(CInt(HttpContext.Current.Items("idCategoria")), 1)
			If myci.metaKeywords <> "" Then
				hm2.Content = myci.metaKeywords
			End If
			If myci.metaDescription <> "" Then
				hm3.Content = myci.metaDescription
			End If

		End If

		head.Controls.Add(hm2)
		head.Controls.Add(hm3)

	End Sub


	Private Function getfeature(ByVal clavecaracterisitca As Integer, claveProducto As Integer) As String
		Dim mypc As New tienda.ProductoCaracteristica(claveProducto, 1, clavecaracterisitca)
		If mypc.valor <> "" Then
			Return mypc.valor.Replace(vbCrLf, " ")
		Else
			Return ""
		End If
	End Function

	Private Function getclave(ByVal claveP As String) As String
		If claveP.Length > 3 Then
			Return claveP.Substring(3)
		Else
			Return claveP
		End If
	End Function

	Private Function GetScripts() As String
		Dim path As String = System.Configuration.ConfigurationManager.AppSettings("path")
		Dim cadena As String = path & "App_Themes/Default/jquery-1.4.2.min.js"
		Dim cadena2 As String = path & "App_Themes/Default/jquery.nivo.slider.pack.js"
		Dim cadena3 As String = path & "App_Themes/Default/SpryAssets/SpryMenuBar.js"
		Dim cadena4 As String = path & "App_Themes/Default/Scripts/swfobject_modified.js"
		Dim cadena5 As String = path & "App_Themes/Default/jqDropDown.jquery.min.js"
		Dim cadena6 As String = path & "App_Themes/Default/SpryAssets/SpryAccordion.js"
		Dim cadena7 As String = ""

		If Request.Path.ToLower = "/default.aspx" Then
			cadena7 = "<script language=""javascript"" async=""true"" type=""text/javascript"" src=""http://cdn.walkme.com/users/6863/walkme_6863.js""></script>"
		End If

		Return "<script type=""text/javascript"" src=""" & cadena & """></script><script type=""text/javascript"" src=""" & cadena2 & """></script><script type=""text/javascript"" src=""" & cadena3 & """></script><script type=""text/javascript"" src=""" & cadena4 & """></script><script type=""text/javascript"" src=""" & cadena5 & """></script><script type=""text/javascript"" src=""" & cadena6 & """></script>" & cadena7
	End Function
End Class
