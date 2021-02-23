
Imports System.Data
Imports System.Data.SqlClient

Namespace tienda

	Public Class Deposito
		Inherits DBObject


		Public idDeposito As Integer
		Public idOrden As Integer
		Public Fecha As Date
		Public Factura As String
		Public Cliente As String
		Public Sucursal As String
		Public Referencia As String
		Public Monto As Decimal
		Public Eliminado As Boolean
		Public ValidadoPor As Integer
		Public TipoDeposito As String
		Public Estatus As String
		Public idComprobante As Integer = 0
		Public Observaciones As String = ""
		Public fechaRegistro As DateTime

		Public existe As Boolean = False

#Region "Constructores"
		Sub New()

		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim sql As String = "select * from depositos where idDeposito=@idDeposito"
			Dim params As SqlParameter() = {New SqlParameter("idDeposito", clavePrincipal)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

			fillDr(dr)
		End Sub

		Sub New(ByVal claveComprobante As Integer, buscarComprobante As Boolean)

			Dim sql As String = "select * from depositos where idComprobante=@idComprobante"
			Dim params As SqlParameter() = {New SqlParameter("idComprobante", claveComprobante)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

			fillDr(dr)
		End Sub

		Private Sub fillDr(dr As SqlDataReader)
			If dr.Read Then
				Me.idDeposito = CInt(dr("idDeposito"))
				Me.idOrden = CInt(dr("idOrden"))
				Me.Fecha = CDate(dr("Fecha"))
				Me.Factura = dr("Factura")
				Me.Cliente = dr("Cliente")
				Me.Sucursal = dr("Sucursal")
				Me.Referencia = dr("Referencia")
				Me.Monto = dr("Monto")
				Me.Eliminado = CBool(dr("eliminado"))
				If Convert.IsDBNull(dr("ValidadoPor")) Then
					Me.ValidadoPor = 0
				Else
					Me.ValidadoPor = CInt(dr("ValidadoPor"))
				End If
				If Convert.IsDBNull(dr("TipoDeposito")) Then
					Me.TipoDeposito = ""
				Else
					Me.TipoDeposito = dr("TipoDeposito")
				End If
				If Convert.IsDBNull(dr("Estatus")) Then
					Me.Estatus = ""
				Else
					Me.Estatus = dr("Estatus")
				End If
				If Convert.IsDBNull(dr("idComprobante")) Then
					Me.idComprobante = 0
				Else
					Me.idComprobante = CInt(dr("idComprobante"))
				End If
				If Not Convert.IsDBNull(dr("Observaciones")) Then
					Me.Observaciones = dr("Observaciones")
				End If

				If Not Convert.IsDBNull(dr("FechaRegistro")) Then
					Me.fechaRegistro = CType(dr("FechaRegistro"), DateTime)
				End If

				Me.existe = True
			End If
			dr.Close()
		End Sub
#End Region

		Public Function Add() As Integer
			Dim sql As String = "INSERT INTO Depositos (idOrden, Fecha, Factura, Cliente, Sucursal, Referencia, Monto, eliminado, " _
				& "ValidadoPor, TipoDeposito, Estatus, idComprobante, Observaciones, FechaRegistro) values (@idOrden, @Fecha, @Factura, " _
				& "@Cliente, @Sucursal, @Referencia, @Monto, @eliminado, @ValidadoPor, @TipoDeposito, @Estatus, @idComprobante, " _
				& "@Observaciones, @FechaRegistro)"

			Dim params As SqlParameter() = { _
				New SqlParameter("@idOrden", Me.idOrden), _
				New SqlParameter("@Fecha", Me.Fecha), _
				New SqlParameter("@Factura", Me.Factura), _
				New SqlParameter("@Cliente", Me.Cliente), _
				New SqlParameter("@Sucursal", Me.Sucursal), _
				New SqlParameter("@Referencia", Me.Referencia), _
				New SqlParameter("@Monto", Me.Monto), _
				New SqlParameter("@eliminado", Me.Eliminado), _
				New SqlParameter("@ValidadoPor", Me.ValidadoPor), _
				New SqlParameter("@TipoDeposito", Me.TipoDeposito), _
				New SqlParameter("@Estatus", Me.Estatus), _
				New SqlParameter("@idComprobante", Me.idComprobante), _
				New SqlParameter("@Observaciones", Me.Observaciones), _
				New SqlParameter("@FechaRegistro", Date.Now)}

			Me.idDeposito = Me.ExecuteNonQuery(sql, params, True)
			Me.existe = True

			Return 1
		End Function

        Public Function GetDSOrden(ByVal claveOrden As Integer) As DataSet
            Dim sql As String = "select d.*, o.proyectoentramiteclave from depositos d, ordenes o  where o.idOrden=d.idOrden and d.eliminado=0 and d.idOrden=@idOrden"
            Dim params As SqlParameter() = {
New SqlParameter("@idOrden", claveOrden)}
            Return Me.ExecuteDataSet(sql, params)


        End Function


        Public Function GetDepositosFacturables(ByVal claveOrden As Integer) As DataSet
            Dim sql As String = "select d.*, o.proyectoentramiteclave from depositos d, ordenes o  where o.idOrden=d.idOrden and d.eliminado=0 and d.idOrden=@idOrden and idComprobante=0"
            Dim params As SqlParameter() = {
New SqlParameter("@idOrden", claveOrden)}
            Return Me.ExecuteDataSet(sql, params)


        End Function

        Public Function GetTotalDepositos(ByVal claveOrden As Integer) As Decimal
			Dim sql As String = "select sum(d.monto) as num from depositos d  where d.eliminado=0 and d.idOrden=@idOrden"
			Dim params As SqlParameter() = { _
New SqlParameter("@idOrden", claveOrden)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
			Dim regreso As Decimal = 0
			If dr.Read Then
				If Not Convert.IsDBNull(dr("num")) Then
					regreso = CDec(dr("num"))
				End If
			End If
			dr.Close()

			Return regreso

		End Function

		Public Function getDepositoUnico(claveOrden As Integer) As Deposito
			Dim queryString As String = "SELECT TOP 1 * FROM Depositos WHERE idOrden=@idOrden AND eliminado = 0 ORDER BY idDeposito DESC"
			Dim parametros As SqlParameter() = {New SqlParameter("idOrden", claveOrden)}
			Dim claveDeposito As Integer
			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)

			If dr.Read Then
				claveDeposito = dr("idDeposito")
			End If
			dr.Close()

			If claveDeposito = 0 Then
				Return New Deposito
			Else
				Return New Deposito(claveDeposito)
			End If
		End Function
	End Class


End Namespace
