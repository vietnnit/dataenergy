<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Product5Year21.ascx.cs"
    Inherits="Client_Modules_DataEnergy_Product5Year21" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Client/Modules/DataEnergy/InputPlan5Year.ascx" TagName="InputPlan5Year"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/DataEnergy/DetailPlanYear.ascx" TagName="DetailPlanYear"
    TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/DataEnergy/ProductYear.ascx" TagName="ProductYear"
    TagPrefix="uc1" %>
<asp:HiddenField ID="hdnNewsUrl" Value="" runat="server" />
<asp:HiddenField ID="hdnReport" Value="" runat="server" />
<asp:HiddenField ID="hdnNextYear" Value="" runat="server" />
<asp:HiddenField ID="hdnDetailId" Value="" runat="server" />
<asp:ScriptManager ID="scriptServer" runat="server"></asp:ScriptManager>
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
                    <span>KẾ HOẠCH 5 NĂM</span>
                </h3>
            </div>
        </div>
        <div class="tab-content">
            <div class="panel" style="width: 100%" for="inputSmall">
                <b>THÔNG TIN CHUNG BÁO CÁO</b>
                <div style="float: right">
                    <asp:LinkButton ID="btnEditBasicInfo" runat="server" Text="Thêm kế hoạch" ToolTip="Sửa thông tin"
                        OnClientClick='javascript:showformInfo(); return false;'><i class="fa fa-edit"></i>&nbsp;Sửa thông tin</asp:LinkButton>
                </div>
            </div>
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-lg-2" for="inputSmall">
                        Kỳ kế hoạch</label>
                    <div class="col-lg-10">
                        <asp:Literal ID="ltReportYear" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2" for="inputSmall">
                        Người lập báo cáo</label>
                    <div class="col-lg-4">
                        <asp:Literal ID="ltReporter" runat="server"></asp:Literal>
                    </div>
                    <%-- </div>
                <div class="form-group">--%>
                    <label class="col-lg-2" for="inputSmall">
                        Ngày báo cáo</label>
                    <div class="col-lg-4">
                        <asp:Literal ID="ltReportDate" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="panel">
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Tên DN</label>
                        <div class="col-lg-10">
                            <asp:Literal ID="ltEnterpriseName" runat="server"></asp:Literal>&nbsp;&nbsp;<a href="#EnterpriseInfo"
                                data-toggle="collapse" aria-expanded="false"><i class="fa fa-chevron-down"></i></a>
                        </div>
                    </div>
                    <div id="EnterpriseInfo" class="collapse">
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Lĩnh vực</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltAreaName" runat="server"></asp:Literal>
                            </div>
                            <%-- </div>                 
                                <div class="form-group">--%>
                            <label class="col-lg-2" for="inputSmall">
                                Phân ngành</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltSubAreaName" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Tỉnh/TP</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltProvinceName" runat="server"></asp:Literal>
                            </div>
                            <%--</div>                 
                                <div class="form-group">--%>
                            <label class="col-lg-2" for="inputSmall">
                                Quận/Huyện</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltDistrictName" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Mã số thuế</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltTaxNo" runat="server"></asp:Literal>
                            </div>
                            <%--</div>
                            <div class="form-group">--%>
                            <label class="col-lg-2" for="inputSmall">
                                Email</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltEmail" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Địa chỉ</label>
                            <div class="col-lg-10">
                                <asp:Literal ID="ltAddress" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Số điện thoại</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltPhoneNumber" runat="server"></asp:Literal>
                            </div>
                            <%--</div>  
                                <div class="form-group">--%>
                            <label class="col-lg-2" for="inputSmall">
                                Fax</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltFaxNo" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Chịu trách nhiệm</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltResponsible" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Chủ sở hữu</label>
                            <div class="col-lg-10">
                                <asp:Literal ID="ltOwner" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-6" for="inputSmall">
                                Cơ sở đã áp dụng mô hình quản lý năng lượng chưa</label>
                            <div class="col-lg-5">
                                <div class="form-check">
                                    <asp:CheckBox ID="cbMoHinhQLNL_ChuaAD" runat="server" class="form-check-input" />
                                    <label class="form-check-label" style="font-weight: normal;" for="cbMoHinhQLNL_ChuaAD">Chưa áp dụng</label>
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="cbMoHinhQLNL_DaAD" runat="server" class="form-check-input" />
                                    <label class="form-check-label" style="font-weight: normal;" for="cbMoHinhQLNL_DaAD">Đã áp dụng mô hình quản lý năng lượng</label>
                                </div>
                                <div class="form-check">
                                    <asp:CheckBox ID="cbMoHinhQLNL_DaAD_ISO" runat="server" class="form-check-input" />
                                    <label class="form-check-label" style="font-weight: normal;" for="cbMoHinhQLNL_DaAD_ISO">Đã áp dụng mô hình QLNL theo TCVN:ISO 50001</label>
                                </div>
                            </div>
                        </div>

                        <div class="panel">
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Công ty mẹ
                            </label>
                            <div class="col-lg-10">
                                <asp:Literal ID="ltParentName" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Tỉnh/TP</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltProvinceParent" runat="server"></asp:Literal>
                            </div>
                            <%-- </div>                 
                                <div class="form-group">--%>
                            <label class="col-lg-2" for="inputSmall">
                                Quận/Huyện</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltDistrictParent" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Địa chỉ</label>
                            <div class="col-lg-10">
                                <asp:Literal ID="ltAddressParent" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Số điện thoại</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltPhoneParent" runat="server"></asp:Literal>
                            </div>
                            <%--</div>  
                                <div class="form-group">--%>
                            <label class="col-lg-2" for="inputSmall">
                                Fax</label>
                            <div class="col-lg-4">
                                <asp:Literal ID="ltFaxParent" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-2" for="inputSmall">
                                Email</label>
                            <div class="col-lg-10">
                                <asp:Literal ID="ltEmailParent" runat="server"></asp:Literal>
                            </div>
                        </div>
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
                                <li><a rel="tabHistory" href="#" class=""><i class="fa fa-comments-o">&nbsp;</i>Ý KIẾN, PHẢN HỒI PHÊ DUYỆT</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div id="tabReport">
                    <div class="row">
                        <div class="col-lg-12">
                            <ul class="nav nav-tabs tabs-border" id="Reporttabs">
                                <li><a rel="tabProduct" href="#" class="active">Cơ sở hạ tầng và sản phẩm</a></li>
                                <li><a rel="tabData" href="#" class="" style="display:none;" >Mức nhiên liệu tiêu thụ năm</a></li>
                                <li><a rel="tabPlan" href="#" class="" style="display:none;">Giải pháp TKNL năm</a></li>
                                <li><a rel="tabPlan5Year" href="#" class="">Giải pháp TKNL 5 năm</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="tabChuyen">
                        <div class="" style="border-top: 0">
                            <div id="tabProduct">
                                <uc1:ProductYear ID="ucProduct" runat="server" Visible="false" />
                                <div class="col-lg-12">
                                    <label class="control-label">
                                        <asp:Literal ID="Literal7" runat="server" Text="1. Năng lực sản xuất của cơ sở"></asp:Literal>
                                        <asp:Literal ID="ltRp5_NangLucSXNamCoSo" runat="server"></asp:Literal>
                                    </label>
                                    <div class="margin-bottom-10">
                                        <table class="table table-bordered table-hover mbn" width="100%">
                                            <thead>
                                                <tr class="primary fs12">
                                                    <th style="width: 15%">Tên sản phẩm
                                                    </th>
                                                    <th style="width: 10%">Đơn vị đo
                                                    </th>
                                                    <th style="width: 15%">Theo thiết kế
                                                    </th>
                                                    <th style="width: 20%">Mức sản xuất hiện tại
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptProductResult" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <%# Eval("ProductName")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("Measurement")%>
                                                            </td>
                                                            <td class="text-right">
                                                                <%# Eval("DesignQuantity")%>
                                                            </td>
                                                            <td class="text-right">
                                                                <%# Eval("MaxQuantity")%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div id="tabData" class="" style="display:none;">
                                <div class="form-horizontal">
                                    <div class="form-group" style="display: none;">
                                        <div class="col-lg-12">
                                            <div class="control-label pt5" style="width: 100%">
                                                <asp:Literal ID="ltDataCurrentTitle" runat="server"></asp:Literal><div style="float: right">
                                                    <asp:LinkButton ID="btnAddFuel" runat="server" Text="Nhập số liệu" data-toggle="modal"
                                                        data-target="#dlgFuelConsume" ToolTip="Thêm báo cáo" OnClientClick='javascript:addReportDetail(0); return 0;'><i class="fa fa-plus"></i>&nbsp;Thêm nhiên liệu</asp:LinkButton>
                                                </div>
                                            </div>
                                            <table class="table table-bordered table-hover mbn" width="100%">
                                                <tr class="primary fs12">
                                                    <th style="width: 5%">STT
                                                    </th>
                                                    <th style="width: 15%">Nhiên liệu
                                                    </th>
                                                    <th style="width: 10%">Mức tiêu thụ
                                                    </th>
                                                    <th style="width: 10%">Đơn vị tính
                                                    </th>
                                                    <th style="width: 10%">Giá (đồng)
                                                    </th>
                                                    <%--<th style="width: 10%">
                                                    Hệ số TOE
                                                </th>--%>
                                                    <th style="width: 10%">Năng lượng tiêu thụ (TOE)
                                                    </th>
                                                    <th style="width: 30%">Mục đích sử dụng
                                                    </th>
                                                    <th style="width: 10%">Thao tác
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
                                                                <%#Eval("NoFuel") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NoFuel"),2) : ""%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("MeasurementName")%>
                                                            </td>
                                                            <td style="text-align: right">
                                                                <%#Eval("Price") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Price"),0) : ""%>
                                                            </td>
                                                            <td style="text-align: right">
                                                                <%#Eval("NoFuel_TOE") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NoFuel_TOE"),2) : ""%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Reason")%>
                                                            </td>
                                                            <td style="text-align: center">
                                                                <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%#Eval("Id") %>'
                                                                    CssClass="fa fa-times" ToolTip="Xóa" OnClientClick="return javascript:confirm('Bạn chắc chắn muốn xóa không');"></asp:LinkButton>
                                                                <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEditDetail_Click" CssClass="fa fa-edit"
                                                                    ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                            <div style="text-align: right">
                                                <b>
                                                    <asp:Literal ID="ltTotal_TOE" runat="server"></asp:Literal></b>
                                            </div>
                                            <%--<asp:LinkButton ID="btnAddFuel" runat="server" Text="Thêm nhiên liệu" CssClass="btn btn-sm btn-primary mr10"></asp:LinkButton>--%>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-12">
                                            <div class="control-label pt5" style="width: 100%">
                                                <asp:Literal ID="ltDataNextYearTitle" runat="server"></asp:Literal><div style="float: right">
                                                    <asp:LinkButton ID="btnAddFuelFuture" runat="server" Text="Nhập số liệu" data-toggle="modal"
                                                        data-target="#dlgFuelConsume" ToolTip="Thêm nhiên liệu" OnClientClick='javascript:addReportDetail(1); return 0;'><i class="fa fa-plus"></i>&nbsp;Thêm nhiên liệu</asp:LinkButton>
                                                </div>
                                            </div>
                                            <asp:Literal ID="ltNoFuelFuture" runat="server"></asp:Literal>
                                            <table class="table table-bordered table-hover mbn" width="100%">
                                                <tr class="primary fs12">
                                                    <th style="width: 5%">STT
                                                    </th>
                                                    <th style="width: 20%">Loại năng lượng
                                                    </th>
                                                    <th style="width: 15%">Đơn vị tính
                                                    </th>
                                                    <th style="width: 15%">Lượng tiêu thụ
                                                    </th>
                                                    <%--    <th style="width: 10%">Giá dự kiến (đồng)
                                                    </th>--%>

                                                    <%--<th style="width: 10%">Năng lượng tiêu thụ (TOE)
                                                    </th>--%>
                                                    <th>Ghi chú
                                                    </th>
                                                    <th style="width: 10%">Thao tác
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

                                                            <td>
                                                                <%#Eval("MeasurementName")%>
                                                            </td>
                                                            <td style="text-align: right">
                                                                <%#Eval("NoFuel") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NoFuel"),2) : ""%>
                                                            </td>
                                                            <%--<td style="text-align: right">
                                                                <%#Eval("Price") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Price"),0) : ""%>
                                                            </td>--%>

                                                            <%--   <td style="text-align: right">
                                                                <%#Eval("NoFuel_TOE") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NoFuel_TOE"),2) : ""%>
                                                            </td>--%>
                                                            <td>
                                                                <%#Eval("Reason")%>
                                                            </td>
                                                            <td style="text-align: center">
                                                                <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%#Eval("Id") %>'
                                                                    CssClass="fa fa-times" ToolTip="Xóa" OnClientClick="return javascript:confirm('Bạn chắc chắn muốn xóa không');"></asp:LinkButton>
                                                                <asp:LinkButton ID="btnEdit" OnClick="btnEditDetail_Click" runat="server" CssClass="fa fa-edit"
                                                                    ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>

                                            <%--<asp:LinkButton ID="btnAddFuelFuture" runat="server" Text="Thêm nhiên liệu" CssClass="btn btn-sm btn-primary mr10"></asp:LinkButton>--%>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="control-label pt5" style="width: 100%">
                                                <asp:Literal ID="ltKeHoachTieuThuDien" runat="server" Text="Tiêu thụ điện"></asp:Literal>
                                                <div style="float: right">
                                                    <a href="#" data-target="#dlgTieuThuSXDien" data-toggle="modal"><i class="fa fa-plus"></i>&nbsp;Nhập số liệu</a>
                                                    <asp:LinkButton ID="LinkButton1" Visible="false" runat="server" Text="Thêm nhiên liệu" data-toggle="modal"
                                                        data-target="#dlgTieuThuSXDien" ToolTip="Sửa thông tin" OnClientClick='javascript:openDlgTieuThuSXDien(); return 0;'><i class="fa fa-plus"></i>&nbsp;Nhập số liệu</asp:LinkButton>
                                                </div>
                                            </div>
                                            <asp:Literal ID="ltTieuThuDien" runat="server"></asp:Literal>
                                        </div>
                                        <div class="col-lg-12" style="text-align: right; margin-top: 10px; margin-right: 10px;">
                                            <b>
                                                <asp:Literal ID="ltTotal_TOE_Future" runat="server"></asp:Literal></b>
                                        </div>
                                    </div>
                                    <asp:Literal ID="error" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div id="tabPlan" style="display:none;">
                                <uc1:DetailPlanYear ID="ucDetailPlanYear" runat="server" Visible="false" />
                            </div>
                            <div id="tabPlan5Year">
                                <uc1:InputPlan5Year ID="ucInputPlan5Year" runat="server" Visible="true" />
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
                                            <th style="width: 15%">Hoạt động
                                            </th>
                                            <th style="width: 60%">Nội dung
                                            </th>
                                            <%-- <th style="width: 15%">
                                                Trạng thái
                                            </th>--%>
                                            <th style="width: 15%">Thời gian cập nhật
                                            </th>
                                            <th style="width: 10%">Người cập nhật
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
                        <div class="col-lg-12 text-right">
                            <asp:LinkButton runat="server" ID="lbtSendFeeback" CssClass="btn btn-sm btn-success mr10"
                                OnClientClick="ShowDialogFeedback();return false;" data-toggle="modal" data-target="#dlgFeedback"
                                Text="Gửi ý kiến" ValidationGroup="view"><i class="fa fa-comment"></i>&nbsp;Gửi ý kiến</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div id="tabAttachFile">
                    <%-- <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            File báo cáo gửi kèm</label>
                    </div>--%>
                    <div class="row">
                        <div class="col-lg-12">
                            <label class="control-label">
                                <asp:Literal ID="Literal4" runat="server" Text=""></asp:Literal></label>
                            <div class="margin-bottom-10">
                                <table class="table table-bordered table-hover mbn" width="100%">
                                    <thead>
                                        <tr class="primary fs12">
                                            <th style="width: 25%">Tên file
                                            </th>
                                            <th style="width: 50%">Ghi chú
                                            </th>
                                            <th style="width: 15%">Thời gian cập nhật
                                            </th>
                                            <th>Người cập nhật
                                            </th>
                                            <th>Tải về
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
                    <div class="col-lg-12 text-left">
                        <asp:LinkButton runat="server" ID="btnExportWord" CssClass="btn btn-sm btn-success mr10"
                            Text="Xuất báo cáo hàng năm" Style="display: none;" OnClientClick="ShowDialogExportword();return false;"
                            data-toggle="modal" data-target="#dlgExportReport"><i class="fa fa-file-word-o"></i>&nbsp;Xuất báo cáo hàng năm</asp:LinkButton>
                        <asp:LinkButton  runat="server" ID="btnExport5Word" CssClass="btn btn-sm btn-success mr10"
                            Visible="true" Text="Xuất báo cáo 5 năm" OnClientClick="ShowDialogExportword();return false;"
                            data-toggle="modal" data-target="#dlgExportReport5"><i class="fa fa-file-word-o"></i>&nbsp;Xuất báo cáo 5 năm</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnReSend" CssClass="btn btn-sm btn-danger mr10"
                            OnClientClick="ShowDialogResend();return false;" data-toggle="modal" data-target="#dlgResend"
                            Text="Hoàn thành và Gửi SCT" OnClick="btnReSend_Click" ValidationGroup="view"><i class="fa fa-send-o"></i>&nbsp;Hoàn thành và Gửi SCT</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btnSend" CssClass="btn btn-sm btn-danger mr10"
                            OnClientClick="ShowDialogSend();return false;" data-toggle="modal" data-target="#dlgSend"
                            Text="Hoàn thành lập và Gửi báo cáo" OnClick="btnSend_Click" ValidationGroup="view"><i class="fa fa-send-o"></i>&nbsp;Hoàn thành lập và Gửi báo cáo</asp:LinkButton>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/doanh-nghiep-5-nam.aspx" CssClass="btn btn-sm btn-primary mr10"
                            Text="Danh sách" ValidationGroup="view" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<%--Thong tin chung bao cao--%>
<div class="modal fade" tabindex="-1" role="dialog" id="frmInfo">
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
                        <label class="col-lg-2 col-md-2 col-sm-2" for="inputSmall">
                            Kế hoạch năm <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4 col-md-10 col-sm-10">
                            <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" Enabled="false"
                                CssClass="form-control input-sm" ValidationGroup="view">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlYear"
                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-2 col-md-2 col-sm-2" for="inputSmall">
                            Ngày báo cáo <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <div class="input-group  input-group-sm">
                                <asp:TextBox ID="txtReportDate" Enabled="false" runat="server" CssClass="form-control input-sm"
                                    ValidationGroup="view" MaxLength="10"></asp:TextBox>
                                <span class="input-group-addon field-icon"><i class="fa fa-calendar"></i></span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="view"
                                    ControlToValidate="txtReportDate" Display="Dynamic" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="form-group" style="clear: both; margin-bottom: 10px">
                        <label class="ol-lg-2 col-md-2 col-sm-2" for="inputSmall">
                            Người lập BC <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4 col-md-10 col-sm-10">
                            <asp:TextBox ID="txtReportName" runat="server" CssClass="form-control input-sm" placeholder="Nhập người báo cáo tối đa 50 ký tự"
                                MaxLength="50" ValidationGroup="valGen"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReportName"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Cơ sở/DN <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtEnterpriseName" Enabled="false" runat="server" CssClass="form-control input-sm"
                                placeholder="Cơ sở/Doanh nghiêp" ValidationGroup="valGen"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEnterpriseName"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Lĩnh vực <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                                CssClass="form-control input-sm" ValidationGroup="valGen" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlArea"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                        <%-- </div>                 
                                <div class="form-group">--%>
                        <label class="col-lg-2" for="inputSmall">
                            Phân ngành <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlSubArea" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="view">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlSubArea"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Tỉnh/TP <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlProvince" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                AutoPostBack="true" ValidationGroup="valGen" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProvince"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                        <%--</div>                 
                                <div class="form-group">--%>
                        <label class="col-lg-2" for="inputSmall">
                            Quận/Huyện <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlDistrict" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="view">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDistrict"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Mã số thuế <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtMST" runat="server" CssClass="form-control input-sm" placeholder="Nhập mã số thuế tối đa 50 ký tự"
                                MaxLength="50" ValidationGroup="view" Enabled="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMST"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                        <%--</div>
                            <div class="form-group">--%>
                        <label class="col-lg-2" for="inputSmall">
                            Email</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm" placeholder="Nhập Email tối đa 50 ký tự"
                                MaxLength="50" ValidationGroup="view"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Địa chỉ</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm" placeholder="Nhập địa chỉ tối đa 255 ký tự"
                                MaxLength="255" ValidationGroup="view"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Số điện thoại</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-sm" placeholder="Nhập số điện thoại tối đa 255 ký tự"
                                MaxLength="50" ValidationGroup="view"></asp:TextBox>
                        </div>
                        <%--</div>  
                                <div class="form-group">--%>
                        <label class="col-lg-2" for="inputSmall">
                            Số Fax</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtFax" runat="server" CssClass="form-control input-sm" placeholder="Nhập số Fax tối đa 255 ký tự"
                                MaxLength="50" ValidationGroup="view"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Chịu trách nhiệm <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtResponsible" runat="server" CssClass="form-control input-sm"
                                placeholder="Nhập người chịu trách nhiệm tối đa 255 ký tự" MaxLength="50" ValidationGroup="valGen"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtResponsible"
                                Display="Dynamic" ValidationGroup="valGen" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Chủ sở hữu</label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlOwner" ValidationGroup="vgInfo" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem Text="Thành phần kinh tế khác" Value="0" Selected="True">
                                </asp:ListItem>
                                <asp:ListItem Text="Doanh nghiệp nhà nước" Value="1">
                                </asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="valGen"
                                runat="server" ControlToValidate="ddlOwner" Display="Dynamic" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <hr class="hr" />
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Công ty mẹ
                        </label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtParentName" runat="server" CssClass="form-control input-sm" placeholder="Nhập Công ty mẹ tối đa 255 ký tự"
                                MaxLength="255" ValidationGroup="valGen"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Tỉnh/TP</label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlProvinceReporter" runat="server" AppendDataBoundItems="True"
                                AutoPostBack="true" CssClass="form-control input-sm" ValidationGroup="view" OnSelectedIndexChanged="ddlProvinceReporter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <%-- </div>                 
                                <div class="form-group">--%>
                        <label class="col-lg-2" for="inputSmall">
                            Quận/Huyện</label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlDistrictReporter" runat="server" AppendDataBoundItems="True"
                                CssClass="form-control input-sm" ValidationGroup="view">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Địa chỉ</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtAddressReporter" runat="server" CssClass="form-control input-sm"
                                placeholder="Nhập Địa chỉ tối đa 255 ký tự" MaxLength="255" ValidationGroup="view"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Số điện thoại</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtPhoneReporter" runat="server" CssClass="form-control input-sm"
                                placeholder="Nhập số điện thoại tối đa 50 ký tự" MaxLength="50" ValidationGroup="view"></asp:TextBox>
                        </div>
                        <%--</div>  
                                <div class="form-group">--%>
                        <label class="col-lg-2" for="inputSmall">
                            Số Fax</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtFaxReporter" runat="server" CssClass="form-control input-sm"
                                placeholder="Nhập Số Fax tối đa 50 ký tự" MaxLength="50" ValidationGroup="view"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Email</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtEmailReporter" runat="server" CssClass="form-control input-sm"
                                placeholder="Nhập Email tối đa 50 ký tự" MaxLength="50" ValidationGroup="view"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12 text-left">
                            <i>Ghi chú: Những thông tin có dấu <span class="append-icon right text-danger">*</span>
                                là những thông tin bắt buộc phải nhập hoặc phải chọn</i>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btn_edit2" CssClass="btn btn-sm btn-primary mr10"
                        Text="Cập nhật" OnClick="btn_edit_Click" ValidationGroup="valGen" />
                    <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                        Đóng</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgFuelConsume">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="ltTitle" runat="server" Text="Tình hình sử dụng nhiên liệu"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <h3>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></h3>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Loại nhiên liệu <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlFuel" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="viewFuelOne" AutoPostBack="true" OnSelectedIndexChanged="ddlFuel_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlFuel"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng chọn nhiên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Đơn vị tính <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="update_ddlMeasure" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger EventName="SelectedIndexChanged" ControlID="ddlFuel" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMeasure" runat="server" AppendDataBoundItems="True" ValidationGroup="viewFuelOne"
                                        AutoPostBack="true" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlMeasure_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:RequiredFieldValidator ID="rfvMeasurement" runat="server" ControlToValidate="ddlMeasure"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng chọn đơn vị tính"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3" for="inputSmall">
                            Lượng tiêu thụ<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtNoFuel" runat="server" CssClass="form-control input-sm" ValidationGroup="viewFuelOne"
                                MaxLength="20" placeholder="Lượng tiêu thụ tối đa 20 ký tự"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtNoFuel"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng nhập Lượng tiêu thụ"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RangeValidator1" runat="server" ControlToValidate="txtNoFuel"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Lượng tiêu thụ chỉ nhập số"
                                ValidationExpression="^[0-9]{1,18}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Đơn giá(<i>đồng</i>)</label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control input-sm" placeholder="Nhập tối đa 15 ký tự"
                                MaxLength="15" ValidationGroup="viewFuelOne"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrice"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Đơn giá nhập số và từ 0 đến 9.999.999.999.999,99"
                                ValidationExpression="^[0-9]{1,13}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-3" for="inputSmall">
                            Hệ số chuyển đổi(TOE)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="update_txtNoTOE" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlMeasure" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox ID="txtNoTOE" runat="server" CssClass="form-control input-sm" ValidationGroup="viewFuelOne"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtNoTOE"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng nhập hệ số chuyển đổi TOE"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvNoTOE" MaximumValue="10" Type="Double" MinimumValue="0"
                                CssClass="text-danger" ControlToValidate="txtNoTOE" ValidationGroup="viewFuelOne"
                                runat="server" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mục đích sử dụng <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtPropose" runat="server" CssClass="form-control input-sm" ValidationGroup="viewFuelOne"
                                MaxLength="255" placeholder="Mục đích sử dụng tối đa 255 ký tự"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPropose"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng mục đích sử dụng"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnSaveFuel" CssClass="btn btn-sm btn-primary mr10"
                    Text="Lưu lại" OnClick="btnSaveFuel_Click" ValidationGroup="viewFuelOne" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgExportReport">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Lựa chọn mẫu báo cáo hàng năm</h4>
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
                <asp:LinkButton ID="btnExport" runat="server" Visible="true" OnClick="btnExport_Click"
                    Text="Xuất báo cáo" CssClass="btn-u btn-u-primary mr10"></asp:LinkButton>
                <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgExportReport5">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Chọn mẫu báo cáo 5 năm</h4>
            </div>
            <div class="modal-body">
                <section class="mbn">
                    <label class="select">
                        <asp:DropDownList runat="server" ID="ddlReportType5">
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
                <asp:LinkButton ID="btnExport5" runat="server" Visible="true" OnClick="btnExport5_Click"
                    Text="Xuất báo cáo" CssClass="btn-u btn-u-primary mr10"></asp:LinkButton>
                <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgSend">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Gửi báo cáo</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group" style="display: none;">
                        <div class="col-lg-3">
                            File báo cáo hàng năm
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9">
                            <asp:FileUpload runat="server" ID="fAttach"></asp:FileUpload>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="fAttach"
                                CssClass="text-danger" ValidationGroup="vgSend" Text="Vui lòng chọn file báo cáo hàng năm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3">
                            File báo cáo 5 năm
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9">
                            <asp:FileUpload runat="server" ID="fAttach5year"></asp:FileUpload>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="fAttach5year"
                                CssClass="text-danger" ValidationGroup="vgSend" Text="Vui lòng chọn file báo cáo 5 năm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3">
                            Nội dung ý kiến <span class="append-icon right text-danger">*</span>
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9">
                            <asp:TextBox runat="server" class="form-control" ID="txtContent" TextMode="MultiLine"
                                MaxLength="500" ValidationGroup="vgSend" Rows="3" placeholder="Mục đích sử dụng tối đa 500 ký tự"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtContent"
                                CssClass="text-danger" ValidationGroup="vgSend" Text="Vui lòng nhập nội dung ý kiến"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="btnSaveSend" runat="server" Visible="true" OnClick="btnSend_Click"
                        Text="Gửi" CssClass="btn-u btn-u-primary mr10"></asp:LinkButton>
                    <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                        Hủy</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgResend">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Bổ sung báo cáo</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group" style="display:none;">
                        <div class="col-lg-3">
                            File báo cáo hàng năm
                        </div>
                        <div class="col-lg-9">
                            <asp:FileUpload runat="server" ID="fAttachResend"></asp:FileUpload>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="fAttachResend"
                                CssClass="text-danger" ValidationGroup="valResend" Text="Vui lòng chọn file báo cáo hàng năm"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3">
                            File 5 năm
                        </div>
                        <div class="col-lg-9">
                            <asp:FileUpload runat="server" ID="fAttachResend5"></asp:FileUpload>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="fAttachResend5"
                                CssClass="text-danger" ValidationGroup="valResend" Text="Vui lòng chọn file báo cáo 5 năm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Nội dung ý kiến <span class="append-icon
right text-danger">*</span></label>
                        <div class="col-lg-9 col-md-9 col-sm-9">
                            <asp:TextBox runat="server" class="form-control" ID="txtNote" TextMode="MultiLine"
                                MaxLength="500" ValidationGroup="valResend" Rows="3" placeholder="Mục đích sử dụng tối đa 500 ký tự"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNote"
                                CssClass="text-danger" ValidationGroup="valResend" Text="Vui lòng nhập nội dung ý kiến"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveResend" runat="server" Visible="true" OnClick="btnReSend_Click"
                    Text="Gửi" CssClass="btn-u
btn-u-primary mr10"
                    ValidationGroup="valResend"></asp:LinkButton>
                <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                    Hủy</button>
            </div>
        </div>
        <!--
/.modal-content -->
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
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Nội dung ý kiến <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox ID="txtFeedback" runat="server" CssClass="form-control input-sm" ValidationGroup="valFeedback"
                                TextMode="MultiLine" Rows="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtFeedback"
                                CssClass="text-danger" ValidationGroup="valFeedback" Text="Vui lòng nhập nội dung ý kiến"
                                Display="Dynamic"></asp:RequiredFieldValidator>
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
                <asp:LinkButton runat="server" ID="btnSaveFeedback" CssClass="btn btn-sm btn-primary mr10"
                    Text="Gửi" OnClick="btnSaveFeedback_Click" ValidationGroup="valFeedback"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>

<%--dialog cap nhat Tiêu thụ điện--%>
<div class="modal" tabindex="-1" role="dialog" id="dlgTieuThuSXDien" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Kế hoạch mua điện và điện tự sản xuất</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <asp:UpdatePanel ID="updateTieuThuSXDien" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btBindTieuThuSXDien" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="ddlElectrictTechnology" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="btnSaveElectrictPlan" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <tbody>
                                    <tr class="primary fs12">
                                        <td style="width: 10%">Điện năng mua từ lưới
                                        </td>
                                        <td style="width: 10%">Công suất đăng ký (kW)<span class="append-icon right text-danger">*</span>:
                                    <asp:TextBox ID="txtDienDkMua" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtDienDkMua" CssClass="text-danger"
                                                ValidationGroup="valElectrictPlan" Text="Vui lòng nhập công suất" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtDienDkMua"
                                                CssClass="text-danger" ValidationGroup="valElectrictPlan" Text="Chỉ nhập số"
                                                ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="width: 10%;" colspan="2">Điện năng (10<sup>6</sup> kWh/năm)<span class="append-icon right text-danger">*</span>:
                                    <asp:TextBox ID="txtDienTieuThu" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtDienTieuThu" CssClass="text-danger"
                                                ValidationGroup="valElectrictPlan" Text="Vui lòng nhập điện năng mua ngoài" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtDienTieuThu"
                                                CssClass="text-danger" ValidationGroup="valElectrictPlan" Text="Chỉ nhập số"
                                                ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Điện năng bán ra(nếu có)
                                        </td>
                                        <td>Công suất bán ra(kW)
                                    <asp:TextBox ID="txtCongSuaBanRa" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                ControlToValidate="txtCongSuaBanRa" CssClass="text-danger"
                                                Text="Chỉ nhập số" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>Sản lượng bán ra(10<sup>6</sup> kWh/năm)
                                    <asp:TextBox ID="txtSanLuongBanRa" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                ControlToValidate="txtSanLuongBanRa" CssClass="text-danger"
                                                Text="Chỉ nhập số" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td rowspan="3">Điện tự sản xuất(nếu có)
                                        </td>
                                        <td>Công nghệ
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlElectrictTechnology" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlElectrictTechnology_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Công suất lắp đặt (kW)
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInstalledCapacityPlan" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                ControlToValidate="txtInstalledCapacityPlan" CssClass="text-danger" ValidationGroup="valElectrictPlan"
                                                Text="Chỉ nhập số" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Điện năng sản xuất (10<sup>6</sup> kWh/năm)
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtProduceQty" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                ControlToValidate="txtProduceQty" CssClass="text-danger" ValidationGroup="valElectrictPlan"
                                                Text="Chỉ nhập số" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>

                                </tbody>
                            </table>
                            <div style="width: 100%; text-align: center; padding-top: 10px;">
                                <label style="color: forestgreen" id="update_message">
                                    <asp:Literal ID="ltmsg" runat="server"></asp:Literal>
                                </label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveElectrictPlan" runat="server" Text="Lưu lại"
                    CssClass="btn btn-sm btn-primary mr10"
                    OnClick="btnSaveElectrictPlan_Click"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>

<div style="display: none;">
    <asp:Button ID="btBindTieuThuSXDien" runat="server" OnClick="btBindTieuThuSXDien_Click" />

    <asp:Button ID="btBindListTieuThuSXDien" runat="server" OnClick="btBindListTieuThuSXDien_Click" />
</div>

<script type="text/javascript">
    function addReportDetail(isnext) { // alert($("#<%=hdnNextYear.ClientID%>").val()); 
        $("#<%=hdnNextYear.ClientID%>").val(isnext);
        $("#<%=hdnDetailId.ClientID%>").val(''); // 
        $("#<%=ddlFuel.ClientID%>").selectedIndex = 0; //         
        $("#<%=ddlMeasure.ClientID%>").selectedIndex = 0;
        $("#<%=txtNoFuel.ClientID%>").val('');
        $("#<%=txtPrice.ClientID%>").val('');
        $("#<%=txtPropose.ClientID%>").val('');
        $("#dlgFuelConsume").on('shown.bs.modal', function () { });
    }
    function showformInfo() {
        $('#frmInfo').modal('toggle');
    }
    function updateReportDetail(isnext) { // alert($("#<%=hdnNextYear.ClientID%>").val()); 
        $("#<%=hdnNextYear.ClientID%>").val(isnext);
        $('#dlgFuelConsume').modal('toggle');
    }
    $(document).ready(function () {
        $("#<%=txtReportDate.ClientID%>").datetimepicker
            ({
                format: 'd/m/Y', timepicker: false
            });
    });

    function ShowDialogExportword() {
        $('#dlgExportReport').on('shown.bs.modal', function () { });
    }
    function ShowDialogExportword5() {
        $('#dlgExportReport5').on('shown.bs.modal', function () { });
    }
    function ShowDialogSend() {
        $('#dlgSend').on('shown.bs.modal', function () { });
    }
    function ShowDialogResend() {
        $('#dlgResend').on('shown.bs.modal', function () { });
    }
    function ShowDialogFeedback() {
        $('#dlgFeedback').on('shown.bs.modal', function () { });
    } 
</script>
<script type="text/javascript"> 
    var tabReport = new ddtabcontent("Reporttabs");
    tabReport.setpersist(true);
    tabReport.setselectedClassTarget("link");
    tabReport.currentTabIndex =<%=activeTab %>;
    tabReport.init();
    var tabReportAll = new ddtabcontent("tabGeneral");
    tabReportAll.setpersist(true);
    tabReportAll.setselectedClassTarget("link");
    tabReportAll.currentTabIndex =<%=activeTab %>;
    tabReportAll.init(); 
</script>
<script type="text/javascript">
    $('#dlgTieuThuSXDien').on('shown.bs.modal', function () {
        $('#<%=btBindTieuThuSXDien.ClientID%>').click();

    });
    $('#dlgTieuThuSXDien').on('hide.bs.modal', function () {
        $('#<%=btBindListTieuThuSXDien.ClientID%>').click();

    });


</script>

<asp:Literal ID="ltScript" runat="server"></asp:Literal>
