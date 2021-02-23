Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports System.Data

Namespace tienda

    Public Class ProductoPregunta
        Inherits DBObject
        Public idProductoPregunta As Integer
        Public idProducto As Integer
        Public Pregunta As String
        Public PreguntaFecha As DateTime
        Public PreguntaUsuario As Integer
        Public Respuesta As String
        Public RespuestaFecha As DateTime
        Public RespuestaUsuario As Integer
        Public Eliminado As Boolean
        Public Calificacion As Integer
        Public existe As Boolean = False


        Sub New()

        End Sub

        Sub New(ByVal claveprincipal As Integer)
            Dim sql As String = "select * from productospreguntas where idProductoPregunta=@idProductoPregunta"
            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveprincipal)}
            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)

            If dr.Read Then
                Me.idProductoPregunta = CInt(dr("idProductoPregunta"))
                Me.idProducto = CInt(dr("idProducto"))
                Me.Pregunta = CStr(dr("Pregunta"))
                Me.PreguntaFecha = CType(dr("PreguntaFecha"), DateTime)
                Me.PreguntaUsuario = CInt(dr("PreguntaUsuario"))
                Me.Respuesta = dr("Respuesta")
                Me.RespuestaFecha = CType(dr("RespuestaFecha"), DateTime)
                Me.RespuestaUsuario = CInt(dr("ResupuestaUsuario"))
                Me.Calificacion = CInt(dr("Calificacion"))
                Me.Eliminado = CBool(dr("eliminado"))
                Me.existe = True
            End If
            dr.Close()

        End Sub




        Public Function Add() As Integer
            Dim sql As String = "insert into productospreguntas (idProducto, Pregunta, PreguntaFecha, PreguntaUsuario, Respuesta, RespuestaFecha, RespuestaUsuario, Calificacion, Eliminado) values (@idProducto, @Pregunta, @PreguntaFecha, @PreguntaUsuario, @Respuesta, @RespuestaUsuario, @RespuestaUsuario, @Calificacion, @Eliminado)"
            Dim params As SqlParameter() = { _
            New SqlParameter("@idProducto", idProducto), _
            New SqlParameter("@Pregunta", Pregunta), _
            New SqlParameter("@PreguntaFecha", PreguntaFecha), _
            New SqlParameter("@PreguntaUsuario", PreguntaUsuario), _
            New SqlParameter("@Respuesta", Respuesta), _
            New SqlParameter("@RespuestaFecha", RespuestaFecha), _
            New SqlParameter("@RespuestaUsuario", RespuestaUsuario), _
            New SqlParameter("@Calificacion", Calificacion), _
            New SqlParameter("@eliminado", Eliminado)}

            Me.idProducto = Me.ExecuteNonQuery(sql, params, True)
            Me.existe = True
            Return 1
        End Function

        Public Function Update() As Integer
            Dim sql As String = "update productospreguntas set idProducto=@idProducto, Pregunta=@Pregunta, PreguntaFecha=@PreguntaFecha, PreguntaUsuario=@PreguntaUsuario, Respuesta=@Respuesta, RespuestaFecha=@RespuestaFecha, RespuestaUsuario=@RespuestaUsuario, Calificacion=@Calificacion, Eliminado=@Eliminado where idProductoPregunta=@idProductoPregunta"
            Dim params As SqlParameter() = { _
          New SqlParameter("@idProductoPregunta", idProductoPregunta), _
          New SqlParameter("@idProducto", idProducto), _
          New SqlParameter("@Pregunta", Pregunta), _
          New SqlParameter("@PreguntaFecha", PreguntaFecha), _
          New SqlParameter("@PreguntaUsuario", PreguntaUsuario), _
          New SqlParameter("@Respuesta", Respuesta), _
          New SqlParameter("@RespuestaFecha", RespuestaFecha), _
          New SqlParameter("@RespuestaUsuario", RespuestaUsuario), _
          New SqlParameter("@Calificacion", Calificacion), _
          New SqlParameter("@eliminado", Eliminado)}

            Return Me.ExecuteNonQuery(sql, params)


        End Function

        Public Function Remove() As Integer
            Me.Eliminado = True
            Return Me.Update()

        End Function

        Public Function Count(claveProducto As Integer, claveUsuario As Integer, clavefecha As Date) As Integer

            Dim sql As String = "select count(idProductoPregunta) as num from productospreguntas where idProducto=@idProducto and PreguntaUsuario=@PreguntaUsuario and year(PreguntaFecha)=@ano and month(PreguntaFecha)=@mes  and day(PreguntaFecha)=@dia"
            Dim params As SqlParameter() = { _
       New SqlParameter("@idProducto", claveProducto), _
       New SqlParameter("@PreguntaUsuario", claveUsuario), _
       New SqlParameter("@dia", clavefecha.Day), _
       New SqlParameter("@mes", clavefecha.Month), _
       New SqlParameter("@ano", clavefecha.Year)}

            Dim regreso As Integer = 0

            Dim dr As SqlDataReader = Me.ExecuteReader(sql, params)
            If dr.Read Then
                If Not Convert.IsDBNull(dr("num")) Then
                    regreso = CInt(dr("num"))
                End If
            End If
            dr.Close()


            Return regreso

        End Function


        Public Function GetDS(claveProducto As Integer) As DataSet
            Dim sql As String = "select pp.*, u.nombre + ' ' + u.apellidos as PNombre,  ux.nombre + ' ' +  ux.apellidos as RNombre from ProductosPreguntas pp left outer join UserProfiles u on pp.PreguntaUsuario=u.idUserProfile left outer join Userprofiles ux  on pp.RespuestaUsuario=ux.idUserProfile  where pp.idProducto=@idProducto and pp.Eliminado=0 order by pp.PreguntaFecha asc"
            Dim params As SqlParameter() = {New SqlParameter("@idProducto", claveProducto)}
            Return Me.ExecuteDataSet(sql, params)
        End Function


        Public Function GetDS() As DataSet
            Dim sql As String = "select pp.*, u.nombre + ' ' + u.apellidos as PNombre,  ux.nombre + ' ' + ux.apellidos as RNombre from ProductosPreguntas pp left outer join UserProfiles u on pp.PreguntaUsuario=u.idUserProfile left outer join Userprofiles ux  on pp.RespuestaUsuario=ux.idUserProfile  and pp.Eliminado=0  order by pp.PreguntaFecha asc"

            Return Me.ExecuteDataSet(sql, Nothing)
        End Function

    End Class
End Namespace

