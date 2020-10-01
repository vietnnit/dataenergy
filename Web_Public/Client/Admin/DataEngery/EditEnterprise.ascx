<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditEnterprise.ascx.cs"
    Inherits="Client_Admin_EditEnterprise" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.css" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.js"></script>
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server"></asp:Literal></a>
            </li>
            <li class="crumb-icon">
                <a href="/Admin/Home/Default.aspx">
                    <span class="glyphicon glyphicon-home"></span>
                </a>
            </li>    
        </ol>
    </div>
    <div class="topbar-right">
         <div class="topbar-icon ml15 ib va-m">
            <a href="/Admin/home/Default.aspx" class="pl5" title="Trang chủ"> 
                <i class="fa fa-home fs22 text-danger"></i><br /><span class="fs11">Trang chủ</span>
            </a>
        </div>
         <div class="topbar-icon ml15 ib va-m">
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/ListEnterprise/Default.aspx" CssClass="pl5" title="Danh sách DN"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">Danh sách</span>
            </asp:HyperLink>
        </div>          
        <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_add" runat="server" OnClick='btn_add_Click' CssClass="pl5" title="Lưu lại"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Lưu lại</span>
            </asp:LinkButton>
        </div>               
       <%-- <div class="topbar-icon ml15 ib va-m">
            <a href="#" class="pl5" title="Trợ giúp"> 
                <i class="fa fa-exclamation-circle fs22 text-primary"></i><br /><span class="fs11">Trợ giúp</span>
            </a>
        </div>--%>
    </div>
</header>
<!-- Begin: Content -->
<section id="content">
<!-- Dashboard Tiles -->
<div class="row mb10">
 <div class="tab-block mb25">         
     <div class="row" runat="server" id="rowTab">
        <div class="col-lg-12">
            <ul class="nav nav-tabs tabs-border" id="Reporttabs">
                <li><a rel="tabInfo" href="#" class="">Thông tin DN</a></li>
                <li><a rel="tabImportant" href="#" class="">Năng lượng tiêu thụ</a></li>
                <li><a rel="tabAccount" href="#" class="">Thông tin Tài khoản</a></li>               
                <li><a rel="tabDataTOE" href="#" class="">Tình hình sử dụng nhiên liệu</a></li>
            </ul>
        </div>
    </div>
    <div id="tabChuyen">
        <div class="tab-content">
            <div id="tabInfo" class="tab-pane active">                                
                        <div class="form-horizontal">
                        <asp:Literal ID="error" runat="server"></asp:Literal>     
                        <div class="col-lg-8">
                         <b>THÔNG TIN DN/CƠ SỞ</b>
                         <hr class="hr-danger" />                          
                            <div class="form-group">
                                <label class="col-lg-2 control-label pt5" for="inputSmall">Tên DN/cơ sở<span class="text-danger"> *</span></label>                
                                <div class="col-lg-10">
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên cơ sở/Doanh nghiệp"  ValidationGroup="vgInfo"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" Display="Dynamic"  ValidationGroup="vgInfo"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                </div>
                            </div>                        
                            <div class="form-group">
                                <label class="col-lg-2 control-label" for="inputSmall">Lĩnh vực<span class="text-danger"> *</span></label>
                                <div class="col-lg-4">                     
                                        <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True"  AutoPostBack="true"
                                            CssClass="form-control input-sm"  ValidationGroup="vgInfo" 
                                            onselectedindexchanged="ddlArea_SelectedIndexChanged">
                                        </asp:DropDownList>                                    
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlArea" Display="Dynamic"  ValidationGroup="vgInfo"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                </div>                           
                                <label class="col-lg-2 control-label" for="inputSmall">Phân ngành<span class="text-danger"> *</span></label>
                                <div class="col-lg-4">                     
                                        <asp:DropDownList ID="ddlSubArea" runat="server" AppendDataBoundItems="True"  ValidationGroup="vgInfo" CssClass="form-control input-sm">
                                        </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6"  ValidationGroup="vgInfo" runat="server" ControlToValidate="ddlSubArea" Display="Dynamic"
                                        ErrorMessage="RequiredFieldValidator" SetFocusOnError="true"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                </div>
                            </div>   
                            <div class="form-group">
                                <label class="col-lg-2 control-label pt5" for="inputSmall">Tỉnh/TP<span class="text-danger"> *</span></label>                
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="ddlProvince"  ValidationGroup="vgInfo" runat="server" AutoPostBack="true"
                                        CssClass="form-control input-sm" 
                                        onselectedindexchanged="ddlProvince_SelectedIndexChanged" ></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vgInfo" runat="server" ControlToValidate="ddlProvince" Display="Dynamic"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                </div>                           
                                <label class="col-lg-2 control-label pt5" for="inputSmall">Quận/Huyện<span class="text-danger"> *</span></label>                
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-sm"  ValidationGroup="vgInfo"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDistrict" Display="Dynamic"  ValidationGroup="vgInfo"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-2 control-label" for="inputSmall">Mã số thuế<span class="text-danger"> *</span></label>
                                <div class="col-lg-4">                                    
                                    <asp:TextBox ID="txtMST"  ValidationGroup="vgInfo" runat="server" CssClass="form-control input-sm" placeholder="Nhập MST"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtMST" Display="Dynamic"  ValidationGroup="vgInfo"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                </div>
                                 <label class="col-lg-2 control-label" for="inputSmall" style="display:none;">Mã khách hàng dùng điện</label>
                                <div class="col-lg-4" style="display:none;">
                                    <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="form-control input-sm" placeholder="" ValidationGroup="vgInfo"></asp:TextBox>
                                    
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-2 control-label" for="inputSmall">Số điện thoại</label>
                                <div class="col-lg-4">                                    
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-sm" placeholder="Số điện thoại" ValidationGroup="vgInfo"></asp:TextBox>
                                </div>
                          
                                <label class="col-lg-2 control-label" for="inputSmall">Fax</label>
                                <div class="col-lg-4">                                    
                                    <asp:TextBox ID="txtFax" runat="server" CssClass="form-control input-sm" placeholder="Fax" ValidationGroup="vgInfo"></asp:TextBox>
                                </div>
                            </div>   
                            <div class="form-group">
                                <label class="col-lg-2 control-label" for="inputSmall">Email</label>
                                <div class="col-lg-4">                                    
                                    <asp:TextBox ID="txtEmail"  ValidationGroup="vgInfo" runat="server" CssClass="form-control input-sm" placeholder="Nhập Email"></asp:TextBox>
                                     <asp:RegularExpressionValidator ValidationGroup="vgInfo" ID="RegularExpressionValidator1"
                                runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RegularExpressionValidator>
                                </div>
                                 <label class="col-lg-2 control-label" for="inputSmall">Người chịu trách nhiệm</label>
                                <div class="col-lg-4">                                    
                                    <asp:TextBox ID="txtResponsible" runat="server" CssClass="form-control input-sm" placeholder="" ValidationGroup="vgInfo"></asp:TextBox>
                                </div>
                            </div>  
                            <div class="form-group">
                                <label class="col-lg-2 control-label" for="inputSmall">Địa chỉ<span class="text-danger"> *</span></label>
                                <div class="col-lg-10">                                    
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm" placeholder="Địa chỉ" ValidationGroup="vgInfo"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAddress" Display="Dynamic"  ValidationGroup="vgInfo"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-lg-2 control-label pt5" for="inputSmall">Chủ sở hữu<span class="text-danger"> *</span></label>                
                                <div class="col-lg-8">
                                    <asp:DropDownList ID="ddlOwner"  ValidationGroup="vgInfo" runat="server"
                                        CssClass="form-control input-sm">
                                         <asp:ListItem Text="Thành phần kinh tế khác" Value="0" Selected="True">
                                        </asp:ListItem>
                                        <asp:ListItem Text="Doanh nghiệp nhà nước"  Value="1">
                                        </asp:ListItem>                                       
                                        </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="vgInfo" runat="server" ControlToValidate="ddlOwner" Display="Dynamic"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <b>TÌNH TRẠNG CƠ SỞ</b>
                            <hr class="hr-danger" />                                       
                                 <asp:Literal ID="ltrImportantInfo" runat="server"></asp:Literal>                                
                            <div class="form-group" runat="server" id="divImportantYear" visible="false"> 
                            <label class="col-lg-2 control-label" for="inputSmall">
                                &nbsp;&nbsp;
                                </label>
                                <div class="col-lg-10">     
                                    <div class="checkbox-custom pt5">
                                        <asp:CheckBox ID="cbxIsImportant" runat="server" Text="Đang là DN sử dụng năng lượng trọng điểm" CssClass="" placeholder="" ValidationGroup="vgInfo" />
                                    </div>
                                </div>
                            </div>  
                            <div class="form-group">
                                <label class="col-lg-2 control-label" for="inputSmall">Tình trạng DN</label>
                                <div class="col-lg-4">
                                    <div class="checkbox-custom pt5">                                    
                                        <asp:CheckBox ID="cbxActive" Checked="true" runat="server" Text="Đang hoạt động" CssClass="" placeholder="" ValidationGroup="vgInfo" />
                                    </div>
                                </div>    
                                <label class="col-lg-3 control-label" for="inputSmall">Năm bắt đầu hoạt động</label>
                                <div class="col-lg-3">
                                    <asp:TextBox ID="txtAtiveYear" runat="server" CssClass="form-control input-sm" placeholder="" ValidationGroup="vgInfo"></asp:TextBox>                                    
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ValidationGroup="vgInfo" runat="server" ControlToValidate="txtAtiveYear" Display="Dynamic"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>                                    
                                </div>
                            </div> 
                            <div class="form-group">
                                <label class="col-lg-2 control-label" for="inputSmall">Ghi chú</label>
                                <div class="col-lg-10">                                    
                                    <asp:TextBox ID="txtNote" runat="server" CssClass="form-control input-sm" placeholder="" ValidationGroup="vgInfo"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12 text-left">
                                <asp:Button runat="server" ID="btn_add1" ValidationGroup="vgInfo" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />                                                        
                                <%--<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Admin/ListEnterprise/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Danh sách" />--%>
                                </div>
                            </div>   
                        </div>  
                        <div class="col-lg-4">
                                     <b>THÔNG TIN CÔNG TY MẸ</b>
                        <hr class="hr-danger" />                         
                            <div class="form-group">
                                <label class="col-lg-4 control-label" for="inputSmall">Tên Cty</label>
                                <div class="col-lg-8">                                    
                                    <asp:TextBox ID="txtParentName" runat="server" CssClass="form-control input-sm" placeholder="" ValidationGroup="vgInfo"></asp:TextBox>
                                </div>
                            </div>  
                            <div class="form-group">
                                <label class="col-lg-4 control-label" for="inputSmall">Tỉnh/TP</label>
                                <div class="col-lg-8">                     
                                        <asp:DropDownList ID="ddlProvinceReporter" runat="server" AppendDataBoundItems="True" onselectedindexchanged="ddlProvinceReporter_SelectedIndexChanged" AutoPostBack="true"
                                            CssClass="form-control input-sm" ValidationGroup="vgInfo">
                                    </asp:DropDownList>                                    
                                </div>
                             </div> 
                             <div class="form-group">
                                <label class="col-lg-4 control-label" for="inputSmall">Quận/Huyện</label>
                                <div class="col-lg-8">                     
                                    <asp:DropDownList ID="ddlDistrictReporter"  ValidationGroup="vgInfo" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm" >
                                    </asp:DropDownList>
                                </div>
                            </div>     
                            <div class="form-group">
                                <label class="col-lg-4 control-label" for="inputSmall">Địa chỉ</label>
                                <div class="col-lg-8">                                    
                                   <asp:TextBox ID="txtAddressReporter" runat="server" CssClass="form-control input-sm" placeholder="" ValidationGroup="vgInfo"></asp:TextBox>
                                </div>
                            </div>   
                            <div class="form-group">
                                <label class="col-lg-4 control-label" for="inputSmall">Số điện thoại</label>
                                <div class="col-lg-8">                                    
                                    <asp:TextBox ID="txtPhoneReporter" runat="server" CssClass="form-control input-sm" placeholder="" ValidationGroup="vgInfo"></asp:TextBox>
                                </div>
                             </div> 
                            <div class="form-group">
                                <label class="col-lg-4 control-label" for="inputSmall">Fax</label>
                                <div class="col-lg-8">                                    
                                    <asp:TextBox ID="txtFaxReporter" runat="server" CssClass="form-control input-sm" placeholder="" ValidationGroup="vgInfo"></asp:TextBox>
                                </div>
                            </div>     
                            <div class="form-group">
                                <label class="col-lg-4 control-label" for="inputSmall">Email</label>
                                <div class="col-lg-8">                                    
                                    <asp:TextBox ID="txtManEmail" runat="server" CssClass="form-control input-sm" placeholder="" ValidationGroup="vgInfo"></asp:TextBox>
                                    <asp:RegularExpressionValidator ValidationGroup="vgInfo" ID="RegularExpressionValidator3"
                                runat="server" ControlToValidate="txtManEmail" ErrorMessage="RegularExpressionValidator"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RegularExpressionValidator>
                                </div>
                            </div>                                                                                                                                                              
                          </div>
                        </div>                    
            </div>
            <div id="tabAccount" class="tab-pane">
            <p>
                <asp:Literal ID="ltTotal" runat="server"></asp:Literal></p>
                <div class="table-responsive mb20">
                    <asp:GridView ID="grvAdmin" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
                    AllowPaging="true" PageSize="1000" OnRowCommand="grvAdmin_RowCommand"
                    OnRowDataBound="grvAdmin_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                        <HeaderStyle CssClass="primary fs12" />
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemStyle CssClass="text-center" />
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" Width="5%" />
                            </asp:TemplateField>      
                            <asp:BoundField HeaderText="ID" DataField="ID">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="5%" />
                            </asp:BoundField>                                     
                            <asp:TemplateField HeaderText="Tên đăng nhập">
                                <ItemStyle CssClass="text-left" />
                                <ItemTemplate>
                                    <%# Eval("AccountName")%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>                  
                             <asp:BoundField DataField="FullName" HeaderText="Tên đầy đủ">
                                <ItemStyle CssClass="text-left" />
                                <HeaderStyle CssClass="text-center"/>
                            </asp:BoundField>                                       
                            <asp:BoundField DataField="Email" HeaderText="Email">
                                <ItemStyle CssClass="text-left" />
                                <HeaderStyle CssClass="text-center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Phone" HeaderText="Phone">
                                <ItemStyle CssClass="text-left" />
                                <HeaderStyle CssClass="text-center"/>
                            </asp:BoundField>                    
                            <asp:CheckBoxField DataField="IsActive" HeaderText="Trạng thái">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="5%" />
                            </asp:CheckBoxField>    
                            <asp:TemplateField HeaderText="Chức năng">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="12%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Id") %>' ToolTip="Sửa thông tin thành viên">
                                            <span class="glyphicons glyphicons-edit fs18" ></span>
                                            </asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="btnReset" runat="server" CommandName="_reset" CommandArgument='<%# Eval("Id") %>' ToolTip="Reset mật khẩu">
                                            <span class="fa fa-key fs18"></span>
                                            </asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="btn_delete" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa tài khoản này không?');" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa thành viên">
                                            <span class="glyphicons glyphicons-remove_2 fs18 text-danger" ></span>
                                            </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="row mb20 right">
                        <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                    LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                    </div>
                </div>
                <div class="form-group ">
                    <div class="col-lg-12 text-left">
                   <%--<asp:Button ID="btnAddMember" CssClass="btn btn-sm btn-info" runat="server" OnClientClick="addmember();return false; " Text="Tạo tài khoản"/>--%>
                   <asp:Button ID="btnAddMember" CssClass="btn btn-sm btn-info" runat="server" OnClick="btnAddMember_Click" Text="Tạo tài khoản"/>
                   <%-- <asp:HyperLink ID="HyperLink5" runat="server" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Admin/listEnterprise/Default.aspx" Text="Danh sách" />--%>
                                 </div>
                </div>
            </div>
            <div id="tabImportant" class="tab-pane">
                    <p>
                <asp:Literal ID="ltrTotalImportant" runat="server"></asp:Literal></p>     
                 <div class="table-responsive mb20">
                  <table class="table table-bordered table-hover mbn" width="100%">
                                <tr class="primary fs12">
                                    <th style="width:5%" class="text-center">STT</th>                                   
                                   <th style="width:10%" class="text-center">Năm</th>                         
                                    <th>TOE</th>          
                                   <%-- <th style="width:10%" class="text-center">Chức năng</th>   --%>
                                </tr>   
                                 <asp:Repeater ID="rptImportantYear" runat="server">
                                                    <ItemTemplate>
                                                        <tr>                                   
                                                            <td class="text-center"><%#Container.ItemIndex+1  %></td>   
                                                             <td class="text-center"><%#Eval("Year")%></td>
                                                              <td><%#Eval("No_TOE")%></td>
                                                             <%--<td class="text-center">
                                                                <asp:LinkButton ID="btn_edit_importantyear" OnClick="btn_edit_importantyear_Click" runat="server"  CommandArgument='<%# Eval("Id") %>' ToolTip="Sửa thông tin">
                                            <span class="glyphicons glyphicons-edit fs18" ></span>
                                            </asp:LinkButton>      
                                             <asp:LinkButton Visible="false" ID="btn_delete_importantyear" OnClick="btn_delete_importantyear_Click" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa thông tin này không?');" runat="server"  CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa bỏ">
                                            <span class="glyphicons glyphicons-remove_2 fs18 text-danger" ></span>
                                            </asp:LinkButton>                                                     
                                                             </td>--%>
                                  </tr>
                                  </ItemTemplate>
                                  </asp:Repeater>
                                </table>
                 </div>
                 <%-- <div class="form-group">
                                <div class="col-lg-12 text-left">
                                <input value="Thêm mới" class="btn btn-sm btn-info" onclick="AddImportantYear();return false;" type="submit" />                                
                                </div></div>--%>
            </div>
            <div id="tabDataTOE" class="tab-pane">
                <div class="form-horizontal">                                                               
                    <div class="form-group">                                    
                        <div class="col-lg-12">
                       <b>Báo cáo năm hiện tại</b>
                            <hr class="hr-danger" />                             
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <tr class="primary fs12">
                                    <th style="width:5%" class="text-center">STT</th>                                    
                                    <th style="width:10%" class="text-center">Năm</th>  
                                    <asp:Literal ID="ltHeader" runat="server"></asp:Literal>
                                    <th style="width:10%">(TOE)</th>                                                    
                                </tr>                                                                
                                <asp:Literal ID="ltData" runat="server"></asp:Literal>
                            </table>     
                            <br />
                             <b>Báo cáo các năm trước</b>
                            <hr class="hr-danger" /> 
                            <p>
                             <asp:Literal ID="ltNotice" runat="server"></asp:Literal></p>
                          <div class="row">
                                <div class="col-lg-12">
                                    <div class="dataTables_length">
                                        <label>
                                            <asp:Literal ID="ltrTotal" runat="server"></asp:Literal></label>
                                    </div>
                                </div>                                
                            </div>
                            <div class="form-horizontal">                                                               
                                <div class="form-group">                                    
                                    <div class="col-lg-12">
                                            <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                            <table class="table table-bordered table-hover mbn" width="100%">
                                                <tr class="primary fs12">
                                                    <th style="width:5%">STT</th>                                                   
                                                    <th style="width:10%">Năm</th> 
                                                    <th style="width:10%">Điện (KWh)</th>      
                                                    <th style="width:10%">Than (Tấn)</th>      
                                                    <th style="width:10%">DO (Tấn)</th>                                          
                                                    <th style="width:10%">FO (Tấn)</th>      
                                                    <th style="width:10%">Xăng (Tấn)</th>      
                                                    <th style="width:10%">Gas (Tấn)</th>      
                                                    <th style="width:10%">Khí (m3)</th>                                                     
                                                    <th style="width:10%">LPG (Tấn)</th>    
                                                    <th style="width:10%">Khác (Số đo)</th>    
                                                    <th style="width:10%">(TOE)</th>                                                 
                                                </tr>                                           
                                                <asp:Repeater ID="rptData" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="text-center"><%#Container.ItemIndex+1  %></td>                                                        
                                                            <td><%#Eval("Year")%></td>
                                                            <td><%#Eval("Dien_kWh")%></td>
                                                            <td><%#Eval("Than_Tan")%></td>
                                                            <td><%#Eval("DO_Tan")%></td>
                                                            <td><%#Eval("FO_Tan")%></td>
                                                            <td><%#Eval("Xang_Tan")%></td>
                                                            <td><%#Eval("Gas_Tan")%></td>
                                                            <td><%#Eval("Khi_m3")%></td>
                                                            <td><%#Eval("LPG_Tan")%></td>
                                                            <td><%#Eval("KhacSoDo")%></td>
                                                            <td><%#Eval("No_TOE")%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                    </div>
                                </div>                                                                                                                                                                                                                                                                                                                                                                       
                            </div>             
                        </div>
                    </div>                                                                                                                                                                                                                                                                                                                                                            
                </div>
            </div>
        </div>
     </div>  
     </div> 
</div>
</section>
<div class="modal fade" tabindex="-1" role="dialog" id="myModalImportantYear">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Cập nhật dữ liệu trọng điểm</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <p>
                        <asp:Literal ID="ltErrorImportantYear" runat="server"></asp:Literal>
                    </p>
                    <div class="form-group">
                        <asp:HiddenField ID="hdnImportantYearEdit" runat="server" Value="0" />
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Năm</label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlImportantYear" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnAddImportantYear" runat="server" Text="Lưu lại" OnClick="btnAddImportantYear_Click"
                    CssClass="btn btn-sm btn-primary mr10" AutoPostback="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Cập nhật thông tin tài khoản</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <p>
                        <asp:Literal ID="ltErrorMember" runat="server"></asp:Literal>
                    </p>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Tên tài khoản</label>
                        <div class="col-lg-9">
                            
                            <asp:TextBox ID="txtAdminName1" runat="server" CssClass="form-control input-sm" Enabled="false" placeholder="Nhập tên tài khoản">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAdminName1"
                                ValidationGroup="vgMember" ErrorMessage="RequiredFieldValidator">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" id="frmPass" runat="server" visible="true">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Mật khẩu</label>
                        <div class="col-lg-3">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"
                                ValidationGroup="vgMember" ControlToCompare="txtAdminPass1" ControlToValidate="txtAdminConfirmPass1">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAdminPass1"
                                ValidationGroup="vgMember" ErrorMessage="RequiredFieldValidator">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAdminPass1" runat="server" CssClass="form-control input-sm" placeholder="Nhập mật khẩu"
                                ValidationGroup="vgMember" TextMode="Password">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group" id="frmConfirmPass" runat="server" visible="true">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Nhập lại mật khẩu</label>
                        <div class="col-lg-3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAdminConfirmPass1"
                                ValidationGroup="vgMember" ErrorMessage="RequiredFieldValidator">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtAdminPass1"
                                ControlToValidate="txtAdminConfirmPass1" ErrorMessage="CompareValidator" ValidationGroup="vgMember">
                                <span class="append-icon right text-danger">Mật khẩu chưa khớp</span></asp:CompareValidator>
                            <asp:TextBox ID="txtAdminConfirmPass1" runat="server" CssClass="form-control input-sm"
                                placeholder="Nhập lại mật khẩu" TextMode="Password" ValidationGroup="vgMember">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Email <span class="text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:RegularExpressionValidator ValidationGroup="vgMember" ID="RegularExpressionValidator2"
                                runat="server" ControlToValidate="txtAdminEmail" ErrorMessage="RegularExpressionValidator"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="vgMember"
                                runat="server" ControlToValidate="txtAdminEmail" ErrorMessage="RequiredFieldValidator">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAdminEmail" runat="server" ValidationGroup="vgMember" CssClass="form-control input-sm">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Họ và tên người quản trị <span class="text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="vgMember"
                                ControlToValidate="txtAdminFullName" ErrorMessage="RequiredFieldValidator">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAdminFullName" runat="server" CssClass="form-control input-sm"
                                placeholder="Tên đầy đủ">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Điện thoại</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtAdminPhone" runat="server" CssClass="form-control input-sm" placeholder="">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Địa chỉ</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtAdminAddress" runat="server" CssClass="form-control input-sm"
                                placeholder="">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Trạng thái</label>
                        <div class="col-lg-9">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="cbxManActive" runat="server" Checked="true" Text="Hoạt động" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveAccount" runat="server" ValidationGroup="vgMember" Visible="true"
                    Text="Lưu lại" OnClick="btnSaveAccount_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="myPass">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Thay đổi mật khẩu đăng nhập doanh nghiệp</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-4 control-label" for="inputSmall">
                            Tên tài khoản</label>
                        <div class="col-lg-8">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAdminName"
                                ValidationGroup="vgPass" ErrorMessage="RequiredFieldValidator">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAdminName" Enabled="false" runat="server" CssClass="form-control input-sm"
                                placeholder="Nhập tên tài khoản">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-4 control-label" for="inputSmall">
                            Mật khẩu mới</label>
                        <div class="col-lg-8">
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="CompareValidator"
                                ValidationGroup="vgPass" ControlToCompare="txtAdminPass" ControlToValidate="txtAdminConfirmPass">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAdminPass"
                                ValidationGroup="vgPass" ErrorMessage="RequiredFieldValidator">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAdminPass" runat="server" CssClass="form-control input-sm" placeholder="Nhập mật khẩu" TextMode="Password"
                                ValidationGroup="vgPass">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-4 control-label" for="inputSmall">
                            Nhập lại mật khẩu mới</label>
                        <div class="col-lg-8">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAdminConfirmPass"
                                ValidationGroup="vgPass" ErrorMessage="RequiredFieldValidator">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtAdminPass"
                                ControlToValidate="txtAdminConfirmPass" ErrorMessage="CompareValidator" ValidationGroup="vgPass">
                                <span class="append-icon right text-danger">Mật khẩu chưa khớp</span></asp:CompareValidator>
                            <asp:TextBox ID="txtAdminConfirmPass" runat="server" CssClass="form-control input-sm"
                                placeholder="Nhập lại mật khẩu" ValidationGroup="vgPass" TextMode="Password">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSavePass" runat="server" ValidationGroup="vgPass" Visible="true"
                    Text="Lưu thay đổi" OnClick="btnSavePass_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<asp:HiddenField ID="hdnMemberId" runat="server" Value="0" />
<script type="text/javascript">   
    var tabReport = new ddtabcontent("Reporttabs");
    tabReport.setpersist(true);
    tabReport.setselectedClassTarget("link");
    tabReport.currentTabIndex=<%=activeTab %>;
    tabReport.init();

    function updatemember() {
        $(document).ready(function () {
            $('#myModal').modal('toggle');                        
        });

    }
    function updatePass() {
        $(document).ready(function () {
            $('#myPass').modal('toggle');                        
        });

    }
    function AddImportantYear() {
        $(document).ready(function () {
         $("#<%=hdnImportantYearEdit.ClientID%>").val('0');
            $('#myModalImportantYear').modal('toggle');                     
        });

    }
    function UpdateImportantYear() {
        $(document).ready(function () {
            $('#myModalImportantYear').modal('toggle');                        
        });

    }
    function addmember() {
        $(document).ready(function () {
            $('#myModal').modal('toggle');       
                $("#<%=hdnMemberId.ClientID%>").val('');
                $("#<%=txtAdminName1.ClientID%>").val('');
                $("#<%=txtAdminConfirmPass1.ClientID%>").val('');
                $("#<%=txtAdminPass1.ClientID%>").val('');       
                $("#<%=frmConfirmPass.ClientID%>").show();
                $("#<%=frmPass.ClientID%>").show();
                $("#<%=txtAdminEmail.ClientID%>").val('');
                $("#<%=txtAdminFullName.ClientID%>").val('');     
                $("#<%=txtAdminPhone.ClientID%>").val('');  
                $("#<%=txtAdminAddress.ClientID%>").val('');  
        });
    }
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
