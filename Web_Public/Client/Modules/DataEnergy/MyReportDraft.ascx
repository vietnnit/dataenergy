<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyReportDraft.ascx.cs"
    Inherits="Client_Modules_DataEnergy_MyReportDraft" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<div class="row box-white mb10 pl10 pr10 pb10">
    <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
    <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
    <table class="table table-bordered table-hover mb10">
        <thead>
            <tr class="primary fs12 text-center">
                <th style="width: 5%" class="text-center">
                    STT
                </th>
                <th>
                    Báo cáo năm
                </th>
                <th style="width: 10%" class="text-center">
                    Ngày lập báo cáo
                </th>
                <th style="width: 10%" class="text-center">
                    Ngày xác nhận
                </th>
                <th style="width: 10%" class="text-center">
                    Ngày gửi báo cáo
                </th>
                <th style="width: 10%" class="text-center">
                    Người lập BC
                </th>
                <th style="width: 15%" class="text-center">
                    Thời gian cập nhật
                </th>
                <th style="width: 10%" class="text-center">
                    Trạng thái
                </th>
                <th style="width: 14%" class="text-center">
                    Thao tác
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptNoFuelCurrent" runat="server" OnItemDataBound="rptNoFuelCurrent_ItemDataBound"
                OnItemCommand="rptComments_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Container.ItemIndex+1  %>
                        </td>
                        <td>
                            <a href='<%#ResolveUrl("~") %>bao-cao-so-lieu-hang-nam.aspx?Id=<%#Eval("Id")%>'>
                                <%#Eval("Year") %>
                            </a>
                        </td>
                        <td>
                            <%#Eval("ReportDate") != null && Convert.ToDateTime(Eval("ReportDate")).Year>1?Convert.ToDateTime(Eval("ReportDate")).ToString("dd/MM/yyyy"):""%>
                        </td>
                        <td>
                            <%#Eval("ConfirmedDate") != DBNull.Value && Convert.ToDateTime(Eval("ConfirmedDate")).Year > 1 ? Convert.ToDateTime(Eval("AprovedDate")).ToString("dd/MM/yyyy") : ""%>
                        </td>
                        <td>
                            <%#Eval("ReceivedDate") != DBNull.Value && Convert.ToDateTime(Eval("ReceivedDate")).Year > 1 ? Convert.ToDateTime(Eval("ReceivedDate")).ToString("dd/MM/yyyy") : ""%>
                        </td>
                        <td>
                            <%#Eval("ReporterName")%>
                        </td>
                        <td>
                            <%#Eval("Modified") != DBNull.Value && Convert.ToDateTime(Eval("Modified")).Year > 1 ? Convert.ToDateTime(Eval("Modified")).ToString("dd/MM/yyyy hh:MM") : ""%>
                        </td>
                        <td>
                            <%--<%#Tool.TrangThaiGui(Convert.ToInt32(Eval("SendSatus")))%>--%>
                        </td>
                        <td class="text-center">
                            <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandName="Delete"
                                CommandArgument='<%#Eval("Id") %>' CssClass="btn btn-danger btn-xs fs14" ToolTip="Xóa"
                                OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa ???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
                            <asp:Literal ID="ltEdit" runat="server"></asp:Literal>
                            <asp:LinkButton runat="server" ID="LinkButton1" runat="server" CommandName="WordComment"
                                CommandArgument='<%#Eval("Id") %>' CssClass="btn btn-primary btn-xs fs14" data-toggle="modal"
                                data-target="#myModal" ToolTip="Xuất mẫu báo cáo" OnClientClick='<%# String.Format("javascript:voidexcel({0}); return 0;", Eval("Id").ToString()) %>'> <i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <div class="ro m3">
        <div class="box-pages">
            <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="<%$ Resources:Resource, T_Top %>"
                LastString="<%$ Resources:Resource, T_Last %>" NextString="<%$ Resources:Resource, T_Next %>"
                PrevString="<%$ Resources:Resource, T_Back %>" />
        </div>
    </div>
    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/bao-cao-so-lieu-hang-nam.aspx"
        CssClass="btn btn-sm btn-primary mr10" Text="Thêm báo cáo" ValidationGroup="view" />
    <asp:LinkButton ID="btnAdd" runat="server" Visible="false" Text="Thêm báo cáo" CssClass="btn btn-sm btn-primary mr10"></asp:LinkButton>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Lựa chọn mẫu báo cáo</h4>
            </div>
            <div class="modal-body">
                <section class="mbn">
                    <label class="select">
                    <asp:DropDownList runat="server" ID="drpmaubaocao">
                        <asp:ListItem Value="1" Text="Dùng cho cơ sở hoạt động trong lĩnh vự sản xuất công nghiệp" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Dùng cho cơ sở sản xuất điện"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Dùng cho tòa nhà đặt trụ sở, văn phòng làm việc"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Dùng cho các trường học; bệnh viện; khu vui chơi, giải trí; thể dục, thể thao"></asp:ListItem>
                        <asp:ListItem Value="5" Text="Dùng cho các khách sạn, nhà hàng"></asp:ListItem>
                        <asp:ListItem Value="6" Text="Dùng cho tòa nhà siêu thị, cửa hàng"></asp:ListItem>
                        <asp:ListItem Value="7" Text="Dùng cho cơ sở là cơ quan, đơn vị sử dụng ngân sách nhà nước"></asp:ListItem>
                        <asp:ListItem Value="8" Text="Dùng cho các cơ sở hoạt động trong lĩnh vực Giao thông vận tải"></asp:ListItem>
                        <asp:ListItem Value="9" Text="Dùng cho các cơ sở chế biến, gia công sản phẩm trong nông nghiệp"></asp:ListItem>
                        <asp:ListItem Value="10" Text="Dùng cho các cơ sở đánh bắt thủy, hải sản; máy móc phục vụ sản xuất nông nghiệp"></asp:ListItem>
                        <asp:ListItem Value="11" Text="Dùng cho cơ sở thủy lợi phục vụ sản xuất nông nghiệp"></asp:ListItem>
                    </asp:DropDownList>
                    <i></i>
                    </label>
                </section>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                    Đóng</button>
                <asp:LinkButton ID="btnExport" runat="server" Visible="true" OnClick="btnExcel_DirectClick"
                    Text="Xuất báo cáo" CssClass="btn-u btn-u-primary mr10"></asp:LinkButton>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<asp:HiddenField ID="hddma" runat="server" />
<!-- /.modal -->
<script type="text/javascript">
    function SelectUrl(RepportId, isNext) {
        var _url = '<%=ResolveUrl("~")%>' + "Client/Admin/DataEngery/Default.aspx?ReportId=" + RepportId + "&isnext=" + isNext;
        return window.open(_url, 'mydoc', 'scrollbars=yes,resizable=no,locationbar=no,width=800,height=350,left='.concat((screen.width - 800) / 2).concat(',top=').concat((screen.height - 350) / 2));
    }
    function UpdateFuel(FuelId, isNext) {
        var _url = '<%=ResolveUrl("~")%>' + "Client/Admin/DataEngery/Default.aspx?FuelId=" + FuelId + "&isnext=" + isNext;
        return window.open(_url, 'newW', 'scrollbars=yes,resizable=no,locationbar=no,width=800,height=350,left='.concat((screen.width - 800) / 2).concat(',top=').concat((screen.height - 350) / 2));
    }
    function voidexcel(id) {
        $("#<%=hddma.ClientID%>").val(id);

        $('#myModal').on('shown.bs.modal', function () {

        });
    }

</script>
