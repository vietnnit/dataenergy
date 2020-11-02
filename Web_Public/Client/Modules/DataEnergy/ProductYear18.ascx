<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductYear18.ascx.cs" Inherits="Client_Modules_DataEnergy_ProductYear18" %>
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <%--I. Năng lực sản xuất--%>
        <div class="col-lg-12">
            <label class="control-label">
                <asp:Literal ID="ltNangLucSX" runat="server" Text="I. Thông tin về cơ sở hạ tầng và hoạt động"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>1. Năng lực sản xuất năm 
                            <asp:Literal ID="ltNangLucSXNamN_1" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btNangLucSXNamN_1" runat="server" Text="Hiệu chỉnh" ToolTip="Hiệu chỉnh"
                                OnClientClick='javascript:AddProductQty(); return false;'><i class="fa fa-plus"></i>&nbsp;Hiệu chỉnh</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 65%">Hạng mục
                            </th>
                            <th style="width: 20%">Đơn vị đo
                            </th>
                            <th>Số lượng
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptNangLucSXNamN_1" runat="server">
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
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>2. Kế hoạch sản xuất năm
                            <asp:Literal ID="ltKHSXNamN" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btKeHoachSXNamN" runat="server" Text="Hiệu chỉnh" ToolTip="Hiệu chỉnh"
                                OnClientClick='javascript:AddProductQty(); return false;'><i class="fa fa-plus"></i>&nbsp;Hiệu chỉnh</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 65%">Hạng mục
                            </th>
                            <th style="width: 20%">Đơn vị đo
                            </th>
                            <th>Số lượng
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptNangLucSXNamN" runat="server">
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
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>3. Dự kiến mức tiêu thụ nhiên liệu
                            <asp:Literal ID="ltKHSXNamN_DuKienTTNL" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btKHSXNamN_DuKienTTNL" runat="server" Text="Hiệu chỉnh" ToolTip="Hiệu chỉnh"
                                OnClientClick='javascript:AddProductQty(); return false;'><i class="fa fa-plus"></i>&nbsp;Hiệu chỉnh</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 65%">Hạng mục
                            </th>
                            <th style="width: 20%">Đơn vị đo
                            </th>
                            <th>Số lượng
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater3" runat="server">
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
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>4. Dự kiến mức tiêu thụ điện
                            <asp:Literal ID="ltKHSXNamN_DuKienTTD" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btKHSXNamN_DuKienTTD" runat="server" Text="Hiệu chỉnh" ToolTip="Hiệu chỉnh"
                                OnClientClick='javascript:AddProductQty(); return false;'><i class="fa fa-plus"></i>&nbsp;Hiệu chỉnh</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 65%">Hạng mục
                            </th>
                            <th style="width: 20%">Đơn vị đo
                            </th>
                            <th>Số lượng
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater4" runat="server">
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
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

        <%--II. Giải pháp tiết kiệm năng lượng--%>
        <div class="col-lg-12">
            <label class="control-label">
                <asp:Literal ID="ltGiaiPhapTKNL" runat="server" Text="II. Giải pháp tiết kiệm năng lượng"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>1. Kết quả đạt được năm 
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Hiệu chỉnh" ToolTip="Hiệu chỉnh"
                                OnClientClick='javascript:AddProductQty(); return false;'><i class="fa fa-plus"></i>&nbsp;Hiệu chỉnh</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 65%">Hạng mục
                            </th>
                            <th style="width: 20%">Đơn vị đo
                            </th>
                            <th>Số lượng
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
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
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>2. Kế hoặch và mục tiêu năm
                            <asp:Literal ID="Literal3" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="LinkButton2" runat="server" Text="Hiệu chỉnh" ToolTip="Hiệu chỉnh"
                                OnClientClick='javascript:AddProductQty(); return false;'><i class="fa fa-plus"></i>&nbsp;Hiệu chỉnh</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 65%">Hạng mục
                            </th>
                            <th style="width: 20%">Đơn vị đo
                            </th>
                            <th>Số lượng
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater2" runat="server">
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
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
