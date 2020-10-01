<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EnergyQuota.ascx.cs" Inherits="Client_Admin_DataEngery_EnergyQuota" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnNextYear" Value="" runat="server" />
<asp:HiddenField ID="hdnFuelId" Value="0" runat="server" />
<asp:HiddenField ID="hdnDetailId" Value="" runat="server" />
<div class="form-horizontal">
    <div class="form-group">
        <div class="col-lg-12">
            <div class="control-label pt5" style="width: 100%; text-align:left">
                <b>Tiêu hao năng lượng theo sản phẩm theo kế hoạch</b>
            </div>
            <asp:Literal ID="ltQuota" runat="server"></asp:Literal>
        </div>
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>
