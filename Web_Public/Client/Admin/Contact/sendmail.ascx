<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sendmail.ascx.cs" Inherits="Admin_Controls_sendmail" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadScriptManager ID="ScriptManager1" runat="server" />
<div id="menubarsub">
    <div class="left_menubarsub">
        <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" />
        <span class="text_menubarsub">
            <asp:Literal ID="litModules" runat="server"></asp:Literal></span>
    </div>
    <div class="right_menubarsub">
        <div id="toolbar" class="toolbar-list">
            <ul>
                <li id="Li1" class="button">
                    <asp:HyperLink ID="btn_home" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
                        CssClass="toolbar" ToolTip="Trở về trang chủ">
                        <span class="icon-32-home"> </span>Trang chủ 
                    </asp:HyperLink>
                </li>
                <li id="Li2" class="button">
                    <asp:LinkButton ID="btn_editpage" runat="server" OnClick='btn_add_Click' CssClass="toolbar">
                <span class="icon-32-messaging"> </span>Gửi Mail</asp:LinkButton>
                </li>
              
                <li id="toolbar-help" class="button"><a class="toolbar" rel="help" href="#"><span
                    class="icon-32-help"></span>Help </a></li>
            </ul>
            <div class="clr">
            </div>
        </div>
    </div>
</div>
<div class="Yt">
    <div class="lineBE">
        <table class="table_line" cellpadding="0" cellspacing="0" width="98%" border="0">
            <tbody>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Literal ID="clientview" runat="server"></asp:Literal>
                    </td>
                </tr>
                
                <tr>
                    <td class="table_line_col1_lable">
                        <asp:Label ID="Label2" runat="server" Text="Tiêu đề thư:" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox" colspan="3">
                        <asp:TextBox ID="txtTitle" runat="server" Width="96%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                  
                <tr>
                    <td class="table_line_col1_lable" style="vertical-align:top;">
                        <asp:Label ID="Label9" runat="server" Text="Chi tiết tin:" CssClass="text_label"></asp:Label>
                    </td>
                    <td class="table_line_col2_textbox" colspan="3">
                        <telerik:RadEditor runat="server" ID="txtRadFull" SkinID="FullSetOfTools" ToolsFile="~/Scripts/Editor/FullSetOfTools.xml"
                            Height="650px" Width="96%" Skin="Default" ContentAreaCssFile="~/Scripts/Editor/EditorContentAreaStyles.css">
                            <MediaManager MaxUploadFileSize="20480000" />
                            <TemplateManager DeletePaths="~/UserFile/Files/News" MaxUploadFileSize="20480000"
                                UploadPaths="~/UserFile/Files/News" ViewPaths="~/UserFile/Files/News" />
                            <DocumentManager DeletePaths="~/UserFile/Files/News" MaxUploadFileSize="20480000"
                                UploadPaths="~/UserFile/Files/News" ViewPaths="~/UserFile/Files/News" />
                            <FlashManager DeletePaths="~/UserFile/Media/News" MaxUploadFileSize="20480000" UploadPaths="~/UserFile/Media/News"
                                ViewPaths="~/UserFile/Media/News" />
                            <Content>
                            
                            
                            
                            </Content>
                            <ImageManager ViewPaths="~/UserFile/Images/News" DeletePaths="~/UserFile/Images/News"
                                MaxUploadFileSize="3048000" UploadPaths="~/UserFile/Images/News"></ImageManager>
                        </telerik:RadEditor>
                    </td>
                </tr>
                  
                 
            </tbody>
        </table>
    </div>
    
    <div class="btn_left">
        <asp:LinkButton runat="server" ID="btn_add1" CssClass="Jm dU" Text="Gửi mail" OnClick="btn_add_Click" />
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/home/Default.aspx"
            CssClass="Jm dU" Text="Trang chủ" />
    </div>
</div>