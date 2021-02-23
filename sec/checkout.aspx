<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageWide.master" AutoEventWireup="false" CodeFile="checkout.aspx.vb" Inherits="sec_checkout" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


<TABLE class="tablaPrincipalInterna" id="Table1" cellSpacing="4" cellPadding="0" align="center"
							border="0" width="90%">
							<TR>
								<TD class="TituloCaja" vAlign="top" align="left"><BR>
                                    <asp:Label ID="Label13" runat="server" Text="Orden de compra" 
                                        meta:resourcekey="Label13Resource1"></asp:Label><BR>
									&nbsp;</TD>
							</TR>
							<TR>
								<TD class="Mediana" vAlign="top" align="left">
									
								    <asp:Label ID="Label27" runat="server" Font-Bold="True" 
                                        Text="Dirección de envío" meta:resourcekey="Label27Resource1"></asp:Label>
                                    <br />
									
									 <asp:Label ID="lbldireccion" Font-Bold="True" runat="server" 
                                        meta:resourcekey="lbldireccionResource1" ></asp:Label><br />
                                        <asp:Label ID="lblciudad" runat="server" 
                                        meta:resourcekey="lblciudadResource1" ></asp:Label>,
                                        &nbsp;<asp:Label ID="lblestado" runat="server" 
                                        meta:resourcekey="lblestadoResource1" ></asp:Label><br />
                                        <asp:Label ID="lblpais" runat="server" meta:resourcekey="lblpaisResource1" ></asp:Label>
                                        &nbsp;<asp:Label ID="lblasd" runat="server" Font-Bold="True" Text="C.P." 
                                        meta:resourcekey="lblasdResource1"></asp:Label>
                                        &nbsp;<asp:Label ID="lblcp" runat="server" 
                                        meta:resourcekey="lblcpResource1" ></asp:Label><br />
                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Tel." 
                                        meta:resourcekey="Label3Resource1"></asp:Label>
                                        &nbsp;<asp:Label ID="lbltelefono" runat="server" 
                                        meta:resourcekey="lbltelefonoResource1" ></asp:Label>
                                    &nbsp;
                                    <br />
                                    <asp:HyperLink ID="lnkCambiardireccion" runat="server" 
                                        NavigateUrl="seleccionarDireccion.aspx?red=1" 
                                        meta:resourcekey="lnkCambiardireccionResource1">Cambiar dirección de envío</asp:HyperLink>
                                    <br />
									
									
									
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center"></TD>
							</TR>
							<TR>
								<TD  >
                                               
                                                
                                           
                                           
                                           <asp:datagrid id="dtgbolsita" runat="server" Width="100%" CssClass="Mediana" GridLines="Horizontal"
										AutoGenerateColumns="False" meta:resourcekey="dtgbolsitaResource1">
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
										<Columns>
											
											<asp:TemplateColumn HeaderText="Cantidad">
												<HeaderStyle HorizontalAlign="Left" Width="70px"></HeaderStyle>
												<ItemStyle HorizontalAlign="center"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="Labedl4" runat="server" Text='<%# eval("cantidad") %>' 
                                                        meta:resourcekey="Labedl4Resource1"></asp:Label>
													
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Foto">
												<HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
												<ItemTemplate>
													<asp:Image ID="Image1" runat="server" Width="50px" 
                                                        ImageUrl='<%# getFoto(cint(eval("idProducto"))) %>' 
                                                        meta:resourcekey="Image1Resource1" />
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Clave">
												<HeaderStyle HorizontalAlign="Left" Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="Labedl4" runat="server" 
                                                        Text='<%# getclave(cint(eval("idProducto"))) %>' 
                                                        meta:resourcekey="Labedl4Resource2"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Nombre del producto">
												<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="Label1" runat="server" 
                                                        Text='<%# getnombre(cint(eval("idProducto"))) %>' 
                                                        meta:resourcekey="Label1Resource1"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Precio Unitario">
												<HeaderStyle HorizontalAlign="Right" Width="120px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="Label4" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.Costounitario", "{0:#.00}") %>' 
                                                        meta:resourcekey="Label4Resource1"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Total">
												<HeaderStyle HorizontalAlign="Right" Width="70px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="Label5" runat="server" 
                                                        Text='<%# DataBinder.Eval(Container, "DataItem.CostoTotal", "{0:#.00}") %>' 
                                                        meta:resourcekey="Label5Resource1"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											
										</Columns>
									</asp:datagrid>
                                           
                                           
									<br />
									<!--seccion tarjeta--->
									
									
								</TD>
							</TR>
							<TR>
								<TD  >
									<table style="width: 100%">
                                        <tr>
                                            <td style="width: 60%; vertical-align:top ">
                                               
                                                
                                           
                                           
                                                <table border="0" cellpadding="1" cellspacing="2" style="width: 400px">
                                                    <tr>
                                                        <td colspan="2">
                                                    <asp:Label ID="Label44" runat="server" Text="1. Datos de facturación" Font-Bold="True" 
                                                                Font-Size="12px" ForeColor="Green" meta:resourcekey="Label44Resource1"></asp:Label>
                                                        </td>
                                                    </tr>
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
                                                            <asp:Label ID="Label45" runat="server" Text="Nombre" Font-Bold="True" 
                                                                meta:resourcekey="Label45Resource1" ></asp:Label>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtnombredireccion" 
                                                                ErrorMessage="La direccion es requerida" 
                                                                meta:resourcekey="RequiredFieldValidator10Resource1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtnombredireccion" runat="server" Width="250px" 
                                                                meta:resourcekey="txtnombredireccionResource1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label40" runat="server" Text="Dirección" Font-Bold="True" 
                                                                meta:resourcekey="Label40Resource1" ></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                                ControlToValidate="txtdireccion" ErrorMessage="La direccion es requerida" 
                                                                meta:resourcekey="RequiredFieldValidator7Resource1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtdireccion" runat="server" Width="250px" 
                                                                meta:resourcekey="txtdireccionResource1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label2" runat="server" Text="Ciudad" Font-Bold="True" 
                                                                meta:resourcekey="Label2Resource1" ></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                                ControlToValidate="txtciudad" ErrorMessage="La ciudad es requerida" 
                                                                meta:resourcekey="RequiredFieldValidator8Resource1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtciudad" runat="server" Width="250px" 
                                                                meta:resourcekey="txtciudadResource1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label41" runat="server" Text="Pais" Font-Bold="True" 
                                                                meta:resourcekey="Label41Resource1" ></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                                ControlToValidate="drpPaises" ErrorMessage="El pais es requerido" 
                                                                meta:resourcekey="RequiredFieldValidator9Resource1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drppaises" runat="server" AutoPostBack="True" 
                                                                DataTextField="Nombre" DataValueField="idPais" 
                                                                meta:resourcekey="drppaisesResource1">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label42" runat="server" Text="Estado" Font-Bold="True" 
                                                                meta:resourcekey="Label42Resource1" ></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                ControlToValidate="drpEstado" ErrorMessage="El estado es requerido" 
                                                                meta:resourcekey="RequiredFieldValidator4Resource1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="drpEstado" runat="server" DataTextField="Nombre" 
                                                                DataValueField="idEstado" meta:resourcekey="drpEstadoResource1">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label43" runat="server" Text="CP" Font-Bold="True" 
                                                                meta:resourcekey="Label43Resource1" ></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                                ControlToValidate="txtcp" ErrorMessage="El cp es requerido" 
                                                                meta:resourcekey="RequiredFieldValidator5Resource1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtcp" runat="server" Width="50px" 
                                                                meta:resourcekey="txtcpResource1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label6" runat="server" Text="Telefono" Font-Bold="True" 
                                                                meta:resourcekey="Label6Resource1" ></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                                ControlToValidate="txttelefono" ErrorMessage="El telefono es requerido" 
                                                                meta:resourcekey="RequiredFieldValidator6Resource1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txttelefono" runat="server" Width="150px" 
                                                                meta:resourcekey="txttelefonoResource1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="Label48" runat="server" Text="RFC" Font-Bold="True" 
                                                                meta:resourcekey="Label48Resource1" ></asp:Label>
                                                            </td>
                                                        <td>
                                                            <asp:TextBox ID="txtrfc" runat="server" Width="150px" 
                                                                meta:resourcekey="txtrfcResource1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                           
                                           
                                           </td>
                                           <td style="width: 40%; vertical-align:top">
									
									
									<TABLE id="Tasble5" cellSpacing="2" cellPadding="1" width="100%" border="0">
											<TR>
												<TD colSpan="2">
                                                    <asp:Label ID="Label29" runat="server" 
                                                        Text="2. Información de tarjeta de crédito" Font-Bold="True" 
                                                                Font-Size="12px" ForeColor="Green" 
                                                        meta:resourcekey="Label29Resource1"></asp:Label></TD>
											</TR>
											<TR>
												<TD  colSpan="2">
                                                    <asp:Label ID="Label31" runat="server" 
                                                        Text="Los datos deben ser exactamente como aparecen en la tarjeta" 
                                                        meta:resourcekey="Label31Resource1"></asp:Label> 
													<br />
													<asp:CustomValidator id="CustomValidator1" runat="server" 
                                                        ErrorMessage="Error en la tarjeta de crédito" 
                                                        meta:resourcekey="CustomValidator1Resource1">Los datos de la tarjeta de credito son incorrectos</asp:CustomValidator>
                                                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" 
                                                        Text="El banco no ha permitido el cargo en la tarjeta" Visible="False" 
                                                        meta:resourcekey="lblMensajeResource1"></asp:Label>
                                                </TD>
											</TR>
											<TR>
												<TD  style="width: 261px">
                                                    <asp:Label ID="Label37" runat="server" Text="Número:" Font-Bold="True" 
                                                        meta:resourcekey="Label37Resource1" ></asp:Label>
													<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumeroCuenta"
														Display="Dynamic" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator></TD>
												<TD >
													<asp:TextBox id="txtNumeroCuenta" runat="server" Columns="20" MaxLength="16" 
                                                        Width="200px" meta:resourcekey="txtNumeroCuentaResource1"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD  style="width: 261px">
                                                    <asp:Label ID="Label34" runat="server" Text="Nombre en tarjeta:" 
                                                        Font-Bold="True" meta:resourcekey="Label34Resource1" ></asp:Label>
													<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtnombre" Display="Dynamic" 
                                                        meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator></TD>
												<TD>
													<asp:TextBox id="txtnombre" runat="server" Columns="25" MaxLength="25" 
                                                        Width="200px" meta:resourcekey="txtnombreResource1"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD style="width: 261px">
                                                    <asp:Label ID="Label36" runat="server" Text="Tipo Tarjeta:" Font-Bold="True" 
                                                        meta:resourcekey="Label36Resource1" ></asp:Label></TD>
												<TD >
													<asp:DropDownList id="drpTipoTarjeta" runat="server" 
                                                        meta:resourcekey="drpTipoTarjetaResource1">
                                                        <asp:ListItem Value="3" meta:resourcekey="ListItemResource1">Visa</asp:ListItem>
                                                        <asp:ListItem Value="2" meta:resourcekey="ListItemResource2">MasterCard</asp:ListItem>
                                                    </asp:DropDownList>&nbsp;<asp:Image 
                                                        id="Image1" runat="server" ImageUrl="~/images/cards.gif" Width="35px" 
                                                        meta:resourcekey="Image1Resource2"></asp:Image></TD>
											</TR>
											<TR>
												<TD  style="width: 261px">
                                                    <asp:Label ID="Label39" runat="server" Text="Fecha de vencimiento:" 
                                                        Font-Bold="True" meta:resourcekey="Label39Resource1" ></asp:Label></TD>
												<TD >
													<asp:DropDownList id="drpMes" runat="server" meta:resourcekey="drpMesResource1">
														<asp:ListItem Value="1" meta:resourcekey="ListItemResource3">Enero</asp:ListItem>
														<asp:ListItem Value="2" meta:resourcekey="ListItemResource4">Febrero</asp:ListItem>
														<asp:ListItem Value="3" meta:resourcekey="ListItemResource5">Marzo</asp:ListItem>
														<asp:ListItem Value="4" meta:resourcekey="ListItemResource6">Abril</asp:ListItem>
														<asp:ListItem Value="5" meta:resourcekey="ListItemResource7">Mayo</asp:ListItem>
														<asp:ListItem Value="6" meta:resourcekey="ListItemResource8">Junio</asp:ListItem>
														<asp:ListItem Value="7" meta:resourcekey="ListItemResource9">Julio</asp:ListItem>
														<asp:ListItem Value="8" meta:resourcekey="ListItemResource10">Agosto</asp:ListItem>
														<asp:ListItem Value="9" meta:resourcekey="ListItemResource11">Septiembre</asp:ListItem>
														<asp:ListItem Value="10" meta:resourcekey="ListItemResource12">Octubre</asp:ListItem>
														<asp:ListItem Value="11" meta:resourcekey="ListItemResource13">Noviembre</asp:ListItem>
														<asp:ListItem Value="12" meta:resourcekey="ListItemResource14">Diciembre</asp:ListItem>
													</asp:DropDownList>
													&nbsp;<asp:DropDownList id="drpAno" runat="server" 
                                                        meta:resourcekey="drpAnoResource1">
														<asp:ListItem Value="2009" meta:resourcekey="ListItemResource15">2009</asp:ListItem>
														<asp:ListItem Value="2010" meta:resourcekey="ListItemResource16">2010</asp:ListItem>
														<asp:ListItem Value="2011" meta:resourcekey="ListItemResource17">2011</asp:ListItem>
														<asp:ListItem Value="2012" meta:resourcekey="ListItemResource18">2012</asp:ListItem>
														<asp:ListItem Value="2013" meta:resourcekey="ListItemResource19">2013</asp:ListItem>
														<asp:ListItem Value="2014" meta:resourcekey="ListItemResource20">2014</asp:ListItem>
														<asp:ListItem Value="2015" meta:resourcekey="ListItemResource21">2015</asp:ListItem>
														<asp:ListItem Value="2016" meta:resourcekey="ListItemResource22">2016</asp:ListItem>
														<asp:ListItem Value="2017" meta:resourcekey="ListItemResource23">2017</asp:ListItem>
														<asp:ListItem Value="2018" meta:resourcekey="ListItemResource24">2018</asp:ListItem>
														<asp:ListItem Value="2019" meta:resourcekey="ListItemResource25">2019</asp:ListItem>
														<asp:ListItem Value="2020" meta:resourcekey="ListItemResource26">2020</asp:ListItem>
														<asp:ListItem Value="2021" meta:resourcekey="ListItemResource27">2021</asp:ListItem>
														<asp:ListItem Value="2022" meta:resourcekey="ListItemResource28">2022</asp:ListItem>
														<asp:ListItem Value="2023" meta:resourcekey="ListItemResource29">2023</asp:ListItem>
														<asp:ListItem Value="2024" meta:resourcekey="ListItemResource30">2024</asp:ListItem>
														<asp:ListItem Value="2025" meta:resourcekey="ListItemResource31">2025</asp:ListItem>
														<asp:ListItem Value="2026" meta:resourcekey="ListItemResource32">2026</asp:ListItem>
														
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD  style="width: 261px">
                                                    <asp:Label ID="Label38" runat="server" Text="Código de seguridad" 
                                                        Font-Bold="True" meta:resourcekey="Label38Resource1" ></asp:Label>
													<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="txtNumeroExtra" Display="Dynamic" 
                                                        meta:resourcekey="RequiredFieldValidator3Resource1">*</asp:RequiredFieldValidator></TD>
												<TD >
													<asp:TextBox id="txtNumeroExtra" runat="server" Columns="6" MaxLength="10" 
                                                        meta:resourcekey="txtNumeroExtraResource1"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD  style="width: 261px"></TD>
												<TD ></TD>
											</TR>
										</TABLE>
									<br />
									<br />
									<TABLE id="Table4" cellSpacing="2" cellPadding="1" width="100%" border="0">
										<TR>
											<TD >
                                                    <asp:Label ID="Label47" runat="server" 
                                                        Text="3. Confirmar total de orden y pagar" Font-Bold="True" 
                                                                Font-Size="12px" ForeColor="Green" 
                                                        meta:resourcekey="Label47Resource1"></asp:Label></TD>
										</TR>
										<TR>
											<TD >
                                           
                                           
									<TABLE id="Table2" cellSpacing="2" cellPadding="1" width="100%" border="0" 
                                        align="right">
										<TR>
											<TD class="Mediana" style="width: 299px">
                                                <asp:Label ID="Label19" runat="server" Text="Subtotal" 
                                                    Font-Bold="True" meta:resourcekey="Label19Resource1"></asp:Label>&nbsp;......................................</TD>
											<TD align="right" width="70" style="width: 130px">
                                                &nbsp;<asp:label id="lblsubtotal" runat="server" CssClass="textonormal4red" 
                                                    meta:resourcekey="lblsubtotalResource1"></asp:label></TD>
											<TD align="right" style="width: 23px">
                                                <asp:Label ID="Label9" runat="server" CssClass="Normal" Font-Bold="True" 
                                                    ForeColor="Green" meta:resourcekey="Label9Resource1">USD</asp:Label>
                                                </TD>
										</TR>
										<TR>
											<TD class="Mediana" style="width: 299px">
                                                <asp:Label ID="Label20" runat="server" Text="Descuentos" Font-Bold="True" 
                                                    meta:resourcekey="Label20Resource1"></asp:Label>&nbsp;...............................</TD>
											<TD align="right" width="70" style="width: 130px">
												&nbsp;-<asp:label id="lblDescuentos" runat="server" CssClass="Mediana" 
                                                    meta:resourcekey="lblDescuentosResource1"></asp:label></TD>
											<TD align="right" style="width: 23px">
                                                <asp:Label ID="Label11" runat="server" CssClass="Mediana" Font-Bold="True" 
                                                    ForeColor="Green" meta:resourcekey="Label11Resource1">USD</asp:Label>
												</TD>
										</TR>
										<TR>
											<TD class="Mediana" style="width: 299px">
                                                <asp:Label ID="Label22" runat="server" Text="Impuesto" Font-Bold="True" 
                                                    meta:resourcekey="Label22Resource1"></asp:Label>&nbsp;...................................</TD>
											<TD align="right" width="70" style="width: 130px">
                                                &nbsp;<asp:label id="lblImpuesto" runat="server" CssClass="Mediana" 
                                                    meta:resourcekey="lblImpuestoResource1"></asp:label></TD>
											<TD align="right" style="width: 23px">
                                                <asp:Label ID="Label12" runat="server" CssClass="Mediana" ForeColor="Green" 
                                                    Font-Bold="True" meta:resourcekey="Label12Resource1">USD</asp:Label>
                                                </TD>
										</TR>
										<TR>
											<TD class="Mediana" style="width: 299px">
                                                <asp:Label ID="Label25" runat="server" Text="Gastos de envío FedEx" 
                                                    Font-Bold="True" meta:resourcekey="Label25Resource1"></asp:Label>&nbsp;...........</TD>
											<TD align="right" width="70" style="width: 130px">
                                                <asp:label id="lblgastosenvio" runat="server" CssClass="Mediana" 
                                                    meta:resourcekey="lblgastosenvioResource1"></asp:label>
											</TD>
											<TD align="right" style="width: 23px">
                                                <asp:Label ID="Label26" runat="server" CssClass="Mediana" ForeColor="Green" 
                                                    Font-Bold="True" meta:resourcekey="Label26Resource1">USD</asp:Label>
											</TD>
										</TR>
										<TR>
											<TD class="Mediana" style="width: 299px"></TD>
											<TD align="right" width="70" style="width: 130px">
												<HR width="100%" SIZE="1">
											</TD>
											<TD align="right" style="width: 23px">
												&nbsp;</TD>
										</TR>
										<TR>
											<TD class="Mediana" style="width: 299px">
                                                <asp:Label ID="Label24" runat="server" Text="Total a pagar" Font-Bold="True" 
                                                    ForeColor="Green" meta:resourcekey="Label24Resource1"></asp:Label>&nbsp;.............................</TD>
											<TD align="right" width="70" style="width: 130px">
                                                <asp:label id="lblTotal" runat="server" CssClass="Mediana" ForeColor="Green" 
                                                    Font-Bold="True"  Font-Underline="False" Font-Size="13pt" 
                                                    meta:resourcekey="lblTotalResource1"></asp:label></TD>
											<TD align="right" style="width: 23px">
                                                <asp:Label ID="Label5" runat="server" CssClass="Mediana" ForeColor="Green" 
                                                    Font-Bold="True" meta:resourcekey="Label5Resource2">USD</asp:Label>
                                                </TD>
										</TR>
										<TR>
											<TD class="Mediana" style="width: 299px"></TD>
											<TD align="right" width="70" style="width: 130px">
												<HR width="100%" SIZE="1">
												&nbsp;</TD>
											<TD align="right" style="width: 23px">
												&nbsp;</TD>
										</TR>
										</TABLE>
									        </TD>
										</TR>
										<TR>
											<TD align="center">
                                                <asp:Button ID="btnchkout" runat="server" Text="Pagar ahora" 
                                                    meta:resourcekey="btnchkoutResource1" />
                                            </TD>
										</TR>
                                        </TABLE>
								            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; vertical-align:top">
                                               
                                                
                                           
                                           
                                                &nbsp;</td>
                                           <td style="width: 40%; vertical-align:top">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 60%; vertical-align:top">
                                               
                                                
                                           
                                           
                                                &nbsp;</td>
                                           <td style="width: 40%; vertical-align:top">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
								</TD>
							</TR>
							<TR>
								<TD  >
									&nbsp;</TD>
							</TR>
							<TR>
								<TD  >
									&nbsp;</TD>
							</TR>
						</TABLE>


</asp:Content>

