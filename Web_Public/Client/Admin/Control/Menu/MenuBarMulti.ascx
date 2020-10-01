<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuBarMulti.ascx.cs"
    Inherits="Control_Modules_Menu_MenuBarMulti" %>
    

<link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/")%>CSS_Admin/js/menu/ddsmoothmenu.css" />
<link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/")%>CSS_Admin/js/menu/ddsmoothmenu-v.css" />

<%--<script type="text/javascript" src="<%=ResolveUrl("~/")%>CSS_Admin/js/menu/jquery.min.js"></script>--%>
<script type="text/javascript" src="<%=ResolveUrl("~/")%>CSS_Admin/js/menu/ddsmoothmenu.js">

</script>

<script type="text/javascript">

ddsmoothmenu.init({
	mainmenuid: "smoothmenu1", //menu DIV id
	orientation: 'h', //Horizontal or vertical menu: Set to "h" or "v"
	classname: 'ddsmoothmenu', //class added to menu's outer DIV
	//customtheme: ["#1c5a80", "#18374a"],
	contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
})

</script>    

<div id="smoothmenu1" class="ddsmoothmenu">
<asp:Literal ID="MenuNews" runat="server"></asp:Literal>

<br style="clear: left" />
</div> 