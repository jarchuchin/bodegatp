
Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class Fabricante
        Inherits DBObject

        Public idFabricante As Integer
        Public prefijo As String
     
        Public eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from Fabricantes where idFabricante=@idFabricante"
            Dim params As SqlParameter() = {New SqlParameter("@idFabricante", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idFabricante = CInt(dr("idFabricante"))
                Me.prefijo = dr("prefijo")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Protected Function Add() As Integer
            Dim sql As String = "insert into Fabricantes ( prefijo, eliminado) values ( @prefijo, @eliminado)"
            Dim params As SqlParameter() = { _
            New SqlParameter("@prefijo", prefijo), _
            New SqlParameter("@eliminado", eliminado)}

            Me.idFabricante = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1
        End Function

        Protected Function Update() As Integer
            Dim sql As String = "update Fabricantes set prefijo=@prefijo, eliminado=@eliminado where idFabricante=@idFabricante"
            Dim params As SqlParameter() = { _
            New SqlParameter("@prefijo", prefijo), _
            New SqlParameter("@eliminado", eliminado), _
            New SqlParameter("@idFabricante", idFabricante)}

            Return Me.ExecuteNonQuery(sql, params)


        End Function



        Protected Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function







    End Class

End Namespace
