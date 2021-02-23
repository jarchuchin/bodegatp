<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage02.master" AutoEventWireup="false" CodeFile="PreguntasFrecuentasPop.aspx.vb" Inherits="PreguntasFrecuentasPop" %>

<%@ Register src="controles/DisplayFAQ.ascx" tagname="DisplayFAQ" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<div class="wrapper faqs">
		<h2>Preguntas Frecuentes</h2>
		<uc1:DisplayFAQ ID="DisplayFAQ1" runat="server" />
	</div>
</asp:Content>