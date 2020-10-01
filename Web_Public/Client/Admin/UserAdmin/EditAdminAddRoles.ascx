<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditAdminAddRoles.ascx.cs" Inherits="Client_Admin_EditAdminAddRoles" %>

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
             <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/listadmin/Default.aspx" CssClass="pl5" title="DS User"> 
                <i class="fa fa-group fs22 text-primary"></i><br /><span class="fs11">DS User</span>
            </asp:HyperLink>
        </div>   
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnOrder" runat="server" OnClick='btn_add_Click' CssClass="pl5" title="Lưu lại"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Lưu lại</span>
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
    
        <div class="panel panel-tile text-primary of-h mb10">
            <div class="panel-body pn br-n pl20 p5">
                <div class="icon-bg">
                    <i class="fa fa-group"></i>
                </div>
                <h2 class="mt15 lh15">
                        <b>Account</b>
                    </h2>
                <h5 class="text-muted"><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h5>
            </div>
        </div>
   

    <div class="panel">
        <div class="panel-body">
            <asp:Literal ID="error" runat="server"></asp:Literal>

            <div class="table-responsive mb20">
            <asp:GridView ID="grvRoles" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="True" PageSize="1000"  EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Roles_ID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="30px" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="#">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="50px" />
                        <ItemTemplate>
                                <asp:CheckBox ID="chkId" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    
                    <asp:BoundField DataField="Roles_Name" HeaderText="Tên nhóm quyền">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:BoundField>
                   
                </Columns>
            </asp:GridView>
        
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_edit2" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_add_Click" />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/listadmin/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="DS User" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>

<asp:HiddenField ID="hddUserName" runat="server" />
