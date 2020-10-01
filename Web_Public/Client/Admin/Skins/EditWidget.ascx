<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditWidget.ascx.cs"
    Inherits="Admin_Controls_EditWidget" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


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
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/EditWidget/Default.aspx" CssClass="pl5" title="Tạo Widget"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Tạo Widget</span>
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
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Tên Widget</label>
                            <div class="col-lg-8">
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWidgetName"
                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="update"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                                 <asp:TextBox ID="txtWidgetName" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên Widget" ValidationGroup="update"></asp:TextBox>
                            </div>
                        </div>
                     </div>
                       <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Kiểu Widget</label>
                            <div class="col-lg-8">
                                 <asp:DropDownList ID="ddlWidgetType" runat="server" ValidationGroup="update" AppendDataBoundItems="True" 
                                     CssClass="form-control input-sm" >
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                </div>
                 <div class="row">
                   <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Đường dẫn</label>
                            <div class="col-lg-8">
                                  <asp:DropDownList ID="dropFolder" runat="server" ValidationGroup="update"
                                     CssClass="form-control input-sm" AutoPostBack="True" OnSelectedIndexChanged="dropFolder_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                       <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Trạng thái</label>
                            <div class="col-lg-8">
                                 <div class="checkbox-custom pt5">
                                <asp:CheckBox ID="chkStatus" runat="server" Text="Hiển thị/Ẩn" ValidationGroup="update"/>
                            </div>
                            </div>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Tên Control</label>
                            <div class="col-lg-8">
                                 <asp:DropDownList ID="dropControl" runat="server" ValidationGroup="update"
                                     CssClass="form-control input-sm" >
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                  
                      <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Mô tả</label>
                            <div class="col-lg-8">
                                   <asp:TextBox ID="txtInfo" runat="server" CssClass="form-control input-sm" ValidationGroup="update" TextMode="MultiLine" Height="50px"></asp:TextBox>
                                   
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
                                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Admin/EditWidget/Default.aspx" Text="Thêm mới" />
                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Admin/Themes/Default.aspx" Text="Themes" />
                                <asp:HyperLink ID="hplHome" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/Home/Default.aspx" Text="Trang chủ" />
                                
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
                
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
                <telerik:RadGrid ID="RadGrid1" runat="server" PageSize="2000" AllowPaging="True"
                    AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
                    OnItemDataBound="RadGrid1_ItemDataBound" 
                    OnItemCommand="RadGrid1_ItemCommand">
                    <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                    <MasterTableView Width="100%" HierarchyLoadMode="Client">
                    <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="WidgetTypeName" HeaderValueSeparator=""
                                    FormatString="" HeaderText=" "></telerik:GridGroupByField>
                            </SelectFields>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="WidgetType" FieldAlias="WidgetType" FormatString=""
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
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </telerik:GridTemplateColumn>
                   
                    
                        <telerik:GridTemplateColumn HeaderText="Tên Widget">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("Id") %>'><%# Eval("WidgetName")%></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>

                          <telerik:GridBoundColumn HeaderText="Dir"
                            HeaderButtonType="TextButton" DataField="WidgetDir" Resizable="False">
                            <HeaderStyle Height="30px" Width="100px" HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                    
                        <telerik:GridBoundColumn HeaderText="Control"
                            HeaderButtonType="TextButton" DataField="WidgetControl" Resizable="False">
                            <HeaderStyle Height="30px" Width="200px" HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
 
                        <telerik:GridCheckBoxColumn HeaderText="Status" DataField="WidgetStatus">
                            <HeaderStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridCheckBoxColumn>
                    
                        <telerik:GridTemplateColumn HeaderText="Chức năng">
                            <ItemStyle HorizontalAlign="Center"/>
                            <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            <ItemTemplate>
                                 <asp:LinkButton ID="btn_edit4" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ID") %>' ToolTip="Sửa??" ValidationGroup="grvWidgetType">
                                <span class="glyphicons glyphicons-edit fs18" ></span>
                                </asp:LinkButton>

                                <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("ID") %>' ToolTip="Xóa??" ValidationGroup="grvWidgetType">
                                <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    
                    </Columns>
                
                </MasterTableView>
           
                <ClientSettings AllowGroupExpandCollapse="true" AllowExpandCollapse = "true" ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True">
                    <Selecting AllowRowSelect="True"></Selecting>
                    <Resizing AllowRowResize="false" AllowColumnResize="false" EnableRealTimeResize="false">
                    </Resizing>
                </ClientSettings>

                <HeaderStyle CssClass="primary fs12" />
            </telerik:RadGrid>
        
            </div>


           
        </div>
    </div>
   

</div>
</section>


<asp:HiddenField ID="txtID" runat="server" />
