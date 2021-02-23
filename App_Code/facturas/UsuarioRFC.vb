

Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class UsuarioRFC
        Inherits tienda.DBObject

        Public IdUsuarioRFC As Integer
        Public IdUsuario As Integer
        Public idRFC As Integer


        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveUsuariorfc As Integer)
            Dim sql As String = "select * from UsuariosRFCs where IdUsuarioRFC=@IdUsuarioRFC"

            Dim param As SqlParameter() = {New SqlParameter("@IdUsuarioRFC", claveUsuariorfc)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.IdUsuarioRFC = CInt(dr("IdUsuarioRFC"))
                Me.IdUsuario = CInt(dr("IdUsuario"))
                Me.idRFC = CInt(dr("idRFC"))

                Me.existe = True
            End If
            dr.Close()


        End Sub


        Sub New(ByVal claveUsuario As Integer, ByVal claveRFC As Integer)
            Dim sql As String = "select * from UsuariosRFCs where idUsuario=@idUsuario and idRFC=@idRFC"

            Dim param As SqlParameter() = {New SqlParameter("@idUsuario", claveUsuario), New SqlParameter("@idRFC", claveRFC)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.IdUsuarioRFC = CInt(dr("IdUsuarioRFC"))
                Me.IdUsuario = CInt(dr("IdUsuario"))
                Me.idRFC = CInt(dr("idRFC"))

                Me.existe = True
            End If
            dr.Close()


        End Sub


        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO UsuariosRFCs (idUsuario, idRFC)  VALUES (@idUsuario, @idRFC)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idUsuario", Me.IdUsuario), _
             New SqlParameter("@idRFC", Me.idRFC)}

            Me.IdUsuarioRFC = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update UsuariosRFCs set idUsuario=@idUsuario, idRFC=@idRFC where  IdUsuarioRFC=@IdUsuarioRFC"


            Dim parameters As SqlParameter() = { _
                 New SqlParameter("@idUsuario", Me.IdUsuario), _
                 New SqlParameter("@idRFC", Me.idRFC), _
               New SqlParameter("@IdUsuarioRFC", Me.IdUsuarioRFC)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete UsuariosRFCs where idUsuarioRFC=@idUsuarioRFC"
            Dim param As SqlParameter() = {New SqlParameter("@IdUsuarioRFC", Me.IdUsuarioRFC)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveUsuario As Integer) As DataSet
            Dim sql As String = "select *  from UsuariosRFCs where idUsuario=@idUsuario"
            Dim param As SqlParameter() = {New SqlParameter("@IdUsuario", claveUsuario)}
            Return Me.ExecuteDataSet(sql, param)
        End Function

        Public Function GetDR(ByVal claveUsuario As Integer) As SqlDataReader
            Dim sql As String = "select * from UsuariosRFCs where idUsuario=@idUsuario"
            Dim param As SqlParameter() = {New SqlParameter("@IdUsuario", claveUsuario)}
            Return Me.ExecuteReader(sql, param)
        End Function

        Public Function GetDSRFCs(ByVal claveUsuario As Integer) As DataSet
            Dim sql As String = "select r.*, ur.idUsuario, ur.idUsuarioRFC, " & _
                " (select sum(c.total) from comprobantes c where c.idRFC=r.idRFC and c.sello<>'')  as facturas " & _
                " from UsuariosRFCs ur, rfcs r  where ur.idRfc=r.idRFC and ur.idUsuario=@idUsuario"
            Dim param As SqlParameter() = {New SqlParameter("@IdUsuario", claveUsuario)}
            Return Me.ExecuteDataSet(sql, param)
        End Function

    End Class

End Namespace
