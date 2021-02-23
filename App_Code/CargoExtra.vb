Imports System.Data
Imports System.Data.SqlClient


Namespace tienda


    Public Class CargoExtra
        Inherits DBObject

        Public idCargoExtra As Integer
        Public idOrden As Integer
        Public idFabricante As Integer
        Public FacturaFolio As String
        Public FechaPago As DateTime
        Public FechaRegistro As DateTime
        Public DatosBancarios As String
        Public Clabe As String
        Public IVA As Decimal
        Public Subtotal As Decimal
        Public Total As Decimal
        Public Aprobado As Boolean
        Public idUserProfileAprobacion As Integer
        Public FechaAprobacion As DateTime
        Public CargoExtraFile As String
        Public Observaciones As String
        Public Eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from CargosExtras where idCargoExtra=@idCargoExtra"
            Dim params As SqlParameter() = { _
  New SqlParameter("@idCargoExtra", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idCargoExtra = CInt(dr("idCargoExtra"))
                Me.idOrden = CInt(dr("idOrden"))
                Me.idFabricante = CInt(dr("idFabricante"))
                Me.FacturaFolio = dr("FacturaFolio")
                Me.FechaPago = CDate(dr("FechaPago"))
                Me.FechaRegistro = CDate(dr("FechaRegistro"))
                Me.DatosBancarios = dr("DatosBancarios")
                Me.Clabe = dr("Clabe")
        
                Me.Subtotal = CDec(dr("Subtotal"))
                Me.iva = CDec(dr("iva"))
                Me.Total = CDec(dr("total"))
                Me.Aprobado = CBool(dr("Aprobado"))
                Me.idUserProfileAprobacion = CInt(dr("idUserProfileAprobacion"))
                Me.FechaAprobacion = CDate(dr("fechaAprobacion"))
                Me.CargoExtraFile = dr("CargoExtraFile")
                Me.Observaciones = dr("Observaciones")
                Me.Eliminado = CBool(dr("eliminado"))
                

                existe = True
            End If
            dr.Close()


        End Sub



        Public Function Add() As Integer
            Dim sql As String = "insert into CargosExtras (idOrden, idFabricante, FacturaFolio, FechaPago, FechaRegistro, DatosBancarios, Clabe, IVA, Subtotal, Total, Aprobado, idUserProfileAprobacion, FechaAprobacion, CargoExtraFile, Observaciones, Eliminado) values ( @idOrden, @idFabricante, @FacturaFolio, @FechaPago, @FechaRegistro, @DatosBancarios, @Clabe, @IVA, @Subtotal, @Total, @Aprobado, @idUserProfileAprobacion, @FechaAprobacion, @CargoExtraFile, @Observaciones, @Eliminado)"


            Dim params As SqlParameter() = { _
            New SqlParameter("@idOrden", Me.idOrden), _
    New SqlParameter("@idFabricante", Me.idFabricante), _
    New SqlParameter("@FacturaFolio", Me.FacturaFolio), _
    New SqlParameter("@FechaPago", Me.FechaPago), _
    New SqlParameter("@FechaRegistro", Me.FechaRegistro), _
    New SqlParameter("@DatosBancarios", Me.DatosBancarios), _
    New SqlParameter("@Clabe", Me.Clabe), _
    New SqlParameter("@IVA", Me.IVA), _
    New SqlParameter("@Subtotal", Me.Subtotal), _
    New SqlParameter("@Total", Me.Total), _
     New SqlParameter("@Aprobado", Me.Aprobado), _
    New SqlParameter("@idUserProfileAprobacion", Me.idUserProfileAprobacion), _
    New SqlParameter("@fechaAprobacion", Me.FechaAprobacion), _
    New SqlParameter("@CargoExtraFile", Me.CargoExtraFile), _
    New SqlParameter("@Observaciones", Me.Observaciones), _
    New SqlParameter("@Eliminado", Me.Eliminado)}

            Me.idCargoExtra = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1

        End Function

        Public Function update() As Integer
            Dim sql As String = "Update CargosExtras set idOrden=@idOrden, idFabricante=@idFabricante, FacturaFolio=@FacturaFolio, FechaPago=@FechaPago, FechaRegistro=@FechaRegistro, DatosBancarios=@DatosBancarios, Clabe=@Clabe, IVA=@IVA, Subtotal=@Subtotal, Total=@Total, Aprobado=@Aprobado, idUserProfileAprobacion=@idUserProfileAprobacion, FechaAprobacion=@FechaAprobacion, CargoExtraFile=@CargoExtraFile, Observaciones=@Observaciones, Eliminado=@Eliminado  where idCargoExtra=@idCargoExtra"



            Dim params As SqlParameter() = { _
          New SqlParameter("@idOrden", Me.idOrden), _
  New SqlParameter("@idFabricante", Me.idFabricante), _
  New SqlParameter("@FacturaFolio", Me.FacturaFolio), _
  New SqlParameter("@FechaPago", Me.FechaPago), _
  New SqlParameter("@FechaRegistro", Me.FechaRegistro), _
  New SqlParameter("@DatosBancarios", Me.DatosBancarios), _
  New SqlParameter("@Clabe", Me.Clabe), _
  New SqlParameter("@IVA", Me.IVA), _
  New SqlParameter("@Subtotal", Me.Subtotal), _
  New SqlParameter("@Total", Me.Total), _
  New SqlParameter("@Aprobado", Me.Aprobado), _
  New SqlParameter("@idUserProfileAprobacion", Me.idUserProfileAprobacion), _
  New SqlParameter("@fechaAprobacion", Me.FechaAprobacion), _
  New SqlParameter("@CargoExtraFile", Me.CargoExtraFile), _
  New SqlParameter("@Observaciones", Me.Observaciones), _
  New SqlParameter("@Eliminado", Me.Eliminado), _
   New SqlParameter("@idCargoExtra", Me.idCargoExtra)}

            Return Me.ExecuteNonQuery(sql, params)



        End Function

        Public Function Remove() As Integer
            Me.Eliminado = True
            Return Me.update()

        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from CargosExtras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0"
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function


        Public Function GetDSFechas(ByVal claveProveedor As Integer, ByVal claveFechaDesde As Date, ByVal claveFechaHasta As Date) As DataSet

            Dim sql As String = "select c.*, fi.nombre as fabricante  from CargosExtras c, fabricantesidiomas fi where c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0 and  c.idFabricante=@idFabricante and c.FechaRegistro>=@fechadesde and c.FechaRegistro<@fechahasta"
            Dim params As SqlParameter() = {New SqlParameter("@idFabricante", claveProveedor), New SqlParameter("@fechadesde", claveFechaDesde), New SqlParameter("@fechahasta", claveFechaHasta)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

       


        Public Function GetDSOrden(ByVal claveOrden As Integer) As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from CargosExtras c, fabricantesidiomas fi where  c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0  and c.idOrden=@idOrden   order by c.fechaPago desc"
            Dim params As SqlParameter() = { _
New SqlParameter("@idOrden", claveOrden)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetDSProcesadas(ByVal clavefabricante As Integer) As DataSet
            Dim sql As String = "select c.*, fi.nombre as fabricante  from CargosExtras c, fabricantesidiomas fi where  c.idfabricante=fi.idfabricante and fi.ididioma=1 and c.eliminado=0  and c.idFabricante=@idFabricante  and c.idCargoExtra not in (select chp.idProc  from chequesProcedencias chp where chp.idProc=c.idCargoExtra and Procedencia='CargoExtra' ) order by c.fechaPago desc"
            Dim params As SqlParameter() = { _
New SqlParameter("@idFabricante", clavefabricante)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetSumaSubtotalCargosExtras(ByVal claveOrden As Integer) As Decimal
            Dim sql As String = "select sum(c.subtotal) as num from cargosextras c where c.idOrden=@idOrden and c.eliminado=0"
            Dim params As SqlParameter() = { _
New SqlParameter("@idOrden", claveOrden)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso
        End Function

        Public Function GetSumaIVACargosExtras(ByVal claveOrden As Integer) As Decimal
            Dim sql As String = "select sum(c.iva) as num from cargosextras c where c.idOrden=@idOrden and c.eliminado=0"
            Dim params As SqlParameter() = { _
New SqlParameter("@idOrden", claveOrden)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso
        End Function


        Public Function GetSumaTotalCargosExtras(ByVal claveOrden As Integer) As Decimal
            Dim sql As String = "select sum(c.total) as num from cargosextras c where c.idOrden=@idOrden and c.eliminado=0"
            Dim params As SqlParameter() = { _
New SqlParameter("@idOrden", claveOrden)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            Dim regreso As Decimal = 0
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CDec(dr("num"))
                End If
            End If
            dr.Close()

            Return regreso
        End Function

    End Class


End Namespace