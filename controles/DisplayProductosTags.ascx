<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayProductosTags.ascx.vb" Inherits="controles_DisplayProductosTags" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>




<style type="text/css">
    .auto-style1 {
        width: 69px;
    }
</style>
<div class="hidden-md hidden-lg" style="height:10px"></div>
<div class="text-center">
 <button id="showmenu" type="button" class="btn btn-success btn-suscribirme hidden-md hidden-lg"  >Refinar búsqueda</button>
</div>
<%--		<div class="">
            This should go left asdfasdf
           
</div>
--%>


<div class="col-md-2  hidden-sm hidden-xs menu sidebarmenu" id="menulateralizq" >

    <div style="height:15px"></div>

    <div class="menuFiltrar">      
        <h4>ORDENAR</h4>

       <%-- <asp:RadioButton ID="rblOrden1" Checked="true" runat="server" Text="Orden Alfabético" value="Nombre asc" />
        <asp:RadioButton ID="rblOrden2" Checked="true" runat="server" Text="Económicos a caros" value="Precio asc" />
        <asp:RadioButton ID="rblOrden3" Checked="true" runat="server" Text="Caros a económicos" value="Precio desc" />--%>
   
        <div class="radio">
        <asp:RadioButtonList ID="rblOrden1x" runat="server">
            <asp:ListItem Text="Relevancia" Value="relevancia desc" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Orden Alfabético" Value="Nombre asc" ></asp:ListItem>
            <asp:ListItem Text="Menor a mayor precio" Value="Precio asc"></asp:ListItem>
            <asp:ListItem Text="Mayor a menor precio" Value="Precio desc"></asp:ListItem>
            <asp:ListItem Text="Clave" Value="clave asc"></asp:ListItem>
        </asp:RadioButtonList>
        </div>

        <div style="height:10px;"></div>

        <h4>COLORES</h4>
        <div class="check">
           
            <asp:checkboxlist ID="chkColores" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CssClass="hiddenText">
                <asp:ListItem    Value="Todos" Selected="True" ></asp:ListItem>
                <asp:ListItem    Value="Rojo" ></asp:ListItem>
                <asp:ListItem    Value="Naranja"></asp:ListItem>
                <asp:ListItem    Value="Verde"></asp:ListItem>
                <asp:ListItem     Value="Azul"></asp:ListItem>
                <asp:ListItem     Value="Amarillo"></asp:ListItem>
                <asp:ListItem     Value="Cafe"></asp:ListItem>
                <asp:ListItem     Value="Morado"></asp:ListItem>
                <asp:ListItem    Value="Negro"></asp:ListItem>
                <asp:ListItem    Value="Gris"></asp:ListItem>
                <asp:ListItem     Value="Blanco"></asp:ListItem>
            </asp:checkboxlist>
        </div>

        <div style="height:10px;"></div>

        <h4>PRECIO</h4>
        <asp:DropDownList ID="drpPrecios" runat="server" CssClass="form-control form-inline" Width="200px">
					<asp:ListItem Value="">Rango de precios</asp:ListItem>
					<asp:ListItem Value="0-5">Menos de $5</asp:ListItem>
					<asp:ListItem Value="5-10">$5 a $10</asp:ListItem>
					<asp:ListItem Value="10-25">$10 a $25</asp:ListItem>
					<asp:ListItem Value="25-50">$25 a $50</asp:ListItem>
					<asp:ListItem Value="50-100">$50 a $100</asp:ListItem>
					<asp:ListItem Value="100-300">$100 a $300</asp:ListItem>
					<asp:ListItem Value="300-10000">$300 o más</asp:ListItem>
				</asp:DropDownList>
        <div style="height:5px;"></div>


        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Desde:<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtdesde" ErrorMessage="Fuera de rango" MaximumValue="100000" MinimumValue="0.01" Type="Currency">*</asp:RangeValidator>
                    <ajaxToolkit:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender" runat="server" BehaviorID="RangeValidator1_ValidatorCalloutExtender" TargetControlID="RangeValidator1">
                    </ajaxToolkit:ValidatorCalloutExtender>
                </td>
                <td style="padding-bottom:5px;"><asp:TextBox ID="txtdesde" runat="server"   CssClass="form-control"></asp:TextBox></td>
            </tr>
           
            <tr>
                <td class="auto-style1">Hasta:

                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txthasta" ErrorMessage="Fuera de rango" MaximumValue="100000" MinimumValue="0.01" Type="Currency">*</asp:RangeValidator>
                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" BehaviorID="RangeValidator2_ValidatorCalloutExtender" TargetControlID="RangeValidator2">
                    </ajaxToolkit:ValidatorCalloutExtender>

                </td>
                <td><asp:TextBox ID="txthasta" runat="server"   CssClass="form-control"></asp:TextBox></td>
            </tr>
        </table>

        <div style="height:10px;"></div>
          <h4>MATERIAL</h4>
         <div class="check">
        <asp:checkboxlist ID="chkMaterial" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
            <asp:ListItem Text="Todos" Value="Todos" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Metálicos" Value="Metálicos"></asp:ListItem>
            <asp:ListItem Text="Tela" Value="Tela"></asp:ListItem>
            <asp:ListItem Text="Plástico" Value="Plástico"></asp:ListItem>
            <asp:ListItem Text="Papel" Value="Papel"></asp:ListItem>
            <asp:ListItem Text="Piedra" Value="Piedra"></asp:ListItem>
            <asp:ListItem Text="Madera" Value="Madera"></asp:ListItem>
    
        </asp:checkboxlist>
        
        <div style="height:10px;"></div>
        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" CssClass="btn btn-success btn-suscribirme" />
         <div style="height:20px;"></div>
    </div>
    </div>


</div>
  
<div class="col-md-10 col-sm-12 col-xs-12">

<div style="height:5px;"></div>
<h2>
	<asp:Label ID="lblNombreCatego" runat="server"></asp:Label> <asp:Label ID="lblArticulos" runat="server" Font-Bold="false" CssClass="txt-gray2" Text="Resultados" Style="padding-left:100px;"></asp:Label>
</h2>
<div style="height:15px;"></div>
<div class="divisorHorizontal"></div>
<div style="height:15px;"></div>

<div class="row">
    <div class="col-md-6"><table style="width:330px;">
		<tr>
			<td style="width:130px">
				<%--<asp:DropDownList ID="drpOrdernar" runat="server" AutoPostBack="True"  CssClass="form-control form-inline" Width="130px">
					<asp:ListItem Value="Nombre">Nombre</asp:ListItem>
					<asp:ListItem Value="Precio">Precio</asp:ListItem>
					<asp:ListItem Value="idProducto">Clave</asp:ListItem>
				</asp:DropDownList>--%>
            </td>
            <td style="width:200px">
				
			</td>
		</tr>
		</table></div>
    <div class="col-md-6" style="text-align:right;">
<div class="btn-toolbar pull-right" >

  <div class="btn-group" role="group" aria-label="Second group">
    <asp:Button ID="btnPaginas01" runat="server" Text="<" cssclass="btn btn-default"  />
  </div>
  <div class="btn-group" >
      <asp:Repeater ID="rptPaginas1" runat="server">
          <ItemTemplate>
              <asp:Button ID="btnPaginas" runat="server" Text='<%# Eval("pagina")%>' cssclass='<%# "btn btn-default " & BotonActivo(Eval("inicio"), Eval("fin"))%>' OnClick="paginar" CommandArgument='<%# Eval("inicio") & "," & eval("fin")%>' visible='<%# presentarBoton(eval("pagina")) %>' />
         
          </ItemTemplate>
          <FooterTemplate>
              <asp:Label ID="lblMasPaginas" runat="server" Text="..." font-size="33px" ForeColor="gray" Visible='<%# presentarPuntos() %>'></asp:Label>
          </FooterTemplate>
      </asp:Repeater>
  </div>
  <div class="btn-group" role="group" aria-label="Third group">
    <asp:Button ID="btnPaginas02" runat="server" Text=">" cssclass="btn btn-default"  />
  </div>
</div></div>
</div>

	
<div style="height:5px;"></div>


<asp:GridView ID="GridView1" runat="server"></asp:GridView>

	
	
       <div class="row">
         

             <asp:Repeater ID="rptproductos" runat="server">
                 <ItemTemplate>
                     <div class="col-md-3 col-sm-4 col-xs-6 text-center" >
					    <div style="height:15px;"></div>
                        <asp:HyperLink ID="lnkProductoI" runat="server" ClientIDMode="Predictable" Style="cursor:pointer;" NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave")) & "?idc=" & categoria  %>' Tooltip='<%# getNombre(Eval("nombre"), False) %>'>
                        <asp:Image ID="Image4" runat="server" imageurl='<%# carpetafiles & Eval("imagen") %>' AlternateText='<%# getNombre(Eval("nombre"), False) %>'  height="176px" />
                        </asp:HyperLink>
                        <asp:HiddenField ID="hiddenIdProducto" ClientIDMode="Predictable" runat="server" Value='<%# "Producto.aspx?idProducto=" & Eval("idProducto")%>' />
                         <div style="height:5px;"></div>

                        <div style="height: 50px;">
                        <asp:HyperLink ID="lnkProducto" runat="server" ClientIDMode="Predictable" CssClass="productoElemento"  NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave")) & "?idc=" & categoria  %>' Text='<%# getNombre(Eval("nombre")) %>' Tooltip='<%# getNombre(Eval("nombre"), False) %>'></asp:HyperLink>
                        </div>
                       


                        <div style="height:3px;"></div>
                       <%-- <asp:Button ID="btnPrecio" runat="server" CssClass="btn btn-default btn-desde" Text='<%# "Desde " & Format(Eval("precio"), "c") %>' />--%>
                           <asp:Label ID="lblPrecioD" runat="server" CssClass="labeldesde"  Text='<%# "Desde " & Format(Eval("precio"), "c") %>'></asp:Label>
                            <div style="height:10px;"></div>
                        <asp:HyperLink ID="lnkPrecioDesde" runat="server" ClientIDMode="Predictable" CssClass="btn btn-default btn-desde"  NavigateUrl='<%# "~/Productos/show/" & Eval("idProducto") & "/" & getTags(Eval("tags"), Eval("nombre"), Eval("clave")) & "?idc=" & categoria  %>'  Text="Cotizar"></asp:HyperLink>

                        <%--<div style="height:3px;"></div>
                        <asp:Label ID="Label5" runat="server" Text="Desde " cssclass="desde"></asp:Label>
                        
                        <asp:Label ID="Label6" runat="server" Text='<%# format(eval("precio"), "c") %>' cssclass="desde"></asp:Label>--%>
                        <div style="height:2px;"></div>
                        <asp:Label ID="Label1" runat="server" Text="Clave: " CssClass="txt-gray2"></asp:Label>
                         <asp:Label ID="Label2"   runat="server"  Text='<%# getclave(Eval("clave"), Eval("idProducto"))%>' CssClass="txt-gray2"></asp:Label>
                     <div style="height:15px;"></div>
                     </div>
                 </ItemTemplate>
             </asp:Repeater>



    </div>



           
<div style="height:10px"></div>
<div class="btn-toolbar pull-right" >

  <div class="btn-group" role="group" aria-label="Second group">
    <asp:Button ID="btnPaginas03" runat="server" Text="<" cssclass="btn btn-default"  />
  </div>
  <div class="btn-group" >
      <asp:Repeater ID="rptPaginas2" runat="server">
          <ItemTemplate>
              <asp:Button ID="btnPaginas" runat="server" Text='<%# Eval("pagina")%>' cssclass='<%# "btn btn-default " & BotonActivo(Eval("inicio"), Eval("fin"))%>' OnClick="paginar" CommandArgument='<%# Eval("inicio") & "," & eval("fin")%>' visible='<%# presentarBoton(eval("pagina")) %>' />
         
          </ItemTemplate>
          <FooterTemplate>
              <asp:Label ID="lblMasPaginas" runat="server" Text="..." font-size="30px" ForeColor="gray" Visible='<%# presentarPuntos() %>'></asp:Label>
          </FooterTemplate>
      </asp:Repeater>
  </div>
  <div class="btn-group" role="group" aria-label="Third group">
    <asp:Button ID="btnPaginas04" runat="server" Text=">" cssclass="btn btn-default"  />
  </div>
</div>

<div style="height:10px"></div>

<h3>Contenido relacionado</h3>
<div style="padding-bottom:15px;">
    <asp:Label ID="lbltagstitle" runat="server"></asp:Label>
</div>

<asp:Label ID="lblinicio" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblFin" runat="server" Visible="False">0</asp:Label>
<asp:Label ID="lblSize" runat="server" Visible="False">50</asp:Label>
<asp:Label ID="lblArt" runat="server" Visible="False">Resultados</asp:Label>
<asp:Label ID="lblcategoria" runat="server" Visible="False"></asp:Label>
<asp:Label ID="lbltags" runat="server" Visible="False"></asp:Label>
</div>
