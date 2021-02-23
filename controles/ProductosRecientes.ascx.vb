
Partial Class controles_ProductosRecientes
    Inherits System.Web.UI.UserControl

	Protected carpetafiles As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"

	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		If Not Page.IsPostBack Then
			llenado()
		End If
	End Sub

	Private Sub llenado()
		If Session("listaRecientes") Is Nothing Then
			noItems()
		Else
			Dim listaEnSesion As List(Of tienda.Productoreciente) = CType(Session("listaRecientes"), List(Of tienda.Productoreciente))
			Dim dView As Data.DataView = tienda.Productoreciente.getDataView(listaEnSesion)

			If dView.Count = 0 Then
				noItems()
			Else
                rptproductos.DataSource = dView
                rptproductos.DataBind()
            End If

		End If
	End Sub

	Private Sub noItems()
		Me.Visible = False
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


    Public Function getclave(ByVal claveP As String, claveProducto As Integer) As String

        If CBool(Session("esAdmin")) Then
            Return "TP-" & claveProducto & ", " & claveP
        Else
            Return "TP-" & claveProducto
        End If

    End Function
End Class
