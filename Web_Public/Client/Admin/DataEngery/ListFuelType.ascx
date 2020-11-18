<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListFuelType.ascx.cs" Inherits="Client_Admin_ListFuelType" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagPrefix="uc1" TagName="PagingControl" %>
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
             <asp:HyperLink ID="btn_new" runat="server" NavigateUrl="~/Admin/CreateFuelType/Default.aspx" CssClass="pl5" title="Tạo mới"> 
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
            <asp:Literal ID="clientview" runat="server"></asp:Literal>
            <div class="row">
                <div class="col-lg-12">
                    <div class="dataTables_length">
                        <label>
                            <asp:Literal ID="ltrTotal" runat="server"></asp:Literal></label>
                    </div>
                </div>               
            </div>
            <div class="table-responsive mb20">
            <asp:GridView ID="grvArea" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
            AllowPaging="false" EmptyDataText="Không tìm thấy bản ghi nào">
                <HeaderStyle CssClass="primary fs12" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="Id">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="30px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Sắp xếp">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="50px" />
                        <ItemTemplate>
                            <div style="position:relative;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOrder"
                            ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txtOrder"
                                MaximumValue="1000" MinimumValue="0" Type="Integer"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RangeValidator>
                           <asp:TextBox ID="txtOrder" runat="server" CssClass="form-control input-sm text-center" Text='<%# Eval("SortOrder")%>'></asp:TextBox>
                       </div>
                        </ItemTemplate>
                    </asp:TemplateField>                                       
                    <asp:TemplateField HeaderText="Loại nhiên liệu">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%# Eval("Title")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>   
                    <asp:TemplateField HeaderText="Mã loại nhiên liệu">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%# Eval("GroupCode")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>         
                    <asp:TemplateField HeaderText="Đơn vị tính">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%# Eval("MeasurementName")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>                                                            
                    <%--<asp:CheckBoxField DataField="IsActive" HeaderText="Trạng thái">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="35px" />
                    </asp:CheckBoxField>--%>
          
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemStyle CssClass="text-center" />
                        <HeaderStyle CssClass="text-center p5" Width="60px" />
                        <ItemTemplate>
                            <a href='<%#ResolveUrl("~") %>Admin/CreateFuelType/<%#Eval("Id") %>/Default.aspx'>
                                     <span class="glyphicons glyphicons-edit fs18" ></span></a>                                                               
                                    <asp:LinkButton ID="btn_delete" OnClick="btnDelete_Click" runat="server" CommandName="_delete" CommandArgument='<%# Eval("Id") %>' ToolTip="Xóa danh mục">
                                    <span class="glyphicons glyphicons-remove_2 fs18" ></span>
                                    </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">
                <asp:Button runat="server" ID="btn_edit2" CssClass="btn btn-sm btn-primary mr10" Text="Sắp xếp" OnClick="btn_Order_Click" />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/CreateFuelType/Default.aspx" CssClass="btn btn-sm btn-system mr10" Text="Thêm mới" />
                
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
