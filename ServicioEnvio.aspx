<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="ServicioEnvio.aspx.vb" Inherits="ServicioEnvio" %>

<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

        <div class="col-md-2 menu">
       
	        <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo2" runat="server" />
        </div>


     <div class="col-md-10 main">
	<h2>Servicio de envío</h2>

	<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut facilisis dui. Duis in eros ipsum. Pellentesque commodo justo in lorem lacinia sit amet rutrum lectus cursus. Nullam ac mauris arcu.</p>
	<ul>
		<li>In dapibus</li>
		<li>Justo at eros</li>
		<li>Venenatis faucibu</li>
		<li>Phasellus blandit elementum massa</li>
	</ul>
	<p>Pretium accumsan mauris feugiat eu. Donec mauris elit, porttitor quis tempus hendrerit, condimentum at lectus. Duis aliquam ullamcorper turpis non malesuada.</p>
	<p>Etiam ac tortor augue, vitae rutrum purus. Donec risus magna, rhoncus eu interdum euismod, molestie nec magna. Curabitur sed vulputate massa. Mauris urna purus, suscipit non tempor et, pulvinar vitae dolor. Pellentesque dolor purus, luctus id malesuada in, mollis eget mauris. Integer vitae sollicitudin leo.</p>

         </div>
</asp:Content>

