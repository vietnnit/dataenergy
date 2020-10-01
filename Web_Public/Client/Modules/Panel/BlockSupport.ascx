<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockSupport.ascx.cs" Inherits="Client_BlockSupport" %>

<div class="ro margin-15t margin-15b">
    <div class="box-support">
        <asp:Literal ID="ltlSupport" runat="server"></asp:Literal>
        <div class="clear">
        </div>
        <div class="br">
            <input type="image" src="<%= ResolveUrl("~/") %>images/btnSendMail.png" title="Gửi ý kiến góp ý"
                alt="Search" value="Search" class="image-loginbutton" />
        </div>
    </div>
</div>

<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />