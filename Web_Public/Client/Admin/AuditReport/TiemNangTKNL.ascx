<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TiemNangTKNL.ascx.cs"
    Inherits="Client_Admin_Audit_TiemNangTKNL" %>
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
                        <label class="col-lg-2 control-label pt5" for="inputSmall">Sở công thương</label>                
                        <div class="col-lg-4">
                            <asp:DropDownList ID="ddlOrg" runat="server" CssClass="form-control input-sm"  ValidationGroup="vgSearch">
                                </asp:DropDownList>    
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlOrg" Display="Dynamic"  ValidationGroup="vgSearch"
                                ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>--%>
                        </div>
                        <label class="col-lg-2 control-label">Lĩnh vực</label>
                        <div class="col-lg-4">                     
                                <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="True"
                                    CssClass="form-control input-sm" ValidationGroup="view" >
                                </asp:DropDownList>                                                                    
                        </div>
                    </div>     
                    <div class="form-group">
                        <div class="col-lg-2 control-label"> 
                            <label>
                               Năm kiểm toán
                            </label>
                        </div>
                        <div class="col-lg-4">                     
                            <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="True"
                                CssClass="form-control input-sm" ValidationGroup="view">
                            </asp:DropDownList>   
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlYear" Display="Dynamic" ValidationGroup="vgSearch"
                                ErrorMessage="RequiredFieldValidator"><span class="append-icon right text-danger"><i class="fa fa-exclamation-triangle"></i></span></asp:RequiredFieldValidator>                                                                 --%>
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
            <asp:Literal ID="ltTotal" runat="server"></asp:Literal>
            </p>
             <div class="row mb20 right">
                <uc1:PagingControl ID="Paging2" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
            LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
            </div>
            <div class="table-responsive">
                <table class="table table-bordered table-hover mb10" width="100%">
                    <thead>
                        <tr class="text-center">
                            <th style="width: 5%" class="text-center">
                                STT
                            </th>
                            <th style="width: 30%" class="text-center">
                                Doanh nghiệp
                            </th>
                            <th style="width: 10%" class="text-center">
                                Năm kiểm toán
                            </th>
                                <th style="width: 10%" class="text-center">
                                Năm cơ sở
                            </th>                                                                                                                                                                           
                             <th style="width: 20%" class="text-center">
                                Năng lượng tiêu thụ (TOE)
                            </th>
                            <th style="width: 20%" class="text-center">
                                Tiềm năng tiết kiệm NL
                            </th>      
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptAuditReport" runat="server" OnItemDataBound="rptAuditReport_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1  %>
                                    </td>
                                        <td>
                                        <a href='<%#ResolveUrl("~") %>Admin/ViewAuditReportBCT/<%#Eval("Id")%>/Default.aspx'>
                                            <%#Eval("Title")%>
                                        </a>
                                    </td>
                                    <td>
                                        <a href='<%#ResolveUrl("~") %>Admin/ViewAuditReportBCT/<%#Eval("Id")%>/Default.aspx'>
                                            <%#Eval("AuditYear")%>
                                        </a>
                                    </td>     
                                    <td>
                                        <a href='<%#ResolveUrl("~") %>Admin/ViewAuditReportBCT/<%#Eval("Id")%>/Default.aspx'>
                                            <%#Eval("DataYear")%>
                                        </a>
                                    </td>                                         
                                    <td class="text-right">
                                        <asp:Literal ID="ltTotalTOE" runat="server"></asp:Literal>
                                    </td>        
                                    <td class="text-right">
                                        <asp:Literal ID="ltSaveTOE" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
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
