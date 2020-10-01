<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListNewsComment.ascx.cs"
    Inherits="Client_Admin_ListNewsComment" %>
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
            <asp:LinkButton ID="btn_listComment" runat="server" OnClick='btn_list' CssClass="pl5" title="DM Tin"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">DS Tin</span>
            </asp:LinkButton>
        </div> 

         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_editpage" runat="server" OnClick='btn_editcomment' CssClass="pl5" title="Đăng Comment"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Đăng Comment</span>
            </asp:LinkButton>
        </div> 
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_enable" runat="server" OnClick='btn_enable_Click' CssClass="pl5" title="Phê duyệt"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Phê duyệt</span>
            </asp:LinkButton>
        </div> 
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_disable" runat="server" OnClick='btn_disable_Click' CssClass="pl5" title="Từ chối"> 
                <i class="fa fa-times fs22 text-primary"></i><br /><span class="fs11">Từ chối</span>
            </asp:LinkButton>
        </div> 
        
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_delall" runat="server" OnClick='btn_delAll_Click' CssClass="pl5" title="Xóa tin"> 
                <i class="fa fa-trash-o fs22 text-primary"></i><br /><span class="fs11">Xóa tin</span>
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
            
            <asp:Literal ID="error" runat="server"></asp:Literal>
            <div class="table-responsive mb20">
            <asp:GridView ID="grvNewsComment" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="true" PageSize="1000" OnRowCommand="grvNewsComment_RowCommand"
            OnRowDataBound="grvNewsComment_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="CommentNewsID">
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
              
                    <asp:TemplateField HeaderText="Xem">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="30px" />
                        <ItemTemplate>
                             <asp:LinkButton ID="btn_view" runat="server" CommandName="_view" CommandArgument='<%# Eval("CommentNewsID") %>' ToolTip="Xem Comment">
                            <span class="glyphicons glyphicons-display fs18 text-danger" ></span>
                            </asp:LinkButton>
                   
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duyệt">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="30px" />
                        <ItemTemplate>
                             <asp:LinkButton ID="btn_approved" runat="server" CommandName="_approved" CommandArgument='<%# Eval("CommentNewsID") %>' ToolTip="Duyệt tin">
                            <span class="glyphicons glyphicons-up_arrow fs18 text-primary" ></span>
                            </asp:LinkButton>
                   
                        </ItemTemplate>
                    </asp:TemplateField>
                     

                    <asp:TemplateField HeaderText="Tiêu đề">
                        <ItemStyle CssClass="text-left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="linkTitle" runat="server" CommandName="_edit" CommandArgument='<%# Eval("CommentNewsID") %>'><%# Eval("Title")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center" />
                    </asp:TemplateField>
                   

                     <asp:BoundField DataField="FullName" HeaderText="Tên KH">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center" Width="100px" />
                    </asp:BoundField>
                    
                   
                    <asp:BoundField DataField="Email" HeaderText="Email">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="100px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="NewsTitle" HeaderText="Tin được đánh giá">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="150px" />
                    </asp:BoundField>

                     <asp:CheckBoxField DataField="Actived" HeaderText="Duyệt">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="35px" />
                    </asp:CheckBoxField>
                    
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("CommentNewsID") %>' ToolTip="Sửa tin">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("CommentNewsID") %>' ToolTip="Xóa tin">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>
           <%-- <div class="row mb20 right">
                <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
            LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
            </div>--%>

            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Thêm mới" OnClick="btn_editcomment" />
                <asp:Button runat="server" ID="Button1" CssClass="btn btn-sm btn-primary mr10" Text="Phê duyệt tin" OnClick="btn_enable_Click" />
                <asp:Button runat="server" ID="Button2" CssClass="btn btn-sm btn-primary mr10" Text="Từ chối" OnClick="btn_disable_Click" />
                <asp:Button runat="server" ID="Button5" CssClass="btn btn-sm btn-primary mr10" Text="Xóa tất cả" OnClick="btn_delAll_Click" />
                <asp:Button runat="server" ID="Button3" CssClass="btn btn-sm btn-primary mr10" Text="DM Tin" OnClick="btn_list" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>


<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hddNewsID" runat="server" />
