Imports System.Data.SqlClient
Imports System.Data

Namespace tienda
    Public Class CatalogoEntidad
        Inherits DBObject

        Public claveentidad As Integer = 0
        Public nombreentidad As String = ""
        Public idPais As Integer = 0


        Sub New()


        End Sub

        Sub New(ByVal claveentidad As Integer)
            Dim sql As String = "select * from catalogoentidades where claveentidad=@claveentidad"

            Dim param As SqlParameter() = {New SqlParameter("@claveentidad", claveentidad)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.claveentidad = CInt(dr("claveentidad"))
                Me.nombreentidad = dr("nombreentidad")
                Me.idPais = CInt(dr("idPais"))
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO catalogoentidades (claveentidad, nombreentidad, idPais)  VALUES (@claveentidad, @nombreentidad, @idPais) "

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@claveentidad", Me.claveentidad), _
             New SqlParameter("@nobmreentidad", Me.nombreentidad), _
             New SqlParameter("@idPais", Me.idPais)}

            Me.claveentidad = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function
        Public Function Update() As Integer
            Dim queryString As String = "Update catalogoentidades where  claveentidad=@claveentidad, nombreentidad=@nombreentidad, idpais=@idPais"


            Dim parameters As SqlParameter() = { _
             New SqlParameter("@claveentidad", Me.claveentidad), _
             New SqlParameter("@nombreentidad", Me.nombreentidad), _
             New SqlParameter("@idPais", Me.idPais)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function GetDS(ByVal clavePais As Integer) As DataSet
            Dim sql As String = "select * from catalogoentidades where idPais=@idPais order by NombreEntidad"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idPais", clavePais)}

            Return Me.ExecuteDataSet(sql, parameters)
        End Function
    End Class
End Namespace

