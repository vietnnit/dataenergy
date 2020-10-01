<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockWelCome.ascx.cs" Inherits="Client_Admin_BlockWelCome" %>
Xin chào: <asp:Label ID="welcomAdmin" runat="server" Text=""></asp:Label>
<asp:Image ID="Image1" runat="server" ImageUrl="~/images/Admin_Theme/Icons/icon-exit.gif" />
<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Thoát</asp:LinkButton>