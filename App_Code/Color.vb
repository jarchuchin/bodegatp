Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace tienda
	Public Class Color
		Inherits DBObject

		Public idColor As Integer
		Public idCodigocolor As Integer
		Public idEntidad As Integer
		Public entidad As TipoEntidad
		Public numero As Byte
		Public imagen As String
		Public existe As Boolean = False

		Sub New()
		End Sub

		Sub New(ByVal clavePrincipal As Integer)
			Dim queryString As String = "SELECT* FROM Colores WHERE idColor=@idColor"
			Dim parametros As SqlParameter() = {New SqlParameter("@idColor", clavePrincipal)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
			If dr.Read Then
				Me.idColor = CInt(dr("idColor"))
				Me.idCodigocolor = CInt(dr("idCodigocolor"))
				Me.idEntidad = CInt(dr("idEntidad"))
				Me.entidad = CType([Enum].Parse(GetType(TipoEntidad), dr("tipoEntidad").ToString), TipoEntidad)
				Me.numero = CByte(dr("numero"))
				Me.imagen = dr("imagen")
				Me.existe = True
			End If
			dr.Close()

		End Sub



		Sub New(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad, ByVal nombreWeb As String)
			Dim queryString As String = "SELECT * FROM Colores AS c INNER JOIN Codigoscolores AS cc ON c.idCodigocolor = cc.idCodigocolor " _
			 & "AND c.idEntidad = @idEntidad AND c.tipoEntidad = @tipoEntidad AND cc.nombreWeb = @nombreWeb"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idEntidad", claveEntidad), _
			 New SqlParameter("@tipoEntidad", tipoDeEntidad.ToString), _
			 New SqlParameter("@nombreWeb", nombreWeb)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
			If dr.Read Then
				Me.idColor = CInt(dr("idColor"))
				Me.idCodigocolor = CInt(dr("idCodigocolor"))
				Me.idEntidad = CInt(dr("idEntidad"))
				Me.entidad = CType([Enum].Parse(GetType(TipoEntidad), CType(dr("tipoEntidad"), String)), TipoEntidad)
				Me.numero = CByte(dr("numero"))
				Me.imagen = dr("imagen")
				Me.existe = True
			End If
			dr.Close()

		End Sub

		Public Function Add() As Integer
			Dim queryString As String = "INSERT INTO Colores (idCodigocolor, idEntidad, tipoEntidad, numero, imagen) " _
			& "VALUES (@idCodigocolor, @idEntidad, @tipoEntidad, @numero, @imagen)"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idCodigocolor", Me.idCodigocolor), _
			 New SqlParameter("@idEntidad", Me.idEntidad), _
			 New SqlParameter("@tipoEntidad", Me.entidad.ToString), _
			 New SqlParameter("@numero", Me.numero), _
			 New SqlParameter("@imagen", Me.imagen)}

			Me.idColor = Me.ExecuteNonQuery(queryString, parametros, True)
			Me.existe = True
			Return 1
		End Function

		Public Function Remove() As Integer
			Dim queryString As String = "DELETE FROM Colores WHERE idColor = @idColor"

			Dim parametros As SqlParameter() = {New SqlParameter("@idColor", Me.idColor)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Function Remove(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad) As Integer
			Dim queryString As String = "DELETE FROM Colores WHERE idEntidad = @idEntidad AND tipoEntidad = @tipoEntidad"

			Dim parametros As SqlParameter() = { _
			New SqlParameter("@idEntidad", claveEntidad), _
			New SqlParameter("@tipoEntidad", tipoDeEntidad.ToString)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Function GetDR(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad, ByVal claveIdioma As Integer) As SqlDataReader
			Dim columnaIdioma As String = "idioma" & claveIdioma
			If claveIdioma > 3 Then columnaIdioma = "idioma1"

			Dim queryStrng As String = "SELECT c.idColor, c.idCodigocolor, c.numero, c.imagen, cc.nombreWeb, cc.codigoHexadecimal, cc." & columnaIdioma & " AS color " _
			 & "FROM Colores AS c INNER JOIN Codigoscolores AS cc ON c.idCodigocolor = cc.idCodigocolor AND c.idEntidad = @idEntidad " _
			 & "AND c.tipoEntidad = @tipoEntidad ORDER BY c.numero"

			Dim params As SqlParameter() = { _
			 New SqlParameter("@idEntidad", claveEntidad), _
			 New SqlParameter("@tipoEntidad", tipoDeEntidad.ToString), _
			 New SqlParameter("idIdioma", claveIdioma)}

			Return Me.ExecuteReader(queryStrng, params)
		End Function

		Public Function GetDView(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad, ByVal claveIdioma As Integer, ByVal numMinimoItems As Integer) As DataView
			Dim dTabla As New DataTable
			Dim dRow As DataRow
			Dim contador As Integer = 1

			dTabla.Columns.Add(New DataColumn("idColor", GetType(Integer)))
			dTabla.Columns.Add(New DataColumn("idCodigocolor", GetType(Integer)))
			dTabla.Columns.Add(New DataColumn("color", GetType(String)))
			dTabla.Columns.Add(New DataColumn("numero", GetType(Integer)))

			If claveEntidad > 0 Then
				Dim dr As SqlDataReader = Me.GetDR(claveEntidad, tipoDeEntidad, claveIdioma)
				Do While dr.Read

					dRow = dTabla.NewRow
					dRow(0) = dr("idColor")
					dRow(1) = dr("idCodigocolor")
					dRow(2) = dr("color")
					dRow(3) = contador
					dTabla.Rows.Add(dRow)

					contador += 1
				Loop
				dr.Close()
			End If

			If contador < numMinimoItems Then
				For i As Integer = contador To numMinimoItems
					dRow = dTabla.NewRow
					dRow(0) = 0
					dRow(1) = 0
					dRow(2) = String.Empty
					dRow(3) = i
					dTabla.Rows.Add(dRow)
				Next
			End If

			Return New DataView(dTabla)
        End Function

        '========================== 2010 =========================
        Public Function GetProductosColoresNotInOrden(ByVal claveOrden As Integer, ByVal claveProducto As Integer, ByVal claveIdioma As Integer) As SqlDataReader
            Dim columnaIdioma As String = "idioma" & claveIdioma
            If claveIdioma > 3 Then columnaIdioma = "idioma1"

            Dim queryStrng As String = "SELECT c.idEntidad AS idProducto, cc.codigoHexadecimal, cc." & columnaIdioma & " AS color FROM Colores AS c INNER JOIN Codigoscolores AS cc " _
             & "ON c.idCodigocolor = cc.idCodigocolor AND c.tipoEntidad = 'Producto' WHERE cc.codigoHexadecimal NOT IN (SELECT color AS codigohexadecimal " _
             & "FROM Ordenesdetalles WHERE idOrden = @idOrden AND idProducto = @idProducto) AND c.idEntidad = @idProducto ORDER BY color"

            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveProducto), New SqlParameter("@idOrden", claveOrden)}

            Return Me.ExecuteReader(queryStrng, params)
        End Function

        Public Function GetProductoColores(ByVal claveOrden As Integer, ByVal claveProducto As Integer, ByVal claveIdioma As Integer) As SqlDataReader
            Dim columnaIdioma As String = "idioma" & claveIdioma
            If claveIdioma > 3 Then columnaIdioma = "idioma1"

            Dim queryStrng As String = "SELECT 0 AS idOrdendetalle, p.idProducto, ISNULL(cc.codigoHexadecimal, '') AS codigoHexadecimal, ISNULL(cc." & columnaIdioma & ", '') AS color, " _
             & "0 as cantidad FROM Productos AS p LEFT OUTER JOIN Colores AS c ON c.idEntidad = p.idProducto AND c.tipoEntidad = 'Producto' LEFT OUTER JOIN Codigoscolores AS cc " _
             & "ON c.idCodigocolor = cc.idCodigocolor WHERE cc.codigoHexadecimal NOT IN (SELECT color AS codigohexadecimal FROM Ordenesdetalles WHERE idOrden = @idOrden " _
             & "AND idProducto = @idProducto) AND p.idProducto = @idProducto UNION SELECT od.idOrdendetalle, od.idProducto, od.color AS codigohexadecimal, cc.idioma1 AS color, " _
             & "cantidad FROM Ordenesdetalles AS od INNER JOIN Codigoscolores AS cc ON cc.codigoHexadecimal = od.color WHERE od.idOrden = @idOrden AND od.idProducto = @idProducto " _
             & "ORDER BY color"

            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveProducto), New SqlParameter("@idOrden", claveOrden)}

            Return Me.ExecuteReader(queryStrng, params)
        End Function



	End Class
End Namespace
