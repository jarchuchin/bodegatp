Imports System.Data
Imports System.Data.SqlClient

Namespace tienda


    Public Class Rol
        Inherits DBObject

        Public idRol As Integer
        Public nombre As String
        Public eliminado As String


        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from Roles where idRol=@idRol"
            Dim params() As SqlParameter = {New SqlParameter("@idRol", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idRol = CInt(dr("idRol"))
                Me.nombre = dr("nombre")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If

            dr.Close()
        End Sub

        Public Function Add() As Integer
            Dim sql As String = "insert into Roles (nombre,  eliminado) values (@nombre, @eliminado)"
            Dim params() As SqlParameter = {New SqlParameter("@nombre", nombre), _
                                New SqlParameter("@eliminado", eliminado)}

            Me.idRol = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update Roles set nombre=@nombre,  eliminado=@eliminado where idRol=@idRol"
            Dim params() As SqlParameter = {New SqlParameter("@nombre", nombre), New SqlParameter("@idRol", idRol), New SqlParameter("@eliminado", eliminado)}

            Me.ExecuteNonQuery(sql, params)
            Return 1

        End Function

        Public Function Remove() As Integer
            Me.eliminado = True
            Me.Update()
        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select * from Roles where eliminado=0"
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function

    End Class
End Namespace
