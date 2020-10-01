<%@ control language="C#" autoeventwireup="true" CodeFile="BlockAdv_2Col.ascx.cs" inherits="Client_BlockAdv_2Col" %>

<div class="ro margin-15t margin-15b">
    <div class="box-adv">
        <asp:Repeater ID="rptAdv" runat="server" OnItemDataBound="rptAdv_ItemDataBound" OnItemCommand="rptAdv_ItemCommand">
            <ItemTemplate>
                <div class="grid-box width50">
                    <div class="module deepest">
                        <asp:LinkButton ID="btnLink" runat="server" CommandName="_link" CommandArgument='<%# Eval("MenuLinksID") %>' OnClientClick="aspnetForm.target ='_blank';">
                            <asp:Literal ID="ltlICON" runat="server"></asp:Literal>
                        </asp:LinkButton>
                        
                        <div class="clear"></div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>
</div>

<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />