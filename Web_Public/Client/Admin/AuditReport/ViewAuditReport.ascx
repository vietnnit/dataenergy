<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewAuditReport.ascx.cs"
    Inherits="Client_Admin_AuditReport_ViewAuditReport" %>
<%@ Register Src="~/Client/Admin/AuditReport/AuditSolutionReport.ascx" TagName="AuditSolution"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Admin/AuditReport/AuditProduct.ascx" TagName="AuditProduct"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Admin/AuditReport/AuditOperationArea.ascx" TagName="AuditOperationArea"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Admin/AuditReport/EnergyConsume.ascx" TagName="EnergyConsume"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Admin/AuditReport/EnergyQuota.ascx" TagName="EnergyQuota"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Admin/AuditReport/ElectrictSystem.ascx" TagName="ElectrictSystem"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Admin/AuditReport/AuditDevice.ascx" TagName="AuditDevice"
    TagPrefix="uc1" %>
<asp:HiddenField ID="hdnNewsUrl" Value="" runat="server" />
<asp:HiddenField ID="hdnReport" Value="" runat="server" />
<asp:HiddenField ID="hdnNextYear" Value="" runat="server" />
<asp:HiddenField ID="hdnDetailId" Value="" runat="server" />
<link type="text/css" href="<%= ResolveUrl("~") %>CSS_Admins/js/DatetimePicker/jquery.datetimepicker.css"
    rel="stylesheet" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>CSS_Admins/js/DatetimePicker/jquery.datetimepicker.js"></script>
<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.css" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.js"></script>
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server" Text="Báo cáo kiểm toán năng lượng/Chi tiết báo cáo kiểm toán"></asp:Literal></a>
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
        <div class="tab-content">
            <div class="panel" style="width: 100%">
                <b>THÔNG TIN CHUNG BÁO CÁO</b>               
            </div>
            <div class="form-horizontal">
                <div class="row">
                    <div class="col-lg-12">
                    <label>
                        <b>1. Doanh nghiệp KTNL:&nbsp;</b></label><asp:Literal ID="ltEnterpriseName" runat="server"></asp:Literal><a href="#EnterpriseInfo" data-toggle="collapse" aria-expanded="false"><i
                            class="fa fa-angle-down"></i></a>
                    </div>                      
                </div>
                
                <div id="EnterpriseInfo" class="collapse">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tr>
                            <td style="width:20%"><label>
                                Lĩnh vực</label></td>
                            <td style="width:30%"><asp:Literal ID="ltAreaName" runat="server"></asp:Literal></td>
                            <td style="width:20%">
                            <label>
                            Phân ngành</label>
                            </td>
                            <td style="width:30%"><asp:Literal ID="ltSubAreaName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td><label>Tỉnh/TP</label></td>
                            <td><asp:Literal ID="ltProvinceName" runat="server"></asp:Literal></td>
                            <td><label>Quận/Huyện</label></td>
                            <td><asp:Literal ID="ltDistrictName" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td><label>Mã số thuế</label></td>
                            <td><asp:Literal ID="ltTaxNo" runat="server"></asp:Literal></td>
                            <td><label>Mã KH dùng điện</label></td>
                            <td><asp:Literal ID="ltCustomerCode" runat="server"></asp:Literal></td>
                        </tr>
                       
                        <tr>
                            <td><label>Địa chỉ</label></td>
                            <td colspan="3"><asp:Literal ID="ltAddress" runat="server"></asp:Literal></td>                       
                        </tr>
                        <tr>
                            <td><label>Email</label></td>
                            <td colspan="3"><asp:Literal ID="ltEmail" runat="server"></asp:Literal></td>            
                        </tr>
                        <tr>                       
                            <td><label>Số điện thoại</label></td>
                            <td><asp:Literal ID="ltPhoneNumber" runat="server"></asp:Literal></td>
                             <td><label>Fax</label></td>
                            <td><asp:Literal ID="ltFaxNo" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>                       
                            <td><label>Chịu trách nhiệm</label></td>
                            <td><asp:Literal ID="ltResponsible" runat="server"></asp:Literal></td>
                             <td><label>Chủ sở hữu</label></td>
                            <td><asp:Literal ID="ltOwner" runat="server"></asp:Literal></td>
                        </tr>
                    </table>                                       
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tr>
                            <td style="width:20%"><label>Công ty mẹ</label></td>
                            <td colspan="3"><asp:Literal ID="ltParentName" runat="server"></asp:Literal></td>
                        </tr>
                         <tr>
                            <td style="width:20%"><label>Tỉnh/TP</label></td>
                            <td style="width:30%"><asp:Literal ID="ltProvinceParent" runat="server"></asp:Literal></td>
                            <td style="width:20%">
                            <label>
                            Quyện/Huyện</label>
                            </td>
                            <td style="width:30%"><asp:Literal ID="ltDistrictParent" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td><label>Địa chỉ</label></td>
                            <td colspan="3"><asp:Literal ID="ltAddressParent" runat="server"></asp:Literal></td>                            
                        </tr>
                        <tr>
                            <td><label>Số điện thoại</label></td>
                            <td><asp:Literal ID="ltPhoneParent" runat="server"></asp:Literal></td>
                            <td>
                            <label>
                            Fax</label>
                            </td>
                            <td><asp:Literal ID="ltFaxParent" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td><label>Email</label></td>
                            <td colspan="3"><asp:Literal ID="ltEmailParent" runat="server"></asp:Literal></td>                           
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <label class="col-lg-12">
                        2. Thông tin đơn vị tư vấn KTNL<a href="#divInfo" data-toggle="collapse" aria-expanded="true"><i
                            class="fa fa-angle-down"></i></a></label>
                </div>
                <div id="divInfo" class="collapse in">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tr>
                            <td style="width: 20%">
                                <label>
                                    Tên đơn vị</label>
                            </td>
                            <td style="width: 80%">
                                <asp:Literal ID="ltAuditUnit" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Địa chỉ</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltAuditAddress" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Kiểm toán viên</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltAuditor" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <label class="col-lg-12">
                        3. Khu vực được kiểm toán NL<a href="#divScope" data-toggle="collapse" aria-expanded="true"><i
                            class="fa fa-angle-down"></i></a></label>
                </div>
                <div id="divScope" class="collapse in">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tr>
                            <td style="width: 20%">
                                <label>
                                    Phạm vi kiểm toán NL</label>
                            </td>
                            <td style="width: 80%" colspan="3">
                                <asp:Literal ID="ltAuditScope" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                <label>
                                    Số ca sản xuất</label>
                            </td>
                            <td>
                                <label>
                                    1 ca</label>
                            </td>
                            <td>
                                <label>
                                    2 ca</label>
                            </td>
                            <td>
                                <label>
                                    3 ca</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltShiftNo1" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltShiftNo2" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltShiftNo3" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <label class="col-lg-12">
                        4. Thời gian thực hiện KTNL<a href="#divTime" data-toggle="collapse" aria-expanded="true"><i
                            class="fa fa-angle-down"></i></a></label>
                </div>
                <div id="divTime" class="collapse in">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tr>
                            <td style="width: 20%">
                                <label>
                                    Năm thực hiện KTNL</label>
                            </td>
                            <td style="width: 80%">
                                <asp:Literal ID="ltAuditYear" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                <label>
                                    Dữ liệu cơ sở năm</label>
                            </td>
                            <td style="width: 80%">
                                <asp:Literal ID="ltDataYear" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                <label>
                                    File báo cáo KTNL</label>
                            </td>
                            <td style="width: 80%">
                                <asp:LinkButton ID="lbtDownload" runat="server" OnClick="lbtDownload_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <b>5. Thiết bị đo kiểm</b><a href="#divQuipment" data-toggle="collapse" aria-expanded="true"><i
                            class="fa fa-angle-down"></i></a>                      
                    </div>
                </div>
                <div id="divQuipment" class="collapse in">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <thead>
                            <tr>
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                                <th style="width: 30%">
                                    Tên thiết bị
                                </th>
                                  <th style="width: 20%">
                                     Số Serial(SN)
                                </th>  
                                <th style="width: 15%">
                                    Đơn vị
                                </th>
                                <th style="width: 15%">
                                    Số lượng
                                </th>
                                <th style="width: 15%">
                                    Nước sản xuất
                                </th>                               
                            </tr>
                        </thead>
                        <asp:Repeater ID="rptEquipment" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center"><%#Container.ItemIndex+1 %></td>
                                    <td>
                                        <%#Eval("DeviceName")%>
                                    </td>
                                    <td class="text-left">
                                        <%#Eval("SerialNo")%>
                                    </td>
                                    <td>
                                        <%#Eval("Measurement")%>
                                    </td>
                                    <td class="text-right">
                                        <%#Eval("Quantity")%>
                                    </td>
                                    <td>
                                        <%#Eval("MadeIn")%>
                                    </td>
                                   
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <br />
                 <div class="row">
                    <div class="col-lg-12">
                        <div class="panel">
                            <ul class="nav nav-tabs tabs-border" id="tabGeneral">
                                <li><a rel="tabReport" href="#" class=""><i class="fa fa-info-circle">&nbsp;</i>THÔNG
                                    TIN CHI TIẾT BÁO CÁO</a></li>
                                <li><a rel="tabAttachFile" href="#" class=""><i class="fa fa-file-pdf-o">&nbsp;</i>FILE
                                    BÁO CÁO</a></li>
                                <li><a rel="tabHistory" href="#" class=""><i class="fa fa-comments-o">&nbsp;</i>Ý KIẾN TRAO ĐỔI</a></li>
                            
                            </ul>
                        </div>
                    </div>
                </div>  
                <div id="tabReport">
                    <div class="row">
                        <div class="col-lg-12">
                            <ul class="nav nav-tabs tabs-border" id="tabAuditReport">
                                <li><a rel="tabSolution" href="#" class="">Giải pháp tiết kiệm</a></li>
                                <li><a rel="tabProduct" href="#" class="">Nguyên liệu và S.phẩm</a></li>
                                <li><a rel="tabOperation" href="#" class="">Số giờ VH</a></li>
                                <li><a rel="tabDevice" href="#" class="">Thiết bị</a></li>                                 
                                <li><a rel="tabPower" href="#" class="">Hệ thống cung cấp điện</a></li>
                                <li><a rel="tabUsingEnergy" href="#" class="">Tiêu thụ NL</a></li>
                                <li><a rel="tabStandardEnergy" href="#" class="">Suất tiêu hao NL</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="tabChuyen">
                        <div class="" style="border-top: 0">
                            <div id="tabSolution">
                                <uc1:AuditSolution ID="ucAuditSolution" runat="server" />
                            </div>
                            <div id="tabProduct" class="">
                                <uc1:AuditProduct ID="ucAuditProduct" runat="server" />
                            </div>
                            <div id="tabOperation">
                                <uc1:AuditOperationArea ID="ucAuditOperationArea" runat="server" />
                            </div>
                            <div id="tabDevice">
                                <uc1:AuditDevice ID="ucAuditDevice" runat="server" />
                            </div>
                            <div id="tabPower">
                                <uc1:ElectrictSystem ID="ucElectrictSystem" runat="server" Visible="true" />
                            </div>
                            <div id="tabUsingEnergy">
                                <uc1:EnergyConsume ID="ucEnergyConsume" runat="server" Visible="true" />
                            </div>
                            <div id="tabStandardEnergy">
                                <uc1:EnergyQuota ID="ucEnergyQuota" runat="server" Visible="true" />
                            </div>
                        </div>
                    </div>                    
                </div>                
                <div id="tabHistory">
                    <div class="row">
                        <div class="col-lg-12">
                            <label class="control-label">
                                <asp:Literal ID="ltOldYear" runat="server" Text=""></asp:Literal></label>
                            <div class="margin-bottom-10">
                                <table class="table table-bordered table-hover mbn" width="100%">
                                    <thead>
                                        <tr class="">
                                            <th style="width: 15%">
                                                Hoạt động
                                            </th>
                                            <th style="width: 60%">
                                                Nội dung
                                            </th>
                                            <%-- <th style="width: 15%">
                                                Trạng thái
                                            </th>--%>
                                            <th style="width: 15%">
                                                Thời gian cập nhật
                                            </th>
                                            <th style="width: 10%">
                                                Người cập nhật
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptLog" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%# Eval("ActionName")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Comment")%>
                                                    </td>
                                                    <%-- <td>
                                                        <%# Eval("Status")%>
                                                    </td>--%>
                                                    <td>
                                                        <%# Convert.ToDateTime(Eval("Created")).ToString("hh:MM:ss dd/MM/yyyy")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("UserName")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <%--<div class="row">
                    <br />
                        <div class="col-lg-12 text-right">
                            <asp:LinkButton runat="server" ID="lbtSendFeeback" CssClass="btn btn-sm btn-success mr10"
                                OnClientClick="ShowDialogFeedback();return false;" data-toggle="modal" data-target="#dlgFeedback"
                                Text="Gửi ý kiến" ValidationGroup="view"></asp:LinkButton>
                        </div>
                    </div>--%>
                </div>
                <div id="tabAttachFile">           
                    <div class="row">
                        <div class="col-lg-12">
                            <label class="control-label">
                                <asp:Literal ID="Literal9" runat="server" Text=""></asp:Literal></label>
                            <div class="margin-bottom-10">
                                <table class="table table-bordered table-hover mbn" width="100%">
                                    <thead>
                                        <tr class="">
                                            <th style="width: 25%">
                                                Tên file
                                            </th>
                                            <th style="width: 50%">
                                                Ghi chú
                                            </th>
                                            <th style="width: 15%">
                                                Thời gian cập nhật
                                            </th>
                                            <th>
                                                Người cập nhật
                                            </th>
                                            <th>
                                                Tải về
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptReportFile" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%# Eval("PathFile")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Comment")%>
                                                    </td>
                                                    <td>
                                                        <%# Convert.ToDateTime(Eval("Created")).ToString("hh:MM:ss dd/MM/yyyy")%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("UserName")%>
                                                    </td>
                                                    <td class="text-center">
                                                        <asp:LinkButton ID="lbtDownload" runat="server" OnClick="lbtDownload_Click" CommandName="Download"
                                                            CommandArgument='<%#Eval("Id") %>' CssClass="" ToolTip="Tải về"><i class="fa fa-download"></i></asp:LinkButton>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div> 
                <br />
                <div class="row">
                    <div class="col-lg-12 text-left">
                        <asp:Button runat="server" ID="btnSend" CssClass="btn btn-sm btn-success mr10" OnClientClick="ShowDialogConfirm();return false;"
                            data-toggle="modal" data-target="#dlgSend" Text="Xác nhận đã gửi"
                                ValidationGroup="view" />                            
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</section>
<%--Thong tin chung bao cao--%>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgConfirm">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="Literal3" runat="server" Text="Xác nhận gửi báo cáo"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Xác nhận nộp báo cáo</label>
                        <div class="col-lg-9">
                            <div class="checkbox-custom pt5">
                                <asp:RadioButtonList ID="rblApproved" runat="server">
                                    <asp:ListItem Value="1" Text="Khóa hiệu chỉnh, bổ sung" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Tiếp tục, hiệu chỉnh"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Nội dung xác nhận<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtContent" TextMode="MultiLine" Rows="3" runat="server" CssClass="form-control input-sm"
                                ValidationGroup="valConfirm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContent" runat="server" ControlToValidate="txtContent"
                                CssClass="text-danger" ValidationGroup="valConfirm" Text="Vui lòng nhập nội dung xác nhận"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnConfirm" CssClass="btn btn-sm btn-primary mr10"
                    Text="Xác nhận" ValidationGroup="valConfirm" OnClick="btnConfirm_Click" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</div>
<script type="text/javascript">


    function ShowDialogInfo() {
        $('#dlgInfo').modal('toggle');
    }

    function ShowDialogConfirm() {
        $(document).ready(function () {
            $('#dlgConfirm').modal('toggle');
        });
    }

</script>
<script type="text/javascript">
    var tabReportAll = new ddtabcontent("tabAuditReport");
    tabReportAll.setpersist(true);
    tabReportAll.setselectedClassTarget("link");
    tabReportAll.currentTabIndex = 0;
    tabReportAll.init();

    var tabGeneralAll = new ddtabcontent("tabGeneral");
    tabGeneralAll.setpersist(true);
    tabGeneralAll.setselectedClassTarget("link");
    tabGeneralAll.currentTabIndex = 0;
    tabGeneralAll.init();

</script>
<asp:Literal ID="ltScript" runat="server"></asp:Literal>
