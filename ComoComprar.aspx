<%@ Page Title="Como comprar" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="ComoComprar.aspx.vb" Inherits="ComoComprar" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register src="controles/DisplayCategories.ascx" tagname="DisplayCategories" tagprefix="uc1" %>
<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

      <div class="col-md-2 menu">
       
	        <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo2" runat="server" />
        </div>


     <div class="col-md-10 main">


	<h1>Proceso de compra</h1>
        <table width="100%" border="0" cellpadding="0" cellspacing="20">
          <tr>
            <td width="368" align="center" valign="top"><p>
                <img src="images/proceso-cotizacion.jpg" 
                    width="605" height="760" alt="proceso" /></p></td>
          </tr>
          <tr>
            <td valign="top" class="txt-black1"><p>&nbsp;</p>
              <p>Quizás te interese también: 
                  <a href="privacidad.aspx" 
                      class="link-purple">Preguntas Frecuentes</a> o 
                  <a href="terminosycondiciones.aspx" 
                      class="link-purple">Cláusulas de Compra</a></p></td>
          </tr>
          </table>          
         </div>
</asp:Content>

