<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNewsApprovedComment.aspx.cs"
    Inherits="Admin_Controls_ViewNewsApprovedComment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMS - Comment</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <meta content="noodp,index,follow" name="robots" />
    <meta content="Copyright © 2011 by minhducmd@yahoo.com - 0963 236 999" name="copyright" />
    <meta content="Global" name="distribution" />
    <meta content="1 DAYS" name="REVISIT-AFTER" />
    <meta content="GENERAL" name="RATING" />
</head>
<body>
    <link href="<%= ResolveUrl("~/") %>CSS/layout.css" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveUrl("~/") %>CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.css" rel="stylesheet"
        type="text/css" />
    <script src="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">

    $(document).ready(function() {
	    $("ul.paging-commnet").quickPager({pageSize:5});
    });

    </script>

    <form id="form1" runat="server">
    <div>
        <div class="container_16">
        <div class="grid_10">
            <div class="r-ro news-detail-line">
                <asp:Literal ID="error" runat="server"></asp:Literal>
                <div class="main_register_panel">
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="width: 20%; height: 20px" class="register_text">
                                Gửi nội dung phản hồi
                            </td>
                            <td>
                                <asp:TextBox ID="txtContent" runat="server" Width="95%" CssClass="register_text_input"
                                    Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; height: 20px" class="register_text">
                                Mã xác nhận
                            </td>
                            <td>
                                <asp:TextBox ID="txtCapcha" runat="server" Width="70" CssClass="register_text_input"></asp:TextBox>
                                <img id="ImgCapcha" align="absmiddle" alt="" runat="server" src="~/Client/Modules/Captcha/Image.aspx" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton runat="server" ID="LinkButton2" CssClass="Jm dU" Text="Gửi phản hồi"
                                    OnClick="Send_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="r-ro news-detail-line">
                <div id="CommentPanel" runat="server">
                    <div class="fmsCommentListBox">
                        <div class="fmsCommentListHead">
                            <div class="clearfix">
                                <div class="fmsCommentFormFunctionLeft">
                                    <span class="fmsCommentListTitle">Phản hồi duyệt bài </span>&nbsp;(<span class="fmsCommentListPageView"><asp:Label
                                        ID="lblComment" runat="server" Text=""></asp:Label></span>)
                                </div>
                            </div>
                        </div>
                        <div class="fmsCommentListItems">
                            <ul class="paging-commnet">
                                <asp:Repeater ID="DataListProductComment" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div class="fmsCommentListItem level-1">
                                                <p>
                                                    <span class="fmsCommentListItem-Fullname">
                                                        <%# Eval("UserName") %></span>: <span class="fmsCommentListItem-Content">
                                                            <%# Eval("Content") %>
                                                        </span>
                                                </p>
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
            </div>
        </div>
    </div>
    <asp:HiddenField ID="txtNewsGroupID" runat="server" />
    
    </form>
</body>
</html>
