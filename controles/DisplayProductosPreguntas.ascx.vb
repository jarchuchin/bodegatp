
Partial Class controles_DisplayProductosPreguntas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocarDatos()
        End If
    End Sub

    Sub colocarDatos()
        Dim producto As Integer
        producto = CInt(HttpContext.Current.Items("idProducto"))

        If Request("idProducto") <> "" Then
            producto = CInt(Request("idProducto"))
        End If


        If Request("mensajePregunta") <> "" Then
            lblMensaje.Visible = True
        End If

        Dim mypp As New tienda.ProductoPregunta
        rptPreguntasyRespuestas.DataSource = mypp.GetDS(producto)
        rptPreguntasyRespuestas.DataBind()


    End Sub

    Protected Sub btnAgregarPregunta_Click(sender As Object, e As EventArgs) Handles btnAgregarPregunta.Click

        Dim producto As Integer
        producto = CInt(HttpContext.Current.Items("idProducto"))

        If Request("idProducto") <> "" Then
            producto = CInt(Request("idProducto"))
        End If

        If Session("idUserProfile") > 0 Then


            Dim mypp As New tienda.ProductoPregunta

            If mypp.Count(producto, CInt(Session("idUserProfile")), Date.Now) < 4 Then
                mypp.idProducto = producto
                mypp.Pregunta = txtAgregar.Text
                mypp.PreguntaFecha = Date.Now
                mypp.PreguntaUsuario = Session("idUserProfile")
                mypp.Respuesta = ""
                mypp.RespuestaFecha = Date.Now
                mypp.RespuestaUsuario = 0
                mypp.Calificacion = 0
                mypp.Eliminado = 0
                mypp.Add()

                colocarDatos()
            Else
                lblMensaje.Visible = True
            End If
           

        Else
            Response.Redirect("~/login.aspx?ReturnUrl=" & HttpUtility.UrlEncode("/producto.aspx?idProducto=" & producto & "&pregunta=" & txtAgregar.Text))
        End If



    End Sub


End Class
