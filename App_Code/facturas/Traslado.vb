

Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Traslado
        Inherits tienda.DBObject

        Public idTraslado As Integer
        Public idComprobante As Integer
        Public impuesto As String
        Public tasa As Decimal
        Public importe As Decimal

        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidTraslado As Integer)
            Dim sql As String = "select * from Traslados where idTraslado=@idTraslado"

            Dim param As SqlParameter() = {New SqlParameter("@idTraslado", claveidTraslado)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idTraslado = CInt(dr("idTraslado"))
                Me.idComprobante = CInt(dr("idComprobante"))
                Me.impuesto = dr("impuesto")
                Me.tasa = CDec(dr("tasa"))
                Me.importe = CDec(dr("importe"))

                Me.existe = True
            End If
            dr.Close()


        End Sub





        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Traslados (idComprobante, impuesto, tasa, importe)  VALUES (@idComprobante, @impuesto, @tasa, @importe)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idComprobante", Me.idComprobante), _
             New SqlParameter("@impuesto", Me.impuesto), _
             New SqlParameter("@tasa", Me.tasa), _
             New SqlParameter("@importe", Me.importe)}

            Me.idTraslado = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Traslados set idComprobante=@idComprobante, impuesto=@impuesto, tasa=@tasa, importe=@importe where  idTraslado=@idTraslado"


            Dim parameters As SqlParameter() = { _
                 New SqlParameter("@idComprobante", Me.idComprobante), _
                 New SqlParameter("@impuesto", Me.impuesto), _
                 New SqlParameter("@tasa", Me.tasa), _
                 New SqlParameter("@importe", Me.importe), _
                 New SqlParameter("@idTraslado", Me.idTraslado)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Traslados where idTraslado=@idTraslado"
            Dim param As SqlParameter() = {New SqlParameter("@idTraslado", Me.idTraslado)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveComprobante As Integer) As DataSet
            Dim sql As String = "select * from Traslados where idComprobante=@idComprobante"
            Dim param As SqlParameter() = {New SqlParameter("@idComprobante", claveComprobante)}
            Return Me.ExecuteDataSet(sql, param)
        End Function



    End Class

End Namespace
