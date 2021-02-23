<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Direccion.aspx.vb" Inherits="sec_Direccion" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register src="../controles/MenuMisOpciones.ascx" tagname="MenuMisOpciones" tagprefix="uc6" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

       <div class="col-md-2 ">
        <div class="menu">
	       		<uc6:MenuMisOpciones ID="MenuMisOpciones1" runat="server" />
	<%--	    <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo1" runat="server" />--%>
        </div>
    </div>

     <div class="col-md-10 main">
	<h2>Editar dirección para envíos</h2>
          
      <table width="95%" border="0" align="center" cellpadding="0" cellspacing="20">
        <tr>
            <td style="vertical-align :top; ">
            


    <table style="width: 400px" align="left">
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    meta:resourcekey="ValidationSummary1Resource1" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Dirección" 
                    meta:resourcekey="Label1Resource1" Font-Size="12px" Font-Bold="True"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdireccion"
                    ErrorMessage="La direccion es requerida" 
                    meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtdireccion" runat="server" Width="250px" CssClass="form-control" 
                    meta:resourcekey="txtdireccionResource1"  ></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="Ciudad" 
                    meta:resourcekey="Label2Resource1" Font-Size="12px" Font-Bold="True"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtciudad"
                    ErrorMessage="La ciudad es requerida" 
                    meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
            </td>
            <td> 
                <asp:TextBox ID="txtciudad" runat="server" Width="250px" CssClass="form-control" 
                    meta:resourcekey="txtciudadResource1"  ></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="Pais" 
                    meta:resourcekey="Label3Resource1" Font-Size="12px" Font-Bold="True"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpPaises"
                    ErrorMessage="El pais es requerido" 
                    meta:resourcekey="RequiredFieldValidator3Resource1">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:DropDownList ID="drppaises" DataValueField="idPais" DataTextField="Nombre" CssClass="form-control"  Width="250px"
                    runat="server" AutoPostBack="True" meta:resourcekey="drppaisesResource1"  >
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label4" runat="server" Text="Estado" 
                    meta:resourcekey="Label4Resource1" Font-Size="12px" Font-Bold="True"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpEstado"
                    ErrorMessage="El estado es requerido" 
                    meta:resourcekey="RequiredFieldValidator4Resource1">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:DropDownList ID="drpEstado" DataValueField="idEstado"  Width="250px" CssClass="form-control" 
                    DataTextField="Nombre" runat="server" meta:resourcekey="drpEstadoResource1" >
                </asp:DropDownList>
            </td>
        </tr>
        
        
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label5" runat="server" Text="CP" 
                    meta:resourcekey="Label5Resource1" Font-Size="12px" Font-Bold="True"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcp"
                    ErrorMessage="El cp es requerido" 
                    meta:resourcekey="RequiredFieldValidator5Resource1">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtcp" runat="server" Width="250px" CssClass="form-control" 
                    meta:resourcekey="txtcpResource1"  ></asp:TextBox>
            </td>
        </tr>
        
        
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label6" runat="server" Text="Teléfono" 
                    meta:resourcekey="Label6Resource1" Font-Size="12px" Font-Bold="True"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txttelefono"
                    ErrorMessage="El telefono es requerido" 
                    meta:resourcekey="RequiredFieldValidator6Resource1">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txttelefono" runat="server" Width="250px" CssClass="form-control"  
                    meta:resourcekey="txttelefonoResource1"  ></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btngrabar" runat="server" Text="Grabar" 
                    meta:resourcekey="btngrabarResource1" CssClass="btn btn-default"  />
&nbsp; <asp:Button ID="btnborrar" runat="server" Text="Borrar" Visible="False"  CssClass="btn btn-danger"
                    meta:resourcekey="btnborrarResource1" SkinID="botongeneral" />
            </td>
        </tr>
    </table>
    
    
    </td>
    </tr></table>
 

         </div>
</asp:Content>
