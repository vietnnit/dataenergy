﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImportReport.ascx.cs"
    Inherits="Client_Admin_DataEnergy_ImportReport" %>
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server" Text="Import báo cáo"></asp:Literal></a>
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
    <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">
            <asp:Literal ID="lterror" runat="server"></asp:Literal>            
             <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Chọn file</label>
                
                <div class="col-lg-6">
                    <asp:FileUpload ID="flReport" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvFile" runat="server" ControlToValidate="flReport" ValidationGroup="valUpload"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group" style="display:none">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Sở công thương</label>                
                <div class="col-lg-4">
                    <asp:DropDownList ID="ddlDonVi" runat="server" CssClass="form-control input-sm" ></asp:DropDownList>
                </div>
        
            </div>            
            
            <div class="form-group">
                <div class="col-lg-2 control-label">Kế hoạch năm</div>      
                <div class="col-lg-4">
                    <asp:TextBox ID="txtPlanYear" runat="server" CssClass="form-control input-sm" Text="2018"></asp:TextBox>                    
                </div>
                <div class="col-lg-6 text-left">
                    <asp:Button runat="server" ID="btnUpload" Visible="false" CssClass="btn btn-sm btn-primary mr10" Text="Xem" OnClick="btnUpload_Click" />
                    <asp:Button runat="server" ID="btnImport" CssClass="btn btn-sm btn-primary mr10"  ValidationGroup="valUpload" Text="Import" OnClick="btnImport_Click" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-sm btn-primary mr10" Text="Xóa" OnClick="btnDelete_Click" />               
                </div>

            </div>
        </div>
    </div>
   

</div>
</section>
<asp:HiddenField ID="txtModulesID" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
<asp:HiddenField ID="hddPostDate" runat="server" />
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  