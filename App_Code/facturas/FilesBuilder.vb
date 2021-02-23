Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Xml
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.DocumentObjectModel.Shapes
Imports MigraDoc.Rendering
Imports PdfSharp.Pdf
Imports PdfSharp.Drawing


Namespace facturitas

	Public Class FilesBuilder
        Inherits tienda.DBObject

		Public Sub New()
		End Sub

		Public Sub buildXML(ByVal idComprobante As Integer)
			Dim objComprobante As New Comprobante(idComprobante)
			Dim objRFC As New RFC(objComprobante.idRFC)
			Dim objDomicilio As New Domicilio(objRFC.idRFC, tipoDomicilio.fiscal)
			Dim objDomicilioExp As New Domicilio(objComprobante.idDomicilio)
			Dim objRFCReceptor As New RFC(objComprobante.idRFC)
			Dim objDomicilioReceptor As New Domicilio(objComprobante.idDomicilioReceptor)
			Dim dViewConcepto As DataView = New Concepto().GetDS(idComprobante).Tables(0).DefaultView
			Dim dViewRetenciones As DataView = New Retencion().GetDS(idComprobante).Tables(0).DefaultView
			Dim dViewTraslados As DataView = New Traslado().GetDS(idComprobante).Tables(0).DefaultView
            Dim filePath As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "generados\"
            'Dim filePath As String = "D:\Mis docs\My Dropbox\own\projects\Facturitas\sec\files\generados\"
            Dim fileName As String

            Dim fechaActual As DateTime = Date.Now

            fileName = "factura_" & objRFC.rfc & "_" & fechaActual.ToString("yyyyMMMdd") & "_"

			If objComprobante.serie = String.Empty Then
				fileName = fileName & objComprobante.folio
			Else
				fileName = fileName & objComprobante.serie & objComprobante.folio
			End If

            Dim textWriter As XmlTextWriter = New XmlTextWriter(filePath & fileName & ".xml", System.Text.UTF8Encoding.UTF8)

            objComprobante.nameFile = fileName
            objComprobante.fecha = fechaActual
            objComprobante.status = facturitas.status.terminado.ToString


			'crea y graba cadenaPipes y sello
			BuildCadenaPipes(objComprobante, objRFC, objDomicilio, objDomicilioExp, objRFCReceptor, objDomicilioReceptor, dViewConcepto, dViewRetenciones, dViewTraslados)

			textWriter.Formatting = Formatting.Indented
			textWriter.Indentation = 4

			textWriter.WriteStartDocument()

			'Elemento Comprobante
			textWriter.WriteStartElement("Comprobante")

			textWriter.WriteAttributeString("version", objComprobante.version)
			If Not objComprobante.serie = String.Empty Then
				textWriter.WriteAttributeString("serie", objComprobante.serie)	'opcional
			End If
			textWriter.WriteAttributeString("folio", objComprobante.folio)
			textWriter.WriteAttributeString("fecha", objComprobante.fecha.ToString("yyyy-MM-ddThh:mm:ssZ"))
			textWriter.WriteAttributeString("sello", objComprobante.sello)
			textWriter.WriteAttributeString("noAprobacion", objComprobante.noAprobacion)
			textWriter.WriteAttributeString("anoAprobacion", objComprobante.anoAprobacion)
			textWriter.WriteAttributeString("tipoDeComprobante", objComprobante.tipoDeComprobante.ToString)
			textWriter.WriteAttributeString("formaDePago", objComprobante.formaDePago)
			textWriter.WriteAttributeString("noCertificado", objComprobante.noCertificado)
			If Not objComprobante.certificado = String.Empty Then
				textWriter.WriteAttributeString("certificado", objComprobante.certificado)	'opcional
			End If
			If Not objComprobante.condicionesDePago = String.Empty Then
				textWriter.WriteAttributeString("condicionesDePago", objComprobante.condicionesDePago)	'opcional
			End If
			textWriter.WriteAttributeString("subTotal", objComprobante.subTotal.ToString("0.000000"))
			textWriter.WriteAttributeString("descuento", objComprobante.descuento.ToString("0.000000"))	'opcional
			If Not objComprobante.motivoDescuento = String.Empty Then
				textWriter.WriteAttributeString("motivoDescuento", objComprobante.motivoDescuento)	'opcional
			End If
			textWriter.WriteAttributeString("total", objComprobante.total.ToString("0.000000"))
			If Not objComprobante.metodoDePago = String.Empty Then
				textWriter.WriteAttributeString("metodoDePago", objComprobante.metodoDePago)	'opcional
			End If

			textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd")
			textWriter.WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/2")
			textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")

			'	Elemento Emisor
			textWriter.WriteStartElement("Emisor")

			textWriter.WriteAttributeString("rfc", objRFC.rfc)
			textWriter.WriteAttributeString("nombre", objRFC.nombre)

			'		Elemento Domicilio fiscal del Emisor
			textWriter.WriteStartElement("DomicilioFiscal")
			textWriter.WriteAttributeString("calle", objDomicilio.calle)
			If Not objDomicilio.noExterior = String.Empty Then
				textWriter.WriteAttributeString("noInterior", objDomicilio.noExterior)	'opcional
			End If
			If Not objDomicilio.noInterior = String.Empty Then
				textWriter.WriteAttributeString("noInterior", objDomicilio.noInterior)	'opcional
			End If
			If Not objDomicilio.colonia = String.Empty Then
				textWriter.WriteAttributeString("colonia", objDomicilio.colonia)	'opcional
			End If
			If Not objDomicilio.localidad = String.Empty Then
				textWriter.WriteAttributeString("localidad", objDomicilio.localidad)	'opcional
			End If
			If Not objDomicilio.referencia = String.Empty Then
				textWriter.WriteAttributeString("referencia", objDomicilio.referencia)	'opcional
			End If
			textWriter.WriteAttributeString("municipio", objDomicilio.municipio)
			textWriter.WriteAttributeString("estado", objDomicilio.estado)
			textWriter.WriteAttributeString("pais", objDomicilio.pais)
			textWriter.WriteAttributeString("codigoPostal", objDomicilio.codigoPostal)
			textWriter.WriteEndElement()
			'		Fin elemento Domicilio fiscal del Emisor

			'		Elemento Domicilio de expedicion del Emisor
			If objComprobante.idDomicilio <> objDomicilio.idDomicilio Then	'hay domicilio de expedicion
				textWriter.WriteStartElement("ExpedidoEn")
				If Not objDomicilioExp.calle = String.Empty Then
					textWriter.WriteAttributeString("calle", objDomicilioExp.calle)	'opcional
				End If
				If Not objDomicilioExp.noExterior = String.Empty Then
					textWriter.WriteAttributeString("noExterior", objDomicilioExp.noExterior)	'opcional
				End If
				If Not objDomicilioExp.noInterior = String.Empty Then
					textWriter.WriteAttributeString("noInterior", objDomicilioExp.noInterior)	'opcional
				End If
				If Not objDomicilioExp.colonia = String.Empty Then
					textWriter.WriteAttributeString("colonia", objDomicilioExp.colonia)	'opcional
				End If
				If Not objDomicilioExp.localidad = String.Empty Then
					textWriter.WriteAttributeString("localidad", objDomicilioExp.localidad)	'opcional
				End If
				If Not objDomicilioExp.referencia = String.Empty Then
					textWriter.WriteAttributeString("referencia", objDomicilioExp.referencia)	'opcional
				End If
				If Not objDomicilioExp.municipio = String.Empty Then
					textWriter.WriteAttributeString("municipio", objDomicilioExp.municipio)	'opcional
				End If
				If Not objDomicilioExp.estado = String.Empty Then
					textWriter.WriteAttributeString("estado", objDomicilioExp.estado) 'opcional
				End If
				textWriter.WriteAttributeString("pais", objDomicilioExp.pais)
				If Not objDomicilioExp.codigoPostal = String.Empty Then
					textWriter.WriteAttributeString("codigoPostal", objDomicilioExp.codigoPostal) 'opcional
				End If

				textWriter.WriteEndElement()
			End If
			'		Fin elemento Domicilio de expedicion del Emisor

			textWriter.WriteEndElement()
			'	FIn elemento Emisor

			'	Elemento Receptor
			textWriter.WriteStartElement("Receptor")
			textWriter.WriteAttributeString("rfc", objRFCReceptor.rfc)
			If Not objRFCReceptor.nombre = String.Empty Then
				textWriter.WriteAttributeString("nombre", objRFCReceptor.nombre) 'opcional
			End If

			'		Elemento Domicilio del Receptor
			textWriter.WriteStartElement("Domicilio")
			If Not objDomicilioReceptor.calle = String.Empty Then
				textWriter.WriteAttributeString("calle", objDomicilioReceptor.calle) 'opcional
			End If
			If Not objDomicilioReceptor.noExterior = String.Empty Then
				textWriter.WriteAttributeString("noExterior", objDomicilioReceptor.noExterior)	'opcional
			End If
			If Not objDomicilioReceptor.noInterior = String.Empty Then
				textWriter.WriteAttributeString("noInterior", objDomicilioReceptor.noInterior)	'opcional
			End If
			If Not objDomicilioReceptor.colonia = String.Empty Then
				textWriter.WriteAttributeString("colonia", objDomicilioReceptor.colonia)	'opcional
			End If
			If Not objDomicilioReceptor.localidad = String.Empty Then
				textWriter.WriteAttributeString("localidad", objDomicilioReceptor.localidad)	'opcional
			End If
			If Not objDomicilioReceptor.referencia = String.Empty Then
				textWriter.WriteAttributeString("referencia", objDomicilioReceptor.referencia)	'opcional
			End If
			If Not objDomicilioReceptor.municipio = String.Empty Then
				textWriter.WriteAttributeString("municipio", objDomicilioReceptor.municipio) 'opcional
			End If
			If Not objDomicilioReceptor.estado = String.Empty Then
				textWriter.WriteAttributeString("estado", objDomicilioReceptor.estado) 'opcional
			End If
			textWriter.WriteAttributeString("pais", objDomicilioReceptor.pais)
			If Not objDomicilioReceptor.codigoPostal = String.Empty Then
				textWriter.WriteAttributeString("codigoPostal", objDomicilioReceptor.codigoPostal) 'opcional
			End If

			textWriter.WriteEndElement()
			'		Fin elemento Domicilio del Receptor
			textWriter.WriteEndElement()
			'	FIn elemento Receptor

			'	Elemento Conceptos
			textWriter.WriteStartElement("Conceptos")

			Dim ienum As IEnumerator = dViewConcepto.GetEnumerator
			Do While ienum.MoveNext
				Dim dRowView As DataRowView = CType(ienum.Current, DataRowView)
				Dim idConcepto As Integer = CInt(dRowView("idConcepto"))

				'		Elemento Concepto
				textWriter.WriteStartElement("Concepto")
				textWriter.WriteAttributeString("cantidad", dRowView("cantidad").ToString)
				If Not dRowView("unidad").ToString = String.Empty Then
					textWriter.WriteAttributeString("unidad", dRowView("unidad").ToString)	'opcional
				End If
				If Not dRowView("noIdentificacion").ToString = String.Empty Then
					textWriter.WriteAttributeString("noIdentificacion", dRowView("noIdentificacion").ToString)	'opcional
				End If
				textWriter.WriteAttributeString("descripcion", dRowView("descripcion").ToString)
				textWriter.WriteAttributeString("valorUnitario", dRowView("valorUnitario").ToString("0.000000"))
				textWriter.WriteAttributeString("importe", dRowView("importe").ToString("0.000000"))

				Select Case dRowView("tipoDatoAnexo")
					Case "aduanera"
						Dim dViewIAux As DataView = New InformacionAduanera().GetDS(idConcepto, tipoObjeto.concepto).Tables(0).DefaultView
						Dim ienumAux As IEnumerator = dViewIAux.GetEnumerator

						'			Elementos InformacionAduanera
						Do While ienumAux.MoveNext
							Dim dRowViewAux As DataRowView = CType(ienumAux.Current, DataRowView)
							textWriter.WriteStartElement("InformacionAduanera")
							textWriter.WriteAttributeString("numero", dRowViewAux("numero").ToString)
							textWriter.WriteAttributeString("fecha", CDate(dRowViewAux("fecha")).ToString("yyyy-MM-dd"))
							textWriter.WriteAttributeString("aduana", dRowViewAux("aduana").ToString)
							textWriter.WriteEndElement()
						Loop
						'			Fin elementos InformacionAduanera

					Case "predial"
						'			Elemento CuentaPredial
						textWriter.WriteStartElement("CuentaPredial")
						textWriter.WriteAttributeString("numero", dRowView("cuentaPredial").ToString)
						textWriter.WriteEndElement()
						'			Fin elemento CuentaPredial

					Case "complemento"
						' por definir por el SAT

					Case "parte"
						Dim dViewIAux As DataView = New Parte().GetDS(idConcepto).Tables(0).DefaultView
						Dim ienumAux As IEnumerator = dViewIAux.GetEnumerator

						'			Elementos Parte
						Do While ienumAux.MoveNext
							Dim dRowViewAux As DataRowView = CType(ienumAux.Current, DataRowView)
							Dim idParte As Integer = CInt(dRowViewAux("idParte"))

							textWriter.WriteStartElement("Parte")
							textWriter.WriteAttributeString("cantidad", dRowViewAux("cantidad"))
							If Not dRowViewAux("unidad").ToString = String.Empty Then
								textWriter.WriteAttributeString("unidad", dRowViewAux("unidad"))	'opcional
							End If
							If Not dRowViewAux("noIdentificacion").ToString = String.Empty Then
								textWriter.WriteAttributeString("noIdentificacion", dRowViewAux("noIdentificacion"))	'opcional
							End If
							textWriter.WriteAttributeString("descripcion", dRowViewAux("descripcion"))
							If CDec(dRowViewAux("valorUnitario")) <> 0 Then
								textWriter.WriteAttributeString("valorUnitario", dRowViewAux("valorUnitario").ToString("0.000000"))	'opcional
							End If
							If CDec(dRowViewAux("importe")) <> 0 Then
								textWriter.WriteAttributeString("importe", dRowViewAux("importe").ToString("0.000000"))	'opcional
							End If

							If CBool(dRowViewAux("informacionAduanera")) Then
								Dim dViewIAux2 As DataView = New InformacionAduanera().GetDS(idParte, tipoObjeto.parte).Tables(0).DefaultView
								Dim ienumAux2 As IEnumerator = dViewIAux2.GetEnumerator

								'			Elementos InformacionAduanera
								Do While ienumAux2.MoveNext
									Dim dRowViewAux2 As DataRowView = CType(ienumAux2.Current, DataRowView)
									textWriter.WriteStartElement("InformacionAduanera")
									textWriter.WriteAttributeString("numero", dRowViewAux2("numero").ToString)
									textWriter.WriteAttributeString("fecha", dRowViewAux2("fecha").ToString("yyyy-MM-dd"))
									textWriter.WriteAttributeString("aduana", dRowViewAux2("aduana").ToString)
									textWriter.WriteEndElement()
								Loop
								'			Fin elementos InformacionAduanera

							End If

							textWriter.WriteEndElement()
						Loop
						'			Fin elementos Parte

				End Select


				textWriter.WriteEndElement()
				'		Fin elemento Concepto
			Loop

			textWriter.WriteEndElement()
			'	Fin elemento Conceptos

			'	Elemento Impuestos
			textWriter.WriteStartElement("Impuestos")
			textWriter.WriteAttributeString("totalImpuestosRetenidos", objComprobante.totalImpuestosRetenidos.ToString("0.000000"))
			textWriter.WriteAttributeString("totalImpuestosTrasladados", objComprobante.totalImpuestosTrasladados.ToString("0.000000"))

			If dViewRetenciones.Count > 0 Then
				Dim ienumRetencion As IEnumerator = dViewRetenciones.GetEnumerator

				'		Elemento Retenciones
				textWriter.WriteStartElement("Retenciones")

				'			Elementos Retencion
				Do While ienumRetencion.MoveNext
					Dim dRowViewRetencion As DataRowView = CType(ienumRetencion.Current, DataRowView)
					textWriter.WriteStartElement("Retencion")
					textWriter.WriteAttributeString("impuesto", dRowViewRetencion("impuesto"))
					textWriter.WriteAttributeString("importe", dRowViewRetencion("importe").ToString("0.000000"))
					textWriter.WriteEndElement()
				Loop
				'			Fin elementos Retencion

				textWriter.WriteEndElement()
				'		Fin elemento Retenciones
			End If

			If dViewTraslados.Count > 0 Then
				Dim ienumTraslado As IEnumerator = dViewTraslados.GetEnumerator

				'		Elemento Traslados
				textWriter.WriteStartElement("Traslados")

				'			Elementos Traslado
				Do While ienumTraslado.MoveNext
					Dim dRowViewTraslado As DataRowView = CType(ienumTraslado.Current, DataRowView)
					textWriter.WriteStartElement("Traslado")
					textWriter.WriteAttributeString("impuesto", dRowViewTraslado("impuesto"))
					textWriter.WriteAttributeString("tasa", dRowViewTraslado("tasa").ToString("0.000000"))
					textWriter.WriteAttributeString("importe", dRowViewTraslado("importe").ToString("0.000000"))
					textWriter.WriteEndElement()
				Loop
				'			Fin elementos Traslado

				textWriter.WriteEndElement()
				'		Fin elemento Traslados
			End If


			textWriter.WriteEndElement()
			'	Fin elemento Impuestos

			'	Elemento Complemento
			textWriter.WriteStartElement("Complemento")
			textWriter.WriteEndElement()
			'	Fin elemento Complemento

			'	Elemento Addenda
			textWriter.WriteStartElement("Addenda")
			textWriter.WriteEndElement()
			'	Fin elemento Addenda

			textWriter.WriteEndElement()
			'Fin elemento Comprobante

			textWriter.WriteEndDocument()
			textWriter.Close()
		End Sub

		Private Sub BuildCadenaPipes(ByRef objComprobante As Comprobante, ByRef objRFC As RFC, ByVal objDomicilio As Domicilio, _
		 ByVal objDomicilioExp As Domicilio, ByVal objRFCReceptor As RFC, ByVal objDomicilioReceptor As Domicilio, _
		 ByVal dViewConcepto As DataView, ByVal dViewRetenciones As DataView, ByVal dViewTraslados As DataView)

			Dim cadenaPipes As String = "||"

			'Comprobante
			cadenaPipes = cadenaPipes & objComprobante.version & "|"
			If Not objComprobante.serie = String.Empty Then
				cadenaPipes = cadenaPipes & objComprobante.serie & "|"
			End If
			cadenaPipes = cadenaPipes & objComprobante.folio & "|"
			cadenaPipes = cadenaPipes & objComprobante.fecha.ToString("dd-MM-yyyyThh:mm:ss") & "|"
			cadenaPipes = cadenaPipes & objComprobante.noAprobacion & "|"
			cadenaPipes = cadenaPipes & objComprobante.anoAprobacion & "|"
			cadenaPipes = cadenaPipes & objComprobante.tipoDeComprobante.ToString & "|"
			cadenaPipes = cadenaPipes & objComprobante.anoAprobacion & "|"
			If Not objComprobante.condicionesDePago = String.Empty Then
				cadenaPipes = cadenaPipes & objComprobante.condicionesDePago & "|"
			End If
			cadenaPipes = cadenaPipes & objComprobante.subTotal.ToString("0.00") & "|"
			cadenaPipes = cadenaPipes & objComprobante.descuento.ToString("0.00") & "|"
			cadenaPipes = cadenaPipes & objComprobante.total.ToString("0.00") & "|"

			'Emisor
			cadenaPipes = cadenaPipes & objRFC.rfc & "|"
			cadenaPipes = cadenaPipes & objRFC.rfc & "|"

			'Domicilio fiscal del Emisor
			cadenaPipes = cadenaPipes & objDomicilio.calle & "|"

			If Not objDomicilio.noExterior = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilio.noExterior & "|"
			End If
			If Not objDomicilio.noInterior = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilio.noInterior & "|"
			End If
			If Not objDomicilio.colonia = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilio.colonia & "|"
			End If
			If Not objDomicilio.localidad = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilio.localidad & "|"
			End If
			If Not objDomicilio.referencia = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilio.referencia & "|"
			End If
			cadenaPipes = cadenaPipes & objDomicilio.municipio & "|"
			cadenaPipes = cadenaPipes & objDomicilio.estado & "|"
			cadenaPipes = cadenaPipes & objDomicilio.pais & "|"
			cadenaPipes = cadenaPipes & objDomicilio.codigoPostal & "|"

			'Domicilio expedicion
			If objComprobante.idDomicilio <> objDomicilio.idDomicilio Then
				If Not objDomicilioExp.calle = String.Empty Then
					cadenaPipes = cadenaPipes & objDomicilioExp.calle & "|"
				End If
				If Not objDomicilioExp.noExterior = String.Empty Then
					cadenaPipes = cadenaPipes & objDomicilioExp.noExterior & "|"
				End If
				If Not objDomicilioExp.noInterior = String.Empty Then
					cadenaPipes = cadenaPipes & objDomicilioExp.noInterior & "|"
				End If
				If Not objDomicilioExp.colonia = String.Empty Then
					cadenaPipes = cadenaPipes & objDomicilioExp.colonia & "|"
				End If
				If Not objDomicilioExp.localidad = String.Empty Then
					cadenaPipes = cadenaPipes & objDomicilioExp.localidad & "|"
				End If
				If Not objDomicilioExp.referencia = String.Empty Then
					cadenaPipes = cadenaPipes & objDomicilioExp.referencia & "|"
				End If
				If Not objDomicilioExp.municipio = String.Empty Then
					cadenaPipes = cadenaPipes & objDomicilioExp.municipio & "|"
				End If
				If Not objDomicilioExp.estado = String.Empty Then
					cadenaPipes = cadenaPipes & objDomicilioExp.estado & "|"
				End If
				cadenaPipes = cadenaPipes & objDomicilioExp.pais & "|"
				If Not objDomicilioExp.codigoPostal = String.Empty Then
					cadenaPipes = cadenaPipes & objDomicilioExp.codigoPostal & "|"
				End If
			End If

			'Receptor
			cadenaPipes = cadenaPipes & objRFCReceptor.rfc & "|"
			If Not objRFCReceptor.nombre = String.Empty Then
				cadenaPipes = cadenaPipes & objRFCReceptor.nombre & "|"
			End If

			'Domicilio del Receptor
			If Not objDomicilioReceptor.calle = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilioReceptor.calle & "|"
			End If
			If Not objDomicilioReceptor.noExterior = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilioReceptor.noExterior & "|"
			End If
			If Not objDomicilioReceptor.noInterior = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilioReceptor.noInterior & "|"
			End If
			If Not objDomicilioReceptor.colonia = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilioReceptor.colonia & "|"
			End If
			If Not objDomicilioReceptor.localidad = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilioReceptor.localidad & "|"
			End If
			If Not objDomicilioReceptor.referencia = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilioReceptor.referencia & "|"
			End If
			If Not objDomicilioReceptor.municipio = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilioReceptor.municipio & "|"
			End If
			If Not objDomicilioReceptor.estado = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilioReceptor.estado & "|"
			End If
			cadenaPipes = cadenaPipes & objDomicilioReceptor.pais & "|"
			If Not objDomicilioReceptor.codigoPostal = String.Empty Then
				cadenaPipes = cadenaPipes & objDomicilioReceptor.codigoPostal & "|"
			End If

			'Elemento Conceptos
			Dim ienumConcepto As IEnumerator = dViewConcepto.GetEnumerator
			Do While ienumConcepto.MoveNext
				Dim dRowView As DataRowView = CType(ienumConcepto.Current, DataRowView)
				Dim idConcepto As Integer = CInt(dRowView("idConcepto"))

				cadenaPipes = cadenaPipes & dRowView("cantidad").ToString & "|"
				If Not dRowView("unidad").ToString = String.Empty Then
					cadenaPipes = cadenaPipes & dRowView("unidad").ToString & "|"
				End If
				If Not dRowView("noIdentificacion").ToString = String.Empty Then
					cadenaPipes = cadenaPipes & dRowView("noIdentificacion").ToString & "|"
				End If
				cadenaPipes = cadenaPipes & dRowView("descripcion").ToString & "|"
				cadenaPipes = cadenaPipes & dRowView("valorUnitario").ToString("0.00") & "|"
				cadenaPipes = cadenaPipes & dRowView("importe").ToString("0.00") & "|"

				Select Case dRowView("tipoDatoAnexo")
					Case "aduanera"

						'InformacionAduanera
						Dim dViewAduanera As DataView = New InformacionAduanera().GetDS(idConcepto, tipoObjeto.concepto).Tables(0).DefaultView
						Dim ienumAduanera As IEnumerator = dViewAduanera.GetEnumerator

						Do While ienumAduanera.MoveNext
							Dim dRowViewAux As DataRowView = CType(ienumAduanera.Current, DataRowView)
							cadenaPipes = cadenaPipes & dRowViewAux("numero").ToString & "|"
							cadenaPipes = cadenaPipes & CDate(dRowViewAux("fecha")).ToString("yyyy-MM-dd") & "|"
							cadenaPipes = cadenaPipes & dRowViewAux("aduana").ToString & "|"
						Loop

					Case "predial"
						'CuentaPredial
						cadenaPipes = cadenaPipes & dRowView("cuentaPredial").ToString & "|"

					Case "complemento"
						' por definir por el SAT

					Case "parte"

						'Parte
						Dim dViewParte As DataView = New Parte().GetDS(idConcepto).Tables(0).DefaultView
						Dim ienumParte As IEnumerator = dViewParte.GetEnumerator

						Do While ienumParte.MoveNext
							Dim dRowViewAux As DataRowView = CType(ienumParte.Current, DataRowView)
							Dim idParte As Integer = CInt(dRowViewAux("idParte"))

							cadenaPipes = cadenaPipes & dRowViewAux("cantidad").ToString & "|"
							If Not dRowViewAux("unidad").ToString = String.Empty Then
								cadenaPipes = cadenaPipes & dRowViewAux("unidad").ToString & "|"
							End If
							If Not dRowViewAux("noIdentificacion").ToString = String.Empty Then
								cadenaPipes = cadenaPipes & dRowViewAux("noIdentificacion").ToString & "|"
							End If
							cadenaPipes = cadenaPipes & dRowViewAux("descripcion").ToString & "|"
							If CDec(dRowViewAux("valorUnitario")) <> 0 Then
								cadenaPipes = cadenaPipes & dRowViewAux("valorUnitario").ToString("0.00") & "|"
							End If
							If CDec(dRowViewAux("importe")) <> 0 Then
								cadenaPipes = cadenaPipes & dRowViewAux("importe").ToString("0.00") & "|"
							End If

							If CBool(dRowViewAux("informacionAduanera")) Then

								'InformacionAduanera
								Dim dViewAduanera As DataView = New InformacionAduanera().GetDS(idParte, tipoObjeto.parte).Tables(0).DefaultView
								Dim ienumAduanera As IEnumerator = dViewAduanera.GetEnumerator

								Do While ienumAduanera.MoveNext
									Dim dRowViewAux2 As DataRowView = CType(ienumAduanera.Current, DataRowView)
									cadenaPipes = cadenaPipes & dRowViewAux2("numero").ToString & "|"
									cadenaPipes = cadenaPipes & CDate(dRowViewAux2("fecha")).ToString("yyyy-MM-dd") & "|"
									cadenaPipes = cadenaPipes & dRowViewAux2("aduana").ToString & "|"
								Loop
							End If

						Loop
				End Select

			Loop

			'Retenciones
			If dViewRetenciones.Count > 0 Then
				Dim ienumRetencion As IEnumerator = dViewRetenciones.GetEnumerator
				Do While ienumRetencion.MoveNext
					Dim dRowViewRetencion As DataRowView = CType(ienumRetencion.Current, DataRowView)
					cadenaPipes = cadenaPipes & dRowViewRetencion("impuesto").ToString & "|"
					cadenaPipes = cadenaPipes & dRowViewRetencion("importe").ToString("0.000000") & "|"
				Loop
				cadenaPipes = cadenaPipes & objComprobante.totalImpuestosRetenidos.ToString("0.000000") & "|"
			End If

			'Traslados
			If dViewTraslados.Count > 0 Then
				Dim ienumTraslado As IEnumerator = dViewTraslados.GetEnumerator
				Do While ienumTraslado.MoveNext
					Dim dRowViewTraslado As DataRowView = CType(ienumTraslado.Current, DataRowView)
					cadenaPipes = cadenaPipes & dRowViewTraslado("impuesto").ToString & "|"
					cadenaPipes = cadenaPipes & dRowViewTraslado("tasa").ToString("0.000000") & "|"
					cadenaPipes = cadenaPipes & dRowViewTraslado("importe").ToString("0.000000") & "|"
				Loop
				cadenaPipes = cadenaPipes & objComprobante.totalImpuestosTrasladados.ToString("0.000000") & "|"
			End If

			cadenaPipes = cadenaPipes & "|"

			objComprobante.cadenaPipes = cadenaPipes
            objComprobante.sello = GeneraSello(objComprobante.cadenaPipes)
            objComprobante.Update()
		End Sub

#Region "cripto"
		Private Function GeneraSello(ByVal cadenaPipes As String) As String
			Dim objSHA1 As New System.Security.Cryptography.SHA1CryptoServiceProvider
			Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(cadenaPipes)
			Dim cadenaReturn As String = String.Empty

			bytesToHash = objSHA1.ComputeHash(bytesToHash)
			For Each b As Byte In bytesToHash
				cadenaReturn += b.ToString("x2")
			Next

			Return cadenaReturn
		End Function
#End Region


		Public Sub Buildpdf(ByVal idComprobante As Integer)
			Dim objComprobante As New Comprobante(idComprobante)
			Dim objRFC As New RFC(objComprobante.idRFC)
			Dim objDomicilio As New Domicilio(objRFC.idRFC, tipoDomicilio.fiscal.ToString)
			Dim dViewConcepto As DataView = New Concepto().GetDS(idComprobante).Tables(0).DefaultView
            Dim filePath As String = System.Configuration.ConfigurationManager.AppSettings("carpetaArchivos") & "generados\"
            'Dim filePath As String = "D:\Mis docs\My Dropbox\own\projects\testFiles\"
			Dim fileName As String
			Dim fechaActual As DateTime = Date.Now

			Dim documento As PdfDocument = CrearDocumento(idComprobante)		'Contenedor principal, el PDF document
			Dim doc As Document = New Document		'Contenedor lógico principal
			Dim sec As Section = doc.AddSection()			'Sección única de doc donde se agregan las tablas para textos e imágenes
			Dim listaTablasConceptos As New List(Of MigraDoc.DocumentObjectModel.Tables.Table)()
			Dim cantidadRenglones As Integer = dViewConcepto.Count
			Dim entrePrimero As Boolean = False

			fileName = filePath & "factura_" & objRFC.rfc & "_" & fechaActual.ToString("yyyyMMMdd") & "_"
			If objComprobante.serie = String.Empty Then
				fileName = fileName & objComprobante.folio & ".pdf"
			Else
				fileName = fileName & objComprobante.serie & objComprobante.folio & ".pdf"
			End If

			'se imprime tantas tablas de conceptos como páginas tendrá el documento final
			LlenarListaTablaConceptos(dViewConcepto.Count, sec, listaTablasConceptos, idComprobante, entrePrimero)

			'Agregar tablas para el resto de zonas de datos: logo, rfc, folios, etc
			Dim tablaDatos As MigraDoc.DocumentObjectModel.Tables.Table = AgregarDatosGenerales(sec, objComprobante, objRFC, objDomicilio)

			Dim tablasDatosReceptor As New List(Of MigraDoc.DocumentObjectModel.Tables.Table)()
			tablasDatosReceptor.Add(AgregarDatosReceptor(New RFC(objComprobante.idRFCReceptor), sec.AddTable))
			Dim tablasTotales As New List(Of MigraDoc.DocumentObjectModel.Tables.Table)()
			tablasTotales.Add(AgegarTotales(objComprobante, sec.AddTable))
			Dim tablasFooter As New List(Of MigraDoc.DocumentObjectModel.Tables.Table)()
			tablasFooter.Add(AgregarFooter(objComprobante, sec.AddTable))

			Dim docRenderer As DocumentRenderer = New DocumentRenderer(doc)
			docRenderer.PrepareDocument()

			'loop para el render de los componentes en el documento final
			Dim page As PdfPage
			Dim gfx As XGraphics
			entrePrimero = False
			Dim numeroTablas As Integer = 0
			Dim ultimaAltura As Integer = 0

			For Each tablaParcialConceptos As MigraDoc.DocumentObjectModel.Tables.Table In listaTablasConceptos
				numeroTablas += 1
				page = documento.AddPage()
				page.Size = PdfSharp.PageSize.Letter
				page.Orientation = PdfSharp.PageOrientation.Portrait

				' Get an XGraphics object for drawing 
				gfx = XGraphics.FromPdfPage(page)

				docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(35), XUnit.FromPoint(600), tablaDatos)

				For Each tablaInterna As MigraDoc.DocumentObjectModel.Tables.Table In tablasFooter
					docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(650), XUnit.FromPoint(600), tablaInterna)
				Next

				For Each tablaInterna As MigraDoc.DocumentObjectModel.Tables.Table In tablasDatosReceptor
					docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(170), XUnit.FromPoint(600), tablaInterna)
				Next

				ultimaAltura = 0
				If entrePrimero = False Then
					entrePrimero = True

					docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(230), XUnit.FromPoint(600), tablaParcialConceptos)

					ultimaAltura = tablaParcialConceptos.Rows.Count
				Else
					docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(230), XUnit.FromPoint(600), tablaParcialConceptos)
					ultimaAltura = tablaParcialConceptos.Rows.Count
				End If

				If listaTablasConceptos.Count = numeroTablas Then
					For Each tablaInterna As MigraDoc.DocumentObjectModel.Tables.Table In tablasTotales
						'docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(670), XUnit.FromPoint(670), tablaTotales)
						If numeroTablas = 1 Then
							Dim superultimo As Integer = (((ultimaAltura - (ultimaAltura Mod 2)) / 2) * 50) + 220
							docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(superultimo), XUnit.FromPoint(600), tablaInterna)
						Else
							Dim superultimo As Integer = (((ultimaAltura - (ultimaAltura Mod 2)) / 2) * 50) + 270
							docRenderer.RenderObject(gfx, XUnit.FromPoint(65), XUnit.FromPoint(superultimo), XUnit.FromPoint(600), tablaInterna)
						End If

					Next

				End If

			Next

			' Save the document... 
			documento.Save(fileName)

		End Sub

		Public Function CrearDocumento(ByVal idComprobante As Integer) As PdfDocument
			Dim documento As PdfDocument = New PdfDocument()
			Dim objComprobante As New Comprobante(idComprobante)
			Dim objRFC As New RFC(objComprobante.idRFC)
			Dim serie_folio As String

			If objComprobante.serie = String.Empty Then
				serie_folio = objComprobante.folio
			Else
				serie_folio = objComprobante.serie & objComprobante.folio
			End If

			documento.Info.Title = "Factura: " & serie_folio & ", para cliente: " & objRFC.rfc
			documento.Info.Subject = "Factura " & serie_folio & " para el cliente " & objRFC.rfc & ", " & Date.Now.ToLongDateString
			documento.Info.Author = "facturitas.com"

			Return documento
		End Function

		Private Sub LlenarListaTablaConceptos(ByVal numConceptos As Integer, ByRef sec As MigraDoc.DocumentObjectModel.Section, _
		  ByVal tablas As List(Of MigraDoc.DocumentObjectModel.Tables.Table), ByVal idComprobante As Integer, ByRef entrePrimero As Boolean)

			Dim cantidadRenglones As Integer = numConceptos
			Dim cantidadPaginas As Integer = (cantidadRenglones - (cantidadRenglones Mod 20)) / 20
			Dim numeroInicio As Integer = 0
			Dim numeroFin As Integer = 20

			If (cantidadRenglones Mod 20) > 0 Then cantidadPaginas += 1

			'se imprime tantas tablas de conceptos como páginas tendrá el documento final
			For i As Integer = 1 To cantidadPaginas

				'Se añade una tabla de conceptos a la sección
				Dim tablaConceptos As MigraDoc.DocumentObjectModel.Tables.Table = sec.AddTable
				tablaConceptos.Style = "Table"
				tablaConceptos.Borders.Color = New MigraDoc.DocumentObjectModel.Color(0, 0, 0)
				tablaConceptos.Borders.Width = 0.15
				tablaConceptos.Borders.Left.Width = 0.25
				tablaConceptos.Borders.Right.Width = 0.25
				tablaConceptos.Rows.LeftIndent = 0

				'Antes de imprimir renglones deben definirse las columnas de cada tabla
				Dim column As Column
				column = tablaConceptos.AddColumn("2.2cm")	   'Cantidad [unidad]
				column.Format.Alignment = ParagraphAlignment.Left
				column = tablaConceptos.AddColumn("2cm")	   'Clave
				column.Format.Alignment = ParagraphAlignment.Left
				column = tablaConceptos.AddColumn("8.8cm")		'Descripción [Info aduanera | cta predial | complementos | Partes [info aduanera]]
				column.Format.Alignment = ParagraphAlignment.Left
				column = tablaConceptos.AddColumn("2cm")	   'Valor unitario
				column.Format.Alignment = ParagraphAlignment.Right
				column = tablaConceptos.AddColumn("2.5cm")	   'Importe
				column.Format.Alignment = ParagraphAlignment.Right

				'Headers de las columnas de esta tabla
				Dim row As Row = tablaConceptos.AddRow()
				row.HeadingFormat = True
				row.VerticalAlignment = VerticalAlignment.Bottom
				row.Format.Alignment = ParagraphAlignment.Center
				row.Format.Font.Bold = True
				row.Format.Font.Name = "Arial"
				row.Format.Font.Size = 10
				row.Shading.Color = New MigraDoc.DocumentObjectModel.Color(252, 241, 177)

				Dim headerColumna0 As Paragraph = row.Cells(0).AddParagraph("Cantidad")
				headerColumna0.Format.Font.Size = 9

				Dim headerColumna1 As Paragraph = row.Cells(1).AddParagraph("Clave")
				headerColumna1.Format.Font.Size = 9

				Dim headerColumna2 As Paragraph = row.Cells(2).AddParagraph("Descripción")
				headerColumna2.Format.Font.Size = 9

				Dim headerColumna3 As Paragraph = row.Cells(3).AddParagraph("Valor unitario")
				headerColumna3.Format.Font.Size = 9

				Dim paraHeader4 As Paragraph = row.Cells(4).AddParagraph("Importe")
				paraHeader4.Format.Font.Size = 9

				tablaConceptos.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.25)
				If entrePrimero = False Then
					entrePrimero = True
					tablas.Add(GenerarTablaDeConceptos(tablaConceptos, idComprobante, 0, 15))
					numeroInicio = 15
					numeroFin = 35
				Else
					tablas.Add(GenerarTablaDeConceptos(tablaConceptos, idComprobante, numeroInicio, numeroFin))
					numeroInicio = numeroInicio + 20
					numeroFin = numeroFin + 20
				End If

			Next
		End Sub

		Private Function GenerarTablaDeConceptos(ByVal tablaConceptos As MigraDoc.DocumentObjectModel.Tables.Table, ByVal idComprobante As Integer, ByVal numeroInicio As Integer, ByVal numeroFin As Integer) As MigraDoc.DocumentObjectModel.Tables.Table
			Dim dViewConcepto As DataView = New Concepto().GetDS(idComprobante).Tables(0).DefaultView
			Dim numero As Integer = 0

			Dim ienum As IEnumerator = dViewConcepto.GetEnumerator
			Do While ienum.MoveNext
				numero = numero + 1

				If numero >= numeroInicio And numero < numeroFin Then
					Dim dr As DataRowView = CType(ienum.Current, DataRowView)
					Dim idConcepto As Integer = CInt(dr("idConcepto"))

					Dim datRow As Row = tablaConceptos.AddRow()
					datRow.TopPadding = 1.5
					datRow.VerticalAlignment = VerticalAlignment.Top

					Dim cantidad As String = dr("cantidad")
					If dr("unidad") <> String.Empty Then cantidad = cantidad & " " & dr("unidad")

					datRow.Cells(0).AddParagraph(cantidad)
					datRow.Cells(0).Format.Alignment = ParagraphAlignment.Center
					datRow.Cells(0).Format.Font.Size = 8

					datRow.Cells(1).AddParagraph(dr("noIdentificacion"))
					datRow.Cells(1).Format.Alignment = ParagraphAlignment.Left
					datRow.Cells(1).Format.Font.Size = 8

					datRow.Cells(2).AddParagraph(dr("descripcion"))
					datRow.Cells(2).Format.Alignment = ParagraphAlignment.Left
					datRow.Cells(2).Format.Font.Size = 8

					Select Case dr("tipoDatoAnexo")
						Case "aduanera"
							Dim dViewIAux As DataView = New InformacionAduanera().GetDS(idConcepto, tipoObjeto.concepto).Tables(0).DefaultView
							Dim ienumAux As IEnumerator = dViewIAux.GetEnumerator

							Do While ienumAux.MoveNext
								Dim drAux As DataRowView = CType(ienumAux.Current, DataRowView)
								Dim cadenaInfoAduanera As String = String.Empty
								cadenaInfoAduanera = "Información aduanera: No. " & drAux("numero") & ", aduana " & _
								drAux("aduana") & ", " & CDate(drAux("fecha")).ToString("dd-MMM-yyyy")

								datRow.Cells(2).AddParagraph(cadenaInfoAduanera)
							Loop

						Case "predial"
							datRow.Cells(2).AddParagraph("Cta. predial: " & dr("cuentaPredial"))

						Case "complemento"
							' por definir por el SAT

						Case "parte"
							Dim dViewIAux As DataView = New Parte().GetDS(idConcepto).Tables(0).DefaultView
							Dim ienumAux As IEnumerator = dViewIAux.GetEnumerator

							'			Elementos Parte
							Do While ienumAux.MoveNext
								Dim drAux As DataRowView = CType(ienumAux.Current, DataRowView)
								Dim idParte As Integer = CInt(drAux("idParte"))
								Dim cadenaParte As String = drAux("cantidad")
								If drAux("unidad") <> String.Empty Then
									cadenaParte = cadenaParte & " " & drAux("unidad")
								End If
								cadenaParte = cadenaParte & " " & drAux("descripcion")
								If drAux("noIdentificacion") <> String.Empty Then
									cadenaParte = cadenaParte & " " & drAux("noIdentificacion")
								End If
								If CDec(drAux("valorUnitario")) > 0 Then
									cadenaParte = cadenaParte & " (" & CDec(drAux("valorUnitario")).ToString("0.000000") & ")"
								End If
								If CDec(drAux("importe")) > 0 Then
									cadenaParte = cadenaParte & ". Importe: " & CDec(drAux("importe")).ToString("0.000000") & ")"
								End If

								datRow.Cells(2).AddParagraph(cadenaParte)

								If CBool(drAux("informacionAduanera")) Then
									Dim dViewAux2 As DataView = New InformacionAduanera().GetDS(idParte, tipoObjeto.parte).Tables(0).DefaultView
									Dim ienumAux2 As IEnumerator = dViewAux2.GetEnumerator

									Do While ienumAux2.MoveNext
										Dim drAux2 As DataRowView = CType(ienumAux2.Current, DataRowView)
										Dim cadenaInfoAduanera As String = String.Empty
										cadenaInfoAduanera = "Información aduanera: No. " & drAux2("numero") & ", aduana " & _
										drAux2("aduana") & ", " & CDate(drAux2("fecha")).ToString("dd-MMM-yyyy")

										datRow.Cells(2).AddParagraph(cadenaInfoAduanera)
									Loop

								End If
							Loop

					End Select

					datRow.Cells(3).AddParagraph(Format(dr("valorUnitario"), "c"))
					datRow.Cells(3).Format.Font.Size = 8
					datRow.Cells(3).Format.Alignment = ParagraphAlignment.Right

					datRow.Cells(4).AddParagraph(Format(dr("importe"), "c"))
					datRow.Cells(4).Format.Font.Size = 8
					datRow.Cells(4).Shading.Color = New MigraDoc.DocumentObjectModel.Color(249, 200, 132)

					tablaConceptos.SetEdge(0, tablaConceptos.Rows.Count - 1, 5, 1, Edge.Box, BorderStyle.Single, 0.25)

				End If

				If numero = numeroFin Then
					Exit Do
				End If
			Loop

			Return tablaConceptos
		End Function

		Private Function AgregarDatosGenerales(ByVal sec As MigraDoc.DocumentObjectModel.Section, ByVal objComprobante As Comprobante, ByVal objRFC As RFC, _
					ByVal objDomicilio As Domicilio) As MigraDoc.DocumentObjectModel.Tables.Table

			Dim tablaDatos As MigraDoc.DocumentObjectModel.Tables.Table = sec.AddTable

			Dim columna As Column
			columna = tablaDatos.AddColumn("11.5cm")	 'logotipo y emisor
			columna = tablaDatos.AddColumn("6cm")		'folio, certificado y fecha

			Dim row1 As Row = tablaDatos.AddRow()
			'row1.Cells(0).AddImage(ConfigurationManager.AppSettings("files") & objRFC.logo)
			row1.Cells(0).MergeDown = 3
			row1.Cells(0).Format.Font.Size = 8

            Dim img As MigraDoc.DocumentObjectModel.Shapes.Image = row1.Cells(0).AddImage(ConfigurationManager.AppSettings("carpetaArchivos") & "rfcs\logos\" & objRFC.logo)
			Dim a As Integer = img.Width
			img.Width = 300
			img.Height = 100
			row1.Cells(0).AddParagraph(objRFC.nombre & " " & objRFC.rfc.ToUpper)
			row1.Cells(0).AddParagraph(GetDomicilioFull(objDomicilio))

			row1.Cells(1).Format.Alignment = ParagraphAlignment.Center
			row1.Cells(1).VerticalAlignment = VerticalAlignment.Center
			If objComprobante.serie = String.Empty Then
				row1.Cells(1).AddParagraph("No. factura: " & objComprobante.folio)
			Else
				row1.Cells(1).AddParagraph("No. factura: " & objComprobante.serie & objComprobante.folio)
			End If
			row1.Cells(1).Format.Font.Bold = True
			row1.Cells(1).Format.Font.Size = 11
			row1.Cells(1).Format.Font.Color = New MigraDoc.DocumentObjectModel.Color(255, 0, 0)
			row1.Cells(1).Shading.Color = New MigraDoc.DocumentObjectModel.Color(240, 240, 240)
			row1.Height = MigraDoc.DocumentObjectModel.Unit.FromPoint(30)

			Dim row2 As Row = tablaDatos.AddRow()
			row2.Cells(1).Format.Alignment = ParagraphAlignment.Center
			row2.Cells(1).VerticalAlignment = VerticalAlignment.Center
			row2.Cells(1).AddParagraph("Año y No. aprobación de folios: " & objComprobante.anoAprobacion & objComprobante.noAprobacion)
			row2.Cells(1).Format.Font.Size = 8
			row2.Height = MigraDoc.DocumentObjectModel.Unit.FromPoint(20)

			Dim row3 As Row = tablaDatos.AddRow()
			row3.Cells(1).Format.Alignment = ParagraphAlignment.Center
			row3.Cells(1).VerticalAlignment = VerticalAlignment.Center
			row3.Cells(1).AddParagraph("No. certificado: " & objComprobante.noCertificado)
			row3.Cells(1).Format.Font.Size = 8
			row3.Height = MigraDoc.DocumentObjectModel.Unit.FromPoint(20)

			Dim row4 As Row = tablaDatos.AddRow()
			row4.Cells(1).Format.Alignment = ParagraphAlignment.Center
			row4.Cells(1).VerticalAlignment = VerticalAlignment.Bottom
			row4.Cells(1).AddParagraph(GetLugarEmision(objComprobante, objDomicilio))
			row4.Cells(1).AddParagraph(Format(Date.Now, "d \de MMMM \de yyyy HH:mm:ss"))
			row4.Cells(1).Format.Font.Size = 8
			row4.Height = MigraDoc.DocumentObjectModel.Unit.FromPoint(20)

			tablaDatos.SetEdge(0, 0, 0, 0, Edge.Box, BorderStyle.Single, 0.25)

			Return tablaDatos
		End Function

		Private Function AgregarDatosReceptor(ByRef objRFCReceptor As RFC, ByRef tabla As MigraDoc.DocumentObjectModel.Tables.Table) As MigraDoc.DocumentObjectModel.Tables.Table

			tabla.Borders.Width = 0.25

			Dim columndatos As Column = tabla.AddColumn("17.5cm")		'datos fijos emisor
			columndatos.LeftPadding = 5
			columndatos.RightPadding = 5

			Dim row As Row = tabla.AddRow()
			row.TopPadding = 5
			row.BottomPadding = 5
			row.VerticalAlignment = VerticalAlignment.Top
			row.Format.Alignment = ParagraphAlignment.Left

			Dim parrafo As Paragraph = row.Cells(0).AddParagraph("Cliente: ")
			parrafo.Format.Font.Size = 9
			parrafo.Format.Font.Bold = True

			parrafo = row.Cells(0).AddParagraph(objRFCReceptor.nombre & " " & objRFCReceptor.rfc.ToUpper)
			parrafo.Format.Font.Size = 9

			parrafo = row.Cells(0).AddParagraph(GetDomicilioFull(New Domicilio(objRFCReceptor.idRFC, tipoDomicilio.fiscal.ToString)))
			parrafo.Format.Font.Size = 9

			Return tabla
		End Function

		Private Function AgegarTotales(ByRef objComprobante As Comprobante, ByRef tabla As MigraDoc.DocumentObjectModel.Tables.Table) As MigraDoc.DocumentObjectModel.Tables.Table
			tabla.Style = "Table"
			tabla.Borders.Color = New MigraDoc.DocumentObjectModel.Color(0, 0, 0)
			tabla.Borders.Width = 0.15
			tabla.Borders.Left.Width = 0.25
			tabla.Borders.Right.Width = 0.25
			'tabla.Rows.LeftIndent = 0

			Dim column As Column
			column = tabla.AddColumn("2.2cm")
			column.Format.Alignment = ParagraphAlignment.Right
			column = tabla.AddColumn("2cm")
			column.Format.Alignment = ParagraphAlignment.Right
			column = tabla.AddColumn("8.8cm")
			column.Format.Alignment = ParagraphAlignment.Right
			column = tabla.AddColumn("2cm")
			column.Format.Alignment = ParagraphAlignment.Left
			column = tabla.AddColumn("2.5cm")
			column.Format.Alignment = ParagraphAlignment.Right

			'Add an invisible row as a space line to the table
			Dim row As Row = tabla.AddRow()
			row.Borders.Visible = False

			row = tabla.AddRow()
			row.TopPadding = 2
			row.BottomPadding = 2
			row.Cells(0).AddParagraph("Subtotal")
			row.Cells(0).Borders.Visible = False
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 3
			row.Cells(0).Format.Font.Size = 8

			row.Cells(4).AddParagraph(Format(objComprobante.subTotal, "c"))
			row.Cells(4).Shading.Color = New MigraDoc.DocumentObjectModel.Color(249, 200, 132)
			row.Cells(4).Format.Font.Size = 8

			row = tabla.AddRow()
			row.TopPadding = 2
			row.BottomPadding = 2
			row.Cells(0).AddParagraph("Impuesto")
			row.Cells(0).Borders.Visible = False
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 3
			row.Cells(0).Format.Font.Size = 8

			row.Cells(4).AddParagraph(Format(objComprobante.totalImpuestosTrasladados, "c"))
			row.Cells(4).Shading.Color = New MigraDoc.DocumentObjectModel.Color(249, 200, 132)
			row.Cells(4).Format.Font.Size = 8

			row = tabla.AddRow()
			row.TopPadding = 2
			row.BottomPadding = 2
			row.Cells(0).AddParagraph("Total")
			row.Cells(0).Borders.Visible = False
			row.Cells(0).Format.Font.Bold = True
			row.Cells(0).Format.Alignment = ParagraphAlignment.Right
			row.Cells(0).MergeRight = 3
			row.Cells(0).Format.Font.Size = 8

			row.Cells(4).AddParagraph(objComprobante.total.ToString("c"))
			row.Cells(4).Shading.Color = New MigraDoc.DocumentObjectModel.Color(249, 200, 132)
			row.Cells(4).Format.Font.Bold = True
			row.Cells(4).Format.Font.Size = 8

			Return tabla
		End Function

		Private Function AgregarFooter(ByRef objComprobante As Comprobante, ByVal tabla As MigraDoc.DocumentObjectModel.Tables.Table) As MigraDoc.DocumentObjectModel.Tables.Table
			tabla.Style = "Table"
			tabla.Borders.Color = New MigraDoc.DocumentObjectModel.Color(0, 0, 0)
			tabla.Borders.Width = 0.15
			tabla.Borders.Left.Width = 0.25
			tabla.Borders.Right.Width = 0.25
			tabla.Rows.LeftIndent = 0

			Dim column As Column = tabla.AddColumn("17.5cm")
			column.Format.Alignment = ParagraphAlignment.Left

			'Dim row As Row = tabla.AddRow()
			'row.HeadingFormat = True
			'row.VerticalAlignment = VerticalAlignment.Bottom
			'row.Format.Alignment = ParagraphAlignment.Center
			'row.Format.Font.Bold = True
			'row.Format.Font.Name = "Arial"
			'row.Format.Font.Size = 10
			'row.Shading.Color = New MigraDoc.DocumentObjectModel.Color(252, 241, 177)

			Dim row As Row = tabla.AddRow()
			row.Cells(0).AddParagraph("Cadena original")
			row.Cells(0).Format.Font.Size = 8
			row.Cells(0).Format.Font.Bold = True

			row.Cells(0).AddParagraph(objComprobante.cadenaPipes)
			row.Cells(0).Format.Font.Size = 8
			row.Cells(0).Format.Font.Bold = False

			row = tabla.AddRow
			row.Borders.Visible = False

			row = tabla.AddRow()
			row.Cells(0).AddParagraph("Sello digital")
			row.Cells(0).Format.Font.Size = 8
			row.Cells(0).Format.Font.Bold = True

			Dim parrafo As Paragraph = row.Cells(0).AddParagraph(objComprobante.sello)
			parrafo.Format.Font.Size = 8
			parrafo.Format.Font.Bold = False

			row = tabla.AddRow
			row.Borders.Visible = False

			row = tabla.AddRow()
			parrafo = row.Cells(0).AddParagraph("Este documento es una impresión de un comprobante fiscal digital")
			parrafo.Format.Alignment = ParagraphAlignment.Center
			parrafo.Format.Font.Size = 8

			tabla.SetEdge(0, 0, 1, 1, Edge.Box, BorderStyle.Single, 0.25)

			Return tabla
		End Function

		Private Function GetDomicilioFull(ByVal objDomicilio As Domicilio) As String
			Dim domicilio As String = String.Empty
			If objDomicilio.calle <> "" Then domicilio = domicilio & " " & objDomicilio.calle
			If objDomicilio.noExterior <> "" Then domicilio = domicilio & " " & objDomicilio.noExterior
			If objDomicilio.noInterior <> "" Then domicilio = domicilio & "-" & objDomicilio.noInterior
			If objDomicilio.colonia <> "" Then domicilio = domicilio & ", col. " & objDomicilio.colonia
			If objDomicilio.localidad <> "" Then domicilio = domicilio & ", " & objDomicilio.localidad
			If objDomicilio.referencia <> "" Then domicilio = domicilio & "-" & objDomicilio.referencia
			If objDomicilio.codigoPostal <> "" Then domicilio = domicilio & ", C.P. " & objDomicilio.codigoPostal
			If objDomicilio.municipio <> "" Then domicilio = domicilio & ", " & objDomicilio.municipio
			If objDomicilio.estado <> "" Then domicilio = domicilio & ", " & objDomicilio.estado
			If objDomicilio.pais <> "" Then domicilio = domicilio & ", " & objDomicilio.pais

			Return domicilio
		End Function

		Private Function GetLugarEmision(ByVal objComprobante As Comprobante, ByVal objDomicilio As Domicilio) As String
			Dim lugar As String = String.Empty
			If objComprobante.idDomicilio <> objDomicilio.idDomicilio Then	'hay domicilio de expedicion
				Dim objDomicilioExp As New Domicilio(objComprobante.idDomicilio)
				If objDomicilioExp.localidad <> "" Then lugar = objDomicilioExp.localidad
				If objDomicilioExp.municipio <> "" Then lugar = lugar & ", " & objDomicilioExp.municipio
				If objDomicilioExp.estado <> "" Then lugar = lugar & ", " & objDomicilioExp.estado
				If objDomicilioExp.pais <> "" Then lugar = lugar & ", " & objDomicilioExp.pais
			Else
				If objDomicilio.localidad <> "" Then lugar = objDomicilio.localidad
				If objDomicilio.municipio <> "" Then lugar = lugar & ", " & objDomicilio.municipio
				If objDomicilio.estado <> "" Then lugar = lugar & ", " & objDomicilio.estado
				If objDomicilio.pais <> "" Then lugar = lugar & ", " & objDomicilio.pais
			End If

			Return lugar
		End Function
	End Class
End Namespace
