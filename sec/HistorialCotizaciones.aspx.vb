Imports System.Data

Partial Class sec_HistorialCotizaciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not CInt(Session("idUserProfile")) > 0 Then
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If
		Catch ex As Exception
		End Try

		If Not Page.IsPostBack Then
			llenado()
		End If
    End Sub

    Private Sub llenado()
        Dim objOrdenes As New tienda.Orden
        Dim dView As DataView = New tienda.Orden().GetDS(CInt(Session("idUserProfile"))).Tables(0).DefaultView

        If hiddenSortExpression.Value <> String.Empty Then
            Dim sort As String = hiddenSortExpression.Value
            If hiddenSortDirection.Value <> String.Empty Then
                sort = sort & " " & hiddenSortDirection.Value
            End If

            dView.Sort = sort
        End If

        gvOrdenes.DataSource = dView
        gvOrdenes.DataBind()

        If gvOrdenes.Rows.Count > 0 Then
            gvOrdenes.Visible = True
            lblNoData.Visible = False
        Else
            gvOrdenes.Visible = False
            lblNoData.Visible = True
        End If

    End Sub

    Protected Sub gvOrdenes_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvOrdenes.PageIndexChanging
        gvOrdenes.PageIndex = e.NewPageIndex
        llenado()
    End Sub

    Protected Sub gvOrdenes_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvOrdenes.Sorting
        If hiddenSortExpression.Value = e.SortExpression Then
            If hiddenSortDirection.Value = "ASC" Then
                hiddenSortDirection.Value = "DESC"
            Else
                hiddenSortDirection.Value = "ASC"
            End If
        Else
            hiddenSortExpression.Value = e.SortExpression
            hiddenSortDirection.Value = "ASC"
        End If

        llenado()
    End Sub
    Public Function getAsignado(ByVal clave As String) As String
        If clave <> "" Then
            If IsNumeric(clave) Then
                Dim myu As New tienda.UserProfile(CInt(clave))
                Return myu.nombre & " " & myu.apellidos
            End If
        End If
        Return "No asignado"
    End Function
End Class
