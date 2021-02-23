Imports System.Web.UI
Imports System.Web

Partial Class MasterPage03
    Inherits System.Web.UI.MasterPage

    'Public htmlGoogle As String = "itemtype=""http://schema.org/Product"""
    'Public htmlFacebook As String = "xmlns:og=""http://ogp.me/ns#"" xmlns:fb=""http://www.facebook.com/2008/fbml"""

    Public Property displaySlider As Boolean
        Set(value As Boolean)
            Me.Header1.displaySlider = value
        End Set
        Get
            Return False
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Master.addBodyClass = "bg"
        Master.fillScripts1 = True

      
    End Sub
End Class

