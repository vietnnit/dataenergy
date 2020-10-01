<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuResponsive.ascx.cs"
    Inherits="Client_Modules_Menu_MenuResponsive" %>

<div class="collapse navbar-collapse mega-menu navbar-responsive-collapse">

        <ul class="nav navbar-nav">
            <!-- Home -->
            <!-- Shortcodes -->
            <li class="dropdown">
                <a href="<%= ResolveUrl("~/") %>" class="dropdown-toggle">
                     <span class="fa fa-home" style="font-size:21px;"></span>
                </a>
            </li>

            <asp:Literal ID="MenuNews" runat="server"></asp:Literal>

    
</div>

