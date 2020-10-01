<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditPhoneBook.ascx.cs"
    Inherits="Client_Admin_EditPhoneBook" %>
<div id="menubarsub">
    <div class="left_menubarsub">
        <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
        <span class="text_menubarsub">
            <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
    </div>
    <div class="right_menubarsub">
        <div id="toolbar" class="toolbar-list">
            <ul>
                <li id="Li1" class="button">
                    <asp:HyperLink ID="btn_home" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
                        CssClass="toolbar">
                        <span class="icon-32-home"> </span>Trang chủ 
                    </asp:HyperLink>
                </li>
                <li id="Li2" class="button">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/listphonebook/Default.aspx"
                        CssClass="toolbar">
                        <span class="icon-32-stats"> </span>Danh mục
                    </asp:HyperLink>
                </li>
                <li id="toolbar-new" class="button">
                    <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editphonebook/Default.aspx"
                        CssClass="toolbar"> <span class="icon-32-new"> </span>Tạo mới
                    </asp:HyperLink>
                </li>
                <li id="toolbar-checkin" class="button">
                    <asp:LinkButton ID="btn_add" runat="server" OnClick='btn_add_Click' CssClass="toolbar">
                <span class="icon-32-save"> </span>Lưu lại</asp:LinkButton>
                </li>
                <li id="Li3" class="button">
                    <asp:LinkButton ID="btn_edit" runat="server" OnClick='btn_edit_Click' CssClass="toolbar">
                <span class="icon-32-save"> </span>Lưu lại</asp:LinkButton>
                </li>
                <li id="toolbar-help" class="button"><a class="toolbar" rel="help" href="#"><span
                    class="icon-32-help"></span>Help </a></li>
            </ul>
            <div class="clr">
            </div>
        </div>
    </div>
</div>
<div class="Yt">
    <div class="lineBE">
        <table class="table_line" cellpadding="0" cellspacing="0" width="96%" border="0">
            <tbody>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Literal ID="clientview" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label6" runat="server" Text="Chọn nhóm :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="96%" AppendDataBoundItems="True"
                            CssClass="text_combo">
                        </asp:DropDownList>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label2" runat="server" Text="Họ và tên :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtFullName" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName"
                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label4" runat="server" Text="Email :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtEmail" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label12" runat="server" Text="Phone 1:" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtPhone1" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label7" runat="server" Text="Phone 2:" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtPhone2" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label8" runat="server" Text="HomePhone :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtHomePhone" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label81" runat="server" Text="Điện thoại cơ quan :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtofficePhone" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label13" runat="server" Text="Địa chỉ :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtAddress" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label14" runat="server" Text="Fax :" CssClass="Thứ tự hiển thị"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtOrder" runat="server" Width="100px" CssClass="text_textbox"></asp:TextBox>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="btn_left">
        <asp:LinkButton runat="server" ID="btn_add1" CssClass="Jm dU" Text="Lưu lại" OnClick="btn_add_Click" />
        <asp:LinkButton runat="server" ID="btn_edit1" CssClass="Jm dU" Text="Cập nhật" OnClick="btn_edit_Click" />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/listphonebook/Default.aspx"
            CssClass="Jm dU" Text="Danh mục" />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/editphonebook/Default.aspx"
            CssClass="Jm dU" Text="Thêm mới" />
    </div>
</div>
<asp:HiddenField ID="hddID" runat="server" />
