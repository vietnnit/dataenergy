<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockNewsSlidebyCateID_All.ascx.cs"
    Inherits="Client_BlockNewsSlidebyCateID_All" %>
<div class="r-ro">
    <div class="box-news">
        <h2 class="h2">
            <span>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></span></h2>
        <div class="br">
            <div class="vd_ln" style="height:375px;overflow:hidden;">
                <div class="vd_ln_vl">
                    <div class="image_carousel-newsStrID">
                        <asp:Literal ID="ltlHotNewsSlider" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
