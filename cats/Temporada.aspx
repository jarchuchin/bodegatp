<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="Temporada.aspx.vb" Inherits="cats_Temporada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


      <div style="height:30px;"></div>

    <div class="row" style="padding-left:50px; padding-right:50px; padding-top:30px; padding-bottom:50px;">

        <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="lnk1" style="font-size:18px;"  navigateurl="~/buscar.aspx?tipo=Año nuevo" runat="server" ><i class="fa fa-globe fa-lg"></i> Año nuevo </asp:hyperlink></div>
     
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink3" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=San valentín" runat="server" ><i class="fa fa-heart fa-lg"></i> San Valentín </asp:hyperlink></div>

      

         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink5" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=mujer" runat="server" ><i class="fa fa-female fa-lg"></i> Día internacional de la mujer </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink6" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Primavera" runat="server" ><i class="fa fa-sun-o fa-lg"></i> Primavera</asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink7" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Semana Santa" runat="server" ><i class="fa life-saver fa-lg"></i> Semana Santa </asp:hyperlink></div>
      
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink9" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Día del niño" runat="server" ><i class="fa fa-user-md fa-lg"></i> Día del niño </asp:hyperlink></div>
        
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink11" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Mamá" runat="server" ><i class="fa fa-female fa-lg"></i> Día de las Madres </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink12" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Padre" runat="server" ><i class="fa fa-laptop fa-lg"></i> Día del padre </asp:hyperlink></div>

         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink13" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Verano" runat="server" ><i class="fa fa-soccer-ball-o fa-lg"></i> Vacaciones de verano </asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink20" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Regreso a clases" runat="server" ><i class="fa fa-tablet fa-lg"></i> Regreso a clases</asp:hyperlink></div>
        <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink2" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Independencia" runat="server" ><i class="fa fa-flag fa-lg"></i> Día de la independencia</asp:hyperlink></div>

        
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink15" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Hallowen" runat="server" ><i class="fa fa-male fa-lg"></i> Hallowen</asp:hyperlink></div>
         <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink16" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Día de los muertos" runat="server" ><i class="fa fa-server fa-lg"></i> Día de los muertos</asp:hyperlink></div>
        
         

        <div class="col-md-3 col-sm-4" style="height:50px;"><asp:hyperlink ID="Hyperlink19" style="font-size:18px;"   navigateurl="~/buscar.aspx?tipo=Navidad" runat="server" ><i class="fa fa-shopping-cart fa-lg"></i> Navidad</asp:hyperlink></div>
        
    </div>

    <div style="height:30px;"></div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

