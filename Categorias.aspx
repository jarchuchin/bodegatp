<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="Categorias.aspx.vb" Inherits="Categorias" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="controles/DisplayCategoriesFullMap.ascx" tagname="DisplayCategoriesFullMap" tagprefix="uc1" %>
<%@ Register src="controles/DisplayBanners.ascx" tagname="DisplayBanners" tagprefix="uc1" %>
<%@ Register src="controles/DisplayAnunciosCategories.ascx" tagname="DisplayAnunciosCategories" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<h2>Categorías</h2>

            <table cellpadding="0" cellspacing="0" border="0" style="width:100%;" >
            <tr>
                <td style="vertical-align:top; width:485px;">
                   <div class="CajaAzulProducto">
                          <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                            <tr>
                                <td style="width:20px"> <asp:Image ID="Image3" runat="server"  Width="20px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left;"> <asp:Label ID="Label7" runat="server"  ForeColor="black" Font-Bold="true" Font-Size="11px">Organización de categorías</asp:Label> </td>
                            </tr>
                          </table>
                     </div>
                   <uc1:DisplayCategoriesFullMap ID="DisplayCategoriesFullMap1" runat="server" />
                </td>
                <td style=" width:10px;" valign="top">
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/transp.gif" Width="10px" Height="10px" />
                 </td>
                <td style="vertical-align:top; width:485px;">
                    <div class="CajaAzulProducto">
                          <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                            <tr>
                                <td style="width:20px"> <asp:Image ID="Image1" runat="server"  Width="20px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left;"> <asp:Label ID="Label1" runat="server"  ForeColor="black" Font-Bold="true" Font-Size="11px">Busqueda avanzada</asp:Label> </td>
                            </tr>
                          </table>
                     </div>
                      <div style=" background-color:#EBF7C1;">
                      <div style="height:10px"></div>
                         <table style="width: 100%">
                            <tr>
                                <td style="width: 15px">
                                    &nbsp;</td>
                                <td style="width: 301px">
                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                                        Text="Buscar productos en:"></asp:Label>
                                </td>
                                <td style="width: 10px">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Precios entre:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15px">
                                    &nbsp;</td>
                                <td style="width: 301px">
                                    <asp:DropDownList ID="drpcategorias" Width="300px" runat="server" Font-Size="10px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtdesde" runat="server" Width="30px" SkinID="textheader"></asp:TextBox> 
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                        ControlToValidate="txtdesde" ErrorMessage="Dato incorrecto" 
                                        MaximumValue="50000" MinimumValue="0" Type="Currency">*</asp:RangeValidator>
                                    <cc1:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="RangeValidator1">
                                    </cc1:ValidatorCalloutExtender>
                                    &nbsp; 
                                    <b>y</b>&nbsp;
                                    <asp:TextBox ID="txthasta" runat="server" Width="30px" SkinID="textheader"></asp:TextBox> 
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToCompare="txtdesde" ControlToValidate="txthasta" 
                                        ErrorMessage="Los precios no estan en orden" Operator="GreaterThan" 
                                        Type="Currency">*</asp:CompareValidator>
                                    <cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="CompareValidator1">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                        ControlToValidate="txthasta" ErrorMessage="Dato incorrecto" 
                                        MaximumValue="50000" MinimumValue="0" Type="Currency">*</asp:RangeValidator>
                                    <cc1:ValidatorCalloutExtender ID="RangeValidator2_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="RangeValidator2">
                                    </cc1:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15px">
                                    &nbsp;</td>
                                <td style="width: 301px">
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Con las palabras:"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtbuscar" Display="Dynamic" 
                                        ErrorMessage="Coloca una palabra">*</asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                    </cc1:ValidatorCalloutExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 15px">
                                    &nbsp;</td>
                                <td style="width: 301px">
                                    <asp:TextBox ID="txtbuscar" runat="server" Width="300px" SkinID="textheader"></asp:TextBox> </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" 
                                            Text="Buscar"   SkinID="botongeneral" 
                                            Width="56px" /></td>
                            </tr>
                        </table>
                     <div style="height:10px"></div>
                      </div>
                     
                     
                     <div style="height:10px"></div>
                     
			<div class="CajaAzulProducto">
				<table cellpadding="0" cellspacing="0" border="0" style="width:100%;">
				<tr>
					<td style="width:20px;"><asp:Image ID="Image2" runat="server" width="20px"  ImageUrl="~/images/transp.gif" /></td>
					<td style="text-align:left;"><asp:Label ID="Label2" runat="server" foreColor="black" Font-Bold="true" Font-Size="11px">Promociones especiales</asp:Label></td>
				</tr>
				</table>
			</div>
			<div style="background-color:#EBF7C1;">
				<div style="height:10px">  </div>
                    <uc2:DisplayAnunciosCategories ID="DisplayAnunciosCategories1" runat="server" />
                <div style="height:10px">  </div>
			</div>
		</td>
	</tr>
	</table>
</asp:Content>

