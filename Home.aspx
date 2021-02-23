<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" %>

<%@ Register src="controles/DisplayCategoriesHome.ascx" tagname="DisplayCategoriesHome" tagprefix="uc2" %>
<%@ Register src="controles/DisplayAnunciosHome.ascx" tagname="DisplayAnunciosHome" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<uc1:DisplayAnunciosHome ID="DisplayAnunciosHome1" runat="server" />

	<div style="height:10px;"></div>

	<uc2:DisplayCategoriesHome id="DisplayCategoriesHome1" runat="server" />
</asp:Content>

