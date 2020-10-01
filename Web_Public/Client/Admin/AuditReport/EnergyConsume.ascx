<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EnergyConsume.ascx.cs"
    Inherits="Client_Admin_DataEngery_EnergyConsume" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnNextYear" Value="" runat="server" />
<asp:HiddenField ID="hdnFuelId" Value="0" runat="server" />
<asp:HiddenField ID="hdnDetailId" Value="" runat="server" />
<div class="form-horizontal">
    
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%; text-align: left">
                <b>Tiêu thụ điện hàng tháng và chi phí điện theo hóa đơn</b>
                <div style="float: right">
                    <a href="javascript:ShowDialogCMIS();">Tra cứu hóa đơn</a></div>
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
                <asp:Repeater ID="rptElectrictConsume" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="text-center">
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
        </div>
    </div>
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%; text-align: left">
                <b>Tiêu thụ điện hàng tháng và chi phí điện tự sản xuất</b>
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
                            <td class="text-center">
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
            <div class="control-label pt5" style="width: 100%; text-align: left">
                <b>Tiêu thụ nhiên liệu theo từng tháng trong năm
                    <asp:Literal ID="ltDataYear" runat="server" Text=""></asp:Literal></b>
            </div>
            <asp:Literal ID="ltOtherEneryConsume" runat="server"></asp:Literal>
        </div>
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgCMIS">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="Literal5" runat="server" Text="Tiêu thụ điện hàng tháng và chi phí theo hóa đơn điện"></asp:Literal>
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
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
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
    function ShowDialogCMIS() {
        $(document).ready(function () {
            $('#dlgCMIS').modal('toggle');
        });
    }
    
    
</script>
