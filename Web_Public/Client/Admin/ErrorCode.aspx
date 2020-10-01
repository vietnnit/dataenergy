<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorCode.aspx.cs" Inherits="Admin_ErrorCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Support EVNIT</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Bạn không được quyền truy cập vào khu vực . Xin hãy liên hệ với BQT !" Font-Size="Large" ForeColor="Red"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text="Click vào "></asp:Label>&nbsp;<asp:HyperLink
            ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Login.aspx"> đây </asp:HyperLink>
        <asp:Label ID="Label3" runat="server" Text="để đăng nhập lại ."></asp:Label></div>
    </form>
</body>
</html>
