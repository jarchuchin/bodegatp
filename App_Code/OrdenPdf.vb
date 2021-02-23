
Imports System.Data
Imports System.Data.SqlClient


Namespace tienda

    Public Class OrdenPdf
        Inherits DBObject

        Public idOrdenPdf As Integer
        Public idOrden As Integer
        Public fecha As DateTime
        Public nombrefile As String
        Public existe As Boolean = False
        Sub New()

        End Sub

  
        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from ordenesPdf where idOrdenPdf=@idOrdenPdf"
            Dim params As SqlParameter() = {New SqlParameter("idOrdenPdf", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idOrdenPdf = CInt(dr("idOrdenPdf"))
                Me.idOrden = CInt(dr("idOrden"))
                Me.Fecha = CDate(dr("Fecha"))
                Me.nombrefile = dr("nombrefile")
           
                Me.existe = True
            End If
            dr.Close()

        End Sub



        Public Function Add() As Integer
            Dim sql As String = "insert into ordenesPdf (idOrden, Fecha, nombrefile) values (@idOrden, @Fecha, @nombrefile)"
            Dim params As SqlParameter() = { _
    New SqlParameter("@idOrden", Me.idOrden), _
    New SqlParameter("@Fecha", Me.fecha), _
    New SqlParameter("@nombrefile", Me.nombrefile)}

            Me.idOrdenPdf = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1


        End Function

        Public Function Update() As Integer
            Dim sql As String = "Update ordenesPdf set idOrden=@idOrden, Fecha=@Fecha, nombrefile=@nombrefile where idOrdenPdf=@idOrdenPdf"

            Dim params As SqlParameter() = { _
New SqlParameter("@idOrden", Me.idOrden), _
New SqlParameter("@Fecha", Me.fecha), _
New SqlParameter("@nombrefile", Me.nombrefile), _
New SqlParameter("@idOrdenPdf", Me.idOrdenPdf)}


            Return Me.ExecuteNonQuery(sql, params)
        End Function

        Public Function GetDSOrden(ByVal claveOrden As Integer) As DataSet
            Dim sql As String = "select * from ordenesPdf where idOrden=@idOrden order by Fecha desc"
            Dim params As SqlParameter() = { _
    New SqlParameter("@idOrden", claveOrden)}
            Return Me.ExecuteDataSet(sql, params)
        End Function




    End Class





End Namespace

