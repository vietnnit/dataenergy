<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListReportWaitting.ascx.cs"
    Inherits="Client_Admin_DataEnergy_ListReportWaitting" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:HiddenField ID="hdnValueId" Value="" runat="server" />
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server" Text="Báo cáo mức của Cơ sở/Doanh nghiệp"></asp:Literal></a>
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
             <asp:HyperLink ID="btn_list" runat="server" NavigateUrl="~/Admin/listReport/Default.aspx" CssClass="pl5" title="Videos"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">Danh sách</span>
            </asp:HyperLink>
        </div> 

        <div class="topbar-icon ml15 ib va-m">
             <asp:LinkButton ID="btn_new" runat="server" OnClick='btn_new_click' CssClass="pl5" title="Thêm dự án" ValidationGroup="view"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm báo cáo</span>
            </asp:LinkButton>
        </div>   


        <div class="topbar-icon ml15 ib va-m">
            <a href="#" class="pl5" title="Trợ giúp"> 
                <i class="fa fa-exclamation-circle fs22 text-primary"></i><br /><span class="fs11">Trợ giúp</span>
            </a>
        </div>
    </div>
</header>
<!-- Begin: Content -->
<section id="content">
<!-- Dashboard Tiles -->
    <div class="row mb10">
        <div class="tab-block mb25">
            
             <div class="panel">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-1">
                            <div class="form-group">
                                <label>
                                    Năm
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlYear" runat="server"  CssClass="form-control input-sm">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="ddlYear" ValidationGroup="vgSearch" Display="Dynamic" Text="Bạn phải chọn năm"></asp:RequiredFieldValidator>
                            </div>
                        </div>                                
                        <div class="col-lg-1">
                            <div class="form-group">
                                <label>
                                    Từ ngày
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <asp:TextBox ID="txtTuNgay" runat="server"  CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-1">
                            <div class="form-group">
                                <label>
                                    Đến ngày
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <div class="form-group">
                                <asp:TextBox ID="txtDenNgay" runat="server"  CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>                                                                        
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="btn btn-outline btn-primary" ValidationGroup="vgSearch"
                                    Text="Tìm kiếm" />
                            </div>
                        </div>
                    </div>
                </div>
             </div>
             
            <%--<ul class="nav nav-tabs tabs-border">      
                <li class="active"><a href="#tab1" data-toggle="tab" aria-expanded="true">Thông tin báo cáo</a></li>
                <li><a href="#tab2" data-toggle="tab" aria-expanded="false">Số liệu báo cáo</a></li>                                
            </ul>--%>
            
                <div id="tab2" class="tab-pane active">   
                    <div class="panel">
                        <div class="panel-body">
                           
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
                    <div class="">
                        <div class="">
                          <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
                            <div class="form-horizontal">                                                               
                                <div class="form-group">                                    
                                    <div class="col-lg-12">
                                            <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
                                            <table class="table table-bordered table-hover mbn" width="100%">
                                                <tr class="primary fs12">
                                                    <th style="width:5%">STT</th>
                                                    <th style="width:7%">Báo cáo năm</th>
                                                    <th style="width:25%">Tên doanh nghiệp</th>
                                                    <th style="width:10%">Địa chỉ</th>
                                                    <th style="width:10%">Lĩnh vực</th>
                                                    <th style="width:10%">Ngành nghề</th>
                                                    <th style="width:10%">Điện thoại</th>
                                                    <th style="width:10%">Email</th>                                                    
                                                    <th style="width:10%">Ngày gửi báo cáo</th>                                                    
                                                    <th style="width:10%">Người báo cáo</th>                                                                                                                                               
                                                    <th style="width:10%">Thao tác</th>
                                                </tr>                                           
                                                <asp:Repeater ID="rptNoFuelCurrent" runat="server" 
                                                    onitemdatabound="rptNoFuelCurrent_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Container.ItemIndex+1  %></td>
                                                        <td><%#Eval("Year") %></td>
                                                        <td><a href='#' onclick="javascript:UpdateFuel(<%#Eval("Id") %>,false);"><%#Eval("Title") %></a></td>                                                        
                                                        <td><%#Eval("Address") %></td>
                                                        <td><%#Eval("ParentAreaName")%></td>
                                                        <td><%#Eval("AreaName") %></td>                                                        
                                                        <td><%#Eval("Phone")%></td>
                                                        <td><%#Eval("Email")%></td>
                                                        <td><%#Eval("ReportDate") != DBNull.Value && Convert.ToDateTime(Eval("ReportDate")).Year > 1 ? Convert.ToDateTime(Eval("ReportDate")).ToString("dd/MM/yyyy") : ""%></td>
                                                        <td><%#Eval("ReporterName")%></td>                                                                                                                                                                     
                                                        <td style="text-align: center">
                                                        <a href="#" onclick='javacript:showforms(<%#Eval("Id") %>);'>Tiếp nhận</a>
                                                            <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%#Eval("Id") %>'
                                                                CssClass="fa fa-times" ToolTip="Xóa" OnClientClick="return javascript:confirm('Bạn chắc chắn muốn xóa không');"></asp:LinkButton>
                                                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="fa fa-edit" ToolTip="Sửa"  CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                </asp:Repeater> 
                                            </table>
                                            <br />
                                            <asp:LinkButton ID="btnAdd" runat="server" Visible="false" Text="Thêm báo cáo" CssClass="btn btn-sm btn-primary mr10"></asp:LinkButton>
                                    </div>
                                </div>                                                                                                                                                                                                  
                                <asp:Literal ID="error" runat="server"></asp:Literal>                                                                                                                                                     
                            </div>
                        </div>
                    </div>    
                </div>            
            </div>
        </div> 
        </div>        
    </div>   
</section>
<div class="modal fade" tabindex="-1" role="dialog" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Tiếp nhận báo cáo</h4>
            </div>
            <div class="modal-body">
                <form>
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
                <div class="form-group">
                    <label for="recipient-name" class="control-label">
                        Ngày tiếp nhận <span class="append-icon right text-danger">*</span></label>
                    <asp:TextBox ID="txtNgayTiepNhan" runat="server" CssClass="form-control" ValidationGroup="vgTN"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNgayTN" ControlToValidate="txtNgayTiepNhan" ValidationGroup="vgTN"
                        runat="server" Text="Vui lòng nhập ngày tiếp nhận" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="message-text" class="control-label">
                        Mô tả</label>
                    <asp:TextBox runat="server" class="form-control" ID="txtmota"></asp:TextBox>
                </div>
                </form>
            </div>
            <div class="modal-footer" style="text-align: left">
                <asp:Button ID="btnSave" runat="server" Visible="true" Text="Lưu lại" OnClick="btnSave_Click"
                    CssClass="btn btn-sm btn-primary mr10" AutoPostback="false" ValidationGroup="vgTN">
                </asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
<script type="text/javascript">
 $(document).ready(function () {

        $("#<%=txtTuNgay.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });
        $("#<%=txtDenNgay.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });
         $("#<%=txtNgayTiepNhan.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });

    });    

    function SelectUrl(RepportId,isNext) {
        var _url = <%=ResolveUrl("~")%>+"Client/Admin/DataEngery/Default.aspx?ReportId="+RepportId+"&isnext="+isNext;
        return window.open(_url, 'mydoc', 'scrollbars=yes,resizable=no,locationbar=no,width=800,height=550,left='.concat((screen.width - 800) / 2).concat(',top=').concat((screen.height - 550) / 2));
    }
    function UpdateFuel(FuelId,isNext) {
        var _url = <%=ResolveUrl("~")%>+"Client/Admin/DataEngery/Default.aspx?FuelId="+FuelId+"&isnext="+isNext;
        return window.open(_url, 'newW', 'scrollbars=yes,resizable=no,locationbar=no,width=800,height=550,left='.concat((screen.width - 800) / 2).concat(',top=').concat((screen.height - 550) / 2));
    }
     function showforms(reportId) {
        $(document).ready(function () {
            $('#myModal').modal('toggle');                                        
                $("#<%=hdnValueId.ClientID%>").val(reportId);               
        });

    }

</script>
