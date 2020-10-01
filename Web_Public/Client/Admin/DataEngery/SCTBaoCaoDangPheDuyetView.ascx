<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SCTBaoCaoDangPheDuyetView.ascx.cs" Inherits="Client_Admin_DataEngery_SCTBaoCaoDangPheDuyetView" %>
<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.css" />
<script type="text/javascript" src="<%= ResolveUrl("~") %>Scripts/tab_announce/tabcontent.js"></script>
<div align="center" style="margin-bottom: 20px;">
    <table style="width: 100%">
        <tr>
            <td colspan="3" style="font-weight: bold; padding: 10px;">&nbsp;BÁO CÁO SỬ DỤNG NĂNG LƯỢNG HÀNG NĂM
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style="width: 80%; margin-right: 10px;" align="right">
                <a href="javascript:ShowDialogInitReport();" class="btn btn-success btn-sm"><i class="fa fa-send"></i>&nbsp;Phê duyệt báo cáo</a>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="font-weight: bold; padding: 10px;">Năm báo cáo:
                <asp:Literal ID="ltNamBaoCao" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</div>

<div class="tab-block mb25">
    <div class="row">
        <div class="col-lg-12">
            <ul class="nav nav-tabs tabs-border" id="DNUpdatetabs">
                <li><a rel="tabInfo" href="#" class="selected">THÔNG TIN BÁO CÁO</a></li>
                <li><a rel="tabImportant" href="#" class="">Ý KIẾN, PHẢN HỒI PHÊ DUYỆT</a></li>
            </ul>
        </div>
    </div>
    <div class="tab-content">
        <div id="tabInfo">
            <asp:Literal ID="ltReport" runat="server"></asp:Literal>
        </div>

        <div id="tabImportant">
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
        <a href="javascript:ShowDialogInitReport();" class="btn btn-danger btn-sm"><i class="fa fa-send"></i>&nbsp;Hoàn thành lập và Gửi báo cáo</a>
    </div>
</asp:Panel>
<asp:Panel ID="pnNoneAction" runat="server" Visible="false">
    <div align="center" style="margin-top: 20px;">
        <asp:LinkButton ID="btnQuayLai" runat="server" CssClass="btn btn-danger btn-sm" OnClick="btnQuayLai_Click"><i class="fa fa-send"></i>&nbsp;Quay lại</asp:LinkButton>
    </div>
</asp:Panel>
<div id="hiddenCalatedData" style="display: none;">
    <asp:HiddenField ID="ltDuLieuNhap" runat="server"></asp:HiddenField>
</div>

<div class="modal fade" tabindex="-1" role="dialog" id="dlgPheDuyetBaoCao">
    <div class="modal-dialog">
        <div class="modal-content sky-form">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Phê duyệt báo cáo</h4>
            </div>
            <div class="modal-body">
                <div class="form-horizontal">
                    <div class="form-check">
                        <label class="form-check-label" for="radio1">
                            <asp:RadioButton ID="rdDongYBaoCao" runat="server" GroupName="PheDuyetBaoCao" Checked="true" CssClass="form-check-input" Text="Đồng ý báo cáo" />
                            <%--<input type="radio" class="form-check-input" id="radio1" name="optradio" value="option1" checked >Đồng ý báo cáo--%>
                        </label>
                    </div>
                    <div class="form-check">
                        <label class="form-check-label" for="radio2">
                            <asp:RadioButton ID="rdYeuCauHieuChinh" runat="server" GroupName="PheDuyetBaoCao" CssClass="form-check-input" Text="Yêu cầu bổ sung, hiệu chỉnh" />
                            <%--  <input type="radio" class="form-check-input" id="radio2" name="optradio" value="option2">Yêu cầu bổ sung, hiệu chỉnh--%>
                        </label>
                    </div>

                    <div class="form-group">
                        <label for="comment">Nội dung ý kiến:</label>
                        <asp:TextBox ID="txtNoiDungYKien" placeholder="Mục đích sử dụng tối đa 500 ký tự" MaxLength="500" runat="server" TextMode="MultiLine" Rows="5" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btPheDuyetBaoCao" OnClick="btPheDuyetBaoCao_Click" runat="server"
                    Text="Xác nhận" CssClass="btn btn-primary" />&nbsp;&nbsp;&nbsp;
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<style type="text/css">
    .modal-dialog {
        z-index: 9999 !important;
    }
</style>
<script type="text/javascript"> 
    function ShowDialogInitReport() { $('#dlgPheDuyetBaoCao').modal('toggle'); }
</script>

<script type="text/javascript">
    var tabReport = new ddtabcontent("DNUpdatetabs");
    //tabReport.setpersist(true);
    //tabReport.setselectedClassTarget("link");
    tabReport.currentTabIndex = 0;
    tabReport.init();
</script>
