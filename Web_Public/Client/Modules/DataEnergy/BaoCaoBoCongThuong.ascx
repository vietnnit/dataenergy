<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BaoCaoBoCongThuong.ascx.cs"
    Inherits="Client_Modules_DataEnergy_BaoCaoBoCongThuong" %>
<div class="row box-white mb10" style="padding-left: 10px; padding-right: 10px;">
    <div class="tab-block mb25">
        <div class="form-horizontal">
            <div class="form-group">
                <div class="col-lg-12">
                    <table class="table table-bordered table-hover mbn" width="100%">
                        <tr class="primary fs12">
                            <th style="width: 5%">
                                STT
                            </th>
                            <th style="width: 10%">
                                Tên cơ sở
                            </th>
                            <th style="width: 10%">
                                Ngày báo cáo
                            </th>
                            <th style="width: 10%">
                                Ngày cập nhật báo cáo
                            </th>
                            <th style="width: 10%">
                                Ngày lập báo cáo
                            </th>
                            <th style="width: 10%">
                                Người lập BC
                            </th>
                            <th style="width: 25%">
                                Thời gian cập nhật
                            </th>
                            <th style="width: 10%">
                                Trạng thái
                            </th>
                            <th style="width: 10%">
                                Thao tác
                            </th>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" tabindex="-1" role="dialog" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Lựa chọn mẫu báo cáo</h4>
            </div>
            <div class="modal-body">
                <p>
                    <asp:DropDownList runat="server" ID="drpmaubaocao">
                        <asp:ListItem Value="1" Text="Dùng cho cơ sở hoạt động trong lĩnh vự sản xuất công nghiệp"
                            Selected="True"></asp:ListItem>
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
                </p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">
                    Close</button>
                <asp:LinkButton ID="btnExport" runat="server" Visible="true" OnClick="btnExcel_DirectClick"
                    Text="Xuất báo cáo" CssClass="btn btn-sm btn-primary mr10"></asp:LinkButton>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<script type="text/javascript">


    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').focus()
    });
  

</script>
