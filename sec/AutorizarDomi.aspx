<%@ Page Title="Autorizar domi" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="AutorizarDomi.aspx.vb" Inherits="sec_AutorizarDomi" %>


<%@ Register src="../controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>
<%@ Register src="../controles/MenuMisOpciones.ascx" tagname="MenuMisOpciones" tagprefix="uc6" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


      <div class="col-md-2  hidden-sm hidden-xs menu">
	       	<%--	<uc6:MenuMisOpciones ID="MenuMisOpciones1" runat="server" />--%>

    </div>

	<div class="col-md-10 main">
         <h2> Autorizar domi del proyecto: #&nbsp; <asp:Literal ID="litNumOrden" runat="server" /></h2>
    

          
        
      <div style="height:2px;"></div>      
      <div class="row">

           <div class="col-lg-8">
                    <%-- <div style="border:solid; border-color:purple; border-bottom-width:1px; padding:10px;">

                      <strong>MIS DATOS DE FACTURACIÓN</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>--%>

                    



               <table style="width:100%">
    <tr>
        <td style="width:300px; vertical-align:top;   text-align:left; ">
            <asp:Image ID="ImageDomi" runat="server" />
            <div style="height:3px;"></div>
            <asp:Image ID="ImageDomi2" runat="server" />
            <div style="height:3px;"></div>
            <asp:Image ID="ImageDomi3" runat="server" />
            <div style="height:15px;"></div>
            <asp:HyperLink ID="lnkVector" runat="server" CssClass="btn-link">Descargar vectores 1</asp:HyperLink>
            <div style="height:3px;"></div>
            <asp:HyperLink ID="lnkVector2" runat="server" CssClass="btn-link">Descargar vectores 2</asp:HyperLink>
            <div style="height:3px;"></div>
            <asp:HyperLink ID="lnkVector3" runat="server" CssClass="btn-link">Descargar vectores 3</asp:HyperLink>
            <div style="height:15px;"></div>
            <div style="width:100%; text-align:left;">
                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Observaciones del vendedor:"></asp:Label><br />
                <asp:Label ID="lblObservacionesvendedor" runat="server"></asp:Label>
             </div>
             <div style="height:15px;"></div>
        </td>
        <td style="vertical-align:top;">
            
        
            <table style="width: 100%">
                <tr>
                    <td style="width: 160px; height: 30px;">
                        <strong>Proyecto</strong></td>
                    <td class="dxmVerticalMenuLargeItemSpacing" style="height: 26px">
                        <asp:Label ID="lblProyecto" runat="server"   ></asp:Label>
                    &nbsp;<asp:Label ID="lblComments" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Fecha</strong></td>
                    <td style="height: 25px">
                        <asp:Label ID="lblProyectoFecha" runat="server" 
                             ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Vendedor</strong></td>
                    <td style="height: 25px">
                        <asp:Label ID="lblVendedor" runat="server" 
                             ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Clave del producto</strong></td>
                    <td style="height: 24px">
                        <asp:Label ID="lblClave" runat="server" 
                             ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Nombre</strong></td>
                    <td style="height: 25px">
                        <asp:Label ID="lblNombre" runat="server" 
                             ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        <strong></strong></td>
                    <td>
            <asp:Image ID="ImagenProducto" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Color</strong></td>
                    <td style="height: 25px">
                        <asp:Label ID="lblColor" runat="server"  
                             ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Logotipo</strong></td>
                    <td>
                        <asp:Label ID="txtLogotipo" runat="server"    ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Ancho</strong></td>
                    <td>
                        <asp:Label ID="txtancho" runat="server"   ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Alto</strong></td>
                    <td>
                        <asp:Label ID="txtAlto" runat="server"   ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Método de impresión</strong></td>
                    <td>
                        <asp:Label ID="txtimpresion" runat="server"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Pantone 1</strong></td>
                    <td>
                        <asp:Label ID="txtPantone1" runat="server"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Pantone 2</strong></td>
                    <td>
                        <asp:Label ID="txtPantone2" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Pantone 3</strong></td>
                    <td>
                        <asp:Label ID="txtPantone3" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Pantone 4</strong></td>
                    <td>
                        <asp:Label ID="txtPantone4" runat="server"  ></asp:Label>
                    </td>
                </tr>
             </table>

            <table style="width: 100%" id="tableAutorizacion" runat="server" visible="false">
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong>Autorización</strong></td>
                    <td>
            <asp:Image ID="imgAutorizacion" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px; height: 30px;">
                        <strong >Autorización fecha</strong></td>
                    <td>
                        <asp:Label ID="lblAutorizacionFecha" runat="server"   
                             ></asp:Label>
                    </td>
                </tr>
            
            </table>

           
            
        
        </td>
    </tr>
    
</table>


 <div style="padding:25px; text-align:center" runat="server" id="panelAutorizar">

            
                 <asp:Label ID="Label2" runat="server" Font-Size="11px"  Text="Al autorizar el domi aceptas las medidas, colores y posición del gráfico en tus promocionales. Los detalles del contrato podrás verlos  en la sección de terminos y condiciones."></asp:Label>


            </div>
                             

                             <div style="height:20px;"></div> 

                    <div class="text-center" style="padding:10px;">
 <asp:Button ID="btnGrabar" runat="server" Text="Autorizar domi"   CssClass="btn  btn-danger btn-sm"/>
                        <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" BehaviorID="btnGrabar_ConfirmButtonExtender" ConfirmText="Al autorizar el domi aceptas las médidas, colores y posición del gráfico en tus promocionales. Los detalles del contrato se tienen en la sección de terminos y condiciones. ¿Deseas continuar?" TargetControlID="btnGrabar">
                        </cc1:ConfirmButtonExtender>
                &nbsp;&nbsp;<asp:Button ID="btnRegresar" runat="server"  CssClass="btn btn-default btn-sm" Text="Regresar" 
                        Visible="true" CausesValidation="False" />

  </div>
                             <div style="height:20px;"></div> 
                       
                    </div>

                        <div style="height:50px;"></div>   



             


       </div>

        </div>

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

