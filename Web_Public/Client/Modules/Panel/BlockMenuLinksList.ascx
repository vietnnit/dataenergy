<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockMenuLinksList.ascx.cs"
    Inherits="Client_BlockMenuLinksList" %>
<div class="ro margin-15t margin-15b ">
    <div class="box-news">
            <asp:Repeater ID="rptAdv" runat="server">
                <ItemTemplate>
                    <div class="margin-10b">
                        <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target="<%# Eval("Target")%>">
                             <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img class='lazy' src='" + Eval("MenuLinksIcon") + "'style='display: inline;width:" + Eval("width") + "px;height:" + Eval("height") + "px' alt='" + Eval("MenuLinksName") + "'>" : "<img class='lazy' src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='display: inline;' alt='" + Eval("MenuLinksName") + "'>"%>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
 
    </div>
    <div class="clear">
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
<script type="text/javascript">
    $(function () {
        $(".box-link-main-grid8-roll").css("opacity", "0");
        $(".box-link-main-grid8-roll").hover(function () {
            $(this).stop().animate({
                opacity: 0.4
            }, "slow");
        },
        function () {
            $(this).stop().animate({
                opacity: 0
            }, "slow");
        });
    });
</script>
