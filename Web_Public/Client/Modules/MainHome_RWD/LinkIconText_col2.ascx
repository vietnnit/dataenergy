<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkIconText_col2.ascx.cs"
    Inherits="Client_LinkIconText_col2" %>

    <asp:Repeater ID="rptWebLink" runat="server">
        <ItemTemplate>
            <div class="col-lg-12 col-md-12 col-sm-24 col-xs-24 ">
                <div class="linkicon_text_a link2_bg_<%#((RepeaterItem)Container).ItemIndex + 1 %>">
                    
                    <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target='<%# Eval("Target")%>'>
                        <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img class='hidden-md' src='" + Eval("MenuLinksIcon") + "'style='border-width: 0px;' alt='" + Eval("MenuLinksName") + "'>" :""%>
                        <h2>
                            
                            <%# Eval("MenuLinksName")%>
                        </h2>
                    </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
