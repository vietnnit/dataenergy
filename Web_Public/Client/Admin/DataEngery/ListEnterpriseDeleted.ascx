<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListEnterpriseDeleted.ascx.cs"
    Inherits="Client_Admin_ListEnterpriseDeleted" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
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
             <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/EditEnterpriseForOrg/Default.aspx" CssClass="pl5" title="Tạo mới"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm mới</span>
            </asp:HyperLink>
        </div>
        <%--<div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btnCreateUser" runat="server" OnClick='btnCreateMember_Click' Visible="true" CssClass="pl5" title="Sắp xếp"> 
                <i class="fa fa-user fs22 text-primary"></i><br /><span class="fs11">Tạo thành viên</span>
            </asp:LinkButton>
        </div> --%>
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
                    <div class="form-group">          
                        <div class="col-lg-2 control-label"> 
                            <label>
                                Trọng điểm năm
                            </label>
                        </div>
                        <div class="col-lg-4">                     
                            <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True"
                                CssClass="form-control input-sm" ValidationGroup="view">
                            </asp:DropDownList>                                                                    
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">Sở công thương</label>
                        <div class="col-lg-4">                     
                            <asp:DropDownList ID="ddlOrg" runat="server" AppendDataBoundItems="True" 
                                CssClass="form-control input-sm"  ValidationGroup="vgInfo">
                            </asp:DropDownList>                                                                        
                        </div>
                    </div>           
                     <div class="form-group">
                        <label class="col-lg-2 control-label" for="inputSmall">Lĩnh vực</label>
                        <div class="col-lg-4">                     
                            <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True"  AutoPostBack="true"
                                CssClass="form-control input-sm" ValidationGroup="view" 
                                onselectedindexchanged="ddlArea_SelectedIndexChanged">
                            </asp:DropDownList>                                                                    
                        </div>
                    
                        <label class="col-lg-2 control-label" for="inputSmall">Phân ngành</label>
                        <div class="col-lg-4">                     
                            <asp:DropDownList ID="ddlSubArea" runat="server" AppendDataBoundItems="True" 
                                CssClass="form-control input-sm" ValidationGroup="view">
                            </asp:DropDownList>                                                                    
                        </div>
                    </div>     
                    <div class="form-group">                            
                        <label class="col-lg-2 control-label pt5" for="inputSmall">Từ khóa</label>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Nhập Tên cơ sở/DN hoặc tên tài khoản"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm" OnClick="btn_search_Click" />
                        </div>
                    </div>                        
                </div>
               
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body">
        <p>
            <asp:Literal ID="clientview" runat="server"></asp:Literal>
            </p>
            <div class="table-responsive mb20">
                <asp:GridView ID="grvNewsGroup" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="false" EmptyDataText="Không tìm thấy bản ghi nào"  onrowdatabound="grvNewsGroup_RowDataBound">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                     <asp:TemplateField HeaderText="#">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                          <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>                                                        
                    <asp:TemplateField HeaderText="Tên doanh nghiệp/Cơ sở">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>                            
                            <%# Eval("Title")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Tên tài khoản">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%#Eval("AccountName")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>    
                    <asp:TemplateField HeaderText="Sở công thương">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>                            
                            <%# Eval("OrgName")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Điện thoại">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%#Eval("Phone") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%#Eval("Email") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Địa chỉ">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%#Eval("Address") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Trọng điểm năm">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <asp:Literal ID="ltImportant" runat="server"></asp:Literal>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>           
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="60px" />
                        <ItemTemplate>
                            <a href='<%#ResolveUrl("~") %>Admin/EditEnterpriseForOrg/<%#Eval("Id") %>/Default.aspx'>
                                     <span class="glyphicons glyphicons-edit fs18" ></span></a>                            
                                    <asp:LinkButton ID="btn_delete" runat="server" OnClientClick="return confirm('Bạn đã chắc chắn xóa doanh nghiệp này không?');"  OnClick="btnDelete_Click" CommandName="_delete" CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa danh mục">
                                    <span class="glyphicons glyphicons-remove_2 fs18 text-danger" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                <div class="row mb20 right">
                    <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                </div>
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">                
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/EditEnterpriseForOrg/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>  

</div>
</section>
