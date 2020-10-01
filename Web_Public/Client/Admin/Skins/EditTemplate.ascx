<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditTemplate.ascx.cs" Inherits="Client_Admin_EditTemplate" %>

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
             <asp:HyperLink ID="btn_list" runat="server" NavigateUrl="~/Admin/EidtTemplate/Default.aspx" CssClass="pl5" title="Tạo Template"> 
                <i class="fa fa-edit fs22 text-primary"></i><br /><span class="fs11">Tạo Template</span>
            </asp:HyperLink>
        </div> 

         <div class="topbar-icon ib va-m">
            <asp:LinkButton ID="btn_add" runat="server" OnClick='btn_add_Click' CssClass="pl5" title="Lưu lại" ValidationGroup="AddForm"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Lưu lại</span>
            </asp:LinkButton>
        </div>
          
         <div class="topbar-icon ml15 ib va-m">
            <asp:LinkButton ID="btn_edit" runat="server" OnClick='btn_edit_Click' CssClass="pl5" title="Cập nhật" ValidationGroup="AddForm"> 
                <i class="fa fa-save fs22 text-primary"></i><br /><span class="fs11">Cập nhật</span>
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
            <div class="col-lg-6 col-sm-12">
                 <div class="form-horizontal">

                  <div class="form-group">
                    <label class="col-lg-4 control-label" for="inputSmall">Tên Template</label>
                    <div class="col-lg-8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ValidationGroup="AddForm"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-sm" placeholder="Nhập tên Template" ValidationGroup="AddForm"></asp:TextBox>
                    </div>
                </div>

                 <div class="form-group">
                        <label class="col-lg-4 control-label" for="inputSmall">Control (Url)</label>
                        <div class="col-lg-8">
                     
                             <asp:DropDownList ID="dropControl" runat="server" CssClass="form-control input-sm" ValidationGroup="AddForm">
                            </asp:DropDownList>

                        </div>
                    </div>

                 <div class="form-group">
                        <label class="col-lg-4 control-label" for="inputSmall">MasterPage (Url)</label>
                        <div class="col-lg-8">
                     
                             <asp:DropDownList ID="ddlMasterPage" runat="server" CssClass="form-control input-sm" ValidationGroup="AddForm">
                            </asp:DropDownList>

                        </div>
                    </div> 


           

                <div class="form-group">
                    <label class="col-lg-4 control-label" for="inputSmall">Mô tả Template</label>
                    <div class="col-lg-8">
                       <asp:TextBox ID="txtInfo" runat="server" Height="50px" TextMode="MultiLine" Text="" class="form-control input-sm" ValidationGroup="AddForm"></asp:TextBox>
                                   

                    </div>
                </div>

              

            </div>
            </div>
            <div class="col-lg-6 col-sm-12">
                <div class="table-responsive mb20">
                <asp:GridView ID="grvTemplate" runat="server" AllowPaging="True" PageSize="1000" 
                        AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
                        Width="100%" OnPageIndexChanging="grvTemplate_PageIndexChanging" OnRowCommand="grvTemplate_RowCommand"
                        OnRowDataBound="grvTemplate_RowDataBound" EmptyDataText="Không tìm thấy bản ghi nào">
                        <HeaderStyle CssClass="primary fs12" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="gridviewHeader" Width="40px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Tên Template">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="gridviewHeader" />
                                <ItemTemplate>
                                   <asp:LinkButton ID="LinkButton1" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ID") %>'>
                                       <%# Eval("TemplateName")%>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="TemplateControl" HeaderText="Control">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="gridviewHeader" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MasterControl" HeaderText="MasterPage">
                                <ItemStyle CssClass="text-left" />
                                <HeaderStyle CssClass="gridviewHeader" Width="120px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Chức năng ">
                                <ItemStyle CssClass="text-center" />
                                <HeaderStyle CssClass="gridviewHeader" Width="60px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btn_edit4" runat="server" CommandName="_edit" CommandArgument='<%# Eval("ID") %>' ToolTip="Sửa Template" ValidationGroup="EditForm">
                                    <span class="glyphicons glyphicons-edit fs18" ></span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btn_delete" runat="server" CommandName="_delete" CommandArgument='<%# Eval("ID") %>' ToolTip="Xóa Template" ValidationGroup="EditForm">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </div>
            </div>

            <div class="form-group">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_add1" CssClass="btn btn-sm btn-primary mr10" Text="Lưu lại" OnClick="btn_add_Click" ValidationGroup="AddForm"/>
                <asp:Button runat="server" ID="btn_add2" CssClass="btn btn-sm btn-primary mr10" Text="Lưu & thêm mới" OnClick="btn_add_Click_more" ValidationGroup="AddForm"/>
                <asp:Button runat="server" ID="btn_edit1" CssClass="btn btn-sm btn-primary mr10" Text="Cập nhật" OnClick="btn_edit_Click" ValidationGroup="AddForm"/>

                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Admin/EditTemplate/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" ValidationGroup="AddForm"/>
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="btn btn-sm btn-system" NavigateUrl="~/Admin/home/Default.aspx" Text="Trang chủ" />
                </div>
            </div>


        </div>
    </div>
   

</div>
</section>
<asp:HiddenField ID="hddID" runat="server" />