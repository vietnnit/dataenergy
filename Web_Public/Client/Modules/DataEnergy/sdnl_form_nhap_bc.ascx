<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sdnl_form_nhap_bc.ascx.cs" Inherits="Client_Modules_DataEnergy_sdnl_form_nhap_bc" %>
<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.css" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.js"></script>
<script type="text/javascript">

    function TOEChanged(obj) {
        if ($(obj).val() == '' || $(obj).val() == '') {
            $(obj).closest('td').next().children('label:first-child').html('');
        }
        else {
            var toe = $(obj).attr('TOEattr').replace(',', '.');
            var fuelused = $(obj).val().replace(',', '.');
            var toeValue = toe * fuelused;
            $(obj).closest('td').next().children('label:first-child').html(toeValue);
        }
        GetAllTOE();
    }

    function GetAllTOE() {
        var TotalTOE = 0;
        $('#tableTOE input').each(function () {
            if ($(this).val() != '') {
                var toe = $(this).attr('TOEattr').replace(',', '.');
                var fuelused = $(this).val().replace(',', '.');
                var toeValue = toe * fuelused;
                TotalTOE += toeValue;
            }
        });

        if (TotalTOE == 0)
            $('#lbTongNLTTQuyDoiTOE').html('');
        else
            $('#lbTongNLTTQuyDoiTOE').html(TotalTOE);
    }

    /*
     * id='id_fuelId_measurementId_toe':id_dn-fuelId-measurementId
        FuelId = 0;
        MeasurementId = 0;
        TOE = 0;
        NangLuongQuyDoi
     */
    function GetData() {
        var ArrData = new Array();
        $('#tableTOE input').each(function () {
            var _tmpMucTieuThu = $(this).val().toString().replace(',', '.');
            console.log(_tmpMucTieuThu);
            var _MucTieuThu = _tmpMucTieuThu != '' ? $(this).val() : 0;
            console.log(_MucTieuThu);
            var fuelused = _MucTieuThu.toString().replace(',', '.');
            var toe = $(this).attr('TOEattr').replace(',', '.');
            var _NangLuongQuyDoi = toe * fuelused;
            console.log(_NangLuongQuyDoi);
            var arr = $(this).attr('id').split('_');
            var obj = { 'FuelId': arr[1], 'MeasurementId': arr[2], 'TOE': arr[3].replace(',', '.'), 'MucTieuThu': _MucTieuThu, 'NangLuongQuyDoi': _NangLuongQuyDoi };
            ArrData.push(obj);
        });

        $('#<%=ltDuLieuNhap.ClientID%>').val(JSON.stringify(ArrData));
    }
    function SaveData() {
        GetData();
        $('#<%=btLuu.ClientID%>').click();
    }
    function SaveAndSendData() {
        GetData();
        $('#<%=btnSendReport.ClientID%>').click();
    }

</script>

<div align="center" style="margin-bottom: 20px;">
    <table style="width: 100%">
        <tr>
            <td style="font-weight: bold;">Năm báo cáo:
            <asp:DropDownList ID="ddlNamBaoCao" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNamBaoCao_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
    </table>
</div>
<div class="row mb10">
    <div class="tab-block mb25">
        <div class="row" runat="server" id="rowTab">
            <div class="col-lg-12">
                <ul class="nav nav-tabs tabs-border" id="DNUpdatetabs">
                    <li><a rel="tabInfo" href="#" class="selected">THÔNG TIN BÁO CÁO</a></li>
                    <li><a rel="tabComment" href="#" class="">Ý KIẾN, PHẢN HỒI PHÊ DUYỆT</a></li>
                </ul>
            </div>
        </div>
        <div class="tab-content">
            <div id="tabInfo">
                <div class="form-horizontal">
                    <asp:Literal ID="ltReport" runat="server"></asp:Literal>
                </div>
            </div>

            <div id="tabComment">
                <table class="table table-bordered table-hover mbn" width="100%">
                    <tr class="primary fs12">
                        <th style="width: 10%" class="text-center">Người cập nhật
                        </th>
                        <th>Nội dung
                        </th>
                        <th style="width: 15%" class="text-center">Thời gian
                        </th>
                    </tr>
                    <asp:Repeater ID="rptComment" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="text-center">
                                    <%#Eval("TaiKhoan")%>
                                </td>
                                <td>
                                    <%#Eval("NoiDung")%>
                                </td>
                                <td class="text-center">
                                    <%# Eval("ThoiGian","{0:dd/MM/yyyy HH:mm}")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnAction" runat="server">
        <div align="center" style="margin-top: 20px;">
            <a href="javascript:SaveData();" class="btn btn-primary"><i class="fa fa-save"></i>&nbsp;Lưu lại</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <a href="javascript:ShowDialogInitReport();" class="btn btn-danger"><i class="fa fa-send"></i>&nbsp;Hoàn thành lập và Gửi báo cáo</a>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnNoneAction" runat="server" Visible="false">
        <div align="center" style="margin-top: 20px;">
            <asp:LinkButton ID="btnQuayLai" runat="server" CssClass="btn btn-danger btn-sm" OnClick="btnQuayLai_Click"><i class="fa fa-send"></i>&nbsp;Quay lại</asp:LinkButton>
        </div>
    </asp:Panel>
</div>


<div id="hiddenCalatedData" style="display: none;">
    <asp:HiddenField ID="ltDuLieuNhap" runat="server"></asp:HiddenField>
    <asp:Button ID="btLuu" runat="server" OnClick="btLuu_Click" />
</div>

<div class="modal fade" tabindex="-1" role="dialog" id="dlgSendReport">
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
                        <label for="comment">Nội dung ý kiến:</label>
                        <asp:TextBox ID="txtNoiDungYKien" placeholder="Mục đích sử dụng tối đa 500 ký tự" MaxLength="500" runat="server" TextMode="MultiLine" Rows="5" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="javascript:SaveAndSendData();" class="btn-u btn-u-primary"><i class="fa fa-save"></i>&nbsp;Gửi</a>&nbsp;&nbsp;&nbsp;
                            <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                                Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<div style="display: none;">
    <asp:Button ID="btnSendReport" OnClick="btnSendReport_Click" runat="server" />
    <asp:HiddenField ID="hdReportId" runat="server" />
</div>
<style type="text/css">
    .modal-dialog {
        z-index: 9999 !important;
    }
</style>
<script type="text/javascript"> 
    function ShowDialogInitReport() { $('#dlgSendReport').modal('toggle'); }
</script>
<script type="text/javascript">
    var tabReport = new ddtabcontent("DNUpdatetabs");
    //tabReport.setpersist(true);
    //tabReport.setselectedClassTarget("link");
    tabReport.currentTabIndex = 0;
    tabReport.init();
</script>
