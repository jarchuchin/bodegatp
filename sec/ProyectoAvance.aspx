<%@ Page Title="Avance de proyecto" Language="VB" MasterPageFile="~/MasterPage02.master" AutoEventWireup="false" CodeFile="ProyectoAvance.aspx.vb" Inherits="ProyectoAvance" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

            <header>
                <div class="logo"><a href="#"></a></div>
                <div class="datos">
                    <div class="carro"><asp:Label ID="lblcotizar" runat="server" Text="Label"></asp:Label></div>
                    <div class="usuario">
                        <span>USUARIO: <asp:Label ID="lblUsuario" runat="server"></asp:Label></span>
                        <span>FECHA: <asp:Label ID="lblfecha" runat="server"></asp:Label></span>
                    </div>
                </div>
            </header>
            <section>
                <div class="pasos">
					<asp:ListView ID="listViewOrdenDetalle" runat="server">
						<LayoutTemplate>
							<table class="paso02">
							<tr>
								<th style="width:80px;">Candidad</th>
								<th>Artículo</th>
								<th style="width:70px;">Foto</th>
								<th style="width:80px;">Clave</th>
								<th style="width:90px;">Color</th>
								<th style="width:120px;">Precio unitario</th>
								<th style="width:90px;">Total</th>
							</tr>
							<tr id="itemPlaceHolder" runat="server"></tr>
							</table>
						</LayoutTemplate>
						<ItemTemplate>
	                        <tr>
								<td>
									<table style="width:100%;">
									<tr>
										<td style="width:80px;">
											<asp:Label id="lblidordendetalle" runat="server" Text='<%# eval("idOrdenDetalle") %>' Visible="false"></asp:Label>
											<asp:TextBox id="txtCantidadOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>'></asp:TextBox>
										</td>
										<td>
											<asp:HyperLink ID="lnknombreOD" runat="server" Text='<%# getnombre(cint(eval("idProducto"))) %>' NavigateUrl='<%# "~/Producto.aspx?idProducto=" & eval("idProducto") & "&idOrdenDetalle=" & eval("idOrdenDetalle") %>' />
											<asp:HyperLink ID="lnkAgregarServicio" runat="server" Visible="false" Font-Size="10px" Text="+ agregar servicio" NavigateUrl='<%# "ProductoWizard.aspx?idOrden=" & eval("idOrden") & "&idOrdenDetalle=" & eval("idOrdenDetalle") & "&idProducto=" & eval("idProducto") %>' />
										</td>
										<td style="width:70px;">
											<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Producto.aspx?idProducto=" & eval("idProducto") & "&idOrdenDetalle=" & eval("idOrdenDetalle") %>'>
												<asp:Image ID="imgFotoOD" runat="server" Width="50px" ImageUrl='<%# getFoto(cint(eval("idProducto"))) %>' />
											</asp:HyperLink>
										</td>
										<td style="width:80px;"><asp:Label id="lblClaveOD" Font-Size="10px" runat="server" Text='<%# getclave(cint(eval("idProducto"))) %>'></asp:Label></td>
										<td style="width:90px;"><asp:Label id="lblColorOD" runat="server" Text='<%# GetColor(eval("color")) %>'></asp:Label></td>
										<td style="width:120px;"><asp:Label id="lblCostoUnitarioOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Costounitario", "{0:c}") %>'></asp:Label></td>
										<td style="width:90px;"><asp:Label id="lblCostoTotalOD" runat="server" Text='<%# format(eval("costoFinal") * eval("cantidad"), "c") %>'></asp:Label></td>
									</tr>
									</table>
									<asp:DataList ID="dtlservicios" runat="server" Width="100%" DataSource='<%# getDetallesServicios(cint(eval("idOrdenDetalle"))) %>'>
										<ItemTemplate>
											<table style="width:100%;">
											<tr>
												<td style="width:80px; text-align:center;" class="precios"><asp:Label id="lblcantidadproductosS" runat="server" Text='<%# eval("cantidadProductos") %>'></asp:Label></td>
												<td style="width:70px;" class="precios">&nbsp;</td>
												<td style=" width:80px;" class="precios"></td>
												<td class="txt-precios"><asp:Label id="lblServicio" runat="server" Text='<%# getServicio(cint(Eval("idServicio"))) %>' ></asp:Label></td>
												<td style="width:90px; text-align:left;" class="precios"></td>
												<td style="width:180px; text-align:right;" class="precios"><asp:Label id="lblCostoUnitarioS" runat="server" Text='<%# Eval("CostoComponenteBase", "{0:c}") %>' ></asp:Label></td>
												<td style="width:90px;text-align:right;" class="precios"><asp:Label id="lblCostoTotalS" runat="server" Text='<%# format((eval("costoFinal") * eval("cantidadProductos") ) + eval("costoSetup"), "c")  %>' ></asp:Label></td>
											</tr>
											</table>
										</ItemTemplate>
									</asp:DataList>
								</td>
					        </tr>
						</ItemTemplate>
					</asp:ListView>
                    <table>
					<tr>
						<td style="vertical-align:top;">
							<table>
							<tr>
								<td>
									<table style="width:100%;">
									<tr>
										<td style="width:50%;">
											<p style="font-weight:bold;">
												Datos personales
												<asp:HyperLink ID="lnkdgEditar" runat="server" ImageUrl="~/images/images02/btn_modificar.png" Font-Bold="true">Editar</asp:HyperLink>
											</p>
										</td>
										<td style="width:50%;">
											<p style="font-weight:bold;">
												Datos de facturación
												<asp:HyperLink ID="lnkdfEditar" runat="server" ImageUrl="~/images/images02/btn_modificar.png" Font-Bold="true" >Editar</asp:HyperLink>
											</p>
										</td>
									</tr>
									<tr>
										<td style="vertical-align:top">
											<table style="width:100%;">
											<tr>
												<td style="font-weight:bold;">Nombre</td>
												<td><asp:Label ID="dgNombre" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">Empresa</td>
												<td><asp:Label ID="dgEmpresa" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">Email</td>
												<td><asp:Label ID="dgEmail" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">Teléfono</td>
												<td><asp:Label ID="dgTelefono" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">Dirección</td>
												<td><asp:Label ID="dgDireccion" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">Fecha evento</td>
												<td><asp:Label ID="dgfechaevento" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">Status</td>
												<td><asp:Label ID="dgStatus" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">Vendedor</td>
												<td><asp:Label ID="dgAsignado" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											</table>
										</td>
										<td style="vertical-align:top">
											<table style="width:100%;">
											<tr>
												<td style="font-weight:bold;">Empresa</td>
												<td><asp:Label ID="dfNombre" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">RFC</td>
												<td><asp:Label ID="dfRFC" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">Teléfono</td>
												<td><asp:Label ID="dfTelefono" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											<tr>
												<td style="font-weight:bold;">Dirección</td>
												<td><asp:Label ID="dfDireccion" runat="server" style="font-weight:bold;"></asp:Label></td>
											</tr>
											</table>
										</td>
									</tr>
									</table>
								</td>
							</tr>
							</table>
						</td>
						<td style="vertical-align:top;">
                    <div class="total_cuenta">
                        <p class="subtotal">
                            <span class="etiqueta">Costo envío:</span>
                            <span class="monto"><asp:label id="lblcostoenvio" runat="server"></asp:label></span>
                        </p>
                        <p class="subtotal">
                            <span class="etiqueta">Costo express:</span>
                            <span class="monto"><asp:label id="lblcostoexpress" runat="server"></asp:label></span>
                        </p>
                        <p class="subtotal">
                            <span class="etiqueta">Subtotal:</span>
                            <span class="monto"><asp:label id="lblsubtotalgeneral" runat="server"></asp:label></span>
                        </p>
                        <p class="iva">
                            <span class="etiqueta">IVA:</span>
                            <span class="monto"><asp:label id="lblImpuesto" runat="server"></asp:label></span>
                        </p>
                        <p class="total">
                            <span class="etiqueta">Total:</span>
                            <span class="monto"><asp:label id="lblTotal" runat="server"></asp:label></span>
                        </p>
                    </div>
                    <div class="botones">
                        <div class="btn_salir">
							<asp:LinkButton ID="lnkBtnActualizar" runat="server" ToolTip="Calcular de nuevo">CALCULAR DE NUEVO</asp:LinkButton>
						</div>
                        <div class="btn_salir">
							<asp:HyperLink ID="lnkAgregarArticulos" runat="server" NavigateUrl="~/Default.aspx">AGREGAR ARTÍCULOS</asp:HyperLink>
						</div>
                        <div class="btn_salir">
							<asp:HyperLink ID="lnkAgregarImagen" runat="server">ADJUNTAR LOGO</asp:HyperLink>
						</div>
                    </div>
                    <div class="botones">
                        <div class="btn_siguiente">
							<asp:LinkButton ID="lnkBtnFinalizar" runat="server" ToolTip="Finalizar cotización">FINALIZAR COTIZACIÓN</asp:LinkButton>
						</div>
					</div>
						</td>
					</tr>
					<tr>
						<td colspan="2" style="text-align:center">
							<div style="margin-bottom:15px;">¿Algún comentario adicional?</div>
							<div style="margin-bottom:15px;"><asp:TextBox ID="txtObservaciones" runat="server" Height="92px" TextMode="MultiLine" Width="454px"></asp:TextBox></div>
						</td>
					</tr>
                    </table>

                </div>
            </section>
            <footer>
                <div class="copy">
                  ¿Necesita asistencia? llame al 01800 702 0505 de lunes a viernes de 9 a 6 pm.
                </div>
            </footer>
</asp:Content>