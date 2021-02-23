<%@ Page Title="Carrito de compras" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Compras.aspx.vb" Inherits="Compras" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	
   <table style="width:95%;">
          <tr>
              <td> <h2>Cotizar Artículos Promocionales</h2></td>
              <td class="text-right preciodesde" >
                  <div style="height:20px;"></div>
                  PASO 2 DE 2

              </td>

          </tr>
    </table>


	<div class="row">
           <div class="col-xs-12">
<asp:Label id="lblmensaje" ForeColor="Red" Visible="false" runat="server" Text="El servicio no puede ser borrado porque la cotización está en proceso"></asp:Label>
		<div class="pasos">

            
           
           
			<asp:ListView ID="listViewOrdenDetalle" runat="server" DataKeyNames="idProducto">
				<LayoutTemplate>
					<table >
					<tr>
                        <th style="width:30px;   font-weight:bold;"></th>
						<th style="width:50px;  font-weight:bold;">Cant.</th>
						<th style=" font-weight:bold; text-align:left">Artículo</th>
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
                        <td style="width:30px; text-align:center; padding:0; vertical-align: middle;"><asp:ImageButton ID="imgBorrarOD" runat="server" ImageUrl="~/images/borrarCuadro.png" Width="27px" CommandName="select" CommandArgument='<%# Eval("idOrdenDetalle") %>' /></td>
						<td style="text-align:center; width:50px;">
							<asp:TextBox id="txtCantidadOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Cantidad") %>' Width="50px" Height="30px" Style="text-align:center"></asp:TextBox>
							<cc1:ConfirmButtonExtender ID="imgBorrarOD_ConfirmButtonExtender" runat="server" ConfirmText="¿Desea quitar este producto de la cotización?" Enabled="True" TargetControlID="imgBorrarOD"></cc1:ConfirmButtonExtender>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidadOD" ErrorMessage="La cantidad es un campo requerido" Display="None"></asp:RequiredFieldValidator>
							<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
							<asp:RangeValidator id="RangeValidator1" runat="server" ControlToValidate="txtCantidadOD" Type="Integer" MaximumValue="50000" MinimumValue='<%# getventaminima(cint(eval("idProducto"))) %>' ErrorMessage="No se puede seleccionar esa cantidad de productos" Display="None"></asp:RangeValidator>
							<cc1:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RangeValidator1"></cc1:ValidatorCalloutExtender>
                            <asp:Label ID="lblidordendetalle" runat="server" Text='<%#Eval("idOrdenDetalle") %>' visible="false"></asp:Label>
						</td>
						<td style="text-align:left;"><asp:HyperLink ID="lnknombreOD" runat="server" Text='<%# getnombre(cint(eval("idProducto"))) %>' NavigateUrl='<%# "~/Producto.aspx?idProducto=" & eval("idProducto") %>' /></td>
						<td>
							<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Producto.aspx?idProducto=" & eval("idProducto") %>'>
								<asp:Image ID="imgFotoOD" runat="server" Width="50px" ImageUrl='<%# getFoto(cint(eval("idProducto"))) %>' />
							</asp:HyperLink>
						</td>
						<td><asp:Label id="lblClaveOD" Font-Size="10px" runat="server" Text='<%# getclave(cint(eval("idProducto"))) %>'></asp:Label></td>
						<td><asp:Label id="lblColorOD" runat="server" Text='<%# GetColor(eval("color")) %>'></asp:Label></td>
						<td style="text-align:right;"><asp:Label id="lblCostoUnitarioOD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Costounitario", "{0:c}") %>'></asp:Label></td>
						<td style="text-align:right;"><asp:Label id="lblCostoTotalOD" runat="server" Text='<%#  format(eval("costoFinal") * eval("cantidad"), "c") %>' ></asp:Label></td>
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
          
            	<asp:LinkButton ID="lnkBtnActualizar" runat="server"  CssClass="ligaRefrescar" Visible="false">Calcular de nuevo</asp:LinkButton>
                 <br />
				<asp:HyperLink ID="lnkAgregarArticulos" runat="server" CssClass="ligaRefrescar">Agregar artículos</asp:HyperLink>
                  <br />
                <asp:HyperLink ID="lnkAgregarImagen" runat="server" CssClass="ligaRefrescar">Adjuntar logo</asp:HyperLink>
                  <br />
				<asp:HiddenField ID="hiddenAgregarImagen" runat="server" ClientIDMode="Static" Value="" />


			<table>
			<tr>
				<td style="width:50%; vertical-align:top;">
					<asp:DataList ID="dtlImagenes" runat="server" RepeatColumns="4">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
							<ItemTemplate>
								<asp:HyperLink ID="lnkBorrarServicio" runat="server" Text="borrar imagen" ImageUrl="~/images/del.gif" NavigateUrl='<%# "Compras.aspx?idOrden=" & eval("idOrden") &  "&idOrdenImagen=" & eval("idOrdenImagen") & "&act=delimagen" %>' ToolTip="Borrar esta imagen" /><br />
								<asp:HyperLink ID="lnkimagenorden" runat="server" NavigateUrl='<%# carpetafiles & eval("imagen") %>' Target="_blank">
									<asp:Image ID="Image14" ImageUrl='<%# carpetafiles & eval("imagen") %>' runat="server"  Width="100px"/>
								</asp:HyperLink>
							</ItemTemplate>
						</asp:DataList>



			
         
          
				</td>
			</tr>
			</table>

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

         
        </div>
   </div>
       <div style="height:20px;"></div>
        <div class="row">
             <div class="col-md-4 col-xs-12">
               <div style="margin-bottom:10px;">
							<h3>Datos personales</h3>
							[<asp:HyperLink ID="lnkdgEditar" runat="server" Font-Bold="true" CssClass="ligaRefrescar">Editar</asp:HyperLink>]
						</div>
						<div class="datosPersonales">
							<span class="tagDato">Nombre:</span>
							<asp:Label ID="dgNombre" runat="server"></asp:Label>,
							<span class="tagDato">Empresa:</span>
							<asp:Label ID="dgEmpresa" runat="server"></asp:Label>,
							<span class="tagDato">Email:</span>
							<asp:Label ID="dgEmail" runat="server"></asp:Label><br />
							<span class="tagDato">Teléfono:</span>
							<asp:Label ID="dgTelefono" runat="server"></asp:Label>,
							<span class="tagDato">Dirección:</span>
							<asp:Label ID="dgDireccion" runat="server"></asp:Label><br />
							<span class="tagDato">Fecha evento:</span>
							<asp:Label ID="dgfechaevento" runat="server"></asp:Label>,
							<span class="tagDato">Status:</span>
							<asp:Label ID="dgStatus" runat="server"></asp:Label>
						</div>
			
						
             </div>
             <div class="col-md-4 col-xs-12">

<div style="margin-bottom:10px;">
							<h3>Datos de facturación</h3>
							[<asp:HyperLink ID="lnkdfEditar" runat="server" Font-Bold="true" CssClass="ligaRefrescar" >Editar</asp:HyperLink>]
						</div>
						<div class="datosPersonales">
							<span class="tagDato">Empresa</span>
							<asp:Label ID="dfNombre" runat="server"></asp:Label>,
							<span class="tagDato">RFC</span>
							<asp:Label ID="dfRFC" runat="server"></asp:Label>,
							<span class="tagDato">Teléfono</span>
							<asp:Label ID="dfTelefono" runat="server"></asp:Label><br />
							<span class="tagDato">Dirección</span>
							<asp:Label ID="dfDireccion" runat="server"></asp:Label>
						</div>
             </div>
             <div class="col-md-4 col-xs-12 text-right">

	<div style="margin-bottom:15px;">¿Algún comentario adicional?</div>
					<div style="margin-bottom:15px;"><asp:TextBox ID="txtObservaciones" runat="server" Height="92px" TextMode="MultiLine" Width="454px"></asp:TextBox></div>

             </div>

        </div>

					
					

         <div class="row">

		    <div class="col-xs-12">
                  <div style="height:20px;"></div>
                    <div style="text-align:right">
	        <asp:button ID="lnkBtnFinalizar" runat="server" text="Finalizar cotización" CssClass="btn btn-warning btn-desde"></asp:button>
                </div>
		    </div>
		</div>

    <div style="height:150px;"></div>
  
</asp:Content>