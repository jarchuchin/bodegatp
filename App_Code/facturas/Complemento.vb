
Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Complemento
        Inherits tienda.DBObject

        Public idComplemento As Integer
        Public idConcepto As Integer
        Public descripcion As String


        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidComplemento As Integer)
            Dim sql As String = "select * from Complementos where idComplemento=@idComplemento"

            Dim param As SqlParameter() = {New SqlParameter("@idComplemento", claveidComplemento)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idComplemento = CInt(dr("idComplemento"))
                Me.idConcepto = CInt(dr("idConcepto"))
                Me.descripcion = dr("descripcion")

                Me.existe = True
            End If
            dr.Close()


        End Sub





        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Complementos (idConcepto, descripcion)  VALUES (@idConcepto, @descripcion)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idConcepto", Me.idConcepto), _
             New SqlParameter("@descripcion", Me.descripcion)}

            Me.idComplemento = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Complementos set idConcepto=@idConcepto, descripcion=@descripcion where  idComplemento=@idComplemento"


            Dim parameters As SqlParameter() = { _
                 New SqlParameter("@idConcepto", Me.idConcepto), _
                 New SqlParameter("@descripcion", Me.descripcion), _
               New SqlParameter("@idComplemento", Me.idComplemento)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Complementos where idConcepto=@idConcepto"
            Dim param As SqlParameter() = {New SqlParameter("@idConcepto", Me.idConcepto)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveidConcepto As Integer) As DataSet
            Dim sql As String = "select * from Complementos where idConcepto=@idConcepto"
            Dim param As SqlParameter() = {New SqlParameter("@idConcepto", claveidConcepto)}
            Return Me.ExecuteDataSet(sql, param)
        End Function



    End Class

End Namespace
