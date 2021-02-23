Imports System.Globalization
Imports System.Threading
Imports ConwayControls

Partial Class sec_SeleccionarDireccion
    Inherits System.Web.UI.Page

    Protected Overrides Sub initializeculture()
        Dim culture As String = Session("idioma")

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)


        MyBase.initializeculture()

    End Sub
    Protected Sub btnnuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Response.Redirect("Direccion.aspx?red=1")

    End Sub

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
        Dim myd As New tienda.Direccion
        dtlDirecciones.DataSource = myd.GetDS(CInt(Session("iduserprofile")), "direccion")
        dtlDirecciones.DataBind()

        If dtlDirecciones.Rows.Count = 0 Then
            Response.Redirect("direccion.aspx?red=1")
        End If
    End Sub

    Public Function getpais(ByVal clavepais As Integer) As String
        Dim myp As New tienda.PaisIdioma(clavepais, CInt(Session("idIdioma")))
        Return myp.nombre

    End Function

    Public Function getestado(ByVal claveestado As Integer) As String
        Dim mye As New tienda.EstadoIdioma(claveestado, CInt(Session("idIdioma")))
        Return mye.nombre
    End Function

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        Dim i As Integer
        Dim clavedireccion As Integer = 0
        For i = 0 To dtlDirecciones.Rows.Count - 1
            Dim control As ConwayControls.Web.RadioButton = dtlDirecciones.Rows(i).FindControl("rdbOpciones")
            If control.Checked Then
                clavedireccion = CInt(control.Value)
            End If
        Next
        If clavedireccion > 0 Then
            Response.Redirect("checkout.aspx?idDireccion=" & clavedireccion)
        Else
            lblmensaje.visible = True
        End If

    End Sub
End Class
