
Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Namespace facturitas
    Public Class Comprobante
        Inherits tienda.DBObject

        Public idComprobante As Integer
        Public idUsuario As Integer
        Public idRFC As Integer
        Public idDomicilio As Integer
        Public idRFCReceptor As Integer
        Public idDomicilioReceptor As Integer
        Public idFolio As Integer
        Public status As String
        Public version As String
        Public serie As String
        Public folio As String
        Public fecha As DateTime
        Public sello As String
        Public noAprobacion As Integer
        Public anoAprobacion As Integer
        Public formaDePago As String
        Public noCertificado As String
        Public certificado As String
        Public condicionesDePago As String
        Public subTotal As Decimal
        Public descuento As Decimal
        Public motivoDescuento As String
        Public total As Decimal
        Public metodoDePago As String
        Public tipoDeComprobante As String
        Public totalImpuestosRetenidos As Decimal
        Public totalImpuestosTrasladados As Decimal
        Public cadenaPipes As String
        Public nameFile As String
        Public idOrden As Integer
        Public Observaciones As String = ""

        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidComprobante As Integer)
            Dim sql As String = "select * from Comprobantes where idComprobante=@idComprobante"

            Dim param As SqlParameter() = {New SqlParameter("@idComprobante", claveidComprobante)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idComprobante = CInt(dr("idComprobante"))
                Me.idUsuario = CInt(dr("idUsuario"))
                Me.idRFC = CInt(dr("idRFC"))
                Me.idDomicilio = CInt(dr("idDomicilio"))
                Me.idRFCReceptor = CInt(dr("idRFCReceptor"))
                Me.idDomicilioReceptor = CInt(dr("idDomicilioReceptor"))
                Me.idFolio = CInt(dr("idFolio"))
                Me.status = dr("status")
                Me.version = dr("version")
                Me.serie = dr("serie")
                Me.folio = dr("folio")
                Me.fecha = CDate(dr("fecha"))
                Me.sello = dr("sello")
                Me.noAprobacion = CInt(dr("noAprobacion"))
                Me.anoAprobacion = CInt(dr("anoAprobacion"))
                Me.formaDePago = dr("formaDePago")
                Me.noCertificado = dr("noCertificado")
                Me.certificado = dr("certificado")
                Me.condicionesDePago = dr("condicionesDePago")
                Me.subTotal = CDec(dr("subTotal"))
                Me.descuento = CDec(dr("descuento"))
                Me.motivoDescuento = dr("motivoDescuento")
                Me.total = CDec(dr("total"))
                Me.metodoDePago = dr("metodoDePago")
                Me.tipoDeComprobante = dr("tipoDeComprobante")
                Me.totalImpuestosRetenidos = CDec(dr("totalImpuestosRetenidos"))
                Me.totalImpuestosTrasladados = CDec(dr("totalImpuestosTrasladados"))
                Me.cadenaPipes = dr("cadenaPipes")
                Me.nameFile = dr("nameFile")
                Me.idOrden = CInt(dr("idOrden"))

                If Not Convert.IsDBNull(dr("Observaciones")) Then
                    Me.Observaciones = dr("Observaciones")
                End If

                Me.existe = True
            End If
            dr.Close()


        End Sub


        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Comprobantes (idUsuario, idRFC, idDomicilio, idRFCReceptor, idDomicilioReceptor, idFolio, status, version, serie, folio, fecha, sello, noAprobacion, anoAprobacion, formaDePago, noCertificado, certificado, condicionesDePago, subTotal, descuento, motivoDescuento, total, metodoDePago, tipoDeComprobante, totalImpuestosRetenidos, totalImpuestosTrasladados, cadenaPipes, nameFile, idOrden, Observaciones)  VALUES (@idUsuario, @idRFC, @idDomicilio, @idRFCReceptor, @idDomicilioReceptor, @idFolio, @status, @version, @serie, @folio, @fecha, @sello, @noAprobacion, @anoAprobacion, @formaDePago, @noCertificado, @certificado, @condicionesDePago, @subTotal, @descuento, @motivoDescuento, @total, @metodoDePago, @tipoDeComprobante, @totalImpuestosRetenidos, @totalImpuestosTrasladados, @cadenaPipes, @nameFile, @idOrden, @Observaciones)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idUsuario", Me.idUsuario), _
             New SqlParameter("@idRFC", Me.idRFC), _
              New SqlParameter("@idDomicilio", Me.idDomicilio), _
               New SqlParameter("@idRFCReceptor", Me.idRFCReceptor), _
               New SqlParameter("@idDomicilioReceptor", Me.idDomicilioReceptor), _
               New SqlParameter("@idFolio", Me.idFolio), _
               New SqlParameter("@status", Me.status), _
               New SqlParameter("@version", Me.version), _
               New SqlParameter("@serie", Me.serie), _
               New SqlParameter("@folio", Me.folio), _
               New SqlParameter("@fecha", Me.fecha), _
               New SqlParameter("@sello", Me.sello), _
               New SqlParameter("@noAprobacion", Me.noAprobacion), _
               New SqlParameter("@anoAprobacion", Me.anoAprobacion), _
               New SqlParameter("@formaDePago", Me.formaDePago), _
               New SqlParameter("@noCertificado", Me.noCertificado), _
               New SqlParameter("@certificado", Me.certificado), _
               New SqlParameter("@condicionesDePago", Me.condicionesDePago), _
               New SqlParameter("@subTotal", Me.subTotal), _
               New SqlParameter("@descuento", Me.descuento), _
               New SqlParameter("@motivoDescuento", Me.motivoDescuento), _
               New SqlParameter("@total", Me.total), _
             New SqlParameter("@metodoDePago", Me.metodoDePago), _
             New SqlParameter("@tipoDeComprobante", Me.tipoDeComprobante), _
             New SqlParameter("@totalImpuestosRetenidos", Me.totalImpuestosRetenidos), _
             New SqlParameter("@totalImpuestosTrasladados", Me.totalImpuestosTrasladados), _
             New SqlParameter("@cadenaPipes", Me.cadenaPipes), _
             New SqlParameter("@nameFile", Me.nameFile), _
             New SqlParameter("@idOrden", Me.idOrden), _
             New SqlParameter("@Observaciones", Me.Observaciones)}

            Me.idComprobante = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Comprobantes set idusuario=@idUsuario, idRFC=@idRFC, idDomicilio=@idDomicilio, idRFCReceptor=@idRFCReceptor, idDomicilioReceptor=@idDomicilioReceptor, idFolio=@idFolio, status=@status, version=@version, serie=@serie, folio=@folio, fecha=@fecha, sello=@sello, noAprobacion=@noAprobacion, anoAprobacion=@anoAprobacion, formaDePago=@formaDePago, noCertificado=@noCertificado, certificado=@certificado, condicionesDePago=@condicionesDePago, subtotal=@subtotal, descuento=@descuento, motivoDescuento=@motivoDescuento, total=@total, metodoDePago=@metodoDePago, tipoDeComprobante=@tipoDeComprobante, totalImpuestosRetenidos=@totalImpuestosRetenidos, totalImpuestosTrasladados=@totalImpuestosTrasladados,  cadenaPipes=@cadenaPipes, nameFile=@nameFile, idOrden=@idOrden, Observaciones=@Observaciones where  idComprobante=@idComprobante"



            'esta seccion cambiara una vez que sepamos que onda con los impuestos !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Me.subTotal = sumarConceptos(Me.idComprobante)
            Me.totalImpuestosTrasladados = subTotal * 0.16
            Me.total = subTotal + totalImpuestosTrasladados



            Dim parameters As SqlParameter() = { _
       New SqlParameter("@idUsuario", Me.idUsuario), _
       New SqlParameter("@idRFC", Me.idRFC), _
        New SqlParameter("@idDomicilio", Me.idDomicilio), _
         New SqlParameter("@idRFCReceptor", Me.idRFCReceptor), _
         New SqlParameter("@idDomicilioReceptor", Me.idDomicilioReceptor), _
         New SqlParameter("@status", Me.status), _
               New SqlParameter("@idFolio", Me.idFolio), _
         New SqlParameter("@version", Me.version), _
         New SqlParameter("@serie", Me.serie), _
         New SqlParameter("@folio", Me.folio), _
         New SqlParameter("@fecha", Me.fecha), _
         New SqlParameter("@sello", Me.sello), _
         New SqlParameter("@noAprobacion", Me.noAprobacion), _
         New SqlParameter("@anoAprobacion", Me.anoAprobacion), _
         New SqlParameter("@formaDePago", Me.formaDePago), _
         New SqlParameter("@noCertificado", Me.noCertificado), _
         New SqlParameter("@certificado", Me.certificado), _
         New SqlParameter("@condicionesDePago", Me.condicionesDePago), _
         New SqlParameter("@subTotal", Me.subTotal), _
         New SqlParameter("@descuento", Me.descuento), _
         New SqlParameter("@motivoDescuento", Me.motivoDescuento), _
         New SqlParameter("@total", Me.total), _
       New SqlParameter("@metodoDePago", Me.metodoDePago), _
       New SqlParameter("@tipoDeComprobante", Me.tipoDeComprobante), _
       New SqlParameter("@totalImpuestosRetenidos", Me.totalImpuestosRetenidos), _
       New SqlParameter("@totalImpuestosTrasladados", Me.totalImpuestosTrasladados), _
           New SqlParameter("@idComprobante", Me.idComprobante), _
             New SqlParameter("@cadenaPipes", Me.cadenaPipes), _
             New SqlParameter("@nameFile", Me.nameFile), _
             New SqlParameter("@idOrden", Me.idOrden), _
             New SqlParameter("@Observaciones", Me.Observaciones)}


            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function



        Public Function CancelarMontos() As Integer
            Dim queryString As String = "Update Comprobantes set  subtotal=@subtotal, total=@total,  totalImpuestosRetenidos=@totalImpuestosRetenidos, totalImpuestosTrasladados=@totalImpuestosTrasladados where  idComprobante=@idComprobante"



        



            Dim parameters As SqlParameter() = { _
         New SqlParameter("@total", 0), _
       New SqlParameter("@subtotal", 0), _
       New SqlParameter("@totalImpuestosRetenidos", 0), _
       New SqlParameter("@totalImpuestosTrasladados", 0)}


            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function sumarConceptos(ByVal claveComprobante As Integer) As Decimal
            Dim sql As String = "select sum(importe) as num  from conceptos where idComprobante = @idComprobante"
            Dim param As SqlParameter() = {New SqlParameter("@idComprobante", claveComprobante)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso
        End Function




        Public Function Remove() As Integer
            Dim sql As String = "delete Comprobantes where idComprobante=@idComprobante"
            Dim param As SqlParameter() = {New SqlParameter("@idComprobante", Me.idComprobante)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveRFC As Integer) As DataSet
            Dim sql As String = "select c.*, c.serie + c.folio as seriefolio, r.rfc as receptorRFC, r.nombre as receptorNombre from Comprobantes c left outer join rfcs r on  r.idrfc=c.idrfcreceptor where c.idRFC=@idRFC"
            Dim param As SqlParameter() = {New SqlParameter("@idRFC", claveRFC)}
            Return Me.ExecuteDataSet(sql, param)
        End Function

        Public Function GetDS(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataSet
            claveFechaHasta = claveFechaHasta.AddDays(1)

            Dim sql As String = "select c.*, c.serie + c.folio as seriefolio, r.rfc as receptorRFC, r.nombre as receptorNombre, isnull((select sum(d.monto) from depositos d where d.idorden=c.idorden), 0) as depositos, c.total - isnull((select sum(d.monto) from depositos d where d.idorden=c.idorden), 0) as saldo  from Comprobantes c left outer join rfcs r on  r.idrfc=c.idrfcreceptor where c.fecha>=@fechadesde and c.fecha<@fechahasta"
            Dim params As SqlParameter() = {New SqlParameter("@FechaDesde", claveFechaDesde), New SqlParameter("@FechaHasta", claveFechaHasta)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetFolioEnComprobante(ByVal claveSerie As Integer, ByVal claveFolio As Integer, ByVal claveRFC As Integer) As String
            Dim myserie As New facturitas.Serie(claveSerie)
            Dim myfolio As New facturitas.Folio(claveFolio)
            Dim myrfc As New facturitas.RFC(claveRFC)

            Dim sql As String = " select top 1 c.idComprobante, c.serie, c.folio, c.status from comprobantes c where c.idRFC=@claveRFC and c.serie=@Serie and c.folio<@folio order by c.folio desc"
            Dim param As SqlParameter() = {New SqlParameter("@Serie", myserie.desde), New SqlParameter("@folio", myfolio.hasta), New SqlParameter("@claveRFC", myrfc.idRFC)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)
            Dim regreso As String = "na"
            If dr.Read Then
                If CInt(dr("folio")) >= myfolio.hasta Then
                    regreso = "na"
                Else
                    regreso = CInt(dr("folio")) + 1
                End If
            Else
                regreso = myfolio.desde
            End If
            dr.Close()

            Return regreso
        End Function

        Public Function GetDSOrden(ByVal claveOrden As Integer) As DataSet
            Dim sql As String = "select c.*, c.serie + c.folio as seriefolio, r.rfc as receptorRFC, r.nombre as receptorNombre from Comprobantes c left outer join rfcs r on  r.idrfc=c.idrfcreceptor where c.idOrden=@idOrden and c.status<>'cancelado'"
            Dim param As SqlParameter() = {New SqlParameter("@idOrden", claveOrden)}
            Return Me.ExecuteDataSet(sql, param)
        End Function


     


        Public Function GetTotalComprobantesOrden(ByVal claveOrden As Integer) As Decimal
            Dim sql As String = "select sum(c.total) as num from Comprobantes c where c.idOrden=@idOrden " 'and c.status='terminado'
            Dim param As SqlParameter() = {New SqlParameter("@idOrden", claveOrden)}
            Dim drs As SqlDataReader = Me.ExecuteReader(sql, param)
            Dim regreso As Decimal = 0
            If drs.Read Then
                If Not Convert.IsDBNull(drs("num")) Then
                    regreso = CDec(drs("num"))
                End If
            End If

            drs.Close()
            Return regreso

        End Function
    End Class

End Namespace
