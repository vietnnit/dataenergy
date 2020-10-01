<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewPlanOneYear.ascx.cs"
    Inherits="Client_Admin_DataEngery_ViewPlanOneYear" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<!-- Begin: Content -->
<!-- Dashboard Tiles -->
<div class="mb10">
    <div class="">
        <div class="">
            <asp:Literal ID="clientview" runat="server"></asp:Literal>
            <%--<div class="tab-content">
                <div id="tab2" class="tab-pane active">
                    <div class="">
                        <div class="">--%>
            <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-lg-12">
                        <label class="control-label">
                            <asp:Literal ID="ltOldYear" runat="server" Text="Kết quả sử dụng nhiên liệu"></asp:Literal></label>
                        <div class="margin-bottom-40" style="margin-top: 10px">
                            <div class="">
                                <label class="control-label pt5" style="width: 100%; text-align: left" for="inputSmall">
                                    1. Kết quả thực hiện kế hoạch giải pháp và mục tiêu tiết kiệm năng lượng
                                </label>
                            </div>
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr style="vertical-align: text-top">
                                        <th style="width: 10%">
                                            Giải pháp TKNL dự kiến áp dụng
                                        </th>
                                        <th style="width: 15%">
                                            Mục đích của giải pháp
                                        </th>
                                        <th style="width: 20%">
                                            Kết quả đạt được
                                        </th>
                                        <th style="width: 10%">
                                            Chi phí thực tế<br />
                                            (Triệu đồng)
                                        </th>
                                        <th style="width: 20%">
                                            Ghi chú
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptResultTKNL" runat="server" OnItemCommand="rptResultTKNL_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Eval("TenGiaiPhap")%>
                                                </td>
                                                <td>
                                                    <%# Eval("MucTieuGP")%>
                                                </td>
                                                <td>
                                                    Mức TK:
                                                    <%# Eval("MucTKThucTe")%>
                                                    <br />
                                                    Tương đương:
                                                    <%# Eval("TuongDuongTT")%>
                                                    <br />
                                                    Tiết kiệm chi phí:
                                                    <%# Eval("MucTKCPThucTe")%>
                                                    <br />
                                                    Lợi ích khác:
                                                    <%# Eval("LoiIchKhacTT")%>
                                                </td>
                                                <td>
                                                    <%# Eval("CPThucTe")%>
                                                </td>
                                                <td>
                                                    <%# Eval("GhiChuTT")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <div class="" style="margin-top: 20px">
                            <div class="">
                                <label class="control-label pt5" style="width: 100%; text-align: left" for="inputSmall">
                                    2. Kết quả thực hiện kế hoạch thay thế nâng cấp, bổ sung thiết bị công nghệ
                                </label>
                            </div>
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr style="vertical-align: text-top">
                                        <%--<th style="width: 5%">
                                            Năm
                                        </th>--%>
                                        <th style="width: 15%">
                                            Tên thiết bị
                                        </th>
                                        <%--      <th style="width:10%">Mô tả</th>--%>
                                        <th style="width: 15%">
                                            Mô tả tính năng, vị trí sử dụng của thiết bị
                                        </th>
                                        <th style="width: 15%">
                                            Cách lắp đặt
                                        </th>
                                        <th style="width: 15%">
                                            Thực hiện
                                        </th>
                                        <th style="width: 15%">
                                            Lý do lắp mới hoặc nâng cấp thay thế
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptResultTB" runat="server" OnItemCommand="rptResultTB_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <%-- <td>
                                                    <%# Eval("Nam")%>
                                                </td>--%>
                                                <td>
                                                    <%# Eval("NameTB")%>
                                                </td>
                                                <td>
                                                    <%# Eval("TinhNang")%>
                                                </td>
                                                <td>
                                                    <%# Eval("CachLapDat")%>
                                                </td>
                                                <td>
                                                    <%# (Eval("IsExecuted") != null && Convert.ToBoolean(Eval("IsExecuted"))) ? "Có" : "Không"%>
                                                </td>
                                                <td>
                                                    <%# Eval("LyDo")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <label class="control-label">
                            <asp:Literal ID="ltNextYear" runat="server" Text="Kế hoạch và mục tiêu tiết kiệm, sử dụng hiệu quả năng lượng năm"></asp:Literal>
                        </label>
                        <div class="margin-bottom-20" style="margin-top: 10px">
                            <div class="">
                                <label class="control-label pt5" style="width: 100%; text-align: left" for="inputSmall">
                                    1. Kế hoạch thực hiện tiết kiệm năng lượng
                                </label>
                            </div>
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr style="vertical-align: text-top">
                                        <th style="width: 10%">
                                            Giải pháp TKNL dự kiến áp dụng
                                        </th>
                                        <th style="width: 15%">
                                            Mục đích của giải pháp
                                        </th>
                                        <th style="width: 20%">
                                            Dự kiến kết quả
                                        </th>
                                        <th style="width: 10%">
                                            Dự kiến chi phí<br />
                                            (Triệu đồng)
                                        </th>
                                        <th style="width: 20%">
                                            Ghi chú
                                        </th>
                                        <th style="width: 15%">
                                            Mức cam kết khả năng thực hiện
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="cpRepeater" runat="server" OnItemCommand="cpRepeater_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Eval("TenGiaiPhap")%>
                                                </td>
                                                <td>
                                                    <%# Eval("MucTieuGP")%>
                                                </td>
                                                <td>
                                                    Mức TK:
                                                    <%# Eval("MucTietKiemDuKien")%>
                                                    <br />
                                                    Tương đương:
                                                    <%# Eval("TuongDuong")%>
                                                    <br />
                                                    Thành tiền:
                                                    <%# Eval("ThanhTien")%>
                                                    <br />
                                                    Lợi ích khác:
                                                    <%# Eval("LoiIchKhac")%>
                                                </td>
                                                <td>
                                                    <%# Eval("ChiPhiDuKien")%>
                                                </td>
                                                <td>
                                                    <%# Eval("GhiChu")%>
                                                </td>
                                                <td>
                                                    Cam kết:
                                                    <%# Eval("MucCamKet")%>
                                                    <br />
                                                    Khả năng:
                                                    <%# Eval("KhaNangThucHien")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <div class="">
                            <div class="">
                                <label class="control-label pt5" style="width: 100%; text-align: left" for="inputSmall">
                                    2. Kế hoạch thay thế nâng cấp, bổ sung thiết bị công nghệ
                                </label>
                            </div>
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr style="vertical-align: text-top">
                                        <th style="width: 5%">
                                            Năm
                                        </th>
                                        <th style="width: 15%">
                                            Tên thiết bị
                                        </th>
                                        <%--      <th style="width:10%">Mô tả</th>--%>
                                        <th style="width: 15%">
                                            Mô tả tính năng, vị trí sử dụng của thiết bị
                                        </th>
                                        <th style="width: 15%">
                                            Cách lắp đặt
                                        </th>
                                        <th style="width: 15%">
                                            Lý do lắp mới hoặc nâng cấp thay thế
                                        </th>
                                        <th style="width: 15%">
                                            Mức cam kết khả năng thực hiện
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptKHBoSungTB" runat="server" OnItemCommand="cpRepeaterTB_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Eval("Nam")%>
                                                </td>
                                                <td>
                                                    <%# Eval("NameTB")%>
                                                </td>
                                                <td>
                                                    <%# Eval("TinhNang")%>
                                                </td>
                                                <td>
                                                    <%# Eval("CachLapDat")%>
                                                </td>
                                                <td>
                                                    <%# Eval("LyDo")%>
                                                </td>
                                                <td>
                                                    Cam kết:
                                                    <%# Eval("CamKet")%>
                                                    <br />
                                                    Khả năng:
                                                    <%# Eval("KhaNang")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <asp:Literal ID="error" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<asp:HiddenField ID="hddvalue" runat="server" Value="" />
<asp:HiddenField ID="hddngaytao" runat="server" Value="1" />
<asp:HiddenField ID="hddkhtknl" runat="server" Value="1" />
<asp:HiddenField ID="hddkhTB" runat="server" Value="1" />
<div class="modal fade" tabindex="-1" role="dialog" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header panel-heading">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h3 class="modal-title">
                    <i class="fa  fa-sliders"></i>Cập nhật Kế Hoạch</h3>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <label for="message-text" class="control-label">
                                Kế hoạch thực hiện giai đoạn:</label>
                            <asp:TextBox ID="txFromYear" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        <%--<div class="col-lg-6">
                        <label for="message-text" class="control-label">
                            Đến:</label>
                        <asp:TextBox ID="txtEndYear" runat="server" Enabled="false" CssClass="form-control" required></asp:TextBox>
                    </div>--%>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <label for="recipient-name" class="control-label">
                                Ngày lập kế hoạch:</label>
                            <asp:TextBox ID="txtNgaytao" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNgaytao"
                                ValidationGroup="viewPlan" Text="Vui lòng ngày lập kế hoạch" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label for="message-text" class="control-label">
                            Mô tả:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtmota" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnExport" runat="server" Visible="true" Text="Lưu lại" OnClick="btnsave_DirectClick"
                    CssClass="btn btn-sm btn-primary mr10" AutoPostback="false" UseSubmitBehavior="false">
                </asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- / modal dialog giaiphap -->
<div class="modal" tabindex="-1" role="dialog" id="mygiaiphap" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header panel-heading">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    <i class="fa fa-sliders"></i>Cập nhật giải pháp tiết kiệm năng lượng</h3>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="form-group col-lg-12">
                        <asp:Literal ID="ltNoticeSolution" runat="server"></asp:Literal>
                    </div>
                    <div class="form-group col-lg-12">
                        <label for="message-text" class="control-label">
                            Tên giải pháp:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtnamegp"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnamegp"
                            ValidationGroup="viewSolution" Text="Vui lòng nhập tên giải pháp" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-lg-12">
                        <label for="message-text" class="control-label">
                            Mô tả:</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtmotagp"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveSolution" runat="server" Visible="true" Text="Lưu lại" ValidationGroup="viewSolution"
                    OnClick="btnSaveSolution_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false"
                    UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="modalGPTKNL" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    <i class="fa fa-sliders"></i>Cập nhật kế hoạch thực hiện tiết kiệm năng lượng</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Giải pháp TKNL:</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="dllgiaiphap"
                                Name="Giải pháp" DataMember="Id" DataValueField="Id" DataTextField="TenGiaiPhap">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                ControlToValidate="dllgiaiphap" ValidationGroup="viewSolutionTKNL" Text="Vui lòng chọn giải pháp"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3" for="inputSmall">
                            Loại nhiên liệu <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlFuelType" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="viewSolutionTKNL">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlFuelType"
                                ValidationGroup="viewSolutionTKNL" Text="Vui lòng chọn nhiên liệu" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mục đích GP:</label>
                        <div class="col-lg-9">
                            <%--    <i class="icon-prepend fa fa-envelope"></i>--%>
                            <asp:TextBox runat="server" ID="txtmuctieuTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmuctieuTKNL"
                                ValidationGroup="viewSolutionTKNL" Text="Vui lòng nhập mục đích giải pháp" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mức tiết kiệm NL:</label>
                        <div class="col-lg-3">
                            <%--  <i class="icon-prepend fa fa-phone"></i>--%>
                            <asp:TextBox runat="server" ID="txtTKNLMucTieuDukien" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTKNLMucTieuDukien"
                                ValidationGroup="viewSolutionTKNL" Text="Vui lòng nhập mức tiết kiệm" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Tương đương:</label>
                        <div class="col-lg-3">
                            <%--  <i class="icon-prepend fa fa-phone"></i>--%>
                            <asp:TextBox runat="server" ID="txtTuongDuong" CssClass="form-control input-sm"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTuongDuong"
                                        ValidationGroup="viewSolutionTKNL" Text="Vui lòng nhập tương đương" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tiết kiệm chi phí:</label>
                        <div class="col-lg-3">
                            <%--  <i class="icon-prepend fa fa-phone"></i>--%>
                            <asp:TextBox runat="server" ID="txtThanhTien" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <label class="col-lg-3">
                            Dự kiến chi phí:</label>
                        <div class="col-lg-3">
                            <%--    <i class="icon-prepend fa fa-envelope"></i>--%>
                            <asp:TextBox runat="server" ID="txtchiphidukienTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtchiphidukienTKNL"
                                ValidationGroup="viewSolutionTKNL" Text="Vui lòng nhập chi phí dự kiến" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Lợi ích khác:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtLoiIchKhac" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mức cam kết:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtcamketTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="rvCamKet" runat="server" ControlToValidate="txtcamketTKNL"
                                Text="Vui lòng nhập mức cam kết trong khoảng từ 0% đến 100%" ValidationGroup="viewSolutionTKNL"
                                Display="Dynamic"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtcamketTKNL"
                                ValidationGroup="viewSolutionTKNL" Text="Vui lòng nhập mức cam kết" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Khả năng thực hiện:</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlKhaNang" Name="Khả năng thực hiện" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Cao" Text="Cao"></asp:ListItem>
                                <asp:ListItem Value="Trung bình" Text="Trung bình"></asp:ListItem>
                                <asp:ListItem Value="Thấp" Text="Thấp"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlKhaNang"
                                ValidationGroup="viewSolutionTKNL" Text="Vui lòng chọn giải pháp" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Ghi chú:</label>
                        <div class="col-lg-9">
                            <%--  <i class="icon-prepend fa fa-phone"></i>--%>
                            <asp:TextBox runat="server" ID="txtGhiChu" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSavePlan" runat="server" Visible="true" ValidationGroup="viewSolutionTKNL"
                    Text="Lưu lại" OnClick="btnSavePlan_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="frmResultTKNL" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    <i class="fa fa-sliders"></i>Kết quả thực hiện giải pháp TKNL</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Giải pháp TKNL:</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddlSolution2"
                                Name="Giải pháp" DataMember="Id" DataValueField="Id" DataTextField="TenGiaiPhap">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Display="Dynamic" runat="server"
                                ControlToValidate="ddlSolution2" ValidationGroup="valAddSolutionTKNL" Text="Vui lòng chọn giải pháp"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3" for="inputSmall">
                            Loại nhiên liệu <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlFuelType2" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valAddSolutionTKNL">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlFuelType2"
                                ValidationGroup="valAddSolutionTKNL" Text="Vui lòng chọn loại nhiên liệu" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mục đích của giải pháp:</label>
                        <div class="col-lg-9">
                            <%--    <i class="icon-prepend fa fa-envelope"></i>--%>
                            <asp:TextBox runat="server" ID="txtMucDichGPTT" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtMucDichGPTT"
                                ValidationGroup="valAddSolutionTKNL" Text="Vui lòng nhập mục đích của giải pháp"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mức tiết kiệm NL:</label>
                        <div class="col-lg-3">
                            <%--  <i class="icon-prepend fa fa-phone"></i>--%>
                            <asp:TextBox runat="server" ID="txtMucTietKiemNLTT" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtMucTietKiemNLTT"
                                ValidationGroup="valAddSolutionTKNL" Text="Vui lòng nhập mức tiết kiệm" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Tương đương:</label>
                        <div class="col-lg-3">
                            <%--  <i class="icon-prepend fa fa-phone"></i>--%>
                            <asp:TextBox runat="server" ID="txtTuongDuongTT" CssClass="form-control input-sm"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTuongDuong"
                                        ValidationGroup="viewSolutionTKNL" Text="Vui lòng nhập tương đương" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tiết kiệm chi phí:</label>
                        <div class="col-lg-3">
                            <%--  <i class="icon-prepend fa fa-phone"></i>--%>
                            <asp:TextBox runat="server" ID="txtTKCPThucTe" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <label class="col-lg-3">
                            Chi phí thực tế:</label>
                        <div class="col-lg-3">
                            <%--    <i class="icon-prepend fa fa-envelope"></i>--%>
                            <asp:TextBox runat="server" ID="txtChiPhiThucTe" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtChiPhiThucTe"
                                ValidationGroup="valAddSolutionTKNL" Text="Vui lòng nhập chi phí dự kiến" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Lợi ích khác:</label>
                        <div class="col-lg-9">
                            <%--  <i class="icon-prepend fa fa-phone"></i>--%>
                            <asp:TextBox runat="server" ID="txtLoiIchKhacTT" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Ghi chú:</label>
                        <div class="col-lg-9">
                            <%--  <i class="icon-prepend fa fa-phone"></i>--%>
                            <asp:TextBox runat="server" ID="txtGhiChuTT" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveAddPlan" runat="server" Visible="true" ValidationGroup="valAddSolutionTKNL"
                    Text="Lưu lại" OnClick="btnSaveAddPlan_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="myModalTB" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    <i class="fa  fa-sliders"></i>Kế hoạch thay thế nâng cấp, bổ sung thiết bị công
                    nghệ</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Năm:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" name="year" ID="txtnamTB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtnamTB"
                                ValidationGroup="viewSolutionTB" Text="Vui lòng nhập năm" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên thiết bị:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtTenTB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtTenTB"
                                ValidationGroup="viewSolutionTB" Text="Vui lòng nhập tên thiết bị" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mô tả tính năng, vị trí sử dụng của thiết bị:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtTinhNangTB" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Cách thức lắp đặt:</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlCacThucLD" Name="Khả năng thực hiện" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Mới" Text="Mới"></asp:ListItem>
                                <asp:ListItem Value="Thay thế" Text="Thay thế"></asp:ListItem>
                                <asp:ListItem Value="Nâng cấp" Text="Nâng cấp"></asp:ListItem>
                                <asp:ListItem Value="Sửa chữa" Text="Sửa chữa"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCacThucLD"
                                ValidationGroup="viewSolutionTB" Text="Vui lòng chọn giải pháp" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Lý do lắp mới hoặc nâng cấp thay thế:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtlydoTB" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mức cam kết:</label>
                        <div class="col-lg-3">
                            <%--    <i class="icon-prepend fa fa-envelope"></i>--%>
                            <asp:TextBox runat="server" ID="txtCamKetTB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCamKetTB"
                                ValidationGroup="viewSolutionTB" Text="Vui lòng nhập mức cam kết" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Khả năng thực hiện:</label>
                        <div class="col-lg-3">
                            <%--    <i class="icon-prepend fa fa-envelope"></i>--%>
                            <%--<asp:TextBox runat="server" ID="txtkhanangTKNL"></asp:TextBox>--%>
                            <asp:DropDownList runat="server" ID="ddlKhaNangTB" Name="Khả năng thực hiện" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Cao" Text="Cao"></asp:ListItem>
                                <asp:ListItem Value="Trung bình" Text="Trung bình"></asp:ListItem>
                                <asp:ListItem Value="Thấp" Text="Thấp"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlKhaNangTB"
                                ValidationGroup="viewSolutionTB" Text="Vui lòng chọn giải pháp" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveDevice" runat="server" Visible="true" Text="Lưu lại" OnClick="btnSaveDevice_Click"
                    CssClass="btn btn-sm btn-primary mr10" ValidationGroup="viewSolutionTB" AutoPostback="false"
                    UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="frmTB" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    <i class="fa  fa-sliders"></i>Kết quả thay thế nâng cấp, bổ sung thiết bị công nghệ</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên thiết bị:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtTenTietBiBS" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtTenTietBiBS"
                                ValidationGroup="valAddSolutionTB" Text="Vui lòng nhập tên thiết bị" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mô tả tính năng, vị trí sử dụng của thiết bị:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtMoTaTinhNangBS" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Cách thức lắp đặt:</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlCacThucLDBS" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Mới" Text="Mới"></asp:ListItem>
                                <asp:ListItem Value="Thay thế" Text="Thay thế"></asp:ListItem>
                                <asp:ListItem Value="Nâng cấp" Text="Nâng cấp"></asp:ListItem>
                                <asp:ListItem Value="Sửa chữa" Text="Sửa chữa"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCachThucLDBS" runat="server" ValidationGroup="valAddSolutionTB"
                                Display="Dynamic" Text="Vui lòng chọn cách thức lắp đặt" ControlToValidate="ddlCacThucLDBS"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Có thực hiện hay không?:</label>
                        <div class="col-lg-3">
                            <asp:CheckBox runat="server" ID="cbxThucHien" Text="Có" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Lý do(nếu không thực hiện):</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtLyDoKhongThucHien" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveAddDevice" runat="server" Visible="true" Text="Lưu lại"
                    OnClick="btnSaveAddDevice_Click" CssClass="btn btn-sm btn-primary mr10" ValidationGroup="valAddSolutionTB"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {

        $("#<%=txtNgaytao.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });
        $('input[id=lefile]').change(function () {
            $('#photoCover').val($(this).val());
        });
    });
    function showgiaiphapTKNL(id) {

        if (id == "1") {

        }
        else {
            $("#<%=hddkhtknl.ClientID%>").val('');
            $("#<%=txtTKNLMucTieuDukien.ClientID%>").val('');
            $("#<%=txtchiphidukienTKNL.ClientID%>").val('');
            $("#<%=txtmuctieuTKNL.ClientID%>").val('');
            $("#<%=txtcamketTKNL.ClientID%>").val('');
        }
        $('#modalGPTKNL').modal('toggle');
    }
    function updategiaiphapTKNL() {
        $('#frmResultTKNL').modal('toggle');
    }
    function addgiaiphapTKNL() {
        $("#<%=hddkhtknl.ClientID%>").val('');
        $('#frmResultTKNL').modal('toggle');
    }
    function showgiaiphapTB(id) {

        if (id == "1") {

        }
        else {
            $("#<%=hddkhTB.ClientID%>").val('');
            $("#<%=txtlydoTB.ClientID%>").val('');
            $("#<%=txtTinhNangTB.ClientID%>").val('');

        }
        $('#myModalTB').modal('toggle');
    }
    function showgiaiphap() {
        $('#mygiaiphap').modal('toggle');
    }
    function showkehoach() {
        $('#myModalthuchien').modal('toggle');
    }
    function updategiaiphapTB() {

        $('#frmTB').modal('toggle');
    }
    function addgiaiphapTB() {
        $("#<%=hddkhTB.ClientID%>").val('');
        $('#frmTB').modal('toggle');
    }
    function UpdateKeHoach() {
        $(document).ready(function () {
            $('#myModal').modal('toggle');

        });

    }
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
