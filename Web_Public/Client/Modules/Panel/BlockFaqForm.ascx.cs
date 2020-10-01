using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ETO;
using BSO;

public partial class Client_BlockFaqForm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindToCateFaqs();
        }
    }

    protected void BindToCateFaqs()
    {
        ddlFaqsCate.Items.Clear();
        FaqsCateBSO faqscateBSO = new FaqsCateBSO();
        DataTable table = faqscateBSO.GetFaqsCate();

        ddlFaqsCate.DataTextField = "FaqsCateName";
        ddlFaqsCate.DataValueField = "FaqsCateID";
        ddlFaqsCate.DataSource = table;
        ddlFaqsCate.DataBind();

        if (table.Rows.Count > 0)
        {
            ddlFaqsCate.SelectedValue = table.Rows[0]["FaqsCateID"].ToString();
        }

    }

    #region ReceiveHtml
    private Faqs ReceiveHtml()
    {
        Faqs faqs = new Faqs();
        faqs.FaqsID = 0;
        faqs.FaqsCateID = Convert.ToInt32(ddlFaqsCate.SelectedValue);
        faqs.ParentFaqsID = 0;

        faqs.Title = txtTitle.Text;
        faqs.Contents = txtContent.Text;
        faqs.PostDate = DateTime.Now;

        faqs.FullName = txtFullname.Text;
        faqs.Address = txtAddress.Text;
        faqs.Department = txtDepartment.Text;
        faqs.Email = txtEmail.Text;
        faqs.Fax = "";
        faqs.Phone = txtPhone.Text;
        faqs.NickSkype = "";
        faqs.NickYahoo = "";
        faqs.Orders = 1;

        faqs.Actived = false;

        faqs.UserName = "";
        faqs.ApprovedDate = DateTime.Now;

      return faqs;

    }
    #endregion

    protected void btn_add_faqs(object sender, EventArgs e)
    {
        Faqs obj = ReceiveHtml();

        if (txtCapcha.Text.ToLower() == Session["Random"].ToString().ToLower())
        {
            FaqsBSO objBSO = new FaqsBSO();
            FaqsCateBSO faqscateBSO = new FaqsCateBSO();
            FaqsCate _faqCate = faqscateBSO.GetFaqsCateById(obj.FaqsCateID);

            int i = objBSO.CreateFaqsGet(obj);

            string strBody = "<b>Thông tin khách hàng : </b><br/>";
            strBody += "<b>Họ tên khách hàng : </b> " + obj.FullName + "<br/>";
            strBody += "<b>Email : </b> " + obj.Email + "<br/>";
            strBody += "<b>Điện thoại : </b> " + obj.Phone + "<br/>";
            strBody += "<b>Đơn vị công tác : </b> " + obj.Department + "<br/>";
            strBody += "<b>Địa chỉ : </b> " + obj.Address + "<br/><br/>";
            strBody += "<b>Thông tin yêu cầu hỗ trợ : </b> <br/>";
            strBody += "<b>Tiêu đề : </b> " + obj.Title + "<br/><br/>";
            strBody += "<b>Nội dung yêu cầu : </b> " + obj.Contents + "<br/><br/>";
            strBody += "<a href='" + Variables.sWebRoot + "d3/faqs/" + GetString(obj.Title) + "-" + obj.FaqsID + ".aspx'><b>Xem chi tiết</b></a>";
            strBody += "<br/>";

            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);

            MailBSO mailBSO = new MailBSO();
            mailBSO.EmailFrom = config.Email_from;

            string strObj = "Thông tin yêu cầu hỗ trợ trên website " + config.WebName + " ngày: " + DateTime.Now.ToString("dd:MM:yyyy");
            mailBSO.SendMail(config.Email_to, strObj, strBody);

            //string strObj1 = "Website Thoitrangdongphuc.com.vn tran trong cam on ";
            //mailBSO.SendMail(obj.Email, strObj1, contentMail());

            //string strObj3 = "Website Thoitrangdongphuc.com.vn gioi thieu ";
            //mailBSO.SendMail(obj.Email, strObj3, contentSendMail());

            Tool.Message(this.Page, "Cám ơn bạn đã gửi yêu cầu hỗ trợ đến chúng tôi, tất cả các thông tin bạn yêu cầu chúng tôi sẽ trả lời ngay khi chúng tôi nhận được. Trân trọng!");
        }
        else
        {
            Tool.Message(this.Page, "Sai mã xác nhận. Trân trọng!");
        }

    }


    //#region ReceiveNewsLetter
    //public PhoneBook ReceiveNewsLetter()
    //{
    //    PhoneBook obj = new PhoneBook();

    //    obj.FullName = txtFullName.Text;
    //    obj.Phone1 = txtPhone1.Text;
    //    obj.Phone2 = txtPhone2.Text;
    //    obj.Officephone = "";
    //    obj.HomePhone = "ID: " + hddProductID.Value;
    //    obj.Email = txtEmail.Text;
    //    obj.Address = txtAddress.Text;
    //    obj.Orders = 0;
    //    obj.ParentId = 0;

    //    obj.CreatorId = "GuestRegister";
    //    return obj;

    //}
    //#endregion

    //#region ReceiveMail
    //public Email ReceiveMail()
    //{
    //    Email obj = new Email();

    //    obj.EmailAddress = txtSendMail.Text;
    //    obj.Name = txtSendMail.Text;

    //    return obj;

    //}
    //#endregion

    //protected void btn_add_email(object sender, EventArgs e)
    //{
    //    PhoneBook obj = ReceiveNewsLetter();

    //    if (txtCapcha.Text.ToLower() == Session["Random"].ToString().ToLower())
    //    {
    //        PhoneBookBSO objBSO = new PhoneBookBSO();

    //        objBSO.CreatePhoneBook(obj);

    //        ProductBSO productBSO = new ProductBSO();
    //        Product product = productBSO.GetProductById(Convert.ToInt32(hddProductID.Value));
    //        if (product == null)
    //            Response.Redirect("~/Default.aspx");

    //        string strBody = "Thông tin Khách hàng đăng ký đặt hàng qua email : <br>";
    //        strBody += "<b>Họ tên khách hàng : </b> " + obj.FullName + "<br>";
    //        strBody += "<b>Email : </b> " + obj.Email + "<br>";
    //        strBody += "<b>Điện thoại : </b> " + obj.Phone1 + "<br>";
    //        strBody += "<b>Đơn vị công tác : </b> " + obj.Address + "<br>";
    //        strBody += "<b>Chức vụ : </b> " + obj.Phone2 + "<br>";
    //        strBody += "<b>Sản phẩm đặt hàng : </b> ";
    //        strBody += "<a href='" + Variables.sWebRoot + "d4/product/" + GetString(product.ProductName) + "-" + hddGroupCate.Value + "-" + product.ProductID + ".aspx'>" + product.ProductName + "</a>";
    //        strBody += "<br/>";

    //        ConfigBSO configBSO = new ConfigBSO();
    //        Config config = configBSO.GetAllConfig(Language.language);

    //        MailBSO mailBSO = new MailBSO();
    //        mailBSO.EmailFrom = config.Email_from;

    //        string strObj = "Thông tin khách hàng đăng ký đặt hàng qua Email tại website thoitrangdongphuc.com.vn " + DateTime.Now.ToString("dd:MM:yyyy");
    //        mailBSO.SendMail(config.Email_to, strObj, strBody);

    //        string strObj1 = "Website Thoitrangdongphuc.com.vn tran trong cam on ";
    //        mailBSO.SendMail(obj.Email, strObj1, contentMail());

    //        string strObj3 = "Website Thoitrangdongphuc.com.vn gioi thieu ";
    //        mailBSO.SendMail(obj.Email, strObj3, contentSendMail());

    //        Tool.Message(this.Page, "Cám ơn bạn đã gửi thông tin đặt hàng sản phẩm đến chúng tôi, tất cả các thông tin bạn yêu cầu chúng tôi sẽ trả lời ngay khi chúng tôi nhận được. Trân trọng!");
    //    }
    //    else
    //    {
    //        Tool.Message(this.Page, "Sai mã xác nhận. Trân trọng!");
    //    }

    //}

    //protected string contentMail()
    //{
    //    string body = "";

    //    body += "<p>Cảm ơn bạn đã truy cập vào website  <a href='http://thoitrangdongphuc.com.vn'>http://thoitrangdongphuc.com.vn<a>  của chúng tôi tất cả các thông tin bạn yêu cầu chúng tôi sẽ trả lời ngay khi chúng tôi nhận được. </p>";
    //    body += "<p>Bạn cần thông tin gì về lĩnh vực thời trang đồng phục hãy vui lòng gửi thư hoặc điện thoại  cho chúng tôi. Kể cả chúng tôi không phải là nhà cung cấp của bạn chúng tôi vẫn sẵn sàng trả lời những yêu cầu của bạn nếu bạn tin tưởng chúng tôi. </p>";
    //    body += "<p>Nếu bạn bè người thân có nhu cầu về thời trang đồng phục,xin vui lòng gửi  địa chỉ website này tới họ.</p>";

    //    body += "<p></p";
    //    body += "<p>Trân trọng Cảm ơn.</p>";
    //    body += "<p></p>";
    //    body += "<p></p>";
    //    body += "<p>----------o0o-------------</p>";
    //    body += "<p><b>Công ty Cổ phần Đầu tư và Thương mại B&B Việt nam</b></p>";
    //    body += "<p>SỐ 8/A9 TT Đại học Ngoại Ngữ,Q.Thanh Xuân- Hà Nội( Km số 9 đường Nguyễn Trãi-Thanh xuân)</p>";
    //    body += "<p>Tel: 04-85-87-83-75- Mobile: 0903-407-686</p>";
    //    body += "<p>Website: <a href='http://thoitrangdongphuc.com.vn'>http://thoitrangdongphuc.com.vn</a>* *</p>";


    //    return body;


    //}

    //protected string contentSendMail()
    //{
    //    string body = "";

    //    body += "<p><b>Kính gửi : Quí khách hàng </b></p>";
    //    body += "<p></p>";
    //    body += "<p>Thoitrangdongphuc.com.vn : là doanh nghiệp trực tiếp thiết kế và sản xuất hàng thời trang chuyên cho lĩnh vực đồng phục may mặc.Phương châm hoạt động của doanh nghiệp là “cung cấp cho khách hàng của chúng tôi chất lượng sản phẩm,dịch vụ và giá là tốt nhất” đến với chúng tôi khách mua hàng có lợi thế sau: </p>";

    //    body += "<p></p>";
    //    body += "<p>1-Bạn thích màu vải nào chúng tôi đáp ứng, thoải mái chọn chất liệu vải và mẫu mã (nếu là may lần đầu hoặc muốn thay đổi mẫu đồng phục cũ)</p>";
    //    body += "<p></p>";

    //    body += "<p>2-Khách mua hàng không cần trực tiếp đến với chúng tôi,chỉ cần gọi số Hotline. Việc còn lại là của chúng tôi. Giao hàng trong thời gian từ 30-60 ngày tùy theo số lượng.</p>";
    //    body += "<p></p>";

    //    body += "<p>3- Chính sách giá của chúng tôi là: Bạn mua càng nhiều chúng tôi giảm giá với mức cam kết là tốt nhất nhưng chất lượng sản phẩm không thay đổi. Nếu bạn không hài lòng bạn có thể kiểm tra. </p>";

    //    body += "<p></p>";
    //    body += "<p>4- Dịch vụ sau bán hàng của chúng tôi là tốt nhất.</p>";
    //    body += "<p></p>";
    //    body += "<p>Bạn nên liên hệ với chúng tôi xin vui lòng làm như vậy tại địa chỉ dưới đây hoặc tại sao không Email,hoặc điện thoại cho chúng tôi với yêu cầu của bạn.</p>";
    //    body += "<p></p>";
    //    body += "<p></p>";

    //    body += "<p><b>Công ty cổ phần B&B Việt nam.</b></p>";
    //    body += "<p>Số 8/A9 TT Đại học Hà nộil( Km số 9 đường Nguyễn trãi -Thanh xuân-HN) </p>";
    //    body += "<p>Liên lạc: 04-85-87-83-75 – Hotline: 0913-211-811</p>";
    //    body += "<p>Website : <a href='http://thoitrangdongphuc.com.vn'>http://thoitrangdongphuc.com.vn</a></p>";
    //    body += "<p>Email : sales@thoitrangdongphuc.com.vn</p>";
    //    body += "<p>kinhdoanh@bbvietnam.net</p>";

    //    body += "<p></p>";
    //    body += "<p><i>Cảm ơn bạn đã đọc thư này. Email này được gởi đến bạn vì nghĩ rằng thông tin này có ích cho bạn. Thành thật xin lỗi bạn nếu thông tin này làm phiền bạn. Powered by <a href='http://thoitrangdongphuc.com.vn'>thoitrangdongphuc.com.vn</a> </i></p>";

    //    return body;


    //}


    //protected void btn_add_sendemail(object sender, EventArgs e)
    //{
    //    Email obj = ReceiveMail();

    //    if (txtCapcha2.Text.ToLower() == Session["Random1"].ToString().ToLower())
    //    {
    //        EmailBSO objBSO = new EmailBSO();

    //        objBSO.CreateEmail(obj);


    //        string strBody = "Thông tin Khách hàng gửi email : <br>";
    //        strBody += "<b>Email : </b> " + obj.EmailAddress + "<br>";


    //        ConfigBSO configBSO = new ConfigBSO();
    //        Config config = configBSO.GetAllConfig(Language.language);

    //        MailBSO mailBSO = new MailBSO();
    //        mailBSO.EmailFrom = config.Email_from;

    //        string strObj = "Thông tin khách hàng gửi Email tại website Thoitrangdongphuc.com.vn " + DateTime.Now.ToString("dd:MM:yyyy");
    //        mailBSO.SendMail(config.Email_to, strObj, strBody);


    //        string strObj1 = "Website Thoitrangdongphuc.com.vn tran trong cam on ";
    //        mailBSO.SendMail(obj.EmailAddress, strObj1, contentMail());

    //        string strObj3 = "Website Thoitrangdongphuc.com.vn gioi thieu ";
    //        mailBSO.SendMail(obj.EmailAddress, strObj3, contentSendMail());

    //        Tool.Message(this.Page, "Cám ơn bạn. Thông tin về doanh nghiệp chúng tôi đã được gửi đến email của quý khách. Chúng tôi sẵn sàng trả lời những yêu cầu của bạn nếu bạn tin tưởng chúng tôi. Trân trọng!");
    //    }
    //    else
    //    {
    //        Tool.Message(this.Page, "Sai mã xác nhận. Trân trọng!");
    //    }


    //}
    protected string GetString(object _txt)
    {
        if (_txt != null)
        {
            Utils objUtil = new Utils();
            return objUtil.Getstring(_txt.ToString());
        }
        return "";
    }
}
