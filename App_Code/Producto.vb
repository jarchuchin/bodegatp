


Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class Producto
        Inherits DBObject

        Public idProducto As Integer
        Public idFabricante As Integer
        Public idPaisOrigen As Integer
        Public idFormato As Integer
        Public clave As String
        Public visitas As Integer
        Public ventas As Integer
        Public existencia As Integer
        Public ventaMinima As Integer
        Public descuentoDistribuidor As Integer

        Public Peso As Decimal
        Public fecharegistro As DateTime
        Public fechamodificacion As DateTime
        Public online As Boolean

        Public eliminado As Boolean

        Public existe As Boolean = False
        Public subclaves As String = ""


        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from Productos where idProducto=@idProducto"
            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idProducto = CInt(dr("idProducto"))
                Me.idFabricante = CInt(dr("idFabricante"))
                Me.idPaisOrigen = CInt(dr("idPaisOrigen"))
                Me.clave = dr("clave")
                Me.visitas = CInt(dr("visitas"))
                Me.ventas = CInt(dr("ventas"))
                Me.existencia = CInt(dr("existencia"))
                Me.ventaMinima = CInt(dr("ventaMinima"))
                Me.descuentoDistribuidor = CInt(dr("descuentoDistribuidor"))
                Me.idFormato = CInt(dr("idFormato"))
                Me.Peso = CDec(dr("Peso"))
                Me.fechamodificacion = CType(dr("fechaModificacion"), DateTime)
                Me.fecharegistro = CType(dr("fecharegistro"), DateTime)
                Me.eliminado = CBool(dr("eliminado"))
                Me.online = CBool(dr("online"))
                Me.existe = True

                If Not Convert.IsDBNull(dr("subclaves")) Then
                    Me.subclaves = dr("subclaves")
                End If
            End If
            dr.Close()

        End Sub


        Sub New(ByVal claveprincipal As String)
            Dim sql As String = "select * from Productos where clave=@clave"
            Dim params As SqlParameter() = {New SqlParameter("@clave", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idProducto = CInt(dr("idProducto"))
                Me.idFabricante = CInt(dr("idFabricante"))
                Me.idPaisOrigen = CInt(dr("idPaisOrigen"))
                Me.clave = dr("clave")
                Me.visitas = CInt(dr("visitas"))
                Me.ventas = CInt(dr("ventas"))
                Me.existencia = CInt(dr("existencia"))
                Me.ventaMinima = CInt(dr("ventaMinima"))
                Me.descuentoDistribuidor = CInt(dr("descuentoDistribuidor"))
                Me.idFormato = CInt(dr("idFormato"))
                Me.Peso = CDec(dr("Peso"))
                Me.fechamodificacion = CType(dr("fechaModificacion"), DateTime)
                Me.fecharegistro = CType(dr("fecharegistro"), DateTime)
                Me.eliminado = CBool(dr("eliminado"))
                Me.online = CBool(dr("online"))
                Me.existe = True

                If Not Convert.IsDBNull(dr("subclaves")) Then
                    Me.subclaves = dr("subclaves")
                End If
            End If
            dr.Close()

        End Sub

        Protected Function Add() As Integer
            Dim sql As String = "insert into Productos (idFabricante, idpaisorigen, clave,  visitas, ventas, existencia, ventaminima, descuentodistribuidor, idFormato, peso, fecharegistro, fechamodificacion, eliminado, online) values (@idfabricante, @idpaisorigen, @clave, @visitas, @ventas, @existencia, @ventaminima, @descuentodistribuidor, @idFormato, @peso, @fecharegistro, @fechamodificacion, @eliminado, @online)"
            Dim params As SqlParameter() = { _
            New SqlParameter("@idFabricante", idFabricante), _
            New SqlParameter("@idPaisOrigen", idPaisOrigen), _
            New SqlParameter("@clave", clave), _
            New SqlParameter("@visitas", visitas), _
            New SqlParameter("@ventas", ventas), _
            New SqlParameter("@existencia", existencia), _
            New SqlParameter("@ventaminima", ventaMinima), _
            New SqlParameter("@descuentodistribuidor", descuentoDistribuidor), _
            New SqlParameter("@idFormato", idFormato), _
            New SqlParameter("@peso", Peso), _
            New SqlParameter("@fecharegistro", fecharegistro), _
            New SqlParameter("@fechamodificacion", fechamodificacion), _
            New SqlParameter("@online", online), _
            New SqlParameter("@eliminado", eliminado)}

            Me.idProducto = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1
        End Function

        Protected Function Update() As Integer
            Dim sql As String = "update Productos set idfabricante=@idfabricante, idpaisorigen=@idpaisorigen, clave=@clave, ventas=@ventas, existencia=@existencia, ventaminima=@ventaminima, descuentodistribuidor=@descuentodistribuidor, idFormato=@idFormato, peso=@peso, fecharegistro=@fecharegistro, fechamodificacion=@fechamodificacion, eliminado=@eliminado, @online=@online where idProducto=@idProducto"
            Dim params As SqlParameter() = { _
            New SqlParameter("@idFabricante", idFabricante), _
            New SqlParameter("@idPaisOrigen", idPaisOrigen), _
            New SqlParameter("@clave", clave), _
            New SqlParameter("@visitas", visitas), _
            New SqlParameter("@ventas", ventas), _
            New SqlParameter("@existencia", existencia), _
            New SqlParameter("@ventaminima", ventaMinima), _
            New SqlParameter("@descuentodistribuidor", descuentoDistribuidor), _
            New SqlParameter("@idFormato", idFormato), _
            New SqlParameter("@peso", Peso), _
            New SqlParameter("@fecharegistro", fecharegistro), _
            New SqlParameter("@fechamodificacion", fechamodificacion), _
            New SqlParameter("@eliminado", eliminado), _
            New SqlParameter("@online", online), _
            New SqlParameter("@idProducto", idProducto)}

            Return Me.ExecuteNonQuery(sql, params)


        End Function

        Protected Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function



    End Class

End Namespace
