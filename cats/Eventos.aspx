<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Eventos.aspx.vb" Inherits="cats_Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">

    <link rel="stylesheet" href="/font-awesome/css/font-awesome.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

    <div style="height:30px;"></div>

    <div class="row" style="padding-left:50px; padding-right:50px; padding-top:30px; padding-bottom:50px;">

       <%-- <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="lnk1" style="font-size:18px;"  navigateurl="~/buscar.aspx?tipo=Aficionados" runat="server" ><i class="fa fa-futbol-o fa-lg"></i> Aficionados </asp:hyperlink></div>--%>
        <%-- <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink1" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Aniversario" runat="server" ><i class="fa fa-heart fa-lg"></i> Aniversario </asp:hyperlink></div>--%>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink3" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Bodas" runat="server" ><i class="fa fa-diamond fa-lg"></i> Bodas </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink4" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Baby" runat="server" ><i class="fa fa-child fa-lg"></i> Baby shower</asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink5" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Conferencias" runat="server" ><i class="fa fa-bar-chart fa-lg"></i> Conferencias </asp:hyperlink></div>
        <%-- <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink6" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Culturales" runat="server" ><i class="fa fa-users fa-lg"></i> Culturales</asp:hyperlink></div>--%>
       <%--  <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink7" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Conciertos" runat="server" ><i class="fa fa-music fa-lg"></i> Conciertos </asp:hyperlink></div>--%>
      <%--   <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink8" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Cocteles" runat="server" ><i class="fa fa-glass fa-lg"></i> Cocteles </asp:hyperlink></div>--%>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink9" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=politicas" runat="server" ><i class="fa fa-certificate fa-lg"></i> Campañas políticas </asp:hyperlink></div>
        
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink11" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Cumpleaños" runat="server" ><i class="fa fa-gift fa-lg"></i> Cumpleaños</asp:hyperlink></div>
        
       
     
         

         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink15" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Despedida de soltera" runat="server" ><i class="fa fa-female fa-lg"></i> Despedida de soltera </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink16" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Expo" runat="server" ><i class="fa fa-clone fa-lg"></i> Expo </asp:hyperlink></div>
         
        <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink29" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Eventos Sociales" runat="server" ><i class="fa fa-bug fa-lg"></i> Sociales </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink18" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Excursiones" runat="server" ><i class="fa fa-cloud fa-lg"></i> Excursiones </asp:hyperlink></div>
      
       
        

         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink24" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Graduaciones" runat="server" ><i class="fa fa-graduation-cap fa-lg"></i> Graduaciones </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink25" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Inauguraciones" runat="server" ><i class="fa fa-hand-paper-o fa-lg"></i> Inauguraciones </asp:hyperlink></div>

         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink27" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=XV años" runat="server" ><i class="fa fa-birthday-cake fa-lg"></i> XV años </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink28" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Torneos" runat="server" ><i class="fa fa-bicycle fa-lg"></i> Torneos </asp:hyperlink></div>
        
        
    </div>

    <div style="height:30px;"></div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

