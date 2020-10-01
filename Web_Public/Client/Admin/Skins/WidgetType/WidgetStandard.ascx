<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WidgetStandard.ascx.cs" Inherits="Client_Admin_TVShow_WidgetType_WidgetStandard" %>

<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server"></asp:Literal></a>
            </li>
                        
        </ol>
    </div>
    <div class="topbar-right">

       
        
        <div class="topbar-icon ml15 ib va-m">
            <a href="JavaScript:window.close();" class="pl5" title="Đóng"> 
                <i class="fa fa-remove fs22 text-danger"></i><br /><span class="fs11">Đóng</span>
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
           <div class='alert alert-sm alert-danger bg-gradient'>Module không có cấu hình!</div>

            
        </div>
    </div>
 
</div>
</section>