<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayCategoriesFullMap.ascx.vb" Inherits="controles_DisplayCategoriesFullMap" %>
<div style=" background-color:#EBF7C1; ">
<asp:DataList ID="dtlCategos1" runat="server" RepeatColumns="3"   Width="100%"
    RepeatDirection="Horizontal">
    <ItemStyle VerticalAlign="Top" />
    <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="0" style=" width:100%;"  class="accordionHeader"  >
                         <tr>
                            <td style=" width :17px"><asp:Image ID="imgflechita" runat="server" ImageUrl="~/images/flecha02.jpg" Width="17px"  /></td>
                            <td><asp:HyperLink ID="lblcategoria" runat="server" Text='<%# eval("Nombre") %>'  NavigateUrl='<% "verx.aspx?tags=" & eval("tags") %>' ></asp:HyperLink></td>
                         </tr>
                 </table>
                 <div class="accordionContentWhite">
                    <asp:DataList ID="dtlCategos2" DataSource='<%# getCategos(cint(eval("idCategoria"))) %>' runat="server" Width="100%">
                            <ItemTemplate>
                                 <table cellpadding="0" cellspacing="0" border="0" style=" width:100%; height:17px; background-color:#EBF7C1;"  >
                                     <tr>
                                        <td style=" width :17px"><asp:Image ID="imgtransp" runat="server" ImageUrl="~/images/transp.gif" Width="17px"  /></td>
                                        <td>
                                          <asp:HyperLink ID="lnkNombre" CssClass="LigaCategoria" runat="server" NavigateUrl='<%# "~/categorias/show/" & eval("idCategoria") & "/" & getTags(eval("tags")) %>' Text='<%# eval("Nombre") %>' > </asp:HyperLink>
                                        </td>
                                     </tr>
                                 </table>
                            </ItemTemplate>
                     </asp:DataList>
                 </div>
                 
        
    </ItemTemplate>

</asp:DataList>



   <table cellpadding="0" cellspacing="0" border="0" style=" width:100%; width: 160px;" class="accordionHeader"  >
                         <tr>
                            <td style=" width :17px"><asp:Image ID="imgflechita" runat="server" ImageUrl="~/images/flecha02.jpg" Width="17px"  /></td>
                            <td><asp:HyperLink ID="lblcategoria" runat="server" Text="Especiales"  NavigateUrl="#"></asp:HyperLink></td>
                         </tr>
                 </table>
                 <div class="accordionContentWhite">
                    <asp:DataList ID="dtlgrupos" runat="server" Width="180px">
                            <ItemTemplate>
                                 <table cellpadding="0" cellspacing="0" border="0" style=" width:100%; height:17px; background-color:#EBF7C1;"  >
                                     <tr>
                                        <td style=" width :17px"><asp:Image ID="imgtransp" runat="server" ImageUrl="~/images/transp.gif" Width="17px"  /></td>
                                        <td>
                                          <asp:HyperLink ID="lnkNombre" CssClass="LigaCategoria"  runat="server" NavigateUrl="~/default.aspx" Text='<%# eval("Nombre") %>' > </asp:HyperLink>
                                        </td>
                                     </tr>
                                 </table>
                            </ItemTemplate>
                     </asp:DataList>
                 </div>
    
    
    <div style="height:10px"></div>
</div>