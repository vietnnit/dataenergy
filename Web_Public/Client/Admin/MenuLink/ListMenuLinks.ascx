<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListMenuLinks.ascx.cs"
    Inherits="Admin_Controls_ListMenuLinks" %>

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
             <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editmenulinks/Default.aspx" CssClass="pl5" title="Tạo mới"> 
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
              <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">Chọn vị trí</label>
                        <div class="col-lg-4">
                     
                             <asp:DropDownList ID="ddlMenuLinks" runat="server" AppendDataBoundItems="True" 
                                 onselectedindexchanged="ddlMenuLinks_SelectedIndexChanged" AutoPostBack="true" 
                                 CssClass="form-control input-sm">
                            </asp:DropDownList>

                        </div>
                    </div>
                </div>
        

            <div class="table-responsive mb20">

                <asp:GridView ID="grvMenuLink" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
                    AllowPaging="True" PageSize="1000" OnPageIndexChanging="grvMenuLink_PageIndexChanging" OnRowCommand="grvMenuLink_RowCommand"
                    OnRowDataBound="grvMenuLink_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                    <HeaderStyle CssClass="primary fs12" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="MenuLinksID">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MenuLinksParent" HeaderText="Cấp độ">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Thứ tự">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="70px" />
                            <ItemTemplate>
                                <div style="position:relative;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMenuLinksOrder"
                                    ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtMenuLinksOrder"
                                        MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                                   <asp:TextBox ID="txtMenuLinksOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("MenuLinksOrder")%>'></asp:TextBox>
                               </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Image">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="70px" />
                            <ItemTemplate>
                                 <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img src='" + Eval("MenuLinksIcon") + "' class='mw60 border bw2 border-info' onmouseover=\"return overlib('&lt;img src=\\'" + Eval("MenuLinksIcon") + "\\' width=\\'250px\\'&gt;', CAPTION, \'\', ABOVE,RIGHT,WIDTH,250);\" onmouseout=\"return nd();\" border=\"0\">" : "<img src='" + ResolveUrl("~/") + "images/spacer.gif' >"%>

                    
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Tên danh mục">
                            <ItemStyle CssClass="TextLeft" />
                            <HeaderStyle CssClass="text-center p5" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("MenuLinksID") %>'><%# Eval("MenuLinksName")%></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MenuLinksUrl" HeaderText="Link">
                            <ItemStyle CssClass="text-left" />
                            <HeaderStyle CssClass="text-center p5" Width="150px" />
                        </asp:BoundField>
            
                          <asp:BoundField DataField="Position" HeaderText="Vị trí Menu">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Hit" HeaderText="Hit">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:BoundField>
                        <asp:CheckBoxField DataField="IsFlash" HeaderText="Flash">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:CheckBoxField>
                        <asp:CheckBoxField DataField="isView" HeaderText="Trang chủ">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:CheckBoxField>
                         <asp:CheckBoxField DataField="Status" HeaderText="Trạng thái">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:CheckBoxField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="70px" />
                            <ItemTemplate>
                                 <asp:LinkButton ID="btn_edit2" runat="server" CommandName="_edit" CommandArgument='<%# Eval("MenuLinksID") %>' ToolTip="Sửa Albums">
                                <span class="glyphicons glyphicons-edit fs18" ></span>
                                </asp:LinkButton>

                                <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("MenuLinksID") %>' ToolTip="Xóa Albums">
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
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/editmenulinks/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>


