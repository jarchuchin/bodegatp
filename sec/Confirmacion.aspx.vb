
Partial Class sec_Confirmacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not CInt(Session("idUserProfile")) > 0 Then
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If
		Catch ex As Exception
		End Try

		If Not IsPostBack Then
			colocardatos()
		End If
    End Sub


    Sub colocardatos()
        Dim myo As New tienda.Orden(CInt(Request("idOrden")))
        If myo.idUserProfile <> CInt(Session("idUserProfile")) Then
			Response.Redirect("~/sec/HistorialCotizaciones.aspx")
        End If

        lblfolio.Text = myo.Folio
        lblRespuesta.Text = myo.respuesta



    End Sub
End Class
