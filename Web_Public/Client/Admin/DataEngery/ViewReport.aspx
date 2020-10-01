<%@ Page Title="" Language="C#" MasterPageFile="~/Client/Skin/Template/PopupPage.master"
    AutoEventWireup="true" CodeFile="ViewReport.aspx.cs" Inherits="Client_Admin_DataEngery_ViewReport" %>

<%@ Register Src="~/Client/Admin/DataEngery/ViewReportFuel.ascx" TagName="ViewReportFuel"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHomepage" runat="Server">
    <uc:ViewReportFuel ID="ucViewReportFuel" runat="server"></uc:ViewReportFuel>
</asp:Content>
