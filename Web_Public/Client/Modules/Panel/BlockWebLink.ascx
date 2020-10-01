<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockWebLink.ascx.cs"
    Inherits="Client_BlockWebLink" %>
<div class="ro margin-15t margin-15b">
    <div class="box-news">
        <asp:Repeater ID="rptWebLink" runat="server">
            <ItemTemplate>
                <div class="news-list-link">
                    <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target='<%# Eval("Target")%>'>
                        <span>
                            <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img class='is_img' src='" + Eval("MenuLinksIcon") + "'style='border-width: 0px;' alt='" + Eval("MenuLinksName") + "'>" : "<img class='is_img' src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='border-width: 0px;' alt='" + Eval("MenuLinksName") + "'>"%>
                            <%# Eval("MenuLinksName")%>
                        </span></a>
                    <div class="desc">
                        <%# Eval("MenuLinksHelp")%>
                     </div>
                    <div class="clr">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
