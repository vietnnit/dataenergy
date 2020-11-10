<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductYear12.ascx.cs" Inherits="Client_Modules_DataEnergy_ProductYear12" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12" style="display: none;">
            <div class="">
                <div class="control-label pt5" style="width: 100%" for="inputSmall">
                    <b>2.1. Thông tin cơ sở hạ tầng</b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnEditInfo" runat="server" Text="Sửa thông tin" ToolTip="Sửa thông tin"
                            OnClientClick='javascript:UpdateInfratructure(); return false;'><i class="fa fa-edit"></i>&nbsp;Sửa thông tin</asp:LinkButton>
                    </div>
                </div>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <thead>
                    <tr>
                        <td style="width: 10%">Năm đưa cơ sở vào hoạt động:
                        </td>
                        <td style="width: 10%;" colspan="2">
                            <asp:Literal ID="ltActiveYear" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 10%">Số lao động/diện tích mặt bằng
                        </th>
                        <th style="width: 10%">Khu vực sản xuất
                        </th>
                        <th style="width: 15%">Khu vực văn phòng
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Tổng số lao động hiện tại
                        </td>
                        <td>
                            <asp:Literal ID="ltProduceEmployeeNo" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="ltOfficeEmployeeNo" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Diện tích mặt bằng(m<sup>2</sup>)
                        </td>
                        <td>
                            <asp:Literal ID="ltProduceArea" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="ltOfficeArea" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <%--1. Năng lực sản xuất của cơ sở năm [N-1] và [N]--%>
        <div class="col-lg-12">
            <label class="control-label">
                <asp:Literal ID="ltOldYear" runat="server" Text="1. Thông tin về cơ sở hạ tầng và hoạt động"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>a. Năng lực sản xuất năm
                            <asp:Literal ID="ltReportYear" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddProductResult" runat="server" Text="Thêm mới" ToolTip="Thêm mới"
                                OnClientClick='javascript:AddProductQty(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 15%">Tên sản phẩm
                                <br />
                                <asp:LinkButton ID="btnAddProductNext" runat="server" CssClass="fs9 btn btn-primary"
                                    Text="Thêm sản phẩm" ToolTip="Thêm sản phẩm" OnClientClick='javascript:AddProduct(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm sản phẩm</asp:LinkButton>
                            </th>
                            <th style="width: 10%">Đơn vị đo
                            </th>
                            <th style="width: 15%">Theo thiết kế
                            </th>
                            <th style="width: 20%">Mức sản xuất hiện tại
                            </th>
                            <th style="width: 20%">Tiêu thụ năng lượng theo sản phẩm
                            </th>
                            <th style="width: 20%">Doanh thu
                            </th>
                            <th style="width: 5%">Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptProductResult" runat="server" OnItemCommand="rptProductResult_ItemCommand"
                            OnItemDataBound="rptProductResult_ItemDataBound">
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
                                    <td class="text-right">
                                        <asp:HiddenField ID="hdTieuThuNLTheoSP" runat="server" Value='<%#Eval("Id")%>' />
                                        <asp:Literal ID="ltTieuThuNLTheoSP" runat="server"></asp:Literal>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("DoanhThuTheoSP ")%>
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
                        <i>b. Kế hoạch sản xuất năm 
                            <asp:Literal ID="ltReportNext" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddProductNextResult" runat="server" Text="Thêm mới" ToolTip="Thêm sản phẩm"
                                OnClientClick='javascript:AddProductQtyPlan(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 15%">Tên sản phẩm<br />
                                <asp:LinkButton ID="btnAddProductPlan" runat="server" CssClass="fs9 btn btn-primary"
                                    Text="Thêm sản phẩm" ToolTip="Thêm sản phẩm" OnClientClick='javascript:AddProduct(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm sản phẩm</asp:LinkButton>
                            </th>
                            <th style="width: 10%">Đơn vị đo</th>
                            <th style="width: 15%">Theo thiết kế
                            </th>
                            <th style="width: 15%">Mức sản xuất dự kiến
                            </th>
                            <th style="width: 5%">Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptProductPlan" runat="server" OnItemCommand="rptProductPlan_ItemCommand"
                            OnItemDataBound="rptProductPlan_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("ProductName")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Measurement")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("DesignQuantity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("MaxQuantity")%>
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

        <%--2. Tiêu thụ năng lượng--%>
        <div class="col-lg-12">
            <label class="control-label">
                <asp:Literal ID="ltDuKienMucTieuThuNangLuong" runat="server" Text="2. Dự kiến mức tiêu thụ năng lượng"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>a. Mức tiêu thụ nhiên liệu
                            <asp:Literal ID="Literal5" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btAddFuelFuture" OnClick="btAddFuelFuture_Click" runat="server" Text="Hiệu chỉnh" ToolTip="Hiệu chỉnh"><i class="fa fa-edit"></i>&nbsp;Hiệu chỉnh</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="btAddFuelFutureUpdate" OnClick="btAddFuelFutureUpdate_Click" Visible="false" runat="server" Text="Cập nhật" ToolTip="Cập nhật"><i class="fa fa-check"></i>&nbsp;Cập nhật</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="btAddFuelFutureCancel" OnClick="btAddFuelFutureCancel_Click" runat="server" Text="Hủy" ToolTip="Hủy" Visible="false"><i class="fa fa-close"></i>&nbsp;Hủy</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%">STT
                            </th>
                            <th style="width: 40%">Loại năng lượng
                            </th>
                            <th style="width: 10%;">Đơn vị tính
                            </th>
                            <th style="width: 15%;">Lượng tiêu thụ</th>
                            <th>Ghi chú</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptFuelFuture" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Container.ItemIndex+1  %>
                                    </td>
                                    <td>
                                        <%# Eval("FuelName")%>
                                    </td>
                                    <td>
                                        <%#Eval("MeasurementName")%>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:HiddenField ID="hdFuelId" runat="server" Value='<%# Eval("FuelId")%>' />
                                        <asp:HiddenField ID="hdGroupFuelId" runat="server" Value='<%# Eval("GroupFuelId")%>' />
                                        <asp:HiddenField ID="hdMeasurementId" runat="server" Value='<%# Eval("MeasurementId")%>' />
                                        <asp:TextBox ID="txtNoFuel" ReadOnly="true" CssClass="form-control input-sm onlyNumberCss" runat="server" Text='<%#Eval("NoFuel") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NoFuel"),2).Trim() : ""%>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReason" runat="server" ReadOnly="true" CssClass="form-control input-sm" Text=' <%#Eval("Reason")%>'></asp:TextBox>
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
                        <i>b. Tiêu thụ điện                            </i>
                        <div style="float: right">
                            <asp:LinkButton ID="btAddElectrictFuture" OnClick="btAddElectrictFuture_Click" runat="server" Text="Hiệu chỉnh" ToolTip="Hiệu chỉnh"><i class="fa fa-edit"></i>&nbsp;Hiệu chỉnh</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="btAddElectrictFutureUpdate" OnClick="btAddElectrictFutureUpdate_Click" Visible="false" runat="server" Text="Cập nhật" ToolTip="Cập nhật"><i class="fa fa-check"></i>&nbsp;Cập nhật</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="btAddElectrictFutureCancel" OnClick="btAddElectrictFutureCancel_Click" runat="server" Text="Hủy" ToolTip="Hủy" Visible="false"><i class="fa fa-close"></i>&nbsp;Hủy</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <tbody>
                        <tr class="primary fs12">
                            <td style="width: 30%">I. Điện năng mua từ lưới
                            </td>
                            <td style="width: 30%">Công suất đăng ký(kW)<asp:TextBox ID="txtUsingElectrictFuture_InstalledCapacity" ReadOnly="true" CssClass="form-control input-sm onlyNumberCss" runat="server"></asp:TextBox>
                            </td>
                            <td>Điện năng(10<sup>6</sup>kWh/năm)
                                <asp:TextBox ID="txtUsingElectrictFuture_Quantity" CssClass="form-control input-sm onlyNumberCss" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>II. Điện tự sản xuất (nếu có):</td>
                            <td>Công suất lắp đặt(kW):<asp:Literal ID="ltUsingElectrictFuture_InstalledCapacity" runat="server"></asp:Literal>
                                kW</td>
                            <td>Điện năng sản xuất:<asp:Literal ID="ltUsingElectrictFuture_Quantity" runat="server"></asp:Literal>
                                10<sup>6</sup>kWh/năm</td>
                        </tr>
                        <asp:Repeater ID="rptUsingElectrictFuture" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Container.ItemIndex+1  %>.<%# Eval("TechName")%>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInstalledCapacity" runat="server" ReadOnly="true" CssClass="form-control input-sm onlyNumberCss" Text=' <%#Eval("InstalledCapacity")%>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProduceQty" runat="server" CssClass="form-control input-sm onlyNumberCss" ReadOnly="true" Text=' <%#Eval("ProduceQty")%>'></asp:TextBox>
                                        <asp:HiddenField ID="hdTechKey" runat="server" Value='<%#Eval("TechKey")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td>III. Điện bán ra (nếu có):</td>
                            <td>Công suất bán ra(kW):<asp:TextBox ID="txtUsingElectrictFuture_CongSuatBanRa" ReadOnly="true" CssClass="form-control input-sm onlyNumberCss" runat="server"></asp:TextBox>
                            </td>
                            <td>Sản lượng điện bán ra(10<sup>6</sup>kWh/năm):<asp:TextBox ID="txtUsingElectrictFuture_SanLuongBanRa" ReadOnly="true" CssClass="form-control input-sm onlyNumberCss" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <%--3. Giải pháp tiết kiệm năng lượng--%>
        <div class="col-lg-12">
            <label class="control-label">
                <asp:Literal ID="Literal6" runat="server" Text="3. Giải pháp tiết kiệm năng lượng"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>a. Kết quả đạt được trong năm 
                            <asp:Literal ID="ltSolutionResult" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddPlan" runat="server" Text="Thêm kết quả thực hiện" ToolTip="Thêm mới kết quả thực hiện"
                                OnClientClick='javascript:ShowDialogSolutionResultOne(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 10%">Giải pháp TKNL<br />
                                <asp:LinkButton ID="btnAddSolution" runat="server" CssClass="fs9 btn btn-primary"
                                    Text="Thêm giải pháp" ToolTip="Thêm giải pháp" OnClientClick='javascript:showgiaiphap(1,0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm giải pháp</asp:LinkButton>
                            </th>
                            <th style="width: 10%">Nhiên liệu
                            </th>
                            <th style="width: 15%">Giải pháp tiết kiệm năng lượng đối với hệ thống
                            </th>
                            <th style="width: 15%">Mô tả giải pháp
                            </th>
                            <th style="width: 20%">Kết quả đạt được
                            </th>
                            <th style="width: 10%">C.Phí đầu tư<br />
                                (Tr.đồng)
                            </th>
                            <th style="width: 20%">Ghi chú
                            </th>
                            <th style="width: 5%">Thao tác
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
                                        <%# Eval("FuelName")%>
                                    </td>
                                    <td>
                                        <%# Eval("SysName")%>
                                    </td>
                                    <td>
                                        <%# Eval("MucTieuGP")%>
                                    </td>

                                    <td>Mức TK:
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
                        <i>b. Kế hoạch và mục tiêu tiết kiệm, sử dụng hiệu quả năng lượng năm
                        <asp:Literal ID="ltSolutionNextYear" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddPlanNext" runat="server" Text="Thêm kế hoạch" ToolTip="Thêm mới kế hoạch"
                                OnClientClick='javascript:ShowDialogSolutionPlanOne(0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="table-responsive">
                    <table class="table table-bordered table-hover mbn">
                        <thead>
                            <tr class="primary fs12">
                                <th style="width: 200px">Giải pháp TKNL dự kiến áp dụng
                                </th>
                                <th style="width: 200px">Nhiên liệu
                                </th>
                                <th style="width: 300px">Giải pháp tiết kiệm năng lượng đối với hệ thống
                                </th>
                                <th style="width: 300px">Mô tả giải pháp
                                </th>
                                <th style="width: 300px">Dự kiến kết quả
                                </th>
                                <th style="width: 100px">Chi phí<br />
                                    (Tr.đồng)
                                </th>
                                <th style="width: 200px">Ghi chú
                                </th>
                                <th style="width: 50px">Thao tác
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptSolutionPlan" runat="server" OnItemCommand="rptPlanTKNL_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("TenGiaiPhap")%>
                                        </td>
                                        <td>
                                            <%# Eval("FuelName")%>
                                        </td>
                                        <td>
                                            <%# Eval("SysName")%>
                                        </td>
                                        <td>
                                            <%# Eval("MucTieuGP")%>
                                        </td>
                                        <td>Mức TK:
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
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>

<%--dialog giải pháp tiết kiệm năng lượng--%>
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
                            Phânloại <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlPhanLoaiHeThong" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlPhanLoaiHeThong_SelectedIndexChanged" runat="server">
                                <asp:ListItem Text="Hệ thống sử dụng điện" Value="E"></asp:ListItem>
                                <asp:ListItem Text="Hệ thống sử dụng nhiên liệu nhiệt" Value="T"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-lg-3" for="inputSmall">
                            Hệ thống sử dụng <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="update_ddlUseSysName" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPhanLoaiHeThong" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlUseSysName" runat="server" CssClass="form-control input-sm">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                <asp:LinkButton ID="btnSaveSolutionResult" runat="server" Visible="true"
                    Text="Lưu lại" OnClick="btnSaveSolutionResult_Click" CssClass="btn btn-sm btn-primary mr10"></asp:LinkButton>
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
                            Phân loại <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlPhanLoaiHeThongPlan" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlPhanLoaiHeThongPlan_SelectedIndexChanged" runat="server">
                                <asp:ListItem Text="Hệ thống sử dụng điện" Value="E"></asp:ListItem>
                                <asp:ListItem Text="Hệ thống sử dụng nhiên liệu nhiệt" Value="T"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label class="col-lg-3" for="inputSmall">
                            Hệ thống sử dụng <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="update_ddlPhanLoaiHeThongPlan" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPhanLoaiHeThongPlan" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlUseSysNamePlan" runat="server" CssClass="form-control input-sm">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                            Loại năng lượng<span class="append-icon right text-danger">*</span></label>
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
                        <label class="col-lg-3 control-label">
                            Ghi chú:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtGhiChu" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSavePlan" runat="server" Visible="true"
                    Text="Lưu lại" OnClick="btnSavePlan_Click" CssClass="btn btn-sm btn-primary mr10"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>

<div class="modal" tabindex="-1" role="dialog" id="divProduct" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Cập nhật danh mục sản phẩm sản xuất</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên sản phẩm<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtProductName"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập tên sản phẩm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Năng lực sản xuất theo thiết kế<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtDesignQty" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtDesignQty"
                                CssClass="text-danger" Text="Vui lòng nhập năng lực sản xuất là ký tự số" ValidationGroup="valProduct"
                                Type="Double" MinimumValue="0" MaximumValue="999999999999" Display="Dynamic"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDesignQty"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập năng lực sản xuất"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Đơn vị tính<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtMeasurement" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMeasurement"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập đơn vị tính tấn/năm;m/năm;..."
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Năm Bắt đầu SX<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtYearStart" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="rvYearStart" runat="server" ControlToValidate="txtYearStart"
                                CssClass="text-danger" Text="Vui lòng nhập năm bắt đầu trong khoảng từ 0 đến 9999"
                                ValidationGroup="valProduct" Type="Double" MinimumValue="0" MaximumValue="9999"
                                Display="Dynamic"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtYearStart"
                                ValidationGroup="valProduct" Text="Vui lòng nhập năm bắt đầu sản xuất" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Kết thúc SX:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtYearEnd" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="rvYearEnd" runat="server" ControlToValidate="txtYearEnd"
                                CssClass="text-danger" Text="Vui lòng nhập năm kết thúc trong khoảng từ 0 đến 9999"
                                ValidationGroup="valProduct" Type="Double" MinimumValue="0" MaximumValue="9999"
                                Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group" style="display: none;">
                        <label class="col-lg-3">
                            Sử dụng năng lượng<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlProductFuel" CssClass="form-control input-sm" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Ghi chú:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveProduct" runat="server" Visible="true" ValidationGroup="valProduct"
                    Text="Lưu lại" OnClick="btnSaveProduct_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>

<div class="modal" tabindex="-1" role="dialog" id="divProductYear" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Sản phẩm sản xuất năm báo cáo</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên sản phẩm<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" ID="ddlProduct" CssClass="form-control input-sm"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProduct"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Vui lòng nhập tên sản phẩm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Năng lực SX theo thiết kế:</label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="update_txtQtyByDesign" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlProduct" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="txtQtyByDesign" CssClass="form-control input-sm"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="txtQtyByDesign"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:Literal ID="ltMearsurement2" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mức sản xuất cao nhất<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="update_txtMaxQty" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlProduct" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="txtMaxQty" CssClass="form-control input-sm"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMaxQty"
                                ValidationGroup="valProductYear" Text="Vui lòng nhập mức sản xuất cao nhất"
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtMaxQty"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:Literal ID="ltMeasurement" runat="server"></asp:Literal>
                        </div>
                    </div>


                    <div class="form-group">
                        <label class="col-lg-3">
                            Tiêu thụ năng lượng theo sản phẩm</label>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlLoaiNangLuong" CssClass="form-control input-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLoaiNangLuong_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-lg-2">
                            <asp:UpdatePanel ID="updateDonVitinh" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlLoaiNangLuong" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlLoaiNangLuong_DVT" runat="server" CssClass="form-control input-sm" AutoPostBack="true" OnSelectedIndexChanged="ddlLoaiNangLuong_DVT_SelectedIndexChanged"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="col-lg-2">
                            <asp:UpdatePanel ID="updatetxtTieuThuTheoSP" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlLoaiNangLuong_DVT" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="txtTieuThuTheoSP" CssClass="form-control input-sm"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtTieuThuTheoSP"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div style="display: none;">
                            <asp:TextBox runat="server" ID="txtTieuThuNLTheoSP" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="txtTieuThuNLTheoSP"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-2">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-lg-3">
                            Doanh thu theo sản phẩm</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtDoanhThuTheoSP" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txtDoanhThuTheoSP"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal-footer">
                <asp:Button ID="btnSaveProductYear" runat="server" Visible="true" ValidationGroup="valProductYear"
                    Text="Lưu lại" OnClick="btnSaveProductYear_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>

<div class="modal" tabindex="-1" role="dialog" id="divProductPlan" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Kế hoạch sản xuất năm tiếp theo</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên sản phẩm<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" ID="ddlProductPlan" CssClass="form-control input-sm"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlProductPlan_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlProductPlan" CssClass="text-danger"
                                ValidationGroup="valProductYearPlan" Text="Vui lòng nhập tên sản phẩm" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Năng lực SX theo thiết kế:</label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="update_txtQtyByDesignPlan" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlProductPlan" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="txtQtyByDesignPlan" CssClass="form-control input-sm"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtQtyByDesignPlan"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Dự kiến sản xuất<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="update_txtMaxQtyPlan" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlProductPlan" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="txtMaxQtyPlan" CssClass="form-control input-sm"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMaxQtyPlan"
                                CssClass="text-danger" ValidationGroup="valProductYearPlan" Text="Vui lòng nhập dự kiến sản xuất"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtMaxQtyPlan"
                                CssClass="text-danger" ValidationGroup="valProductYearPlan" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:Literal ID="ltMeasurementPlan" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="form-group" style="display: none;">
                        <label class="col-lg-3">
                            Tỷ lệ so với CPSX(%)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtRateOfCost" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3">
                            Tỷ lệ so với Doanh thu(%)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtRateOfRevenue" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveProductPlan" runat="server" Visible="true" ValidationGroup="valProductYearPlan"
                    Text="Lưu lại" OnClick="btnSaveProductPlan_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>

<br />
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<asp:HiddenField ID="hddvalue" runat="server" Value="" />
<asp:HiddenField ID="hddkhtknl" runat="server" Value="" />
<asp:HiddenField ID="hddkhTB" runat="server" Value="1" />

<style type="text/css">
    .modal-dialog {
        z-index: 9999 !important;
    }
</style>


<script type="text/javascript">
    function ShowDialogSolutionResultOne(id) {
        if (id == "0") {
            $("#<%=hddkhtknl.ClientID%>").val('');
        }
        else {
            $("#<%=hddkhtknl.ClientID%>").val(id);
        }
        $('#dlgSolutionResultOne').modal('toggle');
    }

    function showgiaiphap() {
        $('#mygiaiphap').modal('toggle');
    }

    function ShowDialogSolutionPlanOne(id) {

        if (id == "0") {
            $("#<%=hddkhtknl.ClientID%>").val('0');
            //$("#<%=txtTKNLMucTieuDukien.ClientID%>").val('');
            //$("#<%=txtchiphidukienTKNL.ClientID%>").val('');
            //$("#<%=txtmuctieuTKNL.ClientID%>").val('');
        }
        else {

        }
        $('#dlgSolutionPlanOne').modal('toggle');
    }

    function AddProduct() {

        if ("1" == "1") {
            $("#<%=txtYearStart.ClientID%>").val('');
            $("#<%=txtYearEnd.ClientID%>").val('');
            $("#<%=txtDescription.ClientID%>").val('');
        }
        else {

        }
        $('#divProduct').modal('toggle');
    }

    function AddProductQty(id) {

        if (id == "0") {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtMaxQtyPlan.ClientID%>").val('');
            $("#<%=txtRateOfCost.ClientID%>").val('');
            $("#<%=txtRateOfRevenue.ClientID%>").val('');
            $("#<%=ltMeasurement.ClientID%>").val('');
            $("#<%=txtQtyByDesign.ClientID%>").val('');
        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }
        $('#divProductYear').modal('toggle');
    }

    function AddProductQtyPlan(id) {

        if (id == "0") {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtMaxQtyPlan.ClientID%>").val('');
            $("#<%=txtRateOfCost.ClientID%>").val('');
            $("#<%=txtRateOfRevenue.ClientID%>").val('');
            $("#<%=ltMeasurementPlan.ClientID%>").val('');

        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);

        }

        $('#divProductPlan').modal('toggle');
    }


    $('#divProductPlan').on('hidden.bs.modal', function () {
        $("#<%=ddlProductPlan.ClientID%>").prop('disabled', false);
    });

    $('#divProductPlan').on('show.bs.modal', function () {
        if ($("#<%=hdnId.ClientID%>").val() != "")
            $("#<%=ddlProductPlan.ClientID%>").prop('disabled', true);
        else
            $("#<%=ddlProductPlan.ClientID%>").prop('disabled', false);
    });

    (function ($) {
        $.fn.inputFilter = function (inputFilter) {
            return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
                if (inputFilter(this.value)) {
                    this.oldValue = this.value;
                    this.oldSelectionStart = this.selectionStart;
                    this.oldSelectionEnd = this.selectionEnd;
                } else if (this.hasOwnProperty("oldValue")) {
                    this.value = this.oldValue;
                    this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
                } else {
                    this.value = "";
                }
            });
        };
    }(jQuery));

    $(".onlyNumberCss").inputFilter(function (value) {
        return /^-?\d*[.,]?\d*$/.test(value);
    });
</script>
