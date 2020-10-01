<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockVideo.ascx.cs" Inherits="Client_BlockVideo" %>
<div class="r-ro">
     <div class="box-news">
        <h2>
            <a href="<%= ResolveUrl("~/") %>thu-vien-video.aspx" title="Video" class="link_block"><asp:Label ID="lblTitle" runat="server"></asp:Label></a>
         </h2>
    
    <div >
        <asp:Literal ID="ltlVideo" runat="server"></asp:Literal>
    </div>
   </div> 
</div>