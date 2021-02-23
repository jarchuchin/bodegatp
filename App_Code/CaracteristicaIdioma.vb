


Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class CaracteristicaIdioma
        Inherits Caracteristica

        Public idCaracteristicaIdioma As Integer
        Public idIdioma As Integer
        Public nombre As String

        Public Shadows existe As Boolean = False

        Sub New()

        End Sub


        Sub New(ByVal claveidCaracteristica As Integer, ByVal claveIdioma As Integer)
            MyBase.New(claveidCaracteristica)
            Dim sql As String = "select * from CaracteristicasIdiomas where idCaracteristica=@idCaracteristica and idIdioma=@idIdioma"

            Dim params As SqlParameter() = {New SqlParameter("@idCaracteristica", claveidCaracteristica), New SqlParameter("@idIdioma", claveIdioma)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idCaracteristicaIdioma = CInt(dr("idCaracteristicaIdioma"))
                Me.idCaracteristica = CInt(dr("idCaracteristica"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")



                Me.existe = True
            End If

            dr.Close()


        End Sub

        Public Overloads Function Add() As Integer
            Dim sql As String = "insert into CaracteristicasIdiomas (idCaracteristica, idIdioma, nombre) values ( @idCaracteristica, @idIdioma, @nombre)"
            If Not MyBase.existe Then
                MyBase.Add()
            End If

            Dim params As SqlParameter() = {New SqlParameter("@idCaracteristica", idCaracteristica), _
                                            New SqlParameter("@idIdioma", idIdioma), _
                                            New SqlParameter("@nombre", nombre)}

            Me.idCaracteristicaIdioma = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True

            Return 1
        End Function

        Public Overloads Function Update() As Integer
            Dim sql As String = "update CaracteristicasIdiomas set idCaracteristica=@idCaracteristica, idIdioma=@idIdioma, nombre=@nombre where idCaracteristicaIdioma=@idCaracteristicaIdioma"
            MyBase.Update()

            Dim params As SqlParameter() = {New SqlParameter("@idCaracteristica", idCaracteristica), _
                                            New SqlParameter("@idIdioma", idIdioma), _
                                            New SqlParameter("@nombre", nombre), _
                                            New SqlParameter("@idCaracteristicaIdioma", idCaracteristicaIdioma)}

            If Me.existe Then
                Me.ExecuteNonQuery(sql, params)
            Else
                Me.Add()
            End If



        End Function

        Public Overloads Function Remove() As Integer
            Return MyBase.Remove()
        End Function

        Public Function GetDS(ByVal claveIdioma As Integer) As DataSet
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre from Caracteristicas c, CaracteristicasIdiomas ci where c.idCaracteristica=ci.idCaracteristica and ci.ididioma = @idIdioma and c.eliminado=0 "
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetDR(ByVal claveIdioma As Integer) As SqlDataReader
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre from Caracteristicas c, CaracteristicasIdiomas ci where c.idCaracteristica=ci.idCaracteristica and ci.ididioma = @idIdioma and c.eliminado=0 "
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}
            Return Me.ExecuteReader(sql, params)

        End Function



        Public Function GetDR(ByVal claveIdioma As Integer, ByVal claveCaracterisitca As Integer) As SqlDataReader
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre from Caracteristicas c, CaracteristicasIdiomas ci where c.idCaracteristica=ci.idCaracteristica and c.idCaracteristica=@idCaracteristica and ci.ididioma = @idIdioma and c.eliminado=0 "
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idCaracteristica", claveCaracterisitca)}
            Return Me.ExecuteReader(sql, params)

        End Function

    End Class

End Namespace

