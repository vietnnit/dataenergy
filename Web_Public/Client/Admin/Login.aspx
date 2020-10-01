<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Client_Admin_Login" %>

<%@ Register Src="~/Client/Admin/Control/Menu/Menutop.ascx" TagName="Menutop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Quản trị hệ thống EED v2.0</title>
    <meta name="keywords" content="Quản trị hệ thống EED 2.0" />
    <meta name="description" content="Quản trị hệ thống EED 2.0" />
    <meta name="author" content="cuonglv.vis@gmail.com - 0986152258" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Font CSS (Via CDN) -->
    <!-- Favicon -->
    <link rel="shortcut icon" href="/favicon.ico" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
   <script src="/CSS_Admins/js/html5shiv.js"></script>
   <script src="/CSS_Admins/js/respond.min.js"></script>
   <![endif]-->
</head>
<body class="external-page sb-l-c sb-r-c">
    <link rel='stylesheet' type='text/css' href='<%=ResolveUrl("~") %>CSS_Admins/fonts/cssfont.css' />
    <link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~") %>CSS_Admins/fonts/cssfont-1.css" />
    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~") %>CSS_Admins/skin/default_skin/css/theme.css" />
    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~") %>CSS_Admins/admin-tools/admin-forms/css/admin-forms.css" />
    <!-- Start: Settings Scripts -->
    <script>
        var boxtest = localStorage.getItem('boxed');

        if (boxtest === 'true') {
            document.body.className += ' boxed-layout';
        }
    </script>
    <!-- End: Settings Scripts -->
    <!-- Start: Main -->
    <div id="main" class="animated fadeIn">
        <form id="form1" runat="server">
        <!-- Start: Content -->
        <div id="content_wrapper">
            <!-- begin canvas animation bg -->
            <div id="canvas-wrapper">
                <canvas id="demo-canvas"></canvas>
            </div>
            <!-- Begin: Content -->
            <div id="content">
                <div class="admin-form theme-info" id="login1">
                    <div class="row mb15 table-layout">
                        <div class="col-xs-6 va-m pln">
                            <a href="/" title="Return to Dashboard">
                                <img src="<%=ResolveUrl("~") %>CSS_Admins/img/logos/logo_white.png" title="Quản trị hệ thống" class="img-responsive w250" />
                            </a>
                        </div>
                    </div>
                    <div class="panel panel-info mt10 br-n">
                        <div class="panel-heading heading-border bg-white" style="padding: 5px;">
                        <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                        </div>
                        <!-- end .form-header section -->
                        <div class="panel-body bg-light p20">
                            <div class="row">
                                <div class="col-sm-12 pr30">
                                    <div class="form-group">
                                        <label for="txtAdminUser" class="control-label text-muted fs14 mb10">
                                            Tên đăng nhập</label>
                                        <div class="input-group input-group-sm margin-10b">
                                            <span class="input-group-addon field-icon"><span class="fa fa-user"></span></span>
                                            <asp:TextBox ID="txtAdminUser" ValidationGroup="valLogin" runat="server" CssClass="gui-input"
                                                placeholder="Nhập tên đăng nhập" aria-describedby="sizing-addon3"></asp:TextBox>                                                
                                        </div>
                                        <asp:RequiredFieldValidator ID="rfvUserName" SetFocusOnError="true" runat="server" Display="Dynamic" ValidationGroup="valLogin" ControlToValidate="txtAdminUser" Text="Vui lòng nhập tên đăng nhập"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtAdminPass" class="control-label text-muted fs14 mb10">
                                            Mật khẩu</label>
                                        <div class="input-group input-group-sm margin-10b">
                                            <span class="input-group-addon field-icon"><span class="fa fa-key"></span></span>
                                            <asp:TextBox ID="txtAdminPass" runat="server" TextMode="Password" class="gui-input"
                                                placeholder="Nhập mật khẩu"></asp:TextBox>                                                
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" runat="server"  Display="Dynamic" ValidationGroup="valLogin" ControlToValidate="txtAdminPass" Text="Vui lòng nhập mật khẩu"></asp:RequiredFieldValidator>
                                    </div>
                                    <div id="Div1" class="form-group" runat="server" visible="false">
                                        <label for="ddlLanguage" class="control-label text-muted fs14 mb10">
                                            Báo cáo năm</label>
                                        <div class="input-group input-group-sm margin-10b">
                                            <span class="input-group-addon"><span class="glyphicon glyphicon-globe"></span></span>
                                            <asp:DropDownList ID="ddlYear" runat="server" class="gui-input">                                               
                                            </asp:DropDownList>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="true"  Display="Dynamic"  runat="server" ValidationGroup="valLogin" ControlToValidate="ddlYear" Text="Vui lòng chọn năm báo cáo"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group" runat="server" visible="false">
                                        <label for="ddlLanguage" class="control-label text-muted fs14 mb10">
                                            Ngôn ngữ</label>
                                        <div class="input-group input-group-sm margin-10b">
                                            <span class="input-group-addon"><span class="glyphicon glyphicon-globe"></span></span>
                                            <asp:DropDownList ID="ddlLanguage" runat="server" class="gui-input">
                                                <asp:ListItem Value="vi-VN" Selected="True">Tiếng Việt</asp:ListItem>
                                                <asp:ListItem Value="en-US">Tiếng Anh</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <!-- end section -->
                                </div>
                            </div>
                        </div>
                        <!-- end .form-body section -->
                        <div class="panel-footer clearfix p10 ph15">
                            <asp:Button ID="btn_sumit1" runat="server" class="btn btn-sm btn-primary mr10 pull-right"
                                Text="Đăng nhập" OnClick="btn_sumit1_Click1" ValidationGroup="valLogin"/>
                            <label class="switch block switch-primary pull-left input-align mt10">
                                <a href="<%=ResolveUrl("~") %>"><span><i class="fa fa-home"></i>&nbsp;Trang chủ</span></a>
                            </label>
                        </div>
                        <!-- end .form-footer section -->
                    </div>
                </div>
            </div>
            <!-- End: Content -->
        </div>
        <!-- End: Content-Wrapper -->
        <!-- End: Main -->
        </form>
    </div>
    <!-- BEGIN: PAGE SCRIPTS -->
    <!-- Google Map API -->
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=true"></script>
    <!-- jQuery -->
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>
    <!-- Bootstrap -->
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/js/bootstrap/bootstrap.min.js"></script>
    <!-- Page Plugins -->
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/js/pages/login/EasePack.min.js"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/js/pages/login/rAF.js"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/js/pages/login/TweenLite.min.js"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/js/pages/login/login.js"></script>
    <!-- Theme Javascript -->
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/js/utility/utility.js"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/js/main.js"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~") %>CSS_Admins/js/demo.js"></script>
    <!-- Page Javascript -->
    <script type="text/javascript">
        jQuery(document).ready(function() {

            "use strict";

            // Init Theme Core      
            Core.init();

            // Init Demo JS
            Demo.init();

            // Init CanvasBG and pass target starting location
            CanvasBG.init({
                Loc: {
                    x: window.innerWidth / 2,
                    y: window.innerHeight / 3.3
                },
            });


        });
    </script>
    <!-- END: PAGE SCRIPTS -->
</body>
</html>
