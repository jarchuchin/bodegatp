Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms


Namespace tienda


    Public Class Compra
        Inherits DBObject

        Public idCompra As Integer
        Public idFabricante As Integer
        Public TipoPago As String
        Public Modalidad As String
        Public FechaPago As Date
        Public NombreContacto As String
        Public RemisionFactura As String
        Public Guia As String
        Public DatosBancarios As String
        Public Clabe As String
        Public Subtotal As Decimal
        Public iva As Decimal
        Public Total As Decimal
        Public Eliminado As Boolean
        Public Fecha As DateTime
        Public idUserProfile As Integer
        Public Aprobado As Boolean
        Public idUserProfileAprobacion As Integer
        Public fechaAprobacion As DateTime
        Public EmailContacto As String
        Public Status As String ' Revision, Ok, Cancelada, 
        Public OrdenFile As String
        Public EnviarA As String
        Public Observaciones As String = ""
        Public FechaCompromiso As DateTime
        Public Entregado As Boolean = False
        Public EntregadoFecha As DateTime
        Public EntregadoUsuario As Integer = 0
        Public EntregadoObservaciones As String = ""
        Public idInstancia As Integer = 1


        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from Compras where idCompra=@idCompra"
            Dim params As SqlParameter() = { _
  New SqlParameter("@idCompra", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idCompra = CInt(dr("idCompra"))
                Me.idFabricante = CInt(dr("idFabricante"))
                Me.TipoPago = dr("TipoPago")
                Me.Modalidad = dr("Modalidad")
                Me.FechaPago = CDate(dr("FechaPago"))
                Me.NombreContacto = dr("NombreContacto")
                Me.RemisionFactura = dr("RemisionFactura")
                Me.Guia = dr("Guia")
                Me.DatosBancarios = dr("DatosBancarios")
                Me.Clabe = dr("Clabe")
                Me.Subtotal = CDec(dr("Subtotal"))
                Me.iva = CDec(dr("iva"))
                Me.Total = CDec(dr("total"))
                Me.Eliminado = CBool(dr("eliminado"))
                Me.Fecha = CDate(dr("fecha"))
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.Aprobado = CBool(dr("Aprobado"))
                Me.idUserProfileAprobacion = CInt(dr("idUserProfileAprobacion"))
                Me.fechaAprobacion = CDate(dr("fechaAprobacion"))

                If Convert.IsDBNull(dr("EmailContacto")) Then
                    Me.EmailContacto = ""
                Else
                    Me.EmailContacto = dr("EmailContacto")
                End If

                If Convert.IsDBNull(dr("Status")) Then
                    Me.Status = "na"
                Else
                    Me.Status = dr("Status")
                End If

                If Convert.IsDBNull(dr("OrdenFile")) Then
                    Me.OrdenFile = ""
                Else
                    Me.OrdenFile = dr("OrdenFile")
                End If

                If Convert.IsDBNull(dr("EnviarA")) Then
                    Me.EnviarA = ""
                Else
                    Me.EnviarA = dr("EnviarA")
                End If

                If Convert.IsDBNull(dr("Observaciones")) Then
                    Me.Observaciones = ""
                Else
                    Me.Observaciones = dr("Observaciones")
                End If

                If Convert.IsDBNull(dr("FechaCompromiso")) Then
                    Me.FechaCompromiso = DateTime.MinValue
                Else
                    Me.FechaCompromiso = CType(dr("FechaCompromiso"), DateTime)
                End If
                If Convert.IsDBNull(dr("Entregado")) Then
                    Me.Entregado = False
                Else
                    Me.Entregado = CType(dr("Entregado"), Boolean)
                End If
                If Convert.IsDBNull(dr("EntregadoFecha")) Then
                    Me.EntregadoFecha = DateTime.MinValue
                Else
                    Me.EntregadoFecha = CType(dr("EntregadoFecha"), DateTime)
                End If
                If Convert.IsDBNull(dr("EntregadoUsuario")) Then
                    Me.EntregadoUsuario = 0
                Else
                    Me.EntregadoUsuario = CType(dr("EntregadoUsuario"), Integer)
                End If
                If Convert.IsDBNull(dr("EntregadoObservaciones")) Then
                    Me.EntregadoObservaciones = ""
                Else
                    Me.EntregadoObservaciones = dr("EntregadoObservaciones")
                End If

                If Not Convert.IsDBNull(dr("idInstancia")) Then
                    Me.idInstancia = CInt(dr("idInstancia"))
                End If
                existe = True
            End If
            dr.Close()


        End Sub



        Public Function Add() As Integer
            Dim sql As String = "insert into Compras ( idFabricante, TipoPago, Modalidad, FechaPago, NombreContacto, RemisionFactura, Guia, DatosBancarios, Clabe, Subtotal, IVA, Total, Eliminado, fecha, idUserProfile, Aprobado, idUserProfileAprobacion, fechaAprobacion, EmailContacto, status, OrdenFile, EnviarA, Observaciones, FechaCompromiso, Entregado, EntregadoFecha, EntregadoUsuario, EntregadoObservaciones, idInstancia ) values ( @idFabricante, @TipoPago, @Modalidad, @FechaPago, @NombreContacto, @RemisionFactura, @Guia, @DatosBancarios, @Clabe, @Subtotal, @IVA, @Total, @Eliminado, @fecha, @idUserProfile, @Aprobado, @idUserProfileAprobacion, @fechaAprobacion, @EmailContacto, @status, @OrdenFile, @EnviarA, @Observaciones, @FechaCompromiso, @Entregado, @EntregadoFecha, @EntregadoUsuario, @EntregadoObservaciones, @idInstancia)"

            
            Dim params As SqlParameter() = { _
    New SqlParameter("@idFabricante", Me.idFabricante), _
    New SqlParameter("@TipoPago", Me.TipoPago), _
    New SqlParameter("@Modalidad", Me.Modalidad), _
    New SqlParameter("@FechaPago", Me.FechaPago), _
    New SqlParameter("@NombreContacto", Me.NombreContacto), _
    New SqlParameter("@RemisionFactura", Me.RemisionFactura), _
    New SqlParameter("@Guia", Me.Guia), _
    New SqlParameter("@DatosBancarios", Me.DatosBancarios), _
    New SqlParameter("@Clabe", Me.Clabe), _
    New SqlParameter("@Subtotal", Me.Subtotal), _
    New SqlParameter("@IVA", Me.iva), _
    New SqlParameter("@Total", Me.Total), _
    New SqlParameter("@Eliminado", Me.Eliminado), _
    New SqlParameter("@fecha", Me.Fecha), _
    New SqlParameter("@idUserProfile", Me.idUserProfile), _
    New SqlParameter("@Aprobado", Me.Aprobado), _
    New SqlParameter("@idUserProfileAprobacion", Me.idUserProfileAprobacion), _
    New SqlParameter("@fechaAprobacion", Me.fechaAprobacion), _
    New SqlParameter("@EmailContacto", Me.EmailContacto), _
    New SqlParameter("@status", Me.Status), _
    New SqlParameter("@OrdenFile", Me.OrdenFile), _
    New SqlParameter("@EnviarA", Me.EnviarA), _
    New SqlParameter("@FechaCompromiso", Me.FechaCompromiso), _
    New SqlParameter("@Observaciones", Me.Observaciones), _
    New SqlParameter("@Entregado", Me.Entregado), _
    New SqlParameter("@EntregadoFecha", Me.EntregadoFecha), _
    New SqlParameter("@EntregadoUsuario", Me.EntregadoUsuario), _
    New SqlParameter("@EntregadoObservaciones", Me.EntregadoObservaciones), _
    New SqlParameter("@idInstancia", Me.idInstancia)}


            If Me.FechaCompromiso = Date.MinValue Then
                params(22).Value = DBNull.Value
            End If
            If Me.EntregadoFecha = Date.MinValue Then
                params(25).Value = DBNull.Value
            End If

            Me.idCompra = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1

        End Function

        '    Public Function update() As Integer
        '        Dim sql As String = "Update Compras set idFabricante=@idFabricante, TipoPago=@TipoPago, Modalidad=@Modalidad, FechaPago=@FechaPago, NombreContacto=@NombreContacto, RemisionFactura=@RemisionFactura, Guia=@Guia, DatosBancarios=@DatosBancarios, Clabe=@Clabe, Subtotal=@Subtotal, IVA=@IVA, Total=@Total, Eliminado=@Eliminado, fecha=@fecha, idUserProfile=@idUserProfile, Aprobado=@Aprobado, fechaAprobacion=@fechaAprobacion, EmailContacto=@EmailContacto, status=@status, OrdenFile=@OrdenFile, EnviarA=@EnviarA, Observaciones=@Observaciones, FechaCompromiso=@FechaCompromiso, Entregado=@Entregado, EntregadoFecha=@EntregadoFecha, EntregadoUsuario=@EntregadoUsuario, EntregadoObservaciones=@EntregadoObservaciones, idInstancia=@idInstancia  where idCompra=@idCompra"

        '        Dim mycde As New CompraDetalleExtra
        '        Dim mycd As New CompraDetalle
        '        Dim mycsd As New CompraServicioDetalle
        '        Me.Subtotal = mycd.GetSumaCompra(Me.idCompra) + mycde.GetSuma(Me.idCompra) + mycsd.GetSumaCompra(Me.idCompra)
        '        Me.iva = Me.Subtotal * (16 / 100)
        '        Me.Total = Me.Subtotal + Me.iva

        '        Dim params As SqlParameter() = { _
        'New SqlParameter("@idFabricante", Me.idFabricante), _
        'New SqlParameter("@TipoPago", Me.TipoPago), _
        'New SqlParameter("@Modalidad", Me.Modalidad), _
        'New SqlParameter("@FechaPago", Me.FechaPago), _
        'New SqlParameter("@NombreContacto", Me.NombreContacto), _
        'New SqlParameter("@RemisionFactura", Me.RemisionFactura), _
        'New SqlParameter("@Guia", Me.Guia), _
        'New SqlParameter("@DatosBancarios", Me.DatosBancarios), _
        'New SqlParameter("@Clabe", Me.Clabe), _
        'New SqlParameter("@Subtotal", Me.Subtotal), _
        'New SqlParameter("@IVA", Me.iva), _
        'New SqlParameter("@Total", Me.Total), _
        'New SqlParameter("@Eliminado", Me.Eliminado), _
        'New SqlParameter("@idCompra", Me.idCompra), _
        'New SqlParameter("@fecha", Me.Fecha), _
        'New SqlParameter("@idUserProfile", Me.idUserProfile), _
        'New SqlParameter("@Aprobado", Me.Aprobado), _
        'New SqlParameter("@idUserProfileAprobacion", Me.idUserProfileAprobacion), _
        'New SqlParameter("@fechaAprobacion", Me.fechaAprobacion), _
        'New SqlParameter("@EmailContacto", Me.EmailContacto), _
        'New SqlParameter("@status", Me.Status), _
        'New SqlParameter("@OrdenFile", Me.OrdenFile), _
        'New SqlParameter("@EnviarA", Me.EnviarA), _
        'New SqlParameter("@FechaCompromiso", Me.FechaCompromiso), _
        'New SqlParameter("@Observaciones", Me.Observaciones), _
        'New SqlParameter("@Entregado", Me.Entregado), _
        'New SqlParameter("@EntregadoFecha", Me.EntregadoFecha), _
        'New SqlParameter("@EntregadoUsuario", Me.EntregadoUsuario), _
        'New SqlParameter("@EntregadoObservaciones", Me.EntregadoObservaciones), _
        'New SqlParameter("@idInstancia", Me.idInstancia)}



        '        If Me.FechaCompromiso = Date.MinValue Then
        '            params(23).Value = DBNull.Value
        '        End If
        '        If Me.EntregadoFecha = Date.MinValue Then
        '            params(26).Value = DBNull.Value
        '        End If


        '        Return Me.ExecuteNonQuery(sql, params)



        '    End Function

        'Public Function Remove() As Integer
        '    Me.Eliminado = True
        '    Me.update()

        'End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0 and status <> 'Ok' and status <> 'Cancelada'"
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function

        Public Function GetDS2() As DataSet
            Dim sql As String = "select top 40 c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0 and status <> 'Ok' and status <> 'Cancelada'  order by c.fecha desc "

         



            Return Me.ExecuteDataSet(sql, Nothing)

        End Function

        Public Function GetDSFechas(ByVal claveProveedor As Integer, ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataSet

            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0 and c.status = 'Ok' and  c.idFabricante=@idFabricante and c.Fecha>=@fechadesde and c.Fecha<@fechahasta"
            Dim params As SqlParameter() = {New SqlParameter("@idFabricante", claveProveedor), New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        'Public Function GetDSFechasTodos(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataView
        '    claveFechaHasta = claveFechaHasta.AddDays(1)

        '    Dim dTable As New DataTable
        '    dTable.Columns.Add(New DataColumn("idCompra", GetType(Integer)))
        '    dTable.Columns.Add(New DataColumn("fabricante", GetType(String)))
        '    dTable.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        '    dTable.Columns.Add(New DataColumn("fechapago", GetType(DateTime)))
        '    dTable.Columns.Add(New DataColumn("Total", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("Pagos", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("Status", GetType(String)))
        '    dTable.Columns.Add(New DataColumn("dia", GetType(Integer)))
        '    dTable.Columns.Add(New DataColumn("idFabricante", GetType(Integer)))
        '    dTable.Columns.Add(New DataColumn("idInstancia", GetType(Integer)))


        '    Dim sql As String = " select c.idInstancia, c.idFabricante, c.idcompra, fi.nombre as fabricante, c.fecha, day(c.fecha) as dia, c.fechapago,   c.Total from Compras c, FabricantesIdiomas  fi where  fi.idFabricante = c.idFabricante and fi.idIdioma=1 and c.Fecha>=@fechadesde and c.Fecha<@fechahasta and c.status='Ok' order by c.fecha asc"
        '    Dim params As SqlParameter() = {New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta)}
        '    Dim mydr As SqlDataReader = Me.ExecuteReader(sql, params)

        '    Dim dRow As DataRow


        '    Dim myChp As New tienda.ChequeProcedencia

        '    Do While mydr.Read
        '        dRow = dTable.NewRow()
        '        dRow(0) = CInt(mydr("idCompra"))
        '        dRow(1) = mydr("fabricante")
        '        dRow(2) = CDate(mydr("fecha"))
        '        dRow(3) = CDate(mydr("fechapago"))
        '        dRow(4) = CDec(mydr("Total"))

        '        Dim mydrcheques As SqlDataReader = myChp.GetDR(CInt(mydr("idCompra")), "Compra")
        '        Dim suma As Decimal = 0
        '        Do While mydrcheques.Read
        '            Dim mycheque As New tienda.Cheque(mydrcheques("idCheque"))
        '            If System.Math.Round(mycheque.Monto, 2) > System.Math.Round(CDec(mydr("Total")), 2) Then
        '                suma = suma + CDec(mydr("Total"))
        '            Else
        '                suma = suma + mycheque.Monto
        '            End If
        '        Loop

        '        If suma < CDec(mydr("Total")) Then
        '            dRow(6) = "n/a"
        '        Else
        '            dRow(6) = "Pagada"

        '        End If
        '        dRow(5) = suma
        '        dRow(7) = mydr("dia")
        '        dRow(8) = mydr("idFabricante")
        '        dRow(9) = mydr("idInstancia")
        '        dTable.Rows.Add(dRow)

        '    Loop

        '    Dim dv As DataView = dTable.DefaultView
        '    Return dv

        'End Function


        Public Function GetDSFechasTodosBarra(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataView
            claveFechaHasta = claveFechaHasta.AddDays(1)


            Dim sql As String = "select CONVERT(date, c.fecha) as fecha, sum(c.total) as total  from Compras c where c.Fecha>=@fechadesde and c.Fecha<@fechahasta and c.status='Ok' group by CONVERT(date, c.fecha) order by 1 asc "
            Dim params As SqlParameter() = {New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta)}
            Dim myds As DataSet = Me.ExecuteDataSet(sql, params)

            Return myds.Tables(0).DefaultView

        End Function

        Public Function GetDSFechasTodosBarra(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date, claveInstancia As Integer) As DataView
            claveFechaHasta = claveFechaHasta.AddDays(1)


            Dim sql As String = "select CONVERT(date, c.fecha) as fecha, sum(c.total) as total  from Compras c where c.Fecha>=@fechadesde and c.Fecha<@fechahasta and c.status='Ok' and c.idInstancia=@idInstancia group by CONVERT(date, c.fecha) order by 1 asc "
            Dim params As SqlParameter() = {New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta), New SqlParameter("@idInstancia", claveInstancia)}
            Dim myds As DataSet = Me.ExecuteDataSet(sql, params)

            Return myds.Tables(0).DefaultView

        End Function

        Public Function GetDSFechasComprasRecibidas(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataView
            claveFechaHasta = claveFechaHasta.AddDays(1)


            Dim sql As String = "select CONVERT(date, c.Entregadofecha) as fecha, count(c.idCompra ) as total  from Compras c where c.Entregadofecha>=@fechadesde and c.Entregadofecha<@fechahasta and c.status='Ok' and c.Entregado=1  group by CONVERT(date, c.Entregadofecha) order by 1 asc "
            Dim params As SqlParameter() = {New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta)}
            Dim myds As DataSet = Me.ExecuteDataSet(sql, params)

            Return myds.Tables(0).DefaultView

        End Function

        Public Function GetDSFechasComprasRecibidas(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date, claveidInstancia As Integer) As DataView
            claveFechaHasta = claveFechaHasta.AddDays(1)


            Dim sql As String = "select CONVERT(date, c.Entregadofecha) as fecha, count(c.idCompra ) as total  from Compras c where c.Entregadofecha>=@fechadesde and c.Entregadofecha<@fechahasta and c.status='Ok' and c.Entregado=1 and c.idInstancia=@idInstancia group by CONVERT(date, c.Entregadofecha) order by 1 asc "
            Dim params As SqlParameter() = {New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta), New SqlParameter("@idInstancia", claveidInstancia)}
            Dim myds As DataSet = Me.ExecuteDataSet(sql, params)

            Return myds.Tables(0).DefaultView

        End Function


        'Public Function GetDSFechasTodos(claveFabricante As Integer, ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataView

        '    Dim dTable As New DataTable
        '    dTable.Columns.Add(New DataColumn("idCompra", GetType(Integer)))
        '    dTable.Columns.Add(New DataColumn("fabricante", GetType(String)))
        '    dTable.Columns.Add(New DataColumn("fecha", GetType(DateTime)))
        '    dTable.Columns.Add(New DataColumn("fechapago", GetType(DateTime)))
        '    dTable.Columns.Add(New DataColumn("Total", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("Pagos", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("Status", GetType(String)))
        '    dTable.Columns.Add(New DataColumn("IVA", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("Subtotal", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("RemisionFactura", GetType(String)))

        '    dTable.Columns.Add(New DataColumn("TotalFacturas", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("TotalFacturasSaldo", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("TotalFacturasPagadas", GetType(Decimal)))

        '    Dim sql As String = " select c.idcompra, fi.nombre as fabricante, c.fecha, c.fechapago, c.IVA, c.subtotal,   c.Total, c.RemisionFactura, isnull((select sum(cf.Monto) from comprasFacturas cf where cf.idCompra=c.idCompra and cf.eliminado=0),0) as TotalFacturas, isnull((select sum(cf.Monto) from comprasFacturas cf where cf.idCompra=c.idCompra and cf.eliminado=0),0) - isnull((select sum(cf.Monto) from comprasFacturas cf where cf.idCompra=c.idCompra and cf.pagado=1 and cf.eliminado=0),0)  as TotalFacturasSaldo, isnull((select sum(cf.Monto) from comprasFacturas cf where cf.idCompra=c.idCompra and cf.pagado=1 and cf.eliminado=0),0)  as TotalFacturasPagadas from Compras c, FabricantesIdiomas  fi where  fi.idFabricante = c.idFabricante and fi.idIdioma=1 and c.Fecha>=@fechadesde and c.Fecha<@fechahasta and c.idFabricante=@idFabricante and c.status='Ok' order by fi.nombre asc"
        '    Dim params As SqlParameter() = {New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta), New SqlParameter("@idFabricante", claveFabricante)}
        '    Dim mydr As SqlDataReader = Me.ExecuteReader(sql, params)

        '    Dim dRow As DataRow


        '    Dim myChp As New tienda.ChequeProcedencia

        '    Do While mydr.Read
        '        dRow = dTable.NewRow()
        '        dRow(0) = CInt(mydr("idCompra"))
        '        dRow(1) = mydr("fabricante")
        '        dRow(2) = CDate(mydr("fecha"))
        '        dRow(3) = CDate(mydr("fechapago"))
        '        dRow(4) = CDec(mydr("Total"))


        '        Dim mydrcheques As SqlDataReader = myChp.GetDR(CInt(mydr("idCompra")), "Compra")
        '        Dim suma As Decimal = 0
        '        Do While mydrcheques.Read
        '            Dim mycheque As New tienda.Cheque(mydrcheques("idCheque"))
        '            If System.Math.Round(mycheque.Monto, 2) > System.Math.Round(CDec(mydr("Total")), 2) Then
        '                suma = suma + CDec(mydr("Total"))
        '            Else
        '                suma = suma + mycheque.Monto
        '            End If
        '        Loop

        '        If suma < CDec(mydr("Total")) Then
        '            dRow(6) = "n/a"
        '        Else
        '            dRow(6) = "Pagada"

        '        End If
        '        dRow(5) = suma
        '        dRow(7) = CDec(mydr("IVA"))
        '        dRow(8) = CDec(mydr("Subtotal"))
        '        dRow(9) = mydr("RemisionFactura")
        '        dRow(10) = CDec(mydr("TotalFacturas"))
        '        dRow(11) = CDec(mydr("TotalFacturasSaldo"))
        '        dRow(12) = CDec(mydr("TotalFacturasPagadas"))
        '        dTable.Rows.Add(dRow)

        '    Loop

        '    Dim dv As DataView = dTable.DefaultView
        '    Return dv

        'End Function


        'Public Function GetDSFechasConcentradoPorPagarSinFactura(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataView
        '    Dim dTable As New DataTable
        '    dTable.Columns.Add(New DataColumn("clave", GetType(Integer)))
        '    dTable.Columns.Add(New DataColumn("fecha", GetType(DateTime)))

        '    dTable.Columns.Add(New DataColumn("Nombre", GetType(String)))

        '    dTable.Columns.Add(New DataColumn("Subtotal", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("IVA", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("Total", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("Pagos", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("Saldo", GetType(Decimal)))
        '    dTable.Columns.Add(New DataColumn("Tipo", GetType(String)))
        '    dTable.Columns.Add(New DataColumn("Status", GetType(String)))
        '    dTable.Columns.Add(New DataColumn("idFabricante", GetType(Integer)))
        '    dTable.Columns.Add(New DataColumn("fechaPago", GetType(DateTime)))

        '    Dim sql As String = "select c.idCompra as clave, c.fecha, c.fechaPago as fechaPago, fix.Nombre, fix.idFabricante,  c.Subtotal, c.IVA, c.Total, 'Compra' as Tipo  from Compras as c left outer join  FabricantesIdiomas  as fix on c.idFabricante = fix.idFabricante and fix.idIdioma=1 where c.fecha>=@fechadesde and c.fecha<@fechahasta and c.RemisionFactura='' and c.status='Ok' union select ce.idCargoExtra  as clave, ce.fechaRegistro as fecha, ce.fechaPago as fechaPago,  fi.Nombre, fi.idFabricante, ce.Subtotal, ce.IVA, ce.Total, 'Extra' as Tipo  from CargosExtras  as ce left outer join  FabricantesIdiomas  as fi on ce.idFabricante = fi.idFabricante and fi.idIdioma=1 where ce.fechaPago>=@fechadesde and ce.fechaPago<@fechahasta and ce.FacturaFolio='' and ce.Eliminado=0 order by nombre, fecha"
        '    Dim params As SqlParameter() = {New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta)}
        '    Dim mydr As SqlDataReader = Me.ExecuteReader(sql, params)

        '    Dim dRow As DataRow


        '    Dim myChp As New tienda.ChequeProcedencia

        '    Do While mydr.Read
        '        dRow = dTable.NewRow()
        '        dRow(0) = CInt(mydr("clave"))
        '        dRow(1) = CDate(mydr("fecha"))
        '        dRow(2) = mydr("nombre")
        '        dRow(3) = CDec(mydr("Subtotal"))
        '        dRow(4) = CDec(mydr("iva"))
        '        dRow(5) = CDec(mydr("Total"))

        '        Select Case mydr("Tipo")
        '            Case "Compra"

        '                'If CInt(mydr("clave")) = 42 Then
        '                '    Dim regreso As String = "hola"
        '                'End If
        '                Dim mypagos As Decimal = GetPagosACompra(CInt(mydr("clave")))
        '                dRow(6) = mypagos
        '                dRow(7) = CDec(mydr("Total")) - mypagos

        '            Case "Extra"
        '                Dim mydrchequesCargos As SqlDataReader = myChp.GetDR(CInt(mydr("clave")), "Extra")
        '                Dim sumaExtra As Decimal = 0
        '                Do While mydrchequesCargos.Read
        '                    Dim mychequeEx As New tienda.Cheque(mydrchequesCargos("idCheque"))
        '                    If System.Math.Round(mychequeEx.Monto, 2) > System.Math.Round(CDec(mydr("Total")), 2) Then
        '                        sumaExtra = sumaExtra + CDec(mydr("Total"))
        '                    Else
        '                        sumaExtra = sumaExtra + mychequeEx.Monto
        '                    End If
        '                Loop
        '                mydrchequesCargos.Close()


        '                dRow(6) = sumaExtra
        '                dRow(7) = CDec(mydr("Total")) - sumaExtra

        '        End Select



        '        dRow(8) = mydr("Tipo")

        '        If System.Math.Round(dRow(7), 2) > 1 Then
        '            dRow(9) = "No Pagado"
        '        Else
        '            dRow(9) = "Pagado"
        '        End If
        '        dRow(10) = CInt(mydr("idFabricante"))
        '        dRow(11) = CDate(mydr("fechaPago"))

        '        If System.Math.Round(CDec(dRow(7)), 2) > 5 Then
        '            dTable.Rows.Add(dRow)
        '        End If


        '    Loop
        '    mydr.Close()


        '    Dim dv As DataView = dTable.DefaultView
        '    Return dv
        'End Function

       


        Public Function GetDS(ByVal clavestatus As String) As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0 and c.status=@status and c.idCompra not in (select chp.idProc  from chequesProcedencias chp where chp.idProc=c.idCompra and Procedencia='Compra' )"
            Dim params As SqlParameter() = { _
   New SqlParameter("@status", clavestatus)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetDSCompras() As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0 and c.status='Ok'"
            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

        Public Function GetDSReporteCompraPagos() As DataSet
            Dim sql As String = "select c.Fecha, c.total as Total, fi.nombre as Fabricante, 'Compras' as Tipo  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0 and c.status='Ok' union select  ch.FechaEnCheque as Fecha, ch.Monto as Total, fi.nombre as Fabricante, 'Pagos' as Tipo from cheques ch, fabricantesidiomas fi where ch.idFabricante=fi.idfabricante and fi.ididioma=1 and ch.eliminado=0 "
          
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function

        Public Function GetDSReporteCompraPagos(claveAno As Integer) As DataSet
            Dim sql As String = "select c.Fecha, c.total as Total, fi.nombre as Fabricante, 'Compras' as Tipo  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0 and c.status='Ok' and year(c.fecha) = @claveano union select  ch.FechaEnCheque as Fecha, ch.Monto as Total, fi.nombre as Fabricante, 'Pagos' as Tipo from cheques ch, fabricantesidiomas fi where ch.idFabricante=fi.idfabricante and fi.ididioma=1 and ch.eliminado=0 and year(ch.FechaEnCheque) = @claveano "

            Dim params As SqlParameter() = { _
 New SqlParameter("@claveano", claveAno)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetDSProcesadas() As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0   and c.idCompra not in (select chp.idProc  from chequesProcedencias chp where chp.idProc=c.idCompra and Procedencia='Compra' ) and (c.status='OK' or c.status = 'Cancelada') order by c.fecha desc"
            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

        Public Function GetDSProcesadasTodas(claveCompra As Integer) As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0 and c.idCompra=@idCompra and (c.status='OK' or c.status = 'Cancelada')  order by c.fecha desc"

            Dim params As SqlParameter() = {New SqlParameter("@idCompra", claveCompra)}
            Return Me.ExecuteDataSet(sql, params)


        End Function

        Public Function GetDSProcesadasFechas(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataSet
            claveFechaHasta = claveFechaHasta.AddDays(1)

            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.FechaCompromiso>=@fechadesde and c.FechaCompromiso<@fechahasta and c.eliminado=0  and c.idCompra not in (select chp.idProc  from chequesProcedencias chp where chp.idProc=c.idCompra and Procedencia='Compra' )   and (c.status='OK' or c.status = 'Cancelada')  "


            Dim params As SqlParameter() = {New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetDSProcesadasFechasAlmacen(ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataSet
            claveFechaHasta = claveFechaHasta.AddDays(1)

            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.FechaCompromiso>=@fechadesde and c.FechaCompromiso<@fechahasta and c.eliminado=0  and c.idCompra not in (select chp.idProc  from chequesProcedencias chp where chp.idProc=c.idCompra and Procedencia='Compra' )   and (c.status='OK' or c.status = 'Cancelada')  "


            Dim params As SqlParameter() = {New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

    
        Public Function GetDSProcesadas(ByVal clavefabricante As Integer) As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where  c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0  and c.idFabricante=@idFabricante  and c.idCompra not in (select chp.idProc  from chequesProcedencias chp where chp.idProc=c.idCompra and Procedencia='Compra' ) and (c.status='OK' or c.status = 'Cancelada') order by c.fecha desc"
            Dim params As SqlParameter() = { _
New SqlParameter("@idFabricante", clavefabricante)}
            Return Me.ExecuteDataSet(sql, params)

        End Function




        Public Function GetDRCalendarioPagos(ByVal claveFecha As Date) As SqlDataReader
            Dim dia As Integer = claveFecha.Day
            Dim mes As Integer = claveFecha.Month
            Dim ano As Integer = claveFecha.Year
            Dim mysql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0   and c.status='OK' and c.idFabricante<>23 and year(c.fechaPago) = @ano and month(c.fechaPago) = @mes and day(c.fechaPago) = @dia order by c.fecha desc"

            Dim params As SqlParameter() = { _
New SqlParameter("@ano", ano), _
New SqlParameter("@mes", mes), _
New SqlParameter("@dia", dia)}


            Return ExecuteReader(mysql, params)

        End Function
        Public Function GetDSCalendarioPagos(ByVal claveFecha As Date) As DataSet
            Dim dia As Integer = claveFecha.Day
            Dim mes As Integer = claveFecha.Month
            Dim ano As Integer = claveFecha.Year
            Dim mysql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0   and c.status='OK' and c.idFabricante<>23 and year(c.fechaPago) = @ano and month(c.fechaPago) = @mes and day(c.fechaPago) = @dia order by c.fecha desc"

            Dim params As SqlParameter() = { _
New SqlParameter("@ano", ano), _
New SqlParameter("@mes", mes), _
New SqlParameter("@dia", dia)}


            Return ExecuteDataSet(mysql, params)

        End Function

        Public Function GetDSParaTaller() As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0  and c.idFabricante=23 and c.status='OK'  order by c.fecha desc"
            'and c.idFabricante=23
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function

        Public Function GetDSParaTaller(ByVal claveFecha As Date) As SqlDataReader
            Dim dia As Integer = claveFecha.Day
            Dim mes As Integer = claveFecha.Month
            Dim ano As Integer = claveFecha.Year
            Dim mysql As String = "select c.*, fi.nombre as fabricante  from compras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0   and c.idFabricante=23 and year(c.fechaCompromiso) = @ano and month(c.fechaCompromiso) = @mes and day(c.fechaCompromiso) = @dia order by c.fecha desc"

            Dim params As SqlParameter() = { _
New SqlParameter("@ano", ano), _
New SqlParameter("@mes", mes), _
New SqlParameter("@dia", dia)}


            Return ExecuteReader(mysql, params)

        End Function

    End Class


End Namespace