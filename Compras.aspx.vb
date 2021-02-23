Imports System.Globalization
Imports System.Threading
Imports System.Data
Imports System.Math

Partial Class Compras
    Inherits System.Web.UI.Page

	Dim objDT As System.Data.DataTable
	Dim objDR As System.Data.DataRow

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			If IsNothing(Session("tabla")) Then
				CrearCarrito()
			End If

			cargarDatos()
		End If
	End Sub

	Private Function CrearCarrito() As Integer
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

		Session("tabla") = dTable

		Return 1
	End Function

	Sub cargarDatos()
        'Try
        '	lblUsuario.Text &= Session("nombre").ToString
        'Catch ex As Exception
        '	lblUsuario.Visible = False
        'End Try

        'lblfecha.Text &= Today.ToShortDateString

		Dim cadenaOrden As String = System.Configuration.ConfigurationManager.AppSettings("HttpRedirect") & HttpUtility.UrlEncode(Request.ServerVariables("SERVER_NAME")) & Request.ApplicationPath

		objDT = Session("tabla")

		listViewOrdenDetalle.DataSource = objDT
		listViewOrdenDetalle.DataBind()

		Dim subtotal As Decimal = GetSubTotal()
		Dim impuesto As Decimal = (16 / 100) * subtotal
		lblsubtotalgeneral.Text = String.Format("{0:c}", subtotal)
		lblImpuesto.Text = String.Format("{0:c}", impuesto)
		lblTotal.Text = String.Format("{0:c}", impuesto + subtotal)
	End Sub

    Private Function GetSubTotal() As Decimal
        objDT = Session("tabla")
        Dim cantidadTotal As Decimal = 0
        Dim i As Integer
        For i = 0 To objDT.Rows.Count - 1
            cantidadTotal = cantidadTotal + CType(objDT.Rows(i).Item("Total"), Decimal)
        Next

        Return cantidadTotal
    End Function

	Private Function ActualizarCantidades() As Integer
		objDT = Session("tabla")

		Dim myDataGridItem As System.Web.UI.WebControls.DataGridItem
		Dim txtCantidad As System.Web.UI.WebControls.TextBox
		Dim i As Integer = 0
		Dim cantidadItems As Integer = 0
		' Dim mypp As New tienda.precio
		Dim myp As tienda.ProductoIdioma
		Dim costoUnitario As Decimal = 0

		For Each myDatalistItem In listViewOrdenDetalle.Items
			txtCantidad = myDatalistItem.FindControl("txtCantidadOD")
			If IsNumeric(txtCantidad.Text) Then
				myp = New tienda.ProductoIdioma(CInt(objDT.Rows(i).Item("idProducto")), 1)
				objDT.Rows(i).Item("Cantidad") = CInt(txtCantidad.Text)
				costoUnitario = New tienda.Precio().GetPrecioUnitario(myp.idProducto, tienda.TipoEntidad.Producto, CInt(txtCantidad.Text))

				objDT.Rows(i).Item("CostoUnitario") = costoUnitario
				objDT.Rows(i).Item("Total") = Round(costoUnitario * CInt(txtCantidad.Text), 2)
				objDT.Rows(i).Item("CostoEnvio") = 0
				objDT.Rows(i).Item("Descuento") = 0
				objDT.Rows(i).Item("CostoFinal") = costoUnitario
				cantidadItems += objDT.Rows(i).Item("Cantidad")

			End If
			i = i + 1
		Next
		Session("tabla") = objDT

		Return cantidadItems
	End Function

	Public Function getClave(ByVal claveproducto As Integer) As String


        If CBool(Session("esAdmin")) Then
            Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
            Return "TP-" & claveproducto & ", " & mypi.clave
        Else
            Return "TP-" & claveproducto
        End If


    End Function

	Public Function getNombre(ByVal claveproducto As Integer) As String
		Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))

		Return mypi.nombre
	End Function

    Public Function getFoto(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoFoto(claveproducto, True)

		Return System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/" & mypi.imagen
	End Function

	Public Function getventaminima(ByVal claveproducto As Integer) As String
		Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))

		Return mypi.ventaMinima
	End Function

	Public Function GetColor(ByVal claveColor As String) As String
		If IsNumeric(claveColor) Then
			Dim myc As New tienda.Color(CInt(claveColor))
			Dim mycc As New tienda.Codigocolor(myc.idCodigocolor)
			Return mycc.idioma1
		Else
			Return claveColor
		End If
    End Function

    Protected Sub listViewOrdenDetalle_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs) Handles listViewOrdenDetalle.SelectedIndexChanging
        listViewOrdenDetalle.SelectedIndex = e.NewSelectedIndex
        cargarDatos()
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

    Protected Sub listViewOrdenDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewOrdenDetalle.SelectedIndexChanged
        objDT = Session("tabla")
        Dim numero As Integer = listViewOrdenDetalle.SelectedIndex
        objDT.Rows.RemoveAt(numero)
        Session("tabla") = objDT

        Response.Redirect("~/Compras.aspx")
    End Sub

    Public Function getDetallesServicios(ByVal claveOrdenDetalle As Integer) As DataSet
        Dim myds As New tienda.OrdendetalleProductoServicio

		Return myds.GetDS(claveOrdenDetalle)
	End Function

	Public Function getTotalServicios(ByVal claveordendetalle As Integer) As Decimal
		Dim myod As New tienda.OrdendetalleProductoServicio

		Return myod.getTotalServicios(claveordendetalle)
	End Function

    Public Function getServicio(ByVal claveServicio As Integer) As String
        Dim mys As New tienda.ServicioIdioma(claveServicio, CInt(Session("idIdioma")))

		Return mys.nombre & " " & mys.unidadComponenteBase & " " & mys.componenteBase
	End Function

    

	Protected Sub lnkBtnSiguiente_Click(sender As Object, e As EventArgs) Handles lnkBtnSiguiente.Click
		Dim cantidadItems As Integer = ActualizarCantidades()
		If cantidadItems > 0 Then
			Dim cadenaOrden As String = "~/sec/grabarOrden.aspx"
			Response.Redirect(cadenaOrden)
		End If
	End Sub

   
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click

        Dim cantidadItems As Integer = ActualizarCantidades()
        Response.Redirect("~/Compras.aspx")
    End Sub
    Protected Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        Response.Redirect("~/Default.aspx")
    End Sub
End Class
