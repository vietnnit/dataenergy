<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListCateNewsGroup.ascx.cs"
    Inherits="Client_Admin_ListCateNewsGroup" %>


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
             <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editcatenewsgroup/Default.aspx" CssClass="pl5" title="Tạo mới"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới</span>
            </asp:HyperLink>
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
            <asp:GridView ID="grvCateNewsGroup" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="True" PageSize="1000" OnPageIndexChanging="grvCateNewsGroup_PageIndexChanging" OnRowCommand="grvCateNewsGroup_RowCommand"
            OnRowDataBound="grvCateNewsGroup_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="CateNewsGroupID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="30px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Sắp xếp">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="50px" />
                        <ItemTemplate>
                            <div style="position:relative;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOrder"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtOrder"
                                MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                           <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("Order")%>'></asp:TextBox>
                       </div>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ICON" Visible="false">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="60px" />
                        <ItemTemplate>
                                <%# (Eval("Icon").ToString() != "") ? "<img src='" + Eval("Icon") + "' class='mw60 br8 border bw2 border-info' onmouseover=\"return overlib('&lt;img src=\\'" + Eval("Icon") + "\\' width=\\'250px\\'&gt;', CAPTION, \'\', ABOVE,RIGHT,WIDTH,250);\" onmouseout=\"return nd();\" border=\"0\">" : "<img src='" + ResolveUrl("~/") + "images/spacer.gif' >"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Sửa">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="30px" />
                        <ItemTemplate>
                             <asp:LinkButton ID="btn_edit1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("CateNewsGroupID") %>' ToolTip="Sửa nhóm chuyên mục">
                            <span class="glyphicons glyphicons-edit fs18 text-danger" ></span>
                            </asp:LinkButton>
                   
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên nhóm chuyên mục">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_listcate" CommandArgument='<%# Eval("CateNewsGroupID") %>'><%# Eval("CateNewsGroupName")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Danh mục">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="50px" />
                        <ItemTemplate>
                             <asp:LinkButton ID="btn_edit3" runat="server" CommandName="_listcate" CommandArgument='<%# Eval("CateNewsGroupID") %>' ToolTip="Cập nhật danh mục cấp 2">
                            <span class="glyphicons glyphicons-list fs18 text-primary" ></span>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PageName" HeaderText="Page">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GroupCate" HeaderText="Value">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="40px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Menu">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="50px" />
                        <ItemTemplate>
                            <div style="position:relative;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMenu"
                                ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtMenu"
                                    MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                               <asp:TextBox ID="txtMenu" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("Menu")%>'></asp:TextBox>
                           </div>
          
                        </ItemTemplate>
                    </asp:TemplateField>
            
                    <asp:BoundField DataField="Position" HeaderText="Position">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="50px" />
                    </asp:BoundField>
            
                    <asp:CheckBoxField DataField="IsView" HeaderText="Hiển thị">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="IsHome" HeaderText="Home">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="IsMenu" HeaderText="Menu">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="IsNew" HeaderText="News">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="IsPage" HeaderText="Page">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>
          
                     <asp:CheckBoxField DataField="IsOfficial" HeaderText="Official">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="IsUrl" HeaderText="Url">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>
                    <asp:TemplateField HeaderText="Phân quyền">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="40px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_rules" runat="server" CommandName="rules" CommandArgument='<%# Eval("CateNewsGroupID") %>' ToolTip="Phân quyền">
                                    <span class="glyphicons glyphicons-user_add fs18 text-system" ></span>
                                    </asp:LinkButton>
                                   
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("CateNewsGroupID") %>' ToolTip="Sửa danh mục">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("CateNewsGroupID") %>' ToolTip="Xóa danh mục">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_edit2" CssClass="btn btn-sm btn-primary mr10" Text="Sắp xếp" OnClick="btn_Order_Click" />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/editcatenewsgroup/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>


