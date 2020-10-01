<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListMemberOrg.ascx.cs" Inherits="Admin_Member_ListMemberOrg" %>
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
            <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editMemberforOrg/Default.aspx" CssClass="pl5" title="Tạo mới"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Tạo mới</span>
            </asp:HyperLink>
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
               
                <div class="row">
                   
                        
                         <div class="form-group">
                         
                            <label class="col-lg-2 control-label pt5" for="inputSmall">Doanh nghiệp</label>
                            <div class="col-lg-4">
                                 <asp:DropDownList ID="ddlEnterprise" runat="server" AppendDataBoundItems="True"
                                     CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                            
                            <label class="col-lg-2 control-label pt5" for="inputSmall">Tài khoản</label>
                            <div class="col-lg-4">
                                    <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Nhập tài khoản"></asp:TextBox>
                            </div>                                               
                             <div class="col-lg-3">
                                <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm" OnClick="btn_search_Click" />
                             </div>
                        </div>
                     
                </div>
               
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body">
            
            <asp:Literal ID="ltTotal" runat="server"></asp:Literal>
            <div class="table-responsive mb20">
            <asp:GridView ID="grvAdmin" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="true" PageSize="1000" OnRowCommand="grvAdmin_RowCommand"
            OnRowDataBound="grvAdmin_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="30px" />
                    </asp:BoundField>                                     
                    <asp:TemplateField HeaderText="Tên đăng nhập">
                        <ItemStyle CssClass="text-left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="linkTitle" runat="server" CommandName="edit" CommandArgument='<%# Eval("Id") %>'><%# Eval("AccountName")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center" />
                    </asp:TemplateField>                  
                     <asp:BoundField DataField="FullName" HeaderText="Tên đầy đủ">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center" Width="180px" />
                    </asp:BoundField>                                       
                    <asp:BoundField DataField="Email" HeaderText="Email">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Phone" HeaderText="Phone">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center" Width="150px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="EnterpriseName" HeaderText="Doanh nghiệp/Cơ sở">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center" Width="150px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="OrgranizationName" HeaderText="Sở Công thương">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center" Width="150px" />
                    </asp:BoundField>
                    <asp:CheckBoxField DataField="IsActive" HeaderText="Trạng thái">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="45px" />
                    </asp:CheckBoxField>
    
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Id") %>' ToolTip="Sửa thành viên">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btn_delete" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa tài khoản này không?');" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa thành viên">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="row mb20 right">
                    <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                </div>
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Admin/editMemberforOrg/Default.aspx" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>
