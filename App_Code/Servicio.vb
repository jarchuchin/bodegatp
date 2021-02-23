Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace tienda
    Public Class Servicio
        Inherits DBObject

        Public idServicio As Integer
        Public idProducto As Integer
        Public tipo As TipoServicio
        Public unidadComponenteBase As Integer
        Public precioComponenteBase As Decimal
        Public costoSetup As Decimal
        Public cantidadMinima As Integer
        Public precioCantidadMinima As Decimal
        Public eliminado As Boolean = False
        Public existe As Boolean = False

        Sub New()
        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT* FROM Servicios WHERE idServicio=@idServicio"
            Dim parametros As SqlParameter() = {New SqlParameter("@idServicio", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idServicio = CInt(dr("idServicio"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.tipo = CType([Enum].Parse(GetType(TipoServicio), dr("tipo").ToString), TipoServicio)
                Me.unidadComponenteBase = CInt(dr("unidadComponenteBase"))
                Me.precioComponenteBase = CDec(dr("precioComponenteBase"))
                Me.costoSetup = CDec(dr("costoSetup"))
                Me.cantidadMinima = CInt(dr("cantidadMinima"))
                Me.precioCantidadMinima = CDec(dr("precioCantidadMinima"))
                Me.eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Servicios (idProducto, tipo, unidadComponenteBase, precioComponenteBase, costoSetup, cantidadMinima, precioCantidadMinima, eliminado) " _
             & "VALUES (@idProducto, @tipo, @unidadComponenteBase, @precioComponenteBase, @costoSetup, @cantidadMinima, @precioCantidadMinima, @eliminado)"

            Dim parametros As SqlParameter() = { _
                     New SqlParameter("@idProducto", Me.idProducto), _
             New SqlParameter("@tipo", Me.tipo.ToString), _
             New SqlParameter("@unidadComponenteBase", Me.unidadComponenteBase), _
             New SqlParameter("@precioComponenteBase", Me.precioComponenteBase), _
             New SqlParameter("@costoSetup", Me.costoSetup), _
             New SqlParameter("@cantidadMinima", Me.cantidadMinima), _
             New SqlParameter("@precioCantidadMinima", Me.precioCantidadMinima), _
             New SqlParameter("@eliminado", Me.eliminado)}

            Me.idServicio = Me.ExecuteNonQuery(queryString, parametros, True)
            Me.existe = True
            Return 1
        End Function

        Public Function Update() As Integer
            Dim queryString As String = "UPDATE Servicios SET idProducto=@idProducto, unidadComponenteBase=@unidadComponenteBase,  precioComponenteBase=@precioComponenteBase, " _
   & "costoSetup=@costoSetup, cantidadMinima=@cantidadMinima, precioCantidadMinima=@precioCantidadMinima, eliminado=@eliminado WHERE idServicio=@idServicio"

            Dim parametros As SqlParameter() = { _
            New SqlParameter("@idServicio", Me.idServicio), _
                      New SqlParameter("@idProducto", Me.idProducto), _
             New SqlParameter("@unidadComponenteBase", Me.unidadComponenteBase), _
             New SqlParameter("@precioComponenteBase", Me.precioComponenteBase), _
             New SqlParameter("@costoSetup", Me.costoSetup), _
             New SqlParameter("@cantidadMinima", Me.cantidadMinima), _
             New SqlParameter("@precioCantidadMinima", Me.precioCantidadMinima), _
             New SqlParameter("@eliminado", Me.eliminado)}

            Return Me.ExecuteNonQuery(queryString, parametros)
        End Function

        Public Function Remove() As Integer
            Me.eliminado = True
            Return Me.Update()

        End Function




    End Class
End Namespace
