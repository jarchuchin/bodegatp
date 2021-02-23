
Partial Class sec_AgregarImagen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If
    End Sub

    Public carpetafiles As String

    Sub colocardatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "ordenes/"

        '      lnkCategoActual.Text = "Cotización # " & Request("idOrden")
        '     lnkCategoActual.NavigateUrl = "Compras.aspx?idOrden=" & Request("idOrden")


        Dim myoi As New tienda.OrdenImagen
        dtlImagenes.DataSource = myoi.getDS(CInt(Request("idOrden")))
        dtlImagenes.DataBind()


        'lblfecha.Text = Format(Date.Now, "dd \de MMMM yyyy")


    End Sub

    Public Function getNameFile(ByVal clave As Integer, ByVal filex As FileUpload) As String
        If filex.HasFile Then
            Dim namefile As String = clave & "." & filex.PostedFile.FileName.Substring((filex.PostedFile.FileName.LastIndexOf(".") + 1))
            filex.SaveAs(System.Configuration.ConfigurationManager.AppSettings("files") & "ordenes\" & namefile)
            Return namefile
        Else
            Return ""
        End If
    End Function

    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        Dim namefile As String = FileUpload1.PostedFile.FileName.Substring((FileUpload1.PostedFile.FileName.LastIndexOf(".") + 1))
        If namefile.ToLower = "bmp" Or namefile.ToLower = "gif" Or namefile.ToLower = "jpg" Or namefile.ToLower = "jpeg" Or namefile.ToLower = "png" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub CustomValidator2_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator2.ServerValidate
        Dim namefile As String = FileUpload1.PostedFile.FileName.Substring((FileUpload2.PostedFile.FileName.LastIndexOf(".") + 1))
        If namefile.ToLower = "bmp" Or namefile.ToLower = "gif" Or namefile.ToLower = "jpg" Or namefile.ToLower = "jpeg" Or namefile.ToLower = "png" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub CustomValidator3_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator3.ServerValidate
        Dim namefile As String = FileUpload1.PostedFile.FileName.Substring((FileUpload3.PostedFile.FileName.LastIndexOf(".") + 1))
        If namefile.ToLower = "bmp" Or namefile.ToLower = "gif" Or namefile.ToLower = "jpg" Or namefile.ToLower = "jpeg" Or namefile.ToLower = "png" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click

        If FileUpload1.HasFile Then
            Dim myoi As New tienda.OrdenImagen
            myoi.idOrden = CInt(Request("idOrden"))
            myoi.imagen = ""
            myoi.Add()

            Dim nombreImagen As String = getNameFile(myoi.idOrdenImagen, FileUpload1)
            If nombreImagen <> "" Then
                myoi.imagen = nombreImagen
                myoi.update()
            End If

        End If


        If FileUpload2.HasFile Then
            Dim myoi As New tienda.OrdenImagen
            myoi.idOrden = CInt(Request("idOrden"))
            myoi.imagen = ""
            myoi.Add()

            Dim nombreImagen As String = getNameFile(myoi.idOrdenImagen, FileUpload2)
            If nombreImagen <> "" Then
                myoi.imagen = nombreImagen
                myoi.Update()
            End If

        End If


        If FileUpload3.HasFile Then
            Dim myoi As New tienda.OrdenImagen
            myoi.idOrden = CInt(Request("idOrden"))
            myoi.imagen = ""
            myoi.Add()

            Dim nombreImagen As String = getNameFile(myoi.idOrdenImagen, FileUpload3)
            If nombreImagen <> "" Then
                myoi.imagen = nombreImagen
                myoi.Update()
            End If

        End If

        Response.Redirect("Compras.aspx?idOrden=" & Request("idOrden"))

    End Sub

    Protected Sub btnregresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnregresar.Click

        Response.Redirect("Compras.aspx?idOrden=" & Request("idOrden"))

    End Sub
End Class
