<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayProductosSugeridosPorTags.ascx.vb" Inherits="controles_DisplayProductosSugeridosPorTags" %>



<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
  
  dafsadf
  
  
   <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="20" rowspan="3"><asp:imagebutton ImageUrl="~/images/transp.gif" id="lnkAnterior1"    runat="server"/></td>
                  <td   style=" vertical-align:top;">
                  
                   <table cellpadding="0" cellspacing="0" border="0"  style=" width:100%; " class="line" >
                            <tr>
                                <td style="" >
                                 <asp:Label ID="lblNombreCatego" runat="server"   CssClass="title1">Productos Sugeridos</asp:Label>
                                  </td>
                                  <td style="width:200px; text-align:right;"> 
			                     </td>
                            </tr>
                        </table>

              <div style=" text-align :center">
          <asp:DataList ID="dtproductos" runat="server" RepeatColumns="4" CellPadding="0" DataKeyField="idProducto" >
          <ItemStyle VerticalAlign="Top" />
     <ItemTemplate>
        
           
    <div class="cuadroProducto">
    <div style="height:5px;"></div>
   <table cellpadding="0" cellspacing="0" border="0"  style=" width:176px;  vertical-align:top; ">
                <tr>
                    <td style=" width:5px;"><asp:Image id="Image1" runat="server" ImageUrl="~/images/transp.gif"  Width="5px" /></td>
                    <td style=" width:176px; vertical-align:top; text-align:center; ">
                               <asp:HyperLink ID="HyperLink1" runat="server" Tooltip='<%# getNombre(eval("nombre"), false) %>' NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))   %>'>
                                    <asp:Image ID="Image4" runat="server" imageurl='<%# carpetaFiles & eval("imagen") %>' AlternateText='<%# getNombre(eval("nombre"), false) & " | Articulos Promocionales" %>'   Width="176px" />
                                </asp:HyperLink>
                      </td>
                    <td style=" width:5px;"><asp:Image id="Image5" runat="server" ImageUrl="~/images/transp.gif"  Width="5px" /></td>
               </tr>
          
               <tr>
                    <td style=" width:5px;"><asp:Image id="Image2" runat="server" ImageUrl="~/images/transp.gif"  Width="5px" /></td>
                    <td style=" text-align:center; vertical-align: top ;" ><table width="176px" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td  style="text-align:center; height:30px; vertical-align: top ;">
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="link-purple2" NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))  %>' Text='<%# getNombre(eval("nombre")) %>' Tooltip='<%# getNombre(eval("nombre"), false) %>'></asp:HyperLink>
                      </td>
                    </tr>
                    <tr>
                      <td align="center" style=" height:25px;" class="desde"><asp:Label ID="Label5"  runat="server" Text="Desde " ></asp:Label>&nbsp;<asp:Label ID="Label6"    runat="server"   Text='<%# format(eval("precio"), "c") %>'></asp:Label></td>
                    </tr>
                     <tr>
                      <td class="txt-gray2" style=" height:25px;"><asp:Label ID="Label1"   runat="server" Text="clave " ></asp:Label> <asp:Label ID="Label2"   runat="server"  Text='<%#  getclave(eval("clave"))  %>'></asp:Label></td>
                    </tr>
                  
                  </table>
                      </td>
                    <td style=" width:5px;"><asp:Image id="Image3" runat="server" ImageUrl="~/images/transp.gif"  Width="5px" /></td>
                </tr>
            </table>

        </div>
    </ItemTemplate>
</asp:DataList>
</div>

     </td>
                  <td width="20" rowspan="3" align="right"><asp:imagebutton id="lnkSiguiente1"   ImageUrl="~/images/transp.gif"  runat="server"/></td>
                </tr>
             </table>
           
          

<asp:Label ID="lblinicio" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblFin" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblSize" runat="server" Visible="False">4</asp:Label>
<asp:Label ID="lblArt" runat="server" Visible="False">Artículos encontrados</asp:Label>
<asp:Label ID="lblcategoria" runat="server" Visible="False"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>