<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewbyGroup_ListScroll.ascx.cs"
    Inherits="Client_HotNewbyGroupScroll" %>
<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <div class="mt20 mb20">
        <div class="headline">
            <h2><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h2>
            <ul class="pull-right breadcrumb hidden-xs">
                <asp:Literal ID="ltlCateSub" runat="server"></asp:Literal>
            </ul>
        </div>

        <div class="row pt5">
            

           <!--=== Illustration v2 ===-->
            <div class="illustration-v2 margin-bottom-10">
               <%-- <div class="customNavigation margin-bottom-25">
                    <a class="owl-btn prev rounded-x"><i class="fa fa-angle-left"></i></a>
                    <a class="owl-btn next rounded-x"><i class="fa fa-angle-right"></i></a>
                </div>
--%>
                <ul class="list-inline owl-slider">
                    <asp:Repeater ID="rptLListNews" runat="server" >
                    <ItemTemplate>

                         <li class="item">
                            <div class="product-img">
                                <a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>">
                                    <img class="full-width img-responsive" src="<%# (Eval("ImageThumb").ToString() != "") ? Utils.getURLThumbImage(Eval("ImageThumb").ToString(), 330): Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg",330) %>" alt="<%# Eval("Title") %>"></a>
                            </div>
                            <div class="product-description product-description-brd">
                                <div class="overflow-h margin-bottom-5">
                                    <div class="pull-left">
                                        <h4 class="title-price"><a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"><%# Eval("Title") %></a></h4>
                                    </div>    
                                    
                                </div>    
                               <%-- <ul class="list-inline product-ratings">
                                    <li><i class="rating-selected fa fa-star"></i></li>
                                    <li><i class="rating-selected fa fa-star"></i></li>
                                    <li><i class="rating-selected fa fa-star"></i></li>
                                    <li><i class="rating fa fa-star"></i></li>
                                    <li><i class="rating fa fa-star"></i></li>
                                    <li class="like-icon"><a data-original-title="Add to wishlist" data-toggle="tooltip" data-placement="left" class="tooltips" href="#"><i class="fa fa-heart"></i></a></li>
                                </ul>    --%>
                            </div>
                        </li>


                        <%--<div class="col-md-6 col-sm-12 col-xs-12 hotnews-col<%#((RepeaterItem)Container).ItemIndex + 1 %>">
                            <div class="thumbnail no-thumbnail">
                                <a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                    title="<%# Eval("Title")%>">
                                    <div class="embed-image ratio-16-9">
                                        <img src="<%# (Eval("ImageThumb").ToString() != "") ? Utils.getURLThumbImage(Eval("ImageThumb").ToString(), 330): Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg",330) %>"
                                            alt="<%# Eval("Title") %>" class="img-responsive" />
                                    </div>
                                </a><a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>"
                                    title="<%# Eval("Title")%>">
                                    <div class="caption">
                                        <h3 class="title-news">
                                            <%# Eval("Title") %></h3>
                                    </div>
                                </a>
                            </div>
                        </div>--%>
                    </ItemTemplate>
                </asp:Repeater>

                   
                      
                </ul>
            </div> 
            <!--=== End Illustration v2 ===-->
            
        </div>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />

<script>

    jQuery(document).ready(function () {
        var OwlCarousel = function () {

            return {
        
                //Owl Carousel
                initOwlCarousel: function () {
		            jQuery(document).ready(function() {
		                //Owl Slider
		                jQuery(document).ready(function() {
		                var owl = jQuery(".owl-slider");
		                    owl.owlCarousel({
		            	        items: [4],
		                        itemsDesktop : [1000,3], //3 items between 1000px and 901px
		                        itemsDesktopSmall : [979,2], //2 items between 901px
		                        itemsTablet: [600,1], //1 items between 600 and 0;
		                        slideSpeed: 1000
		                    });

		                    // Custom Navigation Events
		                    jQuery(".next").click(function(){
		                        owl.trigger('owl.next');
		                    })
		                    jQuery(".prev").click(function(){
		                        owl.trigger('owl.prev');
		                    })
		                });
		            });

		           
		        }
            };
    
        }();
    });
   
</script>


