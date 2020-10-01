<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Link_Text.ascx.cs" Inherits="Client_Link_Text" %>
<div class="margin-10l">
    <div class="box-content-social">
        <h2 class="h2">
            <a href="javascript:void(0)" class='h2-cate'><span>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></span></a></h2>
        <div class="box-content-main">
            <asp:Repeater ID="rptWebLink" runat="server">
                <ItemTemplate>
                   
                            <div class="news-list-icon">
                                <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target='<%# Eval("Target")%>'>
                                    <span>
                                        <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img  src='" + Eval("MenuLinksIcon") + "'style='border-width: 0px;' alt='" + Eval("MenuLinksName") + "'>" : "<img src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='border-width: 0px;' alt='" + Eval("MenuLinksName") + "'>"%>
                                        <%# Eval("MenuLinksName")%>
                                    </span></a>
                                <div class="clr">
                                </div>
                            </div>
                       
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
    <asp:HiddenField ID="hddValue" runat="server" />
    <asp:HiddenField ID="hddRecord" runat="server" />
