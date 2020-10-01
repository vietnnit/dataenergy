<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditOperationArea.ascx.cs"
    Inherits="Client_Module_AuditReport_AuditOperationArea" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <div class="margin-bottom-10">
                <div class="control-label pt5" style="width: 100%">
                    <b>
                        <asp:Literal ID="ltOldYear" runat="server" Text="Số giờ vận hành"></asp:Literal></b>
                    <div style="float: right">
                        <asp:LinkButton ID="btnAddOperation" runat="server" Text="Thêm mới" ToolTip="Thêm mới"
                            OnClientClick="javascript:ShowDialogOperation('0'); return false;"><i class="fa fa-plus"></i>&nbsp;Thêm mới</asp:LinkButton></div>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr class="primary fs12">
                            <th style="width: 5%">
                                TT
                            </th>
                            <th style="width: 65%">
                                Khu vực
                            </th>
                            <th style="width: 20%">
                                Số giờ vận hành (giờ/năm)
                            </th>
                            <th style="width: 10%">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptOperation" runat="server" OnItemCommand="rptOperation_ItemCommand"
                            OnItemDataBound="rptOperation_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1  %>
                                    </td>
                                    <td>
                                        <%# Eval("AreaName")%>
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
<!-- / modal dialog giaiphap -->
<div class="modal" tabindex="-1" role="dialog" id="dlgArea" data-backdrop="static">
    <div class="modal-dialog large">
        <div class="modal-content">
            <div class="modal-header panel-heading  ">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Cập nhật số giờ vận hành</h3>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3">
                            Khu vực<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" ID="txtAreaName" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAreaName"
                                ValidationGroup="valOperation" Text="Vui lòng nhập khu vực" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label">
                            Số giờ vận hành (giờ/năm)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" ID="txtHours" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtHours" CssClass="text-danger"
                                Text="Vui lòng nhập số giờ vận hành từ 0 đến 8760" ValidationGroup="valOperation"
                                Type="Double" MinimumValue="0" MaximumValue="8760" Display="Dynamic"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHours" CssClass="text-danger"
                                ValidationGroup="valOperation" Text="Vui lòng nhập số giờ vận hành" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Visible="true" ValidationGroup="valOperation"
                    Text="Lưu lại" OnClick="btnSave_Click" CssClass="btn btn-sm btn-primary mr10"
                    AutoPostback="false" UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    function ShowDialogOperation(id) {

        if (id == "0") {
            $("#<%=hdnId.ClientID%>").val('0');
            $("#<%=txtHours.ClientID%>").val('');
            $("#<%=txtAreaName.ClientID%>").val('');
        }
        else {
            $("#<%=hdnId.ClientID%>").val(id);
        }

        $('#dlgArea').modal('toggle');
    }
   
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
