

Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class OrdenImagen
        Inherits DBObject

        Public idOrdenImagen As Integer
        Public idOrden As Integer
        Public imagen As String

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from ordenesimagenes where idOrdenImagen=@idOrdenImagen"
            Dim params As SqlParameter() = {New SqlParameter("@idOrdenImagen", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idOrdenImagen = CInt(dr("idOrdenImagen"))
                Me.idOrden = CBool(dr("idOrden"))
                Me.imagen = dr("imagen")
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim sql As String = "insert into ordenesimagenes ( idOrden, Imagen) values (@idOrden, @Imagen)"
            Dim params As SqlParameter() = { _
                       New SqlParameter("@idOrden", idOrden), _
            New SqlParameter("@imagen", imagen)}

            Me.idOrdenImagen = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update ordenesimagenes set idOrden=@idOrden, Imagen=@Imagen where idOrdenImagen=@idOrdenImagen"
            Dim params As SqlParameter() = { _
                       New SqlParameter("@idOrden", idOrden), _
            New SqlParameter("@imagen", imagen), _
            New SqlParameter("@idOrdenImagen", idOrdenImagen)}

            Return Me.ExecuteNonQuery(sql, params)


        End Function



        Public Function Remove() As Integer
            Dim sql As String = "delete ordenesimagenes where idordenimagen=@idordenimagen"
            Dim params As SqlParameter() = { _
                       New SqlParameter("@idordenimagen", idOrdenImagen)}

            Return Me.ExecuteNonQuery(sql, params)
        End Function



        Public Function getDS(ByVal claveOrden As Integer) As DataSet
            Dim sql As String = "select * from ordenesimagenes where idOrden=@idOrden"
            Dim params As SqlParameter() = { _
                       New SqlParameter("@idOrden", claveOrden)}

            Return Me.ExecuteDataSet(sql, params)


        End Function




    End Class

End Namespace
