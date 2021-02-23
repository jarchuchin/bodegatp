﻿Imports System.Globalization
Imports System.Threading


Partial Class Categoria
    Inherits System.Web.UI.Page
    Protected Overrides Sub initializeculture()
        Dim culture As String = "es-MX"

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)


        MyBase.initializeculture()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocarDatos()
        If HttpContext.Current.Items("idCategoria") <> "" Then
            Dim Categoria = CInt(HttpContext.Current.Items("idCategoria"))
            Dim mycatego As New tienda.CategoriaIdioma(Categoria, CInt(Session("idIdioma")))
            Page.Title = mycatego.nombre & " promocionales articulos | TodoPromocional.com"
        End If

    End Sub

    'Protected Sub lnkmenos5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkmenos5.Click
    '    Response.Redirect("Categoria.aspx?idCategoria=" & Request("idCategoria") & "&idIdioma=" & Request("idIdioma") & "&tags=" & Request("tags") & "&desde=0&hasta=5")

    'End Sub

    'Protected Sub lnk5a10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk5a10.Click
    '    Response.Redirect("Categoria.aspx?idCategoria=" & Request("idCategoria") & "&idIdioma=" & Request("idIdioma") & "&tags=" & Request("tags") & "&desde=5&hasta=10")

    'End Sub

    'Protected Sub lnk10a25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk10a25.Click
    '    Response.Redirect("Categoria.aspx?idCategoria=" & Request("idCategoria") & "&idIdioma=" & Request("idIdioma") & "&tags=" & Request("tags") & "&desde=10&hasta=25")

    'End Sub

    'Protected Sub lnk25a50_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk25a50.Click
    '    Response.Redirect("Categoria.aspx?idCategoria=" & Request("idCategoria") & "&idIdioma=" & Request("idIdioma") & "&tags=" & Request("tags") & "&desde=25&hasta=50")

    'End Sub

    'Protected Sub lnk50a100_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk50a100.Click
    '    Response.Redirect("Categoria.aspx?idCategoria=" & Request("idCategoria") & "&idIdioma=" & Request("idIdioma") & "&tags=" & Request("tags") & "&desde=50&hasta=100")

    'End Sub

    'Protected Sub lnk100a300_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk100a300.Click
    '    Response.Redirect("Categoria.aspx?idCategoria=" & Request("idCategoria") & "&idIdioma=" & Request("idIdioma") & "&tags=" & Request("tags") & "&desde=100&hasta=300")

    'End Sub

    'Protected Sub lnk300mas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk300mas.Click
    '    Response.Redirect("Categoria.aspx?idCategoria=" & Request("idCategoria") & "&idIdioma=" & Request("idIdioma") & "&tags=" & Request("tags") & "&desde=300&hasta=0")

    'End Sub
End Class