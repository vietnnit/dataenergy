<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SendEmailNewsg.ascx.cs" Inherits="Client_SendEmailNewsg" %>

<div class="mainContent_panel2">
	<div class="mainContent_mainTitle">
            <span class="content_Text_Cat"> <asp:Literal ID="title_cate" runat="server"></asp:Literal> </span>
            <span class="content_Text"><asp:Literal ID="title_name" runat="server"></asp:Literal></span>
        
      
    </div>
    
    <div class="main_home">
            <div style="padding-top:10px; vertical-align:top; text-align:center;">
    		    
    		    <div class="error_register_text"><asp:Literal ID="labMassege" runat="server"></asp:Literal></div>
    	    
	            <div>
	                    <asp:Label ID="Label1" runat="server" Text="Nhập địa chỉ Email :" CssClass="txt-contact"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="register_text_input" Width="270"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:Button ID="btn_send" runat="server" Text="Gửi Email" OnClick="btn_Send_Click" /><br />
                        
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Sai kiểu Email</asp:RegularExpressionValidator>
                </div>
        </div>                            
        
    </div>

</div>