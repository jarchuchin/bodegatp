

Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class Categoria
        Inherits DBObject

        Public idCategoria As Integer
        Public idRaiz As Integer
        Public activa As Boolean
        Public orden As Integer
        Public resaltar As Boolean
        Public desplegarimagen As Boolean
        Public eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from Categorias where idCategoria=@idCategoria"
            Dim params As SqlParameter() = {New SqlParameter("@idCategoria", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idCategoria = CInt(dr("idCategoria"))
                Me.idRaiz = CInt(dr("idRaiz"))
                Me.activa = CBool(dr("activa"))
                Me.orden = CInt(dr("orden"))
                Me.resaltar = CBool(dr("resaltar"))
                Me.desplegarimagen = CBool(dr("desplegarimagen"))
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Protected Function Add() As Integer
            Dim sql As String = "insert into Categorias (idRaiz, activa, orden, resaltar, desplegarimagen, eliminado) values (@idRaiz, @activa, @orden, @resaltar, @desplegarimagen, @eliminado)"
            Dim params As SqlParameter() = { _
            New SqlParameter("@idRaiz", idRaiz), _
            New SqlParameter("@activa", activa), _
            New SqlParameter("@orden", orden), _
            New SqlParameter("@resaltar", resaltar), _
            New SqlParameter("@desplegarImagen", desplegarimagen), _
            New SqlParameter("@eliminado", eliminado)}

            Me.idCategoria = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1
        End Function

        Protected Function Update() As Integer
            Dim sql As String = "update Categorias set idraiz=@idraiz, activa=@activa, orden=@orden, resaltar=@resaltar, desplegarImagen=@desplegarImagen, eliminado=@eliminado where idCategoria=@idCategoria"
            Dim params As SqlParameter() = { _
            New SqlParameter("@idRaiz", idRaiz), _
            New SqlParameter("@activa", activa), _
            New SqlParameter("@orden", orden), _
            New SqlParameter("@resaltar", resaltar), _
            New SqlParameter("@desplegarImagen", desplegarimagen), _
            New SqlParameter("@eliminado", eliminado), _
            New SqlParameter("@idCategoria", idCategoria)}

            Return Me.ExecuteNonQuery(sql, params)


        End Function



        Protected Function Remove() As Integer
            Me.eliminado = True
            Me.Update()

        End Function







    End Class

End Namespace
