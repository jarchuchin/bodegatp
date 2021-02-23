
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Namespace tienda


    Public Class ProductoArchivo
        Inherits DBObject


        Public idProductoArchivo As Integer
        Public idProducto As Integer
        Public titulo As String
        Public Archivo As String
        Public tamano As Integer
        Public tipo As String
        Public nombreoriginal As String
        Public existe As Boolean = False

   


        Sub New()

        End Sub


        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from ProductosArchivos where idProductoArchivo=@idProductoArchivo"
            Dim params As SqlParameter() = {New SqlParameter("@idProductoArchivo", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idProductoArchivo = CInt(dr("idProductoArchivo"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.titulo = dr("titulo")
                Me.Archivo = dr("Archivo")
                Me.tamano = CInt(dr("tamano"))
                Me.tipo = dr("tipo")
                Me.nombreoriginal = dr("nombreoriginal")
                Me.existe = True
            End If
            dr.Close()

        End Sub


      

        Public Function Add() As Integer
            Dim sql As String = "insert into ProductosArchivos (idproducto, titulo, archivo, tamano, tipo, nombreoriginal) values (@idproducto, @titulo, @archivo, @tamano, @tipo, @nombreoriginal)"
            Dim params As SqlParameter() = { _
            New SqlParameter("@idproducto", idProducto), _
            New SqlParameter("@titulo", titulo), _
            New SqlParameter("@archivo", Archivo), _
            New SqlParameter("@tamano", tamano), _
            New SqlParameter("@nombreoriginal", nombreoriginal), _
            New SqlParameter("@tipo", tipo)}

        
            Me.idProductoArchivo = Me.ExecuteNonQuery(sql, params, True)

            Me.existe = True
            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update ProductosArchivos set idProducto=@idProducto,  titulo=@titulo, archivo=@archivo, tamano=@tamano, tipo=@tipo, nombreoriginal=@nombreoriginal where idProductoArchivo=@idProductoArchivo"
            Dim params As SqlParameter() = { _
          New SqlParameter("@idproducto", idProducto), _
          New SqlParameter("@titulo", titulo), _
          New SqlParameter("@archivo", Archivo), _
          New SqlParameter("@tamano", tamano), _
          New SqlParameter("@tipo", tipo), _
          New SqlParameter("@nombreoriginal", nombreoriginal), _
          New SqlParameter("@idProductoArchivo", idProductoArchivo)}

         
            Return Me.ExecuteNonQuery(sql, params)


        End Function


    

        Public Function Remove() As Integer
            Dim sql As String = "delete ProductosArchivos where idProductoArchivo=@idProductoArchivo"
            Dim params As SqlParameter() = { _
          New SqlParameter("@idProductoArchivo", idProductoArchivo)}


            Dim path As String = System.Configuration.ConfigurationManager.AppSettings("files") & "productos\files\"

            Dim num As Integer = Me.ExecuteNonQuery(sql, params)

            If num > 0 Then
                If File.Exists(path & Me.Archivo) Then
                    File.Delete(path & Me.Archivo)
                End If
          
            End If

            Return num

        End Function

        Public Function GetDS(ByVal claveproducto As Integer) As DataSet
            Dim sql As String = "select * from ProductosArchivos where idproducto=@idProducto"
            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveproducto)}
            Return Me.ExecuteDataSet(sql, params)

        End Function



        
    End Class

End Namespace
