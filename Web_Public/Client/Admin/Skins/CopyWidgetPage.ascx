<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CopyWidgetPage.ascx.cs"
    Inherits="Client_Admin_CopyWidgetPage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
 <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />

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
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Themes/Default.aspx" CssClass="pl5" title="Quản lý giao diện"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">Themes</span>
            </asp:HyperLink>
        </div>

          <div class="topbar-icon ml15 ib va-m">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/EditWidgetPageLayout/Default.aspx" CssClass="pl5" title="Thêm Widget"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm Widget</span>
            </asp:HyperLink>
        </div>
         
       
        <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_edit" runat="server" OnClick='btn_copy_Click' CssClass="pl5" title="Lưu lại" ValidationGroup="update"> 
                <i class="fa fa-copy fs22 text-primary"></i><br /><span class="fs11">Copy</span>
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

                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Trang nguồn</label>
                            <div class="col-lg-8">
                                 <asp:DropDownList ID="ddlPageLayout" runat="server" ValidationGroup="grid1" AppendDataBoundItems="True" 
                                     CssClass="form-control input-sm" onselectedindexchanged="ddlPageLayout_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                   <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Vùng nguồn</label>
                            <div class="col-lg-8">
                                  <asp:DropDownList ID="ddlRegion" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                                        onselectedindexchanged="ddlRegion_SelectedIndexChanged" ValidationGroup="grid1"
                                        CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                       
                </div>
                 <div class="row">
                   <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Trang đích</label>
                            <div class="col-lg-8">
                                  <asp:DropDownList ID="ddlPageLayout2" runat="server" ValidationGroup="grid2" AppendDataBoundItems="True" 
                                     CssClass="form-control input-sm" onselectedindexchanged="ddlPageLayout2_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                       <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Vùng đích</label>
                            <div class="col-lg-8">
                                 <asp:DropDownList ID="ddlRegion2" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                                        onselectedindexchanged="ddlRegion2_SelectedIndexChanged" ValidationGroup="grid2"
                                        CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                </div>
                
                 <div class="row">
                     <div class="col-lg-12">
                        <div class="form-group ">
                        <div class="col-lg-12 text-center">
                        <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Copy Widget" OnClick="btn_copy_Click"  ValidationGroup="update"/>
                                
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
                
                 <telerik:RadGrid ID="RadGrid1" runat="server" PageSize="200" AllowPaging="True" GridLines="None"
                    AutoGenerateColumns="False" Style="border: 1; outline: none;" Skin="Default"
                    OnItemDataBound="RadGrid1_ItemDataBound" 
                    OnItemCommand="RadGrid1_ItemCommand">
                    <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                    <MasterTableView Width="100%" HierarchyLoadMode="Client">
                        <GroupByExpressions>
                            <telerik:GridGroupByExpression>
                                <SelectFields>
                                    <telerik:GridGroupByField FieldName="PageName" HeaderValueSeparator=""
                                        FormatString="" HeaderText=" "></telerik:GridGroupByField>
                                </SelectFields>
                                <GroupByFields>
                                    <telerik:GridGroupByField FieldName="PageLayoutId" FieldAlias="PageLayoutId" FormatString=""
                                        HeaderText=""></telerik:GridGroupByField>
                                </GroupByFields>
                            </telerik:GridGroupByExpression>
                           <telerik:GridGroupByExpression>
                                <SelectFields>
                                    <telerik:GridGroupByField FieldName="RegionId" HeaderValueSeparator=""
                                        FormatString="" HeaderText=" "></telerik:GridGroupByField>
                                </SelectFields>
                                <GroupByFields>
                                    <telerik:GridGroupByField FieldName="RegionId" FieldAlias="RegionId" FormatString=""
                                        HeaderText=""></telerik:GridGroupByField>
                                </GroupByFields>
                            </telerik:GridGroupByExpression>
                        </GroupByExpressions>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="ID" HeaderButtonType="TextButton" DataField="Id"
                                UniqueName="Id" Resizable="False" Visible="false">
                                <HeaderStyle Height="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="#" UniqueName="TemplateColumn" Resizable="False">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkId" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="31px" />
                            </telerik:GridTemplateColumn>
                    
                           <telerik:GridTemplateColumn HeaderText="Sắp xếp">
                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                <ItemTemplate>
                                     <div style="position:relative;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOrder" ValidationGroup="grid1"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangsortle"></i></span></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtOrder" ValidationGroup="grid1" 
                                            MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                                       <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("WidgetOrder")%>' ValidationGroup="grid1"></asp:TextBox>
                                   </div>

                                 </ItemTemplate>
                            </telerik:GridTemplateColumn>
                    
                            <telerik:GridTemplateColumn HeaderText="Cấu hình">
                                <ItemStyle HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                <ItemTemplate>
                                     <asp:LinkButton ID="btn_config" runat="server" CommandName="_config" CommandArgument='<%# Eval("Id") %>' ToolTip="Cấu hình Widget" ValidationGroup="grid1">
                                        <span class="glyphicons glyphicons-settings fs18 text-danger" ></span>
                                      </asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn HeaderText="Preview">
                                <ItemStyle HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_preview" runat="server" CommandName="_preview" CommandArgument='<%# Eval("Id") %>' ToolTip="Xem trước" ValidationGroup="grid1">
                                        <span class="glyphicons glyphicons-display fs18 text-primary" ></span>
                                      </asp:LinkButton>
                                 </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Tên Widget">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Id") %>' ValidationGroup="grid1"><%# Eval("WidgetName")%></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                   
                            <telerik:GridBoundColumn HeaderText="Control"
                                HeaderButtonType="TextButton" DataField="WidgetControl" Resizable="False">
                                <HeaderStyle Height="30px" Width="200px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="true" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn HeaderText="Tiêu đề"
                                HeaderButtonType="TextButton" DataField="Title" Resizable="False">
                                <HeaderStyle Height="30px" Width="150px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Wrap="true" />
                            </telerik:GridBoundColumn>
                   
                            <telerik:GridBoundColumn HeaderText="Type"
                                HeaderButtonType="TextButton" DataField="WidgetTypeName" Resizable="False">
                                <HeaderStyle Height="30px" Width="120px" HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>

                            <telerik:GridCheckBoxColumn HeaderText="Status" DataField="Status">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridCheckBoxColumn>
                    
                            <telerik:GridTemplateColumn HeaderText="Chức năng">
                                <ItemStyle HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                 <ItemTemplate>
                                    <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ID") %>' ToolTip="Sửa tin" ValidationGroup="grid1">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("ID") %>' ToolTip="Xóa tin" ValidationGroup="grid1">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                    
                        </Columns>
                
                    </MasterTableView>
           
                    <ClientSettings AllowGroupExpandCollapse="true" AllowExpandCollapse = "true" ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
                        <Selecting AllowRowSelect="True"></Selecting>
                        <Resizing AllowRowResize="True" AllowColumnResize="True" EnableRealTimeResize="True">
                        </Resizing>
                    </ClientSettings>
                    <HeaderContextMenu EnableTheming="True" Skin="Office2007">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </HeaderContextMenu>
                    <FilterMenu EnableTheming="True" Skin="Office2007">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </FilterMenu>
                    <AlternatingItemStyle BackColor="#F8F8F8" />
                    <HeaderStyle Font-Bold="True" Height="30px" />
                </telerik:RadGrid>
            </div>
        
            </div>


           
        </div>

        <div class="panel">
        <div class="panel-body">
            
            
            <div class="table-responsive mb20">
                <telerik:RadGrid ID="RadGrid2" runat="server" PageSize="200" AllowPaging="True" GridLines="None"
                    AutoGenerateColumns="False" Style="border: 1; outline: none;" Skin="Default"
                    OnItemDataBound="RadGrid2_ItemDataBound" 
                    OnItemCommand="RadGrid2_ItemCommand">
                    <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                    <MasterTableView Width="100%" HierarchyLoadMode="Client">
                        <GroupByExpressions>
                            <telerik:GridGroupByExpression>
                                <SelectFields>
                                    <telerik:GridGroupByField FieldName="PageName" HeaderValueSeparator=""
                                        FormatString="" HeaderText=" "></telerik:GridGroupByField>
                                </SelectFields>
                                <GroupByFields>
                                    <telerik:GridGroupByField FieldName="PageLayoutId" FieldAlias="PageLayoutId" FormatString=""
                                        HeaderText=""></telerik:GridGroupByField>
                                </GroupByFields>
                            </telerik:GridGroupByExpression>
                           <telerik:GridGroupByExpression>
                                <SelectFields>
                                    <telerik:GridGroupByField FieldName="RegionId" HeaderValueSeparator=""
                                        FormatString="" HeaderText=" "></telerik:GridGroupByField>
                                </SelectFields>
                                <GroupByFields>
                                    <telerik:GridGroupByField FieldName="RegionId" FieldAlias="RegionId" FormatString=""
                                        HeaderText=""></telerik:GridGroupByField>
                                </GroupByFields>
                            </telerik:GridGroupByExpression>
                        </GroupByExpressions>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="ID" HeaderButtonType="TextButton" DataField="Id"
                                UniqueName="Id" Resizable="False" Visible="false">
                                <HeaderStyle Height="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="#" UniqueName="TemplateColumn" Resizable="False">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkId" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="31px" />
                            </telerik:GridTemplateColumn>
                    
                            <telerik:GridTemplateColumn HeaderText="Sắp xếp">
                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                <ItemTemplate>
                                     <div style="position:relative;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOrder" ValidationGroup="grid2"
                                        ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangsortle"></i></span></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtOrder" ValidationGroup="grid2" 
                                            MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                                       <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("WidgetOrder")%>' ValidationGroup="grid2"></asp:TextBox>
                                   </div>

                                 </ItemTemplate>
                            </telerik:GridTemplateColumn>
                    
                            <telerik:GridTemplateColumn HeaderText="Cấu hình">
                                <ItemStyle HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                <ItemTemplate>
                                     <asp:LinkButton ID="btn_config" runat="server" CommandName="_config" CommandArgument='<%# Eval("Id") %>' ToolTip="Cấu hình Widget" ValidationGroup="grid2">
                                        <span class="glyphicons glyphicons-settings fs18 text-danger" ></span>
                                      </asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                             <telerik:GridTemplateColumn HeaderText="Preview">
                                <ItemStyle HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_preview" runat="server" CommandName="_preview" CommandArgument='<%# Eval("Id") %>' ToolTip="Xem trước" ValidationGroup="grid2">
                                        <span class="glyphicons glyphicons-display fs18 text-primary" ></span>
                                      </asp:LinkButton>
                                 </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Tên Widget">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Id") %>' ValidationGroup="grid2"><%# Eval("WidgetName")%></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </telerik:GridTemplateColumn>
                   
                            <telerik:GridBoundColumn HeaderText="Control"
                                HeaderButtonType="TextButton" DataField="WidgetControl" Resizable="False">
                                <HeaderStyle Height="30px" Width="200px" HorizontalAlign="Center" />
                                <ItemStyle Wrap="true" />
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn HeaderText="Tiêu đề"
                                HeaderButtonType="TextButton" DataField="Title" Resizable="False">
                                <HeaderStyle Height="30px" Width="150px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Wrap="true" />
                            </telerik:GridBoundColumn>
                   
                            <telerik:GridBoundColumn HeaderText="Type"
                                HeaderButtonType="TextButton" DataField="WidgetTypeName" Resizable="False">
                                <HeaderStyle Height="30px" Width="120px" HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>

                            <telerik:GridCheckBoxColumn HeaderText="Status" DataField="Status">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridCheckBoxColumn>
                    
                            <telerik:GridTemplateColumn HeaderText="Chức năng">
                                <ItemStyle HorizontalAlign="Center"/>
                                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                 <ItemTemplate>
                                    <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ID") %>' ToolTip="Sửa tin" ValidationGroup="grid2">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("ID") %>' ToolTip="Xóa tin" ValidationGroup="grid2">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                    
                        </Columns>
                
                    </MasterTableView>
           
                    <ClientSettings AllowGroupExpandCollapse="true" AllowExpandCollapse = "true" ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
                        <Selecting AllowRowSelect="True"></Selecting>
                        <Resizing AllowRowResize="True" AllowColumnResize="True" EnableRealTimeResize="True">
                        </Resizing>
                    </ClientSettings>
                    <HeaderContextMenu EnableTheming="True" Skin="Office2007">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </HeaderContextMenu>
                    <FilterMenu EnableTheming="True" Skin="Office2007">
                        <CollapseAnimation Duration="200" Type="OutQuint" />
                    </FilterMenu>
                    <AlternatingItemStyle BackColor="#F8F8F8" />
                    <HeaderStyle Font-Bold="True" Height="30px" />
                </telerik:RadGrid>
            </div>
        


             <div class="form-group ">
                    
                    <asp:Button runat="server" ID="Button1" CssClass="btn btn-sm btn-primary mr10" Text="Sắp xếp" OnClick="btn_Order_Click"  ValidationGroup="grid2"/>
                    <asp:Button runat="server" ID="btn_add2" CssClass="btn btn-sm btn-primary mr10" Text="Copy" OnClick="btn_copy_Click"  ValidationGroup="grid1"/>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Admin/EditWidgetPageLayout/Default.aspx" Text="PageLayout" />
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Admin/Themes/Default.aspx" Text="Themes" />
                    <asp:HyperLink ID="HyperLink21" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/Home/Default.aspx" Text="Trang chủ" />
                                
                  
                </div>

            </div>


           
        </div>
    
   

</div>
</section>