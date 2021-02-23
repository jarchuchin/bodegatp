<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayAnunciosHome.ascx.vb" Inherits="controles_DisplayAnunciosHome" %>

<div style="width:100%; background-color:#F2F2F2;">
    <%--  <div style="height:15px;"></div>--%>

<div class="boxedcontainer hidden-xs">

    <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="3000">



         <!-- Wrapper for slides -->
        <div class="carousel-inner">

            <asp:Repeater ID="rptBanners2" runat="server">
                <ItemTemplate>
                   <div class='<%# "item" & getEntro()   %>'>

                        <a  href='<%# Eval("url")%>' > <img src='<%# carpetafiles & Eval("nombreArchivo")%>'  >  </a>
                   
                    </div>
                </ItemTemplate>
             </asp:Repeater>
       
        </div>
    </div>


  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev" style="margin-top:250px;">
    <span class="glyphicon glyphicon-chevron-left"></span>
  </a>
  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next" style="margin-top:250px;">
    <span class="glyphicon glyphicon-chevron-right"></span>
  </a>




</div>


    <div class="boxedcontainer hidden-sm hidden-md hidden-lg text-center">
         <asp:Repeater ID="rptmovil" runat="server">
                <ItemTemplate>
                  

                    <a  href='<%# Eval("url")%>' > <img src='<%# carpetafiles & Eval("nombreArchivo")%>'  style="width:100%;" >  </a>
                    <div style="height:10px"> </div>
                </ItemTemplate>
             </asp:Repeater>
       
    </div>


</div>
<script>

	$('.carousel').carousel({
        interval: 6000
	})

	$('.carousel-control.left').click(function () {
	    $('#myCarousel').carousel('prev');
	});

	$('.carousel-control.right').click(function () {
	    $('#myCarousel').carousel('next');
	});


</script>   


<div class="container hidden-xs hidden-sm">
    <div class="row">
        <div class="col-md-3 inline text-center">
            <asp:HyperLink ID="btn1" runat="server" imageurl="~/images/banerModulos_r1_c1.jpg" ImageHeight="100px"></asp:HyperLink>
        </div>
        <div class="col-md-3 inline text-center">
             <asp:HyperLink ID="btn2" runat="server" imageurl="~/images/banerModulos_r1_c2.jpg" ImageHeight="100px"></asp:HyperLink>
        </div>
        <div class="col-md-3 inline text-center">
            <asp:HyperLink ID="btn3" runat="server" imageurl="~/images/banerModulos_r1_c3.jpg" ImageHeight="100px"></asp:HyperLink>
        </div>
        <div class="col-md-3 inline text-center">
            <asp:HyperLink ID="btn4" runat="server" imageurl="~/images/banerModulos_r1_c4.jpg" ImageHeight="100px"></asp:HyperLink>
        </div>
                
    </div>
</div>


<div class="container hidden-xs hidden-md hidden-lg">
    <div class="row">
        <div class="col-sm-3 inline text-center">
            <asp:HyperLink ID="HyperLink1" runat="server" imageurl="~/images/banerModulos_r1_c1.jpg" ImageHeight="80px"></asp:HyperLink>
        </div>
        <div class="col-sm-3 inline text-center">
             <asp:HyperLink ID="HyperLink2" runat="server" imageurl="~/images/banerModulos_r1_c2.jpg" ImageHeight="80px"></asp:HyperLink>
        </div>
        <div class="col-sm-3 inline text-center">
            <asp:HyperLink ID="HyperLink3" runat="server" imageurl="~/images/banerModulos_r1_c3.jpg" ImageHeight="80px"></asp:HyperLink>
        </div>
        <div class="col-sm-3 inline text-center">
            <asp:HyperLink ID="HyperLink4" runat="server" imageurl="~/images/banerModulos_r1_c4.jpg" ImageHeight="80px"></asp:HyperLink>
        </div>
                
    </div>
</div>




<div class="container">
    <div class="divisorHorizontal"></div>
</div>