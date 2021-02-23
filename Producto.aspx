<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Producto.aspx.vb" Inherits="Producto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="controles/DisplayProductosSugeridos.ascx" tagname="DisplayProductosSugeridos" tagprefix="uc1" %>
<%@ Register src="controles/DisplayProductosSugeridosPorTags.ascx" tagname="DisplayProductosSugeridosPorTags" tagprefix="uc2" %>
<%@ Register src="controles/DisplayRandomProducts.ascx" tagname="DisplayRandomProducts" tagprefix="uc3" %>
<%@ Register src="controles/DisplayProductosPreguntas.ascx" tagname="DisplayProductosPreguntas" tagprefix="uc4" %>
<%@ Register src="controles/ProductosRecientes.ascx" tagname="ProductosRecientes" tagprefix="uc5" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    <div class="breadProducto">
        <asp:Label ID="Label5" runat="server" Text="ESTÁS EN: " CssClass="descripcionMorada"></asp:Label>
        <asp:HyperLink ID="lnkInicio" runat="server" NavigateUrl="~/Default.aspx" CssClass="breadLink">Inicio</asp:HyperLink>
        <asp:Image ID="imgflechacatego" runat="server" ImageUrl="~/images/flechabread.png" />
        <asp:HyperLink ID="lnkcategoria" runat="server" NavigateUrl="~/Default.aspx" CssClass="breadLink">Categoria</asp:HyperLink>
         <asp:Image ID="Image2" runat="server" ImageUrl="~/images/flechabread.png" />
         <asp:Label ID="lblnombrebread" runat="server" CssClass="breadTexto" ></asp:Label>
    </div>
		<div style="height:10px;"></div>
		<div class="row">
			
			<div class="col-md-5 col-sm-6 col-xs-12 text-center">
				<div class="targetarea diffheight">
					<asp:Image ID="imgProductoZoom" runat="server" AlternateText="zoomable" ClientIDMode="Static" />
				</div>
                
                <div class="imgProductoZoom thumbs">
					<asp:ListView ID="listViewImages" runat="server" DataKeyNames="idProductoFoto">
						<LayoutTemplate>
							<asp:HyperLink ID="itemPlaceHolder" runat="server"></asp:HyperLink>
						</LayoutTemplate>
						<ItemTemplate>
							<asp:HyperLink ID="lnkZoom" runat="server" NavigateUrl='<%# pathMed & Eval("imagen")%>' data-large='<%# pathGde & Eval("imagen")%>' data-title="">
								<asp:Image ID="imgZoom" runat="server" ImageUrl='<%# pathCh & Eval("imagen")%>' AlternateText="" Width="40" />
							</asp:HyperLink>
						</ItemTemplate>
						<ItemSeparatorTemplate>
						</ItemSeparatorTemplate>
					</asp:ListView>
				</div>

                <div style="height:15px; " ></div>
                <asp:label runat="server" text="Las imágenes sólo son ilustrativas" id="sadf" forecolor="gray" ></asp:label>
			</div>
			<div class="col-md-4 col-sm-6 col-xs-12">
               
				<div class="descripcion">
					<h2><asp:Literal ID="lblNombreProducto2" runat="server"></asp:Literal></h2>
             
					<p class="clave" style="width:100%;">CLAVE: <asp:Label ID="lblClaveNueva" runat="server"></asp:Label>,&nbsp;&nbsp;<asp:Label ID="lblClave2" runat="server"></asp:Label>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  PUBLICACIÓN: <asp:Label ID="lblfechaActualizacion" runat="server"></asp:Label></p>
					<asp:Label ID="lblNuevo" runat="server" Font-Bold="true" Font-Size="13px" ForeColor="Red">¡NUEVO!</asp:Label>
                    <p class="precioDesde">
                        <asp:Label ID="lblPreciodesde" runat="server" CssClass="preciodesde" ></asp:Label>
                    </p>
					<div id="divFeatures">
						
                            <asp:Label ID="Label2" runat="server" Text="Descripción: " CssClass="descripcionMorada"></asp:Label><asp:Literal ID="litdescripcion" runat="server"></asp:Literal>
					    <br />
						<asp:Label ID="Label4" runat="server" Text="Especificación: " CssClass="descripcionMorada"></asp:Label><asp:Literal ID="litespecificacion" runat="server"></asp:Literal>
					</div>
			
					<asp:ListView ID="listViewFeatures" runat="server">
						<LayoutTemplate>
							<div id="itemPlaceHolder" runat="server"></div>
						</LayoutTemplate>
						<ItemTemplate>
							<div id="divFeatures" runat="server" Visible='<%# getfeature(CInt(Eval("idCaracteristica"))) %>'>
								<asp:Label ID="Label3" runat="server" Text='<%# Eval("Nombre") & ": " %>' CssClass="descripcionMorada"></asp:Label>
								<asp:Label ID="Labelcaracteristica" runat="server" Text='<%# feature %>'></asp:Label>
							</div>
						</ItemTemplate>
					</asp:ListView>
		
					<asp:ListView ID="listViewColores" runat="server">
						<LayoutTemplate>
							<p>
								 <asp:Label ID="Label2" runat="server" Text="Colores: " CssClass="descripcionMorada"></asp:Label>
								<asp:Literal ID="itemPlaceholder" runat="server"></asp:Literal>
							</p>
						</LayoutTemplate>
						<ItemTemplate>
							<asp:Literal ID="litColor" runat="server" Text='<%#Eval("color") & "," %>'></asp:Literal>
						</ItemTemplate>
					</asp:ListView>
                    <div style="height:10px;"></div>
                    <div class="divisorHorizontal"></div>
            
					<asp:ListView ID="listViewPreciosCon" runat="server" Visible="false">
						<LayoutTemplate>
							<p>
								 <asp:Label ID="Label2" runat="server" Text="Acabados disponibles: " CssClass="descripcionMorada"></asp:Label>
								<span id="itemPlaceHolder" runat="server"></span>
							</p>
						</LayoutTemplate>
						<ItemTemplate>
						<asp:Literal ID="lblAcabado" runat="server" Text='<%#Eval("Nombre") %>'></asp:Literal>
						</ItemTemplate>
						<ItemSeparatorTemplate>&middot;</ItemSeparatorTemplate>
					</asp:ListView>

					<div id="pExistencias" runat="server">
						<asp:Label ID="lblExistenciaEtiqueda" runat="server" Text="Existencias: " Font-Bold="true"></asp:Label>
						<asp:Label ID="lblExistencia" runat="server"></asp:Label>
					</div>
           
					<div style="height:20px;"></div>

					<div id="pExistencias2">
						<asp:Label ID="Label1" runat="server" Text="BUSQUEDAS RELACIONADAS: " CssClass="descripcionMorada"></asp:Label>
                        <div style="height:10px;"></div>
                        <p>
						<asp:Literal ID="litPlaceBuscar" runat="server" ></asp:Literal>
                        </p>
					</div>

					<div style="height:10px;"></div>

					
				</div>
			</div>
			<div class="col-md-3 col-sm-12 col-xs-12">
                <div style="height:15px;"></div>
                <div class="cotizar">

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
				<ContentTemplate>

                <div class="row">
                    <div class="col-md-12 col-sm-6">
                                 <div style="height:5x;"></div>
                                <font class="descripcionMorada"><b>TABLE DE PRECIOS</b></font>
                                <div style="height:10px;"></div>
                        		<div class="calculadora">
								<asp:ListView ID="listViewPrecios" runat="server">
									<LayoutTemplate>
										<table>
											<tr>
												<th  ><font class="descripcionMorada"><b>CANTIDAD</b></font> </th> 
												<th style="width:30px;"></th> 
												<th  ><font class="descripcionMorada"><b>PRECIO C/U</b></font> </th> 
											</tr>
											<tr id="itemPlaceHolder" runat="server"></tr>
										</table>
									</LayoutTemplate>
									<ItemTemplate>
								        <tr>
									        <td><asp:Label ID="lblEscala" runat="server" Text='<%# Eval("escala")%>'></asp:Label></td>
										    <td  class="text-center">=</td>
											<td><asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("precio")%>'></asp:Label></td>
				                        </tr>
									</ItemTemplate>
								</asp:ListView>
                                <div style="height:20px;"></div>
                                <div class="divisorHorizontal hidden-sm"></div>
                            	
                                </div>
                    </div>
                    <div class="col-md-12  col-sm-6">
                              <div class="calculadora">
                                   
                                <div style="height:20px;" class="hidden-sm"></div>
                                <font class="descripcionMorada"><b>CALCULA Y COTIZA</b></font>
                                <div style="height:10px;"></div>
								<table id="tablaCantidad" runat="server">

                              
								<tr class="cajas">
									<td >
                                        <font class="descripcionMorada"><b>ARTÍCULOS</b></font> <br />
										<asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"></asp:TextBox>
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtcantidad" ErrorMessage="La cantidad es un campo requerido" Display="None">*</asp:RequiredFieldValidator>
										<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
										<asp:RangeValidator id="RangeValidator1" runat="server" ControlToValidate="txtcantidad" Type="Integer" MaximumValue="50000" ErrorMessage="No se puede seleccionar esa cantidad de productos" Font-Size="12px" Display="None">*</asp:RangeValidator>
										<cc1:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RangeValidator1"></cc1:ValidatorCalloutExtender>
									</td>
									<td style="padding-left:2px; padding-right:2px; width:36px; vertical-align: bottom"><asp:ImageButton ID="btnCalcular" runat="server"  ImageUrl="~/images/botonActualizar.png"  Height="36px" /></td>
									<td > 
                                        <font class="descripcionMorada"><b>PRECIO</b></font> <br />
                                        <asp:TextBox ID="txtsuma" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox></td>
								</tr>
								<tr class="indicaciones">
									<td colspan="3">No incluye I.V.A., impresión o envío</td>
								</tr>
								</table>
						    </div>


                        	<div id="divSelectColores" runat="server" Visible="False" style="margin-top:10px; text-align:left;">
						        <asp:DropDownList ID="drpcolores" runat="server"  CssClass="form-control center-block"></asp:DropDownList>
					        </div>
                            <div style="height:20px;"></div>
					        <div id="divCotizar" runat="server" style="width:95%;" >
						        <asp:LinkButton ID="lnkBtnCotizar" CssClass="btn btn-default btn-desde" Style="width:100%" runat="server">Continuar cotización</asp:LinkButton>
					        </div>

					        <div id="divConfirmar" runat="server" visible="false">
						        <asp:Label ID="lblConfirmarprecios" runat="server" Text="Favor de confirmar precios y existencias con su ejecutivo" ForeColor="Red"></asp:Label>
					        </div>

                    </div>
                </div>
          
				
				
					

                          
						</ContentTemplate>
					</asp:UpdatePanel>

				


				</div><!--terminadiv cotiza-->




			</div>
	     </div>
		<div class="row" id="divOtrosDatos" runat="server" visible="false">
			<div class="col-lg-12 col-md-12 col-sm-6 col-xs-12">
				<div class="producto">
					<div class="titulo_phone">
						<h2><asp:Label ID="lblNombreProducto" runat="server"></asp:Label></h2>
						<p class="clave"><asp:Label ID="lblClave" runat="server"></asp:Label></p>
					</div>

					<div class="imagen"></div>
					<div class="descripcion"></div>
					<div class="cotizar"></div>
				</div>

			    <div style="height:40px;"></div>
			</div>
		</div>
		<div class="row">
			<div class="col-xs-12">
				<div style="padding-left:20px;padding-right:20px;padding-top:20px;">
					<uc4:DisplayProductosPreguntas ID="DisplayProductosPreguntas1" runat="server" />
				</div>
			</div>
		</div>
    
		<div class="row">
			<div class="col-xs-12">
				<div style="padding-left:20px;padding-right:20px;padding-top:20px;">
					
					<uc3:DisplayRandomProducts ID="DisplayRandomProducts1" runat="server" />
				</div>
			</div>
		</div>

    

    <div class="row">
			<div class="col-xs-12">
				<div style="padding-left:20px;padding-right:20px;padding-top:20px;">
					 <div style="height:10px;"></div>
    <div class="divisorHorizontal"></div>
    <uc5:ProductosRecientes ID="ProductosRecientes1" runat="server" />
				</div>
			</div>
		</div>



	<asp:HiddenField ID="hiddenTags" runat="server" Value="" />
</asp:Content>
