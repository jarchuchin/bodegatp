<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayAnunciosPromotions.ascx.vb" Inherits="controles_DisplayAnunciosPromotions" %>
 <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
        <tr>
            <td style=" width: 250px; vertical-align:top;">
    
                <asp:DataList ID="DataList1" runat="server" DataKeyField="idAnuncio" CellPadding="0" CellSpacing="0">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkanuncio1" NavigateUrl='<%# eval("url") %>'  ToolTip='<%# eval("tooltip") %>' runat="server">
                        <asp:Image ID="Image1" runat="server"  ImageUrl='<%# carpetafiles & eval("nombrearchivo") %>' Width="250px" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td style=" width: 10px; vertical-align:top;"><asp:Image ID="asdf" Imageurl="~/images/transp.gif" runat="server" Width="10px" /></td>
            <td style="vertical-align:top;">
             
                <asp:GridView ID="DataList2" runat="server" DataKeyField="idAnuncio" 
                    AutoGenerateColumns="False" AllowPaging="True" GridLines="None" 
                    PageSize="1" ShowHeader="False" CellPadding="0" CellSpacing="0">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                            <asp:HyperLink ID="lnkanuncio1" NavigateUrl='<%# eval("url") %>'  ToolTip='<%# eval("tooltip") %>' runat="server">
                            <asp:Image ID="Image1" runat="server"  ImageUrl='<%# carpetafiles & eval("nombrearchivo") %>' Width="720px" Height="280px" />
                            </asp:HyperLink>
                            
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            
               <div style="height:10px"></div>
               <asp:DataList ID="DataList3" runat="server" DataKeyField="idAnuncio"  
                    RepeatColumns="4" RepeatDirection="Horizontal" BorderStyle="None" CellPadding="0" CellSpacing="0"
                    BorderWidth="0px" >
                    <ItemTemplate>
                         <asp:HyperLink ID="lnkanuncio1" NavigateUrl='<%#eval("url") %>'  ToolTip='<%# eval("tooltip") %>' runat="server">
                        <asp:Image ID="Image1" runat="server"  ImageUrl='<%# carpetafiles & eval("nombrearchivo") %>' Width="180px" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:DataList>
            
            </td>
        </tr>
    </table>