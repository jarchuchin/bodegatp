Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class CategoriaIdioma
        Inherits Categoria

        Public idCategoriaIdioma As Integer
        Public idIdioma As Integer
        Public nombre As String
        Public descripcion As String
        Public nombrearchivo As String
        Public tipoArchivo As Integer
        Public height As Integer
        Public width As Integer
        Public tags As String

        Public metaKeywords As String = ""
        Public metaDescription As String = ""

        Public Shadows existe As Boolean = False

        Sub New()

        End Sub


        Sub New(ByVal claveidCategoria As Integer, ByVal claveIdioma As Integer)
            MyBase.New(claveidCategoria)
            Dim sql As String = "select * from categoriasIdiomas where idCategoria=@idCategoria and idIdioma=@idIdioma"

            Dim params As SqlParameter() = {New SqlParameter("@idCategoria", claveidCategoria), New SqlParameter("@idIdioma", claveIdioma)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idCategoriaIdioma = CInt(dr("idCategoriaIdioma"))
                Me.idCategoria = CInt(dr("idCategoria"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")
                Me.descripcion = dr("descripcion")
                Me.nombrearchivo = dr("nombreArchivo")
                Me.tipoArchivo = CInt(dr("tipoArchivo"))
                Me.height = CInt(dr("height"))
                Me.width = CInt(dr("width"))
                Me.tags = dr("tags")

                If Not Convert.IsDBNull(dr("metaKeywords")) Then
                    Me.metaKeywords = dr("metaKeywords")
                End If
                If Not Convert.IsDBNull(dr("metaDescription")) Then
                    Me.metaDescription = dr("metaDescription")
                End If

                Me.existe = True
            End If

            dr.Close()


        End Sub

        Public Overloads Function Add() As Integer
            Dim sql As String = "insert into CategoriasIdiomas ( idCategoria, idIdioma, nombre, descripcion, nombreArchivo, tipoArchivo, height, width, tags, metaKeywords, metaDescription) values ( @idCategoria, @idIdioma, @nombre, @descripcion, @nombreArchivo, @tipoArchivo, @height, @width, @tags, @metaKeywords, @metaDescription)"
            If Not MyBase.existe Then
                MyBase.Add()
            End If

            Dim params As SqlParameter() = {New SqlParameter("@idCategoria", idCategoria), _
                                            New SqlParameter("@idIdioma", idIdioma), _
                                            New SqlParameter("@nombre", nombre), _
                                            New SqlParameter("@descripcion", descripcion), _
                                            New SqlParameter("@nombreArchivo", nombrearchivo), _
                                            New SqlParameter("@tipoArchivo", tipoArchivo), _
                                            New SqlParameter("@height", height), _
                                            New SqlParameter("@width", width), _
                                            New SqlParameter("@tags", tags), _
                                            New SqlParameter("@metaKeywords", metaKeywords), _
                                            New SqlParameter("@metaDescription", metaDescription)}

            Me.idCategoriaIdioma = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True

            Return 1
        End Function

        Public Overloads Function Update() As Integer
            Dim sql As String = "update CategoriasIdiomas set idcategoria=@idCategoria, idIdioma=@idIdioma, nombre=@nombre, descripcion=@descripcion, nombreArchivo=@nombreArchivo, tipoarchivo=@tipoArchivo, height=@height, width=@width, tags=@tags, metaKeywords=@metaKeywords, metaDescription=@metaDescription where idCategoriaIdioma=@idCategoriaIdioma"
            MyBase.Update()

            Dim params As SqlParameter() = {New SqlParameter("@idCategoria", idCategoria), _
                                              New SqlParameter("@idIdioma", idIdioma), _
                                              New SqlParameter("@nombre", nombre), _
                                              New SqlParameter("@descripcion", descripcion), _
                                              New SqlParameter("@nombreArchivo", nombrearchivo), _
                                              New SqlParameter("@tipoArchivo", tipoArchivo), _
                                              New SqlParameter("@height", height), _
                                              New SqlParameter("@width", width), _
                                            New SqlParameter("@idCategoriaIdioma", idCategoriaIdioma), _
                                            New SqlParameter("@tags", tags), _
                                            New SqlParameter("@metaKeywords", metaKeywords), _
                                            New SqlParameter("@metaDescription", metaDescription)}

            If Me.existe Then
                Me.ExecuteNonQuery(sql, params)
            Else
                Me.nombrearchivo = ""
                Me.Add()
            End If



        End Function

        Public Overloads Function Remove() As Integer
            Return MyBase.Remove()
        End Function

        Public Function GetDS(ByVal claveIdioma As Integer, ByVal claveRaiz As Integer) As DataSet
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre, ci.descripcion, ci.nombrearchivo, ci.tipoArchivo, ci.height, ci.width, ci.tags from categorias c, CategoriasIdiomas ci where c.idCategoria=ci.idCategoria and ci.ididioma = @idIdioma and c.idraiz=@idRaiz and c.eliminado=0 order by ci.nombre"
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idRaiz", claveRaiz)}
            Return Me.ExecuteDataSet(sql, params)

        End Function
        Public Function GetDSNo0() As DataSet
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre, ci.descripcion, ci.nombrearchivo, ci.tipoArchivo, ci.height, ci.width, ci.tags, ci.metaKeywords, ci.metaDescription, r.eliminado as raizeliminada from categorias c, CategoriasIdiomas ci, Categorias r where c.idCategoria=ci.idCategoria and r.idCategoria=c.idRaiz and ci.ididioma = 1 and c.idraiz<>0 and c.eliminado=0 and r.eliminado=0  order by ci.nombre"

            Return Me.ExecuteDataSet(sql, Nothing)

        End Function

        Public Function GetDR(ByVal claveIdioma As Integer, ByVal claveRaiz As Integer) As SqlDataReader
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre, ci.descripcion, ci.nombrearchivo, ci.tipoArchivo, ci.height, ci.width, ci.tags from categorias c, CategoriasIdiomas ci where c.idCategoria=ci.idCategoria and ci.ididioma = @idIdioma and c.idraiz=@idRaiz and c.eliminado=0  order by ci.nombre"
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idRaiz", claveRaiz)}
            Return Me.ExecuteReader(sql, params)

        End Function



        Public Function GetDR(ByVal claveIdioma As Integer, ByVal claveRaizCadena As String) As SqlDataReader
            Dim constructor As String() = claveRaizCadena.Split(",")
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre, ci.descripcion, ci.nombrearchivo, ci.tipoArchivo, ci.height, ci.width, ci.tags from categorias c, CategoriasIdiomas ci where c.idCategoria=ci.idCategoria and ci.ididioma = @idIdioma and c.eliminado=0 and "

            Dim i As Integer = 0
            Dim cadena As String = " ( "
            For i = 0 To constructor.Length - 1
                If i = 0 Then
                    cadena &= " c.idraiz=" & constructor(i).ToString
                Else
                    cadena &= " or c.idraiz=" & constructor(i).ToString
                End If
            Next

            cadena &= ") "
            sql &= cadena & " order by ci.nombre"

            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}
            Return Me.ExecuteReader(sql, params)

        End Function


        Public Function GetCategorias(ByVal claveidioma As Integer) As DataView
            Dim dTable As New DataTable
            dTable.Columns.Add(New DataColumn("idCategoria", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("Nombre", GetType(String)))

            CategoriasRootTitulo(0, dTable, claveidioma, "")

            Dim dView As New DataView(dTable)
            Return dView

        End Function


        Private Function CategoriasRootTitulo(ByVal claveRaiz As Integer, ByRef dtable As DataTable, ByVal claveidioma As Integer, ByVal loctitulo As String) As Integer

            Dim dr As System.Data.SqlClient.SqlDataReader = GetDR(claveidioma, claveRaiz)
            Dim dRow As DataRow
            Dim titulolocal As String = loctitulo
            Dim num As Integer = 0
            While dr.Read
                dRow = dtable.NewRow
                Dim clave As Integer = CInt(dr("idCategoria"))
                dRow(0) = clave
                If loctitulo <> "" Then
                    titulolocal = loctitulo & " > " & dr("Nombre")
                    dRow(1) = titulolocal
                Else
                    titulolocal = dr("Nombre")
                    dRow(1) = dr("Nombre") & " (todas)"
                End If

                num += 1

                dtable.Rows.Add(dRow)
                If CategoriasRootTitulo(CInt(dr("idCategoria")), dtable, claveidioma, titulolocal) = 0 Then
                End If

                titulolocal = ""


            End While

            dr.Close()

            Return num

        End Function



    End Class

End Namespace

