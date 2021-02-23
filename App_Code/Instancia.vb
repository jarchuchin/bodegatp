
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace tienda

    Public Class Instancia
        Inherits DBObject

        Public idInstancia As Integer
        Public Nombre As String
        Public RFC As String
        Public Compras As Boolean
        Public Almacen As Boolean
        Public Taller As Boolean
        Public Administracion As Boolean
        Public Caja As Boolean = False
        Public FechaCreacion As Date
        Public Eliminado As Boolean

        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim sql As String = "select * from Instancias where idInstancia=@idInstancia"

            Dim param As SqlParameter() = {New SqlParameter("@idInstancia", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idInstancia = CInt(dr("idInstancia"))
                Me.Nombre = dr("Nombre")
                Me.RFC = dr("RFC")
                Me.Compras = dr("Compras")
                Me.Almacen = dr("Almacen")
                Me.Taller = dr("Taller")
                Me.Administracion = dr("Administracion")
                If Not Convert.IsDBNull(dr("Caja")) Then
                    Me.Caja = dr("Caja")
                End If

                Me.FechaCreacion = CType(dr("FechaCreacion"), DateTime)
                Me.Eliminado = CBool(dr("Eliminado"))

                Me.existe = True
            End If
            dr.Close()
        End Sub




        Public Function add() As Integer
            Dim querystring As String = "INSERT INTO Instancias (Nombre, RFC, Compras, Almacen, Taller, Administracion, FechaCreacion, Eliminado, Caja) VALUES (@Nombre, @RFC, @Compras, @Almacen, @Taller, @Administracion, @FechaCreacion, @Eliminado, @Caja)"

            Dim parameters As SqlParameter() = { _
            New SqlParameter("@Nombre", Me.Nombre), _
            New SqlParameter("@RFC", Me.RFC), _
            New SqlParameter("@Compras", Me.Compras), _
            New SqlParameter("@Almacen", Almacen), _
            New SqlParameter("@Taller", Taller), _
            New SqlParameter("@Administracion", Administracion), _
            New SqlParameter("@FechaCreacion", FechaCreacion), _
            New SqlParameter("@Eliminado", Eliminado), _
            New SqlParameter("@Caja", Caja)}

            Me.idInstancia = Me.ExecuteNonQuery(querystring, parameters, True)
            Return 1

        End Function

        Public Function Update() As Integer
            Dim queryString As String = "UPDATE Instancias SET Nombre=@Nombre, RFC=@RFC, Compras=@Compras, Almacen=@Almacen, Taller=@Taller, Administracion=Administracion, FechaCreacion=@Fechacreacion, Eliminado=@Eliminado, Caja=@Caja WHERE idInstancia= @idInstancia"

            Dim parameters As SqlParameter() = { _
            New SqlParameter("@Nombre", Me.Nombre), _
            New SqlParameter("@RFC", Me.RFC), _
            New SqlParameter("@Compras", Me.Compras), _
            New SqlParameter("@Almacen", Almacen), _
            New SqlParameter("@Taller", Taller), _
            New SqlParameter("@Administracion", Administracion), _
            New SqlParameter("@FechaCreacion", FechaCreacion), _
            New SqlParameter("@Eliminado", Eliminado), _
            New SqlParameter("@idInstancia", Me.idInstancia), _
            New SqlParameter("@Caja", Caja)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function


        Public Function remove() As Integer
            Me.Eliminado = True
            Return Me.Update()

        End Function

        Public Function GetDS() As DataSet
            Dim sql As String = "select i.*, isnull((select count(idAlmacen) from Almacenes where idInstancia=i.idInstancia and eliminado=0),0) as Almacenes , isnull((select count(idCaja) from Cajas where idInstancia=i.idInstancia and eliminado=0),0) as Cajas  from Instancias i  order by i.nombre desc"
            Return Me.ExecuteDataSet(sql, Nothing)
        End Function


    End Class
End Namespace
