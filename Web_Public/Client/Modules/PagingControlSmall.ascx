<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PagingControlSmall.ascx.cs" Inherits="Admin_PagingControlSmall" %>
<div class="paging-div">
<asp:panel runat="server" id="pnl_First">
    <asp:LinkButton ID="lnkFirst" runat="server" OnCommand="lnkPaging_Click" ></asp:LinkButton>
    <asp:Literal ID="lblFirst" runat="server" ></asp:Literal>
</asp:panel>
<asp:panel runat="server" id="pnl_Prev">
    <asp:LinkButton ID="lnkPrev" runat="server" OnCommand="lnkPaging_Click" ></asp:LinkButton>
    <asp:Literal ID="lblPrev" runat="server" ></asp:Literal>
</asp:panel>
<asp:Repeater runat="server" ID="rptPaging" OnItemCommand="rptPaging_OnItemCommand" Visible="false">
    <ItemTemplate>
        <asp:panel runat="server" id="pnl_Paging">
            <asp:LinkButton ID="lnkPaging" runat="server"></asp:LinkButton>
            <asp:Label ID="lblPaging" runat="server"></asp:Label>
        </asp:panel>
    </ItemTemplate>
    <SeparatorTemplate>
    </SeparatorTemplate>
</asp:Repeater>
<asp:panel runat="server" id="pnl_Next">
    <asp:LinkButton ID="lnkNext" runat="server" OnCommand="lnkPaging_Click" ></asp:LinkButton>
    <asp:Literal ID="lblNext" runat="server" ></asp:Literal>
</asp:panel>
<asp:panel runat="server" id="pnl_Last">
    <asp:LinkButton ID="lnkLast" runat="server" OnCommand="lnkPaging_Click" ></asp:LinkButton>
    <asp:Literal ID="lblLast" runat="server" ></asp:Literal>
</asp:panel>
</div>