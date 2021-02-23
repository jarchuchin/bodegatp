Imports System.Data.SqlClient
Imports System.Data



Namespace tienda
    Public Class Distribuidor
        Inherits DBObject

        Public idDistribuidor As Integer
        Public Nombre As String
        Public Email As String
        Public Password As String
        Public Telefono As String
        Public idEstado As Integer
        Public RazonSocial As String
        Public Giro As String
        Public RFC As String
        Public Direccion As String
        Public PaginaWeb As String
        Public Comentarios As String
        Public FechaRegistro As DateTime

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from distribuidores where idDistribuidor=@idDistribuidor"
            Dim params() As SqlParameter = {New SqlParameter("@idDistribuidor", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idDistribuidor = CInt(dr("idDistribuidor"))
                Me.Nombre = dr("nombre")
                Me.Email = dr("Email")
                Me.Password = dr("Password")
                Me.Telefono = dr("Telefono")
                Me.idEstado = CInt(dr("idEstado"))
                Me.RazonSocial = dr("RazonSocial")
                Me.Giro = dr("Giro")
                Me.RFC = dr("RFC")
                Me.Direccion = dr("Direccion")
                Me.PaginaWeb = dr("PaginaWeb")
                Me.Comentarios = dr("Comentarios")
                Me.FechaRegistro = CDate(dr("FechaRegistro"))

                Me.existe = True
            End If

            dr.Close()
        End Sub


        Sub New(ByVal claveEmail As String)
            Dim sql As String = "select * from distribuidores where Email=@Email"
            Dim params() As SqlParameter = {New SqlParameter("@Email", claveEmail)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idDistribuidor = CInt(dr("idDistribuidor"))
                Me.Nombre = dr("nombre")
                Me.Email = dr("Email")
                Me.Password = dr("Password")
                Me.Telefono = dr("Telefono")
                Me.idEstado = CInt(dr("idEstado"))
                Me.RazonSocial = dr("RazonSocial")
                Me.Giro = dr("Giro")
                Me.RFC = dr("RFC")
                Me.Direccion = dr("Direccion")
                Me.PaginaWeb = dr("PaginaWeb")
                Me.Comentarios = dr("Comentarios")
                Me.FechaRegistro = CDate(dr("FechaRegistro"))

                Me.existe = True
            End If

            dr.Close()
        End Sub


        Public Function Add() As Integer
            Dim sql As String = "insert into distribuidores (nombre, email, password, telefono, idestado, razonsocial, giro, rfc, direccion, Paginaweb, comentarios, fecharegistro) values (@nombre, @email, @password, @telefono, @idestado, @razonsocial, @giro, @rfc, @direccion, @Paginaweb, @comentarios, @fecharegistro)"
            Dim params() As SqlParameter = { _
                                            New SqlParameter("@nombre", Nombre), _
                                            New SqlParameter("@email", Email), _
                                            New SqlParameter("@password", Password), _
                                            New SqlParameter("@telefono", Telefono), _
                                            New SqlParameter("@idestado", idEstado), _
                                            New SqlParameter("@razonsocial", RazonSocial), _
                                            New SqlParameter("@giro", Giro), _
                                            New SqlParameter("@rfc", RFC), _
                                            New SqlParameter("@direccion", Direccion), _
                                            New SqlParameter("@Paginaweb", PaginaWeb), _
                                            New SqlParameter("@comentarios", Comentarios), _
                                            New SqlParameter("@fecharegistro", FechaRegistro)}

            Me.idDistribuidor = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function


        Public Function Update() As Integer
            Dim sql As String = "update distribuidores set nombre=@nombre, email=@email, password=@password, telefono=@telefono, idEstado=@idEstado, razonsocial=@razonsocial, giro=@giro, rfc=@rfc, direccion=@direccion, paginaweb=@paginaweb, comentarios=@comentarios, fecharegistro=@fecharegistro where idDistribuidor=@idDistribuidor"

            Dim params() As SqlParameter = { _
                                            New SqlParameter("@nombre", Nombre), _
                                            New SqlParameter("@email", Email), _
                                            New SqlParameter("@password", Password), _
                                            New SqlParameter("@telefono", Telefono), _
                                            New SqlParameter("@idestado", idEstado), _
                                            New SqlParameter("@razonsocial", RazonSocial), _
                                            New SqlParameter("@giro", Giro), _
                                            New SqlParameter("@rfc", RFC), _
                                            New SqlParameter("@direccion", Direccion), _
                                            New SqlParameter("@Paginaweb", PaginaWeb), _
                                            New SqlParameter("@comentarios", Comentarios), _
                                            New SqlParameter("@fecharegistro", FechaRegistro), _
                                            New SqlParameter("@idDistribuidor", idDistribuidor)}

            Me.idDistribuidor = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function


        Public Function GetDS() As DataSet
            Dim sql As String = "select * from distribuidores"
            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

    End Class

End Namespace
