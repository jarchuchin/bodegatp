<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayGrupoMovimiento.ascx.vb" Inherits="controles_DisplayGrupoMovimiento" %>


  
 



<asp:Panel ID="paneltitulo" runat="server" visible="false" >                     
<table  style="width:100%" cellpadding="0" cellspacing="0" border="0" >
    <tr>
        <td> <h3> <asp:Label ID="lblNombreGrupo" runat="server">Productos similares</asp:Label></h3></td>
        <td style="width:50px;">
            <asp:HyperLink ID="lnkVermas" runat="server" >Más...</asp:HyperLink></td>
    </tr>
</table>
</asp:Panel>		
               


        
 <div class="row">
         

             <asp:Repeater ID="rptproductos" runat="server">
                 <ItemTemplate>
                     <div class="col-md-3 col-sm-4 col-xs-6 text-center" >
                        
                        <div style="height:15px;"></div>
                        <asp:HyperLink ID="lnkProductoI" runat="server" ClientIDMode="Predictable" Style="cursor:pointer;" NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))   %>' Tooltip='<%# getNombre(eval("nombre"), false) %>'>
                        <asp:Image ID="Image4" runat="server" imageurl='<%# carpetafiles & Eval("imagen") %>' AlternateText='<%# getNombre(Eval("nombre"), False) %>'  height="176px" />
                        </asp:HyperLink>
                        <asp:HiddenField ID="hiddenIdProducto" ClientIDMode="Predictable" runat="server" Value='<%# "Producto.aspx?idProducto=" & Eval("idProducto")%>' />
                         <div style="height:5px;"></div>

                        <div style="height: 50px;">
                        <asp:HyperLink ID="lnkProducto" runat="server" ClientIDMode="Predictable" CssClass="productoElemento"  NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))   %>' Text='<%# getNombre(eval("nombre")) %>' Tooltip='<%# getNombre(eval("nombre"), false) %>'></asp:HyperLink>
                        </div>
                       


                        <div style="height:3px;"></div>
                       <%-- <asp:Button ID="btnPrecio" runat="server" CssClass="btn btn-default btn-desde" Text='<%# "Desde " & Format(Eval("precio"), "c") %>' />--%>
                         <asp:Label ID="lblPrecioD" runat="server" CssClass="labeldesde"  Text='<%# "Desde " & Format(Eval("precio"), "c") %>'></asp:Label>
                            <div style="height:10px;"></div>
                        <asp:HyperLink ID="lnkPrecioDesde" runat="server" ClientIDMode="Predictable" CssClass="btn btn-default btn-desde"  NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))   %>' Text="Cotizar"></asp:HyperLink>

                        <%--<div style="height:3px;"></div>
                        <asp:Label ID="Label5" runat="server" Text="Desde " cssclass="desde"></asp:Label>
                        
                        <asp:Label ID="Label6" runat="server" Text='<%# format(eval("precio"), "c") %>' cssclass="desde"></asp:Label>--%>
                        <div style="height:2px;"></div>
                        <asp:Label ID="Label1" runat="server" Text="Clave: " CssClass="txt-gray2"></asp:Label>
                        <asp:Label ID="Label2"   runat="server"  Text='<%# getclave(Eval("clave"), Eval("idProducto"))%>' CssClass="txt-gray2"></asp:Label>
                        <div style="height:15px;"></div>
                     </div>
                 </ItemTemplate>
             </asp:Repeater>



    </div>

 
           
<asp:imagebutton ImageUrl="~/images/transp.gif" id="lnkAnterior1"  visible="false"  runat="server"/><asp:imagebutton id="lnkSiguiente1"   ImageUrl="~/images/transp.gif" Visible="false"  runat="server"/>          
          <div style="height:15px"></div>

<asp:Label ID="lblinicio" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblFin" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblSize" runat="server" Visible="False">8</asp:Label>
<asp:Label ID="lblArt" runat="server" Visible="False">Artículos encontrados</asp:Label>
<asp:Label ID="lblcategoria" runat="server" Visible="False"></asp:Label>
