
Partial Class sec_SubirComprobante
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Sub colocardatos()
        Dim myo As New tienda.Orden(CInt(Request("idOrden")))
        litNumOrden.Text = myo.idOrden

        If myo.idUserProfile <> CInt(Session("idUserProfile")) Then
            Response.Redirect("~/logout.aspx")
        End If

        If Request("idDepositoVenta") <> "" Then
            Dim mydv As New tienda.DepositoVenta(CInt(Request("idDepositoVenta")))
            If mydv.idOrden <> myo.idOrden Then
                Response.Redirect("~/logout.aspx")
            End If

            lblProyecto.Text = myo.idOrden
            drptipodeposito.SelectedValue = mydv.TipoDeposito
            txtFecha.Text = mydv.Fecha.ToShortDateString
            txtcliente.Text = mydv.Cliente
            drpsucursales.SelectedValue = mydv.Sucursal
            txtReferencia.Text = mydv.Referencia
            txtmonto.Text = Format(mydv.Monto, "0.00")

            If mydv.Imagen <> "" Then
                imgComprobante.Visible = True
                lnkComprobante.Visible = True

                lnkComprobante.NavigateUrl = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "depositos\" & mydv.Imagen

                imgComprobante.ImageUrl = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "depositos\mini\" & mydv.Imagen

            Else
                imgComprobante.Visible = False
                lnkComprobante.Visible = False
            End If

        Else
            txtcliente.Text = myo.nombreF
            txtFecha.Text = Date.Now.ToShortDateString

            lblProyecto.Text = myo.idOrden

            lnkComprobante.Visible = False
            imgComprobante.Visible = False



        End If


    End Sub



    Function getNameFile() As String
        If FileUploadImagen.HasFile Then
            Dim fechaActual As DateTime = Date.Now
            Dim claveFotoGUID As String = Guid.NewGuid.ToString()
            Dim namefile As String = "IMG_" & claveFotoGUID & "." & FileUploadImagen.PostedFile.FileName.Substring((FileUploadImagen.PostedFile.FileName.LastIndexOf(".") + 1))
            FileUploadImagen.SaveAs(System.Configuration.ConfigurationManager.AppSettings("files") & "depositos\" & namefile)
            CrearMinImage(namefile)
            Return namefile

        Else

            Return ""


        End If
    End Function

    Public maxmin As Integer = 250

    Public Function CrearMinImage(ByVal nombre As String) As Integer
        Dim cadenaPathFile As String = System.Configuration.ConfigurationManager.AppSettings("files") & "depositos\" & nombre

        Dim cadenaPath As String = System.Configuration.ConfigurationManager.AppSettings("files") & "depositos\mini\" & nombre
        Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(cadenaPathFile)
        Dim proporcion As Double = getProporcion(img.Width, img.Height, maxmin)

        Dim ancho As Integer = img.Width * proporcion
        Dim alto As Integer = img.Height * proporcion
        Dim thumbnailbitmap As New System.Drawing.Bitmap(ancho, alto)

        Dim thumbnailGraph = System.Drawing.Graphics.FromImage(thumbnailbitmap)
        thumbnailGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
        thumbnailGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        thumbnailGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

        Dim imageRectangle = New System.Drawing.Rectangle(0, 0, ancho, alto)
        thumbnailGraph.DrawImage(img, imageRectangle)


        thumbnailbitmap.Save(cadenaPath, img.RawFormat)



        If proporcion <> 1 And proporcion > 0 Then
            thumbnailbitmap.Save(cadenaPath, img.RawFormat)

        Else
            img.Save(cadenaPath)
        End If


        thumbnailbitmap.Dispose()
        thumbnailGraph.Dispose()
        img.Dispose()

        cadenaPath = Nothing
        proporcion = Nothing
        cadenaPathFile = Nothing
        img = Nothing

        Return 1

    End Function
    Private Function thumbnailCallback() As Boolean
        Return False
    End Function

    Private Function getProporcion(ByVal width As Integer, ByVal height As Integer, ByVal max As Integer) As Double
        Dim proporcion As Double = 1

        If (width > height Or width = height) And width <> 0 Then
            proporcion = max / width
        Else
            If height > width Then
                proporcion = max / height
            End If
        End If

        Return proporcion
    End Function

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If Request("idDepositoVenta") <> "" Then
            editar()
        Else
            grabar()
        End If

        Response.Redirect("verCompras.aspx?idOrden=" & Request("idOrden"))
    End Sub

    Sub editar()
        Dim mydv As New tienda.DepositoVenta(CInt(Request("idDepositoVenta")))
        mydv.Fecha = CDate(txtFecha.Text)
        mydv.Cliente = txtcliente.Text
        mydv.Sucursal = drpsucursales.SelectedValue
        mydv.Referencia = txtReferencia.Text
        mydv.Monto = CDec(txtmonto.Text)
        mydv.TipoDeposito = drptipodeposito.SelectedValue
        If FileUploadImagen.HasFile Then
            mydv.Imagen = getNameFile()
        End If
        mydv.Update()


    End Sub

    Sub grabar()
        Dim mydv As New tienda.DepositoVenta()
        mydv.idOrden = CInt(Request("idOrden"))
        mydv.Fecha = CDate(txtFecha.Text)
        mydv.Cliente = txtcliente.Text
        mydv.Sucursal = drpsucursales.SelectedValue
        mydv.Referencia = txtReferencia.Text
        mydv.Monto = CDec(txtmonto.Text)
        mydv.Imagen = getNameFile()
        mydv.Factura = ""

        mydv.Eliminado = False
        mydv.ValidadoPor = 0
        mydv.TipoDeposito = drptipodeposito.SelectedValue
        mydv.Estatus = "No registrado"
        mydv.idComprobante = 0


        mydv.Add()


    End Sub
    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Response.Redirect("verCompras.aspx?idOrden=" & Request("idOrden"))
    End Sub
End Class
