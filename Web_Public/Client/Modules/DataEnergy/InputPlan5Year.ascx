<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InputPlan5Year.ascx.cs"
    Inherits="Client_Module_DataEngery_InputPlan5Year" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<!-- Begin: Content -->
<!-- Dashboard Tiles -->
<asp:Literal ID="clientview" runat="server"></asp:Literal>
<label class="control-label">
    <asp:Literal ID="ltPeriod1" runat="server" Text="Kết quả thực hiện kế hoạch 5 năm"
        Visible="false"></asp:Literal></label>
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0;">
        <div class="col-lg-12" style="display: none">
            <asp:Literal ID="ltDataPeriod" runat="server"></asp:Literal>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        1. Kết quả thực hiện tiết kiệm năng lượng<a onclick="ShowDialogSolutionPlan(0,1);"
                            style="float: right; cursor: pointer; text-decoration: none;"><i class="fa fa-plus">
                            </i>&nbsp;Thêm kết quả thực hiện</a></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%">
                                Giải pháp TKNL dự kiến áp dụng &nbsp; <a style="cursor: pointer;" class="fs9 btn btn-primary"
                                    title="Thêm giải pháp" onclick="showgiaiphap5();"><span class="fa fa-plus"></span>
                                    &nbsp;Thêm giải pháp</a>
                            </th>
                            <th style="width: 15%">
                                Mục đích của giải pháp
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
                        <asp:Repeater ID="rptKetQuaTKNL" runat="server">
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
                                        <%# Eval("MucTKThucTe") != null ? Tool.ConvertDecimalToString(Eval("MucTKThucTe"), 2) : ""%>
                                        <br />
                                        Tương đương:
                                        <%# Eval("TuongDuongTT")%>
                                        <br />
                                        Tiết kiệm chi phí:                                        
                                        <%# Eval("MucTKCPThucTe") != null ? Tool.ConvertDecimalToString(Eval("MucTKCPThucTe"), 0) : ""%>
                                        <br />
                                        Lợi ích khác:
                                        <%# Eval("LoiIchKhacTT")%>
                                    </td>
                                    <td class="text-right">                                        
                                        <%# Eval("CPThucTe") != null ? Tool.ConvertDecimalToString(Eval("CPThucTe"), 0) : ""%>
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
                        <i class="fa fa-tasks"></i>&nbsp;Thay thế nâng cấp, bổ sung thiết bị công nghệ <a
                            style="float: right; cursor: pointer; text-decoration: none; color: #205081"
                            onclick="updateiaiphapTB5(1,0);"><i class="fa fa-plus"></i>&nbsp;Thêm kết quả thực
                            hiện</a></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%">
                                Năm
                            </th>
                            <th style="width: 15%">
                                Tên thiết bị
                            </th>
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
                            <th style="width: 5%">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptKetQuaTB" runat="server" OnItemCommand="rptKetQuaTB_ItemCommand"
                            OnItemDataBound="rptResultTB_ItemDataBound">
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
                <asp:Literal ID="ltNextPeriod" runat="server" Text="Kế hoạch thực hiện"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        1. Kế hoạch thực hiện tiết kiệm năng lượng
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddPlan" runat="server" Text="Thêm mới" ToolTip="Thêm mới"
                                OnClientClick="javascript:ShowDialogSolutionPlan(0,1); return false;"><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 10%">
                                Giải pháp TKNL dự kiến áp dụng &nbsp;
                                <asp:LinkButton ID="btnAddSolution" CssClass="fs9 btn btn-primary" runat="server"
                                    Text="Thêm giải pháp" ToolTip="Thêm giải pháp" OnClientClick='javascript:showgiaiphap5(); return false;'><i class="fa fa-plus"></i>&nbsp;"Thêm giải pháp</asp:LinkButton>
                            </th>
                            <th style="width: 5%">
                                Năm thực hiện
                            </th>
                            <th style="width: 10%">
                                Loại nhiên liệu
                            </th>
                            <th style="width: 15%">
                                Mục đích
                            </th>
                            <th style="width: 20%">
                                Dự kiến kết quả
                            </th>
                            <th style="width: 5%">
                                Dự kiến CP<br />
                                (Tr.đồng)
                            </th>
                            <th style="width: 20%">
                                Ghi chú
                            </th>
                            <th style="width: 15%">
                                Khả năng thực hiện
                            </th>
                            <th style="width: 5%">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="cpRepeater" runat="server" OnItemCommand="cpRepeater_ItemCommand"
                            OnItemDataBound="rptResultTB_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("TenGiaiPhap")%>
                                    </td>
                                    <td>
                                        <%# Eval("NamBatDau")%>
                                        -
                                        <%# Eval("NamKetThuc")%>
                                    </td>
                                    <td>
                                        <%# Eval("FuelName")%>
                                    </td>
                                    <td>
                                        <%# Eval("MucTieuGP")%>
                                    </td>
                                    <td>
                                        Mức TK:                                        
                                          <%#  Tool.ConvertDecimalToString(Eval("MucTietKiemDuKien"), 0)%>
                                        (<i><%#Eval("MeasurementName")%></i>)
                                        <br />
                                        Tương đương:
                                        <%# Eval("TuongDuong") != DBNull.Value && Eval("TuongDuong").ToString()!=""? Eval("TuongDuong")+"%":""%>
                                        <br />
                                        Thành tiền:
                                        <%# (Eval("ThanhTien") != DBNull.Value && Eval("ThanhTien").ToString() != "") ? Tool.ConvertDecimalToString(Eval("ThanhTien"), 0) + " (tr.đồng)" : ""%>                                        
                                        <br />
                                        Lợi ích khác:
                                        <%# Eval("LoiIchKhac")%>
                                    </td>
                                    <td class="text-right">
                                        <%#  Tool.ConvertDecimalToString(Eval("ChiPhiDuKien"), 0)%>
                                       
                                    </td>
                                    <td>
                                        <%# Eval("GhiChu")%>
                                    </td>
                                    <td>
                                        Khả năng:
                                        <%# Eval("KhaNangThucHien")%><br />
                                        Cam kết:
                                        <%# Eval("MucCamKet") != DBNull.Value && Eval("MucCamKet").ToString() != "" ? Eval("MucCamKet") + "%" : ""%>
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
                        2. Kế hoạch thay thế nâng cấp, bổ sung thiết bị công nghệ
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddDevice" runat="server" Text="Thêm mới" ToolTip="Thêm mới"
                                OnClientClick='javascript:ShowDialogDevicePlan(0,1); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%">
                                Năm
                            </th>
                            <th style="width: 15%">
                                Tên thiết bị
                            </th>
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
            <label class="control-label" style="display:none">
                <asp:Literal ID="ltPeriod" runat="server" Text="Kết quả thực hiện kế hoạch 5 năm"></asp:Literal></label>
            <div class="margin-bottom-10" style="display:none">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        1. Kết quả thực hiện tiết kiệm năng lượng
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 50%">
                                Năm
                            </th>
                            <th style="width: 10%">
                                <%=ReportYear - 4%>
                            </th>
                            <th style="width: 10%">
                                <%=ReportYear - 3%>
                            </th>
                            <th style="width: 10%">
                                <%=ReportYear - 2%>
                            </th>
                            <th style="width: 10%">
                                <%=ReportYear - 1%>
                            </th>
                            <th style="width: 10%">
                                <%=ReportYear%>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptResultSolution" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("Year")%>
                                    </td>
                                    <td style="text-align: right">
                                        <%#Eval("1")%>
                                    </td>
                                    <td style="text-align: right">
                                        <%#Eval("2")%>
                                    </td>
                                    <td style="text-align: right">
                                        <%#Eval("3")%>
                                    </td>
                                    <td style="text-align: right">
                                        <%#Eval("4")%>
                                    </td>
                                    <td style="text-align: right">
                                        <%#Eval("5")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10" style="display:none">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        2. Kết quả thay thế nâng cấp, bổ sung thiết bị công nghệ
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%">
                                Năm thực hiện
                            </th>
                            <th style="width: 15%">
                                Tên thiết bị
                            </th>
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
                        <asp:Repeater ID="Repeater1" runat="server">
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
                                        Khả năng:
                                        <%# Eval("KhaNang") != DBNull.Value && Eval("KhaNang").ToString() != "" ? Eval("KhaNang") + "%" : ""%>
                                        <br />
                                        Cam kết:
                                        <%# Eval("CamKet")%>
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
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<asp:HiddenField ID="hddvalue" runat="server" Value="" />
<asp:HiddenField ID="hddngaytao" runat="server" Value="1" />
<asp:HiddenField ID="hddkhtknl" runat="server" Value="1" />
<asp:HiddenField ID="hddkhTB" runat="server" Value="1" />
<asp:HiddenField ID="hdnFiveYear" runat="server" Value="0" />
<asp:HiddenField ID="hdnPlan" runat="server" Value="0" />
<!-- / modal dialog giaiphap -->
<div class="modal" tabindex="-1" role="dialog" id="mygiaiphap5" data-backdrop="static">
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
                        <label for="message-text" class="col-lg-3 control-label">
                            Tên giải pháp:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" class="form-control" ID="txtnamegp"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnamegp"
                                ValidationGroup="viewSolution" Text="Vui lòng nhập tên giải pháp" Display="Dynamic"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-lg-3 control-label ">
                            Mô tả:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" class="form-control" ID="txtmotagp" TextMode="MultiLine"
                                Rows="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveSolution" runat="server" Visible="true" Text="Lưu lại"
                    ValidationGroup="viewSolution" OnClick="btnSaveSolution_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgPlanSolution" data-backdrop="static">
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
                        <label class="col-lg-2">
                            Giải pháp TKNL<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-10">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddlSolution"
                                Name="Giải pháp" DataMember="Id" DataValueField="Id" DataTextField="TenGiaiPhap">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                CssClass="text-danger" ControlToValidate="ddlSolution" ValidationGroup="viewSolutionTKNL5"
                                Text="Vui lòng chọn giải pháp"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2">
                            Năm bắt đầu<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtNamBD" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtNamBD"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập năm bắt đầu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtNamBD"
                                MinimumValue="0" MaximumValue="9999" ValidationGroup="viewSolutionTKNL5" Text="Năm chỉ nhập số. Vui lòng kiểm tra lại"
                                Display="Dynamic"></asp:RangeValidator>
                        </div>
                        <label class="col-lg-2">
                            Năm KT<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtNamKT" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtNamKT"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập năm kết thúc"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtNamKT"
                                CssClass="text-danger" MinimumValue="0" MaximumValue="9999" ValidationGroup="viewSolutionTKNL5"
                                Text="Năm chỉ nhập số. Vui lòng kiểm tra lại" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2">
                            Mục đích<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="txtmuctieuTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmuctieuTKNL"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập mục đích giải pháp thực hiện"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2" for="inputSmall">
                            Loại nhiên liệu <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlFuelType" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="viewSolutionTKNL5" OnSelectedIndexChanged="ddlFuel_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlFuelType"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng chọn nhiên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-2" for="inputSmall">
                            Đơn vị<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlMeasure" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valAddSolutionTKNLOne">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddlMeasure"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng chọn đơn vị tính"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2">
                            Lượng tiết kiệm<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtTKNLMucTieuDukien" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTKNLMucTieuDukien"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập lượng tiết kiệm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTKNLMucTieuDukien"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Lượng tiêu thụ chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-2">
                            Tương đương (%):</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtTuongDuong" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txtTuongDuong"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập mức tương đương từ 0% đến 100%"
                                Display="Dynamic" Type="Double" MinimumValue="0" MaximumValue="100"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2">
                            Tiết kiệm C.phí (Tr.đồng)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtThanhTien" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtThanhTien"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập lượng tiết kiệm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtThanhTien"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Tiết kiệm C.phí chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-2">
                            Lợi ích khác:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtLoiIchKhac" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2">
                            Dự kiến chi phí (Tr.đồng)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtchiphidukienTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtchiphidukienTKNL"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập chi phí dự kiến"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtchiphidukienTKNL"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Dự kiến chi phí chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-2">
                            Hoàn vốn(Năm):</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtvonTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtvonTKNL"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập hoàn vốn"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txtvonTKNL"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng chỉ nhập số"
                                Display="Dynamic" Type="Double" MinimumValue="0" MaximumValue="1000"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2">
                            Khả năng thực hiện(%)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtKhaNangTKNL" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtKhaNangTKNL"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập khả năng thực hiện"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtKhaNangTKNL"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng nhập khả năng thực hiện từ 0% đến 100%"
                                Display="Dynamic" Type="Double" MinimumValue="0" MaximumValue="100"></asp:RangeValidator>
                        </div>
                        <label class="col-lg-2">
                            Mức cam kết<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:DropDownList runat="server" ID="ddlCamKet" Name="Khả năng thực hiện" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Cao" Text="Cao"></asp:ListItem>
                                <asp:ListItem Value="Trung bình" Text="Trung bình"></asp:ListItem>
                                <asp:ListItem Value="Thấp" Text="Thấp"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlCamKet"
                                CssClass="text-danger" ValidationGroup="viewSolutionTKNL5" Text="Vui lòng chọn mức cam kết"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label">
                            Ghi chú:</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="txtGhiChu" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSavePlan" runat="server" Visible="true" ValidationGroup="viewSolutionTKNL5"
                    Text="Lưu lại" OnClick="btnSavePlan_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgDevicePlan" data-backdrop="static">
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
                        <label class="col-lg-2">
                            Năm thực hiện<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" name="year" ID="txtnamTB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtnamTB"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB5" Text="Vui lòng nhập năm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtnamTB"
                                CssClass="text-danger" MinimumValue="0" MaximumValue="9999" ValidationGroup="viewSolutionTB5"
                                Text="Năm chỉ nhập số. Vui lòng kiểm tra lại" Display="Dynamic"></asp:RangeValidator>
                        </div>
                        <label class="col-lg-2">
                            Tên thiết bị<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtTenTB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtTenTB"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB5" Text="Vui lòng nhập tên thiết bị"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2">
                            Mô tả tính năng, vị trí sử dụng của thiết bị<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtTinhNangTB" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator101" runat="server" ControlToValidate="txtTinhNangTB"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB5" Text="Vui lòng nhập mô tả tính năng"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-2">
                            Cách thức lắp đặt<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:DropDownList runat="server" ID="ddlCachThucLD" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Mới" Text="Mới"></asp:ListItem>
                                <asp:ListItem Value="Thay thế" Text="Thay thế"></asp:ListItem>
                                <asp:ListItem Value="Nâng cấp" Text="Nâng cấp"></asp:ListItem>
                                <asp:ListItem Value="Sửa chữa" Text="Sửa chữa"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ValidationGroup="viewSolutionTB5"
                                CssClass="text-danger" Display="Dynamic" Text="Vui lòng chọn cách thức lắp đặt"
                                ControlToValidate="ddlCachThucLD"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2">
                            Lý do lắp mới hoặc nâng cấp thay thế:</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="txtlydoTB" TextMode="MultiLine" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2">
                            Khả năng thực hiện (%)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="txtKhaNangTB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtKhaNangTB"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB5" Text="Vui lòng nhập khả năng thực hiện"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtKhaNangTB"
                                CssClass="text-danger" Type="Double" MinimumValue="0" MaximumValue="100" ValidationGroup="viewSolutionTB5"
                                Text="Nhập khả năng thực hiện trong khoảng từ 0% đến 100%" Display="Dynamic"></asp:RangeValidator>
                        </div>
                        <label class="col-lg-2">
                            Mức cam kết<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-4">
                            <asp:DropDownList runat="server" ID="ddlCamKetTB" Name="Khả năng thực hiện" CssClass="form-control input-sm">
                                <asp:ListItem Value="" Text="---Chọn---" Selected="False"></asp:ListItem>
                                <asp:ListItem Value="Cao" Text="Cao"></asp:ListItem>
                                <asp:ListItem Value="Trung bình" Text="Trung bình"></asp:ListItem>
                                <asp:ListItem Value="Thấp" Text="Thấp"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlCamKetTB"
                                CssClass="text-danger" ValidationGroup="viewSolutionTB5" Text="Vui lòng chọn mức cam kết"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveDevice" runat="server" Visible="true" Text="Lưu lại" OnClick="btnSaveDevice_Click"
                    CssClass="btn btn-sm btn-primary mr10" ValidationGroup="viewSolutionTB5" AutoPostback="false"
                    UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function ShowDialogSolutionPlan(id, plan) {

        if (id != "" && id != "0") {

            $("#<%=hddkhtknl.ClientID%>").val(id);
        }
        else {
            $("#<%=hddkhtknl.ClientID%>").val("0");
            $("#<%=txtTKNLMucTieuDukien.ClientID%>").val('');
            $("#<%=txtchiphidukienTKNL.ClientID%>").val('');
            
            $("#<%=txtKhaNangTKNL.ClientID%>").val('');
            $("#<%=txtvonTKNL.ClientID%>").val('');
        }
        $('#dlgPlanSolution').modal('toggle');
    }

    function ShowDialogDevicePlan(id, plan) {

        if (id != "" && id != "0") {
            $("#<%=hddkhTB.ClientID%>").val(id);
        }
        else {
            $("#<%=hddkhTB.ClientID%>").val("0");
            $("#<%=txtlydoTB.ClientID%>").val('');
            $("#<%=txtnamTB.ClientID%>").val('');
            $("#<%=txtTinhNangTB.ClientID%>").val('');
        }

        $('#dlgDevicePlan').modal('toggle');
    }

    function showgiaiphap5(fiveYear, plan) {
        $("#<%=hdnFiveYear.ClientID%>").val(fiveYear);
        $("#<%=hdnPlan.ClientID%>").val(plan);
        $('#mygiaiphap5').modal('toggle');
    }

    function showgiaiphap5() {
        $('#mygiaiphap5').modal('toggle');
    }
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
