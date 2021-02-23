Imports System.Data

Partial Class controles_DisplayProductosSearchFull
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






        lblFin.Text = lblSize.Text
        llenargridLimites()







    End Sub




    Function llenargridLimites() As Integer


        Dim text As String = Request("text")

        Dim clavecatego As Integer = 0
        Dim clavedesde As Decimal = 0
        Dim clavehasta As Decimal = 0

        If text = "" And clavecatego = 0 And clavedesde = 0 And clavehasta = 0 Then

            lblArticulos.Visible = False
            lblOrdenar.Visible = False
            drpOrdernar.Visible = False
            lnkAnterior1.Visible = False
            lnkSiguiente1.Visible = False
            dtproductos.Visible = False
            lnkAnterior2.Visible = False
            lnkAnterior22.Visible = False
            lnkSiguiente2.Visible = False
            lnkSiguiente22.Visible = False


        Else


            If Request("idCategoria") <> "" Then
                clavecatego = CInt(Request("idCategoria"))
            End If

            If Request("desde") <> "" Then
                clavedesde = CDec(Request("desde"))
            End If

            If Request("hasta") <> "" Then
                clavehasta = CDec(Request("hasta"))
            End If

            Dim myp As New tienda.ProductoIdioma
            Dim ds As DataSet = myp.GetDSSearchFull(CInt(Session("ididioma")), text, drpOrdernar.SelectedValue, clavecatego, clavedesde, clavehasta, "", "", "")

            Dim ds1 As DataSet = New DataSet
            Dim i As Integer = 0

            Dim totalRows As Integer = ds.Tables(0).Rows.Count
            lblArticulos.Text = ds.Tables(0).Rows.Count & " " & lblArt.Text


            If totalRows < CInt(lblFin.Text) Then
                lblFin.Text = totalRows
                lnkSiguiente1.Enabled = False
                lnkSiguiente2.Enabled = False
            Else
                lnkSiguiente1.Enabled = True
                lnkSiguiente2.Enabled = True
            End If

            ds1 = ds.Clone

            For i = CInt(lblinicio.Text) To CInt(lblFin.Text) - 1
                ds1.Tables(0).ImportRow(ds.Tables(0).Rows(i))
            Next

            dtproductos.DataSource = ds1
            dtproductos.DataBind()

            lblFin.Text = CInt(lblinicio.Text) + CInt(lblSize.Text)

            If CInt(lblinicio.Text) >= CInt(lblSize.Text) Then
                lnkAnterior1.Enabled = True
                lnkAnterior2.Enabled = True
            Else
                lnkAnterior1.Enabled = False
                lnkAnterior2.Enabled = False

            End If

        End If

        Return 1

    End Function


    Private Sub lnkAnterior1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAnterior1.Click
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        'categoria = CInt(Request("idCategoria"))
        If CInt(lblinicio.Text) > 0 Then
            If CInt(lblinicio.Text) - CInt(lblSize.Text) < 0 Then
                lblinicio.Text = 0
                lblFin.Text = lblSize.Text
            Else
                lblinicio.Text = CInt(lblinicio.Text) - CInt(lblSize.Text)
                lblFin.Text = CInt(lblFin.Text) - CInt(lblSize.Text)
            End If
        Else
            lblinicio.Text = 0
        End If
        llenargridLimites()

    End Sub

    Private Sub lnkSiguiente1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSiguiente1.Click
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        '  categoria = CInt(Request("idCategoria"))
        lblinicio.Text = lblFin.Text
        lblFin.Text = CInt(lblFin.Text) + CInt(lblSize.Text)
        llenargridLimites()

    End Sub


    Protected Sub lnkAnterior2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAnterior2.Click
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        '    categoria = CInt(Request("idCategoria"))
        If CInt(lblinicio.Text) > 0 Then
            If CInt(lblinicio.Text) - CInt(lblSize.Text) < 0 Then
                lblinicio.Text = 0
                lblFin.Text = lblSize.Text
            Else
                lblinicio.Text = CInt(lblinicio.Text) - CInt(lblSize.Text)
                lblFin.Text = CInt(lblFin.Text) - CInt(lblSize.Text)
            End If
        Else
            lblinicio.Text = 0
        End If
        llenargridLimites()
    End Sub

    Protected Sub lnkSiguiente2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSiguiente2.Click
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        '  categoria = CInt(Request("idCategoria"))
        lblinicio.Text = lblFin.Text
        lblFin.Text = CInt(lblFin.Text) + CInt(lblSize.Text)
        llenargridLimites()
    End Sub

    Protected Sub drpOrdernar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpOrdernar.SelectedIndexChanged
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        categoria = CInt(Request("idCategoria"))
        llenargridLimites()
    End Sub


    Protected Sub btncomparar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim mybtn As WebControls.LinkButton = CType(sender, WebControls.LinkButton)
        If mybtn.CommandName = "comparar" Then

            Dim i As Integer = 0
            Dim entro As Boolean = False
            For i = 0 To dtproductos.Items.Count - 1
                Dim mychk As WebControls.CheckBox = dtproductos.Items(i).FindControl("chkcomparar")
                If mychk.Checked Then

                    addProductoAComparador(dtproductos.DataKeys(dtproductos.Items(i).ItemIndex))
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


    Public Function getclave(ByVal claveP As String) As String
        If claveP.Length > 3 Then
            If CBool(Session("esAdmin")) Then
                Return claveP
            Else
                Return claveP.Substring(3)
            End If
        Else
            Return claveP

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


End Class
