Imports System.Data.SqlClient
Imports System.Data

Namespace tienda



    Public Class Configuracion
        Inherits DBObject


        Public idConfiguracion As Integer
        Public email As String
        Public activarImpuesto As Boolean
        Public activarPagoAutomatico As Boolean
        Public visitas As Boolean
        Public ididiomaDefault As Integer


        Public existe As Boolean = False



        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from Configuraciones where idConfiguracion=@idConfiguracion"
            Dim params As SqlParameter() = {New SqlParameter("@idConfiguracion", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idConfiguracion = CInt(dr("idConfiguracion"))
                Me.email = dr("email")
                Me.activarImpuesto = CBool(dr("activarImpuesto"))
                Me.activarPagoAutomatico = CBool(dr("activarPagoAutomatico"))
                Me.visitas = CInt(dr("visitas"))
                Me.ididiomaDefault = CInt(dr("ididiomaDefault"))
                Me.existe = True

            End If
            dr.Close()
        End Sub


        Public Function Add() As Integer
            Dim sql As String = "insert into configuraciones (email,  activarimpuesto, activarpagoAutomatico, visitas, ididiomaDefault) values (@email, @activarimpuesto, @activarpagoAutomatico, @visitas, @ididiomaDefault)"
            Dim params As SqlParameter() = {New SqlParameter("@email", email), _
                                            New SqlParameter("@activarimpuesto", activarImpuesto), _
                                            New SqlParameter("@activarpagoAutomatico", activarPagoAutomatico), _
                                            New SqlParameter("@visitas", visitas), _
                                            New SqlParameter("@ididiomaDefault", ididiomaDefault)}

            Me.idConfiguracion = Me.ExecuteNonQuery(sql, params, True)

            Return 1

        End Function

        Public Function Update() As Integer
            Dim sql As String = "update configuraciones set email=@email, activarImpuesto=@activarImpuesto, activarPagoAutomatico=@activarPagoAutomatico, visitas=@visitas, ididiomaDefault=@ididiomaDefault where idConfiguracion=@idConfiguracion"
            Dim params As SqlParameter() = {New SqlParameter("@email", email), _
                                            New SqlParameter("@activarImpuesto", activarImpuesto), _
                                            New SqlParameter("@activarPagoAutomatico", activarPagoAutomatico), _
                                            New SqlParameter("@visitas", visitas), _
                                            New SqlParameter("@idConfiguracion", idConfiguracion), _
                                            New SqlParameter("@ididiomaDefault", ididiomaDefault)}

            Me.ExecuteNonQuery(sql, params)

            Return 1

        End Function







    End Class

End Namespace