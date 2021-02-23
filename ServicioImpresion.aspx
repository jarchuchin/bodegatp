<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="ServicioImpresion.aspx.vb" Inherits="ServicioImpresion" %>

<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

     <div class="col-md-2 menu hidden-xs">

	        <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo2" runat="server" />

    </div>

     <div class="col-md-10">
	<h2>Servicio de impresión</h2>

	<p>En Todo Promocional brindamos servicio de serigrafía ya que contamos con maquinaria automática y semiautomática para trabajar rápidamente.

Estos son algunos de los productos con los que podemos trabajar 
</p>

	<p>
        <a href="https://todopromocional.com/Productos/show/17515/%C3%A1nforas-cilindros-bebidas-eventos-xv-a%C3%B1os-graduaci%C3%B3n-boda-anfora-promocionales-promocional-lake-anf,006"><asp:Image ID="Image1" runat="server"  ImageUrl="https://todopromocional.com/siteadmin/files/productos/images/med/44340.jpg" Width="150px" />

        </a>
        <div style="height:20px;"></div>

       <a href="https://todopromocional.com/Productos/show/21577/bolsas-expo-ferias-eco-reciclaje-campa%C3%B1as-bolsa-promocionales-promocional-ecol%C3%B3gica-environment-sin,230"><asp:Image ID="Image2" runat="server" ImageUrl="https://todopromocional.com/siteadmin/files/productos/images/ch/24429.jpg"  Width="150px"  />
        </a>
           <div style="height:20px;"></div>


        <a href="https://todopromocional.com/Productos/show/1453/playera-textil-camiseta-campa%C3%B1a-verano-uniforme-playera-promocionales-promocional-para-caballero-c0300"> <asp:Image ID="Image3" runat="server" ImageUrl="https://todopromocional.com/siteadmin/files/productos/images/ch/44891.png"  Width="150px"  /></a>

           <div style="height:20px;"></div>

        <a href="https://todopromocional.com/Productos/show/17125/bolsa-fp-bl,007-promocionales-promocional-bl,007"> <asp:Image ID="Image4" runat="server" ImageUrl="https://todopromocional.com/siteadmin/files/productos/images/ch/20031.jpg" Width="150px" /></a>
         </p>

         </div>
</asp:Content>


