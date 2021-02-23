
Partial Class controles_DisplayRandomProductsFull
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If

    End Sub

    Public carpetafiles As String = String.Empty

    Sub colocardatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"

        Dim myp As New tienda.ProductoIdioma
        dtproductos.DataSource = myp.GetDRRandom(CInt(Session("ididioma")), 28)
        dtproductos.DataBind()


    End Sub

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
End Class

