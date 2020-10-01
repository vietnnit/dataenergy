<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockWelcome.ascx.cs" Inherits="Client_BlockWelcome" %>

<marquee direction="left"  scrollamount="2" scrolldelay="50" onmouseover='this.stop();' onmouseout='this.start();'> 
    <asp:Literal ID="ltlTextMarquee" runat="server"></asp:Literal>
</marquee>