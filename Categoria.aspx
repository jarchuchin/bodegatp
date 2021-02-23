<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Categoria.aspx.vb" Inherits="Categoria" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register src="controles/DisplayProductosTags.ascx" tagname="DisplayProductosTags" tagprefix="uc2" %>
<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    

        <uc2:DisplayProductosTags ID="DisplayProductosTags1" runat="server" />

</asp:Content>
