<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkIconText_col1.ascx.cs"
    Inherits="Client_LinkIconText_col1" %>
<ul class="list-group sidebar-nav-v1" id="sidebar-nav">
    <asp:Repeater ID="rptWeblink" runat="server" OnItemDataBound="rptWeblink_ItemDataBound">
        <HeaderTemplate>
            <div class="panel panel-blue" style="margin-bottom:0 !important;">
                <div class="panel-heading"  style="margin-bottom:0 !important;">
                    <h3 class="panel-title"  style="margin-bottom:0 !important;">
                        <i class="fa fa-print"></i>
                        <asp:Label ID="lblTitle" runat="server" Text="Báo cáo"></asp:Label>
                    </h3>
                </div>
            </div>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Literal ID="ltMenu" runat="server"></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
</ul>

<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
