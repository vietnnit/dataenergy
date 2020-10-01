<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListNewsFiles.ascx.cs"
    Inherits="Client_Admin_ListNewsFiles" %>

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
            <asp:LinkButton ID="btn_listnews" runat="server" OnClick='btn_listnewsgroup' CssClass="pl5" title="DS Tin"> 
                <i class="fa fa-list-alt fs22 text-primary"></i><br /><span class="fs11">DS Tin</span>
            </asp:LinkButton>
        </div> 

         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_editpage" runat="server" OnClick='btn_editnewsgroupfiles' CssClass="pl5" title="Thêm File"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Thêm File</span>
            </asp:LinkButton>
        </div> 
         
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_delall" runat="server" OnClick='btn_delall_Click' CssClass="pl5" title="Xóa file"> 
                <i class="fa fa-trash-o fs22 text-primary"></i><br /><span class="fs11">Xóa file</span>
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

            <asp:GridView ID="grvFiles" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="true" PageSize="1000" OnPageIndexChanging="grvFiles_PageIndexChanging" OnRowCommand="grvFiles_RowCommand"
            OnRowDataBound="grvFiles_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="NewsGroupFileID">
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
                    
                    <asp:TemplateField HeaderText="Tên File">
                        <ItemStyle CssClass="text-left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="linkTitle" runat="server" CommandName="_edit" CommandArgument='<%# Eval("NewsGroupFileID") %>'><%# Eval("Title")%></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center" />
                    </asp:TemplateField>
                   
                    <asp:HyperLinkField DataNavigateUrlFields="FileName" DataNavigateUrlFormatString="{0}"
                        DataTextField="FileName" HeaderText="File Upload">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-left" Width="250px" />
                    </asp:HyperLinkField>

                  
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center" Width="60px" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="_edit" CommandArgument='<%# Eval("NewsGroupFileID") %>' ToolTip="Sửa File">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("NewsGroupFileID") %>' ToolTip="Xóa File">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>
            

            <div class="form-group ">
                <div class="col-lg-12 text-left">
  
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Thêm File" OnClick="btn_editnewsgroupfiles" />
                <asp:Button runat="server" ID="Button5" CssClass="btn btn-sm btn-primary mr10" Text="Xóa File" OnClick="btn_delall_Click" />
                <asp:Button runat="server" ID="Button1" CssClass="btn btn-sm btn-primary mr10" Text="DS Tin" OnClick="btn_listnewsgroup" />
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>

<asp:HiddenField ID="hddNewsGroupID" runat="server" />

