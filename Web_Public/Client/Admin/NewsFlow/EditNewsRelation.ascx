<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditNewsRelation.ascx.cs"
    Inherits="Client_Admin_EditNewsRelation" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl2" TagPrefix="uc2" %>

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
            <a href="/Admin/ListNews/Default.aspx" class="pl5" title="Trang chủ"> 
                <i class="fa fa-list-alt fs22 text-danger"></i><br /><span class="fs11">DS Tin</span>
            </a>
        </div>

         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_editpage" runat="server" OnClick='btn_add_Click' CssClass="pl5" title="Chọn tin"> 
                <i class="fa fa-check fs22 text-primary"></i><br /><span class="fs11">Chọn tin</span>
            </asp:LinkButton>
        </div> 
        
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_delall" runat="server" OnClick='btn_delall_Click' CssClass="pl5" title="Xóa tin"> 
                <i class="fa fa-trash-o fs22 text-primary"></i><br /><span class="fs11">Xóa tin</span>
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
            <div class="form-horizontal">
                <div class="row">
                   <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Nhóm chuyên mục</label>
                            <div class="col-lg-8">
                                 <asp:DropDownList ID="ddlGroupCate" runat="server" AppendDataBoundItems="True"  AutoPostBack="True"
                                     CssClass="form-control input-sm" OnSelectedIndexChanged="ddlGroupCate_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                      <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-3 control-label pt5" for="inputSmall">Danh mục</label>
                            <div class="col-lg-9">
                                 <asp:DropDownList ID="ddlCateNewsSearch" runat="server" AppendDataBoundItems="True"  AutoPostBack="True"
                                     CssClass="form-control input-sm" OnSelectedIndexChanged="ddlCateNewsSearch_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                     </div>
                </div>
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
                            <label class="col-lg-3 control-label pt5" for="inputSmall">Thời gian</label>
                            <div class="col-lg-4">
                                 <div class="input-group  input-group-sm">
                                    <asp:TextBox ID="txtStartDateTime" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <span class="input-group-addon field-icon"><i class="fa fa-calendar"></i>
                                      </span>
                                    </div>
                            </div>
                             
                                   <label class="col-lg-1 control-label pt5 pr20 ol20" for="inputSmall">đến</label>
                              <div class="col-lg-4">  
                                <div class="input-group  input-group-sm">
                                    <asp:TextBox ID="txtEndDateTime" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                    <span class="input-group-addon field-icon"><i class="fa fa-calendar"></i>
                                      </span>
                                    </div>
                            </div>
                        </div>
                     </div>
                </div>
                <div class="row">
                  
                      <div class="col-lg-6">
                        <div class="form-group">
                            <label class="col-lg-4 control-label pt5" for="inputSmall">Tìm theo</label>
                            <div class="col-lg-8">
                                 <asp:DropDownList ID="ddlType" runat="server" AppendDataBoundItems="True"
                                     CssClass="form-control input-sm">
                                </asp:DropDownList>
                            </div>
   

                        </div>
                        </div>
                         <div class="col-lg-6">
                             <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm" OnClick="btn_search_Click" />
                              <asp:Button runat="server" ID="Button6" CssClass="btn btn-sm btn-alert mr10" Text="Chọn tin liên quan" OnClick="btn_add_Click" />

                         </div>
                   
                </div>
            </div>
       
    </div>
    <div class="panel">
        <div class="panel-body">
            
            <asp:Literal ID="clientview" runat="server"></asp:Literal>

            <div class="col-lg-6">

            <div class="table-responsive mb20">
            <asp:GridView ID="grvNewsGroup" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="false" OnPageIndexChanging="grvNewsGroup_PageIndexChanging" OnRowCommand="grvNewsGroup_RowCommand"
            OnRowDataBound="grvNewsGroup_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="NewsGroupID">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="30px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="#">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="40px" />
                        <ItemTemplate>
                                <asp:CheckBox ID="chkId" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Xem">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="30px" />
                        <ItemTemplate>
                             <asp:LinkButton ID="btn_view" runat="server" CommandName="_view" CommandArgument='<%# Eval("NewsGroupID") %>' ToolTip="Sửa nhóm chuyên mục">
                            <span class="glyphicons glyphicons-display fs18 text-danger" ></span>
                            </asp:LinkButton>
                   
                        </ItemTemplate>
                    </asp:TemplateField>
                   

                    <asp:TemplateField HeaderText="Tiêu đề tin">
                        <ItemStyle CssClass="text-left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="linkTitle" runat="server" CommandName="_edit" CommandArgument='<%# Eval("NewsGroupID") %>'><%# Eval("Title")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center" />
                    </asp:TemplateField>
                  
                     <asp:BoundField DataField="PostDate" HeaderText="Ngày đăng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="80px" />
                    </asp:BoundField>

                     <asp:CheckBoxField DataField="IsApproval" HeaderText="Duyệt">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="35px" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="Status" HeaderText="Hoạt động">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="35px" />
                    </asp:CheckBoxField>
                   
                </Columns>
            </asp:GridView>
        
            </div>
            <div class="row mb20 right">
                <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
            LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
            </div>

            </div>
            <div class="col-lg-6">
                 <div class="table-responsive mb20">
                    <asp:GridView ID="grvRelation" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
                    AllowPaging="false" OnRowCommand="grvRelation_RowCommand"
                    OnRowDataBound="grvRelation_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                        <HeaderStyle CssClass="primary fs12" />

                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="NewsGroupID">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="30px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="#">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="40px" />
                                <ItemTemplate>
                                        <asp:CheckBox ID="chkId" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:TemplateField HeaderText="Xem">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="30px" />
                                <ItemTemplate>
                                     <asp:LinkButton ID="btn_view" runat="server" CommandName="_view" CommandArgument='<%# Eval("NewsGroupID") %>' ToolTip="Sửa nhóm chuyên mục">
                                    <span class="glyphicons glyphicons-display fs18 text-danger" ></span>
                                    </asp:LinkButton>
                   
                                </ItemTemplate>
                            </asp:TemplateField>
                   

                            <asp:TemplateField HeaderText="Tiêu đề tin">
                                <ItemStyle CssClass="text-left" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkTitle" runat="server" CommandName="_edit" CommandArgument='<%# Eval("NewsGroupID") %>'><%# Eval("Title")%></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle CssClass="text-center" />
                            </asp:TemplateField>
                  
                             <asp:BoundField DataField="PostDate" HeaderText="Ngày đăng">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="80px" />
                            </asp:BoundField>

                             <asp:CheckBoxField DataField="IsApproval" HeaderText="Duyệt">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="35px" />
                            </asp:CheckBoxField>
                            <asp:CheckBoxField DataField="Status" HeaderText="Hoạt động">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="35px" />
                            </asp:CheckBoxField>

                             <asp:TemplateField HeaderText="Chức năng">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="text-center" Width="60px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("NewsGroupID") %>' ToolTip="Sửa tin">
                                            <span class="glyphicons glyphicons-edit fs18" ></span>
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("NewsGroupID") %>' ToolTip="Xóa tin">
                                            <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                            </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                   
                        </Columns>
                    </asp:GridView>
        
                    </div>
                    <div class="row mb20 right">
                        <uc2:PagingControl2 ID="paging2" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                    LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                    </div>
            </div>

            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Chọn tin liên quan" OnClick="btn_add_Click" />
                <asp:Button runat="server" ID="btn_create" CssClass="btn btn-sm btn-primary mr10" Text="Xóa tin liên quan" OnClick="btn_delall_Click" />
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/ListNewsGroup/Default.aspx" Text="DS Tin" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>


<asp:HiddenField ID="hddNewsID" runat="server" />
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<asp:HiddenField ID="hdnPage2" runat="server" Value="1" />
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtStartDateTime.ClientID%>").datetimepicker({
            format: 'd/m/Y H:i'
        });
        $("#<%=txtEndDateTime.ClientID%>").datetimepicker({
            format: 'd/m/Y H:i'
        });
    });
</script>