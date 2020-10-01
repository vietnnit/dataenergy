<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockLink_hover_col3.ascx.cs"
    Inherits="Client_BlockLink_hover_col3" %>
<div class="mt10 mb10">
<div class="headline">
    <h2>
        <asp:Label ID="lblTitle" runat="server" Text="Lĩnh vực hoạt động"></asp:Label>
    </h2>
</div>
<div class="box-news-thumb-iconlink">
    <div class="content-boxes-link mt20 ml30 mr30 bg-link-icon">
        <asp:Repeater ID="rptWebLink" runat="server">
            <ItemTemplate>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 lg-margin-bottom-20 md-margin-bottom-20">
                    <h2 class="heading-sm">
                        <a class="glow" href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target="<%# Eval("Target")%>">
                            <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img src='" + Eval("MenuLinksIcon") + "' alt='" + Eval("MenuLinksName") + "'>" : "<img  src='" + ResolveUrl("~/") + "images/img_logo.jpg' alt='" + Eval("MenuLinksName") + "'>"%>
                         </a>
                         <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target="<%# Eval("Target")%>">
                            <span class="pl5"><%# Eval("MenuLinksName")%></span>
                        </a>
                    </h2>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
