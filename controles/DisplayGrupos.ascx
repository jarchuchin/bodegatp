<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayGrupos.ascx.vb" Inherits="controles_DisplayGrupos" %>

<%@ Register src="DisplayGrupoMovimiento.ascx" tagname="DisplayGrupoMovimiento" tagprefix="uc1" %>

<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        
<uc1:DisplayGrupoMovimiento ID="DisplayGrupoMovimiento1" ClaveGrupo='<%# cint(eval("idgrupo")) %>' runat="server" />
           
         
    </ItemTemplate>
</asp:Repeater>




