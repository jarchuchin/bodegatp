Imports System.Web.UI

Partial Class MasterPage02
    Inherits System.Web.UI.MasterPage

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Master.addBodyClass = "bg"
		Master.fillScripts2 = True
	End Sub
End Class

