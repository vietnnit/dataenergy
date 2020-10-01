<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InputReportFuelDetail.ascx.cs"
    Inherits="Client_Modules_DataEnergy_InputReportFuelDetail" %>
<!-- Begin: Content -->
<!-- Dashboard Tiles -->
<div class="row mb10">
    <div class="panel">
        <div class="panel-body">
            <h3>
                <asp:Literal ID="ltTitle" runat="server"></asp:Literal></h3>
            <asp:Literal ID="clientview" runat="server"></asp:Literal>
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">
                        Loại nhiên liệu <span class="append-icon right text-danger">*</span></label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="ddlFuelType" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                            CssClass="form-control input-sm" ValidationGroup="view" OnSelectedIndexChanged="ddlFuelType_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlFuelType"
                            ValidationGroup="view" Text="Vui lòng chọn loại nhiên liệu" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">
                        Nhiên liệu <span class="append-icon right text-danger">*</span></label>
                    <div class="col-lg-4">
                        <asp:DropDownList ID="ddlFuel" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                            ValidationGroup="view" AutoPostBack="true" OnSelectedIndexChanged="ddlFuel_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFuel"
                            ValidationGroup="view" Text="Vui lòng chọn nhiên liệu" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">
                        Đơn vị tính <span class="append-icon right text-danger">*</span></label>
                    <div class="col-lg-4">
                        <asp:DropDownList ID="ddlMeasure" runat="server" AppendDataBoundItems="True" ValidationGroup="view"
                            AutoPostBack="true" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlMeasure_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMeasurement" runat="server" ControlToValidate="ddlMeasure"
                            ValidationGroup="view" Text="Vui lòng chọn đơn vị tính" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">
                        Mức tiêu thụ <span class="append-icon right text-danger">*</span></label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtNoFuel" runat="server" CssClass="form-control input-sm" placeholder="Mức tiêu thụ"
                            ValidationGroup="view"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNoFuel"
                            ValidationGroup="view" Text="Vui lòng nhập Mức tiêu thụ" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">
                        Đơn giá</label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control input-sm" placeholder="Đơn giá"
                            ValidationGroup="view"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPrice"
                            ValidationGroup="view" Text="Vui lòng nhập đơn giá" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">
                        Hệ số chuyển đổi(TOE) <span class="append-icon right text-danger">*</span></label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtNoTOE" runat="server" CssClass="form-control input-sm" placeholder="Hệ số chuyển đổi"
                            ValidationGroup="view"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNoTOE"
                            ValidationGroup="view" Text="Vui lòng nhập hệ số chuyển đổi TOE" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvNoTOE" MaximumValue="10" Type="Double" MinimumValue="0"
                            ControlToValidate="txtNoTOE" ValidationGroup="view" runat="server" Display="Dynamic"></asp:RangeValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">
                        Mục đích sử dụng <span class="append-icon right text-danger">*</span></label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="txtPropose" runat="server" CssClass="form-control input-sm" placeholder="Mục đích sử dụng"
                            ValidationGroup="view"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPropose"
                            ValidationGroup="view" Text="Vui lòng mục đích sử dụng" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-12 text-left">
                        <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại"
                            OnClick="btn_Save_Click" ValidationGroup="view" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
