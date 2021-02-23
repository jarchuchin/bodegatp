<%@ Page Title="Status del proyecto" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="ProyectoStatus.aspx.vb" Inherits="ProyectoStatus" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<h2>Status del proyecto</h2>


	<table width="100%" border="0" cellpadding="0" cellspacing="20">
            <tr>
              <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td class="title1">Status del proyecto</td>
                </tr>
                </table></td>
            </tr>
            <tr>
              <td  align="center" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td valign="top" class="txt-black1">
                    <p>
                        <asp:TextBox ID="txtBuscar" runat="server" SkinID="textheader" Width="200px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtBuscar_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtBuscar" 
                            WatermarkText="Coloca el numero del proyecto">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" 
                            ErrorMessage="Proyecto no encontrado">*</asp:CustomValidator>
                        <cc1:ValidatorCalloutExtender ID="CustomValidator1_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="CustomValidator1">
                        </cc1:ValidatorCalloutExtender>
&nbsp;
                        <asp:Button ID="Button1" runat="server" SkinID="botongeneral" 
                            Text="Revisar avance" />
                      </p>
                      <p class="txt-black1">&nbsp;</p></td>
                  <td width="20">&nbsp;</td>
                  <td width="180" align="center" valign="top"><p>
                      <img src="images/ayuda.png" alt="exhibidor" 
                          width="151" height="163" /><br />
                    </p>
                    <p class="txt-black1">&nbsp;</p></td>
                  </tr>
                </table>
                <p>&nbsp;</p></td>
            </tr>
          </table>          

          <script type="text/javascript">

              var Accordion1 = new Spry.Widget.Accordion("Accordion1");
          
</script>

       </asp:Content>
