
Imports System.Data.SqlClient
Imports System.Data

Namespace facturitas
    Public Class InformacionAduanera
        Inherits tienda.DBObject

        Public idInformacionAduanera As Integer
        Public idItem As Integer
        Public tipoItem As String
        Public numero As String
        Public fecha As DateTime
        Public aduana As String


        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveidInformacionAduanera As Integer)
            Dim sql As String = "select * from InformacionesAduaneras where idInformacionAduanera=@idInformacionAduanera"

            Dim param As SqlParameter() = {New SqlParameter("@idInformacionAduanera", claveidInformacionAduanera)}

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, param)

            If dr.Read Then
                Me.idInformacionAduanera = CInt(dr("idInformacionAduanera"))
                Me.idItem = CInt(dr("idItem"))
                Me.tipoItem = dr("tipoItem")
                Me.numero = dr("numero")
                Me.fecha = CDate(dr("fecha"))
                Me.aduana = CDate(dr("aduana"))
                Me.existe = True
            End If
            dr.Close()


        End Sub





        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO InformacionesAduaneras (idItem, tipoItem, numero, fecha, aduana, existe)  VALUES (@idItem, @tipoItem, @numero, @fecha, @aduana, @existe)"

            Dim parameters As SqlParameter() = { _
             New SqlParameter("@idItem", Me.idItem), _
             New SqlParameter("@tipoItem", Me.tipoItem), _
             New SqlParameter("@numero", Me.numero), _
             New SqlParameter("@fecha", Me.fecha), _
             New SqlParameter("@aduana", Me.aduana), _
             New SqlParameter("@existe", Me.existe)}

            Me.idInformacionAduanera = Me.ExecuteNonQuery(queryString, parameters, True)
            Return 1


        End Function

        Public Function Update() As Integer
            Dim queryString As String = "Update InformacionesAduaneras set idItem=@idItem, tipoItem=@tipoItem, numero=@numero, fecha=@fecha, aduana=@aduana, existe=@existe where  idInformacionAduanera=@idInformacionAduanera"


            Dim parameters As SqlParameter() = { _
            New SqlParameter("@idItem", Me.idItem), _
            New SqlParameter("@tipoItem", Me.tipoItem), _
            New SqlParameter("@numero", Me.numero), _
            New SqlParameter("@fecha", Me.fecha), _
            New SqlParameter("@aduana", Me.aduana), _
            New SqlParameter("@existe", Me.existe), _
            New SqlParameter("@idInformacionAduanera", Me.idInformacionAduanera)}

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function

        Public Function Remove() As Integer
            Dim sql As String = "delete InformacionesAduaneras where idInformacionAduanera=@idInformacionAduanera"
            Dim param As SqlParameter() = {New SqlParameter("@idInformacionAduanera", Me.idInformacionAduanera)}
            Return Me.ExecuteNonQuery(sql, param)

        End Function

		Public Function GetDS(ByVal claveidItem As Integer, ByVal claveTipoItem As tipoObjeto) As DataSet
			Dim sql As String = "select * from InformacionesAduaneras where idItem=@idItem and tipoItem=@tipoItem"
			Dim param As SqlParameter() = {New SqlParameter("@idItem", claveidItem), New SqlParameter("@tipoItem", claveTipoItem.ToString)}
			Return Me.ExecuteDataSet(sql, param)
		End Function



    End Class

End Namespace
