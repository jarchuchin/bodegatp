<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Oficios.aspx.vb" Inherits="cats_Oficios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


     <div style="height:30px;"></div>

    <div class="row" style="padding-left:50px; padding-right:50px; padding-top:30px; padding-bottom:50px;">

        <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="lnk1" style="font-size:18px;"  navigateurl="~/buscar.aspx?tipo=Enfermeras" runat="server" ><i class="fa fa-medkit fa-lg"></i> Enfermeras </asp:hyperlink></div>
       
       
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink4" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Abogados" runat="server" ><i class="fa fa-briefcase fa-lg"></i> Abogados</asp:hyperlink></div>
        
         

         
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink8" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Chefs" runat="server" ><i class="fa fa-cutlery fa-lg"></i> Chef´s </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink9" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Doctores" runat="server" ><i class="fa fa-user-md fa-lg"></i>Médicos </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink10" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Dentistas" runat="server" ><i class="fa fa-hand-pointer-o fa-lg"></i> Dentistas </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink11" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Maestros" runat="server" ><i class="fa fa-graduation-cap fa-lg"></i> Maestros </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink12" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Ingenieros" runat="server" ><i class="fa fa-laptop fa-lg"></i> Ingenieros </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink13" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Arquitectos" runat="server" ><i class="fa fa-industry fa-lg"></i> Arquitectos </asp:hyperlink></div>
       
       
        
    </div>

    <div style="height:30px;"></div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

