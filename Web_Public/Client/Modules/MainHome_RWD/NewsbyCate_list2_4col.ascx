<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsbyCate_list2_4col.ascx.cs"
    Inherits="Client_NewsbyCate_list2_4col" %>

    <div class="mtn mb20">
        <div class="headline mtn mb5">
            <h2>
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </h2>
        </div>
        <div class="box-news-thumb-4">
            <div class="row">
                <asp:Literal ID="ltlNewsCateMainHome" runat="server"></asp:Literal>
            </div>
        </div>
    </div>

<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
