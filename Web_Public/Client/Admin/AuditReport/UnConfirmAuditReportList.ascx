<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UnConfirmAuditReportList.ascx.cs"
    Inherits="Client_Admin_DataEnergy_UnConfirmAuditReportList" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
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
                        <div class="form-group">
                            <div class="col-lg-1">                            
                                <label>
                                    Năm KT
                                </label>
                            </div>                      
                            <div class="col-lg-2">                           
                                <asp:DropDownList ID="ddlYear" runat="server"  CssClass="form-control input-sm">
                                </asp:DropDownList>                                                          
                            </div>                                
                            <div class="col-lg-1">                          
                                <label>
                                    Lĩnh vực
                                </label>                           
                            </div>
                            <div class="col-lg-2">                            
                                <asp:DropDownList ID="ddlArea" runat="server"  CssClass="form-control input-sm">
                                </asp:DropDownList>                           
                            </div>      
                            <div class="col-lg-1">                          
                                <label>
                                    Quận/Huyện
                                </label>                           
                            </div>
                            <div class="col-lg-2">                            
                                <asp:DropDownList ID="ddlDistrict" runat="server"  CssClass="form-control input-sm">
                                </asp:DropDownList>                           
                            </div> 
                            <div class="col-lg-1">                          
                                <label>
                                    Tên DN
                                </label>                           
                            </div>
                            <div class="col-lg-2">                            
                               <asp:TextBox ID="txtKeyword"  runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>                                                                                 
                            <div class="col-lg-3">                            
                                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="btn btn-outline btn-sm btn-primary" ValidationGroup="vgSearch"
                                    Text="Tìm kiếm" />                            
                            </div>
                        </div>
                    </div>
                </div>
             </div>
                
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
                                <uc1:PagingControl ID="Paging2" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
        LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                            </div>
                        </div>
                    </div>
                    <div class="row box-white mb10 pl10 pr10 pb10">
                        <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
                        <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
                        
                        <table class="table table-bordered table-hover mb10">
                            <thead>
                                <tr class="text-center">
                                    <th style="width: 5%" class="text-center">
                                        STT
                                    </th>
                                    <th style="width: 30%" class="text-center">
                                        Doanh nghiệp
                                    </th>
                                    <th style="width: 10%" class="text-center">
                                        Năm kiểm toán
                                    </th>
                                    <th style="width: 20%" class="text-center">
                                        Đơn vị kiểm toán
                                    </th>                                
                                    <th style="width: 10%" class="text-center">
                                        Ngày gửi báo cáo
                                    </th>
                                    <th style="width: 10%" class="text-center">
                                        Trạng thái
                                    </th>
                                    <th style="width: 5%" class="text-center">
                                        Thao tác
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptAuditReport" runat="server" OnItemDataBound="rptAuditReport_ItemDataBound"
                                    OnItemCommand="rptAuditReport_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <%#Container.ItemIndex+1  %>
                                            </td>
                                             <td>
                                                <a href='<%#ResolveUrl("~") %>Admin/ViewAuditReport/<%#Eval("Id")%>/Default.aspx'>
                                                    <%#Eval("Title")%>
                                                </a>
                                            </td>
                                            <td>
                                                <a href='<%#ResolveUrl("~") %>Admin/ViewAuditReport/<%#Eval("Id")%>/Default.aspx'>
                                                    <%#Eval("AuditYear")%>
                                                </a>
                                            </td>                                           
                                            <td>
                                                <%#Eval("AuditConsultancyName")%>
                                            </td>                                            
                                            <td>
                                                <%#Eval("Sent") != DBNull.Value && Convert.ToDateTime(Eval("Sent")).Year > 1 ? Convert.ToDateTime(Eval("Sent")).ToString("hh:MM dd/MM/yyyy") : ""%>
                                            </td>
                                            <td>
                                                <%#Tool.TrangThaiKToan(Convert.ToInt32(Eval("Status")))%>
                                            </td>
                                            <td class="text-center">
                                                <asp:LinkButton ID="lbtDownload" runat="server" OnClick="lbtDownload_Click" CommandName="Download"
                                                    CommandArgument='<%#Eval("Id") %>' CssClass="" ToolTip="Tải về"><i class="fa fa-download"></i></asp:LinkButton>
                                                <asp:Literal ID="ltEdit" runat="server"></asp:Literal>                                                
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <div class="ro m3">
                            <div class="box-pages">
                                <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="<%$ Resources:Resource, T_Top %>"
                                    LastString="<%$ Resources:Resource, T_Last %>" NextString="<%$ Resources:Resource, T_Next %>"
                                    PrevString="<%$ Resources:Resource, T_Back %>" />
                            </div>
                        </div>
                        <asp:Literal ID="error" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>            
        </div>
    </div>
</section>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgAuditReport">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Tạo báo cáo kiểm toán năng lượng</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Đơn vị tư vấn KT<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtAuditConsultant" runat="server" CssClass="form-control input-sm"
                                ValidationGroup="valGen"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAuditConsultant"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Địa chỉ</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm" ValidationGroup="view"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Kiểm toán viên<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtAuditor" runat="server" CssClass="form-control input-sm" ValidationGroup="valGen"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAuditor"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Phạm vi kiểm toán</label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtAuditScope" runat="server" CssClass="form-control input-sm" ValidationGroup="valGen"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAuditScope"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Số ca sản xuất</label>
                        <div class="col-lg-9">
                            <asp:RadioButtonList ID="rbtShiftNo" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Text="1 ca" Value="1">
                                </asp:ListItem>
                                <asp:ListItem Selected="True" Text="2 ca" Value="2">
                                </asp:ListItem>
                                <asp:ListItem Selected="True" Text="3 ca" Value="3">
                                </asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Năm kiểm toán<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlAuditYear" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valGen">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlAuditYear"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Dữ liệu cơ sở năm<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlDataYear" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valGen">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDataYear"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12 text-left">
                            <i>Ghi chú: Những thông tin có dấu <span class="append-icon right text-danger">*</span>
                                là những thông tin bắt buộc phải nhập hoặc phải chọn</i>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                    Hủy</button>
                <asp:LinkButton ID="btnAddReport" runat="server" Visible="true" ValidationGroup="valGen"
                    OnClick="btnAddReport_Click" Text="Tạo báo cáo" CssClass="btn-u btn-u-primary mr10"></asp:LinkButton>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Lựa chọn mẫu báo cáo</h4>
            </div>
            <div class="modal-body">
                <section class="mbn">
                    <label class="select">
                    <asp:DropDownList runat="server" ID="drpmaubaocao">
                        <asp:ListItem Value="1" Text="Dùng cho cơ sở hoạt động trong lĩnh vự sản xuất công nghiệp" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Dùng cho cơ sở sản xuất điện"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Dùng cho tòa nhà đặt trụ sở, văn phòng làm việc"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Dùng cho các trường học; bệnh viện; khu vui chơi, giải trí; thể dục, thể thao"></asp:ListItem>
                        <asp:ListItem Value="5" Text="Dùng cho các khách sạn, nhà hàng"></asp:ListItem>
                        <asp:ListItem Value="6" Text="Dùng cho tòa nhà siêu thị, cửa hàng"></asp:ListItem>
                        <asp:ListItem Value="7" Text="Dùng cho cơ sở là cơ quan, đơn vị sử dụng ngân sách nhà nước"></asp:ListItem>
                        <asp:ListItem Value="8" Text="Dùng cho các cơ sở hoạt động trong lĩnh vực Giao thông vận tải"></asp:ListItem>
                        <asp:ListItem Value="9" Text="Dùng cho các cơ sở chế biến, gia công sản phẩm trong nông nghiệp"></asp:ListItem>
                        <asp:ListItem Value="10" Text="Dùng cho các cơ sở đánh bắt thủy, hải sản; máy móc phục vụ sản xuất nông nghiệp"></asp:ListItem>
                        <asp:ListItem Value="11" Text="Dùng cho cơ sở thủy lợi phục vụ sản xuất nông nghiệp"></asp:ListItem>
                    </asp:DropDownList>
                    <i></i>
                    </label>
                </section>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                    Đóng</button>
                <asp:LinkButton ID="btnExport" runat="server" Visible="true" Text="Xuất báo cáo"
                    CssClass="btn-u btn-u-primary mr10"></asp:LinkButton>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<asp:HiddenField ID="hddma" runat="server" />
<!-- /.modal -->
<script type="text/javascript">
    function SelectUrl(RepportId, isNext) {
        var _url = '<%=ResolveUrl("~")%>' + "Client/Admin/DataEngery/Default.aspx?ReportId=" + RepportId + "&isnext=" + isNext;
        return window.open(_url, 'mydoc', 'scrollbars=yes,resizable=no,locationbar=no,width=800,height=550,left='.concat((screen.width - 800) / 2).concat(',top=').concat((screen.height - 550) / 2));
    }
    function UpdateFuel(FuelId, isNext) {
        var _url = '<%=ResolveUrl("~")%>' + "Client/Admin/DataEngery/Default.aspx?FuelId=" + FuelId + "&isnext=" + isNext;
        return window.open(_url, 'newW', 'scrollbars=yes,resizable=no,locationbar=no,width=800,height=550,left='.concat((screen.width - 800) / 2).concat(',top=').concat((screen.height - 550) / 2));
    }
    function voidexcel(id) {
        $("#<%=hddma.ClientID%>").val(id);

        $('#myModal').on('shown.bs.modal', function () {

        });
    }
    function ShowDialogAuditReport() {
        $('#dlgAuditReport').on('shown.bs.modal', function () {
        });
    }
</script>
