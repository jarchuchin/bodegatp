<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Header.ascx.vb" Inherits="Controles_Header" %>

<%@ Register src="DisplayCategories.ascx" tagname="DisplayCategories" tagprefix="uc1" %>




<header>



    <div class="container" style="height:25px; background-color:#0087CB;" runat="server" id="barraLogin" >
       
        <div class="row" style="margin-top:3px;" >
                <div class="col-md-3 col-xs-8"><asp:Label ID="lblbienvenido" runat="server" Text="Bienvenido"></asp:Label></div>
                <div class="col-md-7 hidden-xs">Recuerda que en <asp:HyperLink ID="lnkMiespacio1" runat="server" NavigateUrl="~/sec/home.aspx">MI ESPACIO</asp:HyperLink> puedes ver tus cotizaciones, traking de tus pedidos y mucho más!</div>
                <div class="col-md-2 col-xs-4 text-center"><asp:HyperLink ID="lnkMiespacio2" runat="server" NavigateUrl="~/login.aspx">MI ESPACIO</asp:HyperLink></div>
          </div>
    </div>

    <div class="container hidden-xs" style="background-color:#0087CB">
        <div style="height:40px; padding-top:13px; padding-left:35px; padding-right:35px;" class="row">
            <div class="col-sm-8 telefono">
                     <b>Whatsapp:</b>  <a href="tel:+528117649645" class="telefono" >+52 811 7649645</a>&nbsp;&nbsp;
                    <b>  MTY:</b>&nbsp; <a href="tel:8147385000" class="telefono" >(81) 4738 5000</a>&nbsp;&nbsp;
                      <b>CDMX:</b> &nbsp;<a href="tel:5533002500" class="telefono" >(55) 3300 2500</a>&nbsp;&nbsp;                    
                      <b>Del Interior:</b><a href="tel:018007020505" class="telefono" > 01 800 7020505</a>
               <%--   <b>Teléfono:</b><a href="tel:8130670300" class="telefono" > 81 3067 0300</a>--%>
                &nbsp;
            </div>
            <div class="col-sm-4 telefono text-right">
               <b class="hidden-sm hidden-md"> <asp:Label ID="Label1" runat="server" Text="Bienvenido"></asp:Label></b>
               &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/sec/home.aspx" CssClass="telefono">Mi cuenta</asp:HyperLink>&nbsp;|&nbsp;
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Contacto.aspx" CssClass="telefono">Contacto</asp:HyperLink> &nbsp;|&nbsp;
                  <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/AddUserDistribuidor.aspx" CssClass="telefono">Distribuidores</asp:HyperLink> &nbsp
            </div>
        </div>
    </div>

     <div class="container hidden-sm hidden-md hidden-lg" style="background-color:#0087CB">
        <div style="height:60px; padding-top:13px;" class="row">
          
            <div class="col-xs-12 telefono text-center">
                    <b>Whatsapp:</b>  <a href="tel:+528117649645" class="telefono" >+52 811 7649645</a>&nbsp;&nbsp;
                      <b>  MTY:</b>&nbsp; <a href="tel:8147385000" class="telefono" >(81) 4738 5000</a>&nbsp;&nbsp;
                      <b>CDMX:</b> &nbsp;<a href="tel:5533002500" class="telefono" >(55) 3300 2500</a>&nbsp;&nbsp;                    
                    <%--  <b>Del Interior:</b><a href="tel:018007020505" class="telefono" > 01 800 7020505</a>--%>
              <%--  
                 <b>Teléfono:</b><a href="tel:8130670300" class="telefono" > 81 3067 0300</a>--%>
                &nbsp;


                

           <br />

               <b><asp:Label ID="Label2" runat="server" Text="Bienvenido"></asp:Label></b> 
               &nbsp;|&nbsp; <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/sec/home.aspx" CssClass="telefono">Mi cuenta</asp:HyperLink>&nbsp;|&nbsp;
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Contacto.aspx" CssClass="telefono">Contacto</asp:HyperLink> &nbsp;|&nbsp;
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/AddUserDistribuidor.aspx" CssClass="telefono">Distribuidores</asp:HyperLink> &nbsp
            </div>
              </div>

    </div>
     



     <!--INICIA MENU XS-->
      <div class="container hidden-sm hidden-md hidden-lg">
     
         
          <div  class="row" >
              <div class="col-xs-12 text-center">
                  <div style="height:20px;"></div>
                  <asp:hyperlink ID="Hyperlink1"  NavigateUrl="~/default.aspx"  runat="server" >
                          <asp:image runat="server" ID="Image2"  ImageUrl="~/images/header/logo-tp-desk.png" style="height:60px;"   />
                    </asp:hyperlink>
              </div>
              
              
                   
              
          </div>
          <div class="row">
            
              <div class="col-xs-12" id="divbuscar2" runat="server" >

                  
                    <div class="navbar-form form-inline" style=" width:100%; margin-top:20px;" >   
                        <div class="form-group" style="display:inline; ">
                            <div class="input-group" style="display:table;Width:100%;">
                           
                                <asp:TextBox ID="txtbuscar2" runat="server" placeholder="Realiza tu búsqueda aquí" CssClass="form-control form-inline" autocomplete="off"  Height="44px" Width="100%" style="border-radius: 0px; border: 1px solid #9F9F9F;"></asp:TextBox>
                                <span class="input-group-btn" >
                                    <asp:image ID="btnBuscar2" runat="server" ImageUrl="~/images/btnBuscar2019.png"    style="margin-top:-1px; cursor: pointer;" />
                                </span>  
                            </div>
                        </div>
                    </div>
                  </div>

            
               
               
          </div>
          <div class="row">
               <div class="col-xs-12 form-inline text-center" >
                      <div class="form-inline inline-block" >

                         <div class=" text-center"  style=" margin-top:2px;">
                             <asp:HyperLink ID="Hyperlink6"  navigateurl="~/Contacto.aspx" runat="server" ImageUrl="~/images/carrito2019.jpg" ImageWidth="40px"></asp:HyperLink>
                             <asp:Label ID="Label4" runat="server" Text="0 Articulos"></asp:Label>
                    
                        </div>
                    </div>  
                </div>
          </div>
    </div>
    <!--FUN MENU XS-->

    <!--INICIA MENU SM-->
    <div class="container hidden-xs hidden-md hidden-lg">
     
         
          
            <div class="row">
                
                <div class="col-sm-4" >
                
                    <asp:hyperlink ID="lnklogosm"  NavigateUrl="~/default.aspx" style=" padding-left:32px;"  runat="server">
                          <asp:image runat="server" ID="imglogosm"  CssClass="img-center"  ImageUrl="~/images/header/logo-tp-desk.png" style="position:absolute; top:0; bottom:0; margin-top:20px; height:60px;" />
                    </asp:hyperlink>
                </div>
                <div class="col-sm-5" >

                        <div class="navbar-form form-inline" style="display: inline-block;  width:100%;  margin-top:25px;"  id="divbuscar" runat="server">   
                            <div class="form-group" style="display:inline; ">
                                <div class="input-group" style="display:table;Width:355px;">
                           
                                    <asp:TextBox ID="txtbuscarsm" runat="server" placeholder="Realiza tu búsqueda aquí" CssClass="form-control form-inline" autocomplete="off"  Height="44px" Width="300px" style="border-radius: 0px; border: 1px solid #9F9F9F;"></asp:TextBox>
                                    <span class="input-group-btn" >
                                        <asp:image ID="btnBuscarsm" runat="server" ImageUrl="~/images/btnBuscar2019.png"   style="margin-top:-1px; cursor: pointer;" />
                                    </span>  
                                </div>
                            </div>
                        </div>

              </div>
              <div class="col-sm-3 form-inline text-right" >
        
                    <div class="form-inline inline-block" style="margin-top:25px;">

                         <div class=" text-right"  style=" margin-top:2px;">
                             <asp:HyperLink ID="Hyperlink7"  navigateurl="~/Contacto.aspx" runat="server" ImageUrl="~/images/carrito2019.jpg" ImageWidth="40px"></asp:HyperLink>
                             <asp:Label ID="Label3" runat="server" Text="0 Articulos"></asp:Label>
                    
                        </div>
                    </div>       


              </div>
                           
          </div>

    </div>
    <!--FUN MENU SM-->

    <!--INICIA MENU MD LG-->
    <div class="container hidden-xs hidden-sm">
     
         
          
            <div class="row">
                
                <div class="col-md-4" >
                
                    <asp:hyperlink ID="lnklogo"  NavigateUrl="~/default.aspx" style=" padding-left:32px;"  runat="server">
                          <asp:image runat="server" ID="imglogo"  CssClass="img-center"  ImageUrl="~/images/header/logo-tp-desk.png" style="position:absolute; top:0; bottom:0; margin-top:20px; height:60px;" />
                    </asp:hyperlink>
                </div>
                <div class="col-md-5" >

                        <div class="navbar-form form-inline" style="display: inline-block;  width:100%;  margin-top:25px;" id="divbuscar3" runat="server" >   
                            <div class="form-group" style="display:inline; ">
                                <div class="input-group" style="display:table;Width:355px;">
                           
                                    <asp:TextBox ID="txtbuscar" runat="server" placeholder="Realiza tu búsqueda aquí" CssClass="form-control form-inline" autocomplete="off"  Height="44px" Width="380px" style="border-radius: 0px; border: 1px solid #9F9F9F;"></asp:TextBox>
                                    <span class="input-group-btn" >
                                        <asp:image ID="btnBuscar" runat="server" ImageUrl="~/images/btnBuscar2019.png"   style="margin-top:-1px; cursor: pointer;" />
                                    </span>  
                                </div>
                            </div>
                        </div>

              </div>
              <div class="col-md-3 form-inline text-center" >
        
                    <div class="form-inline inline-block" style="margin-top:25px;">

                         <div class=" text-center"  style=" margin-top:2px;">
                             <asp:HyperLink ID="Hyperlinks5"  navigateurl="~/Contacto.aspx" runat="server" ImageUrl="~/images/carrito2019.jpg" ImageWidth="40px"></asp:HyperLink>
                             <asp:Label ID="lblArticulo" runat="server" Text="0 Articulos"></asp:Label>
                    
                        </div>
                    </div>       


              </div>
                           
          </div>

    </div>
    <!--FUN MENU MD LG-->    




          
       
       




<div style="height:15px;"></div>

    <asp:Literal ID="litscript" runat="server"></asp:Literal>
      <asp:Literal ID="litscript2" runat="server"></asp:Literal>
</header>

<uc1:DisplayCategories ID="DisplayCategories1" runat="server" />


<div id="barramenu" class="container menuCategorias" runat="server" visible="false" >

    <h4>CATÁLOGOS</h4>

    <asp:DataList ID="dtlCategorias" runat="server" RepeatColumns="3" >
        <ItemTemplate>
            <asp:HyperLink ID="lnkNombre" runat="server" style="padding-left:20px;" NavigateUrl='<%# "~/categorias/show/" & Eval("idCategoria") & "/" & getTags(Eval("tags"), Eval("metaKeywords"))%>' Text='<%# eval("Nombre") %>'   ></asp:HyperLink>
        </ItemTemplate>
    </asp:DataList>
</div>
<div id="barramenu2" class="container menuCategorias" runat="server" visible="false" >

    <h4>CATÁLOGOS</h4>

    <asp:DataList ID="dtlCategorias2" runat="server" RepeatColumns="2" >
        <ItemTemplate>
            <asp:HyperLink ID="lnkNombre" runat="server" style="padding-left:20px;" NavigateUrl='<%# "~/categorias/show/" & Eval("idCategoria") & "/" & getTags(Eval("tags"), Eval("metaKeywords"))%>' Text='<%# eval("Nombre") %>'   ></asp:HyperLink>
        </ItemTemplate>
    </asp:DataList>
</div>