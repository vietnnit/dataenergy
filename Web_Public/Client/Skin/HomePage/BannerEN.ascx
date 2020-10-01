<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerEN.ascx.cs" Inherits="Client_BannerEN" %>
<%@ Register Src="~/Client/Skin/HomePage/BannerTop.ascx" TagName="BannerTop" TagPrefix="panelBannerTop" %>

<div class="container">
    <div class="row">
        <div class="col-lg-16 col-md-16 col-sm-24 col-xs-24">
            <div class="header-logo">
                <h1 class="logo-en">
                    <a href="/" title="http://tuyensinhtructuyen.edu.vn">http://tuyensinhtructuyen.edu.vn</a>
                </h1>
            </div>
        </div>
        <div class="col-lg-8 col-md-8 hidden-xs hidden-sm">
            <panelBannerTop:BannerTop ID="bannerTop1" runat="server" />
        </div>
        <div class="clear">
        </div>
    </div>
</div>
