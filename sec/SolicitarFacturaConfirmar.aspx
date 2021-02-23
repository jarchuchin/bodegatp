<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="SolicitarFacturaConfirmar.aspx.vb" Inherits="sec_SolicitarFacturaConfirmar" %>


<%@ Register src="../controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>
<%@ Register src="../controles/MenuMisOpciones.ascx" tagname="MenuMisOpciones" tagprefix="uc6" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


      <div class="col-md-2  hidden-sm hidden-xs menu">
	       		<%--<uc6:MenuMisOpciones ID="MenuMisOpciones1" runat="server" />--%>

    </div>

	<div class="col-md-10 main">
         <h2> Confirmación de solicitud de facturas: #&nbsp; <asp:Literal ID="litNumOrden" runat="server" /></h2>
    

          
        
      <div style="height:2px;"></div>      
      <div class="row">

           <div class="col-lg-8">
                    <%-- <div style="border:solid; border-color:purple; border-bottom-width:1px; padding:10px;">

                      <strong>MIS DATOS DE FACTURACIÓN</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>--%>

                    
            <div style="height:80px;"></div> 

                   <strong>En breve recibiras tus archivos en tu email</strong>       <br /> 
               <strong>O podrás descargarlas del protal</strong> 
               
                             <div style="height:20px;"></div> 
            Código de confirmación: <asp:Label ID="lblCodigo" runat="server" ></asp:Label>
                  <div style="height:220px;"></div> 
               </div>
       </div>

        </div>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

