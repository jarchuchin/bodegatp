Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class Pais
        Inherits DBObject

        Public idPais As Integer
        Public idMoneda As Integer
        Public clave As String
        Public eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from paises where idpais=@idPais"
            Dim params As SqlParameter() = {New SqlParameter("@idPais", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idPais = CInt(dr("idPais"))
                Me.idMoneda = CInt(dr("idMoneda"))
                Me.clave = dr("clave")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub


        Sub New(ByVal claveprincipal As String)
            Dim sql As String = "select * from paises where clave=@clave"
            Dim params As SqlParameter() = {New SqlParameter("@clave", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idPais = CInt(dr("idPais"))
                Me.idMoneda = CInt(dr("idMoneda"))
                Me.clave = dr("clave")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Protected Function Add() As Integer
            Dim sql As String = "insert into paises (idMoneda, clave, eliminado) values (@idMoneda, @clave, @eliminado)"
            Dim params As SqlParameter() = {New SqlParameter("@idMoneda", idMoneda), New SqlParameter("@clave", clave), New SqlParameter("@eliminado", eliminado)}
            Me.idPais = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True

            Return 1
        End Function

        Protected Function Update() As Integer
            Dim sql As String = "update paises set idMoneda=@idMoneda, clave=@clave, eliminado=@eliminado where idPais=@idPais"
            Dim params As SqlParameter() = { _
                                                                    New SqlParameter("@idMoneda", idMoneda), _
                                                                    New SqlParameter("@clave", clave), _
                                                                    New SqlParameter("@eliminado", eliminado), _
                                                                    New SqlParameter("@idPais", idPais)}

            Return Me.ExecuteNonQuery(sql, params)


        End Function

        Protected Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function



    End Class
End Namespace
