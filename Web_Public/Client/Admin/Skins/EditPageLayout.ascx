<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditPageLayout.ascx.cs"
    Inherits="Client_Admin_EditPageLayout" %>
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
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/EidtPageLayout/Default.aspx" CssClass="pl5" title="Tạo Page"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Tạo Page</span>
            </asp:HyperLink>
        </div>
         
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_add" runat="server" OnClick='btn_add_Click' CssClass="pl5" title="Lưu lại" ValidationGroup="update"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Lưu lại</span>
            </asp:LinkButton>
        </div>      

        <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_edit" runat="server" OnClick='btn_edit_Click' CssClass="pl5" title="Lưu lại" ValidationGroup="update"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Lưu lại</span>
            </asp:LinkButton>
        </div>      

         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnOrder" runat="server" OnClick='btn_Order_Click' CssClass="pl5" title="Sắp xếp" ValidationGroup="grvPageLayout"> 
                <i class="fa fa-trash-o fs22 text-primary"></i><br /><span class="fs11">Sắp xếp</span>
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

            <div class="form-horizontal">

                <div class="row">
                   <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Tên Page</label>
                            <div class="col-lg-8">
                                 <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên Page" ValidationGroup="update"></asp:TextBox>
                            </div>
                        </div>
                     </div>
                      <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Control (Url)</label>
                            <div class="col-lg-8">
                                 <asp:DropDownList ID="ddlTemplate" runat="server" AppendDataBoundItems="True"  ValidationGroup="update"
                                     CssClass="form-control input-sm" >
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                </div>
                <div class="row">
                   <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Slug Page</label>
                            <div class="col-lg-8">
                                 <asp:TextBox ID="txtSlug" runat="server" CssClass="form-control input-sm" placeholder="Slug Page" ValidationGroup="update"></asp:TextBox>
                            </div>
                        </div>
                     </div>
                      <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Thứ tự</label>
                            <div class="col-lg-8">
                                     <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtOrder"
                                        ErrorMessage="RangeValidator" MaximumValue="2000" MinimumValue="0" Type="Integer"
                                        ValidationGroup="update"><span class="append-icon right text-danger">(từ 0-2000)</span></asp:RangeValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrder"
                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="update"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control input-sm" ValidationGroup="update"></asp:TextBox>
                                   
                            </div>
                             
                                  
                        </div>
                        </div>
                     </div>
                     <div class="row">
                     <div class="col-lg-12">
                             <div class="form-group ">
                                <div class="col-lg-12 text-left">
                                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click"  ValidationGroup="update"/>
                                <asp:Button runat="server" ID="btn_add2" CssClass="btn btn-sm btn-primary mr10" Text="Lưu & thêm mới" OnClick="btn_add_Click_more"  ValidationGroup="update"/>
                                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click"  ValidationGroup="update"/>
                                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/EditPageLayout/Default.aspx" Text="Thêm mới" />
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                                </div>
                            </div>
                     </div>
                </div>
                
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body">
            
            
            <div class="table-responsive mb20">
            <asp:GridView ID="grvPageLayout" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="true" PageSize="2000" OnPageIndexChanging="grvPageLayout_PageIndexChanging" OnRowCommand="grvPageLayout_RowCommand"
            OnRowDataBound="grvPageLayout_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="30px" />
                    </asp:BoundField>

                     <asp:TemplateField HeaderText="Thứ tự">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="70px" />
                            <ItemTemplate>
                                <div style="position:relative;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPageOrder" ValidationGroup="grvPageLayout"
                                    ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtPageOrder" ValidationGroup="grvPageLayout" 
                                        MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                                   <asp:TextBox ID="txtPageOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("Orders")%>' ValidationGroup="grvPageLayout"></asp:TextBox>
                               </div>
                            </ItemTemplate>
                     </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="Cấu hình">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="30px" />
                        <ItemTemplate>
                             <asp:LinkButton ID="btn_widget" runat="server" CommandName="_widget" CommandArgument='<%# Eval("ID") %>' ToolTip="Cấu hình">
                            <span class="glyphicons glyphicons-settings fs18 text-danger" ></span>
                            </asp:LinkButton>
                   
                        </ItemTemplate>
                    </asp:TemplateField>
                   

                    <asp:TemplateField HeaderText="Tên Page">
                        <ItemStyle CssClass="text-left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="linkTitle" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ID") %>' ValidationGroup="grvPageLayout"><%# Eval("PageName")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center" />
                    </asp:TemplateField>
                    

                     <asp:BoundField DataField="SlugPageName" HeaderText="Slug">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="150px" />
                    </asp:BoundField>
                    
                   
                    <asp:BoundField DataField="TemplateName" HeaderText="Template">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="150px" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="70px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_edit4" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ID") %>' ToolTip="Sửa tin" ValidationGroup="grvPageLayout">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("ID") %>' ToolTip="Xóa tin" ValidationGroup="grvPageLayout">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>


           
        </div>
    </div>
   

</div>
</section>
<asp:HiddenField ID="hddID" runat="server" />
