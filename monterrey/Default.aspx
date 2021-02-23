<%@ Page Title="Todopromocinoal - Monterrey promocionales" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="monterrey_Default" %>

<%@ Register src="../controles/DisplayGrupos.ascx" tagname="DisplayGrupos" tagprefix="uc3" %>



<%@ Register src="../controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>

<%@ Register src="../controles/DisplayAnunciosHomeMTY.ascx" tagname="DisplayAnunciosHomeMTY" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
    
	     
           
       
    <uc1:DisplayAnunciosHomeMTY ID="DisplayAnunciosHomeMTY1" runat="server" />
    
	     
           
       
 </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
     <div class="col-md-3  hidden-sm hidden-xs">
                <div class="menu">
			        <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo1" runat="server" />
                </div>
			</div>

			 <div class="col-md-9 col-sm-12 col-xs-12">

               <%--     <img src="../images/mty/banner.jpg"  class="img-responsive" alt="banner" />

                 <div style="height:15px;"></div>

                 

    <table border="0" cellpadding="00" cellspacing="0">
      
      <tr>
        <td>
          <table border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td><table width="290" border="0" cellpadding="0" cellspacing="15">
              <tr>
                <td align="center" class="title">¡Visita nuestro exhibidor!<br /></td>
              </tr>
              <tr>
                <td align="center" class="txt">Sorpréndete con la gran variedad de artículos que manejamos, desde sencillos hasta los más sofisticados.</td>
              </tr>
              <tr>
                <td align="center"><img src="../images/mty/exhibidor.jpg" width="290" height="141" alt="EX" /></td>
              </tr>
            </table></td>
            <td><table width="290" border="0" cellpadding="0" cellspacing="15">
              <tr>
                <td align="center" class="title">¡Estamos en Monterrey!</td>
              </tr>
              <tr>
                <td align="center" class="txt">Estamos en Av. Félix U. Gómez 616 Nte. en el Centro de Monterrey, a tres cuadras de Av. Madero.</td>
              </tr>
              <tr>
                <td align="center"><img src="../images/mty/mapa.jpg" alt="EX" width="290" height="141" border="0" usemap="#Map" /></td>
              </tr>
            </table></td>
            <td><table width="290" border="0" cellpadding="0" cellspacing="15">
              <tr>
                <td align="center" class="title">¡Estamos para servirte!</td>
              </tr>
              <tr>
                <td align="center" class="txt"><table border="0">
                  <tr>
                    <td width="60"><a href="../contacto.aspx"><img src="../images/mty/tel.jpg" width="53" height="54" alt="tel" /></a></td>
                    <td class="txt"> Teléfono en Monterrey<br />
                (81) 4738 5000 <br />
Conmutador con 12 líneas</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td align="center"><a href="../contacto.aspx"><img src="../images/mty/contacto.jpg" width="290" height="141" alt="Página de contácto" /></a></td>
              </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
      
    </table>--%>

    <map name="Map" id="Map">
  <area shape="rect" coords="152,92,278,140" href="http://maps.google.com/maps?q=todopromocional&amp;hl=es&amp;ll=25.679145,-100.297505&amp;spn=0.005773,0.010675&amp;sll=37.0625,-95.677068&amp;sspn=41.411029,87.451172&amp;layer=c&amp;cbll=25.679045,-100.297521&amp;panoid=hRqHq-EX_9mTNRdfKPfkBA&amp;cbp=12,315.48,,0,-4.92&amp;z=17" target="_blank" alt="street" />
  <area shape="rect" coords="11,92,124,139" href="http://maps.google.com/maps?q=todopromocional&amp;hl=es&amp;ll=25.679228,-100.297521&amp;spn=0.001455,0.002669&amp;sll=37.0625,-95.677068&amp;sspn=41.411029,87.451172&amp;z=19&amp;iwloc=A" target="_blank" alt="map" />
</map>

                 
                        <uc3:DisplayGrupos ID="DisplayGrupos1" runat="server" />


                 </div>
</asp:Content>

