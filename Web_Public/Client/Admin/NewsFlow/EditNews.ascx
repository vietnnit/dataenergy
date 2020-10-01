<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditNews.ascx.cs" Inherits="Client_Admin_EditNews" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
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
            <asp:LinkButton ID="btn_listnews" runat="server" OnClick='btn_list_click' CssClass="pl5" title="DS Tin"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">DS Tin</span>
            </asp:LinkButton>
        </div> 

         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_editpage" runat="server" OnClick='btn_create_click' CssClass="pl5" title="Đăng tin"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Đăng tin</span>
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
    
  <div class="tab-block mb25">
    <ul class="nav nav-tabs tabs-border">
      
        <li class="active"><a href="#tab1" data-toggle="tab" aria-expanded="true">Nội dung tin</a></li>
        <li><a href="#tab2" data-toggle="tab" aria-expanded="false">Log</a></li>
       
        
    </ul>

    <div class="tab-content">
        <div id="tab1" class="tab-pane active">
            <div class="form-horizontal">
                    <asp:Literal ID="clientview" runat="server"></asp:Literal>
        
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">Lựa chọn chuyên mục</label>
                        <div class="col-lg-6">
                     
                             <asp:DropDownList ID="ddlCateNewsGroup" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                             OnSelectedIndexChanged="ddlCateNewsGroup_SelectedIndexChanged" AutoPostBack="True" >
                            </asp:DropDownList>

                        </div>
                    </div>

                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">Lựa chọn tiểu mục</label>
                        <div class="col-lg-6">
                     
                             <asp:DropDownList ID="ddlCateNews" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm">
                            </asp:DropDownList>

                        </div>
                    </div>
                 
                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tiêu đề</label>
                    <div class="col-lg-9">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control input-sm" placeholder="Nhập tiêu đề"></asp:TextBox>
                    </div>
                     <div class="col-lg-1">
                        <asp:Button runat="server" ID="btnTags" CssClass="btn btn-sm btn-primary mr10" Text="Tags" OnClick="btnTags_Click"/>
                     </div>
                </div>

                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Tiêu đề ngắn gọn</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="txtShortTitle" runat="server" CssClass="form-control input-sm" placeholder="Tiêu đề ngắn gọn"></asp:TextBox>
                    </div>
                     
                </div>

                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Slug</label>
                    <div class="col-lg-9">
                        <asp:TextBox ID="txtSlug" runat="server" CssClass="form-control input-sm" placeholder="Tiêu đề ngắn gọn"></asp:TextBox>
                    </div>
                    
                </div>

                  <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Ảnh (4x3)</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtimage4_3" runat="server" CssClass="form-control input-sm" placeholder="Chọn ảnh..."></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <input type="button" value="Chọn ảnh" onclick="popupimage4_3();" class="btn btn-sm btn-system mr10"/>
                        <asp:Literal ID="img_thumb" runat="server"></asp:Literal>
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">Ảnh (16x9)</label>
                    <div class="col-lg-6">
                        <asp:TextBox ID="txtimage16_9" runat="server" CssClass="form-control input-sm" placeholder="Chọn ảnh..."></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <input type="button" value="Chọn ảnh" onclick="popupimage16_9();" class="btn btn-sm btn-system mr10"/>
                        <asp:Literal ID="img_large" runat="server"></asp:Literal>
                    </div>
                </div>

              <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Mô tả tin</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtRadShort" runat="server" CssClass="form-control input-sm" Height="100px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div> 

             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Nội dung tin</label>
                <div class="col-lg-10">
                    <CKEditor:CKEditorControl ID="txtRadFull" runat="server" Height="400px" CssClass="form-control input-sm" Language="en">
                        </CKEditor:CKEditorControl>                 
                           
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Tags</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtTags" runat="server" CssClass="form-control input-sm" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div> 
             <div class="form-group">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Keyword</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="form-control input-sm" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div> 

            <hr />

                <div class="form-group">
                    <label class="col-lg-2 col-md-2 control-label" for="inputSmall">Loại tin</label>
                    <div class="col-lg-10 col-md-10">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbIshot" runat="server" Text="Tin nổi bật"/>
                            </div>
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbTypeNews" runat="server" Text="Tin đầy đủ"/>
                            </div>
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbIshome" runat="server" Text="Tin mới"/>
                            </div>
                    </div>
                </div>
                 <div class="form-group">
                    <label class="col-lg-2 col-md-2 control-label" for="inputSmall">Đăng nhận xét/Chia sẻ</label>
                    <div class="col-lg-10 col-md-10">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbComment" runat="server" Text="Đăng comment"/>
                            </div>
                    </div>
                </div>
                 <div class="form-group">
                    <label class="col-lg-2 col-md-2 control-label" for="inputSmall">Xuất bản bài viết</label>
                    <div class="col-lg-10 col-md-10">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbStatus" runat="server" Text="Hiển thị"/>
                            </div>
                    </div>
                </div>

                

                <div class="form-group">
                    <label class="col-lg-2 col-md-2 control-label" for="inputSmall">Duyệt bài</label>
                    <div class="col-lg-10 col-md-10">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="rdbApproval" runat="server" Text="Đồng ý"/>
                            </div>
                    </div>
                </div>

                 <div class="form-group">
                    <label class="col-lg-2 col-md-2 control-label" for="inputSmall">Ngày đăng</label>
                    <div class="col-lg-4 col-md-4">
                        <div class="input-group  input-group-sm">
                        <asp:TextBox ID="txtRadDate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        <span class="input-group-addon field-icon"><i class="fa fa-calendar"></i>
                          </span>
                          </div>
                     </div>
                 
                </div>

             <div class="form-group">
                <label class="col-lg-2 control-label" for="inputSmall">Tác giả</label>
                <div class="col-lg-6">
                      <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control input-sm" placeholder="Tên tác giả"></asp:TextBox>
                </div>
            </div>


            <div class="form-group">
                    <label class="col-lg-2 control-label pt5" for="inputSmall">Link liên kết ngoài</label>
                    <div class="col-lg-3">
                            <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="chkUrl" Text="isUrl" runat="server" 
                            oncheckedchanged="chkUrl_CheckedChanged" AutoPostBack="true" />
                            </div>
                    </div>
                </div>

            <div class="form-group" id="panelUrl" runat="server">
                <label class="col-lg-2 col-md-2 control-label pt5" for="inputSmall">URL</label>
                <div class="col-lg-6 col-md-6"> 
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control input-sm" placeholder="Nhập URL..."></asp:TextBox>
                </div>
                
            </div>

             <div class="form-group" id="panelMutiCate" runat="server" visible="false">
                <label class="col-lg-2 control-label pt5" for="inputSmall">Nhóm chuyên mục</label>
                <div class="col-lg-6">
                    <asp:CheckBoxList ID="chkCateNews" runat="server" CssClass="text_checkbox" Visible="false">
                     </asp:CheckBoxList>
                </div>
                
            </div>

            <hr />
            <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <label class="col-lg-4 col-md-4 col-sm-4 control-label pt5" for="inputSmall">Chọn chuyên mục</label>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:ListBox ID="lboGroupCate" runat="server" Height="200px" 
                                onselectedindexchanged="lboGroupCate_SelectedIndexChanged" AutoPostBack="true"
                                CssClass="form-control input-sm" ValidationGroup="update">
                                </asp:ListBox>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:ListBox ID="lboCateNews" runat="server" Height="200px" 
                                CssClass="form-control input-sm" ValidationGroup="update">
                                </asp:ListBox>
                            </div>
                        </div>
                     </div>
                     <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="form-group">
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-sm btn-primary mr10" Text=">>" OnClick="btn_add_list" ValidationGroup="list"/><br />
                                <asp:LinkButton runat="server" ID="LinkButton2" CssClass="btn btn-sm btn-primary mr10" Text="<<" OnClick="btn_remove_list" ValidationGroup="list"/>
                            </div>
                             <div class="col-lg-8 col-md-8 col-sm-8">
                                <asp:ListBox ID="lboCateSelect" runat="server" Height="200px" 
                                CssClass="form-control input-sm" ValidationGroup="update">
                                </asp:ListBox>
                            </div>  
                            
                        </div>
                     </div>
                  </div>


             <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />
                <asp:Button runat="server" ID="btn_add2" CssClass="btn btn-sm btn-primary mr10" Text="Lưu & thêm mới" OnClick="btn_add_Click_more" />
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click" />
                <asp:Button runat="server" ID="btn_list1" CssClass="btn btn-sm btn-primary mr10" Text="Thêm mới" OnClick="btn_create_click" />
                <asp:Button runat="server" ID="btn_create1" CssClass="btn btn-sm btn-primary mr10" Text="DS Tin" OnClick="btn_list_click" />
                       
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>

             </div>
        </div>

        <div id="tab2" class="tab-pane">
            <div class="table-responsive mb20">
            <asp:GridView ID="grvNewsLog" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="false"  OnRowCommand="grvNewsLog_RowCommand"
            OnRowDataBound="grvNewsLog_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="NewsLogID">
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
                    <asp:BoundField HeaderText="NewsGroupID" DataField="NewsGroupID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="60px" />
                    </asp:BoundField>
                   
                    <asp:TemplateField HeaderText="Xem">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="30px" />
                        <ItemTemplate>
                             <asp:LinkButton ID="btn_view" runat="server" CommandName="_view" CommandArgument='<%# Eval("NewsLogID") %>' ToolTip="Sửa nhóm chuyên mục">
                            <span class="glyphicons glyphicons-display fs18 text-danger" ></span>
                            </asp:LinkButton>
                   
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Phiên bản">
                        <ItemStyle Width="35px" CssClass="text-center" />
                        <HeaderStyle Width="35px" CssClass="text-center" />
                        <ItemTemplate>
                            V<%# Eval("Version") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tiêu đề tin">
                        <ItemStyle CssClass="text-left" />
                        <ItemTemplate>
                            <%# Eval("Title")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center" />
                    </asp:TemplateField>
                   

                  
                    <asp:BoundField DataField="CreatedUserName" HeaderText="Người đăng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="80px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="PostDate" HeaderText="Ngày đăng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="120px" />
                    </asp:BoundField>

                      <asp:BoundField DataField="ModifyUserName" HeaderText="Người sửa">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="80px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="ModifyDate" HeaderText="Ngày sửa">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="120px" />
                    </asp:BoundField>

                     <asp:CheckBoxField DataField="IsApproval" HeaderText="Duyệt">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="35px" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="Status" HeaderText="Hoạt động">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="35px" />
                    </asp:CheckBoxField>
                   
                   
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("NewsLogID") %>' ValidationGroup="NewsLog" ToolTip="Phục hồi">
                                    <span class="glyphicons glyphicons-unshare fs18 text-danger" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("NewsLogID") %>'  ValidationGroup="NewsLog" ToolTip="Xóa tin">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>
            <div class="row mb20 right">
                <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
            LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
            </div>
        </div>
    </div>
</div>
</section>
<asp:HiddenField ID="hddNewsGroupID" runat="server" />
<asp:HiddenField ID="hddImageThumb" runat="server" />
<asp:HiddenField ID="hddImageLarge" runat="server" />
<asp:HiddenField ID="hddFileName" runat="server" />
<asp:HiddenField ID="hddParentNewsID" runat="server" />
<asp:HiddenField ID="hddRelationTotal" runat="server" />
<asp:HiddenField ID="hddCommentTotal" runat="server" />
<asp:HiddenField ID="hddIsView" runat="server" />
<asp:HiddenField ID="hddCreateUserName" runat="server" />
<asp:HiddenField ID="hddApprovalUserName" runat="server" />
<asp:HiddenField ID="hddApprovalDate" runat="server" />
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hddisDelete" runat="server" />
<asp:HiddenField ID="hddPostDate" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<script type="text/javascript">
    $(document).ready(function () {
        var time = $("#<%=hddPostDate.ClientID%>").val();

        $("#<%=txtRadDate.ClientID%>").datetimepicker({
            format: 'd/m/Y H:i',
            value: time
        });
    });

    function popupimage4_3() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#<%= txtimage4_3.ClientID %>").val(fileUrl);
            // var img = document.createElement("IMG");
            //img.src = fileUrl;
            // img.width = 48;
            // document.getElementById('image').appendChild(img);
        };
        finder.popup();
    }

    function popupimage16_9() {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#<%= txtimage16_9.ClientID %>").val(fileUrl);
        };
        finder.popup();
    }

</script>
