<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditProduct.ascx.cs"
    Inherits="Client_Admin_DataEngery_AuditProduct" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnId" Value="0" runat="server" />
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <div class="margin-bottom-10">
                <div class="control-label pt5" style="width: 100%; text-align: left">
                    <b>
                        <asp:Literal ID="ltOldYear" runat="server" Text="1. Nguyên liệu tiêu thụ thực tế"></asp:Literal></b>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr>
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 50%">
                                Tên nguyên liệu
                            </th>
                            <th style="width: 15%" class="text-center">
                                Đơn vị đo
                            </th>
                            <th style="width: 20%" class="text-center">
                                Số lượng
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptMaterial" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("ProductName")%>
                                    </td>
                                    <td class="text-center">
                                        <%# Eval("Measurement")%>
                                    </td>
                                    <td class="text-right">                                        
                                        <%# Eval("Quantity") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Quantity"), 2) : ""%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="margin-bottom-10">
                <div class="control-label pt5" style="width: 100%; text-align: left">
                    <b>2. Sản phẩm sản xuất thực tế</b>
                </div>
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr>
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 50%">
                                Tên sản phẩm                                
                            </th>
                            <th style="width: 15%" class="text-center">
                                Đơn vị đo
                            </th>
                            <th style="width: 20%" class="text-center">
                                Sản lượng
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptProduct" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("ProductName")%>
                                    </td>
                                    <td class="text-center">
                                        <%# Eval("Measurement")%>
                                    </td>
                                    <td class="text-right">
                                         <%# Eval("Quantity") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Quantity"), 2) : ""%>
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
