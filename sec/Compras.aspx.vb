Imports System.Globalization
Imports System.Threading
Imports System.Data
Imports System.Net
Imports System.Net.Mail
Imports System.Math

Partial Class Compras
	Inherits System.Web.UI.Page

	Public carpetafiles As String

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
        End If



    End Sub

    Sub cargarDatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "ordenes/"
        'Try
        '	lblUsuario.Text = Session("nombre").ToString
        'Catch ex As Exception
        'End Try
        Dim aCookie As New HttpCookie("cookOrden")

        Dim claveOrden As Integer = getIdOrden()

        If Request("act") = "borraservicio" Then
            borrarServicio(claveOrden)
        End If
        If Request("act") = "delimagen" Then
            borrarImagen()
        End If

        Dim myo As New tienda.Orden(CInt(claveOrden))
        Dim myod As New tienda.OrdenDetalle
        Dim myuser As New tienda.UserProfile(myo.idUserProfile)
        Dim myestados As New tienda.EstadoIdioma(myo.idEstadoE, CInt(Session("idIdioma")))

        Page.Title = "Cotización # " & myo.idOrden
        'lblUsuario.Text &= myuser.nombre & " " & myuser.apellidos
        'lblfecha.Text &= myo.fechaOrden.ToShortDateString
        'lblNumOrden.Text &= myo.idOrden

        '   dtgbolsita.DataSource = myod.getDR(myo.idOrden)
        '   dtgbolsita.DataBind()


        listViewOrdenDetalle.DataSource = myod.getDR(myo.idOrden)
        listViewOrdenDetalle.DataBind()



        'lnkCategoActual.Text = lblCotizar.Text
        'lnkCategoActual.NavigateUrl = "Compras.aspx?idOrden=" & myo.idOrden



        'datos generales
        dgNombre.Text = myo.nombreE
        dgEmpresa.Text = myo.NombreEmpresa
        dgEmail.Text = myuser.email
        dgfechaevento.Text = myo.fechaOrden.ToShortDateString
        dgTelefono.Text = myo.telefonoE

        If myo.direccionE <> "" Then
            dgDireccion.Text = myo.direccionE & " " & myo.ciudadE & ", " & myestados.nombre & " c.p.  " & myo.cpE
        End If
        dgStatus.Text = myo.status.ToString


        myestados = New tienda.EstadoIdioma(myo.idEstadoF, CInt(Session("idIdioma")))
        'datos facturacioon
        dfNombre.Text = myo.nombreF
        dfRFC.Text = myo.rfc
        dfTelefono.Text = myo.telefonoF

        If myo.direccionF <> "" Then
            dfDireccion.Text = myo.direccionF & " " & myo.ciudadF & ", " & myestados.nombre & " c.p.  " & myo.cpF
        End If




        'Dim myci As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))

        'If myci.activarImpuesto Then
        '    Dim mypais As New tienda.Pais("mx")
        '    Dim myestado As New tienda.Estado("nl", mypais.idPais)


        '    impuesto = (myestado.impuesto / 100) * subtotal
        '    lblImpuesto.Text = String.Format("{0:#.00}", impuesto)
        'Else
        '    lblImpuesto.Text = "0.00"
        'End If




        lnkdfEditar.NavigateUrl = "EditarOrdenDatos.aspx?idOrden=" & claveOrden
        lnkdgEditar.NavigateUrl = "EditarOrdenDatos.aspx?idOrden=" & claveOrden


        'lblsubtotal.Text = Format(myo.subtotal - myo.descuento, "c")
        'lblservicios.Text = Format(myo.costoAdicional - myo.Descuentoservicios, "c")

        'If myo.descuento > 0 Then
        '    lblDescuentos.Text = Format(myo.descuento, "c")
        '    lblDescuentos.Visible = True
        '    lbldescproductos.Visible = True
        '    lbldescproductos_x.Visible = True
        'Else
        '    lblDescuentos.Visible = False
        '    lbldescproductos.Visible = False
        '    lbldescproductos_x.Visible = False
        'End If

        'If myo.Descuentoservicios > 0 Then
        '    lbldescuentosservicios.Text = Format(myo.Descuentoservicios, "c")
        '    lbldescuentosservicios.Visible = True
        '    lbldescservicios.Visible = True
        '    lbldescservicios_x.Visible = True
        'Else
        '    lbldescuentosservicios.Visible = False
        '    lbldescservicios.Visible = False
        '    lbldescservicios_x.Visible = False
        'End If

        lblsubtotalgeneral.Text = Format(myo.subtotal + myo.costoAdicional + myo.costoEnvio - myo.Descuentoservicios - myo.descuento, "c")

        lblImpuesto.Text = Format(myo.impuesto, "c")
        lblTotal.Text = Format(myo.total, "c")





        'imagenes
        Dim myoi As New tienda.OrdenImagen
        dtlImagenes.DataSource = myoi.getDS(claveOrden)
        dtlImagenes.DataBind()
        lnkAgregarImagen.NavigateUrl = "AgregarImagen.aspx?idOrden=" & claveOrden
        'hiddenAgregarImagen.Value = "AgregarImagen.aspx?idOrden=" & claveOrden


    End Sub

    Private Function getIdOrden() As Integer
        Dim idOrden As Integer = 0
        Try
            idOrden = CInt(Session("idOrden"))
        Catch ex As Exception
        End Try

        If idOrden <= 0 Then
            Try
                idOrden = CInt(Request("idOrden"))
            Catch ex As Exception
            End Try
        End If

        If idOrden < 0 Then idOrden = 0
        Session("idOrden") = idOrden

        Return idOrden
    End Function





    Private Function ActualizarCantidades() As Integer
        Dim i As Integer
        Dim cantidad As String = String.Empty

        For i = 0 To listViewOrdenDetalle.Items.Count - 1
            Dim mycantidad As System.Web.UI.WebControls.TextBox = listViewOrdenDetalle.Items(i).FindControl("txtCantidadOD")
            Dim myclaveod As System.Web.UI.WebControls.Label = listViewOrdenDetalle.Items(i).FindControl("lblidordendetalle")
            Dim myod As New tienda.OrdenDetalle(CInt(myclaveod.Text))
            myod.cantidad = CInt(mycantidad.Text)
            myod.costoUnitario = New tienda.Precio().GetPrecioUnitario(myod.idProducto, tienda.TipoEntidad.Producto, myod.cantidad)
            myod.total = Round(myod.cantidad * myod.costoUnitario)
            myod.costoEnvio = 0
            myod.descuento = 0
            myod.costoFinal = myod.costoUnitario
            myod.Update()

        Next


        Dim claveOrden As Integer = Session("idOrden")


        Dim myo As New tienda.Orden(claveOrden)
        myo.Update()




        Return claveOrden
    End Function



    Public Function GetColor(ByVal claveColor As String) As String
        If IsNumeric(claveColor) Then
            Dim myc As New tienda.Color(CInt(claveColor))
            Dim mycc As New tienda.Codigocolor(myc.idCodigocolor)
            Return mycc.idioma1
        Else
            Return ""
        End If

    End Function

    Public Function getClave(ByVal claveproducto As Integer) As String


        If CBool(Session("esAdmin")) Then
            Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
            Return "TP-" & claveproducto '& ", " & mypi.clave
        Else
            Return "TP-" & claveproducto
        End If


    End Function


    Public Function getNombre(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
        Return getNombretoLower(mypi.nombre, False)

    End Function


    Public Function getFoto(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoFoto(claveproducto, True)
        Return System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/" & mypi.imagen

    End Function



    Public Function getventaminima(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
        Return mypi.ventaMinima

    End Function



    Public Function getNombretoLower(ByVal claveNombre As String, Optional ByVal reducir As Boolean = True) As String
        Dim regresoName As String
        If reducir Then
            If claveNombre.Length > 25 Then
                regresoName = claveNombre.Substring(0, 25).ToLower & "..."
            Else
                regresoName = claveNombre.ToLower
            End If
        Else
            regresoName = claveNombre.ToLower
        End If


        Return Char.ToUpper(regresoName(0)) & regresoName.Substring(1)
    End Function



    Function EnviarMailOwner(ByVal claveorden As Integer) As Integer
        Dim myct As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))

        Dim myo As New tienda.Orden(claveorden)


        Dim subject As String = "Se ha creado la orden #: " & myo.idOrden & " " & myo.nombreE
        Dim cadena As String = "Ver detalles en la siguiente dirección: <br>" & vbCrLf
        cadena = cadena & "<a href='http://www.todopromocional.com/siteadmin/sec/traking/finorden.aspx?idOrden=" & myo.idOrden & " '>http://www.todopromocional.com/siteadmin/sec/traking/finorden.aspx?idOrden=" & myo.idOrden & "</a> "

        cadena = cadena & "<br><br>###############################################" & vbCrLf & vbCrLf
        cadena = cadena & "<br><br>Fecha y hora: " & myo.fechaOrden.ToLongDateString & " - " & myo.fechaOrden.ToLongTimeString & vbCrLf & vbCrLf & vbCrLf


        cadena = cadena & myct.nombre & vbCrLf

        '  myct.email
        SendMail("alejandra.alvizo@todopromocional.com", cadena, subject)

        Return 1
    End Function

    Function EnviarMailClient(ByVal claveorden As Integer) As Integer
        Dim myu As New tienda.UserProfile(CInt(Session("idUserProfile")))

        Dim myo As New tienda.Orden(claveorden)


        Dim subject As String = "Hemos recibido su orden #: " & myo.idOrden
        Dim cadena As String = "<font style=""font-size:12px;font-family:Arial;"">¡Gracias por preferir a Todopromocional!: <br><br> " & vbCrLf
        cadena = cadena & "Hemos recibido la cotización que usted realizó y la estamos revisando," & vbCrLf
        cadena = cadena & "pronto le enviaremos la cotización en PDF a este correo.<br><br>" & vbCrLf
        cadena = cadena & "Puede ver las cotizaciones que ha realizado en el siguiente link: <br>" & vbCrLf

        cadena = cadena & "<a href=""http://www.todopromocional.com/sec/historialCotizaciones.aspx?idOrden=" & myo.idOrden & """>http://www.todopromocional.com/sec/historialCotizaciones.aspx?idOrden=" & myo.idOrden & "</a> "


        cadena = cadena & "<br><br>" & vbCrLf & vbCrLf
        cadena = cadena & "<br><br>Cotización generada el: " & myo.fechaOrden.ToLongDateString & " - " & myo.fechaOrden.ToLongTimeString & vbCrLf & vbCrLf & vbCrLf
        cadena = cadena & "</font>"




        SendMail(myo.email, cadena, subject)

        Return 1
    End Function




    Public Function SendMail(ByVal correo As String, ByRef body As String, ByVal subject As String) As Integer
        Dim MailMsg As New MailMessage("alejandra.alvizo@todopromocional.com", correo)



        With MailMsg
            .Subject = subject
            .Body = body
            .IsBodyHtml = True



        End With

        Dim numero As Integer = 0
        Try
            Dim aCred As New System.Net.NetworkCredential(CStr(Application("mailUser3")), CStr(Application("mailPass")))

            Dim f As New System.Net.Mail.SmtpClient(CStr(Application("mailHost")))
            f.EnableSsl = False
            f.UseDefaultCredentials = False
            f.Credentials = aCred
            f.Port = CInt(Application("mailPort"))

            f.Send(MailMsg)


            numero = 1
        Catch ex As Exception

        End Try



        Return numero
	End Function





	Public Function getDetallesServicios(ByVal claveOrdenDetalle As Integer) As DataSet
		Dim myds As New tienda.OrdendetalleProductoServicio
		Return myds.GetDS(claveOrdenDetalle)

	End Function


	Public Function getTotalServicios(ByVal claveordendetalle As Integer) As Decimal
		Dim myod As New tienda.OrdendetalleProductoServicio
		Return myod.getTotalServicios(claveordendetalle)
	End Function

	Public Function getServicio(ByVal claveServicio As Integer) As String
		Dim mys As New tienda.ServicioIdioma(claveServicio, CInt(Session("idIdioma")))
		Return mys.nombre & " " & mys.unidadComponenteBase & " " & mys.componenteBase

	End Function


	Function borrarServicio(ByVal orden As Integer) As Integer
		Dim myodps As New tienda.OrdendetalleProductoServicio(CInt(Request("idOrdenDetalleProductoServicio")))
		Dim myo As New tienda.Orden(orden)
		If myo.status = tienda.StatusOrden.AgregandoProductos Then
			myodps.Remove()
			myo.Update()
		Else
			lblmensaje.Visible = True
		End If


	End Function


	Function borrarImagen() As Integer
		Dim myoi As New tienda.OrdenImagen(CInt(Request("idOrdenImagen")))
		myoi.Remove()


	End Function

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim claveorden As Integer = ActualizarCantidades()

        Response.Redirect("Compras.aspx?idOrden=" & claveorden)
    End Sub

	Protected Sub lnkBtnFinalizar_Click(sender As Object, e As EventArgs) Handles lnkBtnFinalizar.Click
		Dim claveOrden As Integer = Request("idOrden")
		Dim myo As New tienda.Orden(claveOrden)

		Dim cadenaOrden As String = myo.folio.ToString
		cadenaOrden = cadenaOrden.Substring(cadenaOrden.Length - 2)

		Dim myru As New tienda.RolesUser
		If cadenaOrden = "00" Then
			cadenaOrden = "100"
        End If

        Dim claveInstancia As Integer = 1
        '############################################################
        'asignar a vendedor df las ordenes de df y mexico
        If myo.idEstadoE = 18 Or myo.idEstadoE = 30 Then
            claveInstancia = 2
        End If




        '############################################################

        Dim claveVendedor As Integer = myru.GetDSRangos(CInt(cadenaOrden), claveInstancia)

        'coloca a Rogelio Frias León como asignación hardcode
        claveVendedor = 35800

        myo.status = tienda.StatusOrden.Revisión
		myo.Observaciones = txtObservaciones.Text
        If claveVendedor > 0 Then
            myo.tempid = claveVendedor
        Else
            myo.tempid = 26
        End If
		myo.Update()


		Session("idOrden") = 0

		EnviarMailOwner(claveOrden)
		EnviarMailClient(claveOrden)

		Session("tabla") = Nothing

		Response.Redirect("ComprasConfirmacion.aspx?idOrden=" & claveOrden)
	End Sub

    Protected Sub listViewOrdenDetalle_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles listViewOrdenDetalle.ItemCommand
        If e.CommandName = "select" Then
            Dim cadena As String = e.CommandArgument
            Dim myod As New tienda.OrdenDetalle(CInt(cadena))
            myod.Remove()

            Response.Redirect("compras.aspx?idOrden=" & myod.idOrden)
        End If
    End Sub






    Protected Sub listViewOrdenDetalle_SelectedIndexChanging(sender As Object, e As ListViewSelectEventArgs) Handles listViewOrdenDetalle.SelectedIndexChanging
        listViewOrdenDetalle.SelectedIndex = e.NewSelectedIndex
        cargarDatos()
    End Sub

End Class
