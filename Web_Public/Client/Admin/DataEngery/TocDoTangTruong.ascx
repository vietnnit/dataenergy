<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TocDoTangTruong.ascx.cs"
    Inherits="Client_Admin_DataEnergy_TocDoTangTruong" %>
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
                        <label class="col-lg-2 control-label pt5" for="inputSmall">Sở công thương<span class="text-danger"> *</span></label>                
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control input-sm"  ValidationGroup="vgSearch">
                                </asp:DropDownList>    
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlOrg" Display="Dynamic"  ValidationGroup="vgSearch"
                                ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>--%>
                        </div>
                        <label class="col-lg-2 control-label" for="inputSmall">Lĩnh vực</label>
                        <div class="col-lg-4">                     
                                <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True"
                                    CssClass="form-control input-sm" ValidationGroup="view" >
                                </asp:DropDownList>                                                                    
                        </div>
                    </div>     
                    <div class="form-group">
                        <div class="col-lg-2 control-label"> 
                            <label>
                               Số liệu năm<span class="text-danger"> *</span>
                            </label>
                        </div>
                        <div class="col-lg-4">                     
                            <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True"
                                CssClass="form-control input-sm" ValidationGroup="view">
                            </asp:DropDownList>   
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlYear" Display="Dynamic" ValidationGroup="vgSearch"
                                ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>                                                                 
                        </div>   
                        <label class="col-lg-2 control-label pt5" for="inputSmall">Từ khóa</label>
                        <div class="col-lg-4">
                                <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Tên doanh nghiệp"></asp:TextBox>
                        </div>                                                                 
                    </div>  
                    <div class="form-group">
                      <div class="col-lg-2 control-label"> 
                            <label>
                               
                            </label>
                        </div>
                        <div class="col-lg-6">
                            <asp:Button runat="server" ID="btn_search" CssClass="btn btn-sm btn-alert mr10" Text="Tìm kiếm" OnClick="btn_search_Click" ValidationGroup="vgSearch" />
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
            AllowPaging="false" EmptyDataText="Không tìm thấy bản ghi nào" 
                    onrowdatabound="grvNewsGroup_RowDataBound">
                <HeaderStyle CssClass="primary fs12" />
                <Columns>                    
                     <asp:TemplateField HeaderText="STT" ItemStyle-Width="30px">
                        <ItemStyle CssClass="text-center" />
                        <ItemTemplate>
                            <%#Eval("row")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>                                                   
                    <asp:TemplateField HeaderText="Tên doanh nghiệp">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%# Eval("Title")%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>                    
                   
                    <asp:TemplateField HeaderText="Địa chỉ">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <%#Eval("Address") %>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>    
                    <asp:TemplateField HeaderText="Kế hoạch (TOE)">
                        <ItemStyle CssClass="text-right" />
                        <ItemTemplate>                            
                             <asp:Literal ID="ltTOEPlan" runat="server"></asp:Literal>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>                
                    <asp:TemplateField HeaderText="Số liệu năm">
                        <ItemStyle CssClass="TextLeft" />
                        <ItemTemplate>
                            <asp:Literal ID="ltImportant" runat="server"></asp:Literal>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TOE so với năm trước">
                        <ItemStyle CssClass="text-right" />
                        <ItemTemplate>                            
                             <asp:Literal ID="ltSpeed" runat="server"></asp:Literal>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="TOE so với KH">
                        <ItemStyle CssClass="text-right" />
                        <ItemTemplate>                            
                             <asp:Literal ID="ltSpeed2" runat="server"></asp:Literal>
                        </ItemTemplate>
                        <HeaderStyle CssClass="text-center p5" />
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="IsActive" HeaderText="DN đang hoạt động" ItemStyle-CssClass="text-center"/>                    
                </Columns>
            </asp:GridView>
                <div class="row mb20 right">
                    <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                </div>
            </div>
            <div class="form-group ">
                <div class="col-lg-12 text-left">                
               
                </div>
            </div>
        </div>
    </div>
   

</div>
</section>
<asp:HiddenField ID="hddGroup" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
