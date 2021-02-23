Imports System.Data.SqlClient
Imports System.Data



Namespace tienda

    Public Class Direccion
        Inherits DBObject

        Public idDireccion As Integer
        Public iduserProfile As Integer
        Public nombre As String
        Public apellidos As String
        Public direccion As String
        Public ciudad As String
        Public idPais As Integer
        Public idEstado As Integer
        Public cp As String
        Public telefono As String
        Public tipo As String
        Public rfc As String = ""


        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from direcciones where idDireccion=@idDireccion"
            Dim params() As SqlParameter = {New SqlParameter("@idDireccion", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idDireccion = CInt(dr("idDireccion"))
                Me.iduserProfile = CInt(dr("idUserProfile"))
                Me.nombre = dr("nombre")
                Me.apellidos = dr("apellidos")
                Me.direccion = dr("direccion")
                Me.ciudad = dr("ciudad")
                Me.idPais = CInt(dr("idPais"))
                Me.idEstado = CInt(dr("idEstado"))
                Me.cp = dr("cp")
                Me.telefono = dr("telefono")
                Me.tipo = dr("tipo")
                Me.tipo = dr("rfc")

                Me.existe = True
            End If

            dr.Close()
        End Sub

        Sub New(ByVal claveusuario As Integer, ByVal tipodireccion As String)
            Dim sql As String = "select * from direcciones where idUserprofile=@idUserprofile and tipo=@tipo"
            Dim params() As SqlParameter = {New SqlParameter("@idUserprofile", claveusuario), New SqlParameter("@tipo", tipodireccion)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idDireccion = CInt(dr("idDireccion"))
                Me.iduserProfile = CInt(dr("idUserProfile"))
                Me.nombre = dr("nombre")
                Me.apellidos = dr("apellidos")
                Me.direccion = dr("direccion")
                Me.ciudad = dr("ciudad")
                Me.idPais = CInt(dr("idPais"))
                Me.idEstado = CInt(dr("idEstado"))
                Me.cp = dr("cp")
                Me.telefono = dr("telefono")
                Me.tipo = dr("tipo")
                Me.tipo = dr("rfc")

                Me.existe = True
            End If

            dr.Close()
        End Sub

        Public Function Add() As Integer
            Dim sql As String = "insert into direcciones (idUserProfile, nombre, apellidos, direccion, ciudad, idPais, idEstado, cp, telefono, tipo, rfc) values (@idUserProfile, @nombre, @apellidos, @direccion, @ciudad, @idPais, @idEstado, @cp, @telefono, @tipo, @rfc)"
            Dim params() As SqlParameter = { _
                                            New SqlParameter("@idUserProfile", iduserProfile), _
                                            New SqlParameter("@nombre", nombre), _
                                            New SqlParameter("@apellidos", apellidos), _
                                            New SqlParameter("@direccion", direccion), _
                                            New SqlParameter("@ciudad", ciudad), _
                                            New SqlParameter("@idPais", idPais), _
                                            New SqlParameter("@idEstado", idEstado), _
                                            New SqlParameter("@cp", cp), _
                                            New SqlParameter("@telefono", telefono), _
                                            New SqlParameter("@tipo", tipo), _
                                            New SqlParameter("@rfc", rfc)}

            Me.idDireccion = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update direcciones set idUserProfile=@idUserProfile, nombre=@nombre, apellidos=@apellidos, direccion=@direccion, ciudad=@ciudad, idpais=@idPais, idestado=@idestado, cp=@cp, telefono=@telefono, tipo=@tipo, rfc=@rfc where idDireccion=@idDireccion"

            Dim params() As SqlParameter = { _
                                            New SqlParameter("@idUserProfile", iduserProfile), _
                                            New SqlParameter("@nombre", nombre), _
                                            New SqlParameter("@apellidos", apellidos), _
                                            New SqlParameter("@direccion", direccion), _
                                            New SqlParameter("@ciudad", ciudad), _
                                            New SqlParameter("@idPais", idPais), _
                                            New SqlParameter("@idEstado", idEstado), _
                                            New SqlParameter("@cp", cp), _
                                            New SqlParameter("@telefono", telefono), _
                                            New SqlParameter("@idDireccion", idDireccion), _
                                            New SqlParameter("@tipo", tipo), _
                                            New SqlParameter("@rfc", rfc)}


            Me.ExecuteNonQuery(sql, params)
            Return 1

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete from direcciones where idDireccion=@idDireccion"
            Dim params() As SqlParameter = {New SqlParameter("@idDireccion", Me.idDireccion)}

            Return Me.ExecuteNonQuery(sql, params)

        End Function

        Public Function GetDS(ByVal claveusuario As Integer, ByVal tipodireccion As String) As DataSet
            Dim sql As String = "select * from direcciones where iduserprofile=@iduserprofile and tipo=@tipo"
            Dim params() As SqlParameter = {New SqlParameter("@iduserprofile", claveusuario), New SqlParameter("@tipo", tipodireccion)}
            Return Me.ExecuteDataSet(sql, params)

        End Function
    End Class


End Namespace
