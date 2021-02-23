<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="PreguntasFrecuentes.aspx.vb" Inherits="PreguntasFrecuentes" %>

<%@ Register src="controles/DisplayFAQ.ascx" tagname="DisplayFAQ" tagprefix="uc1" %>
<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

       <div class="col-md-2 menu">
       
	        <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo2" runat="server" />
        </div>


     <div class="col-md-10 main">
		<h1>Preguntas frecuentes</h1>

	        <div class="wrapper faqs">

		        <uc1:DisplayFAQ ID="DisplayFAQ1" runat="server" />
	        </div>

         </div>
</asp:Content>


