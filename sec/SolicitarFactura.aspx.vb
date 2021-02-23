Imports System.Globalization
Imports System.Threading
Imports System.Data
Imports System.Net
Imports System.Net.Mail

Partial Class sec_SolicitarFactura
    Inherits System.Web.UI.Page


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



    Public carpetafiles As String

    Sub cargarDatos()
        carpetafiles = System.Configuration.ConfigurationManager.AppSettings("carpetafiles") & "ordenes/"

        Dim aCookie As New HttpCookie("cookOrden")

        Dim claveOrden As String = ""
        If Not IsNothing(Request.Cookies("cookOrden")) Then
            If IsNumeric(Request.Cookies("cookOrden").Value) Then
                claveOrden = Request.Cookies("cookOrden").Value
            Else
                Response.Redirect("~/default.aspx")
            End If

        Else
            If Request("idOrden") <> "" Then
                claveOrden = CInt(Request("idOrden"))
            Else
                Response.Redirect("~/default.aspx")
            End If

        End If

        If Request("act") = "delimagen" Then
            borrarImagen()
        End If

        Dim myo As New tienda.Orden(CInt(claveOrden))
        Dim myod As New tienda.OrdenDetalle


        'dtlOrdenDetalles.DataSource = myod.getDR(myo.idOrden)
        'dtlOrdenDetalles.DataBind()
        'rptViewOrden.DataSource = myod.getDS(myo.idOrden)
        'rptViewOrden.DataBind()

        If myo.tempid <> "" Then
            If IsNumeric(myo.tempid) Then
                Dim myasignado As New tienda.UserProfile(CInt(myo.tempid))
                '   dgAsignado.Text = myasignado.nombre & " " & myasignado.apellidos

            End If
        End If

        litNumOrden.Text = myo.idOrden
        Page.Title = "Proyecto # " & myo.idOrden
        Dim myuser As New tienda.UserProfile(myo.idUserProfile)
        Dim myestados As New tienda.CatalogoEntidad(myo.idEstadoE)

        'datos generales
        'dgNombre.Text = myo.nombreE
        'dgEmpresa.Text = myo.NombreEmpresa
        'dgEmail.Text = myuser.email
        'dgfechaevento.Text = myo.fechaCompromiso.ToShortDateString
        'dgTelefono.Text = myo.telefonoE

        'If myo.direccionE <> "" Then
        '    dgDireccion.Text = myo.direccionE & " " & myo.ciudadE & ", " & myestados.nombreentidad & " c.p.  " & myo.cpE
        'End If
        '	dgStatus.Text = myo.status.ToString


        myestados = New tienda.CatalogoEntidad(myo.idEstadoF)

        'datos facturacioon
        dfNombre.Text = myo.nombreF
        dfRFC.Text = myo.rfc
        dfCalle.Text = myo.direccionF
        dfNumexterior.Text = myo.NumeroEF
        dfNuminterior.Text = myo.NumeroIF
        dfColonia.Text = myo.ColoniaF
        dfEstado.Text = myestados.nombreentidad
        dfMunicipio.Text = myo.MunicipioF
        dfLocalidad.Text = myo.ciudadF
        dfReferencia.Text = myo.ReferenciaF
        dfCodigoPostal.Text = myo.cpF
        dfTelefono.Text = myo.telefonoF
        dfClaveBancaria.Text = myo.claveBancaria
        dfIncluirdatosAlfacturar.Text = myo.IncluirObservacionFactura


        '	lblfecha.Text = Format(myo.fechaOrden, "dd/MMMM/yyyy")
        'lblcostoenvio.Text = Format(myo.costoEnvio, "c")
        'lblcostoexpress.Text = Format(myo.costoExpress, "c")
        'lblsubtotalgeneral.Text = Format(myo.subtotal + myo.costoAdicional + myo.costoEnvio - myo.Descuentoservicios - myo.descuento, "c")
        'lblImpuesto.Text = Format(myo.impuesto, "c")
        'lblTotal.Text = Format(myo.total, "c")






        'Dim myof As New Facturitas.Comprobante
        'gvFacturas.DataSource = myof.GetDSOrden(CInt(Request("idOrden")))
        'gvFacturas.DataBind()


        colocarDatosEnProceso(myo)

        Dim mydv As New tienda.Deposito
        gvDepositosVentas.DataSource = mydv.GetDepositosFacturables(myo.idOrden)
        gvDepositosVentas.DataBind()

        If gvDepositosVentas.Rows.Count = 0 Then
            lblMensaje.Visible = True
            btnEditar.Visible = False
        Else
            btnEditar.Visible = False
        End If


    End Sub

    Sub colocarDatosEnProceso(objOrden As tienda.Orden)





    End Sub

    Public ComprasObservaciones As String = ""
    Public FechaUltimaCompra As String = ""
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
                    Dim mycompra As New tienda.Compra(mycd.idCompra)
                    FechaUltimaCompra = Format(mycompra.Fecha, "dd/MMM/yyyy - HH:mm")
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
    Public EstanEnTallerFecha As String
    Public Function EstanEnTaller(claveIdOrden As Integer) As Boolean
        Dim myod As New tienda.OrdenDetalle
        Dim dr As SqlClient.SqlDataReader = myod.getDR(claveIdOrden)
        ' Dim mycsd As tienda.CompraServicioDetalle
        Dim terminadasTodas As Boolean = True

        Dim myodps As New tienda.OrdendetalleProductoServicio
        Dim contarProductos As Integer = 0
        Do While dr.Read()
            Dim drServ As SqlClient.SqlDataReader = myodps.GetDR(dr("idOrdenDetalle"))
            Dim serviciosTotal As Integer = myodps.Count(dr("idOrdenDetalle"))


            If terminadasTodas Then

                If serviciosTotal > 0 Then
                    If CBool(dr("SalirTaller")) Then
                        EstanEnTallerCount = EstanEnTallerCount + 1
                        terminadasTodas = True
                        EstanEnTallerFecha = Format(CType(dr("SalirTallerFecha"), DateTime), "dd/MMM/yyyy - HH:mm")
                    Else
                        terminadasTodas = False
                    End If
                Else
                    EstanEnTallerCount = EstanEnTallerCount + 1
                    terminadasTodas = True
                    EstanEnTallerFecha = "NA" ' Format(CType(dr("SalirTallerFecha"), DateTime), "dd/MMM/yyyy - HH:mm")
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


    Private Function RevisarFacturas() As Integer
        Dim myof As New Facturitas.Comprobante
        Dim ds As DataSet = myof.GetDSOrden(CInt(Request("idOrden")))
        Dim filePath As String = System.Configuration.ConfigurationManager.AppSettings("pathAndromedaOut")
        Dim myc As Facturitas.Comprobante
        Dim objCFDI As Facturitas.CFDI

        For Each dr As DataRow In ds.Tables(0).Rows

            myc = New Facturitas.Comprobante(CInt(dr("idComprobante")))
            If myc.nameFile = "" Then
                Dim cadenaNombre As String = getXMLFile(filePath, myc.serie & myc.folio)

                If cadenaNombre <> "" Then
                    myc.nameFile = cadenaNombre
                    myc.Update()

                    objCFDI = New Facturitas.CFDI(myc.idComprobante, Facturitas.tipoParametroCFDI.claveComprobante, False)
                    objCFDI.uuid = cadenaNombre
                    objCFDI.fechaActualizacion = Now
                    objCFDI.update()

                End If
            End If


        Next

    End Function


    Private Function getXMLFile(filePath As String, clavefolioSerie As String) As String

        Dim cadenarchivos As String() = System.IO.Directory.GetFiles(filePath, "cmp070924fca-" & clavefolioSerie & "*")
        Dim regreso As String = ""

        If cadenarchivos.Count > 0 Then
            regreso = cadenarchivos(0).ToString
            regreso = regreso.Substring(regreso.LastIndexOf("\") + 1, regreso.LastIndexOf("."))
        End If

        Return regreso
    End Function
    Public Function esVisible(claveNombre As String) As Boolean
        If claveNombre <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getNombreArchivo(claveNombre As String, clavetipo As String) As String
        If clavetipo = "xml" Then
            Return "~/siteadmin/files/andromeda/AndromedaOUT/" & claveNombre & ".xml"
        Else
            Return "~/siteadmin/files/andromeda/AndromedaOUT/" & claveNombre & ".pdf"
        End If
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
            Return "TP-" & claveproducto & ", " & mypi.clave
        Else
            Return "TP-" & claveproducto
        End If


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
    Protected Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Response.Redirect("EditarDatosFacturacion.aspx?idOrden=" & Request("idOrden"))
    End Sub
    Protected Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click



        Dim i As Integer = 0
        Dim claveGeneral As String = Request("idOrden") & "_" & Date.Now.Year & Date.Now.Month & Date.Now.Day & Date.Now.Hour & Date.Now.Minute

        For i = 0 To gvDepositosVentas.Rows.Count - 1
            Dim mychk As System.Web.UI.WebControls.CheckBox = CType(gvDepositosVentas.Rows(i).FindControl("chkSeleccion"), CheckBox)
            Dim myclave As System.Web.UI.WebControls.Label = CType(gvDepositosVentas.Rows(i).FindControl("lblClaveDeposito"), Label)
            If mychk.Checked Then
                Dim myd As New tienda.Deposito(CInt(myclave.Text))




            End If

        Next



        Response.Redirect("SolicitarFacturaConfirmar.aspx?idOrden=" & Request("idOrden") & "&clave=" & claveGeneral)



    End Sub
End Class
