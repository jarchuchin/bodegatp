Imports System.Data.SqlClient
Imports System.Data

Namespace tienda


    Public Class UserProfile
        Inherits DBObject

        Public idUserProfile As Integer
        Public idEdadRango As Integer
        Public idIdioma As Integer
        Public idRol As Integer
        Public email As String
        Public password As String
        Public nombre As String
        Public apellidos As String
        Public fechaRegistro As DateTime
        Public activo As Boolean
        Public sexo As String
        Public vencimiento As DateTime
        Public ultimoacceso As DateTime
        Public nombreEmpresa As String
        Public idEstado As Integer
        Public telefono As String
        Public rango1 As Integer
        Public rango2 As Integer
        Public sucursal As String

        Public sitio As Integer = 1


        Public existe As Boolean = False

        Sub New()

        End Sub

        Sub New(ByVal clavePrincipal As Integer)

            Dim sql As String = "select * from userprofiles where iduserprofile=@idUserprofile and sitio=1"
            Dim params As SqlParameter() = {New SqlParameter("@idUserprofile", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.idEdadRango = CInt(dr("idEdadRango"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.idRol = CInt(dr("idRol"))
                Me.email = dr("email")
                Me.password = Me.Desencriptar(dr("password"))
                Me.nombre = dr("nombre")
                Me.apellidos = dr("apellidos")
                Me.activo = CBool(dr("activo"))
                Me.sexo = dr("sexo")
                Me.fechaRegistro = CType(dr("fechaRegistro"), DateTime)
                Me.vencimiento = CType(dr("vencimiento"), DateTime)
                Me.ultimoacceso = CType(dr("ultimoacceso"), DateTime)
                Me.nombreEmpresa = dr("nombreEmpresa")
                Me.idEstado = CInt(dr("idEstado"))
                Me.telefono = dr("telefono")
                If Not Convert.IsDBNull(dr("rango1")) Then
                    Me.rango1 = CInt(dr("rango1"))
                Else
                    Me.rango1 = 0
                End If
                If Not Convert.IsDBNull(dr("rango2")) Then
                    Me.rango2 = CInt(dr("rango2"))
                Else
                    Me.rango2 = 0
                End If
                If Not Convert.IsDBNull(dr("sucursal")) Then
                    Me.sucursal = dr("sucursal")
                Else
                    Me.sucursal = """"
                End If
                If Not Convert.IsDBNull(dr("sitio")) Then
                    Me.sitio = dr("sitio")
                End If

                Me.existe = True

            End If
            dr.Close()

        End Sub


        Sub New(ByVal clavePrincipal As String)

            Dim sql As String = "select * from userprofiles where email=@email  and sitio=1"
            Dim params As SqlParameter() = {New SqlParameter("@email", clavePrincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idUserProfile = CInt(dr("idUserProfile"))
                Me.idEdadRango = CInt(dr("idEdadRango"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.idRol = CInt(dr("idRol"))
                Me.email = dr("email")
                Me.password = Me.Desencriptar(dr("password"))
                Me.nombre = dr("nombre")
                Me.apellidos = dr("apellidos")
                Me.activo = CBool(dr("activo"))
                Me.sexo = dr("sexo")
                Me.fechaRegistro = CType(dr("fechaRegistro"), DateTime)
                Me.vencimiento = CType(dr("vencimiento"), DateTime)
                Me.ultimoacceso = CType(dr("ultimoacceso"), DateTime)
                Me.nombreEmpresa = dr("nombreEmpresa")
                Me.idEstado = CInt(dr("idEstado"))
                Me.telefono = dr("telefono")
                If Not Convert.IsDBNull(dr("rango1")) Then
                    Me.rango1 = CInt(dr("rango1"))
                Else
                    Me.rango1 = 0
                End If
                If Not Convert.IsDBNull(dr("rango2")) Then
                    Me.rango2 = CInt(dr("rango2"))
                Else
                    Me.rango2 = 0
                End If
                If Not Convert.IsDBNull(dr("sucursal")) Then
                    Me.sucursal = dr("sucursal")
                Else
                    Me.sucursal = """"
                End If
                If Not Convert.IsDBNull(dr("sitio")) Then
                    Me.sitio = dr("sitio")
                End If
                Me.existe = True

            End If
            dr.Close()

        End Sub

        Public Function Add() As Integer
            Dim sql As String = "insert into userprofiles (idEdadRango, idIdioma, idRol, email, password, nombre, apellidos, activo, sexo, fechaRegistro, vencimiento, ultimoacceso, nombreEmpresa, idEstado, telefono, sitio) values (@idEdadRango, @idIdioma, @idRol, @email, @password, @nombre, @apellidos, @activo, @sexo, @fechaRegistro, @vencimiento, @ultimoacceso, @nombreEmpresa, @idEstado, @telefono, @sitio)"

            Dim params As SqlParameter() = {New SqlParameter("@idEdadRango", idEdadRango),
                                            New SqlParameter("@idIdioma", idIdioma),
                                            New SqlParameter("@idRol", idRol),
                                            New SqlParameter("@email", email),
                                            New SqlParameter("@password", Me.Encriptar(password)),
                                            New SqlParameter("@nombre", nombre),
                                            New SqlParameter("@apellidos", apellidos),
                                            New SqlParameter("@activo", activo),
                                            New SqlParameter("@sexo", sexo),
                                            New SqlParameter("@fechaRegistro", fechaRegistro),
                                            New SqlParameter("@vencimiento", vencimiento),
                                            New SqlParameter("@ultimoacceso", ultimoacceso),
                                            New SqlParameter("@nombreEmpresa", nombreEmpresa),
                                            New SqlParameter("@telefono", telefono),
                                            New SqlParameter("@idEstado", idEstado),
                                            New SqlParameter("@sitio", sitio)}

            Dim myu As UserProfile = New UserProfile(email)
            If Not myu.existe Then
                Me.idUserProfile = Me.ExecuteNonQuery(sql, params, True)

                Dim myru As New tienda.RolesUser()
                myru.idRol = 2
                myru.idUserprofile = Me.idUserProfile
                myru.Add()
            End If


            Return 1

        End Function


        Public Function Update() As Integer
            Dim sql As String = "update userprofiles set idEdadRango=@idEdadRango, idIdioma=@idIdioma, idRol=@idRol, email=@email, password=@password, nombre=@nombre, apellidos=@apellidos, activo=@activo, sexo=@sexo, fechaRegistro=@fechaRegistro, vencimiento=@vencimiento, ultimoacceso=@ultimoacceso, nombreEmpresa=@nombreEmpresa, idEstado=@idEstado, telefono=@telefono where iduserprofile=@idUserprofile"

            Dim params As SqlParameter() = {New SqlParameter("@idEdadRango", idEdadRango),
                                            New SqlParameter("@idIdioma", idIdioma),
                                            New SqlParameter("@idRol", idRol),
                                            New SqlParameter("@email", email),
                                            New SqlParameter("@password", Me.Encriptar(password)),
                                            New SqlParameter("@nombre", nombre),
                                            New SqlParameter("@apellidos", apellidos),
                                            New SqlParameter("@activo", activo),
                                            New SqlParameter("@sexo", sexo),
                                            New SqlParameter("@fechaRegistro", fechaRegistro),
                                            New SqlParameter("@vencimiento", vencimiento),
                                            New SqlParameter("@ultimoacceso", ultimoacceso),
                                            New SqlParameter("@idUserprofile", idUserProfile),
                                            New SqlParameter("@nombreEmpresa", nombreEmpresa),
                                            New SqlParameter("@telefono", telefono),
                                            New SqlParameter("@idEstado", idEstado)}


            Return Me.ExecuteNonQuery(sql, params)


        End Function


        Public Function GetDS() As DataSet
            Dim sql As String = "select * from userprofiles"
            Return Me.ExecuteDataSet(sql, Nothing)
        End Function


        '============================== 2010 ===================================
        Public Function ListaEmails(ByVal textoItemCero As String) As DataView
            Dim dTable As New DataTable
            Dim dRow As DataRow

            dTable.Columns.Add(New DataColumn("idUserProfile", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("email", GetType(String)))

            dRow = dTable.NewRow
            dRow(0) = 0
            dRow(1) = textoItemCero
            dTable.Rows.Add(dRow)

            Dim queryString As String = "SELECT idUserProfile, email FROM UserProfiles ORDER BY email"
            Dim dr As System.Data.SqlClient.SqlDataReader = Me.ExecuteReader(queryString, Nothing)

            Do While dr.Read
                dRow = dTable.NewRow
                dRow(0) = CInt(dr("idUserProfile"))
                dRow(1) = dr("email")
                dTable.Rows.Add(dRow)
            Loop
            dr.Close()

            Return New DataView(dTable)
        End Function
    End Class
End Namespace
