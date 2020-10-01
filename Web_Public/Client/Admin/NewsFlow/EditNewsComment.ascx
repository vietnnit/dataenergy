<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditNewsComment.ascx.cs"
    Inherits="Client_Admin_EditNewsComment" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
            <asp:LinkButton ID="btn_listnews" runat="server" OnClick='btn_list' CssClass="pl5" title="Comment"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">DS Comment</span>
            </asp:LinkButton>
        </div> 

         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_editpage" runat="server" OnClick='btn_editcomment' CssClass="pl5" title="Thêm mới"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới</span>
            </asp:LinkButton>
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
                    <asp:Literal ID="clientview" runat="server"></asp:Literal>
        
                                     
                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tiêu đề</label>
                    <div class="col-lg-10">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control input-sm" placeholder="Nhập tiêu đề"></asp:TextBox>
                    </div>
                   
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tên KH</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control input-sm" placeholder="Tên khách hàng"></asp:TextBox>
                    </div>
                     
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Email</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm" placeholder="Email"></asp:TextBox>
                    </div>
                     
                </div>

             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Nội dung Comment</label>
                <div class="col-lg-10">
                    <CKEditor:CKEditorControl ID="txtContent" runat="server" Height="400px" CssClass="form-control input-sm" Language="en">
                        </CKEditor:CKEditorControl>                 
                           
                </div>
            </div>


            <hr />

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Duyệt Comment</label>
                    <div class="col-lg-10">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbActive" runat="server" Text="Phê duyệt"/>
                            </div>
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Ngày gửi</label>
                    <div class="col-lg-4">
                        <div class="input-group  input-group-sm">
                        <asp:TextBox ID="txtDateCreated" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        <span class="input-group-addon field-icon"><i class="fa fa-calendar"></i>
                          </span>
                          </div>
                     </div>
                 
                </div>
           

             <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click" />
                <asp:Button runat="server" ID="btn_list1" CssClass="btn btn-sm btn-primary mr10" Text="Thêm mới" OnClick="btn_editcomment" />
                <asp:Button runat="server" ID="btn_create1" CssClass="btn btn-sm btn-primary mr10" Text="DS Tin" OnClick="btn_list" />
                       
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>

             </div>
        </div>
    </div>
</div>
</section>
<asp:HiddenField ID="hddCommentID" runat="server" />
<asp:HiddenField ID="hddNewsID" runat="server" />
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hddApprovalUserName" runat="server" />
<asp:HiddenField ID="hddApprovalDate" runat="server" />
<asp:HiddenField ID="hddPostDate" runat="server" />
<script type="text/javascript">
    $(document).ready(function () {
        var time = $("#<%=hddPostDate.ClientID%>").val();

        $("#<%=txtDateCreated.ClientID%>").datetimepicker({
            format: 'd/m/Y H:i',
            value: time
        });
    });
</script>
