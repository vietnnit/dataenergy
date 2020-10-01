<%@ Control Language="C#" AutoEventWireup="true" CodeFile="editadmin.ascx.cs" Inherits="Admin_Controls_CreateAdmincontent" %>

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
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/listadmin/Default.aspx" CssClass="pl5" title="DS User"> 
                <i class="fa fa-group fs22 text-primary"></i><br /><span class="fs11">DS User</span>
            </asp:HyperLink>
        </div> 

         <div class="topbar-icon ml15 ib va-m">
            <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editadmin/Default.aspx" CssClass="pl5" title="Tạo mới"> 
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
                        <label class="col-lg-2 control-label pt5" for="inputSmall">Kiểu tài khoản CMS/(AD)</label>
                        <div class="col-lg-3">
                                <div class="checkbox-custom pt5">
                                    <asp:CheckBox ID="rdbLoginType" Text="Tài khoản CMS" runat="server" />
                                </div>
                        </div>
                    </div>                                    
                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tên tài khoản</label>
                    <div class="col-lg-6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdminName" ValidationGroup="valUser"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtAdminName" runat="server" CssClass="form-control input-sm"  ValidationGroup="valUser"></asp:TextBox>
                    </div>
                    
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Mật khẩu</label>
                    <div class="col-lg-6">
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ValidationGroup="valUser"
                            ControlToCompare="txtAdminPass" ControlToValidate="Re_Pass"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdminPass" ValidationGroup="valUser"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>

                        <asp:TextBox ID="txtAdminPass" runat="server" CssClass="form-control input-sm" ValidationGroup="valUser" TextMode="Password"></asp:TextBox>
                    </div>                    
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Nhập lại mật khẩu</label>
                    <div class="col-lg-6">
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Re_Pass" ValidationGroup="valUser"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtAdminPass"
                            ControlToValidate="Re_Pass" ErrorMessage="CompareValidator" ValidationGroup="valUser"><span class="append-icon right text-danger">Mật khẩu chưa khớp</span></asp:CompareValidator>

                        <asp:TextBox ID="Re_Pass" runat="server" CssClass="form-control input-sm" ValidationGroup="valUser" TextMode="Password"></asp:TextBox>
                    </div>
                    
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Email</label>
                    <div class="col-lg-6">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAdminEmail" ValidationGroup="valUser"
                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdminEmail"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtAdminEmail" runat="server" CssClass="form-control input-sm" ValidationGroup="valUser"></asp:TextBox>
                    </div>
                     
                </div>

                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tên đầy đủ</label>
                    <div class="col-lg-6">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFullName"
                            ErrorMessage="RequiredFieldValidator" ValidationGroup="valUser"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control input-sm" ></asp:TextBox>
                    </div>
                    
                </div>                
                <div class="form-group">
                    <label class="col-lg-2 control-label pt5" for="inputSmall">Đơn vị</label>                
                    <div class="col-lg-6">
                        <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control input-sm" ></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group" style="display:none">
                    <label class="col-lg-2 control-label" for="inputSmall">Ngày sinh</label>
                    <div class="col-lg-4">
                        <div class="input-group  input-group-sm">
                        <asp:TextBox ID="txtBirth" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        <span class="input-group-addon field-icon"><i class="fa fa-calendar"></i>
                          </span>
                          </div>
                     </div>
                 
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Giới tính</label>
                    <div class="col-lg-10">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbSex" runat="server" Text="Nam/Nữ"/>
                            </div>
                    </div>
                </div>


                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Điện thoại</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    
                </div>
                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Địa chỉ</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Nick Yahoo</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtNickYahoo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Nick Skype</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtNickSkype" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Ảnh đại diện</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtimage4_3" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <input type="button" value="Chọn ảnh" onclick="popupimage4_3();" class="btn btn-sm btn-system mr10"/>
                        <asp:Literal ID="img_thumb" runat="server"></asp:Literal>
                    </div>
                </div>

            <hr />

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Trạng thái</label>
                    <div class="col-lg-10">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbList" runat="server" Text="Hoạt động"/>
                            </div>
                    </div>
                </div>

             <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Phân quyền người dùng</label>
                <div class="col-lg-6">
                    <div class="checkbox-custom pt5">
                    <asp:CheckBoxList ID="chklist" runat="server"  RepeatDirection="Horizontal" >
                     </asp:CheckBoxList>
                     </div>
                </div>
                
            </div>

             <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" ValidationGroup="valUser"/>
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click" ValidationGroup="valUser"/>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/editadmin/Default.aspx" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/listadmin/Default.aspx" Text="DS User" />
                       
                <asp:HyperLink ID="HyperLink11" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>

             </div>
        </div>
    </div>
</div>
</section>



<asp:HiddenField ID="hddAdmin_Id" runat="server" />
<asp:HiddenField ID="hddAdmin_Username" runat="server" />
<asp:HiddenField ID="hdd_Created" runat="server" />
<asp:HiddenField ID="hdd_log" runat="server" />
<asp:HiddenField ID="hddPass" runat="server" />
<asp:HiddenField ID="hddImageThumb" runat="server" />

<asp:HiddenField ID="hddPostDate" runat="server" />


<script type="text/javascript">
    $(document).ready(function () {
        var time = $("#<%=hddPostDate.ClientID%>").val();

        $("#<%=txtBirth.ClientID%>").datetimepicker({
            format: 'd/m/Y H:i',
            value: time
        });
    });

    function popupimage4_3() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#<%= txtimage4_3.ClientID %>").val(fileUrl);
        };
        finder.popup();
    }
</script>
