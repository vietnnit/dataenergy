<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductYear.ascx.cs" Inherits="Client_Module_DataEngery_ProductYear" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">

        <div class="col-lg-12" style="display:none;">
            <div class="">
                <div class="control-label pt5" style="width: 100%" for="inputSmall">
                    <b>2.1. Thông tin cơ sở hạ tầng</b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnEditInfo" runat="server" Text="Sửa thông tin" ToolTip="Sửa thông tin"
                            OnClientClick='javascript:UpdateInfratructure(); return false;'><i class="fa fa-edit"></i>&nbsp;Sửa thông tin</asp:LinkButton>
                    </div>
                </div>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <thead>
                    <tr>
                        <td style="width: 10%">Năm đưa cơ sở vào hoạt động:
                        </td>
                        <td style="width: 10%;" colspan="2">
                            <asp:Literal ID="ltActiveYear" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 10%">Số lao động/diện tích mặt bằng
                        </th>
                        <th style="width: 10%">Khu vực sản xuất
                        </th>
                        <th style="width: 15%">Khu vực văn phòng
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Tổng số lao động hiện tại
                        </td>
                        <td>
                            <asp:Literal ID="ltProduceEmployeeNo" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="ltOfficeEmployeeNo" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Diện tích mặt bằng(m<sup>2</sup>)
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

        <%--1.1 Năng lực sản xuất của cơ sở năm [N-1]--%>
        <div class="col-lg-12">
            <label class="control-label">
                <asp:Literal ID="ltOldYear" runat="server" Text="2.1. Năng lực sản xuất"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>a. Năng lực sản xuất năm hiện tại<asp:Literal ID="ltReportYear" runat="server"></asp:Literal></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddProductResult" runat="server" Text="Thêm mới" ToolTip="Thêm mới"
                                OnClientClick='javascript:AddProductQty(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 15%">Tên sản phẩm
                                <br />
                                <asp:LinkButton ID="btnAddProductNext" runat="server" CssClass="fs9 btn btn-primary"
                                    Text="Thêm sản phẩm" ToolTip="Thêm sản phẩm" OnClientClick='javascript:AddProduct(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm sản phẩm</asp:LinkButton>
                            </th>
                            <th style="width: 10%">Đơn vị đo
                            </th>
                            <th style="width: 15%">Theo thiết kế
                            </th>
                            <th style="width: 20%">Mức sản xuất hiện tại
                            </th>
                            <th style="width: 20%">Tiêu thụ năng lượng theo sản phẩm
                            </th>
                            <th style="width: 20%">Doanh thu
                            </th>
                            <th style="width: 5%">Thao tác
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
                                    <td class="text-right">
                                        <%# Eval("DesignQuantity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("MaxQuantity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("TieuThuNLTheoSP")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("DoanhThuTheoSP ")%>
                                    </td>
                                    <td>
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
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>b. Kế hoạch sản xuất năm tiếp theo <b>Năm
                            <asp:Literal ID="ltReportNext" runat="server"></asp:Literal></b></i>
                        <div style="float: right">
                            <asp:LinkButton ID="btnAddProductNextResult" runat="server" Text="Thêm mới" ToolTip="Thêm sản phẩm"
                                OnClientClick='javascript:AddProductQtyPlan(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <%--<th style="width: 5%">
                                            Năm
                                        </th>--%>
                            <th style="width: 15%">Tên sản phẩm<br />
                                <asp:LinkButton ID="btnAddProductPlan" runat="server" CssClass="fs9 btn btn-primary"
                                    Text="Thêm sản phẩm" ToolTip="Thêm sản phẩm" OnClientClick='javascript:AddProduct(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm sản phẩm</asp:LinkButton>
                            </th>
                                  <th style="width:10%">Đơn vị đo</th>
                             <th style="width: 15%">Theo thiết kế
                            </th>
                             <th style="width: 15%">Mức sản suất dự kiến
                            </th>
<%--                            <th style="width: 15%">Dự kiến sản xuất
                            </th>
                            <th style="width: 10%">Tỷ lệ so với chi phí sản xuất (%)
                            </th>
                            <th style="width: 15%">Tỷ lệ doanh thu (%)
                            </th>--%>
                            <th style="width: 5%">Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptProductPlan" runat="server" OnItemCommand="rptProductPlan_ItemCommand"
                            OnItemDataBound="rptProductPlan_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <%--<td>
                                                    <%# Eval("Nam")%>
                                                </td>--%>
                                    <td>
                                        <%# Eval("ProductName")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Measurement")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("DesignQuantity")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("MaxQuantity")%>
                                    </td>
                                    <td>
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

        <div class="col-lg-12" style="display:none;">
            <label class="control-label">
                <asp:Literal ID="ltNextYear" runat="server" Text="2.2. Điện năng mua ngoài và tự sản xuất"></asp:Literal></label>
            <div class="margin-bottom-10">
                <div class="">
                    <div class="control-label pt5" style="width: 100%">
                        <i>a. Điện mua ngoài và tự sản xuất năm hiện tại</i><div style="float: right">
                            <asp:LinkButton ID="btnEditElecttrict" runat="server" Text="Sửa thông tin" ToolTip="Sửa thông tin"
                                OnClientClick='javascript:UpdateElectrict(); return false;'><i class="fa fa-edit"></i>&nbsp;Sửa thông tin</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <tbody>
                        <tr class="primary fs12">
                            <td style="width: 10%">Điện năng mua ngoài
                            </td>
                            <td style="width: 10%">Công suất:
                                <asp:Literal ID="ltCapacityResult" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 10%;" colspan="2">Điện năng:
                                <asp:Literal ID="ltQuantityResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr class="primary fs12">
                            <td style="width: 10%">Giá mua điện ngoài
                            </td>
                            <td style="width: 10%">Giá trung bình theo công suất:
                                <asp:Literal ID="ltPriceAvgResult" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 10%;" colspan="2">Giá theo hóa đơn:
                                <asp:Literal ID="ltPriceBuy" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="4">Điện tự sản xuất
                            </td>
                            <td>Công suất lắp đặt
                            </td>
                            <td>
                                <asp:Literal ID="ltInstalledResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>Điện năng sản xuất
                            </td>
                            <td>
                                <asp:Literal ID="ltQuantityProduceResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>Công nghệ
                            </td>
                            <td>
                                <asp:Literal ID="ltTechnologyResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>Nhiên liệu sử dụng
                            </td>
                            <td>
                                <asp:Literal ID="ltFuelResult" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="control-label pt5" style="width: 100%" for="inputSmall">
                <i>b. Kế hoạch mua điện và tự sản xuất năm sau</i><div style="float: right">
                    <asp:LinkButton ID="btnEditElectrictPlan" runat="server" Text="Sửa thông tin" ToolTip="Sửa thông tin"
                        OnClientClick='javascript:UpdateElectrictPlan(); return false;'><i class="fa fa-edit"></i>&nbsp;Sửa thông tin</asp:LinkButton>
                </div>
            </div>
            <table class="table table-bordered table-hover mbn" width="100%">
                <tbody>
                    <tr class="primary fs12">
                        <td style="width: 10%">Điện năng mua ngoài
                        </td>
                        <td style="width: 10%">Công suất:
                            <asp:Literal ID="ltCapacityPlan" runat="server"></asp:Literal>
                        </td>
                        <td style="width: 10%;" colspan="2">Điện năng:
                            <asp:Literal ID="ltQuantityElectrictPlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Giá mua điện
                        </td>
                        <td>Giá điện dự kiến
                        </td>
                        <td>
                            <asp:Literal ID="ltPriceBuyPlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="5">Điện tự sản xuất(Nếu có)
                        </td>
                        <td>Công suất lắp đặt
                        </td>
                        <td>
                            <asp:Literal ID="ltInstalledCapacityPlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Điện năng sản xuất
                        </td>
                        <td>
                            <asp:Literal ID="ltQuantityProducePlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Giá điện sản xuất
                        </td>
                        <td>
                            <asp:Literal ID="ltPriceProducePlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Công nghệ
                        </td>
                        <td>
                            <asp:Literal ID="ltTecnologyPlan" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Nhiên liệu sử dụng
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
<br />
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<asp:HiddenField ID="hddvalue" runat="server" Value="" />
<!-- / modal dialog giaiphap -->
<div class="modal" tabindex="-1" role="dialog" id="divProduct" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Cập nhật danh mục sản phẩm sản xuất</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên sản phẩm<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProductName"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập tên sản phẩm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Năng lực sản xuất theo thiết kế<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtDesignQty" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDesignQty"
                                CssClass="text-danger" Text="Vui lòng nhập năng lực sản xuất là ký tự số" ValidationGroup="valProduct"
                                Type="Double" MinimumValue="0" MaximumValue="999999999999" Display="Dynamic"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesignQty"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập năng lực sản xuất"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Đơn vị tính<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtMeasurement" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMeasurement"
                                CssClass="text-danger" ValidationGroup="valProduct" Text="Vui lòng nhập đơn vị tính tấn/năm;m/năm;..."
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Năm Bắt đầu SX<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtYearStart" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="rvYearStart" runat="server" ControlToValidate="txtYearStart"
                                CssClass="text-danger" Text="Vui lòng nhập năm bắt đầu trong khoảng từ 0 đến 9999"
                                ValidationGroup="valProduct" Type="Double" MinimumValue="0" MaximumValue="9999"
                                Display="Dynamic"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtYearStart"
                                ValidationGroup="valProduct" Text="Vui lòng nhập năm bắt đầu sản xuất" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-3">
                            Kết thúc SX:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtYearEnd" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="rvYearEnd" runat="server" ControlToValidate="txtYearEnd"
                                CssClass="text-danger" Text="Vui lòng nhập năm kết thúc trong khoảng từ 0 đến 9999"
                                ValidationGroup="valProduct" Type="Double" MinimumValue="0" MaximumValue="9999"
                                Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Sử dụng năng lượng<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlProductFuel" CssClass="form-control input-sm" runat="server">
                            </asp:DropDownList>
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
<div class="modal" tabindex="-1" role="dialog" id="divProductYear" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Sản phẩm sản xuất năm báo cáo</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên sản phẩm<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" ID="ddlProduct" CssClass="form-control input-sm"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlProduct"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Vui lòng nhập tên sản phẩm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Năng lực SX theo thiết kế:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtQtyByDesign" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="txtQtyByDesign"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:Literal ID="ltMearsurement2" runat="server"></asp:Literal>
                        </div>
                    </div>
                     <div class="form-group">
                        <label class="col-lg-3">
                            Mức sản xuất cao nhất<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtMaxQty" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMaxQty" 
                                ValidationGroup="valProductYear" Text="Vui lòng nhập mức sản xuất cao nhất"
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtMaxQty"
                                        CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>                        
                        <div class="col-lg-3">
                            <asp:Literal ID="ltMeasurement" runat="server"></asp:Literal>
                        </div>
                    </div>             

                
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tiêu thụ năng lượng theo sản phẩm<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtTieuThuNLTheoSP" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtTieuThuNLTheoSP"
                                ValidationGroup="valProductYear" Text="Vui lòng nhập mức sản xuất cao nhất"
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="txtTieuThuNLTheoSP"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-lg-3">
                            Doanh thu theo sản phẩm<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtDoanhThuTheoSP" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtDoanhThuTheoSP"
                                ValidationGroup="valProductYear" Text="Vui lòng nhập mức sản xuất cao nhất"
                                CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txtDoanhThuTheoSP"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal-footer">
                <asp:Button ID="btnSaveProductYear" runat="server" Visible="true" ValidationGroup="valProductYear"
                    Text="Lưu lại" OnClick="btnSaveProductYear_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="divProductPlan" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Kế hoạch sản xuất năm tiếp theo</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tên sản phẩm<span class="append-icon right text-danger">*</span>:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" ID="ddlProductPlan" CssClass="form-control input-sm"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlProductPlan_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlProductPlan" CssClass="text-danger"
                                ValidationGroup="valProductYearPlan" Text="Vui lòng nhập tên sản phẩm" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Năng lực SX theo thiết kế:</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtQtyByDesignPlan" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtQtyByDesignPlan"
                                CssClass="text-danger" ValidationGroup="valProductYear" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Dự kiến sản xuất<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtMaxQtyPlan" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMaxQtyPlan"
                                CssClass="text-danger" ValidationGroup="valProductYearPlan" Text="Vui lòng nhập dự kiến sản xuất"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtMaxQtyPlan"
                                CssClass="text-danger" ValidationGroup="valProductYearPlan" Text="Chỉ nhập số" ValidationExpression="^[1-9]\d*(\,\d{1,2})?$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-6">
                            <asp:Literal ID="ltMeasurementPlan" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Tỷ lệ so với CPSX(%)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtRateOfCost" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtRateOfCost"
                                CssClass="text-danger" Text="Vui lòng nhập trong khoảng từ 0% đến 100%" ValidationGroup="valProductYearPlan"
                                Type="Double" MinimumValue="0" MaximumValue="100" Display="Dynamic"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtRateOfCost"
                                CssClass="text-danger" ValidationGroup="valProductYearPlan" Text="Vui lòng nhập tỷ lệ so với chi phí"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3">
                            Tỷ lệ so với Doanh thu(%)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtRateOfRevenue" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtRateOfRevenue"
                                CssClass="text-danger" Text="Vui lòng nhập trong khoảng từ 0% đến 100%" ValidationGroup="valProductYearPlan"
                                Type="Double" MinimumValue="0" MaximumValue="100" Display="Dynamic"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtRateOfRevenue"
                                CssClass="text-danger" ValidationGroup="valProductYearPlan" Text="Vui lòng nhập tỷ lệ so với doanh thu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveProductPlan" runat="server" Visible="true" ValidationGroup="valProductYearPlan"
                    Text="Lưu lại" OnClick="btnSaveProductPlan_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="divbaseInfo" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Cập nhật thông tin cơ sở</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <thead>
                            <%--<tr class="primary fs12">
                                <td style="width: 10%">
                                    Năm đưa cơ sở vào hoạt động:
                                </td>
                                <td style="width: 10%;" colspan="2">
                                   <asp:Literal ID="ltActiveYearValue" runat="server"></asp:Literal>
                                </td>
                            </tr>--%>
                            <tr class="primary fs12">
                                <th style="width: 30%">Số lao động/diện tích MB
                                </th>
                                <th style="width: 35%">Khu vực sản xuất
                                </th>
                                <th style="width: 35%">Khu vực văn phòng
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Tổng số lao động hiện tại
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProduceEmployeeNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtProduceEmployeeNo"
                                        CssClass="text-danger" ValidationGroup="valBasicInfo" Text="Vui lòng nhập số lao động khu vực sản xuất"
                                        Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="rfv1" runat="server" ControlToValidate="txtProduceEmployeeNo"
                                        CssClass="text-danger" ValidationGroup="valBasicInfo" Text="Chỉ nhập số" ValidationExpression="^[0-9]+$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOficeEmployeeNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtOficeEmployeeNo"
                                        CssClass="text-danger" ValidationGroup="valBasicInfo" Text="Vui lòng nhập số nhân viên khu vực văn phòng"
                                        Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="rfv2" runat="server" ControlToValidate="txtOficeEmployeeNo"
                                        CssClass="text-danger" ValidationGroup="valBasicInfo" Text="Chỉ nhập số" ValidationExpression="^[0-9]+$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Diện tích mặt bằng(m<sup>2</sup>)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProduceArea" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtProduceArea"
                                        CssClass="text-danger" ValidationGroup="valBasicInfo" Text="Vui lòng Diện tích khu vực sản xuất"
                                        Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtProduceArea"
                                        CssClass="text-danger" ValidationGroup="valBasicInfo" Text="Chỉ nhập số" ValidationExpression="^[0-9]+$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOfficeArea" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtOfficeArea"
                                        CssClass="text-danger" ValidationGroup="valBasicInfo" Text="Vui lòng Diện tích khu vực văn phòng" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtOfficeArea"
                                        CssClass="text-danger" ValidationGroup="valBasicInfo" Text="Chỉ nhập số" ValidationExpression="^[0-9]+$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveInfo" runat="server" Visible="true" Text="Lưu lại" OnClick="btnSaveInfo_Click"
                    CssClass="btn btn-sm btn-primary mr10" ValidationGroup="valBasicInfo" AutoPostback="false"
                    UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="divElectrict" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Điện mua ngoài và điện tự sản xuất</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tbody>
                            <tr class="primary fs12">
                                <td style="width: 10%">Điện năng mua ngoài
                                </td>
                                <td style="width: 10%">Công suất (kW)<span class="append-icon right text-danger">*</span>:
                                    <asp:TextBox ID="txtCapacity" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCapacity" CssClass="text-danger"
                                        ValidationGroup="valElectrict" Text="Vui lòng nhập công suất" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtCapacity"
                                        CssClass="text-danger" ValidationGroup="valElectrict" Text="Công suất chỉ nhập số"
                                        ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                                <td style="width: 10%;" colspan="2">Điện năng (10<sup>6</sup> kWh/năm)<span class="append-icon right text-danger">*</span>:
                                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtQuantity" CssClass="text-danger"
                                        ValidationGroup="valElectrict" Text="Vui lòng nhập điện năng mua" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtQuantity"
                                        CssClass="text-danger" ValidationGroup="valElectrict" Text="Điện năng chỉ nhập số"
                                        ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr class="primary fs12">
                                <td style="width: 10%">Giá mua điện
                                </td>
                                <td style="width: 10%">Theo TB công suất (đồng/kW)<span class="append-icon right text-danger">*</span>:
                                    <asp:TextBox ID="txtAvgPrice" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAvgPrice" CssClass="text-danger" SetFocusOnError="true"
                                        ValidationGroup="valElectrict" Text="Vui lòng nhập giá TB theo công suất" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="txtAvgPrice" SetFocusOnError="true"
                                        CssClass="text-danger" ValidationGroup="valElectrict" Text="Chi phí chỉ nhập số"
                                        ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                                <td style="width: 10%;" colspan="2">Theo hóa đơn(đồng/kWh):<span class="append-icon right text-danger">*</span>:
                                    <asp:TextBox ID="txtPriceBuy" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPriceBuy" CssClass="text-danger" SetFocusOnError="true"
                                        ValidationGroup="valElectrict" Text="Vui lòng nhập giá mua điện theo hóa đơn" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPriceBuy" SetFocusOnError="true"
                                        CssClass="text-danger" ValidationGroup="valElectrict" Text="Chi phí chỉ nhập số"
                                        ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="4">Điện tự sản xuất
                                </td>
                                <td>Công suất lắp đặt (kW)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInstalledCapacity" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtInstalledCapacity"
                                        ValidationGroup="valElectrict" Text="Vui lòng nhập công suất lắp đặt" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtInstalledCapacity"
                                        CssClass="text-danger" ValidationGroup="valElectrict" Text="Công suất lắp đặt chỉ nhập số"
                                        ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Điện năng sản xuất (10<sup>6</sup> kWh/năm)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProduceQty" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtProduceQty"
                                        ValidationGroup="valElectrict" Text="Vui lòng nhập điện năng tự sản xuất" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtProduceQty"
                                        CssClass="text-danger" ValidationGroup="valElectrict" Text="Chỉ nhập số" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$"
                                        Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Công nghệ
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTenologyElectrict" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtTenologyElectrict"
                                        ValidationGroup="valElectrict" Text="Vui lòng nhập công nghệ" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>Nhiên liệu sử dụng
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlFuel" CssClass="form-control input-sm">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="ddlFuel"
                                        ValidationGroup="valElectrict" Text="Vui lòng chọn nhiên liệu" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveElectrict" runat="server" Visible="true" Text="Lưu lại"
                    OnClick="btnSaveElectrict_Click" CssClass="btn btn-sm btn-primary mr10" ValidationGroup="valElectrict"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="divElectrictPlan" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">Kế hoạch mua điện và điện tự sản xuất</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tbody>
                            <tr class="primary fs12">
                                <td style="width: 10%">Điện năng mua ngoài
                                </td>
                                <td style="width: 10%">Công suất (kW)<span class="append-icon right text-danger">*</span>:
                                    <asp:TextBox ID="txtCapacityPlan" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtCapacityPlan" CssClass="text-danger"
                                        ValidationGroup="valElectrictPlan" Text="Vui lòng nhập công suất" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtCapacityPlan"
                                        CssClass="text-danger" ValidationGroup="valElectrictPlan" Text="Chỉ nhập số"
                                        ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                                <td style="width: 10%;" colspan="2">Điện năng (10<sup>6</sup> kWh/năm)<span class="append-icon right text-danger">*</span>:
                                    <asp:TextBox ID="txtElectrictQuantityPlan" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txtElectrictQuantityPlan" CssClass="text-danger"
                                        ValidationGroup="valElectrictPlan" Text="Vui lòng nhập điện năng mua ngoài" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtElectrictQuantityPlan"
                                        CssClass="text-danger" ValidationGroup="valElectrictPlan" Text="Chỉ nhập số"
                                        ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Giá mua điện
                                </td>
                                <td>Giá mua TB dự kiến (đồng/ kW)<span class="append-icon right text-danger">*</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCostPlan" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCostPlan" CssClass="text-danger"
                                        ValidationGroup="valElectrictPlan" Text="Vui lòng nhập giá mua điện dự kiến"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                        ControlToValidate="txtCostPlan" CssClass="text-danger" ValidationGroup="valElectrictPlan"
                                        Text="Chỉ nhập số" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="5">Điện tự sản xuất(Nếu có)
                                </td>
                                <td>Công suất lắp đặt (kW)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInstalledCapacityPlan" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="txtInstalledCapacityPlan"
                                        ValidationGroup="valElectrictPlan" Text="Vui lòng Công suất lắp đặt" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                        ControlToValidate="txtInstalledCapacityPlan" CssClass="text-danger" ValidationGroup="valElectrictPlan"
                                        Text="Chỉ nhập số" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Điện năng sản xuất (10<sup>6</sup> kWh/năm)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProduceQtyPlan" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txtProduceQtyPlan"
                                        ValidationGroup="valElectrictPlan" Text="Vui lòng nhập điện năng sản xuất" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                        ControlToValidate="txtProduceQtyPlan" CssClass="text-danger" ValidationGroup="valElectrictPlan"
                                        Text="Chỉ nhập số" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Giá điện sản xuất (đồng/ kW)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPriceProducePlan" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPriceProducePlan"
                                        ValidationGroup="valElectrictPlan" Text="Vui lòng nhập giá điện sản xuất" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                        ControlToValidate="txtPriceProducePlan" CssClass="text-danger" ValidationGroup="valElectrictPlan"
                                        Text="Chỉ nhập số" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Công nghệ
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTenologyPlan" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtTenologyPlan"
                                        ValidationGroup="valElectrictPlan" Text="Vui lòng nhập công nghệ" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>Nhiên liệu sử dụng
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlFuelPlan" CssClass="form-control input-sm">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="ddlFuelPlan"
                                        ValidationGroup="valElectrictPlan" Text="Vui lòng chọn nhiên liệu" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveElectrictPlan" runat="server" Visible="true" Text="Lưu lại"
                    OnClick="btnSaveElectrictPlan_Click" CssClass="btn btn-sm btn-primary mr10" ValidationGroup="valElectrictPlan"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function UpdateElectrict() {

        $('#divElectrict').modal('toggle');
    }
    function UpdateElectrictPlan() {

        $('#divElectrictPlan').modal('toggle');
    }
    function UpdateInfratructure() {
        $('#divbaseInfo').modal('toggle');
    }
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

    function AddProductQty(id) {

        if (id == "0") {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtMaxQtyPlan.ClientID%>").val('');
            $("#<%=txtRateOfCost.ClientID%>").val('');
            $("#<%=txtRateOfRevenue.ClientID%>").val('');
            $("#<%=ltMeasurement.ClientID%>").val('');
            $("#<%=txtQtyByDesign.ClientID%>").val('');
        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }
        $('#divProductYear').modal('toggle');
    }
    function AddProductQtyPlan(id) {

        if (id == "0") {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtMaxQtyPlan.ClientID%>").val('');
            $("#<%=txtRateOfCost.ClientID%>").val('');
            $("#<%=txtRateOfRevenue.ClientID%>").val('');
            $("#<%=ltMeasurementPlan.ClientID%>").val('');

        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }

        $('#divProductPlan').modal('toggle');
    }

</script>
<style type="text/css">
    .modal-dialog {
        z-index: 9999 !important;
    }
</style>
