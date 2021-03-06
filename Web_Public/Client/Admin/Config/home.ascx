﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="home.ascx.cs" Inherits="Admin_Controls_Main" %>
<!-- Start: Topbar -->
<header id="topbar">
    <div class="topbar-left">
        <ol class="breadcrumb">
            <li class="crumb-active">
                <a href="#">Quản trị hệ thống</a>
            </li>
            <li class="crumb-icon">
                <a href="/Admin/Home/Default.aspx">
                    <span class="glyphicon glyphicon-home"></span>
                </a>
            </li>
                        
        </ol>
    </div>
    <div class="topbar-right">
                    
        <div class="ml15 ib va-m">
            <a href="#" class="pl5" title="Trợ giúp"> <i class="fa fa-exclamation-circle fs22 text-primary"></i>
            </a>
        </div>
    </div>
</header>
<!-- End: Topbar -->
<!-- Begin: Content -->
<section id="content">

<!-- Dashboard Tiles -->
<div class="row mb10">
<div class="panel-group accordion" id="panelHomeCollapse">
    <asp:Repeater ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
  
            <ItemTemplate>

            <div class="panel">
                <div class="panel-heading">
                    <a class="accordion-toggle accordion-icon" data-toggle="collapse" data-parent="#panelHomeCollapse" href="#panel-<%# Eval("Modules_ID")%>"><%# Eval("Modules_Name")%></a>
                </div>
                <div id="panel-<%# Eval("Modules_ID")%>" class="panel-collapse collapse in">
                    <div class="panel-body">
                    
                        <asp:Repeater ID="DataList2" runat="server" >
                                <ItemTemplate>
                                 
                                     <div class="col-xs-6 col-sm-3 col-md-3 col-lg-2 ph10 mb10 text-center link_module">
                                         <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/Admin/" + Eval("Slug") +"/Default.aspx"%>'
                                                ToolTip='<%# Eval("Modules_Name")%>' CssClass="holder-style p10 mh-100">
                                           
                                           <span class="<%# (Eval("Modules_Help").ToString()!="")?Eval("Modules_Help").ToString():"fa fa-edit text-i-primary" %> holder-icon br64 bg-light dark p15 ph20"></span>

                                            <br> <%# Eval("Modules_Name")%>
                                        </asp:HyperLink>
                                    </div>
                                  
                                </ItemTemplate>
                           </asp:Repeater>
                    </div>
                </div>
            </div>

            </ItemTemplate>
       </asp:Repeater>
</div>
 </div>

</section>
