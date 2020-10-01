<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TinhHinhBCDNChoSCT.ascx.cs"
    Inherits="Client_Admin_TinhHinhBCDNChoSCT" %>
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
    <div class="tab-block mb25">
       <div class="panel">
            <div class="panel-body">
                <div class="form-horizontal">                                                                                                                                   
                    <div class="form-group">
                        <label class="col-lg-2">Báo cáo năm:</label>
                        <div class="col-lg-2">
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control input-sm"></asp:DropDownList>                                                                  
                        </div>     
                        <label class="col-lg-2" for="inputSmall">Lọc theo DN:</label>                   
                        <div class="col-lg-6">
                            <asp:RadioButtonList ID="rblKey" runat="server" AppendDataBoundItems="True" ValidationGroup="view" RepeatDirection="Horizontal">
                                    <asp:ListItem  Text="Tất cả" Value="0"></asp:ListItem>
                                    <asp:ListItem  Text="Trọng điểm" Value="1"  Selected="True"></asp:ListItem>
                                    <asp:ListItem  Text="Không là trọng điểm" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>                            
                        </div>     
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12">
                            <asp:LinkButton runat="server" ID="btn_search" CssClass="btn btn-sm btn-system mr10" Text="Tìm kiếm" OnClick="btn_search_Click" ><i class="fa fa-search"></i>&nbsp;&nbsp;Tìm kiếm</asp:LinkButton>
                            &nbsp;
                                            <asp:LinkButton ID="btnExport" runat="server" Text="Xuất báo cáo ra Excel" CssClass="btn btn-sm btn-danger mr10" OnClick="btnExport_Click"><i class="fa fa-file-excel-o"></i>&nbsp;&nbsp;Xuất báo cáo ra Excel</asp:LinkButton>                                    
                        </div>

                    </div>
                </div>                
            </div>
        </div>
        <div class="panel">
            <div class="panel-body">
                <asp:Literal ID="clientview" runat="server"></asp:Literal>

                <div class="table-responsive mb20">
                <table class="table table-bordered table-hover mbn">
                    <tr class="primary fs12">
                        <th>#
                        </th>
                        <th>Sở công thương
                        </th>
                        <th>Điện thoại
                        </th>
                        <th>Email
                        </th>
                        <th>Đã gửi</th>
                        <th>Đang duyệt</th>
                        <th>Đã duyệt</th>
                        <th>Chưa gửi</th>
                        <th>Tổng số</th>
                    </tr>            
                    <asp:Repeater ID="rptData" runat="server" onitemdatabound="rptData_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td class="text-center"><%#Container.ItemIndex+1 %></td>
                                <td><%# Eval("Title")%></td>
                                <td><%#Eval("Phone") %></td>
                                <td><%#Eval("Email") %></td>
                                <td class="text-right"><asp:Literal ID="ltSent" runat="server"></asp:Literal></td>
                                <td class="text-right"><asp:Literal ID="ltNoWait" runat="server"></asp:Literal></td>
                                <td class="text-right"><asp:Literal ID="ltNoApproved" runat="server"></asp:Literal></td>
                                <td class="text-right"><asp:Literal ID="ltNoUnReport" runat="server"></asp:Literal></td>
                                <td class="text-right"><asp:Literal ID="ltNoBussines" runat="server"></asp:Literal></td>                        
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                        <tr style="font-weight:bold">
                            <td colspan='4' class="text-right">Tổng số</td>
                            <td class="text-right"><%=TongDaGui%></td>
                            <td class="text-right"><%=TongChuaDuyet %></td>
                            <td class="text-right"><%=TongDaDuyet %></td>
                            <td class="text-right"><%=TongChuaBC %></td>
                            <td class="text-right"><%=TongDN %></td>
                        </tr>
                    </table>                    
                </div>
                <div class="form-group ">
                    <div class="col-lg-12 text-left">                                
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</div>
</section>
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
