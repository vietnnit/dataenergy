<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerMenuTop.ascx.cs"
    Inherits="Client_BannerMenuTop" %>

<div class="search-open" >
    <div class="container animated fadeInDown">
        <div class="input-group">
            <asp:TextBox ID="txtkeyword" runat="server" CssClass="form-control" OnTextChanged="txtSearch_TextChanged" placeholder="<%$ Resources:Resource, T_Search_text %>" ValidationGroup="searchBanner"></asp:TextBox>
            <span class="input-group-btn">
                <asp:LinkButton CssClass="btn-u" ID="btnsearch" runat="server" onclick="btnSearch_Click" ValidationGroup="searchBanner">Tìm</asp:LinkButton>
            </span>
        </div>
    </div>
</div>    

<div class="container">
    <div class="row">
        <div class="col-md-6 col-lg-6 col-sm-12 col-xs-12">
            <ul class="left-topbar list-inline top-v1-contacts">
                <asp:Repeater ID="rptAdv2" runat="server">
                    <ItemTemplate>
                         <li class="hidden-xs">
                            <a href="<%# Eval("MenuLinksUrl") %>" target="<%# Eval("Target") %>">
                                <%# Eval("MenuLinksName") %>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>

        <div class="col-md-6 col-lg-6 hidden-sm hidden-xs">
            <ul class="list-inline right-topbar pull-right top-v1-data">
                <%--<li><a href="<%= ResolveUrl("~/") %>" title="Trang chủ"><i class="fa fa-home"></i></a></li>--%>

                 <asp:Repeater ID="rptAdv" runat="server">
                    <ItemTemplate>
                        <li><a href="<%# Eval("MenuLinksUrl") %>" target="<%# Eval("Target") %>">
                            <%# Eval("MenuLinksName") %>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <li id="liSignOut" runat="server">
                   <asp:Literal ID="ltInfoUser" runat="server"></asp:Literal>
                    (<asp:LinkButton ID="btnSignOut" runat="server" OnClick="btnSignOut_Click" Text="Thoát"></asp:LinkButton>)
                </li>
                <%--<li id="liSignIn" runat="server"><a href="<%=ResolveUrl("~") %>">Đăng nhập</a></li>       --%>                              
            </ul>
        </div>
    </div>        
</div>


<asp:HiddenField ID="hddValue" runat="server" Value="MenuTop" />

<asp:HiddenField ID="hddValue2" runat="server" Value="MenuTopLeft" />