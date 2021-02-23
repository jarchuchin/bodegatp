Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing



Public Class [Global]
    Inherits System.Web.HttpApplication


    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup

        RegisterRoutes(RouteTable.Routes)


        Application("mailPort") = 26
        Application("mailHost") = "mx-s3.vivawebhost.com"
        Application("mailUser1") = "mail1@todopromocional.net"
        Application("mailUser2") = "mail2@todopromocional.net"
        Application("mailUser3") = "mail3@todopromocional.net"
        Application("mailUser4") = "mail4@todopromocional.net"
        Application("mailUser5") = "mail5@todopromocional.net"
        Application("mailUserlc") = "mail1@expepdiente.io"
        Application("mailPass") = "$jwo1R87~^YN"


        'Dim myci As New tienda.ConfiguracionIdioma(1, 1)
        'Dim logo As String = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "logos/" & myci.logoPrincipal
        'Application("logo") = logo

    End Sub


    Protected Sub Application_BeginRequest(sender As [Object], e As EventArgs)
        'If HttpContext.Current.Request.IsSecureConnection.Equals(False) AndAlso HttpContext.Current.Request.IsLocal.Equals(False) Then
        '    Response.Redirect("https://" + Request.ServerVariables("HTTP_HOST") + HttpContext.Current.Request.RawUrl)
        'End If
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        Session("idioma") = "es-MX"
        'Dim myi As New tienda.Idioma(CStr(Session("idioma")))


        '  GetLocation()

        Session("idIdioma") = 1 'myi.idIdioma
        Session("idOrden") = 0
        Session("idUserProfile") = 0
		Session("esAdmin") = False
		Session("listaRecientes") = Nothing

        

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
	End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)


        'routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        ' routes.IgnoreRoute("{resource}.css/{*pathInfo}")
        '   routes.IgnoreRoute("{resource}.js/{*pathInfo}")

        routes.Add("ProductoDetalle", New Route("productos/show/{idProducto}/{tags}", New CustomRouteHandler("~/Producto.aspx")))
        routes.Add("Categoria", New Route("categorias/show/{idCategoria}/{tags}", New CustomRouteHandler("~/Categoria.aspx")))
        routes.Add("Grupos", New Route("grupos/show/{idGrupo}/{tags}", New CustomRouteHandler("~/Grupos.aspx")))

    End Sub

    Function GetLocation() As String

        Dim strIPAddress As String = Request.ServerVariables("REMOTE_ADDR")
        Dim oIPResult As New IP2Location.IPResult
        Dim oIP2Location As New IP2Location.Component
        Dim regreso As String = ""

        Try
            If strIPAddress <> "" Then

                oIP2Location.IPDatabasePath = System.Configuration.ConfigurationManager.AppSettings("filesip") & "Database\IP-COUNTRY-REGION-CITY.BIN"
                oIPResult = oIP2Location.IPQuery(strIPAddress)

                Select Case oIPResult.Status
                    Case "OK"
                        ' Me.txtIPResult.Text += "IP: " & oIPResult.IPAddress & vbNewLine
                        'Me.txtIPResult.Text += "Ciudad: " & oIPResult.City & vbNewLine
                        'Me.txtIPResult.Text += "Codigo: " & oIPResult.CountryShort & vbNewLine
                        'Me.txtIPResult.Text += "Pais: " & oIPResult.CountryLong & vbNewLine
                        ' Me.txtIPResult.Text += "Postal Code: " & oIPResult.ZipCode & vbNewLine
                        'Me.txtIPResult.Text += "Domain Name: " & oIPResult.DomainName & vbNewLine
                        'Me.txtIPResult.Text += "ISP Name: " & oIPResult.InternetServiceProvider & vbNewLine
                        'Me.txtIPResult.Text += "Latitude: " & oIPResult.Latitude & vbNewLine
                        'Me.txtIPResult.Text += "Longitude: " & oIPResult.Longitude & vbNewLine
                        Session("region") = oIPResult.Region
                        Session("ciudad") = oIPResult.City

                        Dim ss As HttpSessionState = HttpContext.Current.Session


                        Dim myloc As New tienda.Localizacion()
                        myloc.IP = strIPAddress
                        myloc.sessionID = ss.SessionID
                        myloc.Region = Session("region")
                        myloc.Ciudad = Session("ciudad")
                        myloc.Fecha = Date.Now
                        myloc.add()


                        'Me.txtIPResult.Text += "Hora: " & Date.Now & vbNewLine & vbNewLine
                        ' Me.txtIPResult.Text += "Time Zone: " & oIPResult.TimeZone & vbNewLine
                        'Me.txtIPResult.Text += "Net Speed: " & oIPResult.NetSpeed & vbNewLine
                        'Me.txtIPResult.Text += "IDD Code: " & oIPResult.IDDCode & vbNewLine
                        'Me.txtIPResult.Text += "Area Code: " & oIPResult.AreaCode & vbNewLine
                        'Me.txtIPResult.Text += "Weather Station Code: " & oIPResult.WeatherStationCode & vbNewLine
                        'Me.txtIPResult.Text += "Weather Station Name: " & oIPResult.WeatherStationName & vbNewLine
                    Case "EMPTY_IP_ADDRESS"
                        regreso = "IP Address cannot be blank."
                    Case "INVALID_IP_ADDRESS"
                        regreso = "Invalid IP Address."
                    Case "MISSING_FILE"
                        regreso = "Invalid Database Path."
                End Select
            Else
                Session("region") = "IP Address cannot be blank."
            End If
        Catch ex As Exception
            Session("region") = ex.Message
        Finally
            oIPResult = Nothing
            oIP2Location = Nothing
        End Try


        Return regreso

    End Function




End Class


