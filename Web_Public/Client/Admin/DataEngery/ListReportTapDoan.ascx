<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListReportTapDoan.ascx.cs"
    Inherits="Client_Admin_DataEngery_ListReportTapDoan" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagPrefix="uc1" TagName="PagingControl" %>
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server"></asp:Literal></a>
            </li>
            <li class="crumb-icon">
               <a href="/Admin/Home/Default.aspx">
                    <span class="glyphicon glyphicon-home"></span>
                </a>
            </li>
                        
        </ol>
    </div>
    <div class="topbar-right">
         <div class="topbar-icon ml15 ib va-m">
            <a href="/Admin/home/Default.aspx" class="pl5" title="Trang chủ"> 
                <i class="fa fa-home fs22 text-danger"></i><br /><span class="fs11">Trang chủ</span>
            </a>
        </div>
        <div class="topbar-icon ml15 ib va-m">
             <a ID="btn_new" runat="server" style="cursor:pointer;"  CssClass="fs11" title="Tạo mới" onclick="showforms(1);"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới</span>
            </a>
        </div>   
         <div class="topbar-icon ml15 ib va-m">
            <%--<asp:LinkButton ID="btnOrder" runat="server" OnClick='btn_Order_Click' CssClass="pl5" title="Sắp xếp"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Sắp xếp</span>
            </asp:LinkButton>--%>
        </div>          
        <div class="topbar-icon ml15 ib va-m">
            <a href="#" class="pl5" title="Trợ giúp"> 
                <i class="fa fa-exclamation-circle fs22 text-primary"></i><br /><span class="fs11">Trợ giúp</span>
            </a>
        </div>
    </div>
</header>
<!-- Begin: Content -->
<section id="content">

<!-- Dashboard Tiles -->
<div class="row mb10">
    <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">
               
                <div class="row">                   
                                                           
                     <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">Từ Ngày</label>
                        <div class="col-lg-3">    
                        <asp:TextBox ID="txtStartDateTime" runat="server" CssClass="form-control input-sm"></asp:TextBox>                                                             
                        </div>
                         <span class="col-lg-1 input-group-addon field-icon"><i class="fa fa-calendar"></i></span>   
                        <label class="col-lg-2 control-label" for="inputSmall">Đến ngày</label>
                        <div class="col-lg-4">                     
                       <asp:TextBox ID="txtEndDateTime" runat="server" CssClass="form-control input-sm"></asp:TextBox>                         
                        </div>
                        <span class="col-lg-1 input-group-addon field-icon"><i class="fa fa-calendar"></i>
                                      </span>
                    </div>     
                    <div class="form-group">
                        <label class="col-lg-2 control-label pt5" for="inputSmall">Từ khóa</label>
                        <div class="col-lg-4">
                                <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Nhập từ khóa"></asp:TextBox>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall"></label>              
                        <div class="col-lg-4">
                        <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm" OnClick="btnsearch_click"/>
                        </div>
                    </div>
                </div>
               
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body">
            <asp:Literal ID="clientview" runat="server"></asp:Literal>

            <div class="tab-content">
                   <div id="tab2" class="tab-pane active">                    
                    <div class="">
                        <div class="">
                          <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
                            <div class="form-horizontal">                                                               
                                <div class="form-group">                                    
                                    <div class="col-lg-12">
                                            <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
                                            <table class="table table-bordered table-hover mbn" width="100%">
                                                <tr class="primary fs12">
                                                    <th style="width:5%">STT</th>
                                                    <th style="width:10%">Đơn vị</th>
                                                    <th style="width:10%">Báo cáo năm</th>
                                                    <th style="width:10%">Mô tả</th>
                                                    <th style="width:10%">Ngày lập báo cáo</th>
                                                    <th style="width:10%">Người lập BC</th>                                                     
                                                     <th style="width:6%">File đính kèm</th>                                          
                                                    <th style="width:6%">Thao tác</th>
                                                </tr>                                           
                                                <asp:Repeater ID="rptNoFuelCurrent" runat="server" OnItemCommand="rptComments_ItemCommand" >
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%#Container.ItemIndex+1  %></td>
                                                        <td><%#Eval("OrgName")%></td>
                                                        <td><%#Eval("Title")%></td>
                                                        <td><%#Eval("Des")%></td>                                                      
                                                        <td><%#Eval("ReportDate") != DBNull.Value && Convert.ToDateTime(Eval("ReportDate")).Year > 1 ? Convert.ToDateTime(Eval("ReportDate")).ToString("dd/MM/yyyy") : ""%></td>                                                    
                                                          <td><%#Eval("Admin_FullName")%></td>                                                       
                                                        <td style="text-align: center"><a target="_blank" href='<%#ResolveUrl("~") %><%#Eval("FilePath")%>' >Xem</a></td>
                                                       <%--   <td><%#Eval("FilePath")%></td>--%>
                                                        <td style="text-align: center">
                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="delete"
                                                                CssClass="fa fa-times" ToolTip="Xóa" OnClientClick="return javascript:confirm('Bạn chắc chắn muốn xóa không');"></asp:LinkButton>
                                                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="fa fa-edit" ToolTip="Sửa"  CommandArgument='<%#Eval("Id") %>' CommandName="edit"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                </asp:Repeater> 
                                            </table>
                                            <br />
                                            <asp:LinkButton ID="btnAdd" runat="server" Visible="false" Text="Thêm báo cáo" CssClass="btn btn-sm btn-primary mr10"></asp:LinkButton>
                                    </div>
                                </div>                                                                                                                                                                                                  
                                <asp:Literal ID="error" runat="server"></asp:Literal>                                                                                                                                                     
                            </div>
                        </div>
                    </div>    
                </div>            
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">     
                <button type="button" class="btn btn-sm btn-info" onclick="showforms(1); "> Thêm mới</button>           
                 <a href="~/Admin/home/Default.aspx">   <button type="button" class="btn  btn-sm btn-info" >Trang chủ</button>   </a>          
                <%-- <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="" />--%>
                </div>
            </div>
        </div>
    </div>
   </div>
</section>
<div class="modal fade" tabindex="-1" role="dialog" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">
                    Báo cáo gửi Bộ công thương</h4>
            </div>
            <div class="modal-body">
                <%--<div class="form-group">
                    <label for="message-text" class="control-label">
                        Tiêu đề:</label>
                    <asp:TextBox runat="server" class="form-control" ID="txttieude"></asp:TextBox>
                </div>--%>
                <div class="form-group">
                    <label class="control-label">
                        Năm báo cáo:</label>
                    <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control input-sm">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvYear" runat="server" ValidationGroup="valReport"
                        Display="Dynamic" Text="Vui lòng chọn cách thức lắp đặt" ControlToValidate="ddlYear"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="recipient-name" class="control-label">
                        Ngày lập báo cáo :</label>
                    <asp:TextBox ID="txtNgaytao" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valReport"
                        Display="Dynamic" Text="Vui lòng nhập ngày lập báo cáo" ControlToValidate="txtNgaytao"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="message-text" class="control-label">
                        Mô tả:</label>
                    <asp:TextBox runat="server" class="form-control" ID="txtmota"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="message-text" class="control-label">
                        File đính kèm:</label>
                    <asp:FileUpload runat="server" class="form-control " ID="ffile"></asp:FileUpload>
                </div>
                <div class="form-group" id="lbldinhkem">
                    <label for="message-text" class="control-label">
                        File đã đính kèm:</label>
                    <asp:TextBox runat="server" class="form-control " ID="txtfile" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnExport" runat="server" Visible="true" Text="Lưu lại" OnClick="btnsave_DirectClick"
                    CssClass="btn btn-sm btn-primary mr10" AutoPostback="false"></asp:Button>
                <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">
                    Đóng</button>
            </div>
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtStartDateTime.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });
        $("#<%=txtEndDateTime.ClientID%>").datetimepicker({
            format: 'd/m/Y', timepicker: false
        });
        $("#<%=txtNgaytao.ClientID%>").datetimepicker({
            format: 'd/m/Y', timepicker: false
        });
        $('input[id=lefile]').change(function () {
            $('#photoCover').val($(this).val());
        });
    });
    function showforms(itrangthai) {
        $(document).ready(function () {
            $('#myModal').modal('toggle');
            if (itrangthai != "1") {
                $("#lbldinhkem").css('display', 'block');
            }
            else {
                $("#lbldinhkem").css('display', 'none');
                $("#<%=hddvalue.ClientID%>").val('');
                $("#<%=txtNgaytao.ClientID%>").val('');
                $("#<%=txtmota.ClientID%>").val('');
            }
        });

    }
</script>
<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<asp:HiddenField ID="hddvalue" runat="server" Value="" />
<asp:HiddenField ID="hddngaytao" runat="server" Value="1" />
