<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditMenuLinks.ascx.cs"
    Inherits="Admin_Controls_EditMenuLinks" %>

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
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/listmenulinks/Default.aspx" CssClass="pl5" title="Danh mục"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">Danh mục</span>
            </asp:HyperLink>
        </div>  
        <div class="topbar-icon ml15 ib va-m">
             <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/editmenulinks/Default.aspx" CssClass="pl5" title="Tạo mới"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới</span>
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
            <asp:Literal ID="clientview" runat="server"></asp:Literal>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Cấp độ</label>
                <div class="col-lg-6">
                     
                     <asp:DropDownList ID="ddlMenuLinks" runat="server" AppendDataBoundItems="True" 
                         CssClass="form-control input-sm" onselectedindexchanged="ddlMenuLinks_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>

                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Tên liên kết</label>
                <div class="col-lg-6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMenuLinksName"
                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtMenuLinksName" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên liên kết"></asp:TextBox>
                </div>
            </div>

             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Link URL</label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtMenuLinksUrl" runat="server" CssClass="form-control input-sm" placeholder="Nhập URL"></asp:TextBox>
                </div>
            </div>

             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">ICON</label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtimage4_3" runat="server" CssClass="form-control input-sm" placeholder="Chọn ảnh..."></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <input type="button" id="btnSelectImg4_3" value="Chọn ảnh" onclick="popupimage4_3();" class="btn btn-sm btn-system mr10"/>
                    <asp:Literal ID="img_thumb" runat="server"></asp:Literal>
                </div>
            </div>

             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Width</label>
                <div class="col-lg-3">
                    <asp:RangeValidator  ID="RangeValidator1" runat="server" ControlToValidate="txtWidth" ErrorMessage="RangeValidator"
                            MaximumValue="2000" MinimumValue="8" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle">(từ 8-2000 px)</i></span></asp:RangeValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWidth"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtWidth" runat="server" CssClass="form-control input-sm" placeholder="Width"></asp:TextBox>
                </div>
            </div>

             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Height</label>
                <div class="col-lg-3">
                    <asp:RangeValidator  ID="RangeValidator2" runat="server" ControlToValidate="txtHeight" ErrorMessage="RangeValidator"
                            MaximumValue="2000" MinimumValue="8" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle">(từ 8-2000 px)</i></span></asp:RangeValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHeight"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtHeight" runat="server" CssClass="form-control input-sm" placeholder="Height"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Kiểu Flash</label>
                    <div class="col-lg-6">
                            <div class="checkbox-custom pt10">
                                <asp:CheckBox ID="chkFlash" Text="Flash" Checked="false" runat="server" 
                            oncheckedchanged="chkFlash_CheckedChanged" AutoPostBack="true" />
                            </div>
                    </div>
                </div>
            
             <div class="form-group" id="panelFilename" runat="server">
                <label class="col-lg-2 control-label" for="inputSmall">File Flash</label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtFileName" runat="server" CssClass="form-control input-sm" placeholder="Chọn file flash..."></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <input type="button" id="Button1" value="Chọn file" onclick="popupFile();" class="btn btn-sm btn-system mr10"/>
                    <asp:Literal ID="ltlFileName" runat="server"></asp:Literal>

                </div>
            </div>

            <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Trạng thái</label>
                    <div class="col-lg-6">
                            <div class="checkbox-custom pt10">
                                <asp:CheckBox ID="rdbStatus" Text="Hoạt động" runat="server" />
                            </div>
                    </div>
                </div>

                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Hiển thị</label>
                    <div class="col-lg-6">
                            <div class="checkbox-custom pt10">
                                <asp:CheckBox ID="rdbIsView" Text="Trang chủ" runat="server" />
                            </div>
                    </div>
                </div>

                 <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Vị trí Icon</label>
                <div class="col-lg-3">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPosition"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control input-sm" placeholder="Nhập vị trí"></asp:TextBox>
                </div>
            </div>

             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Targer</label>
                <div class="col-lg-3">
                     
                     <asp:DropDownList ID="ddlTarget" runat="server" AppendDataBoundItems="True" 
                         CssClass="form-control input-sm">
                         <asp:ListItem Value="_blank" Text="_blank"></asp:ListItem>
                            <asp:ListItem Value="_parent" Text="_parent"></asp:ListItem>
                            <asp:ListItem Value="_search" Text="_search"></asp:ListItem>
                            <asp:ListItem Value="_self" Text="_self"></asp:ListItem>
                            <asp:ListItem Value="_top" Text="_top"></asp:ListItem>
                    </asp:DropDownList>

                </div>
            </div>

       

             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Mô tả</label>
                <div class="col-lg-6">
                    <asp:TextBox ID="txtRadHelp" runat="server" CssClass="form-control input-sm" Height="200px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />
                <asp:Button runat="server" ID="btn_add2" CssClass="btn btn-sm btn-primary mr10" Text="Lưu & thêm mới" OnClick="btn_add_Click_more" />
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click" />
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Admin/listmenulinks/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Danh mục" />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/editmenulinks/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>

            </div>
        </div>
    </div>
   

</div>
</section>


<asp:HiddenField ID="txtMenuLinksID" runat="server" />
<asp:HiddenField ID="hddIcon" runat="server" />
<asp:HiddenField ID="hddFile" runat="server" />
<asp:HiddenField ID="hddHit" runat="server" />

<script type="text/javascript">
    function popupimage4_3() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#<%= txtimage4_3.ClientID %>").val(fileUrl);
        };
        finder.popup();
    }
    function popupFile() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#<%= txtFileName.ClientID %>").val(fileUrl);
        };
        finder.popup();
    }
 
</script>