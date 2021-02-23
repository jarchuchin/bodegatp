Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System
Imports System.Configuration

Namespace tienda
	Public Class ProductoFoto
		Inherits DBObject

#Region "variables globales"
		Public idProductoFoto As Integer
		Public idProducto As Integer
		Public texto As String
		Public tags As String
		Public imagen As String
		Public principal As Boolean
		Public height As Integer
		Public width As Integer
		Public existe As Boolean = False
		Private maxChica As Integer = 160
		Private maxMediana As Integer = 320
		Private maxGrande As Integer = 480
		Private watermarkFileNameG As String = ConfigurationManager.AppSettings("files") & "productos\images\watermarkG.jpg"
		Private watermarkFileNameM As String = ConfigurationManager.AppSettings("files") & "productos\images\watermarkM.jpg"
		Private watermarkFileNameC As String = ConfigurationManager.AppSettings("files") & "productos\images\watermarkC.jpg"
#End Region

#Region "Constructores"
		Sub New()
		End Sub

		Sub New(ByVal claveprincipal As Integer)
			Dim sql As String = "select * from ProductosFotos where idProductoFoto=@idProductoFoto"
			Dim params As SqlParameter() = {New SqlParameter("@idProductoFoto", claveprincipal)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

			If dr.Read Then
				Me.idProductoFoto = CInt(dr("idProductoFoto"))
				Me.idProducto = CInt(dr("idProducto"))
				Me.texto = dr("texto")
				Me.tags = dr("tags")
				Me.imagen = dr("imagen")
				Me.principal = CBool(dr("principal"))
				Me.height = CInt(dr("height"))
				Me.width = CInt(dr("width"))
				Me.existe = True
			End If
			dr.Close()

		End Sub

		Sub New(ByVal claveProducto As Integer, ByVal principal As Boolean)
			Dim sql As String = "select * from ProductosFotos where idProducto=@idProducto and principal=@principal"
			Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveProducto), New SqlParameter("@principal", principal)}
			Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

			If dr.Read Then
				Me.idProductoFoto = CInt(dr("idProductoFoto"))
				Me.idProducto = CInt(dr("idProducto"))
				Me.texto = dr("texto")
				Me.tags = dr("tags")
				Me.imagen = dr("imagen")
				Me.principal = CBool(dr("principal"))
				Me.height = CInt(dr("height"))
				Me.width = CInt(dr("width"))
				Me.existe = True
			End If
			dr.Close()

		End Sub
#End Region

#Region "Acceso general a datos"
		Public Function Add() As Integer
			Dim sql As String = "insert into ProductosFotos (idproducto, texto, tags, imagen, principal, height, width ) values (@idproducto, @texto, @tags, @imagen, @principal,  @height, @width)"
			Dim params As SqlParameter() = { _
			New SqlParameter("@idproducto", idProducto), _
			New SqlParameter("@texto", texto), _
			New SqlParameter("@tags", tags), _
			New SqlParameter("@imagen", imagen), _
			New SqlParameter("@principal", principal), _
			New SqlParameter("@height", height), _
			New SqlParameter("@width", width)}

			If Me.principal Then
				Me.UpdatePrincipal()
			End If

			Me.idProductoFoto = Me.ExecuteNonQuery(sql, params, True)

			Me.existe = True
			Return 1
		End Function

		Public Function Update() As Integer
			Dim sql As String = "update ProductosFotos set idProducto=@idProducto, texto=@texto, tags=@tags, imagen=@imagen, principal=@principal, height=@height, width=@width where idProductoFoto=@idProductoFoto"
			Dim params As SqlParameter() = { _
			New SqlParameter("@idproducto", idProducto), _
			New SqlParameter("@texto", texto), _
			New SqlParameter("@tags", tags), _
			New SqlParameter("@imagen", imagen), _
			New SqlParameter("@principal", principal), _
			New SqlParameter("@idProductoFoto", idProductoFoto), _
			New SqlParameter("@height", height), _
			New SqlParameter("@width", width)}

			If Me.principal Then
				Me.UpdatePrincipal()
			End If

			Return Me.ExecuteNonQuery(sql, params)
		End Function

		Public Function UpdatePrincipal() As Integer
			Dim sql As String = "update ProductosFotos set principal=0 where idProductoFoto=@idProductoFoto"
			Dim params As SqlParameter() = {New SqlParameter("@idProductoFoto", idProductoFoto)}

			Return Me.ExecuteNonQuery(sql, params)
		End Function

		Public Function Remove() As Integer
			Dim sql As String = "delete productosfotos where idproductofoto=@idproductofoto"
			Dim params As SqlParameter() = {New SqlParameter("@idProductoFoto", idProductoFoto)}

			Dim path As String = ConfigurationManager.AppSettings("files") & "productos\images\"
			Dim num As Integer = Me.ExecuteNonQuery(sql, params)

			If num > 0 Then
				If File.Exists(path & "org\" & Me.imagen) Then File.Delete(path & "org\" & Me.imagen)
				If File.Exists(path & "gde\" & Me.imagen) Then File.Delete(path & "gde\" & Me.imagen)
				If File.Exists(path & "med\" & Me.imagen) Then File.Delete(path & "med\" & Me.imagen)
				If File.Exists(path & "ch\" & Me.imagen) Then File.Delete(path & "ch\" & Me.imagen)
			End If

			Return num
		End Function

		Public Function GetDS(ByVal claveproducto As Integer) As DataSet
			Dim sql As String = "select * from productosfotos where idproducto=@idProducto"
			Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveproducto)}

			Return Me.ExecuteDataSet(sql, params)
		End Function
#End Region

		Public Function SaveBulkImagenes() As SortedList
			Dim pathOrg As String = ConfigurationManager.AppSettings("files") & "productos\images\org\"
			Dim pathTemp As String = ConfigurationManager.AppSettings("files") & "productos\images\temp\"
			Dim files As String() = System.IO.Directory.GetFiles(pathTemp)
			Dim resultados As New SortedList

			For Each fileFullName As String In files
				Dim fileName As String = fileFullName.Replace(pathTemp, "")
				Try
					Dim newFileName As String
					Using imagenOriginal As Image = Image.FromFile(fileFullName)
						Dim claveProductoFoto As Integer = AddProductoFoto(fileName, imagenOriginal.Size)
						newFileName = claveProductoFoto & "." & fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower

						SaveCopiasImagenes(imagenOriginal, newFileName)
						imagenOriginal.Dispose()
					End Using

					If System.IO.File.Exists(pathOrg & newFileName) Then
						System.IO.File.Delete(pathOrg & newFileName)
					End If

					System.IO.File.Move(fileFullName, pathOrg & newFileName)
					resultados.Add(fileName, "Saved")

				Catch ex As OutOfMemoryException
					resultados.Add(fileName, "File no valid as image. Not saved")
					System.IO.File.Delete(fileFullName)
				Catch ex As Exception
					resultados.Add(fileName, "Inespecific error. Not saved")
					System.IO.File.Delete(fileFullName)
				End Try

			Next

			Return resultados
		End Function

		Public Function SaveCopiasImagenes(ByVal originalFileName As String) As Integer
			Dim fileOriginal As String = ConfigurationManager.AppSettings("files") & "productos\images\org\" & originalFileName
			Dim bmpOriginal As Bitmap = AddSquareFrame(New Bitmap(fileOriginal))

			Me.SaveCopiaImagen(bmpOriginal, originalFileName, ImgSizes.grande)
			Me.SaveCopiaImagen(bmpOriginal, originalFileName, ImgSizes.mediana)
			Me.SaveCopiaImagen(bmpOriginal, originalFileName, ImgSizes.chica)

			bmpOriginal.Dispose()
		End Function

		Public Function SaveCopiasImagenes(ByVal imagenOriginal As System.Drawing.Image, ByVal originalFileName As String) As Integer
			Dim bmpOriginal As Bitmap = AddSquareFrame(imagenOriginal)

			Me.SaveCopiaImagen(bmpOriginal, originalFileName, ImgSizes.grande)
			Me.SaveCopiaImagen(bmpOriginal, originalFileName, ImgSizes.mediana)
			Me.SaveCopiaImagen(bmpOriginal, originalFileName, ImgSizes.chica)

			bmpOriginal.Dispose()
		End Function

		Private Function SaveCopiaImagen(ByVal imagenOriginal As System.Drawing.Image, ByVal originalFileName As String, ByVal sizeImagen As ImgSizes) As Integer
			Dim WatermarkImage, bmpNueva As Bitmap
			Dim fileNew As String
			Dim maxWidthHeight As Integer
			Dim newSize As Size
			Dim imgFormat As System.Drawing.Imaging.ImageFormat = GetFormat(originalFileName)

			Select Case sizeImagen
				Case ImgSizes.mediana
					fileNew = ConfigurationManager.AppSettings("files") & "productos\images\med\" & originalFileName
					maxWidthHeight = Me.maxMediana
					WatermarkImage = New Bitmap(Me.watermarkFileNameM)
				Case ImgSizes.chica
					fileNew = ConfigurationManager.AppSettings("files") & "productos\images\ch\" & originalFileName
					maxWidthHeight = Me.maxChica
					WatermarkImage = New Bitmap(Me.watermarkFileNameC)
				Case Else
					fileNew = ConfigurationManager.AppSettings("files") & "productos\images\gde\" & originalFileName
					maxWidthHeight = Me.maxGrande
					WatermarkImage = New Bitmap(Me.watermarkFileNameG)
			End Select

			newSize = GetSize(imagenOriginal.Width, imagenOriginal.Height, maxWidthHeight, maxWidthHeight)
			bmpNueva = AddWatermark(imagenOriginal, newSize, WatermarkImage, WatermarkLocation.MiddleCenter)
			bmpNueva.Save(fileNew, imgFormat)

			bmpNueva.Dispose()
			WatermarkImage.Dispose()
		End Function

#Region "Auxiliares para la grabación de imágenes"
		Private Function AddSquareFrame(ByVal imagenOriginal As System.Drawing.Image) As Bitmap
			If imagenOriginal.Width = imagenOriginal.Height Then Return imagenOriginal

			Dim outputImage As Bitmap
			Dim dimensionMayor As Integer
			Dim x, y As Integer
			Dim outputImageEditor As Graphics

			If imagenOriginal.Width > imagenOriginal.Height Then
				dimensionMayor = imagenOriginal.Width
				x = 0
				y = Math.Max(CInt((imagenOriginal.Width - imagenOriginal.Height) / 2) - 1, 0)
			Else
				dimensionMayor = imagenOriginal.Height
				y = 0
				x = Math.Max(CInt((imagenOriginal.Height - imagenOriginal.Width) / 2) - 1, 0)
			End If

			outputImage = New Bitmap(dimensionMayor, dimensionMayor)
			outputImageEditor = Graphics.FromImage(outputImage)
			With outputImageEditor
				.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
				.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
				.FillRectangle(New SolidBrush(Drawing.Color.White), 0, 0, dimensionMayor, dimensionMayor)
				.DrawImage(imagenOriginal, x, y)
				.Dispose()
			End With

			Return outputImage
		End Function

		Private Function AddProductoFoto(ByVal fileName As String, ByVal imgSize As Size) As Integer
			Dim extension As String = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower
			Dim clave As String = fileName.Substring(0, fileName.Length - (extension.Length + 1))

			Dim objProducto As New ProductoIdioma(clave, 1)
			If Not objProducto.existe Then
				objProducto.idFabricante = 0
				objProducto.idPaisOrigen = 0
				objProducto.clave = clave
				objProducto.visitas = 0
				objProducto.ventas = 0
				objProducto.existencia = 0
				objProducto.ventaMinima = 0
				objProducto.descuentoDistribuidor = 0
				objProducto.idFormato = 0
				objProducto.Peso = 0
				objProducto.fecharegistro = Now
				objProducto.fechamodificacion = Now
				objProducto.eliminado = False
				objProducto.Add()

				Dim objProductoIdioma As New tienda.ProductoIdioma(objProducto.idProducto, 1)
				objProductoIdioma.idProducto = objProducto.idProducto
				objProductoIdioma.idIdioma = 1
				objProductoIdioma.nombre = clave
				objProductoIdioma.descripcion = String.Empty
				objProductoIdioma.especificaciones = String.Empty
				objProductoIdioma.tags = String.Empty
				objProductoIdioma.Add()
			Else
				objProducto.fechamodificacion = Now
				objProducto.Update()
			End If

			Dim objProductoFoto As New ProductoFoto(objProducto.idProducto, True)
			If Not objProductoFoto.existe Then
				objProductoFoto.idProducto = objProducto.idProducto
				objProductoFoto.texto = clave
				objProductoFoto.tags = String.Empty
				objProductoFoto.imagen = String.Empty
				objProductoFoto.principal = True
				objProductoFoto.height = imgSize.Height
				objProductoFoto.width = imgSize.Width
				objProductoFoto.Add()

				objProductoFoto.imagen = objProductoFoto.idProductoFoto & "." & extension
				objProductoFoto.Update()
			End If

			Return objProductoFoto.idProductoFoto
		End Function

		Public Shared Function GetSize(ByVal anchoOriginal As Integer, ByVal altoOriginal As Integer, ByVal anchoFinal As Integer, ByVal altoFinal As Integer) As Size
			Dim proporcionAnchos As Double = anchoOriginal / anchoFinal
			Dim proporcionAltos As Double = altoOriginal / altoFinal

			If proporcionAnchos < proporcionAltos Then
				Return New Size(anchoOriginal / proporcionAltos, altoOriginal / proporcionAltos)
			Else
				If proporcionAnchos > proporcionAltos Then
					Return New Size(anchoOriginal / proporcionAnchos, altoOriginal / proporcionAnchos)
				Else
					If proporcionAnchos <> 1 Then
						Return New Size(anchoOriginal / proporcionAnchos, altoOriginal / proporcionAnchos)
					End If
				End If
			End If

			Return New Size(anchoOriginal, altoOriginal)
		End Function

		Private Function GetFormat(ByVal nombreArchivo As String) As Imaging.ImageFormat
			Dim extension As String = nombreArchivo.Substring(nombreArchivo.LastIndexOf(".") + 1).ToLower
			Select Case extension
				Case "bmp"
					Return Imaging.ImageFormat.Bmp
				Case "gif"
					Return Imaging.ImageFormat.Gif
				Case "jpg"
					Return Imaging.ImageFormat.Jpeg
				Case "jpeg"
					Return Imaging.ImageFormat.Jpeg
				Case "png"
					Return Imaging.ImageFormat.Png
				Case Else
					Return Imaging.ImageFormat.Jpeg
			End Select
		End Function

		Private Function AddWatermark(ByVal imagenOriginal As Bitmap, ByVal outputSize As Size, ByRef watermarkImage As Bitmap, ByVal location As WatermarkLocation) As Bitmap
			Dim outputImage As Bitmap
			Dim WatermarkOverlay As Bitmap
			Dim OverlayEditor As Graphics
			Dim StartingX, StartingY, EndX, EndY As Integer
			Dim WatermarkWidth, WatermarkHeight As Integer
			Dim WatermarkPixel, OriginalPixel, NewPixel As System.Drawing.Color
			Dim PixelMultiplier As Single

			outputImage = New Bitmap(imagenOriginal, outputSize)
			WatermarkOverlay = New Bitmap(outputImage.Width, outputImage.Height)
			OverlayEditor = Graphics.FromImage(WatermarkOverlay)
			WatermarkWidth = watermarkImage.Width
			WatermarkHeight = watermarkImage.Height

			Select Case location
				Case WatermarkLocation.TopLeft
					StartingX = 0
					StartingY = 0
				Case WatermarkLocation.TopCenter
					StartingX = Math.Max(CInt((outputImage.Width / 2) - (WatermarkWidth / 2)), 0)
					StartingY = 0
				Case WatermarkLocation.TopRight
					StartingX = Math.Max(CInt(outputImage.Width - WatermarkWidth), 0)
					StartingY = 0
				Case WatermarkLocation.MiddleLeft
					StartingX = 0
					StartingY = Math.Max(CInt((outputImage.Height / 2) - (WatermarkHeight / 2)), 0)
				Case WatermarkLocation.MiddleCenter
					StartingX = Math.Max(CInt((outputImage.Width / 2) - (WatermarkWidth / 2)), 0)
					StartingY = Math.Max(CInt((outputImage.Height / 2) - (WatermarkHeight / 2)), 0)
				Case WatermarkLocation.MiddleRight
					StartingX = Math.Max(CInt(outputImage.Width - WatermarkWidth), 0)
					StartingY = Math.Max(CInt((outputImage.Height / 2) - (WatermarkHeight / 2)), 0)
				Case WatermarkLocation.BottomLeft
					StartingX = 0
					StartingY = Math.Max(CInt(outputImage.Height - WatermarkHeight), 0)
				Case WatermarkLocation.BottomCenter
					StartingX = Math.Max(CInt((outputImage.Width / 2) - (WatermarkWidth / 2)), 0)
					StartingY = Math.Max(CInt(outputImage.Height - WatermarkHeight), 0)
				Case WatermarkLocation.BottomRight
					StartingX = Math.Max(CInt(outputImage.Width - WatermarkWidth), 0)
					StartingY = Math.Max(CInt(outputImage.Height - WatermarkHeight), 0)
			End Select

			StartingX = Math.Max(StartingX - 1, 0)
			StartingY = Math.Max(StartingY - 1, 0)
			EndX = StartingX + WatermarkWidth - 1
			EndY = StartingY + WatermarkHeight - 1

			With OverlayEditor
				.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
				.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
				.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
				.DrawImage(watermarkImage, StartingX, StartingY)
				.Dispose()
			End With

			For pixelXIndex As Integer = StartingX To EndX
				For pixelYIndex = StartingY To EndY
					WatermarkPixel = WatermarkOverlay.GetPixel(pixelXIndex, pixelYIndex)

					If WatermarkPixel.A > 0 Then
						OriginalPixel = outputImage.GetPixel(pixelXIndex, pixelYIndex)
						PixelMultiplier = 1 - CSng(((1 - WatermarkPixel.GetBrightness)) * 0.25)

						NewPixel = System.Drawing.Color.FromArgb(OriginalPixel.A, CInt(OriginalPixel.R * PixelMultiplier), CInt(OriginalPixel.G * PixelMultiplier), CInt(OriginalPixel.B * PixelMultiplier))
						outputImage.SetPixel(pixelXIndex, pixelYIndex, NewPixel)
					End If
				Next
			Next

			WatermarkOverlay.Dispose()
			OverlayEditor.Dispose()

			Return outputImage
		End Function
#End Region

	End Class
End Namespace
