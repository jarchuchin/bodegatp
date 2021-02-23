<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="BuscarAvanzada.aspx.vb" Inherits="BuscarAvanzada" %>

<%@ Register src="controles/DisplayProductosSearchFull.ascx" tagname="DisplayProductosSearchFull" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	<h2>Búsqueda avanzada</h2>

	<table style="width:90%;">
	<tr>
		<td><asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Buscar productos en:"></asp:Label></td>
		<td><asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Precios entre:"></asp:Label></td>
		<td><asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Con las palabras:"></asp:Label></td>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td><asp:DropDownList ID="drpcategorias" Width="300px" runat="server" Font-Size="12px"></asp:DropDownList></td>
		<td>
			<asp:TextBox ID="txtdesde" runat="server" Width="30px" SkinID="textheader"></asp:TextBox>
			<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtdesde" ErrorMessage="Dato incorrecto" MaximumValue="50000" MinimumValue="0" Type="Currency">*</asp:RangeValidator>
			<cc1:validatorcalloutextender ID="RangeValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RangeValidator1"></cc1:validatorcalloutextender>
			<b>&nbsp;y&nbsp;&nbsp;</b>
			<asp:TextBox ID="txthasta" runat="server" Width="30px" SkinID="textheader"></asp:TextBox> 
			<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtdesde" ControlToValidate="txthasta" ErrorMessage="Los precios no estan en orden" Operator="GreaterThan" Type="Currency">*</asp:CompareValidator>
			<cc1:validatorcalloutextender ID="CompareValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="CompareValidator1"></cc1:validatorcalloutextender>
			<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txthasta" ErrorMessage="Dato incorrecto" MaximumValue="50000" MinimumValue="0" Type="Currency">*</asp:RangeValidator>
			<cc1:validatorcalloutextender ID="RangeValidator2_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RangeValidator2"></cc1:validatorcalloutextender>
		</td>
 		<td><asp:TextBox ID="txtbuscar" runat="server" Width="300px" SkinID="textheader"></asp:TextBox></td>
		<td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" SkinID="botongeneral" Width="56px" /></td>
	</tr>
	</table>
	<uc2:DisplayProductosSearchFull ID="DisplayProductosSearchFull1" runat="server" />
</asp:Content>

