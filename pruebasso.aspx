<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="pruebasso.aspx.vb" Inherits="pruebasso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    <div style="padding:100px;">
      Llamada a weblogin SSO prueba general
            <div style="height:20px;"></div>


    <asp:HyperLink ID="lnkJesus" runat="server" Text="Tel. Jesus" NavigateUrl="http://jetty.doxhealth.com?MSISDN=528261069659&logoURL=http://identidadgeek.com/wp-content/uploads/2014/04/Telcel-Logo-600x330.jpg&returnuri=http://todopromocional.com/Acercade.aspx"></asp:HyperLink>


            <div style="height:20px;"></div>

     <asp:HyperLink ID="lnkDavid" runat="server" Text="Tel. David" NavigateUrl="http://jetty.doxhealth.com?MSISDN=18173630464&logoURL=https://www.brandsoftheworld.com/sites/default/files/styles/logo-thumbnail/public/0014/5732/brand.gif&returnuri=http://todopromocional.com/default.aspx"></asp:HyperLink>

        <div style="height:20px;"></div>


     <asp:HyperLink ID="lnkAriosto" runat="server" Text="Tel. Ariosto" NavigateUrl="http://jetty.doxhealth.com?MSISDN=524432737488&logoURL=http://www.phonenews.com/wp-content/uploads/2013/05/america-movil-logo-small.png&returnuri=http://todopromocional.com/default.aspx"></asp:HyperLink>

</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

