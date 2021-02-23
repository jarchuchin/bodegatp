Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
	Public Class CFDI
		Inherits tienda.DBObject

		Public idCFDI As Integer
		Public idComprobante As Integer
		Public uuid As String
		Public rfcEmisor As String
		Public link As String
		Public textoPipes As String
		Public fechaCreacion As Date
		Public fechaActualizacion As Date
		Public cadenaError As String
		Public cancelado As Boolean
		Public existe As Boolean = False

#Region "Constructores"
		Sub New()
		End Sub

		Sub New(ByVal clave As Integer, tipoClave As tipoParametroCFDI, estadoCancelacion As Boolean)
			Dim queryString As String
			Select Case tipoClave
				Case tipoParametroCFDI.claveComprobante
					queryString = "SELECT TOP 1 * FROM CFDIs WHERE idComprobante=@clave AND cancelado = @cancelado ORDER BY fechaActualizacion DESC"
				Case Else
					queryString = "SELECT * FROM CFDIs WHERE idCFDI=@clave AND cancelado = @cancelado"
			End Select

			Dim parametros As SqlParameter() = {New SqlParameter("@clave", clave), New SqlParameter("@cancelado", estadoCancelacion)}
			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)

			If dr.Read Then
				Me.idCFDI = dr("idCFDI")
				Me.idComprobante = dr("idComprobante")
				Me.uuid = dr("uuid")
				Me.rfcEmisor = dr("rfcEmisor")
				Me.link = dr("link")
				Me.textoPipes = dr("textoPipes")
				Me.fechaCreacion = dr("fechaCreacion")
				Me.fechaActualizacion = dr("fechaActualizacion")
				Me.cadenaError = dr("cadenaError")
				Me.cancelado = dr("cancelado")
				Me.existe = True
			End If
			dr.Close()
		End Sub
#End Region

		Public Function add() As Integer
			Dim queryString As String = "INSERT INTO CFDIs (idComprobante, uuid, rfcEmisor, link, textoPipes, fechaCreacion, fechaActualizacion, cadenaError, " _
				& "cancelado) VALUES (@idComprobante, @uuid, @rfcEmisor, @link, @textoPipes, @fechaCreacion, @fechaActualizacion, @cadenaError, @cancelado)"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idComprobante", Me.idComprobante), _
			 New SqlParameter("@uuid", Me.uuid), _
			 New SqlParameter("@rfcEmisor", Me.rfcEmisor), _
			 New SqlParameter("@link", Me.link), _
			 New SqlParameter("@textoPipes", Me.textoPipes), _
			 New SqlParameter("@fechaCreacion", Me.fechaCreacion), _
			 New SqlParameter("@fechaActualizacion", Me.fechaActualizacion), _
			 New SqlParameter("@cadenaError", Me.cadenaError), _
			 New SqlParameter("@cancelado", Me.cancelado)}

			Me.idCFDI = Me.ExecuteNonQuery(queryString, parametros, True)

			Return 1
		End Function

		Public Function update() As Integer
			Dim queryString As String = "UPDATE CFDIs SET uuid=@uuid, link=@link, fechaActualizacion=@fechaActualizacion WHERE idCFDI=@idCFDI"

			Dim parametros As SqlParameter() = { _
			 New SqlParameter("@idCFDI", Me.idCFDI), _
			 New SqlParameter("@uuid", Me.uuid), _
			 New SqlParameter("@link", Me.link), _
			 New SqlParameter("@fechaActualizacion", Me.fechaActualizacion)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Function cancelar() As Integer
			Dim queryString As String = "UPDATE CFDIs SET fechaActualizacion=@fechaActualizacion, cadenaError=@cadenaError, cancelado=@cancelado WHERE idCFDI=@idCFDI"

			Dim parametros As SqlParameter() = { _
			   New SqlParameter("@idCFDI", Me.idCFDI), _
			   New SqlParameter("@fechaActualizacion", Me.fechaActualizacion), _
			   New SqlParameter("@cadenaError", Me.cadenaError), _
			   New SqlParameter("@cancelado", True)}

			Return Me.ExecuteNonQuery(queryString, parametros)
		End Function

		Public Shared Function getDescripcionesError(pathFile As String) As String
			Dim cadenaInicialError As String = ""
			Dim cadenaFinalError As String = ""

			If Not System.IO.File.Exists(pathFile) Then Return cadenaFinalError

			Dim sr As New System.IO.StreamReader(pathFile)

			Try
				Do While True
					Dim linea As String = sr.ReadLine()
					If IsNothing(linea) Then Exit Do

					cadenaInicialError &= linea
				Loop
			Catch ex As Exception
			End Try
			sr.Close()

			If cadenaInicialError <> "" Then
				Dim arrayLineas As String() = cadenaInicialError.Split("-")
				For i As Integer = 0 To arrayLineas.Length - 1
					Dim numero As Integer = 0
					If i = 0 Then
						Try
							numero = CInt(arrayLineas(i).Substring(7, 4))
						Catch ex As Exception
						End Try
					Else
						Try
							numero = CInt(arrayLineas(i).Substring(0, 4))
						Catch ex As Exception
						End Try
					End If

					If numero > 0 Then
						Dim cadenaErrorTemp As String = getDescripcionError(numero)
						If cadenaErrorTemp <> "" Then
							cadenaFinalError &= getDescripcionError(numero) & "; "
						End If
					End If
				Next
			End If

			Return cadenaFinalError
		End Function

        Public Shared Function hayErrores(pathFile As String) As Boolean
            Return System.IO.File.Exists(pathFile)
        End Function

        Private Shared Function getDescripcionError(codigoError As Integer) As String
            Select Case codigoError
                Case 1001
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' No se encontró el esquema para cfdi versión 3.2 en la carpeta
                Case 1002
                    Return "La serie no debe ser mayor a 25 caracteres"                     ' La serie no debe ser mayor a 25 caracteres
                Case 1003
                    Return "El folio no debe ser mayor a 20 caracteres"                     ' El folio no debe ser mayor a 20 caracteres
                Case 1004
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El noCertificado no debe ser mayor a 20 caracteres
                Case 1005
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El tipo de comprobante no es conocido, solo puede ser ingreso, egreso y traslado
                Case 1006
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El NumCtaPago debe ser de mínimo 4 caracteres
                Case 1007
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo fecha es requerido
                Case 1008
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo formaDePago es requerido
                Case 1009
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo subTotal es requerido
                Case 1010
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El Total es requerido
                Case 1011
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo tipoDeComprobante es requerido
                Case 1012
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo metodoDePago es requerido
                Case 1013
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo LugarExpedicion es requerido
                Case 1014
                    Return "El Emisor es requerido "                        ' El Emisor es requerido 
                Case 1015
                    Return "El Receptor es requerido"                       ' El Receptor es requerido
                Case 1016
                    Return "Los impuestos son requeridos"                       ' Los impuestos son requeridos
                Case 1018
                    Return "El rfc debe tener entre 12 y 13 caracteres"                     ' El rfc debe tener entre 12 y 13 caracteres
                Case 1019
                    Return "El rfc contiene un error"                       ' El rfc contiene un error
                Case 1020
                    Return "El nombre no puede quedar en blanco"                        ' El nombre no puede quedar en blanco
                Case 1021
                    Return "El campo rfc es requerido"                      ' El campo rfc es requerido
                Case 1022
                    Return "El regimen Fiscal del emisor es requerido"                      ' El regimen Fiscal del emisor es requerido
                Case 1023
                    Return "Calle no debe ser mayor a 200 caracteres"                       ' Calle no debe ser mayor a 200 caracteres
                Case 1024
                    Return "El campo Calle es requerido"                        ' El campo Calle es requerido
                Case 1025
                    Return "noExterior no puede estar en blanco"                        ' noExterior no puede estar en blanco
                Case 1026
                    Return "noInterior no puede estar en blanco"                        ' noInterior no puede estar en blanco
                Case 1027
                    Return "colonia no puede estar en blanco"                       ' colonia no puede estar en blanco
                Case 1028
                    Return "localidad no puede estar en blanco"                     ' localidad no puede estar en blanco
                Case 1029
                    Return "referencia no puede estar en blanco"                        ' referencia no puede estar en blanco
                Case 1030
                    Return "municipio no puede estar en blanco"                     ' municipio no puede estar en blanco
                Case 1031
                    Return "estado no puede estar en blanco"                        ' estado no puede estar en blanco
                Case 1032
                    Return "país no puede estar en blanco"                      ' país no puede estar en blanco
                Case 1033
                    Return "codigoPostal no puede estar en blanco"                      ' codigoPostal no puede estar en blanco
                Case 1034
                    Return "codigoPostal debe ser de 5 dígitos"                     ' codigoPostal debe ser de 5 dígitos
                Case 1035
                    Return "El campo municipio es requerido"                        ' El campo municipio es requerido
                Case 1036
                    Return "El campo estado es requerido"                       ' El campo estado es requerido
                Case 1037
                    Return "El campo país es requerido"                     ' El campo país es requerido
                Case 1038
                    Return "El campo codigoPostal es requerido"                     ' El campo codigoPostal es requerido
                Case 1039
                    Return "El impuesto debe ser seleccionado primero"                      ' El impuesto debe ser seleccionado primero
                Case 1040
                    Return "El tipo de impuesto en la retención es requerido"                       ' El tipo de impuesto en la retención es requerido
                Case 1041
                    Return "El tipo de impuesto en el traslado es requerido"                        ' El tipo de impuesto en el traslado es requerido
                Case 1042
                    Return "El campo cantidad es requerido"                     ' El campo cantidad es requerido
                Case 1043
                    Return "El campo unidad es requerido"                       ' El campo unidad es requerido
                Case 1044
                    Return "El campo descripción es requerido"                      ' El campo descripción es requerido
                Case 1045
                    Return "El campo Valor Unitario es requerido"                       ' El campo valorUnitario es requerido
                Case 1046
                    Return "El campo importe es requerido"                      ' El campo importe es requerido
                Case 1047
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' No se encontró el esquema para cfd versión 2.2 en la carpeta
                Case 1048
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' No se encontró el esquema para cfdi versión 3.2 en la carpeta
                Case 1049
                    Return "El comprobante no contiene información"                     ' El comprobante no contiene información
                Case 1050
                    Return "El número es requerido"                     ' Error el número es requerido
                Case 1051
                    Return "Se debe agregar al menos un total de impuestos ya sea retenidos o trasladados"                      ' Error se debe agregar al menos un totalimpuestos ya sea retenidos o trasladados
                Case 1052
                    Return "Error al ingresar los impuestos"                        ' Error al ingresar los impuestos
                Case 1053
                    Return "Error al procesar el comprobante"                       ' Error al procesar el comprobante
                Case 1054
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo noAprobacion es requerido
                Case 1055
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo anoAprobacion es requerido
                Case 1056
                    Return "Es requerido ingresar retenciones o traslados"                      ' Es requerido ingresar retenciones o traslados
                Case 1057
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo nombreAlumno es requerido
                Case 1058
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo CURP es requerido
                Case 1059
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo autRVOE es requerido
                Case 1060
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al generar el complemento iedu
                Case 1061
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' No se encontró el archivo
                Case 1062
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El archivo certificado no se encuentra en la ruta
                Case 1063
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El archivo key no se encuentra en la ruta
                Case 1064
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' No se ha cargado un comprobante previamente
                Case 1065
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al generar el preCFDI
                Case 1066
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al generar la cadena original
                Case 1067
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' No se puede encontrar el certificado
                Case 1068
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error debe especificarse el certificado
                Case 1069
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error en constructor sellador
                Case 1070
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error de validación del XML
                Case 1071
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error validando el XML
                Case 1072
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al desencriptar el sello digital
                Case 1073
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El sello del certificado no es valido
                Case 1074
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El RFC del certificado no coincide con el RFC del comprobante
                Case 1075
                    Return "El Domicilio Fiscal es obligatorio"                     ' El DomicilioFiscal es obligatorio
                Case 1076
                    Return "La fecha del CFDI no está dentro del rango de validez del certificado"                      ' La fecha del CFDI no está dentro del rango de validez del certificado
                Case 1077
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El número de certificado utilizado es diferente al certificado utilizado
                Case 1078
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El certificado utilizado es un certificado tipo FIEL
                Case 1079
                    Return "El Comprobante contiene información de timbrado y no puede ser timbrado nuevamente "                            ' El Comprobante contiene información de timbrado y no puede ser timbrado nuevamente 
                Case 1080
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' La versión del CFDI no es 3.2
                Case 1081
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error en la carga del XML
                Case 1082
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El XML no puede estar vacío
                Case 1083
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al generar el complemento donatarios
                Case 1084
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al generar el complemento Timbre Fiscal Digital
                Case 1085
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' No se pudo cargar el esquema implocal.xsd
                Case 1086
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al generar el complemento impuestos locales
                Case 1087
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al accesar al archivo XML
                Case 1088
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' La fecha del CFD no está dentro del rango de validez del certificado
                Case 1089
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' La versión del CFD no es 2.2
                Case 1090
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' La versión del CFDI no es 3.0
                Case 1091
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al generar el sello
                Case 1092
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' No se puede encontrar el archivo key
                Case 1093
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Debe especificar el archivo KEY
                Case 1094
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El certificado ha caducado
                Case 1095
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El certificado no corresponde al número de serie
                Case 1096
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Error al generar el CFD
                Case 1097
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' No se encontró el esquema para cfdi versión 3.0 en la carpeta
                Case 1098
                    Return "La serie no debe ser mayor a 10 caracteres"                     ' La serie no debe ser mayor a 10 caracteres
                Case 1099
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo sello es requerido
                Case 1100
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo noCertificado es requerido
                Case 1101
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El campo certificado es requerido
                Case 1102
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' Fecha del comprobante fuera de rango
                Case 1103
                    Return "Hay un problema con el sistema de facturación. Contacta al administrador del sistema (código de error: " & codigoError & ")"        ' El comprobante no contiene un certificado y no podrá ser validada la autenticidad del sello, el emisor y su vigencia.
                Case Else
                    Return ""
            End Select
        End Function


	End Class

	Public Enum tipoParametroCFDI As Byte
		clavePrincipal = 0
		claveComprobante = 1
	End Enum
End Namespace