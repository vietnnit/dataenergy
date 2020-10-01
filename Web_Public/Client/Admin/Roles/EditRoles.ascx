<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditRoles.ascx.cs" Inherits="Admin_Controls_CreateRoles" %>

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
            <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/EditRoles/Default.aspx" CssClass="pl5" title="Tạo mới"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Tạo mới</span>
            </asp:HyperLink>
        </div> 
         
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_add" runat="server" OnClick='btn_add_Click' CssClass="pl5" title="Lưu lại"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Lưu lại</span>
            </asp:LinkButton>
        </div>
          
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_edit" runat="server" OnClick='btn_edit_Click' CssClass="pl5" title="Cập nhật"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Cập nhật</span>
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
    
    <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">
                    <asp:Literal ID="error" runat="server"></asp:Literal>
        
                 
                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tên nhóm quyền</label>
                    <div class="col-lg-6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRolesName"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtRolesName" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên nhóm quyền"></asp:TextBox>
                    </div>
                    
                </div>

                <hr />


             <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Phân quyền Modules</label>
                <div class="col-lg-6">
                    <div class="checkbox-custom pt5">
                    <asp:CheckBoxList ID="chklist" runat="server"  RepeatDirection="Vertical" >
                     </asp:CheckBoxList>
                     </div>
                </div>
                
            </div>

             <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/EditRoles/Default.aspx" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/ListRoles/Default.aspx" Text="DS User" />
                       
                <asp:HyperLink ID="HyperLink11" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>

             </div>
        </div>
    </div>
</div>
</section>

<asp:HiddenField ID="hddRoles_ID" runat="server" />
