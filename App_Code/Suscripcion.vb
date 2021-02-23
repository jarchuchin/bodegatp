

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace tienda
    Public Class Suscripcion
        Inherits DBObject

        Public idSuscripcion As Integer
        Public email As String
        Public enviarmail As Boolean
        Public fecha As DateTime
        Public existe As Boolean = False

        Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT * FROM Suscripciones WHERE idSuscripcion=@idSuscripcion"
            Dim parametros As SqlParameter() = {New SqlParameter("@idSuscripcion", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idSuscripcion = CInt(dr("idSuscripcion"))
                Me.email = dr("email")
                Me.enviarmail = CBool(dr("enviarmail"))
                Me.fecha = CDate(dr("fecha"))
                Me.existe = True
            End If
            dr.Close()

        End Sub


        Sub New(ByVal clavePrincipalMail As String)
            Dim queryString As String = "SELECT * FROM Suscripciones WHERE email=@email"
            Dim parametros As SqlParameter() = {New SqlParameter("@email", clavePrincipalMail)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idSuscripcion = CInt(dr("idSuscripcion"))
                Me.email = dr("email")
                Me.enviarmail = CBool(dr("enviarmail"))
                Me.fecha = CDate(dr("fecha"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Suscripciones (email, enviarmail, fecha) " _
            & "VALUES (@email, @enviarmail, @fecha)"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@email", Me.email), _
             New SqlParameter("@enviarmail", Me.enviarmail), _
             New SqlParameter("@fecha", Me.fecha)}

            Me.idSuscripcion = Me.ExecuteNonQuery(queryString, parametros, True)
            Me.existe = True
            Return 1
        End Function

      
        Public Function Update() As Integer
            Dim querystring As String = "update suscripciones email=@email, enviarmail=@enviarmail, fecha=@fecha where idSuscripcion=@idSuscripcion"
            Dim parametros As SqlParameter() = { _
           New SqlParameter("@email", Me.email), _
           New SqlParameter("@enviarmail", Me.enviarmail), _
           New SqlParameter("@fecha", Me.fecha), _
           New SqlParameter("@idSuscripcion", Me.idSuscripcion)}

            Me.ExecuteNonQuery(querystring, parametros, True)


        End Function

        Public Function GetDS() As DataSet
            Dim querystring As String = "select * from Suscripciones"
            Return Me.ExecuteDataSet(querystring, Nothing)
        End Function


    End Class
End Namespace
