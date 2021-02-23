<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Direcciones.aspx.vb" Inherits="sec_Direcciones" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register src="../controles/MenuMisOpciones.ascx" tagname="MenuMisOpciones" tagprefix="uc6" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

     <div class="col-md-2  hidden-sm hidden-xs menu">
	       		<uc6:MenuMisOpciones ID="MenuMisOpciones1" runat="server" />

    </div>

       <div class="col-md-10 main">
    

	

    

            

<div class="clearfix">
    <h2 style="float: left;">Direcciones</h2>
    <asp:Button ID="btnnuevo" runat="server" Text="Agregar dirección"  CssClass="btn  btn-success pull-right" style="float: right; position: relative; top: 10px; right: 10px;"
         />
</div>    


<div style="height:20px;"></div>
   
    <asp:GridView ID="dtlDirecciones" runat="server" AutoGenerateColumns="False" 
        meta:resourcekey="dtlDireccionesResource1" GridLines="None" CssClass="table" ShowHeader="false">
        <Columns>
           
            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
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
                        NavigateUrl='<%# "~/sec/Direccion.aspx?idDireccion=" & eval("idDireccion") %>' 
                        meta:resourcekey="lnkeditarResource1" CssClass="LigaProducto">Editar</asp:HyperLink>
                    <div style=" height:15px;"></div>
                </ItemTemplate>
            </asp:TemplateField>
        
        </Columns>
    </asp:GridView>
    

            
         

    
    </div>
</asp:Content>
