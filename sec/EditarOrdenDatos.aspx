<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="EditarOrdenDatos.aspx.vb" Inherits="sec_EditarOrdenDatos" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


<div style="height:20px"></div>

 <table width="100%" border="0" cellpadding="0" cellspacing="20" class="border-box2">
        
       <tr class="line">
          <td><h2>Editar datos de cotización</h2></td>
          <td align="right" valign="middle" class="txt-black-13"><strong>Fecha:</strong> <asp:Label 
                  ID="lblfecha" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
          <td colspan="2"><table width="100%" border="0" cellspacing="5" cellpadding="0">
            <tr>
              <td width="50%" height="37" valign="middle" ><table width="90%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><strong>DATOS GENERALES</strong></td>
                </tr>
              </table></td>
              <td width="50%" valign="middle" ><table width="90%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td><strong>DATOS DE FACTURACIÓN</strong></td>
                  </tr>
              </table></td>
            </tr>
            <tr>
              <td height="52" align="center">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                            >
                                                            <b>Nombre:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dgNombre" runat="server"  cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                            >
                                                            <b>Empresa:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dgEmpresa" runat="server"  cssClass="form-control" 
                                                                Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Email:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dgEmail" runat="server"  cssClass="form-control" 
                                                                Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Fecha de evento:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dgfechaevento" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="dgfechaevento_CalendarExtender" runat="server" 
                                                                Enabled="True" TargetControlID="dgfechaevento">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Teléfono:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dgTelefono" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Dirección</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dgDireccion" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Ciudad</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dgCiudadE" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Estado</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:DropDownList ID="drpestadosE" runat="server" DataTextField="Nombre" cssClass="form-control"
                                                                DataValueField="idEstado"  Width="250px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>CP:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dgcpE" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: left;"  >
                                                            <b></b></td>
                                                        <td  style="text-align:left">
                                                          
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
              <td align="center" style="vertical-align:top">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Nombre/Empresa:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dfNombre" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>RFC:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dfRFC" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Dirección:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dfDireccion" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Ciudad</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dFCiudad" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Estado</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:DropDownList ID="drpestadosF" runat="server" DataTextField="Nombre" cssClass="form-control" Width="250px"
                                                                DataValueField="idEstado" >
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>CP</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dgcpF" runat="server"   cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; " 
                                                             >
                                                            <b>Teléfono:</b></td>
                                                        <td  style="text-align:left;padding:2px;">
                                                            <asp:TextBox ID="dfTelefono" runat="server"  cssClass="form-control" Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: left; height: 25px;">
                                                            <b></b></td>
                                                        <td  style="text-align:left; height: 25px;">
                                                          
                                                            &nbsp;&nbsp; &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: left;">
                                                            <b></b></td>
                                                        <td  style="text-align:left">
                    
                    <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-warning" 
                        Text="Grabar"   />
                                                        &nbsp;<asp:Button ID="btnCancelar" runat="server" 
                        Text="Cancelar" cssClass="btn btn-default"  />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
            </tr>
            <tr>
              <td height="3" align="center" class="txt-precios">
		                    &nbsp;</td>
              <td align="center" class="txt-precios">&nbsp;</td>
            </tr>
            
          </table></td>
        </tr>
        </table>



































</asp:Content>

