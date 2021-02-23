<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayRandomProducts.ascx.vb" Inherits="controles_DisplayRandomProducts" %>


 <div style="height:10px;"></div>
<div class="divisorHorizontal"></div>

<h3>Productos Sugeridos</h3>

<asp:HyperLink ID="lnkVermas" runat="server" CssClass="pull-right" ImageUrl="~/images/ver-mas2.gif" Visible="false">ver más...</asp:HyperLink>


     


    <div class="row">
         

             <asp:Repeater ID="rptproductos" runat="server">
                 <ItemTemplate>
                     <div class="col-md-3 col-sm-4 col-xs-6 text-center" >
					    <div style="height:15px;"></div>
                        <asp:HyperLink ID="lnkProductoI" runat="server" ClientIDMode="Predictable" Style="cursor:pointer;" NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave"))   %>' Tooltip='<%# getNombre(Eval("nombre"), False) %>'>
                        <asp:Image ID="Image4" runat="server" imageurl='<%# carpetafiles & Eval("imagen") %>' AlternateText='<%# getNombre(Eval("nombre"), False) %>'  height="176px" />
                        </asp:HyperLink>
                        <asp:HiddenField ID="hiddenIdProducto" ClientIDMode="Predictable" runat="server" Value='<%# "Producto.aspx?idProducto=" & Eval("idProducto")%>' />
                         <div style="height:5px;"></div>

                        <div style="height: 50px;">
                        <asp:HyperLink ID="lnkProducto" runat="server" ClientIDMode="Predictable" CssClass="productoElemento"  NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave"))   %>' Text='<%# getNombre(Eval("nombre")) %>' Tooltip='<%# getNombre(Eval("nombre"), False) %>'></asp:HyperLink>
                        </div>
                       


                        <div style="height:3px;"></div>
                       <%-- <asp:Button ID="btnPrecio" runat="server" CssClass="btn btn-default btn-desde" Text='<%# "Desde " & Format(Eval("precio"), "c") %>' />--%>
                        <asp:HyperLink ID="lnkPrecioDesde" runat="server" ClientIDMode="Predictable" CssClass="btn btn-default btn-desde"  NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave"))   %>' Text='<%# "Desde " & Format(Eval("precio"), "c") %>'></asp:HyperLink>

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



<asp:imagebutton ImageUrl="~/images/transp.gif" id="lnkAnterior1"    runat="server"/><asp:imagebutton id="lnkSiguiente1"   ImageUrl="~/images/transp.gif"  runat="server"/>
		<div style="height:15px"></div> 

		<asp:Label ID="lblinicio" runat="server" Visible="False">0</asp:Label>
		<asp:Label ID="lblFin" runat="server" Visible="False">0</asp:Label>
		<asp:Label ID="lblSize" runat="server" Visible="False">4</asp:Label>
		<asp:Label ID="lblArt" runat="server" Visible="False">Artículos encontrados</asp:Label>
		<asp:Label ID="lblcategoria" runat="server" Visible="False"></asp:Label>
