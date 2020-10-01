<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockWebLink_col2.ascx.cs"
    Inherits="Client_BlockWebLink_col2" %>
<div class="r-ro">
    <div class="box-adv" style="padding-top:10px;">
        <asp:Repeater ID="rptWebLink" runat="server">
            <ItemTemplate>
                <div class="grid-box width50">
                    <div class="module deepest">
                        <div class="news-list-link-f">
                            <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target='<%# Eval("Target")%>'>
                                <span>
                                    <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img  src='" + Eval("MenuLinksIcon") + "'style='border-width: 0px;' alt='" + Eval("MenuLinksName") + "'>" : "<img src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='border-width: 0px;' alt='" + Eval("MenuLinksName") + "'>"%>
                                    <%# Eval("MenuLinksName")%>
                                </span></a>
                            <div class="clr"></div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
</div>
  <div class="clr"></div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
