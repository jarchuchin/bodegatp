<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayBannersDefault.ascx.vb" Inherits="controles_DisplayBannersDefault" %>
        <asp:GridView ID="DataList2" runat="server" DataKeyField="idAnuncio" 
                    AutoGenerateColumns="False" AllowPaging="True" GridLines="None" 
                    PageSize="1" ShowHeader="False" CellPadding="0" CellSpacing="0">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                            <asp:HyperLink ID="lnkanuncio1" NavigateUrl='<%# eval("url") %>'  ToolTip='<%# eval("tooltip") %>' runat="server">
                            <asp:Image ID="Image1" runat="server"  ImageUrl='<%# carpetafiles & eval("nombrearchivo") %>' Width="770px" />
                            </asp:HyperLink>
                            
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            
               <div style="height:5px"></div>
               <asp:DataList ID="DataList3" runat="server" DataKeyField="idAnuncio"  
                    RepeatColumns="4" RepeatDirection="Horizontal" BorderStyle="None" CellPadding="0" CellSpacing="0"
                    BorderWidth="0px" >
                    <ItemTemplate>
                         <asp:HyperLink ID="lnkanuncio1" NavigateUrl='<%#eval("url") %>'  ToolTip='<%# eval("tooltip") %>' runat="server">
                        <asp:Image ID="Image1" runat="server"  ImageUrl='<%# carpetafiles & eval("nombrearchivo") %>' Width="192px"  Height="80px" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:DataList>
                <div style="height:5px"></div>