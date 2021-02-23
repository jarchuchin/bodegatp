Imports System.Data

Partial Class controles_DisplayProductosSugeridos
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If

    End Sub

    Public carpetafiles As String = String.Empty
    Public producto As Integer = 0

    Sub colocardatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"

        If HttpContext.Current.Items("idProducto") <> "" Then
            lblcategoria.Text = HttpContext.Current.Items("idProducto")
            producto = CInt(HttpContext.Current.Items("idProducto"))
            lblFin.Text = lblSize.Text
			llenargridLimites()
		ElseIf Request("idProducto") <> "" Then
			lblcategoria.Text = Request("idProducto")
			producto = CInt(Request("idProducto"))
			lblFin.Text = lblSize.Text
			llenargridLimites()
		End If

    End Sub


    Public Function getNombre(ByVal claveNombre As String, Optional ByVal reducir As Boolean = True) As String
        Dim regresoName As String
        If reducir Then
            If claveNombre.Length > 925 Then
                regresoName = claveNombre.Substring(0, 25).ToLower & "..."
            Else
                regresoName = claveNombre.ToLower
            End If
        Else
            regresoName = claveNombre.ToLower
        End If


        Return Char.ToUpper(regresoName(0)) & regresoName.Substring(1)
    End Function


    Function llenargridLimites() As Integer




        Dim myp As New tienda.ProductoIdioma 'tienda.ProductoSeleccionado

        Dim ds As DataSet = myp.GetDSRandom(CInt(Session("ididioma")), CInt(lblSize.Text)) ' myp.GetDSSugeridos(producto)

        'Dim ds1 As DataSet = New DataSet
        'Dim i As Integer = 0

        'Dim totalRows As Integer = ds.Tables(0).Rows.Count



        'If totalRows < CInt(lblFin.Text) Then
        '    lblFin.Text = totalRows
        '    lnkSiguiente1.Enabled = False
        'Else
        '    lnkSiguiente1.Enabled = True
        'End If

        'ds1 = ds.Clone

        'For i = CInt(lblinicio.Text) To CInt(lblFin.Text) - 1
        '    ds1.Tables(0).ImportRow(ds.Tables(0).Rows(i))
        'Next

		listViewRelacionados.DataSource = ds
		listViewRelacionados.DataBind()

        'lblFin.Text = CInt(lblinicio.Text) + CInt(lblSize.Text)

        'If CInt(lblinicio.Text) >= CInt(lblSize.Text) Then
        '    lnkAnterior1.Enabled = True

        'Else
        '    lnkAnterior1.Enabled = False


        'End If


        'If totalRows > 0 Then
        '    lnkSiguiente1.Visible = True
        '    lnkAnterior1.Visible = True
        'Else
        '    lnkSiguiente1.Visible = False
        '    lnkAnterior1.Visible = False
        'End If


        Return 1

    End Function





	'Private Sub lnkAnterior1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAnterior1.Click
	'    carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
	'    producto = CInt(HttpContext.Current.Items("idProducto"))
	'    If CInt(lblinicio.Text) > 0 Then
	'        If CInt(lblinicio.Text) - CInt(lblSize.Text) < 0 Then
	'            lblinicio.Text = 0
	'            lblFin.Text = lblSize.Text
	'        Else
	'            lblinicio.Text = CInt(lblinicio.Text) - CInt(lblSize.Text)
	'            lblFin.Text = CInt(lblFin.Text) - CInt(lblSize.Text)
	'        End If
	'    Else
	'        lblinicio.Text = 0
	'    End If
	'    llenargridLimites()

	'End Sub

	'Private Sub lnkSiguiente1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSiguiente1.Click
	'    carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
	'    producto = CInt(HttpContext.Current.Items("idProducto"))
	'    lblinicio.Text = lblFin.Text
	'    lblFin.Text = CInt(lblFin.Text) + CInt(lblSize.Text)
	'    llenargridLimites()

	'End Sub






  

    Protected Sub btncomparar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim mybtn As WebControls.LinkButton = CType(sender, WebControls.LinkButton)
        If mybtn.CommandName = "comparar" Then

            Dim i As Integer = 0
            Dim entro As Boolean = False
			For i = 0 To listViewRelacionados.Items.Count - 1
				Dim mychk As WebControls.CheckBox = listViewRelacionados.Items(i).FindControl("chkcomparar")
				If mychk.Checked Then
					Dim hiddenIdProducto As HiddenField = CType(listViewRelacionados.Items(i).FindControl("chkcomparar"), HiddenField)

					addProductoAComparador(CInt(hiddenIdProducto.Value))
					entro = True
				End If
			Next
            If entro Then
                Response.Redirect("~/Comparador.aspx")
            End If

        End If

    End Sub



    Private Function getTablaComparador() As System.Data.DataTable

        If IsNothing(Session("comparador")) Then
            Dim objDT As New System.Data.DataTable("comparador")
            objDT.Columns.Add("idProducto", GetType(Integer))
            Session("comparador") = objDT
            Return objDT
        Else
            Return CType(Session("comparador"), System.Data.DataTable)

        End If

    End Function

    Public Function addProductoAComparador(ByVal claveProducto As Integer) As Boolean
        Dim objdt As System.Data.DataTable = getTablaComparador()
        Dim i As Integer = 0
        Dim existeProducto As Boolean = False
        For i = 0 To objdt.Rows.Count - 1
            If CInt(objdt.Rows(i).Item("idProducto")) = claveProducto Then
                existeProducto = True
            End If
        Next

        If Not existeProducto Then
            Dim objDR As System.Data.DataRow
            objDR = objdt.NewRow
            objDR("idProducto") = claveProducto
            objdt.Rows.Add(objDR)
            Session("comparador") = objdt

            ''seccion para agergar seguimiento
            ''###############################################################################
            'Dim myps As New tienda.ProductoSeleccionado
            'myps.SessionID = HttpContext.Current.Session.SessionID
            'myps.idProducto = claveProducto
            'myps.idUserProfile = CInt(Session("idUserProfile"))
            'myps.add()
            ''###############################################################################

            Return True
        Else
            Return False

        End If
    End Function
    Public Function getclave(ByVal claveP As String, claveProducto As Integer) As String

        If CBool(Session("esAdmin")) Then
            Return "TP-" & claveProducto & ", " & claveP
        Else
            Return "TP-" & claveProducto
        End If

    End Function

    Public Function getTags(ByVal clavetags As String, ByVal clavenombre As String, ByVal claveProducto As String) As String
        Dim myutils As New tienda.Utils
        claveProducto = myutils.depuraTags2(claveProducto)
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
End Class
