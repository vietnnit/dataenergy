<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Link_TextImage_1Item.ascx.cs"
    Inherits="Client_Link_TextImage_1Item" %>
<div class="margin-25t margin-25b">
    <asp:Repeater ID="rptWebLink" runat="server">
        <ItemTemplate>
            <div class="crescat">
            <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target='<%# Eval("Target")%>'>
              
                    <div class="col-lg-16 col-md-16 hidden-xs hidden-sm padding-0l padding-0r">
                        <div class="crescat-img">
                            <img src="<%# Eval("MenuLinksIcon")%>" alt="<%# Eval("MenuLinksName")%>" class="lazy" style="display: inline;">
                         </div>   
                     </div>
                       
                    <div class="col-lg-8 col-md-8">
                        <div id="latin">
                            <h2>
                                <%# Eval("MenuLinksName")%></h2>
                            <p>
                                 <%# Eval("MenuLinksHelp")%></p>
                        </div>
                        <div id="english">
                            <h2>
                                <%# Eval("MenuLinksName")%></h2>
                            <p>
                                 <%# Eval("MenuLinksHelp")%></p>
                        </div>
                    </div>
                
            </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
