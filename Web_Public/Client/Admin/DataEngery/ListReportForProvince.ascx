<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListReportForProvince.ascx.cs"
    Inherits="Client_Admin_DataEnergy_ListReportForProvince" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<asp:HiddenField ID="hdnNewsUrl" Value="" runat="server" />
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server" Text="Báo cáo mức của Cơ sở/Doanh nghiệp"></asp:Literal></a>
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
             <asp:HyperLink ID="btn_list" runat="server" NavigateUrl="~/Admin/listReport/Default.aspx" CssClass="pl5" title="Videos"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">Danh sách</span>
            </asp:HyperLink>
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
            <%--<ul class="nav nav-tabs tabs-border">      
                <li class="active"><a href="#tab1" data-toggle="tab" aria-expanded="true">Thông tin báo cáo</a></li>
                <li><a href="#tab2" data-toggle="tab" aria-expanded="false">Số liệu báo cáo</a></li>                                
            </ul>--%>
            <div class="">
                <%--<div id="tab1" class="tab-pane active">
                    <div class="panel">
                        <div class="panel-body">                                          
                        </div>
                    </div>
                </div>--%>
                <div id="tab2" class="tab-pane active">        
                    <div class="panel">
                        <div class="panel-body">     
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-2">
                                            <label>
                                                Năm báo cáo
                                            </label>
                                    </div>                                                     
                                    <div class="col-lg-4">
                                            <asp:DropDownList ID="ddlYear" runat="server" ValidationGroup="vgSearch" CssClass="form-control input-sm">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="ddlYear" ValidationGroup="vgSearch" Display="Dynamic" Text="Bạn phải chọn năm"></asp:RequiredFieldValidator>                                        
                                    </div>
                                    <div class="col-lg-2">
                                            Trạng thái
                                    </div>
                                    <div class="col-lg-4">                                    
                                        <asp:DropDownList ID="ddlStatus"  CssClass="form-control input-sm" runat="server">
                                            <asp:ListItem Text="---Tất cả---" Value=""></asp:ListItem>                                            
                                            <asp:ListItem Text="Chờ phê duyệt" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Đã phê duyệt" Value="1"></asp:ListItem>
                                        </asp:DropDownList>                                    
                                    </div>
                                </div>    
                            </div>  
                            <div class="row">    
                                <div class="form-group">
                                    <div class="col-lg-2">
                                        Sở công thương
                                    </div>                                                                 
                                    <div class="col-lg-4">                                    
                                        <asp:DropDownList ID="ddlOrg" runat="server"  CssClass="form-control input-sm">
                                        </asp:DropDownList>                                                
                                    </div>                                
                                    <div class="col-lg-2" >Lĩnh vực</div>
                                    <div class="col-lg-4">                     
                                        <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True"  AutoPostBack="true"
                                            CssClass="form-control input-sm" ValidationGroup="view" 
                                            onselectedindexchanged="ddlArea_SelectedIndexChanged">
                                        </asp:DropDownList>                                                                    
                                    </div>      
                                </div>
                            </div>
                            <div class="row">    
                                <div class="form-group">
                                    <div class="col-lg-2" for="inputSmall">Phân ngành</div>
                                    <div class="col-lg-4">                     
                                        <asp:DropDownList ID="ddlSubArea" runat="server" AppendDataBoundItems="True" 
                                            CssClass="form-control input-sm" ValidationGroup="view">
                                        </asp:DropDownList>                                                                    
                                    </div>                                                                                                                        
                                    <div class="col-lg-2" for="inputSmall">Tên DN/Cơ sở</div>
                                    <div class="col-lg-4">
                                        <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder=""></asp:TextBox>
                                    </div>
                                </div>                                                                                         
                            </div>
                            <div class="row">
                                <div class="col-lg-4">                                    
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
                                            <th style="width:5%">STT</th>
                                            <th style="width:35%">Tên cơ sở/Doanh nghiệp</th>
                                                <th style="width:10%">Tỉnh/TP</th>
                                            <th style="width:10%">Năm báo cáo</th>
                                            <th style="width:10%">Ngày xác nhận</th>
                                            <th style="width:10%">Ngày lập báo cáo</th>
                                            <th style="width:10%">Người lập BC</th>
                                            <th style="width:10%">Thời gian cập nhật</th>
                                            <th style="width:10%">Trạng thái</th>                                          
                                            <th style="width:10%">Thao tác</th>
                                        </tr>                                           
                                        <asp:Repeater ID="rptNoFuelCurrent" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Container.ItemIndex+1  %></td>
                                                <td><a href='<%#ResolveUrl("~") %>Admin/ViewReportDetail/<%#Eval("Id") %>/Default.aspx'><%#Eval("Title") %></a></td>   
                                                <td><%#Eval("ProvinceName") %></td>
                                                <td><%#Eval("Year")%></td>                                                                                                            
                                                <td><%#Eval("ConfirmedDate") != DBNull.Value && Convert.ToDateTime(Eval("ConfirmedDate")).Year > 1 ? Convert.ToDateTime(Eval("ConfirmedDate")).ToString("dd/MM/yyyy") : ""%></td>
                                                <td><%#Eval("ReportDate") != DBNull.Value && Convert.ToDateTime(Eval("ReportDate")).Year > 1 ? Convert.ToDateTime(Eval("ReportDate")).ToString("dd/MM/yyyy") : ""%></td>
                                                <td><%#Eval("ReporterName")%></td>
                                                                                                         
                                                <td><%#Eval("Modified") != DBNull.Value && Convert.ToDateTime(Eval("Modified")).Year > 1 ? Convert.ToDateTime(Eval("Modified")).ToString("dd/MM/yyyy hh:MM") : ""%></td>
                                                <td><%#Convert.ToBoolean(Eval("ApprovedSatus"))?"Đã phê duyệt":"Chờ duyệt"%></td>                                                           
                                                <td style="text-align: center">
                                                         
                        <%#(Eval("PathFile") != null && Eval("PathFile").ToString()!="")? "<a href='"+ ResolveUrl("~") +"UserFile/Report/" + Eval("PathFile")+"'><i class=\"fa fa-download\"></i></a>":"" %>
                        <a class="fa fa-info-circle" href='<%#ResolveUrl("~") %>Admin/ViewReportDetail/<%#Eval("Id") %>/Default.aspx'></a>
                                                            
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
        </div> 
    </div>   
</section>
