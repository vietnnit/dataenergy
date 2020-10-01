<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditNewsFiles.ascx.cs"
    Inherits="Client_Admin_EditNewsFiles" %>

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
         <div class="topbar-icon ib va-m">
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick='btn_listnewsgroup' CssClass="pl5" title="DS Tin"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">DS Tin</span>
            </asp:LinkButton>
        </div>

        <div class="topbar-icon ib va-m">
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick='btn_listfile' CssClass="pl5" title="DS Files"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">DS Files</span>
            </asp:LinkButton>
        </div>
        
        <div class="topbar-icon ib va-m">
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick='btn_editfile' CssClass="pl5" title="Thêm Files"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm Files</span>
            </asp:LinkButton>
        </div>
       
         <div class="topbar-icon ib va-m">
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
            <asp:Literal ID="clientview" runat="server"></asp:Literal>
            <div class="col-lg-9">
                 <div class="form-horizontal">
                   
                   <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">Tên Files</label>
                        <div class="col-lg-10">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên Albums"></asp:TextBox>
                        </div>
                    </div>

                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Chọn Files</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="txtFileName" runat="server" CssClass="form-control input-sm" placeholder="Chọn file..."></asp:TextBox>
                    </div>
                    <div class="col-lg-3">
                        <input type="button" value="Chọn Files" onclick="popupFile();" class="btn btn-sm btn-system mr10"/>
                    </div>
                </div>

            </div>
            </div>
            <div class="col-lg-3">
                <div class="table-responsive mb20">
                        <asp:GridView ID="grvFiles" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
                            AllowPaging="true" PageSize="1000" OnPageIndexChanging="grvFiles_PageIndexChanging" OnRowCommand="grvFiles_RowCommand"
                            OnRowDataBound="grvFiles_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                                <HeaderStyle CssClass="primary fs12" />

                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="NewsGroupFileID">
                                        <ItemStyle CssClass="text-center" />
                                        <HeaderStyle CssClass="text-center" Width="30px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemStyle CssClass="text-center" />
                                        <HeaderStyle CssClass="text-center" Width="40px" />
                                        <ItemTemplate>
                                                <asp:CheckBox ID="chkId" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                    
                                    <asp:TemplateField HeaderText="Tên File">
                                        <ItemStyle CssClass="text-left" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkTitle" runat="server" CommandName="_edit" CommandArgument='<%# Eval("NewsGroupFileID") %>'><%# Eval("Title")%></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="text-center" />
                                    </asp:TemplateField>
                   
                                  <asp:TemplateField HeaderText="File">
                                        <ItemStyle CssClass="text-center" />
                                        <HeaderStyle CssClass="text-center" Width="40px" />
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("FileName") %>' ToolTip='<%# Eval("FileName") %>'>
                                                <span class="fa fa-floppy-o text-primary fs18" ></span>
                                            </asp:HyperLink>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                  
                                    <asp:TemplateField HeaderText="Chức năng">
                                        <ItemStyle CssClass="text-center" />
                                        <HeaderStyle CssClass="text-center" Width="60px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("NewsGroupFileID") %>' ToolTip="Sửa File">
                                            <span class="glyphicons glyphicons-edit fs18" ></span>
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("NewsGroupFileID") %>' ToolTip="Xóa File">
                                            <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                    </div>
            </div>

            <div class="form-group">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click" />
                <asp:Button runat="server" ID="btn_edit2" CssClass="btn btn-sm btn-primary mr10" Text="Thêm File mới" OnClick="btn_editfile" />
                <asp:Button runat="server" ID="Button1" CssClass="btn btn-sm btn-primary mr10" Text="DS Files" OnClick="btn_listfile" />
                <asp:Button runat="server" ID="Button2" CssClass="btn btn-sm btn-primary mr10" Text="DS Tin" OnClick="btn_listnewsgroup" />
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>


        </div>
    </div>
   

</div>
</section>
<asp:HiddenField ID="hddNewsGroupFileID" runat="server" />
<asp:HiddenField ID="hddNewsGroupID" runat="server" />
<asp:HiddenField ID="hddFileName" runat="server" />
<asp:HiddenField ID="hddTitle" runat="server" />

<script type="text/javascript">
    function popupFile() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#<%= txtFileName.ClientID %>").val(fileUrl);
        };
        finder.popup();
    }
 
</script>