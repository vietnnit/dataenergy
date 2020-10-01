<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListCateNews.ascx.cs"
    Inherits="Admin_Controls_ListCateNews" %>

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
             <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/listcatenewsgroup/Default.aspx" CssClass="pl5" title="Chuyên mục"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">Chuyên mục</span>
            </asp:HyperLink>
        </div>   
        <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_add" runat="server" OnClick='btn_create_click' CssClass="pl5" title="Thêm mới"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới</span>
            </asp:LinkButton>
        </div>         
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnOrder" runat="server" OnClick='btn_Order_Click' CssClass="pl5" title="Sắp xếp"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Sắp xếp</span>
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
            <asp:GridView ID="grvCateNews" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="True" PageSize="1000" OnPageIndexChanging="grvCateNews_PageIndexChanging" OnRowCommand="grvCateNews_RowCommand"
            OnRowDataBound="grvCateNews_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="CateNewsID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="30px" />
                    </asp:BoundField>
                     <asp:BoundField HeaderText="Cấp độ" DataField="ParentNewsID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="30px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Sắp xếp">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="70px" />
                        <ItemTemplate>
                            <div style="position:relative;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCateNewsOrder"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtCateNewsOrder"
                                MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                           <asp:TextBox ID="txtCateNewsOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("CateNewsOrder")%>'></asp:TextBox>
                       </div>

                        </ItemTemplate>
                    </asp:TemplateField>
                  
                    
                    <asp:TemplateField HeaderText="Tên danh mục">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("CateNewsID") %>'><%# Eval("CateNewsName")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="ShortName" HeaderText="Tên ngắn" Visible="false">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PageName" HeaderText="Page">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="120px" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="CateNewsTotal" HeaderText="SL Tin">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="50px" />
                    </asp:BoundField>
            
                    <asp:CheckBoxField DataField="IsUrl" HeaderText="isUrl">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="Url" HeaderText="Url" Visible="false">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="120px" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="Status" HeaderText="Status">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>
                    
                    <asp:TemplateField HeaderText="Phân quyền">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="40px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_rules" runat="server" CommandName="rules" CommandArgument='<%# Eval("CateNewsID") %>' ToolTip="Phân quyền">
                                    <span class="glyphicons glyphicons-user_add fs18 text-system" ></span>
                                    </asp:LinkButton>
                                   
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Moving">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="40px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_move" runat="server" CommandName="_move" CommandArgument='<%# Eval("CateNewsID") %>' ToolTip="Phân quyền">
                                    <span class="glyphicons glyphicons-random fs18 text-system" ></span>
                                    </asp:LinkButton>
                                   
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("CateNewsID") %>' ToolTip="Sửa danh mục">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("CateNewsID") %>' ToolTip="Xóa danh mục">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Sắp xếp" OnClick="btn_Order_Click" />
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Thêm mới" OnClick="btn_create_click" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>


<asp:HiddenField ID="hddGroup" runat="server" />
