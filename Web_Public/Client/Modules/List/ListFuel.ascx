<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListFuel.ascx.cs" Inherits="Client_Modules_List_ListFuel" %>
<div class="row mb10">
    <div class="panel" style="display: none">
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-lg-2 control-label" for="inputSmall">
                        Bảng hệ số năm</label>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlParent" runat="server" AppendDataBoundItems="True" CssClass="form-control input-sm"
                            ValidationGroup="vgInfo">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body">
            <asp:Literal ID="clientview" runat="server"></asp:Literal>
            <div class="form-group">
                <div class="col-lg-6">
                    <div class="dataTables_length">
                        <label>
                            <asp:Literal ID="ltrTotal" runat="server"></asp:Literal></label>
                    </div>
                </div>
            </div>
            <div class="table-responsive mb20">
                <asp:GridView ID="grvFuel" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover mbn"
                    AllowPaging="false" EmptyDataText="Không tìm thấy nhiên liệu nào" OnRowDataBound="grvFuel_RowDataBound"
                    DataKeyNames="Id">
                    <HeaderStyle CssClass="primary fs12" />
                    <Columns>
                        <asp:BoundField HeaderText="STT" DataField="row">
                            <ItemStyle CssClass="text-center" />
                            <HeaderStyle CssClass="text-center p5" Width="5%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Loại nhiên liệu">
                            <ItemStyle CssClass="TextLeft" />
                            <ItemTemplate>
                                <%# Eval("FuelName")%>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center p5" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Hệ số quy đổi TOE theo đơn vị tính">
                            <ItemStyle CssClass="TextLeft" />
                            <ItemTemplate>
                                <asp:Literal ID="ltTOE" runat="server"></asp:Literal>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center p5" Width="27%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
