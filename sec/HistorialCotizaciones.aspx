<%@ Page   Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="HistorialCotizaciones.aspx.vb" Inherits="sec_HistorialCotizaciones" %>
<%@ Register src="../controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>
<%@ Register src="../controles/MenuMisOpciones.ascx" tagname="MenuMisOpciones" tagprefix="uc6" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

       <div class="col-md-2  hidden-sm hidden-xs menu">
	       		<uc6:MenuMisOpciones ID="MenuMisOpciones1" runat="server" />

    </div>

     <div class="col-md-10 main">
    
    

           


	<h1>Mis proyectos</h1>
          
          

            
    <asp:GridView ID="gvOrdenes" runat="server" AllowPaging="True"  Font-Size="11px" CssClass="table"
        AllowSorting="True" AutoGenerateColumns="False" 
        PageSize="130" Width="100%" GridLines="None" >
        <HeaderStyle   Font-Size="13px" Height="20px"/>

        <Columns>
            <asp:TemplateField HeaderText="No.">

                <ItemStyle HorizontalAlign="Center" Width="60" />
                <ItemTemplate>
                    <asp:HyperLink ID="lnkOrden" runat="server"  CssClass="link-purple"
                        NavigateUrl='<%# "~/sec/verCompras.aspx?idOrden=" & Eval("idOrden")  & "&idIdioma=1" %>' Text='<%# Eval("idOrden") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="ProyectoEnTramiteFecha" DataFormatString="{0:d}"  
                HeaderText="Fecha" HtmlEncode="false"  >
                <ItemStyle HorizontalAlign="Center" CssClass="txt-black-11"/>
                
            <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Nombre del Cliente" >
                <ItemTemplate>
                    <asp:Label ID="lblFullName" runat="server" Text='<%# Eval("NombreF") %>'  /><br />
                     <asp:Label ID="lblrfc" runat="server" Text='<%# Eval("RFC")%>' ForeColor="Gray" Font-Size="11px"  />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Asesor">
                <ItemTemplate>
                    <asp:Label ID="lblAsigned" runat="server" CssClass="txt-black-11"
                        Text='<%# getAsignado(Eval("tempid")) %>' />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
           <%-- <asp:TemplateField HeaderText="Status"   >
                <ItemTemplate >
                    <asp:Label ID="lblStatus" CssClass="txt-black-11" runat="server" Text='<%# Eval("status") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  CssClass="txt-black-11" />
                <HeaderStyle Width="90px"  />
            </asp:TemplateField>--%>
          
            <asp:BoundField DataField="total" DataFormatString="{0:C}" HeaderText="Total" 
                HtmlEncode="false"  >
            <HeaderStyle Width="130px" />
            <ItemStyle HorizontalAlign="Right"  Font-Bold="true" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
            <asp:Label ID ="lblNoData" runat="server" 
                    Text="No existen cotizaciones relacionadas con este usuario" Visible="False" 
                    Font-Bold="True" Font-Size="X-Small" />
<asp:HiddenField ID="hiddenSortExpression" runat="server" />
				<asp:HiddenField ID="hiddenSortDirection" runat="server" />
            



            </div>


</asp:Content>
