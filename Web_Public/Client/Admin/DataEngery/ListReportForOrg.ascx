<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListReportForOrg.ascx.cs" Inherits="Client_Admin_DataEnergy_ListReportForOrg" %>
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
             <asp:LinkButton ID="btn_new" runat="server" OnClick='btn_new_click' CssClass="pl5" title="Thêm dự án" ValidationGroup="view"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm báo cáo</span>
            </asp:LinkButton>
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
                                <div class="col-lg-1">
                                    <div class="form-group">
                                        <label>
                                            Năm
                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlYear" runat="server"  CssClass="form-control input-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="ddlYear" ValidationGroup="vgSearch" Display="Dynamic" Text="Bạn phải chọn năm"></asp:RequiredFieldValidator>
                                    </div>
                                </div>                                                                                                     
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="btn btn-outline btn-sm btn-primary" ValidationGroup="vgSearch"
                                            Text="Tìm kiếm" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">                                                                   
                                
                            </div>
                        </div>
                    </div>                    
                    <div class="panel">
                        <div class="panel-body">
                          <asp:Literal ID="ltNotice" runat="server"></asp:Literal>
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
                            <div class="form-horizontal">                                                               
                                <div class="form-group">                                    
                                    <div class="col-lg-12">
                                            <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
                                            <table class="table table-bordered table-hover mbn" width="100%">
                                                <tr class="primary fs12">
                                                    <th style="width:5%">STT</th>
                                                    <th style="width:35%">Tên DN</th>
                                                    <th style="width:10%">Địa chỉ</th>
                                                    <%--<th style="width:10%">Tỉnh/TP</th>
                                                    <th style="width:10%">Vùng</th>  --%>                                                  
                                                    <th style="width:10%">Lĩnh vực</th> 
                                                    <th style="width:10%">Ngành nghề</th> 
                                                    <asp:Literal ID="ltHeader" runat="server"></asp:Literal>
                                                    <th style="width:10%">Năng lượng tiêu thụ quy đổi (TOE)</th>                                                    
                                                </tr>                                           
                                                <asp:Literal ID="ltData" runat="server"></asp:Literal>
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

