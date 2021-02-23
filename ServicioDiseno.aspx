<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="ServicioDiseno.aspx.vb" Inherits="ServicioDiseno" %>
<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

    <div class="col-md-2 menu hidden-xs">
 
	        <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo2" runat="server" />

    </div>

     <div class="col-md-10 main">
	    <h2>Servicio de diseño</h2>

	    <p>En caso de no contar con el diseño en vectores o algún formato editable, podrá solicitar un Redibujo. 
</p>
         <p>&nbsp;</p>
         <p>Diseño enviará al ejecutivo un dummy o muestra virtual, es una imagen de cómo se vería el producto con la impresión. El ejecutivo deberá enviárselo al cliente para su aprobación o modificaciones. 
</p>
         <p>&nbsp;</p>
         <p class="text-center">
             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/serviciodiseno.jpeg" />
</p>
         <p class="text-center">
             &nbsp;</p>
         <p>Una vez que el cliente lo considere correcto, el departamento de diseño subirá el dummy al sistema para que el cliente lo autorice en su cuenta o bien a través de su ejecutivo.
</p>

      </div>
</asp:Content>

