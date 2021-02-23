<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayCategories.ascx.vb" Inherits="controles_DisplayCategories" %>



<div style="width:100%; background-color:#F2F2F2;">
      <div style="height:15px;"></div>

    <!--SECCION MD-->
    <div class="container hidden-xs hidden-sm">
    
        <div class="row">
            <div class="col-xs-12 text-center" >

          
                
                     <asp:hyperlink ID="lnk12" style="padding-left:11px;" CssClass="catagoriasHeader"  navigateurl="~/cats/pdfs.aspx?tipo=catalogo" runat="server" >Catálogos Pdf's  <i class="fas fa-sort-down"></i></asp:hyperlink>
           
                     &nbsp;&nbsp;&nbsp;
           
                     <asp:hyperlink ID="lnk22" style="padding-left:11px;" CssClass="catagoriasHeader"  navigateurl="~/cats/Eventos.aspx" runat="server">Para Eventos <i class="fas fa-sort-down"></i></asp:hyperlink>
           
                   &nbsp;&nbsp;&nbsp;
     
                     <asp:hyperlink ID="knk32" style="padding-left:11px;" CssClass="catagoriasHeader" navigateurl="~/cats/Oficios.aspx" runat="server" >Para Oficios <i class="fas fa-sort-down"></i></asp:hyperlink>
            
                   &nbsp;&nbsp;&nbsp;
     
                     <asp:hyperlink ID="lnk42" style="padding-left:11px;" CssClass="catagoriasHeader "  navigateurl="~/cats/Negocios.aspx" runat="server" Text="POR NEGOCIOS">Para Negocios <i class="fas fa-sort-down"></i></asp:hyperlink>


                        &nbsp;&nbsp;&nbsp;
            
               
                         <asp:hyperlink ID="lnk52" style="padding-left:11px;" CssClass="catagoriasHeader "  navigateurl="~/cats/Temporada.aspx" runat="server" >Por Temporada <i class="fas fa-sort-down"></i></asp:hyperlink>

                     
                   &nbsp;&nbsp;&nbsp;
                 
                         <asp:hyperlink ID="lnk62" style="padding-left:11px;" CssClass="catagoriasHeader " navigateurl="~/buscar.aspx?tipo=deportivos" runat="server"> Deportivos <i class="fas fa-sort-down"></i></asp:hyperlink>
                           

                         &nbsp;&nbsp;&nbsp;
                         <asp:hyperlink ID="lnk71" style="padding-left:11px;" CssClass="catagoriasHeader "  navigateurl="~/buscar.aspx?tipo=tecnológicos" runat="server" >Tecnológicos <i class="fas fa-sort-down"></i></asp:hyperlink>
              
              </div>
      
      
        </div>

    </div>

     <!--FIN MD-->


     <!--SECCION SM-->
     <div class="container hidden-md hidden-lg">
    
        <div class="row">
            <div class="col-xs-12 text-center" >

                <div class="inline text-center">
                    <asp:Label ID="lblLabelMenu1" runat="server" CssClass="categoraisHeader">MENÚ</asp:Label>
                    <asp:LinkButton ID="lnkmenu" runat="server" >
                        <asp:Image ID="imgBurguer" runat="server" ImageUrl="~/images/burguer2019.jpg" Width="40px" />
                    </asp:LinkButton>
                </div>                
          
                
                <div runat="server" id="divElementosSM" visible="false">
                     <asp:hyperlink ID="Hyperlink1" style="padding-left:11px;" CssClass="catagoriasHeader"  navigateurl="~/cats/pdfs.aspx?tipo=catalogo" runat="server" >Catálogos Pdf's  <i class="fas fa-sort-down"></i></asp:hyperlink>
           
                     &nbsp;&nbsp;&nbsp;
           
                     <asp:hyperlink ID="Hyperlink2" style="padding-left:11px;" CssClass="catagoriasHeader"  navigateurl="~/cats/Eventos.aspx" runat="server">Para Eventos <i class="fas fa-sort-down"></i></asp:hyperlink>
           
                   &nbsp;&nbsp;&nbsp;
     
                     <asp:hyperlink ID="Hyperlink3" style="padding-left:11px;" CssClass="catagoriasHeader" navigateurl="~/cats/Oficios.aspx" runat="server" >Para Oficios <i class="fas fa-sort-down"></i></asp:hyperlink>
            
                   &nbsp;&nbsp;&nbsp;
     
                     <asp:hyperlink ID="Hyperlink4" style="padding-left:11px;" CssClass="catagoriasHeader "  navigateurl="~/cats/Negocios.aspx" runat="server" Text="POR NEGOCIOS">Para Negocios <i class="fas fa-sort-down"></i></asp:hyperlink>


                        &nbsp;&nbsp;&nbsp;
            
               
                         <asp:hyperlink ID="Hyperlink5" style="padding-left:11px;" CssClass="catagoriasHeader "  navigateurl="~/cats/Temporada.aspx" runat="server" >Por Temporada <i class="fas fa-sort-down"></i></asp:hyperlink>

                     
                   &nbsp;&nbsp;&nbsp;
                 
                         <asp:hyperlink ID="Hyperlink6" style="padding-left:11px;" CssClass="catagoriasHeader " navigateurl="~/buscar.aspx?tipo=deportivos" runat="server"> Deportivos <i class="fas fa-sort-down"></i></asp:hyperlink>
                           

                         &nbsp;&nbsp;&nbsp;
                         <asp:hyperlink ID="Hyperlink7" style="padding-left:11px;" CssClass="catagoriasHeader "  navigateurl="~/buscar.aspx?tipo=tecnológicos" runat="server" >Tecnológicos <i class="fas fa-sort-down"></i></asp:hyperlink>


                  <h2 style="font-weight:lighter">&nbsp; CATEGORÍAS GENERALES</h2>
                       <asp:Repeater ID="rptCategorias" runat="server">
                        <HeaderTemplate>
	                        <ul class="menu_articulos">
                        </HeaderTemplate>
                        <ItemTemplate>
	                        <li style="text-align:left"><asp:HyperLink ID="lnkNombre" runat="server" NavigateUrl='<%# "~/categorias/show/" & Eval("idCategoria") & "/" & getTags(Eval("tags"), Eval("metaKeywords"))%>' Text='<%#Eval("Nombre") %>'  CssClass="catagoriasHeader"  ></asp:HyperLink></li>
                        </ItemTemplate>
                        <FooterTemplate>
	                        </ul>
                        </FooterTemplate>
                        </asp:Repeater>



                              <%--<a class="dropdown-item" href="#">Action</a>
                              <a class="dropdown-item" href="#">Another action</a>
                              <div class="dropdown-divider"></div>
                              <a class="dropdown-item" href="#">Something else here</a>--%>
                   
                        

              
              </div>
            </div>
      
        </div>

    </div>
     <!--FIN SM-->

    <div style="height:10px;"></div>

</div>


 

            
            
            

 