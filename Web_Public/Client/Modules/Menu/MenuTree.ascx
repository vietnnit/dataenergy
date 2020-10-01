<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuTree.ascx.cs" Inherits="Control_Modules_Menu_MenuTree" %>
<link type="text/css" href="<%=ResolveUrl("~/")%>Scripts/FancyTree/style.css" rel="stylesheet" />
<script type="text/javascript" src="<%=ResolveUrl("~/")%>Scripts/FancyTree/jquery.js"></script>
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
<div class="r-ro">
    <div id="treeMenu">
        <asp:Literal ID="MenuNews" runat="server"></asp:Literal>
    </div>
</div>
