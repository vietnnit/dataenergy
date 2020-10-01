<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="Client_Admin_Header" %>
<%@ Register Src="~/Client/Admin/BlockWelCome.ascx" TagName="BlockWelCome" TagPrefix="panelBlockWelCome" %>

<div id="banner">
    <div id="menutop">
	    <ul class="MenuBarTop">
           <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/menutop_homepage.png" CssClass="icon_menutop" /><asp:Label ID="Label1" runat="server" Text="Trang chủ" />
                </asp:HyperLink>
           </li>
           <li>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Sitemap/Default.aspx">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/menutop_sitemap.png" CssClass="icon_menutop" /><asp:Label ID="Label2" runat="server" Text="Sitemap" />
                </asp:HyperLink>
           </li>
           
           <li>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Contact/Default.aspx">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/menutop_contact.png" CssClass="icon_menutop" /><asp:Label ID="Label4" runat="server" Text="Liên hệ" />
                </asp:HyperLink>
           </li>
           <li>
                <asp:HyperLink ID="HyperLink3" runat="server" >
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/menutop_webmail.png" CssClass="icon_menutop" />
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="linkRemoveCache_Click">Xóa Cache</asp:LinkButton>  
                </asp:HyperLink>
            </li>
           <li>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/login/Default.aspx">
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/menutop_login.png" CssClass="icon_menutop" /><asp:Label ID="lblLogin" runat="server" Text="Đăng nhập" />
                </asp:HyperLink>
           </li>
                                    
                        
         </ul>

    </div>
    
    <div style="position:relative; top:85px; left:780px;width:220px;" ID="div_welcome" runat="server">
        <panelBlockWelCome:BlockWelCome ID="blockWelcome1" runat="server" />
    </div>
    
</div>

