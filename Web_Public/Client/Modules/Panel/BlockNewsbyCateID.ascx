<%@ control language="C#" autoeventwireup="true" CodeFile="BlockNewsbyCateID.ascx.cs" inherits="Client_BlockNewsbyCateID" %>
<div class="r-ro">
    <div class="box-news">
        <%--<div class="box-news-more">
            <asp:Literal ID="lblIcon" runat="server"></asp:Literal>
        </div>--%>
        <h2 class="h2">
            <span>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></span></h2>
        <div class="br">
            <div class="vd_ln">
                <div class="vd_ln_vl">
                    <asp:Literal ID="ltlHotNewsSlider" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" /> 
<asp:HiddenField ID="hddRecord" runat="server" /> 