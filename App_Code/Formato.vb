
Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class Formato
        Inherits DBObject

        Public idFormato As Integer
        Public eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from Formatos where idFormato=@idFormato"
            Dim params As SqlParameter() = {New SqlParameter("@idFormato", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idFormato = CInt(dr("idFormato"))
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Protected Function Add() As Integer
            Dim sql As String = "insert into Formatos (eliminado) values ( @eliminado)"
            Dim params As SqlParameter() = { _
            New SqlParameter("@eliminado", eliminado)}

            Me.idFormato = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1
        End Function

        Protected Function Update() As Integer
            Dim sql As String = "update Formatos set eliminado=@eliminado where idFormato=@idFormato"
            Dim params As SqlParameter() = {New SqlParameter("@eliminado", eliminado), _
                 New SqlParameter("@idFormato", idFormato)}

            Return Me.ExecuteNonQuery(sql, params)


        End Function



        Protected Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function







    End Class

End Namespace
