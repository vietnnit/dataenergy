<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListReportApproved.ascx.cs"
    Inherits="Client_Admin_DataEnergy_ListReportApproved" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:HiddenField ID="hdnNewsUrl" Value="" runat="server" />
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();">
                    <asp:Literal ID="litModules" runat="server" Text="Báo cáo mức của Cơ sở/Doanh nghiệp"></asp:Literal></a>
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
                <i class="fa fa-home fs22 text-danger"></i>
                <br />
                <span class="fs11">Trang chủ</span>
            </a>
        </div>

        <div class="topbar-icon ml15 ib va-m">
            <a href="#" class="pl5" title="Trợ giúp">
                <i class="fa fa-exclamation-circle fs22 text-primary"></i>
                <br />
                <span class="fs11">Trợ giúp</span>
            </a>
        </div>
    </div>
</header>
<!-- Begin: Content -->
<section id="content">
    <!-- Dashboard Tiles -->
    <div class="row mb10">
        <div class="tab-block mb25">

            <div class="panel">
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-1">
                                <label>
                                    Phân loại
                                </label>
                            </div>
                            <div class="col-lg-2">
                                <asp:DropDownList ID="ddlPhanLoaiBC" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-1">
                                <label>
                                    Kế hoạch năm
                                </label>
                            </div>
                            <div class="col-lg-2">
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="ddlYear" ValidationGroup="vgSearch" Display="Dynamic" Text="Bạn phải chọn năm"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-lg-1">
                                <label>
                                    Lĩnh vực
                                </label>
                            </div>
                            <div class="col-lg-2">
                                <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-1">
                                <label>
                                    Quận/Huyện
                                </label>
                            </div>
                            <div class="col-lg-2">
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-lg-1">
                                <label>
                                    Từ ngày
                                </label>
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txtTuNgay" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                            <div class="col-lg-1">
                                <label>
                                    Đến ngày
                                </label>
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txtDenNgay" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                            <div class="col-lg-1">
                                <label>
                                    Tên DN
                                </label>
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                            <div class="col-lg-3">
                                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="btn btn-outline btn-sm btn-primary" ValidationGroup="vgSearch"
                                    Text="Tìm kiếm" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="dataTables_length">
                                <label>
                                    <asp:Literal ID="ltrTotal" runat="server"></asp:Literal></label>
                            </div>
                        </div>
                        <div class="col-lg-6" style="text-align: right">
                            <div class="dataTables_paginate paging_simple_numbers">
                                <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                                    LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                            </div>
                        </div>
                    </div>

                    <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-lg-12">
                                <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
                                <table class="table table-bordered table-hover mbn" width="100%">
                                    <tr class="primary fs12">
                                        <th style="width: 5%">STT</th>
                                        <th style="width: 7%">Kế hoạch năm</th>
                                        <th style="width: 25%">Tên doanh nghiệp</th>
                                        <th style="width: 10%">Địa chỉ</th>
                                        <th style="width: 10%">Lĩnh vực</th>
                                        <th style="width: 10%">Ngành nghề</th>
                                        <th style="width: 10%">Điện thoại</th>
                                        <th style="width: 10%">Email</th>
                                        <th style="width: 10%">Ngày duyệt</th>
                                        <th style="width: 10%">Người báo cáo</th>
                                        <th style="width: 10%">Xem</th>
                                    </tr>
                                    <asp:Repeater ID="rptNoFuelCurrent" runat="server"
                                        OnItemDataBound="rptNoFuelCurrent_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Container.ItemIndex+1  %></td>
                                                <td><%#Eval("Year") %></td>
                                                <td>
                                                    <a href='<%#ResolveUrl("~") %>Admin/ViewReportDetail/<%#Eval("Id") %>/Default.aspx'><%#Eval("Title") %></a>
                                                </td>
                                                <td><%#Eval("Address") %></td>
                                                <td><%#Eval("ParentAreaName")%></td>
                                                <td><%#Eval("AreaName") %></td>
                                                <td><%#Eval("Phone")%></td>
                                                <td><%#Eval("Email")%></td>
                                                <td><%#Eval("AprovedDate") != DBNull.Value && Convert.ToDateTime(Eval("AprovedDate")).Year > 1 ? Convert.ToDateTime(Eval("AprovedDate")).ToString("dd/MM/yyyy") : ""%></td>
                                                <td><%#Eval("ReporterName")%></td>
                                                <td style="text-align: center">
                                                    <%--<%#(Eval("PathFile") != null && Eval("PathFile").ToString()!="")? "<a href='"+ ResolveUrl("~") +"UserFile/Report/" + Eval("PathFile")+"'><i class=\"fa fa-download\"></i></a>":"" %>--%>
                                                    <%--<a class="fa fa-search" href='<%#ResolveUrl("~") %>Admin/ViewReportDetail/<%#Eval("Id") %>/Default.aspx'></a>--%>
                                                    <a class="fa fa-info-circle" href='<%#GetUrl((string)Eval("ReportType"),(int)Eval("Id"))%>'></a>
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
</section>
<script type="text/javascript">
    $(document).ready(function () {

        $("#<%=txtTuNgay.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });
        $("#<%=txtDenNgay.ClientID%>").datetimepicker({
            format: 'd/m/Y',
            timepicker: false
        });

    });


</script>
