<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportByTOEForOrg.ascx.cs"
    Inherits="Client_Admin_DataEnergy_ReportByTOEForOrg" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagPrefix="uc1" TagName="PagingControl" %>
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
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label>
                                            Lĩnh vực
                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlArea" runat="server"  CssClass="form-control input-sm" onselectedindexchanged="ddlArea_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>                                        
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label>
                                            Phân ngành
                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlSubArea" runat="server"  CssClass="form-control input-sm">
                                        </asp:DropDownList>                                        
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label>
                                            Số liệu năm
                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddlYear" runat="server"  CssClass="form-control input-sm">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="ddlYear" ValidationGroup="vgSearch" Display="Dynamic" Text="Bạn phải chọn năm"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                   
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label>
                                            Tên DN/Cơ sở
                                        </label>
                                    </div>
                                </div>
                               <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm"></asp:TextBox>                              
                                    </div>
                                </div>                                                                                                                                  
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="btn btn-outline btn-sm btn-primary" ValidationGroup="vgSearch"
                                            Text="Tìm kiếm" />
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
                            </div>
                            <div class="form-horizontal">                                                               
                                <div class="form-group">                                    
                                    <div class="col-lg-12">
                                            <asp:Literal ID="ltNoFuelCurrent" runat="server"></asp:Literal>
                                            <table class="table table-bordered table-hover mbn" width="100%">
                                                <tr class="primary fs12">
                                                    <th style="width:5%">STT</th>
                                                    <th style="width:35%">Tên cơ sở/Doanh nghiệp</th>
                                                    <th style="width:10%">Địa chỉ</th>
                                                    <%--<th style="width:10%">Tỉnh/TP</th>   --%>                                                                                
                                                    <th style="width:10%">Lĩnh vực SX</th> 
                                                    <th style="width:10%">Phân ngành</th> 
                                                    <th style="width:10%">Điện (KWh)</th>      
                                                    <th style="width:10%">Than (Tấn)</th>      
                                                    <th style="width:10%">DO (Tấn)</th>                                          
                                                    <th style="width:10%">FO (Tấn)</th>      
                                                    <th style="width:10%">Xăng (Tấn)</th>      
                                                    <th style="width:10%">Gas (Tấn)</th>      
                                                    <th style="width:10%">Khí (m3)</th>                                                     
                                                    <th style="width:10%">LPG (Tấn)</th>    
                                                    <th style="width:10%">Khác (Số đo)</th>    
                                                    <th style="width:10%">Quy đổi (TOE)</th>                                                 
                                                </tr>                                           
                                                <asp:Repeater ID="rptData" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="text-center"><%#Container.ItemIndex+1  %></td>
                                                            <td><%#Eval("Title")%></td>
                                                            <td><%#Eval("Address")%></td>     
                                                            <%--<td><%#Eval("OrgName")%></td>        --%>                                                                                           
                                                            <td><%#Eval("AreaName")%></td>
                                                            <td><%#Eval("SubAreaName")%></td>
                                                            <td><%#Eval("Dien_kWh")%></td>
                                                            <td><%#Eval("Than_Tan")%></td>
                                                            <td><%#Eval("DO_Tan")%></td>
                                                            <td><%#Eval("FO_Tan")%></td>
                                                            <td><%#Eval("Xang_Tan")%></td>
                                                            <td><%#Eval("Gas_Tan")%></td>
                                                            <td><%#Eval("Khi_m3")%></td>
                                                            <td><%#Eval("LPG_Tan")%></td>
                                                            <td><%#Eval("KhacSoDo")%></td>
                                                            <td><%#Eval("No_TOE")%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>                                            
                                    </div>
                                    <div class="col-lg-12" style="text-align: right">
                                        <div class="dataTables_paginate paging_simple_numbers">
                                            <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                    LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                                        </div>
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
