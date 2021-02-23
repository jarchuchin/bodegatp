<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="Comparador.aspx.vb" Inherits="Comparador" %>

<%@ Register src="controles/DisplayProductoComparar.ascx" tagname="DisplayProductoComparar" tagprefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<h2>Comparar productos</h2>

	<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td width="45" rowspan="3"><asp:Image id="Image5" runat="server" ImageUrl="~/images/transp.gif"  Width="29px" /></td>
		<td height="70" colspan="6"  style=" vertical-align:top;">
			<asp:Panel ID="Panel1" runat="server" Width="100%" ScrollBars="Vertical">
				<asp:DataList ID="DataList1" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
					<ItemTemplate>
						<uc2:DisplayProductoComparar ID="DisplayProductoComparar1" runat="server" claveProducto='<%# cint(eval("idProducto")) %>' />
					</ItemTemplate>
					<ItemStyle  VerticalAlign="Top"/>
				</asp:DataList>
			</asp:Panel>
		</td>
		<td width="45" rowspan="3"><asp:Image id="Image1" runat="server" ImageUrl="~/images/transp.gif" Width="29px" /></td>
	</tr>
	</table>  
</asp:Content>

