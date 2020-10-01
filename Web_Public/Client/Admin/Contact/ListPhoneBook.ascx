<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListPhoneBook.ascx.cs"
    Inherits="Client_Admin_ListPhoneBook" %>
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
                <li id="toolbar-new" class="button">
                    <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editphonebook/Default.aspx"
                        CssClass="toolbar"> <span class="icon-32-new"> </span>Tạo mới
                    </asp:HyperLink>
                </li>
                <li id="toolbar-checkin" class="button">
                    <asp:LinkButton ID="btn_add" runat="server" OnClick='btn_Order_Click' CssClass="toolbar">
                <span class="icon-32-apply"> </span>Cập nhập</asp:LinkButton>
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
    <div class="lineBE" style="text-align: center;">
        <asp:Literal ID="clientview" runat="server"></asp:Literal>
    </div>
    <asp:GridView ID="grvPhoneBook" runat="server" AutoGenerateColumns="False" Width="100%"
        AllowPaging="True" PageSize="30" OnPageIndexChanging="grvContact_PageIndexChanging"
        OnRowCommand="grvContact_RowCommand" OnRowDataBound="grvContact_RowDataBound"
        CellPadding="4" ForeColor="#000000" GridLines="Vertical" EmptyDataText="Không tìm thấy bản ghi nào">
        <PagerStyle BackColor="#cccccc" ForeColor="#000000" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#cccccc" Font-Bold="True" ForeColor="#000000" />
        <HeaderStyle BackColor="#cccccc" Font-Bold="True" ForeColor="#000000" />
        <EditRowStyle BackColor="#cccccc" />
        <AlternatingRowStyle CssClass="DarkLine" BackColor="#eeeeee" />
        <FooterStyle BackColor="#dddddd" Font-Bold="True" ForeColor="#000000" />
        <RowStyle BackColor="#ffffff" />
        <EmptyDataRowStyle BackColor="#f5f5f5" Font-Bold="True" ForeColor="#000000" Height="40px" />
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="30px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Sắp xếp">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="70px" />
                <ItemTemplate>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOrder"
                        Width="10px">*</asp:RequiredFieldValidator>&nbsp;
                    <asp:TextBox ID="txtOrder" runat="server" Width="20px" Text='<%# Eval("Orders")%>'
                        MaxLength="2"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtOrder"
                        MaximumValue="1000" MinimumValue="0" Type="Integer" Width="10px">*</asp:RangeValidator>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Họ tên">
                <ItemStyle CssClass="TextLeft" />
                <HeaderStyle CssClass="gridviewHeader" />
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ID") %>'><%# Eval("FullName")%></asp:LinkButton>
                </ItemTemplate>
                
            </asp:TemplateField>
             <asp:BoundField DataField="Email" HeaderText="Email">
                <ItemStyle CssClass="TextLeft" />
                <HeaderStyle CssClass="gridviewHeader" Width="180px" />
            </asp:BoundField>
             <asp:BoundField DataField="Address" HeaderText="Địa chỉ">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="250px" />
            </asp:BoundField>
            <asp:BoundField DataField="Phone1" HeaderText="Điện thoại1">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="120px" />
            </asp:BoundField>
           <asp:BoundField DataField="Phone2" HeaderText="Điện thoại2">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="120px" />
            </asp:BoundField>
           <asp:BoundField DataField="Homephone" HeaderText="Homephone">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="120px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Chức năng">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="90px" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="_mail" CommandArgument='<%# Eval("ID") %>'
                        ImageUrl="~/images/Admin_Theme/images/mail.png" ToolTip="Gửi mail" />&nbsp;
                    <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ID") %>'
                        ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa danh bạ" />&nbsp;
                    <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("ID") %>'
                        ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="btn_left">
        <asp:LinkButton runat="server" ID="btn_add1" CssClass="Jm dU" Text="Cập nhật" OnClick="btn_Order_Click" />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/editcontact/Default.aspx"
            CssClass="Jm dU" Text="Thêm mới" />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
            CssClass="Jm dU" Text="Trang chủ" />
    </div>
</div>
