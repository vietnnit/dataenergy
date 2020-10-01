<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinksList_Text.ascx.cs"
    Inherits="Client_LinksList_Text" %>
<div class="margin-20t margin-20b ">
    <div class="box-content-cate">
        <h2 class="h2">
            <a href="javascript:void(0)" class='h2-cate'><span>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></span></a></h2>
        <div class="box-content-main-col-a">
            <asp:Repeater ID="rptAdv" runat="server">
                <ItemTemplate>
                    <div class="margin-10b">
                        <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target="<%# Eval("Target")%>">
                            <span class="box-link-main-grid8-roll"></span>
                            <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img class='lazy' src='" + Eval("MenuLinksIcon") + "'style='display: inline;width:" + Eval("width") + "px;height:" + Eval("height") + "px' alt='" + Eval("MenuLinksName") + "'>" : "<img class='lazy' src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='display: inline;' alt='" + Eval("MenuLinksName") + "'>"%>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="clear">
    </div>
</div>


<div class="col4 module tw_fb">
				<h2><a href="http://social.uchicago.edu/" data-ga-category="UChicago Social Module" data-ga-action="Click">UChicago<span>Social</span></a></h2>

				<ul class="modulemore left">
					<li class="ss-social ss-facebook"><a href="http://www.facebook.com/UChicago" data-ga-category="UChicago Social Module" data-ga-action="Click">UChicago on Facebook</a></li>
					<li class="ss-social ss-twitter"><a href="https://twitter.com/UChicago" data-ga-category="UChicago Social Module" data-ga-action="Click">@UChicago on Twitter</a></li>
				</ul>
				<hr>
				<div id="socialrotate">

</div>
			</div>

<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
