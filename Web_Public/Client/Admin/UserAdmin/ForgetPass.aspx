<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPass.aspx.cs" Inherits="Client_Admin_ForgetPass" %>

<%@ Register Src="~/Client/Admin/Control/Menu/Menutop.ascx" TagName="Menutop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Administrator - CMS 2.0</title>
    <meta name="keywords" content="Administrator - CMS 2.0" />
    <meta name="description" content="Administrator - CMS 2.0" />
    <meta name="author" content="ducnm12@gmail.com - 096 236 999" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Font CSS (Via CDN) -->
    <link rel='stylesheet' type='text/css' href='/CSS_Admins/fonts/cssfont.css' />
    <link rel="stylesheet" type="text/css" href="/CSS_Admins/fonts/cssfont-1.css" />
    <!-- Theme CSS -->
    <link rel="stylesheet" type="text/css" href="/CSS_Admins/skin/default_skin/css/theme.css" />
    <!-- Admin Forms CSS -->
    <link rel="stylesheet" type="text/css" href="/CSS_Admins/admin-tools/admin-forms/css/admin-forms.css" />
    <!-- Favicon -->
    <link rel="shortcut icon" href="/favicon.ico" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
   <script src="/CSS_Admins/js/html5shiv.js"></script>
   <script src="/CSS_Admins/js/respond.min.js"></script>
   <![endif]-->
</head>
<body class="external-page sb-l-c sb-r-c">
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
                <div class="admin-form theme-primary mw500" style="margin-top: 10%;" id="login1">
                    <div class="row mb15 table-layout">
                        <div class="col-xs-6 center-block text-center va-m pln">
                            <a href="/" title="Trang chủ">
                                <img src="/CSS_Admins/img/logos/logo_white.png" title="CMS" class="img-responsive w250">
                            </a>
                        </div>
                        <div class="col-xs-6 text-right va-b pr5">
                            <div class="login-links">
                                <a href="javascript:void(0)" class="" title="False Credentials">Quên mật khẩu</a>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info mv10 heading-border br-n">
                        <div class="panel-body bg-light p20">
                            <div class="alert alert-micro alert-border-left alert-info pastel alert-dismissable mn">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">
                                    ×</button>
                                <i class="fa fa-info pr10"></i>Nhập <b>Email</b> của bạn để thiết lập lại mật khẩu.
                                Bạn sẽ nhận được một email với nội dung hướng dẫn lấy lại mật khẩu!
                            </div>
                        </div>
                        <div class="panel-footer p25 pv15">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="section mn">
                                        <div class="smart-widget sm-right smr-80">
                                            <label for="email" class="field prepend-icon">
                                                <asp:TextBox ID="txtEmail" ValidationGroup="services" runat="server" CssClass="gui-input"
                                                    placeholder="Nhập Email lấy lại mật khẩu" aria-describedby="sizing-addon3"></asp:TextBox>
                                                <label class="field-icon p10 text-primary">
                                                    <span class="fa fa-envelope-o"></span>
                                                </label>
                                            </label>
                                            <asp:Button ID="btn_sumit1" runat="server" class="button btn-primary" Text="Reset"
                                                OnClick="btn_GetPass_Click" />
                                        </div>
                                        <!-- end .smart-widget section -->
                                    </div>
                                    <!-- end section -->
                                </div>
                            </div>
                        </div>
                        <!-- end .form-header section -->
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
    <script type="text/javascript" src="/CSS_Admins/vendor/jquery/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="/CSS_Admins/vendor/jquery/jquery_ui/jquery-ui.min.js"></script>
    <!-- Bootstrap -->
    <script type="text/javascript" src="/CSS_Admins/js/bootstrap/bootstrap.min.js"></script>
    <!-- Page Plugins -->
    <script type="text/javascript" src="/CSS_Admins/js/pages/login/EasePack.min.js"></script>
    <script type="text/javascript" src="/CSS_Admins/js/pages/login/rAF.js"></script>
    <script type="text/javascript" src="/CSS_Admins/js/pages/login/TweenLite.min.js"></script>
    <script type="text/javascript" src="/CSS_Admins/js/pages/login/login.js"></script>
    <!-- Theme Javascript -->
    <script type="text/javascript" src="/CSS_Admins/js/utility/utility.js"></script>
    <script type="text/javascript" src="/CSS_Admins/js/main.js"></script>
    <script type="text/javascript" src="/CSS_Admins/js/demo.js"></script>
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
