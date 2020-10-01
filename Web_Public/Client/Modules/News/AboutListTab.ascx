<%@ control language="C#" autoeventwireup="true" CodeFile="AboutListTab.ascx.cs" inherits="Client_AboutListTab" %>
<link href="<%= ResolveUrl("~/") %>Scripts/tab_announce/tabdetail.css" rel="stylesheet" type="text/css" />
<link href="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.css" rel="stylesheet" type="text/css" />
<script src="<%=ResolveUrl("~/")%>Scripts/quickpager/quickpager.jquery.js" type="text/javascript"></script>

 <script type="text/javascript" language="javascript">
     function share_zing() { u = location.href; window.open("http://link.apps.zing.vn/share?u=" + encodeURIComponent(u)); }
     function share_govn() { u = location.href; window.open("http://my.go.vn/share.aspx?url=" + encodeURIComponent(u)); }
     function share_twitter() { u = location.href; t = document.title; window.open("http://twitter.com/home?status=" + encodeURIComponent(u)); }
     function share_facebook() { u = location.href; t = document.title; window.open("http://www.facebook.com/share.php?u=" + encodeURIComponent(u) + "&t=" + encodeURIComponent(t)); }
     function share_google() { u = location.href; t = document.title; window.open("http://www.google.com/bookmarks/mark?op=edit&bkmk=" + encodeURIComponent(u) + "&title=" + t + "&annotation=" + t); }
     function share_buzz() { u = location.href; t = document.title; window.open("http://buzz.yahoo.com/buzz?publisherurn=DanTri&targetUrl=" + encodeURIComponent(u)); }
     function addto_linkhay() {
         u = location.href; t = document.title; window.open("http://linkhay.com/submit?link_url=" + encodeURIComponent(u));
     }
     function OpenPopup(_url, width, height) {
         window.open(_url, '_blank', 'scrollbars=yes,resizable=yes,locationbar=yes,width=' + width + ',height=' + height + ',left='.concat((screen.width - 1000) / 2).concat(',top=').concat((screen.height - 250) / 2));
     }
</script>

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
    </div>

    <div class="tintuc_col-main" id="tintuc_col1" runat="server">
        <asp:Literal ID="ltlCateLink" runat="server"></asp:Literal>
        <div class="r-ro">
            <div class="tangbanbe_s">
                <a title="Chia sẻ link qua Facebook" onclick="javascript:share_facebook();" href="javascript:void(0)">
                    <img width="16" height="16" border="0" alt="Share Facebook" style="vertical-align: middle;
                        cursor: pointer" src="<%=ResolveUrl("~/")%>images/btn_facebook.gif" />
                </a><a title="Share Twitter" onclick="javascript:share_twitter();" href="javascript:void(0)">
                    <img width="16" height="16" border="0" alt="" style="vertical-align: middle; cursor: pointer"
                        src="<%=ResolveUrl("~/")%>images/btn_twitter.gif"/>
                </a><a title="Share Google Bookmark" onclick="javascript:share_google();"
                    href="javascript:void(0)">
                    <img width="16" height="16" border="0" alt="" style="vertical-align: middle; cursor: pointer"
                        src="<%=ResolveUrl("~/")%>images/btn_google.gif"/>
                </a><a title="Share Yahoo Buzz!" onclick="javascript:share_buzz();" href="javascript:void(0)">
                    <img width="16" height="16" border="0" alt="" style="vertical-align: middle; cursor: pointer"
                        src="<%=ResolveUrl("~/")%>images/btn_buzz.gif"/>
                </a><a title="Share qua LinkHay" onclick="javascript:addto_linkhay();" href="javascript:void(0)">
                    <img width="16" height="16" border="0" alt="" style="vertical-align: middle; cursor: pointer"
                        src="<%=ResolveUrl("~/")%>images/btn_linkhay.gif"/>
                </a>
            </div>

            <asp:Literal ID="newsTabList" runat="server"></asp:Literal>


        </div>

        
        <div class="ro m3" id="newsOther" runat="server">
            <div class="box-content-list">
                
                <h2 class="h2">
                    <a href="#"><span><%= Resources.resource.T_relation %></span></a></h2>
                <div class="box-content-main" style="padding:10px 0;">
                    <div class="boxnew-linkother">
                        <ul class="paging-other">
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

        <div class="ro m3" id="newsOther1" runat="server">
            <div class="box-content-list">
                
                <h2 class="h2">
                    <a href="#"><span><%= Resources.resource.T_NewsOther %></span></a></h2>
                <div class="box-content-main" style="padding:10px 0;">
                    <div class="boxnew-linkother">
                        <ul class="paging-other1">
                            <asp:Repeater ID="rptNewsOther1" runat="server">
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
       
    </div>
    
    
    <div class="clear">
    </div>
</div>
<!-- End Tin tuc -->
                  
    
<asp:HiddenField ID="hddGroupCate" runat="server" />
<asp:HiddenField ID="hddCateID" runat="server" />

<script type="text/javascript">

    var countries = new ddtabcontent("detailtabs")
    countries.setpersist(true)
    countries.setselectedClassTarget("link")
    countries.init()

</script>

<script type="text/javascript">
/* <![CDATA] */

$(document).ready(function() {
    $("ul.paging-other").quickPager({pageSize:10});
});

/* ]]> */
</script>