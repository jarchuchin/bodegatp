<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayAnunciosCategories.ascx.vb" Inherits="controles_DisplayAnunciosCategories" %>
 <asp:DataList ID="DataList3" runat="server" DataKeyField="idAnuncio"   HorizontalAlign="Center"
                    RepeatColumns="3" RepeatDirection="Horizontal" BorderStyle="None" CellPadding="0" CellSpacing="0"
                    BorderWidth="0px" >
                    <ItemTemplate>
                         <asp:HyperLink ID="lnkanuncio1" NavigateUrl='<%# eval("url") %>'  ToolTip='<%# eval("tooltip") %>' runat="server">
                        <asp:Image ID="Image1" runat="server"  ImageUrl='<%# carpetafiles & eval("nombrearchivo") %>' Width="155px" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:DataList>