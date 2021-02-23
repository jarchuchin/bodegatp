<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ProductosRecientes.ascx.vb" Inherits="controles_ProductosRecientes" %>



<h3>Productos vistos recientemente</h3>

    <div class="row">
         

             <asp:Repeater ID="rptproductos" runat="server">
                 <ItemTemplate>
                     <div class="col-md-3 col-sm-4 col-xs-6 text-center" >
					    <div style="height:15px;"></div>
                        <asp:HyperLink ID="lnkProductoI" runat="server" ClientIDMode="Predictable" Style="cursor:pointer;" NavigateUrl='<%# Eval("link")%>' Tooltip='<%# getNombre(Eval("nombre"), False) %>'>
                        <asp:Image ID="Image1" runat="server" imageurl='<%# carpetafiles & Eval("imagen") %>' AlternateText='<%# getNombre(Eval("nombre"), False) %>'  height="176px" />
                        </asp:HyperLink>
                        <asp:HiddenField ID="hiddenIdProducto" ClientIDMode="Predictable" runat="server" Value='<%# "Producto.aspx?idProducto=" & Eval("idProducto")%>' />
                         <div style="height:5px;"></div>

                        <div style="height: 50px;">
                        <asp:HyperLink ID="HyperLink2" runat="server" ClientIDMode="Predictable" CssClass="productoElemento"  NavigateUrl='<%# Eval("link")%>' Tooltip='<%# getNombre(Eval("nombre"), False) %>'></asp:HyperLink>
                        </div>
                       


                        <div style="height:3px;"></div>
          
                        <asp:HyperLink ID="lnkPrecioDesde" runat="server" ClientIDMode="Predictable" CssClass="btn btn-default btn-desde" NavigateUrl='<%# Eval("link")%>' Text='<%# "Desde " & Format(Eval("precio"), "c") %>'></asp:HyperLink>

                 
                        <div style="height:3px;"></div>
                        <asp:Label ID="Label3" runat="server" Text="Clave: " CssClass="txt-gray2"></asp:Label>
                         <asp:Label ID="Label2"   runat="server"  Text='<%# getclave(Eval("clave"), Eval("idProducto"))%>' CssClass="txt-gray2"></asp:Label>
                    <div style="height:15px;"></div>
                     </div>
                 </ItemTemplate>
             </asp:Repeater>



    </div>
