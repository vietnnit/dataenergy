<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DetailPlanYear.ascx.cs"
    Inherits="Client_Module_DataEngery_DetailPlanYear" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <label class="control-label">
                <asp:Literal ID="ltOldYear" runat="server" Text="Kết quả sử dụng nhiên liệu"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        1. Kết quả thực hiện giải pháp và mục tiêu tiết kiệm năng lượng
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddPlan" runat="server" Text="Thêm kết quả thực hiện" ToolTip="Thêm mới kết quả thực hiện"
                                OnClientClick='javascript:ShowDialogSolutionResultOne(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 10%">
                                Giải pháp TKNL<br />
                                <asp:LinkButton ID="btnAddSolution" runat="server" CssClass="fs9 btn btn-primary"
                                    Text="Thêm giải pháp" ToolTip="Thêm giải pháp" OnClientClick='javascript:showgiaiphap(1,0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm giải pháp</asp:LinkButton>
                            </th>
                            <th style="width: 10%">
                                Nhiên liệu
                            </th>
                            <th style="width: 15%">
                                Giải pháp tiết kiệm năng lượng đối với hệ thống
                            </th>
                            <th style="width: 15%">
                                Mô tả giải pháp
                            </th>
                            <th style="width: 20%">
                                Kết quả đạt được
                            </th>
                            <th style="width: 10%">
                                C.Phí đầu tư<br />
                                (Tr.đồng)
                            </th>
                            <th style="width: 20%">
                                Ghi chú
                            </th>
                            <th style="width: 5%">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptResultTKNL" runat="server" OnItemCommand="rptResultTKNL_ItemCommand"
                            OnItemDataBound="rptResultTB_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("TenGiaiPhap")%>
                                    </td>
                                    <td>
                                        <%# Eval("FuelName")%>
                                    </td>
                                     <td>
                                        <%# Eval("HeThongSuDung")%>
                                    </td>
                                     <td>
                                        <%# Eval("MucTieuGP")%>
                                    </td>
                                   
                                    <td>
                                        Mức TK:
                                        <%# Eval("MucTKThucTe") != null ? (Tool.ConvertDecimalToString(Eval("MucTKThucTe"),2) + "(" + Eval("MeasurementName"))+")" : ""%>
                                        <br />
                                        Tương đương:
                                        <%# Eval("TuongDuongTT") != DBNull.Value && Eval("TuongDuongTT").ToString()!="" ? (Eval("TuongDuongTT").ToString() + "%") : ""%>
                                        <br />
                                        C.Phí đầu tư:
                                        <%# Eval("MucTKCPThucTe") != null ? (Tool.ConvertDecimalToString(Eval("MucTKCPThucTe"),0) + "(Tr. đồng)") : ""%>
                                        <br />
                                        Lợi ích khác:
                                        <%# Eval("LoiIchKhacTT")%>
                                    </td>
                                    <td class="text-right">
                                        <%#Tool.ConvertDecimalToString(Eval("CPThucTe"),0)%>
                                    </td>
                                    <td>
                                        <%# Eval("GhiChuTT")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>'
                                            CommandName="delete" CssClass="" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa không???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnEdit" runat="server" CssClass="" ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>'
                                            CommandName="edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        2. Kết quả thực hiện thay thế nâng cấp, bổ sung thiết bị công nghệ
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddDevice" runat="server" Text="Thêm kết quả thực hiện" ToolTip="Thêm mới kết quả thực hiện"
                                OnClientClick='javascript:ShowDialogDeviceResultOne(0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 15%">
                                Tên thiết bị
                            </th>
                            <th style="width: 15%">
                                Mô tả tính năng, vị trí sử dụng của thiết bị
                            </th>
                            <th style="width: 10%">
                                Cách lắp đặt
                            </th>
                            <th style="width: 15%">
                                Thực hiện (Có/không)
                            </th>
                            <th style="width: 15%">
                                Lý do lắp mới hoặc nâng cấp thay thế
                            </th>
                            <th style="width: 5%">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptResultTB" runat="server" OnItemCommand="rptResultTB_ItemCommand"
                            OnItemDataBound="rptResultTB_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <%--<td>
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
                                    <td>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>'
                                            CommandName="delete" CssClass="" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa không???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnEdit" runat="server" CssClass="" ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>'
                                            CommandName="edit"><i class="fa fa-edit"></i></asp:LinkButton>
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
                <asp:Literal ID="ltNextYear" runat="server" Text="Kế hoạch và mục tiêu tiết kiệm, sử dụng hiệu quả năng lượng năm"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        1. Kế hoạch thực hiện tiết kiệm năng lượng
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddPlanNext" runat="server" Text="Thêm kế hoạch" ToolTip="Thêm mới kế hoạch"
                                OnClientClick='javascript:ShowDialogSolutionPlanOne(0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                    </div>
                </div>
                <div class="table-responsive">
                    <table class="table table-bordered table-hover mbn">
                        <thead>
                            <tr class="primary fs12">
                                <th style="width: 200px">
                                    Giải pháp TKNL dự kiến áp dụng &nbsp;
                                    <asp:LinkButton ID="btnAddSolution2" runat="server" CssClass="fs9 btn btn-primary"
                                        Text="Thêm giải pháp" ToolTip="Thêm giải pháp" OnClientClick='javascript:showgiaiphap(1,0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm giải pháp</asp:LinkButton>
                                </th>
                                <th style="width: 200px">
                                    Nhiên liệu
                                </th>
                                <th style="width: 300px">
                                    Giải pháp tiết kiệm năng lượng đối với hệ thống
                                </th>
                                <th style="width: 300px">
                                    Mô tả giải pháp
                                </th>
                                <th style="width: 300px">
                                    Dự kiến kết quả
                                </th>
                                <th style="width: 100px">
                                    Chi phí<br />
                                    (Tr.đồng)
                                </th>
                                <th style="width: 200px">
                                    Ghi chú
                                </th>
                              <%--  <th style="width: 200px">
                                    Cam kết & khả năng thực hiện
                                </th>--%>
                                <th style="width: 50px">
                                    Thao tác
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptSolutionPlan" runat="server" OnItemCommand="rptPlanTKNL_ItemCommand"
                                OnItemDataBound="rptResultTB_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("TenGiaiPhap")%>
                                        </td>
                                        <td>
                                            <%# Eval("FuelName")%>
                                        </td>
                                         <td>
                                            <%# Eval("HeThongSuDung")%>
                                        </td>
                                        <td>
                                            <%# Eval("MucTieuGP")%>
                                        </td>
                                        <td>
                                            Mức TK:
                                            <%# Eval("MucTietKiemDuKien") != null ? (Tool.ConvertDecimalToString(Eval("MucTietKiemDuKien"),2)+ "("+Eval("MeasurementName"))+")" : ""%>
                                            <br />
                                            Tương đương:
                                            <%# Eval("TuongDuong") != DBNull.Value && Eval("TuongDuong").ToString() != "" ? (Eval("TuongDuong").ToString() + "%") : ""%>
                                            <br />
                                            C.Phí TK dự kiến:
                                            <%# Eval("ThanhTien") != null ? (Tool.ConvertDecimalToString(Eval("ThanhTien"),0) + "(Tr. đồng)") : ""%>
                                            <br />
                                            Lợi ích khác:
                                            <%# Eval("LoiIchKhac")%>
                                        </td>
                                        <td>
                                            <%# Eval("ChiPhiDuKien") != null ? Tool.ConvertDecimalToString(Eval("ChiPhiDuKien"), 0) : ""%>
                                        </td>
                                        <td>
                                            <%# Eval("GhiChu")%>
                                        </td>
                                       <%-- <td>
                                            Khả năng:
                                            <%# Eval("KhaNangThucHien") != DBNull.Value && Eval("KhaNangThucHien").ToString() != "" ? Eval("KhaNangThucHien") + "%" : ""%>
                                            <br />
                                            Cam kết:
                                            <%# Eval("MucCamKet")%>
                                        </td>--%>
                                        <td>
                                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>'
                                                CommandName="delete" CssClass="" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa không???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="" ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>'
                                                CommandName="edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        2. Kế hoạch thay thế nâng cấp, bổ sung thiết bị công nghệ
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddPlanDeviceNext" runat="server" Text="Thêm kế hoạch" ToolTip="Thêm mới kế hoạch"
                                OnClientClick='javascript:ShowDialogDevicePlanOne(0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 15%">
                                Tên thiết bị
                            </th>
                            <th style="width: 15%">
                                Mô tả tính năng, vị trí sử dụng của thiết bị
                            </th>
                            <th style="width: 10%">
                                Cách lắp đặt
                            </th>
                            <th style="width: 15%">
                                Lý do lắp mới hoặc nâng cấp thay thế
                            </th>
                            <th style="width: 15%">
                                Mức cam kết khả năng thực hiện
                            </th>
                            <th style="width: 5%">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptKHBoSungTB" runat="server" OnItemCommand="rptKHBoSungTB_ItemCommand"
                            OnItemDataBound="rptResultTB_ItemDataBound">
                            <ItemTemplate>
                                <tr>
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
                                        Khả năng:
                                        <%# Eval("KhaNang") != DBNull.Value && Eval("KhaNang").ToString() != "" ? Eval("KhaNang") + "%" : ""%>
                                        <br />
                                        Cam kết:
                                        <%# Eval("CamKet")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>'
                                            CommandName="delete" CssClass="" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa không???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnEdit" runat="server" CssClass="" ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>'
                                            CommandName="edit"><i class="fa fa-edit"></i></asp:LinkButton>
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
<br />
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<asp:HiddenField ID="hddvalue" runat="server" Value="" />
<asp:HiddenField ID="hddngaytao" runat="server" Value="1" />
<asp:HiddenField ID="hddkhtknl" runat="server" Value="1" />
<asp:HiddenField ID="hddkhTB" runat="server" Value="1" />
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
                    <div class="form-group">
                        <label for="message-text" class="col-lg-3">
                            Tên giải pháp<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" class="form-control" ID="txtnamegp"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnamegp"
                                ValidationGroup="viewSolutionOne" Text="Vui lòng nhập tên giải pháp" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-lg-3">
                            Mô tả:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" class="form-control" ID="txtmotagp" TextMode="MultiLine"
                                Rows="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveSolution" runat="server" Visible="true" Text="Lưu lại" ValidationGroup="viewSolutionOne"
                    OnClick="btnSaveSolution_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false"
                    UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgSolutionPlanOne" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    <i class="fa fa-sliders"></i>Kế hoạch thực hiện tiết kiệm năng lượng</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Giải pháp TKNL<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddlSolution"
                                Name="Giải pháp" DataMember="Id" DataValueField="Id" DataTextField="TenGiaiPhap">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                CssClass="text-danger" ControlToValidate="ddlSolution" ValidationGroup="valAddSolutionTKNLOne"
                                Text="Vui lòng chọn giải pháp"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                     <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Hệ thống sử dụng <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlUseSysNamePlan" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mục đích<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtmuctieuTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmuctieuTKNL"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Vui lòng nhập mục đích giải pháp"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Loại nhiên liệu<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlFuelType" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valAddSolutionTKNLOne" OnSelectedIndexChanged="ddlFuel_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlFuelType"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Vui lòng chọn nhiên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3" for="inputSmall">
                            Đơn vị<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlMeasure" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valAddSolutionTKNLOne">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlMeasure"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Vui lòng chọn đơn vị tính"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Lượng tiết kiệm<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtTKNLMucTieuDukien" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTKNLMucTieuDukien"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Vui lòng nhập lượng tiết kiệm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTKNLMucTieuDukien"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-3">
                            Tương đương(%):</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtTuongDuong" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtTuongDuong"
                                MinimumValue="0" MaximumValue="100" Type="Double" ValidationGroup="valAddSolutionTKNLOne"
                                CssClass="text-danger" Text="Vui lòng nhập mức tương đương trong khoảng(0% đến 100%)"
                                Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tiết kiệm C.phí (Tr.đồng)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtThanhTien" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtThanhTien"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtThanhTien"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Vui lòng nhập tiết kiệm C.phí"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Dự kiến C.phí (Tr.đồng)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtchiphidukienTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtchiphidukienTKNL"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Vui lòng nhập chi phí dự kiến"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtchiphidukienTKNL"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
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
                            Khả năng thực hiện(%)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtKhaNangTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="rvCamKet" runat="server" ControlToValidate="txtKhaNangTKNL"
                                Text="Vui lòng nhập khả năng thực hiện trong khoảng từ 0% đến 100%" ValidationGroup="valAddSolutionTKNLOne"
                                CssClass="text-danger" Type="Double" MinimumValue="0" MaximumValue="100" Display="Dynamic"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtKhaNangTKNL"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Vui lòng nhập khả năng thực hiện"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Mức cam kết<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlCamKet" Name="ddlCamKet" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Cao" Text="Cao"></asp:ListItem>
                                <asp:ListItem Value="Trung bình" Text="Trung bình"></asp:ListItem>
                                <asp:ListItem Value="Thấp" Text="Thấp"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlCamKet"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNLOne" Text="Vui lòng chọn mức cam kết"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Ghi chú:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtGhiChu" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSavePlan" runat="server" Visible="true" ValidationGroup="valAddSolutionTKNLOne"
                    Text="Lưu lại" OnClick="btnSavePlan_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgSolutionResultOne" data-backdrop="static">
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
                            Giải pháp TKNL<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddlSolution2"
                                Name="Giải pháp" DataMember="Id" DataValueField="Id" DataTextField="TenGiaiPhap">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Display="Dynamic" runat="server"
                                CssClass="text-danger" ControlToValidate="ddlSolution2" ValidationGroup="valAddSolutionTKNL"
                                Text="Vui lòng chọn giải pháp"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Loại nhiên liệu <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlFuelType2" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valAddSolutionTKNL" OnSelectedIndexChanged="ddlFuel2_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlFuelType2"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Vui lòng chọn loại nhiên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3" for="inputSmall">
                            Đơn vị<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlMeasure2" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valAddSolutionTKNL">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddlMeasure2"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Vui lòng chọn đơn vị tính"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Hệ thống sử dụng <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlUseSysName" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mô tả giải pháp<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtMucDichGPTT" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtMucDichGPTT"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Vui lòng nhập mục đích của giải pháp"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mức tiết kiệm<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtMucTietKiemNLTT" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtMucTietKiemNLTT"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Vui lòng nhập lượng tiết kiệm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMucTietKiemNLTT"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-3">
                            Tương đương(%):</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtTuongDuongTT" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtTuongDuongTT"
                                CssClass="text-danger" MinimumValue="0" MaximumValue="100" Type="Double" ValidationGroup="valAddSolutionTKNL"
                                Text="Vui lòng nhập mức tương đương trong khoảng(0% đến 100%)" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tiết kiệm C.phí (Tr.đồng)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtTKCPThucTe" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtTKCPThucTe"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Vui lòng nhập tiết kiệm chi phí"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTKCPThucTe"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-3">
                            C.phí đầu tư (Tr.đồng)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtChiPhiThucTe" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtChiPhiThucTe"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Vui lòng nhập chi phí thực tế"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtChiPhiThucTe"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Lợi ích khác:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtLoiIchKhacTT" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Ghi chú:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtGhiChuTT" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveSolutionResult" runat="server" Visible="true" ValidationGroup="valAddSolutionTKNL"
                    Text="Lưu lại" OnClick="btnSaveSolutionResult_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgPlanDeviceOne" data-backdrop="static">
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
                            Tên thiết bị<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtTenTB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtTenTB"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB" Text="Vui lòng nhập tên thiết bị"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mô tả tính năng, vị trí sử dụng của thiết bị<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtTinhNangTB" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtTinhNangTB"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB" Text="Vui lòng nhập mô tả tính năng,.."
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Cách thức lắp đặt<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlCacThucLD" Name="Khả năng thực hiện" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Mới" Text="Mới"></asp:ListItem>
                                <asp:ListItem Value="Thay thế" Text="Thay thế"></asp:ListItem>
                                <asp:ListItem Value="Nâng cấp" Text="Nâng cấp"></asp:ListItem>
                                <asp:ListItem Value="Sửa chữa" Text="Sửa chữa"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlCacThucLD"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB" Text="Vui lòng chọn các thức lắp đặt"
                                Display="Dynamic"></asp:RequiredFieldValidator>
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
                            Khả năng thực hiện(%)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtKhaNangTB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtKhaNangTB"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB" Text="Vui lòng nhập khả năng thực hiện"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtKhaNangTB"
                                MinimumValue="0" MaximumValue="100" Type="Double" ValidationGroup="viewSolutionTB"
                                CssClass="text-danger" Text="Vui lòng nhập khả năng thực hiện trong khoảng(0% đến 100%)"
                                Display="Dynamic"></asp:RangeValidator>
                        </div>
                        <label class="col-lg-3">
                            Cam kết<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlCamKetTB" Name="Khả năng thực hiện" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Cao" Text="Cao"></asp:ListItem>
                                <asp:ListItem Value="Trung bình" Text="Trung bình"></asp:ListItem>
                                <asp:ListItem Value="Thấp" Text="Thấp"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlCamKetTB"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB" Text="Vui lòng chọn mức cam kết"
                                Display="Dynamic"></asp:RequiredFieldValidator>
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
<div class="modal" tabindex="-1" role="dialog" id="dlgDeviceResultOne" data-backdrop="static">
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
                            Tên thiết bị<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtTenTietBiBS" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtTenTietBiBS"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTB" Text="Vui lòng nhập tên thiết bị"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mô tả tính năng, vị trí sử dụng của thiết bị<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtMoTaTinhNangBS" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtMoTaTinhNangBS"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTB" Text="Vui lòng nhập mô tả tính năng,.."
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Cách thức lắp đặt<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlCacThucLDBS" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Mới" Text="Mới"></asp:ListItem>
                                <asp:ListItem Value="Thay thế" Text="Thay thế"></asp:ListItem>
                                <asp:ListItem Value="Nâng cấp" Text="Nâng cấp"></asp:ListItem>
                                <asp:ListItem Value="Sửa chữa" Text="Sửa chữa"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCachThucLDBS" runat="server" ValidationGroup="valAddSolutionTB"
                                CssClass="text-danger" Display="Dynamic" Text="Vui lòng chọn cách thức lắp đặt"
                                ControlToValidate="ddlCacThucLDBS"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Thực hiện:</label>
                        <div class="col-lg-3">
                            <asp:RadioButtonList ID="rblThucHien" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Text="Có" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Không"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Lý do lắp mới hoặc nâng cấp thay thế:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtLyDoKhongThucHien" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Thực hiện theo :</label>
                        <div class="col-lg-9">
                            <asp:RadioButtonList ID="rblIsNew" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Text="Kế hoạch" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Không có trong kế hoạch"></asp:ListItem>
                            </asp:RadioButtonList>
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

    function ShowDialogSolutionPlanOne(id) {

        if (id == "0") {
            $("#<%=hddkhtknl.ClientID%>").val('0');
            /* $("#<%=txtTKNLMucTieuDukien.ClientID%>").val('');
            $("#<%=txtchiphidukienTKNL.ClientID%>").val('');
            $("#<%=txtmuctieuTKNL.ClientID%>").val('');
            $("#<%=txtKhaNangTKNL.ClientID%>").val('');*/
        }
        else {

        }
        $('#dlgSolutionPlanOne').modal('toggle');
    }
    function updategiaiphapTKNL() {
        $('#dlgSolutionResult').modal('toggle');
    }
    function ShowDialogSolutionResultOne(id) {
        if (id == "0") {
            $("#<%=hddkhtknl.ClientID%>").val('');
        }
        else {
            $("#<%=hddkhtknl.ClientID%>").val(id);
        }
        $('#dlgSolutionResultOne').modal('toggle');
    }
    function ShowDialogDevicePlanOne(id) {
        if (id == "0") {
            $("#<%=hddkhTB.ClientID%>").val('');
            $("#<%=txtlydoTB.ClientID%>").val('');
            $("#<%=txtTinhNangTB.ClientID%>").val('');
        }
        else {
        }
        $('#dlgPlanDeviceOne').modal('toggle');
    }
    function showgiaiphap() {
        $('#mygiaiphap').modal('toggle');
    }
    function showkehoach() {
        $('#myModalthuchien').modal('toggle');
    }
    function ShowDialogDeviceResultOne(id) {
        if (id == "0") {
            $("#<%=hddkhTB.ClientID%>").val('');
        }
        $('#dlgDeviceResultOne').modal('toggle');
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
