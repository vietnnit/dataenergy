<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlockFaqForm.ascx.cs"
    Inherits="Client_BlockFaqForm" %>

<div class="panel-faqs margin-10t">
<div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title"><asp:Label ID="lblTitle" runat="server"></asp:Label></h3>
  </div>
  <div class="panel-body">
    <div class="input-group input-group-sm margin-10b">
      <span class="input-group-addon"><span class="glyphicon glyphicon-bullhorn"></span></span>
      <asp:TextBox ID="txtTitle" ValidationGroup="faqs" runat="server" CssClass="form-control" placeholder="Yêu cầu hỗ trợ" aria-describedby="sizing-addon3"></asp:TextBox>
      
    </div>
    <div class="input-group input-group-sm margin-10b">
      <span class="input-group-addon"><span class="glyphicon glyphicon-pencil"></span></span>
      <asp:TextBox ID="txtContent" ValidationGroup="faqs" runat="server" CssClass="form-control" placeholder="Nội dung yêu cầu" aria-describedby="sizing-addon3" TextMode="MultiLine" Height="100px"></asp:TextBox>
    </div>
    <div class="input-group input-group-sm margin-10b">
      <span class="input-group-addon"><span class="glyphicon glyphicon-th-list"></span></span>
      <asp:DropDownList ID="ddlFaqsCate" runat="server" CssClass="form-control"
        AppendDataBoundItems="true" ValidationGroup="faqs">
      </asp:DropDownList>

    </div>
    <div class="input-group input-group-sm margin-10b">
      <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
      <asp:TextBox ID="txtFullname" ValidationGroup="faqs" runat="server" CssClass="form-control" placeholder="Họ và tên" aria-describedby="sizing-addon3"></asp:TextBox>
    </div>

    <div class="input-group input-group-sm margin-10b">
      <span class="input-group-addon"><span class="glyphicon glyphicon-envelope"></span></span>
      <asp:TextBox ID="txtEmail" ValidationGroup="faqs" runat="server" CssClass="form-control" placeholder="Email" aria-describedby="sizing-addon3"></asp:TextBox>
    </div>

     <div class="input-group input-group-sm margin-10b">
      <span class="input-group-addon"><span class="glyphicon glyphicon-phone-alt"></span></span>
      <asp:TextBox ID="txtPhone" ValidationGroup="faqs" runat="server" CssClass="form-control" placeholder="Điện thoại" aria-describedby="sizing-addon3"></asp:TextBox>
    </div>
    <div class="input-group input-group-sm margin-10b">
      <span class="input-group-addon"><span class="glyphicon glyphicon-home"></span></span>
      <asp:TextBox ID="txtDepartment" ValidationGroup="faqs" runat="server" CssClass="form-control" placeholder="Đơn vị" aria-describedby="sizing-addon3"></asp:TextBox>
    </div>
    <div class="input-group input-group-sm margin-10b">
      <span class="input-group-addon"><span class="glyphicon glyphicon-earphone"></span></span>
      <asp:TextBox ID="txtAddress" ValidationGroup="faqs" runat="server" CssClass="form-control" placeholder="Địa chỉ liên hệ" aria-describedby="sizing-addon3"></asp:TextBox>

    </div>
     <div class="input-group input-group-sm margin-10b">
     <span class="input-group-addon"><span class="glyphicon glyphicon-qrcode"></span></span>
       <asp:TextBox ID="txtCapcha" ValidationGroup="faqs" runat="server" Width="100" CssClass="form-control" aria-describedby="sizing-addon3"></asp:TextBox>
          <img id="ImgCapcha" align="middle" alt="" runat="server" src="~/Client/Modules/Captcha/Image.aspx" />
    </div>
    <div class="btn-group fr" role="group">
        <asp:LinkButton runat="server" ID="btnSendMail" class="btn btn-primary btn-sm" Text="Gửi yêu cầu"  ValidationGroup="faqs" OnClick="btn_add_faqs"/> 
    </div>

  </div>
</div>
</div>


<%--<script type="text/javascript">
    function Focus(object) {
        object.value = "";
    }

    function Blur1(object) {
        if (object.value == "")
            object.value = "Họ và tên";
    }
    function Blur2(object) {
        if (object.value == "")
            object.value = "E-mail";
    }
    function Blur3(object) {
        if (object.value == "")
            object.value = "Điện thoại";
    }
    function Blur4(object) {
        if (object.value == "")
            object.value = "Đơn vị công tác";
    }
    function Blur5(object) {
        if (object.value == "")
            object.value = "Chức vụ";
    }
    function Blur6(object) {
        if (object.value == "")
            object.value = "Your Email";
    }
</script>
<div class="Fieldset_title_bg">
        <span class="Fieldset_title_text">Thông tin đặt hàng</span>
    </div>

<div class="main_register_panel">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td style="width: 20%; height: 20px" class="register_text">
                Họ và tên
            </td>
            <td>
                <asp:TextBox ID="txtFullName" ValidationGroup="G1" runat="server" CssClass="register_text_input"
                    Width="65%" Text="Họ và tên" onfocus="Focus(this)" onblur="Blur1(this)"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="G1" ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtFullName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
       
        <tr>
            <td style="width: 20%; height: 20px" class="register_text">
                Email
            </td>
            <td>
                <asp:TextBox ValidationGroup="G1" ID="txtEmail" runat="server"  Width="65%" CssClass="register_text_input"
                    Text="E-mail" onfocus="Focus(this)"></asp:TextBox>
                <asp:RegularExpressionValidator ValidationGroup="G1" ID="RegularExpressionValidator2"
                    runat="server" ControlToValidate="txtEmail" ErrorMessage="RegularExpressionValidator"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ValidationGroup="G1" ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; height: 20px" class="register_text">
                Điện thoại
            </td>
            <td>
                <asp:TextBox ValidationGroup="G1" ID="txtPhone1" runat="server"  Width="65%" CssClass="register_text_input"
                    Text="Điện thoại" onfocus="Focus(this)"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="G1" ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtPhone1" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; height: 20px" class="register_text">
                Đơn vị công tác
            </td>
            <td>
                <asp:TextBox ValidationGroup="G1" ID="txtAddress" runat="server"  Width="65%" CssClass="register_text_input"
                    Text="Đơn vị công tác" onfocus="Focus(this)"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="G1" ID="RequiredFieldValidator4" runat="server"
                    ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; height: 20px" class="register_text">
                Chức vụ
            </td>
            <td>
                <asp:TextBox ValidationGroup="G1" ID="txtPhone2" runat="server"  Width="65%" CssClass="register_text_input"
                    Text="Chức vụ" onfocus="Focus(this)"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="G1" ID="RequiredFieldValidator5" runat="server"
                    ControlToValidate="txtPhone2" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; height: 20px" class="register_text">
                Mã xác nhận
            </td>
            <td>
                <asp:TextBox ID="txtCapcha" ValidationGroup="G1" runat="server" Width="100" CssClass="register_text_input"></asp:TextBox>
                <img id="ImgCapcha" align="middle" alt="" runat="server" src="~/Client/Modules/Captcha/Image.aspx" />
            </td>
        </tr>
        <tr>
        <td style="width: 20%; height: 20px" class="register_text">
                
            </td>
            <td align="left" style="height: 48px">
                <asp:LinkButton runat="server" ID="btnNewsLetter" CssClass="Jm dU" Text="Đặt hàng"
                    ValidationGroup="G1" OnClick="btn_add_email" />
            </td>
        </tr>
    </table>
</div>
<div class="Fieldset_title_bg">
        <span class="Fieldset_title_text">Gửi sản phẩm cho bạn bè</span>
    </div>
<div class="main_register_panel">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td style="width: 20%; height: 20px" class="register_text">
                Email nhận thư
            </td>
            <td>
                <asp:TextBox ValidationGroup="G2" ID="txtSendMail" runat="server"  Width="65%" CssClass="register_text_input"
                    Text="Your E-mail" onfocus="Focus(this)" onblur="Blur6(this)"></asp:TextBox>
                <asp:RegularExpressionValidator ValidationGroup="G2" ID="RegularExpressionValidator1"
                    runat="server" ControlToValidate="txtSendMail" ErrorMessage="RegularExpressionValidator"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ValidationGroup="G2" ID="RequiredFieldValidator6" runat="server"
                    ControlToValidate="txtSendMail" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; height: 20px" class="register_text">
                Mã xác nhận
            </td>
            <td>
                <asp:TextBox ID="txtCapcha2" ValidationGroup="G2" runat="server" Width="100" CssClass="register_text_input"></asp:TextBox>
                <img id="Img1" align="middle" alt="" runat="server" src="~/Client/Modules/Captcha/Image1.aspx" />
            </td>
        </tr>
        <tr>
        <td style="width: 20%; height: 20px" class="register_text">
                
            </td>
            <td align="left" style="height: 48px">
                <asp:LinkButton runat="server" ID="btnSendMail" CssClass="Jm dU" Text="Gửi cho bạn bè"
                    ValidationGroup="G2" OnClick="btn_add_sendemail" />
            </td>
        </tr>
    </table>
</div>--%>
<asp:HiddenField ID="hddGroupCate" runat="server" />
<asp:HiddenField ID="hddProductID" runat="server" />
