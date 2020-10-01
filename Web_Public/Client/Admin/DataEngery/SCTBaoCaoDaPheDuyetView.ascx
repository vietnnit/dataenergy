<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCTBaoCaoDaPheDuyetView.ascx.cs" Inherits="Client_Admin_DataEngery_SCTBaoCaoDaPheDuyetView" %>
<div align="center" style="margin-bottom: 20px;">
    <table style="width: 100%">
        <tr>
            <td colspan="3" style="font-weight: bold; padding:10px;">&nbsp;BÁO CÁO SỬ DỤNG NĂNG LƯỢNG HÀNG NĂM
            </td>
        </tr>
        
         <tr>
            <td colspan="3" style="font-weight: bold; padding:10px;">Năm báo cáo: <asp:Literal ID="ltNamBaoCao" runat ="server"></asp:Literal>
            </td>
        </tr>
    </table>
</div>
<div class="panel panel-blue">
    <div class="panel-body pt10 pb10">
        <div class="form-horizontal">
            <asp:Literal ID="ltReport" runat="server"></asp:Literal>
        </div>
    </div>
</div>

<asp:Panel ID="pnAction" runat="server">
    <div align="center" style="margin-top: 20px;">
        <a href="javascript:GetData();" class="btn btn-primary btn-sm"><i class="fa fa-save"></i>&nbsp;Lưu lại</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <a href="javascript:ShowDialogInitReport();" class="btn btn-danger btn-sm"><i class="fa fa-send"></i>&nbsp;Hoàn thành lập và Gửi báo cáo</a>
    </div>
</asp:Panel>
<asp:Panel ID="pnNoneAction" runat="server" Visible="false">
    <div align="center" style="margin-top: 20px;">
          <a href="javascript:window.history.back();" class="btn btn-danger btn-sm"><i class="fa fa-send"></i>&nbsp;Quay lại</a>
    </div>
</asp:Panel>
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
                <asp:Button ID="btnSendReport" OnClick="btnSendReport_Click" runat="server"
                    Text="Gửi" CssClass="btn btn-primary" />&nbsp;&nbsp;&nbsp;
                            <button type="button" class="btn-u btn-u-default" data-dismiss="modal">
                                Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>

<script type="text/javascript"> 
    function ShowDialogInitReport() { $('#dlgSendReport').modal('toggle'); }
</script>