<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListReportFuelForOrg.ascx.cs"
    Inherits="Client_Admin_DataEnergy_ListReportFuelForOrg" %>
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
                <i class="fa fa-home fs22 text-danger"></i><br /><span class="fs11">Dashboard</span>
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
                        <div class="">
                            <div class="form-group">                                                                                                         
                                <label class="col-lg-1">
                                    Số liệu năm
                                </label>                                                                 
                                <div class="col-lg-2">                                    
                                    <asp:DropDownList ID="ddlYear" runat="server"  CssClass="form-control input-sm">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="ddlYear" ValidationGroup="vgSearch" Display="Dynamic" Text="Bạn phải chọn năm"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-lg-1">
                                    Sở công thương
                                </label>                                                                 
                                <div class="col-lg-2">                                    
                                    <asp:DropDownList ID="ddlOrg" runat="server"  CssClass="form-control input-sm">
                                    </asp:DropDownList>                                                
                                </div>                                        
                           <%-- </div>
                            <div class="form-group">--%>
                                <label class="col-lg-1" for="inputSmall">Lĩnh vực</label>
                                <div class="col-lg-2">                     
                                    <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True"  AutoPostBack="true"
                                        CssClass="form-control input-sm" ValidationGroup="view" 
                                        onselectedindexchanged="ddlArea_SelectedIndexChanged">
                                    </asp:DropDownList>                                                                    
                                </div>      
                                <%--<label class="col-lg-2" for="inputSmall">Phân ngành</label>
                                <div class="col-lg-4">                     
                                    <asp:DropDownList ID="ddlSubArea" runat="server" AppendDataBoundItems="True" 
                                        CssClass="form-control input-sm" ValidationGroup="view">
                                    </asp:DropDownList>                                                                    
                                </div>          --%>  
                                <label class="col-lg-1" for="inputSmall">Từ khóa</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên doanh nghiệp"></asp:TextBox>
                                </div>               
                            </div>                                                        
                            <div class="form-group">                                                                                         
                                <div class="col-lg-12">                                    
                                         <asp:LinkButton ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="btn btn-outline btn-sm btn-system" ValidationGroup="vgSearch"
                                            Text="Tìm kiếm" ><i class="fa fa-search"></i>&nbsp;&nbsp;Tìm kiếm</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="btnExport" runat="server" Text="Xuất báo cáo ra Excel" CssClass="btn btn-sm btn-danger mr10" OnClick="btnExport_Click"><i class="fa fa-file-excel-o"></i>&nbsp;&nbsp;Xuất báo cáo ra Excel</asp:LinkButton>
                                </div>
                            </div>
                        </div>               
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
                            <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>                                  
                            <div class="table-responsive">                                    
                                    <table class="table table-bordered table-hover mbn">
                                        <thead>  
                                            <tr>
                                                <th style="width:5%">STT</th>
                                                <th style="width:35%">Tên DN</th>
                                                <th style="width:10%">Địa chỉ</th>
                                                <th style="width:10%">Tỉnh/TP</th>
                                                <%--<th style="width:10%">Vùng</th>--%>                                                    
                                                <th style="width:10%">Lĩnh vực</th> 
                                                <th style="width:10%">Ngành nghề</th> 
                                                <asp:Literal ID="ltHeader" runat="server"></asp:Literal>
                                                <th style="width:10%">Quy đổi (TOE)</th>    
                                            </tr>                                                                                     
                                        </thead>                                           
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
</section>
