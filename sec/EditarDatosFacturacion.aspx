<%@ Page Title="Editar datos de facturación" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="EditarDatosFacturacion.aspx.vb" Inherits="sec_EditarDatosFacturacion" %>

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
         <h2> Datos de facturación proyecto: #&nbsp; <asp:Literal ID="litNumOrden" runat="server" /></h2>
    

          
        
      <div style="height:20px;"></div>      
      <div class="row">

           <div class="col-lg-8">
                    <%-- <div style="border:solid; border-color:purple; border-bottom-width:1px; padding:10px;">

                      <strong>MIS DATOS DE FACTURACIÓN</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>--%>

                         <div class="text-center" style="padding:10px;">
                             <table  style="width:100%">
                               
                                 <tr >
                                   
                                     <td class="text-left" style="width: 160px" ><strong >RFC</strong>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRFC" Display="Dynamic" ErrorMessage="El rfc no está en el formato apropiado" ValidationExpression="^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[A-Z|\d]{3})$">*</asp:RegularExpressionValidator>
                                         <cc1:ValidatorCalloutExtender ID="RegularExpressionValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RegularExpressionValidator1">
                                         </cc1:ValidatorCalloutExtender>
                                     </td>
                                       <td style="padding:3px;">
                                         <asp:TextBox ID="txtRFC" runat="server" cssClass="form-control" Width="200px"></asp:TextBox>
                                       
									</td>
                                 </tr>
                                 <tr >
                                     <td class="text-left" style="width: 160px"><strong >Nombre o empresa</strong></td>
                                     <td style="padding:3px;">
                                         <asp:TextBox ID="txtNombreF" runat="server" cssClass="form-control"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr >
                                     <td class="text-left" style="width: 160px" ><strong >Vendedor asignado</strong></td>
                                       <td style="padding:3px; text-align:left">
                                         <asp:Label ID="lblVendedorAsignado" runat="server" CssClass="text-warning" Font-Bold="True" Text="No hay vendedor asignado"></asp:Label>
                                              <input type="hidden" id="hdVendedorAsignado" runat="server" /> 
                                     </td>
                                 </tr>
                                 <tr >
                                     <td class="text-left" style="width: 160px" ><strong >Calle</strong></td>
                                       <td style="padding:3px;">
                                         <asp:TextBox ID="txtDireccionF" runat="server" cssClass="form-control"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr >
                                     <td class="text-left" style="width: 160px"  ><strong  >Número exterior</strong></td>
                                    <td style="padding:3px;">
                                         <asp:TextBox ID="txtNumeroEF" runat="server" cssClass="form-control"  Width="200px"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr  >
                                     <td class="text-left" style="width: 160px"  ><strong  >Número interior</strong></td>
                                       <td style="padding:3px;">
                                         <asp:TextBox ID="txtNumeroIF" runat="server" cssClass="form-control"  Width="200px"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr  >
                                     <td class="text-left" style="width: 160px"  ><strong  >Colonia</strong></td>
                                      <td style="padding:3px;">
                                         <asp:TextBox ID="txtColoniaF" runat="server" cssClass="form-control"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr  >
                                     <td class="text-left" style="width: 160px" ><strong  >Estado</strong>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dropEstadosF" ErrorMessage="Debes seleccionar una opción">*</asp:RequiredFieldValidator>
                                         <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                                         </cc1:ValidatorCalloutExtender>
                                     </td>
                                      <td style="padding:3px;">
                                         <asp:DropDownList ID="dropEstadosF" runat="server" CssClass="form-control"  Width="300px" AutoPostBack="True">
                                         </asp:DropDownList>
                                          	
                                     </td>
                                 </tr>
                                 <tr  >
                                     <td class="text-left" style="width: 160px"  ><strong  >Municipio</strong></td>
                                       <td style="padding:3px;">
                                         <asp:DropDownList ID="drpMunicipiosF" runat="server" CssClass="form-control"   Width="300px">
                                         </asp:DropDownList>
                                           <input type="hidden" id="hdMunicipioF" runat="server" />
                                     </td>
                                 </tr>
                                 <tr  >
                                     <td class="text-left" style="width: 160px"  ><strong  >Localidad</strong></td>
                                      <td style="padding:3px;">
                                         <asp:TextBox ID="txtCiudadF" runat="server" cssClass="form-control"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr  >
                                     <td class="text-left" style="width: 160px"  ><strong  >Referencia</strong></td>
                                      <td style="padding:3px;">
                                         <asp:TextBox ID="txtReferenciaF" runat="server" cssClass="form-control"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr  >
                                     <td class="text-left" style="width: 160px"  ><strong  >Código Postal</strong></td>
                                    <td style="padding:3px;">
                                         <asp:TextBox ID="txtcpF" runat="server" cssClass="form-control" Width="200px"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr  >
                                     <td class="text-left" style="width: 160px"  ><strong  >Teléfono</strong></td>
                                     <td style="padding:3px;">
                                         <asp:TextBox ID="txtTelefonoF" runat="server" cssClass="form-control"  Width="200px"></asp:TextBox>
                                     </td>
                                 </tr>
                            
                                 <tr  >
                                     <td class="text-left" style="width: 160px"  ><strong  >Clave bancaria</strong></td>
                                    <td style="padding:3px;">
                                         <asp:TextBox ID="txtClaveBancaria" runat="server" cssClass="form-control" Width="200px"></asp:TextBox>
                                     </td>
                                 </tr>
                                
                                 <tr >
                                     <td class="text-left" style="width: 160px"  ><strong  >Incluir el siguiente dato al momento de facturar</strong></td>
                                   <td style="padding:3px;">
                                         <asp:TextBox ID="txtincluirobservacionfactura" runat="server" Height="46px" TextMode="MultiLine"  CssClass="form-control"></asp:TextBox>
                                     </td>
                                 </tr>
                               
                             </table>

                             <div style="height:20px;"></div> 


 <asp:Button ID="btnEditar" runat="server" Text="Grabar" CssClass="btn btn-success btn-sm" />
                         &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default btn-sm" />


                             <div style="height:20px;"></div> 
                         </div>
                    </div>

                        <div style="height:50px;"></div>   



             


       </div>
        </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

