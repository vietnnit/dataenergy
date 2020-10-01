<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditDEOrganization.ascx.cs"
    Inherits="Client_Admin_EditDEOrganization" %>
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
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/ListOrganization/Default.aspx" CssClass="pl5" title="Danh mục"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">Danh mục</span>
            </asp:HyperLink>
        </div>  
        <div class="topbar-icon ml15 ib va-m">
             <a onclick="javascript:addorg();return false;">
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới</span>
            </a>
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
                <label class="col-lg-2 control-label pt5" for="inputSmall">Tên sở/Tập đoàn</label>
                
                <div class="col-lg-6">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control input-sm" placeholder="Tên sở/Tập đoàn"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" Display="Dynamic"
                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Tỉnh/TP</label>                
                <div class="col-lg-6">
                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control input-sm" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProvince" Display="Dynamic"
                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Số điện thoại</label>
                <div class="col-lg-4">                                    
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-sm" placeholder="Số điện thoại" ValidationGroup="view"></asp:TextBox>
                </div>
            </div>
             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Email</label>
                <div class="col-lg-10">                                    
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm" placeholder="Nhập Email" ValidationGroup="view"></asp:TextBox>
                </div>
            </div>  
            <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Địa chỉ</label>
                <div class="col-lg-10">                                    
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm" placeholder="Địa chỉ" ValidationGroup="view"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Ghi chú</label>
                <div class="col-lg-10">                                    
                    <asp:TextBox ID="txtNote" runat="server" CssClass="form-control input-sm" placeholder="Địa chỉ" ValidationGroup="view"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Thứ tự hiển thị</label>
                
                <div class="col-lg-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSorOrder"
                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtSorOrder"
                            ErrorMessage="*" Type="Integer" MinimumValue="0" MaximumValue="9999"><span class="append-icon right text-danger">(0-9999)</span></asp:RangeValidator>
                    <asp:TextBox ID="txtSorOrder" runat="server" CssClass="form-control input-sm" placeholder="Vị trí"></asp:TextBox>
                </div>
            </div>

            

            <div class="form-group">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />
                <asp:Button runat="server" ID="btn_add2" CssClass="btn btn-sm btn-primary mr10" Text="Lưu & thêm mới" OnClick="btn_add_Click_more" />
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click" />
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Admin/ListOrganization/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Danh mục" />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/EditDEOrganization/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>

            </div>
        </div>
    </div>
   

</div>
</section>
<asp:HiddenField ID="txtModulesID" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
<asp:HiddenField ID="hddPostDate" runat="server" />
