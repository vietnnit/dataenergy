<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockWebLinkCombo.ascx.cs"
    Inherits="Client_BlockWebLinkCombo" %>
<div class="r-ro">
    <div style="float: right;">
        <asp:DropDownList ID="ddlWeblink" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
            CssClass="dropdown-large" Width="250px" OnSelectedIndexChanged="ddlWeblink_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
</div>
<div class="clr"></div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
