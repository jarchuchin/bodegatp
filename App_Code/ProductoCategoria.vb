Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Namespace tienda


    Public Class ProductoCategoria
        Inherits DBObject


        Public idProductoCategoria As Integer
        Public idProducto As Integer
        Public idCategoria As Integer
        Public existe As Boolean = False

       
        Sub New()

        End Sub


        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from ProductosCategorias where idProductoCategoria=@idProductoCategoria"
            Dim params As SqlParameter() = {New SqlParameter("@idProductoCategoria", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idProductoCategoria = CInt(dr("idProductoCategoria"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.idCategoria = CInt(dr("idCategoria"))
                Me.existe = True
            End If
            dr.Close()

        End Sub


        Sub New(ByVal claveproducto As Integer, ByVal claveCategoria As Integer)
            Dim sql As String = "select * from ProductosCategorias where idProducto=@idProducto and idcategoria=@idCategoria"
            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveproducto), New SqlParameter("@idcategoria", claveCategoria)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idProductoCategoria = CInt(dr("idProductoCategoria"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.idCategoria = CInt(dr("idCategoria"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim sql As String = "insert into ProductosCategorias (idproducto, idCategoria) values (@idproducto, @idCategoria)"
            Dim params As SqlParameter() = { _
            New SqlParameter("@idproducto", idProducto), _
            New SqlParameter("@idCategoria", idCategoria)}

            Dim mypc As New ProductoCategoria(idProducto, idCategoria)
            If Not mypc.existe Then
                Me.idProductoCategoria = Me.ExecuteNonQuery(sql, params, True)
            End If


            Me.existe = True
            Return 1
        End Function

        



        Public Function Remove() As Integer
            Dim sql As String = "delete ProductosCategorias where idProductoCategoria=@idProductoCategoria"
            Dim params As SqlParameter() = { _
          New SqlParameter("@idProductoCategoria", idProductoCategoria)}


       

            Return Me.ExecuteNonQuery(sql, params)

        End Function

        Public Function GetDS(ByVal claveproducto As Integer, ByVal claveIdioma As Integer) As DataSet
            Dim sql As String = "select p.*, ci.nombre from ProductosCategorias p, categoriasIdiomas ci where p.idCategoria=ci.idCategoria and ci.idIdioma=@idioma and  idproducto=@idProducto"
            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveproducto), New SqlParameter("@idioma", claveIdioma)}
            Return Me.ExecuteDataSet(sql, params)

        End Function



        

    End Class

End Namespace
