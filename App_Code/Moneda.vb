Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class Moneda
        Inherits DBObject

        Public idMoneda As Integer
        Public nombre As String
        Public simbolo As String
        Public eliminado As Boolean



        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from monedas where idMoneda=@idMoneda"
            Dim params() As SqlParameter = {New SqlParameter("@idMoneda", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idMoneda = CInt(dr("idMoneda"))
                Me.nombre = dr("nombre")
                Me.simbolo = dr("simbolo")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If

            dr.Close()
        End Sub

        Public Function Add() As Integer
            Dim sql As String = "insert into monedas (nombre, simbolo, eliminado) values (@nombre, @simbolo, @eliminado)"
            Dim params() As SqlParameter = {New SqlParameter("@nombre", nombre), _
                                            New SqlParameter("@simbolo", simbolo), _
                                            New SqlParameter("@eliminado", eliminado)}

            Me.idMoneda = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update monedas set nombre=@nombre, simbolo=@simbolo, eliminado=@eliminado where idMoneda=@idMoneda"
            Dim params() As SqlParameter = {New SqlParameter("@nombre", nombre), New SqlParameter("@simbolo", simbolo), New SqlParameter("@idMoneda", idMoneda), New SqlParameter("@eliminado", eliminado)}

            Me.ExecuteNonQuery(sql, params)
            Return 1

        End Function

        Public Function Remove() As Integer
            Me.eliminado = True
            Me.Update()
        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select * from monedas where eliminado=0"
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function
    End Class
End Namespace
