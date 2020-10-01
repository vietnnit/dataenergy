<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsbyGroup_Thumb.ascx.cs"
    Inherits="Client_NewsbyGroup_Thumb" %>
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <div class="mt20 mb20">
        <div class="headline">
            <h2><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h2>
            <ul class="pull-right breadcrumb hidden-xs">
                <asp:Literal ID="ltlCateSub" runat="server"></asp:Literal>
            </ul>
        </div>

        <div class="row pt5">
            <asp:Literal ID="ltlNewsCateMainHome" runat="server"></asp:Literal>
        </div>

    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
