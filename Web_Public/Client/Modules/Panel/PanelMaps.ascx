<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PanelMaps.ascx.cs" Inherits="Client_Modules_Panel_PanelMaps" %>
<div style="padding-top: 20px;">
    <a href="javascript:void(0)" class="FormMap-Staff-Links">
        <img src="<%=ResolveUrl("~/")%>images/maps300.jpg" width="246px" />
    </a>
</div>
<div class="clr">
</div>
<div id="FormMap">
    <div id="FormMap-Wrapper">
        <div style="padding: 10px 0 10px 0;">
            <iframe width="700" height="425" frameborder="0" scrolling="no" marginheight="0"
                marginwidth="0" src="https://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=vi&amp;geocode=&amp;q=%C4%91%E1%BA%A1i+h%E1%BB%8Dc+khoa+h%E1%BB%8Dc+x%C3%A3+h%E1%BB%99i+%26+nh%C3%A2n+v%C4%83n+h%C3%A0+n%E1%BB%99i&amp;aq=&amp;sll=37.0625,-95.677068&amp;sspn=39.371738,86.572266&amp;t=m&amp;ie=UTF8&amp;hq=%C4%91%E1%BA%A1i+h%E1%BB%8Dc+khoa+h%E1%BB%8Dc+x%C3%A3+h%E1%BB%99i+%26+nh%C3%A2n+v%C4%83n&amp;hnear=H%C3%A0+N%E1%BB%99i,+Ho%C3%A0n+Ki%E1%BA%BFm,+H%C3%A0+N%E1%BB%99i,+Vi%E1%BB%87t+Nam&amp;ll=20.995445,105.807198&amp;spn=0.022717,0.042272&amp;z=14&amp;iwloc=A&amp;cid=4693880946671081362&amp;output=embed">
            </iframe>
            <br />
            <small><a href="https://maps.google.com/maps?f=q&amp;source=embed&amp;hl=vi&amp;geocode=&amp;q=%C4%91%E1%BA%A1i+h%E1%BB%8Dc+khoa+h%E1%BB%8Dc+x%C3%A3+h%E1%BB%99i+%26+nh%C3%A2n+v%C4%83n+h%C3%A0+n%E1%BB%99i&amp;aq=&amp;sll=37.0625,-95.677068&amp;sspn=39.371738,86.572266&amp;t=m&amp;ie=UTF8&amp;hq=%C4%91%E1%BA%A1i+h%E1%BB%8Dc+khoa+h%E1%BB%8Dc+x%C3%A3+h%E1%BB%99i+%26+nh%C3%A2n+v%C4%83n&amp;hnear=H%C3%A0+N%E1%BB%99i,+Ho%C3%A0n+Ki%E1%BA%BFm,+H%C3%A0+N%E1%BB%99i,+Vi%E1%BB%87t+Nam&amp;ll=20.995445,105.807198&amp;spn=0.022717,0.042272&amp;z=14&amp;iwloc=A&amp;cid=4693880946671081362"
                style="color: #0000FF; text-align: left">Xem Bản đồ cỡ lớn hơn</a></small>
        </div>
    </div>
    <!--end Contact-Wrapper-->
</div>
<script type="text/javascript">
    $('#FormMap').dialog({
        autoOpen: false,
        width: 720,
        modal: true,
        maxHeight: 580,
        title: "Bản đồ",
        buttons: {
            "Thoát": function () {
                $(this).dialog("close");
            }
        },
        stack: false,
        overlay: { zIndex: 9999 }
    });

    $('.FormMap-Staff-Links').click(function () {
        $('#FormMap').dialog('open');
        return false;
    });
</script>
