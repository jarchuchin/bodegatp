<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="Eventos.aspx.vb" Inherits="Eventos" %>



<%@ Register src="controles/DisplayAnunciosEvents.ascx" tagname="DisplayAnunciosEvents" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    
    <uc1:DisplayAnunciosEvents ID="DisplayAnunciosEvents1" runat="server" />
    
</asp:Content>

