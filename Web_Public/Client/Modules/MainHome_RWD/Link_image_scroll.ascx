<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Link_image_scroll.ascx.cs"
    Inherits="Client_Link_image_scroll" %>
<div class="row">
    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 adv-slider-hot">
        <ul class="list-unstyled owl-ts-v1-img">
            <asp:Repeater ID="rptWebLink" runat="server">
                <ItemTemplate>
                    <li class="item">
                        <div class="thumbnail no-thumbnail pln prn ptn pbn">
                           <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target="<%# Eval("Target")%>">
                                <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img src='" + Eval("MenuLinksIcon") + "' alt='" + Eval("MenuLinksName") + "' class='mln mrn'>" : "<img src='" + ResolveUrl("~/") + "images/img_logo.jpg' alt='" + Eval("MenuLinksName") + "'>"%>
                            </a>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

    </div>
</div>
<asp:HiddenField ID="hddValue" Value="Adv_Partner" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
