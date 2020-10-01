<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PanelFooterRight.ascx.cs"
    Inherits="Client_PanelFooterRight" %>

<%--<div class="headline"><h2> <asp:Label ID="lblTitle" runat="server"></asp:Label></h2></div>   --%>
<asp:Label ID="lblTitle" runat="server"  Visible="false"></asp:Label>                      
<address class="md-margin-bottom-20 md-margin-top-20">
    <asp:Literal ID="ltlFooter" runat="server"></asp:Literal>
</address>
