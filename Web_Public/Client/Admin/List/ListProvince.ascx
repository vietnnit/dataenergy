<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListProvince.ascx.cs"
    Inherits="Client_Admin_List_ListProvince" %>
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
            <a onclick="javascript:addprovince();return false;">
        <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới</span>
        </a>  
        </div>   
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnOrder" runat="server" ValidationGroup="vgsort" OnClick='btn_Order_Click' CssClass="pl5" title="Sắp xếp"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Sắp xếp</span>
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
                <div class="form-group col-lg-12">      
                <label class="col-lg-1 control-label" for="inputSmall">Tỉnh/TP</label>
                    <div class="col-lg-2">                     
                            <asp:DropDownList ID="ddlRegionSearch" runat="server" AppendDataBoundItems="True" 
                                CssClass="form-control input-sm" >
                            </asp:DropDownList>                                                                        
                    </div>             
                    <label class="col-lg-1 control-label pt5" for="inputSmall">Từ khóa</label>
                    <div class="col-lg-2">
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Nhập từ khóa"></asp:TextBox>
                    </div>
                     <div class="col-lg-6">     
                    <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm" OnClick="btn_search_Click" /></div>
                </div>                   
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body"><p>
            <asp:Literal ID="clientview" runat="server"></asp:Literal></p>
            <div class="table-responsive mb20">
            <asp:GridView ID="grvProvince" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="false" OnRowCommand="grvProvince_RowCommand" EmptyDataText="Không tìm thấy tỉnh/thành phố nào">
                <HeaderStyle CssClass="primary fs12" />
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="5%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Sắp xếp">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="6%" />
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
                    <asp:TemplateField HeaderText="Mã Tỉnh/TP">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%# Eval("ProvinceCode")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>                                        
                    <asp:TemplateField HeaderText="Tỉnh/TP">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%# Eval("ProvinceName")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>    
                     <asp:TemplateField HeaderText="Vùng">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%# Eval("RegionName")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="8%" />
                        <ItemTemplate>
                            <asp:LinkButton  CommandName="_edit" ID="btn_edit" runat="server"
                                                CommandArgument='<%# Eval("Id") %>' ToolTip="Sửa thông tin">
                                            <span class="glyphicons glyphicons-edit fs18" ></span></asp:LinkButton>    
                           &nbsp;&nbsp;                                                           
                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa tỉnh thành">
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
               <input value="Thêm mới" class="btn btn-sm btn-system mr10" onclick="addprovince();return false;"
                            type="submit" /> 
                </div>
            </div>
        </div>
    </div>  

</div>
</section>
<asp:HiddenField ID="hdnEditId" Value="0" runat="server" />
<div class="modal fade" tabindex="-1" role="dialog" id="popupprovince">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h4 class="modal-title">
                    Cập nhật tỉnh thành phố</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <asp:Literal ID="error" runat="server"></asp:Literal>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Tên Tỉnh/TP</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên Tỉnh/Tp"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                Display="Dynamic" ValidationGroup="vgprovince" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Mã Tỉnh/TP</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtProvinceCode" runat="server" CssClass="form-control input-sm"
                                placeholder="Nhập mã Tỉnh/TP"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Vùng/miền</label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlRegion"
                                Display="Dynamic" ValidationGroup="vgprovince" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Thứ tự hiển thị</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtSorOrder" runat="server" CssClass="form-control input-sm" placeholder="Số thứ tự"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" ValidationGroup="vgprovince" runat="server"
                                ControlToValidate="txtSorOrder" ErrorMessage="*" Type="Integer" MinimumValue="0"
                                MaximumValue="9999"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i> (0-9999)</span></asp:RangeValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Text="Lưu lại" ValidationGroup="vgprovince"
                    OnClick="btnSave_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false">
                </asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    function addprovince() {
        $(document).ready(function () {
            $("#<%=hdnEditId.ClientID%>").val('0');
            $('#popupprovince').modal('toggle');
            $("#<%=txtTitle.ClientID%>").val('');
            $("#<%=txtProvinceCode.ClientID%>").val('');
        });
    }
    function updateprovince() {
        $(document).ready(function () {
            $('#popupprovince').modal('toggle');
        });
    }         
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
