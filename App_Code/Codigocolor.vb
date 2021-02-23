Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace tienda
	Public Class Codigocolor
		Inherits DBObject

		Public idCodigocolor As Integer
		Public nombreWeb As String
		Public codigoHexadecimal As String
		Public idioma1 As String
		Public idioma2 As String
		Public idioma3 As String
		Public existe As Boolean = False

		Sub New()
		End Sub

		Sub New(ByVal webColor As String)
			Dim queryString As String = "SELECT* FROM Codigoscolores WHERE nombreWeb=@nombreWeb"
			Dim parametros As SqlParameter() = {New SqlParameter("@nombreWeb", webColor)}

			Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
			If dr.Read Then
				Me.idCodigocolor = CInt(dr("idCodigocolor"))
				Me.nombreWeb = dr("nombreWeb")
				Me.codigoHexadecimal = dr("codigoHexadecimal")
				Me.idioma1 = dr("idioma1")
				Me.idioma2 = dr("idioma2")
				Me.idioma3 = dr("idioma3")
				Me.existe = True
			End If
			dr.Close()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)
            Dim queryString As String = "SELECT* FROM Codigoscolores WHERE idCodigocolor=@idCodigocolor"
            Dim parametros As SqlParameter() = {New SqlParameter("@idCodigocolor", clavePrincipal)}

            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                Me.idCodigocolor = CInt(dr("idCodigocolor"))
                Me.nombreWeb = dr("nombreWeb")
                Me.codigoHexadecimal = dr("codigoHexadecimal")
                Me.idioma1 = dr("idioma1")
                Me.idioma2 = dr("idioma2")
                Me.idioma3 = dr("idioma3")
                Me.existe = True
            End If
            dr.Close()

        End Sub

		Public Function GetDR() As SqlDataReader
			Dim queryStrng As String = "SELECT * FROM Codigoscolores"

			Return Me.ExecuteReader(queryStrng, Nothing)
		End Function

		Public Function GetView() As DataView
			Dim queryStrng As String = "SELECT * FROM Codigoscolores"

			Return Me.ExecuteDataSet(queryStrng, Nothing).Tables(0).DefaultView
		End Function

		Public Function GetListaColores(ByVal claveIdioma As Integer) As SortedList
			Dim lista As New SortedList
			Dim dr As SqlDataReader = Me.GetDR
			Do While dr.Read
				Dim key As Integer = CInt(dr("idCodigocolor"))
				Dim value As String
				Select Case claveIdioma
					Case 2
						value = dr("idioma2")
					Case 3
						value = dr("idioma3")
					Case Else
						value = dr("idioma1")
				End Select

				lista.Add(key, value)
			Loop
			dr.Close()

			Return lista
        End Function

        '=============================== 2010 ========================== START
        Public Function GetNombre(ByVal codigoHex As String, ByVal claveIdioma As Integer) As String
            Dim columnaIdioma As String = "idioma" & claveIdioma
            If claveIdioma > 3 Then columnaIdioma = "idioma1"

            Dim queryString As String = "SELECT " & columnaIdioma & " as nombre FROM Codigoscolores WHERE codigoHexadecimal = @codigoHexadecimal"
            Dim parametros As SqlParameter() = {New SqlParameter("@codigoHexadecimal", codigoHex)}

            Dim nombre As String = String.Empty
            Dim dr As SqlDataReader = Me.ExecuteReader(queryString, parametros)
            If dr.Read Then
                If Not IsDBNull(dr("nombre")) Then nombre = dr("nombre")
            End If
            dr.Close()

            Return nombre
        End Function
        '=============================== 2010 ========================== END
	End Class
End Namespace
