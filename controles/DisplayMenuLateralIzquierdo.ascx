<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayMenuLateralIzquierdo.ascx.vb" Inherits="controles_DisplayMenuLateralIzquierdo" %>


<h2 style="font-weight:lighter">&nbsp; CATEGORÍAS</h2>
<asp:Repeater ID="rptCategorias" runat="server">
	<HeaderTemplate>
		<ul class="menu_articulos">
	</HeaderTemplate>
	<ItemTemplate>
		<li style="text-align:left"><asp:HyperLink ID="lnkNombre" runat="server" NavigateUrl='<%# "~/categorias/show/" & Eval("idCategoria") & "/" & getTags(Eval("tags"), Eval("metaKeywords"))%>' Text='<%# eval("Nombre") %>'   ></asp:HyperLink></li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:Repeater>
