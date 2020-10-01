<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewReportDetail.ascx.cs"
    Inherits="Client_Admin_DataEnergy_ViewReportDetail" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Client/Admin/DataEngery/ViewPlan5Year.ascx" TagName="ViewPlan5Year"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Admin/DataEngery/ViewPlanOneYear.ascx" TagName="ViewPlanOneYear"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Admin/DataEngery/ViewProductYear.ascx" TagName="ViewProductYear"
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
            <asp:LinkButton ID="btn_add" runat="server" OnClientClick="approvedReport();return false;" CssClass="pl5" title="Lưu lại"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Phê duyệt</span>
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
        <div class=" tab-content">
            <div class="panel" style="width: 100%" for="inputSmall">
                <b>THÔNG TIN CHUNG BÁO CÁO</b>  
                <div style="float:right"><div class="col-lg-12 text-left">                            
                        <asp:Button runat="server" ID="btnExecutedApproved2" CssClass="btn btn-sm btn-success mr10"
                            Text="Phê duyệt báo cáo" OnClientClick="approvedReport();return false;"  data-toggle="modal"
                            data-target="#approvedReport" />    
                        <asp:Button runat="server" ID="btnDelince2" Visible="false" CssClass="btn btn-sm btn-alert mr10"
                        Text="Báo cáo chưa đạt" OnClientClick="delinceReport();return false;"  data-toggle="modal"
                        data-target="#approvedReport" />
                        <asp:Button runat="server" ID="Button2" CssClass="btn btn-sm btn-success mr10"
                                Text="Xuất báo cáo hàng năm" OnClientClick="ShowDialogExport();return false;" data-toggle="modal"
                                data-target="#dlgExport" />                         
                        </div>          
                    </div>         
            </div>
            <div class="row">
                <div class="form-group">
                    <label class="col-lg-2" for="inputSmall">
                        Người lập báo cáo</label>
                    <div class="col-lg-4">
                        <asp:Literal ID="ltReporterName" runat="server"></asp:Literal>
                    </div>
                    <%-- </div>
                <div class="form-group">--%>
                    <label class="col-lg-2" for="inputSmall">
                        Ngày báo cáo</label>
                    <div class="col-lg-4">
                        <asp:Literal ID="ltReportDate" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="row">
                <label class="col-lg-2" for="inputSmall">
                    Tên cơ sở/DN</label>
                <div class="col-lg-10">
                    <asp:Literal ID="ltEnterpriseName" runat="server"></asp:Literal>&nbsp;&nbsp;<a href="#EnterpriseInfo"
                        data-toggle="collapse" aria-expanded="false"><i class="fa fa-chevron-down"></i></a>
                </div>
            </div>
            <div class="">
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
                            <td><label>Email</label></td>
                            <td><asp:Literal ID="ltEmail" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td><label> Địa chỉ</label></td>
                            <td colspan="3"><asp:Literal ID="ltAddress" runat="server"></asp:Literal></td>                       
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
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel">
                        <ul class="nav nav-tabs tabs-border" id="tabGeneral">
                            <li><a rel="tabReport" href="#" class=""><i class="fa fa-info-circle">&nbsp;</i>THÔNG
                                TIN CHI TIẾT BÁO CÁO</a></li>
                            <li><a rel="tabAttachFile" href="#" class=""><i class="fa fa-file-pdf-o">&nbsp;</i>FILE
                                BÁO CÁO</a></li>
                            <li><a rel="tabHistory" href="#" class=""><i class="fa fa-comments-o">&nbsp;</i>Ý KIẾN,
                                PHẢN HỒI PHÊ DUYỆT</a></li>
                            
                        </ul>
                    </div>
                </div>
            </div>                                          
            <div id="tabReport">
                <div class="row">
                    <div class="col-lg-12">
                        <ul class="nav nav-tabs tabs-border" id="Reporttabs">
                            <li><a rel="tabProduct" href="#" class="">Cơ sở hạ tầng và sản phẩm</a></li>
                            <li><a rel="tabData" href="#" class="">Mức nhiên liệu tiêu thụ năm</a></li>
                            <li><a rel="tabPlan" href="#" class="">Giải pháp TKNL năm</a></li>                        
                            <li><a rel="tabPlan5Year" href="#" class="">Giải pháp TKNL 5 năm</a></li> 
                        </ul>
                    </div>
                </div>
                <div id="tabChuyen">
                    <div class="" style="border-top: 0">
                        <div id="tabProduct">
                            <uc1:ViewProductYear ID="ucProduct" runat="server" />
                        </div>
                        <div id="tabData" class="">
                            <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div class="control-label pt5" style="width: 100%; text-align:left">
                                        <b><asp:Literal ID="ltDataCurrentTitle" runat="server" Text="Mức nhiên liệu tiêu thụ thực tế"></asp:Literal></b>                                        
                                    </div>
                                    <table class="table table-bordered table-hover mbn" width="100%">
                                        <tr class="">
                                            <th style="width: 5%">
                                                STT
                                            </th>
                                            <th style="width: 15%">
                                                Nhiên liệu
                                            </th>
                                            <th style="width: 10%">
                                                Mức tiêu thụ
                                            </th>
                                            <th style="width: 10%">
                                                Đơn vị tính
                                            </th>
                                            <th style="width: 10%">
                                                Giá
                                            </th>
                                            <%--<th style="width: 10%">
                                            Hệ số TOE
                                        </th>--%>
                                            <th style="width: 10%">
                                                Năng lượng tiêu thụ (TOE)
                                            </th>
                                            <th style="width: 30%">
                                                Mục đích sử dụng
                                            </th>                                                   
                                        </tr>
                                        <asp:Repeater ID="rptNoFuelCurrent" runat="server" OnItemDataBound="rptNoFuelCurrent_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%#Container.ItemIndex+1  %>
                                                    </td>
                                                    <td>
                                                        <%#Eval("FuelName") %>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <%#Eval("NoFuel") %>
                                                    </td>
                                                    <td>
                                                        <%#Eval("MeasurementName")%>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <%#Eval("Price")%>
                                                    </td>
                                                    <%--<td>
                                                    <%#Eval("No_RateTOE")!=null?((float)Convert.ToDecimal(Eval("No_RateTOE"))).ToString():""%>
                                                </td>--%>
                                                    <td style="text-align: right">
                                                        <%#Eval("NoFuel_TOE") != null ? ((float)Convert.ToDecimal(Eval("NoFuel_TOE"))).ToString() : ""%>
                                                    </td>
                                                    <td>
                                                        <%#Eval("Reason")%>
                                                    </td>                                                            
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                    <div style="text-align: right">
                                        <b>
                                            <asp:Literal ID="ltTotal_TOE" runat="server"></asp:Literal></b>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">                                            
                                        <div class="control-label pt5" style="width: 100%;text-align:left;">
                                   <b><asp:Literal ID="ltDataNextYearTitle" runat="server" Text="Kế hoạch tiêu thụ nhiên liệu"></asp:Literal></b>
                                    </div>
                                    <table class="table table-bordered table-hover mbn" width="100%">
                                        <tr class="">
                                            <th style="width: 5%">
                                                STT
                                            </th>
                                            <th style="width: 15%">
                                                Nhiên liệu
                                            </th>
                                            <th style="width: 10%">
                                                Mức tiêu thụ dự kiến
                                            </th>
                                            <th style="width: 10%">
                                                Đơn vị tính
                                            </th>
                                            <th style="width: 10%">
                                                Giá dự kiến
                                            </th>
                                            <%-- <th style="width: 10%">
                                            Hệ số TOE
                                        </th>--%>
                                            <th style="width: 10%">
                                                Năng lượng tiêu thụ (TOE)
                                            </th>
                                            <th style="width: 30%">
                                                Mục đích sử dụng
                                            </th>                                                    
                                        </tr>
                                        <asp:Repeater ID="rptNoFuelFuture" runat="server" OnItemDataBound="rptNoFuelFuture_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%#Container.ItemIndex+1  %>
                                                    </td>
                                                    <td>
                                                        <%#Eval("FuelName") %>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <%#Eval("NoFuel") %>
                                                    </td>
                                                    <td>
                                                        <%#Eval("MeasurementName")%>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <%#Eval("Price")%>
                                                    </td>
                                                    <%--<td>
                                                    <%#Eval("No_RateTOE")!=null?((float)Convert.ToDecimal(Eval("No_RateTOE"))).ToString():""%>
                                                </td>--%>
                                                    <td style="text-align: right">
                                                        <%#Eval("NoFuel_TOE") != null ? ((float)Convert.ToDecimal(Eval("NoFuel_TOE"))).ToString() : ""%>
                                                    </td>
                                                    <td>
                                                        <%#Eval("Reason")%>
                                                    </td>                                                            
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                    <div style="text-align: right">
                                        <b>
                                            <asp:Literal ID="ltTotal_TOE_Future" runat="server"></asp:Literal></b>
                                    </div>                                    
                                </div>
                            </div>
                            <asp:Literal ID="Literal8" runat="server"></asp:Literal>
                        </div>
                        </div>
                        <div id="tabPlan">
                            <uc1:ViewPlanOneYear ID="ucViewPlanOneYear" runat="server" />
                        </div>
                        <div id="tabPlan5Year">
                            <uc1:ViewPlan5Year ID="ucViewPlan5Year" runat="server" />
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
                <div class="row">
                <br />
                    <div class="col-lg-12 text-right">
                        <asp:LinkButton runat="server" ID="lbtSendFeeback" CssClass="btn btn-sm btn-success mr10"
                            OnClientClick="ShowDialogFeedback();return false;" data-toggle="modal" data-target="#dlgFeedback"
                            Text="Gửi ý kiến" ValidationGroup="view"></asp:LinkButton>
                    </div>
                </div>
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
            <div class="row">
            <br />            
                 <div class="form-group">                            
                    <div class="col-lg-12 text-right">                            
                        <asp:Button runat="server" ID="btnExecutedApproved" CssClass="btn btn-sm btn-success mr10"
                            Text="Phê duyệt báo cáo" OnClientClick="approvedReport();return false;"  data-toggle="modal"
                            data-target="#approvedReport" />    
                        <asp:Button runat="server" ID="btnDelince" Visible="false" CssClass="btn btn-sm btn-alert mr10"
                        Text="Báo cáo chưa đạt" OnClientClick="delinceReport();return false;"  data-toggle="modal"
                        data-target="#approvedReport" />      
                        <asp:Button runat="server" ID="btnExportWord" CssClass="btn btn-sm btn-success mr10"
                                Text="Xuất báo cáo hàng năm" OnClientClick="ShowDialogExport();return false;" data-toggle="modal"
                                data-target="#dlgExport" />                   
                    </div>                            
                </div>                    
            </div>                      
        </div>                            
    </div>
</section>
<div class="modal fade" tabindex="-1" role="dialog" id="approvedReport">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Phê duyệt báo cáo</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group" style="display: none">
                        <label for="recipient-name" class="col-lg-3 col-md-3 col-sm-3 control-label">
                            Ngày xác nhận <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-6 col-md-4 col-sm-4">
                            <asp:TextBox ID="txtApprovedDate" runat="server" CssClass="form-control" ValidationGroup="valApproved"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNgayTN" ControlToValidate="txtApprovedDate" ValidationGroup="valApproved"
                                runat="server" Text="Vui lòng nhập ngày xác nhận" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Phê duyệt báo cáo</label>
                        <div class="col-lg-9">
                            <div class="checkbox-custom pt5">
                                <asp:RadioButtonList ID="rblApproved" runat="server">
                                    <asp:ListItem Value="1" Text="Đồng ý báo cáo" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Yêu cầu bổ sung, hiệu chỉnh"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 col-md-3 col-sm-3 control-label">
                            Nội dung ý kiến<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9 col-md-9 col-sm-9">
                            <asp:TextBox runat="server" class="form-control" ID="txtmota" TextMode="MultiLine"
                                Rows="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtmota"
                                ValidationGroup="valApproved" runat="server" Text="Vui lòng nhập nội dung ý kiến"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            File đính kèm</label>
                        <div class="col-lg-9">
                            Chọn file báo cáo đính kèm
                            <asp:FileUpload runat="server" ID="fAttachApp"></asp:FileUpload>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnApproved" CssClass="btn btn-sm btn-primary mr10"
                    Text="Xác nhận" OnClick="btnApproved_Click" ValidationGroup="valApproved" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="reportDelince">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Phê duyệt báo cáo</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <labelclass="col-lg-2 col-md-2 col-sm-2 control-label">
                            Ý kiến phê duyệt<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-10 col-md-10 col-sm-10">
                            <asp:TextBox runat="server" class="form-control" ID="TextBox2"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="Button1" CssClass="btn btn-sm btn-primary mr10" Text="Báo cáo chưa đạt"
                    OnClick="btnDelince_Click" ValidationGroup="vgTN" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgExport">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Lựa chọn mẫu báo cáo hàng năm</h4>
            </div>
            <div class="modal-body">
                <section class="mbn">
                    <label class="select">
                    <asp:DropDownList runat="server" ID="drpmaubaocao" CssClass="form-control input-sm">
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
                <asp:LinkButton ID="btnExport" runat="server" Visible="true" OnClick="btnExport_Click"
                    Text="Xuất báo cáo" CssClass="btn btn-sm btn-success mr10"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-warning mr10" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgFeedback">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="Literal5" runat="server" Text="Gửi ý kiến"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <h3>
                    <asp:Literal ID="Literal6" runat="server"></asp:Literal></h3>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Nội dung ý kiến <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtFeedback" runat="server" CssClass="form-control input-sm" ValidationGroup="valFeedback"
                                TextMode="MultiLine" Rows="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtFeedback"
                                ValidationGroup="valFeedback" Text="Vui lòng nhập nội dung ý kiến" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            File đính kèm</label>
                        <div class="col-lg-9">
                            Chọn file báo cáo đính kèm
                            <asp:FileUpload runat="server" ID="fAttachFeedback"></asp:FileUpload>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnSaveFeedback" CssClass="btn btn-sm btn-primary mr10"
                    Text="Lưu lại" OnClick="btnSaveFeedback_Click" ValidationGroup="valFeedback" />
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
    function ShowDialogExport() {
        $('#dlgExport').on('shown.bs.modal', function () {
        });
    }
    function approvedReport() {
        $('#approvedReport').on('shown.bs.modal', function () {
        });
    }

    function delinceReport() {
        $('#reportDelince').on('shown.bs.modal', function () {
        });
    }
    function ShowDialogFeedback() {
        $('#dlgFeedback').on('shown.bs.modal', function () {
        });
    }
    var tabReport = new ddtabcontent("Reporttabs");
    tabReport.setpersist(true);
    tabReport.setselectedClassTarget("link");
    tabReport.currentTabIndex = 0;
    tabReport.init();

    var tabReportAll = new ddtabcontent("tabGeneral");
    tabReportAll.setpersist(true);
    tabReportAll.setselectedClassTarget("link");
    tabReportAll.currentTabIndex = 0;
    tabReportAll.init();

    $(document).ready(function () {
        $("#<%=txtApprovedDate.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });

    });
</script>
