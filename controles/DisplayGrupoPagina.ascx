<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayGrupoPagina.ascx.vb" Inherits="controles_DisplayGrupoPagina" %>


<h2>
	<asp:Label ID="lblNombreCatego" runat="server"></asp:Label>
</h2>



		<div style="height:10px"></div>
		<table style="width:100%;" >
		<tr>
			<td>

<table style="width:100%;">
		<tr>
			<td>
				<asp:DropDownList ID="drpOrdernar" runat="server" Font-Size="11px" AutoPostBack="True" Height="27px">
					<asp:ListItem Value="Nombre">Nombre</asp:ListItem>
					<asp:ListItem Value="Precio">Precio</asp:ListItem>
					<asp:ListItem Value="idProducto">Clave</asp:ListItem>
				</asp:DropDownList>
				<asp:DropDownList ID="drpPrecios" runat="server" Font-Size="11px" AutoPostBack="True" Height="27px">
					<asp:ListItem Value="">Rangos de precios</asp:ListItem>
					<asp:ListItem Value="0-5">Menos de $5</asp:ListItem>
					<asp:ListItem Value="5-10">$5 a $10</asp:ListItem>
					<asp:ListItem Value="10-25">$10 a $25</asp:ListItem>
					<asp:ListItem Value="25-50">$25 a $50</asp:ListItem>
					<asp:ListItem Value="50-100">$50 a $100</asp:ListItem>
					<asp:ListItem Value="100-300">$100 a $300</asp:ListItem>
					<asp:ListItem Value="300-10000">$300 o más</asp:ListItem>
				</asp:DropDownList>
			</td>
		</tr>
		</table>

			</td>
			<td style="width:200px; text-align:right;"><asp:Label ID="lblArticulos" runat="server" Font-Bold="true" CssClass="txt-gray2" Text="Artículos encontrados"></asp:Label></td>
		</tr>
		</table>


		

		<div style="height:20px;"></div>
	
 <div class="row">
         

             <asp:Repeater ID="rptproductos" runat="server">
                 <ItemTemplate>
                     <div class="col-md-3 col-sm-4 col-xs-6 text-center" >
					    <div style="height:15px;"></div>
                        <asp:HyperLink ID="lnkProductoI" runat="server" ClientIDMode="Predictable" Style="cursor:pointer;" NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave")) & "?idc=" & categoria  %>' Tooltip='<%# getNombre(Eval("nombre"), False) %>'>
                        <asp:Image ID="Image4" runat="server" imageurl='<%# carpetafiles & Eval("imagen") %>' AlternateText='<%# getNombre(Eval("nombre"), False) %>'  height="176px" />
                        </asp:HyperLink>
                        <asp:HiddenField ID="hiddenIdProducto" ClientIDMode="Predictable" runat="server" Value='<%# "Producto.aspx?idProducto=" & Eval("idProducto")%>' />
                         <div style="height:5px;"></div>

                        <div style="height: 50px;">
                        <asp:HyperLink ID="lnkProducto" runat="server" ClientIDMode="Predictable" CssClass="productoElemento"  NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave")) & "?idc=" & categoria  %>' Text='<%# getNombre(Eval("nombre")) %>' Tooltip='<%# getNombre(Eval("nombre"), False) %>'></asp:HyperLink>
                        </div>
                       


                        <div style="height:3px;"></div>
                       <%-- <asp:Button ID="btnPrecio" runat="server" CssClass="btn btn-default btn-desde" Text='<%# "Desde " & Format(Eval("precio"), "c") %>' />--%>
                        <asp:HyperLink ID="lnkPrecioDesde" runat="server" ClientIDMode="Predictable" CssClass="btn btn-default btn-desde"  NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave")) & "?idc=" & categoria  %>' Text='<%# "Desde " & Format(Eval("precio"), "c") %>'></asp:HyperLink>

                        <%--<div style="height:3px;"></div>
                        <asp:Label ID="Label5" runat="server" Text="Desde " cssclass="desde"></asp:Label>
                        
                        <asp:Label ID="Label6" runat="server" Text='<%# format(eval("precio"), "c") %>' cssclass="desde"></asp:Label>--%>
                        <div style="height:3px;"></div>
                        <asp:Label ID="Label1" runat="server" Text="Clave: " CssClass="txt-gray2"></asp:Label>
                         <asp:Label ID="Label2"   runat="server"  Text='<%# getclave(Eval("clave"), Eval("idProducto"))%>' CssClass="txt-gray2"></asp:Label>
                     <div style="height:15px;"></div>
                     </div>
                 </ItemTemplate>
             </asp:Repeater>



    </div>



           
<%--<div style="height:10px"></div>
 <table border="0" align="center" cellpadding="0" cellspacing="10">
<tr>
	<td><asp:imagebutton id="lnkAnterior22" ImageUrl="~/images/images02/btn_backA.gif" runat="server"></asp:imagebutton></td>
	<td>&nbsp;</td>
	<td>&nbsp;</td>
	<td><asp:imagebutton id="lnkSiguiente22" ImageUrl="~/images/images02/btn_nextA.gif"  runat="server"></asp:imagebutton></td>
</tr>
</table>--%>

<div style="height:10px"></div>
<div style="padding:15px;">
    <asp:Label ID="lbltagstitle" runat="server" Font-Size="10px"  ForeColor="#cccccc"></asp:Label>
</div>

<asp:Label ID="lblinicio" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblFin" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblSize" runat="server" Visible="False">35</asp:Label>
<asp:Label ID="lblArt" runat="server" Visible="False">Artículos encontrados</asp:Label>
<asp:Label ID="lblcategoria" runat="server" Visible="False"></asp:Label>
<asp:Label ID="lbltags" runat="server" Visible="False"></asp:Label>
