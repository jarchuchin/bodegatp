
Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Folio
        Inherits tienda.DBObject

        Public idFolio As Integer
        Public idSerie As Integer
        Public desde As String
        Public hasta As String
        Public statusAprobacion As String
        Public noAprobacion As Integer
        Public fechaRegistro As DateTime




        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidFolio As Integer)
            Dim sql As String = "select * from Folios where idFolio=@idFolio"
            Dim param As SqlParameter() = {New SqlParameter("@idFolio", claveidFolio)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idFolio = CInt(dr("idFolio"))
                Me.idSerie = CInt(dr("idSerie"))
                Me.desde = dr("desde")
                Me.hasta = dr("hasta")
                Me.statusAprobacion = dr("statusAprobacion")
                Me.noAprobacion = CInt(dr("noAprobacion"))
                Me.fechaRegistro = CDate(dr("fechaRegistro"))
                Me.existe = True
            End If
            dr.Close()
        End Sub





        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Folios (idSerie, desde, hasta, statusAprobacion, noAprobacion, fechaRegistro)  VALUES (@idSerie, @desde, @hasta, @statusAprobacion, @noAprobacion, @fechaRegistro)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idSerie", Me.idSerie), _
             New SqlParameter("@desde", Me.desde), _
             New SqlParameter("@hasta", Me.hasta), _
             New SqlParameter("@statusAprobacion", Me.statusAprobacion), _
             New SqlParameter("@noAprobacion", Me.noAprobacion), _
             New SqlParameter("@fechaRegistro", Me.fechaRegistro)}

            Me.idFolio = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Folios set idSerie=@idSerie, desde=@desde, hasta=@hasta, statusAprobacion=@statusAprobacion, noAprobacion=@noAprobacion, fechaRegistro=@fechaRegistro where  idFolio=@idFolio"


            Dim parameters As SqlParameter() = { _
       New SqlParameter("@idSerie", Me.idSerie), _
       New SqlParameter("@desde", Me.desde), _
       New SqlParameter("@hasta", Me.hasta), _
       New SqlParameter("@statusAprobacion", Me.statusAprobacion), _
       New SqlParameter("@noAprobacion", Me.noAprobacion), _
       New SqlParameter("@idFolio", Me.idFolio), _
             New SqlParameter("@fechaRegistro", Me.fechaRegistro)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Folios where idFolio=@idFolio"
            Dim param As SqlParameter() = {New SqlParameter("@idFolio", Me.idFolio)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveidSerie As Integer) As DataSet
            Dim sql As String = "select * from Folios where idSerie=@idSerie"
            Dim param As SqlParameter() = {New SqlParameter("@idSerie", claveidSerie)}
            Return Me.ExecuteDataSet(sql, param)
        End Function

        Public Function GetDSFolioName(ByVal claveidSerie As Integer) As DataSet
            Dim sql As String = "select f.idFolio, 'Folio: ' + cast(f.desde as nvarchar) + '-' + cast(f.hasta as nvarchar) as FolioName from Folios f where f.idSerie=@idSerie"
            Dim param As SqlParameter() = {New SqlParameter("@idSerie", claveidSerie)}
            Return Me.ExecuteDataSet(sql, param)
        End Function


      

    End Class

End Namespace
