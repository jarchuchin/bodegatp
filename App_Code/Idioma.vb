Imports System.Data
Imports System.Data.SqlClient


Namespace tienda


    Public Class Idioma
        Inherits DBObject

        Public idIdioma As Integer
        Public idMoneda As Integer
        Public nombre As String
        Public cultureid As String
        Public eliminado As Boolean


        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from Idiomas where idIdioma =@idIdioma"
            Dim params() As SqlParameter = {New SqlParameter("@idIdioma", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.idMoneda = CInt(dr("idMoneda"))
                Me.nombre = dr("nombre")
                Me.cultureid = dr("cultureid")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If

            dr.Close()


        End Sub

        Sub New(ByVal clavePrincipal As String)
            Dim sql As String = "select * from Idiomas where cultureid =@cultureid"
            Dim params() As SqlParameter = {New SqlParameter("@cultureid", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.idMoneda = CInt(dr("idMoneda"))
                Me.nombre = dr("nombre")
                Me.cultureid = dr("cultureid")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If

            dr.Close()


        End Sub

        Public Function Add() As Integer
            Dim sql As String = "insert into idiomas (idMoneda, nombre, cultureid, eliminado) values (@idMoneda, @nombre, @cultureid, @eliminado)"
            Dim params() As SqlParameter = {New SqlParameter("@idMoneda", Me.idMoneda), New SqlParameter("@nombre", Me.nombre), New SqlParameter("@cultureid", Me.cultureid), New SqlParameter("@eliminado", eliminado)}
            Me.idIdioma = Me.ExecuteNonQuery(sql, params, True)
            Return 1

        End Function

        Public Function Update() As Integer
            Dim sql As String = "update idiomas set idMoneda=@idMoneda, nombre=@nombre, cultureid=@cultureid where idIdioma=@idIdioma"
            Dim params() As SqlParameter = {New SqlParameter("@idMoneda", Me.idMoneda), New SqlParameter("@nombre", Me.nombre), New SqlParameter("@cultureid", Me.cultureid), New SqlParameter("@idIdioma", Me.idIdioma)}
            Return Me.ExecuteNonQuery(sql, params)

        End Function

        Public Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select * from idiomas where eliminado=0"
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function


    End Class

End Namespace
