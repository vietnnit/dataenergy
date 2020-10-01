<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditCateNews.ascx.cs"
    Inherits="Admin_Controls_EditCateNews" %>

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
            <asp:LinkButton ID="btn_list" runat="server" OnClick='btn_list_click' CssClass="pl5" title="Danh mục"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">Danh mục</span>
            </asp:LinkButton>
        </div>
        <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_create" runat="server" OnClick='btn_create_click' CssClass="pl5" title="Thêm mới"> 
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
                <label class="col-lg-2 control-label pt5" for="inputSmall">Cấp độ danh mục</label>
                <div class="col-lg-6">
                     
                     <asp:DropDownList ID="ddlCateNews" runat="server" AppendDataBoundItems="True" 
                         CssClass="form-control input-sm">
                        
                    </asp:DropDownList>

                </div>
            </div>


            <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Tên danh mục</label>
                
                <div class="col-lg-6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCateNewsName"
                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtCateNewsName" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên danh mục"></asp:TextBox>
                </div>
            </div>


             <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Tên viết tắt</label>
                
                <div class="col-lg-6">
                    <asp:TextBox ID="txtShortName" runat="server" CssClass="form-control input-sm" placeholder="Tên viết tắt"></asp:TextBox>
                </div>
            </div>

            <hr />

             <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Chọn PageLayout</label>
                <div class="col-lg-3">
                     
                     <asp:DropDownList ID="ddlPageLayout" runat="server" AppendDataBoundItems="True" 
                         CssClass="form-control input-sm">
                        
                    </asp:DropDownList>

                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Nhóm danh mục</label>
                
                <div class="col-lg-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGroupCate"
                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtGroupCate" runat="server" CssClass="form-control input-sm" placeholder="GroupCate"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                    <label class="col-lg-2 control-label pt5" for="inputSmall">Trạng thái</label>
                    <div class="col-lg-3">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbStatus" Checked="true" Text="Hiển thị/Ẩn" runat="server" />
                            </div>
                    </div>
                </div>


            <div class="form-group">
                    <label class="col-lg-2 control-label pt5" for="inputSmall">Liên kết ngoài</label>
                    <div class="col-lg-3">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbType" Text="is Url" runat="server" 
                            oncheckedchanged="rdbType_CheckedChanged" AutoPostBack="true" />
                            </div>
                    </div>
                </div>

            <div class="form-group" id="panelUrl" runat="server">
                <label class="col-lg-2 control-label pt5" for="inputSmall">URL</label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control input-sm" placeholder="Nhập URL..."></asp:TextBox>
                </div>
                
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">ICON</label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtimage4_3" runat="server" CssClass="form-control input-sm" placeholder="Chọn ảnh..."></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <input type="button" id="btnSelectImg4_3" value="Chọn ảnh" onclick="popupimage4_3();" class="btn btn-sm btn-system mr10"/>
                    <asp:Literal ID="img_thumb" runat="server"></asp:Literal>
                </div>
            </div>

             <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Mô tả</label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtSlogan" runat="server" CssClass="form-control input-sm" Height="200px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />
                <asp:Button runat="server" ID="btn_add2" CssClass="btn btn-sm btn-primary mr10" Text="Lưu & thêm mới" OnClick="btn_add_Click_more" />
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click" />
                <asp:Button runat="server" ID="btn_list1" CssClass="btn btn-sm btn-primary mr10" Text="Thêm mới" OnClick="btn_create_click" />
                <asp:Button runat="server" ID="btn_create1" CssClass="btn btn-sm btn-primary mr10" Text="Danh mục" OnClick="btn_list_click" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/listcatenewsselect/Default.aspx" Text="Chuyên mục" />
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>

            </div>
        </div>
    </div>
   

</div>
</section>



<asp:HiddenField ID="hddCateNewsID" runat="server" />
<asp:HiddenField ID="hddParentID" runat="server" />
<asp:HiddenField ID="hddCateNewsTotal" runat="server" />
<asp:HiddenField ID="hddCateNewsOrder" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
<asp:HiddenField ID="HddGroupCate" runat="server" />
<asp:HiddenField ID="hddRoles" runat="server" />
<asp:HiddenField ID="hddUserName" runat="server" />
<asp:HiddenField ID="hddCreated" runat="server" />

<script type="text/javascript">
    function popupimage4_3() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#<%= txtimage4_3.ClientID %>").val(fileUrl);
        };
        finder.popup();
    }

</script>