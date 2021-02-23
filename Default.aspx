<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default"  uiculture="auto" %>

<%@ Register src="controles/DisplayAnunciosHome.ascx" tagname="DisplayAnunciosHome" tagprefix="uc11" %>
<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>
<%@ Register src="controles/DisplayGrupos.ascx" tagname="DisplayGrupos" tagprefix="uc3" %>
<%@ Register src="controles/ProductosRecientes.ascx" tagname="ProductosRecientes" tagprefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
    <uc11:DisplayAnunciosHome ID="DisplayAnunciosHome1" runat="server" />
    
 </asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
  
<div class="col-md-2  hidden-sm hidden-xs menu" style="border-right-width:1px;border-right-color:#c4c4c4;border-right-style:dashed;">
                 
	<uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo1" runat="server" />
            
</div>
  
<div class="col-md-10 col-sm-12 col-xs-12">


    <uc3:DisplayGrupos ID="DisplayGrupos1" runat="server" />
    <uc6:ProductosRecientes ID="ProductosRecientes1" runat="server" />
</div>




</asp:Content>

