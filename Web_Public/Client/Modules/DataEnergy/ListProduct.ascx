<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListProduct.ascx.cs" Inherits="Client_Modules_DataEnergy_ListProduct" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:HiddenField ID="hdnEditId" Value="0" runat="server" />
<div class="row mb10">
    <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="row">
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Từ năm</label>
                        <div class="col-lg-2">
                            <asp:DropDownList ID="ddlYearStart" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Đến năm</label>
                        <div class="col-lg-2">
                            <asp:DropDownList ID="ddlYearEnd" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Loại</label>
                        <div class="col-lg-2">
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem Text="--Tất cả--" Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Sản phẩm" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Nguyên liệu" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Từ khóa</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder=""></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm"
                                OnClick="btn_search_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-lg-6">
                        <div class="dataTables_length">
                            <p>
                                <label>
                                    <asp:Literal ID="ltrTotal" runat="server"></asp:Literal></label></p>
                        </div>
                    </div>
                    <div class="col-lg-6" style="text-align: right">
                        <div class="dataTables_paginate paging_simple_numbers">
                            <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                                LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                        </div>
                    </div>
                </div>
                <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
                <div class="form-group">
                    <div class="col-lg-12">
                        <p>
                            <asp:Literal ID="ltTotalProduct" runat="server"></asp:Literal></p>
                        <table class="table table-bordered table-hover mbn" width="100%">
                            <tr class="primary fs12">
                                <th style="width: 5%">
                                    STT
                                </th>
                                <th>
                                    Tên sản phẩm
                                </th>
                                <th style="width: 15%">
                                    Sản lượng dự tính
                                </th>
                                <th style="width: 12%">
                                    Đơn vị tính
                                </th>
                                <th style="width: 14%" class="text-center">
                                    Khoảng năm
                                </th>
                                <th style="width: 20%">
                                    Ghi chú
                                </th>
                                <th style="width: 10%">
                                    Thao tác
                                </th>
                            </tr>
                            <asp:Repeater ID="rptProduct" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="text-center">
                                            <%#Eval("row")%>
                                        </td>
                                        <td>
                                            <%#Eval("ProductName")%>
                                        </td>
                                        <td>
                                            <%#Eval("Quantity")!=null?Convert.ToDecimal(Eval("Quantity")).ToString("0.###"):""%>
                                        </td>
                                        <td>
                                            <%#Eval("Measurement")%>
                                        </td>
                                        <td class="text-center">
                                            <%#Eval("YearStart")%>
                                            -
                                            <%#Eval("YearEnd")%>
                                        </td>
                                        <td>
                                            <%#Eval("Note")%>
                                        </td>
                                        <td class="text-center">
                                            <asp:LinkButton ID="btn_edit_product" OnClick="btn_edit_product_Click" runat="server"
                                                CommandArgument='<%# Eval("Id") %>' ToolTip="Sửa thông tin">
                                            <span class="fa fa-edit"></span>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btn_delete_product" OnClick="btn_delete_product_Click" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?');"
                                                runat="server" CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa bỏ">
                                            <span class="fa fa-times text-danger" ></span>
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-12 text-left">
                        <input value="Thêm mới" class="btn btn-sm btn-info" onclick="addproduct();return false;"
                            type="submit" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- popup them moi/ cap nhat -->
<div class="modal" tabindex="-1" role="dialog" id="popupproduct" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header panel-heading">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Cập nhật sản phẩm</h3>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Tên sản phẩm
                        </label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" class="form-control" ID="txtProductName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName"
                                Display="Dynamic" ValidationGroup="vgProduct" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Loại sản phẩm</label>
                        <div class="col-lg-10">
                            <asp:RadioButton ID="cbxIsproduct1" Checked="true" runat="server" Text="Sản phẩm"
                                CssClass="" GroupName="Isproduct" />&nbsp;
                            <asp:RadioButton ID="cbxIsproduct0" GroupName="Isproduct" runat="server" Text="Nguyên liệu"
                                CssClass="" /></div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Sản lượng dự tính</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" class="form-control" ID="txtQuantity"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQuantity" Display="Dynamic"
                                ValidationGroup="vgProduct" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Đơn vị tính</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" class="form-control" ID="txtMeasurement"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMeasurement"
                                Display="Dynamic" ValidationGroup="vgProduct" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Từ năm</label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlYearStartUpdate" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlYearStartUpdate"
                                Display="Dynamic" ValidationGroup="vgProduct" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator></div>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Đến năm</label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlYearEndUpdate" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlYearEndUpdate"
                                Display="Dynamic" ValidationGroup="vgProduct" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Ghi chú</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" class="form-control" ID="txtNote"></asp:TextBox></div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" Text="Lưu lại" ValidationGroup="vgProduct"
                    OnClick="btnSave_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false">
                </asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function addproduct() {
        $("#<%=hdnEditId.ClientID%>").val('0');
        $('#popupproduct').modal('toggle');
    }
    function updateproduct() {
        $('#popupproduct').modal('toggle');
    }         
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
