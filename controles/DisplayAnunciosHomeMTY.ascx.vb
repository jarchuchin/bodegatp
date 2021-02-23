Imports System.Data.SqlClient
Partial Class controles_DisplayAnunciosHomeMTY
    Inherits System.Web.UI.UserControl
    Public carpetafiles As String = String.Empty
    Public activo As String = "active"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

        End If
    End Sub





    Public Function getActivo() As String
        Dim regreso As String = activo
        activo = ""
        Return regreso

    End Function

    Private entro As Boolean = False

    Public Function getEntro() As String
        If entro = False Then
            entro = True
            Return " active"
        Else
            Return ""
        End If


    End Function


End Class

