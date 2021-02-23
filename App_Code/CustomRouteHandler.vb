Imports Microsoft.VisualBasic
Imports System.Web.Routing
Imports System.Web.Compilation



Public Class CustomRouteHandler
    Implements IRouteHandler

    Private _virtualPath As String

    Public Sub New(ByVal vPath As String)
        _virtualPath = vPath
    End Sub

    Public Property VirtualPath() As String
        Get
            Return _virtualPath
        End Get
        Private Set(ByVal value As String)
            _virtualPath = value
        End Set
    End Property

    Public Function GetHttpHandler(ByVal requestContext As System.Web.Routing.RequestContext) As System.Web.IHttpHandler Implements System.Web.Routing.IRouteHandler.GetHttpHandler


        Dim handler As IHttpHandler
        handler = GetHandlerFromRequestContext(requestContext)
        For Each urlParm In requestContext.RouteData.Values
            HttpContext.Current.Items(urlParm.Key) = urlParm.Value
        Next

        Return handler

    End Function

    Private Function GetHandlerFromRequestContext(ByVal requestContext As System.Web.Routing.RequestContext) As System.Web.IHttpHandler

        Dim pathPath As VirtualPathData = requestContext.RouteData.Route.GetVirtualPath(requestContext, requestContext.RouteData.Values)
   
        Return CType(BuildManager.CreateInstanceFromVirtualPath(VirtualPath, GetType(Page)), IHttpHandler)

    End Function
End Class





