<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UpdateInfo.ascx.cs" Inherits="Client_Modules_DataEnergy_UpdateInfo" %>
<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.css" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.js"></script>
<div class="row mb10">
    <div class="tab-block mb25">
        <div class="row" runat="server" id="rowTab">
            <div class="col-lg-12">
                <ul class="nav nav-tabs tabs-border" id="DNUpdatetabs">
                    <li><a rel="tabInfo" href="#" class="selected">Thông tin doanh nghiệp</a></li>
                    <li><a rel="tabData" href="#" class="">Thông tin tài khoản</a></li>
                    <li><a rel="tabPass" href="#" class="">Đổi mật khẩu</a></li>
                    <li><a rel="tabImportant" href="#" class="">Năng lượng tiêu thụ</a></li>
                </ul>
            </div>
        </div>
        <div class="tab-content">
            <div id="tabInfo">
                <div class="form-horizontal">
                    <asp:Literal ID="error" runat="server"></asp:Literal>
                    <div class="form-group">
                        <label class="col-lg-2 control-label pt5" for="inputSmall">
                            Tên DN/cơ sở</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtTitle" runat="server" Enabled="false" CssClass="form-control input-sm"
                                MaxLength="255" placeholder="Tên doanh nghiệp/Cơ sở tối đa 200 ký tự" ValidationGroup="vgInfo"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Lĩnh vực<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                                CssClass="form-control input-sm" ValidationGroup="vgInfo" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlArea"
                                Display="Dynamic" ValidationGroup="vgInfo" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Phân ngành<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlSubArea" runat="server" AppendDataBoundItems="True" ValidationGroup="vgInfo"
                                CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="vgInfo"
                                runat="server" ControlToValidate="ddlSubArea" Display="Dynamic" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label pt5" for="inputSmall">
                            Tỉnh/TP <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlProvince" ValidationGroup="vgInfo" runat="server" CssClass="form-control input-sm"
                                Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vgInfo"
                                runat="server" ControlToValidate="ddlProvince" Display="Dynamic" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-2 control-label pt5" for="inputSmall">
                            Quận/Huyện <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDistrict"
                                Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="vgInfo"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Mã số thuế</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtMST" ValidationGroup="vgInfo" runat="server" CssClass="form-control input-sm"
                                MaxLength="50" placeholder="Mã số thuế tối đa 50 ký tự"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMST"
                                Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="vgInfo"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>--%>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall" style="display: none;">
                            Mã khách hàng điện lực</label>
                        <div class="col-lg-4" style="display: none;">
                            <asp:TextBox ID="txtCustomerCode" runat="server" Visible="false" CssClass="form-control input-sm"
                                MaxLength="200" placeholder="Mã khách hàng điện lực tối đa 200 ký tự" ValidationGroup="vgInfo"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Số điện thoại</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-sm" placeholder="Số điện thoại tối đa 50 ký tự"
                                MaxLength="50" ValidationGroup="vgInfo"></asp:TextBox>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Số Fax</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtFax" runat="server" CssClass="form-control input-sm" placeholder="Số Fax tối đa 50 ký tự"
                                MaxLength="50" ValidationGroup="vgInfo"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Email</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtEmail" ValidationGroup="vgInfo" runat="server" CssClass="form-control input-sm"
                                MaxLength="255" placeholder="Email tối đa 255 ký tự"></asp:TextBox>
                            <asp:RegularExpressionValidator ValidationGroup="vgInfo" ID="RegularExpressionValidator1"
                                runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Người chịu trách nhiệm</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtResponsible" runat="server" CssClass="form-control input-sm"
                                MaxLength="255" placeholder="Người chịu trách nhiệm tối đa 255 ký tự" ValidationGroup="vgInfo"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Địa chỉ <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm" placeholder="Địa chỉ tối đa 255 ký tự"
                                MaxLength="255" ValidationGroup="vgInfo"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAddress"
                                Display="Dynamic" ErrorMessage="RequiredFieldValidator" ValidationGroup="vgInfo"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label pt5" for="inputSmall">
                            Chủ sở hữu<span class="text-danger"> *</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlOwner" ValidationGroup="vgInfo" runat="server" CssClass="form-control input-sm">
                                <asp:ListItem Text="Thành phần kinh tế khác" Value="0" Selected="True">
                                </asp:ListItem>
                                <asp:ListItem Text="Doanh nghiệp nhà nước" Value="1">
                                </asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="vgInfo"
                                runat="server" ControlToValidate="ddlOwner" Display="Dynamic" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-lg-2 control-label pt5" for="inputSmall">
                            Chọn mẫu báo cáo<span class="text-danger">*</span></label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlReportTemplate" ValidationGroup="vgInfo" runat="server" CssClass="form-control input-sm">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vgInfo"
                                runat="server" ControlToValidate="ddlReportTemplate" Display="Dynamic" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label pt5" for="inputSmall">
                            Cơ sở đã áp dụng mô hình quản lý năng lượng chưa?</label>
                        <div class="col-lg-5">
                            <div class="form-check">
                                <asp:CheckBox ID="cbMoHinhQLNL_ChuaAD" runat="server" class="form-check-input" />
                                <label class="form-check-label" style="font-weight: normal;" for="cbMoHinhQLNL_ChuaAD">Chưa áp dụng</label>
                            </div>
                            <div class="form-check">
                                <asp:CheckBox ID="cbMoHinhQLNL_DaAD" runat="server" class="form-check-input" />
                                <label class="form-check-label" style="font-weight: normal;" for="cbMoHinhQLNL_DaAD">Đã áp dụng mô hình quản lý năng lượng</label>
                            </div>
                            <div class="form-check">
                                <asp:CheckBox ID="cbMoHinhQLNL_DaAD_ISO" runat="server" class="form-check-input" />
                                <label class="form-check-label" style="font-weight: normal;" for="cbMoHinhQLNL_DaAD_ISO">Đã áp dụng mô hình QLNL theo TCVN:ISO 50001</label>
                            </div>
                        </div>
                    </div>
                    <b>THÔNG TIN CÔNG TY MẸ</b>
                    <hr class="hr-danger" />
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Tên công ty mẹ
                        </label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtParentName" runat="server" CssClass="form-control input-sm" placeholder="Tên công ty mẹ tối đa 255 ký tự"
                                ValidationGroup="vgInfo" MaxLength="255"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Năm hoạt động</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtActiveYear" runat="server" CssClass="form-control input-sm" ValidationGroup="vgInfo" MaxLength="4"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtActiveYear" Type="Integer" MinimumValue="0" MaximumValue="9999"
                                CssClass="text-danger" ValidationGroup="vgInfo" Text="Năm chỉ nhập từ 0 đến 9999"
                                Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Tỉnh/TP</label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlProvinceReporter" runat="server" AppendDataBoundItems="True"
                                CssClass="form-control input-sm" ValidationGroup="vgInfo" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlProvinceReporter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Quận/Huyện</label>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlDistrictReporter" ValidationGroup="vgInfo" runat="server"
                                AppendDataBoundItems="True" CssClass="form-control input-sm">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Địa chỉ</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtAddressReporter" runat="server" CssClass="form-control input-sm"
                                MaxLength="255" placeholder="Địa chỉ tối đa 255 ký tự" ValidationGroup="vgInfo"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Số điện thoại</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtPhoneReporter" runat="server" CssClass="form-control input-sm"
                                MaxLength="50" placeholder="Số điện thoại tối đa 50 ký tự" ValidationGroup="vgInfo"></asp:TextBox>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Fax</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtFaxReporter" runat="server" CssClass="form-control input-sm"
                                MaxLength="50" placeholder="Số Fax tối đa 50 ký tự" ValidationGroup="vgInfo"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Email</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtManEmail" runat="server" CssClass="form-control input-sm" placeholder="Email tối đa 255 ký tự"
                                MaxLength="255" ValidationGroup="vgInfo"></asp:TextBox>
                            <asp:RegularExpressionValidator ValidationGroup="vgInfo" ID="RegularExpressionValidator3"
                                runat="server" ControlToValidate="txtManEmail" ErrorMessage="RegularExpressionValidator"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                <span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i>
                                </span>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Ghi chú</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtNote" runat="server" CssClass="form-control input-sm" ValidationGroup="vgInfo"
                                TextMode="MultiLine" Rows="5"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            &nbsp;</label>
                        <div class="col-lg-10 text-left">
                            <asp:Button runat="server" ID="btn_edit1" ValidationGroup="vgInfo" CssClass="btn btn-sm btn-primary mr10"
                                Text="Lưu lại" OnClick="btn_edit_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="tabData">
                <div class="form-horizontal">
                    <asp:Literal ID="ltInfoErr" runat="server"></asp:Literal>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Tên tài khoản</label>
                        <div class="col-lg-6">
                            <asp:Literal ID="ltrAdminName" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Họ tên người quản trị<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control input-sm" placeholder="Họ tên đầy đủ tối đa 255 ký tự"
                                MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator21" runat="server"
                                ValidationGroup="vgMember" ControlToValidate="txtFullName" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Email</label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtAdminEmail" runat="server" ValidationGroup="vgMember" CssClass="form-control input-sm"
                                placeholder="Email tối đa 255 ký tự" MaxLength="255"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ValidationGroup="vgMember" ID="RegularExpressionValidator2"
                                runat="server" ControlToValidate="txtAdminEmail" ErrorMessage="RegularExpressionValidator"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Điện thoại</label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtPhoneMember" runat="server" CssClass="form-control input-sm"
                                placeholder="Điện thoại tối đa 50 ký tự" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Địa chỉ</label>
                        <div class="col-lg-10">
                            <asp:TextBox ID="txtAddressMember" runat="server" CssClass="form-control input-sm"
                                placeholder="Địa chỉ tối đa 255 ký tự" MaxLength="255"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            &nbsp;</label>
                        <div class="col-lg-10 text-left">
                            <asp:Button runat="server" ID="btnUpdateInfo" ValidationGroup="vgMember" CssClass="btn btn-sm btn-primary mr10"
                                Text="Lưu lại" OnClick="btnUpdateInfo_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="tabImportant">
                <p>
                    <asp:Literal ID="ltrTotalImportant" runat="server"></asp:Literal>
                </p>
                <div class="table-responsive mb20">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tr class="primary fs12">
                            <th style="width: 5%" class="text-center">STT
                            </th>
                            <th style="width: 10%" class="text-center">Năm
                            </th>
                            <th>TOE
                            </th>
                        </tr>
                        <asp:Repeater ID="rptImportantYear" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1  %>
                                    </td>
                                    <td class="text-center">
                                        <%#Eval("Year")%>
                                    </td>
                                    <td>
                                        <%#Eval("No_TOE")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
            <div id="tabPass">
                <div class="form-horizontal">
                    <asp:Literal ID="ltErrPass" runat="server"></asp:Literal>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Tên tài khoản</label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtAdminName" Enabled="false" runat="server" CssClass="form-control input-sm"
                                MaxLength="255"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Mật khẩu cũ</label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtOldPass" runat="server" CssClass="form-control input-sm"
                                MaxLength="30" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Mật khẩu mới</label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtAdminPass" runat="server" CssClass="form-control input-sm" ValidationGroup="vgUpdate"
                                MaxLength="30" placeholder="Mật khẩu mới tối đa 30" TextMode="Password"></asp:TextBox><asp:CompareValidator
                                    ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToCompare="txtAdminPass"
                                    ControlToValidate="Re_Pass"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="vgUpdate"
                                runat="server" ControlToValidate="txtAdminPass" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtAdminPass"
                                CssClass="text-danger" ValidationGroup="vgUpdate" Text="Mật khẩu phải chứa ít nhất từ 6 đến 30 ký tự, bao gồm ít nhất 1 ký tự viết hoa, it nhất 1 ký tự số, 1 ký tự đặc biệt."
                                ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,30}$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            Nhập lại mật khẩu</label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="Re_Pass" runat="server" CssClass="form-control input-sm" ValidationGroup="vgUpdate"
                                MaxLength="30" placeholder="Nhập lại mật khẩu tối đa 30" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="vgUpdate"
                                runat="server" ControlToValidate="Re_Pass" ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" ValidationGroup="vgUpdate" runat="server"
                                ControlToCompare="txtAdminPass" ControlToValidate="Re_Pass" ErrorMessage="CompareValidator"><span class="append-icon right text-danger">Mật khẩu chưa khớp</span></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">
                            &nbsp;</label>
                        <div class="col-lg-10 text-left">
                            <asp:Button runat="server" ID="btnUpdateAccount" ValidationGroup="vgUpdate" CssClass="btn btn-sm btn-primary mr10"
                                Text="Lưu lại" OnClick="btnUpdateAccount_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    var tabReport = new ddtabcontent("DNUpdatetabs");
    tabReport.setpersist(true);
    tabReport.setselectedClassTarget("link");
    tabReport.currentTabIndex = 0;
    tabReport.init();

    //checkbox cbMoHinhQLNL
    var cbMoHinhQLNL_ChuaAD = $('#<%=cbMoHinhQLNL_ChuaAD.ClientID%>');
    var cbMoHinhQLNL_DaAD = $('#<%=cbMoHinhQLNL_DaAD.ClientID%>');
    var cbMoHinhQLNL_DaAD_ISO = $('#<%=cbMoHinhQLNL_DaAD_ISO.ClientID%>');

    function cbMoHinhQLNL_CheckedChange(obj) {
        if ($(obj).is(":checked")) {
            if ($(obj).attr('id') != $(cbMoHinhQLNL_ChuaAD).attr('id'))
                $(cbMoHinhQLNL_ChuaAD).prop('checked', false);

            if ($(obj).attr('id') != $(cbMoHinhQLNL_DaAD).attr('id'))
                $(cbMoHinhQLNL_DaAD).prop('checked', false);

            if ($(obj).attr('id') != $(cbMoHinhQLNL_DaAD_ISO).attr('id'))
                $(cbMoHinhQLNL_DaAD_ISO).prop('checked', false);
        }
    }
    $(cbMoHinhQLNL_ChuaAD).change(function () {
        cbMoHinhQLNL_CheckedChange($(this));
    });

    $(cbMoHinhQLNL_DaAD).change(function () {
        cbMoHinhQLNL_CheckedChange($(this));
    });

    $(cbMoHinhQLNL_DaAD_ISO).change(function () {
        cbMoHinhQLNL_CheckedChange($(this));
    });


</script>
