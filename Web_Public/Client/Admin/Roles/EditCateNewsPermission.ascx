﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditCateNewsPermission.ascx.cs"
    Inherits="Client_Admin_EditCateNewsPermission" %>
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
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/ListRoles/Default.aspx" CssClass="pl5" title="DS nhóm quyền"> 
                <i class="fa fa-group fs22 text-primary"></i><br /><span class="fs11">DS nhóm quyền</span>
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
    
        <div class="panel panel-tile text-primary of-h mb10">
            <div class="panel-body pn br-n pl20 p5">
                <div class="icon-bg">
                    <i class="fa fa-group"></i>
                </div>
                <h2 class="mt15 lh15">
                        <b>Nhóm</b>
                    </h2>
                <h5 class="text-muted"><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h5>
            </div>
        </div>
        <div class="panel">
        <div class="panel-body">
                <div class="form-horizontal">

                    <asp:Literal ID="error" runat="server"></asp:Literal>

                    <div class="form-group ">

                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
                    <telerik:RadGrid ID="RadGrid1" runat="server" PageSize="2000" AllowPaging="True"
                        GridLines="None" AutoGenerateColumns="False" Style="border: 1; outline: none;"
                        Skin="Office2007" OnItemDataBound="RadGrid1_ItemDataBound">
                        <PagerStyle Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                        <MasterTableView Width="100%" HierarchyLoadMode="Client">
                            <GroupByExpressions>
                                <telerik:GridGroupByExpression>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldAlias="&#160;" FieldName="GroupCateName" HeaderValueSeparator="Nh&#243;m danh mục : "
                                            FormatString="" HeaderText=""></telerik:GridGroupByField>
                                    </SelectFields>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="GroupCate" FieldAlias="GroupCate" FormatString=""
                                            HeaderText=""></telerik:GridGroupByField>
                                    </GroupByFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="cID" HeaderButtonType="TextButton" DataField="CateNewsID"
                                    UniqueName="CateNewsID" Resizable="False" Visible="false">
                                    <HeaderStyle Height="30px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="#" UniqueName="TemplateColumn" Resizable="False">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkId" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="31px" Height="30px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn SortExpression="CateNewsName" HeaderText="T&#234;n danh mục"
                                    HeaderButtonType="TextButton" DataField="CateNewsName" UniqueName="CateNewsName"
                                    Resizable="False">
                                    <HeaderStyle Height="30px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                        </MasterTableView>
                        <ClientSettings AllowGroupExpandCollapse="true" AllowExpandCollapse="true" ReorderColumnsOnClient="True"
                            AllowDragToGroup="True" AllowColumnsReorder="True">
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
                        <div class="col-lg-12 text-left">
                            <asp:Button runat="server" ID="Button2" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" />

                        </div>
                    </div>

                </div>
            </div>
        </div>


</div>
</section>

<asp:HiddenField ID="hddRoles" runat="server" />
