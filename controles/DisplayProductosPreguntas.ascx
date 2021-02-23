<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayProductosPreguntas.ascx.vb" Inherits="controles_DisplayProductosPreguntas" %>

 <div style="height:10px;"></div>
<div class="divisorHorizontal"></div>

<h3>Preguntas hechas por nuestros clientes</h3>

 <div style="height:10px;"></div>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="row">
              <div class="col-md-6 col-sm-8 col-xs-10">

                        <asp:TextBox ID="txtAgregar" runat="server"  placeholder="Coloca tu pregunta aquí" CssClass="form-control form-inline"  autocomplete="off" ></asp:TextBox>                            
                        
   
               </div>
               <div class="col-md-6 col-sm-4 col-xs-2">
                   <asp:Button ID="btnAgregarPregunta" runat="server" Text="Agregar pregunta"  CssClass="btn btn-primary" UseSubmitBehavior="false" />
               </div>
        </div>

        <div class="row">
                <div class="col-xs-12">
                     <asp:Label ID="lblMensaje" runat="server" Text="Excediste el límite de preguntas al día. Intenta mañana" ForeColor="Red"  Visible="false"></asp:Label>
        <div style="height:10px;"></div>
                    <asp:Repeater ID="rptPreguntasyRespuestas" runat="server">
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Pregunta: "></asp:Label> <asp:Label ID="Label1" runat="server" Text='<%# Eval("Pregunta")%>'></asp:Label> - <asp:Label ID="Label2" runat="server" Text='<%# Eval("PreguntaFecha")%>' ></asp:Label>  <asp:Label ID="Label8" runat="server" Text='<%# "Por: " & Eval("PNombre")%>' Font-Italic="true" ForeColor="Gray" ></asp:Label><br />
                <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Respuesta: " visible='<%# Eval("Respuesta") <> ""%>'></asp:Label>   <asp:Label ID="Label3" runat="server" Text='<%# Eval("Respuesta")%>' visible='<%# Eval("Respuesta") <> ""%>'></asp:Label> <asp:Label ID="Label7" runat="server" Text="-" visible='<%# Eval("Respuesta") <> ""%>'></asp:Label> <asp:Label ID="Label4" runat="server" Text='<%# Eval("RespuestaFecha")%>' visible='<%# Eval("Respuesta") <> ""%>'></asp:Label> <asp:Label ID="Label9" runat="server" Text='<%# "Por: " & Eval("RNombre")%>' Font-Italic="true" ForeColor="Gray" visible='<%# Eval("Respuesta") <> ""%>' ></asp:Label>
                <div style="height:10px;"></div>
            </ItemTemplate>
        </asp:Repeater>

                </div>
        </div>
       
        

    </ContentTemplate>
</asp:UpdatePanel>
