<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsbyCate_list1.ascx.cs"
    Inherits="Client_NewsbyCate_list1" %>
<div class="ro margin-20t margin-20b">
    <div class="box-content-cate">
        <h2 class="h2">
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </h2>
        <div class="box-content-main margin-10t cate_news_1">
            <div class='box-news-thumb'>
                <asp:Literal ID="ltlNewsCateMainHome" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
