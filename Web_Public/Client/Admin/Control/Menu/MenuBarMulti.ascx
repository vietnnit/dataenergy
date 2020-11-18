<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuBarMulti.ascx.cs" Inherits="Client_Admin_Control_Menu_MenuBarMulti" %>
<link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/")%>Scripts/menubar/ddsmoothmenu.css" />
<link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/")%>Scripts/menubar/ddsmoothmenu-v.css" />
<script type="text/javascript" src="<%=ResolveUrl("~/")%>Scripts/menubar/ddsmoothmenu.js"></script>
<script type="text/javascript">
    ddsmoothmenu.init({
        mainmenuid: "smoothmenu1",
        orientation: 'h',
        classname: 'ddsmoothmenu',
        contentsource: "markup"
    })
</script>

    <div class="container_24 menubar-bg">
        <div class="grid_24">
            <div id="smoothmenu1" class="ddsmoothmenu">
                <asp:Literal ID="MenuNews" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>

