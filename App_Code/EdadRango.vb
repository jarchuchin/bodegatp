Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class EdadRango
        Inherits DBObject

        Public idEdadRango As Integer
        Public rango As String
        Public eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from edadesrangos where idEdadRango=@idEdadRango"
            Dim params() As SqlParameter = {New SqlParameter("@idEdadRango", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idEdadRango = CInt(dr("idEdadRango"))
                Me.rango = dr("rango")
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If

            dr.Close()
        End Sub


        Public Function Add() As Integer
            Dim sql As String = "insert into edadesrangos (rango, eliminado) values (@rango, @eliminado)"
            Dim params() As SqlParameter = {New SqlParameter("@rango", rango), _
                                            New SqlParameter("@eliminado", eliminado)}

            Me.idEdadRango = Me.ExecuteNonQuery(sql, params, True)

            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update edadesrangos set rango=@rango, eliminado=@eliminado where idEdadRango=@idEdadRango"
            Dim params() As SqlParameter = {New SqlParameter("@rango", rango), New SqlParameter("@eliminado", eliminado), New SqlParameter("@idEdadRango", idEdadRango)}

            Me.ExecuteNonQuery(sql, params)
            Return 1

        End Function

        Public Function Remove() As Integer
            Me.eliminado = True
            Me.Update()
        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select * from edadesrangos where eliminado=0"
            Return Me.ExecuteDataSet(sql, Nothing)

        End Function

    End Class
End Namespace
