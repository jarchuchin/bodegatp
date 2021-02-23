Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Usuario
        Inherits tienda.DBObject

        Public IdUsuario As Integer
        Public Login As String
        Public Password As String
        Public Nombre As String
        Public Apellidos As String
        Public Email As String
        Public Movil As String
        Public FechaRegistro As DateTime
        Public Foto As String
        Public Descripcion As String
        Public Eliminado As Boolean

        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveUsuario As Integer)
            Dim sql As String = "select * from Usuarios where IdUsuario=@IdUsuario"

            Dim param As SqlParameter() = {New SqlParameter("@IdUsuario", claveUsuario)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.IdUsuario = CInt(dr("IdUsuario"))
                Me.Login = dr("Login")
                Me.Password = Me.Desencriptar(dr("Password"))
                Me.Nombre = dr("Nombre")
                Me.Apellidos = dr("Apellidos")
                Me.Email = dr("Email")
                Me.Movil = dr("Movil")
                Me.FechaRegistro = CType(dr("FechaRegistro"), DateTime)
                Me.Foto = dr("Foto")
                Me.Descripcion = dr("Descripcion")
                Me.Eliminado = CType(dr("Eliminado"), Boolean)

                Me.existe = True
            End If
            dr.Close()


        End Sub


        Sub New(ByVal claveUsuarioLogin As String)
            Dim sql As String = "select * from Usuarios where Login=@Login"

            Dim param As SqlParameter() = {New SqlParameter("@Login", claveUsuarioLogin)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.IdUsuario = CInt(dr("IdUsuario"))
                Me.Login = dr("Login")
                Me.Password = Me.Desencriptar(dr("Password"))
                Me.Nombre = dr("Nombre")
                Me.Apellidos = dr("Apellidos")
                Me.Email = dr("Email")
                Me.Movil = dr("Movil")
                Me.FechaRegistro = CType(dr("FechaRegistro"), DateTime)
                Me.Foto = dr("Foto")
                Me.Descripcion = dr("Descripcion")
                Me.Eliminado = CType(dr("Eliminado"), Boolean)

                Me.existe = True
            End If
            dr.Close()


        End Sub


        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Usuarios (Login, Password, Email, Movil, Eliminado, FechaRegistro, nombre, apellidos, foto, descripcion)  VALUES (@Login, @Password, @Email, @Movil,@Eliminado, @FechaRegistro, @nombre, @apellidos, @foto, @descripcion)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@Login", Me.Login), _
             New SqlParameter("@Password", Me.Encriptar(Me.Password)), _
             New SqlParameter("@Email", Me.Email), _
             New SqlParameter("@Movil", Me.Movil), _
             New SqlParameter("@Eliminado", Me.Eliminado), _
             New SqlParameter("@nombre", Me.Nombre), _
             New SqlParameter("@apellidos", Me.Apellidos), _
             New SqlParameter("@foto", Me.Foto), _
             New SqlParameter("@descripcion", Me.Descripcion), _
             New SqlParameter("@FechaRegistro", Me.FechaRegistro)}

            Me.IdUsuario = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Usuarios set Login=@Login, Password=@Password, Email=@Email, Movil=@Movil, Eliminado=@Eliminado, FechaRegistro=FechaRegistro, nombre=@nombre, apellidos=@apellidos, foto=@foto, descripcion=@descripcion where  IdUsuario=@IdUsuario"


            Dim parameters As SqlParameter() = { _
             New SqlParameter("@Login", Me.Login), _
             New SqlParameter("@Password", Me.Encriptar(Me.Password)), _
             New SqlParameter("@Email", Me.Email), _
             New SqlParameter("@Movil", Me.Movil), _
             New SqlParameter("@Eliminado", Me.Eliminado), _
                   New SqlParameter("@nombre", Me.Nombre), _
             New SqlParameter("@apellidos", Me.Apellidos), _
                New SqlParameter("@foto", Me.Foto), _
             New SqlParameter("@descripcion", Me.Descripcion), _
             New SqlParameter("@FechaRegistro", Me.FechaRegistro), _
             New SqlParameter("@IdUsuario", Me.IdUsuario)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Me.Eliminado = True
            Me.Update()
            Return 1

        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select * from Usuarios where eliminado=0"
            Return Me.ExecuteDataSet(sql, Nothing)
        End Function



    End Class

End Namespace
