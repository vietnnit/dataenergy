<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditSolutionReport.ascx.cs"
    Inherits="Client_Module_DataEngery_AuditSolutionReport" %>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <div class="margin-bottom-10">
                <div class="control-label pt5" style="width: 100%">
                    <b>Tổng hợp giải pháp tiết kiệm năng lượng</b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnAddPlan" runat="server" Text="Thêm kết quả thực hiện" ToolTip="Thêm mới"
                            OnClientClick='javascript:ShowDialogAddSaveSolution(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 20%">
                                Giải pháp TKNL dự kiến
                                <br />
                                <asp:LinkButton ID="btnAddSolution" runat="server" CssClass="fs9 btn btn-primary"
                                    Text="Thêm giải pháp" ToolTip="Thêm giải pháp" OnClientClick='javascript:ShowDialogSolution(); return false;'><i class="fa fa-plus"></i>&nbsp;Thêm giải pháp</asp:LinkButton>
                            </th>
                            <th style="width: 15%" class="text-center">
                                Nhiên liệu
                            </th>
                            <th style="width: 10%" class="text-center">
                                Số lượng
                            </th>
                            <th style="width: 10%" class="text-center">
                                Đơn vị
                            </th>
                            <th style="width: 10%" class="text-center">
                                Năng lượng TK (TOE)
                            </th>
                            <th style="width: 15%" class="text-center">
                                Mức đầu tư dự kiến<br />
                                (Tr.đồng)
                            </th>
                            <th style="width: 10%" class="text-center">
                                Thời gian hoàn vốn (Năm)
                            </th>
                            <th style="width: 5%" class="text-center">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptResultTKNL" runat="server" OnItemCommand="rptResultTKNL_ItemCommand"
                            OnItemDataBound="rptResultTKNL_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("TenGiaiPhap")%>
                                    </td>
                                    <td>
                                        <%# Eval("FuelName")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Quantity") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Quantity"),2) : ""%>
                                    </td>
                                    <td class="text-center">
                                        <%# Eval("MeasurementName")%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("NoTOE") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NoTOE"),2) : ""%>
                                    </td>
                                    <td class="text-right">
                                        <%# Eval("Budget") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Budget"),0) : ""%>
                                    </td>
                                    <td class="text-right">                                        
                                        <%# Eval("TimeExecuted") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("TimeExecuted"), 2) : ""%>
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
<!-- / modal dialog giaiphap -->
<div class="modal" tabindex="-1" role="dialog" id="dlgSolution" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header panel-heading">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    <i class="fa fa-sliders"></i>Cập nhật giải pháp tiết kiệm năng lượng</h3>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <asp:Literal ID="ltNoticeSolution" runat="server"></asp:Literal>
                </div>
                <div class="form-group">
                    <label class="control-label col-lg-3">
                        Tên giải pháp <span class="append-icon right text-danger">*</span>:</label>
                    <div class="col-lg-9">
                        <asp:TextBox runat="server" class="form-control" ID="txtSolutionName"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSolutionName"
                            ValidationGroup="viewSolutionOne" Text="Vui lòng nhập tên giải pháp" Display="Dynamic"></asp:RequiredFieldValidator></div>
                </div>
                <div class="form-group">
                    <label class="control-label col-lg-3">
                        Mô tả:</label>
                    <div class="col-lg-9">
                        <asp:TextBox runat="server" class="form-control" ID="txtDes" TextMode="MultiLine"
                            Rows="3"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveSolution" runat="server" Visible="true" Text="Lưu lại" ValidationGroup="viewSolutionOne"
                    OnClick="btnSaveSolution_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false"
                    UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<div class="modal" tabindex="-1" role="dialog" id="dlgSaveSolution" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Giải pháp TKNL</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Giải pháp TKNL:</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" CssClass="form-control input-sm" ID="ddlSolution"
                                Name="Giải pháp" DataMember="Id" DataValueField="Id" DataTextField="TenGiaiPhap">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Display="Dynamic" runat="server"
                                ControlToValidate="ddlSolution" ValidationGroup="valAddSolutionTKNL" Text="Vui lòng chọn giải pháp"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Loại nhiên liệu <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddlFuelType" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                AutoPostBack="true" ValidationGroup="valAddSolutionTKNL" OnSelectedIndexChanged="ddlFuel_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlFuelType"
                                ValidationGroup="valAddSolutionTKNL" Text="Vui lòng chọn loại nhiên liệu" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Số lượng<asp:Literal ID="ltMeasurement" runat="server"></asp:Literal></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtQuantity"
                                ValidationGroup="valAddSolutionTKNL" Text="Vui lòng nhập số lượng" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RangeValidator1" runat="server" ControlToValidate="txtQuantity"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Số lượng chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="ddlMeasure" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="valAddSolutionTKNL">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMeasure"
                                ValidationGroup="valAddSolutionTKNL" Text="Chọn đơn vị" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Dự kiến đầu tư (Tr.đồng):</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtBudget" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBudget"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Dự kiến đầu tư chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-3">
                            Thời gian hoàn vốn (năm):</label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtTimeExecuted" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtTimeExecuted"
                                ValidationGroup="valAddSolutionTKNL" Text="Thời gian hoàn vốn" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTimeExecuted"
                                CssClass="text-danger" ValidationGroup="valAddSolutionTKNL" Text="Thời gian hoàn vốn chỉ nhập số"
                                ValidationExpression="^[0-9]+(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:LinkButton ID="btnSaveAddPlan" runat="server" Visible="true" ValidationGroup="valAddSolutionTKNL"
                    Text="Lưu lại" OnClick="btnSaveAddPlan_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:LinkButton>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    function ShowDialogSaveSolution() {
        $('#dlgSaveSolution').modal('toggle');
    }
    function ShowDialogAddSaveSolution() {
        $("#<%=hdnId.ClientID%>").val("0");
        $("#<%=txtBudget.ClientID%>").val('');
        $("#<%=txtQuantity.ClientID%>").val('');
        $("#<%=txtTimeExecuted.ClientID%>").val('');
        $("#<%=ddlMeasure.ClientID%>").attr('selectedIndex', 0);
        $("#<%=ddlSolution.ClientID%>").attr('selectedIndex', 0);
        $("#<%=ddlFuelType.ClientID%>").attr('selectedIndex', 0);
        $('#dlgSaveSolution').modal('toggle');
    }
    function ShowDialogSolution() {
        $('#dlgSolution').modal('toggle');
    }
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
