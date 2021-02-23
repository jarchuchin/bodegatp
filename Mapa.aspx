<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage02.master" AutoEventWireup="false" CodeFile="Mapa.aspx.vb" Inherits="Mapa" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<h2>Mapa del sitio</h2>
<table width="95%" border="0" align="center" cellpadding="0" cellspacing="20">
        
        <tr>
          <td width="73%" align="center" class="txt-black-13"><span class="titulo-categoria">Sitemap</span></td>
        </tr>
        <tr>
          <td valign="top"><table border="0" align="center" cellpadding="0" cellspacing="10">
            <tr>
                <td align="center" class="txt-purple-15"><span class="txt-black-17"><strong>Información de la Compañía</strong></span></td>
                <td align="center" class="txt-purple-15">&nbsp;</td>
              </tr>
              <tr>
                <td align="center"><p><span class="txt-black-13"><a href="http://todopromocional.com/acercade.aspx">Quienes Somos</a><br />
                      <a href="http://todopromocional.com/Contacto.aspx">Contáctanos</a></span></p></td>
                <td align="center">&nbsp;</td>
              </tr>
              <tr>
                <td align="center" class="txt-purple-15"><span class="txt-black-17"><strong>Registro y Cotizaciones</strong></span></td>
                <td align="center">&nbsp;</td>
              </tr>
              <tr>
                <td align="center"><span class="txt-black-13"><a href="#">Registro de Usuarios</a><br />
                      <a href="http://todopromocional.com/Privacidad.aspx">Privacidad</a><br />
                      <a href="http://todopromocional.com/ayuda.aspx">Cláusulas de Compra</a><br />
                    <a href="http://todopromocional.com/sec/HistorialCotizaciones.aspx">Historial de Cotizaciones</a></span></td>
                <td align="center">&nbsp;</td>
              </tr>
            </table>
              <br />
            <table width="100%" border="0" cellspacing="10" cellpadding="0">
              <tr>
                <td align="center" class="txt-black-17"><strong>Hogar y Personales</strong></td>
                <td align="center" class="txt-black-17"><strong>Oficina y Escolares</strong></td>
                <td align="center" class="txt-black-17"><strong>Deporte y Diversión</strong></td>
                <td align="center" class="txt-black-17"><strong>Ropa y Accesorios</strong></td>
                <td align="center" class="txt-purple-15"><strong class="txt-black-17">Electrónicos</strong></td>
              </tr>
              <tr>
                <td align="center" valign="top" >
                
                   <asp:DataList ID="dtlCategorias2" runat="server"  RepeatColumns="1" CellSpacing="5" CellPadding="0" Width="100%">
                                    <ItemStyle  Width="33%" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkNombre" CssClass="link-purple" runat="server" NavigateUrl='<%# "~/categorias/show/" & eval("idCategoria") & "/" & getTags(eval("tags")) %>' Text='<%# eval("Nombre") %>' > </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:DataList>
                
                </td>
                <td align="center" valign="top" >
                
                <asp:DataList ID="dtlCategorias3" runat="server"  RepeatColumns="1" CellSpacing="5" CellPadding="0" Width="100%">
                                    <ItemStyle  Width="50%" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkNombre" CssClass="link-purple" runat="server" NavigateUrl='<%# "~/categorias/show/" & eval("idCategoria") & "/" & getTags(eval("tags")) %>' Text='<%# eval("Nombre") %>' > </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:DataList>
                
                </td>
                <td align="center" valign="top" >
                
                      <asp:DataList ID="dtlCategorias4" runat="server"  RepeatColumns="1" CellSpacing="5" CellPadding="0" Width="100%">
                                    <ItemStyle  Width="50%" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkNombre" CssClass="link-purple" runat="server" NavigateUrl='<%# "~/categorias/show/" & eval("idCategoria") & "/" & getTags(eval("tags")) %>' Text='<%# eval("Nombre") %>' > </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:DataList>
                
                </td>
                <td align="center" valign="top" >
                
                 <asp:DataList ID="dtlCategorias5" runat="server"  RepeatColumns="1" CellSpacing="5" CellPadding="0" Width="100%">
                                    <ItemStyle  Width="50%" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkNombre" CssClass="link-purple" runat="server" NavigateUrl='<%# "~/categorias/show/" & eval("idCategoria") & "/" & getTags(eval("tags")) %>' Text='<%# eval("Nombre") %>' > </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:DataList>
                
                </td>
                <td align="center" valign="top" >
                
                     <asp:DataList ID="dtlCategorias6" runat="server"  RepeatColumns="1" CellSpacing="5" CellPadding="0" Width="100%">
                                    <ItemStyle  Width="100%" VerticalAlign="Top"/>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkNombre" CssClass="link-purple" runat="server" NavigateUrl='<%# "~/categorias/show/" & eval("idCategoria") & "/" & getTags(eval("tags")) %>' Text='<%# eval("Nombre") %>' > </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:DataList>
                
                </td>
              </tr>
            </table>
            <p class="txt-black-13"><br />
            </p>
            <p class="txt-black-13">&nbsp;</p>          </td>
        </tr>
        <tr>
          <td align="center">&nbsp;</td>
        </tr>
      </table>
      &nbsp;
</asp:Content>

