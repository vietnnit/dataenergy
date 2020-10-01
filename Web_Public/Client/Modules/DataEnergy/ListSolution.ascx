<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListSolution.ascx.cs"
    Inherits="Client_Modules_DataEnergy_ListSolution" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:HiddenField ID="hdnSolutionId" Value="0" runat="server" />
<div class="row mb10">
    <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="row">                   
                    <div class="form-group col-lg-12">
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
            <div class="row">
                <div class="col-lg-6">
                    <div class="dataTables_length">
                        <label>
                            <asp:Literal ID="ltrTotal" runat="server"></asp:Literal></label>
                    </div>
                </div>
                <div class="col-lg-6" style="text-align: right">
                    <div class="dataTables_paginate paging_simple_numbers">
                        <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                            LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                    </div>
                </div>
            </div>           
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-lg-12">
                        <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
                        <table class="table table-bordered table-hover mbn" width="100%">
                            <tr class="primary fs12">
                                <th style="width: 5%">
                                    STT
                                </th>
                                <th style="width: 25%">
                                    Tên giải pháp
                                </th>
                                <th>
                                    Mô tả giải pháp
                                </th>
                                <th style="width: 8%">
                                    Thao tác
                                </th>
                            </tr>
                            <asp:Repeater ID="rptSolution" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="text-center">
                                            <%#Container.ItemIndex+1  %>
                                        </td>
                                        <td>
                                            <%#Eval("TenGiaiPhap")%>
                                        </td>
                                        <td>
                                            <%#Eval("MoTa")%>
                                        </td>
                                        <td style="text-align: center">
                                            <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" ToolTip="Sửa thông tin"
                                                CommandArgument='<%#Eval("Id") %>'><span class="fa fa-edit"></span></asp:LinkButton>&nbsp;&nbsp;
                                            <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClick="return confirm('Bạn chắc chắn muốn xóa giải pháp này không?');"
                                                ToolTip="Xóa bỏ" CommandArgument='<%#Eval("Id") %>'> <span class="fa fa-times text-danger" ></span></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-12 text-left">
                        <input value="Thêm mới" class="btn btn-sm btn-info" onclick="addgiaiphap();return false;"
                            type="submit" />
                    </div>
                </div>
                <asp:Literal ID="error" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
<!-- / modal dialog giaiphap -->
<div class="modal" tabindex="-1" role="dialog" id="mygiaiphap" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header panel-heading">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                <h3 class="modal-title">
                    Cập nhật giải pháp tiết kiệm năng lượng</h3>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="form-group col-lg-12">
                        <asp:Literal ID="ltNoticeSolution" runat="server"></asp:Literal>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Tên giải pháp</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" class="form-control" ID="txtnamegp"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnamegp"
                                Display="Dynamic" ValidationGroup="viewSolution" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="form-group col-lg-12">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Mô tả</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" class="form-control" ID="txtmotagp"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmotagp"
                                Display="Dynamic" ValidationGroup="viewSolution" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator></div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveSolution" runat="server" Visible="true" Text="Lưu lại" ValidationGroup="viewSolution"
                    OnClick="btnSaveSolution_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false"
                    UseSubmitBehavior="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function addgiaiphap() {
        $("#<%=hdnSolutionId.ClientID%>").val('0');
        $('#mygiaiphap').modal('toggle');
    }
    function updategiaiphap() {
        $('#mygiaiphap').modal('toggle');
    }         
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
