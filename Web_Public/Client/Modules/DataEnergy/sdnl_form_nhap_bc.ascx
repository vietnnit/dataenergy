<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sdnl_form_nhap_bc.ascx.cs" Inherits="Client_Modules_DataEnergy_sdnl_form_nhap_bc" %>
<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.css" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.js"></script>
<asp:ScriptManager ID="clientScript" runat="server"></asp:ScriptManager>
<asp:HiddenField ID="hdnNewsUrl" Value="" runat="server" />
<asp:HiddenField ID="hdnReport" Value="" runat="server" />
<asp:HiddenField ID="hdnNextYear" Value="" runat="server" />


<div class="row mb10">
    <div class="tab-block mb25">
        <div class="panel panel-blue" style="margin-bottom: 0;">
            <div class="panel-heading">
                <h3 class="panel-title">
                    <span>CẬP NHẬT BÁO CÁO SỬ DỤNG NĂNG LƯỢNG HÀNG NĂM</span>
                </h3>
            </div>
        </div>
        <div class="form-horizontal">
            <div class="form-group">
                <div class="col-lg-12">
                    <div class="control-label pt5" style="width: 100%">
                        <asp:Literal ID="ltDataCurrentTitle" runat="server"></asp:Literal><div style="float: right">
                            <asp:LinkButton ID="btnAddFuel" runat="server" Text="Thêm nhiên liệu" data-toggle="modal"
                                data-target="#dlgFuelConsume" ToolTip="Thêm báo cáo" OnClientClick='javascript:addReportDetail(0); return 0;'><i class="fa fa-plus"></i>&nbsp;Thêm loại năng lượng</asp:LinkButton>
                        </div>
                    </div>
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tr class="primary fs12">
                            <th style="width: 5%">STT
                            </th>
                            <th style="width: 15%">Loại năng lượng
                            </th>
                            <th style="width: 10%">Mức tiêu thụ
                            </th>
                            <th style="width: 10%">Đơn vị tính
                            </th>
                            <th style="width: 10%">Giá (đồng)
                            </th>
                            <%--<th style="width: 10%">
                                                    Hệ số TOE
                                                </th>--%>
                            <th style="width: 10%">Năng lượng tiêu thụ (TOE)
                            </th>
                            <th style="width: 30%">Mục đích sử dụng
                            </th>
                            <th style="width: 10%">Thao tác
                            </th>
                        </tr>
                        <asp:Repeater ID="rptNoFuelCurrent" runat="server" OnItemDataBound="rptNoFuelCurrent_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Container.ItemIndex+1  %>
                                    </td>
                                    <td>
                                        <%#Eval("FuelName") %>
                                    </td>
                                    <td style="text-align: right">
                                        <%#Eval("NoFuel") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NoFuel"),2) : ""%>
                                    </td>
                                    <td>
                                        <%#Eval("MeasurementName")%>
                                    </td>
                                    <td style="text-align: right">
                                        <%#Eval("Price") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Price"),0) : ""%>
                                    </td>
                                    <td style="text-align: right">
                                        <%#Eval("NoFuel_TOE") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("NoFuel_TOE"),2) : ""%>
                                        <asp:HiddenField ID="hdDenotation" runat="server" Value='<%#Eval("Denotation")%>' />
                                    </td>
                                    <td>
                                        <%#Eval("Reason")%>
                                    </td>
                                    <td style="text-align: center">
                                        <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandArgument='<%#Eval("Id") %>'
                                            CssClass="fa fa-times" ToolTip="Xóa" OnClientClick="return javascript:confirm('Bạn chắc chắn muốn xóa không');"></asp:LinkButton>
                                        <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEditDetail_Click" CssClass="fa fa-edit"
                                            ToolTip="Sửa" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div style="text-align: right">
                        <b>
                            <asp:Literal ID="ltTotal_TOE" runat="server"></asp:Literal></b>
                    </div>
                    <%--<asp:LinkButton ID="btnAddFuel" runat="server" Text="Thêm nhiên liệu" CssClass="btn btn-sm btn-primary mr10"></asp:LinkButton>--%>
                </div>
            </div>
            <asp:Literal ID="error" runat="server"></asp:Literal>
        </div>
        <div class="row">
            <div class="col-lg-12 text-left">
                <asp:LinkButton runat="server" ID="btnExportWord" OnClick="btnExportWord_Click" CssClass="btn btn-sm btn-success mr10"><i class="fa fa-file-word-o"></i>&nbsp;Xuất báo cáo</asp:LinkButton>
                <asp:LinkButton runat="server" ID="btnSend" CssClass="btn btn-sm btn-danger mr10"
                            OnClientClick="ShowDialogSend();return false;" data-toggle="modal" data-target="#dlgSend"
                            Text="Hoàn thành lập và Gửi báo cáo"  ValidationGroup="view"><i class="fa fa-send-o"></i>&nbsp;Hoàn thành lập và Gửi báo cáo</asp:LinkButton>
                 <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/dn-su-dung-nang-luong.aspx" CssClass="btn btn-sm btn-primary mr10"
                            Text="Danh sách" />
            </div>
        </div>
    </div>
</div>

<div class="modal fade" tabindex="-1" role="dialog" id="dlgFuelConsume">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    <asp:Literal ID="ltTitle" runat="server" Text="Tình hình sử dụng nhiên liệu"></asp:Literal>
                </h4>
            </div>
            <div class="modal-body">
                <h3>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></h3>
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Loại nhiên liệu <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:DropDownList ID="ddlFuel" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                                ValidationGroup="viewFuelOne" AutoPostBack="true" OnSelectedIndexChanged="ddlFuel_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlFuel"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng chọn nhiên liệu"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Đơn vị tính <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="updateMearse" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlFuel" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlMeasure" runat="server" AppendDataBoundItems="True" ValidationGroup="viewFuelOne"
                                        AutoPostBack="true" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlMeasure_SelectedIndexChanged">
                                    </asp:DropDownList>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:RequiredFieldValidator ID="rfvMeasurement" runat="server" ControlToValidate="ddlMeasure"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng chọn đơn vị tính"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <%--</div>
                    <div class="form-group">--%>
                        <label class="col-lg-3" for="inputSmall">
                            Lượng tiêu thụ<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlFuel" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox ID="txtNoFuel" runat="server" CssClass="form-control input-sm" ValidationGroup="viewFuelOne"
                                        MaxLength="20" placeholder="Lượng tiêu thụ tối đa 20 ký tự"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtNoFuel"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng nhập Lượng tiêu thụ"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RangeValidator1" runat="server" ControlToValidate="txtNoFuel"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Lượng tiêu thụ chỉ nhập số"
                                ValidationExpression="^[0-9]{1,18}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3" for="inputSmall">
                            Đơn giá(<i>đồng</i>)</label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlFuel" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control input-sm" placeholder="Nhập tối đa 15 ký tự"
                                        MaxLength="15" ValidationGroup="viewFuelOne"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrice"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Đơn giá nhập số và từ 0 đến 9.999.999.999.999,99"
                                ValidationExpression="^[0-9]{1,13}(\,[0-9]{1,2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <label class="col-lg-3" for="inputSmall">
                            Hệ số chuyển đổi(TOE)<span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlFuel" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox ID="txtNoTOE" runat="server" CssClass="form-control input-sm" ValidationGroup="viewFuelOne"></asp:TextBox>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtNoTOE"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng nhập hệ số chuyển đổi TOE"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvNoTOE" MaximumValue="10" Type="Double" MinimumValue="0"
                                CssClass="text-danger" ControlToValidate="txtNoTOE" ValidationGroup="viewFuelOne"
                                runat="server" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-3">
                            Mục đích sử dụng <span class="append-icon right text-danger">*</span></label>
                        <div class="col-lg-9">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlFuel" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:TextBox ID="txtPropose" runat="server" CssClass="form-control input-sm" ValidationGroup="viewFuelOne"
                                        MaxLength="255" placeholder="Mục đích sử dụng tối đa 255 ký tự"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPropose"
                                CssClass="text-danger" ValidationGroup="viewFuelOne" Text="Vui lòng mục đích sử dụng"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button runat="server" ID="btnSaveFuel" CssClass="btn btn-sm btn-primary mr10"
                    Text="Lưu lại" OnClick="btnSaveFuel_Click" ValidationGroup="viewFuelOne" />
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgSend">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Gửi báo cáo</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-3">
                            File báo cáo hàng năm
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9">
                            <asp:FileUpload runat="server" ID="fAttach"></asp:FileUpload>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="fAttach"
                                CssClass="text-danger" ValidationGroup="vgSend" Text="Vui lòng chọn file báo cáo hàng năm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" style="display:none;">
                        <div class="col-lg-3">
                            File báo cáo 5 năm
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9">
                            <asp:FileUpload runat="server" ID="fAttach5year"></asp:FileUpload>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="fAttach5year"
                                CssClass="text-danger" ValidationGroup="vgSend" Text="Vui lòng chọn file báo cáo 5 năm"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3">
                            Nội dung ý kiến <span class="append-icon right text-danger">*</span>
                        </div>
                        <div class="col-lg-9 col-md-9 col-sm-9">
                            <asp:TextBox runat="server" class="form-control" ID="txtContent" TextMode="MultiLine"
                                MaxLength="500" ValidationGroup="vgSend" Rows="3" placeholder="Mục đích sử dụng tối đa 500 ký tự"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtContent"
                                CssClass="text-danger" ValidationGroup="vgSend" Text="Vui lòng nhập nội dung ý kiến"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="btnSaveSend" runat="server" Visible="true" OnClick="btnSend_Click"
                         Text="Gửi" CssClass="btn-u btn-u-primary mr10"></asp:LinkButton>
                    <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                        Hủy</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</div>
<asp:Literal ID="clientview" runat="server"></asp:Literal>



<div style="display: none;">
    <asp:UpdatePanel ID="update_hdnDetailId" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlFuel" EventName="SelectedIndexChanged" />
        </Triggers>
        <ContentTemplate>
            <asp:HiddenField ID="hdnDetailId" Value="" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>

<script type="text/javascript">
    function updateReportDetail(isnext) {
        $('#dlgFuelConsume').modal('toggle');
    }

    function addReportDetail(isnext) {
        dlgFuelConsume_Init(isnext);
    }

    $("#dlgFuelConsume").on('hide.bs.modal', function () {
        $("#<%=ddlFuel.ClientID%>#elem").prop('selectedIndex', 0);
        $("#<%=hdnNextYear.ClientID%>").val(0);
        //$("#<%=ddlFuel.ClientID%>").selectedIndex = 0; //         
        $("#<%=ddlMeasure.ClientID%>").selectedIndex = 0;
        $("#<%=txtNoFuel.ClientID%>").val('');
        $("#<%=txtPrice.ClientID%>").val('');
        $("#<%=txtPropose.ClientID%>").val('');
    });

    function dlgFuelConsume_Init(isnext) {
        $("#<%=ddlFuel.ClientID%>#elem").prop('selectedIndex', 0);
        $("#<%=hdnNextYear.ClientID%>").val(0);
        //$("#<%=ddlFuel.ClientID%>").selectedIndex = 0; //         
        $("#<%=ddlMeasure.ClientID%>").selectedIndex = 0;
        $("#<%=txtNoFuel.ClientID%>").val('');
        $("#<%=txtPrice.ClientID%>").val('');
        $("#<%=txtPropose.ClientID%>").val('');
    }

</script>


