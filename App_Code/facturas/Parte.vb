Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Parte
        Inherits tienda.DBObject

        Public idParte As Integer
        Public idConcepto As Integer
        Public cantidad As Integer
        Public unidad As String
        Public noIdentificacion As String
        Public descripcion As String
        Public valorUnitario As Decimal
        Public importe As Decimal
        Public informacionAduanera As Boolean



        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidParte As Integer)
            Dim sql As String = "select * from Partes where idParte=@idParte"

            Dim param As SqlParameter() = {New SqlParameter("@idParte", claveidParte)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idParte = CInt(dr("idParte"))
                Me.idConcepto = CInt(dr("idConcepto"))
                Me.cantidad = CInt(dr("cantidad"))
                Me.unidad = dr("unidad")
                Me.noIdentificacion = dr("noIdentificacion")
                Me.descripcion = dr("descripcion")
                Me.valorUnitario = CDec(dr("valorUnitario"))
                Me.importe = CDec(dr("importe"))
                Me.informacionAduanera = CBool(dr("informacionAduanera"))
                Me.existe = True
            End If
            dr.Close()


        End Sub





        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Partes (idConcepto, cantidad, unidad, noIdentificacion, descripcion, valorUnitario, importe, informacionAduanera)  VALUES (@idConcepto, @cantidad, @unidad, @noIdentificacion, @descripcion, @valorUnitario, @importe, @informacionAduanera)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idConcepto", Me.idConcepto), _
             New SqlParameter("@cantidad", Me.cantidad), _
             New SqlParameter("@unidad", Me.unidad), _
             New SqlParameter("@noIdentificacion", Me.noIdentificacion), _
             New SqlParameter("@descripcion", Me.descripcion), _
             New SqlParameter("@valorUnitario", Me.valorUnitario), _
             New SqlParameter("@importe", Me.importe), _
             New SqlParameter("@informacionAduanera", Me.informacionAduanera)}

            Me.idParte = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Partes set idConcepto=@idConcepto, cantidad=@cantidad, unidad=@unidad, noIdentificacion=@noIdentificacion, descripcion=@descripcion, valorUnitario=@valorUnitario, importe=@improte, informacionAduanera=@informacionAduanera where  idParte=@idParte"


            Dim parameters As SqlParameter() = { _
               New SqlParameter("@idConcepto", Me.idConcepto), _
               New SqlParameter("@cantidad", Me.cantidad), _
               New SqlParameter("@unidad", Me.unidad), _
               New SqlParameter("@noIdentificacion", Me.noIdentificacion), _
               New SqlParameter("@descripcion", Me.descripcion), _
               New SqlParameter("@valorUnitario", Me.valorUnitario), _
               New SqlParameter("@importe", Me.importe), _
               New SqlParameter("@informacionAduanera", Me.informacionAduanera), _
              New SqlParameter("@idParte", Me.idParte)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Partes where idParte=@idParte"
            Dim param As SqlParameter() = {New SqlParameter("@idParte", Me.idParte)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveidConcepto As Integer) As DataSet
            Dim sql As String = "select * from Partes where idConcepto=@idConcepto"
            Dim param As SqlParameter() = {New SqlParameter("@idConcepto", claveidConcepto)}
            Return Me.ExecuteDataSet(sql, param)
        End Function



    End Class

End Namespace

