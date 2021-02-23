Imports System.Data.SqlClient
Imports System.Data

Namespace tienda
	Public Class Transaccion
		Inherits DBObject

#Region "Declaración de variables"
		Public idTransaccion As Integer
		Public idOrden As Integer
		Public idDeposito As Integer
		Public status As String
		Public AuthCode As String
		Public CcErrCode As Integer
		Public CcReturnMsg As String
		Public ProcReturnCode As String
		Public ProcReturnMsg As String
		Public Cvv2Resp As String
		Public TimeIn As DateTime
		Public TimeOut As DateTime
		Public MaxSev As Byte
		Public Text As String
		Public total As Decimal
		Public fechaTransaccion As DateTime
		Public esUltimoIntento As Boolean
		Public numeroIntento As Integer
		Public existe As Boolean = False
#End Region

#Region "Constructores"
		Sub New()
		End Sub

		Sub New(ByVal claveTransaccion As Integer)
			Dim queryString As String = "SELECT * FROM Transacciones WHERE idTransaccion=@idTransaccion"
			Dim parametros As SqlParameter() = {New SqlParameter("@idTransaccion", claveTransaccion)}
			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)

			fillVariables(dr)
		End Sub

		Sub New(claveOrden As Integer, devuelveUltimoIntento As Boolean)
			Dim queryString As String = "SELECT * FROM Transacciones WHERE idOrden=@idOrden"
			If devuelveUltimoIntento Then
				queryString &= " AND esUltimoIntento = 1"
			End If

			Dim parametros As SqlParameter() = {New SqlParameter("@idOrden", claveOrden)}
			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)

			fillVariables(dr)
		End Sub

		Private Sub fillVariables(dr As SqlDataReader)
			If dr.Read Then
				Me.idTransaccion = dr("idTransaccion")
				Me.idOrden = dr("idOrden")
				Me.idDeposito = dr("idDeposito")
				Me.status = dr("status")
				Me.AuthCode = dr("AuthCode")
				Me.CcErrCode = dr("CcErrCode")
				Me.CcReturnMsg = dr("CcReturnMsg")
				Me.ProcReturnCode = dr("ProcReturnCode")
				Me.ProcReturnMsg = dr("ProcReturnMsg")
				Me.Cvv2Resp = dr("Cvv2Resp")
				Me.TimeIn = dr("TimeIn")
				Me.TimeOut = dr("TimeOut")
				Me.MaxSev = dr("MaxSev")
				Me.Text = dr("Text")
				Me.total = dr("total")
				Me.fechaTransaccion = dr("fechaTransaccion")
				Me.esUltimoIntento = dr("esUltimoIntento")
				Me.numeroIntento = dr("numeroIntento")
				Me.existe = True
			End If
			dr.Close()

		End Sub
#End Region

		Public Function Add() As Integer
			Dim queryString As String = "INSERT INTO Transacciones (idOrden, idDeposito, status, AuthCode, CcErrCode, CcReturnMsg, " _
				& "ProcReturnCode, ProcReturnMsg, Cvv2Resp, TimeIn, TimeOut, MaxSev, Text, total, fechaTransaccion, esUltimoIntento, " _
				& "numeroIntento) VALUES (@idOrden, @idDeposito, @status, @AuthCode, @CcErrCode, @CcReturnMsg, @ProcReturnCode, @ProcReturnMsg, " _
				& "@Cvv2Resp, @TimeIn, @TimeOut, @MaxSev, @Text, @total, @fechaTransaccion, @esUltimoIntento, @numeroIntento)"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idOrden", Me.idOrden), _
			 New SqlParameter("@idDeposito", Me.idDeposito), _
			 New SqlParameter("@status", Me.status), _
			 New SqlParameter("@AuthCode", Me.AuthCode), _
			 New SqlParameter("@CcErrCode", Me.CcErrCode), _
			 New SqlParameter("@CcReturnMsg", Me.CcReturnMsg), _
			 New SqlParameter("@ProcReturnCode", Me.ProcReturnCode), _
			 New SqlParameter("@ProcReturnMsg", Me.ProcReturnMsg), _
			 New SqlParameter("@Cvv2Resp", Me.Cvv2Resp), _
			 New SqlParameter("@TimeIn", Me.TimeIn), _
			 New SqlParameter("@TimeOut", Me.TimeOut), _
			 New SqlParameter("@MaxSev", Me.MaxSev), _
			 New SqlParameter("@Text", Me.Text), _
			 New SqlParameter("@total", Me.total), _
			 New SqlParameter("@fechaTransaccion", Me.fechaTransaccion), _
			 New SqlParameter("@esUltimoIntento", Me.esUltimoIntento), _
			 New SqlParameter("@numeroIntento", Me.numeroIntento)}

			Me.idTransaccion = Me.ExecuteNonQuery(queryString, parametros, True)
			Me.existe = True
			Return 1
		End Function

		Public Function Update() As Integer
			Dim queryString As String = "UPDATE Transacciones SET idDeposito=@idDeposito, esUltimoIntento=@esUltimoIntento, " _
				& "numeroIntento=@numeroIntento WHERE idTransaccion=@idTransaccion"

			Dim parametros As SqlParameter() = { _
				New SqlParameter("@idTransaccion", idTransaccion), _
				New SqlParameter("@idDeposito", Me.idDeposito), _
				New SqlParameter("@esUltimoIntento", Me.esUltimoIntento), _
				New SqlParameter("@numeroIntento", Me.numeroIntento)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Function count(claveOrden As Integer) As Integer
			Dim queryString As String = "SELECT COUNT(*) as total FROM Transacciones WHERE idOrden = @idOrden"
			Dim parametros As SqlParameter() = {New SqlParameter("idOrden", claveOrden)}
			Dim total As Integer
			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)

			If dr.Read Then
				total = dr("total")
			End If
			dr.Close()

			Return total
		End Function
	End Class

End Namespace
