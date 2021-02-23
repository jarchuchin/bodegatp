<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayProductosSearchFull.ascx.vb" Inherits="controles_DisplayProductosSearchFull" %>






  <style type="text/css">
      .style1
      {
          width: 259px;
      }
  </style>





  <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td width="45" rowspan="3"><asp:Image id="Image5" runat="server" ImageUrl="~/images/transp.gif"  Width="29px" /></td>
                  <td height="70" colspan="6"  style=" vertical-align:top;">
                        <table cellpadding="0" cellspacing="0" border="0"  style=" width:100%; height:70px;     ">
                            <tr>
                                <td class="style1" >
                                
                                    &nbsp;&nbsp; &nbsp;</td>
                                  <td ><asp:Label ID="lblArticulos" runat="server"   CssClass="txt-black-11" Text="Artículos encontrados" Font-Size="12px"></asp:Label></td>
         <td style="width:80px"> <asp:Label ID="lblOrdenar" runat="server"  CssClass="txt-black-11" Text="Ordenar por:" Font-Size="12px"></asp:Label></td>
         <td> 
         <asp:DropDownList ID="drpOrdernar" runat="server" Font-Size="11px" 
                 AutoPostBack="True"  >
             <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
                <asp:ListItem Value="Precio">Precio</asp:ListItem>
                <asp:ListItem Value="idProducto">Clave</asp:ListItem>
             
         </asp:DropDownList>
         </td>
         <td style="width:140px">
             <asp:linkbutton id="lnkAnterior1" CssClass="link-purple"   runat="server"><< Anterior</asp:linkbutton>&nbsp;
			  <asp:linkbutton id="lnkSiguiente1" CssClass="link-purple"   runat="server">Siguiente >></asp:linkbutton>
         </td>
                            </tr>
                        </table>
                        <!--seccion de productos-->
             <asp:DataList ID="dtproductos" runat="server" RepeatColumns="6" CellPadding="0" DataKeyField="idProducto" RepeatDirection="Horizontal" >
            <ItemStyle VerticalAlign="Top" />
                <ItemTemplate>
                   
            <table cellpadding="0" cellspacing="0" border="0"  style=" width:130px;  vertical-align:top; ">
                <tr>
                    <td style=" width:129px; vertical-align:top; text-align:center; ">
                               <asp:HyperLink ID="HyperLink1" runat="server" Tooltip='<%# getNombre(eval("nombre"), false) %>' NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))   %>'>
                                    <asp:Image ID="Image4" runat="server" imageurl='<%# carpetaFiles & eval("imagen") %>'  Width="116px" Height="119px"/>
                                </asp:HyperLink>
                      </td>
                    <td style=" width:15px; height:15px;"><asp:Image id="Image5" runat="server" ImageUrl="~/images/transp.gif"  Width="15px" /></td>
               </tr>
               <tr>
                    <td style=" width:129px; vertical-align: top ; text-align:left;">
                    <div style="text-align:left;  padding:5px;  ">
                      
                     </div>
                    </td>
                     <td style=" width:15px;"><asp:Image id="Image6" runat="server" ImageUrl="~/images/transp.gif"  Width="15px" /></td>
                </tr>
               <tr>
                    <td style=" text-align:center; vertical-align: bottom ;"  class="etiqueta-2"> <table width="176px" border="0" cellspacing="0"  cellpadding="0">
                    <tr><td style="height:5px;"><asp:Image id="Image2" runat="server" ImageUrl="~/images/transp.gif"   Height ="5px" Width="5px" /></td></tr>
                    <tr>
                      <td  style="text-align:center; height:30px; vertical-align:top;">
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="titulo-producto" NavigateUrl='<%# "~/Productos/show/" & eval("idProducto") & "/" & getTags(eval("tags"), eval("nombre"), eval("clave"))  %>' Text='<%# getNombre(eval("nombre")) %>' Tooltip='<%# getNombre(eval("nombre"), false) %>'></asp:HyperLink>
                      </td>
                    </tr>
                    <tr><td style="height:5px;"><asp:Image id="Image3" runat="server" ImageUrl="~/images/transp.gif"   Height ="5px" Width="5px" /></td></tr>
                    <tr>
                      <td class="clave-producto"><asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Clave: " ></asp:Label> <asp:Label ID="Label2"  Font-Bold="true"  runat="server"  Text='<%#  getclave(eval("clave"))  %>'></asp:Label></td>
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
                    <tr><td style="height:5px;"><asp:Image id="Image9" runat="server" ImageUrl="~/images/transp.gif"   Height ="10px" Width="5px" /></td></tr>
                     <tr>
                      <td align="center">   <asp:CheckBox ID="chkcomparar" runat="server"   />
                         <asp:LinkButton ID="btncomparar" runat="server" CssClass="link-purple-10" onclick="btncomparar_Click" CommandName="comparar" CommandArgument='<%# eval("idProducto") %>'>Comparar</asp:LinkButton></td>
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

          

 <table border="0" align="center" cellpadding="0" cellspacing="10">
        <tr>
          <td><asp:linkbutton id="lnkAnterior2" CssClass="link-purple"  runat="server">Anterior</asp:linkbutton>
          </td>
          <td>
          <asp:imagebutton id="lnkAnterior22" ImageUrl="~/images/images02/btn_backA.gif"  runat="server"></asp:imagebutton>
          </td>
          <td>
            <asp:imagebutton id="lnkSiguiente22" ImageUrl="~/images/images02/btn_nextA.gif"  runat="server"></asp:imagebutton>
          </td>
          <td><asp:linkbutton id="lnkSiguiente2" CssClass="link-purple"  runat="server">Siguiente</asp:linkbutton></td>
        </tr>
      </table>

&nbsp;
			














<asp:Label ID="lblinicio" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblFin" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblSize" runat="server" Visible="False">35</asp:Label>
<asp:Label ID="lblArt" runat="server" Visible="False">Artículos encontrados</asp:Label>
<asp:Label ID="lblcategoria" runat="server" Visible="False"></asp:Label>
<asp:Label ID="lbltags" runat="server" Visible="False"></asp:Label>


