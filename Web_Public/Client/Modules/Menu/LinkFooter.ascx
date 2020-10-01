<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkFooter.ascx.cs" Inherits="Client_LinkFooter" %>

<div class="headline"><h2> <asp:Label ID="lblTitle" runat="server"></asp:Label></h2></div>
<ul class="list-unstyled link-list">
    <asp:Repeater ID="rptAdv" runat="server">
        <ItemTemplate>
            <li><a href="<%# Eval("MenuLinksUrl") %>" target="<%# Eval("Target") %>">
                <%# Eval("MenuLinksName") %>
            </a>
            </li>

        </ItemTemplate>
    </asp:Repeater>
           
</ul>



<asp:HiddenField ID="hddValue" runat="server" Value="MenuFooter" />
