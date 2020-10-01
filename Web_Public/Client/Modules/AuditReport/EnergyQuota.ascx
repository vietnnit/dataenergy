<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EnergyQuota.ascx.cs" Inherits="Client_Module_DataEngery_EnergyQuota" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnNextYear" Value="" runat="server" />
<asp:HiddenField ID="hdnFuelId" Value="0" runat="server" />
<asp:HiddenField ID="hdnDetailId" Value="" runat="server" />
<div class="form-horizontal">
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%">
                <b>Tiêu hao năng lượng theo sản phẩm theo kế hoạch
                    <asp:Literal ID="ltDataYear" runat="server" Text=""></asp:Literal></b><div style="float: right">
                        <asp:LinkButton ID="btnAddFuelFuture" runat="server" Text="Cập nhật tiêu thụ" ToolTip="Cập nhật tiêu thụ"
                            OnClientClick='javascript:ShowDialogQuota(); return false;'><i class="fa fa-edit"></i>&nbsp;Cập nhật tiêu hao</asp:LinkButton></div>
            </div>
            <div class="table-responsive">
                <asp:Literal ID="ltQuota" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgQuota">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="ltTitle" runat="server" Text="Tiêu hao năng lượng theo sản phẩm theo kế hoạch"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="ltErrConsume" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-2 control-label">
                            Sản phẩm<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlProduct" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valQuota" AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="ddlProduct"
                                ValidationGroup="valQuota" Text="Vui lòng chọn sản phẩm" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label">
                            Nhiên liệu<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlFuel" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valQuota" AutoPostBack="true" OnSelectedIndexChanged="ddlFuel_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlFuel"
                                CssClass="text-danger" ValidationGroup="valQuota" Text="Vui lòng chọn nhiên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Đơn vị tính<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlMeasure" runat="server" AppendDataBoundItems="True" ValidationGroup="valFuel"
                                AutoPostBack="false" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlMeasure_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvMeasurement" runat="server" ControlToValidate="ddlMeasure"
                                CssClass="text-danger" ValidationGroup="valQuota" Text="Vui lòng chọn đơn vị tính"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label">
                            Số lượng<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuantity"
                                CssClass="text-danger" ValidationGroup="valQuota" Text="Vui lòng nhập số lượng"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtQuantity"
                                CssClass="text-danger" ValidationGroup="valQuota" Text="Số lượng chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật"
                                OnClick="btnSave_Click" ValidationGroup="valQuota" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <table class="table table-bordered table-hover mbn" width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            Nhiên liệu
                                        </th>
                                        <th>
                                            Đơn vị
                                        </th>
                                        <th>
                                            Số lượng
                                        </th>
                                        <th>
                                            Xóa
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="rptDataQuota" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("FuelName")%>
                                            </td>
                                            <td>
                                                <%#Eval("MeasurementName")%>
                                            </td>
                                            <td>
                                                <%#Eval("Quantity")%>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="btnDelete" OnClick="btnDeleteFuel_Click" runat="server" CommandArgument='<%#Eval("FuelId") %>'
                                                    CommandName="delete" CssClass="" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa không???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
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
                <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-sm btn-warning mr10"
                    Text="Xóa tất cả" OnClick="btnDelete_Click" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<script type="text/javascript" language="javascript">

    function ShowDialogQuota() {
        $("#dlgQuota").modal('toggle');
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
