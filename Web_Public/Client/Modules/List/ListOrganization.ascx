<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListOrganization.ascx.cs"
    Inherits="Client_Modules_List_ListOrganization" %>
<%@ Register Src="../PagingControl.ascx" TagName="PagingControl" TagPrefix="uc1" %>
<div class="row mb10">
    <div class="panel">
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-lg-1 control-label" for="inputSmall">
                        Tỉnh/TP</label>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlProvinceSearch" runat="server" AppendDataBoundItems="True"
                            CssClass="form-control input-sm">
                        </asp:DropDownList>
                    </div>
                    <label class="col-lg-1 control-label pt5" for="inputSmall">
                        Từ khóa</label>
                    <div class="col-lg-2">
                        <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control input-sm" placeholder="Nhập từ khóa"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <asp:LinkButton runat="server" ID="btn_search" CssClass="btn btn-sm btn-primary mr10" Text="Tìm kiếm"
                            OnClick="btn_search_Click"><i class="fa fa-search"></i>&nbsp;&nbsp;Tìm kiếm</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="panel">
        <div class="panel-body">
            <asp:Literal ID="clientview" runat="server"></asp:Literal>
            <div class="row">
                <div class="col-lg-6">
                    <div class="dataTables_length">
                        <label>
                            <asp:Literal ID="ltrTotal" runat="server"></asp:Literal></label>
                    </div>
                </div>
                <div class="col-lg-6" style="text-align: right">
                    <div class="dataTables_paginate paging_simple_numbers">
                        <uc1:PagingControl ID="Paging" OnPaging_Click="Paging_Click" runat="server" FirstString="Trang đầu"
                            LastString="Trang cuối" NextString="Tiếp" PrevString="Quay lại" />
                    </div>
                </div>
            </div>
            <div class="table-responsive mb20">
                <asp:GridView ID="grvOrg" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover mbn"
                    AllowPaging="false" EmptyDataText="Không tìm thấy bản ghi nào">
                    <HeaderStyle CssClass="primary fs12" />
                    <Columns>
                        <asp:TemplateField HeaderText="#" HeaderStyle-Width="6%">
                            <ItemStyle CssClass="text-center" />
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1%>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center p5" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sở Công thương">
                            <ItemStyle CssClass="TextLeft" />
                            <ItemTemplate>
                                <%# Eval("Title")%>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center p5" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Điện thoại">
                            <ItemStyle CssClass="TextLeft" />
                            <ItemTemplate>
                                <%#Eval("Phone") %>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center p5" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemStyle CssClass="TextLeft" />
                            <ItemTemplate>
                                <%#Eval("Email") %>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center p5" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Địa chỉ">
                            <ItemStyle CssClass="TextLeft" />
                            <ItemTemplate>
                                <%#Eval("Address") %>
                            </ItemTemplate>
                            <HeaderStyle CssClass="text-center p5" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
