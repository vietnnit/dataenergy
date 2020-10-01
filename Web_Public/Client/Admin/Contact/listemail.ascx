<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listemail.ascx.cs" Inherits="Admin_Controls_listemail" %>

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
                          <asp:HyperLink ID="btn_editpage" runat="server" CssClass="toolbar" NavigateUrl="~/Admin/editemail/Default.aspx">
			                    <span class="icon-32-publish" title="Tạo mới">
			                    </span>
			                    Tạo mới
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
      </tr>
    </table>

		<table width="100%" border="0" cellspacing="0" cellpadding="5">
         
          <tr>
            <td>
    
            <asp:GridView ID="grvEmail" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grvEmail_RowCommand" OnRowDataBound="grvEmail_RowDataBound" CssClass="gridviewBorder">
                <Columns>
                    <asp:BoundField DataField="EmailID" HeaderText="ID" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight" HeaderStyle-Width="31" HeaderStyle-Height="22" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight"  />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Tên khách hàng" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"  HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="250px">
                       <ItemStyle HorizontalAlign="left" CssClass="gridviewCellBottom gridviewCellRight"  />
                    </asp:BoundField>
                    <asp:BoundField DataField="EmailAddress" HeaderText="Email của khách hàng" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"  HeaderStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="left" CssClass="gridviewCellBottom gridviewCellRight"  />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="Chức năng" HeaderStyle-CssClass="gridviewCellBottom gridviewCellRight"  HeaderStyle-Width="80" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" CssClass="gridviewCellBottom gridviewCellRight" />
                        <ItemTemplate>
                            <asp:ImageButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("EmailID") %>' ImageUrl="~/images/Admin_Theme/images/btn_edit.png" />&nbsp;
                            <asp:ImageButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("EmailID") %>' ImageUrl="~/images/Admin_Theme/images/btn_delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
    
        </td>
          </tr>
        </table>
</div>
