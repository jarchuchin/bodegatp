<%@ Page Title="Subir comprobante" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="SubirComprobante.aspx.vb" Inherits="sec_SubirComprobante" %>


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
         <h2> Subir comprobante de pago proyecto: #&nbsp; <asp:Literal ID="litNumOrden" runat="server" /></h2>
    

          
        
      <div style="height:2px;"></div>      
      <div class="row">

           <div class="col-lg-8">
                    <%-- <div style="border:solid; border-color:purple; border-bottom-width:1px; padding:10px;">

                      <strong>MIS DATOS DE FACTURACIÓN</strong><br />
                    <div style="height:10px;">&nbsp;</div>
                    <div  style="height:1px; background-color:#dcdcdc">   </div>
                    <div  style="height:2px; background-color:#773fa9; width:110px">   </div>
                    <div style="height:10px;">&nbsp;</div>--%>

                    
                             <table style="width: 100%" >
            <tr>
                <td style="width: 169px">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblDatosactualizados" runat="server" ForeColor="Red" 
                        Text="Saved:" Visible="false"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 169px; text-align: left;">
                   <asp:Label ID="Label7" runat="server" Text="Proyecto" Font-Bold="True"></asp:Label>
                </td>
                <td style="height:30px">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblProyecto" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
              <tr>
                  <td style="width: 169px; text-align: left;">
                      <strong>Tipo del deposito</strong></td>
                  <td style="padding:3px;">
                      <asp:DropDownList ID="drptipodeposito" runat="server"  CssClass="form-control" Width="200px">
                        <asp:ListItem Value="Efectivo" Text="Efectivo" ></asp:ListItem>
                        <asp:ListItem Value="Transferencia" Text="Transferencia" Selected="True" ></asp:ListItem>
                        <asp:ListItem Value="Cheque salvo buen cobro" Text="Cheque salvo buen cobro" ></asp:ListItem>
                      </asp:DropDownList>
                  </td>
            </tr>
              <tr>
                  <td style="width: 169px; text-align: left;">
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Fecha"></asp:Label>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="txtFecha" ErrorMessage="La fecha es un campo requerido">*</asp:RequiredFieldValidator>
                      <asp:CustomValidator ID="CustomValidator1" runat="server" 
                          ControlToValidate="txtFecha" 
                          ErrorMessage="La fecha no esta en el formato apropiado dd/mm/aaaa">*</asp:CustomValidator>
                  </td>
                   <td style="padding:3px;">
                      <asp:TextBox ID="txtFecha" runat="server"  CssClass="form-control" Width="100px"></asp:TextBox>
                      <cc1:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                          Enabled="True" TargetControlID="txtFecha">
                      </cc1:CalendarExtender>
                  </td>
            </tr>
            <tr>
                <td style="width: 169px; text-align: left;">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Cliente"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtFecha" ErrorMessage="El cliente es un campo requerido">*</asp:RequiredFieldValidator>
                </td>
                 <td style="padding:3px;">
                    <asp:TextBox ID="txtcliente" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 169px; text-align: left;">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Sucursal"></asp:Label>
                </td>
                <td style="padding:3px;">
                    <asp:DropDownList ID="drpsucursales" runat="server"   CssClass="form-control" 
                        Width="100px">
                       
                        <asp:ListItem>Monterrey</asp:ListItem>
                         <asp:ListItem>DF</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 169px; text-align: left;">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" 
                        Text="Autorización o referencia bancaria"></asp:Label>
                      <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtReferencia" ErrorMessage="El numero de referencia ya ha sido agregado al sistema">*</asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReferencia" ErrorMessage="El numero de referencia es un campo requerido">*</asp:RequiredFieldValidator>
                </td>
                 <td style="padding:3px;">
                    <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control"
                        Width="300px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width: 169px; text-align: left;">
                  <asp:Label ID="Label4" runat="server" Text="Monto" Font-Bold="True"></asp:Label>
                
                    <asp:RangeValidator ID="RangeValidator2" runat="server" 
                        ControlToValidate="txtmonto" 
                        ErrorMessage="El valor del monto no esta en el formato apropiado" 
                        MaximumValue="10000000" MinimumValue="0" Type="Currency">*</asp:RangeValidator>
                </td>
                <td style="padding:3px;">
                    <asp:TextBox ID="txtmonto" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
          
          
            
           
            <tr>
                <td style="width: 169px; text-align: left;">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Imagen o comprobante"></asp:Label>
                </td>
                <td style="padding:3px;">
                    <asp:FileUpload ID="FileUploadImagen" runat="server" CssClass="form-control" Width="300px" />
                </td>
            </tr>
          
          
            
           
            <tr>
                <td style="width: 169px; text-align: left;">
                    &nbsp;</td>
                <td style="padding:3px;">
                    <asp:Image ID="imgComprobante" runat="server" Height="100px" />
                    <br />
                    <asp:HyperLink ID="lnkComprobante" runat="server">Descargar comprobante</asp:HyperLink>
                </td>
            </tr>
          
          
            
           
        </table>

                             <div style="height:20px;"></div> 

                    <div class="text-center" style="padding:10px;">
 <asp:Button ID="btnGrabar" runat="server" Text="Grabar"   CssClass="btn btn-success btn-sm"/>
                &nbsp;<asp:Button ID="btnBorrar" runat="server" Text="Borrar" Visible="False" 
                         CssClass="btn btn-danger btn-sm" CausesValidation="False" />
                    <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                        ConfirmText="Deseas borrar el deposito de este proyecto?" Enabled="True" 
                        TargetControlID="btnBorrar">
                    </cc1:ConfirmButtonExtender>
                    &nbsp;<asp:Button ID="btnRegresar" runat="server"  CssClass="btn btn-default btn-sm" Text="Regresar" 
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

