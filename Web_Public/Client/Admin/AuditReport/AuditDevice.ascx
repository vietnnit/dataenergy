<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditDevice.ascx.cs" Inherits="Client_Admin_AuditReport_AuditDevice" %>

<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <div class="margin-bottom-10">
                <div class="text-left pt5" style="width: 100%">
                    <b>1. Máy nén khí</b>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr>
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 20%">
                                Tên thiết bị
                            </th>
                            <th style="width: 15%" class="text-center">
                                Số lượng
                            </th>
                            <th style="width: 10%" class="text-center">
                                Công suất định mức
                            </th>
                            <th style="width: 10%" class="text-center">
                                Áp suất đm (Bar)
                            </th>
                            <th style="width: 10%" class="text-center">
                                Áp suất LV (Bar)
                            </th>
                            <th style="width: 10%" class="text-center">
                                Số giờ vận hành/ngày
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptCompressor" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("CompressorName")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Capacity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Pressure")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("PressureLV")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("OperationHours")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="text-left pt5" style="width: 100%">
                    <b>2. Lò hơi</b>                    
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr>
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 20%">
                                Tên thiết bị
                            </th>
                            <th style="width: 15%" class="text-center">
                                Nhiên liệu sử dụng
                            </th>
                            <th style="width: 20%" class="text-center">
                                S/lg
                            </th>
                            <th style="width: 20%" class="text-center">
                                C/suất đặt (tấn/h)
                            </th>
                            <th style="width: 20%" class="text-center">
                                Số giờ vận hành/ngày
                            </th>                           
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptBoiler" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("BoilerName")%>
                                    </td>
                                    <td class="text-center">
                                     <%# Eval("FuelName")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("CapacityInstalled")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("OperationHours")%>
                                    </td>                                    
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="text-left pt5" style="width: 100%">
                    <b>3. Lò nung và thiết bị gia nhiệt</b>                    
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr>
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 20%">
                                Tên thiết bị
                            </th>
                            <th style="width: 15%" class="text-center">
                                Nhiên liệu sử dụng
                            </th>
                            <th style="width: 20%" class="text-center">
                                S/lg
                            </th>
                            <th style="width: 20%" class="text-center">
                                C/suất đặt (tấn/h)
                            </th>
                            <th style="width: 20%" class="text-center">
                                Số giờ vận hành/ngày
                            </th>
                          
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptFurnaces" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("DeviceName")%>
                                    </td>
                                    <td class="text-center">
                                     <%# Eval("FuelName")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("CapacityInstalled")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("OperationHours")%>
                                    </td>
                                  
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="text-left pt5" style="width: 100%">
                    <b>4. Động cơ điện có công suất lớn nhất (5 động cơ)</b>                   
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr>
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 20%">
                                Tên thiết bị
                            </th>
                            <th style="width: 10%" class="text-center">
                                S/lg
                            </th>
                            <th style="width: 15%" class="text-center">
                                C/suất đm(kW)
                            </th>
                            <th style="width: 20%" class="text-center">
                                C/suất SD (kW)
                            </th>
                            <th style="width: 20%" class="text-center">
                                Số giờ vận hành/ngày
                            </th>
                           
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptElectricMotors" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("ElectricMotorsName")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Quantity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Capacity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("CapacityUsed")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("OperationHours")%>
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
