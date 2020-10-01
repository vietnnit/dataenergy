<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsbyGroup_list2_4col.ascx.cs"
    Inherits="Client_NewsbyGroup_list2_4col" %>

    <div class="mt20 mb20">
        <div class="headline">
            <h2>
                <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h2>
            <ul class="pull-right breadcrumb hidden-xs">
                <asp:Literal ID="ltlCateSub" runat="server"></asp:Literal>
            </ul>
        </div>
        
            <div class="row">
                <asp:Literal ID="ltlNewsCateMainHome" runat="server"></asp:Literal>
            </div>
       
    </div>

<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
