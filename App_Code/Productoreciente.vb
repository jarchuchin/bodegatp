Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

	Public Class Productoreciente
		Inherits DBObject

		Public idUserProfile As Integer
		Public idProducto As Integer
		Public fecha As DateTime
		Public link As String
		Public nombre As String
        Public imagen As String
        Public clave As String
        Public precio As Decimal


		Public existe As Boolean = False

		Private Const maxItemsSaved As Integer = 10

		Public Shared ReadOnly Property maxRecientesSaved As Integer
			Get
				Return maxItemsSaved
			End Get
		End Property

		Sub New()
		End Sub

		Public Sub New(claveUsuario As Integer, claveProducto As Integer)
            Dim queryString As String = "SELECT pr.*, p.clave, isnull((select top 1 pp.precio from precios pp where pp.idEntidad=pr.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio FROM Productosrecientes pr left outer join Productos p on p.idproducto=pr.idproducto WHERE pr.idUserProfile=@idUserProfile AND pr.idProducto=@idProducto"
			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario), New SqlParameter("@idProducto", claveProducto)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
			If dr.Read Then
				Me.idUserProfile = dr("idUserProfile")
				Me.idProducto = dr("idProducto")
				Me.fecha = dr("fecha")
				Me.link = ""
                Me.nombre = ""
                Me.precio = CDec(dr("precio"))
                Me.clave = dr("clave")
				Me.existe = True
			End If
			dr.Close()
		End Sub

		Public Function add() As Integer
			Dim queryString As String = "INSERT INTO Productosrecientes (idUserProfile, idProducto, fecha) VALUES (@idUserProfile, @idProducto, @fecha)"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idUserProfile", Me.idUserProfile), _
			 New SqlParameter("@idProducto", Me.idProducto), _
			 New SqlParameter("@fecha", Me.fecha)}

			Me.idUserProfile = Me.ExecuteNonQuery(queryString, parametros, True)
			Me.existe = True

			Return 1
		End Function

		Public Function update() As Integer
			Dim queryString As String = "UPDATE Productosrecientes SET fecha=@fecha WHERE idUserProfile=@idUserProfile AND idProducto=@idProducto"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idUserProfile", Me.idUserProfile), _
			 New SqlParameter("@idProducto", Me.idProducto), _
			 New SqlParameter("@fecha", Me.fecha)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Function remove() As Integer
			Dim queryString As String = "DELETE FROM Productosrecientes WHERE idUserProfile=@idUserProfile AND idProducto=@idProducto"
			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", Me.idUserProfile), New SqlParameter("@idProducto", Me.idProducto)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Function removeOld(claveUsuario As Integer, fechaUltimoItem As Date) As Integer
			Dim queryString As String = "DELETE FROM Productosrecientes WHERE idUserProfile=@idUserProfile AND fecha<@fecha"
			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario), New SqlParameter("@fecha", fechaUltimoItem)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Function removeAll(claveUsuario As Integer) As Integer
			Dim queryString As String = "DELETE FROM Productosrecientes WHERE idUserProfile=@idUserProfile"
			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUsuario)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Function getListaRecientes(ByVal claveIdioma As Integer, ByVal claveUsuario As Integer) As List(Of Productoreciente)
			Dim lista As New List(Of Productoreciente)
			Dim counter As Integer = 0

			Dim dr As SqlDataReader = Me.getDR(claveIdioma, claveUsuario)

            Do While dr.Read And counter < maxItemsSaved
                Dim objProductoreciente As New Productoreciente
                With objProductoreciente
                    .idProducto = dr("idProducto")
                    .fecha = dr("fecha")
                    .link = "~/Productos/show/" & .idProducto & "/" & getTags(dr("tags"), dr("nombre"), dr("clave"))
                    .nombre = getNombre(dr("nombre"))
                    .imagen = getNombre(dr("imagen"))
                    .precio = CDec(dr("precio"))
                    .clave = dr("clave")
                End With

                lista.Add(objProductoreciente)

                counter += 1
            Loop
            dr.Close()

            Return lista
		End Function

		Private Function getDR(ByVal claveIdioma As Integer, ByVal claveUsuario As Integer) As SqlDataReader
            Dim queryString As String = "SELECT p.idProducto, p.clave, pi.nombre, pi.tags, pr.fecha, ISNULL ((SELECT TOP (1) imagen FROM ProductosFotos AS pf WHERE (idProducto = p.idProducto) AND (principal = 1)), 'default.jpg') AS imagen, isnull((select top 1 pp.precio from precios pp where pp.idEntidad=p.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio FROM Productos AS p INNER JOIN ProductosIdiomas AS pi ON p.idProducto = pi.idProducto AND pi.idIdioma = @ididioma INNER JOIN Productosrecientes AS pr ON p.idProducto = pr.idProducto AND pr.idUserProfile = @idUserProfile WHERE (p.eliminado = 0) ORDER BY pr.fecha DESC"
			Dim parametros As SqlParameter() = {New SqlParameter("@ididioma", claveIdioma), New SqlParameter("@idUserProfile", claveUsuario)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

		Private Function getProducto(ByVal claveIdioma As Integer, ByVal claveUsuario As Integer, claveProducto As Integer) As Productoreciente
            Dim queryString As String = "SELECT p.idProducto, p.clave, pi.nombre, pi.tags, pr.fecha, ISNULL ((SELECT TOP (1) imagen FROM ProductosFotos AS pf WHERE (idProducto = p.idProducto) AND (principal = 1)), 'default.jpg') AS imagen, isnull((select top 1 pp.precio from precios pp where pp.idEntidad=p.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio FROM Productos AS p INNER JOIN ProductosIdiomas AS pi ON p.idProducto = pi.idProducto AND pi.idIdioma = @ididioma LEFT OUTER JOIN Productosrecientes AS pr ON p.idProducto = pr.idProducto AND pr.idUserProfile = @idUserProfile WHERE (p.eliminado = 0) AND (p.idProducto = @idProducto)"

			Dim parametros As SqlParameter() = { _
				New SqlParameter("@ididioma", claveIdioma), _
				New SqlParameter("@idUserProfile", claveUsuario), _
				New SqlParameter("@idProducto", claveProducto)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)

			Dim objProducto As New Productoreciente
			If dr.Read Then
				With objProducto
					.idUserProfile = claveUsuario
					.idProducto = claveProducto
					.link = "~/Productos/show/" & .idProducto & "/" & getTags(dr("tags"), dr("nombre"), dr("clave"))
					.nombre = getNombre(dr("nombre"))
					.imagen = getNombre(dr("imagen"))
                    .precio = CDec(dr("precio"))
                    .clave = dr("clave")

					If IsDBNull(dr("fecha")) Then
						.fecha = Now
						.existe = False
					Else
						.fecha = dr("fecha")
						.existe = True
					End If

				End With
			End If
			dr.Close()

			Return objProducto
		End Function

		Private Shared Function getTags(ByVal clavetags As String, ByVal clavenombre As String, ByVal claveProducto As String) As String
			Dim myutils As New tienda.Utils
			clavenombre = myutils.depuraTags(clavenombre)
			Dim cadena As String = clavetags.Replace(",", " ")
			cadena = cadena.Replace(" ", "-")
			If cadena <> "" Then
				cadena &= "-" & clavenombre.Replace(" ", "-")
			Else
				cadena &= clavenombre.Replace(" ", "-")
			End If

			If cadena <> "" Then
				If claveProducto.Length > 3 Then
					cadena &= "-" & claveProducto.Substring(3)
				Else
					cadena &= "-" & claveProducto
				End If
			Else
				If claveProducto.Length > 3 Then
					cadena &= claveProducto.Substring(3)
				Else
					cadena &= claveProducto
				End If
			End If

			Return cadena.ToLower
		End Function

		Private Shared Function getNombre(ByVal claveNombre As String, Optional ByVal reducir As Boolean = True) As String
			Dim regresoName As String
			If reducir Then
				If claveNombre.Length > 925 Then
					regresoName = claveNombre.Substring(0, 25).ToLower & "..."
				Else
					regresoName = claveNombre.ToLower
				End If
			Else
				regresoName = claveNombre.ToLower
			End If


			Return Char.ToUpper(regresoName(0)) & regresoName.Substring(1)
		End Function

		Public Sub updateLista(ByRef listaActual As List(Of Productoreciente), ByVal claveIdioma As Integer, ByVal claveUsuario As Integer, claveProducto As Integer)
			Dim index As Integer = 0

			'se busca el idProducto en la lista; si se encuentra se elimina porque se reinsertará al tope con la fecha actualizada
			For Each item As Productoreciente In listaActual
				If item.idProducto = claveProducto Then
					listaActual.RemoveAt(index)
					Exit For
				End If

				index += 1
			Next

			'se recuperan los datos del producto que se insertará en la lista
			Dim objNuevoReciente As Productoreciente = Me.getProducto(claveIdioma, claveUsuario, claveProducto)

			If claveUsuario > 0 Then
				'si hay Usuario entonces se pueden grabar los datos en la DB; de lo contrario, solo quedan en sesión
				If objNuevoReciente.existe Then
					objNuevoReciente.fecha = Now
					objNuevoReciente.update()
				Else
					objNuevoReciente.add()
				End If
			End If

			listaActual.Insert(0, objNuevoReciente)

			If listaActual.Count > maxItemsSaved Then
				Dim itemsSobrantes As Integer = listaActual.Count - maxItemsSaved
				listaActual.RemoveRange(10, itemsSobrantes)
			End If

		End Sub

		Public Function mergeListasProductos(ByVal claveIdioma As Integer, ByVal claveUsuario As Integer, listaEnSesion As List(Of Productoreciente)) As List(Of Productoreciente)
			Dim listaDB As List(Of Productoreciente) = getListaRecientes(claveIdioma, claveUsuario)
			Dim nuevaLista As New List(Of Productoreciente)

			'se comparan ambos arreglos para eliminar idProducto repetidos, dejando en cada caso el de fecha más reciente
			For Each itemSesion As Productoreciente In listaEnSesion

				For Each itemDB As Productoreciente In listaDB

					If itemSesion.idProducto = itemDB.idProducto Then
						If itemSesion.fecha.CompareTo(itemDB.fecha) >= 0 Then
							'itemSesion es más reciente por lo que se elimina el de la db
							listaDB.Remove(itemDB)
						Else
							'itemSesion es más antiguo, así que se elimina
							listaEnSesion.Remove(itemSesion)
						End If
						Exit For
					End If

				Next
			Next

			If listaEnSesion.Count = 0 Then
				If listaDB.Count > 0 Then Return listaDB
				Return nuevaLista
			Else
				If listaDB.Count = 0 Then
					Me.removeAll(idUserProfile)
					For Each item As Productoreciente In listaEnSesion
						Dim objNuevoItem As New Productoreciente
						With objNuevoItem
							.idUserProfile = claveUsuario
							.idProducto = item.idProducto
							.fecha = item.fecha
							.link = item.link
							.nombre = item.nombre
                            .imagen = item.imagen
                            .precio = item.precio
                            .clave = item.clave
							.add()
						End With
						nuevaLista.Add(objNuevoItem)
					Next

					Return nuevaLista
				End If
			End If

			'ahora vuelven a compararse pero para pasar los más recientes al nuevo arreglo
			For Each itemSesion As Productoreciente In listaEnSesion
				If nuevaLista.Count >= maxItemsSaved Then Exit For

				For Each itemDB As Productoreciente In listaDB
					If nuevaLista.Count >= maxItemsSaved Then Exit For

					If itemSesion.fecha.CompareTo(itemDB.fecha) >= 0 Then
						'itemSesion es más reciente por lo que se agrega a la nueva lista
						Dim objNuevoItem As New Productoreciente
						With objNuevoItem
							.idUserProfile = claveUsuario
							.idProducto = itemSesion.idProducto
							.fecha = itemSesion.fecha
							.link = itemSesion.link
							.nombre = itemSesion.nombre
                            .imagen = itemSesion.imagen
                            .precio = itemSesion.precio
                            .clave = itemSesion.clave
							.add()
						End With

						nuevaLista.Add(objNuevoItem)
						Exit For
					Else
						nuevaLista.Add(itemDB)
						listaDB.Remove(itemDB)
					End If

				Next
			Next

			'se eliminan de la db los anteriores al último de la nueva lista
			Me.removeOld(claveUsuario, nuevaLista.Item(nuevaLista.Count - 1).fecha)


			Return nuevaLista
		End Function

		Public Shared Function getDataView(lista As List(Of tienda.Productoreciente)) As DataView
			Dim tabla As New DataTable
			Dim row As DataRow

			tabla.Columns.Add(New DataColumn("idUserProfile", GetType(Integer)))
			tabla.Columns.Add(New DataColumn("idProducto", GetType(Integer)))
			tabla.Columns.Add(New DataColumn("fecha", GetType(Date)))
			tabla.Columns.Add(New DataColumn("link", GetType(String)))
			tabla.Columns.Add(New DataColumn("nombre", GetType(String)))
            tabla.Columns.Add(New DataColumn("imagen", GetType(String)))
            tabla.Columns.Add(New DataColumn("precio", GetType(Decimal)))
            tabla.Columns.Add(New DataColumn("clave", GetType(String)))

			For Each item As Productoreciente In lista
				If item.idProducto > 0 Then
					row = tabla.NewRow
					row(0) = item.idUserProfile
					row(1) = item.idProducto
					row(2) = item.fecha
					row(3) = item.link
					row(4) = item.nombre
                    row(5) = item.imagen
                    row(6) = item.precio
                    row(7) = item.clave
					tabla.Rows.Add(row)
				End If
			Next

			Return New DataView(tabla)
		End Function

	End Class

End Namespace
