<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListFuel.ascx.cs" Inherits="Client_Admin_ListFuel" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagPrefix="uc1" TagName="PagingControl" %>
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();">
                    <asp:Literal ID="litModules" runat="server"></asp:Literal></a>
            </li>
            <li class="crumb-icon">
                <a href="/Admin/Home/Default.aspx">
                    <span class="glyphicon glyphicon-home"></span>
                </a>
            </li>
        </ol>
    </div>
    <div class="topbar-right">
        <div class="topbar-icon ml15 ib va-m">
            <a href="/Admin/home/Default.aspx" class="pl5" title="Trang chủ">
                <i class="fa fa-home fs22 text-danger"></i>
                <br />
                <span class="fs11">Trang chủ</span>
            </a>
        </div>
        <div class="topbar-icon ml15 ib va-m">
            <a href="addFuel();return false;" onclick="addFuel();return false;">
                <i class="fa fa-plus fs22 text-primary"></i>
                <br />
                <span class="fs11">Thêm mới</span>
            </a>
        </div>
        <%-- <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnOrder" runat="server" OnClick='btn_Order_Click' CssClass="pl5" title="Sắp xếp"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Sắp xếp</span>
            </asp:LinkButton>
        </div>     --%>
        <%-- <div class="topbar-icon ml15 ib va-m">
            <a href="#" class="pl5" title="Trợ giúp"> 
                <i class="fa fa-exclamation-circle fs22 text-primary"></i><br /><span class="fs11">Trợ giúp</span>
            </a>
        </div>--%>
    </div>
</header>
<!-- Begin: Content -->
<section id="content">
    <!-- Dashboard Tiles -->
    <div class="row mb10">
        <div class="panel">
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">Nhóm nhiên liệu</label>
                        <div class="col-lg-2">
                            <asp:DropDownList ID="ddlParent" runat="server" AppendDataBoundItems="True"
                                CssClass="form-control input-sm" ValidationGroup="vgInfo">
                            </asp:DropDownList>

                        </div>
                        <label class="col-lg-1 control-label pt5" for="inputSmall">Từ khóa</label>
                        <div class="col-lg-2">
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Nhập từ khóa"></asp:TextBox>
                        </div>
                        <div class="col-lg-5">
                            <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm" OnClick="btn_search_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel">
            <div class="panel-body">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>
                <div class="form-group">
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
                <div class="table-responsive mb20">
                    <asp:GridView ID="grvFuel" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover mbn"
                        AllowPaging="false" OnRowCommand="grvFuel_RowCommand" EmptyDataText="Không tìm thấy nhiên liệu nào"
                        OnRowDataBound="grvFuel_RowDataBound" DataKeyNames="Id">
                        <HeaderStyle CssClass="primary fs12" />
                        <Columns>
                            <asp:BoundField HeaderText="STT" DataField="row">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center p5" Width="5%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Loại nhiên liệu">
                                <ItemStyle CssClass="TextLeft" />
                                <ItemTemplate>
                                    <%# Eval("FuelName")%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center p5" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nhóm nhiên liệu">
                                <ItemStyle CssClass="TextLeft" />
                                <ItemTemplate>
                                    <%# Eval("GroupFuelName")%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center p5" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Đơn vị chuẩn">
                                <ItemStyle CssClass="TextLeft" />
                                <ItemTemplate>
                                    <%# Eval("MeasurementName")%>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center p5" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chức năng">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center p5" Width="8%" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Id") %>' ToolTip="Cập nhật thông tin">
                                <span class="glyphicons glyphicons-edit fs18"></span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btn_delete" OnClientClick="return confirm('Bạn chắc chắn có muốn xóa nhiên liệu không?');" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa bỏ">
                                <span class="glyphicons glyphicons-remove_2 fs18 text-danger" ></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Hệ số quy đổi TOE theo đơn vị tính">
                                <ItemStyle CssClass="TextLeft" />
                                <ItemTemplate>
                                    <asp:Literal ID="ltTOE" runat="server"></asp:Literal>
                                    <a title="Thêm mới hệ số quy đổi" onclick="javascript:addtoefuel('<%# Eval("FuelName")%>','<%# Eval("Id")%>');return false;"><span class="glyphicon glyphicon-plus"></span></a>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center p5" Width="27%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quy đổi CO2">
                                <ItemStyle CssClass="TextLeft" />
                                <ItemTemplate>
                                    <asp:Literal ID="ltCO2" runat="server"></asp:Literal>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center p5" Width="27%" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
                <div class="form-group ">
                    <div class="col-lg-12 text-left">
                        <input value="Thêm mới nhiên liệu" class="btn btn-sm btn-system mr10" onclick="addFuel(); return false;"
                            type="submit" />
                        <%--<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/CreateFuel/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" />--%>
                        <%--<asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />--%>
                    </div>
                </div>
            </div>
        </div>


    </div>
</section>
<div class="modal fade" tabindex="-1" role="dialog" id="popupFuel">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Cập nhật nhiên liệu</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Loại nhiên liệu</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" class="form-control input-sm" ID="txtTitle"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
                                Display="Dynamic" ValidationGroup="vgFuel" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Nhóm nhiên liệu</label>
                        <div class="col-lg-6">
                            <asp:DropDownList runat="server" ID="ddlGroupFuel" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGroupFuel"
                                Display="Dynamic" ValidationGroup="vgFuel" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Đơn vị tính quy chuẩn</label>
                        <div class="col-lg-6">
                            <asp:DropDownList runat="server" ID="ddlMeasurement" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMeasurement"
                                Display="Dynamic" ValidationGroup="vgFuel" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            TOE/ Đơn vị tính</label>
                        <div class="col-lg-1">
                            (từ)
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" class="form-control input-sm" ID="txtFromTOE_S"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFromTOE_S"
                                Display="Dynamic" ValidationGroup="vgFuel" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtFromTOE_S"
                                CssClass="text-danger" ValidationGroup="vgFuel" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]{1,10}(\,[0-9]{1,10})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-2">
                            đến (Nếu có)
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" class="form-control input-sm" ID="txtToTOE_S"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtToTOE_S"
                                CssClass="text-danger" ValidationGroup="vgFuel" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]{1,10}(\,[0-9]{1,10})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Quy đổi CO<sub>2</sub></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" class="form-control input-sm" ID="txtNoCO2_S"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNoCO2_S"
                                Display="Dynamic" ValidationGroup="vgFuel" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtNoCO2_S"
                                CssClass="text-danger" ValidationGroup="vgFuel" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]{1,10}(\,[0-9]{1,10})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>

                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSave" runat="server" ValidationGroup="vgFuel" Visible="true" Text="Lưu lại"
                    OnClick="btnSave_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="popupfueltoe">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Hệ số quy đổi TOE theo đơn vị tính</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <asp:HiddenField ID="hdnToeId" Value="0" runat="server" />
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Loại nhiên liệu</label>
                        <div class="col-lg-9">
                            <asp:TextBox runat="server" Enabled="false" class="form-control input-sm" ID="lblFuelName"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Đơn vị tính</label>
                        <div class="col-lg-9">
                            <asp:DropDownList runat="server" ID="ddlMeasurement1" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlMeasurement1"
                                Display="Dynamic" ValidationGroup="vgtoeFuel" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            TOE/ Đơn vị tính</label>
                        <div class="col-lg-1">
                            (từ)
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" class="form-control input-sm" ID="txttoeFrom"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txttoeFrom"
                                Display="Dynamic" ValidationGroup="vgtoeFuel" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txttoeFrom"
                                CssClass="text-danger" ValidationGroup="vgtoeFuel" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]{1,10}(\,[0-9]{1,10})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-lg-2">
                            đến (Nếu có)
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" class="form-control input-sm" ID="txttoeto"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txttoeto"
                                CssClass="text-danger" ValidationGroup="vgtoeFuel" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]{1,10}(\,[0-9]{1,10})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3 control-label" for="inputSmall">
                            Quy đổi CO<sub>2</sub></label>
                        <div class="col-lg-3">
                            <asp:TextBox runat="server" class="form-control input-sm" ID="txtNoCO2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNoCO2"
                                Display="Dynamic" ValidationGroup="vgtoeFuel" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtNoCO2"
                                CssClass="text-danger" ValidationGroup="vgtoeFuel" Text="Chỉ nhập số"
                                ValidationExpression="^[0-9]{1,10}(\,[0-9]{1,10})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>

                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSaveTOE" runat="server" ValidationGroup="vgtoeFuel" Visible="true"
                    Text="Lưu lại" OnClick="btnSaveTOE_Click" CssClass="btn btn-sm btn-primary mr10" AutoPostback="false"></asp:Button>
                <asp:Button ID="btnDeleteTOE" runat="server" OnClientClick="return confirm('Bạn chắc chắn có muốn xóa hệ số không?');"
                    Visible="true" Text="Xóa bỏ" OnClick="btnDeleteTOE_Click" CssClass="btn btn-sm btn-danger mr10"
                    AutoPostback="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function addFuel() {
        $(document).ready(function () {
            $("#<%=hdnEditId.ClientID%>").val('0');
            $("#<%=txtTitle.ClientID%>").val('');
            $('#popupFuel').modal('toggle');
        });
    }
    function updateFuel() {
        $(document).ready(function () {
            $('#popupFuel').modal('toggle');
        });
    }
    function showupdatetoefuel() {
        $(document).ready(function () {
            $('#popupfueltoe').modal('toggle');
        });
    }

    function updatetoefuel(id, fuelname, fuelid, fromtoe, totoe, noco2, measurementid) {
        $(document).ready(function () {
            $("#<%=hdnfuelid.ClientID%>").val(fuelid);
            $("#<%=hdnToeId.ClientID%>").val(id);
            $("#<%=txttoeFrom.ClientID%>").val(fromtoe);
            $("#<%=txttoeto.ClientID%>").val(totoe);
            $("#<%=txtNoCO2.ClientID%>").val(noco2);
            $("#<%=lblFuelName.ClientID%>").val(fuelname);
            $("#<%=ddlMeasurement1.ClientID%>").val(measurementid);
            $('#popupfueltoe').modal('toggle');
        });
    }

    function addtoefuel(fuelname, fuelid) {
        $(document).ready(function () {
            $("#<%=hdnfuelid.ClientID%>").val(fuelid);
            $("#<%=lblFuelName.ClientID%>").val(fuelname);
            $("#<%=hdnToeId.ClientID%>").val('0');
            $("#<%=txttoeFrom.ClientID%>").val('');
            $("#<%=txttoeto.ClientID%>").val('');
            $('#popupfueltoe').modal('toggle');
        });
    }        
</script>
<style type="text/css">
    .modal-dialog {
        z-index: 9999 !important;
    }
</style>
<asp:HiddenField ID="hdnEditId" Value="0" runat="server" />
<asp:HiddenField ID="hdnfuelid" Value="0" runat="server" />
