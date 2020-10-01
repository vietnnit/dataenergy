<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsLatestScroll.ascx.cs"
    Inherits="Client_Modules_NewsLatestScroll" %>
<div class="col-lg-4 col-md-4 col-sm-6 col-xs-24">
    <div class="box-news-thumb-hot">
        <div class="pln prn col-lg-12 col-md-12 col-sm-12 col-xs-12">
           <asp:Repeater ID="rptAdv" runat="server">
                <ItemTemplate>
                    <a href="<%# Eval("MenuLinksUrl") %>" target="<%# Eval("Target") %>">
                        <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img class='header-banner img-responsive' src='" + Eval("MenuLinksIcon") + "'style='border-width: 0px;' alt='" + Eval("MenuLinksName") + "'>" :""%>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <h2 class="h2-cate-hot">
            <asp:Label ID="lblTitle" runat="server" Text="Tin mới"></asp:Label>
        </h2>
        <div class="box-content-main">
            <div class="fix_height_hotother-180" id="content_listhotother">
                <ul class="list-unstyled colorful-ul">
                    <asp:Repeater ID="rptHotNews" runat="server">
                        <ItemTemplate>
                            <li>
                                <div class="title_news">
                                    <a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                        title="<%# Eval("Title")%>">
                                        <%# Eval("Title") %>
                                    </a><span style="color: #6D6D6D; font-size: 11px; font-style: italic;">(<%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %>)</span>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
<asp:HiddenField ID="hddValue3" runat="server" Value="HotNews_Adv"/>
<script type="text/javascript">
    (function ($) {
        $(window).load(function () {
            $("#content_listhotother").mCustomScrollbar({
                autoHideScrollbar: true,
                theme: "light-thin"
            });

        });
    })(jQuery);
</script>


