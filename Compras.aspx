<%@ Page Title="Carrito de compras" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Compras.aspx.vb" Inherits="Compras" uiculture="auto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

    <table style="width:95%;">
          <tr>
              <td> <h2>Cotizar Artículos Promocionales</h2></td>
              <td class="text-right preciodesde" >
                  <div style="height:20px;"></div>
                  PASO 1 DE 2

              </td>

          </tr>
    </table>

    <div class="row">
           <div class="col-xs-12">
<asp:Label id="lblmensaje" ForeColor="Red" Visible="false" runat="server" Text="El servicio no puede ser borrado porque la cotización está en proceso"></asp:Label>
		<div class="pasos">
			

			<asp:ListView ID="listViewOrdenDetalle" runat="server" DataKeyNames="idProducto">
				<LayoutTemplate>
                    <div style="height:20px;"></div>
					<table class="paso01">
					<tr>
                        <th style="width:30px; padding-top:15px;"></th>
						<th style="width:50px;  font-weight:bold;">Cant.</th>
						<th style=" font-weight:bold; text-align:left;">Artículo</th>
						<th style="width:100px; font-weight:bold;">Foto</th>
						<th style="width:100px; font-weight:bold;">Clave</th>
						<th style="width:110px; font-weight:bold;">Color</th>
						<th style="width:105px; font-weight:bold;">Precio unitario</th>
						<th style="width:90px; font-weight:bold;">Total</th>
					</tr>
					<tr id="itemPlaceHolder" runat="server"></tr>
					</table>
				</LayoutTemplate>
				<ItemTemplate>
					<tr>
                        <td style="width:30px; text-align:center; padding:0; vertical-align: middle;"><asp:ImageButton ID="imgBorrarOD" runat="server" ImageUrl="~/images/borrarCuadro.png" CommandName="select" /></td>
						<td style="text-align:center; width:50px; ">
							<asp:TextBox id="txtCantidadOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Width="40px" Height="30px" Style="text-align:center;"></asp:TextBox>
							<cc1:ConfirmButtonExtender ID="imgBorrarOD_ConfirmButtonExtender" runat="server" ConfirmText="¿Desea quitar este producto de la cotización?" Enabled="True" TargetControlID="imgBorrarOD"></cc1:ConfirmButtonExtender>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidadOD" ErrorMessage="La cantidad es un campo requerido" Display="None"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
							<asp:RangeValidator id="RangeValidator1" runat="server" ControlToValidate="txtCantidadOD" Type="Integer" MaximumValue="50000" MinimumValue='<%# getventaminima(CInt(Eval("idProducto"))) %>' ErrorMessage="No se puede seleccionar esa cantidad de productos" Display="None"></asp:RangeValidator>
							<cc1:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RangeValidator1"></cc1:ValidatorCalloutExtender>
						</td>
						<td style="text-align:left;"><asp:HyperLink ID="lnknombreOD" runat="server" Text='<%# getNombre(CInt(Eval("idProducto"))) %>' NavigateUrl='<%# "~/Producto.aspx?idProducto=" & Eval("idProducto") %>' /></td>
						<td>
							<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Producto.aspx?idProducto=" & Eval("idProducto") %>'>
								<asp:Image ID="imgFotoOD" runat="server" Width="50px" ImageUrl='<%# getFoto(CInt(Eval("idProducto"))) %>' />
							</asp:HyperLink>
						</td>
						<td><asp:Label id="lblClaveOD" Font-Size="10px" runat="server" Text='<%# getClave(CInt(Eval("idProducto"))) %>'></asp:Label></td>
						<td><asp:Label id="lblColorOD" runat="server" Text='<%# GetColor(Eval("color")) %>'></asp:Label></td>
						<td style="text-align:right;"><asp:Label id="lblCostoUnitarioOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Costounitario", "{0:c}") %>'></asp:Label></td>
						<td style="text-align:right;"><asp:Label id="lblCostoTotalOD" runat="server" Text='<%#Format(Eval("costoFinal") * Eval("cantidad"), "c") %>' ></asp:Label></td>
					</tr>
				</ItemTemplate>
			</asp:ListView>
          
          
            

		
			
		
                </div>
           </div>
    </div>
   

      <div style="height:20px;"></div>

    <div class="row">
        <div class="col-md-4 col-xs-12">

              <asp:Image ID="Image1" runat="server" ImageUrl="~/images/botonrefrescar.png" /> <asp:LinkButton id="btnActualizar" runat="server"  CssClass="ligaRefrescar"  Text="Actualizar Cantidad" />


        </div>
        <div class="col-md-4 col-xs-12 text-right">
            
           
			
			

        </div>
        <div class="col-md-4 col-xs-12"> 
            
            <table style="width:100%; font-size:14px; font-weight:bold; padding-right:20px; ">
                    <tr>
                        <td style="text-align:right; height:35px;">	Subtotal:</td>
                        <td style="text-align:right;  width: 100px;"><asp:label id="lblsubtotalgeneral" runat="server"></asp:label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;height:35px; ">IVA:</td>
                        <td style="text-align:right; width: 100px;"><asp:label id="lblImpuesto" runat="server"></asp:label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;height:35px; ">Total:</td>
                        <td style="text-align:right; width: 100px;"><asp:label id="lblTotal" runat="server"></asp:label></td>
                    </tr>
                </table>

            <div style="height:20px;"></div>
           
        </div>
    </div>
 <div style="text-align:right">
                <asp:LinkButton id="btnContinuar" runat="server"  CssClass="ligaRefrescar"  Text="Continuar comprando" />
             &nbsp;<asp:button ID="lnkSalir" runat="server"  CssClass="btn  btn-default" Text="Anterior"></asp:button>&nbsp;&nbsp;
            <asp:button ID="lnkBtnSiguiente" runat="server" cssclass="btn btn-warning btn-desde" Text="Continuar Cotización"> </asp:button>
            </div>
    <div style="height:150px;"></div>
   
</asp:Content>