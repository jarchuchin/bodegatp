<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="ServicioBordado.aspx.vb" Inherits="ServicioBordado" %>
<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	
      <div class="col-md-2 menu hidden-xs">

	        <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo2" runat="server" />

    </div>

     <div class="col-md-10">
    <h2>Servicio de bordado</h2>

	<p>En Todo Promocional, contamos con servicio de bordado y la mejor calidad en cada puntada, para brindarte un servicio rápido y eficaz en todas tus necesidades.

</p>
         <p>Estos son algunos de los productos con los que podemos trabajar:
</p>


                <div style="height:20px;"></div>
        <a href="https://todopromocional.com/Productos/show/19957/textil-playera-polo-uniforme-playera-promocionales-promocional-yager-ply,002">  <asp:Image ID="Image1" runat="server"  ImageUrl="https://todopromocional.com/siteadmin/files/productos/images/gde/22809.jpg" Width="150px" /></a>


        <div style="height:20px;"></div>

        <a href="https://todopromocional.com/Productos/show/31657/mochila-escolar-mochila-promocionales-promocional-fort-c531"> <asp:Image ID="Image2" runat="server" ImageUrl="https://todopromocional.com/siteadmin/files/productos/images/ch/44252.jpg"  Width="150px"  />
         </a>

           <div style="height:20px;"></div>


        <a href="https://todopromocional.com/Productos/show/29828/gorra-verano-gorro-promocionales-promocional-favourite-g215"> <asp:Image ID="Image3" runat="server" ImageUrl="https://todopromocional.com/siteadmin/files/productos/images/ch/40083.jpg"  Width="150px"  />
         </a>

           <div style="height:20px;"></div>

        <a href="https://todopromocional.com/Productos/show/30363/chamarra-invierno-textil-uniforme-chamarra-promocionales-promocional-norfolk-chm,010"> <asp:Image ID="Image4" runat="server" ImageUrl="https://todopromocional.com/siteadmin/files/productos/images/ch/41416.jpg" Width="150px" />
   
</a>


         </div>
</asp:Content>

