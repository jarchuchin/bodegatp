<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayBanners.ascx.vb" Inherits="controles_DisplayBanners" %>
											<asp:Panel ID="panelBody" runat="server">
												<table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td style="width:20px;">&nbsp;</td>
													<td style="width:470px;" valign="top">
														<asp:HyperLink ID="HyperLink1" runat="server" Visible="false">
															<asp:Image ID="Image1" runat="server" Width="470" Visible="false" />
														</asp:HyperLink>
													</td>
													<td style="width:20px;">&nbsp;</td>
													<td style="width:470px;" valign="top">
														<asp:HyperLink ID="HyperLink2" runat="server" Visible="false">
															<asp:Image ID="Image2" runat="server" Width="470" Visible="false" />
														</asp:HyperLink>
													</td>
													<td style="width:20px;">&nbsp;</td>
												</tr>
												</table>

												<div style="height:20px"></div>

												<table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td style="width:20px;">&nbsp;</td>
													<td style="width:231px;" valign="top">
														<asp:HyperLink ID="HyperLink3" runat="server" Visible="false">
															<asp:Image ID="Image3" runat="server" Width="231" Visible="false" />
														</asp:HyperLink>
													</td>
													<td style="width:12px;">&nbsp;</td>
													<td style="width:231px;" valign="top">
														<asp:HyperLink ID="HyperLink4" runat="server" Visible="false">
															<asp:Image ID="Image4" runat="server" Width="231" Visible="false" />
														</asp:HyperLink>
													</td>
													<td style="width:12px;">&nbsp;</td>
													<td style="width:231px;" valign="top">
														<asp:HyperLink ID="HyperLink5" runat="server" Visible="false">
															<asp:Image ID="Image5" runat="server" Width="231" Visible="false" />
														</asp:HyperLink>
													</td>
													<td style="width:12px;">&nbsp;</td>
													<td style="width:231px;" valign="top">
														<asp:HyperLink ID="HyperLink6" runat="server" Visible="false">
															<asp:Image ID="Image6" runat="server" Width="231" Visible="false" />
														</asp:HyperLink>
													</td>
													<td style="width:20px;">&nbsp;</td>
												</tr>
												</table>
											</asp:Panel>
											<asp:Panel ID="panelLateral" runat="server" Visible="false">
												<asp:DataList ID="dataListAnuncios" runat="server" CellPadding="8" RepeatColumns="2" RepeatDirection="Horizontal">
													<ItemTemplate>
														<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl='<%# Eval("url") %>' Target='<%# Eval("target") %>' ToolTip='<%# Eval("tooltip") %>'>
															<asp:Image ID="Image7" runat="server" Width="217" ImageUrl='<%# GetImagen(Eval("nombreArchivo")) %>' />
														</asp:HyperLink>
													</ItemTemplate>
												</asp:DataList>
											</asp:Panel>
											<asp:HiddenField ID="hiddenPos" runat="server" />
											<asp:HiddenField ID="hiddenPag" runat="server" />
