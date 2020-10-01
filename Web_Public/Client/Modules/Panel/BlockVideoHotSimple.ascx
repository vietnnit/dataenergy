<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockVideoHotSimple.ascx.cs"
    Inherits="Client_BlockVideoHotSimple" %>
<div class="mt20 mb20">
    <div class="headline headline-md">
        <h2><asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
     </div>
   
     <div class="mt10 videopanel">
        <div id="mediaplayer"></div>
            <script type="text/javascript" src="<%=ResolveUrl("~")%>Scripts/jwplayer/jwplayer.js"></script>
            <script type="text/javascript" src="<%=ResolveUrl("~")%>Scripts/jwplayer/jwplayerhtml5.js""></script>
            <script type="text/javascript">
                jwplayer.key = "pESR7KYNUU9qq8IBB26ybqQnTTlEN1Uf2g0Xw9/fUTgKLN96LcflFw==";
                       
            </script>
            <script type="text/javascript">
                var widthdetail = $(".videopanel").width();
                widthdetail *= 1;
                var heightdetail = Math.round((widthdetail / 16) * 9);

                jwplayer("mediaplayer").setup({
                    volume: 100,
                    menu: true,
                    allowscriptaccess: 'always',
                    wmode: 'opaque',
                    file: '<%= PathFileAudio %>',
                    image: '<%= PathFileImg %>',
                    height: heightdetail,
                    width: widthdetail

                });
            </script>
            <asp:Literal ID="ltlVideoHot1" runat="server"></asp:Literal> 
        </div>

</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
