<%@ control language="C#" autoeventwireup="true" CodeFile="NewsgList.ascx.cs" inherits="Client_NewsgList" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>


 <!-- Slider -->
<div class="ro m3">
     <div class="box-content-list">

        <h2 class="h2">
            <a href="#"><span><asp:Literal ID="title_name" runat="server"></asp:Literal></span></a></h2>

        <div class="cattitle_sub">    
            <asp:Literal ID="title_cate" runat="server"></asp:Literal>
                <div class="clr"> </div>
        </div>
         <div class="clr"></div>
       <%-- <div class="box-content-main" style="padding:10px 0 0 0;">
            <div class="box-hotnews">--%>
                <asp:Literal ID="ltlHotNewsGroup" runat="server"></asp:Literal>
                
              <%--  <div class="clear">
                </div>
            </div>
        </div>--%>
    </div>
</div>
<!-- /End Slider -->

<!-- Tin tuc -->
<div class="ro m3">
    <div class="grid_8_1" id="tintuc_col1" runat="server">
        <asp:Repeater ID="rptListNewsGroup" runat="server">
            <ItemTemplate>
                <div class="r-ro">
                            
                    <a class="list-news-lnkImg" href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>" title="<%# Eval("Title")%>">
                    
                    <%# (Eval("ImageThumb").ToString() != "") ? "<img src='" + Utils.getURLThumbImage(Eval("ImageThumb").ToString(),150) + "' alt='" + Eval("Title") + "' >" : "" %>
                     </a>
                    <a class="list-news-lnkTt" href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>" title="<%# Eval("Title")%>">
                       <%# Eval("Title") %>
                    </a>
                
                    <span style="color:#6D6D6D; font-size: 12px;">(<%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %>)</span>
                    <p class="list-news_lnkP">
                        <%# Tool.SubString(Tool.StripTagsCharArray(Eval("ShortDescribe").ToString()),260) %>
                    </p>

                    <div class="clear"></div>
                    
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="ro m3" id="newsOther" runat="server">
            <div class="box-content-list">
                
                <h2 class="h2">
                    <a href="#"><span><%= Resources.resource.T_NewsOther %></span></a></h2>
                <div class="box-content-main" style="padding:10px 0;">
                    <!-- post-container -->
                    <div class="boxnew-linkother">
                        <ul>
                            <asp:Repeater ID="rptListNewsOther" runat="server">
                                <ItemTemplate>
                                    <li class="ter">
                                        <a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>" title="<%# Eval("Title")%>">
                                           <%# Eval("Title") %>
                                        <span style="color:#6D6D6D; font-size: 12px;">(<%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %>)</span>
                                        </a>
                                     </li>
                                </ItemTemplate>
                             </asp:Repeater>
                        </ul>
                    </div>

                    
                </div>
            </div>
        </div>
        <div class="ro m3">
            <div class="box-pages">
                        <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="<%$ Resources:Resource, T_Top %>"
                            LastString="<%$ Resources:Resource, T_Last %>" NextString="<%$ Resources:Resource, T_Next %>" PrevString="<%$ Resources:Resource, T_Back %>" />
                    </div>
       </div>
       <div class="ro m3" style="padding-top:30px;" id="panelDate" runat="server">
           <span class="bold" style="float:left;line-height:26px;padding-right:5px; "><%= Resources.resource.T_FromDate %></span> 
            <asp:TextBox ID="dateFrom" runat="server" Width="80px"></asp:TextBox><img class="icon13" src="<%= ResolveUrl("~/") %>images/calendar.gif" alt="..." title="..." />
            <span class="bold"><%= Resources.resource.T_ToDate %></span> 
            <asp:TextBox ID="dateTo" runat="server" Width="80px"></asp:TextBox><img class="icon13" src="<%= ResolveUrl("~/") %>images/calendar.gif" alt="..." title="..." />
            &nbsp;<asp:LinkButton runat="server" ID="LinkButton2" CssClass="Jm dU" Text="<%$ Resources:Resource, T_View %>" OnClick="btn_search_Click" />
       </div>
    </div>
    
    <div class="grid_4_1" id="listNewsCatePanel" runat="server">
        
        <asp:Literal ID="ltlListNewsCate" runat="server"></asp:Literal>
       

    </div>
    <div class="clear">
    </div>
</div>
<!-- End Tin tuc -->
                  
    
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
            dateFormat:"dd/mm/yy",
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
//        $("#format").change(function () {
//            $("#<%= dateFrom.ClientID %>").datepicker("option", "dateFormat", "dd/MM/yyyy");
//            $("#<%= dateTo.ClientID %>").datepicker("option", "dateFormat", "dd/MM/yyyy");
//        });
    });
  </script>