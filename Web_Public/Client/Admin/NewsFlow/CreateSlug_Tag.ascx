<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateSlug_Tag.ascx.cs"
    Inherits="Client_Admin_CreateSlug_Tag" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<div class="headerText">
    <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
    <span class="subNavLink">
        <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right">
                <div class="toolbar" id="toolbar">
                    <table class="toolbar">
                        <tbody>
                            <tr>
                                <td id="toolbar-unarchive">
                                    <asp:HyperLink ID="btn_home" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
                                        CssClass="toolbar">
			                    <span class="icon-32-home" title="Trở về trang chủ">
			                    </span>
			                    Trang chủ
                                    </asp:HyperLink>
                                </td>
                               
                                <td id="Td1" style="text-align: center">
                                    <asp:HyperLink ID="btn_listComment" runat="server" CssClass="toolbar" ToolTip="Danh mục Comment">
                                        <asp:ImageButton ID="btn_listComment1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-archive.png"
                                            OnClick="btn_slug_click" />
                                        <br />
                                        Tạo Slug & Tags
                                    </asp:HyperLink>
                                </td>
                                 <td id="Td2" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" ToolTip="Danh mục Comment">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-archive.png"
                                            OnClick="btn_img_click" />
                                        <br />
                                        Sửa Images URL
                                    </asp:HyperLink>
                                </td>
                                 <td id="Td3" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="toolbar" ToolTip="Danh mục Comment">
                                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-archive.png"
                                            OnClick="btn_img1_click" />
                                        <br />
                                        Sửa Images1 URL
                                    </asp:HyperLink>
                                </td>
                                <td id="Td5" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink4" runat="server" CssClass="toolbar" ToolTip="Danh mục Comment">
                                        <asp:ImageButton ID="ImageButton4" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-archive.png"
                                            OnClick="btn_img2_click" />
                                        <br />
                                        ảnh đại diện
                                    </asp:HyperLink>
                                </td>
                                 <td id="Td4" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="toolbar" ToolTip="Danh mục Comment">
                                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-archive.png"
                                            OnClick="btn_html_click" />
                                        <br />
                                       stripHTML
                                    </asp:HyperLink>
                                </td>
                                 <td id="Td6" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink5" runat="server" CssClass="toolbar" ToolTip="Danh mục Comment">
                                        <asp:ImageButton ID="ImageButton5" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-archive.png"
                                            OnClick="btn_down_click" />
                                        <br />
                                       downfile JPGs
                                    </asp:HyperLink>
                                </td>
                                 <td id="Td7" style="text-align: center">
                                    <asp:HyperLink ID="HyperLink6" runat="server" CssClass="toolbar" ToolTip="Danh mục Comment">
                                        <asp:ImageButton ID="ImageButton6" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-archive.png"
                                            OnClick="btn_down_thumb_click" />
                                        <br />
                                       downfile thumb
                                    </asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table cellpadding="5" cellspacing="0" border="0" width="100%">

        <tr>
            <td align="center">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grvNewsGroup" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="false" 
                    CssClass="gridviewBorder" PageSize="15"
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="NewsGroupID" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" Height="22px" HorizontalAlign="Center"
                                Width="31px" />
                        </asp:BoundField>
                      
                        <asp:BoundField DataField="Title" HeaderText="Ti&#234;u đề tin">
                            <ItemStyle HorizontalAlign="Justify" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Slug" HeaderText="Slug">
                            <ItemStyle HorizontalAlign="Justify" CssClass="gridviewCellBottom gridviewCellRight" />
                            <HeaderStyle CssClass="gridviewCellBottom gridviewCellRight" HorizontalAlign="Center" Width="400px" />
                        </asp:BoundField>
                        
                       
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <div>
                    <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                        LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                </div>
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
