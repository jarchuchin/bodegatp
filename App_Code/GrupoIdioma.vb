Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

	Public Class GrupoIdioma
		Inherits Grupo

		Public idGrupoIdioma As Integer
		Public idIdioma As Integer
		Public nombre As String
		Public Shadows existe As Boolean = False

		Sub New()
		End Sub

		Sub New(ByVal claveidGrupo As Integer, ByVal claveIdioma As Integer)
			MyBase.New(claveidGrupo)

			Dim sql As String = "SELECT * from GruposIdiomas WHERE idGrupo=@idGrupo AND idIdioma=@idIdioma"

			Dim params As SqlParameter() = {New SqlParameter("@idGrupo", claveidGrupo), New SqlParameter("@idIdioma", claveIdioma)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
			If dr.Read Then
				Me.idGrupoIdioma = CInt(dr("idGrupoIdioma"))
				Me.idGrupo = CInt(dr("idGrupo"))
				Me.idIdioma = CInt(dr("idIdioma"))
				Me.nombre = dr("nombre")
				Me.existe = True
			End If
			dr.Close()
		End Sub

		Public Overloads Function Add() As Integer
			Dim sql As String = "INSERT INTO GruposIdiomas (idGrupo, idIdioma, nombre) VALUES ( @idGrupo, @idIdioma, @nombre)"
			If Not MyBase.existe Then
				MyBase.Add()
			End If

			Dim params As SqlParameter() = {New SqlParameter("@idGrupo", Me.idGrupo), _
			  New SqlParameter("@idIdioma", Me.idIdioma), _
			  New SqlParameter("@nombre", Me.nombre)}

			Me.idGrupoIdioma = Me.ExecuteNonQuery(sql, params, True)
			Me.existe = True

			Return 1
		End Function

		Public Overloads Function Update() As Integer
			Dim sql As String = "UPDATE GruposIdiomas SET idGrupo=@idGrupo, idIdioma=@idIdioma, nombre=@nombre WHERE idGrupoIdioma=@idGrupoIdioma"
			MyBase.Update()

			Dim params As SqlParameter() = {New SqlParameter("@idGrupo", idGrupo), _
			  New SqlParameter("@idIdioma", idIdioma), _
			  New SqlParameter("@nombre", nombre), _
			  New SqlParameter("@idGrupoIdioma", idGrupoIdioma)}

			If Me.existe Then
				Me.ExecuteNonQuery(sql, params)
			Else
				Me.Add()
			End If
		End Function

		Public Overloads Function Remove() As Integer
			Return MyBase.Remove()
		End Function

		Public Function GetDS(ByVal claveIdioma As Integer) As DataSet
            Dim sql As String = "SELECT g.*, gi.idIdioma, gi.nombre FROM Grupos AS g INNER JOIN GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo " _
             & " WHERE g.eliminado = 0 AND gi.idIdioma = @idIdioma ORDER BY g.orden"



			Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}

			Return Me.ExecuteDataSet(sql, params)
		End Function

		Public Function GetDR(ByVal claveIdioma As Integer) As SqlDataReader
            Dim sql As String = " SELECT g.*, gi.idIdioma, gi.nombre FROM Grupos AS g INNER JOIN GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo " _
             & " WHERE g.eliminado = 0   AND gi.idIdioma = @idIdioma ORDER BY g.orden"



			Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}

			Return Me.ExecuteReader(sql, params)
        End Function

        Public Function GetDRHome(ByVal claveIdioma As Integer) As SqlDataReader
            Dim sql As String = " SELECT g.*, gi.idIdioma, gi.nombre FROM Grupos AS g INNER JOIN GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo " _
             & " WHERE g.eliminado = 0 and g.display=1   AND gi.idIdioma = @idIdioma ORDER BY g.orden"

            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteReader(sql, params)
        End Function


        Public Function GetDRHome(ByVal claveIdioma As Integer, clavesitio As Integer) As SqlDataReader
            Dim sql As String = " SELECT g.*, gi.idIdioma, gi.nombre FROM Grupos AS g INNER JOIN GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo " _
             & " WHERE g.eliminado = 0 and g.display=1   AND gi.idIdioma = @idIdioma and g.sitio=@sitio ORDER BY g.orden"

            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@sitio", clavesitio)}

            Return Me.ExecuteReader(sql, params)
        End Function

        Public Function GetDSHome(ByVal claveIdioma As Integer, clavesitio As Integer) As SqlDataReader
            Dim sql As String = " SELECT g.*, gi.idIdioma, gi.nombre FROM Grupos AS g INNER JOIN GruposIdiomas AS gi ON g.idGrupo = gi.idGrupo " _
             & " WHERE g.eliminado = 0 and g.display=1   AND gi.idIdioma = @idIdioma and g.sitio=@sitio ORDER BY g.orden"

            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@sitio", clavesitio)}

            Return Me.ExecuteReader(sql, params)
        End Function

        Public Function GetDSProductoGrupo(ByVal claveIdioma As Integer) As DataSet
			Dim ds As New DataSet
			Dim queryString As String
			Dim connString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
			Dim dataAdapterGrupos, dataAdapterProductosGrupos As SqlDataAdapter

			queryString = "SELECT g.idGrupo, g.display, g.orden, g.eliminado, gi.nombre FROM Grupos AS g INNER JOIN GruposIdiomas AS gi " _
			 & "ON g.idGrupo = gi.idGrupo WHERE gi.idIdioma = " & claveIdioma & " AND g.eliminado = 0 ORDER BY g.orden"

			dataAdapterGrupos = New SqlDataAdapter(queryString, connString)
			dataAdapterGrupos.Fill(ds, "Grupos")

			queryString = "SELECT p.*, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags, pg.idProductoGrupo, p.eliminado, pf.imagen, pg.idGrupo " _
			 & "FROM ProductosIdiomas AS pi INNER JOIN Productos AS p ON pi.idProducto = p.idProducto INNER JOIN ProductosGrupos AS pg " _
			 & "ON p.idProducto = pg.idProducto INNER JOIN ProductosFotos AS pf ON p.idProducto = pf.idProducto WHERE pi.idIdioma = " & claveIdioma _
			 & "AND p.eliminado = 0 AND pf.principal = 1"

			dataAdapterProductosGrupos = New SqlDataAdapter(queryString, connString)
			dataAdapterProductosGrupos.Fill(ds, "ProductosGrupos")

			Dim relation As New DataRelation("ProductosGrupos", ds.Tables("Grupos").Columns("idGrupo"), ds.Tables("ProductosGrupos").Columns("idGrupo"), False)

			ds.Relations.Add(relation)

			Return ds

		End Function
	End Class
End Namespace

