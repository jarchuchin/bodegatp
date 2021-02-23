


Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class Localizacion
        Inherits DBObject

        Public idLocalizacion As Integer
        Public IP As String
        Public sessionID As String
        Public Region As String
        Public Ciudad As String
        Public Fecha As DateTime
        Public existe As Boolean = False

        Sub New()
        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from Localizaciones where idLocalizacion=@idLocalizacion"
            Dim params As SqlParameter() = {New SqlParameter("@idLocalizacion", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idLocalizacion = CInt(dr("idLocalizacion"))
                Me.IP = dr("IP")
                Me.sessionID = dr("sessionID")
                Me.Region = dr("Region")
                Me.Ciudad = dr("Ciudad")
                Me.Fecha = CType(dr("Fecha"), DateTime)
                Me.existe = True
            End If
            dr.Close()

        End Sub

   

        Public Function Add() As Integer
            Dim sql As String = "INSERT INTO Localizaciones ( IP, SessionID, Region, Ciudad, Fecha) VALUES (@IP, " _
             & "@SessionID, @Region, @Ciudad, @Fecha)"


            If Me.Region.Length > 100 Then
                Me.Region = Me.Region.Substring(0, 100)
            End If

            If Me.Ciudad.Length > 100 Then
                Me.Ciudad = Me.Region.Substring(0, 100)
            End If

            Dim params As SqlParameter() = { _
             New SqlParameter("@IP", Me.IP), _
             New SqlParameter("@SessionID", Me.sessionID), _
             New SqlParameter("@Region", Me.Region), _
             New SqlParameter("@Ciudad", Me.Ciudad), _
             New SqlParameter("@Fecha", Me.Fecha)}

            Me.idLocalizacion = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1
        End Function

        Protected Function Update() As Integer

            Return 0
        End Function

        
    End Class

End Namespace
