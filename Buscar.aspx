<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Buscar.aspx.vb" Inherits="Buscar" %>


<%@ Register src="controles/DisplayProductosSearch.ascx" tagname="DisplayProductosSearch" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


        <uc2:DisplayProductosSearch ID="DisplayProductosSearch1" runat="server" />

       
</asp:Content>
