<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockVideobyCate.ascx.cs"
    Inherits="Client_BlockVideobyCate" %>
<div class="r-ro">
    <div class="box-news">
     
        <h2 class="h2">
            <span>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></span></h2>
        <div class="br">
            <div class="vd_ln">
                <div class="vd_ln_vl">
                    <asp:Repeater ID="rptVideo" runat="server">
                        <ItemTemplate>
                            <div class="item-panel-video">
                                <a class="lnk_img lnk_video" href="<%# ResolveUrl("~/") + "thu-vien-videos/"+ GetString(Eval("Title")) + "- " + Eval("VideosID") + ".aspx" %>" title="<%# Eval("Title") %>">
                                    <img alt="<%# Eval("Title") %>" src="<%# Utils.getURLThumbImage(Eval("ImageThumb").ToString(),100) %>">
                                </a><a class="lnk_ct lnk_video under" style="cursor: text; text-decoration: none"
                                    href="<%# ResolveUrl("~/") + "thu-vien-videos/"+ GetString(Eval("Title")) + "-" + Eval("VideosID") + ".aspx" %>" title="<%# Eval("Title") %>">
                                    <%# Eval("Title") %> </a><span class="span_view">Cập nhật: <span
                                        style="color:#6D6D6D;font-size: 12px;"><%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM") %></span> </span>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <%-- <asp:Literal ID="ltlHotNewsSlider" runat="server"></asp:Literal>--%>
        </div>
    </div>
</div>
<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
