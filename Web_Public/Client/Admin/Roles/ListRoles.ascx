<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListRoles.ascx.cs" Inherits="Admin_Controls_ListRoles" %>
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
            <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/EditRoles/Default.aspx" CssClass="pl5" title="Tạo mới"> 
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
            
            <asp:Literal ID="error" runat="server"></asp:Literal>
            <div class="table-responsive mb20">
            <asp:GridView ID="grvRoles" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="true" PageSize="1000" OnRowCommand="grvRoles_RowCommand"
            OnRowDataBound="grvRoles_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Roles_ID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="40px" />
                    </asp:BoundField>
                   
                   

                    <asp:TemplateField HeaderText="Tên nhóm quyền">
                        <ItemStyle CssClass="text-left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="linkTitle" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Roles_ID") %>'><%# Eval("Roles_Name")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center" />
                    </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Phân quyền chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_module" runat="server" CommandName="module" CommandArgument='<%# Eval("Roles_ID") %>' ToolTip="Phân quyền chức năng">
                                    <span class="glyphicons glyphicons-show_big_thumbnails fs18 text-system" ></span>
                                    </asp:LinkButton>
                                   
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Phân quyền chuyên mục">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="80px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_rules0" runat="server" CommandName="rules0" CommandArgument='<%# Eval("Roles_ID") %>' ToolTip="Phân quyền nhóm chuyên mục">
                                    <span class="glyphicon glyphicon-th-list fs18 text-primary" ></span>
                                    </asp:LinkButton>
                             <asp:LinkButton ID="btn_rules" runat="server" CommandName="rules" CommandArgument='<%# Eval("Roles_ID") %>' ToolTip="Phân quyền chuyên mục">
                                    <span class="glyphicons glyphicons-list fs18 text-system" ></span>
                                    </asp:LinkButton>       
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Thêm tài khoản">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="40px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_user" runat="server" CommandName="user" CommandArgument='<%# Eval("Roles_ID") %>' ToolTip="Thêm tài khoản">
                                    <span class="glyphicons glyphicons-user_add fs18 text-danger" ></span>
                                    </asp:LinkButton>
                                   
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Roles_ID") %>' ToolTip="Sửa Roles">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Roles_ID") %>' ToolTip="Xóa Roles">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Admin/EditRoles/Default.aspx" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>