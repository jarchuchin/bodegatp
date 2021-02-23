


Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Log
        Inherits tienda.DBObject

        Public idLog As Integer
        Public IdUsuario As Integer
        Public idRFC As Integer
        Public tipoAccion As String
        Public fechaAccion As DateTime
        Public descripcion As String
        Public respuesta As String


        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveLog As Integer)
            Dim sql As String = "select * from Logs where idLog=@idLog"

            Dim param As SqlParameter() = {New SqlParameter("@idLog", claveLog)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idLog = CInt(dr("idLog"))
                Me.IdUsuario = CInt(dr("IdUsuario"))
                Me.idRFC = CInt(dr("idRFC"))
                Me.tipoAccion = dr("tipoAccion")
                Me.fechaAccion = CDate(dr("fechaAccion"))
                Me.descripcion = dr("descripcion")
                Me.respuesta = dr("respuesta")
                Me.existe = True
            End If
            dr.Close()


        End Sub


      


        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Logs (idUsuario, idRFC, tipoAccion, fechaAccion, descripcion, respuesta)  VALUES (@idUsuario, @idRFC, @tipoAccion, @fechaAccion, @descripcion, @respuesta)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idUsuario", Me.IdUsuario), _
             New SqlParameter("@idRFC", Me.idRFC), _
             New SqlParameter("@tipoAccion", Me.tipoAccion), _
             New SqlParameter("@fechaAccion", Me.fechaAccion), _
             New SqlParameter("@descripcion", Me.descripcion), _
             New SqlParameter("@respuesta", Me.respuesta)}

            Me.idLog = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Logs set idUsuario=@idUsuario, idRFC=@idRFC, tipoAccion=@tipoAccion, fechaAccion=@fechaAccion, descripcion=@descripcion, respuesta=@respuesta where  idLog=@idLog"


            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idUsuario", Me.IdUsuario), _
             New SqlParameter("@idRFC", Me.idRFC), _
             New SqlParameter("@tipoAccion", Me.tipoAccion), _
             New SqlParameter("@fechaAccion", Me.fechaAccion), _
             New SqlParameter("@descripcion", Me.descripcion), _
             New SqlParameter("@respuesta", Me.respuesta), _
             New SqlParameter("@idLog", Me.idLog)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Logs where idLog=@idLog"
            Dim param As SqlParameter() = {New SqlParameter("@idLog", Me.idLog)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveUsuario As Integer) As DataSet
            Dim sql As String = "select * from Logs where idUsuario=@idUsuario order by fechaaccion desc"
            Dim param As SqlParameter() = {New SqlParameter("@idUsuario", claveUsuario)}
            Return Me.ExecuteDataSet(sql, param)
        End Function



    End Class

End Namespace
