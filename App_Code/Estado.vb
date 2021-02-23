

Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class Estado
        Inherits DBObject

        Public idEstado As Integer
        Public idPais As Integer
        Public clave As String
        Public impuesto As Decimal
        Public eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from Estados where idEstado=@idEstado"
            Dim params As SqlParameter() = {New SqlParameter("@idEstado", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idPais = CInt(dr("idPais"))
                Me.idEstado = CInt(dr("idEstado"))
                Me.clave = dr("clave")
                Me.impuesto = CDec(dr("impuesto"))
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveprincipal As String, ByVal clavepais As Integer)
            Dim sql As String = "select * from Estados where clave=@clave and idpais=@idpais"
            Dim params As SqlParameter() = {New SqlParameter("@clave", claveprincipal), New SqlParameter("@idpais", clavepais)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idPais = CInt(dr("idPais"))
                Me.idEstado = CInt(dr("idEstado"))
                Me.clave = dr("clave")
                Me.impuesto = CDec(dr("impuesto"))
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Protected Function Add() As Integer
            Dim sql As String = "insert into Estados (idPais, clave, impuesto, eliminado) values (@idPais, @clave, @impuesto, @eliminado)"
            Dim params As SqlParameter() = {New SqlParameter("@idPais", idPais), New SqlParameter("@clave", clave), New SqlParameter("@impuesto", impuesto), New SqlParameter("@eliminado", eliminado)}
            Me.idEstado = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function

        Protected Function Update() As Integer
            Dim sql As String = "update Estados set idPais=@idPais, clave=@clave, impuesto=@impuesto, eliminado=@eliminado where idEstado=@idEstado"
            Dim params As SqlParameter() = { _
                                                                    New SqlParameter("@idPais", idPais), _
                                                                    New SqlParameter("@clave", clave), _
                                                                    New SqlParameter("@impuesto", impuesto), _
                                                                    New SqlParameter("@eliminado", eliminado), _
                                                                    New SqlParameter("@idEstado", idEstado)}

            Return Me.ExecuteNonQuery(sql, params)


        End Function

        Protected Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function



    End Class

End Namespace
