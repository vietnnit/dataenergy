<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkImage_col1_hover.ascx.cs"
    Inherits="Client_LinkImage_col1_hover" %>
<div class="boxlightfulladv">
        <asp:Repeater ID="rptWebLink" runat="server">
            <ItemTemplate>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 box<%# (((RepeaterItem)Container).ItemIndex)%2 %>">
                     <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target="<%# Eval("Target")%>" class="div_bg<%#((RepeaterItem)Container).ItemIndex%>">
                        <h2>
                            <%# Eval("MenuLinksName")%></h2>
                        <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img class='lazy' src='" + Eval("MenuLinksIcon") + "'style='display: inline;' alt='" + Eval("MenuLinksName") + "'>" : "<img class='lazy' src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='display: inline;' alt='" + Eval("MenuLinksName") + "'>"%>
                    </a>
                </div>
                
            </ItemTemplate>
        </asp:Repeater>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
