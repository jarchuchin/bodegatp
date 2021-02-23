

Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class RFC
        Inherits tienda.DBObject

        Public idRFC As Integer
        Public rfc As String
        Public nombre As String
        Public editable As Boolean
        Public logo As String
        Public CreditoDias As Integer
        Public FinCredito As Date
        Public MontoMaximoCredito As Decimal
        Public DistribuidorPorcentaje As Integer
        Public VendedorAsignado As Integer
        Public UltimaEscala As Boolean

        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidRFC As Integer)
            Dim sql As String = "select * from RFCs where idRFC=@idRFC"

            Dim param As SqlParameter() = {New SqlParameter("@idRFC", claveidRFC)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idRFC = CInt(dr("idRFC"))
                Me.rfc = dr("rfc")
                Me.nombre = dr("nombre")
                Me.editable = CBool(dr("editable"))
                Me.logo = dr("logo")
                Me.existe = True
                If Not Convert.IsDBNull(dr("CreditoDias")) Then
                    Me.CreditoDias = CInt(dr("CreditoDias"))
                Else
                    Me.CreditoDias = 0
                End If
                If Not Convert.IsDBNull(dr("FinCredito")) Then
                    Me.FinCredito = CDate(dr("FinCredito"))
                Else
                    Me.FinCredito = Date.MinValue
                End If
                If Not Convert.IsDBNull(dr("MontoMaximoCredito")) Then
                    Me.MontoMaximoCredito = CDec(dr("MontoMaximoCredito"))
                Else
                    Me.MontoMaximoCredito = 0
                End If
                If Not Convert.IsDBNull(dr("DistribuidorPorcentaje")) Then
                    Me.DistribuidorPorcentaje = CInt(dr("DistribuidorPorcentaje"))
                Else
                    Me.DistribuidorPorcentaje = 0
                End If
                If Not Convert.IsDBNull(dr("VendedorAsignado")) Then
                    Me.VendedorAsignado = CInt(dr("VendedorAsignado"))
                Else
                    Me.VendedorAsignado = 0
                End If
                If Not Convert.IsDBNull(dr("UltimaEscala")) Then
                    Me.UltimaEscala = CBool(dr("UltimaEscala"))
                Else
                    Me.UltimaEscala = 0
                End If

            End If
            dr.Close()


        End Sub

        Sub New(ByVal claveRFC As String)
            Dim sql As String = "select * from RFCs where rfc=@rfc"

            Dim param As SqlParameter() = {New SqlParameter("@rfc", claveRFC)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idRFC = CInt(dr("idRFC"))
                Me.rfc = dr("rfc")
                Me.nombre = dr("nombre")
                Me.editable = CBool(dr("editable"))
                Me.logo = dr("logo")
                Me.existe = True
                If Not Convert.IsDBNull(dr("CreditoDias")) Then
                    Me.CreditoDias = CInt(dr("CreditoDias"))
                Else
                    Me.CreditoDias = 0
                End If
                If Not Convert.IsDBNull(dr("FinCredito")) Then
                    Me.FinCredito = CDate(dr("FinCredito"))
                Else
                    Me.FinCredito = Date.MinValue
                End If
                If Not Convert.IsDBNull(dr("MontoMaximoCredito")) Then
                    Me.MontoMaximoCredito = CDec(dr("MontoMaximoCredito"))
                Else
                    Me.MontoMaximoCredito = 0
                End If
                If Not Convert.IsDBNull(dr("DistribuidorPorcentaje")) Then
                    Me.DistribuidorPorcentaje = CInt(dr("DistribuidorPorcentaje"))
                Else
                    Me.DistribuidorPorcentaje = 0
                End If
                If Not Convert.IsDBNull(dr("VendedorAsignado")) Then
                    Me.VendedorAsignado = CInt(dr("VendedorAsignado"))
                Else
                    Me.VendedorAsignado = 0
                End If
                If Not Convert.IsDBNull(dr("UltimaEscala")) Then
                    Me.UltimaEscala = CBool(dr("UltimaEscala"))
                Else
                    Me.UltimaEscala = 0
                End If
            End If
            dr.Close()


        End Sub



        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO RFCs (rfc, nombre, editable, logo, CreditoDias, FinCredito, MontoMaximoCredito, DistribuidorPorcentaje, VendedorAsignado, UltimaEscala)  VALUES (@rfc, @nombre, @editable, @logo, @CreditoDias, @FinCredito, @MontoMaximoCredito, @DistribuidorPorcentaje, @VendedorAsignado, @UltimaEscala)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@rfc", Me.rfc), _
             New SqlParameter("@nombre", Me.nombre), _
             New SqlParameter("@editable", Me.editable), _
             New SqlParameter("@logo", Me.logo), _
             New SqlParameter("@CreditoDias", Me.CreditoDias), _
             New SqlParameter("@FinCredito", Me.FinCredito), _
             New SqlParameter("@MontoMaximoCredito", Me.MontoMaximoCredito), _
             New SqlParameter("@DistribuidorPorcentaje", Me.DistribuidorPorcentaje), _
             New SqlParameter("@VendedorAsignado", Me.VendedorAsignado), _
             New SqlParameter("@UltimaEscala", Me.UltimaEscala)}

            If Me.FinCredito = Date.MinValue Then
                parameters(5).Value = DBNull.Value
            End If

            Me.idRFC = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update RFCs set rfc=@rfc, nombre=@nombre, editable=@editable, logo=@logo, CreditoDias=@CreditoDias, FinCredito=@FinCredito, MontoMaximoCredito=@MontoMaximoCredito, DistribuidorPorcentaje=@DistribuidorPorcentaje, VendedorAsignado=@VendedorAsignado, UltimaEscala=@UltimaEscala where  idRFC=@idRFC"


            Dim parameters As SqlParameter() = { _
                 New SqlParameter("@rfc", Me.rfc), _
                 New SqlParameter("@nombre", Me.nombre), _
                 New SqlParameter("@editable", Me.editable), _
                   New SqlParameter("@idRFC", Me.idRFC), _
             New SqlParameter("@logo", Me.logo), _
             New SqlParameter("@CreditoDias", Me.CreditoDias), _
             New SqlParameter("@FinCredito", Me.FinCredito), _
                 New SqlParameter("@MontoMaximoCredito", Me.MontoMaximoCredito), _
             New SqlParameter("@DistribuidorPorcentaje", Me.DistribuidorPorcentaje), _
             New SqlParameter("@VendedorAsignado", Me.VendedorAsignado), _
             New SqlParameter("@UltimaEscala", Me.UltimaEscala)}

            If Me.FinCredito = Date.MinValue Then
                parameters(6).Value = DBNull.Value
            End If

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete RFCs where idRFC=@idRFC"
            Dim param As SqlParameter() = {New SqlParameter("@idRFC", Me.idRFC)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveComprobante As Integer) As DataSet
            Dim sql As String = "select * from RFCs"

            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

        Public Function GetDR(ByVal claveRFC As String, ByVal claveidrfcNoDisplay As Integer) As SqlDataReader
            Dim sql As String = "select * from RFCs where rfc like @claveRFC and idRFC<>@idRFC order by rfc"
            Dim param As SqlParameter() = {New SqlParameter("@claveRFC", claveRFC & "%"), New SqlParameter("@idRFC", claveidrfcNoDisplay)}
            Return Me.ExecuteReader(sql, param)
        End Function


        Public Function GetRFCyDomicilioFiscal(ByVal claveRFC As String) As DataSet
            Dim sql As String = "select r.rfc, r.nombre, r.editable, d.*, r.vendedorasignado, up.nombre + ' ' + up.apellidos as nombrevendedor  from rfcs r left outer join  UserProfiles  as up on up.idUserProfile=r.VendedorAsignado left outer join  domicilios as d on d.idRFC=r.idrfc and d.tipo='fiscal'  where   r.rfc=@rfc  "
            Dim param As SqlParameter() = {New SqlParameter("@rfc", claveRFC)}
            Return Me.ExecuteDataSet(sql, param)

        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = " select r.*,  " & _
                " (select sum(total) from ordenes where rfc=r.rfc) as Cotizaciones, " & _
                " (select sum(total) from ordenes where rfc=r.rfc and proyectoEnTramite=1) as Proyectos, " & _
                " (select sum(cp.total) from comprobantes cp, rfcs rf where rf.idrfc=cp.idrfcreceptor and rf.rfc=r.rfc and status='terminado') as Facturas " & _
              " from RFCs r where idrfc<>1 order by rfc"

            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

    End Class

End Namespace
