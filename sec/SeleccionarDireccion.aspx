<%@ Page Title="Seleccionar direcciones" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="SeleccionarDireccion.aspx.vb" Inherits="sec_SeleccionarDireccion" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register assembly="ConwayControls" namespace="ConwayControls.Web" tagprefix="ccwc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<h2><asp:Label ID="Label10" CssClass="TituloCaja" runat="server" Text="Direcciones de envío" meta:resourcekey="Label10Resource1"></asp:Label></h2>

<div id="CajaInterna">
<TABLE class="tablaPrincipalInterna" id="Table1" cellSpacing="4" cellPadding="0" align="center" border="0" width="90%">
<tr><td>
    <br />
    <asp:GridView ID="dtlDirecciones" runat="server" AutoGenerateColumns="False" 
        HorizontalAlign="Center" GridLines="None" ShowHeader="False" 
        meta:resourcekey="dtlDireccionesResource1">
        <Columns>
            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                <ItemTemplate>
                    <ccwc:RadioButton ID="rdbOpciones" runat="server" GroupName="radios" 
                        Value='<%# cint(eval("idDireccion")) %>' 
                        meta:resourcekey="rdbOpcionesResource1" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                <ItemStyle  HorizontalAlign="Left"/>
                <ItemTemplate>
                    <asp:Label ID="lbldireccion" Font-Bold="True" runat="server" 
                        Text='<%# eval("direccion") %>' meta:resourcekey="lbldireccionResource1"></asp:Label><br />
                        <asp:Label ID="Label3" runat="server" Text='<%# eval("ciudad") %>' 
                        meta:resourcekey="Label3Resource1"></asp:Label>,
                        &nbsp;<asp:Label ID="Label4" runat="server" 
                        Text='<%# getestado(cint(eval("idEstado"))) %>' 
                        meta:resourcekey="Label4Resource1"></asp:Label><br />
                        <asp:Label ID="Label5" runat="server" 
                        Text='<%# getpais(cint(eval("idPais"))) %>' meta:resourcekey="Label5Resource1"></asp:Label>
                        &nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="True" Text="C.P." 
                        meta:resourcekey="Label7Resource1"></asp:Label>
                        &nbsp;<asp:Label ID="Label6" runat="server" Text='<%# eval("cp") %>' 
                        meta:resourcekey="Label6Resource1"></asp:Label><br />
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Tel." 
                        meta:resourcekey="Label9Resource1"></asp:Label>
                        &nbsp;<asp:Label ID="Label8" runat="server" Text='<%# eval("telefono") %>' 
                        meta:resourcekey="Label8Resource1"></asp:Label><br />
                        <asp:HyperLink ID="lnkeditar" runat="server" 
                        NavigateUrl='<%# "~/sec/Direccion.aspx?idDireccion=" & eval("idDireccion") & "&red=1" %>' 
                        meta:resourcekey="lnkeditarResource1">Editar</asp:HyperLink>
                    
                </ItemTemplate>
            </asp:TemplateField>
        
        </Columns>
    </asp:GridView>
    
    &nbsp;</td>
</tr>
<tr><td style="text-align:center">
     <asp:Label ID="lblmensaje" runat="server" ForeColor="Red" 
         Text="Debes seleccionar una dirección" Visible="False" 
         meta:resourcekey="lblmensajeResource1"></asp:Label>

</td>
</tr>
<tr><td style="text-align:center">
     <asp:LinkButton ID="btnnuevo" runat="server" Text="Agregar dirección" 
         meta:resourcekey="btnnuevoResource1"></asp:LinkButton>&nbsp;&nbsp;
    &nbsp;<asp:Button ID="btnContinuar" runat="server" Text="Continuar" 
         meta:resourcekey="btnContinuarResource1" />

</td>
</tr>
</TABLE>
</div>
    
</asp:Content>

