<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Catalogo.aspx.vb" Inherits="Catalogo" %>

<%@ Register src="controles/DisplayGrupos.ascx" tagname="DisplayGrupos" tagprefix="uc3" %>
<%@ Register src="controles/DisplayRandomProducts.ascx" tagname="DisplayRandomProducts" tagprefix="uc2" %>
<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	 <div class="col-md-2 ">
        <div class="menu">
	        <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo2" runat="server" />
        </div>
    </div>
    <div class="col-md-10 main">
        <uc3:DisplayGrupos ID="DisplayGrupos1" runat="server" />
	<uc2:DisplayRandomProducts ID="DisplayRandomProducts1" runat="server" />
    </div>

  
</asp:Content>

