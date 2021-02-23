Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class FabricanteIdioma
        Inherits Fabricante

        Public idFabricanteIdioma As Integer
        Public idIdioma As Integer
        Public nombre As String
        Public descripcion As String
        Public nombrearchivo As String
        Public height As Integer
        Public width As Integer

        Public Shadows existe As Boolean = False

        Sub New()

        End Sub


        Sub New(ByVal claveidFabricante As Integer, ByVal claveIdioma As Integer)
            MyBase.New(claveidFabricante)
            Dim sql As String = "select * from FabricantesIdiomas where idFabricante=@idFabricante and idIdioma=@idIdioma"

            Dim params As SqlParameter() = {New SqlParameter("@idFabricante", claveidFabricante), New SqlParameter("@idIdioma", claveIdioma)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idFabricanteIdioma = CInt(dr("idFabricanteIdioma"))
                Me.idFabricante = CInt(dr("idFabricante"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")
                Me.descripcion = dr("descripcion")
                Me.nombrearchivo = dr("nombreArchivo")
                Me.height = CInt(dr("height"))
                Me.width = CInt(dr("width"))


                Me.existe = True
            End If

            dr.Close()


        End Sub

        Public Overloads Function Add() As Integer
            Dim sql As String = "insert into FabricantesIdiomas ( idFabricante, idIdioma, nombre, descripcion, nombreArchivo, height, width) values ( @idFabricante, @idIdioma, @nombre, @descripcion, @nombreArchivo, @height, @width)"
            If Not MyBase.existe Then
                MyBase.Add()
            End If

            Dim params As SqlParameter() = {New SqlParameter("@idFabricante", idFabricante), _
                                            New SqlParameter("@idIdioma", idIdioma), _
                                            New SqlParameter("@nombre", nombre), _
                                            New SqlParameter("@descripcion", descripcion), _
                                            New SqlParameter("@nombreArchivo", nombrearchivo), _
                                            New SqlParameter("@height", height), _
                                            New SqlParameter("@width", width)}

            Me.idFabricanteIdioma = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True

            Return 1
        End Function

        Public Overloads Function Update() As Integer
            Dim sql As String = "update FabricantesIdiomas set idFabricante=@idFabricante, idIdioma=@idIdioma, nombre=@nombre, descripcion=@descripcion, nombreArchivo=@nombreArchivo, height=@height, width=@width where idFabricanteIdioma=@idFabricanteIdioma"
            MyBase.Update()

            Dim params As SqlParameter() = {New SqlParameter("@idFabricante", idFabricante), _
                                              New SqlParameter("@idIdioma", idIdioma), _
                                              New SqlParameter("@nombre", nombre), _
                                              New SqlParameter("@descripcion", descripcion), _
                                              New SqlParameter("@nombreArchivo", nombrearchivo), _
                                              New SqlParameter("@height", height), _
                                              New SqlParameter("@width", width), _
                                            New SqlParameter("@idFabricanteIdioma", idFabricanteIdioma)}

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
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre, ci.descripcion, ci.nombrearchivo, ci.height, ci.width from Fabricantes c, FabricantesIdiomas ci where c.idFabricante=ci.idFabricante and ci.ididioma = @idIdioma  and c.eliminado=0 "
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}
            Return Me.ExecuteDataSet(sql, params)

        End Function




    End Class

End Namespace

