<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintNewsGroup.aspx.cs" Inherits="Client_PrintNewsGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Printer</title>
</head>
<body>
    <link type="text/css" rel="stylesheet" href="<%= Page.ResolveUrl("~/")%>CSS/order.css" />
    <link type="text/css" rel="stylesheet" href="<%= Page.ResolveUrl("~/")%>CSS/style.css" />
    <form id="form1" runat="server">
    <asp:Panel ID="Panel_NewsGroup" runat="server">
        <div id="outter">
           
            <div class="md-talbe">
                <div id="content">
                    <!--begin header -->
                    <div id="header">
                        <!--begin logo and name -->
                        <div class="logo-name">
                            <div class="logo fl">
                                <a href="#">
                                    <img src="<%= Page.ResolveUrl("~/")%>images/logo_black.png"></a></div>
                        </div>
                        <!--end logo and name -->
                    </div>
                    <!--end header -->
                    <!--begin body content -->
                    <div id="body-content">
                        <div class="content-wrap">
                            <!--begin noi dung so1 -->
                            <div class="r-ro">
                                <h1 class="news-title-detail">
                                    <asp:Label ID="ltlTitle" runat="server"></asp:Label>
                                </h1>
                                <div class="news-detail-ct">
                                    <p>
                                        <asp:Label ID="FullDescirbe" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <div class="r-ro news-detail-line" style="padding-bottom:10px;">
                                <div class="fr">
                                    <span class="text-author">Tác giả:
                                        <asp:Label ID="LabelAuthor" runat="server" /></span> ; <span class="text-author">xuất
                                            bản:
                                            <asp:Label ID="LabelDate" runat="server" /></span>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end body content -->
                </div>
            </div>
          
        </div>
    </asp:Panel>
    <div id="Div3">
        <div class="register_succeed">
            <asp:ImageButton ID="cmdPrint" runat="server" OnClick="btn_print" ImageUrl="~/images/btnPrint.png" />
            <asp:ImageButton ID="btn_add" runat="server" OnClick="btn_finish" ImageUrl="~/images/btnContinue1.png" />
        </div>
    </div>
    <asp:HiddenField ID="txtNewsGroupID" runat="server" />
    </form>
</body>
</html>
