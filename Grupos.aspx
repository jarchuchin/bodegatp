<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Grupos.aspx.vb" Inherits="Grupos" %>

<%@ Register src="controles/DisplayGrupoPagina.ascx" tagname="DisplayGrupoPagina" tagprefix="uc1" %>
<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>
<%@ Register src="controles/ProductosRecientes.ascx" tagname="ProductosRecientes" tagprefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    

<div class="col-md-2  hidden-sm hidden-xs menu">
                 
	<uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo1" runat="server" />
            
</div>
  <div class="col-md-10 col-sm-12 col-xs-12">
       <uc1:DisplayGrupoPagina ID="DisplayGrupoPagina1" runat="server" />
    </div>


     <uc6:ProductosRecientes ID="ProductosRecientes1" runat="server" />
</asp:Content>
