<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="AgregarImagen.aspx.vb" Inherits="sec_AgregarImagen" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
          <table width="100%" border="0" cellpadding="0" cellspacing="20" class="border-box2">
        
         <tr>
          <td><div style=" height:25px;"></div><table width="100%" border="0" cellspacing="5" cellpadding="0">
            <tr>
              <td width="100%" valign="middle" ><table width="350px" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td style="text-align:center;"><span class="title1">Subir archivos de imágenes</span></td>
                  </tr>
              </table></td>
            </tr>
            <tr>
              <td align="center" style="vertical-align:top">
                                                <table style="width: 350px;">
                                                    <tr>
                                                        <td style="width: 100px; font-size: small;">
                                                            &nbsp;</td>
                                                         <td style="text-align:left;">
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; font-size: small; height: 30px;">
                                                            <span style="font-size: xx-small"><b style="font-size: small">Archivo 1:</b></span><b><asp:CustomValidator ID="CustomValidator1" runat="server" 
                                                                ControlToValidate="FileUpload1" 
                                                                ErrorMessage="Solo archivos de imágenes son permitidos" style="font-size: small">*</asp:CustomValidator>
                                                            </b>
                                                        </td>
                                                        <td style="text-align:left; height: 30px;">
                                                            <asp:FileUpload ID="FileUpload1" runat="server" Font-Size="11px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; font-size: small; height: 30px;">
                                                            <span style="font-size: xx-small"><b style="font-size: small">Archivo 2:</b></span><b><asp:CustomValidator ID="CustomValidator2" runat="server" 
                                                                ControlToValidate="FileUpload2" 
                                                                ErrorMessage="Solo archivos de imágenes son permitidos" style="font-size: small">*</asp:CustomValidator>
                                                            </b>
                                                        </td>
                                                        <td style="text-align:left; height: 30px;">
                                                            <asp:FileUpload ID="FileUpload2" runat="server" Font-Size="11px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; font-size: small; height: 30px;">
                                                            <span style="font-size: xx-small"><b style="font-size: small">Archivo 3:</b></span><b><asp:CustomValidator ID="CustomValidator3" runat="server" 
                                                                ControlToValidate="FileUpload3" 
                                                                ErrorMessage="Solo archivos de imágenes son permitidos" style="font-size: small">*</asp:CustomValidator>
                                                            </b>
                                                        </td>
                                                        <td style="text-align:left; height: 30px;">
                                                            <asp:FileUpload ID="FileUpload3" runat="server" Font-Size="11px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; font-size: small;">
                                                            &nbsp;</td>
                                                        <td>
                                                          
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                  
                                                    <td style="text-align:center;" colspan="2">
                    
                    <asp:Button ID="btnEditar" runat="server"  CssClass="btn btn-primary"
                        Text="Subir imágenes"   />
                                                            &nbsp;
                                                            <cc1:ConfirmButtonExtender ID="btnEditar_ConfirmButtonExtender" runat="server" 
                                                                ConfirmText="¿Desea subir estas imágenes?" Enabled="True" 
                                                                TargetControlID="btnEditar">
                                                            </cc1:ConfirmButtonExtender>
                                                        &nbsp;<asp:Button ID="btnregresar" runat="server"  CausesValidation="false"
                        Text="Regresar" CssClass="btn btn-default"   />
                                                          
                                                        </td>
                                                    </tr>
                                                </table>
                                               <asp:DataList ID="dtlImagenes" runat="server" RepeatColumns="4">
                                                    <ItemStyle    HorizontalAlign="Left"/>
                                                    <ItemTemplate>
                                                         <asp:HyperLink ID="lnkBorrarServicio" runat="server" Text="borrar imagen" ImageUrl="~/images/del.gif"  NavigateUrl='<%# "Compras.aspx?idOrden" & eval("idOrden") &  "&idOrdenImagen=" & eval("idOrdenImagen") & "&act=delimagen" %>' ToolTip="Borrar esta imagen" /><br />
                                                         <asp:HyperLink ID="lnkimagenorden" runat="server" NavigateUrl='<%# carpetafiles & eval("imagen") %>'  Target="_blank">
                                                                <asp:Image ID="Image14" ImageUrl='<%# carpetafiles & eval("imagen") %>' runat="server"  Width="100px"/>
                                                        </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                <div style="height:50px;"></div>
                                            </td>
            </tr>
            <tr>
              <td align="center" class="txt-precios">&nbsp;</td>
            </tr>
             <tr>
              <td align="right"><a href="../privacidad.aspx" class="link-purple">Código de  privacidad</a></td>
            </tr>
          </table></td>
        </tr>
        </table>
</asp:Content>