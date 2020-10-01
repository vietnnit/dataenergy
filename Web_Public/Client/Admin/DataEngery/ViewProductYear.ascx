<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewProductYear.ascx.cs" Inherits="Client_Admin_DataEngery_ViewProductYear" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <div class="">
                <div class="control-label pt5" style="width: 100%; text-align:left" for="inputSmall">
                    <b>2.1. Thông tin cơ sở hạ tầng</b>                    
                </div>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <thead>
                    <tr>
                        <td style="width: 10%">
                            Năm đưa cơ sở vào hoạt động:
                        </td>
                        <td style="width: 10%;" colspan="2">
                            <asp:Literal ID="ltActiveYear" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 10%">
                            Số lao động/diện tích mặt bằng
                        </th>
                        <th style="width: 10%">
                            Khu vực sản xuất
                        </th>
                        <th style="width: 15%">
                            Khu vực văn phòng
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            Tổng số lao động hiện tại
                        </td>
                        <td>
                            <asp:Literal ID="ltProduceEmployeeNo" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="ltOfficeEmployeeNo" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Diện tích mặt bằng(m<sup>2</sup>)
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
        <div class="col-lg-12">
            <label class="control-label">
                <asp:Literal ID="ltOldYear" runat="server" Text="2.2. Năng lực sản xuất"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%; text-align:left" for="inputSmall">
                        <i>a. Năng lực sản xuất năm hiện tại</i>                        
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="">
                            <th style="width: 15%">
                                Sản phẩm                                
                            </th>
                            <th style="width: 10%">
                                Đơn vị đo
                            </th>
                            <th style="width: 15%">
                                Theo thiết kế
                            </th>
                            <th style="width: 20%">
                                Mức sản xuất cao nhất hiện tại
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
                                    <td>
                                        <%# Eval("DesignQuantity")%>
                                    </td>
                                    <td>
                                        <%# Eval("MaxQuantity")%>
                                    </td>                                    
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%; text-align:left" for="inputSmall">
                        <i>b. Kế hoạch sản xuất năm tiếp theo</i>                        
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="">                            
                            <th style="width: 15%">
                                Sản phẩm                                
                            </th>                            
                            <th style="width: 15%">
                                Dự kiến sản xuất
                            </th>
                            <th style="width: 10%">
                                Tỷ lệ so với chi phí sản xuất
                            </th>
                            <th style="width: 15%">
                                Tỷ lệ doanh thu
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
                                    <td>
                                        <%# Eval("MaxQuantity")%>(<%# Eval("Measurement")%>)
                                    </td>
                                    <td>
                                        <%# Eval("RateOfCost")%>
                                    </td>
                                    <td>
                                        <%# Eval("RateOfRevenue")%>
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
                <asp:Literal ID="ltNextYear" runat="server" Text="2.3. Điện năng mua ngoài và tự sản xuất"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%; text-align:left" for="inputSmall">
                        <i>a. Điện mua ngoài và tự sản xuất năm hiện tại</i>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <tbody>
                        <tr class="">
                            <td style="width: 10%">
                                Điện năng mua ngoài
                            </td>
                            <td style="width: 10%">
                                Công suất:
                                <asp:Literal ID="ltCapacityResult" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 10%;" colspan="2">
                                Điện năng:
                                <asp:Literal ID="ltQuantityResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr class="">
                            <td style="width: 10%">
                                Giá mua điện ngoài
                            </td>
                            <td style="width: 10%">
                                Giá TB:
                                <asp:Literal ID="ltPriceAvgResult" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 10%;" colspan="2">
                                Tổng chi phí:
                                <asp:Literal ID="ltCostTotalResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="4">
                                Điện tự sản xuất
                            </td>
                            <td>
                                Công suất lắp đặt
                            </td>
                            <td>
                                <asp:Literal ID="ltInstalledResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Điện năng sản xuất
                            </td>
                            <td>
                                <asp:Literal ID="ltQuantityProduceResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Công nghệ
                            </td>
                            <td>
                                <asp:Literal ID="ltTechnologyResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nhiên liệu sử dụng
                            </td>
                            <td>
                                <asp:Literal ID="ltFuelResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="control-label pt5" style="width: 100%; text-align:left" for="inputSmall">
                <i>b. Kế hoạch mua điện và tự sản xuất năm sau</i>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <tbody>
                    <tr class="">
                        <td style="width: 10%">
                            Điện năng mua ngoài
                        </td>
                        <td style="width: 10%">
                            Công suất:
                            <asp:Literal ID="ltCapacityPlan" runat="server"></asp:Literal>
                        </td>
                        <td style="width: 10%;" colspan="2">
                            Điện năng:
                            <asp:Literal ID="ltQuantityElectrictPlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Giá mua điện
                        </td>
                        <td>
                            Giá điện dự kiến
                        </td>
                        <td>
                            <asp:Literal ID="ltPriceBuyPlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="5">
                            Điện tự sản xuất(Nếu có)
                        </td>
                        <td>
                            Công suất lắp đặt
                        </td>
                        <td>
                            <asp:Literal ID="ltInstalledCapacityPlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Điện năng sản xuất
                        </td>
                        <td>
                            <asp:Literal ID="ltQuantityProducePlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Giá điện sản xuất
                        </td>
                        <td>
                            <asp:Literal ID="ltPriceProducePlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Công nghệ
                        </td>
                        <td>
                            <asp:Literal ID="ltTecnologyPlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nhiên liệu sử dụng
                        </td>
                        <td>
                            <asp:Literal ID="ltFuelPlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>
