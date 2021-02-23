Imports System.Data.SqlClient
Imports System.Data


Namespace tienda


    Public Class ConfiguracionIdioma
        Inherits Configuracion

        Public idConfiguracionIdioma As Integer
        Public idIdioma As Integer
        Public nombre As String
        Public header As String
        Public footer As String
        Public keywords As String
        Public description As String
        Public h1 As String
        Public mapa As String
        Public acercaDe As String
        Public polizaPrivacidad As String
        Public comoComprar As String
        Public formasContacto As String
        Public logoPrincipal As String = String.Empty


        Public Shadows existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal claveidConfiguracion As Integer, ByVal claveIdioma As Integer)
            MyBase.New(claveidConfiguracion)
            Dim sql As String = "select * from configuracionesidiomas where idConfiguracion=@idConfiguracion and idIdioma=@idIdioma"
            Dim params As SqlParameter() = {New SqlParameter("@idConfiguracion", claveidConfiguracion), New SqlParameter("@idIdioma", claveIdioma)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idConfiguracionIdioma = CInt(dr("idConfiguracionIdioma"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")
                Me.header = dr("header")
                Me.footer = dr("footer")
                Me.keywords = dr("keywords")
                Me.description = dr("description")
                Me.h1 = dr("h1")
                Me.mapa = dr("mapa")
                Me.acercaDe = dr("acercaDe")
                Me.polizaPrivacidad = dr("polizaPrivacidad")
                Me.comoComprar = dr("comoComprar")
                Me.formasContacto = dr("formasContacto")
                If Not Convert.IsDBNull(dr("logoPrincipal")) Then
                    Me.logoPrincipal = dr("logoPrincipal")
                End If
                Me.existe = True
            End If

            dr.Close()


        End Sub

        Public Overloads Function Add() As Integer
            Dim sql As String = "insert into configuracionesidiomas ( idConfiguracion, idIdioma, nombre, header, footer, keywords, description, h1, mapa, acercade, polizaprivacidad, comocomprar, formascontacto, logoPrincipal) values ( @idConfiguracion, @idIdioma, @nombre, @header, @footer, @keywords, @description, @h1, @mapa, @acercade, @polizaprivacidad, @comocomprar, @formascontacto, @logoPrincipal)"
            If Not MyBase.existe Then
                MyBase.Add()
            End If

            Dim params As SqlParameter() = {New SqlParameter("@idConfiguracion", idConfiguracion),
                                            New SqlParameter("@idIdioma", idIdioma),
                                            New SqlParameter("@nombre", nombre),
                                            New SqlParameter("@header", header),
                                            New SqlParameter("@footer", footer),
                                            New SqlParameter("@keywords", keywords),
                                            New SqlParameter("@description", description),
                                            New SqlParameter("@h1", h1),
                                            New SqlParameter("@mapa", mapa),
                                            New SqlParameter("@acercade", acercaDe),
                                            New SqlParameter("@polizaprivacidad", polizaPrivacidad),
                                            New SqlParameter("@comocomprar", comoComprar),
                                            New SqlParameter("@formascontacto", formasContacto),
                                            New SqlParameter("@logoPrincipal", logoPrincipal)}

            Me.idConfiguracionIdioma = Me.ExecuteNonQuery(sql, params, True)


            Return 1
        End Function

        Public Overloads Function Update() As Integer
            Dim sql As String = "update configuracionesidiomas set idConfiguracion=@idConfiguracion, idIdioma=@idIdioma, nombre=@nombre, header=@header, footer=@footer, keywords=@keywords, description=@description, h1=@h1, mapa=@mapa, acercade=@acercade, polizaprivacidad=@polizaprivacidad, comocomprar=@comocomprar, formascontacto=@formascontacto, logoPrincipal=@logoPrincipal where idConfiguracionIdioma=@idConfiguracionIdioma"
            MyBase.Update()

            Dim params As SqlParameter() = {New SqlParameter("@idConfiguracion", idConfiguracion),
                                            New SqlParameter("@idIdioma", idIdioma),
                                            New SqlParameter("@nombre", nombre),
                                            New SqlParameter("@header", header),
                                            New SqlParameter("@footer", footer),
                                            New SqlParameter("@keywords", keywords),
                                            New SqlParameter("@description", description),
                                            New SqlParameter("@h1", h1),
                                            New SqlParameter("@mapa", mapa),
                                            New SqlParameter("@acercade", acercaDe),
                                            New SqlParameter("@polizaprivacidad", polizaPrivacidad),
                                            New SqlParameter("@comocomprar", comoComprar),
                                            New SqlParameter("@formascontacto", formasContacto),
                                            New SqlParameter("@idConfiguracionIdioma", idConfiguracionIdioma),
                                            New SqlParameter("@logoPrincipal", logoPrincipal)}

            If Me.existe Then
                Me.ExecuteNonQuery(sql, params)
            Else
                Me.Add()
            End If



        End Function






    End Class
End Namespace
