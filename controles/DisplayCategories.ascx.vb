Imports System.Data

Partial Class controles_DisplayCategories
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        'Dim myc As New tienda.CategoriaIdioma()
        'rptCategorias.DataSource = myc.GetDSNo0
        'rptCategorias.DataBind()

        Dim myc As New tienda.CategoriaIdioma()
        rptCategorias.DataSource = myc.GetDSNo0
        rptCategorias.DataBind()


    End Sub



    Public Function getTags(ByVal clavetags As String, claveMetaKeywords As Object) As String

        Dim cadena As String = clavetags.Replace(",", " ")
        cadena = cadena.Replace(" ", "-")


        cadena = cadena & "-promocionales-articulos" '& cadenaKeywords




        Return cadena.ToLower


    End Function

    Protected Sub lnkmenu_Click(sender As Object, e As EventArgs) Handles lnkmenu.Click
        If divElementosSM.Visible = False Then
            divElementosSM.Visible = True
        Else
            divElementosSM.Visible = False
        End If
    End Sub
End Class
