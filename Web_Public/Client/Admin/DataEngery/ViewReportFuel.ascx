<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewReportFuel.ascx.cs"
    Inherits="Client_Admin_DataEnergy_ViewReportFuel" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<%@ Register Src="~/Client/Modules/DataEnergy/InputReportFuelDetail.ascx" TagName="ReportFuelDetail"
    TagPrefix="uc1" %>
<asp:HiddenField ID="hdnNewsUrl" Value="" runat="server" />
<asp:HiddenField ID="hdnReport" Value="" runat="server" />
<asp:HiddenField ID="hdnNextYear" Value="" runat="server" />
<link type="text/css" href="<%= ResolveUrl("~") %>CSS_Admins/js/DatetimePicker/jquery.datetimepicker.css"
    rel="stylesheet" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>CSS_Admins/js/DatetimePicker/jquery.datetimepicker.js"></script>
<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.css" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.js"></script>
<div class="row mb10">
    <div class="tab-block mb25">
        <div class="tab-content">
            <div class="form-group">
                <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                    Báo cáo năm <span class="append-icon right text-danger">*</span></label>
                <div class="col-lg-4 col-md-10 col-sm-10">
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                        ValidationGroup="view">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlYear"
                        Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                </div>
                <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                    Ngày lập báo cáo <span class="append-icon right text-danger">*</span></label>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <div class="input-group  input-group-sm">
                        <asp:TextBox ID="txtReportDate" runat="server" CssClass="form-control input-sm" ValidationGroup="view"></asp:TextBox>
                        <span class="input-group-addon field-icon"><i class="fa fa-calendar"></i></span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="view"
                            ControlToValidate="txtReportDate" Display="Dynamic" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group" style="clear: both; margin-bottom: 10px">
                    <label for="message-text" class="col-lg-2 col-md-2 col-sm-2">
                        File báo cáo đính kèm:</label>
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <div class="input-group  input-group-sm">
                            <asp:LinkButton ID="lbtDownload" runat="server" OnClick="lbtDownload_Click" Text="Tải về"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" runat="server" id="rowTab">
                <div class="col-lg-12">
                    <ul class="nav nav-tabs tabs-border" id="Reporttabs">
                        <li><a rel="tabInfo" href="#" class="">Thông tin chung</a></li>
                        <li><a rel="tabData" href="#" class="">Mức nhiên liệu tiêu thụ</a></li>
                        <li><a rel="tabApproved" href="#" class="">Phê duyệt báo cáo</a></li>
                    </ul>
                </div>
            </div>
            <div id="tabChuyen">
                <div class="tab-content" style="border-top: 0">
                    <div id="tabInfo" class="">
                        <div class="">
                            <div class="">
                                <asp:Literal ID="clientview" runat="server"></asp:Literal>
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Báo cáo năm <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-4 col-md-10 col-sm-10">
                                            <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                                ValidationGroup="view">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlYear"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Doanh nghiệp <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10">
                                            <asp:TextBox ID="txtEnterpriseName" Enabled="false" runat="server" CssClass="form-control input-sm"
                                                placeholder="Cơ sở/Doanh nghiêp" ValidationGroup="view"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtEnterpriseName"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Lĩnh vực <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                                                CssClass="form-control input-sm" ValidationGroup="view" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlArea"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                        <%-- </div>                 
                                <div class="form-group">--%>
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Phân ngành <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlSubArea" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                                ValidationGroup="view">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlSubArea"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Tỉnh/TP <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlProvince" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                                AutoPostBack="true" ValidationGroup="view" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProvince"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                        <%--</div>                 
                                <div class="form-group">--%>
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Quận/Huyện <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlDistrict" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                                ValidationGroup="view">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDistrict"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Mã số thuế <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10">
                                            <asp:TextBox ID="txtMST" Enabled="false" runat="server" CssClass="form-control input-sm"
                                                placeholder="" ValidationGroup="view"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMST"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Địa chỉ</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10">
                                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm" placeholder="Địa chỉ"
                                                ValidationGroup="view"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Số điện thoại</label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-sm" placeholder="Số điện thoại"
                                                ValidationGroup="view"></asp:TextBox>
                                        </div>
                                        <%--</div>  
                                <div class="form-group">--%>
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Fax</label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtFax" runat="server" CssClass="form-control input-sm" placeholder="Fax"
                                                ValidationGroup="view"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Người lập báo cáo <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10">
                                            <asp:TextBox ID="txtReportName" runat="server" CssClass="form-control input-sm" placeholder="Nhập người chịu trách nhiệm nội dung báo cáo"
                                                ValidationGroup="view"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtReportName"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Tỉnh/TP <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlProvinceReporter" runat="server" AppendDataBoundItems="True"
                                                AutoPostBack="true" CssClass="form-control input-sm" ValidationGroup="view" OnSelectedIndexChanged="ddlProvinceReporter_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlProvinceReporter"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                        <%-- </div>                 
                                <div class="form-group">--%>
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Quận/Huyện <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:DropDownList ID="ddlDistrictReporter" runat="server" AppendDataBoundItems="True"
                                                CssClass="form-control input-sm" ValidationGroup="view">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDistrictReporter"
                                                Display="Dynamic" ValidationGroup="view" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger" ><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Địa chỉ</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10">
                                            <asp:TextBox ID="txtAddressReporter" runat="server" CssClass="form-control input-sm"
                                                placeholder="Nhập địa chỉ người chịu trách nhiệm nội dung báo cáo" ValidationGroup="view"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Số điện thoại</label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtPhoneReporter" runat="server" CssClass="form-control input-sm"
                                                placeholder="Nhập Số điện thoại người chịu trách nhiệm nội dung báo cáo" ValidationGroup="view"></asp:TextBox>
                                        </div>
                                        <%--</div>  
                                <div class="form-group">--%>
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Fax</label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <asp:TextBox ID="txtFaxReporter" runat="server" CssClass="form-control input-sm"
                                                placeholder="Nhập số Fax" ValidationGroup="view"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Email</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm" placeholder="Nhập Email"
                                                ValidationGroup="view"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-2 col-md-2 col-sm-2 control-label" for="inputSmall">
                                            Ngày lập báo cáo <span class="append-icon right text-danger">*</span></label>
                                        <div class="col-lg-4 col-md-4 col-sm-4">
                                            <div class="input-group  input-group-sm">
                                                <asp:TextBox ID="txtCreated" runat="server" CssClass="form-control input-sm" ValidationGroup="view"></asp:TextBox>
                                                <span class="input-group-addon field-icon"><i class="fa fa-calendar"></i></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="view"
                                                    ControlToValidate="txtCreated" Display="Dynamic" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tabData" class="">
                        <div id="tabDetail">
                            <div class="">
                                <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label class="col-lg-12 control-label pt5" for="inputSmall">
                                            Mức nhiên tiêu thụ năng lượng hiện tại</label>
                                        <div class="col-lg-12">
                                            <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
                                            <table class="table table-bordered table-hover mbn" width="100%">
                                                <tr class="primary fs12">
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
                                                    <th style="width: 10%">
                                                        Hệ số TOE
                                                    </th>
                                                    <th style="width: 10%">
                                                        Năng lượng tiêu thụ quy đổi
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
                                                                <a href='#' onclick="javascript:UpdateFuel(<%#Eval("Id") %>,false);">
                                                                    <%#Eval("FuelName") %></a>
                                                            </td>
                                                            <td>
                                                                <%#Eval("NoFuel") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("MeasurementName")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Price")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("No_RateTOE")%>
                                                            </td>
                                                            <td>
                                                                <%#Convert.ToDecimal(Eval("No_RateTOE")) * Convert.ToDecimal(Eval("NoFuel"))%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Reason")%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-12 control-label pt5" for="inputSmall">
                                            Dự kiến sử dụng nhiên liệu</label>
                                        <div class="col-lg-12">
                                            <asp:Literal ID="ltNoFuelFuture" runat="server"></asp:Literal>
                                            <table class="table table-bordered table-hover mbn" width="100%">
                                                <tr class="primary fs12">
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
                                                    <th style="width: 10%">
                                                        Hệ số TOE
                                                    </th>
                                                    <th style="width: 10%">
                                                        Năng lượng tiêu thụ quy đổi
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
                                                                <a href='#' onclick="javascript:UpdateFuel(<%#Eval("Id") %>,true);">
                                                                    <%#Eval("FuelName") %></a>
                                                            </td>
                                                            <td>
                                                                <%#Eval("NoFuel") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("MeasurementName")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Price")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("No_RateTOE")%>
                                                            </td>
                                                            <td>
                                                                <%#Convert.ToDecimal(Eval("No_RateTOE")) * Convert.ToDecimal(Eval("NoFuel"))%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Reason")%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                    <asp:Literal ID="error" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tabApproved" class="">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="recipient-name" class="col-lg-2 col-md-2 col-sm-2 control-label">
                                    Ngày xác nhận <span class="append-icon right text-danger">*</span></label>
                                <div class="col-lg-4 col-md-4 col-sm-4">
                                    <asp:TextBox ID="txtApprovedDate" runat="server" CssClass="form-control" ValidationGroup="vgTN"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNgayTN" ControlToValidate="txtApprovedDate" ValidationGroup="vgTN"
                                        runat="server" Text="Vui lòng nhập ngày xác nhận" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="col-lg-2 col-md-2 col-sm-2 control-label">
                                    Ý kiến phê duyệt</label>
                                <div class="col-lg-10 col-md-10 col-sm-10">
                                    <asp:TextBox runat="server" class="form-control" ID="txtmota"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12 text-left">
                                    <asp:Button runat="server" ID="btnApproved" CssClass="btn btn-sm btn-primary mr10"
                                        Text="Phê duyệt" ValidationGroup="view" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<%--<div class="modal fade" tabindex="-1" role="dialog" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="ltTitleForm" runat="server" Text="Nhập mức tiêu thụ nhiên liệu"></asp:Literal> </h4>
            </div>
            <div class="modal-body">
                <uc1:ReportFuelDetail ID="ucReportFuelDetail" runat="server" />
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">
                    Close</button>                

            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>--%>
<script type="text/javascript">


    $(document).ready(function () {

        $("#<%=txtCreated.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });
        $("#<%=txtApprovedDate.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });

    });
</script>
<script type="text/javascript">   
    var tabReport = new ddtabcontent("Reporttabs");
    tabReport.setpersist(true);
    tabReport.setselectedClassTarget("link");
    tabReport.currentTabIndex=<%=activeTab %>;
    tabReport.init();
</script>
<asp:Literal ID="ltScript" runat="server"></asp:Literal>