Imports System.Data.SqlClient
Imports System.Data
Imports System.Math

Namespace tienda
	Public Class Orden
		Inherits DBObject


        Public idOrden As Integer
        Public idUserProfile As Integer
        Public status As StatusOrden
        Public idTipoTarjeta As Integer
        Public numeroCuenta As String
        Public mes As String
        Public year As String
        Public nombre As String
        Public numeroExtra As String
        Public nombreE As String
        Public direccionE As String
        Public ciudadE As String
        Public idPaisE As Integer
        Public idEstadoE As Integer
        Public cpE As String
        Public telefonoE As String

        Public subtotal As Decimal
        Public impuesto As Decimal
        Public costoEnvio As Decimal
        Public descuento As Decimal
        Public costoAdicional As Decimal
        Public total As Decimal
        Public tipoCambio As Decimal
        Public totalDollar As Decimal
        Public fechaOrden As DateTime
        Public fechaUltimaActualizacion As DateTime
        Public idTipoEnvio As Integer
        Public nombreF As String
        Public rfc As String
        Public direccionF As String
        Public ciudadF As String
        Public idPaisF As Integer
        Public idEstadoF As Integer
        Public cpF As String
        Public telefonoF As String
        Public facturar As Boolean
        Public folio As Integer
        Public tipoPago As Integer
        Public respuesta As String
        Public eliminado As Boolean
        Public existe As Boolean = False
        Public tempid As String = String.Empty
        Public email As String = String.Empty
        Public fechaEntrega As DateTime
        Public requiereFacturacion As Boolean
        Public NombreEmpresa As String
        Public Observaciones As String
        Public Condiciones As String
        Public Descuentoservicios As Decimal

        Public proyectoEnTramiteClave As String
        Public proyectoEnTramite As Boolean
        Public proyectoEnTramiteFecha As DateTime
        Public fechaCompromiso As DateTime
        Public envioGuia As String
        Public envioFecha As DateTime
        Public mercanciaLista As Boolean
        Public mercanciaListaFecha As DateTime
        Public tempidFecha As DateTime
        Public costoExpress As Decimal = 0

        Public ComoConocio As String
        Public FormaContacto As String
        Public TipoCliente As String
        Public TipoEvento As String

        Public incluirAnticipos As Boolean = False
        Public incluirPoliticas As Boolean = False
        Public cuentaBancaria As String = ""
        Public tiempoEntrega As String = ""

        Public NumeroEF As String = ""
        Public NumeroIF As String = ""
        Public ColoniaF As String = ""
        Public ReferenciaF As String = ""
        Public MunicipioF As String = ""


        Public SucursalDestino As String = ""

        Public idInstancia As Integer = 1 'coloca por default la instancia/sucursal monterrey

        Public claveBancaria As String = ""
        Public IncluirObservacionFactura As String = ""

        Public DomiSolicitarObservaciones As String = ""


        Public generadoPorCliente As Boolean = False


        Sub New()
        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "SELECT * FROM Ordenes WHERE idOrden=@idOrden"
            Dim params As SqlParameter() = {New SqlParameter("@idOrden", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idOrden = CInt(dr("idOrden"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.status = CType([Enum].Parse(GetType(StatusOrden), dr("Status")), StatusOrden)
                Me.idTipoTarjeta = CInt(dr("idTipoTarjeta"))
                Me.numeroCuenta = Me.Desencriptar(dr("NumeroCuenta"))
                Me.mes = Me.Desencriptar(dr("Mes"))
                Me.year = Me.Desencriptar(dr("year"))
                Me.nombre = Me.Desencriptar(dr("Nombre"))
                Me.numeroExtra = Me.Desencriptar(dr("NumeroExtra"))
                Me.nombreE = dr("NombreE")
                Me.direccionE = dr("DireccionE")
                Me.ciudadE = dr("CiudadE")
                Me.idPaisE = CInt(dr("idPaisE"))
                Me.idEstadoE = CInt(dr("idEstadoE"))
                Me.cpE = dr("cpE")
                Me.telefonoE = dr("TelefonoE")
                Me.subtotal = Round(CDec(dr("Subtotal")), 2)
                Me.impuesto = Round(CDec(dr("Impuesto")), 2)
                Me.costoEnvio = Round(CDec(dr("CostoEnvio")), 2)
                Me.descuento = Round(CDec(dr("Descuento")), 2)
                Me.costoAdicional = Round(CDec(dr("CostoAdicional")), 2)
                Me.total = Round(CDec(dr("Total")), 2)
                Me.tipoCambio = Round(CDec(dr("TipoCambio")), 2)
                Me.totalDollar = Round(CDec(dr("TotalDollar")), 2)
                Me.fechaOrden = CDate(dr("FechaOrden"))
                Me.fechaUltimaActualizacion = CDate(dr("FechaUltimaActualizacion"))
                Me.idTipoEnvio = CInt(dr("idTipoEnvio"))
                Me.nombreF = dr("NombreF")
                Me.rfc = dr("RFC")
                Me.direccionF = dr("DireccionF")
                Me.ciudadF = dr("CiudadF")
                Me.idPaisF = CInt(dr("idPaisF"))
                Me.idEstadoF = CInt(dr("idEstadoF"))
                Me.cpF = dr("cpF")
                Me.telefonoF = dr("TelefonoF")
                Me.facturar = CBool(dr("Facturar"))
                Me.folio = CInt(dr("Folio"))
                Me.tipoPago = CInt(dr("TipoPago"))
                Me.respuesta = dr("respuesta")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
                Me.tempid = dr("tempid")
                Me.email = dr("email")
                Me.fechaEntrega = CDate(dr("fechaEntrega"))
                Me.requiereFacturacion = CBool(dr("requiereFacturacion"))
                Me.NombreEmpresa = dr("nombreEmpresa")
                Me.Observaciones = dr("Observaciones")
                Me.Condiciones = dr("Condiciones")
                Me.Descuentoservicios = Round(CDec(dr("Descuentoservicios")), 2)
                Me.proyectoEnTramiteClave = dr("proyectoEnTramiteClave")
                Me.proyectoEnTramite = CBool(dr("proyectoEnTramite"))
                Me.proyectoEnTramiteFecha = CDate(dr("proyectoEnTramiteFecha"))
                Me.fechaCompromiso = CDate(dr("fechaCompromiso"))
                Me.envioGuia = dr("envioGuia")
                Me.envioFecha = CDate(dr("envioFecha"))
                Me.mercanciaLista = CBool(dr("mercanciaLista"))
                Me.mercanciaListaFecha = CDate(dr("mercanciaListaFecha"))
                Me.tempidFecha = CDate(dr("tempidFecha"))
                Me.costoExpress = Round(CDec(dr("costoExpress")), 2)
                If Not Convert.IsDBNull(dr("generadoPorCliente")) Then
                    Me.generadoPorCliente = CBool(dr("generadoPorCliente"))
                End If
                If Not Convert.IsDBNull(dr("ComoConocio")) Then
                    Me.ComoConocio = dr("ComoConocio")
                Else
                    Me.ComoConocio = ""
                End If
                If Not Convert.IsDBNull(dr("FormaContacto")) Then
                    Me.FormaContacto = dr("FormaContacto")
                Else
                    Me.FormaContacto = ""
                End If
                If Not Convert.IsDBNull(dr("TipoCliente")) Then
                    Me.TipoCliente = dr("TipoCliente")
                Else
                    Me.TipoCliente = ""
                End If
                If Not Convert.IsDBNull(dr("TipoEvento")) Then
                    Me.TipoEvento = dr("TipoEvento")
                Else
                    Me.TipoEvento = ""
                End If
                If Not Convert.IsDBNull(dr("incluirAnticipos")) Then
                    Me.incluirAnticipos = CBool(dr("incluirAnticipos"))
                Else
                    Me.incluirAnticipos = False
                End If
                If Not Convert.IsDBNull(dr("incluirPoliticas")) Then
                    Me.incluirPoliticas = CBool(dr("incluirPoliticas"))
                Else
                    Me.incluirPoliticas = False
                End If
                If Not Convert.IsDBNull(dr("cuentaBancaria")) Then
                    Me.cuentaBancaria = dr("cuentaBancaria")
                Else
                    Me.cuentaBancaria = ""
                End If
                If Not Convert.IsDBNull(dr("tiempoEntrega")) Then
                    Me.tiempoEntrega = dr("tiempoEntrega")
                Else
                    Me.tiempoEntrega = ""
                End If

                If Not Convert.IsDBNull(dr("NumeroEF")) Then
                    Me.NumeroEF = dr("NumeroEF")
                Else
                    Me.NumeroEF = ""
                End If
                If Not Convert.IsDBNull(dr("NumeroIF")) Then
                    Me.NumeroIF = dr("NumeroIF")
                Else
                    Me.NumeroIF = ""
                End If
                If Not Convert.IsDBNull(dr("ColoniaF")) Then
                    Me.ColoniaF = dr("ColoniaF")
                Else
                    Me.ColoniaF = ""
                End If
                If Not Convert.IsDBNull(dr("ReferenciaF")) Then
                    Me.ReferenciaF = dr("ReferenciaF")
                Else
                    Me.ReferenciaF = ""
                End If
                If Not Convert.IsDBNull(dr("MunicipioF")) Then
                    Me.MunicipioF = dr("MunicipioF")
                Else
                    Me.MunicipioF = ""
                End If


                If Not Convert.IsDBNull(dr("SucursalDestino")) Then
					Me.SucursalDestino = dr("SucursalDestino")
                End If

                If Not Convert.IsDBNull(dr("idInstancia")) Then
                    Me.idInstancia = CInt(dr("idInstancia"))
                End If

                If Not Convert.IsDBNull(dr("claveBancaria")) Then
                    Me.claveBancaria = dr("claveBancaria")
                Else
                    Me.claveBancaria = ""
                End If
                If Not Convert.IsDBNull(dr("IncluirObservacionFactura")) Then
                    Me.IncluirObservacionFactura = dr("IncluirObservacionFactura")
                End If

                If Not Convert.IsDBNull(dr("DomiSolicitarObservaciones")) Then
                    Me.DomiSolicitarObservaciones = dr("DomiSolicitarObservaciones")
                End If

            End If
            dr.Close()

        End Sub

        Sub New(ByVal claveprincipal As String)
            Dim sql As String = "SELECT * FROM Ordenes WHERE tempid=@tempid"
            Dim params As SqlParameter() = {New SqlParameter("@tempid", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                 Me.idOrden = CInt(dr("idOrden"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.status = CType([Enum].Parse(GetType(StatusOrden), dr("Status")), StatusOrden)
                Me.idTipoTarjeta = CInt(dr("idTipoTarjeta"))
                Me.numeroCuenta = Me.Desencriptar(dr("NumeroCuenta"))
                Me.mes = Me.Desencriptar(dr("Mes"))
                Me.year = Me.Desencriptar(dr("year"))
                Me.nombre = Me.Desencriptar(dr("Nombre"))
                Me.numeroExtra = Me.Desencriptar(dr("NumeroExtra"))
                Me.nombreE = dr("NombreE")
                Me.direccionE = dr("DireccionE")
                Me.ciudadE = dr("CiudadE")
                Me.idPaisE = CInt(dr("idPaisE"))
                Me.idEstadoE = CInt(dr("idEstadoE"))
                Me.cpE = dr("cpE")
                Me.telefonoE = dr("TelefonoE")
                Me.subtotal = Round(CDec(dr("Subtotal")), 2)
                Me.impuesto = Round(CDec(dr("Impuesto")), 2)
                Me.costoEnvio = Round(CDec(dr("CostoEnvio")), 2)
                Me.descuento = Round(CDec(dr("Descuento")), 2)
                Me.costoAdicional = Round(CDec(dr("CostoAdicional")), 2)
                Me.total = Round(CDec(dr("Total")), 2)
                Me.tipoCambio = Round(CDec(dr("TipoCambio")), 2)
                Me.totalDollar = Round(CDec(dr("TotalDollar")), 2)
                Me.fechaOrden = CDate(dr("FechaOrden"))
                Me.fechaUltimaActualizacion = CDate(dr("FechaUltimaActualizacion"))
                Me.idTipoEnvio = CInt(dr("idTipoEnvio"))
                Me.nombreF = dr("NombreF")
                Me.rfc = dr("RFC")
                Me.direccionF = dr("DireccionF")
                Me.ciudadF = dr("CiudadF")
                Me.idPaisF = CInt(dr("idPaisF"))
                Me.idEstadoF = CInt(dr("idEstadoF"))
                Me.cpF = dr("cpF")
                Me.telefonoF = dr("TelefonoF")
                Me.facturar = CBool(dr("Facturar"))
                Me.folio = CInt(dr("Folio"))
                Me.tipoPago = CInt(dr("TipoPago"))
                Me.respuesta = dr("respuesta")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
                Me.tempid = dr("tempid")
                Me.email = dr("email")
                Me.fechaEntrega = CDate(dr("fechaEntrega"))
                Me.requiereFacturacion = CBool(dr("requiereFacturacion"))
                Me.NombreEmpresa = dr("nombreEmpresa")
                Me.Observaciones = dr("Observaciones")
                Me.Condiciones = dr("Condiciones")
                Me.Descuentoservicios = Round(CDec(dr("Descuentoservicios")), 2)
                Me.proyectoEnTramiteClave = dr("proyectoEnTramiteClave")
                Me.proyectoEnTramite = CBool(dr("proyectoEnTramite"))
                Me.proyectoEnTramiteFecha = CDate(dr("proyectoEnTramiteFecha"))
                Me.fechaCompromiso = CDate(dr("fechaCompromiso"))
                Me.envioGuia = dr("envioGuia")
                Me.envioFecha = CDate(dr("envioFecha"))
                Me.mercanciaLista = CBool(dr("mercanciaLista"))
                Me.mercanciaListaFecha = CDate(dr("mercanciaListaFecha"))
                Me.tempidFecha = CDate(dr("tempidFecha"))
                Me.costoExpress = Round(CDec(dr("costoExpress")), 2)
                If Not Convert.IsDBNull(dr("generadoPorCliente")) Then
                    Me.generadoPorCliente = CBool(dr("generadoPorCliente"))
                End If
                If Not Convert.IsDBNull(dr("ComoConocio")) Then
                    Me.ComoConocio = dr("ComoConocio")
                Else
                    Me.ComoConocio = ""
                End If
                If Not Convert.IsDBNull(dr("FormaContacto")) Then
                    Me.FormaContacto = dr("FormaContacto")
                Else
                    Me.FormaContacto = ""
                End If
                If Not Convert.IsDBNull(dr("TipoCliente")) Then
                    Me.TipoCliente = dr("TipoCliente")
                Else
                    Me.TipoCliente = ""
                End If
                If Not Convert.IsDBNull(dr("TipoEvento")) Then
                    Me.TipoEvento = dr("TipoEvento")
                Else
                    Me.TipoEvento = ""
                End If
                If Not Convert.IsDBNull(dr("incluirAnticipos")) Then
                    Me.incluirAnticipos = CBool(dr("incluirAnticipos"))
                Else
                    Me.incluirAnticipos = False
                End If
                If Not Convert.IsDBNull(dr("incluirPoliticas")) Then
                    Me.incluirPoliticas = CBool(dr("incluirPoliticas"))
                Else
                    Me.incluirPoliticas = False
                End If
                If Not Convert.IsDBNull(dr("cuentaBancaria")) Then
                    Me.cuentaBancaria = dr("cuentaBancaria")
                Else
                    Me.cuentaBancaria = ""
                End If
                If Not Convert.IsDBNull(dr("tiempoEntrega")) Then
                    Me.tiempoEntrega = dr("tiempoEntrega")
                Else
                    Me.tiempoEntrega = ""
                End If

                If Not Convert.IsDBNull(dr("NumeroEF")) Then
                    Me.NumeroEF = dr("NumeroEF")
                Else
                    Me.NumeroEF = ""
                End If
                If Not Convert.IsDBNull(dr("NumeroIF")) Then
                    Me.NumeroIF = dr("NumeroIF")
                Else
                    Me.NumeroIF = ""
                End If
                If Not Convert.IsDBNull(dr("ColoniaF")) Then
                    Me.ColoniaF = dr("ColoniaF")
                Else
                    Me.ColoniaF = ""
                End If
                If Not Convert.IsDBNull(dr("ReferenciaF")) Then
                    Me.ReferenciaF = dr("ReferenciaF")
                Else
                    Me.ReferenciaF = ""
                End If
                If Not Convert.IsDBNull(dr("MunicipioF")) Then
                    Me.MunicipioF = dr("MunicipioF")
                Else
                    Me.MunicipioF = ""
                End If


                If Not Convert.IsDBNull(dr("SucursalDestino")) Then
					Me.SucursalDestino = dr("SucursalDestino")
                End If

                If Not Convert.IsDBNull(dr("idInstancia")) Then
                    Me.idInstancia = CInt(dr("idInstancia"))
                End If



                If Not Convert.IsDBNull(dr("claveBancaria")) Then
                    Me.claveBancaria = dr("claveBancaria")
                Else
                    Me.claveBancaria = ""
                End If
                If Not Convert.IsDBNull(dr("IncluirObservacionFactura")) Then
                    Me.IncluirObservacionFactura = dr("IncluirObservacionFactura")
                End If

                If Not Convert.IsDBNull(dr("DomiSolicitarObservaciones")) Then
                    Me.DomiSolicitarObservaciones = dr("DomiSolicitarObservaciones")
                End If
            End If
            dr.Close()

        End Sub

		Public Function Add() As Integer
            Dim sql As String = "insert into Ordenes (idUserProfile, status, idTipoTarjeta, numeroCuenta, mes, year, nombre, numeroExtra, nombreE, direccionE, " _
         & "ciudadE, idPaisE, idEstadoE, cpE, telefonoE, subtotal, impuesto, costoEnvio, descuento, costoAdicional, total, tipoCambio, totalDollar, fechaOrden, " _
         & "fechaUltimaActualizacion, idTipoEnvio, nombreF, rfc, direccionF, ciudadF, idPaisF, idEstadoF, cpF, telefonoF, facturar, folio, tipoPago, respuesta, " _
         & "eliminado, tempid, email, fechaEntrega, requiereFacturacion, NombreEmpresa, Observaciones, Condiciones, DescuentoServicios, " _
         & " proyectoEnTramiteClave, proyectoEnTramite, proyectoEnTramiteFecha, fechaCompromiso, envioGuia, envioFecha, mercanciaLista, mercanciaListaFecha, tempidFecha, costoExpress, generadoPorCliente, " _
         & " ComoConocio, FormaContacto, TipoCliente, TipoEvento, incluirAnticipos, incluirPoliticas, cuentaBancaria, tiempoEntrega,  NumeroEF, NumeroIF, ColoniaF, ReferenciaF, MunicipioF, idInstancia, claveBancaria,  IncluirObservacionFactura, DomiSolicitarObservaciones) values (@idUserProfile, @status, @idTipoTarjeta, @numeroCuenta, @mes, @year, @nombre, @numeroExtra, @nombreE, @direccionE, " _
         & "@ciudadE, @idPaisE, @idEstadoE, @cpE, @telefonoE, @subtotal, @impuesto, @costoEnvio, @descuento, @costoAdicional, @total, @tipoCambio, " _
         & "@totalDollar, @fechaOrden, @fechaUltimaActualizacion, @idTipoEnvio, @nombreF, @rfc, @direccionF, @ciudadF, @idPaisF, @idEstadoF, @cpF, " _
         & "@telefonoF, @facturar, @folio, @tipoPago, @respuesta, @eliminado, @tempid, @email, @fechaEntrega, @requiereFacturacion, @NombreEmpresa, @Observaciones, @Condiciones, @DescuentoServicios, @proyectoEnTramiteClave, @proyectoEnTramite, @proyectoEnTramiteFecha, @fechaCompromiso, @envioGuia, @envioFecha, @mercanciaLista, @mercanciaListaFecha, @tempidFecha, @costoExpress, @generadoPorCliente, @ComoConocio, @FormaContacto, @TipoCliente, @TipoEvento, @incluirAnticipos, @incluirPoliticas, @cuentaBancaria, @tiempoEntrega, @NumeroEF, @NumeroIF, @ColoniaF, @ReferenciaF, @MunicipioF, @idInstancia, @claveBancaria,  @IncluirObservacionFactura, @DomiSolicitarObservaciones)"


            Me.generadoPorCliente = True
            Me.folio = getFolio()

            Dim params As SqlParameter() = {
             New SqlParameter("@idUserProfile", Me.idUserProfile),
             New SqlParameter("@status", Me.status.ToString),
             New SqlParameter("@idTipoTarjeta", Me.idTipoTarjeta),
             New SqlParameter("@numeroCuenta", Me.Encriptar(Me.numeroCuenta)),
             New SqlParameter("@mes", Me.Encriptar(Me.mes)),
             New SqlParameter("@year", Me.Encriptar(Me.year)),
             New SqlParameter("@nombre", Me.Encriptar(Me.nombre)),
             New SqlParameter("@numeroExtra", Me.Encriptar(Me.numeroExtra)),
             New SqlParameter("@nombreE", Me.nombreE),
             New SqlParameter("@direccionE", Me.direccionE),
             New SqlParameter("@ciudadE", Me.ciudadE),
             New SqlParameter("@idPaisE", Me.idPaisE),
             New SqlParameter("@idEstadoE", Me.idEstadoE),
             New SqlParameter("@cpE", Me.cpE),
             New SqlParameter("@telefonoE", Me.telefonoE),
             New SqlParameter("@subtotal", Round(Me.subtotal, 2)),
             New SqlParameter("@impuesto", Round(Me.impuesto, 2)),
             New SqlParameter("@costoEnvio", Round(Me.costoEnvio, 2)),
             New SqlParameter("@descuento", Round(Me.descuento, 2)),
             New SqlParameter("@costoAdicional", Round(Me.costoAdicional, 2)),
             New SqlParameter("@total", Round(Me.total, 2)),
             New SqlParameter("@tipoCambio", Round(Me.tipoCambio, 2)),
             New SqlParameter("@totalDollar", Round(Me.totalDollar, 2)),
             New SqlParameter("@fechaOrden", Me.fechaOrden),
             New SqlParameter("@fechaUltimaActualizacion", Me.fechaUltimaActualizacion),
             New SqlParameter("@idTipoEnvio", Me.idTipoEnvio),
             New SqlParameter("@nombreF", Me.nombreF),
             New SqlParameter("@rfc", Me.rfc),
             New SqlParameter("@direccionF", Me.direccionF),
             New SqlParameter("@ciudadF", Me.ciudadF),
             New SqlParameter("@idPaisF", Me.idPaisF),
             New SqlParameter("@idEstadoF", Me.idEstadoF),
             New SqlParameter("@cpF", Me.cpF),
             New SqlParameter("@telefonoF", Me.telefonoF),
             New SqlParameter("@facturar", Me.facturar),
             New SqlParameter("@folio", Me.folio),
             New SqlParameter("@tipoPago", Me.tipoPago),
             New SqlParameter("@respuesta", Me.respuesta),
             New SqlParameter("@eliminado", Me.eliminado),
             New SqlParameter("@tempid", Me.tempid),
             New SqlParameter("@email", Me.email),
             New SqlParameter("@fechaEntrega", Me.fechaEntrega),
             New SqlParameter("@requiereFacturacion", Me.requiereFacturacion),
             New SqlParameter("@NombreEmpresa", Me.NombreEmpresa),
             New SqlParameter("@Observaciones", Me.Observaciones),
             New SqlParameter("@Condiciones", Me.Condiciones),
             New SqlParameter("@DescuentoServicios", Round(Me.Descuentoservicios, 2)),
               New SqlParameter("@proyectoEnTramiteClave", Me.proyectoEnTramiteClave),
             New SqlParameter("@proyectoEnTramite", Me.proyectoEnTramite),
             New SqlParameter("@proyectoEnTramiteFecha", Me.proyectoEnTramiteFecha),
             New SqlParameter("@fechaCompromiso", Me.fechaCompromiso),
             New SqlParameter("@envioGuia", Me.envioGuia),
             New SqlParameter("@envioFecha", Me.envioFecha),
             New SqlParameter("@mercanciaLista", Me.mercanciaLista),
             New SqlParameter("@mercanciaListaFecha", Me.mercanciaListaFecha),
             New SqlParameter("@tempidFecha", Me.tempidFecha),
                 New SqlParameter("@generadoPorCliente", Me.generadoPorCliente),
             New SqlParameter("@costoExpress", Round(Me.costoExpress, 2)),
             New SqlParameter("@ComoConocio", Me.ComoConocio),
             New SqlParameter("@FormaContacto", Me.FormaContacto),
                 New SqlParameter("@TipoCliente", Me.TipoCliente),
             New SqlParameter("@TipoEvento", Me.TipoEvento),
             New SqlParameter("@incluirAnticipos", Me.incluirAnticipos),
             New SqlParameter("@incluirPoliticas", Me.incluirPoliticas),
                 New SqlParameter("@cuentabancaria", Me.cuentaBancaria),
             New SqlParameter("@tiempoEntrega", Me.tiempoEntrega),
                New SqlParameter("@NumeroEF", Me.NumeroEF),
             New SqlParameter("@NumeroIF", Me.NumeroIF),
             New SqlParameter("@ColoniaF", Me.ColoniaF),
             New SqlParameter("@ReferenciaF", Me.ReferenciaF),
             New SqlParameter("@MunicipioF", Me.MunicipioF),
             New SqlParameter("@idInstancia", Me.idInstancia),
             New SqlParameter("@claveBancaria", Me.claveBancaria),
             New SqlParameter("@IncluirObservacionFactura", Me.IncluirObservacionFactura),
             New SqlParameter("@DomiSolicitarObservaciones", Me.DomiSolicitarObservaciones)}

            Me.idOrden = Me.ExecuteNonQuery(sql, params, True)
			Me.existe = True
			Return 1
		End Function

        '============================= 2010 ======================== START
        Public Function Update() As Integer
            Dim sql As String = "UPDATE Ordenes SET status=@status, idTipoTarjeta=@idTipoTarjeta, numeroCuenta=@numeroCuenta, mes=@mes, year=@year, " _
             & "nombre=@nombre, numeroExtra=@numeroExtra, nombreE=@nombreE, direccionE=@direccionE, ciudadE=@ciudadE, idPaisE=@idPaisE, " _
             & "idEstadoE=@idEstadoE, cpE=@cpE, telefonoE=@telefonoE, subtotal=@subtotal, impuesto=@impuesto, costoEnvio=@costoEnvio, descuento=@descuento, " _
             & "costoAdicional=@costoAdicional, total=@total, tipoCambio=@tipoCambio, totalDollar=@totalDollar, fechaOrden=@fechaOrden, " _
             & "fechaUltimaActualizacion=@fechaUltimaActualizacion, idTipoEnvio=@idTipoEnvio, nombreF=@nombreF, rfc=@rfc, direccionF=@direccionF, " _
             & "ciudadF=@ciudadF, idPaisF=@idPaisF, idEstadoF=@idEstadoF, cpF=@cpF, telefonoF=@telefonoF, facturar=@facturar, folio=@folio, tipoPago=@tipoPago, " _
             & "respuesta=@respuesta, eliminado=@eliminado, tempid=@tempid, email=@email, fechaEntrega=@fechaEntrega, RequiereFacturacion=@requiereFacturacion, " _
             & "NombreEmpresa=@NombreEmpresa, Observaciones=@Observaciones, Condiciones=@Condiciones, Descuentoservicios=@DescuentoServicios,  proyectoEnTramiteClave=@proyectoEnTramiteClave, proyectoEnTramite=@proyectoEnTramite, proyectoEnTramiteFecha=@proyectoEnTramiteFecha, fechaCompromiso=@fechaCompromiso, envioGuia=@envioGuia, envioFecha=@envioFecha, mercanciaLista=@mercanciaLista, mercanciaListaFecha=@mercanciaListaFecha, tempidFecha=@tempidFecha, costoExpress=@costoExpress, generadoPorCliente=@generadoPorCliente, ComoConocio=@ComoConocio, FormaContacto=@FormaContacto, TipoCliente=@TipoCliente, TipoEvento=@TipoEvento, incluirAnticipos=@incluirAnticipos, incluirPoliticas=@incluirPoliticas, cuentaBancaria=@cuentaBancaria, tiempoEntrega=@tiempoEntrega, NumeroEF=@NumeroEF, NumeroIF=@NumeroIF, ColoniaF=@ColoniaF, ReferenciaF=@ReferenciaF, MunicipioF=@MunicipioF, idInstancia=@idInstancia, claveBancaria=@claveBancaria, IncluirObservacionFactura=@IncluirObservacionFactura, DomiSolicitarObservaciones=@DomiSolicitarObservaciones   WHERE idOrden=@idOrden"

            Me.subtotal = getTotalProductos()
            Me.fechaUltimaActualizacion = Date.Now
            Me.costoAdicional = getTotalServicios()
            Me.descuento = getTotalProductosDescuentos()
            Me.Descuentoservicios = getTotalServiciosDescuentos()

            Me.impuesto = (Me.subtotal + Me.costoAdicional + Me.costoEnvio + Me.costoExpress - Me.descuento - Me.Descuentoservicios) * (16 / 100)
            Me.total = Me.subtotal + Me.costoAdicional + Me.costoEnvio + Me.costoExpress - Me.descuento - Me.Descuentoservicios + Me.impuesto

            Dim params As SqlParameter() = {
             New SqlParameter("@idOrden", Me.idOrden),
             New SqlParameter("@status", Me.status.ToString),
             New SqlParameter("@idTipoTarjeta", Me.idTipoTarjeta),
             New SqlParameter("@numeroCuenta", Me.Encriptar(Me.numeroCuenta)),
             New SqlParameter("@mes", Me.Encriptar(Me.mes)),
             New SqlParameter("@year", Me.Encriptar(Me.year)),
             New SqlParameter("@nombre", Me.Encriptar(Me.nombre)),
             New SqlParameter("@numeroExtra", Me.Encriptar(Me.numeroExtra)),
             New SqlParameter("@nombreE", Me.nombreE),
             New SqlParameter("@direccionE", Me.direccionE),
             New SqlParameter("@ciudadE", Me.ciudadE),
             New SqlParameter("@idPaisE", Me.idPaisE),
             New SqlParameter("@idEstadoE", Me.idEstadoE),
             New SqlParameter("@cpE", Me.cpE),
             New SqlParameter("@telefonoE", Me.telefonoE),
             New SqlParameter("@subtotal", Round(Me.subtotal, 2)),
             New SqlParameter("@impuesto", Round(Me.impuesto, 2)),
             New SqlParameter("@costoEnvio", Round(Me.costoEnvio, 2)),
             New SqlParameter("@descuento", Round(Me.descuento, 2)),
             New SqlParameter("@costoAdicional", Round(Me.costoAdicional, 2)),
             New SqlParameter("@total", Round(Me.total, 2)),
             New SqlParameter("@tipoCambio", Round(Me.tipoCambio, 2)),
             New SqlParameter("@totalDollar", Round(Me.totalDollar, 2)),
             New SqlParameter("@fechaOrden", Me.fechaOrden),
             New SqlParameter("@fechaUltimaActualizacion", Me.fechaUltimaActualizacion),
             New SqlParameter("@idTipoEnvio", Me.idTipoEnvio),
             New SqlParameter("@nombreF", Me.nombreF),
             New SqlParameter("@rfc", Me.rfc),
             New SqlParameter("@direccionF", Me.direccionF),
             New SqlParameter("@ciudadF", Me.ciudadF),
             New SqlParameter("@idPaisF", Me.idPaisF),
             New SqlParameter("@idEstadoF", Me.idEstadoF),
             New SqlParameter("@cpF", Me.cpF),
             New SqlParameter("@telefonoF", Me.telefonoF),
             New SqlParameter("@facturar", Me.facturar),
             New SqlParameter("@folio", Me.folio),
             New SqlParameter("@tipoPago", Me.tipoPago),
             New SqlParameter("@respuesta", Me.respuesta),
             New SqlParameter("@eliminado", Me.eliminado),
             New SqlParameter("@tempid", Me.tempid),
             New SqlParameter("@email", Me.email),
             New SqlParameter("@fechaEntrega", Me.fechaEntrega),
             New SqlParameter("@requiereFacturacion", Me.requiereFacturacion),
             New SqlParameter("@NombreEmpresa", Me.NombreEmpresa),
             New SqlParameter("@Observaciones", Me.Observaciones),
             New SqlParameter("@Condiciones", Me.Condiciones),
             New SqlParameter("@DescuentoServicios", Round(Me.Descuentoservicios, 2)),
               New SqlParameter("@proyectoEnTramiteClave", Me.proyectoEnTramiteClave),
             New SqlParameter("@proyectoEnTramite", Me.proyectoEnTramite),
             New SqlParameter("@proyectoEnTramiteFecha", Me.proyectoEnTramiteFecha),
             New SqlParameter("@fechaCompromiso", Me.fechaCompromiso),
             New SqlParameter("@envioGuia", Me.envioGuia),
             New SqlParameter("@envioFecha", Me.envioFecha),
             New SqlParameter("@mercanciaLista", Me.mercanciaLista),
             New SqlParameter("@mercanciaListaFecha", Me.mercanciaListaFecha),
             New SqlParameter("@tempidFecha", Me.tempidFecha),
                 New SqlParameter("@generadoPorCliente", Me.generadoPorCliente),
             New SqlParameter("@costoExpress", Round(Me.costoExpress, 2)),
             New SqlParameter("@ComoConocio", Me.ComoConocio),
             New SqlParameter("@FormaContacto", Me.FormaContacto),
                 New SqlParameter("@TipoCliente", Me.TipoCliente),
             New SqlParameter("@TipoEvento", Me.TipoEvento),
             New SqlParameter("@incluirAnticipos", Me.incluirAnticipos),
             New SqlParameter("@incluirPoliticas", Me.incluirPoliticas),
                 New SqlParameter("@cuentabancaria", Me.cuentaBancaria),
             New SqlParameter("@tiempoEntrega", Me.tiempoEntrega),
                New SqlParameter("@NumeroEF", Me.NumeroEF),
             New SqlParameter("@NumeroIF", Me.NumeroIF),
             New SqlParameter("@ColoniaF", Me.ColoniaF),
             New SqlParameter("@ReferenciaF", Me.ReferenciaF),
             New SqlParameter("@MunicipioF", Me.MunicipioF),
             New SqlParameter("@idInstancia", Me.idInstancia),
             New SqlParameter("@claveBancaria", Me.claveBancaria),
             New SqlParameter("@IncluirObservacionFactura", Me.IncluirObservacionFactura),
             New SqlParameter("@DomiSolicitarObservaciones", Me.DomiSolicitarObservaciones)}


            Return Me.ExecuteNonQuery(sql, params)
        End Function
        '============================= 2010 ======================== END

        Private Function getTotalProductos() As Decimal
            Dim myod As New OrdenDetalle
            Dim myodps As New tienda.OrdendetalleProductoServicio
            Dim dr As SqlDataReader = myod.getDR(Me.idOrden)
            Dim totalproductos As Decimal = 0

            Do While dr.Read
                totalproductos = totalproductos + CDec(dr("total"))

            Loop
            dr.Close()


            Return Round(totalproductos, 2)

        End Function
        Private Function getTotalProductosDescuentos() As Decimal
            Dim myod As New OrdenDetalle
            Dim myodps As New tienda.OrdendetalleProductoServicio
            Dim dr As SqlDataReader = myod.getDR(Me.idOrden)
            Dim totalproductosdescuento As Decimal = 0

            Do While dr.Read
                totalproductosdescuento = totalproductosdescuento + CDec(dr("descuento"))

            Loop
            dr.Close()


            Return Round(totalproductosdescuento, 2)

        End Function

        Private Function getTotalServicios() As Decimal

            Dim mysql As String = "select SUM(odps.total) as num  from OrdenesDetallesProductosServicios odps, OrdenesDetalles od where od.idOrdenDetalle = odps.idOrdenDetalle and od.idOrden = @idOrden"
            Dim params As SqlParameter() = { _
          New SqlParameter("@idOrden", Me.idOrden)}

            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, params)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return Round(regreso, 2)

        End Function

        Private Function getTotalServiciosDescuentos() As Decimal
            Dim mysql As String = "select SUM(odps.descuento) as num  from OrdenesDetallesProductosServicios odps, OrdenesDetalles od where od.idOrdenDetalle = odps.idOrdenDetalle and od.idOrden = @idOrden"
            Dim params As SqlParameter() = { _
          New SqlParameter("@idOrden", Me.idOrden)}

            Dim dr As SqlDataReader = Me.ExecuteReader(mysql, params)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()


            Return Round(regreso, 2)

        End Function

        Private Function getFolio() As Integer
            Dim sql As String = "select top 1 folio from Ordenes where generadoPorCliente=1 order by folio desc"
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, Nothing)
            Dim regreso As Integer = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("folio")) Then
                    regreso = CInt(dr("folio"))
                End If
            End If
            dr.Close()

            Return regreso + 1
        End Function

		Public Function Remove() As Integer
			Me.eliminado = True
			Me.Update()
		End Function

		Public Function GetDS() As DataSet
            Dim queryString As String = "SELECT o.idOrden, o.status, ISNULL(u.nombre + ' ' + u.apellidos, '---') AS fullName, ISNULL(aux.productos, 0) AS productos, o.total, " _
             & "o.generadoPorCliente, o.fechaOrden, o.fechaUltimaActualizacion, o.tempid FROM Ordenes AS o LEFT OUTER JOIN UserProfiles AS u ON o.idUserProfile = u.idUserProfile LEFT OUTER JOIN " _
             & " (SELECT idOrden, COUNT(*) AS productos FROM OrdenesDetalles GROUP BY idOrden) AS aux ON o.idOrden = aux.idOrden WHERE o.eliminado = 0 " _
             & "ORDER BY fechaOrden DESC"

			Return Me.ExecuteDataSet(queryString, Nothing)
		End Function

		Public Function GetDR() As SqlDataReader
            Dim queryString As String = "SELECT o.idOrden, o.status, ISNULL(u.nombre + ' ' + u.apellidos, '---') AS fullName, ISNULL(aux.productos, 0) AS productos, o.total, " _
             & "o.generadoPorCliente, o.fechaOrden, o.fechaUltimaActualizacion, o.tempid FROM Ordenes AS o LEFT OUTER JOIN UserProfiles AS u ON o.idUserProfile = u.idUserProfile LEFT OUTER JOIN " _
             & " (SELECT idOrden, COUNT(*) AS productos FROM OrdenesDetalles GROUP BY idOrden) AS aux ON o.idOrden = aux.idOrden WHERE o.eliminado = 0 " _
             & "ORDER BY fechaOrden DESC"

			Return Me.ExecuteReader(queryString, Nothing)
		End Function

        Public Function GetDS(ByVal claveUser As Integer) As DataSet
            Dim queryString As String = "SELECT o.idOrden, o.status, ISNULL(u.nombre + ' ' + u.apellidos, '---') AS fullName, ISNULL(aux.productos, 0) AS productos, o.total, o.ProyectoEntramiteFecha, o.NombreF, o.RFC, " _
   & "o.generadoPorCliente, o.fechaOrden, o.fechaUltimaActualizacion, o.tempid FROM Ordenes AS o LEFT OUTER JOIN UserProfiles AS u ON o.idUserProfile = u.idUserProfile LEFT OUTER JOIN " _
   & " (SELECT idOrden, COUNT(*) AS productos FROM OrdenesDetalles GROUP BY idOrden) AS aux ON o.idOrden = aux.idOrden WHERE o.eliminado = 0 and o.idUserProfile = @idUserProfile " _
   & "ORDER BY fechaOrden DESC"
            'Dim queryString As String = "SELECT * FROM Ordenes WHERE idUserProfile = @idUserProfile ORDER BY fechaOrden DESC"
            Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

		Public Function GetDR(ByVal claveUser As Integer) As SqlDataReader
			Dim queryString As String = "SELECT * FROM Ordenes WHERE idUserProfile = @idUserProfile ORDER BY fechaOrden DESC"
			Dim parametros As SqlParameter() = {New SqlParameter("@idUserProfile", claveUser)}

			Return Me.ExecuteReader(queryString, parametros)
		End Function

        Public Function GetDS(ByVal status As StatusOrden) As DataSet

            Dim queryString As String = "SELECT * FROM Ordenes WHERE status = @status ORDER BY fechaOrden DESC"
            Dim parametros As SqlParameter() = {New SqlParameter("@status", status.ToString)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

		Public Function GetDR(ByVal status As StatusOrden) As SqlDataReader
			Dim queryString As String = "SELECT * FROM Ordenes WHERE status = @status ORDER BY fechaOrden DESC"
			Dim parametros As SqlParameter() = {New SqlParameter("@status", status.ToString)}

			Return Me.ExecuteReader(queryString, parametros)
        End Function



        '==================================== 2010 ============================== START
        Public Function GetDR(ByVal claveOrden As Integer, ByVal claveIdioma As Integer) As SqlDataReader
            Dim queryString As String = "SELECT aux.idOrdendetalle, aux.idProducto, aux.clave, aux.cantidad, aux.costoUnitario, aux.total, aux.nombre, aux.imagen, " _
             & "ISNULL(SUM(odps.total), 0) AS servicios FROM (SELECT od.idOrdendetalle, od.idProducto, p.clave, od.cantidad, od.costoUnitario, od.total, pi.nombre, pf.imagen " _
             & "FROM Ordenesdetalles AS od INNER JOIN Productos AS p ON od.idProducto = p.idProducto INNER JOIN ProductosIdiomas AS pi ON od.idProducto = pi.idProducto " _
             & "LEFT OUTER JOIN ProductosFotos AS pf ON od.idProducto = pf.idProducto AND pf.principal = 1 WHERE od.idOrden = @idOrden AND pi.idIdioma = @idIdioma) AS aux " _
             & "LEFT OUTER JOIN OrdenesdetallesProductosServicios AS odps ON aux.idOrdendetalle = odps.idOrdendetalle GROUP BY aux.idOrdendetalle, aux.idProducto, " _
             & "aux.clave, aux.cantidad, aux.costoUnitario, aux.total, aux.nombre, aux.imagen"

            Dim parametros As SqlParameter() = {New SqlParameter("@idOrden", claveOrden), New SqlParameter("@idIdioma", claveIdioma)}

            Return Me.ExecuteReader(queryString, parametros)
        End Function
        '==================================== 2010 ============================== END

	End Class
End Namespace
