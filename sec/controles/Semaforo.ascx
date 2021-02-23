<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Semaforo.ascx.vb" Inherits="sec_reportes_controles_Semaforo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Panel ID="panelCompleto1" runat="server" >
  <table cellpadding="0" cellspacing="0" border="0"  style=" width:100%; height:30px;   text-align:left;">
                        <tr>
                            <td >
                            <asp:Label ID="lblCotizar" runat="server"  ForeColor="Black" Font-Bold="True"  Font-Size="17px">Proyecto  # </asp:Label>
                           </td>
                        </tr>
                    </table>
     
                                <div id="puntosTitulo"></div>
                     <div style="height:15px"></div>
</asp:Panel>



               
<table style="border: 1px solid #808080;  width:100%"  cellspacing="0" cellpadding="0">
    <tr style="height:30px; ">
        <td style="width:95px; font-size:10px; text-align:center;"><asp:Literal ID="litCotizacion" runat="server"></asp:Literal></td>
        <td style="width:95px; font-size:10px; text-align:center;"><asp:Literal ID="litProyecto" runat="server"></asp:Literal></td>
        <td style="width:95px; font-size:10px; text-align:center;"><asp:Literal ID="litAnticipo" runat="server"></asp:Literal></td>
        <td style="width:95px; font-size:10px; text-align:center;"><asp:Literal ID="litCompras" runat="server"></asp:Literal></td>
        <td style="width:95px; font-size:10px; text-align:center;"><asp:Literal ID="litAlmacen" runat="server"></asp:Literal></td>
        <td style="width:95px; font-size:10px; text-align:center;"><asp:Literal ID="litTaller" runat="server"></asp:Literal></td>
        <td style="width:95px; font-size:10px; text-align:center;"><asp:Literal ID="litDepositos" runat="server"></asp:Literal></td>
        <td style="width:95px; font-size:10px; text-align:center;"><asp:Literal ID="LitFacturacion" 
                runat="server"></asp:Literal></td>
        <td style="width:95px; font-size:10px; text-align:center;"><asp:Literal ID="litEnviado" 
                runat="server"></asp:Literal></td>
        <td style="width:95px; font-size:10px; text-align:center;">
             <asp:Label ID="lblporcentaje" runat="server" Font-Bold="True" Font-Size="15px"></asp:Label></td>
                <td></td>
    </tr>
     <tr style="height:30px;">
        <td style="width:95px; font-size:10px; text-align:center;">
            <asp:Label ID="Label1" runat="server" 
                Text="Cotización" Font-Bold="True"></asp:Label></td>
        <td style="width:95px; font-size:10px; text-align:center;">
            <asp:Label ID="Label5" runat="server" 
                Text="Proyecto" Font-Bold="True"></asp:Label></td>
        <td style="width:95px; font-size:10px; text-align:center;">
             <asp:Label ID="Label12" runat="server" 
                Text="Anticipo" Font-Bold="True"></asp:Label></td>
        <td style="width:95px; font-size:10px; text-align:center;">
            <asp:Label ID="Label6" runat="server" 
                Text="Compra" Font-Bold="True"></asp:Label></td>
        <td style="width:95px; font-size:10px; text-align:center;">
            <asp:Label ID="Label7" runat="server" 
                Text="Almacen" Font-Bold="True"></asp:Label></td>
        <td style="width:95px; font-size:10px; text-align:center;">
            <asp:Label ID="Label8" runat="server" 
                Text="Taller" Font-Bold="True"></asp:Label></td>
         <td style="width:95px; font-size:10px; text-align:center;">
             <asp:Label ID="Label9" runat="server" 
                Text="Depositos" Font-Bold="True"></asp:Label></td>
         <td style="width:95px; font-size:10px; text-align:center;">
             <asp:Label ID="Label10" runat="server" 
                Text="Facturación" Font-Bold="True"></asp:Label></td>
         <td style="width:95px; font-size:10px; text-align:center;">
             <asp:Label ID="Label11" runat="server" 
                Text="Enviado" Font-Bold="True"></asp:Label></td>
         <td style="width:95px; font-size:10px; text-align:center;">
             &nbsp;</td>
        <td></td>
    </tr>
</table>


<asp:Panel ID="panelCompleto2" runat="server" >

      <div style="height:20px"></div>
    
                
                  
                    
                    <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                            <tr>
                                <td style="text-align: left; vertical-align:top;  width:475px;">
                               
                                        

                                        
                    
                                          <table cellpadding="0" cellspacing="0" border="0" style=" width:475px; ">
                                            <tr>
                                                <td style="width:1px ;"> <asp:Image ID="Image6" runat="server"  Width="1px"  
                                                        ImageUrl="~/images/transp.gif" Height="20px" /></td>
                                                <td style="text-align: left;"> 
                                                    <asp:Label ID="Label2" runat="server"   Font-Bold="True"  Font-Size="11px">DATOS FACTURACIÓN</asp:Label>
                                                </td>
                                            </tr>
                                          </table>
                                     
                                     
                                     <div style=" height :10px"></div>
                                    
                                     <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                        <tr>
                                            <td style="width:20px"> <asp:Image ID="Image8" runat="server"  Width="20px"  ImageUrl="~/images/transp.gif" /></td>
                                            <td style="text-align: left; ">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 100px">
                                                            Nombre/Empresa:</td>
                                                        <td>
                                                           <table cellpadding="0" cellspacing="0" border="0" style="width:100%">
                                                                <tr>
                                                                    <td><asp:Label ID="dfNombre" runat="server" Font-Bold="True"></asp:Label></td>
                                                                    <td style="text-align:right; width:40px;"> &nbsp;&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            RFC</td>
                                                        <td>
                                                            <asp:Label ID="dfRFC" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            Dirección:</td>
                                                        <td>
                                                            <asp:Label ID="dfDireccion" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            Teléfono:</td>
                                                        <td>
                                                            <asp:Label ID="dfTelefono" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    </table>
                                            </td>
                                        </tr>
                                        </table>
                                        
                                      <div style=" height :10px"></div>






                                     <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                            <tr>
                                                <td style="width:1px"> <asp:Image ID="Image1" runat="server"  Width="1px"  Height="20px" ImageUrl="~/images/transp.gif" /></td>
                                                <td style="text-align: left;"> 
                                                    <asp:Label ID="Label3" runat="server"   Font-Bold="True"  Font-Size="11px">DATOS DEL PROYECTO</asp:Label>
                                                </td>
                                            </tr>
                                          </table>


                                       <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                        <tr>
                                            <td style="width:20px"> <asp:Image ID="Image2" runat="server"  Width="20px"  ImageUrl="~/images/transp.gif" /></td>
                                            <td style="text-align: left;"  >
                                                 <table style=" width:100%;">
                                                <tr>
                                                        <td style="width: 100px">
                                                            Estatus:</td>
                                                        <td>
                                                            <asp:Label ID="dgStatus" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            Vendedor:</td>
                                                        <td>
                                                            
                                                            <asp:Label ID="dgasignado" runat="server" Font-Bold="True"></asp:Label>
                                                            
                                                        &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            Forma de pago:</td>
                                                        <td>
                                                            
                                                            <asp:Label ID="lblformadepago" runat="server" Font-Bold="True"></asp:Label>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            Fecha compromiso:</td>
                                                        <td>
                                                            
                                                            <asp:Label ID="lblfechacompromiso" runat="server" Font-Bold="True" 
                                                                ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            &nbsp;</td>
                                                        <td>
                                                            
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        </table>

                                </td>
                                <td style="width:10px"> <asp:Image ID="Image4" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left; vertical-align:top; width:475px">
                                
                                
                                            <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                            <tr>
                                                <td style="width:1px"> <asp:Image ID="Image7" runat="server"  Width="1px"  Height="20px" ImageUrl="~/images/transp.gif" /></td>
                                                <td style="text-align: left;"> 
                                                    <asp:Label ID="Label4" runat="server"   Font-Bold="True"  Font-Size="11px">RESUMEN GENERAL</asp:Label>
                                                </td>
                                            </tr>
                                          </table>




                                           <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                            <tr>
                                                <td style="width:20px"> <asp:Image ID="Image9" runat="server"  Width="20px"  ImageUrl="~/images/transp.gif" /></td>
                                                <td style="text-align: left; ">
                                                        <table style="width: 200px">
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    Total de proyecto</td>
                                                                <td style=" text-align:right">
                                                                    <asp:Label ID="lbltotalproyecto" runat="server" Font-Bold="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    Total depositos</td>
                                                                <td style=" text-align:right">
                                                                    <asp:Label ID="lbldepositos" runat="server" Font-Bold="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px; height:10px">
                                                                    &nbsp;</td>
                                                                <td style="height:10px; text-align:right">
                                                                    ----------------------------</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    Saldo</td>
                                                                <td style=" text-align:right">
                                                                    <asp:Label ID="lblSaldo" runat="server" Font-Bold="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    Total facturado</td>
                                                                <td style=" text-align:right">
                                                                    <asp:Label ID="lblfacturado" runat="server" Font-Bold="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    Cargos extras</td>
                                                                <td style=" text-align:right">
                                                                    <asp:Label ID="lblcargosextras" runat="server" Font-Bold="True"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                            </table>






                                     </td>
                            </tr>
                       </table>
                    
                     <div style=" height :25px"></div>
                    
		            <table style="width:100%;   border="0" cellpadding="0" cellspacing="0" >
		                <tr>
		                    <td>
		                    <table cellpadding="2" cellspacing="0" style=" width:990px; background-color:Black; height:21px;"   >
		                        <tr>
		                           
		                           <td style=" width:40px; text-align:center; color:White; "><b>Cant.</b></td>
		                            <td style=" width:54px; text-align:center; color:White;"><b>Foto</b></td>
		                            <td style=" width:80px; color:White;"><b>Clave</b></td>
		                            <td style="color:White;"><b>Nombre</b></td>
		                            <td style=" width:100px;text-align: center;color:White;"><b>Color</b>&nbsp;</td>
		                            <td style=" width:90px;text-align:right ;color:White;"><b>Setup</b>&nbsp;</td>
		                            <td style=" width:90px;text-align:right ;color:White;"><b>P. Unitario</b>&nbsp;</td>
		                            <td style=" width:90px;text-align:right ;color:White;"><b>P. Desc.</b>&nbsp;</td>
		                            <td style=" width:110px;text-align:center ;color:White;"><b>Total</b>&nbsp;</td>
                                    <td style=" width:30px;text-align:center ;color:White;"><b>Listo</b>&nbsp;</td>
		                        </tr>    
		                    </table>
                                <asp:DataList ID="dtlOrdenDetalles" runat="server" Width="100%" 
                                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                    CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <AlternatingItemStyle BackColor="#CCCCCC" />
                                    <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" style="width:980px; ">
                                            <tr>
                                              
                                                <td style=" width:40px; text-align:center;">
                                                    <asp:Label id="lblidordendetalle" runat="server" Text='<%# eval("idOrdenDetalle") %>'  Visible="false" Width="40px"></asp:Label>
                                                    <asp:Label id="txtCantidadOD" Width="28px" runat="server" SkinID="textheader" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' ></asp:Label>
													
                                                </td>
                                                <td style=" width:54px;">
                                                    <asp:HyperLink ID="lnkImagenOD" runat="server" CssClass="LigaProducto" ToolTip="Actualizar costo y cantidad"  >
                                                    <asp:Image ID="imgFotoOD" runat="server" Width="50px" ImageUrl='<%# getFoto(cint(eval("idProducto"))) %>' />
                                                    </asp:HyperLink>
                                                    
                                                </td>
                                                <td style=" width:80px;">
                                                	<asp:Label id="lblClaveOD" runat="server" Text='<%# getclave(cint(eval("idProducto"))) %>' ></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:HyperLink ID="lnknombreOD" runat="server" CssClass="LigaProducto" Text='<%# getnombre(cint(eval("idProducto"))) %>'  ToolTip="Actualizar costo y cantidad"   />
                                                  
                                                </td>
                                                <td style=" width:90px;text-align: left;">
                                                    <asp:Label id="lblColorOD" runat="server" Text='<%# GetColor(eval("color")) %>' ></asp:Label>
                                                </td>
                                                <td style=" width:90px;text-align:right ;">&nbsp;</td>
                                                <td style="width:90px; text-align:right;">
                                                <asp:Label id="lblCostoUnitarioOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Costounitario", "{0:c}") %>'    SkinID="textheader" ></asp:Label>
                                                </td>
                                                <td style="width:90px; text-align:right;">
                                                <asp:Label id="lblCostoFinalOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CostoFinal", "{0:c}") %>'    SkinID="textheader" ></asp:Label>
                                                </td>
                                                <td style="width:110px;text-align:right;">
                                                    <asp:Label id="lblCostoTotalOD" runat="server"  Text='<%# DataBinder.Eval(Container, "DataItem.Total", "{0:c}") %>' ></asp:Label>&nbsp;
                                                </td>
                                                <td style="width:30px;text-align:right;">
                                                   <asp:Image ID="imgDatos" runat="server" ImageUrl='<%# getImagenCheck(cint(eval("idOrdenDetalle"))) %>' />
                                                </td>
                                            </tr>
                                        </table>
                                        
                                        <!--Seccion de ProductoServiciosOrdenesDetalles-->
                                        <asp:DataList ID="dtlservicios" runat="server" Width="100%" DataSource='<%# getDetallesServicios(cint(eval("idOrdenDetalle"))) %>'>
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" style="width:980px; ">
                                                    <tr>
                                                   
                                                        <td style=" width:40px; text-align:center;">
                                                            <asp:Label id="lblcantidadproductosS" runat="server" Text='<%# eval("cantidadProductos") %>' ></asp:Label>
                                                        </td>
                                                        <td style=" width:54px;">&nbsp;</td>
                                                        <td style=" width:80px;">
                                                	    </td>
                                                        <td >
                                                            <asp:Label id="lblidS" runat="server" Text='<%# eval("idOrdenDetalleProductoServicio") %>'  Visible="false" Width="40px"></asp:Label>
                                                            <asp:HyperLink id="lblServicio" runat="server" CssClass="LigaProducto" Font-Underline="false"  Text='<%# getServicio(cint(Eval("idServicio"))) %>' ></asp:HyperLink>&nbsp;
                                                        </td>
                                                         <td style=" width:90px;text-align: left;"></td>
                                                        <td style=" width:90px;text-align:right ;">
                                                            <asp:Label id="lblCostoSetupS" runat="server" Text='<%# Eval("CostoSetup", "{0:c}") %>' ></asp:Label>&nbsp;
                                                        </td>
                                                        <td style="width:90px; text-align:right;">
                                                            <asp:Label id="lblCostoUnitarioS" runat="server" Text='<%# Eval("CostoComponenteBase", "{0:c}") %>' Width="40px"  SkinID="textheader"></asp:Label>
                                                             <asp:Label id="lblidordendetalleproductoservicio" runat="server" Text='<%# eval("idOrdenDetalleProductoServicio") %>'  Visible="false" Width="40px"></asp:Label>
                                                        </td>
                                                       <td style="width:90px; text-align:right;">
                                                          <asp:Label id="lblCostoFinalS" runat="server" Text='<%# Eval("CostoFinal", "{0:c}") %>'   SkinID="textheader" ></asp:Label>
                                                        </td>
                                                        <td style="width:110px;text-align:right;">
                                                            <asp:Label id="lblCostoTotalS" runat="server" Text='<%# Eval("Total", "{0:c}") %>' ></asp:Label>&nbsp;
                                                        </td>
                                                         <td style="width:30px;text-align:right;">
                                                   <asp:Image ID="imgDatos" runat="server" ImageUrl='<%# getImagenCheck2(cint(eval("idOrdenDetalleProductoServicio"))) %>' />
                                                </td>
                                                    </tr>
                                                </table>
                                                </ItemTemplate>
                                        </asp:DataList>
                                        <!--fin seccion de productoserviciosordenesdetalles-->
                                        
                                        
                                        
                                    </ItemTemplate>
                                </asp:DataList>
                                
                             
		     
                    </td>
                    </tr>
                    </table>
                    
                            
                    
                                      <div style=" height :10px"></div>
                    
        <!--seccion para el popup Ordendetalle-->
                    
                    
                    <!--- termina seccion del popup Ordendetalle-->					
                    
                          <!--seccion para el popup Servicios-->
                    
                    
                    <!--- termina seccion del popup servicios-->						
						
                    <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                            <tr>
                                <td style="text-align: left; vertical-align:top; ; width:775px;">
                         
                                          &nbsp;</td>
                                <td style="width:10px"> <asp:Image ID="Image11" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left; vertical-align:top; width:475px">
                    
                                          <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                            <tr>
                                                <td style="width:20px"> <asp:Image ID="Image12" runat="server"  Width="20px"  
                                                        ImageUrl="~/images/transp.gif" /></td>
                                                <td style="text-align: right;"> 
                                                    <asp:Label ID="Label26" runat="server"   Font-Bold="True"  Font-Size="11px">RESUMEN DE PROYECTO</asp:Label>
                                                </td>
                                            </tr>
                                          </table>
                     
                                     
                                     <div style=" height :10px"></div>
                                    
                           
                                   <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                        <tr>
                                            <td style="width:20px"> <asp:Image ID="Image13" runat="server"  Width="20px"  
                                                    ImageUrl="~/images/transp.gif" /></td>
                                            <td style="text-align: left; ">
                                                <TABLE id="Table2" cellSpacing="2" cellPadding="1" width="100%" border="0">
										            <TR>
											            <TD class="Mediana">
                                                            &nbsp;</TD>
											            <TD class="Mediana" style="width: 130px; font-weight: bold; text-align:right;">
                                                            Costo envio</TD>
											            <TD align="right"   style="width: 130px">
												            <asp:label id="lblcostoenvio" runat="server"    SkinID="textheader" style="text-align:right"></asp:label>
											            </TD>
										            </TR>
										            <TR>
											            <TD class="Mediana">
                                                            &nbsp;</TD>
											            <TD class="Mediana" style="width: 130px; text-align:right; font-weight: 700;">
                                                            Costo express</TD>
											            <TD align="right"   style="width: 130px">
												            <asp:label id="lblcostoexpress" runat="server"    
                                                                SkinID="textheader" style="text-align:right"></asp:label>
											            </TD>
										            </TR>
										            <TR>
											            <TD class="Mediana">
                                                            &nbsp;</TD>
											            <TD class="Mediana" style="width: 130px; text-align:right;">
                                                            &nbsp;</TD>
											            <TD align="right"   style="width: 130px">
												            <HR width="100%" SIZE="1">
											            </TD>
										            </TR>
										            <TR>
											            <TD class="Mediana">
                                                            &nbsp;</TD>
											            <TD class="Mediana" style="width: 130px; text-align:right;">
                                                            <asp:Label ID="Label28" runat="server" Text="Subtotal" 
                                                                 Font-Bold="True"></asp:Label></TD>
											            <TD align="right"   style="width: 130px">
                                                            <asp:label id="lblsubtotalgeneral" runat="server" CssClass="Mediana" 
                                                                Font-Bold="True"  Font-Size="12px"
                                                                 ></asp:label></TD>
										            </TR>
										            <TR>
											            <TD class="Mediana">
                                                            &nbsp;</TD>
											            <TD class="Mediana" style="width: 130px; text-align:right;">
                                                            <asp:Label ID="Label22" runat="server" Text="Impuesto" 
                                                                meta:resourcekey="Label22Resource1" Font-Bold="True"></asp:Label></TD>
											            <TD align="right"   style="width: 130px">
                                                            &nbsp;<asp:label 
                                                                id="lblImpuesto" runat="server" CssClass="Mediana"  Font-Size="12px" Font-Bold="True"
                                                                 ></asp:label></TD>
										            </TR>
										            <TR>
											            <TD class="Mediana" vAlign="top"></TD>
											            <TD class="Mediana" style="width: 130px; text-align:right;"></TD>
											            <TD align="right"   style="width: 130px">
												            <HR width="100%" SIZE="1">
											            </TD>
										            </TR>
										            <TR>
											            <TD class="Mediana" vAlign="top">
                                                            &nbsp;</TD>
											            <TD class="Mediana" style="width: 130px; text-align:right;">
                                                            <asp:Label ID="Label24" runat="server" Text="Total" 
                                                                  Font-Bold="True"></asp:Label></TD>
											            <TD align="right"   style="width: 130px">
                                                            <asp:label id="lblTotal" runat="server" CssClass="Mediana" ForeColor="Green" 
                                                                Font-Bold="True"  Font-Underline="False" Font-Size="12px" 
                                                                meta:resourcekey="lblTotalResource1"></asp:label></TD>
										            </TR>
										            <TR>
											            <TD class="Mediana" vAlign="top"></TD>
											            <TD class="Mediana" style="width: 130px; text-align:right;"></TD>
											            <TD align="right"   style="width: 130px">
												            <HR width="100%" SIZE="1">
												            &nbsp;</TD>
										            </TR>
										            <TR>
											            <TD class="Mediana" vAlign="top">&nbsp;</TD>
											            <TD class="Mediana" style="width: 130px; text-align:right;">
                                                            &nbsp;</TD>
											            <TD align="right"   style="width: 130px">
                                                            
                                                        </TD>
										            </TR>
									            </TABLE>
                                            </td>
                                        </tr>
                                        </table>
                                     
                                  
                
                                </td>
                            </tr>
                       </table>
                    
           
     </asp:Panel>  				
         
<%-- 
          <uc1:DisplayDepositosPorCotizacion ID="DisplayDepositosPorCotizacion1" runat="server" />
    
    <div style=" height :25px"></div>


           <uc3:DisplayCargosExtrasPorCotizacion ID="DisplayCargosExtrasPorCotizacion1" runat="server" />

      <div style=" height :25px"></div>
        <uc4:DisplayFacturasOrden ID="DisplayFacturasOrden1" runat="server" />

              

    --%>
