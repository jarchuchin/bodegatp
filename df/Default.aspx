<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage01.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="df_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    <div></div>
    <asp:Image ID="Image1" ImageUrl="~/images/ciudadMexico.jpg" runat="server" Width="765px" />
    <div style="height:20px"></div>

      <div class="oficinas">
                <ul>
                    <li class="df">
                        <h3>Distrito Federal</h3>
                        <p>
                            Isabel La Católica No. 846<br />
                            Col. Postal, Delegación Benito Juárez<br />
                            C.P. 03410 Mexico D.F.
                        </p>
                        <p><strong>Tel: (55) 56588841</strong></p>
                      
                    </li>
                    </ul>
          </div>
    
    <div style="height:20px"></div>
    MAPA
    <div style="height:20px"></div>
    <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d1881.7308991848438!2d-99.1421511!3d19.3924432!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0000000000000000%3A0x0a1aae43bc14a30b!2sTP+TOO+PROMOCIONAL!5e0!3m2!1sen!2scm!4v1414426100502" width="100%" height="325" frameborder="0" style="border:0"></iframe>



</asp:Content>

