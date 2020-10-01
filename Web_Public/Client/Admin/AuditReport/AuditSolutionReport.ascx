<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditSolutionReport.ascx.cs"
    Inherits="Client_Admin_DataEngery_AuditSolutionReport" %>
<asp:Literal ID="ltNotice" runat="server"></asp:Literal>
<div class="form-horizontal">
    <div class="form-group" style="margin-bottom: 0">
        <div class="col-lg-12">
            <div class="margin-bottom-10">
                <table class="table table-bordered table-hover mbn" width="100%">
                    <thead>
                        <tr>
                            <th style="width: 5%" class="text-center">
                                TT
                            </th>
                            <th style="width: 20%">
                                Giải pháp TKNL dự kiến
                            </th>
                            <th style="width: 15%" class="text-center">
                                Nhiên liệu
                            </th>
                            <th style="width: 15%" class="text-center">
                                Số lượng
                            </th>
                            <th style="width: 10%" class="text-center">
                                Đơn vị
                            </th>
                            <th style="width: 15%" class="text-center">
                                Mức đầu tư dự kiến<br />
                                (Tr.đồng)
                            </th>
                            <th style="width: 10%" class="text-center">
                                Thời gian hoàn vốn (Năm)
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptResultTKNL" runat="server" OnItemCommand="rptResultTKNL_ItemCommand"
                            OnItemDataBound="rptResultTKNL_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center">
                                        <%#Container.ItemIndex+1 %>
                                    </td>
                                    <td>
                                        <%# Eval("TenGiaiPhap")%>
                                    </td>
                                    <td>
                                        <%# Eval("FuelName")%>
                                    </td>
                                    <td class="text-right">                                        
                                          <%# Eval("Quantity") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Quantity"), 2) : ""%>
                                    </td>
                                    <td>
                                        <%# Eval("MeasurementName")%>
                                    </td>
                                    <td class="text-right">                                        
                                         <%# Eval("Budget") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("Budget"), 2) : ""%>
                                    </td>
                                    <td class="text-right">                                        
                                        <%# Eval("TimeExecuted") != DBNull.Value ? Tool.ConvertDecimalToString(Eval("TimeExecuted"), 2) : ""%>
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
