Imports System.Globalization
Imports System.Threading
Imports System.Data
Imports System.Net
Imports System.Net.Mail
Imports System.Math

Partial Class sec_CheckoutCard
    Inherits System.Web.UI.Page

	Protected carpetafiles As String

	Protected Overrides Sub initializeculture()
		Dim culture As String = Session("idioma")

		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
		Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)

		MyBase.InitializeCulture()
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Try
			If Not CInt(Session("idUserProfile")) > 0 Then
				Response.Redirect("~/Login.aspx?ReturnUrl=" & tienda.Utils.getReturnURL(Request.Url.PathAndQuery))
			End If
		Catch ex As Exception
		End Try

		If Not IsPostBack Then
			cargarDatos()
			llenaParametros()
		End If
	End Sub

	Private Sub cargarDatos()
		'para continuar proyectoentramite = 1
		' si ya está pagada habrá un depósito efectivo con la idOrden y en el campo referencia el idTransaccion
		'  en ese caso desahabilitar el botón de pago

		carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "ordenes/"
		Dim aCookie As New HttpCookie("cookOrden")
		Dim claveOrden As Integer = getIdOrden()
		Dim idIdioma As Integer = CInt(Session("idIdioma"))

		If claveOrden = 0 Then Response.Redirect("~/default.aspx")

		Dim objOrden As New tienda.Orden(CInt(claveOrden))
		If Not objOrden.existe Or objOrden.eliminado Then Response.Redirect("~/sec/HistorialCotizaciones.aspx")

		'para continuar en esta página es necesario que proyectoEnTramite = True
		If objOrden.proyectoEnTramite = False Then Response.Redirect("~/sec/ProyectoAvance.aspx?idOrden=" & claveOrden)

		Dim objDeposito As tienda.Deposito = New tienda.Deposito().getDepositoUnico(claveOrden)
		If objDeposito.existe Then
			'si está pagado habrá un depósito único, cubriendo el total de la orden
			If objDeposito.Monto = objOrden.total Then
				spanPagada.Visible = True
				btnchkout.Visible = False

				Dim objTransaccion As New tienda.Transaccion(claveOrden, True)
				lblAuthCode.Text = objTransaccion.AuthCode
				lblFechaTransaccion.Text = objTransaccion.fechaTransaccion
			Else
				'si hay depósitos parciales, entonces no debe continuar en esta página sino en ProyectoAvance
				Response.Redirect("~/sec/ProyectoAvance.aspx?idOrden=" & claveOrden)
			End If
		Else
			'lista para pagarse
			spanPagada.Visible = False
			btnchkout.Visible = True
		End If

		Dim objOrdenDetalle As New tienda.OrdenDetalle

		Page.Title = "Cotización # " & objOrden.idOrden
		lblTitulo.Text &= objOrden.idOrden
		dtlOrdenDetalles.DataSource = objOrdenDetalle.getDR(objOrden.idOrden)
		dtlOrdenDetalles.DataBind()
		lblfecha.Text = Format(Date.Now, "D")

		Dim objUserProfile As New tienda.UserProfile(objOrden.idUserProfile)
		Dim objEstadoIdioma As New tienda.EstadoIdioma(objOrden.idEstadoE, idIdioma)

		'datos generales
		dgNombre.Text = objOrden.nombreE
		dgEmpresa.Text = objOrden.NombreEmpresa
		dgEmail.Text = objUserProfile.email
		dgfechaevento.Text = objOrden.fechaOrden.ToShortDateString
		dgTelefono.Text = objOrden.telefonoE

		If objOrden.direccionE <> "" Then
			dgDireccion.Text = objOrden.direccionE & " " & objOrden.ciudadE & ", " & objEstadoIdioma.nombre & " c.p. " & objOrden.cpE
		End If
		dgStatus.Text = objOrden.status.ToString


		'datos facturacioon
		objEstadoIdioma = New tienda.EstadoIdioma(objOrden.idEstadoF, idIdioma)
		dfNombre.Text = objOrden.nombreF
		dfRFC.Text = objOrden.rfc
		dfTelefono.Text = objOrden.telefonoF

		If objOrden.direccionF <> "" Then
			dfDireccion.Text = objOrden.direccionF & " " & objOrden.ciudadF & ", " & objEstadoIdioma.nombre & " c.p.  " & objOrden.cpF
		End If

		lblSubtotal.Text = Format(objOrden.subtotal + objOrden.costoAdicional + -objOrden.Descuentoservicios - objOrden.descuento, "c")
		lblCostoExpress.Text = objOrden.costoExpress
		lblCostoEnvio.Text = objOrden.costoEnvio
		lblImpuesto.Text = Format(objOrden.impuesto, "c")
		lblTotal.Text = Format(objOrden.total, "c")

		'imagenes
		Dim objOrdenImagen As New tienda.OrdenImagen
		dtlImagenes.DataSource = objOrdenImagen.getDS(claveOrden)
		dtlImagenes.DataBind()
	End Sub

	Private Sub llenaParametros()
		Dim objOrden As New tienda.Orden(getIdOrden)


		'>>>>> datos provistos por el banco <<<<<
		Dim ClientId As String = 19											'Número de cliente asignado por el banco; 1-10 caracteres
		Dim Name As String = "tienda19"										'Usuario de acceso para las transacciones; 32 caracteres máximo
		Dim Password As String = "2006"										'Contraseña para las transacciones
		Dim Mode As String = "R"											'Y (prueba aprobatoria), N (prueba declinada), R (prueba random), P (Producción)
		Dim MerchantId As String = 19										'Afiliación del comercio; número de 7 caracteres
		Dim MerchantName As String = "TiendaPruebas"						'Nombre del comercio; 25 caracteres
		Dim MerchantCity As String = "Monterrey"							'Ubicación de la matriz del negocio; 40 caracteres


		'>>>>> datos provistos por todopromocional <<<<<
		Dim ResponsePath As String = "http://www.todopromocional.com/sec/ConfirmacionCard.aspx"		'Url a donde PayWorks mandará las variables de retorno
		Dim OrderId As String = objOrden.idOrden							'IdOrden único; 36 caracteres máximo
		Dim CustomerName As String											'Nombre del comprador; 30 caracteres máximo
		If objOrden.nombreE <> String.Empty Then
			CustomerName = objOrden.nombreE
		Else
			CustomerName = objOrden.nombre
		End If

		If CustomerName.Length > 30 Then
			CustomerName = CustomerName.Substring(0, 29)
		End If

		Dim Amount As String = Format(objOrden.total.ToString("0.00"))		'Total de la transacción; con punto y dos decimales; número de 18 caracteres
		Dim Concept As String = "Artículos de Todopromocional"				'Concepto de compra; 64 caracteres

		'E1, E2, E3 son variables propias de control que luego de enviarse se regresarán tal cual
		'se usa E1 para enviar el id de la última transacción para cacharlo en el regreso y determinar si debe
		'  grabarse o no una nueva transacción o el cliente simplemente recargó la página de confirmación
		Dim E1 As String = 0
		Dim objTransaccion As New tienda.Transaccion(objOrden.idOrden, True)
		If objTransaccion.existe Then
			E1 = objTransaccion.idTransaccion
		End If
		Dim E2 As String = CustomerName


		Literal1.Text = "<input type=""hidden"" name=""ClientId"" value=""" & ClientId & """/>" _
			& "<input type=""hidden"" name=""Name"" value=""" & Name & """/>" _
			& "<input type=""hidden"" name=""Password"" value=""" & Password & """/>" _
			& "<input type=""hidden"" name=""Mode"" value=""" & Mode & """/>" _
			& "<input type=""hidden"" name=""ResponsePath"" value=""" & ResponsePath & """/>" _
			& "<input type=""hidden"" name=""OrderId"" value=""" & OrderId & """/>" _
			& "<input type=""hidden"" name=""CustomerName"" value=""" & CustomerName & """/>" _
			& "<input type=""hidden"" name=""Amount"" value=""" & Amount & """/>" _
			& "<input type=""hidden"" name=""Concept"" value=""" & Concept & """/>" _
			& "<input type=""hidden"" name=""E1"" value=""" & E1 & """/>" _
			& "<input type=""hidden"" name=""E2"" value=""" & E2 & """/>" _
			& "<input type=""hidden"" name=""MerchantId"" value=""" & MerchantId & """/>" _
			& "<input type=""hidden"" name=""MerchantName"" value=""" & MerchantName & """/>" _
			& "<input type=""hidden"" name=""MerchantCity"" value=""" & MerchantCity & """/>"

	End Sub

	Private Function getIdOrden() As Integer
		Dim idOrden As Integer

		If CInt(Session("idOrden")) > 0 Then
			idOrden = CInt(Session("idOrden"))
		Else
			Try
				idOrden = CInt(Request("idOrden"))
			Catch ex As Exception
			End Try
		End If

		If idOrden < 0 Then idOrden = 0

		Return idOrden
	End Function

	Private Function getIdOrdenDetalleProductoServicio() As Integer
		Dim idOrdenDetalleProductoServicio As Integer

		Try
			idOrdenDetalleProductoServicio = CInt(Request("idOrdenDetalleProductoServicio"))
		Catch ex As Exception
		End Try

		If idOrdenDetalleProductoServicio < 0 Then idOrdenDetalleProductoServicio = 0

		Return idOrdenDetalleProductoServicio
	End Function

	Private Function getIdOrdenImagen() As Integer
		Dim idOrdenImagen As Integer

		Try
			idOrdenImagen = CInt(Request("idOrdenImagen"))
		Catch ex As Exception
		End Try

		If idOrdenImagen < 0 Then idOrdenImagen = 0

		Return idOrdenImagen
	End Function



#Region "Detalles dtlOrdenDetalles"
	Protected Function getNombre(ByVal claveproducto As Integer) As String
		Dim objProductoIdioma As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
		Dim nombre As String = objProductoIdioma.nombre.ToLower

		Return Char.ToUpper(nombre(0)) & nombre.Substring(1)
	End Function

	Protected Function getFoto(ByVal claveproducto As Integer) As String
		Dim objProductoFoto As New tienda.ProductoFoto(claveproducto, True)

		Return System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/" & objProductoFoto.imagen
	End Function

	Protected Function getClave(ByVal claveproducto As Integer) As String
		Dim objProductoIdioma As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))

		Return objProductoIdioma.clave
	End Function

	Protected Function getColor(ByVal claveColor As String) As String
		If IsNumeric(claveColor) Then
			Dim objColor As New tienda.Color(CInt(claveColor))
			Dim objCodigoColor As New tienda.Codigocolor(objColor.idCodigocolor)
			Return objCodigoColor.idioma1
		Else
			Return String.Empty
		End If
	End Function

	Protected Function getVentaminima(ByVal claveproducto As Integer) As String
		Dim objProductoIdioma As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))

		Return objProductoIdioma.ventaMinima
	End Function

	Protected Function getDetallesServicios(ByVal claveOrdenDetalle As Integer) As DataSet
		Dim objOrdendetalleProductoServicio As New tienda.OrdendetalleProductoServicio

		Return objOrdendetalleProductoServicio.GetDS(claveOrdenDetalle)
	End Function

	Protected Function getServicio(ByVal claveServicio As Integer) As String
		Dim objServicioIdioma As New tienda.ServicioIdioma(claveServicio, CInt(Session("idIdioma")))

		Return objServicioIdioma.nombre & " " & objServicioIdioma.unidadComponenteBase & " " & objServicioIdioma.componenteBase
	End Function
#End Region


	Protected Sub btnchkout_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnchkout.Click
		'''''''enviar a pago banorte
	End Sub


	'Public Function getTotalServicios(ByVal claveordendetalle As Integer) As Decimal
	'	Dim myod As New tienda.OrdendetalleProductoServicio
	'	Return myod.getTotalServicios(claveordendetalle)
	'End Function

	'Function EnviarMailOwner(ByVal claveorden As Integer) As Integer
	'	Dim myct As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))

	'	Dim myo As New tienda.Orden(claveorden)


	'	Dim subject As String = "Se ha creado la orden #: " & myo.idOrden & " " & myo.nombreE
	'	Dim cadena As String = "Ver detalles en la siguiente dirección: <br>" & vbCrLf
	'	cadena = cadena & "<a href='http://www.todopromocional.com/siteadmin/sec/traking/finorden.aspx?idOrden=" & myo.idOrden & " '>http://www.todopromocional.com/siteadmin/sec/traking/finorden.aspx?idOrden=" & myo.idOrden & "</a> "

	'	cadena = cadena & "<br><br>###############################################" & vbCrLf & vbCrLf
	'	cadena = cadena & "<br><br>Fecha y hora: " & myo.fechaOrden.ToLongDateString & " - " & myo.fechaOrden.ToLongTimeString & vbCrLf & vbCrLf & vbCrLf


	'	cadena = cadena & myct.nombre & vbCrLf


	'	SendMail(myct.email, cadena, subject)

	'	Return 1
	'End Function

	'Function EnviarMailClient(ByVal claveorden As Integer) As Integer
	'	Dim myu As New tienda.UserProfile(CInt(Session("idUserProfile")))

	'	Dim myo As New tienda.Orden(claveorden)

	'	Dim subject As String = "Hemos recibido su orden #: " & myo.idOrden
	'	Dim cadena As String = "<font style=""font-size:12px;font-family:Arial;"">¡Gracias por preferir a Todopromocional!: <br><br> " & vbCrLf
	'	cadena = cadena & "Hemos recibido la cotización que usted realizó y la estamos revisando," & vbCrLf
	'	cadena = cadena & "pronto le enviaremos la cotización en PDF a este correo.<br><br>" & vbCrLf
	'	cadena = cadena & "Puede ver las cotizaciones que ha realizado en el siguiente link: <br>" & vbCrLf

	'	cadena = cadena & "<a href=""http://www.todopromocional.com/sec/historialCotizaciones.aspx?idOrden=" & myo.idOrden & """>http://www.todopromocional.com/sec/historialCotizaciones.aspx?idOrden=" & myo.idOrden & "</a> "


	'	cadena = cadena & "<br><br>" & vbCrLf & vbCrLf
	'	cadena = cadena & "<br><br>Cotización generada el: " & myo.fechaOrden.ToLongDateString & " - " & myo.fechaOrden.ToLongTimeString & vbCrLf & vbCrLf & vbCrLf
	'	cadena = cadena & "</font>"




	'	SendMail(myu.email, cadena, subject)

	'	Return 1
	'End Function

	'Public Function SendMail(ByVal correo As String, ByRef body As String, ByVal subject As String) As Integer
	'	Dim MailMsg As New MailMessage("contacto@todopromocional.com", correo)



	'	With MailMsg
	'		.Subject = subject
	'		.Body = body
	'		.IsBodyHtml = True



	'	End With

	'	Dim numero As Integer = 0
	'	Try
	'		'Dim aCred As New System.Net.NetworkCredential("jesus.alvarado@edcont.com", "chuchin")

	'		Dim f As New System.Net.Mail.SmtpClient("smtpout.secureserver.net")
	'		'f.EnableSsl = False
	'		'f.UseDefaultCredentials = False
	'		'   f.Credentials = aCred


	'		f.Send(MailMsg)

	'		'    numero = 1
	'	Catch ex As Exception
	'		'  txtComment.Text = ex.Message & " " & ex.InnerException.Message & " " & ex.InnerException.Source
	'	End Try



	'	Return numero
	'End Function
End Class
