<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage1Col.master" AutoEventWireup="false" CodeFile="pdfs.aspx.vb" Inherits="cats_pdfs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

<div style="height:30px;"></div>

     <div class="row" style="padding:50px;">



         <asp:datalist ID="DataList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="hidden-sm hidden-xs" >
             <ItemTemplate>
                  <div  class="text-center" >
		        <div style="padding-top:15px; padding-bottom:15px; padding-left: 15px;">
                    <asp:HyperLink ID="lnkProductoI" runat="server" ClientIDMode="Predictable" Style="cursor:pointer;" ToolTip='<%# Eval("titulo") %>' NavigateUrl='<%#carpetafiles & "pdfs/" & Eval("nombreArchivo")  %>'>
                    <asp:Image ID="Image4" runat="server" imageurl='<%# carpetafiles & "fotos/" & Eval("nombreImagen") %>'   width="200px" /></asp:HyperLink>
                       
                    <div style="height:5px;"></div>

                         
                    <asp:HyperLink ID="lnkdescargar" runat="server" ClientIDMode="Predictable" CssClass="productoElemento" Target="_blank"  NavigateUrl='<%# carpetafiles & "pdfs/" & Eval("nombreArchivo")  %>'> Descargar PDF </asp:HyperLink>
                                           
                </div>
            </div>
             </ItemTemplate>
         </asp:datalist>

           

          <asp:datalist ID="DataList2" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CssClass="hidden-xs hidden-md hidden-lg" >
             <ItemTemplate>
                  <div  class="text-center" >
		        <div style="padding-top:15px; padding-bottom:15px; padding-left: 15px;">
                    <asp:HyperLink ID="lnkProductoI" runat="server" ClientIDMode="Predictable" Style="cursor:pointer;" ToolTip='<%# Eval("titulo") %>' NavigateUrl='<%#carpetafiles & "pdfs/" & Eval("nombreArchivo")  %>'>
                    <asp:Image ID="Image4" runat="server" imageurl='<%# carpetafiles & "fotos/" & Eval("nombreImagen") %>'   width="200px" /></asp:HyperLink>
                       
                    <div style="height:5px;"></div>

                         
                    <asp:HyperLink ID="lnkdescargar" runat="server" ClientIDMode="Predictable" CssClass="productoElemento" Target="_blank"  NavigateUrl='<%# carpetafiles & "pdfs/" & Eval("nombreArchivo")  %>'> Descargar PDF </asp:HyperLink>
                                           
                </div>
            </div>
             </ItemTemplate>
         </asp:datalist>


          <asp:datalist ID="DataList3" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CssClass="hidden-sm hidden-md hidden-lg" >
             <ItemTemplate>
                  <div  class="text-center" >
		        <div style="padding-top:15px; padding-bottom:15px; padding-left: 15px;">
                    <asp:HyperLink ID="lnkProductoI" runat="server" ClientIDMode="Predictable" Style="cursor:pointer;" ToolTip='<%# Eval("titulo") %>' NavigateUrl='<%#carpetafiles & "pdfs/" & Eval("nombreArchivo")  %>'>
                    <asp:Image ID="Image4" runat="server" imageurl='<%# carpetafiles & "fotos/" & Eval("nombreImagen") %>'   width="200px" /></asp:HyperLink>
                       
                    <div style="height:5px;"></div>

                         
                    <asp:HyperLink ID="lnkdescargar" runat="server" ClientIDMode="Predictable" CssClass="productoElemento" Target="_blank"  NavigateUrl='<%# carpetafiles & "pdfs/" & Eval("nombreArchivo")  %>'> Descargar PDF </asp:HyperLink>
                                           
                </div>
            </div>
             </ItemTemplate>
         </asp:datalist>
             
      
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelSinContainer" Runat="Server">
</asp:Content>

