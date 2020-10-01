<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuTreeUSSH.ascx.cs" Inherits="Control_Modules_MenuTreeUSSH" %>
<link type="text/css" href="<%=ResolveUrl("~/")%>Scripts/FancyTree/menu_ussh.css" rel="stylesheet" />
<script type="text/javascript" src="<%=ResolveUrl("~/")%>Scripts/FancyTree/treeMenu.js"></script>
<style type="text/css">
    .rightPrt
    {
        position: absolute;
        left: 324px;
        top: 274px;
    }
    div.link
    {
        width: 322px;
        height: 255px;
        float: left;
        display: inline;
    }
    div.link a
    {
        width: 100%;
        height: 100%;
        display: block;
        text-decoration: none;
        outline: none 0;
    }
</style>
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 box-white-block mb10" id="panel_menutree" runat="server">
    <div id="treeMenu">
        <asp:Literal ID="MenuNews" runat="server"></asp:Literal>
    </div>
</div>
