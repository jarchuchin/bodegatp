<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayProductosSugeridos.ascx.vb" Inherits="controles_DisplayProductosSugeridos" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>

		<asp:ListView ID="listViewRelacionados" runat="server" GroupItemCount="4">
			<LayoutTemplate>
				<div id="divProductos" runat="server" class="articulos_vistos">
					<h3>Articulos relacionado sdfasdfsssssssssssssssssssssssssss</h3>
					<ul id="groupPlaceholder" runat="server"></ul>
				</div>
			</LayoutTemplate>
			<GroupTemplate>
		  <div class="renglonCuadritos" id="itemPlaceHolder" runat="server">  
					
		</div>
			</GroupTemplate>
			<ItemTemplate>
				<div class="item">
					<div class="well cuadroProducto">
                          <div style="height:15px;"></div>
					<asp:HyperLink ID="HyperLink1" runat="server" Tooltip='<%# getNombre(eval("nombre"), false) %>' NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave"))%>'>
						<asp:Image ID="Image4" runat="server" imageurl='<%# carpetaFiles & eval("imagen") %>' AlternateText='<%# getNombre(eval("nombre"), false)  %>' Width="176px" />
					</asp:HyperLink>
					<p class="nombre"><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))  %>' Text='<%# getNombre(eval("nombre")) %>' Tooltip='<%# getNombre(eval("nombre"), false) %>'></asp:HyperLink></p>
					<p class="precio">
						DESDE
						<strong><asp:Label ID="Label6" runat="server" Text='<%# format(eval("precio"), "c") %>'></asp:Label></strong></p>
					<p class="clave"> <asp:Label ID="Label2"   runat="server"  Text='<%# getclave(Eval("clave"), Eval("idProducto"))%>' CssClass="txt-gray2"></asp:Label></p>
					<asp:HiddenField ID="hiddenIdProducto" runat="server" Value='<%# Eval("idProducto")%>' />
				   </div>
				</div>
			</ItemTemplate>
		</asp:ListView>
  
		<asp:Label ID="lblinicio" runat="server" Visible="False">0</asp:Label>
		<asp:Label ID="lblFin" runat="server" Visible="False">0</asp:Label>
		<asp:Label ID="lblSize" runat="server" Visible="False">6</asp:Label>
		<asp:Label ID="lblArt" runat="server" Visible="False">Artículos encontrados</asp:Label>
		<asp:Label ID="lblcategoria" runat="server" Visible="False"></asp:Label>
	</ContentTemplate>
</asp:UpdatePanel>