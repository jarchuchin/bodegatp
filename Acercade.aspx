<%@ Page Title="Acerca de" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Acercade.aspx.vb" Inherits="Acercade" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register src="controles/DisplayMenuLateralIzquierdo.ascx" tagname="DisplayMenuLateralIzquierdo" tagprefix="uc5" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    <div class="col-md-2  hidden-sm hidden-xs menu">
			        <uc5:DisplayMenuLateralIzquierdo ID="DisplayMenuLateralIzquierdo1" runat="server" />

			</div>

	<div class="col-md-10 col-sm-12 col-xs-12">
	        <h2>La compañía más grande de artículos promocionales en México</h2>
          <div style="height:10px;"></div>
           <a href="https://www.youtube.com/watch?t=1&v=Fa5ymBVR5OA" target="_blank">
                        <img src="images/videopromotodopromocional.jpg" /></a>
            
	        <div style="height:20px;"></div>
				<div style="max-width:90%;">
                    <img src="images/mapa1.gif" alt="exhibidor" width="289" height="195" style="float:left; padding-right:20px; padding-bottom:20px;" />
                    Somos la Concentradora de articulos promocionales más grande y completa de todo México, contamos un extenso catálogo con miles de productos que mostramos a traves de la Web y de un extenso exhibidor fisico.
				<p class="txt-black1">Damos  servicio a 313 ciudades en los 32 estados de la república mexicana desde la oficina matriz en la ciudad de Monterrey y la oficina de ventas en la capital de México; nuestro equipo directivo cuenta con una experiencia de mas de 10 años en el mercado, conformando en equipo una empresa respetable y reconocida a nivel nacional.</p>
				<p class="txt-black1">Contamos con la capacidad logística para una distribucion ágil  a toda la república y la infraestructura tecnológica para una producción de la mayor calidad con entregas en menor tiempo.</p>
				<p class="txt-black1">
                    <img src="images/Excibicion.jpg" width="289" style="float: right; padding-right:20px; padding-bottom:20px;"  alt="exhibidor" />
                    Nuestra tecnología de impresión incluye servicios como Serigrafía automática, tampografía con maquinaria GPE y Winon, así como serigrafía tradicional, bordado, grabado lasser, grabado punta diamante, hot stamping entre otros.</p>
				<p class="txt-black1">Todopromocional forma parte de la AMPPRO (Asociación Mexicana de Profesionales de la Promoción A.C.), CANACO (Camara Nacional del Comercio) y AMIPCI (La Asociación Mexicana de Internet), impulsando el mercado de los artículos promocionales en México.</p>
				<p class="txt-black1">Importantes marcas de artículos promocionales avalan nuestra calidad de servicio. Nuestro principal objetivo es <br />
                    mejorar día con día nuestra oferta, fortaleciendo las relaciones comerciales con clientes y proveedores.</p>
				<p class="title4">Nuestro Compromiso</p>
				<p class="txt-black1">El conocer las necesidades de nuestro cliente, nos da la oportunidad de servirle mejor al ofrecer productos y servicios de calidad que -generan la satisfacción total de nuestros clientes, derivada de nuestro mejor                  esfuerzo, compromiso y capacitación constante. </p>
				<p class="txt-black1">Construir día a día una sólida                  red de proveedores que permita asegurar el mejor y más amplio catálogo de                  artículos, así como el mejor precio y calidad. Brindar a nuestros clientes un                  modo fácil, ágil y seguro de comprar artículos promocionales, consolidándonos                  así como líderes en el mercado de los promocionales, posicionándonos como un                  generador de soluciones reales y efectivas que aportan valor a nuestros                  clientes. </p>
				      
				<p><br /></p>
				<p class="txt-black1">Servimos a clientes en más de 313 ciudades</p>
				     </div>
         </div>
</asp:Content>
