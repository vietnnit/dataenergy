<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsTagsList.ascx.cs"
    Inherits="Client_NewsTagsList" %>
<%@ Register Src="~/Client/Modules/PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>

<div class="blog-page page_list"> 
     <div class="row box-white mb10 mln mrn">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

        <asp:Repeater ID="rptListNewsGroup" runat="server">
            <ItemTemplate>
               <div class="row blog blog-medium">
                            <%# (Eval("ImageThumb").ToString() != "") ? "<div class='col-md-4'><a  href='"+ ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx' title='" + Eval("Title") +"'><div class='embed-image ratio-16-9 thumbnail-style thumbnail-kenburn'><img src='" + Utils.getURLThumbImage(Eval("ImageThumb").ToString(),350) + "' alt='" + Eval("Title") + "' class='img-responsive'> </div></a></div><div class='col-md-8'>" : "<div class='col-md-12'>" %>
                                <h2>
                                     <a href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>" title="<%# Eval("Title")%>">
                                        <%# Eval("Title") %>
                                    </a>
                                </h2>
                                <ul class="list-unstyled list-inline blog-info">
                                    <li><i class="fa fa-calendar"></i> <%# Convert.ToDateTime(Eval("PostDate")).ToString("dd/MM/yyyy") %></li>
                                </ul>
                                <p>
                                    <%# Tool.SubString(Tool.StripTagsCharArray(Eval("ShortDescribe").ToString()),300) %>
                                </p>
                                <p><a class="btn-u btn-u-sm pull-right" href="<%# ResolveUrl("~/")+ "d4/news/" + GetString(Eval("Title")) + "-" + Eval("GroupCate") + "-" + Eval("NewsGroupID") + ".aspx" %>" title="<%# Eval("Title")%>">Chi tiết... <%--<i class="fa fa-angle-double-right margin-left-5"></i>--%></a></p>
                            
                            </div>    
                            
                        </div>
                        <hr class="mt10 mb20"/>
            </ItemTemplate>
        </asp:Repeater>

           </div>
    </div>
</div> 

<div class="row box-white mb10 mln mrn">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
     
            <div class="box-pages pull-right mr20 mb15">
                <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="<%$ Resources:Resource, T_Top %>"
                    LastString="<%$ Resources:Resource, T_Last %>" NextString="<%$ Resources:Resource, T_Next %>"
                    PrevString="<%$ Resources:Resource, T_Back %>" />
             </div>
       
    </div>
</div>

<asp:HiddenField ID="hddTags" runat="server" />
<asp:HiddenField ID="hdnPage" runat="server" Value="1" />
