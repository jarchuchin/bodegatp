<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="olvido.aspx.vb" Inherits="olvido" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">



     <div style="width:450px;margin:0 auto; min-height:300px;" >

 


		<div class="form-signin" runat="server" >
			<h2 class="form-signin-heading">Recuperación de contraseña</h2>



            <label for="inputEmail" class="sr-only">Coloca tu correo electrónico</label>
            <asp:TextBox id="txtlogin" runat="server" ValidationGroup="login" cssclass="form-control" ></asp:TextBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtlogin" ValidationGroup="login" ErrorMessage="Escribe el correo electrónico">*</asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
			<cc1:TextBoxWatermarkExtender ID="txtlogin_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtlogin" WatermarkText="Correo electrónico"></cc1:TextBoxWatermarkExtender>
            <div style="height:5px;"></div>

            <div style="height:10px;"></div>
            <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar contraseña" ValidationGroup="login"  CssClass="btn btn-warning"  />

             <div style="height:10px;"></div>
            <asp:Label id="lblMensajeerror" runat="server" forecolor="Red" Visible="False" >No existe una cuenta asociada a este correo.</asp:Label>

        </div>


    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

