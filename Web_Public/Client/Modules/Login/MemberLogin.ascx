<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MemberLogin.ascx.cs" Inherits="Client_Modules_MemberLogin" %>
<div class="panel panel-blue">
    <div class="panel-heading">
        <h3 class="panel-title">
            <i class="fa fa-user"></i>
            <asp:Label ID="lblTitle" runat="server" Text="Doanh nghiệp đăng nhập"></asp:Label>
        </h3>
    </div>
    <div class="panel-body pt10 pb10">
        <div class="form-horizontal">
            <asp:Panel ID="plLogin" runat="server" DefaultButton="btnMember">
                <asp:Literal ID="error" runat="server"></asp:Literal>
                <%--<asp:ValidationSummary CssClass="class='alert alert-sm alert-danger bg-gradient p5 mbn"
                    ID="vsErr" runat="server" DisplayMode="List" ShowSummary="true" HeaderText="Vui lòng nhập kiểm tra lại."
                    ValidationGroup="valLogin" />--%>
                <div class="form-group mbn">
                    <label class="col-sm-12 control-label ptn">
                        Tên đăng nhập</label>
                    <div class="col-sm-12">
                        <div class="input-group input-group-sm margin-10b">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                            <asp:TextBox ID="txtAdminUser11" runat="server" aria-describedby="sizing-addon3"
                                CssClass="form-control" MaxLength="50"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ID="rfvAdminUser" ControlToValidate="txtAdminUser11"
                            ValidationGroup="valLogin" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Tài khoản không được bỏ trống"><span class="append-icon right text-danger">Vui lòng nhập tài khoản</span></asp:RequiredFieldValidator>
                    </div>
                    <label class="col-sm-12 control-label">
                        Mật khẩu</label>
                    <div class="col-sm-12">
                        <div class="input-group input-group-sm margin-10b">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                            <asp:TextBox ID="txtAdminPass11" aria-describedby="sizing-addon3" placeholder="Mật khẩu"
                                class="form-control" runat="server" TextMode="Password" CssClass="form-control"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtAdminPass11"
                            ValidationGroup="valLogin" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Mật khẩu không được bỏ trống"><span class="append-icon right text-danger" >Vui lòng nhập mật khẩu</span></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mt20 mb20">
                        <div class="input-group input-group-sm margin-10b" style="width: 100%">
                            <asp:LinkButton ID="btnMember" runat="server" Text="Đăng nhập" Width="100%" CssClass="btn btn-danger btn-sm"
                                OnClick="btnMember_Click" ValidationGroup="valLogin"><i class="fa fa-sign-in"></i>&nbsp;&nbsp;Đăng nhập</asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-sm-6 mt20 mb20">
                        <a href="<%=ResolveUrl("~") %>danh-sach-so-cong-thuong.aspx"><i class="fa fa-key"></i>&nbsp;&nbsp;Quên mật khẩu</a> <a href="<%=ResolveUrl("~") %>danh-sach-so-cong-thuong.aspx"><i
                            class="fa fa-user-plus"></i>&nbsp;&nbsp;Đăng ký</a>
                    </div>
                    <div class="col-sm-12">
                        <a href="<%=ResolveUrl("~") %>admin/login.aspx"><i class="fa fa-sign-in"></i>&nbsp;&nbsp;Sở
                            SCT, Bộ CT truy cập</a>
                    </div>
                </div>
            </asp:Panel>
        </div>
        <div id="plUser" runat="server">
            <div class="overflow-h">
                <span class="font-s fwb">
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></span>
                <p class="color-grey mbn">
                    <i class="fa fa-user"></i>&nbsp;Tên đăng nhập: <span class="hex">
                        <asp:Label ID="ltAccountName" runat="server" Text="Label"></asp:Label></span></p>
                <p class="color-grey mbn">
                    <i class="fa fa-envelope"></i>&nbsp;Email: <span class="hex">
                        <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></span></p>
                <p class="color-grey mbn">
                    <i class="fa fa-phone"></i>&nbsp;Điện thoại: <span class="hex">
                        <asp:Label ID="lblTel" runat="server" Text="Label"></asp:Label></span></p>
                <p class="color-grey mbn">
                    <i class="fa fa-home"></i>&nbsp;Địa chỉ: <span class="hex">
                        <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></span></p>
            </div>
            <hr class="mt5 mb5" />
            <ul class="list-unstyled save-job">
                <li></li>
            </ul>
            <div class="input-group input-group-sm">
                <div class="col-sm-6">
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Thoát" CssClass="btn btn-danger btn-sm"
                        OnClick="btn_signout_Click"><i class="fa fa-sign-out"></i>&nbsp;&nbsp;Thoát</asp:LinkButton></div>
                <div class="col-sm-6">
                    <a href="<%=ResolveUrl("~") %>thong-tin-doanh-nghiep.aspx" class="btn btn-primary btn-sm"><i class="fa fa-info"></i>&nbsp;&nbsp;Thông tin DN</a></div>
            </div>
        </div>
    </div>
</div>
