Imports System.Data.SqlClient
Imports System.Data

Namespace tienda



    Public Class EstadoIdioma
        Inherits Estado

        Public idEstadoIdioma As Integer
        Public idIdioma As Integer
        Public nombre As String

        Public Shadows existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveEstado As Integer, ByVal claveIdioma As Integer)
            MyBase.New(claveEstado)
            Dim sql As String = "select * from EstadosIdiomas where idEstado=@idEstado and idIdioma=@idIdioma"
            Dim params As SqlParameter() = {New SqlParameter("@idEstado", claveEstado), New SqlParameter("@idIdioma", claveIdioma)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idEstadoIdioma = CInt(dr("idEstadoIdioma"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")
                Me.existe = True
            End If

            dr.Close()


        End Sub

        Public Overloads Function Add() As Integer
            Dim sql As String = "insert into EstadosIdiomas ( idEstado, idIdioma, nombre) values ( @idEstado, @idIdioma, @nombre)"
            If Not MyBase.existe Then
                MyBase.Add()
            End If

            Dim params As SqlParameter() = {New SqlParameter("@idEstado", idEstado), _
                                            New SqlParameter("@idIdioma", idIdioma), _
                                            New SqlParameter("@nombre", nombre)}
            Dim mytemp As New EstadoIdioma(idEstado, idIdioma)
            If Not mytemp.existe Then
                Me.idEstadoIdioma = Me.ExecuteNonQuery(sql, params, True)
            End If



            Return 1
        End Function

        Public Overloads Function Update() As Integer
            Dim sql As String = "update EstadosIdiomas set idEstado=@idEstado, idIdioma=@idIdioma, nombre=@nombre where idEstadoIdioma=@idEstadoIdioma"
            MyBase.Update()

            Dim params As SqlParameter() = {New SqlParameter("@idEstado", idEstado), _
                                            New SqlParameter("@idIdioma", idIdioma), _
                                            New SqlParameter("@nombre", nombre), _
                                            New SqlParameter("@idEstadoIdioma", idEstadoIdioma)}

            If Me.existe Then
                Me.ExecuteNonQuery(sql, params)
            Else
                Me.Add()
            End If



        End Function

        Public Overloads Function Remove() As Integer

            Return MyBase.Remove()

        End Function


        Public Function GetDS(ByVal claveIdioma As Integer, ByVal clavepais As Integer) As DataSet
            Dim sql As String = "select e.idestado, e.idPais, e.impuesto, ei.ididioma, ei.nombre from Estados e, EstadosIdiomas ei where  e.idEstado=ei.idEstado and ei.ididioma = @idIdioma  and e.idPais=@idPais and e.eliminado=0 order by ei.nombre"
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idPais", clavepais)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

    End Class
End Namespace
