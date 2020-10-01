<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listcontact.ascx.cs" Inherits="Admin_Controls_listcontact" %>

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
                    <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editcontact/Default.aspx"
                        CssClass="toolbar"> <span class="icon-32-new"> </span>Tạo mới
                    </asp:HyperLink>
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
    <div class="lineBE" style="text-align:center;">
        <asp:Literal ID="error" runat="server"></asp:Literal>
    </div>
    <asp:GridView ID="grvContact" runat="server" AutoGenerateColumns="False" Width="100%"
        AllowPaging="True" OnRowCommand="grvContact_RowCommand"
        OnRowDataBound="grvContact_RowDataBound" CellPadding="4" ForeColor="#000000"
        GridLines="Vertical" EmptyDataText="Không tìm thấy bản ghi nào">
        <PagerStyle BackColor="#cccccc" ForeColor="#000000" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#cccccc" Font-Bold="True" ForeColor="#000000" />
        <HeaderStyle BackColor="#cccccc" Font-Bold="True" ForeColor="#000000" />
        <EditRowStyle BackColor="#cccccc" />
        <AlternatingRowStyle CssClass="DarkLine" BackColor="#eeeeee" />
        <FooterStyle BackColor="#dddddd" Font-Bold="True" ForeColor="#000000" />
        <RowStyle BackColor="#ffffff" />
        <EmptyDataRowStyle BackColor="#f5f5f5" Font-Bold="True" ForeColor="#000000" Height="40px" />
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ContactID">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="30px" />
            </asp:BoundField>
           
            <asp:TemplateField HeaderText="Họ tên khách hàng">
                <ItemStyle CssClass="TextLeft" />
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ContactID") %>'><%# Eval("Name")%></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle CssClass="gridviewHeader" />
            </asp:TemplateField>
            <asp:BoundField DataField="Tel" HeaderText="Điện thoại">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="120px" />
            </asp:BoundField>
           
            
            <asp:BoundField DataField="Email" HeaderText="Email">
                <ItemStyle CssClass="TextLeft" />
                <HeaderStyle CssClass="gridviewHeader" Width="250px" />
            </asp:BoundField>
            
            <asp:BoundField DataField="Date" HeaderText="Ngày gửi">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="150px" />
            </asp:BoundField>
           
            
            <asp:TemplateField HeaderText="Chức năng">
                <ItemStyle CssClass="TextCenter" />
                <HeaderStyle CssClass="gridviewHeader" Width="90px" />
                <ItemTemplate>
                    <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ContactID") %>'
                        ImageUrl="~/images/Admin_Theme/images/btn_edit.png" ToolTip="Sửa nhóm danh mục" />&nbsp;
                    <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("ContactID") %>'
                        ImageUrl="~/images/Admin_Theme/images/btn_delete.png" ToolTip="Xóa ???" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="btn_left">
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/editcontact/Default.aspx"
            CssClass="Jm dU" Text="Thêm mới" />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
            CssClass="Jm dU" Text="Trang chủ" />
    </div>
</div>
