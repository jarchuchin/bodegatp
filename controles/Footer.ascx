<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Footer.ascx.vb" Inherits="Controles_Footer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<div runat="server" id="divRegistroFooter" style="text-align:center; background-color:#FFF;" class="inline container">

    



    <table style="width:100%; height:160px;" class="hidden-xs hidden-sm">
        <tr>
            <td style="width:50%;background-image: url('/images/barraFooter_r1_c1.jpg');">
                <div style="padding-left:200px; padding-top:95px; width:600px;" >
                  <div class="form-group" style="display:inline; width:100%;">
                            <div class="input-group" style="display:table;">
						    <asp:TextBox ID="txtSuscripcion" runat="server" placeholder="Escribe tu email" CssClass="form-control" UseSubmitBehavior="false"></asp:TextBox>
                                <span class="input-group-btn" style="padding-right:10px;">
						    <asp:Button ID="lnkBtnSuscripcion" runat="server" text="Suscribirme" CssClass="btn btn-success form-inline btn-suscribirme"  ></asp:Button>
                                    </span>
                        </div>
                    </div>

                </div>
            </td>
            <td style="width:50%;background-image: url('/images/barraFooter_r1_c2.jpg');">
                 <asp:HyperLink ID="lnkLoginFooter" runat="server" NavigateUrl="~/login.aspx" ImageUrl="~/images/trasnp.gif"   ImageHeight="80px" ImageWidth="80px" ></asp:HyperLink>
            </td>

        </tr>
    </table>
    <%-- <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/login.aspx" ImageUrl="~/images/barraFooter_r1_c1.jpg" ImageWith="682px" ></asp:HyperLink>--%>
   

</div>


<footer id="footer2" runat="server" visible="false">
<div class="divisorHorizontal"></div>
    <div class="row">
            <div class="col-md-4">
                 <div style="height:5px;"></div>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/login.aspx" ImageUrl="~/images/logo2019.jpg">
                </asp:HyperLink>
            </div>
            <div class="col-md-8">
                <div style="height:10px;"></div>
                <asp:Label ID="Label1" ForeColor="#666666" runat="server" Text="ATENCIÓN PERSONAL DE Lunes a Viernes de 8:30 AM a 6:30 PM Llama sin costo 01800 7020 505  SERVICIO A TODO MÉXICO"></asp:Label>

            </div>
         
    </div>
</footer>

    <footer id="footer1" runat="server" visible="true">
            
              

           <div style="height:20px;"></div>
        
        <div class=" " style="text-align:center;">
           
                <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/login.aspx" ImageUrl="~/images/logo2019.jpg"></asp:HyperLink>

        </div>








                <div class="row hidden-xs hidden-sm" >
                     <div class="col-md-1"></div>
                     <div class="col-md-3">
                         <div class="links" style="padding-left:15px;">
                            <h2>CONÓCENOS</h2>
                            <ul>
                                <li><asp:HyperLink ID="lnkAcerca" runat="server" NavigateUrl="~/Acercade.aspx">Quiénes somos</asp:HyperLink></li>
                                <li><asp:HyperLink ID="lnkTerminos" runat="server" NavigateUrl="~/TerminosyCondiciones.aspx">Términos de uso</asp:HyperLink></li>
                            </ul>
                         </div>
                    </div>

                   <div class="col-md-2">
                         <div class="links" style="padding-left:15px;">
                        <h2>USUARIOS</h2>
                        <ul>
                            <li><asp:HyperLink ID="lnkRegistro" runat="server" NavigateUrl="~/adduser.aspx">Regístrate</asp:HyperLink></li>
                            <li><asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx">Acceso a clientes</asp:HyperLink></li>
                            <li><asp:HyperLink ID="lnkFAQ" runat="server" NavigateUrl="~/PreguntasFrecuentes.aspx">Preguntas frecuentes</asp:HyperLink></li>
                            <li><asp:HyperLink ID="lnkComoComprar" runat="server" NavigateUrl="~/ComoComprar.aspx">Proceso de compra</asp:HyperLink></li>
                            <li><asp:HyperLink ID="lnkClausulasCompra" runat="server" NavigateUrl="~/ClausulasDeCompra.aspx">Cláusulas de compra</asp:HyperLink></li>
                        </ul>
                    </div>
                    </div>

                  
                    <div class="col-md-2">
                         <div class="links" style="padding-left:15px;">
                        <h2>INFORMACIÓN</h2>
                        <ul>
                            <li><asp:HyperLink ID="lnkServicioDiseno" runat="server" NavigateUrl="~/ServicioDiseno.aspx">Diseño</asp:HyperLink></li>
                            <li><asp:HyperLink ID="lnkServicioImpresion" runat="server" NavigateUrl="~/ServicioImpresion.aspx">Impresión</asp:HyperLink></li>
                            <li><asp:HyperLink ID="lnkServicioBordado" runat="server" NavigateUrl="~/ServicioBordado.aspx">Bordado</asp:HyperLink></li>
                            <li><asp:HyperLink ID="lnkServicioGrabado" runat="server" NavigateUrl="~/ServicioGrabado.aspx">Grabado</asp:HyperLink></li>
                            <li><asp:HyperLink ID="lnkServicioEnvio" runat="server" NavigateUrl="~/ServicioEnvio.aspx">Envío</asp:HyperLink></li>
                        </ul>
                        </div>
                    </div>
                   
                     <div class="col-md-3">

                           <div class="links" style="padding-left:15px;">
                        <h2>CONTACTO</h2>
                        <ul>
                            <li>Whatsapp: &nbsp; <a href="tel:+528111764917"  >+52 81 11764917</a></li>
                            <li>  MTY:&nbsp; <a href="tel:8147385000"  >(81) 4738 5000</a></li>
                            <li>CDMX: &nbsp;<a href="tel:5533002500" >(55) 3300 2500</a></li>
                            <li>Del Interior:  &nbsp;<a href="tel:018007020505"  > 01 800 7020505</a></li>
                            <li><asp:HyperLink ID="HyperLink31" runat="server" NavigateUrl="~/AddUserDistribuidor.aspx" CssClass="telefono">Distribuidores</asp:HyperLink> </li>
                        </ul>
                        </div>



                     
                        
                        </div>
                         


                           

        
               
                    <div class="col-md-1"></div>
                 
                </div>  
        








        <div class="row hidden-xs  hidden-md hidden-lg" >
                     <div class="col-sm-1"></div>
                     <div class="col-sm-3">
                         <div class="links" style="padding-left:15px;">
                            <h2>CONÓCENOS</h2>
                            <ul>
                                <li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Acercade.aspx">Quiénes somos</asp:HyperLink></li>
                                <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/TerminosyCondiciones.aspx">Términos de uso</asp:HyperLink></li>
                            </ul>
                         </div>
                    </div>

                   <div class="col-sm-3">
                         <div class="links" style="padding-left:15px;">
                        <h2>USUARIOS</h2>
                        <ul>
                            <li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/adduser.aspx">Regístrate</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Login.aspx">Acceso a clientes</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/PreguntasFrecuentes.aspx">Preguntas frecuentes</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/ComoComprar.aspx">Proceso de compra</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/ClausulasDeCompra.aspx">Cláusulas de compra</asp:HyperLink></li>
                        </ul>
                    </div>
                    </div>

                  
                    <div class="col-sm-3">
                         <div class="links" style="padding-left:15px;">
                        <h2>INFORMACIÓN</h2>
                        <ul>
                            <li><asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/ServicioDiseno.aspx">Diseño</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/ServicioImpresion.aspx">Impresión</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/ServicioBordado.aspx">Bordado</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/ServicioGrabado.aspx">Grabado</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/ServicioEnvio.aspx">Envío</asp:HyperLink></li>
                        </ul>
                        </div>
                    </div>
                   
                 
                    <div class="col-sm-2"></div>
                 


            
                <div class="col-sm-3"></div>
            
                <div class="col-sm-6">

                          <div style="height:30px;"></div>
                           <div class="links" style="padding-left:15px;">
                            <h2> ¡Recibe promociones exclusivas!</h2>
                        
                        </div>
                         


                             <div class="form-group" style="display:inline; width:350px;">
                                 <div class="input-group" style="display:table;">
						            <asp:TextBox ID="TextBox1" runat="server" placeholder="Escribe tu email" CssClass="form-control" UseSubmitBehavior="false"></asp:TextBox>
                                        <span class="input-group-btn" style="padding-right:10px;">
						            <asp:Button ID="Button1" runat="server" text="Suscribirme" CssClass="btn btn-success form-inline btn-suscribirme"  ></asp:Button>
                                            </span>
                                </div>
                           </div>

                        

        
                    </div>
                    <div class="col-sm-3"></div>
                </div>  








         <div class="row hidden-sm  hidden-md hidden-lg" >
                 
                     <div class="col-xs-6">
                         <div class="links" style="padding-left:15px;">
                            <h2>CONÓCENOS</h2>
                            <ul>
                                <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Acercade.aspx">Quiénes somos</asp:HyperLink></li>
                                <li><asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/TerminosyCondiciones.aspx">Términos de uso</asp:HyperLink></li>
                            </ul>
                         </div>
                    </div>

                   <div class="col-xs-6">
                         <div class="links" style="padding-left:15px;">
                        <h2>USUARIOS</h2>
                        <ul>
                            <li><asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/adduser.aspx">Regístrate</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Login.aspx">Acceso a clientes</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/PreguntasFrecuentes.aspx">Preguntas frecuentes</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="~/ComoComprar.aspx">Proceso de compra</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink25" runat="server" NavigateUrl="~/ClausulasDeCompra.aspx">Cláusulas de compra</asp:HyperLink></li>
                        </ul>
                    </div>
                    </div>

            </div> 

             <div class="row hidden-sm  hidden-md hidden-lg" >
                  
                    <div class="col-xs-6">
                         <div class="links" style="padding-left:15px;">
                        <h2>INFORMACIÓN</h2>
                        <ul>
                            <li><asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="~/ServicioDiseno.aspx">Diseño</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="~/ServicioImpresion.aspx">Impresión</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink28" runat="server" NavigateUrl="~/ServicioBordado.aspx">Bordado</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink29" runat="server" NavigateUrl="~/ServicioGrabado.aspx">Grabado</asp:HyperLink></li>
                            <li><asp:HyperLink ID="HyperLink30" runat="server" NavigateUrl="~/ServicioEnvio.aspx">Envío</asp:HyperLink></li>
                        </ul>
                        </div>
                    </div>
                   
                 
            
            
                <div class="col-xs-6">

                   <div class="links" style="padding-left:15px;">
                        <h2>CONTACTO</h2>
                        <ul>
                            <li>Whatsapp: &nbsp; <a href="tel:+528111764917"  >+52 81 11764917</a></li>
                            <li>MTY:&nbsp; <a href="tel:8147385000"  >(81) 4738 5000</a></li>
                            <li>CDMX: &nbsp;<a href="tel:5533002500" >(55) 3300 2500</a></li>
                            <li>Del Interior:  &nbsp;<a href="tel:018007020505"  > 01 800 7020505</a></li>
                       
                        </ul>

                    </div>



                     
                        
                        </div>

                 </div>
                   
          






        <div style="height:30px;"></div>


        <div class="container" style="background-color:#0087CB">
               <div style="padding-top:5px; padding-left:35px; padding-right:35px;" class="row">
                    <div class="row">
                        <div class="col-sm-12 inline text-center">
                             <asp:HyperLink ID="HyperLink21" runat="server"  NavigateUrl="https://www.facebook.com/TpTodopromocional/" ImageHeight="37px"  ImageUrl="~/images/redesociales_r1_c1.jpg"></asp:HyperLink>
                             <asp:HyperLink ID="HyperLink22" runat="server"  NavigateUrl="https://twitter.com/todopromocional"  ImageHeight="37px"  ImageUrl="~/images/redesociales_r1_c2.jpg"></asp:HyperLink>
                             <asp:HyperLink ID="HyperLink23" runat="server"  NavigateUrl="https://www.youtube.com/user/todopromocional/" ImageHeight="37px"  ImageUrl="~/images/redesociales_r1_c3.jpg"></asp:HyperLink>
                             <asp:HyperLink ID="HyperLink20" runat="server"  NavigateUrl="mailto:contacto@todopromocional.com" ImageHeight="37px"  ImageUrl="~/images/redesociales_r1_c4.jpg"></asp:HyperLink>
                        </div>

                    </div>

                </div>
            <div style="height:5px;"></div>

        </div>

 </footer>