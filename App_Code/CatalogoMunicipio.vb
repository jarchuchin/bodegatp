Imports System.Data.SqlClient
Imports System.Data

Namespace tienda
    Public Class CatalogoMunicipio
        Inherits DBObject

        Public idMunicipio As Integer
        Public claveentidad As Integer
        Public clavemunicipio As Integer
        Public claveLucalidad As Integer
        Public nombremunicipio As String

        Sub New()

        End Sub


        Sub New(ByVal clavemunicipio As Integer)
            Dim sql As String = "select * from catalogomunicipios where idMunicipio=@idMunicipio"

            Dim param As SqlParameter() = {New SqlParameter("@idMunicipio", clavemunicipio)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idMunicipio = CInt(dr("idMunicipio"))
                Me.clavemunicipio = CInt(dr("clavemunicipio"))
                Me.claveentidad = CInt(dr("claveentidad"))
                Me.nombremunicipio = dr("nombremunicipio")
            End If
            dr.Close()

        End Sub


        Sub New(ByVal localclaveentidad As Integer, ByVal localclavemunicipio As Integer)
            Dim sql As String = "select * from catalogomunicipios where claveentidad=@claveentidad and clavemunicipio=@clavemunicipio"

            Dim param As SqlParameter() = {New SqlParameter("@clavemunicipio", localclavemunicipio), New SqlParameter("@claveentidad", localclaveentidad)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idMunicipio = CInt(dr("idMunicipio"))
                Me.clavemunicipio = CInt(dr("clavemunicipio"))
                Me.claveentidad = CInt(dr("claveentidad"))
                Me.nombremunicipio = dr("nombremunicipio")
            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO catalogomunicipios (clavemunicipio, claveentidad, nombremunicipio)  VALUES (@clavemunicipio, @claveentidad, @nombremunicipio) "

            Dim parameters As SqlParameter() = { _
New SqlParameter("@clavemunicipio", Me.clavemunicipio), _
New SqlParameter("@claveentidad", Me.claveentidad), _
             New SqlParameter("@nombremunicipio", Me.nombremunicipio)}

            Me.clavemunicipio = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update catalogomunicipios set claveMunicipio=@claveMunicipio, claveentidad=@claveentidad, nobmremunicipio=@nombremunicipio where  idMunicipio=@idMunicipio"


            Dim parameters As SqlParameter() = { _
            New SqlParameter("@clavemunicipio", Me.clavemunicipio), _
             New SqlParameter("@claveentidad", Me.claveentidad), _
             New SqlParameter("@nombremunicipio", Me.nombremunicipio), _
             New SqlParameter("@idMunicipio", Me.idMunicipio)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function GetDS(ByVal localclaveentidad As Integer) As DataSet
            Dim sql As String = "select * from catalogomunicipios where claveentidad=@claveentidad  order by nombremunicipio"
            Dim parameters As SqlParameter() = { _
             New SqlParameter("@claveentidad", localclaveentidad)}
            Return Me.ExecuteDataSet(sql, parameters)
        End Function
    End Class
End Namespace