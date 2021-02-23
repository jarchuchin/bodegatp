<%@ Page Title="Como comprar" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="servicios.aspx.vb" Inherits="ComoComprar" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register src="controles/DisplayCategories.ascx" tagname="DisplayCategories" tagprefix="uc1" %>

<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">

    <uc2:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo1" 
        runat="server" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="22" valign="middle" class="path" style=" text-align:left;"><table border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="100" align="center" class="path-title" >Estas aquí:</td>
                <td class="path-link">
    <asp:HyperLink ID="lnkinicio" runat="server" NavigateUrl="~/default.aspx" CssClass="path-link">Inicio</asp:HyperLink> &gt; Conocenos &gt; Servicios</td>
              </tr>
            </table></td>
          </tr>
        </table>

        

</asp:Content>

