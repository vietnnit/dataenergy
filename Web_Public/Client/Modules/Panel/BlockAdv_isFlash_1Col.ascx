<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockAdv_isFlash_1Col.ascx.cs"
    Inherits="Client_BlockAdv_isFlash_1Col" %>
<div class="boxlightfulladv mt10 mb10">
    <div class="headline">
        <h2>
            <asp:Label ID="lblTitle" runat="server" Text="Hồ sơ năng lực"></asp:Label>
        </h2>
    </div>
    <div class="box-news-thumb-sm mt5">
        <div class="row">
            <asp:Literal ID="ltlAdv" runat="server"></asp:Literal>
        </div>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
