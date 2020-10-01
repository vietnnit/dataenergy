<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditCateNewsGroupPermission.ascx.cs"
    Inherits="Client_Admin_EditCateNewsGroupPermission" %>

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
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/ListRoles/Default.aspx" CssClass="pl5" title="DS nhóm quyền"> 
                <i class="fa fa-group fs22 text-primary"></i><br /><span class="fs11">DS nhóm quyền</span>
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
    
        <div class="panel panel-tile text-primary of-h mb10">
            <div class="panel-body pn br-n pl20 p5">
                <div class="icon-bg">
                    <i class="fa fa-group"></i>
                </div>
                <h2 class="mt15 lh15">
                        <b>Nhóm</b>
                    </h2>
                <h5 class="text-muted"><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h5>
            </div>
        </div>
        <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">

                <asp:Literal ID="error" runat="server"></asp:Literal>

                

                 <div class="form-group">
                    <label class="col-lg-2 control-label pt5" for="inputSmall">Chọn nhóm chuyên mục</label>
                    <div class="col-lg-6">
                        <div class="checkbox-custom pt5">
                        <asp:CheckBoxList ID="chklist" runat="server"  RepeatDirection="Vertical" >
                         </asp:CheckBoxList>
                         </div>
                    </div>
                
                </div>

                <div class="form-group ">
                    <div class="col-lg-12 text-left">
                        <asp:Button runat="server" ID="Button1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />

                    </div>
                </div>

            </div>
            </div>
        </div>


</div>
</section>
<asp:HiddenField ID="hddRoles" runat="server" />
