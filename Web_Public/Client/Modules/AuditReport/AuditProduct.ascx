<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditProduct.ascx.cs"
    Inherits="Client_Module_DataEngery_AuditProduct" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <div class="margin-bottom-10">
                <div class="control-label pt5" style="width: 100%">
                    <b>
                        <asp:Literal ID="ltOldYear" runat="server" Text="Nguyên liệu tiêu thụ"></asp:Literal></b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnAddProductResult" runat="server" Text="Thêm mới" ToolTip="Thêm mới"
                            OnClientClick="javascript:ShowDialogMaterial(); return false;"><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 50%">
                                Tên nguyên liệu
                                <br />
                                <asp:LinkButton ID="btnAddProductNext" runat="server" CssClass="fs9 btn btn-primary"
                                    Text="Thêm nguyên liệu" ToolTip="Thêm nguyên liệu" OnClientClick='javascript:ShowDialogMaterialList(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm nguyên liệu</asp:LinkButton>
                            </th>
                            <th style="width: 15%" class="text-center">
                                Đơn vị đo
                            </th>
                            <th style="width: 20%" class="text-center">
                                Số lượng
                            </th>
                            <th style="width: 10%" class="text-center">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptMaterial" runat="server" OnItemCommand="rptMaterial_ItemCommand"
                            OnItemDataBound="rptMaterial_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("ProductName")%>
                                    </td>
                                    <td class="text-center">
                                        <%# Eval("Measurement")%>
                                    </td>
                                    <td class="text-right">                                        
                                        <%# Eval("Quantity") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Quantity"), 2) : ""%>
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
                    <b>Sản phẩm sản xuất</b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnAddProductNextResult" runat="server" Text="Thêm mới" ToolTip="Thêm sản phẩm"
                            OnClientClick='javascript:ShowDialogProduct(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 50%">
                                Tên sản phẩm<br />
                                <asp:LinkButton ID="btnAddProductPlan" runat="server" CssClass="fs9 btn btn-primary"
                                    Text="Thêm sản phẩm" ToolTip="Thêm sản phẩm" OnClientClick='javascript:AddProduct(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm sản phẩm</asp:LinkButton>
                            </th>
                            <th style="width: 15%" class="text-center">
                                Đơn vị đo
                            </th>
                            <th style="width: 20%" class="text-center">
                                Sản lượng
                            </th>
                            <th style="width: 10%" class="text-center">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptProduct" runat="server" OnItemCommand="rptProduct_ItemCommand"
                            OnItemDataBound="rptProduct_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("ProductName")%>
                                    </td>
                                    <td class="text-center">
                                        <%# Eval("Measurement")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Quantity") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Quantity"), 2) : ""%>
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
<div class="modal" tabindex="-1" role="dialog" id="dlgMaterialList" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Cập nhật danh mục nguyên liệu thực tế</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Nguyên liệu<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtMaterialName" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMaterialName"
                                CssClass="text-danger" ValidationGroup="valMaterial" Text="Vui lòng nhập tên nguyên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Đơn vị tính<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtMeasurementM" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMeasurementM"
                                CssClass="text-danger" ValidationGroup="valMaterial" Text="Vui lòng nhập đơn vị tính tấn/năm;m/năm;..."
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Ghi chú:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtDesM" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveMaterialList" runat="server" Visible="true" ValidationGroup="valMaterial"
                    Text="Lưu lại" OnClick="btnSaveMaterialList_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<!-- / modal dialog giaiphap -->
<div class="modal" tabindex="-1" role="dialog" id="divProduct" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Cập nhật danh mục sản phẩm sản thực tế</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên sản phẩm<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProductName"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập tên sản phẩm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Năng lực sản xuất theo thiết kế<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtDesignQty" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDesignQty"
                                CssClass="text-danger" ValidationGroup="valProduct" Text=" Năng lực sản xuất theo thiết kế chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesignQty"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập năng lực sản xuất"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Đơn vị tính<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtMeasurement" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMeasurement"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập đơn vị tính tấn/năm;m/năm;..."
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Năm bắt đầu SX</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtYearStart" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="rvYearStart" runat="server" ControlToValidate="txtYearStart"
                                Text="Vui lòng nhập năm bắt đầu trong khoảng từ 0 đến 9999" ValidationGroup="valProduct"
                                CssClass="text-danger" Type="Double" MinimumValue="0" MaximumValue="9999" Display="Dynamic"></asp:RangeValidator>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtYearStart"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập năm bắt đầu sản xuất"
                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </div>
                        <label class="col-lg-3">
                            Kết thúc SX:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtYearEnd" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="rvYearEnd" runat="server" ControlToValidate="txtYearStart"
                                CssClass="text-danger" Text="Vui lòng nhập năm kết thúc trong khoảng từ 0 đến 9999"
                                ValidationGroup="valProduct" Type="Double" MinimumValue="0" MaximumValue="9999"
                                Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Ghi chú:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveProduct" runat="server" Visible="true" ValidationGroup="valProduct"
                    Text="Lưu lại" OnClick="btnSaveProduct_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgMaterial" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Báo cáo nguyên liệu cho sản xuất</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Nguyên liệu <span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" ID="ddlMaterial" CssClass="form-control input-sm"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlMaterial_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMaterial"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Vui lòng chọn nguyên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Số lượng <span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtMaterialQty" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="txtMaterialQty" ValidationGroup="valProductYear" Text="Vui lòng nhập số lượng"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMaterialQty"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Số lượng chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:Literal ID="ltMaterialMeasurement" runat="server"></asp:Literal></div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveMaterial" runat="server" Visible="true" ValidationGroup="valProductYear"
                    Text="Lưu lại" OnClick="btnSaveMaterial_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgProduct" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Báo cáo kết quả sản xuất sản phẩm</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Sản phẩm <span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" ID="ddlProduct" CssClass="form-control input-sm"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProduct"
                                ValidationGroup="valProductYearPlan" Text="Vui lòng chọn sản phẩm" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Sản lượng <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtProductQty" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtProductQty"
                                ValidationGroup="valProductYearPlan" Text="Vui lòng nhập sản lượng" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtProductQty"
                                CssClass="text-danger" ValidationGroup="valProductYearPlan" Text="Sản lượng chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:Literal ID="ltProductMeasurement" runat="server"></asp:Literal></div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveProductUse" runat="server" Visible="true" ValidationGroup="valProductYearPlan"
                    Text="Lưu lại" OnClick="btnSaveProductUse_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
            s
        </div>
    </div>
</div>
<script type="text/javascript">

    function AddProduct() {

        if ("1" == "1") {
            $("#<%=txtYearStart.ClientID%>").val('');
            $("#<%=txtYearEnd.ClientID%>").val('');
            $("#<%=txtDescription.ClientID%>").val('');
        }
        else {

        }
        $('#divProduct').modal('toggle');
    }
    function ShowDialogMaterialList() {
        $('#dlgMaterialList').modal('toggle');
    }
    function ShowDialogMaterial(id) {

        if (id == "0") {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtMaterialQty.ClientID%>").val('');
            $("#<%=ltMaterialMeasurement.ClientID%>").val('');
        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }
        $('#dlgMaterial').modal('toggle');
    }
    function ShowDialogProduct(id) {

        if (id == "0") {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtProductQty.ClientID%>").val('');
            $("#<%=ltProductMeasurement.ClientID%>").val('');
        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }

        $('#dlgProduct').modal('toggle');
    }
    function UpdateKeHoach() {
        $(document).ready(function () {
            $('#myModal').modal('toggle');

        });

    }
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
