Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Rol
        Inherits tienda.DBObject
        Public IdRol As Integer
        Public Nombre As String
        Public Descripcion As String
        Public Eliminado As Boolean = False
        Public Existe As Boolean = False


        Sub New()

        End Sub
        Sub New(ByVal claveRol As Integer)
            Dim sql As String = "select * from Roles where IdRol=@IdRol"

            Dim param As SqlParameter() = {New SqlParameter("@IdRol", claveRol)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.IdRol = CInt(dr("IdRol"))
                Me.Nombre = dr("Nombre")
                Me.Descripcion = dr("Descripcion")
                Me.Eliminado = CBool(dr("Eliminado"))
                Me.Existe = True

            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Roles (Nombre, Descripcion, Eliminado)  VALUES (@Nombre, @Descripcion, @Eliminado) "

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@Nombre", Me.Nombre), _
             New SqlParameter("@Descripcion", Me.Descripcion), _
             New SqlParameter("@Eliminado", Me.Eliminado)}

            Me.IdRol = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Roles set Nombre=@Nombre,  Descripcion=@Descripcion, Eliminado=@Eliminado where  IdRol=@IdRol"


            Dim parameters As SqlParameter() = { _
             New SqlParameter("@Nombre", Me.Nombre), _
             New SqlParameter("@Descripcion", Me.Descripcion), _
             New SqlParameter("@Eliminado", Me.Eliminado), _
             New SqlParameter("@IdRol", Me.IdRol)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Me.Eliminado = True
            Me.Update()

        End Function
        Public Function GetDS() As DataSet
            Dim sql As String = "select * from Roles where eliminado=0"
            Return Me.ExecuteDataSet(sql, Nothing)
        End Function
    End Class
End Namespace

