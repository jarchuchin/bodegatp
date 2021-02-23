

Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Serie
        Inherits tienda.DBObject

        Public idSerie As Integer
        Public idRFC As Integer
        Public tipo As String
        Public desde As String
        Public hasta As String
        Public FechaRegistro As DateTime



        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidSerie As Integer)
            Dim sql As String = "select * from Series where idSerie=@idSerie"
            Dim param As SqlParameter() = {New SqlParameter("@idSerie", claveidSerie)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idSerie = CInt(dr("idSerie"))
                Me.idRFC = CInt(dr("idRFC"))
                Me.tipo = dr("tipo")
                Me.desde = dr("desde")
                Me.hasta = dr("hasta")
                Me.FechaRegistro = CDate(dr("fechaRegistro"))
                Me.existe = True
            End If
            dr.Close()
        End Sub





        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Series (idRFC, tipo, desde, hasta, FechaRegistro)  VALUES (@idRFC, @tipo, @desde, @hasta, @FechaRegistro)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRFC", Me.idRFC), _
             New SqlParameter("@tipo", Me.tipo), _
             New SqlParameter("@desde", Me.desde), _
             New SqlParameter("@hasta", Me.hasta), _
             New SqlParameter("@FechaRegistro", Me.FechaRegistro)}

            Me.idSerie = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Series set idRFC=@idRFC, tipo=@tipo, desde=@desde, hasta=@hasta, FechaRegistro=@FechaRegistro where  idSerie=@idSerie"


            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRFC", Me.idRFC), _
             New SqlParameter("@tipo", Me.tipo), _
             New SqlParameter("@desde", Me.desde), _
             New SqlParameter("@hasta", Me.hasta), _
             New SqlParameter("@idSerie", Me.idSerie), _
             New SqlParameter("@FechaRegistro", Me.FechaRegistro)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Series where idSerie=@idSerie"
            Dim param As SqlParameter() = {New SqlParameter("@idSerie", Me.idSerie)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveidRFC As Integer) As DataSet
            Dim sql As String = "select * from Series where idRFC=@idRFC"
            Dim param As SqlParameter() = {New SqlParameter("@idRFC", claveidRFC)}
            Return Me.ExecuteDataSet(sql, param)
        End Function

        Public Function GetDSSerieName(ByVal claveidRFC As Integer) As DataSet
            Dim sql As String = "select s.idSerie, 'Serie: '  + s.desde +  ' - ' + s.hasta + ', Tipo:' +  s.tipo as serieName from Series s where s.idRFC=@idRFC"
            Dim param As SqlParameter() = {New SqlParameter("@idRFC", claveidRFC)}
            Return Me.ExecuteDataSet(sql, param)
        End Function


    End Class

End Namespace
