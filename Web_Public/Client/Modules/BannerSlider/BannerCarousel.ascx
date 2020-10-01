<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerCarousel.ascx.cs"
    Inherits="Client_Modules_BannerCarousel" %>
<link href="<%= ResolveUrl("~/") %>CSS/bootstrap/plugin/carousel.css" rel="stylesheet"
    type="text/css" />

<div class="bg_bannerSlider">
    <div id="sliderBanner" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <asp:Literal ID="ltlBannerThumb" runat="server"></asp:Literal>
        </ol>
        <div class="carousel-inner">
            <asp:Literal ID="ltlBannerLarger" runat="server"></asp:Literal>
      
        
        </div>
        <a class="left carousel-control" href="#sliderBanner" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span></a>
         <a class="right carousel-control"
                href="#sliderBanner" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right">
                </span></a>
    </div>
</div>
<script type="text/javascript">
    $('.carousel-caption').hide();	
    $('.active .carousel-caption').delay(1500).addClass('rotateInDownLeft').show();
    $('.carousel').on('slid.bs.carousel', function() {
       $('.carousel-caption').hide();
       $('.carousel-caption').removeClass('rotateInDownLeft');
       $('.active .carousel-caption').offsetWidth = $('.active .carousel-caption').offsetWidth;
       $('.active .carousel-caption').delay(1500).addClass('rotateInDownLeft').show();
    });
</script>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
