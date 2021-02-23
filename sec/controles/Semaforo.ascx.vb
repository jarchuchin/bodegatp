Imports System.Data

Partial Class sec_reportes_controles_Semaforo
    Inherits System.Web.UI.UserControl

    Dim vardesplegarCompleto As Boolean = True
    Dim varclaveOrden As Integer = 0

    Public Property DesplegarCompelto As Boolean
        Set(value As Boolean)
            vardesplegarCompleto = value
        End Set
        Get
            Return vardesplegarCompleto
        End Get
    End Property

    Public Property Claveorden As Integer
        Set(value As Integer)
            varclaveOrden = value

        End Set
        Get
            Return varclaveOrden
        End Get
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarDatos()
        End If
    End Sub



    Public carpetafiles As String

    Sub cargarDatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("path") & "files/ordenes/"



        Dim claveOrden As String = ""

        If Request("idOrden") <> "" Then
            claveOrden = CInt(Request("idOrden"))
        Else
            If varclaveOrden = 0 Then
                Response.Redirect("~/default.aspx")
            Else
                claveOrden = varclaveOrden
            End If

        End If




        Dim myo As New tienda.Orden(CInt(claveOrden))
        Dim myod As New tienda.OrdenDetalle
        '   dtgbolsita.DataSource = myod.getDR(myo.idOrden)
        '   dtgbolsita.DataBind()

        lblCotizar.Text = "Proyecto # " & myo.proyectoEnTramiteClave
        Page.Title = "Proyecto # " & myo.proyectoEnTramiteClave
        lblfechacompromiso.Text = myo.fechaCompromiso.ToLongDateString

        dtlOrdenDetalles.DataSource = myod.getDR(myo.idOrden)
        dtlOrdenDetalles.DataBind()



        Dim myuser As New tienda.UserProfile(myo.idUserProfile)
        Dim myestados As New tienda.EstadoIdioma(myo.idEstadoE, CInt(Session("idIdioma")))

        'datos generales
        'dgNombre.Text = myo.nombreE
        '   dgEmpresa.Text = myo.NombreEmpresa
        ' dgEmail.Text = myo.email
        'dgfechaevento.Text = myo.fechaOrden.ToLongDateString
        'dgTelefono.Text = myo.telefonoE

        If myo.tempid <> "" Then
            If IsNumeric(myo.tempid) Then
                Dim myasignado As New tienda.UserProfile(CInt(myo.tempid))
                dgasignado.Text = myasignado.nombre & " " & myasignado.apellidos

            End If
        End If

        Dim myru As New tienda.RolesUser(1, CInt(Session("idUserprofile")))

        dgStatus.Text = myo.status.ToString


        myestados = New tienda.EstadoIdioma(myo.idEstadoF, CInt(Session("idIdioma")))
        'datos facturacioon
        dfNombre.Text = myo.nombreF
        dfRFC.Text = myo.rfc
        dfTelefono.Text = myo.telefonoF


        dfDireccion.Text = myo.direccionF & " "
        If dfDireccion.Text <> "" Then
            dfDireccion.Text &= " " & myo.ciudadF
        Else
            dfDireccion.Text &= " " & myo.ciudadF
        End If
        If dfDireccion.Text <> "" Then
            dfDireccion.Text &= ", " & myestados.nombre
        Else
            dfDireccion.Text &= " " & myestados.nombre
        End If
        If dfDireccion.Text <> "" Then
            If myo.cpF <> "" Then
                dfDireccion.Text &= " C.p.  " & myo.cpF
            End If
        Else
            If myo.cpF <> "" Then
                dfDireccion.Text &= " C.p.  " & myo.cpF
            End If
        End If

        Select Case myo.tipoPago
            Case 1
                lblformadepago.text = "Credito"
            Case 0
                lblformadepago.Text = "Contado"
        End Select



        lblsubtotalgeneral.Text = Format(myo.subtotal + myo.costoAdicional + myo.costoEnvio + myo.costoExpress - myo.descuento, "c")

        lblImpuesto.Text = Format(myo.impuesto, "c")
        lblTotal.Text = Format(myo.total, "c")
        lblcostoenvio.Text = Format(myo.costoEnvio, "0.00")
        lblcostoexpress.Text = Format(myo.costoExpress, "0.00")


        lbltotalproyecto.Text = Format(myo.total, "c")
        Dim mydepositos As New tienda.Deposito
        Dim deposito As Decimal = mydepositos.GetTotalDepositos(myo.idOrden)
        lbldepositos.Text = Format(deposito, "c")

        lblSaldo.Text = Format(myo.total - deposito, "c")
        Dim mycomp As New facturitas.Comprobante
        Dim facturado As Decimal = mycomp.GetTotalComprobantesOrden(myo.idOrden)
        lblfacturado.Text = Format(facturado, "c")

        Dim myce As New tienda.CargoExtra
        Dim cargoextra As Decimal = myce.GetSumaTotalCargosExtras(myo.idOrden)
        lblcargosextras.Text = Format(cargoextra, "c")



        'el jairo es joto

        '  lnkEditar.NavigateUrl = "finalizarCotizacion.aspx?idOrden=" & myo.idOrden & "&regresar=1"
        Dim porcentaje As Integer = 0

        'Cotizacion
        litCotizacion.Text = "<div style=""background-color:red;width:100%;height:100%;padding:2px;"">En revisión</div>"
        If myo.status <> tienda.StatusOrden.AgregandoProductos Then
            litCotizacion.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;"">Autorizada</div>"
            porcentaje = porcentaje + 10
        End If

        'Proyecto
        litProyecto.Text = "<div style=""background-color:red;width:100%;height:100%;padding:2px;"">En revisión</div>"
        If myo.proyectoEnTramite Then
            litProyecto.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black"" > " & myo.proyectoEnTramiteFecha.ToShortDateString & " </div>"
            porcentaje = porcentaje + 10

        End If

        'Anticipo
        Dim entroAnticipo As Boolean = False
        litAnticipo.Text = "<div style=""background-color:red;width:100%;height:100%;padding:2px;"">Esperando anticipo</div>"
        Select Case myo.tipoPago
            Case 1
                litAnticipo.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black"" > " & "Credito" & " </div>"
                entroAnticipo = True
                porcentaje = porcentaje + 10
            Case 0
                If deposito > 0 Then
                    litAnticipo.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black""  > " & Format(deposito, "c") & " </div>"
                    entroAnticipo = True
                    porcentaje = porcentaje + 10
                End If
        End Select

        'Compras
        litCompras.Text = "<div style=""background-color:red;width:100%;height:100%;padding:2px;"">N/A</div>"
        If entroAnticipo Then
            If EstanComprandoce(myo.idOrden) Then
                litCompras.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black""  > Productos Listos </div>"
                porcentaje = porcentaje + 10
            Else
                litCompras.Text = "<div style=""background-color: #FFCC00;width:100%;height:100%;padding:2px;color:black""  > Adquiriendo </div>"
                porcentaje = porcentaje + 5
            End If
        End If

        Label6.ToolTip = ComprasObservaciones

        'Almacen
        litAlmacen.Text = "<div style=""background-color:red;width:100%;height:100%;padding:2px;"">N/A</div>"
        If EntregadosAlmacen Then
            litAlmacen.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black""  >En Almacen</div>"
            porcentaje = porcentaje + 10
        Else
            If EntregadoAlmacenCount > 0 Then
                litAlmacen.Text = "<div style=""background-color: #FFCC00;width:100%;height:100%;padding:2px;color:black"">En transito</div>"
                porcentaje = porcentaje + 5
            End If

        End If

        'Taller
        litTaller.Text = "<div style=""background-color:red;width:100%;height:100%;padding:2px;"">N/A</div>"
        If EstanEnTaller(myo.idOrden) Then
            litTaller.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black""  >Taller listo</div>"
            porcentaje = porcentaje + 20
        Else
            If EstanEnTallerCount > 0 Then
                litTaller.Text = "<div style=""background-color: #FFCC00;width:100%;height:100%;padding:2px;color:black"">En taller</div>"
                porcentaje = porcentaje + 5
            End If
        End If


        'depositos
        If deposito >= myo.total Then
            litDepositos.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black""  >Completo</div>"
            porcentaje = porcentaje + 10
        Else
            If deposito > 0 Then
                litDepositos.Text = "<div style=""background-color:#FFCC00;width:100%;height:100%;padding:2px;"">" & Format(deposito, "c") & " </div>"
                porcentaje = porcentaje + 5
            Else
                litDepositos.Text = "<div style=""background-color:red;width:100%;height:100%;padding:2px;"">N/A</div>"
            End If
            
        End If

        'facturacion
        If myo.total = facturado Then
            LitFacturacion.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black""  >Facturado</div>"
            porcentaje = porcentaje + 10
        Else
            If facturado > 0 Then
                LitFacturacion.Text = "<div style=""background-color:#FFCC00;width:100%;height:100%;padding:2px;"">Facturado: " & Format(facturado, "c") & " </div>"
                porcentaje = porcentaje + 5
            Else
                LitFacturacion.Text = "<div style=""background-color:red;width:100%;height:100%;padding:2px;"">N/A</div>"
            End If

        End If

        If myo.envioGuia <> "" Then
            If myo.envioGuia = "NA" Then
                litEnviado.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black""  >--</div>"
            Else
                litEnviado.Text = "<div style=""background-color:green;width:100%;height:100%;padding:2px;color:black""  >" & myo.envioGuia & "</div>"
            End If

            porcentaje = porcentaje + 10
        Else
            litEnviado.Text = "<div style=""background-color:red;width:100%;height:100%;padding:2px;"">N/A</div>"
        End If



        lblporcentaje.Text = porcentaje & "%" '& myo.GetSemaforo(myo.idOrden)

        If vardesplegarCompleto Then
            panelCompleto1.Visible = True
            panelCompleto2.Visible = True
        Else
            panelCompleto1.Visible = False
            panelCompleto2.Visible = False

        End If
    End Sub


    Public Function getClave(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, 1)
        Return mypi.clave

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

    Public Function getNombre(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, 1)
        Return mypi.nombre

    End Function


    Public Function getFoto(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoFoto(claveproducto, True)
        Return System.Configuration.ConfigurationManager.AppSettings("path") & "files/productos/images/ch/" & mypi.imagen

    End Function



    Public Function getventaminima(ByVal claveproducto As Integer) As String
        Dim mypi As New tienda.ProductoIdioma(claveproducto, 1)
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


    Public EntregadosAlmacen As Boolean = True
    Public EntregadoFecha As DateTime
    Public EntregadoObservaciones As String
    Dim EntregadoAlmacenCount As Integer = 0
    Public Function getImagenCheck(claveOrdenDetalle As Integer) As String
        Dim mycd As New tienda.CompraDetalle(claveOrdenDetalle, False)
        Dim imagen As String = "~/images/pagina/t-icon-no.png"
        If mycd.Entregado Then
            EntregadoFecha = mycd.EntregadoFecha
            EntregadoObservaciones = mycd.EntregadoObservaciones
            imagen = "~/images/pagina/t-icon-si.png"
            If EntregadosAlmacen Then
                EntregadosAlmacen = True
            End If
            EntregadoAlmacenCount = EntregadoAlmacenCount + 1
        Else
            EntregadosAlmacen = False
        End If

        Return imagen
    End Function



    Public ComprasObservaciones As String = ""
    Public Function EstanComprandoce(claveIdOrden As Integer) As Boolean
        Dim myod As New tienda.OrdenDetalle
        Dim dr As SqlClient.SqlDataReader = myod.getDR(claveIdOrden)
        Dim mycd As tienda.CompraDetalle
        Dim compradastodas As Boolean = True
        Do While dr.Read()
            mycd = New tienda.CompraDetalle(dr("idOrdenDetalle"), False)
            If compradastodas Then
                If mycd.existe Then
                    compradastodas = True

                Else
                    compradastodas = False
                End If
                ComprasObservaciones = ComprasObservaciones & mycd.EntregadoObservaciones & "-" & mycd.idCompraDetalle
            End If

        Loop
        dr.Close()
        Return compradastodas


    End Function


    Public EstanEnTallerCount As Integer = 0
    Public Function EstanEnTaller(claveIdOrden As Integer) As Boolean
        Dim myod As New tienda.OrdenDetalle
        Dim dr As SqlClient.SqlDataReader = myod.getDR(claveIdOrden)
        ' Dim mycsd As tienda.CompraServicioDetalle
        Dim terminadasTodas As Boolean = True

        Dim myodps As New tienda.OrdendetalleProductoServicio
        Dim contarProductos As Integer = 0
        Do While dr.Read()
            ' Dim drServ As SqlClient.SqlDataReader = myodps.GetDR(dr("idOrdenDetalle"))
            If terminadasTodas Then

                If Not Convert.IsDBNull(dr("SalirTaller")) Then
                    If CBool(dr("SalirTaller")) Then
                        EstanEnTallerCount = EstanEnTallerCount + 1
                        terminadasTodas = True
                    Else
                        terminadasTodas = False
                    End If
                End If



            End If

            contarProductos = contarProductos + 1
           

        Loop
        dr.Close()

        If EstanEnTallerCount = contarProductos Then
            Return terminadasTodas
        Else
            Return False
        End If



    End Function



    Public Function getImagenCheck2(claveidOrdenDetalleProductoServicio As Integer) As String
        Dim mycsd As New tienda.CompraServicioDetalle(claveidOrdenDetalleProductoServicio, False)
        Dim imagen As String = "~/images/pagina/t-icon-no.png"
        'If mycsd.Entregado Then
        '    EntregadoFecha = mycsd.EntregadoFecha
        '    EntregadoObservaciones = mycsd.EntregadoObservaciones
        '    imagen = "~/images/pagina/t-icon-si.png"
        '    If EntregadosAlmacen Then
        '        EntregadosAlmacen = True
        '    End If
        '    EntregadoAlmacenCount = EntregadoAlmacenCount + 1
        'Else
        '    EntregadosAlmacen = False
        'End If

        Return imagen
    End Function




End Class
