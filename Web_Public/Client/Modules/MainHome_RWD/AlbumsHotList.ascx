<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AlbumsHotList.ascx.cs"
    Inherits="Client_AlbumsHotList" %>
<div class="box-content-slider">
    <h2 class="h2">
        <a href="<%= ResolveUrl("~/")+ "thu-vien-anh.aspx" %>">
            <asp:Label ID="lblTitle" runat="server"></asp:Label></a></h2>
    <div class="box-content-main-slide">
        <asp:Repeater ID="rptAlbums" runat="server">
            <ItemTemplate>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-24 <%#(((RepeaterItem)Container).ItemIndex + 1==3)?"clear_sm":"" %>">
                    <div class="thumbnail no-thumbnail">
                        <a href="<%# ResolveUrl("~/")+ "thu-vien-anh/"+ GetString(Eval("AlbumsCateName")) + "-" + Eval("AlbumsCateID") + ".aspx" %>"
                            title="<%# Eval("AlbumsCateName") %>">
                            <div class="embed-image ratio-16-9">
                                <img src="<%# Utils.getURLThumbImage(Eval("ImageThumb").ToString() , 330) %>" class="img-responsive" />
                            </div>
                        </a>
                        <div class="caption">
                            <h3 class="title-news">
                                <a href="<%# ResolveUrl("~/")+ "thu-vien-anh/"+ GetString(Eval("AlbumsCateName")) + "-" + Eval("AlbumsCateID") + ".aspx" %>"
                                    title="<%# Eval("AlbumsCateName") %>">
                                    <%# Eval("AlbumsCateName").ToString().Trim() %>
                                </a>
                            </h3>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
<asp:HiddenField ID="hddCateID" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
