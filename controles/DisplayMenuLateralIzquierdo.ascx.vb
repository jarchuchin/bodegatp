Imports System.Data

Partial Class controles_DisplayMenuLateralIzquierdo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim myc As New tienda.CategoriaIdioma()
        rptCategorias.DataSource = myc.GetDSNo0
        rptCategorias.DataBind()


    End Sub



    Public Function getTags(ByVal clavetags As String, claveMetaKeywords As Object) As String

        Dim cadena As String = clavetags.Replace(",", " ")
        cadena = cadena.Replace(" ", "-")

        'Dim cadenaKeywords As String = ""
        'If Not Convert.IsDBNull(claveMetaKeywords) Then
        '    cadenaKeywords = claveMetaKeywords

        '    cadenaKeywords = cadenaKeywords.Replace(",", " ")
        '    cadenaKeywords = cadenaKeywords.Replace(" ", "-")
        'End If

        ' If cadenaKeywords <> "" Then
        cadena = cadena & "-promocionales-articulos" '& cadenaKeywords
        '  End If



        Return cadena.ToLower


    End Function

End Class
