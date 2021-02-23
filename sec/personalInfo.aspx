<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="personalInfo.aspx.vb" Inherits="sec_personalInfo" %>


<%@ Register src="../controles/MenuMisOpciones.ascx" tagname="MenuMisOpciones" tagprefix="uc6" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

     <div class="col-md-2  hidden-sm hidden-xs menu">
	       		<uc6:MenuMisOpciones ID="MenuMisOpciones1" runat="server" />

    </div>


     <div class="col-md-10 main">

	<h2>Información personal</h2>



								
												<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
													<TR>
														<TD class="Mediana" style="width: 142px; text-align: left;">
                                                            <asp:Label ID="Label3" runat="server" Text="Email *" 
                                                                meta:resourcekey="Label3Resource1" Font-Bold="True" 
                                                                style="font-size: 12px"></asp:Label>
															<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" 
                                                                ControlToValidate="txtlogin" Display="Dynamic" 
                                                                meta:resourcekey="RequiredFieldValidator1Resource1" 
                                                                style="font-size: 12px">*</asp:requiredfieldvalidator>
															</TD>
														<TD style="text-align: left; padding:2px;"><asp:textbox id="txtlogin" runat="server" Columns="30" Width="220px"   
                                                                meta:resourcekey="txtloginResource1" Enabled="False" cssclass="form-control"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 142px; text-align: left;">
                                                            <asp:Label ID="Label4" runat="server" Text="Nombre *" 
                                                                meta:resourcekey="Label4Resource1" Font-Bold="True" 
                                                                style="font-size: 12px"></asp:Label>
															<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" 
                                                                ControlToValidate="txtNombre" Display="Dynamic" 
                                                                meta:resourcekey="RequiredFieldValidator3Resource1" 
                                                                style="font-size: 12px">*</asp:requiredfieldvalidator></TD>
														<TD style="text-align: left;padding:2px;"><asp:textbox id="txtNombre" runat="server" Columns="30" Width="220px"  
                                                                meta:resourcekey="txtNombreResource1" cssclass="form-control"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 142px; text-align: left;">
                                                            <asp:Label ID="Label13" runat="server" Text="Apellidos *" 
                                                                meta:resourcekey="Label13Resource1" Font-Bold="True" 
                                                                style="font-size: 12px"></asp:Label>
															<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" 
                                                                ControlToValidate="txtapellidos" Display="Dynamic" 
                                                                meta:resourcekey="RequiredFieldValidator5Resource1" 
                                                                style="font-size: 12px">*</asp:requiredfieldvalidator></TD>
														<TD style="text-align: left;padding:2px;"><asp:textbox id="txtapellidos" runat="server" Columns="30" Width="220px"  
                                                                meta:resourcekey="txtapellidosResource1" cssclass="form-control"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 142px; text-align: left;">
                                                            <asp:Label ID="Label14" runat="server" Text="Empresa *" Font-Bold="True" 
                                                                style="font-size: 12px" ></asp:Label>
															<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" 
                                                                ControlToValidate="txtnombreempresa" Display="Dynamic" 
                                                                style="font-size: 12px" >*</asp:requiredfieldvalidator></TD>
														<TD style="text-align: left;padding:2px;"><asp:textbox id="txtnombreempresa" runat="server" Columns="30" Width="220px" cssclass="form-control"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 142px; text-align: left;">
                                                            <asp:Label ID="Label5" runat="server" Text="Password *" 
                                                                meta:resourcekey="Label5Resource1" Font-Bold="True" 
                                                                style="font-size: 12px"></asp:Label>
															<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" 
                                                                ControlToValidate="txtpassword" Display="Dynamic" 
                                                                meta:resourcekey="RequiredFieldValidator2Resource1" 
                                                                style="font-size: 12px">*</asp:requiredfieldvalidator></TD>
														<TD style="text-align: left;padding:2px;"><asp:textbox id="txtpassword" runat="server" Columns="30" TextMode="Password"  
                                                                Width="220px" meta:resourcekey="txtpasswordResource1" cssclass="form-control" ></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 142px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server" Text="Confirmar password *" 
                                                                meta:resourcekey="Label6Resource1" Font-Bold="True" 
                                                                style="font-size: 12px"></asp:Label>
															<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" 
                                                                ControlToValidate="txtconfirmar" Display="Dynamic" 
                                                                meta:resourcekey="Requiredfieldvalidator4Resource1" 
                                                                style="font-size: 12px">*</asp:requiredfieldvalidator>
															<asp:CompareValidator id="CompareValidator1" runat="server" 
                                                                ControlToValidate="txtconfirmar" Display="Dynamic"
																CssClass="textoNormal2Red" ControlToCompare="txtpassword" meta:resourcekey="CompareValidator1Resource1" 
                                                                style="font-size: 12px">*</asp:CompareValidator></TD>
														<TD style="text-align: left;padding:2px;"><asp:textbox id="txtconfirmar" runat="server" Columns="30" TextMode="Password" 
                                                                Width="220px" meta:resourcekey="txtconfirmarResource1" cssclass="form-control"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 142px; text-align: left;">
                                                            <asp:Label ID="Label18" runat="server" Text="Estado" 
                                                                 Font-Bold="True" style="font-size: 12px"  ></asp:Label>
															</TD>
														<TD style="text-align: left;padding:2px;">
                                                            <asp:DropDownList ID="drpEstados" runat="server" DataTextField="NombreEntidad"  cssclass="form-control"
                                                                DataValueField="ClaveEntidad" Font-Size="12px" Width="220px">
                                                            </asp:DropDownList>
                                                        </TD>
													</TR>
												<TR>
														<TD class="Mediana" style="width: 142px; font-weight: bold; text-align: left;">
                                                            <span style="font-size: 12px">Telefono *</span><asp:requiredfieldvalidator 
                                                                id="RequiredFieldValidator7" runat="server"  Text="*"
                                                                ControlToValidate="txttelefono" Display="Dynamic" 
                                                                ErrorMessage="El telefono es un campo requerido" style="font-size: 12px" 
                                                                 ></asp:requiredfieldvalidator>
															</TD>
														<TD style="text-align: left;padding:2px;">
                                                            <asp:textbox id="txttelefono" runat="server" Columns="30" Width="220px"  
                                                                meta:resourcekey="txtapellidosResource1" cssclass="form-control"></asp:textbox>
                                                        </TD>
													</TR>
												</TABLE>
                                                <div style="height:15px;"></div>

                                                <h2>Información extra</h2>
									
                                           

												<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
													<TR>
														<TD class="Mediana" style="width: 143px; text-align: left;">
                                                            <asp:Label ID="Label8" runat="server" Text="Edad" 
                                                                meta:resourcekey="Label8Resource1" Font-Bold="True" 
                                                                style="font-size: 12px"></asp:Label></TD>
														<TD style="text-align: left;padding:2px;">
															<asp:DropDownList id="drpRango" runat="server" DataTextField="rango"  cssclass="form-control"  Width="220px" 
                                                                DataValueField="idedadrango" meta:resourcekey="drpRangoResource1" 
                                                                Font-Size="12px" style="font-size: 12px"></asp:DropDownList></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 143px; text-align: left;"></TD>
														<TD>
															<asp:image id="Image6" runat="server" Width="7px" Height="2px" 
                                                                ImageUrl="~/images/transp.gif" meta:resourcekey="Image6Resource1" 
                                                                style="font-size: 12px"></asp:image></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 143px; text-align: left;">
                                                            <asp:Label ID="Label9" runat="server" Text="Sexo" 
                                                                meta:resourcekey="Label9Resource1" Font-Bold="True" 
                                                                style="font-size: 12px"></asp:Label></TD>
														<TD style="text-align: left">
															<asp:RadioButtonList id="rdbsexo" runat="server"  CssClass="form-group"
                                                                RepeatDirection="Horizontal" meta:resourcekey="rdbsexoResource1" 
                                                                Font-Size="12px">
																<asp:ListItem Value="M" Selected="True" meta:resourcekey="ListItemResource1">Mujer</asp:ListItem>
																<asp:ListItem Value="H" meta:resourcekey="ListItemResource2">Hombre</asp:ListItem>
															</asp:RadioButtonList></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 143px; text-align: left; font-size: 12px;">
                                                            &nbsp;</TD>
														<TD>
																<asp:Label id="lblTienda1" runat="server" CssClass="Mediana" Font-Bold="True" 
                                                    meta:resourcekey="lblTienda1Resource1" style="font-size: 12px"></asp:Label>
                                                                <span style="font-size: 12px">&nbsp;
                                                </span>
                                                <asp:Label ID="Label10" runat="server" 
                                                    Text="respeta a sus clientes y&nbsp; su privacidad." 
                                                    meta:resourcekey="Label10Resource1" style="font-size: 12px"></asp:Label>
                                                                <BR style="font-size: 12px">
												<BR style="font-size: 12px">
												<asp:Label id="lblTienda2" runat="server" CssClass="Mediana" Font-Bold="True" 
                                                    meta:resourcekey="lblTienda2Resource1" style="font-size: 12px"></asp:Label>
												                <span style="font-size: 12px">&nbsp;
                                                </span>
                                                <asp:Label ID="Label11" runat="server" Text="mantendrá y usará la información del cliente en forma responsable. 
												Nosotros no vendemos o rentamos la información que nos das, no la ofrecemos a 
												terceros ni la usamos sin tú consentimiento. Para más información lee la Poliza 
												de privacidad." meta:resourcekey="Label11Resource1" style="font-size: 12px"></asp:Label></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 143px; text-align: left;">
                                                            &nbsp;</TD>
														<TD>
                                                <asp:Button ID="Button1" runat="server" Text="Actualizar cuenta"  CssClass="btn btn-success"  
                                                    />
                                                        &nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
                                                                Text="Cancelar"  CssClass="btn btn-default" />
                                                        </TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 143px; text-align: left;">
                                                            &nbsp;</TD>
														<TD>
									<asp:validationsummary id="ValidationSummary1" runat="server" Width="100%" 
                                        CssClass="textoNormal2Red" HeaderText="Verifica los campos marcados como requeridos"
										DisplayMode="SingleParagraph" meta:resourcekey="ValidationSummary1Resource1" style="font-size: 11px"></asp:validationsummary></TD>
													</TR>
													<TR>
														<TD class="Mediana" style="width: 143px; text-align: left;">
                                                            &nbsp;</TD>
														<TD>
                                                <asp:Label ID="Label12" runat="server" 
                                                    Text="Los campos marcados con el simbolo '*' son requeridos." 
                                                    meta:resourcekey="Label12Resource1" style="font-size: 12px"></asp:Label></TD>
													</TR>
												</TABLE>
									
        


         </div>
</asp:Content>
