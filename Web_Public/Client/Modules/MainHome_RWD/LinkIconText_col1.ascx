<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkIconText_col1.ascx.cs"
    Inherits="Client_LinkIconText_col1" %>
<ul class="list-group sidebar-nav-v1" id="sidebar-nav">
    <asp:Repeater ID="rptWeblink" runat="server" OnItemDataBound="rptWeblink_ItemDataBound">
        <ItemTemplate>
            <asp:Literal ID="ltMenu" runat="server"></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
