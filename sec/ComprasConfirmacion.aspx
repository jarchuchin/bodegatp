<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="ComprasConfirmacion.aspx.vb" Inherits="sec_ComprasConfirmacion" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
     <div class="text-center">
<h1 >Hemos recibido tu cotización</h1>
            </div>
    <div style="height:20px;"></div>
		<div class="pasos">
			
			<table class="paso01" style="border-bottom:none; font-size:17px">
			
			<tr>
				<td style="text-align:center;">
					<div style="margin-bottom:20px;" class="title1">
						<img src="../images/ico-ok.png" width="20" height="19" alt="ok" />
						Tu cotización ha sido recibida
                       
					</div>
                     <div class="usuario">
				            <asp:Label ID="lblUsuario" runat="server" Text="USUARIO: "></asp:Label>
				            <asp:Label ID="lblfecha" runat="server" Text="FECHA: "></asp:Label>
				            <asp:Label ID="lblNumOrden" runat="server" Text="COTIZACIÓN #"></asp:Label>
			         </div>
                    <div style="height:15px:"></div>
					<div style="margin-bottom:20px;">
                        <asp:Label ID="lblmensajesucursal" runat="server" Font-Bold="True" Font-Size="18px">Cotización recibida en sucursal:</asp:Label><asp:Label ID="lblSucursal" runat="server" Font-Bold="True" Font-Size="18px"></asp:Label>
                        <div style="height:20px;"></div>
						<asp:Label ID="lblVendedor" runat="server" Font-Bold="True"></asp:Label><br />
						<asp:Label ID="lblVendedorEmail" runat="server"></asp:Label><br />
						<asp:Label ID="lblVendedorExtension" runat="server"></asp:Label>
					</div>
					<div style="margin-bottom:40px;">
						<asp:Label ID="Label8" runat="server" Text="¡Tu cotización fue generada exitosamente!" Font-Bold="True"></asp:Label><br />
						<asp:Label ID="Label3" runat="server" Text="En breve recibirás una confirmación en tu email"></asp:Label><br />
						<asp:Label ID="Label2" runat="server" Text="y un asesor se comunicará contigo"></asp:Label><br />
						<asp:Label ID="Label9" runat="server" Text="¡Gracias por preferir Todopromocional!"></asp:Label>
					</div>

				</td>
			</tr>
			</table>
		</div>

      <div style="height:120px;"></div>

	
</asp:Content>