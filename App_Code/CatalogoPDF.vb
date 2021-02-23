


Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms



Namespace tienda

    Public Class CatalogoPDF
        Inherits DBObject

        Public idCatalogoPDF As Integer
        Public titulo As String
        Public nombreArchivo As String
        Public nombreImagen As String
        Public Eliminado As Boolean
        Public sitio As Integer = 1


        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from CatalogosPDF where idCatalogoPDF=@idCatalogoPDF and eliminado=0"

            Dim param As SqlParameter() = {New SqlParameter("@idCatalogoPDF", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idCatalogoPDF = CInt(dr("idCatalogoPDF"))
                Me.titulo = dr("titulo")
                Me.nombreArchivo = dr("nombreArchivo")
                Me.nombreImagen = dr("nombreImagen")
                Me.Eliminado = CBool(dr("Eliminado"))
                If Not Convert.IsDBNull(dr("sitio")) Then
                    Me.sitio = CInt(dr("sitio"))
                End If
                Me.existe = True
            End If
            dr.Close()
        End Sub




        Public Function add() As Integer
            Dim querystring As String = "INSERT INTO CatalogosPDF (titulo, nombreArchivo, nombreImagen, Eliminado, sitio) VALUES (@titulo, @nombreArchivo, @nombreImagen, @Eliminado, @sitio)"

            Dim parameters As SqlParameter() = {
            New SqlParameter("@titulo", Me.titulo),
            New SqlParameter("@nombreArchivo", Me.nombreArchivo),
            New SqlParameter("@nombreImagen", Me.nombreImagen),
            New SqlParameter("@Eliminado", False),
            New SqlParameter("@sitio", Me.sitio)}

            Me.idCatalogoPDF = Me.ExecuteNonQuery(querystring, parameters, True)
            Return 1

        End Function

        Public Function Update() As Integer
            Dim queryString As String = "UPDATE CatalogosPDF SET titulo=@titulo, nombreArchivo=@nombreArchivo, nombreImagen=@nombreImagen, Eliminado=@Eliminado, sitio=@sitio WHERE idCatalogoPDF= @idCatalogoPDF"

            Dim parameters As SqlParameter() = {
            New SqlParameter("@titulo", Me.titulo),
            New SqlParameter("@nombreArchivo", Me.nombreArchivo),
            New SqlParameter("@nombreImagen", Me.nombreImagen),
            New SqlParameter("@Eliminado", Me.Eliminado),
           New SqlParameter("@idCatalogoPDF", Me.idCatalogoPDF),
            New SqlParameter("@sitio", Me.sitio)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function


        Public Function remove() As Integer
            Me.Eliminado = True
            Return Me.Update()

        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select * from CatalogosPDF where Eliminado=0 order by titulo"

            Return Me.ExecuteDataSet(sql, Nothing)
        End Function



        Public Function GetDS(clavesitio As Integer) As DataSet
            Dim sql As String = "select * from CatalogosPDF where sitio=@sitio and Eliminado=0 order by idCatalogoPDF desc"
            Dim parameters As SqlParameter() = {
            New SqlParameter("@sitio", clavesitio)}
            Return Me.ExecuteDataSet(sql, parameters)
        End Function


    End Class
End Namespace
