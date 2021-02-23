<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPagePagoUnico.master" AutoEventWireup="false" CodeFile="CheckoutCard.aspx.vb" Inherits="sec_CheckoutCard" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	<div style="height:20px"></div>

	<table width="100%" border="0" cellpadding="0" cellspacing="20" class="border-box2">
	<tr class="line">
		<td class="title1"><asp:Label ID="lblTitulo" runat="server" Text="Pago de cotización #"></asp:Label></td>
		<td align="right" valign="middle" class="txt-black-13" style="width: 30%">
			<strong>Fecha:</strong>
			<asp:Label ID="lblfecha" runat="server"></asp:Label>
		</td>
	</tr>
	<tr>
		<td colspan="2">
			<table width="100%" border="0" cellspacing="5" cellpadding="0">
			<tr>
				<td width="50%" height="37" valign="middle" class="titulo-cotizador" style="background-color:#D6F1BC;">
					<table width="90%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td class="txt-black1"><strong>Datos Personales</strong></td>
					</tr>
					</table>
				</td>
				<td width="50%" valign="middle" class="titulo-cotizador" style="background-color:#D6F1BC;">
					<table width="90%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td  class="txt-black1"><strong>Datos de Facturación</strong></td>
					</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td height="52" align="center">
					<table width="90%" border="0" cellpadding="0" cellspacing="5" class="txt-black1">
					<tr>
						<td class="txt-green1" style="font-weight:bold; text-align:left;"><strong>Nombre</strong></td>
						<td style="text-align:left;"><asp:Label ID="dgNombre" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					<tr>
						<td class="txt-green1" style="font-weight:bold; text-align:left;"><strong>Empresa</strong></td>
						<td style="text-align:left;"><asp:Label ID="dgEmpresa" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					<tr>
						<td class="txt-green1" style="font-weight:bold; text-align:left;"><strong>Email</strong></td>
						<td style="text-align:left;"><asp:Label ID="dgEmail" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					<tr>
						<td class="txt-green1" style="font-weight:bold; text-align:left;"><strong>Teléfono</strong></td>
						<td style="text-align:left;"><asp:Label ID="dgTelefono" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					<tr>
						<td class="txt-green1" style="font-weight: bold; text-align:left;"><strong>Dirección</strong></td>
						<td style="text-align:left;"><asp:label ID="dgDireccion" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					<tr>
						<td class="txt-green1" style="font-weight: bold; text-align:left;"><strong>Fecha evento</strong></td>
						<td style="text-align:left;"><asp:label ID="dgfechaevento" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					<tr>
						<td class="txt-green1" style="font-weight: bold; text-align:left;"><strong>Status</strong></td>
						<td style="text-align:left;"><asp:label ID="dgStatus" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					</table>
				</td>
				<td align="center" style="vertical-align:top">
					 <table width="90%" border="0" cellpadding="0" cellspacing="5" class="txt-black1">
					<tr>
						<td class="txt-green1" style="font-weight: bold; text-align:left;"><strong>Empresa</strong></td>
						<td style="text-align:left;"><asp:label ID="dfNombre" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					<tr>
						<td class="txt-green1"style="font-weight: bold; text-align:left;"><strong>RFC</strong></td>
						<td style="text-align:left;"><asp:label ID="dfRFC" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					<tr>
						<td class="txt-green1" style="font-weight: bold; text-align:left;"><strong>Teléfono</strong></td>
						<td style="text-align:left;"><asp:label ID="dfTelefono" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					<tr>
						<td class="txt-green1" style="font-weight: bold; text-align:left;"><strong>Dirección</strong></td>
						<td style="text-align:left;"><asp:label ID="dfDireccion" runat="server" Font-Bold="False" style="font-weight: bold"></asp:Label></td>
					</tr>
					</table>
				</td>
			</tr>
			</table>
		</td>
	</tr>
	<tr>
		 <td colspan="2">
			<table cellpadding="0" cellspacing="0" style=" width:100%; height:37px;background-color:#D6F1BC;">
			<tr>
				<td valign="middle" style=" width:80px; text-align:center; font-weight: bold;" class="txt-black1">Cantidad</td>
				<td valign="middle" class="txt-black1" style="font-weight: bold">Nombre</td>
				<td valign="middle" style=" width:70px; text-align:center; font-weight: bold;" class="txt-black1">Foto</td>
				<td valign="middle" style=" width:80px; font-weight: bold; text-align:center;" class="txt-black1">Clave</td>
				<td valign="middle" style=" width:90px;text-align: center; font-weight: bold;" class="txt-black1">Color</td>
				<td valign="middle" style=" width:120px;text-align:center; font-weight: bold;" class="txt-black1">Precio Unitario</td>
				<td valign="middle" style=" width:90px;text-align:center; font-weight: bold;" class="txt-black1">Total</td>
			</tr>
			</table>

			<asp:DataList ID="dtlOrdenDetalles" runat="server" Width="100%">
				<AlternatingItemStyle BackColor="White" />
				<ItemTemplate>
					<table cellpadding="0" cellspacing="0" style="width:100%;">
					<tr>
						<td style=" width:80px; text-align:center;" class="precios"><asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("cantidad")%>'></asp:Label></td>
						<td class="precios" valign="middle"><asp:HyperLink ID="lnknombreOD" runat="server" CssClass="link-purple" Text='<%# getnombre(cint(eval("idProducto"))) %>' NavigateUrl='<%# "~/Producto.aspx?idProducto=" & eval("idProducto") & "&idOrdenDetalle=" & eval("idOrdenDetalle") %>' /><asp:HyperLink ID="lnkAgregarServicio" runat="server" CssClass="link-purple" Visible="false" Font-Size="10px" Font-Bold="false" Text="+ agregar servicio" NavigateUrl='<%# "ProductoWizard.aspx?idOrden=" & eval("idOrden") & "&idOrdenDetalle=" & eval("idOrdenDetalle") & "&idProducto=" & eval("idProducto") %>' /></td>
						<td style=" width:70px; text-align:center;" class="precios">
							<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Producto.aspx?idProducto=" & eval("idProducto") & "&idOrdenDetalle=" & eval("idOrdenDetalle") %>' Target="_blank">
								<asp:Image ID="imgFotoOD" runat="server" Width="50px" ImageUrl='<%# getFoto(cint(eval("idProducto"))) %>' />
							</asp:HyperLink>
						</td>
						<td style=" width:80px; text-align:center;" class="precios"><asp:Label id="lblClaveOD" Font-Size="10px" runat="server" Text='<%# getclave(cint(eval("idProducto"))) %>'></asp:Label></td>
						<td style=" width:90px;text-align: left;" class="precios"><asp:Label id="lblColorOD" runat="server" Text='<%# GetColor(eval("color")) %>'></asp:Label></td>
						<td style="width:120px; text-align:right;" class="precios"><asp:Label id="lblCostoUnitarioOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Costounitario", "{0:c}") %>'></asp:Label></td>
						<td style="width:90px;text-align:right;" class="precios"><asp:Label id="lblCostoTotalOD" runat="server" Text='<%# format(eval("costoFinal") * eval("cantidad"), "c") %>'></asp:Label></td>
					</tr>
					</table>

					<!--Seccion de ProductoServiciosOrdenesDetalles-->
					<asp:DataList ID="dtlservicios" runat="server" Width="100%" DataSource='<%# getDetallesServicios(cint(eval("idOrdenDetalle"))) %>'>
						<ItemTemplate>
							<table cellpadding="0" cellspacing="0" style="width:100%;">
							<tr>
								<td style=" width:80px; text-align:center;" class="precios"><asp:label id="lblcantidadproductosS" runat="server" Text='<%# eval("cantidadProductos") %>'></asp:Label></td>
								<td class="txt-precios"><asp:label id="lblServicio" runat="server" CssClass="link-purple" Font-Underline="false" Text='<%# getServicio(cint(Eval("idServicio"))) %>'></asp:Label>&nbsp;</td>
								<td style=" width:240px;" class="precios">&nbsp;</td>
								<td style="width:180px; text-align:right;" class="precios"><asp:label id="lblCostoUnitarioS" CssClass="precios" runat="server" Text='<%# Eval("CostoComponenteBase", "{0:c}") %>'></asp:Label>&nbsp;</td>
								<td style="width:90px;text-align:right;" class="precios"><asp:label id="lblCostoTotalS" CssClass="precios" runat="server" Text='<%# format((eval("costoFinal") * eval("cantidadProductos") ) + eval("costoSetup"), "c") %>'></asp:Label>&nbsp;</td>
							</tr>
							</table>
						</ItemTemplate>
					</asp:DataList>
					<!--fin seccion de productoserviciosordenesdetalles-->
										
				</ItemTemplate>
			</asp:DataList>
		</td>
	</tr>
	<tr>
		<td width="70%" align="center" valign="middle" class="txt-black1" rowspan="2">
			<asp:DataList ID="dtlImagenes" runat="server" RepeatColumns="5">
				<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
				<ItemTemplate>
					<asp:HyperLink ID="lnkimagenorden" runat="server" NavigateUrl='<%# carpetafiles & eval("imagen") %>' Target="_blank">
						<asp:Image ID="Image14" ImageUrl='<%# carpetafiles & eval("imagen") %>' runat="server" Width="100px"/>
					</asp:HyperLink>
				</ItemTemplate>
			</asp:DataList>
		</td>
		 <td align="right" valign="top" style="width: 30%">
			 <table width="100%" border="0" cellspacing="0" cellpadding="5">
			<tr>
				<td class="precios" align="right">Subtotal productos y servicios:</td>
				<td class="precios" align="right"><asp:label id="lblSubtotal" runat="server"></asp:label></td>
			</tr>
			<tr>
				<td class="precios" align="right">Costo express:</td>
				<td class="precios" align="right"><asp:label id="lblCostoExpress" runat="server"></asp:label></td>
			</tr>
			<tr>
				<td class="precios" align="right">Costo envío:</td>
				<td class="precios" align="right"><asp:label id="lblCostoEnvio" runat="server"></asp:label></td>
			</tr>
			<tr>
				<td class="precios" align="right">Impuestos:</td>
				<td class="precios" align="right"><asp:label id="lblImpuesto" runat="server"></asp:label></td>
			</tr>
			<tr>
				<td class="precios" align="right"><strong>Total:</strong></td>
				<td class="precios" align="right"><strong> <asp:label id="lblTotal" runat="server"></asp:label></strong></td>
			</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td style="text-align:center; vertical-align:top; width: 30%;">
			<asp:Button ID="btnchkout" runat="server" Text="Pagar orden" SkinID="botongeneral" OnClientClick="enviar()" />
			<span id="spanPagada" runat="server" visible="false">
				<asp:Label ID="lblPagada" runat="server" Text="Su orden ya fue pagada" ForeColor="Red"></asp:Label><br />
				<asp:Label ID="lblTagAuthCode" runat="server" Text="Código de depósito con tarjeta:" CssClass="precios"></asp:Label>
				<asp:Label ID="lblAuthCode" runat="server" Font-Bold="true" CssClass="precios"></asp:Label><br />
				<asp:Label ID="lblTagFecha" runat="server" Text="Fecha:" CssClass="precios"></asp:Label>
				<asp:Label ID="lblFechaTransaccion" runat="server" Font-Bold="true" CssClass="precios"></asp:Label>
			</span>
		</td>
	</tr>
	</table>

	<div style="height:100px;"></div>
	<asp:Literal ID="Literal1" runat="server"></asp:Literal>

	<script type="text/javascript">
	</script>

</asp:Content>