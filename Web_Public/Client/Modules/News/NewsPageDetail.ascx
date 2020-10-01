<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsPageDetail.ascx.cs" Inherits="Client_NewsPageDetail" %>
<link href="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.css" rel="stylesheet" type="text/css" />
<script src="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.jquery.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function share_zing() { u = location.href; window.open("http://link.apps.zing.vn/share?u=" + encodeURIComponent(u)); }
    function share_govn() { u = location.href; window.open("http://my.go.vn/share.aspx?url=" + encodeURIComponent(u)); }
    function share_twitter() { u = location.href; t = document.title; window.open("http://twitter.com/home?status=" + encodeURIComponent(u)); }
    function share_facebook() { u = location.href; t = document.title; window.open("http://www.facebook.com/share.php?u=" + encodeURIComponent(u) + "&t=" + encodeURIComponent(t)); }
    function share_google() { u = location.href; t = document.title; window.open("http://www.google.com/bookmarks/mark?op=edit&bkmk=" + encodeURIComponent(u) + "&title=" + t + "&annotation=" + t); }
    function share_buzz() { u = location.href; t = document.title; window.open("http://buzz.yahoo.com/buzz?publisherurn=DanTri&targetUrl=" + encodeURIComponent(u)); }
    function addto_linkhay() {
        u = location.href; t = document.title; window.open("http://linkhay.com/submit?link_url=" + encodeURIComponent(u));
    }
    function OpenPopup(_url, width, height) {
        window.open(_url, '_blank', 'scrollbars=yes,resizable=yes,locationbar=yes,width=' + width + ',height=' + height + ',left='.concat((screen.width - 1000) / 2).concat(',top=').concat((screen.height - 250) / 2));
    }
</script>
<div class="ro m3">
    <div class="box-content-list">
        <h2 class="h2">
            <a href="#"><span>
                <asp:Literal ID="title_name" runat="server"></asp:Literal></span></a></h2>
        <div class="cattitle_sub">
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
            <div class="clr">
            </div>
        </div>
        <div class="clr">
        </div>
        <div class="box-content-main" style="padding: 10px 0 0 0;" id="content_notice" runat="server"
            visible="false">
            <div class="tintuc-col-main">
                <div class="r-ro">
                    Nội dung này yêu cầu có quyền xem nội dung. Vui lòng thông báo cho quản trị hệ thống.
                </div>
            </div>
        </div>
        <div class="box-content-main" style="padding: 10px 0 0 0;" id="content_news" runat="server"
            visible="true">
            <div class="tintuc-col-main">
                <div class="r-ro">
                    <h1 class="news-title-detail">
                        <asp:Label ID="ltlTitle" runat="server"></asp:Label>
                    </h1>
                    <div class="tangbanbe_s">
                         <a title="Chia sẻ link qua Facebook" onclick="javascript:share_facebook();" href="javascript:void(0)">
                            <img width="16" height="16" border="0" alt="Share Facebook" style="vertical-align: middle;
                                cursor: pointer" src="<%=ResolveUrl("~/")%>images/btn_facebook.gif">
                        </a><a title="Share Twitter" onclick="javascript:share_twitter();" href="javascript:void(0)">
                            <img width="16" height="16" border="0" alt="" style="vertical-align: middle; cursor: pointer"
                                src="<%=ResolveUrl("~/")%>images/btn_twitter.gif">
                        </a><a title="Share Google Bookmark" onclick="javascript:share_google();"
                            href="javascript:void(0)">
                            <img width="16" height="16" border="0" alt="" style="vertical-align: middle; cursor: pointer"
                                src="<%=ResolveUrl("~/")%>images/btn_google.gif">
                        </a><a title="Share Yahoo Buzz!" onclick="javascript:share_buzz();" href="javascript:void(0)">
                            <img width="16" height="16" border="0" alt="" style="vertical-align: middle; cursor: pointer"
                                src="<%=ResolveUrl("~/")%>images/btn_buzz.gif">
                        </a><a title="Share LinkHay" onclick="javascript:addto_linkhay();" href="javascript:void(0)">
                            <img width="16" height="16" border="0" alt="" style="vertical-align: middle; cursor: pointer"
                                src="<%=ResolveUrl("~/")%>images/btn_linkhay.gif">
                        </a>
                    </div>
                    <div class="news-detail-ct">
                        <p>
                            <strong>
                                <asp:Literal ID="ltlDescribe" runat="server"></asp:Literal></strong>
                        </p>
                        <p>
                            <asp:Label ID="FullDescirbe" runat="server"></asp:Label>
                        </p>
                    </div>
                    <%-- <div class="news-detail-releation">
                      <a href="Canh_giac_voi_chieu_lua_dao_bang_SMS_tren_iPhone_170-272-357971.html" class="news-detail-releation">
                        &gt; Cảnh giác với chiêu lừa đảo bằng SMS trên iPhone</a>
                        <br>
                        <a href="iPhone_4S_va_4_giam_gia_nhe__don__iPhone_5_170-0-356583.html" class="news-detail-releation">
                            &gt; iPhone 4S và 4 giảm giá nhẹ 'đón' iPhone 5</a>
                    
                    </div>--%>
                </div>
                <div class="r-ro news-detail-line">
                    <span class="f-14 bold">TAGS:</span>
                    <asp:Literal ID="ltlTags" runat="server"></asp:Literal>
                </div>
                <div class="r-ro news-detail-line">
                    <div class="fr">
                        <span class="text-author">
                            <asp:Label ID="LabelAuthor" runat="server" /></span>
                    </div>
                    <div class="fl">
                        <a class="linkface" title="Share Facebook" onclick="javascript:share_facebook();"
                            href="javascript:void(0)"></a><a class="linkgoogle" title="Share Google Plus"
                                onclick="javascript:share_google();" href="javascript:void(0)"></a><a class="linkyahoo"
                                    title="Share Yahoo Buzz!" onclick="javascript:share_buzz();" href="javascript:void(0)">
                                </a><a class="linktiwth" title="Share Twitter" onclick="javascript:share_twitter();"
                                    href="javascript:void(0)"></a><a class="linkhay" title="Share LinkHay"
                                        onclick="javascript:addto_linkhay();" href="javascript:void(0)">
                        </a><a class="linkmail" title="Mail"></a>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Print" ToolTip="Print"
                            CssClass="linkprint"></asp:LinkButton>
                        <a class="comment" title="<%= Resources.resource.T_Comment_n %>" id="btnComment" runat="server"></a>
                        <div id="PanelComments_form" style="padding-bottom: 15px; display: block;" class="block-comment">
                            <span class="up-arrow"></span>
                            <asp:Literal ID="error" runat="server"></asp:Literal>
                            <div class="main_register_panel">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td style="width: 20%; height: 20px" class="register_text">
                                            <%= Resources.resource.T_Comment_Name %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFullName" runat="server" Width="95%" CssClass="register_text_input"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%; height: 20px" class="register_text">
                                            <%= Resources.resource.T_Comment_Email %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" Width="95%" CssClass="register_text_input"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                                ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                class="register_text_error1">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%; height: 20px" class="register_text">
                                            <%= Resources.resource.T_Comment_Title %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTitle" runat="server" Width="95%" CssClass="register_text_input"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%; height: 20px" class="register_text">
                                            <%= Resources.resource.T_Comment_Content %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContent" runat="server" Width="95%" CssClass="register_text_input"
                                                Height="100px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%; height: 20px" class="register_text">
                                            <%= Resources.resource.T_Comment_Capcha %>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCapcha" runat="server" Width="70" CssClass="register_text_input"></asp:TextBox>
                                            <img id="ImgCapcha" align="absmiddle" alt="" runat="server" src="~/Client/Modules/Captcha/Image.aspx" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" style="height: 48px">
                                            <asp:LinkButton runat="server" ID="LinkButton2" CssClass="Jm dU" Text="<%$ Resources:Resource, T_Comment_n %>" OnClick="Send_Click" />
                                           
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="r-ro news-detail-line">
                    <div id="CommentPanel" runat="server">

                        <div class="fmsCommentListBox">
                            <div class="fmsCommentListHead">
                                <div class="clearfix">
                                    <div class="fmsCommentFormFunctionLeft">
                                        <span class="fmsCommentListTitle"><%= Resources.resource.T_Comment1 %></span> &nbsp;(<span class="fmsCommentListPageView"><asp:Label ID="lblComment" runat="server" Text=""></asp:Label></span>)
                                    </div>
                                </div>
                            </div>
                            <div class="fmsCommentListItems">
                                 <ul class="paging-commnet">
                                <asp:Repeater ID="DataListProductComment" runat="server">
                                    <ItemTemplate>
                                        <li>
                                        <div class="fmsCommentListItem level-1" >
                                            <p>
                                                <span class="fmsCommentListItem-Fullname"><%# Eval("FullName") %></span>: 
                                                <span class="fmsCommentListItem-Content">
                                                    <%# Eval("Content") %>   
                                                </span></p>
                                            <ul class="fmsCommentListItem-Function clearfix">
                                                <li><span class="fmsCommentListItem-Date">
                                                <%# Convert.ToDateTime(Eval("DateCreated")).ToString("dd/MM/yyyy hh:mm") %>
                                                </span></li>
                                             </ul>
                                          
                                        </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                </ul>
                            </div>
                        </div>

                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="r-ro" id="newsOther" runat="server">
                    <div class="box-content-list">
                        <h2>
                            <a href="#"><%= Resources.resource.T_relation %></a></h2>
                        <div class="box-content-main" style="padding: 10px 0;">
                            <!-- post-container -->
                            <div class="boxnew-linkother">
                                <ul>
                                    <asp:Repeater ID="DataListNews" runat="server">
                                        <ItemTemplate>
                                            <li class="ter"><a href="<%# ResolveUrl("~/") + "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                                title="<%# Eval("Title") %>">
                                                <%# Eval("Title") %></a> </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
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
});

/* ]]> */
</script>
<asp:HiddenField ID="txtNewsGroupID" runat="server" />
<asp:HiddenField ID="hddGroupCate" runat="server" />
