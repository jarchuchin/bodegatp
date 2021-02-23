Imports System.Data

Partial Class ProyectoAvance
    Inherits System.Web.UI.Page



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



    Public carpetafiles As String

    Sub cargarDatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "ordenes/"

    
        Dim claveOrden As String = ""

        If Request("idOrden") <> "" Then
            claveOrden = CInt(Request("idOrden"))
        Else
            Response.Redirect("~/default.aspx")
        End If




        'If Request("act") = "borraservicio" Then
        '    borrarServicio(claveOrden)
        'End If
        'If Request("act") = "delimagen" Then
        '    borrarImagen()
        'End If

        Dim myo As New tienda.Orden(CInt(claveOrden))
        Dim myod As New tienda.OrdenDetalle
        '   dtgbolsita.DataSource = myod.getDR(myo.idOrden)
        '   dtgbolsita.DataBind()
		Dim objUsuario As New tienda.UserProfile(myo.idUserProfile)
		lblUsuario.Text = objUsuario.nombre & " " & objUsuario.apellidos

		listViewOrdenDetalle.DataSource = myod.getDR(myo.idOrden)
		listViewOrdenDetalle.DataBind()

        If myo.tempid <> "" Then
            If IsNumeric(myo.tempid) Then
                Dim myasignado As New tienda.UserProfile(CInt(myo.tempid))
                dgAsignado.Text = myasignado.nombre & " " & myasignado.apellidos

            End If
        End If

        lblcotizar.Text = "Cotización # " & myo.idOrden
        Page.Title = "Cotización # " & myo.idOrden
        Dim myuser As New tienda.UserProfile(myo.idUserProfile)
        Dim myestados As New tienda.CatalogoEntidad(myo.idEstadoE)

        'datos generales
        dgNombre.Text = myo.nombreE
        dgEmpresa.Text = myo.NombreEmpresa
        dgEmail.Text = myuser.email
        dgfechaevento.Text = myo.fechaCompromiso.ToShortDateString

        dgTelefono.Text = myo.telefonoE

        If myo.direccionE <> "" Then
            dgDireccion.Text = myo.direccionE & " " & myo.ciudadE & ", " & myestados.nombreentidad & " c.p.  " & myo.cpE
        End If
        dgStatus.Text = myo.status.ToString


        myestados = New tienda.CatalogoEntidad(myo.idEstadoF)
        'datos facturacioon
        dfNombre.Text = myo.nombreF
        dfRFC.Text = myo.rfc
        dfTelefono.Text = myo.telefonoF

        If myo.direccionF <> "" Then
            dfDireccion.Text = myo.direccionF & " " & myo.ciudadF & ", " & myestados.nombreentidad & " c.p.  " & myo.cpF
        End If


        ' lnkCategoActual.NavigateUrl = "vercompras.aspx?idOrden=" & myo.idOrden
        lblfecha.Text = Format(myo.fechaOrden, "dd \de MMMM yyyy")


        'Dim myci As New tienda.ConfiguracionIdioma(1, CInt(Session("idIdioma")))

        'If myci.activarImpuesto Then
        '    Dim mypais As New tienda.Pais("mx")
        '    Dim myestado As New tienda.Estado("nl", mypais.idPais)


        '    impuesto = (myestado.impuesto / 100) * subtotal
        '    lblImpuesto.Text = String.Format("{0:#.00}", impuesto)
        'Else
        '    lblImpuesto.Text = "0.00"
        'End If






        'lblsubtotal.Text = Format(myo.subtotal - myo.descuento, "c")
        'lblservicios.Text = Format(myo.costoAdicional - myo.Descuentoservicios, "c")
        lblcostoenvio.Text = Format(myo.costoEnvio, "c")
        lblcostoexpress.Text = Format(myo.costoExpress, "c")

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
        'Dim myoi As New tienda.OrdenImagen
        'dtlImagenes.DataSource = myoi.getDS(claveOrden)
        'dtlImagenes.DataBind()



    End Sub






    'Private Function ActualizarCantidades() As Integer
    '    Dim i As Integer
    '    Dim cantidad As String = String.Empty

    '    For i = 0 To dtlOrdenDetalles.Items.Count - 1
    '        Dim mycantidad As System.Web.UI.WebControls.TextBox = dtlOrdenDetalles.Items(i).FindControl("txtCantidadOD")
    '        Dim myclaveod As System.Web.UI.WebControls.Label = dtlOrdenDetalles.Items(i).FindControl("lblidordendetalle")
    '        Dim myod As New tienda.OrdenDetalle(CInt(myclaveod.Text))
    '        myod.cantidad = CInt(mycantidad.Text)
    '        myod.Update()


    '    Next


    '    Dim claveOrden As Integer
    '    If Not IsNothing(Request.Cookies("cookOrden")) Then
    '        If IsNumeric(Request.Cookies("cookOrden").Value) Then
    '            claveOrden = CInt(Request.Cookies("cookOrden").Value)
    '        Else
    '            Response.Redirect("~/default.aspx")
    '        End If

    '    Else
    '        If Request("idOrden") <> "" Then
    '            claveOrden = CInt(Request("idOrden"))
    '        Else
    '            Response.Redirect("~/default.aspx")
    '        End If

    '    End If


    '    Dim myo As New tienda.Orden(claveOrden)
    '    myo.Update()




    '    Return claveOrden
    'End Function



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
        Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
        Return mypi.clave

    End Function


    Public Function getNombre(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
        Return mypi.nombre

    End Function


    Public Function getFoto(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoFoto(claveproducto, True)
        Return System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "productos/images/ch/" & mypi.imagen

    End Function



    Public Function getventaminima(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, CInt(Session("idIdioma")))
        Return mypi.ventaMinima

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


    'Function borrarServicio(ByVal orden As Integer) As Integer
    '    Dim myodps As New tienda.OrdendetalleProductoServicio(CInt(Request("idOrdenDetalleProductoServicio")))
    '    Dim myo As New tienda.Orden(orden)
    '    If myo.status = tienda.StatusOrden.AgregandoProductos Then
    '        myodps.Remove()
    '        myo.Update()
    '    Else
    '        lblmensaje.Visible = True
    '    End If


    'End Function


    Function borrarImagen() As Integer
        Dim myoi As New tienda.OrdenImagen(CInt(Request("idOrdenImagen")))
        Return myoi.Remove()


    End Function


	Protected Sub listViewOrdenDetalle_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles listViewOrdenDetalle.ItemCommand
		If e.CommandName = "borrarod" Then
			Dim myod As New tienda.OrdenDetalle(CInt(e.CommandArgument))
			myod.Remove()

			Response.Redirect("compras.aspx?idOrden=" & myod.idOrden)
		End If

	End Sub


    Public Function getTags(ByVal claveidProducto As Integer) As String

        'ByVal clavetags As String, ByVal clavenombre As String, ByVal claveProducto As String
        Dim mypi As New tienda.ProductoIdioma(claveidProducto, 1)
        Dim claveTags As String = mypi.tags
        Dim clavenombre As String = mypi.nombre
        Dim claveProducto As String = mypi.clave

        Dim cadena As String = claveTags.Replace(",", " ")
        cadena = cadena.Replace(" ", "-")
        If cadena <> "" Then
            cadena &= "-" & clavenombre.Replace(" ", "-")
        Else
            cadena &= clavenombre.Replace(" ", "-")
        End If

        If cadena <> "" Then
            If claveProducto.Length > 3 Then
                cadena &= "-" & claveProducto.Substring(3)
            Else
                cadena &= "-" & claveProducto
            End If
        Else
            If claveProducto.Length > 3 Then
                cadena &= claveProducto.Substring(3)
            Else
                cadena &= claveProducto
            End If
        End If


        Return cadena.ToLower


    End Function

End Class
