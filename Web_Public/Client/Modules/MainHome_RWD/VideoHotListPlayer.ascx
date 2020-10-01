<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VideoHotListPlayer.ascx.cs"
    Inherits="Client_VideoHotListPlayer" %>

<%--<div class="headline-center-v2 headline-center-v2-dark mt20">
     <h2>
        <a href="<%# ResolveUrl("~/") + "thu-vien-video.aspx" %>">
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </a>
     </h2>
    <span class="bordered-icon"><i class="fa fa-th-large"></i></span>
</div>--%>

<div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 box-white-block">
    <div class="mt30 mb30">
    <div class="heading heading-v1 margin-bottom-20">
                    <h2>Video</h2></div>
        <div class="video_panel">
        <div id="mediaplayer"></div>
             <script type="text/javascript" src="<%=ResolveUrl("~")%>Scripts/jwplayer/jwplayer.js"></script>
            <script type="text/javascript" src="<%=ResolveUrl("~")%>Scripts/jwplayer/jwplayerhtml5.js""></script>
            <script type="text/javascript">
                jwplayer.key = "pESR7KYNUU9qq8IBB26ybqQnTTlEN1Uf2g0Xw9/fUTgKLN96LcflFw==";
                       
            </script>
             <script type="text/javascript">
                 var widthdetail = $(".video_panel").width();
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
<%--<div class="col-md-6 col-lg-6 col-sm-12 col-xs-12 mt30 mb30">
    <div class="row">
        <asp:Literal ID="ltlHotOther" runat="server"></asp:Literal>
    </div>
   <a href="<%= ResolveUrl("~/") + "thu-vien-video.aspx" %>" class="btn-u pull-right">Xem thêm</a>
</div>--%>
            

<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
