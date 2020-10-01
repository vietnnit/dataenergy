<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ElectrictSystem.ascx.cs"
    Inherits="Client_Module_DataEngery_ElectrictSystem" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<asp:HiddenField ID="hdnIdS" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%">
                <b>1. Thông số máy biến áp
                    <asp:Literal ID="ltDataYear" runat="server" Text=""></asp:Literal></b><div style="float: right">
                        <asp:LinkButton ID="btnAddFuelFuture" runat="server" Text="Cập nhật thông số MBA"
                            ToolTip="Cập nhật thông số MBA" OnClientClick='javascript:ShowDialogElectrictMBA(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <thead>
                    <tr class="primary fs12">
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
                        <th style="width: 10%" class="text-center">
                            Thao tác
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptMBA" runat="server" OnItemDataBound="rptMBA_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("DeviceName")%>
                                </td>
                                <td class="text-right">
                                    <%# Tool.ConvertDecimalToString(Eval("PlacingCapacity"),0)%>
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
                                    <%# Eval("Performance") != DBNull.Value && Convert.ToDecimal(Eval("Performance")) > 0 ? Tool.ConvertDecimalToString(Eval("Performance"), 2) + "%" : ""%>
                                </td>
                                <td class="text-center">
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>'
                                        OnClick="btnDeleteMBA_Click" CommandName="delete" CssClass="" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa không???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                    <asp:LinkButton ID="btnEdit" OnClick="btnEditMBA_Click" runat="server" CssClass=""
                                        ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>' CommandName="edit"><i class="fa fa-edit"></i></asp:LinkButton>
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
            <div class="control-label pt5" style="width: 100%">
                <b>2. Thông số máy phát
                    <asp:Literal ID="Literal1" runat="server" Text=""></asp:Literal></b><div style="float: right">
                        <asp:LinkButton ID="btnAddSelf" runat="server" Text="Cập nhật máy phát" ToolTip="Cập nhật thông số"
                            OnClientClick='javascript:ShowDialogElectrictSupply(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <thead>
                    <tr class="text-center">
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
                        <th style="width: 10%" class="text-center">
                            Thao tác
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptSelf" runat="server" OnItemDataBound="rptSelf_ItemDataBound">
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
                                <td class="text-center">
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>'
                                        CommandName="delete" CssClass="" OnClick="btnDeleteSupply_Click" ToolTip="Xóa"
                                        OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa không???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                    <asp:LinkButton ID="btnEdit" OnClick="btnEditSupply_Click" runat="server" CssClass=""
                                        ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>' CommandName="edit"><i class="fa fa-edit"></i></asp:LinkButton>
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
<div class="modal fade" tabindex="-1" role="dialog" id="dlgMBA">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="ltTitle" runat="server" Text="Thông số máy biến áp"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="ltErrConsume" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Tên MBA<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtMBAName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMBAName"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Vui lòng nhập máy biến áp"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3 control-label">
                            Công suất đặt(kVA)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtPlacingCapacity" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPlacingCapacity"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Vui lòng nhập công suất đặt"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtPlacingCapacity"
                                ValidationGroup="valMBA" CssClass="text-danger" Text="Công suất đặt chỉ nhập số"
                                Type="Integer" MinimumValue="0" MaximumValue="2147483647 " Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Cấp điện áp(kV)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtVoltageLevel" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVoltageLevel"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Vui lòng nhập cấp điện áp"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%-- </div>
                    <div class="form-group">--%>
                        <label class="col-lg-3 control-label">
                            Cos φ<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtCos" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCos"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Vui lòng nhập Cos phi"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCos"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Cos φ chỉ nhập số" ValidationExpression="^[0-9]{1,3}(\,[0-9]{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Tải trung bình(MV)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtCoefficient" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCoefficient"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Vui lòng nhập hệ số mang tải"
                                Display="Dynamic"></asp:RequiredFieldValidator>                             
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCoefficient"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Tải trung bình chỉ nhập số" ValidationExpression="^[0-9]{1,3}(\,[0-9]{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <%-- </div>
                    <div class="form-group">--%>
                        <label class="col-lg-3 control-label">
                            Điện năng từ lưới(kWh)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtCapacity" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCapacity"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Vui lòng nhập điện năng từ lưới"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtCapacity"
                                ValidationGroup="valMBA" CssClass="text-danger" Text="Điện năng từ lưới chỉ nhập số"
                                Type="Integer" MinimumValue="0" MaximumValue="2147483647 " Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Hiệu suất(%)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtPerformance" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPerformance"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Vui lòng nhập hiệu suất"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPerformance"
                                CssClass="text-danger" ValidationGroup="valMBA" Text="Hiệu suất chỉ nhập số"
                                ValidationExpression="^[0-9]{1,3}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Visible="true" ValidationGroup="valMBA" Text="Lưu lại"
                    OnClick="btnSave_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false"
                    UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgSupply">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="Literal2" runat="server" Text="Cập nhật thông số máy phát"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Tên máy phát<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtMBANameS" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMBANameS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Vui lòng nhập máy phát"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3 control-label">
                            Công suất đặt(kVA)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtPlacingCapacityS" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPlacingCapacityS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Vui lòng nhập công suất đặt"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvDonGia" runat="server" ControlToValidate="txtPlacingCapacityS"
                                ValidationGroup="valSupply" CssClass="text-danger" Text="Công suất đặt chỉ nhập số"
                                Type="Integer" MinimumValue="0" MaximumValue="2147483647 " Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Cấp điện áp(kV)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtVoltageLevelS" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtVoltageLevelS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Vui lòng nhập cấp điện áp"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%-- </div>
                    <div class="form-group">--%>
                        <label class="col-lg-3 control-label">
                            Cos φ<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtCosS" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCosS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Vui lòng nhập Cos phi"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCosS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Cos φ chỉ nhập số" ValidationExpression="^[0-9]{1,3}(\,[0-9]{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Hệ số mang tải(A)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtCoefficientS" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCoefficientS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Vui lòng nhập hệ số mang tải"
                                Display="Dynamic"></asp:RequiredFieldValidator>                         
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCoefficientS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Hệ số mang tải chỉ nhập số" ValidationExpression="^[0-9]{1,3}(\,[0-9]{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <%-- </div>
                    <div class="form-group">--%>
                        <label class="col-lg-3 control-label">
                            Điện năng tự SX(kWh)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtCapacityS" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCapacityS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Vui lòng nhập điện năng tự sản xuất"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtPlacingCapacityS"
                                ValidationGroup="valSupply" CssClass="text-danger" Text="Điện năng tự SX chỉ nhập số"
                                Type="Integer" MinimumValue="0" MaximumValue="2147483647 " Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Hiệu suất(%)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox ID="txtPerformanceS" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPerformanceS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Vui lòng nhập hiệu suất"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPerformanceS"
                                CssClass="text-danger" ValidationGroup="valSupply" Text="Hiệu suất chỉ nhập số"
                                ValidationExpression="^[0-9]{1,3}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveSupply" runat="server" Visible="true" ValidationGroup="valSupply"
                    Text="Lưu lại" OnClick="btnSaveSupply_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<script type="text/javascript" language="javascript">

    function ShowDialogElectrictMBA() {
        $("#dlgMBA").modal('toggle');
    }
    function ShowDialogElectrictSupply() {
        $("#dlgSupply").modal('toggle');
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
