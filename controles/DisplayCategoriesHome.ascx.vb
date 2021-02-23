Imports System.Data

Partial Class controles_DisplayCategoriasHome
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub
    Dim categoriaroot As Integer = 0

    Sub colocardatos()
        Dim myc As New tienda.CategoriaIdioma()

        If Request("idCategoria") <> "" Then
            Dim mycate As New tienda.Categoria(CInt(Request("idCategoria")))
            categoriaroot = mycate.idRaiz
        End If

        rptcategos2.DataSource = myc.GetDS(CInt(Session("idIdioma")), 0)
        rptcategos2.DataBind()


    End Sub


    Public Function getCollapsed(ByVal clavecatego As Integer) As Boolean
        If clavecatego = categoriaroot Then
            Return False
        Else
            Return True
        End If
    End Function

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
