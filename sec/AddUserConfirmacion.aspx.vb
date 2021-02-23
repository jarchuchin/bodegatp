
Partial Class AddUserConfirmacion
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargardatos()

        End If
    End Sub


    Sub cargardatos()
        '   litgoogle.Text = getGoogle()

        lblfecha.Text = Format(Date.Now, "dd \de MMMM yyyy")
        'lnkCategoActual.Text = "Cotizacion # " & Request("idOrden")
        'lnkCategoActual.NavigateUrl = "verCompras.aspx?idOrden" & Request("idOrden")

        lblcotizar.Text = Session("nombre")

    End Sub

    Public Function getGoogle() As String

        Dim myo As New tienda.Orden(CInt(Request("idOrden")))


        Dim cadena As String = "<!-- Google Code for Cotización Levantada Conversion Page -->" & vbCrLf & _
        "<script language='JavaScript' type='text/javascript'> " & vbCrLf & _
        "<!--" & vbCrLf & _
        "var google_conversion_id = 1052814348xxxx;" & vbCrLf & _
        "var google_conversion_language =" & """es""" & ";" & vbCrLf & _
        "var google_conversion_format =  " & """1""" & ";" & vbCrLf & _
        "var google_conversion_color = " & """ffffff""" & ";" & vbCrLf & _
        "var google_conversion_label = " & """nyPFCJ66TRCM2IL2Aw""" & ";" & vbCrLf & _
        "if (" & myo.total & ") { " & vbCrLf & _
        "var google_conversion_value = " & myo.total & "; " & vbCrLf & _
        "}" & vbCrLf & _
        "-->" & vbCrLf & _
        "</script>" & vbCrLf & _
        "<script language=" & """JavaScript""" & " src=" & """http://www.googleadservices.com/pagead/conversion.js""" & "> " & vbCrLf & _
        "</script>" & vbCrLf & _
        "<noscript>" & vbCrLf & _
        "<img height='1' width='1' border='0' src='http://www.googleadservices.com/pagead/conversion/1052814348/?value=" & myo.total & "&label=nyPFCJ66TRCM2IL2Aw&script=0'/> " & vbCrLf & _
        "</noscript>"


        Return cadena

    End Function

    Protected Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click

        If Request("ReturnUrl") <> "" Then
            Response.Redirect(Request("ReturnUrl"))
        Else
            Response.Redirect("~/sec/HistorialCotizaciones.aspx")
        End If



    End Sub
End Class
