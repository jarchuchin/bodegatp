

Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System


Namespace tienda


    Public Class DBObject

        Private connection As SqlConnection


        Private Function OpenConnection() As Integer

            connection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString)
            connection.Open()

            Return 1

        End Function

        Public Function CloseConnection() As Integer
            connection.Close()
            connection.Dispose()

            Return 1
        End Function

        Public Function ExecuteScalar(ByVal mysql As String, ByVal myParameters() As IDataParameter) As Object
            Me.OpenConnection()
            Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myParameters)

            Try
                Return command.ExecuteScalar()
            Finally
                command.Dispose()
                Me.CloseConnection()
            End Try

        End Function

        Public Function ExecuteReader(ByVal mysql As String, ByVal myparameters() As IDataParameter) As SqlDataReader
            Me.OpenConnection()
            Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myparameters)

            Dim dr As SqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)
            Return dr


        End Function

        Public Function ExecuteDataSet(ByVal mysql As String, ByVal myparameters() As IDataParameter) As DataSet
            Me.OpenConnection()
            Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myparameters)

            Dim ds As DataSet = New DataSet
            Dim myda As SqlDataAdapter = New SqlDataAdapter(command)
            myda.Fill(ds)
            command.Dispose()
            Me.CloseConnection()

            Return ds

        End Function

        'IDataAdapter
        Public Function ExecuteNonQuery(ByVal mysql As String, ByVal myparameters() As IDataParameter, _
        Optional ByVal returnLastID As Boolean = False) As Integer

            Dim resultado As Integer

            Me.OpenConnection()
            Dim command As SqlCommand = Me.BuildQueryCommand(mysql, myparameters)

            'Try
            resultado = command.ExecuteNonQuery()

            If returnLastID Then
                command = New SqlCommand("SELECT @@IDENTITY as lastId", Me.connection)
                Dim dr As SqlDataReader = command.ExecuteReader()
                dr.Read()
                If Not Convert.IsDBNull(dr("lastId")) Then
                    resultado = CType(dr("lastId"), Integer)
                End If
                dr.Close()
            End If
            '	Catch ex As Exception
            'Dim m As String = ex.Message
            '     Finally
            command.Dispose()
            Me.CloseConnection()
            '      End Try

            Return resultado
        End Function

        Private Function BuildQueryCommand(ByVal mysql As String, ByVal myParameters() As IDataParameter) As SqlCommand
            Dim command As SqlCommand = New SqlCommand(mysql, Me.connection)
            command.CommandType = CommandType.Text


            If Not IsNothing(myParameters) Then
                For Each myp As SqlParameter In myParameters
                    command.Parameters.Add(myp)
                Next
            End If

            Return command
        End Function

        Public Function Encriptar(ByVal texto As String) As Byte()
            Dim myt As New TripleDES()
            Return myt.Encrypt(texto)
        End Function

        Public Function Desencriptar(ByVal entradaBytes() As Byte) As String
            Dim myt As New TripleDES
            Return myt.Decrypt(entradaBytes)
        End Function




    End Class

End Namespace
