<%@ Page Title="Solicitar Factura" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="SolicitarFactura.aspx.vb" Inherits="sec_SolicitarFactura" %>

<%@ Register src="../controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>
<%@ Register src="../controles/MenuMisOpciones.ascx" tagname="MenuMisOpciones" tagprefix="uc6" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	
         <div class="col-md-2  hidden-sm hidden-xs menu">
	       		<%--<uc6:MenuMisOpciones ID="MenuMisOpciones1" runat="server" />--%>

    </div>

		<div class="col-md-10 main">
            <h2> Revisar datos de facturación proyecto: #&nbsp; <asp:Literal ID="litNumOrden" runat="server" /></h2>
    

          
        
      <div style="height:20px;"></div>      

<%--    <div class="row">
                <div class="col-lg-8">
                    <strong>DATOS FISCALES TODOPROMOCIONAL</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>
                     <table style="width: 100%">
                        <tr>
                            <td style="text-align: left; width: 160px;"><b>Nombre/Empresa</b></td>
                            <td style="text-align: left">
						<asp:Label ID="lblLabel0" runat="server">Concentradora de Medios Promocionales S.A. de C.V.</asp:Label>
							</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 128px"><b>RFC</b></td>
                            <td style="text-align: left">
						<asp:Label ID="lblLabel" runat="server">CMP070924FCA</asp:Label>
							</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 128px; vertical-align:top;"><b>Direccion</b></td>
                            <td style="text-align: left">
						<asp:Label ID="lblLabel1" runat="server">Félix Uresti Gómez, No. Ext. 616 Norte</asp:Label><br />
                                <asp:Label ID="Label1" runat="server">Col. Monterrey Centro</asp:Label><br />
                                <asp:Label ID="Label3" runat="server">Monterrey, Nuevo León</asp:Label><br />
                                <asp:Label ID="Label4" runat="server">México, CP. 64000</asp:Label>
							</td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 128px"><b>Teléfono</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgTelefonsso" runat="server">814738500</asp:Label>
							</td>
                        </tr>
                   
                      <%--  <tr>
                            <td style="text-align: left; width: 111px"><b>Status</b></td>
                            <td style="text-align: left">
						<asp:Label ID="dgStatus" runat="server"></asp:Label>
							</td>
                        </tr>
                    
                    </table>
                    <div style="height:30px;">&nbsp;</div>
                </div>
        </div>--%>
        <div class="row"    >
                <div class="col-lg-8">
                    

                      <strong>MIS DATOS DE FACTURACIÓN</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>

                     <table style="width: 100%">
                        <tr>
                            <td style="text-align: left; width: 160px;"><b>Nombre/Empresa</b></td>
                            <td style="text-align: left"><asp:Label ID="dfNombre" runat="server"></asp:Label> </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;"><b>RFC</b></td>
                            <td style="text-align: left">
							<asp:Label ID="dfRFC" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;"><b>Calle</b></td>
                            <td style="text-align: left">
							<asp:Label ID="dfCalle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; "><b>Número exterior</b></td>
                            <td style="text-align: left">
							<asp:Label ID="dfNumexterior" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; "><b>Número interior</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfNuminterior" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="text-align: left; "><b>Colonia</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfColonia" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="text-align: left; "><b>Estado</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfEstado" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="text-align: left; "><b>Municipio</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfMunicipio" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="text-align: left; "><b>Localidad</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfLocalidad" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="text-align: left; "><b>Referencia</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfReferencia" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="text-align: left; "><b>Código Postal</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfCodigoPostal" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="text-align: left; "><b>Teléfono</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfTelefono" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="text-align: left; "><b>Clave bancaria</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfClaveBancaria" runat="server"></asp:Label>
                               
                            </td>
                        </tr>
                     
                        <tr>
                            <td style="text-align: left; "><b>Incluir el siguiente<br />
                                dato al facturar</b></td>
                            <td style="text-align: left">
                               
							<asp:Label ID="dfIncluirdatosAlfacturar" runat="server"></asp:Label>
                               
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: left; "> </td>
                            <td style="text-align: left">
                               
						 <asp:Button ID="btnEditar" runat="server" Text="Editar datos de facturación" CssClass="btn btn-warning btn-sm" />
                               
                            </td>
                        </tr>
                     
                        </table>

                         
            

                        <div style="height:50px;"></div>   


              </div>

                <div class="col-lg-2">

                      
                    <img alt="" src="../images/process6.jpg" style="width:45px;" />
                    <div style="height:10px;"></div>
                  

             



                </div>

    </div>

            
			
    <div style="height:40px;"></div>  




              <div class="row">
                <div class="col-lg-8">
                    <strong>SELECCIONAR LOS PAGOS INCLUIDOS EN LA FACTURA</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>



                    <div style="height:10px;">&nbsp;</div>
                 
                             	<asp:GridView ID="gvDepositosVentas" runat="server"  CssClass="table table-striped"   AutoGenerateColumns="False" GridLines="None" ShowHeader="False" Width="100%" >
							<Columns>
                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
									<ItemTemplate>
										<asp:checkbox ID="chkSeleccion" runat="server"   ></asp:checkbox>
                                        <asp:Label ID="lblClaveDeposito" runat="server" Text='<%# Eval("idDeposito") %>' Visible="false"></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center">
									<ItemTemplate>
										<asp:label ID="lnkEditarPago" runat="server"  Text='<%#Format(Eval("fecha"), "d") %>' ToolTip="Editar datos" Font-Size="11px"></asp:label>
									</ItemTemplate>
								</asp:TemplateField>
								
                                <asp:TemplateField ItemStyle-Font-Size="11px" >
									<ItemTemplate>
    									<asp:Label ID="Label1" runat="server" Text='<%# Eval("Cliente") %>' Font-Size="11px"></asp:Label><br />
                                        Ref. <asp:Label ID="Label3ss" runat="server" Text='<%# Eval("Referencia") %>' Font-Bold="true" Font-Size="11px"></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
                                  <asp:TemplateField ItemStyle-Width="100px">
									<ItemTemplate>
    									<asp:Label ID="Label1dsf" Font-Italic="true" runat="server" Text='<%#Eval("Estatus") %>' Font-Size="11px"></asp:Label>
									</ItemTemplate>

								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="80px">
									<ItemTemplate>
    									<asp:Label ID="Labfdgfel1" Font-Bold="true" runat="server" Text='<%# Format(Eval("Monto"), "c") %>' Font-Size="11px"></asp:Label>
									</ItemTemplate>

								</asp:TemplateField>
							</Columns>
						</asp:GridView>
                        <asp:Label ID="lblMensaje" runat="server" Text="No hay pagos con el status de registrados en el sistema" Visible="false"></asp:Label>

                     <div style="height:40px;"></div>  
                     <div style="text-align:center">
                         <asp:Button ID="btnSolicitar" runat="server" Text="Solicitar factura" CssClass="btn btn-success btn-lg" />
                    </div>
                </div>
            </div>
			

             
			
          

           
    
                      <div style="height:40px;"></div> 
       </div>


 


</asp:Content>

