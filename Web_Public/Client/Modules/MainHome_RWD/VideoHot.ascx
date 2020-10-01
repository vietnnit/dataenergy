<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoHot.ascx.cs" Inherits="Client_VideoHot" %>
<div class="row">
<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 video-box-panel">
        
        <h2 class="h2-cate-video mtn mbn">
            <a href="/thu-vien-video.aspx"> <asp:Label ID="lblTitle" runat="server" Text="Thư viện Video"></asp:Label></a>
        </h2>
      
        <div class="videopanel">
            <div id="mediaplayer">
            </div>
            <script type="text/javascript" src="<%=ResolveUrl("~")%>Scripts/jwplayer/jwplayer.js"></script>
            <script type="text/javascript" src="<%=ResolveUrl("~")%>Scripts/jwplayer/jwplayerhtml5.js"></script>
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
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
