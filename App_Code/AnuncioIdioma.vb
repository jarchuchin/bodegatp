Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing

Namespace tienda

    Public Class AnuncioIdioma
        Inherits Anuncio

        Public idAnuncioIdioma As Integer
        Public idIdioma As Integer
        Public titulo As String
        Public tooltip As String
        Public nombrearchivo As String
        Public tipoArchivo As Integer
        Public height As Integer
        Public width As Integer
        Private maxWidth As Integer = 470
        Public Shadows existe As Boolean = False

        Public ReadOnly Property anchoMaximo() As Integer
            Get
                Return maxWidth
            End Get
        End Property

        Sub New()
        End Sub

        Sub New(ByVal claveidAnuncio As Integer, ByVal claveIdioma As Integer)
            MyBase.New(claveidAnuncio)
            Dim sql As String = "select * from AnunciosIdiomas where idAnuncio=@idAnuncio and idIdioma=@idIdioma"

            Dim params As SqlParameter() = {New SqlParameter("@idAnuncio", claveidAnuncio), New SqlParameter("@idIdioma", claveIdioma)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idAnuncioIdioma = CInt(dr("idAnuncioIdioma"))
                Me.idAnuncio = CInt(dr("idAnuncio"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.titulo = dr("titulo")
                Me.tooltip = dr("tooltip")
                Me.nombrearchivo = dr("nombreArchivo")
                Me.tipoArchivo = CInt(dr("tipoArchivo"))
                Me.height = CInt(dr("height"))
                Me.width = CInt(dr("width"))
                Me.existe = True
            End If
            dr.Close()
        End Sub

        Public Overloads Function Add() As Integer
            Dim sql As String = "insert into AnunciosIdiomas (idAnuncio, idIdioma, titulo, tooltip, nombreArchivo, tipoArchivo, height, width) " _
             & "VALUES (@idAnuncio, @idIdioma, @titulo, @tooltip, @nombreArchivo, @tipoArchivo, @height, @width)"

            If Not MyBase.existe Then
                MyBase.Add()
            End If

            Dim params As SqlParameter() = { _
              New SqlParameter("@idAnuncio", Me.idAnuncio), _
              New SqlParameter("@idIdioma", Me.idIdioma), _
              New SqlParameter("@titulo", Me.titulo), _
              New SqlParameter("@tooltip", Me.tooltip), _
              New SqlParameter("@nombreArchivo", Me.nombrearchivo), _
              New SqlParameter("@tipoArchivo", Me.tipoArchivo), _
              New SqlParameter("@height", Me.height), _
              New SqlParameter("@width", Me.width)}

            Me.idAnuncioIdioma = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True

            Return 1
        End Function

        Public Overloads Function Update() As Integer
            Dim sql As String = "update AnunciosIdiomas set idAnuncio=@idAnuncio, idIdioma=@idIdioma, titulo=@titulo, tooltip=@tooltip, nombreArchivo=@nombreArchivo, tipoarchivo=@tipoArchivo, height=@height, width=@width where idAnuncioIdioma=@idAnuncioIdioma"
            MyBase.Update()

            Dim params As SqlParameter() = {New SqlParameter("@idAnuncio", idAnuncio), _
             New SqlParameter("@idIdioma", idIdioma), _
             New SqlParameter("@titulo", titulo), _
             New SqlParameter("@tooltip", tooltip), _
             New SqlParameter("@nombreArchivo", nombrearchivo), _
             New SqlParameter("@tipoArchivo", tipoArchivo), _
             New SqlParameter("@height", height), _
             New SqlParameter("@width", width), _
              New SqlParameter("@idAnuncioIdioma", idAnuncioIdioma)}

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

        Public Function GetDS(ByVal claveIdioma As Integer) As DataSet
            Dim sql As String = "SELECT a.*, ai.idIdioma, ai.titulo, ai.tooltip, ai.nombrearchivo, ai.tipoArchivo, ai.height, ai.width FROM Anuncios AS a " _
             & "INNER JOIN AnunciosIdiomas AS ai ON a.idAnuncio = ai.idAnuncio WHERE a.Eliminado = 0 AND ai.idIdioma = @idIdioma " _
             & "ORDER BY a.pagina, a.Posicion, a.orden"
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteDataSet(sql, params)
        End Function

        Public Function GetDR(ByVal claveIdioma As Integer) As SqlDataReader
            Dim sql As String = "SELECT a.*, ai.idIdioma, ai.titulo, ai.tooltip, ai.nombrearchivo, ai.tipoArchivo, ai.height, ai.width FROM Anuncios AS a " _
             & "INNER JOIN AnunciosIdiomas AS ai ON a.idAnuncio = ai.idAnuncio WHERE a.Eliminado = 0 AND ai.idIdioma = @idIdioma " _
             & "ORDER BY a.pagina, a.Posicion, a.orden"
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteReader(sql, params)
        End Function

        Public Function GetDS(ByVal claveIdioma As Integer, ByVal paginaUbicacion As PaginaAnuncio) As DataSet
            Dim queryString As String = "SELECT a.*, ai.idIdioma, ai.titulo, ai.tooltip, ai.nombrearchivo, ai.tipoArchivo, ai.height, ai.width FROM Anuncios a, AnunciosIdiomas ai " _
             & "WHERE a.idAnuncio = ai.idAnuncio AND ai.idIdioma = @idIdioma AND a.eliminado = 0 AND a.pagina = @pagina ORDER BY posicion, orden"

            Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@pagina", paginaUbicacion.ToString)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Function GetDR(ByVal claveIdioma As Integer, ByVal paginaUbicacion As PaginaAnuncio) As SqlDataReader
            Dim queryString As String = "SELECT a.*, ai.idIdioma, ai.titulo, ai.tooltip, ai.nombrearchivo, ai.tipoArchivo, ai.height, ai.width FROM Anuncios a, AnunciosIdiomas ai " _
             & "WHERE a.idAnuncio = ai.idAnuncio AND ai.idIdioma = @idIdioma AND a.eliminado = 0 AND a.pagina = @pagina ORDER BY posicion, orden"

            Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@pagina", paginaUbicacion.ToString)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function GetDR(ByVal claveIdioma As Integer, ByVal paginaUbicacion As PaginaAnuncio, ByVal posicionEnPagina As Integer) As SqlDataReader
            Dim queryString As String = "SELECT a.*, a.orden, ai.nombrearchivo, ai.tipoArchivo, ai.height, ai.width, ai.tooltip FROM Anuncios AS a " _
 & "INNER JOIN AnunciosIdiomas AS ai ON a.idAnuncio = ai.idAnuncio WHERE a.pagina = @pagina AND a.Posicion = @posicion AND a.Eliminado = 0 " _
 & "AND ai.idIdioma = @idIdioma ORDER BY a.orden"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@pagina", paginaUbicacion.ToString), _
             New SqlParameter("@posicion", posicionEnPagina), _
             New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function

        Public Function GetDS(ByVal claveIdioma As Integer, ByVal paginaUbicacion As PaginaAnuncio, ByVal posicionEnPagina As Integer) As DataSet
            Dim queryString As String = "SELECT a.*, a.orden, ai.nombrearchivo, ai.tipoArchivo, ai.height, ai.width, ai.tooltip FROM Anuncios AS a " _
 & "INNER JOIN AnunciosIdiomas AS ai ON a.idAnuncio = ai.idAnuncio WHERE a.pagina = @pagina AND a.Posicion = @posicion AND a.Eliminado = 0 " _
 & "AND ai.idIdioma = @idIdioma ORDER BY a.orden"

            Dim parametros As SqlParameter() = { _
             New SqlParameter("@pagina", paginaUbicacion.ToString), _
             New SqlParameter("@posicion", posicionEnPagina), _
             New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Function GetAnunciosEnPagina(ByVal claveIdioma As Integer, ByVal paginaUbicacion As PaginaAnuncio) As DataView
            Dim dTabla As New DataTable
            Dim dRow As DataRow

            dTabla.Columns.Add(New DataColumn("idAnuncio", GetType(Integer)))
            dTabla.Columns.Add(New DataColumn("posicion", GetType(Integer)))
            dTabla.Columns.Add(New DataColumn("orden", GetType(Byte)))
            dTabla.Columns.Add(New DataColumn("nombreArchivo", GetType(String)))

            Dim queryString As String = "SELECT TOP 1 a.idAnuncio, a.posicion, a.orden, ai.nombreArchivo FROM Anuncios a INNER JOIN AnunciosIdiomas ai " _
             & "ON a.idAnuncio = ai.idAnuncio WHERE a.pagina = @pagina AND a.Posicion = 1 AND a.Eliminado = 0 AND ai.idIdioma = @idIdioma ORDER BY orden"

            Dim parametro As SqlParameter() = {New SqlParameter("@pagina", paginaUbicacion.ToString), New SqlParameter("@idIdioma", claveIdioma)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametro)

            dRow = dTabla.NewRow
            If dr.Read Then
                dRow(0) = dr("idAnuncio")
                dRow(3) = dr("nombreArchivo")
            Else
                dRow(0) = 0
                dRow(3) = String.Empty
            End If
            dRow(1) = 1
            dRow(2) = 1
            dTabla.Rows.Add(dRow)
            dr.Close()

            queryString = "SELECT TOP 6 a.idAnuncio, a.posicion, a.orden, ai.nombreArchivo FROM Anuncios a INNER JOIN AnunciosIdiomas ai " _
             & "ON a.idAnuncio = ai.idAnuncio WHERE a.pagina = @pagina AND a.Posicion = 2 AND a.Eliminado = 0 AND ai.idIdioma = @idIdioma ORDER BY orden"
            Dim parametro2 As SqlParameter() = {New SqlParameter("@pagina", paginaUbicacion.ToString), New SqlParameter("@idIdioma", claveIdioma)}

            dr = Me.ExecuteReader(queryString, parametro2)
            Dim counter As Integer = 0
            Do While dr.Read
                dRow = dTabla.NewRow
                dRow(0) = dr("idAnuncio")
                dRow(1) = 2
                dRow(2) = dr("orden")
                dRow(3) = dr("nombreArchivo")
                dTabla.Rows.Add(dRow)
                counter = counter + 1
            Loop
            dr.Close()

            Do While counter < 6
                counter = counter + 1
                dRow = dTabla.NewRow
                dRow(0) = 0
                dRow(1) = 2
                dRow(2) = counter
                dRow(3) = String.Empty
                dTabla.Rows.Add(dRow)
            Loop

            queryString = "SELECT TOP 1 a.idAnuncio, a.posicion, a.orden, ai.nombreArchivo FROM Anuncios a INNER JOIN AnunciosIdiomas ai " _
             & "ON a.idAnuncio = ai.idAnuncio WHERE a.pagina = @pagina AND a.Posicion = 3 AND a.Eliminado = 0 AND ai.idIdioma = @idIdioma ORDER BY orden"
            Dim parametro3 As SqlParameter() = {New SqlParameter("@pagina", paginaUbicacion.ToString), New SqlParameter("@idIdioma", claveIdioma)}

            dr = Me.ExecuteReader(queryString, parametro3)
            dRow = dTabla.NewRow
            If dr.Read Then
                dRow(0) = dr("idAnuncio")
                dRow(3) = dr("nombreArchivo")
            Else
                dRow(0) = 0
                dRow(3) = String.Empty
            End If
            dRow(1) = 3
            dRow(2) = 1
            dTabla.Rows.Add(dRow)
            dr.Close()

            Return New DataView(dTabla)
        End Function

        Public Sub BuildPageThumbnail(ByVal claveIdioma As Integer, ByVal paginaUbicacion As PaginaAnuncio)
            Dim dirPathAnuncios As String = ConfigurationManager.AppSettings("files") & "Anuncios\"
            Dim imgContainer, imgThumb As Bitmap
            Dim grayPen As New Pen(System.Drawing.Color.FromArgb(204, 204, 204), 3)

            Dim dView As DataView = GetAnunciosEnPagina(claveIdioma, paginaUbicacion)
            dView.RowFilter = "posicion = 2"

            Dim ienum As IEnumerator = dView.GetEnumerator

            If paginaUbicacion <> PaginaAnuncio.Categorias Then
                imgContainer = New Bitmap(ConfigurationManager.AppSettings("files") & "AnunciosThumb0_base.jpg")
                Dim g As Graphics = Graphics.FromImage(imgContainer)

                While ienum.MoveNext
                    Dim dRow As DataRowView = CType(ienum.Current, DataRowView)
                    Dim varOrden As Byte = CByte(dRow("orden"))
                    Select Case varOrden
                        Case 1, 2
                            If dRow("nombreArchivo") <> String.Empty Then
                                imgThumb = ResizeImg(New Bitmap(dirPathAnuncios & dRow("nombreArchivo").ToString), 84, 64)
                                g.DrawImage(imgThumb, 4 + ((varOrden - 1) * 88), 40, imgThumb.Width, imgThumb.Height)
                            Else
                                g.DrawRectangle(grayPen, 4 + ((varOrden - 1) * 88), 40, 84, 64)
                            End If
                        Case 3, 4, 5, 6
                            If dRow("nombreArchivo") <> String.Empty Then
                                imgThumb = ResizeImg(New Bitmap(dirPathAnuncios & dRow("nombreArchivo").ToString), 40, 30)
                                g.DrawImage(imgThumb, 4 + ((varOrden - 3) * 44), 110, imgThumb.Width, imgThumb.Height)
                            Else
                                g.DrawRectangle(grayPen, 4 + ((varOrden - 3) * 44), 110, 40, 30)
                            End If
                    End Select
                End While

            Else

                imgContainer = New Bitmap(ConfigurationManager.AppSettings("files") & "AnunciosThumb1_base.jpg")
                Dim g As Graphics = Graphics.FromImage(imgContainer)

                While ienum.MoveNext
                    Dim dRow As DataRowView = CType(ienum.Current, DataRowView)
                    Dim varOrden As Byte = CByte(dRow("orden"))
                    Dim x As Integer = 135 - ((varOrden Mod 2) * 41)
                    Dim y As Integer
                    Select Case varOrden
                        Case 1, 2
                            y = 70
                        Case 3, 4
                            y = 102
                        Case 5, 6
                            y = 134
                    End Select

                    If dRow("nombreArchivo") <> String.Empty Then
                        imgThumb = ResizeImg(New Bitmap(dirPathAnuncios & dRow("nombreArchivo").ToString), 39, 29)
                        g.DrawImage(imgThumb, x, y, imgThumb.Width, imgThumb.Height)
                    Else
                        g.DrawRectangle(grayPen, x, y, 39, 29)
                    End If

                End While

            End If

            imgContainer.Save(ConfigurationManager.AppSettings("files") & "AnunciosThumb" & paginaUbicacion & ".jpg", Imaging.ImageFormat.Jpeg)

            If Not imgThumb Is Nothing Then
                imgThumb.Dispose()
                imgThumb = Nothing
            End If

            imgContainer.Dispose()
            imgContainer = Nothing
        End Sub

        Private Function ResizeImg(ByRef imgOriginal As Bitmap, ByVal nuevoAncho As Integer, ByVal nuevoAlto As Integer) As Bitmap
            Dim proporcionAnchos As Double = imgOriginal.Width / nuevoAncho
            Dim proporcionAltos As Double = imgOriginal.Height / nuevoAlto
            Dim newSize As New Size(imgOriginal.Width, imgOriginal.Height)

            If proporcionAnchos < proporcionAltos Then
                newSize = New Size(imgOriginal.Width / proporcionAltos, imgOriginal.Height / proporcionAltos)
            Else
                If proporcionAnchos > proporcionAltos Then
                    newSize = New Size(imgOriginal.Width / proporcionAnchos, imgOriginal.Height / proporcionAnchos)
                Else
                    If proporcionAnchos <> 1 Then
                        newSize = New Size(imgOriginal.Width / proporcionAnchos, imgOriginal.Height / proporcionAnchos)
                    End If
                End If
            End If

            Dim imgNew As New Bitmap(newSize.Width, newSize.Height)
            Dim g As Graphics = Graphics.FromImage(imgNew)
            g.DrawImage(imgOriginal, 0, 0, imgNew.Width, imgNew.Height)

            Return imgNew
        End Function

    End Class


End Namespace

