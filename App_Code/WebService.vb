Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Function getOrdenDetalle(ByVal claveordendetalle As Integer) As String

        Dim myod As New tienda.OrdenDetalle
        Dim ds As DataSet = myod.getOrdenDetalle(claveordendetalle)

        Return ds.GetXml

    End Function


    <WebMethod()> _
   Public Function getOrdenDetalleProductoServicio(ByVal claveordendetalleproductoservicio As Integer) As String

        Dim myod As New tienda.OrdendetalleProductoServicio
        Dim ds As DataSet = myod.getOrdenDetalleProductoServicio(claveordendetalleproductoservicio)

        Return ds.GetXml

    End Function






    '#################Facturitas###############################



    <WebMethod()> _
    Public Function GetRFCsTextbox(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        Dim myrfc As New facturitas.RFC()
        Dim dr As System.Data.SqlClient.SqlDataReader = myrfc.GetDR(prefixText, CInt(contextKey))
        Dim lista As New List(Of String)


        Do While dr.Read
            lista.Add(dr("RFC"))
        Loop
        dr.Close()

        Return lista.ToArray
    End Function


    <WebMethod()> _
    Public Function GetRFCyDomicilioFiscal(ByVal claverfc As String) As String

        Dim myrfc As New facturitas.RFC
        Dim ds As DataSet = myrfc.GetRFCyDomicilioFiscal(claverfc)

        Return ds.GetXml

    End Function


    <WebMethod()> _
    Public Function GetConcepto(ByVal claveconcepto As Integer) As String

        Dim myrfc As New Facturitas.Concepto
        Dim ds As DataSet = myrfc.GetDSConcepto(claveconcepto)

        Return ds.GetXml

    End Function



    <WebMethod(EnableSession:=True)> _
    Public Function GetDropDownListItems(claveEntidad As Integer, municipioSeleccionado As String) As List(Of valoresParaClase)
        Dim result As New List(Of valoresParaClase)()

        Dim mycm As New tienda.CatalogoMunicipio
        Dim ds As DataSet = mycm.GetDS(claveEntidad)
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim munSelect As Boolean = False
            If ds.Tables(0).Rows(i).Item("NombreMunicipio") = municipioSeleccionado Then
                munSelect = True
            End If
            result.Add(New valoresParaClase(ds.Tables(0).Rows(i).Item("NombreMunicipio"), ds.Tables(0).Rows(i).Item("NombreMunicipio"), munSelect))
        Next

        'result.Add(New valoresParaClase(1, "one"))
        'result.Add(New valoresParaClase(2, "two"))
        Return result
    End Function


End Class

Public Class valoresParaClase

    Dim varId As String
    Dim varTexto As String
    Dim varSeleccionado As Boolean


    Sub New(idx As String, textx As String, seleccionadox As Boolean)
        varId = idx
        varTexto = textx
        varSeleccionado = seleccionadox
    End Sub

    Public Property ID As String
        Set(value As String)
            varId = value
        End Set
        Get
            Return varId
        End Get
    End Property

    Public Property Text As String
        Set(value As String)
            varTexto = value
        End Set
        Get
            Return varTexto
        End Get
    End Property

    Public Property Seleccionado As String
        Set(value As String)
            varSeleccionado = value
        End Set
        Get
            Return varSeleccionado
        End Get
    End Property

End Class





