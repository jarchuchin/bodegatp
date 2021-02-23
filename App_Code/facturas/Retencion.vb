

Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Retencion
        Inherits tienda.DBObject

        Public idRetencion As Integer
        Public idComprobante As Integer
        Public impuesto As String
        Public importe As Decimal

        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidRetencion As Integer)
            Dim sql As String = "select * from Retenciones where idRetencion=@idRetencion"

            Dim param As SqlParameter() = {New SqlParameter("@idRetencion", claveidRetencion)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idRetencion = CInt(dr("idRetencion"))
                Me.idComprobante = CInt(dr("idComprobante"))
                Me.impuesto = dr("impuesto")
                Me.importe = CDec(dr("importe"))

                Me.existe = True
            End If
            dr.Close()


        End Sub





        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Retenciones (idComprobante, impuesto,  importe)  VALUES (@idComprobante, @impuesto,  @importe)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idComprobante", Me.idComprobante), _
             New SqlParameter("@impuesto", Me.impuesto), _
             New SqlParameter("@importe", Me.importe)}

            Me.idRetencion = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Retenciones set idComprobante=@idComprobante, impuesto=@impuesto,  importe=@importe where  idRetencion=@idRetencion"


            Dim parameters As SqlParameter() = { _
                 New SqlParameter("@idComprobante", Me.idComprobante), _
                 New SqlParameter("@impuesto", Me.impuesto), _
                 New SqlParameter("@importe", Me.importe), _
                 New SqlParameter("@idRetencion", Me.idRetencion)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Retenciones where idRetencion=@idRetencion"
            Dim param As SqlParameter() = {New SqlParameter("@idRetencion", Me.idRetencion)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveComprobante As Integer) As DataSet
            Dim sql As String = "select * from Retenciones where idComprobante=@idComprobante"
            Dim param As SqlParameter() = {New SqlParameter("@idComprobante", claveComprobante)}
            Return Me.ExecuteDataSet(sql, param)
        End Function



    End Class

End Namespace
