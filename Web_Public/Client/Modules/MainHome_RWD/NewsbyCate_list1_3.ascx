<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsbyCate_list1_3.ascx.cs"
    Inherits="Client_NewsbyCate_list1_3" %>
<div class="mt10 mb10">
    <div class="headline">
        <h2>
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </h2>
    </div>
    <div class="box-news-thumb">
        <asp:Literal ID="ltlNewsCateMainHome" runat="server"></asp:Literal>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
