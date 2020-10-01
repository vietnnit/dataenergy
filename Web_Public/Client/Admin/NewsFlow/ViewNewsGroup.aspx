<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNewsGroup.aspx.cs" Inherits="Client_Admin_ViewNewsGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Administrator - CMS2.0</title>
    <link href="<%=ResolveUrl("~/")%>CSS_Admin/style_news.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <h1 class="main_title_news_bold">
        <asp:Label ID="ltlTitle" runat="server" CssClass="main_title_news_bold"></asp:Label>
        <span class="date">(<asp:Label ID="LabelDate" runat="server" CssClass="date"></asp:Label>)</span></h1>
        
    <div style="width: 100%">
        <p class="main_desc_news" style="font-size: 13px;">
            <strong>
                <asp:Literal ID="ltlDescribe" runat="server"></asp:Literal></strong>
        </p>
        <div class="main_desc_news">
            <asp:Label ID="FullDescirbe" runat="server"></asp:Label></div>
    </div>
     <div class="main_content_author">
                <asp:Label ID="LabelAuthor" runat="server" /></div>
    </form>
</body>
</html>
