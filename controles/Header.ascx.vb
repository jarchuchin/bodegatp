Imports System.Data

Partial Class Controles_Header
	Inherits System.Web.UI.UserControl

	Public WriteOnly Property displaySlider As Boolean
		Set(value As Boolean)
            '	divSlider.Visible = value
		End Set
	End Property

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			colocar()
		End If
	End Sub

    Sub colocar()

        Dim myci As New tienda.ConfiguracionIdioma(1, 1)

        Dim logo As String = "~/images/logo2019.jpg"
        'If myci.logoPrincipal <> "" Then
        '    logo = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "logos/" & myci.logoPrincipal
        'End If

        Image2.ImageUrl = logo
        imglogo.ImageUrl = logo
        imglogosm.ImageUrl = logo

        litscript.Text = getScript()
        litscript2.Text = getScript2()

        ' lblFecha.Text = Format(Date.Now, "dd MMM yyyy")
        'litusuario.Text = "Usuario"
        Try
            If CInt(Session("idUserProfile")) > 0 Then
                '	lnkSesion.NavigateUrl = "~/logout.aspx"
                '             lnkSesion.Text = "Cerrar sesión"
                'lnkPortal.NavigateUrl = "~/sec/verCompras.aspx"
                lblbienvenido.Text = "Bienvenido, " & Session("nombre") & "!"
                'userPage.Visible = False
                'menucuenta.Visible = True
                barraLogin.Visible = True
            Else
                '	lnkSesion.NavigateUrl = "~/Login.aspx"
                '             lnkSesion.Text = "Iniciar sesión"
                '             litusuario.Text = "Mi Cuenta"
                'menucuenta.Visible = False
                'userPage.Visible = True
                barraLogin.Visible = False
            End If
        Catch ex As Exception
        End Try

        Dim cadenaPath As String = System.Configuration.ConfigurationManager.AppSettings("path") & "Buscar.aspx?"
        txtbuscar.Attributes.Add("onKeyPress", "buscarEnter(event, 1, """ & cadenaPath & """)")
        btnBuscar.Attributes.Add("onClick", "buscar1(""" & cadenaPath & """)")

        txtbuscarsm.Attributes.Add("onKeyPress", "buscarEnter(event, 3, """ & cadenaPath & """)")
        btnBuscarsm.Attributes.Add("onClick", "buscar3(""" & cadenaPath & """)")


        txtbuscar2.Attributes.Add("onKeyPress", "buscarEnter2(event, 1, """ & cadenaPath & """)")
        btnBuscar2.Attributes.Add("onClick", "buscar12(""" & cadenaPath & """)")

        If IsNothing(Session("tabla")) Then
            ' liCarrito.Visible = False
        Else
            Dim objDT As System.Data.DataTable
            objDT = Session("tabla")
            If objDT.Rows.Count > 0 Then
                '     liCarrito.Visible = True
                ' litcarritovacio.Visible = False
                '     littextocarrito.Text = "Carrito " & "(" & objDT.Rows.Count & ")"
                '   litTotalCarrito.Text = "<b>Total: " & Format(SumarCarro(objDT), "c") & "</b>"
                ' dtlcarrito.DataSource = objDT
                '  dtlcarrito.DataBind()

            Else
                '    liCarrito.Visible = False
                ' litcarritovacio.Text = "<p>Carrito vacio</p>"
                ' litcarritovacio.Visible = True
            End If

        End If

        If Session("idOrden") > 0 Then
            'hiddenIdOrden.Value = CInt(Session("idOrden"))
            'Dim myo As New tienda.Orden(CInt(Session("idOrden")))
            'lnkCarrito.NavigateUrl = "~/sec/compras.aspx?idOrden=" & myo.idOrden
        End If

        If Request("text") <> "" Then
            txtbuscar.Text = Request("text")
        End If

        'Dim objCategoriaIdioma As New tienda.CategoriaIdioma()
        'listViewCategorias.DataSource = objCategoriaIdioma.GetDSNo0
        'listViewCategorias.DataBind()



        Dim myc As New tienda.CategoriaIdioma()
        Dim ds As DataSet = myc.GetDSNo0

        dtlCategorias.DataSource = ds
        dtlCategorias.DataBind()

        dtlCategorias2.DataSource = ds
        dtlCategorias2.DataBind()


    End Sub


    Public Function getFoto(ByVal fotoproductoloc As String) As String
		Return System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/" & fotoproductoloc
	End Function

	Public Function getTagsArticulos(ByVal clavetags As String) As String
		Dim cadena As String = clavetags.Replace(",", " ")
		cadena = cadena.Replace(" ", "-")
		cadena = cadena & "-promocionales-articulos"

		Return cadena.ToLower
	End Function


    Function SumarCarro(objDT As System.Data.DataTable) As Decimal
        Dim suma As Decimal = 0
        For Each dr As DataRow In objDT.Rows
            suma += dr("costoFinal") * dr("cantidad")
        Next

        suma = suma * 1.16

        Return suma
    End Function

	Private Function getQtyProductos() As Integer
		Dim productos As Integer = 0

		Try
			Dim tabla As DataTable = CType(Session("tabla"), DataTable)
			productos = tabla.Rows.Count
		Catch ex As Exception

		End Try
		Return productos
	End Function


    Public Function getScript() As String
        Dim cadena As New StringBuilder
        cadena.AppendLine("<script language=""javascript"" type=""text/javascript"">")
        cadena.AppendLine("function buscar1(dir) {")
        cadena.AppendLine("if (document.getElementById(""" & txtbuscar.ClientID & """).value.length >= 0) {")
        '     cadena.AppendLine("alert(document.getElementById(""" & drpRangoPrecios.ClientID & """).value);")
        ' cadena.AppendLine("var cadena2 = ""&rango="" + document.getElementById(""" & "" & """).value; ")
        cadena.AppendLine("var cadena = dir + ""text="" + document.getElementById(""" & txtbuscar.ClientID & """).value;  ")
        cadena.AppendLine("window.location = cadena;")
        cadena.AppendLine("}else{")
        cadena.AppendLine("alert(""Coloca la palabra de busqueda en la caja de texto"");")
        cadena.AppendLine("}")
        cadena.AppendLine("}")


        cadena.AppendLine("function buscar3(dir) {")
        cadena.AppendLine("if (document.getElementById(""" & txtbuscarsm.ClientID & """).value.length >= 0) {")
        '     cadena.AppendLine("alert(document.getElementById(""" & drpRangoPrecios.ClientID & """).value);")
        ' cadena.AppendLine("var cadena2 = ""&rango="" + document.getElementById(""" & "" & """).value; ")
        cadena.AppendLine("var cadena = dir + ""text="" + document.getElementById(""" & txtbuscarsm.ClientID & """).value;  ")
        cadena.AppendLine("window.location = cadena;")
        cadena.AppendLine("}else{")
        cadena.AppendLine("alert(""Coloca la palabra de busqueda en la caja de texto"");")
        cadena.AppendLine("}")
        cadena.AppendLine("}")

        cadena.AppendLine("function buscarEnter(e, num, dir){")
        cadena.AppendLine("var unicode=e.charCode? e.charCode : e.keyCode;")
        cadena.AppendLine("if (unicode == 13) {")
        cadena.AppendLine("e.returnValue=false;")
        cadena.AppendLine("e.cancel = true;")
        '  cadena.AppendLine("alert(num);")
        cadena.AppendLine("if (num == 1) {")
        cadena.AppendLine("buscar1(dir);")
        cadena.AppendLine("}")
        cadena.AppendLine("if (num == 2){")
        cadena.AppendLine("buscar2(dir);")
        cadena.AppendLine("}")
        cadena.AppendLine("if (num == 3){")
        cadena.AppendLine("buscar3(dir);")
        cadena.AppendLine("}")
        cadena.AppendLine("}")
        cadena.AppendLine("}")
        cadena.Append("</script>")

        'cadena.AppendLine("<script>")
        'cadena.AppendLine("$(function () {")
        'cadena.AppendLine("$(""#" & drpRangoPrecios.ClientID & """).jqDropDown();")
        'cadena.AppendLine("});")
        'cadena.AppendLine("</script>")

        cadena.AppendLine("")
        cadena.AppendLine("")

        Return cadena.ToString
    End Function

    Public Function getScript2() As String
        Dim cadena As New StringBuilder
        cadena.AppendLine("<script language=""javascript"" type=""text/javascript"">")
        cadena.AppendLine("function buscar12(dir) {")
        cadena.AppendLine("if (document.getElementById(""" & txtbuscar2.ClientID & """).value.length >= 0) {")
        '     cadena.AppendLine("alert(document.getElementById(""" & drpRangoPrecios.ClientID & """).value);")
        ' cadena.AppendLine("var cadena2 = ""&rango="" + document.getElementById(""" & "" & """).value; ")
        cadena.AppendLine("var cadena = dir + ""text="" + document.getElementById(""" & txtbuscar2.ClientID & """).value;  ")
        cadena.AppendLine("window.location = cadena;")
        cadena.AppendLine("}else{")
        cadena.AppendLine("alert(""Coloca la palabra de busqueda en la caja de texto"");")
        cadena.AppendLine("}")
        cadena.AppendLine("}")

        cadena.AppendLine("function buscarEnter2(e, num, dir){")
        cadena.AppendLine("var unicode=e.charCode? e.charCode : e.keyCode;")
        cadena.AppendLine("if (unicode == 13) {")
        cadena.AppendLine("e.returnValue=false;")
        cadena.AppendLine("e.cancel = true;")
        '  cadena.AppendLine("alert(num);")
        cadena.AppendLine("if (num == 1) {")
        cadena.AppendLine("buscar12(dir);")
        cadena.AppendLine("}")
        cadena.AppendLine("if (num == 2){")
        cadena.AppendLine("buscar22(dir);")
        cadena.AppendLine("}")
        cadena.AppendLine("}")
        cadena.AppendLine("}")
        cadena.Append("</script>")

        'cadena.AppendLine("<script>")
        'cadena.AppendLine("$(function () {")
        'cadena.AppendLine("$(""#" & drpRangoPrecios.ClientID & """).jqDropDown();")
        'cadena.AppendLine("});")
        'cadena.AppendLine("</script>")

        cadena.AppendLine("")
        cadena.AppendLine("")

        Return cadena.ToString
    End Function

    Public Function getCategos(ByVal clavecatego As Integer) As DataSet
		Dim myc As New tienda.CategoriaIdioma()
		Return myc.GetDS(CInt(Session("idIdioma")), clavecatego)
	End Function

	Public Function getTags(ByVal clavetags As String) As String
		Dim cadena As String = clavetags.Replace(",", " ")
		cadena = cadena.Replace(" ", "-")
		Return cadena.ToLower
	End Function

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/buscar.aspx?text=" & txtbuscar.Text.Trim & "&rango=")
    End Sub
    'Protected Sub imgBurguer_Click(sender As Object, e As ImageClickEventArgs) Handles imgBurguer.Click
    '    If barramenu.Visible Then
    '        barramenu.Visible = False
    '    Else
    '        barramenu.Visible = True



    '    End If
    'End Sub
    'Protected Sub imgBurguer2_Click(sender As Object, e As ImageClickEventArgs) Handles imgburguer2.Click
    '    If barramenu.Visible Then
    '        barramenu.Visible = False
    '    Else
    '        barramenu.Visible = True



    '    End If
    'End Sub


    'Protected Sub imgBurguer3_Click(sender As Object, e As ImageClickEventArgs) Handles imgburguer3.Click
    '    If barramenu2.Visible Then
    '        barramenu2.Visible = False
    '    Else
    '        barramenu2.Visible = True
    '    End If
    'End Sub

    Public Function getTags(ByVal clavetags As String, claveMetaKeywords As Object) As String

        Dim cadena As String = clavetags.Replace(",", " ")
        cadena = cadena.Replace(" ", "-")

        'Dim cadenaKeywords As String = ""
        'If Not Convert.IsDBNull(claveMetaKeywords) Then
        '    cadenaKeywords = claveMetaKeywords

        '    cadenaKeywords = cadenaKeywords.Replace(",", " ")
        '    cadenaKeywords = cadenaKeywords.Replace(" ", "-")
        'End If

        ' If cadenaKeywords <> "" Then
        cadena = cadena & "-promocionales-articulos" '& cadenaKeywords
        '  End If



        Return cadena.ToLower


    End Function


End Class
