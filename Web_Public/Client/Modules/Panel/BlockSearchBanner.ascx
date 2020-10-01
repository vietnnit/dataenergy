<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockSearchBanner.ascx.cs"
    Inherits="Client_BlockSearchBanner" %>
<div class="search_box_top" id="sitesearch">
    <asp:TextBox ID="txtkeyword" runat="server" OnTextChanged="txtSearch_TextChanged"
        placeholder="<%$ Resources:Resource, T_Search_text %>" CssClass="placeholder animate-out transparent" ValidationGroup="searchBanner"></asp:TextBox>
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/search_dark.png"
        OnClick="btnSearch_Click" CssClass="search_btn"  ValidationGroup="searchBanner"/>
 </div>
