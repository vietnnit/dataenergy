<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AboutLabList.ascx.cs" Inherits="Client_Mobules_News_AboutLabList" %>
<link href="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.css" rel="stylesheet"
    type="text/css" />
<script src="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.jquery.js" type="text/javascript"></script>
<div class="blog margin-bottom-40 content-detail">
    <div class="row box-white mb10 mln mrn">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <h2>
                <asp:Label ID="ltlTitle" runat="server"></asp:Label>
            </h2>
            <p>
                <asp:Label ID="FullDescirbe" runat="server"></asp:Label>
            </p>
        </div>
    </div>
    <div class="row box-white mb10  mln mrn">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <ul class="list-unstyled list-inline blog-info">
                <li><i class="fa fa-calendar"></i>
                    <asp:Label ID="lblAproved" runat="server" /></li>
                <li><i class="fa fa-pencil"></i>
                    <asp:Label ID="LabelAuthor" runat="server" /></li>
            </ul>
            <ul class="list-unstyled list-inline blog-tags">
                <li><i class="fa fa-tags"></i>
                    <asp:Literal ID="ltlTags" runat="server"></asp:Literal>
                </li>
            </ul>
        </div>
    </div>
    <div id="newsOther" runat="server">
        <div class="row box-white mb10 mln mrn pb10">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="media">
                    <h3>
                        <%= Resources.resource.T_relation %></h3>
                    <div class="media-body">
                        <ul class="paging-relation list-unstyled save-job">
                            <asp:Repeater ID="rptListNewsOther" runat="server">
                                <ItemTemplate>
                                    <li class="pt5"><i class="fa fa-caret-right color-blue"></i><a href="<%# ResolveUrl("~/") + "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                        title="<%# Eval("Title") %>">
                                        <%# Eval("Title") %></a> <span style="color: #6D6D6D; font-size: 12px;">(<%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %>)</span>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <!--/media-->
            </div>
        </div>
    </div>
    <div id="newsOther1" runat="server">
        <div class="row box-white mb10 mln mrn pb10">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="media">
                    <h3>
                        <%= Resources.resource.T_NewsOther%></h3>
                    <div class="media-body">
                        <ul class="list-unstyled save-job">
                            <asp:Repeater ID="rptNewsOther1" runat="server">
                                <ItemTemplate>
                                    <li class="pt5"><i class="fa fa-caret-right color-blue"></i><a href="<%# ResolveUrl("~/") + "d4/thi-nghiem-v/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                        title="<%# Eval("Title") %>">
                                        <%# Eval("Title") %>
                                        <span style="color: #6D6D6D; font-size: 12px; font-style: italic;">(<%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %>)</span>
                                    </a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hddGroupCate" runat="server" />
<asp:HiddenField ID="hddCateID" runat="server" />
<script type="text/javascript">
/* <![CDATA[ */

$(document).ready(function() {
    $("ul.paging-other").quickPager({pageSize:10});
     $("ul.paging-other1").quickPager({pageSize:20});
});

/* ]]> */
</script>
