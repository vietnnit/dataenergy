<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Link_Image_Text_Sroll.ascx.cs"
    Inherits="Client_Modules_MainHome_RWD_Link_Image_Text_Scroll" %>

<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <div class="headline">
        <h2>
            <asp:Label ID="lblTitle" runat="server" Text="Dự án mới"></asp:Label>
        </h2>
    </div>
    <div class="row pt5">
        <div class="illustration-v2">
            <ul class="list-unstyled owl-slider">
                <asp:Repeater ID="rptWebLink" runat="server">
                    <ItemTemplate>
                        <li class="item">
                            <div class="product-img">
                                <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>">
                                    <div class="embed-image ratio-16-9 thumbnail-style thumbnail-zoom">
                                        <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img class='img-responsive' src='" + ((Eval("MenuLinksIcon").ToString() != "") ? Utils.getURLThumbImage(Eval("MenuLinksIcon").ToString(), 330) : Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 330)) + "' style='display: inline;' alt='" + Eval("MenuLinksName") + "'>" : "<img class='lazy' src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='display: inline;' alt='" + Eval("MenuLinksName") + "'>"%>
                                    </div>
                                </a>
                            </div>
                            <div class="product-description product-description-brd">
                                <div class="overflow-h margin-bottom-5">
                                    <div class="pull-left">
                                        <h4 class="title-price">
                                            <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>">
                                                <%# Eval("MenuLinksName")%>
                                            </a>
                                        </h4>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
