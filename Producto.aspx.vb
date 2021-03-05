Imports System.Globalization
Imports System.Threading
Imports System.Web.Routing
Imports System.Web
Imports System.Data
Imports System.Math

Partial Class Producto
    Inherits System.Web.UI.Page


	Public precioImpresion As Decimal
	Public carpetafiles As String = ""
	Public pathCh As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
	Public pathMed As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/med/"
	Public pathGde As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/gde/"

	Public producto As Integer = 0
	Private idIdioma As Integer
	Private idUserProfile As Integer = 0

	Protected Overrides Sub initializeculture()
		Dim culture As String = "es-MX"

		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
		Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)

		MyBase.InitializeCulture()
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		cargarProducto()


        If CInt(Session("idUserProfile")) = 0 Then
            Response.Redirect("Login.aspx")
        End If


        If Not IsPostBack Then
			idIdioma = CInt(Session("idIdioma"))
			getIdUserProfile()
			colocardatos()
		End If
	End Sub

	Sub cargarProducto()
		producto = CInt(HttpContext.Current.Items("idProducto"))

		If Request("idProducto") <> "" Then
			producto = CInt(Request("idProducto"))
		End If

	End Sub

	Sub colocardatos()
		If Request("idProducto") <> "" Then
			producto = CInt(Request("idProducto"))
		Else
			If producto = 0 Then
				Response.Redirect("~/default.aspx")
			End If

		End If

		Dim mypi As New tienda.ProductoIdioma(producto, idIdioma)


		If Request("pregunta") <> "" Then
			Dim mypp As New tienda.ProductoPregunta

			If mypp.Count(producto, idUserProfile, Date.Now) < 4 Then
				mypp.idProducto = producto
				mypp.Pregunta = Request("pregunta")
				mypp.PreguntaFecha = Date.Now
				mypp.PreguntaUsuario = idUserProfile
				mypp.Respuesta = ""
				mypp.RespuestaFecha = Date.Now
				mypp.RespuestaUsuario = 0
				mypp.Calificacion = 0
				mypp.Eliminado = 0
				mypp.Add()
				Response.Redirect("producto.aspx?idProducto=" & producto & "&mensajePregunta=1")
			End If

		End If


		carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
		Dim carpetafilesbig As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/gde/"
		Dim carpetafilesmed As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/med/"
		Dim mypf As New tienda.ProductoFoto(mypi.idProducto, True)

		If mypf.imagen <> "" Then
			imgProductoZoom.ImageUrl = carpetafilesmed & mypf.imagen
		Else
			imgProductoZoom.ImageUrl = carpetafilesmed & "Default.jpg"
		End If

		'imgProducto.Width = System.Web.UI.WebControls.Unit.Pixel(368)
		imgProductoZoom.AlternateText = mypi.nombre & " | Articulos Promocionales"


        'seccion para agregar seguimiento
        '###############################################################################
        'Dim myps As New tienda.ProductoSeleccionado
        'myps.SessionID = System.Web.HttpContext.Current.Session.SessionID
        'myps.idProducto = mypi.idProducto
        'myps.idUserProfile = idUserProfile
        'myps.Add()

        '###############################################################################


        'Barra bread crumb
        If Request("idc") <> "" Then
            Dim categoria As Integer = CInt(Request("idc"))
            Dim mycatego As New tienda.CategoriaIdioma(categoria, 1)
            'Dim mycategoRoot As New tienda.CategoriaIdioma(mycatego.idRaiz, idIdioma)
            lnkcategoria.Text = mycatego.nombre
        Else
            lnkcategoria.Visible = False
            imgflechacatego.Visible = False
        End If

        'Barra azul


        '   Response.Write(mypi.idProducto & "---" & mypi.clave & "---" & mypi.nombre)
        ' Response.Write(mypi.nombre)
        ' Response.End()

        lblNombreProducto.Text = getNombre(mypi.nombre, False)
        lblNombreProducto2.Text = lblNombreProducto.Text
        lblnombrebread.Text = lblNombreProducto.Text



        Dim diferencia As TimeSpan = Date.Now - mypi.fecharegistro
		If diferencia.Days < 14 Then
			lblNuevo.Visible = True
		Else
			lblNuevo.Visible = False
		End If


		'precios sin impresion
		Dim myprecio As New tienda.Precio
		escalagenreal = mypi.ventaMinima

		listViewPrecios.DataSource = myprecio.TablaDePrecios3(mypi.idProducto)
		listViewPrecios.DataBind()
		If listViewPrecios.Items.Count = 0 Then
			divConfirmar.Visible = True
			lblConfirmarprecios.Visible = True
			divCotizar.Visible = False
			tablaCantidad.Visible = False
		End If

		Dim mysi As New tienda.ServicioIdioma()
		listViewPreciosCon.DataSource = mysi.GetDR(idIdioma, mypi.idProducto)
		listViewPreciosCon.DataBind()

		If CBool(Session("esAdmin")) Then
            lblClave.Text = mypi.clave.ToUpper
            lblClave2.Text = mypi.clave.ToUpper
            lblClave.Visible = True
            lblClave2.Visible = True
        Else
            lblClave.Text = mypi.clave.Substring(3).ToUpper
            lblClave2.Text = lblClave.Text.ToUpper
            lblClave2.Visible = False
            lblClave.Visible = False

        End If


        lblClaveNueva.Text = "TP-" & mypi.idProducto


        lblExistencia.Visible = False
		lblExistenciaEtiqueda.Visible = False

		'  mypi.clave = "PR-ABA001"

		'###################################################################
		'Seccion para presentar existencias de promoopcion
		'###################################################################
		'If mypi.clave.Substring(0, 2).ToLower = "pr" Then
		'    Dim clavedelproducto As String = mypi.clave.Substring(3).Trim

		'    Dim espacio As Boolean = False
		'    Dim claveconEspacios As String = ""
		'    For i = 0 To clavedelproducto.Length - 1

		'        If IsNumeric(clavedelproducto.Substring(i, 1)) And espacio = False Then
		'            claveconEspacios = claveconEspacios & " " & clavedelproducto.Substring(i, 1)
		'            espacio = True
		'        Else
		'            If Not IsNumeric(clavedelproducto.Substring(i, 1)) And espacio Then
		'                If clavedelproducto.Substring(i, 1) = "-" Then
		'                    claveconEspacios = claveconEspacios & clavedelproducto.Substring(i, 1)
		'                    espacio = True
		'                Else
		'                    claveconEspacios = claveconEspacios & " " & clavedelproducto.Substring(i, 1)
		'                    espacio = False
		'                End If

		'            Else

		'                If clavedelproducto.Substring(i, 1) = "-" Then
		'                    claveconEspacios = claveconEspacios & clavedelproducto.Substring(i, 1)
		'                Else
		'                   claveconEspacios = claveconEspacios & clavedelproducto.Substring(i, 1)
		'                End If
		'            End If

		'        End If

		'    Next





		'    Dim arregloSubclaves As String() = mypi.subclaves.Split(",")
		'    Dim claveCompuesta As String
		'    Dim cadenatable As New StringBuilder
		'    cadenatable.AppendLine("<table style=""width:100%"">")
		'    cadenatable.AppendLine("<tr>")
		'    cadenatable.AppendLine("<td style=""width:60px""></td>")
		'    cadenatable.AppendLine("<td style=""width:30px""><b>MTY</b></td>")
		'    cadenatable.AppendLine("<td style=""width:30px""><b>DF</b></td>")
		'    cadenatable.AppendLine("<td style=""width:30px""><b>GDL</b></td>")
		'    cadenatable.AppendLine("</tr>")



		'    For i = 0 To arregloSubclaves.Length - 1

		'        If arregloSubclaves(i).Trim <> "" Then
		'            claveCompuesta = claveconEspacios & " " & arregloSubclaves(i).Trim
		'        Else
		'            claveCompuesta = claveconEspacios
		'        End If


		'        Dim regresoexistenciamty As String = getdatos("http://www.promoopcion.com/exsi.php?op=1&item=" & claveCompuesta & "&city=MTY")
		'        Dim regresoexistengdl As String = getdatos("http://www.promoopcion.com/exsi.php?op=1&item=" & claveCompuesta & "&city=GDL")
		'        Dim regresoexistendf As String = getdatos("http://www.promoopcion.com/exsi.php?op=1&item=" & claveCompuesta & "&city=DF")


		'        cadenatable.AppendLine("<tr>")

		'        cadenatable.AppendLine("<td style=""width:60px"">" & claveCompuesta & "</td>")
		'        cadenatable.AppendLine("<td style=""width:30px"">" & regresoexistenciamty & "</td>")
		'        cadenatable.AppendLine("<td style=""width:30px"">" & regresoexistendf & "</td>")
		'        cadenatable.AppendLine("<td style=""width:30px"">" & regresoexistengdl & "</td>")

		'        cadenatable.AppendLine("</tr>")


		'    Next

		'    'clavedelproducto = claveconEspacios 'clavedelproducto.Substring(0, 3) & " " & clavedelproducto.Substring(3)

		'    If arregloSubclaves.Length = 0 Then

		'        Dim regresoexistenciamty As String = getdatos("http://www.promoopcion.com/exsi.php?op=1&item=" & clavedelproducto & "&city=MTY")
		'        Dim regresoexistengdl As String = getdatos("http://www.promoopcion.com/exsi.php?op=1&item=" & clavedelproducto & "&city=GDL")
		'        Dim regresoexistendf As String = getdatos("http://www.promoopcion.com/exsi.php?op=1&item=" & clavedelproducto & "&city=DF")


		'        cadenatable.AppendLine("<tr>")

		'        cadenatable.AppendLine("<td style=""width:100px"">" & clavedelproducto & "</td>")
		'        cadenatable.AppendLine("<td style=""width:30px"">" & regresoexistenciamty & "</td>")
		'        cadenatable.AppendLine("<td style=""width:30px"">" & regresoexistendf & "</td>")
		'        cadenatable.AppendLine("<td style=""width:30px"">" & regresoexistengdl & "</td>")

		'        cadenatable.AppendLine("</tr>")
		'    End If

		'    cadenatable.AppendLine("</table>")
		'    cadenatable.AppendLine("<div style=""height:10px;""></div>")




		'    lblExistencia.Text = cadenatable.ToString
		'    lblExistencia.Visible = True
		'    lblExistenciaEtiqueda.Visible = True

		'    '   lblClave.Text = clavedelproducto & "---" & claveCompuesta

		'End If





		'###################################################################
		'Seccion para presentar existencias de todoproocional
		'###################################################################

		If mypi.clave.Substring(0, 2).ToLower = "tp" Then
			If mypi.existe < 0 Then
				lblExistencia.Text = 0
			Else
				lblExistencia.Text = mypi.existencia
			End If

			lblExistencia.Visible = True
			lblExistenciaEtiqueda.Visible = True

		End If
		'    Dim clavedelproducto As String = mypi.clave.Substring(3)
		'    clavedelproducto = clavedelproducto.Replace("-", "")
		'    clavedelproducto = clavedelproducto.Replace(" ", "")
		'http://www.promoopcion.com/exsi.php?op=1&item=SOC 180-01&city=MTY
		'    Dim regresoExistenciaMty As String = getdatos("http://www.promoopcion.com/exsi.php?item=" & clavedelproducto & "&city=MTY")
		'    Dim regresoExistenGDL As String = getdatos("http://www.promoopcion.com/exsi.php?item=" & clavedelproducto & "&city=GDL")
		'    Dim regresoExistenDF As String = getdatos("http://www.promoopcion.com/exsi.php?item=" & clavedelproducto & "&city=DF")
		'    lblExistencia.Text = "GDL: " & regresoExistenGDL & ", MTY: " & regresoExistenciaMty & ", DF: " & regresoExistenDF
		'    lblExistencia.Visible = True
		'    lblExistenciaEtiqueda.Visible = True
		'Else

		'End If


		If mypi.descripcion <> "" Then
			litdescripcion.Text = mypi.descripcion
			'  panelDescripciones.Visible = True
		End If
		If mypi.especificaciones <> "" Then
            litespecificacion.Text = mypi.especificaciones
			'panelEspecificaciones.Visible = True
		End If
        Dim preciodesde As Decimal = 0
        Dim preciodesde2 As Decimal = 0

        If mypi.ventaMinima > 0 Then
			Dim cantidadx As Integer = 0
            Dim cantidadmin As Integer = 0

            Dim ds As DataSet = myprecio.GetDS(producto, tienda.TipoEntidad.Producto)
			If ds.Tables(0).Rows.Count > 0 Then
                cantidadx = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1).Item("escala")
                cantidadmin = ds.Tables(0).Rows(0).Item("escala")
            End If
			If mypi.ventaMinima < cantidadx Then
                txtCantidad.Text = cantidadmin
                RangeValidator1.MinimumValue = cantidadmin
            Else
                txtCantidad.Text = cantidadmin
                RangeValidator1.MinimumValue = cantidadmin
            End If


            Dim precio As Decimal = New tienda.Precio().GetPrecioUnitario(producto, tienda.TipoEntidad.Producto, cantidadx)
            Dim precio2 As Decimal = New tienda.Precio().GetPrecioUnitario(producto, tienda.TipoEntidad.Producto, cantidadmin)

            preciodesde = precio
            preciodesde2 = precio2
            txtsuma.Text = Format(precio2 * cantidadmin, "c")

        Else

			Dim ds As DataSet = myprecio.GetDS(producto, tienda.TipoEntidad.Producto)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim cantidadx As Integer = 0
                Dim cantidadmin As Integer = 0

                cantidadx = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1).Item("escala")
                cantidadmin = ds.Tables(0).Rows(0).Item("escala")

                txtCantidad.Text = ds.Tables(0).Rows(0).Item("escala")
                RangeValidator1.MinimumValue = ds.Tables(0).Rows(0).Item("escala")

                Dim precio As Decimal = New tienda.Precio().GetPrecioUnitario(producto, tienda.TipoEntidad.Producto, cantidadx)
                Dim precio2 As Decimal = New tienda.Precio().GetPrecioUnitario(producto, tienda.TipoEntidad.Producto, cantidadmin)

                preciodesde = precio
                preciodesde2 = precio2
                txtsuma.Text = Format(precio2 * cantidadmin, "c")
            Else
                txtCantidad.Text = 1
				RangeValidator1.MinimumValue = 1
			End If

		End If

        lblPreciodesde.Text = "Desde: " & Format(preciodesde, "c")


        Dim myci As New tienda.CaracteristicaIdioma
		listViewFeatures.DataSource = myci.GetDS(idIdioma)
		listViewFeatures.DataBind()


		'lnkampliar.NavigateUrl = carpetafilesbig & mypf.imagen
		'lnkampliar.Target = "_blank"


		'dlFotos.DataSource = mypf.GetDS(mypi.idProducto)
		'dlFotos.DataBind()

		listViewImages.DataSource = mypf.GetDS(mypi.idProducto)
		listViewImages.DataBind()


		Page.Title = getNombre(mypi.nombre, False) & " " & mypi.tags.Replace(",", " ") & " promocionales | " & getclave(mypi.clave) & " | TodoPromocional.com"


		'Colores
		Dim mycolores As New tienda.Color
		listViewColores.DataSource = mycolores.GetDR(mypi.idProducto, tienda.TipoEntidad.Producto, idIdioma)
		listViewColores.DataBind()

		If listViewColores.Items.Count > 0 Then
			'    lblColor.Visible = True
			drpcolores.DataSource = mycolores.GetDR(mypi.idProducto, tienda.TipoEntidad.Producto, idIdioma)
			drpcolores.DataTextField = "color"
			drpcolores.DataValueField = "idcolor"
			drpcolores.DataBind()

			For i As Integer = 0 To drpcolores.Items.Count - 1
				Dim myctemp As New tienda.Color(CInt(drpcolores.Items(i).Value))
				Dim mycctemp As New tienda.Codigocolor(myctemp.idCodigocolor)
				drpcolores.Items(i).Attributes.Add("style", "background-color:" & mycctemp.codigoHexadecimal & ";color:" & mycctemp.codigoHexadecimal & ";")
			Next

			divSelectColores.Visible = True
		Else
			'  lblColoresEtiqueta.Visible = False
		End If


		'compartir 
		Dim pathgeneral As String = Request.Url.ToString()
		' lnkFacebook.NavigateUrl = "http://www.facebook.com/sharer.php?u=" & pathgeneral & "&t=" & mypi.nombre & "-" & mypi.clave.Substring(3)
		'  lnktwitter.NavigateUrl = "http://twitter.com/home?status=" & pathgeneral
		'lnkmailfriend.NavigateUrl = "EnviarEmailProducto.aspx?idProducto=" & mypi.idProducto
		'hiddenFacebookLnk.Value = lnkFacebook.NavigateUrl
		'	hiddenTwitterLnk.Value = lnktwitter.NavigateUrl
		'hiddenYoutubeLnk.Value = lnkYoutube.NavigateUrl
		'fecha
		lblfechaActualizacion.Text = mypi.fechamodificacion.ToShortDateString

		'tags
		setPlaceHolderTags(mypi.tags)
		hiddenTags.Value = mypi.tags
		'listViewOtrasBusquedas.DataSource = getDataLinksTags()
		'listViewOtrasBusquedas.DataBind()

		'likethis
		'  Dim likethistodopromocional As String = "http%3A%2F%2Ftodopromocional.com%2FProductos%2Fshow%2F" & mypi.idProducto & "%2F" & getTags(mypi.tags, mypi.nombre, mypi.clave)
		' Dim likethis As String = "<iframe src=""http://www.facebook.com/plugins/like.php?href=" & likethistodopromocional & "&amp;layout=button_count&amp;show_faces=true&amp;width=100&amp;action=like&amp;colorscheme=light&amp;height=25"" scrolling=""no"" frameborder=""0"" style=""border:none; overflow:hidden; width:100px; height:25px;"" allowTransparency=""true""></iframe>"
		'litLike.Text = likethis



		If Request("idOrdenDetalle") <> "" Then
			Dim myod As New tienda.OrdenDetalle(CInt(Request("idOrdenDetalle")))
			txtCantidad.Text = myod.cantidad
			If myod.color <> "" Then
				Dim i As Integer
				For i = 0 To drpcolores.Items.Count - 1
					If drpcolores.Items(i).Text = myod.color Then
						drpcolores.Items(i).Selected = True
					Else
						drpcolores.Items(i).Selected = False
					End If
				Next
			End If
		End If

        actualizaListaProductosRecientes(producto)


        'If mypi.online = 0 Or mypi.eliminado = 0 Then
        '    lnkBtnCotizar.Visible = False
        '    lblConfirmarprecios.Visible = True

        'End If
    End Sub

	Public Function setPlaceHolderTags(ByVal tags As String) As Integer
		If tags <> "" Then
			Dim constructor As String() = tags.Split(",")
			Dim i As Integer = 0
			Dim cadena As New StringBuilder

			For i = 0 To constructor.Length - 1
				Dim mylnktag As New System.Web.UI.WebControls.HyperLink
				mylnktag.ID = "lnk" & i
				mylnktag.Text = constructor(i).ToString
				mylnktag.NavigateUrl = "~/buscar.aspx?text=" & constructor(i).ToString
				mylnktag.CssClass = "busquedaTags"
                '    mylnktag.Font.Size = 13

                'Dim myespacio As New System.Web.UI.WebControls.Label
                'myespacio.Text = ", "
                'If i > 0 Then
                '    PlaceHolder1.Controls.Add(myespacio)
                '    PlaceHolder1.Controls.Add(mylnktag)
                'Else
                '    PlaceHolder1.Controls.Add(mylnktag)
                'End If


                cadena.AppendLine("<a id=""lnkBusqueda" & i & """ class=""busquedaTags"" style=""cursor:pointer"" href=""/buscar.aspx?text=" & CultureInfo.CurrentCulture.TextInfo.ToTitleCase(constructor(i).ToString.ToLower) & """><span class=""badge"">	" & CultureInfo.CurrentCulture.TextInfo.ToTitleCase(constructor(i).ToString.ToLower) & "</span></a>")
                cadena.AppendLine("<input id=""hiddenLnk" & i & """ type=""hidden"" Value=""" & constructor(i).ToString & """ />")

			Next

			litPlaceBuscar.Text = cadena.ToString

		End If

		Return 1

	End Function

	Public Function getclave(ByVal claveP As String) As String
		If claveP.Length > 3 Then

			Return claveP.Substring(3)

		Else
			Return claveP

		End If
	End Function

	Public feature As String = ""
	Public Function getfeature(ByVal clavecaracterisitca As Integer) As Boolean
		feature = ""

		Dim mypc As New tienda.ProductoCaracteristica(producto, idIdioma, clavecaracterisitca)
		If mypc.valor <> "" Then
			feature = mypc.valor.Replace(vbCrLf, "<br/>")
			Return True

		Else
			feature = ""
			Return False
		End If


	End Function

	Public escalagenreal As Integer = 0

	Public Function getEscala(ByVal escala As Integer) As String
		Dim cadena As String = escalagenreal & " - " & escala
		escalagenreal = escalagenreal + 1
		Return cadena
	End Function


	'Protected Sub dlFotos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dlFotos.SelectedIndexChanged
	'	Dim clave As Integer = dlFotos.DataKeys(dlFotos.SelectedIndex)
	'	Dim mypf As New tienda.ProductoFoto(clave)

	'	imgProducto.ImageUrl = carpetafilesbig & mypf.imagen
	'	imgProducto.Width = System.Web.UI.WebControls.Unit.Pixel(368)

	'	'lnkampliar.NavigateUrl = carpetafilesbig & mypf.imagen
	'End Sub



	Public Function getNombre(ByVal claveNombre As String, Optional ByVal reducir As Boolean = True) As String
		Dim regresoName As String
		If reducir Then
			If claveNombre.Length > 30 Then
				regresoName = claveNombre.Substring(0, 30).ToLower & "..."
			Else
				regresoName = claveNombre.ToLower
			End If
		Else
			If claveNombre.Length > 0 Then
				regresoName = claveNombre.ToLower
			Else
				regresoName = ""
			End If

		End If


		Return Char.ToUpper(regresoName(0)) & regresoName.Substring(1)
	End Function


	Public NombreColor As String = ""
	Public Function GetColor(ByVal clavecolor As Integer) As String
		Dim mycodcolor As New tienda.Codigocolor(clavecolor)
		'If mycodcolor.idioma1 <> "" Then
		'    NombreColor = mycodcolor.idioma1
		'Else
		'    NombreColor = mycodcolor.nombreWeb
		'End If
		Dim cadena As String
		'cadena = " <table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width: 20px; height :20px"" ><tr><td style=""width:20px; height :20px; background-color:" & mycodcolor.codigoHexadecimal & ";""></td></tr></table>"
		cadena = "<span style=""background-color:" & mycodcolor.codigoHexadecimal & ";""></span>"
		Return cadena
	End Function

	'   Public Function setPlaceHolderTags(ByVal tags As String) As Integer
	'       If tags <> "" Then
	'           Dim constructor As String() = tags.Split(",")
	'           Dim i As Integer = 0

	'           For i = 0 To constructor.Length - 1
	'			Dim mylnktag As New System.Web.UI.WebControls.HyperLink
	'			With mylnktag
	'				.ID = "lnkBuscar_" & i
	'				.ClientIDMode = UI.ClientIDMode.Predictable
	'				.Text = constructor(i).ToString
	'				.CssClass = "tags_producto"
	'				'mylnktag.NavigateUrl = "~/buscar.aspx?text=" & constructor(i).ToString
	'			End With

	'			Dim hiddenTag As New HiddenField
	'			With hiddenTag
	'				.ID = "hiddenTag_" & i
	'				.ClientIDMode = UI.ClientIDMode.Predictable
	'				.Value = "~/buscar.aspx?text=" & constructor(i).ToString
	'			End With

	'			If i > 0 Then
	'				PlaceHolder1.Controls.Add(New LiteralControl(", "))
	'			End If
	'			PlaceHolder1.Controls.Add(mylnktag)
	'			PlaceHolder1.Controls.Add(hiddenTag)
	'		Next


	'       End If

	'       Return 1
	'End Function

	Protected Function getDataLinksTags() As DataTable
		Dim tabla As New DataTable
		Dim col1 As New DataColumn("texto", GetType(String))
		Dim col2 As New DataColumn("indice", GetType(Integer))
		Dim keys As DataColumn() = {col1}
		Dim row As DataRow

		tabla.Columns.Add(col1)
		tabla.Columns.Add(col2)
		tabla.PrimaryKey = keys

		Dim tags As String = hiddenTags.Value
		If tags <> "" Then
			Dim tagsArray As String() = tags.Split(",")
			For i As Integer = 0 To tagsArray.Length - 1

				row = tabla.NewRow
				row(0) = tagsArray(i)
				row(1) = i
				tabla.Rows.Add(row)
			Next
		End If

		Return tabla
	End Function

	Protected Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
		Dim precio As Decimal = New tienda.Precio().GetPrecioUnitario(producto, tienda.TipoEntidad.Producto, CInt(txtcantidad.Text))

		txtsuma.Text = Format(precio * CInt(txtcantidad.Text), "c")

	End Sub

	Protected Sub lnkBtnCotizar_Click(sender As Object, e As EventArgs) Handles lnkBtnCotizar.Click
		AgregarProductoATabla(producto, CInt(txtcantidad.Text))

		Response.Redirect("~/Compras.aspx")
	End Sub

	Public Function getTags(ByVal clavetags As String, ByVal clavenombre As String, ByVal claveProducto As String) As String
		Dim myutils As New tienda.Utils
		clavenombre = myutils.depuraTags(clavenombre)
		Dim cadena As String = clavetags.Replace(",", " ")
		cadena = cadena.Replace(" ", "-")
		If cadena <> "" Then
			cadena &= "-" & clavenombre.Replace(" ", "-")
		Else
			cadena &= clavenombre.Replace(" ", "-")
		End If

		If cadena <> "" Then
			If claveProducto.Length > 3 Then
				cadena &= "-" & claveProducto.Substring(3)
			Else
				cadena &= "-" & claveProducto
			End If
		Else
			If claveProducto.Length > 3 Then
				cadena &= claveProducto.Substring(3)
			Else
				cadena &= claveProducto
			End If
		End If


		Return cadena.ToLower


	End Function


	Public Function CrearTabla() As DataTable
		Dim dTable As New DataTable

		dTable.Columns.Add(New DataColumn("idProducto", GetType(Integer)))
		dTable.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
		dTable.Columns.Add(New DataColumn("CostoUnitario", GetType(Decimal)))
		dTable.Columns.Add(New DataColumn("Total", GetType(Decimal)))
		dTable.Columns.Add(New DataColumn("CostoEnvio", GetType(Decimal)))
		dTable.Columns.Add(New DataColumn("Descuento", GetType(Decimal)))
		dTable.Columns.Add(New DataColumn("Color", GetType(String)))
		dTable.Columns.Add(New DataColumn("CostoFinal", GetType(Decimal)))
		dTable.Columns.Add(New DataColumn("Nombre", GetType(String)))
		dTable.Columns.Add(New DataColumn("Clave", GetType(String)))
		dTable.Columns.Add(New DataColumn("Foto", GetType(String)))

		Return dTable
	End Function


	Public Function AgregarProductoATabla(claveProducto As Integer, cantidadProducto As Integer) As Integer

		Dim mypi As New tienda.ProductoIdioma(claveProducto, 1)
		Dim tablaProductos As DataTable
		If IsNothing(Session("tabla")) Then
			tablaProductos = CrearTabla()
		Else
			tablaProductos = CType(Session("tabla"), DataTable)
		End If
		Dim ProductosTotales As Integer = BuscarProdutoEnTabla(claveProducto, cantidadProducto, tablaProductos)

		tablaProductos = Session("tabla")

		Dim dRow As DataRow = tablaProductos.NewRow
		dRow("idProducto") = mypi.idProducto
		dRow("Cantidad") = ProductosTotales
		Dim costoUnitario As Decimal = New tienda.Precio().GetPrecioUnitario(claveProducto, tienda.TipoEntidad.Producto, ProductosTotales)
		dRow("CostoUnitario") = costoUnitario
		dRow("Total") = Round(ProductosTotales * costoUnitario, 2)
		dRow("CostoEnvio") = 0
		dRow("Descuento") = 0
		If drpcolores.Visible Then
			dRow("Color") = drpcolores.Items(drpcolores.SelectedIndex).Text
		Else
			dRow("Color") = ""
		End If
		dRow("CostoFinal") = costoUnitario
		dRow("Nombre") = mypi.nombre
		dRow("Clave") = getclave(mypi.clave)

		Dim mypf As New tienda.ProductoFoto(mypi.idProducto, True)
		Dim foto As String = "default.jpg"
		If mypf.existe Then
			foto = mypf.imagen
		End If
		dRow("Foto") = foto

		tablaProductos.Rows.Add(dRow)
		Session("tabla") = tablaProductos

		Return 1

	End Function

	Public Function BuscarProdutoEnTabla(claveProducto As Integer, cantidadProducto As Integer, tablaProductos As DataTable) As Integer
		Dim i As Integer
		Dim numeroProductos As Integer = cantidadProducto
		Dim renglonBorrar As Integer = 0
		For i = 0 To tablaProductos.Rows.Count - 1
			If CInt(tablaProductos.Rows(i).Item("idProducto")) = claveProducto Then
				numeroProductos = cantidadProducto + CInt(tablaProductos.Rows(i).Item("Cantidad"))
				renglonBorrar = i
			End If
		Next

		If renglonBorrar > 0 Then
			tablaProductos.Rows.RemoveAt(renglonBorrar)
		End If

		Session("tabla") = tablaProductos



		Return numeroProductos


	End Function


	Public Function getdatos(ByVal url As String) As String
		Dim result As String
		Try
			Dim objRequest As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)
			objRequest.Timeout = 3000
			objRequest.Method = "GET"
			Dim objResponse As System.Net.HttpWebResponse = objRequest.GetResponse()
			Dim sr As System.IO.StreamReader
			sr = New System.IO.StreamReader(objResponse.GetResponseStream())
			result = sr.ReadToEnd()
			sr.Close()

			'  Return result & "--" & url

			If result.Length < 50 Then
				Return result
			Else
				Return "n/a"
			End If

		Catch ex As Exception
			Return "n/a." 'ex.Message.ToString
		End Try



	End Function

	Private Sub actualizaListaProductosRecientes(idProducto As Integer)
		Dim objProductorectiente As New tienda.Productoreciente
		Dim lista As List(Of tienda.Productoreciente)

		If idUserProfile > 0 Then
			If Session("listaRecientes") Is Nothing Then
				lista = objProductorectiente.getListaRecientes(idIdioma, idUserProfile)
			Else
				lista = CType(Session("listaRecientes"), List(Of tienda.Productoreciente))
			End If
		Else
			If Session("listaRecientes") Is Nothing Then
				lista = New List(Of tienda.Productoreciente)
			Else
				lista = CType(Session("listaRecientes"), List(Of tienda.Productoreciente))
			End If
		End If

		objProductorectiente.updateLista(lista, idIdioma, idUserProfile, idProducto)
		Session("listaRecientes") = lista
	End Sub

	Private Sub getIdUserProfile()
		Try
			idUserProfile = Session("idUserProfile")
		Catch ex As Exception
		End Try
	End Sub
End Class
