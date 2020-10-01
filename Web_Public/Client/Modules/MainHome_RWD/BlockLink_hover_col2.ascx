<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockLink_hover_col2.ascx.cs"
    Inherits="Client_BlockLink_hover_col2" %>
<div class="mt10 mb10">
<div class="headline">
    <h2>
        <asp:Label ID="lblTitle" runat="server" Text="Ứng dụng"></asp:Label>
    </h2>
</div>
<div class="box-news-thumb">
    <div class="content-boxes-v1 mt20">
        <asp:Repeater ID="rptWebLink" runat="server">
            <ItemTemplate>
                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-6 md-margin-bottom-30 lg-margin-bottom-30">
                    <h2 class="heading-sm1">
                        <a href="<%# Eval("MenuLinksUrl")%>" target="<%# Eval("Target")%>">
                            <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img src='" + Eval("MenuLinksIcon") + "'style='display: inline;' alt='" + Eval("MenuLinksName") + "'>" : "<img src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='display: inline;' alt='" + Eval("MenuLinksName") + "'>"%></a>
                        <span>
                            <a href="<%# Eval("MenuLinksUrl")%>" class="weblink_title" target="<%# Eval("Target")%>"><%# Eval("MenuLinksName")%></a></span>
                    </h2>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />

