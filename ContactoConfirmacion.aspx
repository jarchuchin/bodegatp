<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="ContactoConfirmacion.aspx.vb" Inherits="ContactoConfirmacion" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register src="controles/DisplayCategories.ascx" tagname="DisplayCategories" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    <div class="wrapper contactanos">
      <div style="padding:30px;">
<div style="height:10px"></div>
        <div class="text-center">
<h1 >Confirmación de contacto</h1>
            </div>
 <table width="100%" border="0" cellpadding="0" cellspacing="20" >
        
       
        <tr>
             <td colspan="2" align="center">
                                  <h2>  <asp:Label ID="Label13" runat="server" Text="Nuestro centro de contacto esta procesando tu petición" 
                                        
                  Visible="True"></asp:Label></h2>
                                  <p>  
                                      <asp:Image ID="Image11" runat="server" ImageUrl="~/images/mty/contacto.jpg" />
                                  </p><br />
              <asp:Label ID="Label1" runat="server" Text="Pronto nos pondremos en contacto contigo" 
                                    
                  Visible="True"></asp:Label>
									</td>
        </tr>
        <tr>
          <td colspan="2" align="center"><table width="100%" border="0" cellspacing="5" cellpadding="0">
            <tr>
              <td height="2" colspan="2" valign="middle" class="txt-precios">&nbsp;</td>
            </tr>
            <tr>
              <td height="37" valign="middle"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="43"><asp:Image ID="Image9" runat="server" ImageUrl="~/images/images02/ico_telefono.gif" /></td>
                    <td><strong class="txt-black-17">Teléfonos</strong></td>
                  </tr>
              </table></td>
              <td height="37" valign="middle"><table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="53"> <asp:Image ID="Image10" runat="server" ImageUrl="~/images/images02/ico_direcc.gif" /></td>
                    <td><strong class="txt-black-17">Direcciones</strong></td>
                  </tr>
              </table></td>
            </tr>
            <tr>
              <td valign="top"><table border="0" cellpadding="0" cellspacing="5" class="txt-black-13">
                  <tr>
                    <td class="txt-green-13" style="text-align: left">Monterrey</td>
                    <td>(81) 8143-9555</td>
                  </tr>
                  <tr>
                    <td class="txt-green-13" style="text-align: left">México D.F.</td>
                    <td>(55) 56 58 2009</td>
                  </tr>
                  <tr>
                    <td class="txt-green-13" style="text-align: left">Guadalajara</td>
                    <td>89 95 48 02</td>
                  </tr>
                  <tr>
                    <td class="txt-green-13" style="text-align: left">Lada sin costo:</td>
                    <td>01800 702 0505</td>
                  </tr>
              </table></td>
              <td style=" text-align:left"><table border="0" cellpadding="0" cellspacing="5" class="txt-black-13">
                <tr>
                  <td class="txt-green-13" style="text-align: left"><strong>Monterrey</strong></td>
                </tr>
                <tr>
                  <td style="text-align: left">Av. Félix U. Gómez 616 Nte. Col. Centro<br />
                    Monterrey, N.L. C.P. 64000</td>
                </tr>
                <tr>
                  <td class="txt-green-13" style="text-align: left"><strong>México D.F.</strong></td>
                </tr>
                <tr>
                  <td style="text-align: left">Isabel la Católica No. 846 <br />
                      Col. Postal<br />
                       Delegación Benito Juárez <br />
                       Entre Calle Correspondencia  <br />
                       y Calle Unión Postal, <br />
                       Mexico D.F.</td>
                </tr>

              </table></td>
            </tr>
            <tr>
              <td height="3" colspan="2" align="center" class="txt-precios">&nbsp;</td>
            </tr>
            
          </table></td>
        </tr>
        <tr>
          <td colspan="2" align="center">
           
									<asp:Literal id="LitContacto" runat="server" 
                                        meta:resourcekey="LitContactoResource1" Visible="False"></asp:Literal></td>
        </tr>
      </table>
      <p>&nbsp;</p>





























<!-- Google Code for Solicitud de Información Conversion Page -->
<script language="JavaScript" type="text/javascript">
<!--
var google_conversion_id = 1052814348;
var google_conversion_language = "es";
var google_conversion_format = "1";
var google_conversion_color = "ffffff";
var google_conversion_label = "K0TRCOzXcBCM2IL2Aw";
-->
</script>
<script language="JavaScript" src="http://www.googleadservices.com/pagead/conversion.js">
</script>
<noscript>
<img height="1" width="1" border="0" src="http://www.googleadservices.com/pagead/conversion/1052814348/?label=K0TRCOzXcBCM2IL2Aw&script=0"/>
</noscript>

</div>
        </div>
</asp:Content>




