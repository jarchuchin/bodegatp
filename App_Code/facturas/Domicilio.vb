
Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class Domicilio
        Inherits tienda.DBObject

        Public idDomicilio As Integer
        Public idRFC As Integer
        Public tipo As String
        Public calle As String
        Public noExterior As String
        Public noInterior As String
        Public colonia As String
        Public localidad As String
        Public referencia As String
        Public municipio As String
        Public estado As String
        Public pais As String
        Public codigoPostal As String



        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidDomicilio As Integer)
            Dim sql As String = "select * from Domicilios where idDomicilio=@idDomicilio"
            Dim param As SqlParameter() = {New SqlParameter("@idDomicilio", claveidDomicilio)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idDomicilio = CInt(dr("idDomicilio"))
                Me.idRFC = CInt(dr("idRFC"))
                Me.tipo = dr("tipo")
                Me.calle = dr("calle")
                Me.noExterior = dr("noExterior")
                Me.noInterior = dr("noInterior")
                Me.colonia = dr("colonia")
                Me.colonia = dr("colonia")
                Me.localidad = dr("localidad")
                Me.referencia = dr("referencia")
                Me.municipio = dr("municipio")
                Me.estado = dr("estado")
                Me.pais = dr("pais")
                Me.codigoPostal = dr("codigoPostal")

                Me.existe = True
            End If
            dr.Close()
        End Sub

        Sub New(ByVal claveidRFC As Integer, ByVal claveTipo As String)
            Dim sql As String = "select * from Domicilios where idRFC=@idRFC and tipo=@tipo"
            Dim param As SqlParameter() = {New SqlParameter("@idRFC", claveidRFC), New SqlParameter("@tipo", claveTipo)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idDomicilio = CInt(dr("idDomicilio"))
                Me.idRFC = CInt(dr("idRFC"))
                Me.tipo = dr("tipo")
                Me.calle = dr("calle")
                Me.noExterior = dr("noExterior")
                Me.noInterior = dr("noInterior")
                Me.colonia = dr("colonia")
                Me.localidad = dr("localidad")
                Me.referencia = dr("referencia")
                Me.municipio = dr("municipio")
                Me.estado = dr("estado")
                Me.pais = dr("pais")
                Me.codigoPostal = dr("codigoPostal")

                Me.existe = True
            End If
            dr.Close()
        End Sub



        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO Domicilios (idRFC, tipo, calle, noExterior, noInterior, colonia, localidad, referencia, municipio, estado, pais, codigoPostal)  VALUES (@idRFC, @tipo, @calle, @noExterior, @noInterior, @colonia, @localidad, @referencia, @municipio, @estado, @pais, @codigoPostal)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idRFC", Me.idRFC), _
             New SqlParameter("@tipo", Me.tipo), _
             New SqlParameter("@calle", Me.calle), _
             New SqlParameter("@noExterior", Me.noExterior), _
             New SqlParameter("@noInterior", Me.noInterior), _
             New SqlParameter("@colonia", Me.colonia), _
             New SqlParameter("@localidad", Me.localidad), _
             New SqlParameter("@referencia", Me.referencia), _
             New SqlParameter("@municipio", Me.municipio), _
             New SqlParameter("@estado", Me.estado), _
             New SqlParameter("@pais", Me.pais), _
             New SqlParameter("@codigoPostal", Me.codigoPostal)}

            Me.idDomicilio = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update Domicilios set idRFC=@idRFC, tipo=@tipo, calle=@calle, noExterior=@noExterior, noInterior=@noInterior, colonia=@colonia, localidad=@localidad, referencia=@referencia, municipio=@municipio, estado=@estado, pais=@pais, codigoPostal=@codigoPostal  where  idDomicilio=@idDomicilio"


            Dim parameters As SqlParameter() = { _
               New SqlParameter("@idRFC", Me.idRFC), _
               New SqlParameter("@tipo", Me.tipo), _
               New SqlParameter("@calle", Me.calle), _
               New SqlParameter("@noExterior", Me.noExterior), _
               New SqlParameter("@noInterior", Me.noInterior), _
               New SqlParameter("@colonia", Me.colonia), _
               New SqlParameter("@localidad", Me.localidad), _
               New SqlParameter("@referencia", Me.referencia), _
               New SqlParameter("@municipio", Me.municipio), _
               New SqlParameter("@estado", Me.estado), _
               New SqlParameter("@pais", Me.pais), _
               New SqlParameter("@codigoPostal", Me.codigoPostal), _
               New SqlParameter("@idDomicilio", Me.idDomicilio)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete Domicilios where idDomicilio=@idDomicilio"
            Dim param As SqlParameter() = {New SqlParameter("@idDomicilio", Me.idDomicilio)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

        Public Function GetDS(ByVal claveidRFC As Integer) As DataSet
            Dim sql As String = "select * from Domicilios where idRFC=@idRFC"
            Dim param As SqlParameter() = {New SqlParameter("@idRFC", claveidRFC)}
            Return Me.ExecuteDataSet(sql, param)
        End Function

      

    End Class

End Namespace
