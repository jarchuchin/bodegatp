Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class FormatoIdioma
        Inherits Formato

        Public idFormatoIdioma As Integer
        Public idIdioma As Integer
        Public nombre As String
    

        Public Shadows existe As Boolean = False

        Sub New()

        End Sub


        Sub New(ByVal claveidFormato As Integer, ByVal claveIdioma As Integer)
            MyBase.New(claveidFormato)
            Dim sql As String = "select * from FormatosIdiomas where idFormato=@idFormato and idIdioma=@idIdioma"

            Dim params As SqlParameter() = {New SqlParameter("@idFormato", claveidFormato), New SqlParameter("@idIdioma", claveIdioma)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idFormatoIdioma = CInt(dr("idFormatoIdioma"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")
            


                Me.existe = True
            End If

            dr.Close()


        End Sub

        Public Overloads Function Add() As Integer
            Dim sql As String = "insert into FormatosIdiomas ( idFormato, idIdioma, nombre) values ( @idFormato, @idIdioma, @nombre)"
            If Not MyBase.existe Then
                MyBase.Add()
            End If

            Dim params As SqlParameter() = {New SqlParameter("@idFormato", idFormato), _
                                            New SqlParameter("@idIdioma", idIdioma), _
                                            New SqlParameter("@nombre", nombre)}

            Me.idFormatoIdioma = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True

            Return 1
        End Function

        Public Overloads Function Update() As Integer
            Dim sql As String = "update FormatosIdiomas set idFormato=@idFormato, idIdioma=@idIdioma, nombre=@nombre where idFormatoIdioma=@idFormatoIdioma"
            MyBase.Update()

            Dim params As SqlParameter() = {New SqlParameter("@idFormato", idFormato), _
                                              New SqlParameter("@idIdioma", idIdioma), _
                                              New SqlParameter("@nombre", nombre), _
                                          New SqlParameter("@idFormatoIdioma", idFormatoIdioma)}

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
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre from Formatos c, FormatosIdiomas ci where c.idFormato=ci.idFormato and ci.ididioma = @idIdioma and c.eliminado=0 "
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}
            Return Me.ExecuteDataSet(sql, params)

        End Function




    End Class

End Namespace

