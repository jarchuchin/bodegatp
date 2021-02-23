<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="verCompras.aspx.vb" Inherits="sec_verCompras" %>
<%@ Register src="../controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>
<%@ Register src="../controles/MenuMisOpciones.ascx" tagname="MenuMisOpciones" tagprefix="uc6" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	
         <div class="col-md-2  hidden-sm hidden-xs menu">
	       		<uc6:MenuMisOpciones ID="MenuMisOpciones1" runat="server" />

    </div>

		<div class="col-md-10 main">
            <h2> Proyecto #&nbsp; <asp:Literal ID="litNumOrden" runat="server" /></h2>
           

            <div class="row">
                <div class="col-lg-12>">
                        <div id="statusOrden" style="text-align:center; width:634px;width: 75%; margin: 0 auto; ">


                        <table style="width:634px;">
                            <tr>
                                <td><img alt="" src="../images/process1.jpg"  /></td>
                                <td><img alt="" src="../images/process2.jpg"  /></td>
                                <td><img alt="" src="../images/process3.jpg"  /></td>
                                <td><img alt="" src="../images/process4.jpg"  /></td>
                                <td><img alt="" src="../images/process5.jpg"  /></td>
                            </tr>
                            <tr>
                                <td><asp:Image ID="imgProcess1" runat="server" ImageUrl="~/images/ico-ok.png" /></td>
                                <td><asp:Image ID="imgProcess2" runat="server" ImageUrl="~/images/ico-ok.png" /></td>
                                <td><asp:Image ID="imgProcess3" runat="server" ImageUrl="~/images/ico-ok.png" /></td>
                                <td><asp:Image ID="imgProcess4" runat="server" ImageUrl="~/images/ico-bad.png" /></td>
                                <td><asp:Image ID="imgProcess5" runat="server" ImageUrl="~/images/ico-bad.png" /></td>
                            </tr>
                            <tr>
                                <td style="height:50px;">Inicia proceso</td>
                                <td>Aprovisionamiento</td>
                                <td>Taller y produccción</td>
                                <td>Preparacíon</td>
                                <td>Enviado</td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblprocess1" runat="server" Font-Bold="True"></asp:Label></td>
                                <td><asp:Label ID="lblprocess2" runat="server" Font-Bold="True"></asp:Label></td>
                                <td><asp:Label ID="lblprocess3" runat="server" Font-Bold="True"></asp:Label></td>
                                <td><asp:Label ID="lblprocess4" runat="server" Font-Bold="True"></asp:Label></td>
                                <td><asp:Label ID="lblprocess5" runat="server" Font-Bold="True"></asp:Label></td>
                            </tr>
                        </table>

                        </div>
                </div>
          </div>
        
    

    <div style="height:40px;"></div> 


    <div class="row">
                <div class="col-lg-6">
                    <strong>DATOS GENERALES</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>
                     <table style="width: 100%">
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Contacto</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgNombre" runat="server"></asp:Label>
							</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Empresa</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgEmpresa" runat="server"></asp:Label>
							</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Email</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgEmail" runat="server"></asp:Label>
							</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Teléfono</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgTelefono" runat="server"></asp:Label>
							</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Dirección</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgDireccion" runat="server"></asp:Label>
							</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Fecha evento</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgfechaevento" runat="server"></asp:Label>
							</td>
                        </tr>
                      <%--  <tr>
                            <td style="text-align: left; width: 111px"><b>Status</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgStatus" runat="server"></asp:Label>
							</td>
                        </tr>--%>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Vendedor</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgAsignado" runat="server"></asp:Label>
							</td>
                        </tr>
                    </table>
                </div>
                <div class="col-lg-6">
                      <strong>DATOS DE FACTURACIÓN</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>

                     <table style="width: 100%">
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Nombre/Empresa</b></td>
                            <td style="text-align: left"><asp:Label ID="dfNombre" runat="server"></asp:Label> </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>RFC</b></td>
                            <td style="text-align: left">
							<asp:Label ID="dfRFC" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Teléfono</b></td>
                            <td style="text-align: left">
							<asp:Label ID="dfTelefono" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Dirección</b></td>
                            <td style="text-align: left">
							<asp:Label ID="dfDireccion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Incluir en factura</b></td>
                            <td style="text-align: left">
							<asp:Label ID="dfincluir" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 111px"><b>Facturas</b></td>
                            <td style="text-align: left">
                               
                            </td>
                        </tr>
                         <tr>
                             <td colspan="2" style="width:100%;">
                                <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="false" Font-Size="10px" CssClass="table table-hover" width="100%" GridLines="None">
                                    <Columns>
                                         <asp:TemplateField HeaderText="Fecha" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" id="lblFecha" Text='<%# Format(eval("Fecha"), "dd/MMM/yyyy") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Folio" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" id="Label2" Text='<%# Eval("Serie")%>'></asp:Label><asp:Label runat="server" id="lblFolio" Text='<%# eval("Folio") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                <%--        <asp:TemplateField HeaderText="RFC" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" id="lblRFC" Text='<%# eval("RFC") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Subtotal" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" id="lblSubtotal" Text='<%# Format(Eval("Subtotal"), "c")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IVA" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" id="lblIVA" Text='<%# Format(Eval("totalImpuestosTrasladados"), "c")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" id="lblTotal" Text='<%# Format(Eval("Total"), "c")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Archivos" >
                                            <ItemTemplate>
                                                <asp:hyperlink runat="server" id="lnkpdf" navigateurl='<%# getNombreArchivo(Eval("nameFile"), "pdf")%>' Text="PDF" Target="_blank" Visible='<%# esVisible(Eval("nameFile")) %>'></asp:hyperlink>
                                                <asp:hyperlink runat="server" id="lnkxml" navigateurl='<%# getNombreArchivo(Eval("nameFile"), "xml")%>' Text="XML" Target="_blank" Visible='<%# esVisible(Eval("nameFile")) %>'></asp:hyperlink>
                                                <asp:Label runat="server" id="lblmensaje"  Text="No disponible"  Visible='<%# Not esVisible(Eval("nameFile"))%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                             </td>
                         </tr>
                        </table>
                    <div style="height:10px"></div>
                    <div class="form-inline">
                    <asp:Button ID="btnEditarDatosF" runat="server" Text="Editar datos de facturación" CssClass="btn  btn-warning btn-sm" />
                    &nbsp;<asp:Button ID="btnSolicitarFactura" runat="server" Text="Solicitar factura" CssClass="btn btn-success btn-sm" />
                        </div>
                </div>

    </div>

            
			
    <div style="height:40px;"></div>  




        <asp:Repeater ID="rptViewOrden" runat="server">
            <HeaderTemplate>
                    <table class="table table-hover">
                        <tr>
							<th style="width:40px; vertical-align:middle;  font-weight:bold;">Cant</th>
                            <th style="width:100px; vertical-align:middle; font-weight:bold;">Foto</th>
							<th style=" vertical-align:middle; font-weight:bold;">Artículo</th>
							
							<th style="width:90px; vertical-align:middle; font-weight:bold;">Domi</th>
							<th style="width:90px; vertical-align:middle; font-weight:bold;">Clave</th>
							<th style="width:110px; vertical-align:middle; font-weight:bold;">Color</th>
							<th style="width:120px; vertical-align:middle; font-weight:bold;">Precio unitario</th>
							<th style="width:90px; vertical-align:middle; font-weight:bold;">Total</th>
						</tr>
            </HeaderTemplate>
            <ItemTemplate>
                    	<tr>
									<td style="width:40px; text-align:center;">
										<asp:Label id="lblCantidad" runat="server" Text='<%# Eval("Cantidad")%>'></asp:Label>
										<asp:HiddenField ID="hiddenIdOrdenDetalle" runat="server" Value='<%# eval("idOrdenDetalle") %>' />
									</td>
                                    <td style="width:100px; text-align:center;">

										<asp:HyperLink ID="lnkProductoI" runat="server" ClientIDMode="Predictable" CssClass="lnk_producto">
											<asp:Image ID="imgFotoOD" runat="server" Width="50px" ImageUrl='<%# getFoto(CInt(eval("idProducto"))) %>' />
										</asp:HyperLink>
									</td>
									<td style="text-align:left;">
										<asp:HyperLink ID="lnkProducto" runat="server" ClientIDMode="Predictable"  Text='<%# getnombre(CInt(eval("idProducto"))) %>' />
										

									</td>
									<td style="width:90px; text-align:center;">
                                        <asp:HyperLink ID="lnkAutorizar" runat="server"  Text="Autorizar domi" CssClass="btn btn-info  btn-sm" NavigateUrl='<%# "AutorizarDomi.aspx?idOrden=" & Eval("idOrden") & "&idOrdenDetalle=" & Eval("idOrdenDetalle") %>' Visible='<%# mostrarBotonAutorizar(Eval("Autorizado")) %>'/>

                                        <asp:Image ID="imgAutorizado" runat="server" ImageUrl="~/images/t-mini_icon_ok.png" Visible='<%# mostrarLigasEimagenesAutorizar(Eval("Autorizado")) %>' /><br />
                                         <asp:HyperLink ID="lnkAutorizado" runat="server"  CssClass="btn-link" NavigateUrl='<%# "AutorizarDomi.aspx?idOrden=" & Eval("idOrden") & "&idOrdenDetalle=" & Eval("idOrdenDetalle") %>' text="Autorizado"  Visible='<%# mostrarLigasEimagenesAutorizar(Eval("Autorizado")) %>'/>
									</td>
									<td style="width:90px;"><asp:Label id="lblClaveOD" Font-Size="10px"  runat="server" Text='<%# getClave(CInt(Eval("idProducto"))) %>'></asp:Label></td>
									<td style="width:110px;"><asp:Label id="lblColorOD" runat="server" Text='<%# GetColor(Eval("color")) %>'></asp:Label></td>
									<td style="width:120px;text-align:right;"><asp:Label id="lblCostoUnitarioOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CostoFinal", "{0:c}") %>'></asp:Label></td>
									<td style="width:90px;text-align:right;"><asp:Label id="lblCostoTotalOD" runat="server" Text='<%#Format(Eval("costoFinal") * Eval("cantidad"), "c") %>'></asp:Label></td>
								</tr>
							
								
										<asp:ListView ID="listViewServicios" runat="server" DataSource='<%# getDetallesServicios(CInt(Eval("idOrdenDetalle"))) %>'>
											
											<ItemTemplate>
												<tr>
													<td style="width:40px; text-align:center;"><asp:Label id="lblcantidadproductosS" runat="server" Text='<%#Eval("cantidadProductos") %>'></asp:Label></td>
                                                    <td style="width:100px;"></td>
													<td style=" text-align:left;"><asp:Label id="lblServicio" runat="server" Text='<%# getServicio(CInt(Eval("idServicio"))) %>'></asp:Label></td>
													<td style="width:90px;"></td>
													<td style="width:110px;"></td>
													<td	style="width:120px; text-align:right;"><asp:Label id="lblCostoUnitarioS" runat="server" Text='<%# Eval("CostoFinal", "{0:c}") %>'></asp:Label></td>
													<td style="width:90px;text-align:right;"><asp:Label id="lblCostoTotalS" runat="server" Text='<%#Format((Eval("costoFinal") * Eval("cantidadProductos")) + Eval("costoSetup"), "c")  %>'></asp:Label></td>
												</tr>
											</ItemTemplate>
										</asp:ListView>
								

            </ItemTemplate>
            <FooterTemplate>
                  </table>
            </FooterTemplate>
        </asp:Repeater>
    			
         
      

              <div class="row">
                <div class="col-lg-6">
                 <%--   <strong>DATOS GENERALES</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>--%>
                </div>
                <div class="col-lg-6">
                    <strong>RESUMEN</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>
                    <table style="width:100%">
                        <tr>
                            <td style="width:50%"><b>Costo de envío:</b></td>
                            <td style="width:50%; text-align:right; padding-right:20px;"><asp:label id="lblcostoenvio" runat="server"></asp:label></td>
                        </tr>
                         <tr>
                            <td style="width:50%"><b>Costo express:</b></td>
                            <td style="width:50%; text-align:right; padding-right:20px;"><asp:label id="lblcostoexpress" runat="server"></asp:label></td>
                        </tr>
                         <tr>
                            <td style="width:50%"><b>Subtotal:</b></td>
                            <td style="width:50%; text-align:right; padding-right:20px;"><asp:label id="lblsubtotalgeneral" runat="server"></asp:label></td>
                        </tr>
                         <tr>
                            <td style="width:50%"><b>IVA:</b></td>
                            <td style="width:50%; text-align:right; padding-right:20px;"><asp:label id="lblImpuesto" runat="server"></asp:label></td>
                        </tr>
                         <tr>
                            <td style="width:50%"><b>Total</b></td>
                            <td style="width:50%; text-align:right; padding-right:20px;"><asp:label id="lblTotal" runat="server" Font-Bold="true"></asp:label></td>
                        </tr>

                    </table>
                  

                </div>
            </div>
			
            <div style="height:40px;"></div>      

    
            <div class="row">
                        <div class="col-lg-6">
                             <strong>COTIZACIÓNES CREADAS</strong><br />
                            <div style="height:10px;">&nbsp;</div>
                            <div  style="height:1px; background-color:#dcdcdc">   </div>
                            <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                            <div style="height:10px;">&nbsp;</div>
                    	        <asp:GridView ID="gvCotizaciones" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False" Width="100%" >
							        <Columns>
								        <asp:TemplateField>
									        <ItemTemplate>
										        <asp:HyperLink ID="lblvercotizacion" runat="server"  navigateurl='<%# "~/siteadmin/files/cotizaciones/" & eval("nombreFile") %>' Target="_blank" Text='<%# eval("nombreFile") %>' ToolTip="ver cotizacion" Font-Size="11px"></asp:HyperLink>
									        </ItemTemplate>
								        </asp:TemplateField>
								        <asp:TemplateField>
									        <ItemTemplate>
    									        <asp:Label ID="Label1" runat="server" Text='<%# Bind("fecha") %>' Font-Size="11px"></asp:Label>
									        </ItemTemplate>
								        </asp:TemplateField>
							        </Columns>
						        </asp:GridView>
                        </div>
                        <div class="col-lg-6">
                            <strong>PAGOS REALIZADOS</strong><br />
                            <div style="height:10px;">&nbsp;</div>
                            <div  style="height:1px; background-color:#dcdcdc">   </div>
                            <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                            <div style="height:10px;">&nbsp;</div>
                             <asp:Button ID="btnSubirPago" runat="server" Text="Subir comprobante de pago" CssClass="btn  btn-primary btn-sm" />

                            <div style="height:10px;">&nbsp;</div>
                             	<asp:GridView ID="gvDepositosVentas" runat="server"  CssClass="table table-striped"   AutoGenerateColumns="False" GridLines="None" ShowHeader="False" Width="100%" >
							<Columns>
								<asp:TemplateField ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
									<ItemTemplate>
										<asp:HyperLink ID="lnkEditarPago" runat="server"  navigateurl='<%# "SubirComprobante.aspx?idOrden=" & Eval("idOrden") & "&idDepositoVenta=" & Eval("idDepositoVenta") %>' Text='<%#Format(Eval("fecha"), "d") %>' ToolTip="Editar datos" Font-Size="11px"></asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
								
                                <asp:TemplateField ItemStyle-Font-Size="11px" >
									<ItemTemplate>
    									<asp:Label ID="Label1" runat="server" Text='<%# Eval("Cliente") %>' Font-Size="11px"></asp:Label><br />
                                        Ref. <asp:Label ID="Label3" runat="server" Text='<%# Eval("Referencia") %>' Font-Bold="true" Font-Size="11px"></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
                                  <asp:TemplateField ItemStyle-Width="100px">
									<ItemTemplate>
    									<asp:Label ID="Label1" Font-Italic="true" runat="server" Text='<%#Eval("Estatus") %>' Font-Size="11px"></asp:Label>
									</ItemTemplate>

								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px">
									<ItemTemplate>
    									<asp:Label ID="Label1" Font-Bold="true" runat="server" Text='<%# Format(Eval("Monto"), "c") %>' Font-Size="11px"></asp:Label>
									</ItemTemplate>

								</asp:TemplateField>
							</Columns>
						</asp:GridView>



                            	<asp:GridView ID="gvDepositos" runat="server"  CssClass="table table-striped"   AutoGenerateColumns="False" GridLines="None" ShowHeader="False" Width="100%" >
							<Columns>
								<asp:TemplateField ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
									<ItemTemplate>
										<asp:label ID="lnkEditarPago" runat="server"   Text='<%#Format(Eval("fecha"), "d") %>'  Font-Size="11px"></asp:label>
									</ItemTemplate>
								</asp:TemplateField>
								
                                <asp:TemplateField ItemStyle-Font-Size="11px" >
									<ItemTemplate>
    									<asp:Label ID="Label1" runat="server" Text='<%# Eval("Cliente") %>' Font-Size="11px"></asp:Label><br />
                                        Ref. <asp:Label ID="Label3" runat="server" Text='<%# Eval("Referencia") %>' Font-Bold="true" Font-Size="11px"></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
                                  <asp:TemplateField ItemStyle-Width="100px">
									<ItemTemplate>
    									<asp:Label ID="Label1" Font-Italic="true" runat="server" Text='<%#Eval("Estatus") %>' Font-Size="11px"></asp:Label>
									</ItemTemplate>

								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px">
									<ItemTemplate>
    									<asp:Label ID="Label1" Font-Bold="true" runat="server" Text='<%# Format(Eval("Monto"), "c") %>' Font-Size="11px"></asp:Label>
									</ItemTemplate>

								</asp:TemplateField>
							</Columns>
						</asp:GridView>


                        </div>
            </div>

          
				

             <div style="height:40px;"></div>  
    

       </div>


 


</asp:Content>

