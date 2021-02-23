<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayRandomProductsFull.ascx.vb" Inherits="controles_DisplayRandomProductsFull" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="45" rowspan="3"><asp:Image id="Image5" runat="server" ImageUrl="~/images/transp.gif"  Width="29px" /></td>
                  <td height="70" colspan="6"  style=" vertical-align:top;">
                        <table cellpadding="0" cellspacing="0" border="0"  style=" width:100%; height:70px; ">
                            <tr>
                                <td style="width:100%" >
                                 <asp:Label ID="lblTitulo1" Text="Otros productos sugeridos" runat="server"  class="titulo-categoria"></asp:Label>
                                 <div id="puntosTitulo"></div>
                                 </td>
                            </tr>
                        </table>
                        <!--seccion de productos-->
             <asp:DataList ID="dtproductos" runat="server" RepeatColumns="6" CellPadding="0" DataKeyField="idProducto" RepeatDirection="Horizontal" >
            <ItemStyle VerticalAlign="Top" />
                <ItemTemplate>
                   
           <table cellpadding="0" cellspacing="0" border="0"  style=" width:176px;  vertical-align:top; ">
                <tr>
                    <td style=" width:176px; vertical-align:top; ">
                               <asp:HyperLink ID="HyperLink1" runat="server" Tooltip='<%# getNombre(eval("nombre"), false) %>' NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))   %>'>
                                    <asp:Image ID="Image4" runat="server" imageurl='<%# carpetaFiles & eval("imagen") %>' AlternateText='<%# getNombre(eval("nombre"), false) & " | Articulos Promocionales" %>'   Width="176px" />
                                </asp:HyperLink>
                      </td>
                    <td style=" width:15px; height:15px;"><asp:Image id="Image5" runat="server" ImageUrl="~/images/transp.gif"  Width="15px" /></td>
               </tr>
               <tr>
                    <td style=" width:176px; vertical-align: top ; text-align:left;">
                    <div style="text-align:left;  padding:5px;  ">
                      
                     </div>
                    </td>
                     <td style=" width:15px;"><asp:Image id="Image6" runat="server" ImageUrl="~/images/transp.gif"  Width="15px"  Height="1px" /></td>
                </tr>
               <tr>
                    <td style=" text-align:center; vertical-align:  top  ;"  class="etiqueta-1"> <table width="129" border="0"  cellspacing="0" cellpadding="0">
                    <tr><td style="height:5px;"><asp:Image id="Image2" runat="server" ImageUrl="~/images/transp.gif"   Height ="5px" Width="5px" /></td></tr>
                    <tr>
                      <td  style="text-align:center; height:25px; vertical-align:top;">
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="titulo-producto" NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))  %>' Text='<%# getNombre(eval("nombre")) %>' Tooltip='<%# getNombre(eval("nombre"), false) %>'></asp:HyperLink>
                      </td>
                    </tr>
                    <tr><td style="height:5px;"><asp:Image id="Image3" runat="server" ImageUrl="~/images/transp.gif"   Height ="5px" Width="5px" /></td></tr>
                    <tr>
                      <td class="clave-producto"><asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Clave: " ></asp:Label> <asp:Label ID="Label2"  Font-Bold="true"  runat="server" Font-Size="10px" Text='<%#  getclave(eval("clave"))  %>'></asp:Label></td>
                    </tr>
                       <tr><td style="height:5px;"><asp:Image id="Image8" runat="server" ImageUrl="~/images/transp.gif"   Height ="5px" Width="5px" /></td></tr>
                    <tr>
                      <td align="center"><table border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td valign="bottom" class="txt-black-11"><asp:Label ID="Label5" Font-Bold="true" runat="server" Text="Desde" ></asp:Label>&nbsp;</td>
                            <td class="precio"> <asp:Label ID="Label6"    runat="server"   Text='<%# format(eval("precio"), "c") %>'></asp:Label></td>
                          </tr>
                        </table></td>
                    </tr>
                  </table>
                   
                      </td>
                    <td style=" width:15px; height:15px;"><asp:Image id="Image7" runat="server" ImageUrl="~/images/transp.gif"  Width="15px" /></td>
                </tr>
            </table>
                 <div style="height:15px"></div>
      
                </ItemTemplate>
            </asp:DataList>       
            
            
              <!-- termina seccion de productos-->
            
                  
                  </td>
                  <td width="45" rowspan="3" align="right"><asp:Image id="Image1" runat="server" ImageUrl="~/images/transp.gif"  Width="29px" /></td>
                </tr>
             </table>
           
           
            <div style="height:10px" ></div>

          

