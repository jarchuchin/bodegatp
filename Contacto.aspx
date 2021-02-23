<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Contacto.aspx.vb" Inherits="Contacto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    
   

    <div style="width:100%; text-align:center">
         <%-- <h2>Del interior de la República llama: </h2><p ><strong style="font-size:20px;">01 800 7020 505</strong></p>--%>

         <h2>Llama: </h2><p ><strong style="font-size:20px;">
                         
      

             </strong></p>
    </div>
  
    
<%-- <div class="col-md-6">
    
            <div class="oficinas">
                <ul>
                    <li class="df" style="padding:10px;">
                        <h3>Distrito Federal</h3>
                        <p>
                            Isabel La Católica No. 846<br />
                            Col. Postal, Delegación Benito Juárez<br />
                            C.P. 03410 Mexico D.F.
                        </p>
                        <p ><strong>Tel: (55) 3300 2500</strong><br />
                            <strong>Tel: (55) 5579 0028</strong><br />
                            <strong>Tel: (55) 5579 6097</strong><br />
                            <strong>Tel: (55) 5658 6296</strong><br />
                            <strong>Tel: (55) 5696 36160</strong><br />



                        </p>
                       <div style="padding:4px;">   <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d1881.7308991848438!2d-99.1421511!3d19.3924432!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0000000000000000%3A0x0a1aae43bc14a30b!2sTP+TOO+PROMOCIONAL!5e0!3m2!1sen!2scm!4v1414426100502" width="250" height="200" frameborder="0" style="border:0"></iframe></div>
                    </li>
                </ul>
             </div>
</div>--%>
     <div class="col-md-3"></div>
 <div class="col-md-6">
    
            <div class="oficinas">
                <ul>
                    <li class="mty">
                        <h3>Teléfonos de contacto</h3>
                        
                   


                           <%--   <b>Teléfono:</b>--%>
                    <%--  --%>
                      <div style="height:10px;"></div>
                        <a href="tel:+528111764917">Whatsapp: 811176 4917</a>&nbsp;
                         <%--    <div style="height:2px;"></div>
                         <a href="tel:018007020505"  >Llama 01 800 7020505</a>--%>
                             <div style="height:10px;"></div>
                            <a href="tel:5533002500"  >CdMx&nbsp;(55) 3300 2500</a>
                    <div style="height:10px;"></div>
                     <a href="tel:8147385000" >Mty&nbsp;(81) 4738 5000</a>

                         <div style="height:20px;"></div>

                       <%-- <p>
                            Av. Félix U. Gómez 616 Nte.<br />
                            Col. Centro<br />
                            C.P. 64000 Monterrey, N.L.
                        </p>--%>
                     <%--   <p><strong> (81) 4738 5000 </strong></p>--%>
                       <%--Tel:55 56 588 841--%>
                          <div style="padding:4px;"><iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d3595.7635120302903!2d-100.29761099999999!3d25.679133!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8662957db4cd7e01%3A0xc1756c83b1d82360!2sArticulos+Promocionales+TodoPromocional.com!5e0!3m2!1sen!2scm!4v1414426184182" width="250" height="200" frameborder="0" style="border:0"></iframe></div>
                    </li>
                </ul>
             </div>
</div>

     <div class="col-md-3"></div>

<%-- <div class="col-md-4">
    
            <div class="oficinas">
                <ul>
                    <li class="gdl">
                        <h3>Guadalajara</h3>
                        <p></p>
                        <p><strong>Tel: (33) 8995 4802</strong></p>
                    </li>
                </ul>
            </div>
</div>--%>
           <%-- <div class="mapa mapa_df" id="mapa_df">
				
            </div>
            <div class="mapa mapa_mty" id="mapa_mty" style="display:none">
				
            </div>
             <div class="mapa mapa_gdl" id="mapa_gdl" style="display:none">
            </div>--%>

<div style="height:30px;"></div>

 <hr>
     <div style="text-align:center;">
      <h2>Formulario de contacto</h2>
       </div> 
    <div style="height:20px;"></div>

		<div class="form-horizontal" style="padding-top:20px;">


            <div class="form-group">
                 <label class="control-label col-xs-2" for="Nombre" >Dirigido a:</label>
                 <div class="col-xs-6">
					<asp:DropDownList ID="dropDirigidoA" runat="server" cssclass="form-control">
						<asp:ListItem Text="Ventas" Value="ventas"></asp:ListItem>
						<asp:ListItem Text="Compras" Value="compras"></asp:ListItem>
						<asp:ListItem Text="Webmaster" Value="webmaster"></asp:ListItem>
						<asp:ListItem Text="Dirección" Value="direccion"></asp:ListItem>
					</asp:DropDownList>
	
                </div>
            </div>


             <div class="form-group">
                 <label class="control-label col-sm-2" for="Nombre">Nombre:</label>
                 <div class="col-sm-6">
				
                     <asp:textbox id="txtContacto" runat="server"  cssclass="form-control" placeholder="Nombre"></asp:textbox>
					<asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" ControlToValidate="txtContacto" Display="None" ErrorMessage="El nombre es un campo requerido" >*</asp:requiredfieldvalidator>
					<cc1:ValidatorCalloutExtender ID="Requiredfieldvalidator8_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="Requiredfieldvalidator8"></cc1:ValidatorCalloutExtender>
	
                </div>
            </div>


              <div class="form-group">
                 <label class="control-label col-sm-2" for="Correo">Correo:</label>
                 <div class="col-sm-6">
				
                     <asp:textbox id="txtCorreo" runat="server" cssclass="form-control" placeholder="Correo electrónico"></asp:textbox>
					<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtCorreo" Display="None" Text="*" ErrorMessage="El correo es un campo requerido"></asp:requiredfieldvalidator>
                 
					<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="txtCorreo" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="El correo es un campo requerido">*</asp:RegularExpressionValidator>
					<cc1:ValidatorCalloutExtender ID="RegularExpressionValidator1_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2"></cc1:ValidatorCalloutExtender>
                </div>
            </div>


             <div class="form-group">
                 <label class="control-label col-sm-2" for="Telefono">Teléfono:</label>
                 <div class="col-sm-6">
				
                     <asp:textbox id="txtTelefono" runat="server" cssclass="form-control" placeholder="Teléfono (lada) xxx xx xx"></asp:textbox>
					<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ControlToValidate="txtTelefono" Display="None" ErrorMessage="El telefono es un campo requerido">*</asp:requiredfieldvalidator>
					<cc1:ValidatorCalloutExtender ID="Requiredfieldvalidator4_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="Requiredfieldvalidator4"></cc1:ValidatorCalloutExtender>
                </div>
            </div>


                 <div class="form-group">
                 <label class="control-label col-sm-2" for="Celular">Teléfono celular:</label>
                 <div class="col-sm-6">
				
                     <asp:textbox id="txtFax" runat="server" cssclass="form-control" placeholder="Celular xxx xx xx"></asp:textbox>
					<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtFax" Display="None" ErrorMessage="El celular es un campo requerido">*</asp:requiredfieldvalidator>
					<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="Requiredfieldvalidator1"></cc1:ValidatorCalloutExtender>
                </div>
            </div>


                <div class="form-group">
                 <label class="control-label col-sm-2" for="Estados">Estado:</label>
                 <div class="col-sm-6">
				
               
                    <asp:DropDownList ID="drpestados" runat="server" cssclass="form-control" ></asp:DropDownList>
					<asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" Display="None" ControlToValidate="drpestados" ErrorMessage="El estado es un campo requerido">*</asp:requiredfieldvalidator>
					<cc1:ValidatorCalloutExtender ID="Requiredfieldvalidator7_ValidatorCalloutExtender" runat="server" Enabled="True" TargetControlID="Requiredfieldvalidator7"></cc1:ValidatorCalloutExtender>

                </div>
            </div>


                <div class="form-group">
                 <label class="control-label col-sm-2" for="Ciudad">Ciudad:</label>
                 <div class="col-sm-6">
				
                     <asp:textbox id="txtCiudad" runat="server" cssclass="form-control" placeholder="Ciudad"></asp:textbox>
					<asp:requiredfieldvalidator id="Requiredfieldvalidator9" runat="server" ControlToValidate="txtCiudad" Display="None" ErrorMessage="El celular es un campo requerido">*</asp:requiredfieldvalidator>
					<cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="Requiredfieldvalidator9"></cc1:ValidatorCalloutExtender>
                </div>
            </div>


             <div class="form-group">
                 <label class="control-label col-sm-2" for="Ciudad">Motivo:</label>
                 <div class="col-sm-6">
				
                   <asp:TextBox id="txtmotivo" runat="server" Columns="40" TextMode="MultiLine" cssclass="form-control"></asp:TextBox>
				
					<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" Display="None" ControlToValidate="txtmotivo" >*</asp:requiredfieldvalidator>
                </div>
            </div>

          <%--  <div class="form-control">
                <label class="control-label col-sm-2" for="Capcha"></label>
                <div class="col-sm-6">

                    <BotDetect:Captcha ID="ExampleCaptcha" runat="server" />
                    <asp:TextBox ID="CaptchaCodeTextBox" runat="server" />

                </div>
            </div>--%>


             <div class="form-group"> 
                  <label class="control-label col-sm-2" ></label>
    <div class="col-sm-6">
                
                 <asp:Button ID="lnkBtnEnviar" runat="server" Text="Enviar mensaje"   CssClass="btn btn-warning" Width="150px" />


				<asp:validationsummary id="ValidationSummary2" runat="server" Width="100%"
					ValidationGroup="crear" CssClass="textoNormal2Red"
					HeaderText="Todos los campos son requeridos"
					DisplayMode="List"></asp:validationsummary>
			<asp:Label ID="txtComment" runat="server" Font-Size="11pt" ForeColor="Red"></asp:Label>
         </div>
            </div>

     
          
         </div>
    




  



        
</asp:Content>
