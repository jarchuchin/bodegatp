<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayCategoriesHome.ascx.vb" Inherits="controles_DisplayCategoriasHome" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


 <table cellpadding="0" cellspacing="0" border="0" style="background-color:#0C8ECC; width:100%; height:21px;"  >
 <tr>
    <td style=" width: 18px"><asp:Image ID="imgdatos" runat="server" ImageUrl="~/images/transp.gif" Width="18px" Height="21px"  /></td>
    <td><asp:Label ID="Label2" runat="server" Text="Artículos" Font-Bold="true" ForeColor="White" Font-Size="11px"></asp:Label></td>
 </tr>
 </table>
 <div >
  <asp:Repeater ID="rptcategos2"  runat="server">
    <HeaderTemplate>
    <table style="width:100%; height:200px; background-color:#EBF7C1;">
    <tr>
    </HeaderTemplate>
    <ItemTemplate>
    <td style="width:181px; vertical-align:top;">
     <asp:Panel ID="Panel2" runat="server" CssClass="accordionHeader"> 
            <div style="cursor: pointer; vertical-align: middle">
                <table cellpadding="0" cellspacing="0" border="0" style=" width:100%; height:17px;"  >
                         <tr>
                            <td style=" width :17px"><asp:Image ID="imgflechita" runat="server" ImageUrl="~/images/flecha01.jpg" Width="17px"  /></td>
                            <td><asp:Label ID="lblcategoria" runat="server" Text='<%# eval("Nombre") %>' ></asp:Label></td>
                         </tr>
                 </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server"    Height="0px">
            <div class="accordionContentWhite">
                <asp:DataList ID="dtlCategos" DataSource='<%# getCategos(cint(eval("idCategoria"))) %>' runat="server" Width="100%">
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
        </asp:Panel>
        <div style="height:2px"></div>
   
        <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender0" runat="Server"
            TargetControlID="Panel1"
            ExpandControlID="Panel2"
            CollapseControlID="Panel2" 
            Collapsed="false"
            TextLabelID="lblcategoria"
            ImageControlID="imgflechita"    
            ExpandedText='<%# eval("Nombre") %>'
             CollapsedText='<%# eval("Nombre") %>'
            ExpandedImage="~/images/flecha02.jpg"
            CollapsedImage="~/images/flecha01.jpg"
            SuppressPostBack="true"
            SkinID="CollapsiblePanelDemo" />
            
    
    </td>
    </ItemTemplate>
    <FooterTemplate>
    </tr>
    </table>
    </FooterTemplate>
 </asp:Repeater>
 
 

 </div>           
            
            

 