Imports Microsoft.VisualBasic

Namespace tienda
    Public Class InformacionPago



        Public Function validarTarjeta(ByVal varmes As Integer, ByVal varano As Integer, ByVal numerotarjeta As String, ByVal tipotarjeta As Integer) As Boolean
            Dim regreso As Boolean = False

            regreso = validarFecha(varmes, varano)
            If regreso Then
                regreso = validarTipoTarjeta(numerotarjeta, tipotarjeta)
            End If

            If regreso Then
                regreso = validarNumeroTarjeta(numerotarjeta)
            End If



            Return regreso

        End Function



        Private Function validarFecha(ByVal varMes As Integer, ByVal varano As Integer) As Boolean
            Dim regreso As Boolean = False
            If varano = Date.Now.Year Then
                If varMes >= Date.Now.Month Then
                    regreso = True
                End If
            End If
            If Not regreso Then
                If varano > Date.Now.Year Then
                    regreso = True
                End If
            End If

            Return regreso
        End Function

        Private Function validarTipoTarjeta(ByVal NumeroTarjeta As String, ByVal tipotarjeta As Integer) As Boolean
            Dim regreso As Boolean = False
            Select Case tipotarjeta
                Case ETipoTarjeta.Amex 'AMEX -- 34 or 37 -- 15 length
                    If Regex.IsMatch(NumeroTarjeta, "^(34|37)") And NumeroTarjeta.Length = 15 Then
                        regreso = True
                    End If
                Case ETipoTarjeta.MasterCard 'MasterCard -- 51 through 55 -- 16 length
                    If Regex.IsMatch(NumeroTarjeta, "^(51|52|53|54|55)") And NumeroTarjeta.Length = 16 Then
                        regreso = True
                    End If
                Case ETipoTarjeta.VISA 'VISA -- 4 -- 13 and 16 length
                    If Regex.IsMatch(NumeroTarjeta, "^(4)") And (NumeroTarjeta.Length = 16 Or NumeroTarjeta.Length = 13) Then
                        regreso = True
                    End If

            End Select

            Return regreso
        End Function

        Private Function validarNumeroTarjeta(ByVal Numerotarjeta As String) As Boolean

            Dim total As Integer = 0
            Dim i As Integer
            For i = Numerotarjeta.Length - 2 To i >= 0 Step -2
                Dim valor As Integer = Integer.Parse(Numerotarjeta.Substring(i, 1)) * 2
                'total += Integer.Parse((valor / 10)) + Integer.Parse((valor Mod 10))
                If valor > 9 Then
                    Dim num1 As Integer = CInt(valor.ToString.Substring(0, 1))
                    Dim num2 As Integer = CInt(valor.ToString.Substring(1, 1))
                    total += num1 + num2
                Else
                    total += valor
                End If
            Next

            For i = Numerotarjeta.Length - 1 To i >= 0 Step -2
                total += Integer.Parse(Numerotarjeta.Substring(i, 1))
            Next

            Return (total Mod 10) = 0


        End Function



    End Class
End Namespace
