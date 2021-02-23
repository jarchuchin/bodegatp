<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MenuMisOpciones.ascx.vb" Inherits="controles_MenuMisOpciones" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<h2>Menú</h2>
<ul class="menu_articulos">
	<li style="text-align:left"><asp:hyperlink id="lnkInfopersonal" runat="server" NavigateUrl="~/sec/personalInfo.aspx">Información personal</asp:hyperlink></li>
	<li style="text-align:left"><asp:hyperlink id="lnkenvio" runat="server" NavigateUrl="~/sec/direcciones.aspx">Direcciones</asp:hyperlink></li>
	<li style="text-align:left"><asp:hyperlink id="lnkOrdenes" runat="server" Font-Bold="true" NavigateUrl="~/sec/HistorialCotizaciones.aspx">Mis proyectos</asp:hyperlink></li>
	<li style="text-align:left;"><asp:hyperlink id="lnkLogout" runat="server" NavigateUrl="~/logout.aspx">Salir</asp:hyperlink></li>
	
</ul>
