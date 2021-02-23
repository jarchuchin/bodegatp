


Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class ServicioProductoNegado
        Inherits DBObject

        Public idServicioProductoNegado As Integer
        Public idServicio As Integer
        Public idProducto As Integer

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from ServiciosProductosNegados where idServicioProductoNegado=@idServicioProductoNegado"
            Dim params As SqlParameter() = {New SqlParameter("@idServicioProductoNegado", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idServicioProductoNegado = CInt(dr("idServicioProductoNegado"))
                Me.idServicio = CInt(dr("idServicio"))
                Me.idProducto = CInt(dr("idProducto"))

                Me.existe = True
            End If
            dr.Close()

        End Sub


        Sub New(ByVal claveservicio As Integer, ByVal claveproducto As Integer)
            Dim sql As String = "select * from ServiciosProductosNegados where idProducto=@idProducto and idServicio=@idServicio"
            Dim params As SqlParameter() = {New SqlParameter("@idServicio", claveservicio), New SqlParameter("@idProducto", claveproducto)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idServicioProductoNegado = CInt(dr("idServicioProductoNegado"))
                Me.idServicio = CInt(dr("idServicio"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim sql As String = "insert into ServiciosProductosNegados (idservicio, idProducto) values (@idservicio, @idProducto)"
            Dim params As SqlParameter() = {New SqlParameter("@idservicio", idServicio), New SqlParameter("@idProducto", idProducto)}
            Me.idServicioProductoNegado = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function


        Public Function Remove() As Integer
            Dim sql As String = "delete serviciosproductosnegados where idServicioProductoNegado=@idServicioProductoNegado "
            Dim params As SqlParameter() = {New SqlParameter("@idServicioProductoNegado", idServicioProductoNegado)}
            Return Me.ExecuteNonQuery(sql, params)
        End Function



    End Class

End Namespace
