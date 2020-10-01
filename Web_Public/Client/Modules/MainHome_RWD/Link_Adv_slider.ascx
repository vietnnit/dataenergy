<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Link_Adv_slider.ascx.cs"
    Inherits="Client_Modules_Link_Adv_slider" %>
<div class="mt10 mb10">
    <div class="headline">
        <h2>
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </h2>
    </div>
    <div class="mt5 mb40">
      
        <div class="owl-clients-v1">
            <asp:Repeater ID="rptWebLink" runat="server" OnItemDataBound="rptWebLink_ItemDataBound"
                OnItemCommand="rptWebLink_ItemCommand">
                <ItemTemplate>
                    <div class="item">
                        <asp:LinkButton ID="btnLink" runat="server" CommandName="_link" CommandArgument='<%# Eval("MenuLinksID") %>'
                            OnClientClick="aspnetForm.target ='_blank';">
                            <asp:Literal ID="ltlICON" runat="server"></asp:Literal>
                        </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
       
    </div>
</div>
<asp:HiddenField ID="hddValue" Value="Adv_Partner" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
