<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockAlbum.ascx.cs" Inherits="Client_BlockAlbum" %>
<link href="<%=ResolveUrl("~/")%>Scripts/flexslider/flexslider.css" rel="stylesheet" type="text/css" />
<script src="<%=ResolveUrl("~/")%>Scripts/flexslider/jquery.flexslider-min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function() {
        var currentPosition = 0;
        var slideWidth = '100%';
        var slides = $('.slide_album');
        var numberOfSlides = slides.length;
        $('#slidesContainer').css('overflow', 'hidden');
        slides.wrapAll('<div id="slideInner"></div>')
	        .css({
	            'float': 'left',
	            'width': slideWidth
	        });
        $('#slideInner_album').css('width', slideWidth * numberOfSlides);
        $('#slideshow_album')
                .prepend('<span class="control_album" id="leftControl">Clicking moves left</span>')
                .append('<span class="control_album" id="rightControl">Clicking moves right</span>');
        manageControls(currentPosition);
        $('.control_album')
                .bind('click', function() {
                    currentPosition = ($(this).attr('id') == 'rightControl') ? currentPosition + 1 : currentPosition - 1;
                    manageControls(currentPosition);
                    $('#slideInner_album').animate({
                        'marginLeft': slideWidth * (-currentPosition)
                    });
                });
        function manageControls(position) {
            if (position == 0) { $('#leftControl').hide() } else { $('#leftControl').show() }
            if (position == numberOfSlides - 1) { $('#rightControl').hide() } else { $('#rightControl').show() }
        }
    });
</script>

<script type="text/javascript">
    $(window).load(function() {
        $('.flexslider').flexslider();
    });
	</script>



<div class="mb20 mt10">
    <div class="headline headline-md">
        <h2><asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
     </div>
    <div class="mt10">
        <div id="container">
            <div class="flexslider">
                <ul class="slides_album">
                    <asp:Literal ID="ltlAlbumSlider" runat="server"></asp:Literal>
                </ul>
                <div class="clr">
                </div>
            </div>
        </div>

    </div>
   
</div>
