<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerTop.ascx.cs" Inherits="Client_BannerTop" %>

<asp:Repeater ID="rptAdv" runat="server">
    <ItemTemplate>
        <a href="<%# Eval("MenuLinksUrl") %>" target="<%# Eval("Target") %>">
            <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img class='header-banner img-responsive' src='" + Eval("MenuLinksIcon") + "'style='border-width: 0px;' alt='" + Eval("MenuLinksName") + "'>" :""%>
        </a>
    </ItemTemplate>
</asp:Repeater>
        
<asp:HiddenField ID="hddValue" runat="server" Value="BannerTop" />
<asp:HiddenField ID="hddRecord" runat="server" Value="1" />
