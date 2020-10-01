<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewAuditReportBCT.ascx.cs"
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
<link type="text/css" href="<%= ResolveUrl("~") %>CSS_Admins/vendor/plugins/c3charts/c3.min.css"
    rel="stylesheet" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>CSS_Admins/vendor/plugins/c3charts/c3.min.js"></script>
<script type="text/javascript" src="<%= ResolveUrl("~") %>CSS_Admins/vendor/plugins/c3charts/d3.min.js"></script>
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
                                <th style="width: 15%">
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
                                <li><a rel="tabReport" href="#" class=""><i class="fa fa-info-circle">&nbsp;</i>CHI TIẾT BÁO CÁO</a></li>
                                <li><a rel="tabKPI" href="#" class=""><i class="fa fa-bar-chart-o">&nbsp;</i>THỐNG KÊ CHỈ TIÊU NĂNG LƯỢNG</a></li>
                                                            
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
                <div id="tabKPI">
                     <div class="row">
                        <div class="col-lg-12 text-center">
                        <b>TỶ LỆ CÁC LOẠI NĂNG LƯỢNG TIÊU THỤ</b>
                        </div>                      
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                             <div id="chartTOE"></div>
                        </div>
                        <div class="col-lg-6">                        
                            <div class="table-responsive">                                                   
                                <table class="table table-bordered table-hover mbn" width="100%">
                                    <thead>
                                        <tr>
                                            <th style="width: 5%">
                                                #
                                            </th>
                                            <th style="width: 35%">
                                                Nhiêu liệu
                                            </th>
                                            <th style="width: 20%">
                                                Năng lượng tiêu thụ (TOE)
                                            </th>
                                            <th style="width: 20%">
                                                Tỷ lệ tiêu thụ NL
                                            </th>
                                            <th style="width: 20%">
                                                Mức phát thải CO2 (Tấn)
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptFuelConsume" runat="server" OnItemDataBound="rptFuelConsume_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%# Container.ItemIndex+1%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("FuelName")%>
                                                    </td>
                                                    <td class="text-right">                                                        
                                                         <%# Tool.ConvertDecimalToString(Eval("NoTOE"), 2)%>
                                                    </td>
                                                    <td  class="text-right">
                                                         <%# TotalTOE>0? Math.Round((Convert.ToDecimal(Eval("NoTOE"))/TotalTOE)*100,1)+"%":""%>
                                                    </td>
                                                    <td  class="text-right">
                                                        <%# Tool.ConvertDecimalToString(Eval("NoCO2"),2)%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                          <td colspan="2">
                                                <b>Tổng</b>
                                            </td>
                                            <td class="text-right">
                                                <b><asp:Literal ID="ltTotalTOE" runat="server"></asp:Literal></b>
                                            </td>
                                            <td class="text-right">
                                                        
                                            </td>
                                            <td  class="text-right">
                                                <b><asp:Literal ID="ltTotaCO2" runat="server"></asp:Literal></b>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>                     
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 text-center">
                        <b>TỶ LỆ CÁC LOẠI NĂNG LƯỢNG TRONG NĂNG LƯỢNG TIẾT KIỆM</b>
                        </div>                      
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div id="chartSaveTOE"></div>
                        </div>
                        <div class="col-lg-6">                        
                            <div class="table-responsive">                                                   
                                <table class="table table-bordered table-hover mbn" width="100%">
                                    <thead>
                                        <tr>
                                            <th style="width: 5%">
                                                #
                                            </th>
                                            <th style="width: 35%">
                                                Nhiêu liệu
                                            </th>
                                            <th style="width: 15%">
                                                Năng lượng tiêu thụ (TOE)
                                            </th>
                                            <th style="width: 15%">
                                                Tỷ lệ
                                            </th>
                                            <th style="width: 15%">
                                                Tỷ lệ NL tiết kiệm/Tổng NL tiêu thụ
                                            </th>
                                            <th style="width: 15%">
                                                Mức phát thải CO2 (Tấn)
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptSaveFuel" runat="server"  OnItemDataBound="rptSaveFuel_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <%# Container.ItemIndex+1%>
                                                    </td>
                                                    <td>
                                                        <%# Eval("FuelName")%>
                                                    </td>
                                                    <td class="text-right">                                                        
                                                        <%# Tool.ConvertDecimalToString(Eval("NoTOE"), 2)%>
                                                    </td>
                                                    <td  class="text-right">
                                                        <%# TotalTOES > 0 ? Math.Round((Convert.ToDecimal(Eval("NoTOE")) / TotalTOES) * 100, 1) : Math.Round(Convert.ToDecimal(Eval("NoTOE")) * 100, 1)%>%
                                                    </td>
                                                    <td  class="text-right">
                                                        <%# TotalTOE>0? Math.Round((Convert.ToDecimal(Eval("NoTOE"))/TotalTOE)*100,1):Math.Round(Convert.ToDecimal(Eval("NoTOE"))*100,1)%>%
                                                    </td>
                                                    <td  class="text-right">
                                                        <%# Tool.ConvertDecimalToString(Eval("NoCO2"),2)%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>                                            
                                        </asp:Repeater>
                                        <tr>
                                          <td colspan="2">
                                                <b>Tổng</b>
                                            </td>
                                            <td class="text-right">
                                                <b><asp:Literal ID="ltTotalTOES" runat="server"></asp:Literal></b>
                                            </td>
                                            <td class="text-right">
                                               
                                            </td>
                                            <td class="text-right">
                                               <asp:Literal ID="ltRateSave" runat="server"></asp:Literal>         
                                            </td>
                                            <td  class="text-right">
                                                <b><asp:Literal ID="ltTotalCO2S" runat="server"></asp:Literal></b>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>                     
                            </div>
                        </div>
                    </div>   
                            
                </div>
               
            </div>
        </div>
    </div>
</div>
</section>
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

    var chart = c3.generate({
        bindto: '#chartTOE',
        data: {
            // iris data from R
            columns: [
            <%= DataTOE %>
        ],
            type: 'pie',
            onclick: function (d, i) { console.log("onclick", d, i); },
            onmouseover: function (d, i) { console.log("onmouseover", d, i); },
            onmouseout: function (d, i) { console.log("onmouseout", d, i); }
        }
    });
    


    var chartSaveTOE = c3.generate({
        bindto: '#chartSaveTOE',
        data: {
            // iris data from R
            columns: [            
             <%= DataSaveTOE %>
        ],
            type: 'pie',
            onclick: function (d, i) { console.log("onclick", d, i); },
            onmouseover: function (d, i) { console.log("onmouseover", d, i); },
            onmouseout: function (d, i) { console.log("onmouseout", d, i); }
        }
    });
   
</script>
