<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="sec_Home" %>
<%@ Register src="../controles/MenuMisOpciones.ascx" tagname="MenuMisOpciones" tagprefix="uc6" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
        <div class="col-md-2  hidden-sm hidden-xs menu">
	       		<uc6:MenuMisOpciones ID="MenuMisOpciones1" runat="server" />

    </div>

     <div class="col-md-10 main">
    
    

           


	<h1>Mis proyectos</h1>
          
         </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

