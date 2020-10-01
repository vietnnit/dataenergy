<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listadmin.ascx.cs" Inherits="Admin_Controls_ListAdmin" %>

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
            <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editadmin/Default.aspx" CssClass="pl5" title="Tạo mới"> 
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
                   <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Từ khóa</label>
                            <div class="col-lg-8">
                                 <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Nhập từ khóa"></asp:TextBox>
                            </div>
                        </div>
                     </div>
                      <div class="col-lg-6">
                         <div class="form-group">
                            <label class="col-lg-3 control-label pt5" for="inputSmall">Tìm theo</label>
                            <div class="col-lg-6">
                                 <asp:DropDownList ID="ddlRoles" runat="server" AppendDataBoundItems="True"
                                     CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                             <div class="col-lg-3">
                                <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm" OnClick="btn_search_Click" />
                             </div>
                        </div>
                     </div>
                </div>
               
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body">
            
            <asp:Literal ID="error" runat="server"></asp:Literal>
            <div class="table-responsive mb20">
            <asp:GridView ID="grvAdmin" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="true" PageSize="1000" OnRowCommand="grvAdmin_RowCommand"
            OnRowDataBound="grvAdmin_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Admin_ID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="30px" />
                    </asp:BoundField>
                   
                   

                    <asp:TemplateField HeaderText="Tên đăng nhập">
                        <ItemStyle CssClass="text-left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="linkTitle" runat="server" CommandName="edit" CommandArgument='<%# Eval("Admin_ID") %>'><%# Eval("Admin_Username")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center" />
                    </asp:TemplateField>
                  

                     <asp:BoundField DataField="Admin_FullName" HeaderText="Tên đầy đủ">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center" Width="180px" />
                    </asp:BoundField>
                    
                   
                    <asp:BoundField DataField="Admin_Email" HeaderText="Email">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Admin_Permission" HeaderText="Quyền">
                        <ItemStyle CssClass="text-left" />
                        <HeaderStyle CssClass="text-center" />
                    </asp:BoundField>

                    
                    <asp:CheckBoxField DataField="Admin_Actived" HeaderText="Trạng thái">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="45px" />
                    </asp:CheckBoxField>

                     <asp:CheckBoxField DataField="Admin_LoginType" HeaderText="Login Domain">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="45px" />
                    </asp:CheckBoxField>
                   
                    <asp:TemplateField HeaderText="Phân quyền">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="40px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_user" runat="server" CommandName="user" CommandArgument='<%# Eval("Admin_ID") %>' ToolTip="Phân quyền">
                                    <span class="fa fa-group fs18 text-system" ></span>
                                    </asp:LinkButton>
                                   
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Admin_ID") %>' ToolTip="Sửa User">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Admin_ID") %>' ToolTip="Xóa User">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Admin/editadmin/Default.aspx" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>