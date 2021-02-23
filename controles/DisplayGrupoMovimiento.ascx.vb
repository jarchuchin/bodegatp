Imports System.Data

Partial Class controles_DisplayGrupoMovimiento
    Inherits System.Web.UI.UserControl
    Dim varClaveGrupo As Integer = 0
    Public Property ClaveGrupo() As Integer
        Get
            Return varClaveGrupo
        End Get
        Set(ByVal value As Integer)
            varClaveGrupo = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If

    End Sub

    Public carpetafiles As String = String.Empty


    Sub colocardatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"

        If varClaveGrupo > 0 Then
            Dim mygrupo As New tienda.GrupoIdioma(varClaveGrupo, 1)
            lblNombreGrupo.Text = mygrupo.nombre
            lblcategoria.Text = varClaveGrupo
            lblFin.Text = lblSize.Text
            llenargridLimites()

            lnkVermas.NavigateUrl = "~/grupos/show/" & mygrupo.idGrupo & "/" & getTags("", mygrupo.nombre, "")

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




        Dim myp As New tienda.ProductoGrupo


        Dim ds As DataSet = myp.GetDS(1, varClaveGrupo)

        Dim ds1 As DataSet = New DataSet
        Dim i As Integer = 0

        Dim totalRows As Integer = ds.Tables(0).Rows.Count



        If totalRows <= CInt(lblFin.Text) Then
            lblFin.Text = totalRows
            lnkSiguiente1.Enabled = False
        Else
            lnkSiguiente1.Enabled = True
        End If

        ds1 = ds.Clone

        For i = CInt(lblinicio.Text) To CInt(lblFin.Text) - 1
            ds1.Tables(0).ImportRow(ds.Tables(0).Rows(i))
        Next

        rptproductos.DataSource = ds1
        rptproductos.DataBind()

        lblFin.Text = CInt(lblinicio.Text) + CInt(lblSize.Text)

        If CInt(lblinicio.Text) >= CInt(lblSize.Text) Then
            lnkAnterior1.Enabled = True

        Else
            lnkAnterior1.Enabled = False


        End If


        If totalRows > 0 Then
            paneltitulo.Visible = True
            lnkSiguiente1.Visible = True
            lnkAnterior1.Visible = True
        Else
            paneltitulo.Visible = False
            lnkSiguiente1.Visible = False
            lnkAnterior1.Visible = False
        End If


        Return 1

    End Function





    Private Sub lnkAnterior1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAnterior1.Click
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        varClaveGrupo = CInt(lblcategoria.Text)
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
        varClaveGrupo = CInt(lblcategoria.Text)
        lblinicio.Text = lblFin.Text
        lblFin.Text = CInt(lblFin.Text) + CInt(lblSize.Text)
        llenargridLimites()

    End Sub








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

