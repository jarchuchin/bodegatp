<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayProductoComparar.ascx.vb" Inherits="controles_DisplayProductoComparar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>








<table cellpadding="0" cellspacing="0" border="0" style="width:210px" >
    <tr>

        <td style="width:200px;  vertical-align:top; text-align:left;">
         <asp:HyperLink ID="lnkFoto" runat="server"  >
              <asp:Image ID="imgProducto" runat="server"  Width="200px" />
       </asp:HyperLink>
       
            <table cellpadding="0" cellspacing="0" border="0"  style=" width:100%; height:22px;   text-align:left;">
                <tr>
                    <td style="width:2px; text-align:center;" >
                        <asp:Panel ID="panelnuevo" runat="server" Visible="true"  Width="15px">
                            <table cellpadding="0" cellspacing="0" border="0"  style=" width:15px; height:22px; background-color:red; text-align:center;">
                                <tr><td><asp:Label ID="lblNuevo" runat="server"  ForeColor="white" Font-Bold="true" Font-Size="11px" Width="15px">¡N!</asp:Label></td></tr>
                            </table> 
                        </asp:Panel>       
                    </td>
                    <td >
                    <asp:Label ID="lblNombreProducto" runat="server"  CssClass="titulo-producto"  ></asp:Label>
                   </td>
                </tr>
            </table>
            
            
              <div style="   width: 100%"><div  >
                          <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                            <tr>
                                <td style="width:10px"> <asp:Image ID="Image4" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left;"> <asp:Label ID="Label8" runat="server"  
                                        ForeColor="Black" Font-Bold="True" CssClass="txt-black-11" >Características</asp:Label></td></tr></table></div><div style="height:10px"></div>
                    <!--clave -->
                     
                     <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                            <tr>
                                <td style="width:10px"> <asp:Image ID="Image17" runat="server"  Width="10px" Height="1px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left;"> <asp:Label ID="Label16" runat="server"  Font-Bold="true" CssClass="txt-black-11" Text="Clave:"></asp:Label></td></tr><tr>
                                <td style="width:10px"> <asp:Image ID="Image18" runat="server"  Width="10px" Height="1px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left;"><asp:Label ID="lblClave" runat="server" Font-Bold="true" Font-Size="14px" CssClass="txt-black-11" ></asp:Label></td></tr></table><!--termina clave --><div style="height:10px"></div>
                        <!--Colores-->
                           <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                <tr>
                                    <td style="width:10px"> <asp:Image ID="Image19" runat="server"  Width="10px" Height="1px"  ImageUrl="~/images/transp.gif" /></td>
                                    <td style="text-align: left;"> <asp:Label ID="lblColoresEtiqueta" runat="server"  Font-Size="11px"
                                            Font-Bold="True" Text="Colores:"></asp:Label></td></tr><tr>
                                    <td style="width:10px"> <asp:Image ID="Image24" runat="server"  Width="10px" Height="1px"  ImageUrl="~/images/transp.gif" /></td>
                                    <td style="text-align: left; vertical-align:top; ">
                                      
                                        
                                        <asp:DataList ID="dtlColores" runat="server" RepeatColumns="1" Width="100%"  >
                                            <ItemTemplate>
                                                   <table cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
                                                    <tr>
                                                        <td style="width:50px;" class="txt-black-11"><asp:Literal ID="litcolor" runat="server" Text='<%# getColor( eval("idCodigoColor")) %>'></asp:Literal> </td>
                                                         <td style="width:2px" class="txt-black-11"> <asp:Image ID="Ifdmage24" runat="server"  Width="2px"  ImageUrl="~/images/transp.gif" /></td>
                                                        <td class="txt-black-11"><asp:Label ID="lblcolor" runat="server"   Text='<%# NombreColor %>'></asp:Label></td></tr></table></ItemTemplate></asp:DataList></td></tr></table><!--Colores--><!--aqui empiezan las features--><asp:Repeater ID="rptfeatures" runat="server"  >
                        <ItemTemplate>
                            <asp:Panel ID="panelFeatures"  runat="server"   Visible='<%# getfeature(cint(eval("idCaracteristica"))) %>' >
                            <div style="height:10px"></div>
                             <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                    <tr>
                                        <td style="width:10px"> <asp:Image ID="Image1s7" runat="server"  Width="10px" Height="1px"  ImageUrl="~/images/transp.gif" /></td>
                                        <td style="text-align: left;" class="txt-black-11"> <asp:Label ID="Label3" runat="server" Text='<%# eval("Nombre") & ":" %>' Font-Bold="True" ></asp:Label></td></tr><tr>
                                        <td style="width:10px"> <asp:Image ID="Image18" runat="server"  Width="10px" Height="1px"  ImageUrl="~/images/transp.gif" /></td>
                                        <td style="text-align: left; vertical-align:top;" class="txt-black-11"><asp:Label ID="Labelcaracteristica" runat="server" Text='<%# feature %>' ></asp:Label></td></tr></table></asp:Panel></ItemTemplate></asp:Repeater><asp:Panel ID="panelEspecificaciones"  runat="server" Visible="false"    >
                           <div style="height:10px"></div>
                            <!--Especificaciones -->
                               <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                    <tr>
                                        <td style="width:10px"> <asp:Image ID="Image20" runat="server"  Width="10px"  Height="1px"   ImageUrl="~/images/transp.gif" /></td>
                                        <td style="text-align: left;" class="txt-black-11">    <asp:Label ID="Label4" runat="server" Text="Especificaciones:" Font-Bold="True" ></asp:Label></td></tr><tr>
                                        <td style="width:10px"> <asp:Image ID="Image21" runat="server"  Width="10px"  Height="1px"   ImageUrl="~/images/transp.gif" /></td>
                                        <td style="text-align: left; vertical-align:top;" class="txt-black-11">   <asp:Literal ID="litespecificacion" runat="server" ></asp:Literal></td></tr></table><!--end Especificaciones--></asp:Panel><asp:Panel ID="panelDescripciones"  runat="server" Visible="false"    >
                           <div style="height:10px"></div>
                            <!--Descripciones-->
                               <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                    <tr>
                                        <td style="width:10px"> <asp:Image ID="Image22" runat="server"  Width="10px"  Height="1px"   ImageUrl="~/images/transp.gif" /></td>
                                        <td style="text-align: left;" class="txt-black-11"><asp:Label ID="Label1" runat="server" Text="Descripción:" Font-Bold="True" ></asp:Label></td></tr><tr>
                                        <td style="width:10px"> <asp:Image ID="Image23" runat="server"  Width="10px"  Height="1px"   ImageUrl="~/images/transp.gif" /></td>
                                        <td style="text-align: left; vertical-align:top;" class="txt-black-11">   <asp:Literal ID="litdescripcion" runat="server" meta:resourcekey="litdescripcionResource1"></asp:Literal></td></tr></table><!--end Descripciones--></asp:Panel><div style=" height :10px"></div>
                 <div  >
                          <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                            <tr>
                                <td style="width:10px"> <asp:Image ID="Image3" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left;" class="txt-black-11"> <asp:Label ID="Label7" runat="server"  ForeColor="black" Font-Bold="true" Font-Size="11px">Precios</asp:Label></td></tr></table></div><div style=" height :10px"></div>
                     <!--Precios sin impresion -->
                     <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                        <tr>
                            <td style="width:10px"> <asp:Image ID="Image5" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
                            <td style="text-align: left; vertical-align:top;"> 
                                <asp:Label ID="Label9" 
                                    runat="server" Text="Precio sin impresión" Font-Bold="True" 
                                    CssClass="txt-black-11"></asp:Label><asp:Repeater ID="rptprecios" runat="server" >
                                <HeaderTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0" style=" width:150px" >
                                        <tr>
                                        <td class="txt-black-11"><asp:Label ID="Label9" runat="server" Text="Cantidad" Font-Bold="false"></asp:Label></td><td class="txt-black-11"><asp:Label ID="Label10" runat="server" Text="Costo" Font-Bold="false"></asp:Label></td></tr></HeaderTemplate><ItemTemplate>
                                    <tr>
                                    <td style="width:100px" class="txt-black-11"><asp:Label ID="Label14" runat="server"  Text='<%# Eval("desde") %>'></asp:Label>&nbsp;-&nbsp;<asp:Label ID="Label15" runat="server"  Text='<%# Eval("hasta") %>'></asp:Label></td><td class="txt-black-11"><asp:Label ID="Label10" runat="server"  Font-Bold="true" Text='<%# Eval("precio") %>'></asp:Label></td></tr></ItemTemplate><FooterTemplate>
                                    </table>
                                </FooterTemplate>
                                </asp:Repeater>
                                
                             </td>
                        </tr>
                      </table>
                      
                     
                      <div style=" height :10px"></div>
                 <div  >
                          <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                            <tr>
                                <td style="width:10px"> <asp:Image ID="Image2" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left;" class="txt-black-11"> <asp:Label ID="Label2" runat="server"  ForeColor="black" Font-Bold="true" Font-Size="11px">Acabados</asp:Label></td></tr></table></div><div style="height:10px"></div>
                      <!--Precios servicios-->
                     <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                        <tr>
                            <td style="width:10px"> <asp:Image ID="Image6" runat="server"  Width="10px"   ImageUrl="~/images/transp.gif" /></td>
                            <td style="text-align: left; vertical-align:top;"> 
                              
                                <asp:DataList ID="rptprecioscon" runat="server" RepeatColumns="1" >
                                    <ItemTemplate>
                                       <asp:Label ID="lblAcabado" runat="server" Font-Bold="True"  CssClass="txt-black-11" Text='<%# eval("Nombre") %>' > </asp:Label> &nbsp;<asp:Label ID="Label8" Font-Size="10px" Font-Bold="True" runat="server" Text='<%# eval("Unidadcomponentebase") %>' > </asp:Label> &nbsp;<asp:Label ID="Label9"  CssClass="txt-black-11" Font-Bold="True" runat="server" Text='<%# eval("componenteBase") %>' ></asp:Label><br />
                                        <asp:Label ID="Label5" runat="server" Text="Precio unitario: " Font-Bold="true" CssClass="txt-black-11"></asp:Label><asp:Label ID="Label6" runat="server" Text='<%# eval("precioComponenteBase", "{0:c}") %>' CssClass="txt-black-11"></asp:Label><br />
                                        <asp:Label ID="Label3" runat="server" Text="Cantidad mínima: " Font-Bold="true" CssClass="txt-black-11"></asp:Label><asp:Label ID="Label10" CssClass="txt-black-11" runat="server" Text='<%# eval("CantidadMinima") %>' ></asp:Label><br />
                                        <asp:Label ID="Label11" runat="server" Text="Costo setup: " Font-Bold="true" CssClass="txt-black-11"></asp:Label><asp:Label ID="Label12" runat="server" Text='<%# eval("costoSetup", "{0:c}") %>' CssClass="txt-black-11"></asp:Label><div style="height:5px"></div>
                                    </ItemTemplate>
                                </asp:DataList>
                                
                             </td>
                        </tr>            
                      </table>
              
                    <!--Precios con impresion -->
                     
                     <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                            <tr>
                                <td style="width:10px"> <asp:Image ID="Image9" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
                                <td style="text-align: left;"> <asp:Label ID="Label10" runat="server" CssClass="txt-black-11"  Font-Bold="false"  Text="Los precios No incluyen IVA"></asp:Label></td></tr></table><div style="height:10px"></div>
                   <!--Tags-->
                        <div  >
                          <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                <tr>
                                    <td style="width:10px"> <asp:Image ID="Image29" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
                                    <td style="text-align: left;"> <asp:Label ID="Label19" runat="server"  ForeColor="black" Font-Bold="true" CssClass="txt-black-11">Tags</asp:Label></td></tr></table></div><div style="height:10px"></div>
                     <table style="width:100%; text-align:left;" cellpadding="0" cellspacing="0" border="0">
                       <tr>
                            <td style="width:10px"> <asp:Image ID="Image30" runat="server"  Width="10px"  ImageUrl="~/images/transp.gif" /></td>
                            <td >
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </td>
                            
                        </tr>
                        </table>
                      <div style="height:10px;"></div>
                           
                        <!--termina Tags-->
                        
                        
                      
                
                
                
                
                  <div style="height:10px"></div>
                            <!--Ultima actualización-->
                               <table cellpadding="0" cellspacing="0" border="0" style="width:100%; ">
                                    <tr>
                                        <td style="width:10px"> <asp:Image ID="Image25" runat="server"  Width="10px"  Height="1px"  ImageUrl="~/images/transp.gif" /></td>
                                        <td style="text-align: left;">    <asp:Label ID="Label6" runat="server" Text="Última actualización:" Font-Bold="True"  CssClass="txt-black-11"></asp:Label></td></tr><tr>
                                        <td style="width:10px"> <asp:Image ID="Image26" runat="server"  Width="10px"   Height="1px"   ImageUrl="~/images/transp.gif" /></td>
                                        <td style="text-align: left; vertical-align:top;"> <asp:Label ID="lblfechaActualizacion" runat="server" CssClass="txt-black-11"></asp:Label></td></tr></table><!--end Ultima actualización--><!--termina x --></div></td><td style="width:10px">
         <asp:Image ID="Image1" runat="server"  Width="10px"  Height="1px"  ImageUrl="~/images/transp.gif" />
        </td>
       
        
      
    </tr>
</table>
