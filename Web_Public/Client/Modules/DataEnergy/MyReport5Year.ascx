<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyReport5Year.ascx.cs" Inherits="Client_Modules_DataEnergy_MyReport5Year" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<div class="row box-white mb10 pl10 pr10 pb10">
    <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
    <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
    <div class="panel panel-blue" style="margin-bottom: 0;">
        <div class="panel-heading">
            <h3 class="panel-title">
                <span>KẾ HOẠCH SỬ DỤNG NĂNG LƯỢNG 5 NĂM</span>
            </h3>
        </div>
    </div>
    <div class="control-label pt5" style="width: 100%">
        <i class="fa fa-tasks"></i>&nbsp;Báo cáo đang duyệt và chưa gửi<div style="float: right">
            <a title="Thêm báo cáo" href='javascript:ShowDialogInitReport();'><i class="fa fa-plus"></i>&nbsp;Thêm báo cáo</a>
        </div>
    </div>
    <table class="table table-bordered table-hover mb10">
        <thead>
            <tr class="primary fs12 text-center">
                <th style="width: 5%" class="text-center">STT
                </th>
                <th style="width: 10%" class="text-center">Kỳ kế hoạch
                </th>
                <th style="width: 10%" class="text-center">Ngày lập báo cáo
                </th>
                <th style="width: 10%" class="text-center">Ngày gửi báo cáo
                </th>
                <th style="width: 10%" class="text-center">Ngày nhận báo cáo
                </th>
                <th style="width: 20%" class="text-center">Người lập BC
                </th>
                <th style="width: 10%" class="text-center">Trạng thái
                </th>
                <th style="width: 10%" class="text-center">Thao tác
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptReport" runat="server" OnItemDataBound="rptReport_ItemDataBound"
                OnItemCommand="rptReport_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Container.ItemIndex+1  %>
                        </td>
                        <td>
                            <a href='<%#ResolveUrl("~") %>bao-cao-so-lieu-5-nam-<%#Eval("Id")%>.aspx'>
                                <%#Eval("Year") %> - <%#((int)Eval("Year") + 4) %>
                            </a>
                        </td>
                        <td>
                            <%#Eval("ReportDate") != null && Convert.ToDateTime(Eval("ReportDate")).Year>1?Convert.ToDateTime(Eval("ReportDate")).ToString("dd/MM/yyyy"):""%>
                        </td>
                        <td>
                            <%#Eval("SendDate") != DBNull.Value && Convert.ToDateTime(Eval("SendDate")).Year > 1 ? Convert.ToDateTime(Eval("SendDate")).ToString("dd/MM/yyyy") : ""%>
                        </td>
                        <td>
                            <%#Eval("ReceivedDate") != DBNull.Value && Convert.ToDateTime(Eval("ReceivedDate")).Year > 1 ? Convert.ToDateTime(Eval("ReceivedDate")).ToString("dd/MM/yyyy") : ""%>
                        </td>
                        <td>
                            <%#Eval("ReporterName")%>
                        </td>
                        <td>
                            <%#Tool.TrangThaiGui(Convert.ToInt32(Eval("SendSatus")), Convert.ToBoolean(Eval("ApprovedSatus")))%>
                        </td>
                        <td class="text-center">
                            <asp:Literal ID="ltEdit" runat="server"></asp:Literal>
                            <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" CommandName="Delete"
                                CommandArgument='<%#Eval("Id") %>' CssClass="" ToolTip="Xóa" OnClientClick="javascript:return confirm('Bạn có muốn chắc chắn xóa ???');"><i class="fa fa-trash-o"></i></asp:LinkButton>
                            <%--<asp:LinkButton runat="server" ID="LinkButton1" CommandName="WordComment" CommandArgument='<%#Eval("Id") %>'
                                CssClass="" data-toggle="modal" data-target="#myModal" ToolTip="Xuất mẫu báo cáo"
                                OnClientClick='<%# String.Format("javascript:voidexcel({0}); return 0;", Eval("Id").ToString()) %>'> <i class="fa  fa-file-word-o"></i></asp:LinkButton>--%>
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
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <div class="control-label pt5" style="width: 100%" for="inputSmall">
        <i class="fa fa-tasks"></i>&nbsp;Báo cáo đã được duyệt
    </div>
    <table class="table table-bordered table-hover mb10">
        <thead>
            <tr class="primary fs12 text-center">
                <th style="width: 5%" class="text-center">STT
                </th>
                <th style="width: 10%" class="text-center">Kế hoạch năm
                </th>
                <th style="width: 10%" class="text-center">Ngày báo cáo
                </th>
                <th style="width: 10%" class="text-center">Ngày xác nhận
                </th>
                <th style="width: 10%" class="text-center">Ngày nhận báo cáo
                </th>
                <th style="width: 10%" class="text-center">Người lập BC
                </th>
                <th style="width: 10%" class="text-center">Thao tác
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptApproved" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Container.ItemIndex+1  %>
                        </td>
                        <td>
                            <a href='<%#ResolveUrl("~") %>bao-cao-so-lieu-5-nam-<%#Eval("Id")%>.aspx'>
                                <%#Eval("Year") %>
                            </a>
                        </td>
                        <td>
                            <%#Eval("ReportDate") != null && Convert.ToDateTime(Eval("ReportDate")).Year>1?Convert.ToDateTime(Eval("ReportDate")).ToString("dd/MM/yyyy"):""%>
                        </td>
                        <td>
                            <%#Eval("ConfirmedDate") != DBNull.Value && Convert.ToDateTime(Eval("ConfirmedDate")).Year > 1 ? Convert.ToDateTime(Eval("ConfirmedDate")).ToString("dd/MM/yyyy") : ""%>
                        </td>
                        <td>
                            <%#Eval("ReceivedDate") != DBNull.Value && Convert.ToDateTime(Eval("ReceivedDate")).Year > 1 ? Convert.ToDateTime(Eval("ReceivedDate")).ToString("dd/MM/yyyy") : ""%>
                        </td>
                        <td>
                            <%#Eval("ReporterName")%>
                        </td>
                        <td class="text-center">
                            <a href='<%#ResolveUrl("~") %>bao-cao-so-lieu-5-nam-<%#Eval("Id") %>.aspx'><i
                                class='fa fa-search'></i></a>
                            <%--<asp:LinkButton runat="server" ID="LinkButton1" CommandName="WordComment" CommandArgument='<%#Eval("Id") %>'
                                CssClass="" data-toggle="modal" data-target="#myModal" ToolTip="Xuất mẫu báo cáo"
                                OnClientClick='<%# String.Format("javascript:voidexcel({0}); return 0;", Eval("Id").ToString()) %>'> <i class="fa  fa-file-word-o"></i></asp:LinkButton>--%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <div class="ro m3">
        <div class="box-pages">
            <uc1:PagingControl ID="PagingApproved" OnPaging_Click="PagingApp_Click" runat="server"
                FirstString="<%$ Resources:Resource, T_Top %>" LastString="<%$ Resources:Resource, T_Last %>"
                NextString="<%$ Resources:Resource, T_Next %>" PrevString="<%$ Resources:Resource, T_Back %>" />
        </div>
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="dlgReport">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Khởi tạo báo cáo tình hình sử dụng năng lượng hàng năm</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:Literal ID="ltErr" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3">
                            Kế hoạch năm
                        </div>
                        <div class="select col-lg-3">
                            <asp:DropDownList runat="server" ID="ddlYear">
                            </asp:DropDownList>
                            <i></i>
                        </div>
                        <div class="col-lg-6">
                            <asp:LinkButton ID="btnAddReport" runat="server" Visible="true" OnClick="btnAddReport_Click"
                                Text="Khởi tạo" CssClass="btn-u btn-u-primary mr10"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>

<asp:HiddenField ID="hddma" runat="server" />
<!-- /.modal -->
<script type="text/javascript"> 
    function ShowDialogInitReport() { $('#dlgReport').modal('toggle'); }
</script>
