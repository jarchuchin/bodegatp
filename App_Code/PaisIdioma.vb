Imports System.Data.SqlClient
Imports System.Data

Namespace tienda



    Public Class PaisIdioma
        Inherits Pais

        Public idPaisIdioma As Integer
        Public idIdioma As Integer
        Public nombre As String

        Public Shadows existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePais As Integer, ByVal claveIdioma As Integer)
            MyBase.New(clavePais)
            Dim sql As String = "select * from paisesidiomas where idPais=@idPais and idIdioma=@idIdioma"
            Dim params As SqlParameter() = {New SqlParameter("@idPais", clavePais), New SqlParameter("@idIdioma", claveIdioma)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idPaisIdioma = CInt(dr("idPaisIdioma"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")
                Me.existe = True
            End If

            dr.Close()


        End Sub

        Public Overloads Function Add() As Integer
            Dim sql As String = "insert into PaisesIdiomas ( idPais, idIdioma, nombre) values ( @idPais, @idIdioma, @nombre)"
            If Not MyBase.existe Then
                MyBase.Add()
            End If

            Dim params As SqlParameter() = {New SqlParameter("@idPais", idPais), _
                                            New SqlParameter("@idIdioma", idIdioma), _
                                            New SqlParameter("@nombre", nombre)}
            Me.idPaisIdioma = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True

            Return 1
        End Function

        Public Overloads Function Update() As Integer
            Dim sql As String = "update paisesIdiomas set idPais=@idPais, idIdioma=@idIdioma, nombre=@nombre where idPaisIdioma=@idPaisIdioma"
            MyBase.Update()

            Dim params As SqlParameter() = {New SqlParameter("@idPais", idPais), _
                                            New SqlParameter("@idIdioma", idIdioma), _
                                            New SqlParameter("@nombre", nombre), _
                                            New SqlParameter("@idPaisIdioma", idPaisIdioma)}

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
            Dim sql As String = "select p.idPais, p.idMoneda, m.nombre as moneda, p.clave, pi.ididioma, pi.nombre from paises p, paisesidiomas pi, monedas m where m.idMoneda=p.idMoneda and  p.idpais=pi.idpais and pi.ididioma = @idIdioma and p.eliminado=0 order by pi.nombre "
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}
            Return Me.ExecuteDataSet(sql, params)
        End Function




       

    End Class
End Namespace
