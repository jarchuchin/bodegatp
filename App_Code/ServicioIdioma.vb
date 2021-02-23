Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace tienda
    Public Class ServicioIdioma
        Inherits Servicio

        Public idServicioIdioma As Integer
        Public idIdioma As Integer
        Public nombre As String
        Public componenteBase As String
        Public Shadows existe As Boolean = False

        Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT* FROM ServiciosIdiomas WHERE idServicioIdioma=@idServicioIdioma"
            Dim parametros As SqlParameter() = {New SqlParameter("@idServicioIdioma", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idServicioIdioma = CInt(dr("idServicioIdioma"))
                Me.idServicio = CInt(dr("idServicio"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")
                Me.componenteBase = dr("componenteBase")
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveServicio As Integer, ByVal claveIdioma As Integer, Optional ByVal devuelveIdiomaExistente As Boolean = False)
            MyBase.New(claveServicio)

            Dim queryString As String = "SELECT * FROM ServiciosIdiomas WHERE idServicio=@idServicio AND idIdioma=@idIdioma"
            Dim parametros As SqlParameter() = {New SqlParameter("@idServicio", claveServicio), New SqlParameter("@idIdioma", claveIdioma)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idServicioIdioma = CInt(dr("idServicioIdioma"))
                Me.idServicio = CInt(dr("idServicio"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")
                Me.componenteBase = dr("componenteBase")
                Me.existe = True
            End If
            dr.Close()

            If Not existe And devuelveIdiomaExistente Then
                queryString = "SELECT TOP 1 * FROM ServiciosIdiomas WHERE idServicio=@idServicio ORDER BY idIdioma"
                Dim parametros2 As SqlParameter() = {New SqlParameter("@idServicio", claveServicio)}
                dr = Me.ExecuteReader(queryString, parametros2)
                If dr.Read Then
                    Me.idServicioIdioma = CInt(dr("idServicioIdioma"))
                    Me.idServicio = CInt(dr("idServicio"))
                    Me.idIdioma = CInt(dr("idIdioma"))
                    Me.nombre = dr("nombre")
                    Me.componenteBase = dr("componenteBase")
                    Me.existe = True
                End If
                dr.Close()
            End If
            '   dr.Close()

        End Sub

        Public Overloads Function Add() As Integer
            If Not MyBase.existe Then MyBase.Add()

            Dim queryString As String = "INSERT INTO ServiciosIdiomas (idServicio, idIdioma, nombre, componenteBase) " _
             & "VALUES (@idServicio, @idIdioma, @nombre, @componenteBase)"

            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idServicio", Me.idServicio), _
            New SqlParameter("@idIdioma", Me.idIdioma), _
            New SqlParameter("@nombre", Me.nombre), _
            New SqlParameter("@componenteBase", Me.componenteBase)}

            Me.idServicioIdioma = Me.ExecuteNonQuery(queryString, parametros, True)
            Me.existe = True
            Return 1
        End Function

        Public Overloads Function Update() As Integer
            MyBase.Update()

            Dim queryString As String = "UPDATE ServiciosIdiomas SET nombre=@nombre, componenteBase=@componenteBase WHERE idServicioIdioma=@idServicioIdioma"

            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idServicioIdioma", Me.idServicioIdioma), _
            New SqlParameter("@nombre", Me.nombre), _
            New SqlParameter("@componenteBase", Me.componenteBase)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Overloads Function Remove() As Integer
            Return MyBase.Remove()
        End Function

        Public Function GetDS(ByVal claveIdioma As Integer) As DataSet
            Dim queryString As String = "SELECT  si.nombre, si.componenteBase, s.* " _
    & "FROM ServiciosIdiomas AS si INNER JOIN Servicios AS s ON si.idServicio = s.idServicio WHERE si.idIdioma = @idIdioma and s.eliminado=0 and s.MostrarEnSitio=1"

            Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Overloads Function GetDR(ByVal claveIdioma As Integer) As SqlDataReader
            Dim queryString As String = "SELECT si.nombre, si.componenteBase, s.* FROM ServiciosIdiomas AS si INNER JOIN Servicios AS s ON si.idServicio = s.idServicio and s.idproducto=0 and s.eliminado=0 and s.MostrarEnSitio=1  " _
    & " WHERE si.idIdioma = @idIdioma"

            Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function


        Public Overloads Function GetDR(ByVal claveIdioma As Integer, ByVal claveProducto As Integer) As SqlDataReader
            Dim queryString As String = "SELECT si.nombre, si.componenteBase, s.* " & _
                                                                " from serviciosidiomas si, servicios s " & _
                                                                " where si.idServicio = s.idServicio And s.idproducto = 0 and s.eliminado=0 and s.MostrarEnSitio=1 and si.idIdioma = @idIdioma" & _
                                                                " and s.idServicio not in (select spn.idServicio from serviciosproductosnegados spn where spn.idproducto=@idProducto) " & _
                                                                " union " & _
                                                                " SELECT si.nombre, si.componenteBase, s.* " & _
                                                                " from serviciosidiomas si, servicios s " & _
                                                                " where si.idServicio = s.idServicio And s.idproducto = @idProducto and s.eliminado=0 and si.idIdioma = @idIdioma and s.MostrarEnSitio=1"


            Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idProducto", claveProducto)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Overloads Function GetDRSoloProducto(ByVal claveIdioma As Integer, ByVal claveProducto As Integer) As SqlDataReader
            Dim queryString As String = " SELECT si.nombre, si.componenteBase, s.* " & _
                                                                " from serviciosidiomas si, servicios s " & _
                                                                " where si.idServicio = s.idServicio And s.idproducto = @idProducto and si.idIdioma = @idIdioma and s.eliminado=0 and s.MostrarEnSitio=1"


            Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idProducto", claveProducto)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function


        Public Overloads Function GetDRTodos(ByVal claveIdioma As Integer, ByVal claveProducto As Integer) As SqlDataReader
            Dim queryString As String = "SELECT si.nombre, si.componenteBase, s.* FROM ServiciosIdiomas AS si INNER JOIN Servicios AS s ON si.idServicio = s.idServicio and s.idproducto=@idProducto and s.idproducto=0 and s.eliminado=0 and s.MostrarEnSitio=1 " _
    & "WHERE si.idIdioma = @idIdioma"

            Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idProducto", claveProducto)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function


    End Class
End Namespace
