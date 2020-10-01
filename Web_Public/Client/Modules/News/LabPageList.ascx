<%@ control language="C#" autoeventwireup="true" CodeFile="LabPageList.ascx.cs" inherits="Client_Modules_News_LabPageList" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>

<div class="blog-page page_list"> 
     <div class="row box-white mb10 mln mrn">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <!--Blog Post-->
            <asp:Repeater ID="rptListNewsGroup" runat="server">
                    <ItemTemplate>
                         <div class="row blog blog-medium">
                            <%# (Eval("ImageThumb").ToString() != "") ? "<div class='col-md-4'><a  href='" + ResolveUrl("~/") + "d4/thi-nghiem-v/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx' title='" + Eval("Title") + "'><div class='embed-image ratio-16-9 thumbnail-style thumbnail-kenburn'><img src='" + Utils.getURLThumbImage(Eval("ImageThumb").ToString(), 350) + "' alt='" + Eval("Title") + "' class='img-responsive'> </div></a></div><div class='col-md-8'>" : "<div class='col-md-12'>"%>
                  
                    
                                <h2>
                                     <a href="<%# ResolveUrl("~/")+ "d4/thi-nghiem-v/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>" title="<%# Eval("Title")%>">
                                        <%# Eval("Title") %>
                                    </a>
                                </h2>
                                <ul class="list-unstyled list-inline blog-info">
                                    <li><i class="fa fa-calendar"></i> <%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %></li>
                                </ul>
                                <p>
                                    <%# Tool.SubString(Tool.StripTagsCharArray(Eval("ShortDescribe").ToString()),300) %>
                                </p>
                                <p><a class="btn-u btn-u-sm pull-right" href=""<%# ResolveUrl("~/")+ "d4/thi-nghiem-v/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>" title="<%# Eval("Title")%>">Chi tiết... <%--<i class="fa fa-angle-double-right margin-left-5"></i>--%></a></p>
                            
                            </div>    
                            
                        </div>
                        <hr class="mt10 mb20"/>
                    </ItemTemplate>
                </asp:Repeater>
             <!--End Blog Post-->   
        </div>
    </div>
</div>     



<div id="newsOther" runat="server">
    <div class="row box-white mb10 mln mrn">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="media">
                <h3><%= Resources.resource.T_NewsOther%></h3>
                <div class="media-body">
                    <ul class="list-unstyled save-job">
                        
                        <asp:Repeater ID="rptListNewsOther" runat="server">
                            <ItemTemplate>
                                <li class="pt5"><i class="fa fa-caret-right color-blue"></i>
                                    <a href="<%# ResolveUrl("~/") + "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>" title="<%# Eval("Title") %>">
                                        <%# Eval("Title") %>
                                        <span style="color:#6D6D6D; font-size: 12px;font-style:italic;">(<%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %>)</span>
                                        </a>   
                                    </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="row box-white mb10 mln mrn" id="panel_page" runat="server">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     
            <div class="box-pages pull-right mr20 mb15">
                 <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="<%$ Resources:Resource, T_Top %>"
                     LastString="<%$ Resources:Resource, T_Last %>" NextString="<%$ Resources:Resource, T_Next %>" PrevString="<%$ Resources:Resource, T_Back %>" />
             </div>
       
    </div>
</div>

<div id="panelDate" runat="server">
    <div class="row box-white mb10 mln mrn">
         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="row form-date mb5">
                <div class="sky-form no-border">
                    <div class="col-lg-4">
                        <label class="input">
                            <i class="icon-append fa fa-calendar"></i>
                            <asp:TextBox ID="dateFrom" runat="server" placeholder="Xem từ ngày"></asp:TextBox>
                        </label>
                    </div>
                    <div class="col-lg-4">
                        <label class="input">
                            <i class="icon-append fa fa-calendar"></i>
                            <asp:TextBox ID="dateTo" runat="server" placeholder="đến ngày"></asp:TextBox>
                        </label>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button runat="server" ID="LinkButton2" CssClass="btn-u" Text="<%$ Resources:Resource, T_View %>" OnClick="btn_search_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

    
<asp:HiddenField ID="hddGroupCate" runat="server" />
<asp:HiddenField ID="hddCateID" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />

<script type="text/javascript">
    jQuery(function ($) {
        $.datepicker.setDefaults($.datepicker.regional['vi']);
        $("#<%= dateFrom.ClientID %>").datepicker({

            defaultDate: "+1w",
            changeMonth: true,
            numberOfMonths: 1,
            dateFormat: "dd/mm/yy",
            onClose: function (selectedDate) {
                $("#<%= dateTo.ClientID %>").datepicker("option", "minDate", selectedDate);
            }
        });
        $("#<%= dateTo.ClientID %>").datepicker({

            defaultDate: "+1w",
            changeMonth: true,
            numberOfMonths: 1,
            dateFormat: "dd/mm/yy",
            onClose: function (selectedDate) {
                $("#<%= dateFrom.ClientID %>").datepicker("option", "maxDate", selectedDate);
            }
        });
    });
  </script>