


Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Cliente
        Inherits tienda.DBObject

        Public idCliente As Integer
        Public idRFCEmisor As Integer
        Public idRFCReceptor As Integer


        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidCliente As Integer)
            Dim sql As String = "select * from Clientes where idCliente=@idCliente"

            Dim param As SqlParameter() = {New SqlParameter("@idCliente", claveidCliente)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idCliente = CInt(dr("idCliente"))
                Me.idRFCEmisor = CInt(dr("idRFCEmisor"))
                Me.idRFCReceptor = CInt(dr("idRFCReceptor"))

                Me.existe = True
            End If
            dr.Close()


        End Sub

        Sub New(ByVal claveidRFCEmisor As Integer, ByVal claveidRFCReceptor As Integer)
            Dim sql As String = "select * from Clientes where idRFCEmisor=@idRFCEmisor and idRFCReceptor=@idRFCReceptor"

            Dim param As SqlParameter() = {New SqlParameter("@idRFCEmisor", claveidRFCEmisor), New SqlParameter("@idRFCReceptor", claveidRFCReceptor)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idCliente = CInt(dr("idCliente"))
                Me.idRFCEmisor = CInt(dr("idRFCEmisor"))
                Me.idRFCReceptor = CInt(dr("idRFCReceptor"))

                Me.existe = True
            End If
            dr.Close()


        End Sub



        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Clientes (idRFCEmisor, idRFCReceptor)  VALUES (@idRFCEmisor, @idRFCReceptor)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRFCEmisor", Me.idRFCEmisor), _
             New SqlParameter("@idRFCReceptor", Me.idRFCReceptor)}

            Dim myctemp As New facturitas.Cliente(Me.idRFCEmisor, Me.idRFCReceptor)
            If Not myctemp.existe Then
                Me.idCliente = Me.ExecuteNonQuery(queryString, parameters, True)
            End If

            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Clientes set idRFCEmisor=@idRFCEmisor, idRFCReceptor=@idRFCReceptor where  idCliente=@idCliente"


            Dim parameters As SqlParameter() = { _
                 New SqlParameter("@idRFCEmisor", Me.idRFCEmisor), _
                 New SqlParameter("@idRFCReceptor", Me.idRFCReceptor), _
               New SqlParameter("@idCliente", Me.idCliente)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Clientes where idCliente=@idCliente"
            Dim param As SqlParameter() = {New SqlParameter("@idCliente", Me.idCliente)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveidRFCEmisor As Integer) As DataSet
            Dim sql As String = "select c.*, r.*, " & _
                " (select sum(total) from ordenes where rfc=r.rfc and proyectoEnTramite=0) as Cotizaciones, " & _
                " (select sum(total) from ordenes where rfc=r.rfc and proyectoEnTramite=1) as Proyectos, " & _
                " (select sum(total) from comprobantes, rfcs where rfcs.idrfc=comprobantes.idrfc and rfc=r.rfc and status='terminado') as Facturas " & _
                " from Clientes c, RFCs r where r.idRFC=c.idRFCReceptor and c.idRFCEmisor=@idRFCEmisor"
            Dim param As SqlParameter() = {New SqlParameter("@idRFCEmisor", claveidRFCEmisor)}
            Return Me.ExecuteDataSet(sql, param)
        End Function



    End Class

End Namespace
