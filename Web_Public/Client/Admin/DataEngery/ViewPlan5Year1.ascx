<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewPlan5Year1.ascx.cs"
    Inherits="Client_Admin_DataEngery_ViewPlan5Year" %>
<!-- Begin: Content -->
<!-- Dashboard Tiles -->
<div class=" mb10">
    <div class="">
        <div class="">
            <asp:Literal ID="clientview" runat="server"></asp:Literal>
            <%--<div class="tab-content">
                <div id="tab2" class="tab-pane active">
                    <div class="">
                        <div class="">--%>
            <label class="control-label pt5">
                <asp:Literal ID="ltPeriod" runat="server" Text="Kết quả thực hiện kế hoạch 5 năm"
                    Visible="false"></asp:Literal></label>
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-lg-12" style="display: none">
                        <asp:Literal ID="ltDataPeriod" runat="server"></asp:Literal>
                        <div class="margin-bottom-20" style="margin-top: 10px">
                            <div class="">
                                <label class="control-label pt5" for="inputSmall" style="width: 100%; text-align: left">
                                    1. Kết quả thực hiện tiết kiệm năng lượng</label>
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
                                        <%--<th style="width: 15%">
                                            Mức cam kết khả năng thực hiện
                                        </th>--%>
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
                                                <%--  <td>
                                                    Cam kết:
                                                    <%# Eval("MucCamKet")%>
                                                    <br />
                                                    Khả năng:
                                                    <%# Eval("KhaNangThucHien")%>
                                                </td>--%>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <div class="margin-bottom-10" style="margin-top: 20px">
                            <div class="">
                                <label class="control-label pt5" for="inputSmall" style="width: 100%; text-align: left">
                                    2. Thay thế nâng cấp, bổ sung thiết bị công nghệ</label></div>
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr style="vertical-align: text-top">
                                        <th style="width: 10%">
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
                                    <asp:Repeater ID="rptKetQuaTB" runat="server">
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
                    <div class="col-lg-12">
                        <label class="control-label pt5">
                            <asp:Literal ID="ltNextPeriod" runat="server" Text="Kế hoạch thực hiện"></asp:Literal>
                        </label>
                        <div class="margin-bottom-20" style="margin-top: 10px">
                            <div class="">
                                <label class="control-label pt5" for="inputSmall" style="width: 100%; text-align: left">
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
                                    <asp:Repeater ID="cpRepeater" runat="server">
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
                        <div class="margin-bottom-10">
                            <div class="">
                                <label class="control-label pt5" for="inputSmall" style="width: 100%; text-align: left">
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
                                    <asp:Repeater ID="rptKHBoSungTB" runat="server">
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
<asp:HiddenField ID="hdnFiveYear" runat="server" Value="0" />
<asp:HiddenField ID="hdnPlan" runat="server" Value="0" />
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
