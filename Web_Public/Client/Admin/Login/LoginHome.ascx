<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginHome.ascx.cs" Inherits="Admin_LoginHome" %>
<div class="loginContainer" id="loginForm">
    <div class="form-row row-fluid">
        <div class="span12">
            <div class="row-fluid">
                <label class="form-label span12" for="username">
                    Tài khoản: <span class="icon16 icomoon-icon-user-2 right gray marginR10"></span>
                </label>
                <asp:TextBox ID="txtAdminUser" runat="server" CssClass="span12"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="form-row row-fluid">
        <div class="span12">
            <div class="row-fluid">
                <label class="form-label span12" for="password">
                    Mật khẩu: <span class="icon16 icomoon-icon-locked right gray marginR10"></span>
                </label>
                <asp:TextBox ID="txtAdminPass" runat="server" CssClass="span12" TextMode="Password"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="form-row row-fluid" id="capcha_panel" runat="server">
        <div class="span12">
            <div class="row-fluid">
                <label class="form-label span12" for="password">
                   Mã xác nhận: <span class="icon16-l entypo-icon-images right  red marginR10"></span>
                </label>
                <asp:TextBox ID="txtCapcha" runat="server" CssClass="leftFix span6 marginR10" ></asp:TextBox>
                <img id="ImgCapcha" style="vertical-align:middle;padding:3px 0 0 10px;" alt="" runat="server" src="~/Client/Admin/Captcha/Image.aspx" />
            </div>
        </div>
    </div>
    <div class="form-row row-fluid">
        <div class="span12">
            <div class="row-fluid">
                <div class="form-actions">
                    <div class="span12 controls">
                        <asp:CheckBox ID="chkRemember" runat="server" Visible="false" CssClass="chk-login" Text="Nhớ thông tin đăng nhập" />
                        <asp:LinkButton ID="Button1" runat="server" ValidationGroup="G" Text="Đăng nhập" OnClick="btn_sumit_Click"
                            CssClass="btn btn-sm btn-info right btn-login"><i class="fa fa-sign-in"></i>&nbsp;&nbsp;Đăng nhập</asp:LinkButton>
                    </div>
                    <label class="form-label span12" for="password">
                        <span class="forgot">
                            <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" OnClick="btnGetPass_Click" CssClass="login_link_button">Lấy lại mật khẩu</asp:LinkButton></span>
                    </label>
                </div>
            </div>
        </div>
    </div>
</div>


