Imports System.Globalization
Imports System.Threading
Partial Class ComoComprar
    Inherits System.Web.UI.Page
    Protected Overrides Sub initializeculture()
        Dim culture As String = session("idioma")

        thread.currentthread.currentculture = cultureinfo.createspecificculture(culture)
        thread.currentthread.currentuiculture = New cultureinfo(culture)


        MyBase.initializeculture()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim myct As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))
            'LitComocomprar.Text = myct.comoComprar

        End If
    End Sub
End Class
