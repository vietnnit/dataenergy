<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigation.ascx.cs" Inherits="Client_Skin_HomePage_Navigation" %>

 <!--=== Breadcrumbs ===-->
<div class="breadcrumbs">
    <div class="container">
        <h1 class="pull-left"><asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        <ul class="pull-right breadcrumb">
            <asp:Literal ID="TitleCate" runat="server"></asp:Literal>
        </ul>
    </div>
</div><!--/breadcrumbs-->