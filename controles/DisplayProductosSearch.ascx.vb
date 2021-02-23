Imports System.Data

Partial Class controles_DisplayProductosSearch
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If

    End Sub

    Public carpetafiles As String = String.Empty
    Public categoria As Integer = 0

    Sub colocardatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"

        lblNombreCatego.Text = """" & Request("text") & Request("tipo") & """"

        lblFin.Text = lblSize.Text
        llenargridLimites()
    End Sub




    Function llenargridLimites() As Integer


        Dim text As String = Request("text")
        Dim rango As String = Request("rango")
        Dim tipoCat As String = ""
        '    If text <> "" And rango <> "" Then

        If Request("tipo") <> "" Then
            tipoCat = Request("tipo")
        End If

        Dim clavedesde As Decimal = 0.1
        Dim clavehasta As Decimal = 0

        If rango <> "" Then
            Dim claverango() As String = rango.Split("-")
            clavedesde = CDec(claverango(0))
            clavehasta = CDec(claverango(1))
            drpPrecios.SelectedValue = rango
        End If

        If Request("desde") <> "" Then
            clavedesde = CDec(Request("desde"))
        End If

        If Request("hasta") <> "" Then
            clavehasta = CDec(Request("hasta"))
        End If

        If txtdesde.Text <> "" And txthasta.Text <> "" Then
            clavedesde = txtdesde.Text
            clavehasta = txthasta.Text
        Else
            If drpPrecios.SelectedValue <> "" Then
                Dim constructor As String() = drpPrecios.SelectedValue.Split("-")
                clavedesde = CDec(constructor(0).ToString)
                clavehasta = CDec(constructor(1).ToString)
            End If
        End If

        Dim myp As New tienda.ProductoIdioma
        Dim ds As DataSet = myp.GetDSSearchFull(CInt(Session("ididioma")), text, rblOrden1x.SelectedValue, 0, clavedesde, clavehasta, getListaColores, getListaMateriales, tipoCat)

        Dim ds1 As DataSet = New DataSet
        Dim i As Integer = 0

        Dim totalRows As Integer = ds.Tables(0).Rows.Count
        lblArticulos.Text = ds.Tables(0).Rows.Count & " " & lblArt.Text


         If totalRows < CInt(lblFin.Text) Then
            lblFin.Text = totalRows
        End If

        ds1 = ds.Clone

        For i = CInt(lblinicio.Text) To CInt(lblFin.Text) - 1
            ds1.Tables(0).ImportRow(ds.Tables(0).Rows(i))
        Next



        'listViewProductos.DataSource = ds1
        'listViewProductos.DataBind()

        rptproductos.DataSource = ds1
        rptproductos.DataBind()


        Dim tablePaginas As New DataTable
        tablePaginas.Columns.Add("pagina")
        tablePaginas.Columns.Add("inicio")
        tablePaginas.Columns.Add("fin")

        Dim inicioCOntar As Integer = 0
        Dim rangoContar As Integer = 0
        For i = 0 To ds.Tables(0).Rows.Count

            If i = CInt(rangoContar) Then
                inicioCOntar += 1
                rangoContar = i + CInt(lblSize.Text)
                Dim dRow As DataRow = tablePaginas.NewRow
                dRow("pagina") = inicioCOntar
                dRow("inicio") = i
                dRow("fin") = rangoContar - 1
                tablePaginas.Rows.Add(dRow)
            End If
        Next


        rptPaginas1.DataSource = tablePaginas
        rptPaginas1.DataBind()

        rptPaginas2.DataSource = tablePaginas
        rptPaginas2.DataBind()

        lblFin.Text = CInt(lblinicio.Text) + CInt(lblSize.Text)

        '  lblFin.Text = CInt(lblinicio.Text) + CInt(lblSize.Text)

        If CInt(lblFin.Text) >= ds.Tables(0).Rows.Count Then
            btnPaginas04.Enabled = False
            btnPaginas02.Enabled = False

            btnPaginas03.Enabled = True
            btnPaginas01.Enabled = True
        Else
            btnPaginas04.Enabled = True
            btnPaginas02.Enabled = True

            If CInt(lblinicio.Text) > 0 Then
                btnPaginas03.Enabled = True
                btnPaginas01.Enabled = True
            Else
                btnPaginas03.Enabled = False
                btnPaginas01.Enabled = False
            End If


        End If

        '    End If

        Return 1

    End Function







    'Protected Sub drpOrdernar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpOrdernar.SelectedIndexChanged
    '    carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
    '    categoria = CInt(Request("idCategoria"))
    '    llenargridLimites()
    'End Sub


    'Protected Sub btncomparar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim mybtn As WebControls.LinkButton = CType(sender, WebControls.LinkButton)
    '    If mybtn.CommandName = "comparar" Then

    '        Dim i As Integer = 0
    '        Dim entro As Boolean = False
    '        For i = 0 To dtproductos.Items.Count - 1
    '            Dim mychk As WebControls.CheckBox = dtproductos.Items(i).FindControl("chkcomparar")
    '            If mychk.Checked Then

    '                addProductoAComparador(dtproductos.DataKeys(dtproductos.Items(i).ItemIndex))
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

    Public Function getNombre(ByVal claveNombre As String, Optional ByVal reducir As Boolean = True) As String
        Dim regresoName As String
        If reducir Then
            If claveNombre.Length > 930 Then
                regresoName = claveNombre.Substring(0, 30).ToLower & "..."
            Else
                regresoName = claveNombre.ToLower
            End If
        Else
            regresoName = claveNombre.ToLower
        End If


        Return Char.ToUpper(regresoName(0)) & regresoName.Substring(1)
    End Function
    Protected Sub btnPaginas01_Click(sender As Object, e As EventArgs) Handles btnPaginas01.Click
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        categoria = CInt(HttpContext.Current.Items("idCategoria"))
        If CInt(lblinicio.Text) > 0 Then
            If CInt(lblinicio.Text) - CInt(lblSize.Text) < 0 Then
                lblinicio.Text = 0
                lblFin.Text = lblSize.Text
            Else
                lblinicio.Text = CInt(lblinicio.Text) - CInt(lblSize.Text)
                lblFin.Text = CInt(lblinicio.Text) + CInt(lblSize.Text) - 1
            End If
        Else
            lblinicio.Text = 0
        End If
        llenargridLimites()
    End Sub

    Protected Sub btnPaginas02_Click(sender As Object, e As EventArgs) Handles btnPaginas02.Click
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        categoria = CInt(HttpContext.Current.Items("idCategoria"))
        lblinicio.Text = lblFin.Text
        lblFin.Text = CInt(lblFin.Text) + CInt(lblSize.Text)
        llenargridLimites()
    End Sub

    Public Function BotonActivo(inicio As Integer, fin As Integer) As String

        Dim regreso As String = ""

        If CInt(lblinicio.Text) = inicio Then
            regreso = "active active"
        End If

        Return regreso
    End Function

    Sub paginar(ByVal sender As Object, ByVal e As EventArgs)

        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        categoria = CInt(HttpContext.Current.Items("idCategoria"))

        Dim btn As Button = sender
        Dim cadena() As String = btn.CommandArgument.Split(",")
        lblinicio.Text = cadena(0)
        lblFin.Text = cadena(1)
        llenargridLimites()

    End Sub

    Protected Sub btnPaginas03_Click(sender As Object, e As EventArgs) Handles btnPaginas03.Click
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        categoria = CInt(HttpContext.Current.Items("idCategoria"))
        If CInt(lblinicio.Text) > 0 Then
            If CInt(lblinicio.Text) - CInt(lblSize.Text) < 0 Then
                lblinicio.Text = 0
                lblFin.Text = lblSize.Text
            Else
                lblinicio.Text = CInt(lblinicio.Text) - CInt(lblSize.Text)
                lblFin.Text = CInt(lblinicio.Text) + CInt(lblSize.Text) - 1
            End If
        Else
            lblinicio.Text = 0
        End If
        llenargridLimites()
    End Sub

    Protected Sub btnPaginas04_Click(sender As Object, e As EventArgs) Handles btnPaginas04.Click
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        categoria = CInt(HttpContext.Current.Items("idCategoria"))
        lblinicio.Text = lblFin.Text
        lblFin.Text = CInt(lblFin.Text) + CInt(lblSize.Text)
        llenargridLimites()
    End Sub


    Public Function presentarBoton(numeroPagina As Integer) As String
        If numeroPagina < 9 Then
            Return "True"
        Else
            Return "False"
        End If
    End Function


    Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        colocardatos()
    End Sub

    Public Function getListaColores() As String
        Dim i As Integer = 0
        Dim cadena As String = ""
        For i = 0 To chkColores.Items.Count - 1
            If chkColores.Items(i).Selected Then
                If cadena = "" Then
                    cadena = chkColores.Items(i).Value
                    If chkColores.Items(i).Value.ToString.ToLower = "todos" Then
                        cadena = ""
                        Exit For
                    Else
                        cadena = chkColores.Items(i).Value
                    End If
                Else
                    cadena = cadena & "," & chkColores.Items(i).Value
                End If
            End If
        Next

        Return cadena

    End Function


    Public Function getListaMateriales() As String
        Dim i As Integer = 0
        Dim cadena As String = ""
        For i = 0 To chkMaterial.Items.Count - 1
            If chkMaterial.Items(i).Selected Then
                If cadena = "" Then

                    If chkMaterial.Items(i).Value.ToString.ToLower = "todos" Then
                        cadena = ""
                        Exit For
                    Else
                        cadena = chkMaterial.Items(i).Value
                    End If
                Else
                    cadena = cadena & "," & chkMaterial.Items(i).Value
                End If
            End If
        Next

        Return cadena

    End Function
End Class
