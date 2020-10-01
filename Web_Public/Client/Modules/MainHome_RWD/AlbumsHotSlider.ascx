<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AlbumsHotSlider.ascx.cs"
    Inherits="Client_AlbumsHotSlidert" %>
<script type="text/javascript" language="javascript" src="<%= ResolveUrl("~/") %>Scripts/carouFred/jquery.carouFredSel-6.2.1-packed.js"></script>
<div class="margin-25t margin-25b">
    <div class="list_carousel responsive">
        <ul id="carousel_album">
            <asp:Repeater ID="rptAlbums" runat="server">
                <ItemTemplate>
                    <li><a href="<%# ResolveUrl("~/")+ "thu-vien-anh/"+ GetString(Eval("AlbumsCateName")) + "-" + Eval("AlbumsCateID") + ".aspx" %>"
                        title="<%# Eval("AlbumsCateName") %>">
                        <img src="<%# Utils.getURLThumbImage(Eval("ImageThumb").ToString() , 350) %>" height="100%" />
                    </a>
                        <div class="list_carousel-caption">
                            <a href="<%# ResolveUrl("~/")+ "thu-vien-anh/"+ GetString(Eval("AlbumsCateName")) + "-" + Eval("AlbumsCateID") + ".aspx" %>"
                                title="<%# Eval("AlbumsCateName") %>">
                               <h2> <%# Eval("AlbumsCateName").ToString().Trim() %>
                               </h2>
                            </a>
                                
                        </div>
                       
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="clearfix">
        </div>
        <a id="prev_album" class="prev_album" href="#"><span class="glyphicon glyphicon-chevron-left">
        </span></a><a id="next_album" class="next_album" href="#"><span class="glyphicon glyphicon-chevron-right">
        </span></a>
        <div id="pager_album" class="pager_album">
        </div>
    </div>
    <div class="clr">
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
<asp:HiddenField ID="hddCateID" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
<script type="text/javascript" language="javascript">
    $(function () {

        //	Responsive layout, resizing the items
        $('#carousel_album').carouFredSel({
            responsive: true,
            width: '100%',
            scroll: 2,
            items: {
                width: 200,
                //	height: '30%',	//	optionally resize item-height
                visible: {
                    min: 1,
                    max: 1
                }
            },
            scroll: {
                items: 1,
                //easing          : "elastic",
                duration: 1000,
                pauseOnHover: true
            },
            prev: '#prev_album',
            next: '#next_album',
            pagination: "#pager_album",
            mousewheel: true,
            swipe: {
                onMouse: true,
                onTouch: true
            }
        });

        //	Fuild layout, centering the items


    });
</script>
