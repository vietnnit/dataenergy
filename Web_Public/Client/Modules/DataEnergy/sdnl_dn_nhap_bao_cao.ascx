<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sdnl_dn_nhap_bao_cao.ascx.cs" Inherits="Client_Modules_DataEnergy_sdnl_dn_nhap_bao_cao" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>

<div class="row box-white mb10 pl10 pr10 pb10">
    <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
    <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
    <div class="control-label pt5" style="width: 100%">
        <i class="fa fa-tasks"></i>&nbsp;Báo cáo đang duyệt và chưa gửi<div style="float: right">
            <asp:LinkButton ID="btNhapBaoCao" runat="server" OnClick="btNhapBaoCao_Click" Text="Thêm báo cáo"><i class="fa fa-plus">
            </i>&nbsp;Thêm báo cáo</asp:LinkButton>
        </div>
    </div>
    <table class="table table-bordered table-hover mb10">
        <thead>
            <tr class="primary fs12 text-center">
                <th style="width: 5%" class="text-center">STT
                </th>
                <th style="width: 10%" class="text-center">Năm báo cáo
                </th>
                <th style="width: 10%" class="text-center">Ngày lập báo cáo
                </th>
                <th style="width: 10%" class="text-center">Ngày gửi báo cáo
                </th>
                <th style="width: 10%" class="text-center">Trạng thái
                </th>
                <th style="width: 10%" class="text-center">Thao tác
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="ltBaoCaoChuaGui" runat="server"></asp:Literal>
        </tbody>
    </table>


    <div class="control-label pt5" style="width: 100%" for="inputSmall">
        <i class="fa fa-tasks"></i>&nbsp;Báo cáo đã được phê duyệt
    </div>
    <table class="table table-bordered table-hover mb10">
        <thead>
            <tr class="primary fs12 text-center">
                <th style="width: 5%" class="text-center">STT
                </th>
                <th class="text-center">Kế hoạch năm
                </th>
                <th style="width: 15%" class="text-center">Ngày báo cáo
                </th>
                <th style="width: 15%" class="text-center">Ngày gửi báo cáo
                </th>
                <th style="width: 15%" class="text-center">Ngày xác nhận
                </th>
                <th style="width: 15%" class="text-center">Trạng thái
                </th>
                <th style="width: 5%" class="text-center">Thao tác
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="ltBaoCaoDaDuyet" runat="server"></asp:Literal>
        </tbody>
    </table>
    <div class="ro m3">
        <div class="box-pages">
            <uc1:PagingControl ID="PagingApproved" runat="server"
                FirstString="<%$ Resources:Resource, T_Top %>" LastString="<%$ Resources:Resource, T_Last %>"
                NextString="<%$ Resources:Resource, T_Next %>" PrevString="<%$ Resources:Resource, T_Back %>" />
        </div>
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>


<asp:HiddenField ID="hddma" runat="server" />
<div style="display: none;">
    <asp:Button ID="btDelete" runat="server" />
</div>
<!-- /.modal -->
<script type="text/javascript"> 
    function ShowDialogInitReport() { $('#dlgReport').modal('toggle'); }
    function DeleteBCChoGui(idbc) {
        if (confirm('Bạn có muốn chắc chắn xóa??')) {
            __doPostBack('<%=btDelete.ClientID%>', idbc)

        }
    }
</script>
