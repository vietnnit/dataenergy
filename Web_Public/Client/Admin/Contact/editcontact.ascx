<%@ Control Language="C#" AutoEventWireup="true" CodeFile="editcontact.ascx.cs" Inherits="Admin_Controls_editcontact" %>
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
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/listcontact/Default.aspx"
                        CssClass="toolbar">
                        <span class="icon-32-stats"> </span>Danh mục
                    </asp:HyperLink>
                </li>
                <li id="toolbar-new" class="button">
                    <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editcontact/Default.aspx"
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
                        <asp:Literal ID="error" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label2" runat="server" Text="Tên khách hàng :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtName" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
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
                        <asp:Label ID="Label12" runat="server" Text="Điện thoại :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtTel" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
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
                        <asp:Label ID="Label14" runat="server" Text="Fax :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtFax" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label15" runat="server" Text="Tỉnh/Thành phố :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtCity" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label1" runat="server" Text="Ngày liên hệ:" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox" colspan="3">
                        Ngày
                        <asp:DropDownList ID="cboDay1" runat="server">
                        </asp:DropDownList>
                        Tháng
                        <asp:DropDownList ID="cboMonth1" runat="server">
                        </asp:DropDownList>
                        Năm
                        <asp:DropDownList ID="cboYear1" runat="server">
                        </asp:DropDownList>
                        Giờ
                        <asp:DropDownList ID="cboHour1" runat="server">
                        </asp:DropDownList>
                        Phút
                        <asp:DropDownList ID="cboMinutes1" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label3" runat="server" Text="Công ty :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox">
                        <asp:TextBox ID="txtCompany" runat="server" Width="96%" CssClass="text_textbox"></asp:TextBox>
                    </td>
                    <td class="table_line_col3_lable">
                    </td>
                    <td class="table_line_col4_textbox">
                    </td>
                </tr>
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label5" runat="server" Text="Nội dung yêu cầu :" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox" colspan="3">
                        <asp:TextBox ID="txtRequire" runat="server" Width="96%" Height="150px" TextMode="MultiLine"
                            CssClass="text_textbox"></asp:TextBox>
                    </td>
                    
                </tr>
            </tbody>
        </table>
    </div>
    
    
    <div class="btn_left">
        <asp:LinkButton runat="server" ID="btn_add1" CssClass="Jm dU" Text="Lưu lại" OnClick="btn_add_Click" />
        <asp:LinkButton runat="server" ID="btn_edit1" CssClass="Jm dU" Text="Lưu lại" OnClick="btn_edit_Click" />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/listcontact/Default.aspx"
            CssClass="Jm dU" Text="Danh mục" />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/editcontact/Default.aspx"
            CssClass="Jm dU" Text="Thêm mới" />
    </div>
</div>
<asp:HiddenField ID="hddContactID" runat="server" />
