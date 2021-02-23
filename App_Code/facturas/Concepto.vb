

Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Concepto
        Inherits tienda.DBObject

        Public idConcepto As Integer
        Public idComprobante As Integer
        Public cantidad As Decimal
        Public unidad As String
        Public noIdentificacion As String
        Public descripcion As String
        Public valorUnitario As Decimal
        Public importe As Decimal
        Public tipoDatoAnexo As String
        Public cuentaPredial As String


        Public existe As Boolean = False

        Private numDecimales As Integer = 4


        Sub New()

        End Sub

        Sub New(ByVal claveidConcepto As Integer)
            Dim sql As String = "select * from Conceptos where idConcepto=@idConcepto"

            Dim param As SqlParameter() = {New SqlParameter("@idConcepto", claveidConcepto)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idConcepto = CInt(dr("idConcepto"))
                Me.idComprobante = CInt(dr("idComprobante"))
                Me.cantidad = CInt(dr("cantidad"))
                Me.unidad = dr("unidad")
                Me.noIdentificacion = dr("noIdentificacion")
                Me.descripcion = dr("descripcion")
                Me.valorUnitario = CDec(dr("valorUnitario"))
                Me.importe = CDec(dr("importe"))
                Me.tipoDatoAnexo = dr("tipoDatoAnexo")
                Me.cuentaPredial = dr("cuentaPredial")
                Me.existe = True
            End If
            dr.Close()


        End Sub





        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Conceptos (idComprobante, cantidad, unidad, noIdentificacion, descripcion, valorUnitario, importe, tipoDatoAnexo, cuentaPredial)  VALUES (@idComprobante, @cantidad, @unidad, @noIdentificacion, @descripcion, @valorUnitario, @importe, @tipoDatoAnexo, @cuentaPredial)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idComprobante", Me.idComprobante), _
             New SqlParameter("@cantidad", Me.cantidad), _
             New SqlParameter("@unidad", Me.unidad), _
             New SqlParameter("@noIdentificacion", Me.noIdentificacion), _
             New SqlParameter("@descripcion", Me.descripcion), _
             New SqlParameter("@valorUnitario", Me.valorUnitario), _
             New SqlParameter("@importe", Me.importe), _
             New SqlParameter("@tipoDatoAnexo", Me.tipoDatoAnexo), _
             New SqlParameter("@cuentaPredial", Me.cuentaPredial)}

            Me.idConcepto = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Conceptos set idComprobante=@idComprobante, cantidad=@cantidad, unidad=@unidad, noIdentificacion=@noIdentificacion, descripcion=@descripcion, valorUnitario=@valorUnitario, importe=@importe, tipoDatoAnexo=@tipoDatoAnexo, cuentaPredial=@cuentaPredial where  idConcepto=@idConcepto"


            Dim parameters As SqlParameter() = { _
            New SqlParameter("@idComprobante", Me.idComprobante), _
            New SqlParameter("@cantidad", Me.cantidad), _
            New SqlParameter("@unidad", Me.unidad), _
            New SqlParameter("@noIdentificacion", Me.noIdentificacion), _
            New SqlParameter("@descripcion", Me.descripcion), _
            New SqlParameter("@valorUnitario", Me.valorUnitario), _
            New SqlParameter("@importe", Me.importe), _
            New SqlParameter("@tipoDatoAnexo", Me.tipoDatoAnexo), _
            New SqlParameter("@cuentaPredial", Me.cuentaPredial), _
             New SqlParameter("@idConcepto", Me.idConcepto)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Conceptos where idConcepto=@idConcepto"
            Dim param As SqlParameter() = {New SqlParameter("@idConcepto", Me.idConcepto)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveidComprobante As Integer) As DataSet
            Dim sql As String = "select * from Conceptos where idComprobante=@idComprobante"
            Dim param As SqlParameter() = {New SqlParameter("@idComprobante", claveidComprobante)}
            Return Me.ExecuteDataSet(sql, param)
        End Function


        Public Function GetDSConcepto(ByVal claveConceptor As Integer) As DataSet
            Dim sql As String = "select * from Conceptos where idConcepto=@idConcepto "
            Dim param As SqlParameter() = {New SqlParameter("@idConcepto", claveConceptor)}
            Return Me.ExecuteDataSet(sql, param)

        End Function

        Public Function GetPrimerConcepto(ByVal claveidComprobante As Integer) As Integer
            Dim sql As String = "select * from Conceptos where idComprobante=@idComprobante"
            Dim param As SqlParameter() = {New SqlParameter("@idComprobante", claveidComprobante)}
            Dim dr As SqlClient.SqlDataReader = Me.ExecuteReader(sql, param)
            Dim regreso As Integer = 0
            If dr.Read Then
                regreso = CInt(dr("idConcepto"))
            End If
            dr.Close()

            Return regreso

        End Function
    End Class

End Namespace

