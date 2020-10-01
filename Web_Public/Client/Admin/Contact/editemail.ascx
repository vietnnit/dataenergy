<%@ Control Language="C#" AutoEventWireup="true" CodeFile="editemail.ascx.cs" Inherits="Admin_Controls_editemail" %>
<div class="headerText">
	<asp:Image ID="imgIcon" runat="server" CssClass="icon_image"/>
    <span class="subNavLink"><asp:Literal ID="litModules" runat="server"></asp:Literal></span>
</div>
<div class="container_ListProduct">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    
                     <td align="right" >
                            <div class="toolbar" id="toolbar">
	                            <table class="toolbar"><tbody><tr>
		                            <td  id="toolbar-unarchive">
			                            <asp:HyperLink ID="btn_home" runat="server" NavigateUrl="~/Admin/home/Default.aspx" CssClass="toolbar">
			                                <span class="icon-32-home" title="Trở về trang chủ">
			                                </span>
			                                Trang chủ
			                            </asp:HyperLink>
		                            </td>
                                    
                                   
                                    
                                     <td  id="Td2" style="text-align:center">
                                      <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/listemail/Default.aspx">
			                                <span class="icon-32-menus" title="Danh mục">
			                                </span>
			                                Danh mục
                                        </asp:HyperLink>
                			            
		                            </td>
            		                
            		                <td  id="Td1" style="text-align:center">
                                      <asp:HyperLink ID="HyperLink1" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editemail/Default.aspx">
			                                <span class="icon-32-publish" title="Đăng tin mới">
			                                </span>
			                                Tạo mới
                                        </asp:HyperLink>
                			            
		                            </td>
		                            
		                             <td id="Td4" style="text-align: center">
                                        <asp:HyperLink ID="btn_add" runat="server" CssClass="toolbar">
                                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-save.png"
                                                OnClick="btn_add_Click" />
                                            <br />
                                            Lưu lại
                                        </asp:HyperLink>
                                    </td>
                                    
		                            <td id="Td3" style="text-align: center">
                                        <asp:HyperLink ID="btn_edit" runat="server" CssClass="toolbar">
                                            <asp:ImageButton ID="ImageButton3" runat="server" CssClass="toolbar" ImageUrl="~/images/Admin_Theme/Icons/icon-32-apply.png"  
                                                OnClick="btn_edit_Click" />
                                            <br />
                                            Cập nhật
                                        </asp:HyperLink>
                                    </td>
                                    
                                    <td  id="Td6">
			                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/home/Default.aspx" CssClass="toolbar">
			                                <span class="icon-32-help" title="Trợ giúp">
			                                </span>
			                                Trợ giúp
			                            </asp:HyperLink>
		                            </td>
                                    
                                
                                  </tr>
                              </tbody>
                        </table>
                    </div>
        </td>
        </tr> </table>
<table width="100%" border="0" cellpadding="5" cellspacing="0">
    <tr>
        <td align="center" colspan="2">
            <asp:Literal ID="clientview" runat="server"></asp:Literal></td>
    </tr>
    <tr>
       
        <td width="140" class="txt-from-taomoi" style="height: 24px">
            <asp:Label ID="Label1" runat="server" Text="Tên khách hàng"></asp:Label></td>
        <td  style="height: 24px">
            <asp:TextBox ID="txtName" runat="server" Width="272px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        
        <td class="txt-from-taomoi">
            <asp:Label ID="Label2" runat="server" Text="Địa chỉ Email"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtEmailAddress" runat="server" Width="272px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmailAddress"
                ErrorMessage="Địa chỉ Email không chính xác" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmailAddress"
                ErrorMessage="Địa chỉ Email không chính xác" Font-Bold="False" Font-Size="10px" Font-Names="Arial">*</asp:RequiredFieldValidator>
    </tr>
</table>
</div>
<asp:HiddenField ID="hddEmailID" runat="server" />
