<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditOperationArea.ascx.cs"
    Inherits="Client_Admin_AuditReport_AuditOperationArea" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <div class="margin-bottom-10">
                <div class="control-label pt5" style="width: 100%; text-align:left">
                    <b>
                        <asp:Literal ID="ltOldYear" runat="server" Text="Số giờ vận hành"></asp:Literal></b>
                    
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr>
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 65%" class="text-center">
                                Khu vực
                            </th>
                            <th style="width: 20%" class="text-center">
                                Số giờ vận hành (giờ/năm)
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptOperation" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1  %>
                                    </td>
                                    <td>
                                        <%# Eval("AreaName")%>
                                    </td>
                                    <td class="text-right">
                                         <%# Eval("OperationHours") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("OperationHours"), 0) : ""%>
                                    </td>
                                    
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <asp:Literal ID="error" runat="server"></asp:Literal>
</div>

<style type="text/css">
    .modal-dialog
    {
        z-index: 9999 !important;
    }
</style>
