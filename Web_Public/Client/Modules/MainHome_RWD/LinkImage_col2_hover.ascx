<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkImage_col2_hover.ascx.cs"
    Inherits="Client_LinkImage_col2_hover" %>
<div class="boxlight">
        <asp:Repeater ID="rptWebLink" runat="server">
            <ItemTemplate>
               <%-- <div <%#((((RepeaterItem)Container).ItemIndex + 1) % 2 == 0) ? "class='col_link2-r'" : "class='col_link2-l'"%> >--%>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-24 box<%# (((RepeaterItem)Container).ItemIndex)%2 %>">
                     <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target="<%# Eval("Target")%>" class="div_bg<%#((RepeaterItem)Container).ItemIndex%>">
                    
                        <h2>
                            <%# Eval("MenuLinksName")%></h2>
                            <%--<span class="spotlight-roll" ></span>--%>
                        <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img class='lazy' src='" + Eval("MenuLinksIcon") + "'style='display: inline;' alt='" + Eval("MenuLinksName") + "'>" : "<img class='lazy' src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='display: inline;' alt='" + Eval("MenuLinksName") + "'>"%>
                    </a>
                </div>
                
            </ItemTemplate>
        </asp:Repeater>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
<%--<script type="text/javascript">
    $(function () {
        $(".spotlight-roll").css("opacity", "0");
        $(".spotlight-roll").hover(function () {
            $(this).stop().animate({
                opacity: 0.7
            }, "slow");
        },
        function () {
            $(this).stop().animate({
                opacity: 0
            }, "slow");
        });
    });
</script>--%>