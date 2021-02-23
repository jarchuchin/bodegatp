<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="Distribuidor.aspx.vb" Inherits="Distribuidor" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	<h2>Regístrate como distribuidor</h2>
	<h3>¡aprovecha  beneficios exclusivos!</h3>

        <table width="100%" border="0" cellpadding="0" cellspacing="20" class="border-box2">
          <tr>
            <td width="400" align="left"><table border="0" cellspacing="10" cellpadding="0" 
                    style="width: 500px;">
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td>
                              <asp:Image ID="Image8" runat="server" imageurl="~/images/campo-left.png" width="10" height="27"/></td>
                    <td width="283" ><asp:textbox id="txtNombre" runat="server" SkinID="textheader" Width="283px" CssClass="search-box" Height="27px" TabIndex="1"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtNombre_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtNombre" WatermarkText="Nombre">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
                    <td>
                              <asp:Image ID="Image20" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtNombre" ErrorMessage="El nombre es requerido">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                </cc1:ValidatorCalloutExtender>
                      </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td>
                              <asp:Image ID="Image9" runat="server" imageurl="~/images/campo-left.png" 
                            width="10" height="27"/></td>
                    <td width="283" ><asp:textbox id="txtEmail" runat="server" SkinID="textheader" 
                            Width="283px" CssClass="search-box" Height="27px" TabIndex="1"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtEmail_TextBoxWatermarkExtender" runat="server" 
                            Enabled="True" TargetControlID="txtEmail" 
                            WatermarkText="Email (será tu identificación de usuario)">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
                    <td>
                              <asp:Image ID="Image21" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="El email es requerido">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                                </cc1:ValidatorCalloutExtender>
                      </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td>
                              &nbsp;</td>
                    <td width="283" style="font-size: 12px" >Contraseña</td>
                    <td>
                              &nbsp;</td>
                  </tr>
                  <tr>
                    <td>
                              <asp:Image ID="Image10" runat="server" imageurl="~/images/campo-left.png" 
                            width="10" height="27"/></td>
                    <td width="283" ><asp:textbox id="txtContraseña" runat="server" SkinID="textheader" 
                            Width="283px" CssClass="search-box" Height="27px" TabIndex="1" 
                            TextMode="Password"></asp:textbox>
                      </td>
                    <td>
                              <asp:Image ID="Image22" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtContraseña" ErrorMessage="La contraseña es requerida">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                </cc1:ValidatorCalloutExtender>
                      </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td>
                              &nbsp;</td>
                    <td width="283" style="font-size: 12px" >Repetir contraseña</td>
                    <td>
                              &nbsp;</td>
                  </tr>
                  <tr>
                    <td>
                              <asp:Image ID="Image11" runat="server" imageurl="~/images/campo-left.png" 
                            width="10" height="27"/></td>
                    <td width="283" >
                        <asp:textbox id="txtContraseña0" runat="server" 
                            SkinID="textheader" Width="283px" CssClass="search-box" Height="27px" 
                            TabIndex="1" TextMode="Password"></asp:textbox>
                      </td>
                    <td>
                              <asp:Image ID="Image23" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtContraseña0" 
                                    ErrorMessage="La confirmación de la contraseña es requerida">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                </cc1:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToCompare="txtContraseña" ControlToValidate="txtContraseña0" 
                                    ErrorMessage="No coincide la contraseña con la confirmación">*</asp:CompareValidator>
                                <cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="CompareValidator1">
                                </cc1:ValidatorCalloutExtender>
                      </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td>
                              <asp:Image ID="Image12" runat="server" imageurl="~/images/campo-left.png" 
                            width="10" height="27"/></td>
                    <td width="283"><asp:textbox id="txtTelefono" runat="server" SkinID="textheader" 
                            Width="283px" CssClass="search-box" Height="27px" TabIndex="1"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtTelefono_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtTelefono" 
                            WatermarkText="Teléfono">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
                    <td>
                              <asp:Image ID="Image24" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txtTelefono" ErrorMessage="El teléfono es requerido">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                </cc1:ValidatorCalloutExtender>
                      </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
             
                    <td width="200" >
                              <asp:DropDownList ID="drpestados" runat="server"  Height="27px"
                      SkinID="textheader" Width="200px" TabIndex="5" >
                                                            </asp:DropDownList>
                          </td>
                    <td>&nbsp;</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td>
                              <asp:Image ID="Image14" runat="server" imageurl="~/images/campo-left.png" 
                            width="10" height="27"/></td>
                    <td width="283" ><asp:textbox id="txtRazonSocial" runat="server" 
                            SkinID="textheader" Width="283px" CssClass="search-box" Height="27px" 
                            TabIndex="1"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtRazonSocial_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtRazonSocial" 
                            WatermarkText="Razón social">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
                    <td>
                              <asp:Image ID="Image25" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="txtRazonSocial" ErrorMessage="La razon social es requerida">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                </cc1:ValidatorCalloutExtender>
                      </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="200" >
                              <asp:DropDownList ID="drpgiro" runat="server"  Height="27px"
                      SkinID="textheader" Width="200px" TabIndex="5" >
                                  <asp:ListItem>Empresa de publicidad</asp:ListItem>
                                  <asp:ListItem>Distribuidor de promocionales</asp:ListItem>
                                  <asp:ListItem>Impresor</asp:ListItem>
                                                            </asp:DropDownList>
                          </td>
                    <td>&nbsp;</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td>
                              <asp:Image ID="Image16" runat="server" imageurl="~/images/campo-left.png" 
                            width="10" height="27"/></td>
                    <td width="200" ><asp:textbox id="txtRFC" runat="server" SkinID="textheader" 
                            Width="283px" CssClass="search-box" Height="27px" TabIndex="1"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtRFC_TextBoxWatermarkExtender" runat="server" 
                            Enabled="True" TargetControlID="txtRFC" WatermarkText="RFC">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
                    <td>
                              <asp:Image ID="Image26" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txtRFC" ErrorMessage="El rfc es requerido">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                </cc1:ValidatorCalloutExtender>
                      </td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;">
                    <asp:textbox id="txtDireccion" runat="server" 
                            Width="296px" Height="78px" 
                            TabIndex="1" TextMode="MultiLine"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtDireccion_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtDireccion" 
                            WatermarkText="Dirección completa">
                  </cc1:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ControlToValidate="txtDireccion" 
                        ErrorMessage="La direccion es requerida">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender" 
                                    runat="server" Enabled="True" 
                        TargetControlID="RequiredFieldValidator8">
                                </cc1:ValidatorCalloutExtender>
                         </td>
                      
              </tr>
              <tr>
                <td style="text-align: left;"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td>
                              <asp:Image ID="Image18" runat="server" imageurl="~/images/campo-left.png" 
                            width="10" height="27"/></td>
                    <td width="283" ><asp:textbox id="txtPaginaWeb" runat="server" SkinID="textheader" 
                            Width="283px" CssClass="search-box" Height="27px" TabIndex="1"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtPaginaWeb_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtPaginaWeb" 
                            WatermarkText="Página web">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
                    <td>
                              <asp:Image ID="Image27" runat="server" 
                            Imageurl="~/images/campo-right.png" width="10" height="27" /></td>
                            <td>&nbsp;</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td style="text-align: left;">
                    <asp:textbox id="txtComentarios" runat="server" 
                            SkinID="textheader" Width="301px" Height="80px" 
                            TabIndex="1" TextMode="MultiLine"></asp:textbox>
                  <cc1:TextBoxWatermarkExtender ID="txtComentarios_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtComentarios" 
                            WatermarkText="Comentarios">
                  </cc1:TextBoxWatermarkExtender>
                          </td>
               
              </tr>
            </table>
              <table border="0" cellspacing="20" cellpadding="0">
                <tr>
                  <td>
                              <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="button2"  />
                              <cc1:ConfirmButtonExtender ID="btnRegistrar_ConfirmButtonExtender" 
                                  runat="server" 
                                  ConfirmText="¿Deseas registrarte como uno de nuestros distribuidores?" 
                                  Enabled="True" TargetControlID="btnRegistrar">
                              </cc1:ConfirmButtonExtender>
                    </td>
                  <td><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button2"  /></td>
                </tr>
              </table></td>
          </tr>
          <tr>
            <td align="right"><a href="privacidad.aspx" class="link-purple">Código de  privacidad</td>
          </tr>
        </table>

</asp:Content>

