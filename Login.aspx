<%@ Page Title="Login" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
       <div style="width:350px;margin:0 auto; min-height:300px;" >

 
        <div style="height:50px;"></div>
        <asp:Panel ID="p" runat="server" DefaultButton="btnLogin">
		<div class="form-signin" runat="server" >
			<h2 class="form-signin-heading">Ingreso al sistema</h2>
            <label for="inputEmail" class="sr-only">Direccion de correo</label>
			<asp:TextBox id="txtlogin" runat="server" ValidationGroup="login" cssclass="form-control" ></asp:TextBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtlogin" ValidationGroup="login" ErrorMessage="Escribe el correo electrónico">*</asp:RequiredFieldValidator>
			<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
			<cc1:TextBoxWatermarkExtender ID="txtlogin_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtlogin" WatermarkText="Correo electrónico"></cc1:TextBoxWatermarkExtender>
            <div style="height:5px;"></div>
            <label for="inputPassword" class="sr-only">Contraseña</label>
			<asp:TextBox id="txtpassword" runat="server" TextMode="Password" ValidationGroup="login" cssclass="form-control" AutoPostBack="false" ></asp:TextBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtpassword" ValidationGroup="login" ErrorMessage="Escribe la contraseña">*</asp:RequiredFieldValidator>
			<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2"></cc1:ValidatorCalloutExtender>
			<cc1:TextBoxWatermarkExtender ID="txtpassword_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtpassword" WatermarkText="Contraseña"></cc1:TextBoxWatermarkExtender>

            <div style="height:10px;"></div>
			<%--<div class="enter_login">
				<asp:LinkButton ID="lnkBtnIngresar" runat="server" ValidationGroup="login" Height="41px" Width="137px">Entrar</asp:LinkButton>
			</div>--%>
            <asp:Button ID="btnLogin" runat="server" Text="Entrar" ValidationGroup="login"  CssClass="btn btn-warning" Width="150px" />

             <div style="height:10px;"></div>

            <asp:Label ID="Label1" runat="server" Text="Si aún no tienes cuenta, regístrate "></asp:Label> <asp:HyperLink ID="lnkRegistro" runat="server">aquí</asp:HyperLink>
			<div>
				<asp:Label id="lblMensajeerror" runat="server" forecolor="Red" Visible="False" meta:resourcekey="lblMensajeerrorResource1">El correo o la contraseña no son correctos; verifica tus datos.</asp:Label>
				<asp:ValidationSummary id="ValidationSummary1" runat="server" Width="70%" 
					DisplayMode="List" 
					HeaderText="Ambos campos son requeridos: el login debe ser escrito name@company.com y el password debe tener entre 5 y 12 caracteres" 
					meta:resourcekey="ValidationSummary1Resource1" ValidationGroup="login"></asp:ValidationSummary>
			</div>
            <div style="height:10px;"></div>
            <asp:HyperLink ID="lnkOlvido" runat="server" NavigateUrl="~/olvido.aspx">¿Olvidaste tu contraseña?</asp:HyperLink>
		</div>
        </asp:Panel>
		
                      <div style="height:100px;"></div>


    </div>

	<asp:HiddenField ID="hiddenReturnURL" runat="server" ClientIDMode="Static" Value="" />
	<asp:HiddenField ID="hiddenRed" runat="server" ClientIDMode="Static" Value="" />
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<asp:HiddenField ID="hiddenValidation" runat="server" ClientIDMode="Static" Value="0" />

		</ContentTemplate>
	</asp:UpdatePanel>

	<script type="text/javascript">
		
		
	    function enterText(event) {
	      //  alert(event.keyCode);
	        if (event.keyCode == 13) { // This is pseudo-code, check how to really do it
                alert("asdfasdf");
              //  $("#<%=btnLogin.ClientID %>").click();

                __doPostBack('<%= btnLogin.ClientID %>','')
		    }
		}
		
	</script>



</asp:Content>

