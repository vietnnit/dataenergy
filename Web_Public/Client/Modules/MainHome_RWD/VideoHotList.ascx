<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoHotList.ascx.cs"
    Inherits="Client_VideoHotList" %>
<div class="box-content-social">
    <h2 class="h2">
        <a href="<%= ResolveUrl("~/") + "thu-vien-video.aspx" %>" class='h2-cate margin-10l'><span>
            <asp:Label ID="lblTitle" runat="server" Text="Thư viện Video"></asp:Label></span></a></h2>
    <div class="box-content-main">
        <asp:Repeater ID="rptVideo" runat="server">
            <ItemTemplate>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="thumbnail no-thumbnail">
                        <a href="<%# ResolveUrl("~/") + "thu-vien-videos/" + GetString(Eval("Title")) + "-" + Eval("VideosCateID") + "-" + Eval("VideosID") + ".aspx" %>"
                            title="<%# Eval("Title")%>" target="_self">
                            <div class="embed-image ratio-16-9">
                                <img src="<%# Utils.getURLThumbImage(Eval("ImageThumb").ToString(), 210) %>" alt="<%# Eval("Title") %>"
                                    class="img-responsive" />
                            </div>
                        </a><a href="<%# ResolveUrl("~/") + "thu-vien-videos/" + GetString(Eval("Title")) + "-" + Eval("VideosCateID") + "-" + Eval("VideosID") + ".aspx" %>"
                            title="<%# Eval("Title")%>">
                            <div class="caption">
                                <h3 class="title-news">
                                    <%# Eval("Title") %></h3>
                            </div>
                        </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
