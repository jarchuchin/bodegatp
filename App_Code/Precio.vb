Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Math


Namespace tienda

    Public Class Precio
        Inherits DBObject

        Public idPrecio As Integer
        Public idEntidad As Integer
        Public entidad As TipoEntidad
        Public precio As Decimal
        Public escala As Integer
        Public numero As Byte
        Public existe As Boolean = False

        Sub New()
        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from Precios where idPrecio=@idPrecio"
            Dim params As SqlParameter() = {New SqlParameter("@idPrecio", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idPrecio = CInt(dr("idPrecio"))
                Me.idEntidad = CInt(dr("idEntidad"))
                Me.entidad = CType([Enum].Parse(GetType(TipoEntidad), dr("entidad")), TipoEntidad)
                Me.precio = Round(CDec(dr("precio")), 2)
                Me.escala = CInt(dr("escala"))
                Me.numero = CInt(dr("numero"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad, ByVal numeroOrden As Byte)
            Dim sql As String = "SELECT * FROM Precios WHERE idEntidad=@idEntidad AND entidad = @entidad AND numero = @numero"
            Dim params As SqlParameter() = { _
             New SqlParameter("@idEntidad", claveEntidad), _
             New SqlParameter("@entidad", tipoDeEntidad.ToString), _
             New SqlParameter("@numero", numeroOrden)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idPrecio = CInt(dr("idPrecio"))
                Me.idEntidad = CInt(dr("idEntidad"))
                Me.entidad = CType([Enum].Parse(GetType(TipoEntidad), dr("entidad")), TipoEntidad)
                Me.precio = Round(CDec(dr("precio")), 2)
                Me.escala = CInt(dr("escala"))
                Me.numero = CInt(dr("numero"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim sql As String = "INSERT INTO Precios (idEntidad, entidad, precio, escala, numero) values (@idEntidad, @entidad, @precio, @escala, @numero)"

            Dim params As SqlParameter() = { _
            New SqlParameter("@idEntidad", Me.idEntidad), _
            New SqlParameter("@entidad", Me.entidad.ToString), _
            New SqlParameter("@precio", Round(Me.precio, 2)), _
            New SqlParameter("@escala", Me.escala), _
            New SqlParameter("@numero", Me.numero)}

            Me.idPrecio = Me.ExecuteNonQuery(sql, params, True)

            Me.existe = True
            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update Precios set idEntidad=@idEntidad, precio=@precio, escala=@escala where idPrecio=@idPrecio"
            Dim params As SqlParameter() = { _
            New SqlParameter("@idPrecio", Me.idPrecio), _
            New SqlParameter("@precio", Round(Me.precio, 2)), _
            New SqlParameter("@escala", Me.escala), _
            New SqlParameter("@numero", Me.numero)}

            Return Me.ExecuteNonQuery(sql, params)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Precios where idPrecio=@idPrecio"
            Dim params As SqlParameter() = { _
             New SqlParameter("@idPrecio", idPrecio)}

            Return Me.ExecuteNonQuery(sql, params)

        End Function

        Public Function Remove(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad) As Integer
            Dim sql As String = "DELETE Precios WHERE idEntidad=@idEntidad AND entidad=@entidad"
            Dim params As SqlParameter() = {New SqlParameter("@idEntidad", claveEntidad), New SqlParameter("@entidad", tipoDeEntidad.ToString)}

            Return Me.ExecuteNonQuery(sql, params)
        End Function

        Public Function GetDS(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad) As DataSet
            Dim sql As String = "SELECT * FROM Precios WHERE idEntidad=@idEntidad AND entidad=@entidad ORDER BY escala ASC"
            Dim params As SqlParameter() = {New SqlParameter("@idEntidad", claveEntidad), New SqlParameter("@entidad", tipoDeEntidad.ToString)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetDR(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad) As SqlDataReader
            Dim sql As String = "SELECT * FROM Precios WHERE idEntidad=@idEntidad AND entidad=@entidad ORDER BY escala ASC"
            Dim params As SqlParameter() = {New SqlParameter("@idEntidad", claveEntidad), New SqlParameter("@entidad", tipoDeEntidad.ToString)}
            Return Me.ExecuteReader(sql, params)

        End Function

        Public Function GetDView(ByVal claveEntidad As Integer, ByVal tipoDeEntidad As TipoEntidad, ByVal numMinimoItems As Integer) As DataView
            Dim dTabla As New DataTable
            Dim dRow As DataRow
            Dim contador As Integer = 1

            dTabla.Columns.Add(New DataColumn("idPrecio", GetType(Integer)))
            dTabla.Columns.Add(New DataColumn("precio", GetType(String)))
            dTabla.Columns.Add(New DataColumn("escala", GetType(String)))
            dTabla.Columns.Add(New DataColumn("numero", GetType(Integer)))

            Dim dr As SqlDataReader = Me.GetDR(claveEntidad, tipoDeEntidad)
            Do While dr.Read

                dRow = dTabla.NewRow
                dRow(0) = dr("idPrecio")
                dRow(1) = Round(CDec(dr("precio")), 2)
                dRow(2) = dr("escala")
                dRow(3) = contador
                dTabla.Rows.Add(dRow)

                contador += 1
            Loop
            dr.Close()

            If contador < numMinimoItems Then
                For i As Integer = contador To numMinimoItems
                    dRow = dTabla.NewRow
                    dRow(0) = 0
                    dRow(1) = String.Empty
                    dRow(2) = String.Empty
                    dRow(3) = i
                    dTabla.Rows.Add(dRow)
                Next
            End If

            Return New DataView(dTabla)
        End Function

        Public Function GetPrecioUnitario(ByVal claveEntidad As Integer, ByVal tipo As TipoEntidad, ByVal cantidadProductos As Integer) As Decimal
            'Dim queryString As String = "SELECT TOP (1) precio FROM Precios WHERE idEntidad = @idEntidad AND entidad = @entidad AND escala >= @escala"

            'Dim parametros As SqlParameter() = { _
            ' New SqlParameter("@idEntidad", claveEntidad), _
            ' New SqlParameter("@entidad", tipo.ToString), _
            ' New SqlParameter("@escala", cantidadProductos)}

            'Dim precioUnitario As Decimal
            'Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            'If dr.Read Then
            '    If Not IsDBNull(dr("precio")) Then
            '        precioUnitario = CDec(dr("precio"))
            '    End If

            'End If
            'dr.Close()

            'Return precioUnitario

            Dim queryString As String = "SELECT p.* FROM Precios p WHERE p.idEntidad = @idEntidad AND p.entidad = @entidad  order by escala asc"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idEntidad", claveEntidad), _
             New SqlParameter("@entidad", tipo.ToString), _
             New SqlParameter("@escala", cantidadProductos)}

            Dim precioUnitario As Decimal = 0
            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            Dim entro As Boolean = False
            Do While dr.Read
                If Not entro Then
                    precioUnitario = Round(CDec(dr("precio")), 2)
                    entro = True
                End If
                If CInt(dr("escala")) <= cantidadProductos Then
                    precioUnitario = Round(CDec(dr("precio")), 2)

                End If
              
            Loop

            dr.Close()

            Return precioUnitario
        End Function


        Public Function GetDSDetailsPreciosNested(ByVal claveproducto As Integer) As DataSet
            Dim ds As New DataSet
            Dim queryString As String




            queryString = "SELECT pp.idPrecio, pp.idEntidad AS idProducto, pp.numero, ISNULL(aux.escala + 1, 1) AS desde, pp.escala AS hasta, pp.precio " _
             & "FROM Productos AS p INNER JOIN Precios AS pp ON p.idProducto = pp.idEntidad AND pp.entidad = 'Producto' LEFT OUTER JOIN " _
             & "	(SELECT idEntidad, escala, numero FROM Precios AS pp2 WHERE entidad = 'Producto') AS aux ON pp.idEntidad = aux.idEntidad " _
             & "AND aux.numero = pp.numero - 1 WHERE p.eliminado = 0 and p.idproducto=@idproducto ORDER BY idProducto, pp.numero"

            Dim params As SqlParameter() = {New SqlParameter("@idproducto", claveproducto)}
            Return Me.ExecuteDataSet(queryString, params)

        End Function

        '============================  2010 ==========================
        Public Function GetDRPreciosYEscalas(ByVal claveProducto As Integer) As SqlDataReader
            Dim queryString As String = "SELECT pp.numero, ISNULL(aux.escala + 1, 1) AS desde, pp.escala AS hasta, pp.precio FROM Productos AS p INNER JOIN " _
             & "Precios AS pp ON p.idProducto = pp.idEntidad AND pp.entidad = 'Producto' LEFT OUTER JOIN (SELECT idEntidad, escala, numero FROM Precios AS pp2 " _
             & "WHERE entidad = 'Producto') AS aux ON pp.idEntidad = aux.idEntidad AND aux.numero = pp.numero - 1 WHERE p.eliminado = 0 AND p.idProducto = @idProducto " _
             & "ORDER BY pp.numero"

            Dim parametros As SqlParameter() = {New SqlParameter("@idProducto", claveProducto)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function TablaDePrecios(ByVal claveproducto As Integer) As DataTable
            Dim objDT As System.Data.DataTable
            Dim objDR As System.Data.DataRow

            objDT = New System.Data.DataTable("EscalasPrecios")
            objDT.Columns.Add("desde", GetType(String))
            objDT.Columns.Add("hasta", GetType(String))
            objDT.Columns.Add("precio", GetType(String))

            Dim ds As DataSet = Me.GetDS(claveproducto, TipoEntidad.Producto)
            Dim myp As New Producto(claveproducto)
            Dim ventaminima As Integer
            If myp.ventaMinima > 0 Then
                ventaminima = myp.ventaMinima
            Else
                ventaminima = 1
            End If

            For i = 0 To ds.Tables(0).Rows.Count - 1
                objDR = objDT.NewRow
                objDR("desde") = ds.Tables(0).Rows(i).Item("escala")
                If i + 1 <= ds.Tables(0).Rows.Count - 1 Then
                    objDR("hasta") = CInt(ds.Tables(0).Rows(i + 1).Item("escala")) - 1
                End If
                objDR("Precio") = String.Format("{0:C}", Round(CType(ds.Tables(0).Rows(i).Item("Precio"), Decimal), 2))
                objDT.Rows.Add(objDR)

            Next


            ds = Nothing

            Return objDT
		End Function

        Public Function TablaDePrecios2(ByVal claveproducto As Integer) As DataTable
            Dim objDT As System.Data.DataTable
            Dim objDR As System.Data.DataRow

            objDT = New System.Data.DataTable("EscalasPrecios")
            objDT.Columns.Add("tipo", GetType(String))
            


            Dim ds As DataSet = Me.GetDS(claveproducto, TipoEntidad.Producto)
            Dim myp As New Producto(claveproducto)
            Dim ventaminima As Integer
            If myp.ventaMinima > 0 Then
                ventaminima = myp.ventaMinima
            Else
                ventaminima = 1
            End If

            For i = 0 To ds.Tables(0).Rows.Count - 1
                objDT.Columns.Add("escalaprecio" & i, GetType(String))
            Next
            objDR = objDT.NewRow
            objDR("tipo") = "Escalas:"
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If i + 1 <= ds.Tables(0).Rows.Count - 1 Then
                    objDR("escalaprecio" & i) = ds.Tables(0).Rows(i).Item("escala") & " a " & CInt(ds.Tables(0).Rows(i + 1).Item("escala")) - 1
                Else
                    objDR("escalaprecio" & i) = ds.Tables(0).Rows(i).Item("escala") & " o más"
                End If

            Next
            objDT.Rows.Add(objDR)

            objDR = objDT.NewRow
            objDR("tipo") = "Precio:"
            For i = 0 To ds.Tables(0).Rows.Count - 1
                objDR("escalaprecio" & i) = String.Format("{0:C}", Round(CType(ds.Tables(0).Rows(i).Item("Precio"), Decimal), 2))
            Next
            objDT.Rows.Add(objDR)

            ds = Nothing

            Return objDT
        End Function

		'hecha por FAMG por diseño de Moisés
		Public Function TablaDePrecios3(ByVal claveproducto As Integer) As DataTable
			Dim tabla As New DataTable
			Dim dRow As DataRow

			tabla.Columns.Add("escala", GetType(String))
			tabla.Columns.Add("precio", GetType(String))

			Dim ds As DataSet = Me.GetDS(claveproducto, TipoEntidad.Producto)
			Dim inferior As String = ""
			Dim superior As String = ""

			For i = 0 To ds.Tables(0).Rows.Count - 1
				inferior = CInt(ds.Tables(0).Rows(i).Item("escala")).ToString
				If i + 1 <= ds.Tables(0).Rows.Count - 1 Then
					superior = " a " & (CInt(ds.Tables(0).Rows(i + 1).Item("escala")) - 1).ToString
				Else
					superior = " o más"
				End If

				Dim pr As Decimal = CDec(ds.Tables(0).Rows(i).Item("Precio"))
				dRow = tabla.NewRow
				dRow(0) = inferior & superior
				dRow(1) = pr.ToString("c")
				tabla.Rows.Add(dRow)
			Next

			Return tabla
		End Function

	End Class
End Namespace
