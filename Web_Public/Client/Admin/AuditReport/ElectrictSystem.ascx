<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ElectrictSystem.ascx.cs"
    Inherits="Client_Admin_DataEngery_ElectrictSystem" %>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<asp:HiddenField ID="hdnIdS" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%; text-align: left">
                <b>1. Thông số máy biến áp </b>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <thead>
                    <tr>
                        <tr class="text-center">
                            <th style="width: 30%" class="text-center">
                                Tên máy phát
                            </th>
                            <th style="width: 12%" class="text-center">
                                Công suất đặt(KVA)
                            </th>
                            <th style="width: 12%" class="text-center">
                                Cấp điện áp(V)
                            </th>
                            <th style="width: 12%" class="text-center">
                                Cos φ
                            </th>
                            <th style="width: 12%" class="text-center">
                                Tải trung bình(MV)
                            </th>
                            <th style="width: 12%" class="text-center">
                                Điện năng mua (KWh)
                            </th>
                            <th style="width: 12%" class="text-center">
                                Hiệu suất
                            </th>
                        </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptMBA" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("DeviceName")%>
                                </td>
                                <td class="text-right">
                                    <%# Tool.ConvertDecimalToString(Eval("PlacingCapacity"), 0)%>
                                </td>
                                <td>
                                    <%# Eval("VoltageLevel")%>
                                </td>
                                <td class="text-right">
                                    <%# Tool.ConvertDecimalToString(Eval("Cos"), 2)%>
                                </td>
                                <td class="text-right">
                                    <%# Tool.ConvertDecimalToString(Eval("Coefficient"), 0)%>
                                </td>
                                <td class="text-right">
                                    <%# Tool.ConvertDecimalToString(Eval("Capacity"), 0)%>
                                </td>
                                <td class="text-right">
                                    <%# Eval("Performance") != DBNull.Value && Convert.ToDecimal(Eval("Performance")) > 0 ? Tool.ConvertDecimalToString(Eval("Performance"), 0) + "%" : ""%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%; text-align: left">
                <b>2. Thông số máy phát</b>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <thead>
                    <tr>
                        <th style="width: 30%">
                            Tên máy phát
                        </th>
                        <th style="width: 12%" class="text-center">
                            Công suất đặt(KWh)
                        </th>
                        <th style="width: 12%" class="text-center">
                            Cấp điện áp(V)
                        </th>
                        <th style="width: 12%" class="text-center">
                            Cos φ
                        </th>
                        <th style="width: 12%" class="text-center">
                            Hệ số mang tải(A)
                        </th>
                        <th style="width: 12%" class="text-center">
                            Điện năng tự SX (KWh)
                        </th>
                        <th style="width: 12%" class="text-center">
                            Hiệu suất
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptSelf" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("DeviceName")%>
                                </td>
                                <td class="text-right">
                                    <%# Tool.ConvertDecimalToString(Eval("PlacingCapacity"), 0)%>
                                </td>
                                <td>
                                    <%# Eval("VoltageLevel")%>
                                </td>
                                <td class="text-right">
                                    <%# Tool.ConvertDecimalToString(Eval("Cos"), 2)%>
                                </td>
                                <td class="text-right">
                                    <%# Tool.ConvertDecimalToString(Eval("Coefficient"), 0)%>
                                </td>
                                <td class="text-right">
                                    <%# Tool.ConvertDecimalToString(Eval("Capacity"), 0)%>
                                </td>
                                <td class="text-right">
                                    <%# Eval("Performance") != DBNull.Value && Convert.ToDecimal(Eval("Performance")) > 0 ? Tool.ConvertDecimalToString(Eval("Performance"), 0) + "%" : ""%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>
