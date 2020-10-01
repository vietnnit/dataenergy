<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditDevice.ascx.cs" Inherits="Client_Module_Audit_AuditDevice" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <div class="margin-bottom-10">
                <div class="control-label pt5" style="width: 100%">
                    <b>1. Máy nén khí</b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnAddCompressor" runat="server" Text="Thêm mới" ToolTip="Thêm mới"
                            OnClientClick="javascript:ShowDialogCompressor(0); return false;"><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 50%">
                                Tên thiết bị
                            </th>
                            <th style="width: 15%" class="text-center">
                                Số lượng
                            </th>
                            <th style="width: 20%" class="text-center">
                                Công suất định mức
                            </th>
                            <th style="width: 20%" class="text-center">
                                Áp suất đm (Bar)
                            </th>
                            <th style="width: 20%" class="text-center">
                                Áp suất LV (Bar)
                            </th>
                            <th style="width: 20%" class="text-center">
                                Số giờ vận hành/ngày
                            </th>
                            <th style="width: 10%" class="text-center">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptCompressor" runat="server" OnItemCommand="rptCompressor_ItemCommand"
                            OnItemDataBound="rptCompressor_ItemDataBound">
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
                                    <td class="text-center">
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
                <div class="control-label pt5" style="width: 100%">
                    <b>2. Lò hơi</b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnAddBoiler" runat="server" Text="Thêm mới" ToolTip="Thêm mới"
                            OnClientClick='javascript:ShowDialogBoiler(0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 50%">
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
                            <th style="width: 10%" class="text-center">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptBoiler" runat="server" OnItemCommand="rptBoiler_ItemCommand"
                            OnItemDataBound="rptBoiler_ItemDataBound">
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
                                    <td class="text-center">
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
                <div class="control-label pt5" style="width: 100%">
                    <b>3. Lò nung và thiết bị gia nhiệt</b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnAddFurnaces" runat="server" Text="Thêm mới" ToolTip="Thêm sản phẩm"
                            OnClientClick='javascript:ShowDialogFurnaces(0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 50%">
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
                            <th style="width: 10%" class="text-center">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptFurnaces" runat="server" OnItemCommand="rptFurnaces_ItemCommand"
                            OnItemDataBound="rptFurnaces_ItemDataBound">
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
                                    <td class="text-center">
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
                <div class="control-label pt5" style="width: 100%">
                    <b>4. Động cơ điện có công suất lớn nhất (5 động cơ)</b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnAddElectrict" runat="server" Text="Thêm mới" ToolTip="Thêm mới"
                            OnClientClick='javascript:ShowDialogElectricMotor(0); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 50%">
                                Tên thiết bị
                            </th>
                            <th style="width: 20%" class="text-center">
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
                            <th style="width: 10%" class="text-center">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptElectricMotors" runat="server" OnItemCommand="rptElectricMotors_ItemCommand"
                            OnItemDataBound="rptElectricMotors_ItemDataBound">
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
                                    <td class="text-center">
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
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>
<br />
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<asp:HiddenField ID="hddvalue" runat="server" Value="" />
<!-- / modal dialog giaiphap -->
<div class="modal" tabindex="-1" role="dialog" id="dlgCompressor" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Cập nhật máy nén khí</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên thiết bị<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtDeviceNameC" CssClass="form-control input-sm"
                                MaxLength="50" placeholder="Tên thiết bị tối đa 50 ký tự"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDeviceNameC"
                                CssClass="text-danger" ValidationGroup="valDeviceC" Text="Vui lòng nhập tên thiết bị"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Số lượng<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtQuantityC" CssClass="form-control input-sm"></asp:TextBox>
                            <%--
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesignQty"
                                CssClass="text-danger" ValidationGroup="valProduct1" Text="Vui lòng nhập năng lực sản xuất"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            C/suất định mức(kW)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtCapacityC" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCapacityC"
                                CssClass="text-danger" ValidationGroup="valDeviceC" Text="Số lượng chỉ nhập số"
                                ValidationExpression="^[0-9]{1,15}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                      <label class="col-lg-3">
                            Áp suất định mức (Bar)</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtPressureC" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPressureC"
                                CssClass="text-danger" ValidationGroup="valDeviceC" Text="Áp suất định mức chỉ nhập số"
                                ValidationExpression="^[0-9]{1,15}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-3">
                            Áp suất LV (Bar)</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtPressureLVC" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPressureLVC"
                                CssClass="text-danger" ValidationGroup="valDeviceC" Text="Áp suất LV mức chỉ nhập số"
                                ValidationExpression="^[0-9]{1,15}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Số giờ vận hành/ngày</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtHoursC" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtHoursC"
                                CssClass="text-danger" ValidationGroup="valDeviceC" Type="Integer" Text="Số giờ vận hành chỉ nhập từ 0 đến 24"
                                MinimumValue="0" MaximumValue="24" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveC" runat="server" Visible="true" ValidationGroup="valDeviceC"
                    Text="Lưu lại" OnClick="btnSaveC_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgBoiler" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Cập nhật Lò hơi</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên thiết bị<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtDeviceNameB" CssClass="form-control input-sm"
                                MaxLength="50" placeholder="Tên thiết bị tối đa 50 ký tự"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDeviceNameB"
                                CssClass="text-danger" ValidationGroup="valDeviceB" Text="Vui lòng nhập tên thiết bị"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Số lượng<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtQuantityB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtQuantityB"
                                CssClass="text-danger" ValidationGroup="valDeviceB" Type="Integer" Text="Số lượng chỉ nhập từ 0 đến 2147483647"
                                MinimumValue="0" MaximumValue="2147483647" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3">
                            C/suất đặt (tấn/h)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtCapacityB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCapacityB"
                                CssClass="text-danger" ValidationGroup="valDeviceB" Text="Số lượng chỉ nhập số"
                                ValidationExpression="^[0-9]{1,15}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Nhiên liệu</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlFuelB" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlFuelB"
                                CssClass="text-danger" ValidationGroup="valDeviceB" Text="Vui lòng chọn nhiên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3">
                            Số giờ vận hành/ngày</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtHoursB" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtHoursB"
                                CssClass="text-danger" ValidationGroup="valDeviceB" Text="Số giờ vận hành chỉ nhập từ 0 đến 24"
                                MinimumValue="0" MaximumValue="24" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveB" runat="server" Visible="true" ValidationGroup="valDeviceB"
                    Text="Lưu lại" OnClick="btnSaveB_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgFurnaces" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Cập nhật Lò nung và thiết bị gia nhiệt</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên thiết bị<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtDeviceNameF" CssClass="form-control input-sm"
                                MaxLength="50" placeholder="Tên thiết bị tối đa 50 ký tự"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDeviceNameF"
                                CssClass="text-danger" ValidationGroup="valDeviceF" Text="Vui lòng nhập tên thiết bị"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Số lượng<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtQuantityF" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator132" runat="server" ControlToValidate="txtQuantityE"
                                CssClass="text-danger" ValidationGroup="valDeviceF" Type="Integer" Text="Số lượng chỉ nhập từ 0 đến 2147483647"
                                MinimumValue="0" MaximumValue="2147483647" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3">
                            C/suất đặt (tấn/h)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtCapacityF" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCapacityF"
                                CssClass="text-danger" ValidationGroup="valDeviceF" Text="Số lượng chỉ nhập số"
                                ValidationExpression="^[0-9]{1,15}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Nhiên liệu</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlFuelF" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlFuelF"
                                CssClass="text-danger" ValidationGroup="valDeviceF" Text="Vui lòng chọn nhiên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3">
                            Số giờ vận hành/ngày</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtHoursF" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtHoursF"
                                CssClass="text-danger" ValidationGroup="valDeviceF" Text="Số giờ vận hành chỉ nhập từ 0 đến 24"
                                MinimumValue="0" MaximumValue="24" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveF" runat="server" Visible="true" ValidationGroup="valDeviceF"
                    Text="Lưu lại" OnClick="btnSaveF_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>


<div class="modal" tabindex="-1" role="dialog" id="dlgElectricMotor" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Cập nhật Động cơ điện có công suất lớn</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên thiết bị<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtDeviceNameE" CssClass="form-control input-sm"
                                MaxLength="50" placeholder="Tên thiết bị tối đa 50 ký tự"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDeviceNameE"
                                CssClass="text-danger" ValidationGroup="valDeviceE" Text="Vui lòng nhập tên thiết bị"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Số lượng<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtQuantityE" CssClass="form-control input-sm"></asp:TextBox>
                            <%--
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesignQty"
                                CssClass="text-danger" ValidationGroup="valProduct1" Text="Vui lòng nhập năng lực sản xuất"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <asp:RangeValidator ID="RangeValidator42432" runat="server" ControlToValidate="txtQuantityE"
                                CssClass="text-danger" ValidationGroup="valDeviceE" Type="Integer" Text="Số lượng chỉ nhập từ 0 đến 2147483647"
                                MinimumValue="0" MaximumValue="2147483647" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                       
                    </div>
                    <div class="form-group">
                       <label class="col-lg-3">
                            C/suất định mức(kW)<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtCapacityE" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtCapacityE"
                                CssClass="text-danger" ValidationGroup="valDeviceE" Text="Số lượng chỉ nhập số"
                                ValidationExpression="^[0-9]{1,15}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-3">
                             C/suất sử dụng(kW)</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtCapacityUse" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtCapacityUse"
                                CssClass="text-danger" ValidationGroup="valDeviceE" Text="C/suất sử dụng chỉ nhập số"
                                ValidationExpression="^[0-9]{1,15}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Số giờ vận hành/ngày</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtHoursE" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtHoursC"
                                CssClass="text-danger" ValidationGroup="valDeviceE" Type="Integer" Text="Số giờ vận hành chỉ nhập từ 0 đến 24"
                                MinimumValue="0" MaximumValue="24" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveE" runat="server" Visible="true" ValidationGroup="valDeviceE"
                    Text="Lưu lại" OnClick="btnSaveE_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">


    function ShowDialogCompressor(id) {
        if (id == 0) {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtDeviceNameC.ClientID%>").val('');
            $("#<%=txtQuantityC.ClientID%>").val('');
            $("#<%=txtCapacityC.ClientID%>").val('');
            $("#<%=txtPressureC.ClientID%>").val('');
            $("#<%=txtPressureLVC.ClientID%>").val('');
            $("#<%=txtHoursC.ClientID%>").val('');
        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }
        $('#dlgCompressor').modal('toggle');
    }
    function ShowDialogBoiler(id) {
        if (id == 0) {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtDeviceNameB.ClientID%>").val('');
            $("#<%=txtQuantityB.ClientID%>").val('');
            $("#<%=txtCapacityB.ClientID%>").val('');      
            $("#<%=txtHoursB.ClientID%>").val('');
        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }
        $('#dlgBoiler').modal('toggle');
    }
    function ShowDialogFurnaces(id) {
        if (id == 0) {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtDeviceNameF.ClientID%>").val('');
            $("#<%=txtQuantityF.ClientID%>").val('');
            $("#<%=txtCapacityF.ClientID%>").val('');
            $("#<%=txtHoursF.ClientID%>").val('');
        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }
        $('#dlgFurnaces').modal('toggle');
    }
    function ShowDialogElectricMotor(id) {
        if (id == 0) {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtDeviceNameE.ClientID%>").val('');
            $("#<%=txtQuantityE.ClientID%>").val('');
            $("#<%=txtCapacityE.ClientID%>").val('');
            $("#<%=txtCapacityUse.ClientID%>").val('');
            $("#<%=txtHoursE.ClientID%>").val('');
        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }
        $('#dlgElectricMotor').modal('toggle');
    }
    
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
