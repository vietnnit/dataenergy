<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkImage_notext_col2_hover.ascx.cs"
    Inherits="Client_LinkImage_notext_col2_hover" %>

<!--=== Illustration v1 ===-->
<div class="row margin-top-20 margin-bottom-20">
     <asp:Repeater ID="rptWebLink" runat="server">
            <ItemTemplate>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 xs-margin-bottom-10">
                    <div class="overflow-h thumbnail-zoom">
                        <a href="<%# Eval("MenuLinksUrl")%>" title="<%# Eval("MenuLinksName")%>" target="<%# Eval("Target")%>" class="div_bg<%#((RepeaterItem)Container).ItemIndex%>">
                            <%# (Eval("MenuLinksIcon").ToString() != "") ? "<img src='" + Eval("MenuLinksIcon") + "'style='display: inline;' alt='" + Eval("MenuLinksName") + "'>" : "<img class='lazy' src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='display: inline;' alt='" + Eval("MenuLinksName") + "'>"%>
                        </a>
                    </div>    
                </div>
                
            </ItemTemplate>
        </asp:Repeater>

 
</div><!--/end row-->
<!--=== End Illustration v1 ===-->


<asp:HiddenField ID="hddValue" runat="server" />
<asp:HiddenField ID="hddRecord" runat="server" />
