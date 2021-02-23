Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class RolUsuario
        Inherits tienda.DBObject

        Public IdRolUsuario As Integer
        Public IdRol As Integer
        Public IdUsuario As Integer


        Public existe As Boolean = False


        Sub New()

        End Sub
        Sub New(ByVal claveRolUsuario As Integer)
            Dim sql As String = "select * from RolesUsuarios where IdRolUsuario=@IdRolUsuario"

            Dim param As SqlParameter() = {New SqlParameter("@IdRolUsuario", claveRolUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.IdRolUsuario = CInt(dr("IdRolUsuario"))
                Me.IdRol = CInt(dr("IdRol"))
                Me.IdUsuario = CInt(dr("IdUsuario"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveRol As Integer, ByVal claveUsuario As Integer)
            Dim sql As String = "select * from RolesUsuarios where IdRol=@IdRol and idUsuario=@idUsuario"

            Dim param As SqlParameter() = {New SqlParameter("@IdRol", claveRol), New SqlParameter("@idUsuario", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.IdRolUsuario = CInt(dr("IdRolUsuario"))
                Me.IdRol = CInt(dr("IdRol"))
                Me.IdUsuario = CInt(dr("IdUsuario"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO RolesUsuarios (IdRol, IdUsuario)  VALUES (@IdRol, @IdUsuario) "

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@IdRol", Me.IdRol), _
             New SqlParameter("@IdUsuario", Me.IdUsuario)}

            Me.IdRol = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update RolesUsuarios set  IdRol=@IdRol, IdUsuario=@IdUsuario where  IdRolUsuario=@IdRolUsuario"


            Dim parameters As SqlParameter() = { _
             New SqlParameter("@IdRolUsuario", Me.IdRolUsuario), _
             New SqlParameter("@IdRol", Me.IdRol), _
             New SqlParameter("@IdUsuario", Me.IdUsuario)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim queryString As String = "Delete RolesUsuarios where idRolUsuario=@idRolUsuario"

            Dim parameters As SqlParameter() = {New SqlParameter("@IdRolUsuario", Me.IdRolUsuario)}
            Return Me.ExecuteNonQuery(queryString, parameters)


        End Function


    End Class
End Namespace
