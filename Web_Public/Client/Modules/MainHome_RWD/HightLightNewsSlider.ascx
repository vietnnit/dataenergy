<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HightLightNewsSlider.ascx.cs"
    Inherits="Client_Modules_HightLightNewsSlider" %>
<div class="col-lg-4 col-md-4 col-sm-6 col-xs-24">
    <div class="box-news-thumb-hot news-slider-hot">
        <ul class="list-unstyled owl-ts-v1-hot">
            <asp:Repeater ID="rptHotNews" runat="server">
                <ItemTemplate>
                    <li class="item">
                        <div class="thumbnail no-thumbnail pln prn ptn pbn">
                            <a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                title="<%# Eval("Title")%>">
                                <div class="embed-image ratio-16-9">
                                    <img src="<%# (Eval("ImageThumb").ToString() != "") ? Utils.getURLThumbImage(Eval("ImageThumb").ToString(), 330): Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg",330) %>"
                                        alt="<%# Eval("Title") %>" class="img-responsive" />
                                </div>
                            </a>
                        </div>
                        <div class="news-slider-hot-title">
                            <a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                title="<%# Eval("Title")%>">
                                <%# Eval("Title") %>
                            </a>
                        </div>
                        <p>
                            <%# Tool.SubString(Tool.StripTagsCharArray(Eval("ShortDescribe").ToString()),250) %>
                        </p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
<asp:HiddenField ID="hddValue3" runat="server" Value="HotNews_Adv"/>

