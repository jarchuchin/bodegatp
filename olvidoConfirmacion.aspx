<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="olvidoConfirmacion.aspx.vb" Inherits="olvidoConfirmacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

      


 <table width="100%" border="0" cellpadding="0" cellspacing="2" >
		
		 <tr class="line">
		  <td >
			 <h2><asp:Label ID="lblcotizar" runat="server"  ></asp:Label></h2></td>
		  <td align="right" valign="middle" class="txt-black-13"><strong>Fecha:</strong> <asp:Label 
				  ID="lblfecha" runat="server" ></asp:Label>
			</td>
		</tr>
        <tr>
          <td colspan="2" valign="middle" align="center">

          <p class="title1"><span class="title2"><img src="images/ico-ok.png" width="20" height="19" alt="ok" /></span> Recuperación de datos<br />
                  </p>
              <br />
              <br />
              <br />
    <asp:Label ID="Label8" runat="server" 
        Text="¡Hemos enviado los datos solicitados!" 
          Font-Bold="True"></asp:Label>
              <br />
    <asp:Label ID="Label3" runat="server" 
        Text="En breve los recibirás en tu email" 
         ></asp:Label>
    
              <br />
    <asp:Label ID="Label9" runat="server" 
        Text="¡Gracias por preferir Todopromocional!." ></asp:Label>
    <br />
              <br />
              <br />
              <br />
    <asp:Label ID="Label10" runat="server" 
        Text="Te invitamos a seguirnos en:" Font-Size="12px" 
                  meta:resourceKey="Label2Resource1"  ></asp:Label>
    <br />
    
       <asp:HyperLink ID="lnkFacebook" runat="server" 
                      text="Compartir en Facebook" CssClass="LigaProducto" Font-Size="11px"  NavigateUrl="http://www.facebook.com/todopromocional"
                      target="_blank" ImageUrl="~/images/images02/confirmacionFacebook.jpg" ></asp:HyperLink>
                                  
                                &nbsp;
                                  
                            
              &nbsp;<asp:HyperLink ID="lnktwitter" runat="server"  navigateurl="http://twitter.com/todopromocional"
                      text="Compartir en Twitter" CssClass="LigaProducto" Font-Size="11px"  
                      target="_blank" ImageUrl="~/images/images02/confirmacionTwitter.jpg"  ></asp:HyperLink>
    
    
              <br />
    <asp:Label ID="Label11" runat="server" 
        Text="¡Para que recibas nuestras promociones antes que otros!" Font-Size="12px" 
                  meta:resourceKey="Label2Resource1"  ></asp:Label>
    <br />
    <br />
                    <br />
                    <br />
    <table border="0" cellspacing="5" cellpadding="0">
                    <tr>
                      <td></td>
                      </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />

    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" navigateurl="~/Default.aspx" 
        Font-Bold="True"  CssClass="link-purple" >www.todopromocional.com</asp:HyperLink>
              <br />
              <br />
              <br />
              <br />
              <br />
    <br />
            </td>
          </tr>
          
          </table>
    
    
    
    
    
    
        
<div style="height:20px"></div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

