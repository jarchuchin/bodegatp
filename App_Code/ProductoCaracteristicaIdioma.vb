


Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class ProductoCaracteristicaIdioma
        Inherits DBObject

        Public idProductoCaracteristicaIdioma As Integer
        Public idProducto As Integer
        Public idCaracteristica As Integer
        Public idIdioma As Integer
        Public valor As String



        Public existe As Boolean = False

        Sub New()

        End Sub
        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from productosCaracteristicasidiomas where  idProductoCaracteristicaIdioma=@idProductoCaracteristicaIdioma"
            Dim params() As SqlParameter = {New SqlParameter("@idProductoCaracteristicaIdioma", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idProductoCaracteristicaIdioma = CInt(dr("idProductoCaracteristicaIdioma"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.idCaracteristica = CInt(dr("idCaracteristica"))
                Me.idIdioma = CInt(dr("ididioma"))
                Me.valor = dr("valor")
                Me.existe = True
            End If

            dr.Close()
        End Sub

        Sub New(ByVal claveproducto As Integer, ByVal claveidioma As Integer, ByVal clavecaracteristica As Integer)
            Dim sql As String = "select * from productosCaracteristicasidiomas where idProducto=@idProducto and idIdioma=@idIdioma and idCaracteristica=@idCaracteristica"
            Dim params() As SqlParameter = {New SqlParameter("@idProducto", claveproducto), New SqlParameter("@idIdioma", claveidioma), New SqlParameter("@idCaracteristica", clavecaracteristica)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idProductoCaracteristicaIdioma = CInt(dr("idProductoCaracteristicaIdioma"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.idCaracteristica = CInt(dr("idCaracteristica"))
                Me.idIdioma = CInt(dr("ididioma"))
                Me.valor = dr("valor")
                Me.existe = True
            End If

            dr.Close()
        End Sub


        Sub New(ByVal claveproducto As Integer, ByVal claveidioma As Integer, ByVal clavecaracteristica As Integer, ByVal activardefault As Boolean)
            Dim sql As String = "select * from productosCaracteristicasidiomas where idProducto=@idProducto and idIdioma=@idIdioma and idCaracteristica=@idCaracteristica and valor <> ''"
            Dim params() As SqlParameter = {New SqlParameter("@idProducto", claveproducto), New SqlParameter("@idIdioma", claveidioma), New SqlParameter("@idCaracteristica", clavecaracteristica)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idProductoCaracteristicaIdioma = CInt(dr("idProductoCaracteristicaIdioma"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.idCaracteristica = CInt(dr("idCaracteristica"))
                Me.idIdioma = CInt(dr("ididioma"))
                Me.valor = dr("valor")
                Me.existe = True
            Else
                Dim sql2 As String = "select * from productosCaracteristicasidiomas where idProducto=@idProducto  and idCaracteristica=@idCaracteristica and valor <> ''"
                Dim params2() As SqlParameter = {New SqlParameter("@idProducto", claveproducto), New SqlParameter("@idCaracteristica", clavecaracteristica)}
                Dim dr2 As SqlDataReader = Me.ExecuteReader(sql2, params2)
                If dr2.Read Then
                    Me.idProductoCaracteristicaIdioma = CInt(dr2("idProductoCaracteristicaIdioma"))
                    Me.idProducto = CInt(dr2("idProducto"))
                    Me.idCaracteristica = CInt(dr2("idCaracteristica"))
                    Me.idIdioma = CInt(dr2("ididioma"))
                    Me.valor = dr2("valor")

                    Me.existe = True
                End If
                dr2.Close()

            End If

            dr.Close()
        End Sub

        Public Function Add() As Integer
            Dim sql As String = "insert into productosCaracteristicasidiomas (idproducto, idcaracteristica, ididioma, valor) values (@idproducto, @idcaracteristica, @ididioma, @valor)"
            Dim params() As SqlParameter = {New SqlParameter("@idproducto", idProducto), _
                                            New SqlParameter("@idcaracteristica", idCaracteristica), _
                                            New SqlParameter("@ididioma", idIdioma), _
                                            New SqlParameter("@valor", valor)}

            Me.idProductoCaracteristicaIdioma = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update productosCaracteristicasidiomas set idproducto=@idproducto, idcaracteristica=@idcaracteristica, ididioma=@ididioma, valor=@valor where idProductoCaracteristicaIdioma=@idProductoCaracteristicaIdioma "

            Dim params() As SqlParameter = {New SqlParameter("@idproducto", idProducto), _
                                             New SqlParameter("@idcaracteristica", idCaracteristica), _
                                             New SqlParameter("@ididioma", idIdioma), _
                                             New SqlParameter("@valor", valor), _
                                             New SqlParameter("@idProductoCaracteristicaIdioma", idProductoCaracteristicaIdioma)}


            Me.ExecuteNonQuery(sql, params)
            Return 1

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete productosCaracteristicasidiomas where idProductoCaracteristicaIdioma=@idProductoCaracteristicaIdioma"
            Dim params() As SqlParameter = {New SqlParameter("@idProductoCaracteristicaIdioma", idProductoCaracteristicaIdioma)}
            Return Me.ExecuteNonQuery(sql, params)



        End Function

     
    End Class
End Namespace
