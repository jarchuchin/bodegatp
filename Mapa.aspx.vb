Imports System.Data

Partial Class Mapa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim myc As New tienda.CategoriaIdioma()

            dtlCategorias2.DataSource = myc.GetDR(CInt(Session("idIdioma")), "31,2")
            dtlCategorias2.DataBind()

            dtlCategorias3.DataSource = myc.GetDR(CInt(Session("idIdioma")), "11,12")
            dtlCategorias3.DataBind()

            dtlCategorias4.DataSource = myc.GetDR(CInt(Session("idIdioma")), "31")
            dtlCategorias4.DataBind()

            dtlCategorias5.DataSource = myc.GetDR(CInt(Session("idIdioma")), "13,31")
            dtlCategorias5.DataBind()

            dtlCategorias6.DataSource = myc.GetDR(CInt(Session("idIdioma")), "72")
            dtlCategorias6.DataBind()
        End If
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
