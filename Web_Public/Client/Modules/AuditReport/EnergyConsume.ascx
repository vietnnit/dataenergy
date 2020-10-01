<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EnergyConsume.ascx.cs"
    Inherits="Client_Module_DataEngery_EnergyConsume" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnNextYear" Value="" runat="server" />
<asp:HiddenField ID="hdnFuelId" Value="0" runat="server" />
<asp:HiddenField ID="hdnDetailId" Value="" runat="server" />
<div class="form-horizontal">
    
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%">
                <b>Tiêu thụ điện hàng tháng và chi phí điện theo hóa đơn
                    <asp:Literal ID="ltAuditYear" runat="server"></asp:Literal></b><div style="float: right">
                        <asp:LinkButton ID="btnSearchCMIS" runat="server" Text="Điện tiêu thụ" Visible="false" ToolTip="Xem hóa đơn điện"
                            OnClientClick='javascript:ShowDialogCMIS(); return false;'><i class="fa fa-search"></i>&nbsp;Xem hóa đơn điện</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                                ID="btnAddFuel" runat="server" Text="Điện tiêu thụ" ToolTip="Thêm báo cáo" OnClientClick='javascript:ShowDialogElectrictConsume(); return false;'><i class="fa fa-edit"></i>&nbsp;Cập nhật tiêu thụ</asp:LinkButton></div>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <thead>
                    <tr>
                        <th style="width: 10%; text-align: center" rowspan="2">
                            Tháng
                        </th>
                        <th style="width: 60%; text-align: center" colspan="3">
                            Điện theo giờ
                        </th>
                        <th style="width: 15%; text-align: center" rowspan="2">
                            Tổng (KWh)
                        </th>
                        <th style="width: 15%; text-align: center" rowspan="2">
                            Tổng tiền
                            <br />
                            <i>(đồng)</i>
                        </th>
                    </tr>
                    <tr>
                        <th class='text-center'>
                            B.thường (KWh)
                        </th>
                        <th class='text-center'>
                            Cao điểm (KWh)
                        </th>
                        <th class='text-center'>
                            Thấp điểm (KWh)
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="rptElectrictConsume" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class='text-center'>
                                <%#Container.ItemIndex+1  %>
                            </td>
                            <td style="text-align: right; width: 20%" class='text-right'>                                
                                <%# Eval("NormalNo") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NormalNo"), 0) : ""%>
                            </td>
                            <td style="text-align: right; width: 20%" class='text-right'>                                
                                <%# Eval("PeakNo") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("PeakNo"), 0) : ""%>
                            </td>
                            <td style="text-align: right; width: 20%" class='text-right'>
                                <%# Eval("LowNo") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("LowNo"), 0) : ""%>
                            </td>
                            <td class='text-right'>
                                <%# Eval("ElectrictTotal") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("ElectrictTotal"), 0) : ""%>
                            </td>
                            <td class='text-right'>
                                <%# Eval("CostTotal") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("CostTotal"), 0) : ""%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div style="text-align: right">
                <b>
                    <asp:Literal ID="ltTotal_TOE" runat="server"></asp:Literal></b>
            </div>
            <%--<asp:LinkButton ID="btnAddFuel" runat="server" Text="Thêm nhiên liệu" CssClass="btn btn-sm btn-primary mr10"></asp:LinkButton>--%>
        </div>
    </div>
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%">
                <b>Tiêu thụ điện hàng tháng và chi phí điện tự sản xuất
                    <asp:Literal ID="ltAuditYear2" runat="server"></asp:Literal></b><div style="float: right">
                        <asp:LinkButton ID="lbtSelfElectrict" runat="server" Text="Điện tiêu thụ" ToolTip="Thêm báo cáo"
                            OnClientClick='javascript:ShowDialogSelfConsume(); return false;'><i class="fa fa-edit"></i>&nbsp;Cập nhật tiêu thụ</asp:LinkButton></div>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <thead>
                    <tr>
                        <th style="width: 10%; text-align: center" rowspan="2">
                            Tháng
                        </th>
                        <th style="width: 60%; text-align: center" colspan="3">
                            Điện theo giờ
                        </th>
                        <th style="width: 15%; text-align: center" rowspan="2">
                            Tổng (KWh)
                        </th>
                        <th style="width: 15%; text-align: center" rowspan="2">
                            Tổng tiền
                            <br />
                            <i>(đồng)</i>
                        </th>
                    </tr>
                    <tr>
                        <th style="text-align: center">
                            B.thường (KWh)
                        </th>
                        <th style="text-align: center">
                            Cao điểm (KWh)
                        </th>
                        <th style="text-align: center">
                            Thấp điểm (KWh)
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="rptDataSelf" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class='text-center'>
                                <%#Container.ItemIndex+1  %>
                            </td>
                            <td style="text-align: right; width: 20%" class='text-right'>                                
                                <%# Eval("NormalNo") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NormalNo"), 0) : ""%>
                            </td>
                            <td style="text-align: right; width: 20%" class='text-right'>                                
                                <%# Eval("PeakNo") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("PeakNo"), 0) : ""%>
                            </td>
                            <td style="text-align: right; width: 20%" class='text-right'>
                                <%# Eval("LowNo") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("LowNo"), 0) : ""%>
                            </td>
                            <td class='text-right'>
                                <%# Eval("ElectrictTotal") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("ElectrictTotal"), 0) : ""%>
                            </td>
                            <td class='text-right'>
                                <%# Eval("CostTotal") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("CostTotal"), 0) : ""%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div style="text-align: right">
                <b>
                    <asp:Literal ID="Literal3" runat="server"></asp:Literal></b>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%">
                <b>Tiêu thụ nhiên liệu theo từng tháng trong năm
                    <asp:Literal ID="ltDataYear" runat="server" Text=""></asp:Literal></b><div style="float: right">
                        <asp:LinkButton ID="btnAddFuelFuture" runat="server" Text="Cập nhật tiêu thụ" ToolTip="Cập nhật tiêu thụ"
                            OnClientClick='javascript:ShowDialogFuelConsume(); return false;'><i class="fa fa-edit"></i>&nbsp;Cập nhật tiêu thụ</asp:LinkButton></div>
            </div>
            <div class="table-responsive">
                <asp:Literal ID="ltOtherEneryConsume" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgFuel">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="ltTitle" runat="server" Text="Tiêu thụ nhiên liệu theo từng tháng trong năm"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="ltErrConsume" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-2 control-label">
                            Nhiên liệu<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlFuel" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valFuelConsume" AutoPostBack="true" OnSelectedIndexChanged="ddlFuel_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlFuel" CssClass="text-danger"
                                ValidationGroup="valFuelConsume" Text="Vui lòng chọn nhiên liệu" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Đơn vị tính<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlMeasure" runat="server" AppendDataBoundItems="True" ValidationGroup="valFuelConsume"
                                AutoPostBack="false" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlMeasure_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvMeasurement" runat="server" ControlToValidate="ddlMeasure" CssClass="text-danger"
                                ValidationGroup="valFuelConsume" Text="Vui lòng chọn đơn vị tính" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            Tháng
                                        </th>
                                        <th>
                                            Số lượng
                                        </th>
                                        <th>
                                            Chi phí
                                            <br />
                                            <i>(nghìn đồng)</i>
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="rptDataFuel" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <%#Container.ItemIndex+1 %>
                                            </td>
                                            <td class="text-right">
                                                <input name='txtQuantity<%#Container.ItemIndex+1 %>' id='txtQuantity' value='<%#Eval("Quantity")%>'
                                                    class="form-control input-sm" />
                                            </td>
                                            <td class="text-right">
                                                <input name='txtCost<%#Container.ItemIndex+1 %>' id="txtCost" value='<%#Eval("Cost")%>'
                                                    class="form-control input-sm" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnDeleteFuelConsume" CssClass="btn btn-sm btn-warning mr10"
                    Text="Xóa trắng" OnClick="btnDeleteFuelConsume_Click" ValidationGroup="valFuelConsume" />
                <asp:Button runat="server" ID="btnSaveFuel" CssClass="btn btn-sm btn-primary mr10"
                    Text="Lưu lại" OnClick="btnSaveFuel_Click" ValidationGroup="valFuelConsume" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgElectrict">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="Literal1" runat="server" Text="Tiêu thụ điện hàng tháng và chi phí điện theo hóa đơn"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="ltErrElectrictConsume" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr class="primary fs12">
                                        <th style="width: 10%; text-align: center" rowspan="2">
                                            Tháng
                                        </th>
                                        <th style="width: 60%; text-align: center" colspan="3">
                                            Điện theo giờ
                                        </th>
                                        <th style="width: 15%; text-align: center" rowspan="2">
                                            Tổng (KWh)
                                        </th>
                                        <th style="width: 15%; text-align: center" rowspan="2">
                                            Tổng tiền
                                            <br />
                                            <i>(đồng)</i>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center">
                                            B.thường (KWh)
                                        </th>
                                        <th style="text-align: center">
                                            Cao điểm (KWh)
                                        </th>
                                        <th style="text-align: center">
                                            Thấp điểm (KWh)
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="rptElecttrictInput" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <%#Container.ItemIndex+1 %>
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtNormalNo<%#Container.ItemIndex+1 %>'
                                                    id='txtNormalNo' value='<%#Eval("NormalNo")%>'/>
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtPeakNo<%#Container.ItemIndex+1 %>'
                                                    id='txtPeakNo' value='<%#Eval("PeakNo")%>'/>
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtLowNo<%#Container.ItemIndex+1 %>'
                                                    id='txtLowNo' value='<%#Eval("LowNo")%>'/>
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtElectrictTotal<%#Container.ItemIndex+1 %>'
                                                    id="txtElectrictTotal" value='<%#Eval("ElectrictTotal")%>'/>
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtCostTotal<%#Container.ItemIndex+1 %>'
                                                    id="txtCostTotal" value='<%#Eval("CostTotal")%>'/>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnDeleteElectrictConsume" CssClass="btn btn-sm btn-warning mr10"
                    Text="Xóa trắng" OnClick="btnDeleteElectrictConsume_Click" />
                <asp:Button runat="server" ID="btnSaveElectrictConsume" CssClass="btn btn-sm btn-primary mr10"
                    Text="Lưu lại" OnClick="btnSaveElectrictConsume_Click" ValidationGroup="valElectrictConsume" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgSelf">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="Literal2" runat="server" Text="Tiêu thụ điện hàng tháng và chi phí điện tự sản xuất"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr class="primary fs12">
                                        <th style="width: 10%; text-align: center" rowspan="2">
                                            Tháng
                                        </th>
                                        <th style="width: 60%; text-align: center" colspan="3">
                                            Điện theo giờ
                                        </th>
                                        <th style="width: 15%; text-align: center" rowspan="2">
                                            Tổng (KWh)
                                        </th>
                                        <th style="width: 15%; text-align: center" rowspan="2">
                                            Tổng tiền
                                            <br />
                                            <i>(đồng)</i>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center">
                                            B.thường (KWh)
                                        </th>
                                        <th style="text-align: center">
                                            Cao điểm (KWh)
                                        </th>
                                        <th style="text-align: center">
                                            Thấp điểm (KWh)
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="rptSelfInput" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center">
                                                <%#Container.ItemIndex+1 %>
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtNormalNoS<%#Container.ItemIndex+1 %>'
                                                    id='txtNormalNoS' value='<%#Eval("NormalNo")%>'/>
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtPeakNoS<%#Container.ItemIndex+1 %>'
                                                    id='txtPeakNoS' value='<%#Eval("PeakNo")%>' />
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtLowNoS<%#Container.ItemIndex+1 %>'
                                                    id='txtLowNoS' value='<%#Eval("LowNo")%>'/>
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtElectrictTotalS<%#Container.ItemIndex+1 %>'
                                                    id="txtElectrictTotalS" value='<%#Eval("ElectrictTotal")%>'/>
                                            </td>
                                            <td class="text-right">
                                                <input class="text-right form-control input-sm" name='txtCostTotalS<%#Container.ItemIndex+1 %>'
                                                    id="txtCostTotalS" value='<%#Eval("CostTotal")%>'/>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnDeleteSelf" CssClass="btn btn-sm btn-warning mr10"
                    Text="Xóa trắng" OnClick="btnDeleteSelf_Click" />
                <asp:Button runat="server" ID="btnSaveSelf" CssClass="btn btn-sm btn-primary mr10"
                    Text="Lưu lại" OnClick="btnSaveSelf_Click" ValidationGroup="valSelfConsume" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgCMIS">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="Literal5" runat="server" Text="Tiêu thụ điện hàng tháng theo hóa đơn"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-2 control-label">
                            Mã KHĐL<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtCustommerCode" runat="server" Enabled="false" AppendDataBoundItems="True"
                                CssClass="form-control input-sm" ValidationGroup="valCMIS"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustommerCode"
                                ValidationGroup="valCMIS" Text="Vui lòng nhập mã khách hàng" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-4">
                            <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-sm btn-primary mr10"
                                Text="Xem" OnClick="btnSearch_Click" ValidationGroup="valCMIS" />
                            <asp:Button runat="server" ID="btnImport" CssClass="btn btn-sm btn-warning mr10"
                                Text="Lấy dữ liệu" OnClick="btnImport_Click" ValidationGroup="valCMIS" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr class="primary fs12">
                                        <th style="width: 10%; text-align: center" rowspan="2">
                                            Tháng
                                        </th>
                                        <th style="width: 60%; text-align: center" colspan="3">
                                            Điện theo giờ
                                        </th>
                                        <th style="width: 15%; text-align: center" rowspan="2">
                                            Tổng (KWh)
                                        </th>
                                        <th style="width: 15%; text-align: center" rowspan="2">
                                            Tổng tiền
                                            <br />
                                            <i>(đồng)</i>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center">
                                            B.thường (KWh)
                                        </th>
                                        <th style="text-align: center">
                                            Cao điểm (KWh)
                                        </th>
                                        <th style="text-align: center">
                                            Thấp điểm (KWh)
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="rptCMIS" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class='text-center'>
                                                <%#Eval("THANG")%>
                                            </td>
                                            <td style="text-align: right; width: 20%" class='text-right'>
                                                <%#Eval("KWH_BT")%>
                                            </td>
                                            <td style="text-align: right; width: 20%" class='text-right'>
                                                <%#Eval("KWH_CD")%>
                                            </td>
                                            <td style="text-align: right; width: 20%" class='text-right'>
                                                <%#Eval("KWH_TD")%>
                                            </td>
                                            <td class='text-right'>
                                                <%#Convert.ToInt32(Eval("KWH_BT"))+Convert.ToInt32(Eval("KWH_CD"))+Convert.ToInt32(Eval("KWH_TD")) %>
                                            </td>
                                            <td class='text-right'>
                                                <%#Convert.ToInt32(Eval("TIEN_BT")) + Convert.ToInt32(Eval("TIEN_CD")) + Convert.ToInt32(Eval("TIEN_TD"))%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<script type="text/javascript" language="javascript">

    function ShowDialogFuelConsume() {
        $("#dlgFuel").modal('toggle');
    }
    function ShowDialogCMIS() {
        $("#dlgCMIS").modal('toggle');
    }
    function ShowDialogElectrictConsume() {
        $("#dlgElectrict").modal('toggle');
    }
    function ShowDialogSelfConsume() {
        $("#dlgSelf").modal('toggle');
    }
    
</script>
<script>
    function addCommas(nStr) {
        var str2 = nStr.toString().replace(".", "");
        alert(str2);
    var parts = str2.split(",");
        parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ".");
        return parts.join(",");    
    }
    function setformat(txtvalue) {
        valuetext = addCommas(txtvalue.value);
        txtvalue.value = valuetext;
       
    }
</script>



<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
    .input-sm
    {
        height: 25px;
    }
    .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td
    {
        padding: 3px;
    }
</style>
