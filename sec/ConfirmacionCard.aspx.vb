Imports System.Net.Mail

Partial Class sec_ConfirmacionCard
    Inherits System.Web.UI.Page

	Protected Sub sec_ConfirmacionCard_Load(sender As Object, e As EventArgs) Handles Me.Load
		Try
			If Not CInt(Session("idUserProfile")) > 0 Then
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If
		Catch ex As Exception
		End Try

		If Not Page.IsPostBack Then
			llenado()
		End If
	End Sub

	Private Sub llenado()
		Dim idOrden As Integer = getIdOrden()
		If idOrden = 0 Then Response.Redirect("~/sec/HistorialCotizaciones.aspx")

		Dim objOrden As New tienda.Orden(idOrden)
		If Not objOrden.existe Or objOrden.eliminado Then Response.Redirect("~/sec/HistorialCotizaciones.aspx")
		If objOrden.proyectoEnTramite = False Then Response.Redirect("~/sec/HistorialCotizaciones.aspx")

		lblfecha.Text = Format(Date.Now, "dd \de MMMM yyyy")

		Dim codigoResultado As String = procesaRequest(objOrden)

		If codigoResultado = "1" Then
			panelExito.Visible = True
			panelFailed.Visible = False
			displayExito(objOrden)
		Else
			panelExito.Visible = False
			panelFailed.Visible = True
			displayFailed(objOrden)
		End If
	End Sub

	Private Function procesaRequest(ByRef objOrden As tienda.Orden) As String
		Dim CcErrCode As String = getCcErrCode()				'De 1 a 4 dígitos (es la única con que se valida la aprobación o rechazo): 1=éxito
		Dim AuthCode As String = Request("AuthCode")			'La transacción exitosa devuelve una cadena alfanumerica de 6 caracteres
		If Not AuthCode <> String.Empty Then AuthCode = String.Empty

		Dim ProcReturnMsg As String = Request("ProcReturnMsg")	'Mensaje correspondiente a ProcReturnCode
		If Not ProcReturnMsg <> String.Empty Then ProcReturnMsg = String.Empty

		Dim Cvv2Resp As String = Request("Cvv2Resp")			'Devuelve el Cvv2Val si se especifico al enviar la transacción
		If Not Cvv2Resp <> String.Empty Then Cvv2Resp = String.Empty

		Dim TimeIn As Date = getTimeIn()						'Tiempo de inicio de transacción
		Dim TimeOut As Date = getTimeOut()						'Tiempo de fin de transacción
		Dim MaxSev As Integer = getMaxSev()						'Grado de severidad de error de 0 a 8; 5 o más significa que la transacción falló
		Dim total As Decimal = getTotal()						'El importe total de la transacción

		'%%%%%  variables extras que pueden enviarse y recuperarse para control interno. el banco las regresa tal cual  %%%%%
		Dim idTransaccionAnterior_E1 As Integer = getIdTransaccionAnterior()	'se usa Request("E1")
		Dim cliente As String = Request("E2")	'nombre del cliente (CustomerName)
		Dim E3 As String = Request("E3")
		'%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


		Dim objTransaccionUltima As New tienda.Transaccion(objOrden.idOrden, True)
		Dim idTransaccion As Integer = objTransaccionUltima.idTransaccion
		Dim idDeposito As Integer = objTransaccionUltima.idDeposito

		If idTransaccion = idTransaccionAnterior_E1 And idDeposito = 0 Then
			'la igualdad indica que esta transacción no se había procesado y los datos siguen igual en la base de datos

			If objTransaccionUltima.existe Then
				objTransaccionUltima.esUltimoIntento = False
				objTransaccionUltima.Update()
			End If

			Dim objTransaccion As New tienda.Transaccion()
			With objTransaccion
				.idOrden = objOrden.idOrden
				.idDeposito = 0
				.status = Request("Status")					'1=transacción completamente procesada; null=procesamiento incompleto
				.AuthCode = AuthCode
				.CcErrCode = CcErrCode
				.CcReturnMsg = Request("CcReturnMsg")			'Mensaje  correspondiente a CcErrCode
				.ProcReturnCode = Request("ProcReturnCode")	'Código de Retorno del procesador de tarjeta; 1 a 10 caracteres
				.ProcReturnMsg = ProcReturnMsg
				.Cvv2Resp = Cvv2Resp
				.TimeIn = TimeIn
				.TimeOut = TimeOut
				.MaxSev = MaxSev
				.Text = Request("Text")						'Texto del mensaje de error regresado
				.total = total
				.fechaTransaccion = Now
				.esUltimoIntento = True
				.numeroIntento = objTransaccionUltima.numeroIntento + 1
				.Add()
			End With

			idTransaccion = objTransaccion.idTransaccion
			'idDeposito = objTransaccion.idDeposito
		End If

		If CcErrCode = "1" Then
			If idDeposito = 0 Then
				Dim objDeposito As New tienda.Deposito
				With objDeposito
					.idOrden = objOrden.idOrden
					.Fecha = TimeOut
					.Factura = ""
					.Cliente = cliente
					.Sucursal = objOrden.SucursalDestino
					.Referencia = idTransaccion
					.Monto = total
					.Eliminado = False
					.ValidadoPor = 0
					.TipoDeposito = "Transferencia"
					.Estatus = "Registrado"
					.idComprobante = 0
					.Observaciones = "Pago con tarjeta, vía Banorte"
					.fechaRegistro = .Fecha
					.Add()
				End With

				Dim objTransaccion As New tienda.Transaccion(idTransaccion)
				objTransaccion.idDeposito = objDeposito.idDeposito
				objTransaccion.Update()

				hiddenSendMail.Value = True
			End If
		End If

		Return CcErrCode
	End Function

	Private Sub displayExito(ByRef objOrden As tienda.Orden)
		Dim objUserProfile As New tienda.UserProfile(CInt(objOrden.tempid))
		Dim objTransaccion As New tienda.Transaccion(objOrden.idOrden, True)

		lblVendedor.Text = "Vendedor asignado: " & objUserProfile.nombre & " " & objUserProfile.apellidos
		lblVendedorEmail.Text = objUserProfile.email
		lblVendedorExtension.Text = "<b>Teléfono</b>: 01800 702 0505 ext. <b>" & objUserProfile.telefono & "</b>"

		lblidOrden.Text = objOrden.idOrden
		lblTotal.Text = objOrden.total.ToString("c")
		lblFechaTransaccion.Text = objTransaccion.fechaTransaccion

		Label2.Text = "<b>" & objUserProfile.nombre & " " & objUserProfile.apellidos & "</b> será tu contacto para el envío de tu orden."
		lnkDetalles.NavigateUrl &= objOrden.idOrden

		Dim enviarMail As Boolean
		Try
			enviarMail = CBool(hiddenSendMail.Value)
		Catch ex As Exception
		End Try

		If enviarMail Then
			Dim body As String = buildMessageBody(objOrden, objUserProfile, objTransaccion)
			'sendMailConfirmacion("ventas@todopromocional.com", objOrden.email, body, objOrden.idOrden, objOrden.nombreE)
			'sendMailConfirmacion("ventas@todopromocional.com", "ventas@todopromocional.com", body & "<br />........copia.......", objOrden.idOrden, objOrden.nombreE)
			sendMailConfirmacionTest("jesus.alvarado@edcont.com", "jesus.alvarado@edcont.com", body, objOrden.idOrden, objOrden.nombreE)
			sendMailConfirmacionTest("jesus.alvarado@edcont.com", "jesus.alvarado@edcont.com", body & "<br />........copia.......", objOrden.idOrden, objOrden.nombreE)
		End If
	End Sub

	Private Sub displayFailed(ByRef objOrden As tienda.Orden)
		lblMensajeBanco.Text = Request("ProcReturnMsg")
		lnkReTry.NavigateUrl &= objOrden.idOrden

		Dim objUserProfile As New tienda.UserProfile(CInt(objOrden.tempid))

		lblVendedor2.Text = "Vendedor asignado: " & objUserProfile.nombre & " " & objUserProfile.apellidos
		lblVendedorEmail2.Text = objUserProfile.email
		lblVendedorExtension2.Text = "<b>Teléfono</b>: 01800 702 0505 ext. <b>" & objUserProfile.telefono & "</b>"
	End Sub

	Private Function getIdOrden() As Integer
		Dim idOrden As Integer
		Try
			idOrden = CInt(Request("OrderId"))
		Catch ex As Exception
		End Try

		If idOrden < 0 Then idOrden = 0

		Return idOrden
	End Function

	Private Function getCcErrCode() As Integer
		Dim CcErrCode As Integer
		Try
			CcErrCode = CInt(Request("CcErrCode"))
		Catch ex As Exception
		End Try

		Return CcErrCode
	End Function

	Private Function getTimeIn() As Date
		Dim TimeIn As Date = Now
		Try
			TimeIn = CDate(Request("TimeIn"))
		Catch ex As Exception
		End Try

		Return TimeIn
	End Function

	Private Function getTimeOut() As Date
		Dim TimeOut As Date = Now
		Try
			TimeOut = CDate(Request("TimeOut"))
		Catch ex As Exception
		End Try

		Return TimeOut
	End Function

	Private Function getMaxSev() As Integer
		Dim MaxSev As Integer
		Try
			MaxSev = CInt(Request("MaxSev"))
		Catch ex As Exception
		End Try

		Return MaxSev
	End Function

	Private Function getTotal() As Decimal
		Dim total As Decimal
		Try
			total = CDec(Request("total"))
		Catch ex As Exception
		End Try

		Return total
	End Function

	Private Function getCodigoError(codigo As Integer) As String
		Select Case codigo
			Case 1
				Return "Approved"
			Case 2
				Return "Referral (General)"
			Case 3
				Return "Referral - Call bank for manual approval"
			Case 4
				Return "AVS request accepted"
			Case 50
				Return "Declined (General)"
			Case 51
				Return "Connection timed-out"
			Case 52
				Return "Error connecting to processor or sending data"
			Case 53
				Return "Error during Payment Commit phase"
			Case 54
				Return "Timed out waiting for response"
			Case 100
				Return "Transaction failed to settle due to Soft Error"
			Case 101
				Return "Transaction failed to settle due to Hard Error"
			Case 102
				Return "Transaction failed to settle because the transaction is marked as Locked"
			Case 400
				Return "Entry mode is not valid"
			Case 401
				Return "Card-present flag is not valid"
			Case 402
				Return "Customer-present flag is not valid"
			Case 403
				Return "Terminal type is not valid"
			Case 404
				Return "Terminal capability is not valid"
			Case 500
				Return "Declined - Transaction considered fraudulent by Fraud component"
			Case 501
				Return "The transaction was Approved by the processor. However, it failed a postprocessing fraud rule and has been voided"
			Case 502
				Return "The transaction was Approved by the processor. However, it failed a fraud rule and has been marked for review"
			Case 1001
				Return "Invoice number not valid"
			Case 1002
				Return "Amount not valid"
			Case 1003
				Return "Interchange or Payment Service data submitted is not valid"
			Case 1004
				Return "Level III data is missing or is not valid"
			Case 1005
				Return "Currency is not valid"
			Case 1006
				Return "BIN is not valid"
			Case 1007
				Return "Card number is not valid"
			Case 1008
				Return "Start date (Switch or Solo card) is not valid"
			Case 1009
				Return "Issue number (Switch or Solo card) is not valid"
			Case 1010
				Return "Magnetic stripe data is not valid"
			Case 1011
				Return "Card expiration date is not valid"
			Case 1012
				Return "Transaction date or time is not valid"
			Case 1013
				Return "Date is not valid"
			Case 1014
				Return "Transaction is not valid"
			Case 1015
				Return "PIN is not correct"
			Case 1016
				Return "Merchant ID is not valid"
			Case 1017
				Return "Account is not valid"
			Case 1018
				Return "Encryption Error"
			Case 1019
				Return "Check Digit Error"
			Case 1020
				Return "Verification Error"
			Case 1021
				Return "Destination not found"
			Case 1022
				Return "Service code is not valid or is restricted"
			Case 1023
				Return "Violation, cannot complete"
			Case 1024
				Return "Error response text from check service"
			Case 1025
				Return "No account"
			Case 1026
				Return "No such issuer"
			Case 1027
				Return "PIN tries exceeded"
			Case 1028
				Return "Transaction not permitted"
			Case 1029
				Return "Security Violation"
			Case 1030
				Return "Unable to back out transaction"
			Case 1031
				Return "Unable to locate. No match was found"
			Case 1032
				Return "Inconsistent data, rev. or repeat"
			Case 1033
				Return "Already reversed at switch"
			Case 1034
				Return "Cannot verify PIN"
			Case 1035
				Return "Terminal ID is not valid"
			Case 1036
				Return "Message format error"
			Case 1037
				Return "Track 2 data is not valid"
			Case 1050
				Return "Declined - Insufficient funds"
			Case 1051
				Return "Customer card is expired"
			Case 1052
				Return "Lost or stolen card"
			Case 1053
				Return "Pick up card. Issuer wants card returned"
			Case 1054
				Return "Response is not valid"
			Case 1055
				Return "CVV failure or CVV Value supplied is not valid"
			Case 1056
				Return "Transaction type or code is not valid"
			Case 1057
				Return "Declined - Do not honor"
			Case 1058
				Return "Declined – Exceeds issuer withdrawal limit"
			Case 1059
				Return "Declined – Exceeds withdrawal limit"
			Case 1060
				Return "Declined – Activity limit exceeded"
			Case 1061
				Return "Declined - Cashback limit exceeded"
			Case 1062
				Return "Cashback service not available"
			Case 1063
				Return "Resend Batch"
			Case 1064
				Return "Download failed"
			Case 1065
				Return "Switch or issuer system error"
			Case 1066
				Return "Unable to route transaction"
			Case 1067
				Return "System error"
			Case 1068
				Return "Duplicate transmission"
			Case 1069
				Return "Honor with identification"
			Case 1070
				Return "Currency conversion failed"
			Case 1071
				Return "Periodic transaction - new account information available"
			Case 1072
				Return "Periodic transaction - try again later"
			Case 1073
				Return "Periodic transaction - do not try again"
			Case 1074
				Return "Duplicate transaction"
			Case 1075
				Return "Unsolicited reversal transaction"
			Case 1076
				Return "Unable to complete transaction"
			Case 1077
				Return "Re-enter transaction"
			Case 1078
				Return "Previous message located"
			Case 1079
				Return "Incomplete access, could not do reversal lookup. Re-send may be successful"
			Case 1080
				Return "Undetermined reversal error. Re-send may be successful"
			Case 1081
				Return "Timeout performing reversal. Re-send may be successful"
			Case 1500
				Return "Checking account is not valid"
			Case 1501
				Return "Savings account is not valid"
			Case 2001
				Return "Terminal ID not set up for settlement on this card type"
			Case 2002
				Return "Terminal ID not set up for authorization on this card type"
			Case 2003
				Return "Process code, authorization type, or card type is not valid"
			Case 2005
				Return "Source ID is not valid"
			Case 2006
				Return "Summary ID is not valid"
			Case 2008
				Return "Bankcard merchant number in the processor host database is not valid"
			Case 2009
				Return "File access error occurred in the processor host database"
			Case 2010
				Return "Terminal flagged as Inactive in the processor host database"
			Case 2011
				Return "Merchant ID and terminal ID combination is not valid"
			Case 2012
				Return "Unrecoverable database error from an authorization process; this might indicate that the merchant ID and terminal ID combination was already in use"
			Case 2013
				Return "Processor host-database-access lock encountered, Retry after 3 seconds"
			Case 2014
				Return "Processor host-database error in summary process. Retry after 3 seconds"
			Case 2015
				Return "Transaction ID is not valid, is incorrect, or is out of sequence"
			Case 2016
				Return "Terminal flagged as Violated in processor host database. Call customer support"
			Case 2017
				Return "Terminal ID not set up for leased line access on processor host database"
			Case 2018
				Return "Settle Trans for Summary ID where earlier Summary ID still open"
			Case 2019
				Return "Account number found by authorization process is not valid"
			Case 2020
				Return "Settlement data found in summary process (trans level) is not valid"
			Case 2021
				Return "Settlement data found in summary process (summary level) is not valid"
			Case 2024
				Return "Transaction count value is not valid"
			Case 2025
				Return "Entry not valid. Reenter the authorization request"
			Case 2026
				Return "Lost or stolen card. Card issuer wants the card returned"
			Case 2027
				Return "Batch is out of balance"
			Case 2028
				Return "Terminal is not programmed for this service"
			Case 2050
				Return "Dependent data is missing or is not valid"
			Case 2051
				Return "Division ID is not valid"
			Case 2052
				Return "Credit card number does not match the method of payment"
			Case 2053
				Return "Method of payment is not valid for the division ID"
			Case 2054
				Return "Card was authorized, but approval was overwritten per merchant"
			Case 2055
				Return "Issuer requires more information"
			Case 2056
				Return "Restricted card"
			Case 2057
				Return "MAC code is invalid"
			Case 2058
				Return "Check merchant entitlement"
			Case 2059
				Return "Capture not allowed"
			Case 2060
				Return "Communication error - resend"
			Case 2061
				Return "Non-numeric folio number"
			Case 2062
				Return "Retain card"
			Case 2063
				Return "No action taken"
			Case 2064
				Return "Suspicion of manipulation"
			Case 2065
				Return "Requested function not supported"
			Case 2066
				Return "Secondary transaction was not carried out with the card which was used for the original transaction"
			Case 2067
				Return "The transaction amount of the secondary transaction is higher than original transaction amount"
			Case 2068
				Return "Card issuer temporarily not reachable"
			Case 2069
				Return "The card type is not processed by the authorization center"
			Case 2070
				Return "Processing temporarily not possible"
			Case 2071
				Return "The POS terminal has to initiate an automatic re-initialization"
			Case 2072
				Return "The user should initiate an automatic re-initialization"
			Case 2073
				Return "Declined - data entry error"
			Case 2074
				Return "Declined – negative data"
			Case 2075
				Return "Declined - scoring decline"
			Case 2076
				Return "Declined - no response from host"
			Case 2077
				Return "Institution is no longer valid"
			Case 2078
				Return "Card not active. Effective date not valid"
			Case Else
				Return ""
		End Select
	End Function

	Private Function getIdTransaccionAnterior() As Integer
		Dim idTransaccion As Integer
		Try
			idTransaccion = CInt(Request("E1"))
		Catch ex As Exception
		End Try

		If idTransaccion < 0 Then idTransaccion = 0

		Return idTransaccion
	End Function

	Private Function buildMessageBody(objOrden As tienda.Orden, objUserProfile As tienda.UserProfile, objTransaccion As tienda.Transaccion) As String
		Dim url As String = "http://www.todopromocional.com/sec/CheckoutCard.aspx?idOrden=" & objOrden.idOrden & "&idIdioma=" & Session("idIdioma")
		Dim liga As String = "<a href=""" & url & """ style=""font-family:Arial; font-size:15px;color:#7c7c7c"">" & url & "</a>"

		Dim body As String = "Se realizó con éxito un cargo a tu tarjeta por <b>" & objOrden.total.ToString("c") & "</b> por concepto de "
		body &= "<b>Pago de orden #" & objOrden.idOrden & "</b> con fecha: " & objTransaccion.fechaTransaccion & "<br /><br /><br />"

		body &= "Para darle seguimiento a tu orden te atenderá nuestro agente de ventas" & objUserProfile.nombre & " " & objUserProfile.apellidos & "<br />"
		body &= "Ponte en contacto con él escribiendo a " & objUserProfile.email & " o hablando al teléfono 01800 702 0505 ext. " & objUserProfile.telefono & "<br /><br /><br />"

		body &= "Para ver detalles de la orden haz clic en la siguiente liga o cópiala en tu navegador:<br /><br />"
		body &= liga & "<br /><br /><br />"
		body &= "¡Gracias por preferir Todopromocional!<br /><br />"


		body &= "<table cellpadding=""0"" cellspacing=""0"" border=""0""><tr><td style=""width:308px"">" _
			& "<a href=""http://www.todopromocional.com"" border=""0""><img src=""http:/todopromocional.com/images/mail/firmas/medtp.jpg"" " _
			& "width=""308px"" alt=""""/></a></td><td style=""width:45px""><a href=""http://www.twitter.com/todopromocional"" " _
			& "border=""0""><img src=""http:/todopromocional.com/images/mail/firmas/medtwitter.jpg"" width=""45px"" alt=""""/></a></td>" _
			& "<td style=""width:42px""><a href=""http://www.facebook.com/promocional"" border=""0"">" _
			& "<img src=""http:/todopromocional.com/images/mail/firmas/medfb.jpg"" width=""42px"" alt=""""/></a></td><td style=""width:299px"">" _
			& "<a href=""http://www.youtube.com/todopromocional"" border=""0""><img src=""http:/todopromocional.com/images/mail/firmas/medyoutube.jpg"" " _
			& "width=""299px"" alt=""""/></a></td></tr></table>'"
		body &= "<hr />"
		body &= "<font style=""font-family:Arial; font-size:10px;color:black"">El contenido de esta comunicación electrónica no se considera " _
			& "oferta o acuerdo de voluntades, salvo que sea suscrito por firma autógrafa del representante legal de la Compañia. El contenido de " _
			& "esta comunicación es confidencial para uso exclusivo del destinatario, por lo que se prohíbe su divulgación total o parcial a " _
			& "cualquier tercero no autorizado.</font><br/><br/>"
		body &= "<div style=""width:300px;height:20px""></div>"
		body &= "<font style=""font-family:Arial; font-size:10px;color:black"">The content of this electronic communication is not to be " _
			& "cosidered as an offer, proposal, or agreement unless it is confirmed in a document duly signed by the Company's legal representative. " _
			& "The content of this communication is confidential and for the exclusive use of the addressee. Its total or partial disclosure to " _
			& "any unauthorized third party is strictly forbidden.</font>"

		Return body
	End Function

	Public Function sendMailConfirmacion(ByVal correoFrom As String, ByVal correoTo As String, ByRef body As String, ByVal claveCotizacion As Integer, ByVal nombre As String) As Integer
		Dim MailMsg As New MailMessage(correoFrom, correoTo)

		With MailMsg
			.Subject = "Ha sido pagada la cotización # " & claveCotizacion & " -- " & nombre
			.Body = body
			.IsBodyHtml = True
		End With

		Dim numero As Integer = 0
		Try
			Dim f As New System.Net.Mail.SmtpClient("smtpout.secureserver.net")
			f.Send(MailMsg)

			numero = 1
		Catch ex As Exception
		End Try

		Return numero
	End Function

	Public Function sendMailConfirmacionTest(ByVal correoFrom As String, ByVal correoTo As String, ByRef body As String, ByVal claveCotizacion As Integer, ByVal nombre As String) As Integer
		Dim MailMsg As New MailMessage(correoFrom, correoTo)

		With MailMsg
			.Subject = "Ha sido pagada la cotización # " & claveCotizacion & " -- " & nombre
			.Body = body
			.IsBodyHtml = True
		End With

		Dim numero As Integer = 0
		Try
			Dim f As New System.Net.Mail.SmtpClient("smtpout.secureserver.net", 80)
			f.EnableSsl = False
			f.UseDefaultCredentials = False
			f.Credentials = New System.Net.NetworkCredential("jesus.alvarado@edcont.com", "chuchin")
			f.Send(MailMsg)

			numero = 1
		Catch ex As Exception
		End Try

		Return numero
	End Function
End Class
