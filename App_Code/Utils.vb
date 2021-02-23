Imports Microsoft.VisualBasic

Namespace tienda
	Public Enum TipoEntidad As Byte
		Producto = 0
		Servicio = 1
		ProductoServicio = 2
	End Enum

	Public Enum TipoArchivos As Byte
		Imagen = 1
		Flash = 2
	End Enum

	Public Enum TipoDato As Byte
		numero = 1
		cadena = 2
		fecha = 3
		falsoverdadero = 4
	End Enum

	Public Enum TipoServicio As Byte
		Serigrafía = 0
		Tampografía = 1
		Grabado = 2
		Bordado = 3
	End Enum

	Public Enum ImgSizes As Byte
		chica = 0
		mediana = 1
		grande = 2
		original = 3
	End Enum

	Public Enum WatermarkType
		TextWatermark = 0
		ImageWatermark = 1
	End Enum

	Public Enum WatermarkLocation
		TopLeft = 0
		TopCenter = 1
		TopRight = 2
		MiddleLeft = 3
		MiddleCenter = 4
		MiddleRight = 5
		BottomLeft = 6
		BottomCenter = 7
		BottomRight = 8
	End Enum

    Public Enum StatusOrden As Byte
        AgregandoProductos = 0
        Enviada = 1
        Revisión = 2
        Autorizada = 3
        Rechazada = 4
        Cancelada = 5
        Pagandose = 6
        Pagada = 7
        Surtiendose = 8
        Surtida = 9
        Archivada = 10
    End Enum

    Public Enum PaginaAnuncio As Byte
        Home = 0
        Categorias = 1
        Eventos = 2
        Promociones = 3
        All = 10
    End Enum

	Public Class Utils

        Public Function depuraTags(ByVal cadenaInicial As String) As String
            If cadenaInicial.Trim = String.Empty Then Return String.Empty

            Dim cadenaTrabajo As String = cadenaInicial
            Dim cadenaFinal As String = String.Empty

            'eliminar espacios y separadores
            If cadenaTrabajo.Contains("%") Then
                cadenaTrabajo = cadenaTrabajo.Replace("%", " ")
            End If
            If cadenaTrabajo.Contains("/") Or cadenaTrabajo.Contains("\") Then
                cadenaTrabajo = cadenaTrabajo.Replace("/", " ")
                cadenaTrabajo = cadenaTrabajo.Replace("\", " ")
            End If
            If cadenaTrabajo.Contains("""") Then
                cadenaTrabajo = cadenaTrabajo.Replace("""", " ")
            End If
            If cadenaTrabajo.Contains("+") Then
                cadenaTrabajo = cadenaTrabajo.Replace("+", "")
            End If
            If cadenaTrabajo.Contains("*") Then
                cadenaTrabajo = cadenaTrabajo.Replace("*", "")
            End If
            If cadenaTrabajo.Contains(":") Then
                cadenaTrabajo = cadenaTrabajo.Replace(":", "")
            End If

            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "[,\.;\-@]+", ",", RegexOptions.IgnoreCase).Trim
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "[ ]+", " ", RegexOptions.IgnoreCase)
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, ",[ ]+", ",", RegexOptions.IgnoreCase).Trim
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "[ ]+,", ",", RegexOptions.IgnoreCase).Trim
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, " ", "@%@", RegexOptions.IgnoreCase)
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "[\s]+", "", RegexOptions.IgnoreCase)
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "@%@", " ", RegexOptions.IgnoreCase)
            Dim i As Integer
            Dim arreglodeEspacios As String() = cadenaTrabajo.Split(" ")
            For i = 0 To arreglodeEspacios.Length - 1
                If i = 0 Then
                    cadenaTrabajo = arreglodeEspacios(i) & " promocionales-promocional"
                Else
                    cadenaTrabajo = cadenaTrabajo & " " & arreglodeEspacios(i)
                End If
            Next

            Dim arregloTags As String() = cadenaTrabajo.Split(",")
            i = arregloTags.Length - 1

            'eliminar las repetidas, cambiando por cadenas vacías
            Do While i >= 0
                If arregloTags(i) <> String.Empty Then

                    For j As Integer = 0 To arregloTags.Length - 1
                        If i <> j And arregloTags(j) <> String.Empty Then
                            If String.Compare(arregloTags(i), arregloTags(j), True) = 0 Then
                                arregloTags(i) = String.Empty
                                Exit For
                            End If
                        End If
                    Next

                End If

                i = i - 1
            Loop

            For i = 0 To arregloTags.Length - 1
                If arregloTags(i) <> String.Empty Then
                    If i = 0 Then
                        cadenaFinal = arregloTags(i)
                    Else
                        cadenaFinal = cadenaFinal & "," & arregloTags(i)
                    End If
                End If
            Next

            Return cadenaFinal
        End Function

        Public Function depuraTags2(ByVal cadenaInicial As String) As String
            If cadenaInicial.Trim = String.Empty Then Return String.Empty

            Dim cadenaTrabajo As String = cadenaInicial
            Dim cadenaFinal As String = String.Empty

            'eliminar espacios y separadores
            If cadenaTrabajo.Contains("%") Then
                cadenaTrabajo = cadenaTrabajo.Replace("%", " ")
            End If
            If cadenaTrabajo.Contains("/") Or cadenaTrabajo.Contains("\") Then
                cadenaTrabajo = cadenaTrabajo.Replace("/", " ")
                cadenaTrabajo = cadenaTrabajo.Replace("\", " ")
            End If
            If cadenaTrabajo.Contains("""") Then
                cadenaTrabajo = cadenaTrabajo.Replace("""", " ")
            End If

            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "[,\.;\-@]+", ",", RegexOptions.IgnoreCase).Trim
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "[ ]+", " ", RegexOptions.IgnoreCase)
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, ",[ ]+", ",", RegexOptions.IgnoreCase).Trim
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "[ ]+,", ",", RegexOptions.IgnoreCase).Trim
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, " ", "@%@", RegexOptions.IgnoreCase)
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "[\s]+", "", RegexOptions.IgnoreCase)
            cadenaTrabajo = Regex.Replace(cadenaTrabajo, "@%@", " ", RegexOptions.IgnoreCase)
            Dim i As Integer
            Dim arreglodeEspacios As String() = cadenaTrabajo.Split(" ")
            For i = 0 To arreglodeEspacios.Length - 1
                If i = 0 Then
                    cadenaTrabajo = arreglodeEspacios(i)
                Else
                    cadenaTrabajo = cadenaTrabajo & " " & arreglodeEspacios(i)
                End If
            Next

            Dim arregloTags As String() = cadenaTrabajo.Split(",")
            i = arregloTags.Length - 1

            'eliminar las repetidas, cambiando por cadenas vacías
            Do While i >= 0
                If arregloTags(i) <> String.Empty Then

                    For j As Integer = 0 To arregloTags.Length - 1
                        If i <> j And arregloTags(j) <> String.Empty Then
                            If String.Compare(arregloTags(i), arregloTags(j), True) = 0 Then
                                arregloTags(i) = String.Empty
                                Exit For
                            End If
                        End If
                    Next

                End If

                i = i - 1
            Loop

            For i = 0 To arregloTags.Length - 1
                If arregloTags(i) <> String.Empty Then
                    If i = 0 Then
                        cadenaFinal = arregloTags(i)
                    Else
                        cadenaFinal = cadenaFinal & "," & arregloTags(i)
                    End If
                End If
            Next

            Return cadenaFinal
        End Function

		Public Shared Function getReturnURL(returnURL As String) As String
			Dim cadena As String = returnURL.Replace("/", "%2f")
			cadena = cadena.Replace("?", "%3f")
			cadena = cadena.Replace("=", "%3d")
			cadena = cadena.Replace("&", "%26")

			Return cadena
		End Function

	End Class
End Namespace