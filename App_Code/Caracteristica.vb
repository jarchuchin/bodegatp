


Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class Caracteristica
        Inherits DBObject

        Public idCaracteristica As Integer
        Public tipo As Integer
        Public requerido As Boolean
        Public caracteres As Integer
        Public minimo As Integer
        Public maximo As Integer
        Public orden As Integer
        Public eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from Caracteristicas where idCaracteristica=@idCaracteristica"
            Dim params As SqlParameter() = {New SqlParameter("@idCaracteristica", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idCaracteristica = CInt(dr("idCaracteristica"))
                Me.tipo = CType(dr("tipo"), tienda.TipoDato)
                Me.requerido = CBool(dr("requerido"))
                Me.caracteres = CInt(dr("caracteres"))
                Me.minimo = CInt(dr("minimo"))
                Me.minimo = CInt(dr("minimo"))
                Me.maximo = CInt(dr("maximo"))
                Me.orden = CInt(dr("orden"))
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Protected Function Add() As Integer
            Dim sql As String = "insert into Caracteristicas (tipo, requerido, caracteres, minimo, maximo, orden, eliminado) values (@tipo, @requerido, @caracteres, @minimo, @maximo, @orden, @eliminado)"
            Dim params As SqlParameter() = { _
            New SqlParameter("@tipo", tipo), _
            New SqlParameter("@requerido", requerido), _
            New SqlParameter("@caracteres", caracteres), _
            New SqlParameter("@minimo", minimo), _
            New SqlParameter("@maximo", maximo), _
            New SqlParameter("@orden", orden), _
            New SqlParameter("@eliminado", eliminado)}

            Me.idCaracteristica = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1
        End Function

        Protected Function Update() As Integer
            Dim sql As String = "update Caracteristicas set tipo=@tipo, requerido=@requerido, caracteres=@caracteres, minimo=@minimo, maximo=@maximo, orden=@orden, eliminado=@eliminado where idCaracteristica=@idCaracteristica"
            Dim params As SqlParameter() = { _
            New SqlParameter("@tipo", tipo), _
            New SqlParameter("@requerido", requerido), _
            New SqlParameter("@caracteres", caracteres), _
            New SqlParameter("@minimo", minimo), _
            New SqlParameter("@maximo", maximo), _
            New SqlParameter("@orden", orden), _
            New SqlParameter("@eliminado", eliminado), _
            New SqlParameter("@idCaracteristica", idCaracteristica)}

            Return Me.ExecuteNonQuery(sql, params)


        End Function

        Protected Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function



    End Class

End Namespace
