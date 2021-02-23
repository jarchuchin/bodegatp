
Partial Class controles_DisplayProductoComparar
    Inherits System.Web.UI.UserControl

    Dim varProducto As Integer
    Public Property claveProducto() As Integer
        Get
            Return varProducto
        End Get
        Set(ByVal value As Integer)
            varProducto = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If

    End Sub



    Public precioImpresion As Decimal
    Public carpetafiles As String = ""


    Public Function getNombre(ByVal claveNombre As String, Optional ByVal reducir As Boolean = True) As String
        Dim regresoName As String
        If reducir Then
            If claveNombre.Length > 30 Then
                regresoName = claveNombre.Substring(0, 30).ToLower & "..."
            Else
                regresoName = claveNombre.ToLower
            End If
        Else
            regresoName = claveNombre.ToLower
        End If


        Return Char.ToUpper(regresoName(0)) & regresoName.Substring(1)
    End Function


    Sub colocardatos()

      

        Dim mypi As New tienda.ProductoIdioma(varProducto, CInt(Session("idIdioma")))
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        Dim carpetafilesbig As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/gde/"
        Dim mypf As New tienda.ProductoFoto(mypi.idProducto, True)

        imgProducto.ImageUrl = carpetafilesbig & mypf.imagen
        imgProducto.Width = System.Web.UI.WebControls.Unit.Pixel(200)
        lnkFoto.NavigateUrl = "~/Productos/show/" & mypi.idProducto & "/" & getTags(mypi.tags, mypi.tags, mypi.clave)


        'Barra azul
        lblNombreProducto.Text = getNombre(mypi.nombre, False)

        Dim diferencia As TimeSpan = Date.Now - mypi.fecharegistro
        If diferencia.Days < 14 Then
            panelnuevo.Visible = True
        Else
            panelnuevo.Visible = False
        End If



        'precios sin impresion
        Dim myprecio As New tienda.Precio
        escalagenreal = mypi.ventaMinima

        rptprecios.DataSource = myprecio.TablaDePrecios(mypi.idProducto)
        rptprecios.DataBind()

        'Dim mys As New tienda.Servicio(1)
        'precioImpresion = mys.precioComponenteBase

        'RptPreciosCon.DataSource = myprecio.GetDSDetailsPreciosNested(mypi.idProducto)
        'RptPreciosCon.DataBind()

        Dim mysi As New tienda.ServicioIdioma()
        RptPreciosCon.DataSource = mysi.GetDR(CInt(Session("idIdioma")), mypi.idProducto)
        RptPreciosCon.DataBind()





        If CBool(Session("esAdmin")) Then
            lblClave.Text = mypi.clave
        Else
            lblClave.Text = mypi.clave.Substring(3)
        End If


        If mypi.descripcion <> "" Then
            litdescripcion.Text = mypi.descripcion
            panelDescripciones.Visible = True
        End If
        If mypi.especificaciones <> "" Then
            litespecificacion.Text = mypi.especificaciones
            panelEspecificaciones.Visible = True
        End If

      


        Dim myci As New tienda.CaracteristicaIdioma
        rptfeatures.DataSource = myci.GetDS(CInt(Session("idIdioma")))
        rptfeatures.DataBind()


       
     



        'Colores
        Dim mycolores As New tienda.Color
        dtlcolores.datasource = mycolores.GetDR(mypi.idProducto, tienda.TipoEntidad.Producto, CInt(Session("idIdioma")))
        dtlcolores.databind()

        If dtlColores.Items.Count > 0 Then
 
        Else
            lblColoresEtiqueta.Visible = False
        End If





        'fecha
        lblfechaActualizacion.Text = mypi.fechamodificacion

        'tags
        setPlaceHolderTags(mypi.tags)


    

    End Sub


    Public feature As String = ""
    Public Function getfeature(ByVal clavecaracterisitca As Integer) As Boolean
        feature = ""

        Dim mypc As New tienda.ProductoCaracteristica(varProducto, CInt(Session("idIdioma")), clavecaracterisitca)
        If mypc.valor <> "" Then
            feature = mypc.valor.Replace(vbCrLf, "<br/>")
            Return True

        Else
            feature = ""
            Return False
        End If


    End Function

    Public escalagenreal As Integer = 0

    Public Function getEscala(ByVal escala As Integer) As String
        Dim cadena As String = escalagenreal & " - " & escala
        escalagenreal = escalagenreal + 1
        Return cadena
    End Function


    Public NombreColor As String = ""
    Public Function GetColor(ByVal clavecolor As Integer) As String
        Dim mycodcolor As New tienda.Codigocolor(clavecolor)
        If mycodcolor.idioma1 <> "" Then
            NombreColor = mycodcolor.idioma1
        Else
            NombreColor = mycodcolor.nombreWeb
        End If
        Dim cadena As String
        cadena = " <table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width: 50px; height :10px"" ><tr><td style=""width:50px; height :4px; background-color:" & mycodcolor.codigoHexadecimal & ";""></td></tr></table>"
        Return cadena

    End Function

    Public Function setPlaceHolderTags(ByVal tags As String) As Integer
        If tags <> "" Then
            Dim constructor As String() = tags.Split(",")
            Dim i As Integer = 0

            For i = 0 To constructor.Length - 1
                Dim mylnktag As New System.Web.UI.WebControls.HyperLink
                mylnktag.ID = "lnk" & i
                mylnktag.Text = constructor(i).ToString
                mylnktag.NavigateUrl = "~/buscar.aspx?text=" & constructor(i).ToString
                mylnktag.CssClass = "LigaProducto"

                Dim myespacio As New System.Web.UI.WebControls.Label
                myespacio.Text = ", "
                If i > 0 Then
                    PlaceHolder1.Controls.Add(myespacio)
                    PlaceHolder1.Controls.Add(mylnktag)
                Else
                    PlaceHolder1.Controls.Add(mylnktag)
                End If


            Next


        End If

        Return 1

    End Function


    Public Function getTags(ByVal clavetags As String, ByVal clavenombre As String, ByVal claveProducto As String) As String
        Dim myutils As New tienda.Utils

        clavenombre = myutils.depuraTags(clavenombre)
        Dim cadena As String = clavetags.Replace(",", " ")
        cadena = cadena.Replace(" ", "-")
        If cadena <> "" Then
            cadena &= "-" & clavenombre.Replace(" ", "-")
        Else
            cadena &= clavenombre.Replace(" ", "-")
        End If

        If cadena <> "" Then
            If claveProducto.Length > 3 Then
                cadena &= "-" & claveProducto.Substring(3)
            Else
                cadena &= "-" & claveProducto
            End If
        Else
            If claveProducto.Length > 3 Then
                cadena &= claveProducto.Substring(3)
            Else
                cadena &= claveProducto
            End If
        End If


        Return cadena.ToLower


    End Function

End Class
