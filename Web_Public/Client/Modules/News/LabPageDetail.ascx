<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LabPageDetail.ascx.cs" Inherits="Client_Modules_News_LabPageDetail" %>
<link href="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.css" rel="stylesheet"
    type="text/css" />
<script src="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.jquery.js" type="text/javascript"></script>
<div class="blog margin-bottom-40 content-detail">
    <div class="row box-white mb10 mln mrn" id="content_notice" runat="server" visible="false"
        style="min-height: 500px; text-align: center">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <b>Nội dung này yêu cầu có quyền xem nội dung. Vui lòng thông báo cho quản trị hệ thống.</b>
        </div>
    </div>
    <div id="content_news" runat="server" visible="true">
        <div class="row box-white mb10 mln mrn">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <h2 class="mt10">
                    <asp:Label ID="ltlTitle" runat="server"></asp:Label>
                </h2>
                <p>
                    <strong>
                        <asp:Literal ID="ltlDescribe" runat="server"></asp:Literal></strong>
                </p>
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
                    <li><i class="fa fa-comments"></i>
                        <asp:Label ID="lblComment" runat="server" Text="" /></li>
                </ul>
                <ul class="list-unstyled list-inline blog-tags">
                    <li><i class="fa fa-tags"></i>
                        <asp:Literal ID="ltlTags" runat="server"></asp:Literal>
                    </li>
                </ul>
            </div>
        </div>
        <div class="row box-white mb10 mln mrn">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="mb10 mt10">
                    <asp:Literal ID="ltlFb_like" runat="server"></asp:Literal>
                </div>
                <div class="mb10 mt10">
                    <asp:Literal ID="ltlFb_comment" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
        <div id="newsRelation" runat="server">
            <div class="row box-white mb10 mln mrn">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <!-- Recent Comments -->
                    <div class="media">
                        <h3>
                            <%= Resources.resource.T_relation %></h3>
                        <div class="media-body">
                            <ul class="paging-relation list-unstyled save-job">
                                <asp:Repeater ID="rptNewsRelation" runat="server">
                                    <ItemTemplate>
                                        <li class="pt5"><i class="fa fa-caret-right color-blue"></i><a href="<%# ResolveUrl("~/") + "d4/thi-nghiem-v/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                            title="<%# Eval("Title") %>">
                                            <%# Eval("Title") %></a> <span style="color: #6D6D6D; font-size: 12px;">(<%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %>)</span>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <%-- <h4 class="media-heading">Media heading <span>5 hours ago / <a href="#">Reply</a></span></h4>--%>
                        </div>
                    </div>
                    <!--/media-->
                </div>
            </div>
        </div>
        <div id="newsOther" runat="server">
            <div class="row box-white mb10 mln mrn">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <!-- Recent Comments -->
                    <div class="media">
                        <h3>
                            <%= Resources.resource.T_NewsOther%></h3>
                        <div class="media-body">
                            <ul class="list-unstyled save-job">
                                <asp:Repeater ID="DataListNews" runat="server">
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
                    <!--/media-->
                </div>
            </div>
        </div>
        <div id="CommentPanel" runat="server">
            <div class="row box-white mb10 mln mrn">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="media">
                        <h3>
                            <%= Resources.resource.T_Comment1 %></h3>
                        <div class="media-body">
                            <ul class="paging-commnet">
                                <asp:Repeater ID="DataListProductComment" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <h4 class="media-heading">
                                                <%# Eval("FullName") %><span><%# Convert.ToDateTime(Eval("DateCreated")).ToString("dd/MM/yyyy hh:mm") %>
                                                </span>
                                            </h4>
                                            <p>
                                                <%# Eval("Content") %>
                                            </p>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <!--/media-->
            </div>
        </div>
        <div id="btnComment" runat="server">
            <!-- Comment Form -->
            <div class="row box-white mb10 mln mrn">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pb20">
                    <div class="post-comment sky-form no-border ml10 mr10">
                        <h3>
                            Gửi nhận xét</h3>
                        <asp:Literal ID="error" runat="server"></asp:Literal>
                        <div class="row">
                            <div class="col-md-4">
                                <label class="input">
                                    <i class="icon-append fa fa-user"></i>
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Họ và tên"></asp:TextBox>
                                </label>
                            </div>
                            <div class="col-md-4">
                                <label class="input">
                                    <i class="icon-append fa fa-icon-append fa fa-envelope"></i>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                </label>
                            </div>
                            <div class="col-md-4">
                                <label class="input">
                                    <i class="icon-append fa fa-icon-append fa fa-edit"></i>
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Tiêu đề"></asp:TextBox>
                                </label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label class="input">
                                    <%--<i class="icon-append fa fa-icon-append fa fa-comment"></i>--%>
                                    <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine"
                                        Height="100px" placeholder="Nội dung"></asp:TextBox>
                                </label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label class="input input-captcha">
                                    <img id="ImgCapcha" runat="server" src="~/Client/Modules/Captcha/Image.aspx" width="100"
                                        height="32" alt="Captcha image" />
                                    <asp:TextBox ID="txtCapcha" runat="server" CssClass="form-control" placeholder="Mã xác nhận"></asp:TextBox>
                                </label>
                            </div>
                        </div>
                        <div class="pull-right mt10">
                            <asp:Button runat="server" ID="LinkButton2" CssClass="btn-u" Text="<%$ Resources:Resource, T_Comment_n %>"
                                OnClick="Send_Click" />
                        </div>
                    </div>
                    <!-- End Comment Form -->
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery("#PanelComments_form").hide();
        //toggle the componenet with class msg_body
        jQuery(".comment").click(function () {
            jQuery(this).next("#PanelComments_form").slideToggle(10);
        });
    });
</script>
<script type="text/javascript">
/* <![CDATA[ */

$(document).ready(function() {
	$("ul.paging-commnet").quickPager({pageSize:5});
    $("ul.paging-relation").quickPager({pageSize:10});
});

/* ]]> */
</script>
<asp:HiddenField ID="txtNewsGroupID" runat="server" />
<asp:HiddenField ID="hddGroupCate" runat="server" />
