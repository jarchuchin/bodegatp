Imports System.Globalization
Imports System.Threading
Imports System.Net
Imports System.Net.Mail

Partial Class ContactoConfirmacion
    Inherits System.Web.UI.Page
    Protected Overrides Sub initializeculture()
        Dim culture As String = session("idioma")

        thread.currentthread.currentculture = cultureinfo.createspecificculture(culture)
        thread.currentthread.currentuiculture = New cultureinfo(culture)


        MyBase.initializeculture()

    End Sub
End Class
