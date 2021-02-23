Imports System.Data.SqlClient
Partial Class controles_DisplayAnunciosHome
    Inherits System.Web.UI.UserControl
    Public carpetafiles As String = String.Empty
    Public activo As String = "active"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "Anuncios/"
        If Not IsPostBack Then
            'colocarBanners()
            llenaSlider()
        End If
    End Sub

    Private Sub llenaSlider()
        'listViewLarge.DataSource = New tienda.AnuncioIdioma().GetDR(1, tienda.PaginaAnuncio.Home, 1)
        'listViewLarge.DataBind()
        '      listViewSmall.DataSource = New tienda.AnuncioIdioma().GetDR(1, tienda.PaginaAnuncio.Home, 4)
        'listViewSmall.DataBind()

        rptBanners2.DataSource = New tienda.AnuncioIdioma().GetDR(1, tienda.PaginaAnuncio.Home, 1)
        rptBanners2.DataBind()

        rptmovil.DataSource = New tienda.AnuncioIdioma().GetDR(1, tienda.PaginaAnuncio.Home, 1)
        rptmovil.DataBind()

    End Sub

    Protected Function getImgSrc(nombreArchivo As String) As String
        Dim carpetaPath As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "Anuncios/"

        Return carpetaPath & nombreArchivo
    End Function

    Public Function getActivo() As String
        Dim regreso As String = activo
        activo = ""
        Return regreso

    End Function

    Private entro As Boolean = False

    Public Function getEntro() As String
        If entro = False Then
            entro = True
            Return " active"
        Else
            Return ""
        End If


    End Function

    Sub colocarBanners()
        Dim mya As New tienda.AnuncioIdioma
        Dim dr As SqlDataReader = mya.GetDR(1, tienda.PaginaAnuncio.Home, 1)
        Dim cadena As New StringBuilder
        Dim numero As Integer = 0
        cadena.AppendLine("<div class=""carousel slide"" id=""carousel-880641"">")
        cadena.AppendLine("<ol class=""carousel-indicators"">")

        Dim entro As Boolean = False


        Do While dr.Read
            If Not entro Then
                cadena.AppendLine("<li class=""active"" data-slide-to=""" & numero & """ data-target=""#carousel-880641""></li>")
                entro = True
            Else
                cadena.AppendLine(" <li data-slide-to=""" & numero & """ data-target=""#carousel-880641""></li>")
            End If
            numero = numero + 1
        Loop
        dr.Close()

        cadena.AppendLine("</ol>")

        entro = False
        numero = 0

        cadena.AppendLine(" <div class=""carousel-inner"">")
        dr = mya.GetDR(1, tienda.PaginaAnuncio.Home, 1)
        Do While dr.Read
            If Not entro Then
                cadena.AppendLine("<div class=""item active"">")
                cadena.AppendLine(" <a target=""" & dr("target") & """ href=""" & dr("url") & """ ><img  src=""" & carpetafiles & dr("nombreArchivo") & """   alt=""""  /></a>")
                cadena.AppendLine("</div>")
                entro = True
            Else
                cadena.AppendLine("<div class=""item"">")
                cadena.AppendLine(" <a target=""" & dr("target") & """ href=""" & dr("url") & """ ><img  src=""" & carpetafiles & dr("nombreArchivo") & """  alt=""""   /></a>")
                cadena.AppendLine("</div>")
            End If
            numero = numero + 1
        Loop
        dr.Close()


        cadena.AppendLine("</div> ")

        cadena.AppendLine("<a data-slide=""prev"" href=""#carousel-880641"" class=""left carousel-control"">‹</a> ")

        cadena.AppendLine("<a data-slide=""next"" href=""#carousel-880641"" class=""right carousel-control"">‹</a> ")
        cadena.AppendLine("<div>")

        'litBanners.Text = cadena.ToString
    End Sub
End Class

