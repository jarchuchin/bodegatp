<%@ Page Title="Enviar correo electrónico" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="EnviarEmailProducto.aspx.vb" Inherits="EnviarEmailProducto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	<h2>Envía esta información por email</h2>


        <table width="100%" border="0" cellpadding="0" cellspacing="20" >
        
          <tr>
            <td width="100%" align="center"><table border="0" cellspacing="10" cellpadding="0" 
                    style="width: 100%;">
              <tr>
                <td style="text-align: center;"><table border="0" cellspacing="0" cellpadding="0" align="center">
                  <tr>
                    <td>
                              <asp:Image ID="Image8" runat="server" imageurl="~/images/campo-left.png" width="10" height="27"/></td>
                    <td width="283" ><asp:textbox id="txtEmailPara" runat="server" SkinID="textheader" Width="283px" CssClass="search-box" Height="27px" TabIndex="1"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtNombre_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtEmailPara" WatermarkText="Email a quien deseas enviar">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
                    <td>
                              <asp:Image ID="Image20" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtEmailPara" ErrorMessage="El email es requerido">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                </cc1:ValidatorCalloutExtender>
                      </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: center;"><table border="0" cellspacing="0" cellpadding="0" align="center">
                  <tr>
                    <td>
                              <asp:Image ID="Image9" runat="server" imageurl="~/images/campo-left.png" 
                            width="10" height="27"/></td>
                    <td width="283" ><asp:textbox id="txtEmail" runat="server" SkinID="textheader" 
                            Width="283px" CssClass="search-box" Height="27px" TabIndex="1"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtEmail_TextBoxWatermarkExtender" runat="server" 
                            Enabled="True" TargetControlID="txtEmail" 
                            WatermarkText="Tu Email">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
                    <td>
                              <asp:Image ID="Image21" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="El email es requerido">*</asp:RequiredFieldValidator>
                      </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: center;">
                    <asp:textbox id="txtMensaje" runat="server" 
                            SkinID="textheader" Width="301px" Height="80px" 
                            TabIndex="1" TextMode="MultiLine"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtMensaje_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtMensaje" 
                            WatermarkText="Mensaje">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
               
              </tr>
            </table>
              <table border="0" cellspacing="20" cellpadding="0">
                <tr>
                  <td>
                              <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="button2"  />
                              <cc1:ConfirmButtonExtender ID="btnEnviar_ConfirmButtonExtender" 
                                  runat="server" 
                                  ConfirmText="¿Deseas enviar la información del producto por correo electrónico?" 
                                  Enabled="True" TargetControlID="btnEnviar">
                              </cc1:ConfirmButtonExtender>
                    </td>
                  <td><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button2"  /></td>
                </tr>
              </table></td>
          </tr>
          </table>








<table width="95%" border="0" cellpadding="0" cellspacing="20" class="border-box2">
			<tr>
			  <td width="368" valign="top" class="title1">
						  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
					<ContentTemplate>
					
						<table cellpadding="0" cellspacing="0" class="tablaImagenProducto">
							<tr><td>   <div style="text-align:center; background-color:White;">
						<asp:Image ID="imgProducto" runat="server"  Width="368px" />
					  </div></td></tr>
						</table>
				   
					  
					   <div style="height: 20px"></div>
					   <table cellpadding="0" cellspacing="0" border="0"  style=" width:100%; text-align:left;">
						<tr><td>
						
						<asp:DataList ID="dlFotos" runat="server" DataKeyField="idProductoFoto"  HorizontalAlign="Left" RepeatColumns="4"  BorderWidth="0px" meta:resourcekey="dlFotosResource1" >
						<ItemStyle   VerticalAlign="Top"/>
						<ItemTemplate>
							 <table cellpadding="0" cellspacing="0" border="0"  style=" width:80px; text-align:left;">
								<tr>
								<td style="width:80px;  background-color:White;"> <table cellpadding="0" cellspacing="0" class="tablaImagenProducto">
							<tr><td><asp:ImageButton ID="imgFoto"  ImageUrl='<%# carpetafiles &  Eval("imagen") %>'   CommandName="Select"  Width="80px" runat="server"                                 CausesValidation="False" meta:resourcekey="imgFotoResource1"/></td></tr>
						</table></td>
								<td style="width:3px"><asp:Image ID="imgdiv121" runat="server"  Width="3px"  ImageUrl="~/images/transp.gif" /></td>
								</tr>
							</table>
						   <div style="height: 3px"></div>
						</ItemTemplate>
						</asp:DataList>
					  
					   </td></tr>
					  </table>
					  <asp:HyperLink ID="lnkampliar" runat="server"  Text="zoom"  CssClass="link-purple"
							  ></asp:HyperLink> 
				   
					 
					</ContentTemplate>
				</asp:UpdatePanel>    
			  </td>
			  <td width="368" valign="top"><table width="100%" border="0" cellspacing="5" cellpadding="0">
				<tr>
				  <td class="title1">
				  <table cellpadding="0" cellspacing="0" border="0"  style="  height:30px;  text-align:left;">
					<tr>
						<td style="width:1px; text-align:center;" >
							<asp:Panel ID="panelnuevo" runat="server" Visible="true"  Width="70px">
								<table cellpadding="0" cellspacing="0" border="0"  style=" width:70px; height:30px; background-color:red; text-align:center;">
									<tr><td><asp:Label ID="lblNuevo" runat="server"  ForeColor="white" Font-Bold="true" Font-Size="13px">¡NUEVO!</asp:Label></td><td> 
								
										</td></tr>
								</table> 
							</asp:Panel>       
						</td>
						<td><asp:Label ID="lblNombreProducto" runat="server" CssClass="title1"></asp:Label></td>
					</tr>
				</table>
				  </td>
				  </tr>
				<tr>
				  <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
					  <td width="50%" class="txt-gray-11"> <asp:Label ID="Label16" runat="server"  
							  Font-Bold="False" Text="Clave:" CssClass="txt-gray-11" ></asp:Label> &nbsp;<asp:Label 
							  ID="lblClave" runat="server" 
										Font-Bold="False"  CssClass="txt-gray-11"  ></asp:Label></td>
					  <td width="50%" class="txt-gray2">Publicado el 
						  <asp:Label ID="lblfechaActualizacion" CssClass="txt-gray2"  runat="server" ></asp:Label> </td>
					  </tr>
					</table></td>
				  </tr>
				<tr>
				  <td height="30" valign="bottom" class="txt-black1"><strong>Descripción</strong></td>
				  </tr>
				<tr>
				  <td class="txt-black1"> <asp:Literal ID="litdescripcion" runat="server" ></asp:Literal></td>
				  </tr>
				<tr>
				  <td height="30" valign="bottom" class="txt-black1"><strong>Acabados disponibles:</strong></td>
				  </tr>
				<tr>
				  <td class="txt-black1">
							
					
								<asp:DataList ID="rptprecioscon" runat="server" RepeatColumns="3" 
									RepeatLayout="Flow" CssClass="txt-black1" >
									<ItemTemplate>
									   <asp:Label ID="lblAcabado" runat="server"  CssClass="txt-black1"  Text='<%# eval("Nombre") %>' > </asp:Label>
									</ItemTemplate>
								</asp:DataList>
								
					</td>
				  </tr>
				<tr>
				  <td height="30"><asp:Repeater ID="rptfeatures" runat="server"  >
						<ItemTemplate>
							<asp:Panel ID="panelFeatures"  runat="server"   Visible='<%# getfeature(cint(eval("idCaracteristica"))) %>' >
							 <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
									<tr>
										<td style="text-align: left; width:93px;"><asp:Label ID="Label3" runat="server" Text='<%# eval("Nombre")  %>' CssClass="txt-black1"  Font-Bold="true"></asp:Label><b>:</b></td>
										<td style="text-align: left; vertical-align:top;"><asp:Label ID="Labelcaracteristica" CssClass="txt-black1"   runat="server" Text='<%# feature %>' ></asp:Label></td>
									</tr>
							  </table>
                              <div style="height:5px;"> </div>
							  </asp:Panel>
						</ItemTemplate>
					</asp:Repeater></td>
				  </tr>
				<tr>
				  <td height="40" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
					  <td width="63" class="txt-black1"><strong>Colores:</strong></td>
					  <td height="20" class="txt-black1"><asp:DataList ID="dtlColores" runat="server" 
                              RepeatColumns="10" Width="10px" RepeatDirection="Horizontal"  >
											<ItemTemplate>
												   <table cellpadding="0" cellspacing="0" border="0" style="width: 20px" >
													<tr>
														<td style="width:20px;" class="txt-black-13" ><asp:Literal ID="litcolor" runat="server" Text='<%# getColor( eval("idCodigoColor")) %>'></asp:Literal> </td>
														 <td style="width:2px"> <asp:Image ID="Ifdmage24" runat="server"  Width="2px"  ImageUrl="~/images/transp.gif" ToolTip='<%# getColor( eval("idCodigoColor")) %>' /></td>
													</tr>
												</table>
											</ItemTemplate>
										</asp:DataList>
						 </td>
					  </tr>
					</table></td>
				  </tr>
				<tr>
				  <td align="center" class="border-box"><table border="0" cellspacing="5" cellpadding="0">
					<tr>
					  <td><asp:Image ID="imgprecio" runat="server" ImageUrl="images/icon-precio.png" /></td>
					  <td><strong><span class="txt-black1">PRECIOS</span></strong></td>
					  <td><span class="txt-red1">No incluyen I.V.A, impresión o  envío.</span></td>
					  </tr>
					</table>
					
										  

					<asp:GridView ID="rptprecios" runat="server" CssClass="precios" CellSpacing="5" 
						  GridLines="None" ShowHeader="False">
					</asp:GridView>
					
					
					  </td>
				  </tr>
				</table>
                
                
					  <!--termina Cotizador-->
				   
				   
				   
				   
				   
					
        
			  </tr>
        </table>

</asp:Content>

