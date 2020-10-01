<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListDEArea.ascx.cs" Inherits="Client_Admin_ListDEArea" %>
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
             <a onclick="javascript:addfield();return false;">
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới lĩnh vực</span>
            </a>
        </div>   
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnOrder" ValidationGroup="vgSort" runat="server" OnClick='btn_Order_Click' CssClass="pl5" title="Sắp xếp"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Sắp xếp</span>
            </asp:LinkButton>
        </div>   
        <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnImport" runat="server" OnClick='btnImport_Click' CssClass="pl5" title="Sắp xếp"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Import SL</span>
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
    <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">                                                                     
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Lĩnh vực</label>
                    <div class="col-lg-4">                     
                            <asp:DropDownList ID="ddlParent" runat="server" AppendDataBoundItems="True" 
                                CssClass="form-control input-sm"  ValidationGroup="vgInfo">
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
            <asp:GridView ID="grvArea" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover mbn"
            AllowPaging="false" OnRowCommand="grvArea_RowCommand" EmptyDataText="Không tìm thấy lĩnh vực nào">
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOrder"
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="vgSort" ><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtOrder"
                                MaximumValue="1000" MinimumValue="0" ValidationGroup="vgSort" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                           <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("SortOrder")%>'></asp:TextBox>
                       </div>
                        </ItemTemplate>
                    </asp:TemplateField>                                       
                    <asp:TemplateField HeaderText="Tên lĩnh vực/Phân ngành">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%# Eval("AreaName")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>    
                     <asp:TemplateField HeaderText="Lĩnh vực cha">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%# Eval("ParentName")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" Width="20%" />
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="10%" />
                        <ItemTemplate>
                             <asp:LinkButton CommandName="_edit" ID="btn_edit" runat="server"
                                                CommandArgument='<%# Eval("Id") %>' ToolTip="Sửa thông tin">
                                            <span class="glyphicons glyphicons-edit fs18" ></span></asp:LinkButton>    
                           &nbsp;&nbsp;                                                           
                                    <asp:LinkButton ID="btn_delete" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa lĩnh vực này không?');" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa lĩnh vực">
                                    <span class="glyphicons glyphicons-remove_2 fs18 text-danger" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_edit2" ValidationGroup="vgSort" CssClass="btn btn-sm btn-primary mr10" Text="Sắp xếp" OnClick="btn_Order_Click" />
                 <input value="Thêm mới lĩnh vực" class="btn btn-sm btn-system mr10" onclick="addfield();return false;"
                            type="submit" />                  
                </div>
            </div>
        </div>
    </div>   

</div>
</section>
<script type="text/javascript">
    function addfield() {
        $(document).ready(function () {
            $("#<%=hdnEditId.ClientID%>").val('0');
            $("#<%=txtTitle.ClientID%>").val('');
            $('#popupfield').modal('toggle');
        });
    }
    function updatefield() {
        $(document).ready(function () {
            $('#popupfield').modal('toggle');
        });
    }
</script>
<div class="modal fade" tabindex="-1" role="dialog" id="popupfield">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Cập nhật lĩnh vực</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <asp:HiddenField ID="hdnEditId" Value="0" runat="server" />
                    <asp:Literal ID="error" runat="server"></asp:Literal>
                    <div class="form-group">
                        <label class="col-lg-3 control-label pt5" for="inputSmall">
                            Tên lĩnh vực<span class="text-danger"> *</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control input-sm" placeholder="Tên lĩnh vực"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="vgFuel" ID="RequiredFieldValidator5"
                                runat="server" ControlToValidate="txtTitle" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Lĩnh vực cha</label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlFieldParent" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Thứ tự hiển thị
                        </label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtSorOrder" runat="server" CssClass="form-control input-sm" placeholder="Vị trí"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" ValidationGroup="vgFuel" runat="server"
                                ControlToValidate="txtSorOrder" ErrorMessage="*" Type="Integer" MinimumValue="0"
                                MaximumValue="9999"><span class="append-icon right text-danger"></span></asp:RangeValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" ValidationGroup="vgFuel" Visible="true" Text="Lưu lại"
                    OnClick="btnSave_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false">
                </asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
