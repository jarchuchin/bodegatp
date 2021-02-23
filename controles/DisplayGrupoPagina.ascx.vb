Imports System.Data

Partial Class controles_DisplayGrupoPagina
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If

    End Sub

    Public carpetafiles As String = String.Empty
    Public categoria As Integer = 0
    Public tags As String

    Sub colocardatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"




        If HttpContext.Current.Items("idGrupo") <> "" Then
            lblcategoria.Text = HttpContext.Current.Items("idGrupo")
            categoria = CInt(HttpContext.Current.Items("idGrupo"))
            Dim mycatego As New tienda.GrupoIdioma(categoria, CInt(Session("idIdioma")))
            lbltags.Text = mycatego.nombre


            'lnkCategoActual.Text = mycatego.nombre
            'lnkCategoActual.NavigateUrl = "~/grupos/show/" & mycatego.idGrupo & "/" & getTags(mycatego.nombre)

            lblNombreCatego.Text = mycatego.nombre & " promocionales"

            lblFin.Text = lblSize.Text
            llenargridLimites()
        End If






    End Sub




    Function llenargridLimites() As Integer



        If lbltags.Text <> "" Then
            Dim myp As New tienda.ProductoGrupo

            Dim clavedesde As Decimal = 0
            Dim clavehasta As Decimal = 0

          


            Dim ds As DataSet = myp.GetDS(CInt(Session("ididioma")), categoria)

            Dim ds1 As DataSet = New DataSet
            Dim i As Integer = 0

            Dim totalRows As Integer = ds.Tables(0).Rows.Count
            lblArticulos.Text = ds.Tables(0).Rows.Count & " " & lblArt.Text


            'If totalRows < CInt(lblFin.Text) Then
            '    lblFin.Text = totalRows
            '    lnkSiguiente22.Enabled = False
            'Else
            '    lnkSiguiente22.Enabled = True
            'End If

            ' ds1 = ds.Clone

            'For i = CInt(lblinicio.Text) To CInt(lblFin.Text) - 1
            '    ds1.Tables(0).ImportRow(ds.Tables(0).Rows(i))
            'Next

            rptproductos.DataSource = ds
            rptproductos.DataBind()

            'lblFin.Text = CInt(lblinicio.Text) + CInt(lblSize.Text)

            'If CInt(lblinicio.Text) >= CInt(lblSize.Text) Then
            '    lnkAnterior22.Enabled = True

            'Else
            '    lnkAnterior22.Enabled = False

            'End If

        End If

        Return 1

    End Function




    Protected Sub drpOrdernar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpOrdernar.SelectedIndexChanged
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        categoria = CInt(HttpContext.Current.Items("idGrupo"))
        llenargridLimites()
    End Sub





    'Protected Sub btncomparar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim mybtn As WebControls.LinkButton = CType(sender, WebControls.LinkButton)
    '    If mybtn.CommandName = "comparar" Then

    '        Dim i As Integer = 0
    '        Dim entro As Boolean = False
    '        For i = 0 To listViewProductos.Items.Count - 1
    '            Dim mychk As WebControls.CheckBox = listViewProductos.Items(i).FindControl("chkcomparar")
    '            If mychk.Checked Then

    '                Dim hiddenIdProducto As HiddenField = CType(listViewProductos.Items(i).FindControl("hiddenIdProducto"), HiddenField)

    '                addProductoAComparador(CInt(hiddenIdProducto.Value))
    '                entro = True
    '            End If
    '        Next
    '        If entro Then
    '            Response.Redirect("~/Comparador.aspx")
    '        End If

    '    End If

    'End Sub



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

            'seccion para agergar seguimiento
            '###############################################################################
            Dim myps As New tienda.ProductoSeleccionado
            myps.SessionID = HttpContext.Current.Session.SessionID
            myps.idProducto = claveProducto
            myps.idUserProfile = CInt(Session("idUserProfile"))
            myps.add()
            '###############################################################################

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

    Public Function getTags(ByVal clavetags As String) As String
        Dim cadena As String = clavetags.Replace(",", " ")
        cadena = cadena.Replace(" ", "-")

        Return cadena.ToLower
    End Function

    Public Function getNombre(ByVal claveNombre As String, Optional ByVal reducir As Boolean = True) As String
        Dim regresoName As String
        If reducir Then
            If claveNombre.Length > 30 Then
                regresoName = claveNombre.Substring(0, 30).ToLower & "..."
            Else
                regresoName = claveNombre.ToLower
            End If
        Else
            regresoName = claveNombre.ToLower
        End If


        Return Char.ToUpper(regresoName(0)) & regresoName.Substring(1)
    End Function


    'Protected Sub lnkAnterior22_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkAnterior22.Click
    '    carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
    '    categoria = CInt(HttpContext.Current.Items("idGrupo"))
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

    'Protected Sub lnkSiguiente22_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles lnkSiguiente22.Click
    '    carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
    '    categoria = CInt(HttpContext.Current.Items("idGrupo"))
    '    lblinicio.Text = lblFin.Text
    '    lblFin.Text = CInt(lblFin.Text) + CInt(lblSize.Text)
    '    llenargridLimites()
    'End Sub



End Class
