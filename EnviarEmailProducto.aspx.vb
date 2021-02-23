Imports System.Net
Imports System.Net.Mail
Imports System.IO
Imports System.Data

Partial Class EnviarEmailProducto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarProducto()
        End If
    End Sub
    Public carpetafiles As String = ""
    Public producto As Integer = 0

    Sub cargarproducto()

        If Request("idProducto") <> "" Then
            producto = CInt(Request("idProducto"))
        Else
            If producto = 0 Then
                '  Response.Redirect("default.aspx")
                Response.Redirect("~/default.aspx")
            End If

        End If

        Dim mypi As New tienda.ProductoIdioma(producto, CInt(Session("idIdioma")))
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/"
        Dim carpetafilesbig As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/gde/"
        Dim mypf As New tienda.ProductoFoto(mypi.idProducto, True)

        imgProducto.ImageUrl = carpetafilesbig & mypf.imagen
        imgProducto.Width = System.Web.UI.WebControls.Unit.Pixel(405)


        'seccion para agergar seguimiento
        '###############################################################################
        Dim myps As New tienda.ProductoSeleccionado
        myps.SessionID = System.Web.HttpContext.Current.Session.SessionID
        myps.idProducto = mypi.idProducto
        myps.idUserProfile = CInt(Session("idUserProfile"))
        myps.Add()

        '###############################################################################


        'Barra bread crumb
        If Request("idCategoria") <> "" Then
            Dim categoria As Integer = CInt(Request("idCategoria"))
            Dim mycatego As New tienda.CategoriaIdioma(categoria, CInt(Session("idIdioma")))
            Dim mycategoRoot As New tienda.CategoriaIdioma(mycatego.idRaiz, CInt(Session("idIdioma")))
			'lnkCategoRoot.Text = mycategoRoot.nombre
			'lnkCategoRoot.NavigateUrl = "~/Default.aspx?idCategoria=" & mycategoRoot.idCategoria

			'lnkCategoActual.Text = mycatego.nombre
			'lnkCategoActual.NavigateUrl = "~/categoria.aspx?idCategoria=" & mycatego.idCategoria & "&idIdioma=" & mycatego.idIdioma & "&tags=" & mycatego.tags

			'lbl1.Visible = True
			'lbl2.Visible = True

        End If

        'Barra azul
        lblNombreProducto.Text = getNombre(mypi.nombre, False)
		'lnkCategoActual.Text = lblNombreProducto.Text
		'lbl1.Visible = True

        Dim diferencia As TimeSpan = Date.Now - mypi.fecharegistro
        If diferencia.Days < 14 Then
            panelnuevo.Visible = True
        Else
            panelnuevo.Visible = False
        End If


        'precios sin impresion
        Dim myprecio As New tienda.Precio
        ' escalagenreal = mypi.ventaMinima

        rptprecios.DataSource = myprecio.TablaDePrecios2(mypi.idProducto)
        rptprecios.DataBind()
        If rptprecios.Rows.Count = 0 Then
            'lblConfirmarprecios.Visible = True
            'panelconfirmar.Visible = True
            'btnAgregar.Visible = False
            'txtcantidad.Visible = False
        End If
        'Dim mys As New tienda.Servicio(1)
        'precioImpresion = mys.precioComponenteBase

        'RptPreciosCon.DataSource = myprecio.GetDSDetailsPreciosNested(mypi.idProducto)
        'RptPreciosCon.DataBind()

        Dim mysi As New tienda.ServicioIdioma()
        rptprecioscon.DataSource = mysi.GetDR(CInt(Session("idIdioma")), mypi.idProducto)
        rptprecioscon.DataBind()




        If CBool(Session("esAdmin")) Then
            lblClave.Text = mypi.clave
        Else
            lblClave.Text = mypi.clave.Substring(3)
        End If



        If mypi.descripcion <> "" Then
            litdescripcion.Text = mypi.descripcion
            '  panelDescripciones.Visible = True
        End If
        If mypi.especificaciones <> "" Then
            ' litespecificacion.Text = mypi.especificaciones
            'panelEspecificaciones.Visible = True
        End If

        'If mypi.ventaMinima > 0 Then
        '    'txtcantidad.Text = mypi.ventaMinima
        '    RangeValidator1.MinimumValue = mypi.ventaMinima

        '    Dim precio As Decimal = New tienda.Precio().GetPrecioUnitario(producto, tienda.TipoEntidad.Producto, CInt(txtcantidad.Text))
        '    txtsuma.Text = Format(precio * CInt(txtcantidad.Text), "c")
        'Else
        '    txtcantidad.Text = 1
        '    RangeValidator1.MinimumValue = 1
        'End If



        Dim myci As New tienda.CaracteristicaIdioma
        rptfeatures.DataSource = myci.GetDS(CInt(Session("idIdioma")))
        rptfeatures.DataBind()


        lnkampliar.NavigateUrl = carpetafilesbig & mypf.imagen
        lnkampliar.Target = "_blank"


        dlFotos.DataSource = mypf.GetDS(mypi.idProducto)
        dlFotos.DataBind()

        Page.Title = "todopromocional.com: Enviar correo electrónico " & mypi.nombre & " " & mypi.tags


        'Colores
        Dim mycolores As New tienda.Color
        dtlColores.DataSource = mycolores.GetDR(mypi.idProducto, tienda.TipoEntidad.Producto, CInt(Session("idIdioma")))
        dtlColores.DataBind()

        'If dtlColores.Items.Count > 0 Then
        '    '    lblColor.Visible = True
        '    drpcolores.DataSource = mycolores.GetDR(mypi.idProducto, tienda.TipoEntidad.Producto, CInt(Session("idIdioma")))
        '    drpcolores.DataTextField = "color"
        '    drpcolores.DataValueField = "idcolor"
        '    drpcolores.DataBind()

        '    For i As Integer = 0 To drpcolores.Items.Count - 1
        '        Dim myctemp As New tienda.Color(CInt(drpcolores.Items(i).Value))
        '        Dim mycctemp As New tienda.Codigocolor(myctemp.idCodigocolor)
        '        drpcolores.Items(i).Attributes.Add("style", "background-color:" & mycctemp.codigoHexadecimal & ";color:" & mycctemp.codigoHexadecimal & ";")
        '    Next

        '    drpcolores.Visible = True
        'Else
        '    '  lblColoresEtiqueta.Visible = False
        'End If


        'compartir 
        Dim pathgeneral As String = Request.Url.ToString()
        '     lnkFacebook.NavigateUrl = "http://www.facebook.com/sharer.php?u=" & pathgeneral & "&t=" & mypi.nombre & "-" & mypi.clave.Substring(3)
        '      lnktwitter.NavigateUrl = "http://twitter.com/home?status=" & pathgeneral

        '    lnkmailfriend.NavigateUrl = "EnviarEmailProducto.aspx?idProducto=" & mypi.idProducto

        'fecha
        lblfechaActualizacion.Text = mypi.fechamodificacion.ToShortDateString

        'tags
        'setPlaceHolderTags(mypi.tags)


        'likethis
        'Dim likethistodopromocional As String = "http%3A%2F%2Ftodopromocional.com%2FProductos%2Fshow%2F" & mypi.idProducto & "%2F" & getTags(mypi.tags, mypi.nombre, mypi.clave)
        'Dim likethis As String = "<iframe src=""http://www.facebook.com/plugins/like.php?href=" & likethistodopromocional & "&amp;layout=button_count&amp;show_faces=true&amp;width=100&amp;action=like&amp;colorscheme=light&amp;height=25"" scrolling=""no"" frameborder=""0"" style=""border:none; overflow:hidden; width:100px; height:25px;"" allowTransparency=""true""></iframe>"
        'litLike.Text = likethis



        'If Request("idOrdenDetalle") <> "" Then
        '    Dim myod As New tienda.OrdenDetalle(CInt(Request("idOrdenDetalle")))
        '    txtcantidad.Text = myod.cantidad
        '    If myod.color <> "" Then
        '        Dim i As Integer
        '        For i = 0 To drpcolores.Items.Count - 1
        '            If drpcolores.Items(i).Text = myod.color Then
        '                drpcolores.Items(i).Selected = True
        '            Else
        '                drpcolores.Items(i).Selected = False
        '            End If
        '        Next
        '    End If
        'End If

    End Sub




    Public NombreColor As String = ""
    Public Function GetColor(ByVal clavecolor As Integer) As String
        Dim mycodcolor As New tienda.Codigocolor(clavecolor)
        If mycodcolor.idioma1 <> "" Then
            NombreColor = mycodcolor.idioma1
        Else
            NombreColor = mycodcolor.nombreWeb
        End If
        Dim cadena As String
        cadena = " <table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width: 20px; height :20px"" ><tr><td style=""width:20px; height :20px; background-color:" & mycodcolor.codigoHexadecimal & ";""></td></tr></table>"
        Return cadena

    End Function



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

    Public feature As String = ""
    Public Function getfeature(ByVal clavecaracterisitca As Integer) As Boolean
        feature = ""

        Dim mypc As New tienda.ProductoCaracteristica(producto, CInt(Session("idIdioma")), clavecaracterisitca)
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


    Protected Sub btnEnviar_Click(sender As Object, e As System.EventArgs) Handles btnEnviar.Click
        enviarCorreo()
    End Sub

    Sub enviarCorreo()
        Dim cadena As New StringBuilder
        Dim mypi As New tienda.ProductoIdioma(CInt(Request("idProducto")), CInt(Session("idIdioma")))
        Dim mypf As New tienda.ProductoFoto(mypi.idProducto, True)
        Dim carpetafilesbig As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/gde/" & mypf.imagen
        Dim carpetafilesbanner As String = "http://todopromocional.com/images/bannermails.jpg"

        cadena.AppendLine("<style>")
        cadena.AppendLine("body{font-famili:Arial; font-size:11px;}")
        cadena.AppendLine(".title1 {font-family: Arial, Helvetica, sans-serif;font-size: 24px;color: #666;}")
        cadena.AppendLine(".textoNegro {font-family: Arial, Helvetica, sans-serif;font-size: 12px;color: black;}")
        cadena.AppendLine(".textoGris {font-family: Arial, Helvetica, sans-serif;font-size: 11px;color: #666;}")
        cadena.AppendLine(".border-box {border: 1px solid #CCC;-webkit-border-radius: 8px;-moz-border-radius: 8px;border-radius: 8px;padding: 5px 10px;background-color: #F5F5F5;}")
        cadena.AppendLine(".txt-red1 {font-family: Arial, Helvetica, sans-serif;font-size: 11px;color: #C30;}")

        cadena.AppendLine("</style>")

        cadena.AppendLine("<img src=""" & carpetafilesbanner & """ border=""0""  width=""850px""/> <br>")
        cadena.AppendLine("<div style=""height:10px;""></div>")
        cadena.AppendLine("<div style=""width:100%;"" class=""textoNegro"" ><b>Hola:</b><br><br>" & txtMensaje.Text & "</div><br>")
        cadena.AppendLine("<div style=""height:25px;""></div>")

        cadena.AppendLine("<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""20"" >")
        cadena.AppendLine("<tr>")
        cadena.AppendLine("<td width=""368px"" valign=""top"">")
        cadena.AppendLine("<img src=""" & carpetafilesbig & """ border=""0""  width=""350px""/> <br><br>")


        Dim dsFotos As DataSet = mypf.GetDS(mypi.idProducto)
        Dim contadorFotos As Integer = 0
        cadena.AppendLine("<table width=""250px"" border=""0"" cellpadding=""0"" cellspacing=""0"" >")
        For Each rowFoto As DataRow In dsFotos.Tables(0).Rows
            If contadorFotos = 0 Then
                cadena.AppendLine("<tr>")
            End If

            cadena.AppendLine("<td width=""50px"" valign=""top"">")
            cadena.AppendLine("<img src=""" & System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/" & rowFoto("imagen") & """ border=""0""  width=""50px""/>")
            cadena.AppendLine("</td>")
            cadena.AppendLine("<td style=""width:3px""><img src=""http://todopromocional.com/images/transp.gif""  Width=""3px""  /></td>")

            If contadorFotos = 3 Then
                cadena.AppendLine("</tr>")
            End If

            contadorFotos = contadorFotos + 1
            If contadorFotos = 4 Then
                contadorFotos = 0
            End If
        Next

        If contadorFotos < 4 Then
            Select Case contadorFotos
                    

                Case 1
                    cadena.AppendLine("<td width=""50px"" valign=""top""></td>")
                    cadena.AppendLine("<td style=""width:3px""><img src=""http://todopromocional.com/images/transp.gif""  Width=""3px""  /></td>")

                    cadena.AppendLine("<td width=""50px"" valign=""top""></td>")
                    cadena.AppendLine("<td style=""width:3px""><img src=""http://todopromocional.com/images/transp.gif""  Width=""3px""  /></td>")

                    cadena.AppendLine("<td width=""50px"" valign=""top""></td>")
                    cadena.AppendLine("<td style=""width:3px""><img src=""http://todopromocional.com/images/transp.gif""  Width=""3px""  /></td>")

                    cadena.AppendLine("</tr>")

                Case 2
                    cadena.AppendLine("<td width=""50px"" valign=""top""></td>")
                    cadena.AppendLine("<td style=""width:3px""><img src=""http://todopromocional.com/images/transp.gif""  Width=""3px""  /></td>")

                    cadena.AppendLine("<td width=""50px"" valign=""top""></td>")
                    cadena.AppendLine("<td style=""width:3px""><img src=""http://todopromocional.com/images/transp.gif""  Width=""3px""  /></td>")

                    cadena.AppendLine("</tr>")
                Case 3
                    cadena.AppendLine("<td width=""50px"" valign=""top""></td>")
                    cadena.AppendLine("<td style=""width:3px""><img src=""http://todopromocional.com/images/transp.gif""  Width=""3px""  /></td>")

                    cadena.AppendLine("</tr>")
                Case Else

            End Select
        End If

        cadena.AppendLine("</table>")



        cadena.AppendLine("<div style=""height:10px;""></div>")


        cadena.AppendLine("</td>")
        cadena.AppendLine("<td valign=""top"">")
        cadena.AppendLine("<font class=""title1"">" & mypi.nombre & "</font><br>")
        cadena.AppendLine("<table width=""100%"" ><tr><td class=""textoGris"" >" & mypi.clave.Substring(3) & "</td><td class=""textoGris"">Publicado el " & mypi.fechamodificacion.ToShortDateString & "</td></tr></table>")
        cadena.AppendLine("<font class=""textoNegro""><b>Descripción</b></font><br><br>")
        cadena.AppendLine("<div style=""height:3px;width:100%""></div>")
        cadena.AppendLine("<font class=""textoNegro"">" & mypi.descripcion & "</font><br><br>")
        cadena.AppendLine("<div style=""height:5px;width:100%;""></div>")

        cadena.AppendLine("<b><font class=""textoNegro"">Acabados disponibles:</font></b><br><br>")
        cadena.AppendLine("<div style=""height:3px;width:100%;""></div>")
        Dim mysi As New tienda.ServicioIdioma()
        Dim drServicios As System.Data.SqlClient.SqlDataReader = mysi.GetDR(CInt(Session("idIdioma")), mypi.idProducto)
        Dim cadenaservicios As String = ""
        Do While drServicios.Read
            If cadenaservicios = "" Then
                cadenaservicios = drServicios("Nombre")
            Else
                cadenaservicios = cadenaservicios & ", " & drServicios("Nombre")
            End If

        Loop
        drServicios.Close()

        cadena.AppendLine("<font class=""textoNegro"">" & cadenaservicios & "</font><br><br>")
        cadena.AppendLine("<div style=""height:5px;width:100%;""></div>")

        'Features
        Dim myci As New tienda.CaracteristicaIdioma
        Dim drCaracteristicas As System.Data.SqlClient.SqlDataReader = myci.GetDR(CInt(Session("idIdioma")))
        Do While drCaracteristicas.Read
            If getfeature(CInt(drCaracteristicas("idCaracteristica"))) Then
                cadena.AppendLine("<table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width:100%;"">")
                cadena.AppendLine("<tr>")
                cadena.AppendLine("<td style=""text-align: left; width:93px;""><font class=""textoNegro""><b>" & drCaracteristicas("Nombre") & ":</b></font>")
                cadena.AppendLine("<td style=""text-align: left; vertical-align:top;"">" & feature & "</td>")
                cadena.AppendLine("</tr>")
                cadena.AppendLine("</table>")
                cadena.AppendLine("<div style=""height:5px;width:100%;""> </div>")
            End If
        Loop
        drCaracteristicas.Close()
        cadena.AppendLine("<div style=""height:10px;width:100%;""></div>")
        cadena.AppendLine("<font class=""textoNegro""><b>Colores:</b><br></font>")
        cadena.AppendLine("<div style=""height:10px;width:100%;""></div>")

        'colores
        Dim mycolores As New tienda.Color
        Dim drColores As System.Data.SqlClient.SqlDataReader = mycolores.GetDR(mypi.idProducto, tienda.TipoEntidad.Producto, CInt(Session("idIdioma")))
        cadena.AppendLine("<table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width: 100%; height: 21px;"" >")
        cadena.AppendLine("<tr>")
        Do While drColores.Read
            cadena.AppendLine("<td style=""width:21px;""> " & GetColor(drColores("idCodigoColor")) & "</td>")
        Loop
        drColores.Close()
        cadena.AppendLine("<td></td>")
        cadena.AppendLine("</tr>")
        cadena.AppendLine("</table>")


        cadena.AppendLine("<br><br><div style=""height:5px;width:100%;""></div>")
        cadena.AppendLine("<table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""width: 100%;"" >")
        cadena.AppendLine("<tr>")
        cadena.AppendLine("<td class=""border-box"">")

        cadena.AppendLine("<table border=""0"" cellspacing=""5"" cellpadding=""0""><tr><td><img border=""0"" src=""http://todopromocional.com/images/icon-precio.png"" /></td><td><strong><span class=""textoNegro"">PRECIOS</span></strong></td><td><span class=""txt-red1"">No incluyen I.V.A, impresión o  envío.</span></td></tr></table>")

        cadena.AppendLine("<div style=""height:5px;width:100%;""></div>")

        Dim myprecio As New tienda.Precio
        Dim dtPrecios As datatable = myprecio.TablaDePrecios2(mypi.idProducto)
        Dim i As Integer = 0
        Dim j As Integer = 0

        cadena.AppendLine("<table cellpadding=""2"" cellspacing=""0"" border=""0"" style=""width: 100%;"" >")
        For i = 0 To dtPrecios.Rows.Count - 1
            cadena.AppendLine("<tr>")
            For j = 0 To dtPrecios.Columns.Count - 1
                cadena.AppendLine("<td class=""textoNegro"">")
                cadena.AppendLine(dtPrecios.Rows(i).Item(j).ToString)
                cadena.AppendLine("</td>")
            Next

            cadena.AppendLine("</tr>")

        Next
            cadena.AppendLine("</table>")



            cadena.AppendLine("</td>")
            cadena.AppendLine("</tr>")
            cadena.AppendLine("</table>")





            cadena.AppendLine("</td>")
            cadena.AppendLine("</tr>")
            cadena.AppendLine("</table>")


            SendMail(txtEmailPara.Text, cadena.ToString)

            Response.Redirect("EnviarEmailProductoConfirmacion.aspx")
    End Sub


    Private Function RenderGridView() As String
        Dim writer As New StringWriter
        Dim htmlWriter As New HtmlTextWriter(writer)
        Try
            rptprecios.RenderControl(htmlWriter)
        Catch ex As HttpException

        End Try

        Return writer.ToString()
    End Function





    Public Function SendMail(ByVal correo As String, ByRef body As String) As Integer
        Dim MailMsg As New MailMessage(txtEmail.Text.ToString, correo)
        Dim mypi As New tienda.ProductoIdioma(CInt(Request("idProducto")), CInt(Session("idIdioma")))


        With MailMsg
            .Subject = mypi.nombre
            .Body = body
            .IsBodyHtml = True



        End With


        Dim numero As Integer = 0
        Try
            Dim aCred As New System.Net.NetworkCredential("websystem@todopromocional.com", "NaguaVENnafta17")

            Dim f As New System.Net.Mail.SmtpClient("smtpout.secureserver.net")
            f.EnableSsl = False
            f.UseDefaultCredentials = False
            f.Credentials = aCred


            f.Send(MailMsg)

            '    numero = 1
        Catch ex As Exception
            '  txtComment.Text = ex.Message & " " & ex.InnerException.Message & " " & ex.InnerException.Source
        End Try



        Return 1
    End Function

  
End Class
