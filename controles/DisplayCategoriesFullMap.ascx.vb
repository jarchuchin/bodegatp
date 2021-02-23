Imports System.Data

Partial Class controles_DisplayCategoriesFullMap
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocarDatos()

        Dim myc As New tienda.CategoriaIdioma()
        dtlCategos1.DataSource = myc.GetDS(CInt(Session("idIdioma")), 0)
        dtlCategos1.DataBind()

        Dim mygi As New tienda.GrupoIdioma
        dtlgrupos.DataSource = mygi.GetDS(CInt(Session("idIdioma")))
        dtlgrupos.DataBind()


    End Sub

    Public Function getCategos(ByVal clavecatego As Integer) As DataSet
        Dim myc As New tienda.CategoriaIdioma()
        Return myc.GetDS(CInt(Session("idIdioma")), clavecatego)
    End Function
    Public Function getTags(ByVal clavetags As String) As String
        Dim cadena As String = clavetags.Replace(",", " ")
        cadena = cadena.Replace(" ", "-")



        Return cadena.ToLower


    End Function

End Class
