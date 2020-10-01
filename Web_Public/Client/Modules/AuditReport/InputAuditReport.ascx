<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InputAuditReport.ascx.cs"
    Inherits="Client_Modules_AuditReport_InputAuditReport" %>
<%@ Register Src="~/Client/Modules/DataEnergy/InputPlan5Year.ascx" TagName="InputPlan5Year"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/AuditReport/AuditSolutionReport.ascx" TagName="AuditSolution"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/AuditReport/AuditProduct.ascx" TagName="AuditProduct"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/AuditReport/AuditOperationArea.ascx" TagName="AuditOperationArea"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/AuditReport/EnergyConsume.ascx" TagName="EnergyConsume"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/AuditReport/EnergyQuota.ascx" TagName="EnergyQuota"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/AuditReport/ElectrictSystem.ascx" TagName="ElectrictSystem"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/AuditReport/AuditDevice.ascx" TagName="AuditDevice"
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
<div class="row mb10">
    <div class="tab-block mb25">
        <div class="panel panel-blue" style="margin-bottom: 0;">
            <div class="panel-heading">
                <h3 class="panel-title">
                    <span>BÁO CÁO KIỂM TOÁN NĂNG LƯỢNG</span>
                </h3>
            </div>
        </div>
        <div class="tab-content">
            <div class="panel" style="width: 100%">
                <b>THÔNG TIN CHUNG BÁO CÁO</b>
                <div style="float: right">
                    <asp:LinkButton ID="btnEditBasicInfo" runat="server" Text="Thêm kế hoạch" ToolTip="Sửa thông tin"
                        OnClientClick='javascript:ShowDialogInfo(); return false;'><i class="fa fa-edit"></i>&nbsp;Sửa thông tin</asp:LinkButton></div>
            </div>
            <div class="form-horizontal">
                <div class="row">
                    <label class="col-lg-12">
                        1. Thông tin đơn vị tư vấn KTNL<a href="#divInfo" data-toggle="collapse" aria-expanded="true"><i
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
                                    Mã số thuế</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltTaxCode" runat="server"></asp:Literal>
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
                        <tr>
                            <td>
                                <label>
                                    Mã số kiểm soán viên</label>
                            </td>
                            <td>
                                <asp:Literal ID="ltAuditorCode" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <label class="col-lg-12">
                        2. Khu vực được kiểm toán NL<a href="#divScope" data-toggle="collapse" aria-expanded="true"><i
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
                        3. Thời gian thực hiện KTNL<a href="#divTime" data-toggle="collapse" aria-expanded="true"><i
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
                        <b>4. Thiết bị đo kiểm</b><a href="#divQuipment" data-toggle="collapse" aria-expanded="true"><i
                            class="fa fa-angle-down"></i></a>
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddPlan" runat="server" Text="Thêm kết quả thực hiện" ToolTip="Thêm mới"
                                OnClientClick='javascript:ShowDialogAddEquipment(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
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
                                                         
                               <%-- <th style="width: 15%" class="text-center">
                                    Đơn vị
                                </th>--%>
                                <th style="width: 15%" class="text-center">
                                    Số lượng
                                </th>
                                <th style="width: 20%">
                                     Số Serial(SN)
                                </th>  
                                <th style="width: 15%" class="text-center">
                                    Nước sản xuất
                                </th>
                                <th style='width: 10%<%=AllowEdit==false? ";display:none":""%>' class="text-center">
                                    Thao tác
                                </th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rptEquipment" runat="server" OnItemCommand="rptEquipment_ItemCommand"
                            OnItemDataBound="rptEquipment_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%#Eval("DeviceName")%>
                                    </td>
                                    <td class="text-right">
                                        <%#Eval("Quantity")%>
                                    </td>
                                    <td class="text-left">
                                        <%#Eval("SerialNo")%>
                                    </td>
                                   <%-- <td class="text-center">
                                        <%#Eval("Measurement")%>
                                    </td>--%>
                                    
                                    <td>
                                        <%#Eval("MadeIn")%>
                                    </td>
                                    <td class="text-center" <%#AllowEdit==false? "style='display:none'":""%>>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>'
                                            CommandName="delete" CssClass="" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa không???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnEdit" runat="server" CssClass="" ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>'
                                            CommandName="edit"><i class="fa fa-edit"></i></asp:LinkButton>
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
                                <li><a rel="tabStandardEnergy" href="#" class="">Suất tiêu hao</a></li>
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
                                        <tr class="primary fs12">
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
                   <%-- <div class="row">
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
                                <asp:Literal ID="Literal4" runat="server" Text=""></asp:Literal></label>
                            <div class="margin-bottom-10">
                                <table class="table table-bordered table-hover mbn" width="100%">
                                    <thead>
                                        <tr class="primary fs12">
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
            </div>
            
            <div class="row">
                <div class="col-lg-12 text-left">
                    <asp:Button runat="server" ID="btnSend" CssClass="btn btn-sm btn-success mr10" OnClientClick="ShowDialogSend();return false;"
                        data-toggle="modal" data-target="#dlgSend" Text="Hoàn thành lập và Gửi báo cáo"
                        OnClick="btn_Send_Click" ValidationGroup="view" />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Danh-sach-bao-cao-ktnl.aspx"
                        CssClass="btn btn-sm btn-primary mr10" Text="Danh sách" ValidationGroup="view" />
                </div>
            </div>
        </div>
    </div>
</div>
<%--Thong tin chung bao cao--%>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgInfo">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="Literal3" runat="server" Text="Thông tin chung báo cáo"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
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
                        <label class="col-lg-3 control-label">
                            Mã số thuế</label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtMST" runat="server" CssClass="form-control input-sm" ValidationGroup="valGen"></asp:TextBox>
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
                            Mã số kiểm toán viên<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtAuditorCode" runat="server" CssClass="form-control input-sm"
                                ValidationGroup="valGen"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAuditorCode"
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
                        <label class="col-lg-3 control-label" for="inputSmall">
                            File đính kèm</label>
                        <div class="col-lg-9">
                            Chọn file báo cáo đính kèm
                            <asp:FileUpload runat="server" ID="fAttach"></asp:FileUpload>
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
                <asp:Button runat="server" ID="btn_edit2" CssClass="btn btn-sm btn-primary mr10"
                    Text="Cập nhật" OnClick="btn_edit_Click" ValidationGroup="valGen" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgEquipment">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="Literal5" runat="server" Text="Cập nhật thiết bị đo kiểm"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Tên thiết bị<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtEquipmentName" runat="server" CssClass="form-control input-sm"
                                ValidationGroup="valEquipment"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="true" runat="server" ControlToValidate="txtEquipmentName" CssClass="text-danger" Text="Vui lòng nhập tên thiết bị"
                                Display="Dynamic" ValidationGroup="valEquipment" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Số lượng<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control input-sm" ValidationGroup="valEquipment"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  SetFocusOnError="true" runat="server" ControlToValidate="txtQuantity"
                                Display="Dynamic" ValidationGroup="valEquipment" ErrorMessage="RequiredFieldValidator" CssClass="text-danger" Text="Vui lòng nhập số lượng"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvDonGia" runat="server" ControlToValidate="txtQuantity" ValidationGroup="valEquipment"
                                CssClass="text-danger" Text="Số lượng chỉ nhập số" Type="Double" MinimumValue="0"
                                MaximumValue="2147483647 " Display="Dynamic"></asp:RangeValidator>
                        </div>                        
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Số Serial(SN)<%--<span class="append-icon right text-danger">*</span>--%></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtSerialNumber" runat="server" CssClass="form-control input-sm"
                                ValidationGroup="valEquipment"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSerialNumber"
                                Display="Dynamic" ValidationGroup="valEquipment" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>--%>
                        </div>
           
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Nước sản xuất<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtMadeIn" runat="server"  SetFocusOnError="true" CssClass="form-control input-sm" ValidationGroup="valEquipment"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMadeIn" CssClass="text-danger"
                                Display="Dynamic" ValidationGroup="valEquipment" ErrorMessage="RequiredFieldValidator" Text="Vui lòng nhập nước sản xuất"></asp:RequiredFieldValidator>
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
                <asp:Button runat="server" ID="btnSaveEquipment" CssClass="btn btn-sm btn-primary mr10"
                    Text="Lưu lại" OnClick="btnSaveEquipment_Click" ValidationGroup="valEquipment" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgSend">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Gửi báo cáo kiểm toán cho SCT</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            File đính kèm</label>
                        <div class="col-lg-9">
                            <asp:Literal ID="ltAttach" runat="server"></asp:Literal><asp:FileUpload runat="server"
                                ID="fAttachResend"></asp:FileUpload>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="fAttachResend"
                                CssClass="text-danger" ValidationGroup="vgSend" Text="Vui lòng chọn file đính kèm"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Nội dung ý kiến <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtContent" runat="server" CssClass="form-control input-sm" ValidationGroup="vgSend"
                                TextMode="MultiLine" Rows="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtContent"
                                CssClass="text-danger" ValidationGroup="vgSend" Text="Vui lòng nhập nội dung ý kiến"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnResend" runat="server" Visible="true" OnClick="btn_Send_Click"
                    Text="Gửi" CssClass="btn-u btn-u-primary mr10" ValidationGroup="vgSend"></asp:LinkButton>
                <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                    Hủy</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<script type="text/javascript">

    
    function ShowDialogEquipment() {
        $('#dlgEquipment').modal('toggle');
    }
    function ShowDialogAddEquipment() {
        $("#<%=hdnDetailId.ClientID%>").val('');
        $("#<%=txtQuantity.ClientID%>").val('');
        $("#<%=txtEquipmentName.ClientID%>").val('');        
        $("#<%=txtMadeIn.ClientID%>").val('');
        $("#<%=txtSerialNumber.ClientID%>").val('');        
        $('#dlgEquipment').modal('toggle');
    }

    function ShowDialogInfo() {
        $('#dlgInfo').modal('toggle');
    }

    function ShowDialogSend() {
        $('#dlgSend').on('shown.bs.modal', function () {
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


//    $('label').parent().click(function () {
//        if ($('label i').hasClass('fa fa-angle-down')) {
//            $('label').html('<i class="fa fa-angle-up"></i>');
//        }
//        else {
//            $('label').html('<i class="fa fa-angle-down"></i>');
//        }
//    }); 
    
</script>
<asp:Literal ID="ltScript" runat="server"></asp:Literal>
