<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="ConfirmacionCard.aspx.vb" Inherits="sec_ConfirmacionCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	<div style="height:20px"></div>

	<table width="100%" border="0" cellpadding="0" cellspacing="20" class="border-box2">
	<tr class="line">
		<td class="title1"><asp:Label ID="lblcotizar" runat="server"></asp:Label></td>
		<td align="right" valign="middle" class="txt-black-13">
			<strong>Fecha:</strong>
			<asp:Label ID="lblfecha" runat="server"></asp:Label>
		</td>
	</tr>
	<tr>
		<td colspan="2" valign="middle" align="center">

			<asp:Panel ID="panelExito" runat="server" Visible="false">
				<div class="title1" style="margin-bottom:15px;">
					<span class="title2"><img src="../images/ico-ok.png" width="20" height="19" alt="ok" /></span>
					Tu orden ha quedado pagada<br />
				</div>

				<div style="margin-bottom:15px;">
					<asp:Label ID="lblVendedor" runat="server" Text="" Font-Bold="True"></asp:Label><br />
					<asp:Label ID="lblVendedorEmail" runat="server" Font-Bold="False"></asp:Label><br />
					<asp:Label ID="lblVendedorExtension" runat="server" Font-Bold="False"></asp:Label>
				</div>

				<div style="margin-bottom:30px;">
					<asp:Label ID="Label8" runat="server" Text="Se realizó con éxito un cargo a tu tarjeta" Font-Bold="True"></asp:Label>

					<div style="background-color:#f0f0f0;">
						Número de orden: <asp:Label ID="lblidOrden" runat="server"></asp:Label><br />
						Total: <asp:Label ID="lblTotal" runat="server"></asp:Label><br />
						Fecha: <asp:Label ID="lblFechaTransaccion" runat="server"></asp:Label>
					</div>

					<asp:Label ID="Label3" runat="server" Text="En breve recibirás una confirmación en tu email"></asp:Label><br />
					<asp:Label ID="Label2" runat="server" Text="y un asesor le dará seguimiento a tu orden."></asp:Label><br />
					<asp:HyperLink ID="lnkDetalles" runat="server" text="Ver detalles de la orden" NavigateUrl="~/sec/CheckoutCard.aspx?idOrden="></asp:HyperLink><br /><br /><br /><br />

					<asp:Label ID="Label9" runat="server" Text="¡Gracias por preferir Todopromocional!"></asp:Label>
				</div>

				<div style="margin-bottom:30px;">
					<asp:Label ID="Label10" runat="server" Text="Te invitamos a seguirnos en:" Font-Size="12px"></asp:Label><br />
					<asp:HyperLink ID="lnkFacebook" runat="server" text="Compartir en Facebook" CssClass="LigaProducto" Font-Size="11px" NavigateUrl="http://www.facebook.com/todopromocional" target="_blank" ImageUrl="~/images/images02/confirmacionFacebook.jpg" ></asp:HyperLink>&nbsp;&nbsp;
					<asp:HyperLink ID="lnktwitter" runat="server"  navigateurl="http://twitter.com/todopromocional" text="Compartir en Twitter" CssClass="LigaProducto" Font-Size="11px" target="_blank" ImageUrl="~/images/images02/confirmacionTwitter.jpg"></asp:HyperLink><br />
					<asp:Label ID="Label11" runat="server" Text="¡para que recibas nuestras promociones antes que nadie!" Font-Size="12px"></asp:Label>
				</div>

				<div style="margin-bottom:30px;">
					<table border="0" cellspacing="5" cellpadding="0">
					<tr>
						<td style="height: 21px"><a href="../default.aspx" class="button">OK</a></td>
					</tr>
					</table>
				</div>
			</asp:Panel>

			<asp:Panel ID="panelFailed" runat="server" Visible="false">
				<div class="title1" style="margin-bottom:30px;">No procedió el pago con tu tarjeta</div>

				<div style="margin-bottom:30px;">
					<asp:Label ID="lblMensajeBanco" runat="server" Font-Bold="True"></asp:Label><br /><br /><br />
					<asp:HyperLink ID="lnkReTry" runat="server" text="Intentarlo de nuevo" NavigateUrl="~/sec/CheckoutCard.aspx?idOrden="></asp:HyperLink><br /><br />

					O ponte en contacto con tu vendedor asignado:
					<asp:Label ID="lblVendedor2" runat="server" Text="" Font-Bold="True"></asp:Label><br />
					<asp:Label ID="lblVendedorEmail2" runat="server" Font-Bold="False"></asp:Label><br />
					<asp:Label ID="lblVendedorExtension2" runat="server" Font-Bold="False"></asp:Label>
				</div>

				<div style="margin-bottom:30px;">
					<asp:Label ID="Label14" runat="server" Text="Te invitamos a seguirnos en:" Font-Size="12px"></asp:Label><br />
					<asp:HyperLink ID="HyperLink2" runat="server" text="Compartir en Facebook" CssClass="LigaProducto" Font-Size="11px" NavigateUrl="http://www.facebook.com/todopromocional" target="_blank" ImageUrl="~/images/images02/confirmacionFacebook.jpg" ></asp:HyperLink>&nbsp;&nbsp;
					<asp:HyperLink ID="HyperLink3" runat="server"  navigateurl="http://twitter.com/todopromocional" text="Compartir en Twitter" CssClass="LigaProducto" Font-Size="11px" target="_blank" ImageUrl="~/images/images02/confirmacionTwitter.jpg"></asp:HyperLink><br />
					<asp:Label ID="Label15" runat="server" Text="¡para que recibas nuestras promociones antes que nadie!" Font-Size="12px"></asp:Label>
				</div>

				<div style="margin-bottom:30px;">
					<table border="0" cellspacing="5" cellpadding="0">
					<tr>
						<td style="height: 21px"><a href="../default.aspx" class="button">OK</a></td>
					</tr>
					</table>
				</div>
			</asp:Panel>

			
			<asp:HyperLink ID="HyperLink1" runat="server" navigateurl="~/Default.aspx" Font-Bold="True"  CssClass="link-purple" >www.todopromocional.com</asp:HyperLink>
		</td>
	</tr>
          
	</table>

	<div style="height:30px;"></div>
    
	<asp:Literal ID="litgoogle" runat="server"></asp:Literal>
	<asp:HiddenField ID="hiddenSendMail" runat="server" Value="0" />
</asp:Content>



