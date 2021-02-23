Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace tienda


    Public Class RolesUser
        Inherits DBObject
        Public idRolUser As Integer
        Public idRol As Integer
        Public idUserprofile As Integer



        Public Exist As Boolean = False



        Sub New()

        End Sub

        Sub New(ByVal claveRolUsuario As Integer)
            Dim sql As String = "select * from Rolesuser where idRolUser=@idRolUser"

            Dim param As SqlParameter() = {New SqlParameter("@idRolUser", claveRolUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idRolUser = CInt(dr("idRolUser"))
                Me.idRol = CInt(dr("idRol"))
                Me.idUserprofile = CInt(dr("idUserprofile"))
                Me.Exist = True
            End If
            dr.Close()

        End Sub


        Sub New(ByVal claveRol As Integer, ByVal claveUsuario As Integer)
            Dim sql As String = "select * from Rolesuser where idRol=@idRol and idUserprofile=@idUserprofile"

            Dim param As SqlParameter() = {New SqlParameter("@idRol", claveRol), New SqlParameter("@idUserprofile", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idRolUser = CInt(dr("idRolUser"))
                Me.idRol = CInt(dr("idRol"))
                Me.idUserprofile = CInt(dr("idUserprofile"))
                Me.Exist = True
            End If
            dr.Close()

        End Sub


        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Rolesuser (idRol, idUserprofile)  VALUES (@idRol, @idUserprofile) "

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRol", Me.idRol), _
             New SqlParameter("@idUserprofile", Me.idUserprofile)}

            Dim myru As RolesUser = New RolesUser(Me.idRol, Me.idUserprofile)
            If Not myru.Exist Then
                Me.idRolUser = Me.ExecuteNonQuery(queryString, parameters, True)
            End If


            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Rolesuser set idRol=@idRol, idUserprofile=@idUserprofile where  idRolUser=@idRolUser"


            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idUserprofile", Me.idUserprofile), _
             New SqlParameter("@idRol", Me.idRol), _
             New SqlParameter("@idRolUser", Me.idRolUser)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function


        Public Function Remove() As Integer
            Dim sql As String = "delete Rolesuser where idRolUser=@idRolUser"
            Dim parameters As SqlParameter() = { _
           New SqlParameter("@idRolUser", Me.idRolUser)}

            Return Me.ExecuteNonQuery(sql, parameters)

        End Function

        Public Function PrivilegiosEspeciales(ByVal claveusuario As Integer) As Boolean
            Dim sql As String = "select * from Rolesuser where iduserprofile=@iduserProfile and idRol<>4"
            Dim parameters As SqlParameter() = { _
           New SqlParameter("@iduserProfile", claveusuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, parameters)
            Dim regreso As Boolean = False
            If dr.HasRows Then
                regreso = True
            End If

            dr.Close()
            Return regreso

        End Function

        Public Function GetDSPrivilegios() As DataSet
            Dim sql As String = "select ru.*, u.nombre, u.apellidos, u.email  from Rolesuser ru, userprofiles u where u.iduserprofile = ru.iduserprofile and ru.idroluser <> 2"
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function


        Public Function GetDSRangos(numero As Integer, instancia As Integer) As Integer

            Dim sql As String = "select ru.*, u.nombre, u.apellidos, u.email, u.rango1, u.rango2, u.sucursal  from Rolesuser ru, userprofiles u where u.iduserprofile = ru.iduserprofile and u.rango1<=@numero and u.rango2>=@numero and ru.idrol <> 2 and u.idInstancia=@instancia"
            Dim parameters As SqlParameter() = { _
       New SqlParameter("@numero", numero), New SqlParameter("@instancia", instancia)}


            Dim mydr As SqlDataReader = Me.ExecuteReader(sql, parameters)
            Dim regreso As Integer = 0
            If mydr.Read Then
                regreso = CInt(mydr("idUserProfile"))

            End If
            mydr.Close()

           


            Return regreso
        End Function

    End Class
End Namespace
