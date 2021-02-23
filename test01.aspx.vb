Imports System.Security




Partial Class test01
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            colocardatos()
        End If


    End Sub


    Sub colocardatos()


        'txtIPResult.Text =  '189.152.53.112
        For i = 0 To 100
            Query(Request.ServerVariables("REMOTE_ADDR"))
        Next


    End Sub

    Function Query(ByVal strIPAddress As String) As Integer
        Dim oIPResult As New IP2Location.IPResult
        Dim oIP2Location As New IP2Location.Component

        ' Try
        If strIPAddress <> "" Then

            oIP2Location.IPDatabasePath = System.Configuration.ConfigurationManager.AppSettings("filesip") & "Database\IP-COUNTRY-REGION-CITY.BIN"

            'Set License Path
            'e.g. C:\Program Files\IP2Location\License.key
            'oIP2Location.IPLicensePath = "C:\Program Files\IP2Location\License.key"

            oIPResult = oIP2Location.IPQuery(strIPAddress)
            Select Case oIPResult.Status
                Case "OK"
                    Me.txtIPResult.Text += "IP: " & oIPResult.IPAddress & vbNewLine
                    Me.txtIPResult.Text += "Ciudad: " & oIPResult.City & vbNewLine
                    Me.txtIPResult.Text += "Codigo: " & oIPResult.CountryShort & vbNewLine
                    Me.txtIPResult.Text += "Pais: " & oIPResult.CountryLong & vbNewLine
                    ' Me.txtIPResult.Text += "Postal Code: " & oIPResult.ZipCode & vbNewLine
                    'Me.txtIPResult.Text += "Domain Name: " & oIPResult.DomainName & vbNewLine
                    'Me.txtIPResult.Text += "ISP Name: " & oIPResult.InternetServiceProvider & vbNewLine
                    'Me.txtIPResult.Text += "Latitude: " & oIPResult.Latitude & vbNewLine
                    'Me.txtIPResult.Text += "Longitude: " & oIPResult.Longitude & vbNewLine
                    Me.txtIPResult.Text += "Estado: " & oIPResult.Region & vbNewLine
                    Me.txtIPResult.Text += "Hora: " & Date.Now & vbNewLine & vbNewLine
                    ' Me.txtIPResult.Text += "Time Zone: " & oIPResult.TimeZone & vbNewLine
                    'Me.txtIPResult.Text += "Net Speed: " & oIPResult.NetSpeed & vbNewLine
                    'Me.txtIPResult.Text += "IDD Code: " & oIPResult.IDDCode & vbNewLine
                    'Me.txtIPResult.Text += "Area Code: " & oIPResult.AreaCode & vbNewLine
                    'Me.txtIPResult.Text += "Weather Station Code: " & oIPResult.WeatherStationCode & vbNewLine
                    'Me.txtIPResult.Text += "Weather Station Name: " & oIPResult.WeatherStationName & vbNewLine
                Case "EMPTY_IP_ADDRESS"
                    Response.Write("IP Address cannot be blank.")
                Case "INVALID_IP_ADDRESS"
                    Response.Write("Invalid IP Address.")
                Case "MISSING_FILE"
                    Response.Write("Invalid Database Path.")
            End Select
        Else
            'Response.Write("IP Address cannot be blank.")
        End If
        'Catch ex As Exception
        'Response.Write(ex.Message)
        '   Finally
        oIPResult = Nothing
        oIP2Location = Nothing
        '  End Try
    End Function


End Class
