

Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class ProductoIdioma
        Inherits Producto

        Public idProductoIdioma As Integer
        Public idIdioma As Integer
        Public nombre As String
        Public descripcion As String
        Public especificaciones As String
        Public tags As String
        Public tagColor As String = ""
        Public tagMaterial As String = ""
        Public tagTipo As String = ""

        Public Shadows existe As Boolean = False

        Sub New()

        End Sub


        Sub New(ByVal claveidproducto As Integer, ByVal claveIdioma As Integer)
            MyBase.New(claveidproducto)
            Dim sql As String = "select * from productosidiomas where idProducto=@idProducto and idIdioma=@idIdioma"

            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveidproducto), New SqlParameter("@idIdioma", claveIdioma)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                Me.idProductoIdioma = CInt(dr("idProductoIdioma"))
                Me.idIdioma = CInt(dr("idIdioma"))
                Me.nombre = dr("nombre")
                Me.descripcion = dr("descripcion")
                Me.especificaciones = dr("especificaciones")

                Me.tags = dr("tags")

                If Not Convert.IsDBNull(dr("tagColor")) Then
                    Me.tagColor = dr("tagColor")
                End If
                If Not Convert.IsDBNull(dr("tagMaterial")) Then
                    Me.tagMaterial = dr("tagMaterial")
                End If
                If Not Convert.IsDBNull(dr("tagTipo")) Then
                    Me.tagTipo = dr("tagTipo")
                End If

                Me.existe = True
            End If

            dr.Close()


        End Sub




        Public Overloads Function Add() As Integer
            Dim sql As String = "insert into productosidiomas (idProducto, idIdioma, nombre, descripcion, especificaciones, tags, tagColor, tagMateria, tagTipo) values ( @idProducto, @idIdioma, @nombre, @descripcion, @especificaciones, @tags, @tagColor, @tagMaterial, @tagTipo)"
            If Not MyBase.existe Then
                MyBase.Add()
            End If

            Dim params As SqlParameter() = {New SqlParameter("@idProducto", idProducto),
                                            New SqlParameter("@idIdioma", idIdioma),
                                            New SqlParameter("@nombre", nombre),
                                            New SqlParameter("@descripcion", descripcion),
                                            New SqlParameter("@especificaciones", especificaciones),
                                            New SqlParameter("@tags", tags),
                                            New SqlParameter("@tagColor", tagColor),
                                            New SqlParameter("@tagMaterial", tagMaterial),
                                            New SqlParameter("@tagTipo", tagTipo)}

            Me.idProductoIdioma = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True

            Return 1
        End Function

        Public Overloads Function Update() As Integer
            Dim sql As String = "update productosidiomas set idProducto=@idProducto, idIdioma=@idIdioma, nombre=@nombre, descripcion=@descripcion, especificaciones=@especificaciones, tags=@tags, tagColor=@tagColor, tagMaterial=@tagMateria, tagTipo=@tagTipo  where idProductoIdioma=@idProductoIdioma"
            MyBase.Update()

            Dim params As SqlParameter() = {New SqlParameter("@idProducto", idProducto),
                                          New SqlParameter("@idIdioma", idIdioma),
                                          New SqlParameter("@nombre", nombre),
                                          New SqlParameter("@descripcion", descripcion),
                                          New SqlParameter("@especificaciones", especificaciones),
                                            New SqlParameter("@idProductoIdioma", idProductoIdioma),
                                            New SqlParameter("@tags", tags),
                                            New SqlParameter("@tagColor", tagColor),
                                            New SqlParameter("@tagMaterial", tagMaterial),
                                            New SqlParameter("@tagTipo", tagTipo)}

            If Me.existe Then
                Me.ExecuteNonQuery(sql, params)
            Else
                Me.Add()
            End If



        End Function

        Public Overloads Function Remove() As Integer
            Return MyBase.Remove()
        End Function

        Public Function GetDS(ByVal claveIdioma As Integer) As DataSet
            Dim sql As String = "select c.*, ci.idIdioma, ci.nombre, ci.descripcion, ci.especificaciones, ci.tags from Productos c, ProductosIdiomas ci where c.idProducto=ci.idProducto and ci.ididioma = @idIdioma and c.eliminado=0 and c.online=1 "
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}
            Return Me.ExecuteDataSet(sql, params)

        End Function


        Public Function GetDRRandom(ByVal claveidioma As Integer, ByVal numero As Integer) As SqlDataReader


            Dim sql As String = "select top " & numero & " c.*, ci.idIdioma, ci.nombre, ci.descripcion, ci.especificaciones, ci.tags," & _
             " isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=c.idproducto and pf.principal=1), 'default.jpg') as imagen, " & _
             " isnull((select top 1 pp.precio from precios pp where pp.identidad=c.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio " & _
             " from Productos c, ProductosIdiomas ci where c.idProducto=ci.idProducto and ci.ididioma = @idIdioma and c.eliminado=0 and c.online=1 ORDER BY NEWID() "
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveidioma)}
            Return Me.ExecuteReader(sql, params)





        End Function

        Public Function GetDSRandom(ByVal claveidioma As Integer, ByVal numero As Integer) As DataSet


            Dim sql As String = "select top " & numero & " c.*, ci.idIdioma, ci.nombre, ci.descripcion, ci.especificaciones, ci.tags," & _
             " isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=c.idproducto and pf.principal=1), 'default.jpg') as imagen, " & _
             " isnull((select top 1 pp.precio from precios pp where pp.identidad=c.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio " & _
             " from Productos c, ProductosIdiomas ci where c.idProducto=ci.idProducto and ci.ididioma = @idIdioma and c.eliminado=0 and c.online=1 and isnull((select top 1 pp.precio from precios pp where pp.idEntidad=c.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') > 0 ORDER BY NEWID() "
            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveidioma)}
            Return Me.ExecuteDataSet(sql, params)





        End Function


        Public Function GetDSTags(ByVal claveidioma As Integer, ByVal tags As String, ByVal claveorden As String, ByVal desde As Decimal, ByVal hasta As Decimal, clavetagColor As String, clavetagMaterial As String, clavetagTIpo As String) As DataSet

            tags = tags.ToLower.Replace("declare", " ")
            tags = tags.ToLower.Replace("cast", " ")
            tags = tags.ToLower.Replace("exec", " ")
            tags = tags.ToLower.Replace("set", " ")
            tags = tags.Replace("'", "")



            Dim constructor As String() = tags.Split(",")
            Dim i As Integer = 0
            Dim sql2 As String = ""
            For i = 0 To constructor.Length - 1
                If constructor(i).Length > 2 Then
                    If sql2 = "" Then
                        sql2 = sql2 & " ci.tags like  '%" & constructor(i).Trim & "%'"
                    Else
                        sql2 = sql2 & " or ci.tags like '%" & constructor(i).Trim & "%'"
                    End If
                End If
            Next

            If sql2 <> "" Then
                sql2 = " and (" & sql2 & ")"
            End If


            'seccion clavetagsColor
            clavetagColor = clavetagColor.ToLower.Replace("declare", " ")
            clavetagColor = clavetagColor.ToLower.Replace("cast", " ")
            clavetagColor = clavetagColor.ToLower.Replace("exec", " ")
            clavetagColor = clavetagColor.ToLower.Replace("set", " ")
            clavetagColor = clavetagColor.Replace("'", "")

            constructor = clavetagColor.Split(",")
            i = 0
            Dim sql3 As String = ""
            For i = 0 To constructor.Length - 1
                If constructor(i).Length > 2 Then
                    If sql3 = "" Then
                        sql3 = sql3 & " ci.tagColor like  '%" & constructor(i).Trim & "%'"
                    Else
                        sql3 = sql3 & " or ci.tagColor like '%" & constructor(i).Trim & "%'"
                    End If
                End If
            Next

            If sql3 <> "" Then
                sql2 = sql2 & " and (" & sql3 & ")"
            End If

            'seccion clavetagMaterial
            clavetagMaterial = clavetagMaterial.ToLower.Replace("declare", " ")
            clavetagMaterial = clavetagMaterial.ToLower.Replace("cast", " ")
            clavetagMaterial = clavetagMaterial.ToLower.Replace("exec", " ")
            clavetagMaterial = clavetagMaterial.ToLower.Replace("set", " ")
            clavetagMaterial = clavetagMaterial.Replace("'", "")

            constructor = clavetagMaterial.Split(",")
            i = 0
            Dim sql4 As String = ""
            For i = 0 To constructor.Length - 1
                If constructor(i).Length > 2 Then
                    If sql4 = "" Then
                        sql4 = sql4 & " ci.tagMaterial like  '%" & constructor(i).Trim & "%'"
                    Else
                        sql4 = sql4 & " or ci.tagMaterial like '%" & constructor(i).Trim & "%'"
                    End If
                End If
            Next

            If sql4 <> "" Then
                sql2 = sql2 & " and (" & sql4 & ")"
            End If


            'seccion clavetagTipo
            clavetagTIpo = clavetagTIpo.ToLower.Replace("declare", " ")
            clavetagTIpo = clavetagTIpo.ToLower.Replace("cast", " ")
            clavetagTIpo = clavetagTIpo.ToLower.Replace("exec", " ")
            clavetagTIpo = clavetagTIpo.ToLower.Replace("set", " ")
            clavetagTIpo = clavetagTIpo.Replace("'", "")

            constructor = clavetagTIpo.Split(",")
            i = 0
            Dim sql5 As String = ""
            For i = 0 To constructor.Length - 1
                If constructor(i).Length > 2 Then
                    If sql5 = "" Then
                        sql5 = sql5 & " ci.tagMaterial like  '%" & constructor(i).Trim & "%'"
                    Else
                        sql5 = sql5 & " or ci.tagMaterial like '%" & constructor(i).Trim & "%'"
                    End If
                End If
            Next

            If sql5 <> "" Then
                sql2 = sql2 & " and (" & sql5 & ")"
            End If


            Dim preciossql As String = String.Empty
            If desde > 0 And hasta > 0 Then
                preciossql = " and isnull((select top 1 pp.precio from precios pp where pp.idEntidad=c.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') >= @desde and isnull((select top 1 pp.precio from precios pp where pp.idEntidad=c.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') <= @hasta "
            Else
                If desde = 0 And hasta = 0 Then
                Else
                    If desde > 0 Then
                        preciossql = "and isnull((select top 1 pp.precio from precios pp where pp.idEntidad=c.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') >= @desde "
                    End If
                    If hasta > 0 Then
                        preciossql = " and isnull((select top 1 pp.precio from precios pp where pp.idEntidad=c.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') <= @hasta "
                    End If
                End If
            End If

            Dim sql As String = "select  c.*, ci.idIdioma, ci.nombre, ci.descripcion, ci.especificaciones, ci.tags," &
             " isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=c.idproducto and pf.principal=1), 'default.jpg') as imagen, " &
             " isnull((select top 1 pp.precio from precios pp where pp.idEntidad=c.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio " &
             " from Productos c, ProductosIdiomas ci where c.idProducto=ci.idProducto and ci.ididioma = @idIdioma and c.eliminado=0 and c.online=1 " & preciossql & sql2 & " order by  " & claveorden



            'If claveorden = "relevancia" Then
            '    sql = sql & " desc"
            'Else
            '    sql = sql & " asc"

            'End If

            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveidioma), New SqlParameter("@desde", desde), New SqlParameter("@hasta", hasta)}
            Return Me.ExecuteDataSet(sql, params)





        End Function




        Public Function GetDSSearch(ByVal claveidioma As Integer, ByVal text As String, ByVal claveorden As String) As DataSet

            text = text.ToLower.Replace("declare", " ")
            text = text.ToLower.Replace("cast", " ")
            text = text.ToLower.Replace("exec", " ")
            text = text.ToLower.Replace("set", " ")

            text = text.Replace("y", "")
            text = text.Replace("Y", "")
            text = text.Replace(":", "")
            text = text.Replace("'", "")
            Dim constructor As String() = text.Split(" ")
            Dim i As Integer = 0
            Dim sql2 As String = ""
            For i = 0 To constructor.Length - 1
                If constructor(i).Length > 0 Then
                    If sql2 = "" Then
                        If IsNumeric(constructor(i).Trim) Then
                            sql2 = sql2 & " p.idProducto=" & constructor(i).Trim & " "
                        Else
                            sql2 = sql2 & " pi.nombre like '%" & constructor(i).Trim & "%' or pi.descripcion like '%" & constructor(i).Trim & "%' or pi.especificaciones like '%" & constructor(i).Trim & "%' or pi.especificaciones like '%" & constructor(i).Trim & "%' or pi.tags like '%" & constructor(i).Trim & "%'  or p.clave like '%" & constructor(i).Trim & "%' "
                        End If

                    Else
                        If IsNumeric(constructor(i).Trim) Then
                            sql2 = sql2 & " or p.idProducto=" & constructor(i).Trim & " "
                        Else
                            sql2 = sql2 & " or pi.nombre like '%" & constructor(i).Trim & "%' or pi.descripcion like '%" & constructor(i).Trim & "%' or pi.especificaciones like '%" & constructor(i).Trim & "%' or pi.especificaciones like '%" & constructor(i).Trim & "%' or pi.tags like '%" & constructor(i).Trim & "%'  or p.clave like '%" & constructor(i).Trim & "%' "
                        End If
                    End If
                End If


            Next


            If sql2 <> "" Then
                sql2 = " and (" & sql2 & ")"
            End If



            Dim sql As String = "select  p.*, pi.idIdioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags," & _
          " isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=p.idproducto and pf.principal=1), 'default.jpg') as imagen, " & _
          " isnull((select top 1 pp.precio from precios pp where pp.idEntidad=p.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio " & _
          " from Productos p, ProductosIdiomas pi where p.idProducto=pi.idProducto and pi.ididioma = @idIdioma and p.eliminado=0 and p.online=1 " & sql2 & " order by " & claveorden & " asc"





            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveidioma)}
            Return Me.ExecuteDataSet(sql, params)
        End Function


        Public Function GetDSSearchFull(ByVal claveidioma As Integer, ByVal text As String, ByVal claveorden As String, ByVal claveCategoria As Integer, ByVal desde As Decimal, ByVal hasta As Decimal, clavetagColor As String, clavetagMaterial As String, clavetagTipo As String) As DataSet


            If IsNothing(text) Then
                text = ""
            End If

            text = text.ToLower.Replace("declare", " ")
            text = text.ToLower.Replace("cast", " ")
            text = text.ToLower.Replace("exec", " ")
            text = text.ToLower.Replace("set", " ")


            Dim i As Integer = 0
            Dim sql2 As String = ""
            If text <> "" Then
                text = text.Replace(" y ", "")
                text = text.Replace(" Y ", "")
                text = text.Replace(":", "")
                text = text.Replace(" de ", "")
                text = text.Replace("'", "")


                Dim constructor2 As String() = text.Split(" ")

                For i = 0 To constructor2.Length - 1
                    If constructor2(i).Length > 0 Then
                        If sql2 = "" Then
                            'If IsNumeric(constructor(i).Trim) Then
                            '    sql2 = sql2 & " p.idProducto=" & constructor(i).Trim & " "
                            'Else
                            sql2 = sql2 & " pi.nombre + ' ' + pi.descripcion + ' ' + pi.especificaciones + ' ' + pi.tags + ' ' + p.clave   like '%" & constructor2(i).Trim & "%' COLLATE Modern_Spanish_CI_AI or convert(varchar(50), p.idProducto) = '" & constructor2(i).Trim & "' "
                            '  End If

                        Else
                            'If IsNumeric(constructor(i).Trim) Then
                            'sql2 = sql2 & " or p.idProducto=" & constructor(i).Trim & " "
                            '   Else
                            sql2 = sql2 & " or pi.nombre + ' ' + pi.descripcion + ' ' + pi.especificaciones + ' ' + pi.tags + ' ' + p.clave   like '%" & constructor2(i).Trim & "%' COLLATE Modern_Spanish_CI_AI or convert(varchar(50), p.idProducto) = '" & constructor2(i).Trim & "' "
                            ' End If
                        End If
                    End If



                Next
            End If


            Dim categotags As String = "" 'getTagsCatego(claveCategoria, claveidioma)

            If sql2 <> "" Then
                If categotags = "" Then
                    sql2 = " and (" & sql2 & ") "
                Else
                    sql2 = " and (" & sql2 & ") and ( " & categotags & " ) "
                End If
            Else
                If categotags <> "" Then
                    sql2 = " and (" & categotags & ") "
                End If
            End If


            'aqui ponemos los nuevos tags. 
            'seccion clavetagsColor
            clavetagColor = clavetagColor.ToLower.Replace("declare", " ")
            clavetagColor = clavetagColor.ToLower.Replace("cast", " ")
            clavetagColor = clavetagColor.ToLower.Replace("exec", " ")
            clavetagColor = clavetagColor.ToLower.Replace("set", " ")
            clavetagColor = clavetagColor.Replace("'", "")

            Dim constructor As String() = clavetagColor.Split(",")
            i = 0
            Dim sql3 As String = ""
            For i = 0 To constructor.Length - 1
                If constructor(i).Length > 2 Then
                    If sql3 = "" Then
                        sql3 = sql3 & " pi.tagColor like  '%" & constructor(i).Trim & "%'"
                    Else
                        sql3 = sql3 & " or pi.tagColor like '%" & constructor(i).Trim & "%'"
                    End If
                End If
            Next

            If sql3 <> "" Then
                sql2 = sql2 & " and (" & sql3 & ")"
            End If

            'seccion clavetagMaterial
            clavetagMaterial = clavetagMaterial.ToLower.Replace("declare", " ")
            clavetagMaterial = clavetagMaterial.ToLower.Replace("cast", " ")
            clavetagMaterial = clavetagMaterial.ToLower.Replace("exec", " ")
            clavetagMaterial = clavetagMaterial.ToLower.Replace("set", " ")
            clavetagMaterial = clavetagMaterial.Replace("'", "")

            constructor = clavetagMaterial.Split(",")
            i = 0
            Dim sql4 As String = ""
            For i = 0 To constructor.Length - 1
                If constructor(i).Length > 2 Then
                    If sql4 = "" Then
                        sql4 = sql4 & " pi.tagMaterial like  '%" & constructor(i).Trim & "%'"
                    Else
                        sql4 = sql4 & " or pi.tagMaterial like '%" & constructor(i).Trim & "%'"
                    End If
                End If
            Next

            If sql4 <> "" Then
                sql2 = sql2 & " and (" & sql4 & ")"
            End If


            'seccion clavetagTipo
            clavetagTipo = clavetagTipo.ToLower.Replace("declare", " ")
            clavetagTipo = clavetagTipo.ToLower.Replace("cast", " ")
            clavetagTipo = clavetagTipo.ToLower.Replace("exec", " ")
            clavetagTipo = clavetagTipo.ToLower.Replace("set", " ")
            clavetagTipo = clavetagTipo.Replace("'", "")

            constructor = clavetagTipo.Split(",")
            i = 0
            Dim sql5 As String = ""
            For i = 0 To constructor.Length - 1
                If constructor(i).Length > 2 Then
                    If sql5 = "" Then
                        sql5 = sql5 & " pi.tagTipo like  '%" & constructor(i).Trim & "%'"
                    Else
                        sql5 = sql5 & " or pi.tagTipo like '%" & constructor(i).Trim & "%'"
                    End If
                End If
            Next

            If sql5 <> "" Then
                sql2 = sql2 & " and (" & sql5 & ")"
            End If




            Dim preciossql As String = String.Empty
            If desde > 0 And hasta > 0 Then
                preciossql = " and isnull((select top 1 pp.precio from precios pp where pp.idEntidad=p.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') >= @desde and isnull((select top 1 pp.precio from precios pp where pp.idEntidad=p.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') <= @hasta "
            Else
                If desde = 0 And hasta = 0 Then
                Else
                    If desde > 0 Then
                        preciossql = " and isnull((select top 1 pp.precio from precios pp where pp.idEntidad=p.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') >= @desde "
                    End If
                    If hasta > 0 Then
                        preciossql = " and isnull((select top 1 pp.precio from precios pp where pp.idEntidad=p.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') <= @hasta "
                    End If
                End If
            End If


            Dim sql As String = " select  p.*, pi.idIdioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags," &
          " isnull((select top 1 pf.imagen from productosfotos pf where pf.idproducto=p.idproducto and pf.principal=1), 'default.jpg') as imagen, " &
          " isnull((select top 1 pp.precio from precios pp where pp.idEntidad=p.idproducto and pp.entidad='Producto' order by pp.precio asc), '0.00') as precio " &
          " from Productos p, ProductosIdiomas pi where p.idProducto=pi.idProducto and pi.ididioma = @idIdioma and p.eliminado=0 and p.online=1  " & preciossql & sql2 & "   order by " & claveorden



            'If claveorden = "relevancia" Then
            '    sql = sql & " desc"
            'Else
            '    sql = sql & " asc"

            'End If



            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveidioma), New SqlParameter("@desde", desde), New SqlParameter("@hasta", hasta)}
            Return Me.ExecuteDataSet(sql, params)


        End Function

        Public Function getTagsCatego(ByVal claveCategoria As Integer, ByVal claveidioma As Integer) As String

            Dim mysql As String = String.Empty

            If claveCategoria > 0 Then
                Dim myc As New CategoriaIdioma
                Dim dr As SqlDataReader = myc.GetDR(claveidioma, claveCategoria)
                Do While dr.Read
                    Dim tags As String = dr("tags")
                    Dim constructor As String() = tags.Split(",")
                    For i = 0 To constructor.Length - 1
                        If mysql = String.Empty Then
                            mysql = mysql & " pi.tags like '%" & constructor(i).Trim & "%'  "
                        Else
                            mysql = mysql & " or pi.tags like '%" & constructor(i).Trim & "%'  "
                        End If
                    Next
                Loop
                dr.Close()


                myc = New tienda.CategoriaIdioma(claveCategoria, claveidioma)
                Dim tagsC As String = myc.tags
                Dim constructorC As String() = tagsC.Split(",")
                For i = 0 To constructorC.Length - 1
                    If mysql = String.Empty Then
                        mysql = mysql & " pi.tags like '%" & constructorC(i).Trim & "%'  "
                    Else
                        mysql = mysql & " or pi.tags like '%" & constructorC(i).Trim & "%'  "
                    End If
                Next


            End If




            Return mysql

        End Function


        Public Function GetDSDetails(ByVal claveIdioma As Integer) As DataSet
            Dim sql As String = "SELECT  p.idProducto, p.idFabricante, p.idPaisOrigen, p.idFormato, p.clave, p.visitas, p.ventas, p.existencia, p.ventaMinima, " _
             & "p.descuentoDistribuidor, p.peso, p.fecharegistro, p.fechamodificacion, p.eliminado, pi.idIdioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags, " _
             & "pid.nombre AS pais, fi.Nombre AS formato, fa.prefijo as fabricante FROM Productos AS p LEFT OUTER JOIN ProductosIdiomas AS pi ON p.idProducto = pi.idProducto LEFT OUTER JOIN " _
             & "FormatosIdiomas AS fi ON p.idFormato = fi.idFormato LEFT OUTER JOIN Fabricantes AS fa ON p.idFabricante = fa.idFabricante LEFT OUTER JOIN " _
             & "PaisesIdiomas AS pid ON p.idPaisOrigen = pid.idPais WHERE (pi.idIdioma = @idIdioma) AND (p.eliminado = 0) and (p.online=1)"

            Dim params As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma)}
            Return Me.ExecuteDataSet(sql, params)

        End Function

        Public Function GetDSDetailsPreciosNested(ByVal claveIdioma As Integer) As DataSet
            Dim ds As New DataSet
            Dim queryString As String
            Dim connString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
            Dim dataAdapterProductos, dataAdapterPrecios, dataAdapterServicios As SqlDataAdapter

            queryString = "SELECT  DISTINCT p.idProducto, p.idFabricante, p.idPaisOrigen, p.idFormato, p.clave, p.visitas, p.ventas, p.existencia, p.ventaMinima, " _
             & "p.descuentoDistribuidor, p.peso, p.fecharegistro, p.fechamodificacion, p.eliminado, pi.idIdioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags, " _
             & "pid.nombre AS pais, fi.Nombre AS formato, fa.prefijo as fabricante FROM Productos AS p LEFT OUTER JOIN ProductosIdiomas AS pi ON p.idProducto = pi.idProducto LEFT OUTER JOIN " _
             & "FormatosIdiomas AS fi ON p.idFormato = fi.idFormato AND fi.idIdioma = " & claveIdioma & " LEFT OUTER JOIN Fabricantes AS fa ON p.idFabricante = fa.idFabricante LEFT OUTER JOIN " _
             & "PaisesIdiomas AS pid ON p.idPaisOrigen = pid.idPais AND pid.idIdioma = " & claveIdioma & " WHERE pi.idIdioma = " & claveIdioma & " AND p.eliminado = 0 and p.online=1 "

            dataAdapterProductos = New SqlDataAdapter(queryString, connString)
            dataAdapterProductos.Fill(ds, "Productos")

            queryString = "SELECT pp.idPrecio, pp.idEntidad AS idProducto, pp.numero, ISNULL(aux.escala + 1, 1) AS desde, pp.escala AS hasta, pp.precio " _
             & "FROM Productos AS p INNER JOIN Precios AS pp ON p.idProducto = pp.idEntidad AND pp.entidad = 'Producto' LEFT OUTER JOIN " _
             & "	(SELECT idEntidad, escala, numero FROM Precios AS pp2 WHERE entidad = 'Producto') AS aux ON pp.idEntidad = aux.idEntidad " _
             & "AND aux.numero = pp.numero - 1 WHERE p.eliminado = 0 and p.online=1 ORDER BY idProducto, pp.numero"

            dataAdapterPrecios = New SqlDataAdapter(queryString, connString)
            dataAdapterPrecios.Fill(ds, "Precios")

            queryString = "SELECT ps.idProducto, si.nombre AS servicio FROM ProductosServicios AS ps INNER JOIN Servicios AS s ON ps.idServicio = s.idServicio INNER JOIN " _
             & "ServiciosIdiomas AS si ON s.idServicio = si.idServicio WHERE si.idIdioma = " & claveIdioma

            dataAdapterServicios = New SqlDataAdapter(queryString, connString)
            dataAdapterServicios.Fill(ds, "Servicios")

            Dim relation As New DataRelation("ProductoPrecio", ds.Tables("Productos").Columns("idProducto"), ds.Tables("Precios").Columns("idProducto"), False)
            Dim relation2 As New DataRelation("ProductoServicio", ds.Tables("Productos").Columns("idProducto"), ds.Tables("Servicios").Columns("idProducto"), False)

            ds.Relations.Add(relation)
            ds.Relations.Add(relation2)

            Return ds
        End Function

        Public Function GetDSDetailsPreciosNested(ByVal claveIdioma As Integer, ByVal filtroFechaDesde As Date, ByVal filtroFechaHasta As Date) As DataSet
            'Dim ds As New DataSet
            'Dim queryString As String
            'Dim connString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
            'Dim dataAdapterProductos, dataAdapterPrecios As SqlDataAdapter
            Dim dsProductos, dsPrecios As DataSet

            Dim queryString As String = "SELECT  DISTINCT p.idProducto, p.idFabricante, p.idPaisOrigen, p.idFormato, p.clave, p.visitas, p.ventas, p.existencia, p.ventaMinima, " _
             & "p.descuentoDistribuidor, p.peso, p.fecharegistro, p.fechamodificacion, p.eliminado, pi.idIdioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags, " _
             & "pid.nombre AS pais, fi.Nombre AS formato, fa.prefijo as fabricante FROM Productos AS p LEFT OUTER JOIN ProductosIdiomas AS pi ON p.idProducto = pi.idProducto LEFT OUTER JOIN " _
             & "FormatosIdiomas AS fi ON p.idFormato = fi.idFormato AND fi.idIdioma = " & claveIdioma & " LEFT OUTER JOIN Fabricantes AS fa ON p.idFabricante = fa.idFabricante LEFT OUTER JOIN " _
             & "PaisesIdiomas AS pid ON p.idPaisOrigen = pid.idPais AND pid.idIdioma = " & claveIdioma & " WHERE pi.idIdioma = " & claveIdioma & " AND p.eliminado = 0 and p.online=1 " _
             & "AND p.fechamodificacion >= "
            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idIdioma", claveIdioma), _
             New SqlParameter("@fechaDesde", filtroFechaDesde), _
             New SqlParameter("@fechaHasta", filtroFechaHasta)}

            dsProductos = Me.ExecuteDataSet(queryString, parametros)
            dsProductos.Tables(0).TableName = "Productos"

            'dataAdapterProductos = New SqlDataAdapter(queryString, connString)
            'dataAdapterProductos.Fill(ds, "Productos")

            queryString = "SELECT pp.idPrecio, pp.idEntidad AS idProducto, pp.numero, ISNULL(aux.escala + 1, 1) AS desde, pp.escala AS hasta, pp.precio " _
             & "FROM Productos AS p INNER JOIN Precios AS pp ON p.idProducto = pp.idEntidad AND pp.entidad = 'Producto' LEFT OUTER JOIN " _
             & "	(SELECT idEntidad, escala, numero FROM Precios AS pp2 WHERE entidad = 'Producto') AS aux ON pp.idEntidad = aux.idEntidad " _
             & "AND aux.numero = pp.numero - 1 WHERE p.eliminado = 0 and p.online=1 ORDER BY idProducto, pp.numero"

            dsPrecios = Me.ExecuteDataSet(queryString, Nothing)
            dsPrecios.Tables(0).TableName = "Precios"

            'dataAdapterPrecios = New SqlDataAdapter(queryString, connString)
            'dataAdapterPrecios.Fill(ds, "Precios")

            dsProductos.Tables.Add(dsPrecios.Tables(0))
            Dim relation As New DataRelation("ProductoPrecio", dsProductos.Tables("Productos").Columns("idProducto"), dsProductos.Tables("Precios").Columns("idProducto"), False)

            dsProductos.Relations.Add(relation)

            Return dsProductos
        End Function

        Public Function GetDSDetailsPreciosNested2(ByVal claveIdioma As Integer, ByVal filtroFechaDesde As Date, ByVal filtroFechaHasta As Date) As DataSet
            'Dim ds As New DataSet
            'Dim queryString As String
            'Dim connString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
            'Dim dataAdapterProductos, dataAdapterPrecios As SqlDataAdapter
            Dim dsProductos, dsPrecios As DataSet

            Dim queryString As String = "SELECT  DISTINCT p.idProducto, p.idFabricante, p.idPaisOrigen, p.idFormato, p.clave, p.visitas, p.ventas, p.existencia, p.ventaMinima, " _
             & "p.descuentoDistribuidor, p.peso, p.fecharegistro, p.fechamodificacion, p.eliminado, pi.idIdioma, pi.nombre, pi.descripcion, pi.especificaciones, pi.tags, " _
             & "pid.nombre AS pais, fi.Nombre AS formato, fa.prefijo as fabricante FROM Productos AS p LEFT OUTER JOIN ProductosIdiomas AS pi ON p.idProducto = pi.idProducto LEFT OUTER JOIN " _
             & "FormatosIdiomas AS fi ON p.idFormato = fi.idFormato AND fi.idIdioma = " & claveIdioma & " LEFT OUTER JOIN Fabricantes AS fa ON p.idFabricante = fa.idFabricante LEFT OUTER JOIN " _
             & "PaisesIdiomas AS pid ON p.idPaisOrigen = pid.idPais AND pid.idIdioma = " & claveIdioma & " WHERE pi.idIdioma = " & claveIdioma & " AND p.eliminado = 0  and p.online=1 " _
             & "AND p.fechamodificacion >= "
            Dim parametros As SqlParameter() = { _
             New SqlParameter("@idIdioma", claveIdioma), _
             New SqlParameter("@fechaDesde", filtroFechaDesde), _
             New SqlParameter("@fechaHasta", filtroFechaHasta)}

            dsProductos = Me.ExecuteDataSet(queryString, parametros)
            dsProductos.Tables(0).TableName = "Productos"

            'dataAdapterProductos = New SqlDataAdapter(queryString, connString)
            'dataAdapterProductos.Fill(ds, "Productos")

            queryString = "SELECT pp.idPrecio, pp.idEntidad AS idProducto, pp.numero, ISNULL(aux.escala + 1, 1) AS desde, pp.escala AS hasta, pp.precio " _
             & "FROM Productos AS p INNER JOIN Precios AS pp ON p.idProducto = pp.idEntidad AND pp.entidad = 'Producto' LEFT OUTER JOIN " _
             & "	(SELECT idEntidad, escala, numero FROM Precios AS pp2 WHERE entidad = 'Producto') AS aux ON pp.idEntidad = aux.idEntidad " _
             & "AND aux.numero = pp.numero - 1 WHERE p.eliminado = 0 and p.online=1 ORDER BY idProducto, pp.numero"

            dsPrecios = Me.ExecuteDataSet(queryString, Nothing)
            dsPrecios.Tables(0).TableName = "Precios"

            'dataAdapterPrecios = New SqlDataAdapter(queryString, connString)
            'dataAdapterPrecios.Fill(ds, "Precios")

            dsProductos.Tables.Add(dsPrecios.Tables(0))
            Dim relation As New DataRelation("ProductoPrecio", dsProductos.Tables("Productos").Columns("idProducto"), dsProductos.Tables("Precios").Columns("idProducto"), False)

            dsProductos.Relations.Add(relation)

            Return dsProductos
        End Function

        Public Function ListaProductosParaOrden(ByVal claveIdioma As Integer, ByVal claveOrden As Integer) As DataView
            Dim dTable As New DataTable
            Dim dRow As DataRow
            Dim queryString As String
            Dim dr As SqlDataReader

            dTable.Columns.Add(New DataColumn("idProducto", GetType(Integer)))
            dTable.Columns.Add(New DataColumn("producto", GetType(String)))
            dTable.Columns.Add(New DataColumn("clave", GetType(String)))
            dTable.Columns.Add(New DataColumn("nombre", GetType(String)))
            dTable.Columns.Add(New DataColumn("tags", GetType(String)))

            queryString = "SELECT p.idProducto, p.clave, pi.nombre, pi.tags FROM Productos AS p INNER JOIN ProductosIdiomas AS pi ON p.idProducto = pi.idProducto " _
             & "AND pi.idIdioma = @idIdioma WHERE p.idProducto NOT IN (SELECT idProducto FROM OrdenesDetalles WHERE idOrden = @idOrden) ORDER BY pi.nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("@idIdioma", claveIdioma), New SqlParameter("@idOrden", claveOrden)}
            dr = Me.ExecuteReader(queryString, parametros)

            Do While dr.Read
                Dim product As String
                If dr("nombre").ToString.Length >= 75 Then
                    product = Left(dr("nombre"), 71) & "... " & dr("clave")
                Else
                    If dr("nombre").ToString.Length = 74 Then
                        product = dr("nombre").ToString & " " & dr("clave")
                    Else
                        Dim puntos As String = ""
                        For i As Integer = 1 To 74 - dr("nombre").ToString.Length
                            If i Mod 2 = 0 Then
                                puntos = puntos & " "
                            Else
                                puntos = puntos & "."
                            End If
                        Next
                        puntos = puntos & " "
                        product = dr("nombre").ToString & puntos & dr("clave")
                    End If
                End If

                dRow = dTable.NewRow
                dRow(0) = dr("idProducto")
                dRow(1) = product
                dRow(2) = dr("clave")
                dRow(3) = dr("nombre")
                dRow(4) = dr("tags")
                dTable.Rows.Add(dRow)
            Loop
            dr.Close()

            Return New DataView(dTable)
        End Function

        '======================  2010 ======================== START



        Public Function GetDSProductosNotInOrden(ByVal claveOrden As Integer, ByVal claveIdioma As Integer) As DataSet
            Dim queryString As String = "SELECT p.idProducto, p.clave, pi.nombre, pi.tags, p.ventaMinima, ISNULL(pf.imagen, '') AS imagen FROM Productos AS p INNER JOIN " _
             & "ProductosIdiomas AS pi ON p.idProducto = pi.idProducto LEFT OUTER JOIN ProductosFotos AS pf ON p.idProducto = pf.idProducto AND pf.principal = 1 " _
             & "WHERE p.idProducto IN (SELECT c.idEntidad AS idProducto FROM Colores AS c INNER JOIN Codigoscolores AS cc ON c.idCodigocolor = cc.idCodigocolor " _
             & "WHERE c.tipoEntidad = 'Producto' AND c.idEntidad IN (SELECT idProducto FROM Ordenesdetalles WHERE idOrden = @idOrden) AND cc.codigoHexadecimal NOT IN " _
             & "(SELECT color FROM Ordenesdetalles WHERE idOrden = @idOrden AND color <> '') UNION SELECT idProducto FROM Productos WHERE idProducto NOT IN " _
             & "(SELECT idProducto FROM Ordenesdetalles WHERE idOrden = @idOrden)) AND pi.idIdioma = @idIdioma"

            Dim parametros As SqlParameter() = {New SqlParameter("idOrden", claveOrden), New SqlParameter("idIdioma", claveIdioma)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function

        Public Function GetDSProductosParaOrden(ByVal claveIdioma As Integer) As DataSet
            Dim queryString As String = "SELECT p.idProducto, p.clave, pi.nombre,  pi.tags, p.ventaMinima, ISNULL(pf.imagen, '') AS imagen  FROM Productos AS p INNER JOIN ProductosIdiomas AS pi " _
             & "ON p.idProducto = pi.idProducto LEFT OUTER JOIN ProductosFotos AS pf ON p.idProducto = pf.idProducto AND pf.principal = 1 WHERE pi.idIdioma = @idIdioma " _
             & "AND p.eliminado = 0 ORDER BY pi.nombre"

            Dim parametros As SqlParameter() = {New SqlParameter("idIdioma", claveIdioma)}

            Return Me.ExecuteDataSet(queryString, parametros)
        End Function
    End Class
    '======================  2010 ======================== END

End Namespace

