<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listmodules.ascx.cs" Inherits="Admin_Controls_ListModules" %>
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="javascript:void();"> <asp:Literal ID="litModules" runat="server"></asp:Literal></a>
            </li>
            <li class="crumb-icon">
                <a href="/">
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
             <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/editmodules/Default.aspx" CssClass="pl5" title="Tạo mới"> 
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

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
                    AllowPaging="True" PageSize="2000" OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" EmptyDataText="Không tìm thấy bản ghi nào">
                    <HeaderStyle CssClass="primary fs12" />

                    <Columns>
                        <asp:BoundField DataField="Modules_ID" HeaderText="ID">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Modules_Parent" HeaderText="Cấp độ">
                            <ItemStyle Width="40px" CssClass="text-center" />
                            <HeaderStyle Width="40px" CssClass="text-center p5" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sắp xếp">
                            <ItemStyle Width="70px" CssClass="text-center" />
                            <HeaderStyle Width="70px" CssClass="text-center p5" />
                            <ItemTemplate>
                                <div style="position:relative;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtModulesOrder"
                                    ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtModulesOrder"
                                        MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                                   <asp:TextBox ID="txtModulesOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("Modules_Order")%>'></asp:TextBox>
                               </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ICON" HeaderStyle-Width="60" HeaderStyle-CssClass="text-center p5">
                            <ItemStyle CssClass="text-center" />
                            <ItemTemplate>
                                 <%# (Eval("Modules_Icon") != DBNull.Value && Eval("Modules_Icon").ToString() != "") ? "<i class='glyphicons " + Eval("Modules_Icon") + "'></i>" : ""%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tên Module">
                            <ItemStyle CssClass="text-left" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" CommandArgument='<%# Eval("Modules_ID") %>'><%# Eval("Modules_Name")%></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center p5" />
                        </asp:TemplateField>
                         <asp:BoundField DataField="Slug" HeaderText="Slug">
                            <ItemStyle CssClass="text-left" />
                            <HeaderStyle CssClass="text-center p5" Width="100px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Modules_Url" HeaderText="Tên Control" Visible="false">
                            <ItemStyle CssClass="text-left fs10" />
                            <HeaderStyle CssClass="text-center p5" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Modules_Dir" HeaderText="Đường dẫn" Visible="false">
                            <ItemStyle CssClass="text-left fs10" />
                            <HeaderStyle CssClass="text-center p5" Width="70px" />
                        </asp:BoundField>
            
                         <asp:CheckBoxField DataField="Status" HeaderText="Status">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:CheckBoxField>
            
                         <asp:CheckBoxField DataField="IsMenu" HeaderText="Menu">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:CheckBoxField>
            
                          <asp:CheckBoxField DataField="IsView" HeaderText="View">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="40px" />
                        </asp:CheckBoxField>
            
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center p5" Width="70px" />
                                <ItemTemplate>
                                        <asp:LinkButton ID="btn_edit" runat="server" CommandName="edit" CommandArgument='<%# Eval("Modules_ID") %>' ToolTip="Sửa Albums">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="delete" CommandArgument='<%# Eval("Modules_ID") %>' ToolTip="Xóa Albums">
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
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/editmodules/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>
