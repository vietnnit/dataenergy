<%@ Control Language="C#" AutoEventWireup="true" CodeFile="changepass.ascx.cs" Inherits="Admin_Controls_Changepass" %>
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
            <asp:LinkButton ID="btn_edit" runat="server" OnClick='btn_Update_Click' CssClass="pl5" title="Lưu lại"> 
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
    
    <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">
                    <asp:Literal ID="clientview" runat="server"></asp:Literal>                        
                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tên tài khoản</label>
                    <div class="col-lg-6">
                        <asp:RequiredFieldValidator ValidationGroup="valChangePas" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdminUser"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtAdminUser" runat="server" Enabled="false" CssClass="form-control input-sm" placeholder="Nhập tên tài khoản"></asp:TextBox>
                    </div>
                    
                </div>

                
                  <div class="form-group" style="display:none">
                    <label class="col-lg-2 control-label" for="inputSmall">Tên đầy đủ</label>
                    <div class="col-lg-6">
                         <asp:RequiredFieldValidator ValidationGroup="valChangePas" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFullName"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control input-sm" placeholder="Tên đầy đủ"></asp:TextBox>
                    </div>
                    
                </div>

                  <div class="form-group" style="display:none">
                    <label class="col-lg-2 control-label" for="inputSmall">Email</label>
                    <div class="col-lg-6">
                        <asp:RegularExpressionValidator ValidationGroup="valChangePas" ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAdminEmail"
                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ValidationGroup="valChangePas" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdminEmail"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtAdminEmail" runat="server" CssClass="form-control input-sm" placeholder="Nhập Email"></asp:TextBox>
                    </div>
                     
                </div>


                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Mật khẩu cũ</label>
                    <div class="col-lg-6">                         
                        <asp:RequiredFieldValidator ValidationGroup="valChangePas" ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOldPass"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtOldPass" runat="server" CssClass="form-control input-sm" placeholder="Nhập mật khẩu cũ" TextMode="Password"></asp:TextBox>
                    </div>                    
                </div>
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Mật khẩu mới</label>
                    <div class="col-lg-6">
                         <asp:CompareValidator ValidationGroup="valChangePas" ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"
                            ControlToCompare="News_Pass" ControlToValidate="Re_Pass"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:CompareValidator>
                        <asp:RequiredFieldValidator ValidationGroup="valChangePas" ID="RequiredFieldValidator2" runat="server" ControlToValidate="News_Pass"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="News_Pass" runat="server" CssClass="form-control input-sm" placeholder="Nhập mật khẩu" TextMode="Password"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RangeValidator1" runat="server" ControlToValidate="News_Pass"
                                CssClass="text-danger" ValidationGroup="valChangePas" Text="Mật khẩu phải chứa ít nhất từ 6 đến 30 ký tự, bao gồm ít nhất 1 ký tự viết hoa, it nhất 1 ký tự số, 1 ký tự đặc biệt."
                                ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,30}$" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>                    
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Nhập lại mật khẩu</label>
                    <div class="col-lg-6">
                          <asp:RequiredFieldValidator ValidationGroup="valChangePas" ID="RequiredFieldValidator3" runat="server" ControlToValidate="Re_Pass"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="News_Pass"
                            ControlToValidate="Re_Pass" ValidationGroup="valChangePas" ErrorMessage="CompareValidator"><span class="append-icon right text-danger">Mật khẩu chưa khớp</span></asp:CompareValidator>
                         
                        <asp:TextBox ID="Re_Pass" ValidationGroup="valChangePas" runat="server" CssClass="form-control input-sm" placeholder="Nhập lại mật khẩu" TextMode="Password"></asp:TextBox>
                    </div>
                    
                </div>

             
             <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" ValidationGroup="valChangePas" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_Update_Click" />
                <asp:HyperLink ID="HyperLink11" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>

             </div>
        </div>
    </div>
</div>
</section>
<asp:HiddenField ID="hdd_Created" runat="server" />
<asp:HiddenField ID="hdd_log" runat="server" />
<asp:HiddenField ID="hddPass" runat="server" />
<asp:HiddenField ID="hddPermission" runat="server" />
<asp:HiddenField ID="hddRoles_ID" runat="server" />
<asp:HiddenField ID="hddActied" runat="server" />
<asp:HiddenField ID="hddAddress" runat="server" />
<asp:HiddenField ID="hddBirth" runat="server" />
<asp:HiddenField ID="hddSex" runat="server" />
<asp:HiddenField ID="hddNickYahoo" runat="server" />
<asp:HiddenField ID="hddNickSkype" runat="server" />
<asp:HiddenField ID="hddPhone" runat="server" />
<asp:HiddenField ID="hddImageThumb" runat="server" />
<asp:HiddenField ID="hddAdminLoginType" runat="server" />
