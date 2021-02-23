Imports System.Data
Imports System.Data.SqlClient
Imports System


Namespace tienda


    Public Class ValorDollar
        Inherits DBObject

        Public idValorDollar As Integer
        Public fecha As Date
        Public valordollar As Decimal

        Public Existe As Boolean = False

        Sub New()


            Dim myq As String = "SELECT top 1 [ValorDollar].* FROM [ValorDollar] order by fecha desc"

          

            Dim dr As SqlDataReader = Me.ExecuteReader(myq, Nothing)
            If dr.Read Then
                Me.idValorDollar = CType(dr("idValorDollar"), Integer)
                Me.fecha = CType(dr("fecha"), DateTime)
                Me.valordollar = CType(dr("valordollar"), Decimal)

                Existe = True
            End If
            dr.Close()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)

            Dim myq As String = "SELECT [ValorDollar].* FROM [ValorDollar] WHERE ([ValorDollar].[idValorDollar] = @idValorDollar)"

            Dim parameters As SqlParameter() = {New SqlParameter("@idValorDollar", SqlDbType.Int)}
            parameters(0).Value = clavePrincipal

            Dim dr As SqlDataReader = Me.ExecuteReader(myq, parameters)
            If dr.Read Then
                Me.idValorDollar = CType(dr("idValorDollar"), Integer)
                Me.fecha = CType(dr("fecha"), DateTime)
                Me.valordollar = CType(dr("valordollar"), Decimal)

                Existe = True
            End If
            dr.Close()
        End Sub


     

        Public Function Add() As Integer
            Dim queryString As String = "INSERT INTO [ValorDollar] ([fecha], [valordollar]) VALUES ( " & _
    "@Fecha, @ValorDollar )"

            Dim parameters As SqlParameter() = { _
    New SqlParameter("@Fecha", SqlDbType.DateTime), _
    New SqlParameter("@ValorDollar", SqlDbType.Money)}


            parameters(0).Value = Me.fecha
            parameters(1).Value = Me.valordollar


            Me.idValorDollar = Me.ExecuteNonQuery(queryString, parameters, True)


           

            Return 1
        End Function


        Public Function Update() As Integer
            Dim queryString As String = "UPDATE [ValorDollar] SET [valorDollar]=@ValorDollar " & _
                                                " WHERE ([ValorDollar].[idValorDollar] = @idValorDollar)"

            Dim parameters As SqlParameter() = { _
     New SqlParameter("@valorDollar", SqlDbType.Money), _
     New SqlParameter("@idValorDollar", SqlDbType.Int)}


            parameters(0).Value = Me.valordollar
            parameters(1).Value = Me.idValorDollar

            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function
        Public Function getDSAll() As DataSet
            Dim mysql As String = "select * from ValorDollar order by fecha desc"
            Return Me.ExecuteDataSet(mysql, Nothing)
        End Function

        Public Function getDRAll() As SqlDataReader
            Dim mysql As String = "select * from ValorDollar order by fecha desc"
            Return Me.ExecuteReader(mysql, Nothing)
        End Function

        Public Function Remove() As Integer

            Dim queryString As String = "DELETE FROM [ValorDollar] WHERE ([ValorDollar].[idValorDollar] = @idValorDollar)"
            Dim parameters As SqlParameter() = {New SqlParameter("@idValorDollar", SqlDbType.Int)}
            parameters(0).Value = Me.idValorDollar
            Return Me.ExecuteNonQuery(queryString, parameters)

        End Function



    End Class

End Namespace
