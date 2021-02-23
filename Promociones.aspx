<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="Promociones.aspx.vb" Inherits="Promociones" %>



<%@ Register src="controles/DisplayAnunciosPromotions.ascx" tagname="DisplayAnunciosPromotions" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

    <uc1:DisplayAnunciosPromotions ID="DisplayAnunciosPromotions1" runat="server" />

</asp:Content>

