<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListDEOrganization.ascx.cs"
    Inherits="Client_Admin_ListDEOrganization" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
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
              <a onclick="javascript:addorg();return false;">
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới</span>
            </a>
        </div>   
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnOrder" runat="server" ValidationGroup="vgsort" OnClick='btn_Order_Click' CssClass="pl5" title="Sắp xếp"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Sắp xếp</span>
            </asp:LinkButton>
        </div>    
       <%-- <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnCreateUser" runat="server" OnClick='btnCreateUser_Click' CssClass="pl5" title="Sắp xếp"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Tạo tài khoản</span>
            </asp:LinkButton>
        </div>      --%> 
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
<div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">                                                                     
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tỉnh</label>
                    <div class="col-lg-4">                     
                            <asp:DropDownList ID="ddlProvinceSearch" runat="server" AppendDataBoundItems="True" 
                                CssClass="form-control input-sm">
                            </asp:DropDownList>                                                                        
                    </div>
                    <label class="col-lg-1 control-label pt5" for="inputSmall">Từ khóa</label>
                    <div class="col-lg-2">
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Nhập từ khóa"></asp:TextBox>
                    </div>
                     <div class="col-lg-3">
                      <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm" OnClick="btn_search_Click" />
                     </div>
                </div>                                               
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body">
            <asp:Literal ID="clientview" runat="server"></asp:Literal>
            <div class="row">
                <div class="col-lg-6">
                    <div class="dataTables_length">
                        <label>
                            <asp:Literal ID="ltrTotal" runat="server"></asp:Literal></label>
                    </div>
                </div>
                <div class="col-lg-6" style="text-align: right">
                    <div class="dataTables_paginate paging_simple_numbers">
                        <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                    </div>
                </div>
            </div>
            <div class="table-responsive mb20">
            <asp:GridView ID="grvOrg" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="false" OnRowCommand="grvOrg_RowCommand"  EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="6%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Sắp xếp">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="8%" />
                        <ItemTemplate>
                            <div style="position:relative;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="vgsort" runat="server" ControlToValidate="txtOrder"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" ValidationGroup="vgsort" runat="server" ControlToValidate="txtOrder"
                                MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                           <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("SortOrder")%>'></asp:TextBox>
                       </div>
                        </ItemTemplate>
                    </asp:TemplateField>                                       
                    <asp:TemplateField HeaderText="Sở Công thương/Tập đoàn">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Id") %>'><%# Eval("Title")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Điện thoại">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%#Eval("Phone") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                               
                    <asp:TemplateField HeaderText="Email">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%#Eval("Email") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Địa chỉ">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%#Eval("Address") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="8%" />
                        <ItemTemplate>
                            <asp:LinkButton CommandName="_edit" ID="btn_edit" runat="server"
                                                CommandArgument='<%# Eval("Id") %>' ToolTip="Sửa thông tin">
                                            <span class="glyphicons glyphicons-edit fs18" ></span></asp:LinkButton>    
                           &nbsp;&nbsp;                                                           
                                    <asp:LinkButton ID="btn_delete" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa không?');" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa bỏ">
                                    <span class="glyphicons glyphicons-remove_2 fs18 text-danger" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>        
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_edit2" ValidationGroup="vgsort" CssClass="btn btn-sm btn-primary mr10" Text="Sắp xếp" OnClick="btn_Order_Click" />
                 <input value="Thêm mới" class="btn btn-sm btn-system mr10" onclick="addorg();return false;"
                            type="submit" />  
               <%-- <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/EditDEOrganization/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" />--%>
                <%--<asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />--%>
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>
<script type="text/javascript">
    function addorg() {
        $(document).ready(function () {
            $("#<%=hdnEditId.ClientID%>").val('0');
            $("#<%=txtTitle.ClientID%>").val('');
            $('#popuporg').modal('toggle');
        });
    }
    function updateorg() {
        $(document).ready(function () {
            $('#popuporg').modal('toggle');
        });
    }
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
<div class="modal fade" tabindex="-1" role="dialog" id="popuporg">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Cập nhật sở công thương/ Tập đoàn</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <asp:HiddenField ID="hdnEditId" Value="0" runat="server" />
                    <asp:Literal ID="error" runat="server"></asp:Literal>
                    <div class="form-group">
                        <div class="form-group">
                            <label class="col-lg-2 control-label pt5" for="inputSmall">
                                Tên sở/Tập đoàn</label>
                            <div class="col-lg-6">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control input-sm" placeholder="Tên sở/Tập đoàn"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                    Display="Dynamic" ValidationGroup="vgorg" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2 control-label pt5" for="inputSmall">
                                Tỉnh/TP</label>
                            <div class="col-lg-6">
                                <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ValidationGroup="vgorg" ID="RequiredFieldValidator2"
                                    runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2 control-label" for="inputSmall">
                                Số điện thoại</label>
                            <div class="col-lg-4">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-sm" placeholder="Số điện thoại"
                                    ValidationGroup="view"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2 control-label" for="inputSmall">
                                Email</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm" placeholder="Nhập Email"
                                    ValidationGroup="view"></asp:TextBox>
                                <asp:RegularExpressionValidator ValidationGroup="vgorg" ID="RegularExpressionValidator3"
                                    runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2 control-label" for="inputSmall">
                                Địa chỉ</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm" placeholder="Địa chỉ"
                                    ValidationGroup="view"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2 control-label" for="inputSmall">
                                Ghi chú</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="txtNote" runat="server" CssClass="form-control input-sm" placeholder="Ghi chú"
                                    ValidationGroup="view"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2 control-label pt5" for="inputSmall">
                                Thứ tự hiển thị</label>
                            <div class="col-lg-3">
                                <asp:RequiredFieldValidator ValidationGroup="vgorg" ID="RequiredFieldValidator5"
                                    runat="server" ControlToValidate="txtSorOrder" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator1" ValidationGroup="vgorg" runat="server" ControlToValidate="txtSorOrder"
                                    ErrorMessage="*" Type="Integer" MinimumValue="0" MaximumValue="9999"><span class="append-icon right text-danger">(0-9999)</span></asp:RangeValidator>
                                <asp:TextBox ID="txtSorOrder" runat="server" CssClass="form-control input-sm" placeholder="Vị trí"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" ValidationGroup="vgorg" Visible="true" Text="Lưu lại"
                    OnClick="btnSave_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false">
                </asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
