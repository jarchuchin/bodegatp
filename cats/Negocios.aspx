<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Negocios.aspx.vb" Inherits="cats_Negocios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


    
     <div style="height:30px;"></div>

    <div class="row" style="padding-left:50px; padding-right:50px; padding-top:30px; padding-bottom:50px;">

       
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink1" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Restaurant" runat="server" ><i class="fa fa-desktop fa-lg"></i> Restaurant </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink3" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Hoteles" runat="server" ><i class="fa fa-hotel fa-lg"></i> Hoteles </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink4" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Bares" runat="server" ><i class="fa fa-glass fa-lg"></i> Bares</asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink5" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Gimnasio" runat="server" ><i class="fa fa-male fa-lg"></i> Gimnasio</asp:hyperlink></div>
         
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink7" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Hospitales" runat="server" ><i class="fa fa-hospital-o fa-lg"></i> Hospitales </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink8" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Agencias" runat="server" ><i class="fa fa-car fa-lg"></i> Agencias de carros </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink9" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Inmobiliarias" runat="server" ><i class="fa fa-building-o fa-lg"></i> Inmobiliarias </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink10" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Escuelas" runat="server" ><i class="fa fa-institution fa-lg"></i> Escuelas </asp:hyperlink></div>
        
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink12" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Oficinas" runat="server" ><i class="fa fa-laptop fa-lg"></i> Oficinas </asp:hyperlink></div>

       
       
       
        
    </div>

    <div style="height:30px;"></div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

