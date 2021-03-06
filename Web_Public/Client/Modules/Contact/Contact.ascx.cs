using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using BSO;
public partial class Client_Contact : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewWelcome(Language.language);
        form_register.Visible = true;
        form_register_send.Visible = false;
    }

    private void ViewWelcome(string lang)
    {
        ConfigBSO configBSO = new ConfigBSO();
        Config config = configBSO.GetAllConfig(lang);
        LiteralContact.Text = config.Contact;
    }

    #region ReceiveHtml
    public Contact ReceiveHtml()
    {


        Contact contact = new Contact();
        contact.ContactID = 0;

        contact.Email = Email.Text.Trim();
        contact.Name = NameContact.Text.Trim();
        contact.Address = Address.Text.Trim();
        contact.Tel = Telephone.Text.Trim();
        contact.Fax = Fax.Text.Trim();

        contact.City = City.Text.Trim();
        contact.Company = Company.Text.Trim();


        contact.Date = DateTime.Now;


        contact.Attact = "";

        contact.Require = Require.Text;

        return contact;
    }
    #endregion

    protected void contact_Click(object sender, EventArgs e)
    {
        try
        {
            Contact contact = ReceiveHtml();
            if (txtCapcha.Text.ToLower() == Session["Random"].ToString().ToLower())
            {
                ContactBSO contactBSO = new ContactBSO();
                contactBSO.CreateContact(contact);

                ConfigBSO configBSO = new ConfigBSO();
                Config config = configBSO.GetAllConfig(Language.language);

                string strBody = "Thông tin liên hệ tới Website " + config.WebName + " (" + config.WebDomain + "): <br>";
                strBody += "<b>Họ tên  : </b> " + NameContact.Text + "<br>";
                strBody += "<b>Cơ quan công tác : </b> " + Company.Text + "<br>";
                strBody += "<b>Địa chỉ : </b> " + Address.Text + "<br>";
                strBody += "<b>Thành phố : </b> " + City.Text + "<br>";
                strBody += "<b>Điện thoại : </b> " + Telephone.Text + "<br>";
                strBody += "<b>Fax : </b> " + Fax.Text + "<br>";

                strBody += "<b>Email : </b> " + Email.Text + "<br>";
                strBody += "<b>Nội dung Yêu cầu : </b> " + Require.Text + "<br>";

                MailBSO mailBSO = new MailBSO();


                //       mailBSO.EmailFrom = Email.Value;
                mailBSO.EmailFrom = config.Email_from;
                string strObj = "Thông tin liên hệ tới quản trị viên website " + config.WebName + " (" + config.WebDomain + ") - Ngày " + DateTime.Now.ToString("dd:MM:yyyy");
                mailBSO.SendMail(config.Email_to, strObj, strBody);

                form_register.Visible = false;
                form_register_send.Visible = true;

                ltlSucceed1.Text = Resources.resource.Contact_succeed1;
                //ltlSucceed2.Text = Resources.resource.Contact_succeed2; ;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

    protected void btn_send_more(object sender, EventArgs e)
    {
        form_register.Visible = true;
        form_register_send.Visible = false;
    }
}
