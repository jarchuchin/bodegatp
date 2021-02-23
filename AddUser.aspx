<%@ Page Title="Crear cuenta" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="AddUser.aspx.vb" Inherits="AddUser" meta:resourcekey="PageResource1" uiculture="auto" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
  

         <h2>Registro para clientes nuevos</h2>
        
	    Llena el siguiente formulario:
    <div style="height:20px;"></div>

		<div class="form-horizontal">

			

			 <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Nombre:</label>
                 <div class="col-sm-8">
				<asp:TextBox id="txtNombre" runat="server" ValidationGroup="crear" cssclass="form-control" placeholder="Nombre"></asp:TextBox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server"  ValidationGroup="crear" ControlToValidate="txtNombre" Display="None" ErrorMessage="Escribe tu nombre">*</asp:requiredfieldvalidator>
				<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3"></cc1:ValidatorCalloutExtender>
	
                </div>
            </div>


            <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Apellidos:</label>
                 <div class="col-sm-8">
				<asp:TextBox id="txtapellidos" runat="server" ValidationGroup="crear" cssclass="form-control" placeholder="Apellidos"></asp:TextBox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ValidationGroup="crear" ControlToValidate="txtapellidos" Display="None" ErrorMessage="Escribe tus apellidos">*</asp:requiredfieldvalidator>
				<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5"></cc1:ValidatorCalloutExtender>
		
                </div>
            </div>


            <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Nombre de la empresa:</label>
                 <div class="col-sm-8">
				<asp:TextBox id="txtnombreempresa" runat="server" ValidationGroup="crear" cssclass="form-control" placeholder="Nombre de la empresa"></asp:TextBox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server"  ValidationGroup="crear" ControlToValidate="txtnombreempresa" Display="None" ErrorMessage="Escribe el nombre de tu empresa">*</asp:requiredfieldvalidator>
				<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6"></cc1:ValidatorCalloutExtender>
				
			 </div>
            </div>	
			
            <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Teléfono:</label>
                 <div class="col-sm-8">      
               	<asp:TextBox id="txttelefono" runat="server" ValidationGroup="crear" cssclass="form-control" placeholder="Teléfono (lada) xxx xxxx"></asp:TextBox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server"  Text="*"  ValidationGroup="crear" ControlToValidate="txttelefono" Display="None" ErrorMessage="El teléfono es un campo requerido"></asp:requiredfieldvalidator>
				<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7"></cc1:ValidatorCalloutExtender>
				
			 </div>
            </div>
                     
             <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Nombre:</label>
                 <div class="col-sm-8">	
				<asp:RadioButtonList id="rdbsexo" runat="server" RepeatDirection="Horizontal" >
					<asp:ListItem Value="M" Selected="True">Mujer</asp:ListItem>
					<asp:ListItem Value="H">Hombre</asp:ListItem>
				</asp:RadioButtonList>
             </div>
            </div>


            <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Edad:</label>
                 <div class="col-sm-8">

                <asp:DropDownList id="drpRango" runat="server" DataTextField="rango" ValidationGroup="crear" DataValueField="idedadrango" cssclass="form-control"></asp:DropDownList>
                       <asp:requiredfieldvalidator id="RequiredFieldValidator12" runat="server"  Text="*"  ValidationGroup="crear" ControlToValidate="drpRango" Display="None" ErrorMessage="Debes seleccionar un rango de edad"></asp:requiredfieldvalidator>
				<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator12"></cc1:ValidatorCalloutExtender>
         </div>
            </div>
        <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Estado:</label>
                 <div class="col-sm-8">
                <asp:DropDownList ID="drpEstados" runat="server" DataTextField="Nombre" ValidationGroup="crear" DataValueField="idEstado" cssclass="form-control"></asp:DropDownList>
                <asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server"  Text="*"  ValidationGroup="crear" ControlToValidate="drpEstados" Display="None" ErrorMessage="Debes seleccionar un estado"></asp:requiredfieldvalidator>
				<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator11"></cc1:ValidatorCalloutExtender>
         </div>
            </div>
                     <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Correo electrónico:</label>
                 <div class="col-sm-8">
				<asp:textbox id="txtlogin0" runat="server" ValidationGroup="crear" cssclass="form-control"  autocomplete="off"></asp:textbox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" ValidationGroup="crear" ControlToValidate="txtlogin0" Display="None" Text="*"></asp:requiredfieldvalidator>
				<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8"></cc1:ValidatorCalloutExtender>
				<asp:CustomValidator id="CustomValidator1" runat="server" Display="None" ControlToValidate="txtlogin0"  ValidationGroup="crear" ErrorMessage="El email ya existe en nuestra lista de usuarios">*</asp:CustomValidator>
				<cc1:ValidatorCalloutExtender ID="CustomValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="CustomValidator1"></cc1:ValidatorCalloutExtender>

                     <asp:CustomValidator id="CustomValidator2" runat="server" Display="None" ControlToValidate="txtlogin0"  ValidationGroup="crear" ErrorMessage="El correo electrónico no esta en el fomrato requerido">*</asp:CustomValidator>
				<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="CustomValidator2"></cc1:ValidatorCalloutExtender>
				<cc1:TextBoxWatermarkExtender ID="txtlogin0_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtlogin0" WatermarkText="Ejemplo: nombredeusuario@dominio.com"></cc1:TextBoxWatermarkExtender>
             </div>
            </div>

                     <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Contraseña:</label>
                 <div class="col-sm-8">
				<asp:textbox id="txtpassword0" runat="server" TextMode="Password" ValidationGroup="crear"  cssclass="form-control" PlaceHolder="Contraseña" autocomplete="off" AutoCompleteType="Disabled"></asp:textbox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" ValidationGroup="crear" ControlToValidate="txtpassword0" Display="None" ErrorMessage="Escribe una contraseña">*</asp:requiredfieldvalidator>
				<cc1:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator9"></cc1:ValidatorCalloutExtender>
				<cc1:TextBoxWatermarkExtender ID="txtpassword0_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtpassword0" WatermarkText="Contraseña"></cc1:TextBoxWatermarkExtender>
				 </div>
            </div>
                
                     <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Confirmar contraseña:</label>
                 <div class="col-sm-8">
				<asp:textbox id="txtconfirmar" runat="server" TextMode="Password" ValidationGroup="crear" cssclass="form-control" PlaceHolder="Confirmar contraseña" autocomplete="off" AutoCompleteType="Disabled"></asp:textbox> 
				<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server"  ValidationGroup="crear" ControlToValidate="txtconfirmar" Display="None" ErrorMessage="Escribe de nuevo la contraseña">*</asp:requiredfieldvalidator>
				<cc1:ValidatorCalloutExtender ID="Requiredfieldvalidator4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="Requiredfieldvalidator4"></cc1:ValidatorCalloutExtender>
				<asp:CompareValidator id="CompareValidator1" runat="server" ValidationGroup="crear" ControlToValidate="txtconfirmar" Display="None" ControlToCompare="txtpassword0" ErrorMessage="La confirmación debe ser idéntica a la contraseña">*</asp:CompareValidator>
				<cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="CompareValidator1"></cc1:ValidatorCalloutExtender>
				<cc1:TextBoxWatermarkExtender ID="txtconfirmar_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtconfirmar" WatermarkText="Confirmación de la contraseña"></cc1:TextBoxWatermarkExtender>

                  </div>
            </div>

  <div class="form-group"> 
    <div class="col-sm-offset-2 col-sm-8">
                
                 <asp:Button ID="btnRegistro" runat="server" Text="Registrarme" ValidationGroup="crear"  CssClass="btn btn-warning" Width="150px" />
        <asp:Button ID="btnPrivacidad" runat="server" Text="Privacidad"  CausesValidation="false"  CssClass="btn btn-success" Width="150px" />


				<asp:validationsummary id="ValidationSummary2" runat="server" Width="100%"
					ValidationGroup="crear" CssClass="textoNormal2Red"
					HeaderText="Todos los campos son requeridos"
					DisplayMode="List"></asp:validationsummary>
			
         </div>
            </div>



		</div>
       <div style="height:40px;"></div>
      
</asp:Content>