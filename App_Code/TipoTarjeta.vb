Imports System.Data.SqlClient
Imports System.Data

Namespace tienda


    Public Enum ETipoTarjeta
        Amex = 1
        MasterCard = 2
        VISA = 3
    End Enum



    Public Class TipoTarjeta
        Inherits DBObject

        Public idTipoTarjeta As Integer
        Public tipo As String
        Public foto As String
        Public eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from tipostarjetas where idTipoTarjeta=@idTipoTarjeta"
            Dim params() As SqlParameter = {New SqlParameter("@idTipoTarjeta", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idTipoTarjeta = CInt(dr("idTipoTarjeta"))
                Me.tipo = dr("tipo")
                Me.foto = dr("foto")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If

            dr.Close()
        End Sub


        Public Function Add() As Integer
            Dim sql As String = "insert into tipostarjetas (tipo, foto, eliminado) values (@tipo, @foto, @eliminado)"
            Dim params() As SqlParameter = {New SqlParameter("@tipo", tipo), _
                                            New SqlParameter("@foto", foto), _
                                            New SqlParameter("@eliminado", eliminado)}

            Me.idTipoTarjeta = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update tipostarjetas set tipo=@tipo, foto=@foto, eliminado=@eliminado where idTipoTarjeta=@idTipoTarjeta"
            Dim params() As SqlParameter = {New SqlParameter("@tipo", tipo), _
                                            New SqlParameter("@foto", foto), _
                                            New SqlParameter("@eliminado", eliminado), _
                                            New SqlParameter("@idTipoTarjeta", idTipoTarjeta)}

            Me.ExecuteNonQuery(sql, params)
            Return 1

        End Function

        Public Function Remove() As Integer
            Me.eliminado = True
            Me.Update()
        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select * from tipostarjetas where eliminado=0"
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function

    End Class
End Namespace
