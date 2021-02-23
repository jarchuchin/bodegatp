
Partial Class ProyectoStatus
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        If Page.IsValid Then
            Dim myo As New tienda.Orden(CInt(txtBuscar.Text))
            Response.Redirect("ProyectoAvance.aspx?idOrden=" & myo.idOrden)
        End If
    End Sub

    Protected Sub CustomValidator1_ServerValidate(source As Object, args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If txtBuscar.Text <> "" Then
            If IsNumeric(txtBuscar.Text) Then
                Dim myo As New tienda.Orden(CInt(txtBuscar.Text))
                If myo.existe Then
                    args.IsValid = True
                Else
                    args.IsValid = False
                End If
            Else
                args.IsValid = False
            End If
        Else
            args.IsValid = False
        End If
    End Sub

	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		Try
			If Not CInt(Session("idUserProfile")) > 0 Then
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If
		Catch ex As Exception
		End Try
	End Sub
End Class
