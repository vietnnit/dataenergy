<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menutop.ascx.cs" Inherits="Control_Modules_Menu_Menutop" %>
<ul class="nav navbar-nav navbar-right">
    <li><a href="/Admin/home/Default.aspx"><span
        class="octicon octicon-home fs18 mr5"></span>
    </a></li>
    <li>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="linkRemoveCache_Click">
        <span class="fa fa-exchange fs18 mr5" ></span>
        </asp:LinkButton>
      </li>
    <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">
        <asp:Label ID="lang" runat="server" Text=""></asp:Label>
    </a>
        <ul class="dropdown-menu animated animated-short flipInX" role="menu">
            <li>
                <asp:LinkButton ID="btnVN" runat="server" OnClick="btn_lang_vi" CssClass="fw600"> 
                                <span class="flag-xs flag-vn mr10"></span>Tiếng Việt
                </asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="btnUS" runat="server" OnClick="btn_lang_en" CssClass="fw600"> 
                                     <span class="flag-xs flag-us mr10"></span>English
                </asp:LinkButton>
            </li>
        </ul>
    </li>
    <li class="dropdown"><a href="#" class="dropdown-toggle fw600 " data-toggle="dropdown">
        <asp:Label ID="welcomAdmin" runat="server" Text=""></asp:Label>
        <span class="caret caret-tp"></span></a>
        <ul class="dropdown-menu dropdown-persist pn w250 bg-white" role="menu">
             <li class="br-t of-h">
             <asp:LinkButton ID="LinkButton3" runat="server" OnClick="linkRemoveCache_Click" CssClass="fw600 p12 animated animated-short fadeInUp" >
                <span class="fa fa-magic pr5"></span>Xóa Cache
             </asp:LinkButton>
            </li>
            <li class="br-t of-h">
                <asp:LinkButton ID="lbSignInOrther" runat="server" OnClick="lbSignInOrther_Click" CssClass="fw600 p12 animated animated-short fadeInDown">
                               <span class="fa fa-sign-out pr5"></span>Đăng nhập tài khoản khác
                </asp:LinkButton>
            </li>
            <li class="br-t of-h"><a href="/Admin/changepass/Default.aspx" class="fw600 p12 animated animated-short fadeInUp">
                <span class="fa fa-key pr5"></span>Đổi mật khẩu</a></li>
            <li class="br-t of-h">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="fw600 p12 animated animated-short fadeInDown">
                               <span class="fa fa-power-off pr5"></span>Thoát
                </asp:LinkButton>
            </li>
        </ul>
    </li>
</ul>
