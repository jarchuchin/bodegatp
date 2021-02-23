<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageWide.master" AutoEventWireup="false" CodeFile="ProductoWizard.aspx.vb" Inherits="ProductoWizard" %>

<%@ Register Assembly="Utilities" Namespace="Utilities" TagPrefix="cc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
 


<table cellpadding="0" cellspacing="0" border="0" style="width:100%;">
	<tr>
	
		<td style="vertical-align:top; "><asp:Image ID="imgProducto" runat="server" Width="405px" /></td>
		<td style="vertical-align:top; width:10px"><asp:Image ID="imgdiv1" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
		<td style="vertical-align:top; width:568px;">
			<table cellpadding="0" cellspacing="0" border="0"  style=" width:565px; height:30px; background-color:#0C8ECC; text-align:left;">
			<tr>
				<td style="width:10px; text-align:center;" ></td>
				<td><asp:Label ID="lblCotizar" runat="server"  ForeColor="White" Font-Bold="True" Font-Size="19px">Seleccionar servicio</asp:Label></td>
			</tr>
			</table>

			<table cellpadding="0" cellspacing="0" border="0" style="width:565px;">
			<tr>
				<td style="vertical-align:top; background-color:#EBF7C1; width: 565px; text-align:left;">

					<div style=" height :10px"></div>

					<table cellpadding="0" cellspacing="0" border="0" style="width:565px; ">
					<tr>
						<td style="width:20px"><asp:Image ID="Image4" runat="server" width="20px" imageUrl="~/images/transp.gif" /></td>
						<td> 
							<table style="width: 100%">
							<tr>
								<td style="width: 125px"><asp:Label ID="Label35" runat="server" Font-Bold="True" Text="Nombre:" Font-Italic="False"></asp:Label></td>
								<td><asp:Label ID="lblNombreProducto" runat="server"  ForeColor="black" Font-Bold="true" Font-Size="11px"></asp:Label></td>
							</tr>
							<tr>
								<td><asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Clave:" Font-Italic="False"></asp:Label></td>
								<td><asp:Label ID="lblClave" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td><asp:Label ID="Label36" runat="server" Font-Bold="True" Text="Color:" Font-Italic="False"></asp:Label></td>
								<td><asp:Label ID="lblColor" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td><asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Cantidad" Font-Italic="False"></asp:Label></td>
								<td><asp:Label ID="lblCantidad" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td><asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Precio unitario" Font-Italic="False"></asp:Label></td>
								<td><asp:Label ID="lblCostoUnitario" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td><asp:Label ID="Label37" runat="server" Font-Bold="True" Text="Servicio seleccionado" 
                                        Font-Italic="False"></asp:Label></td>
								<td><asp:Label ID="lblServicio" runat="server"></asp:Label></td>
							</tr>
							</table>
						</td>
					</tr>
					</table>

					<div style=" height :10px"></div>

				

					<asp:GridView ID="gridServicios" runat="server" AutoGenerateColumns="false" DataKeyNames="idServicio" Width="100%" GridLines="None" ShowHeader="False">
						<RowStyle BackColor="White" />
						<AlternatingRowStyle BackColor="#EBF7C1" />
						<Columns>
							<asp:TemplateField>
								<ItemTemplate><asp:Image ID="Image4" runat="server" width="15px" imageUrl="~/images/transp.gif" /></ItemTemplate>
								<ItemStyle Width="15" />
							</asp:TemplateField>
							<asp:TemplateField>
								<ItemTemplate >
									<cc3:GridViewRowSelector ID="GridViewRowSelector1" runat="server" />
								</ItemTemplate>
								<ItemStyle Width="20px" VerticalAlign="Top" />
							</asp:TemplateField>
							<asp:TemplateField>
								<ItemTemplate>
									<table cellpadding="0" cellspacing="0" border="0">
									<tr>
										<td rowspan="4" valign="top" style="width:100px;"><asp:Label ID="lblAcabado" runat="server" Font-Bold="True" Font-Size="11px" Text='<%# eval("Nombre") %>'></asp:Label></td>
										<td style="font-weight:bold; width:110px;"><asp:DropDownList ID="dropCantidadComponente" runat="server"></asp:DropDownList></td>
										<td>
											<asp:Label ID="lblComponenteBase" Font-Size="11px" runat="server" Font-Bold="true" Text='<%# eval("componenteBase") %>'></asp:Label>&nbsp;
											<asp:HiddenField ID="hiddenUnidadComponente" runat="server" Value='<%# Eval("unidadComponenteBase") %>' />
										</td>
									</tr>
									<tr>
										<td style="font-weight:bold;">Precio unitario</td>
										<td><asp:Label ID="Label6" runat="server" Text='<%# eval("precioComponenteBase", "{0:c}") %>'></asp:Label></td>
									</tr>
									<tr>
										<td style="font-weight:bold;">Cantidad mínima</td>
										<td><asp:Label ID="Label10" runat="server" Text='<%# eval("CantidadMinima") %>' ></asp:Label></td>
									</tr>
									<tr>
										<td style="font-weight:bold;">Costo setup</td>
										<td><asp:Label ID="Label12" runat="server" Text='<%# eval("costoSetup", "{0:c}") %>' ></asp:Label></td>
									</tr>
									</table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

				

                    <div style=" height :10px"></div>
					<table cellpadding="0" cellspacing="0" border="0" style="width:565px; ">
					<tr>
						<td style="width:20px"><asp:Image ID="Image1" runat="server" width="20px" imageUrl="~/images/transp.gif" /></td>
						<td><asp:Button ID="btnGrabar" runat="server" Text="Agregar servicio >>>" SkinID="botongeneral" /></td>
					</tr>
					</table>
					<div style=" height :10px"></div>
				</td>
			</tr>
			</table>

		</td>
		
	</tr>
	</table>
    
</asp:Content>

