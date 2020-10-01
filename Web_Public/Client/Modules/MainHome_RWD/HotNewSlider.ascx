<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HotNewSlider.ascx.cs"
    Inherits="Client_HotNewSlider" %>


<div class="col-lg-6 col-md-6 col-sm-8 col-xs-24">
    <div class="carousel slide carousel-v1 margin-bottom-10" id="sliderHotnews" style="box-shadow:0 1px 2px rgba(0,0,0,.1);-moz-box-sizing:border-box;box-sizing:border-box;">
            <%--<ol class="carousel-indicators">
                <asp:Repeater ID="rptHotNewsPage" runat="server">
                    <ItemTemplate>
                        <li data-target="#sliderHotnews" data-slide-to="<%#((RepeaterItem)Container).ItemIndex %>"
                            <%#(((RepeaterItem)Container).ItemIndex ==0)?"class='active'":"" %>></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ol>--%>
            <div class="carousel-inner">
                <asp:Repeater ID="rptHotNews" runat="server">
                    <ItemTemplate>
                        <div class="item <%#(((RepeaterItem)Container).ItemIndex ==0)?"active":"" %> ">
                            <div class="thumbnail no-thumbnail">
                                <a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                    title="<%# Eval("Title")%>">
                                    <div class="embed-image ratio-16-9">
                                        <img src="<%# (Eval("ImageLarge").ToString() != "") ? Utils.getURLThumbImage(Eval("ImageLarge").ToString(), 500): (Eval("ImageThumb").ToString() != "") ? Utils.getURLThumbImage(Eval("ImageThumb").ToString(), 500): Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg",500) %>"
                                            alt="<%# Eval("Title") %>" class="img-responsive" />
                                    </div>
                                </a>
                            </div>
                            <div class="carousel-caption">
                                <a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                    title="<%# Eval("Title")%>">
                                    <p>
                                        <%# Eval("Title") %>
                                    </p>
                                </a>
                                <%-- <p class='blurb whitealpha hidden-xs'>
                                <%# Eval("ShortDescribe") %>
                            </p>--%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="carousel-arrow">
                

                <a data-slide="prev" href="#sliderHotnews" class="left carousel-control">
                    <i class="icon-custom icon-sm rounded-x icon-color-blue icon-line fa fa-chevron-left"></i>
                </a>
                <a data-slide="next" href="#sliderHotnews" class="right carousel-control">
                    <i class="icon-custom icon-sm rounded-x icon-color-blue icon-line fa fa-chevron-right"></i>
                </a>
            </div>
          
    </div>
</div>
<div class="col-lg-3 col-md-3 col-sm-4 col-xs-24">
    <div class="margin-20t">
        <ul class="news-thumb">
            <asp:Repeater ID="rptLListNews" runat="server">
                <ItemTemplate>
                    <li><a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                        title="<%# Eval("Title")%>">
                        <img src="<%# (Eval("ImageLarge").ToString() != "") ? Utils.getURLThumbImage(Eval("ImageLarge").ToString(), 100): (Eval("ImageThumb").ToString() != "") ? Utils.getURLThumbImage(Eval("ImageThumb").ToString(), 100): Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg",100) %>"
                            alt="<%# Eval("Title") %>" width="100px" class="image loaded"/>
                        <div class="caption">
                            <span class="title">
                                <%# Eval("Title") %></span> <span class="sourcename">
                                    <%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %>
                                </span>
                        </div>
                    </a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
