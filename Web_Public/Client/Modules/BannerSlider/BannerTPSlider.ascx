<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerTPSlider.ascx.cs"  Inherits="Client_BannerTPSlider" %>
 <script type="text/javascript" src="<%= ResolveUrl("~/") %>Themes/js/plugins/revolution-slider.js"></script>
<!--=== Slider ===-->
<div class="tp-banner-container">
    <div class="tp-banner">
        <ul>
            <!-- SLIDE -->
            <asp:Repeater ID="rptSlider" runat="server">
                <ItemTemplate>
                    <li class="revolution-mch-1" data-transition="fade" data-slotamount="5" data-masterspeed="1000" data-title="<%# Eval("MenuLinksName")%>">
                    <!-- MAIN IMAGE -->
                    <img src="<%# Utils.getURLThumbImage(Eval("MenuLinksIcon").ToString(), Convert.ToInt32(Eval("Width").ToString())) %>"  alt="<%# Eval("MenuLinksName")%>"  data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                        <%#  (Eval("MenuLinksHelp").ToString() != "")? "<div class='tp-caption revolution-ch1 sft start' data-x='left' offset='0' data-y='300' data-speed='1500' data-start='300' data-easing='Back.easeInOut'  data-endeasing='Power1.easeIn' data-endspeed='300'>" +Eval("MenuLinksHelp") + "</div>":"" %>
                  
                </li>
                </ItemTemplate>
            </asp:Repeater>
             
      
        </ul>
        <div class="tp-bannertimer tp-bottom"></div>            
    </div>
</div>
<!--=== End Slider ===-->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            RevolutionSlider.initRSfullWidth();
        });
    </script>


<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
