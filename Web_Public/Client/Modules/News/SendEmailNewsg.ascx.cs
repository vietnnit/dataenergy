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
public partial class Client_SendEmailNewsg : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request["error"]))
            labMassege.Text = "Bản tin đã được gửi đến địa chỉ: " + Request["error"];

        title_cate.Text = "<a href='"+ResolveUrl("~/")+"Default.aspx' class='content_Text_Cat'>TRANG CHỦ</a> &nbsp;<img src='"+ResolveUrl("~/")+"images/icon_arrows1.png'>&nbsp;";
        //title_name.Text = "Thông báo";
        title_name.Text = "Gửi Mail bản tin";
    }



    protected void btn_Send_Click(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"], out Id);

        NewsGroupBSO newsBSO = new NewsGroupBSO();
        NewsGroup news = newsBSO.GetNewsGroupById(Id);
        ConfigBSO configBSO = new ConfigBSO();
        Config config = configBSO.GetAllConfig(Language.language);

        string email = txtEmail.Text.Trim();

        string strBody = "Bản tin từ Website " + config.WebName + " ("+ config.WebDomain +") : <br>";

        strBody += "<b>" + news.Title + "</b> <br>";
        strBody += "<img src='" + config.WebDomain + "/Upload/NewsGroup/NewsGroupThumb/" + news.ImageThumb + "' align='left' border='0' hspace='5'>";
        strBody += "<b>" + news.ShortDescribe + "</b> <br>";
        strBody += news.FullDescribe + "<br>";
        strBody += news.Author + "<br>";

        strBody += "<b>Liên kết đến bản tin : </b>  <a href='" + config.WebDomain + "/News/" + news.GroupCate + "/" + news.NewsGroupID+"/"+GetString(news.Title) + ".aspx'>" + news.Title + "</a><br>";



        MailBSO mailBSO = new MailBSO();
        


        mailBSO.EmailFrom = config.Email_from;

        string strObj = "Bản tin từ Website " + config.WebName + " (" + config.WebDomain + ") - Ngày:  " + DateTime.Now.ToString("dd:MM:yyyy");
        mailBSO.SendMail(email, strObj, strBody);


        Response.Redirect("~/MailNews/" + Id + "/" + email + "/Default.aspx");


    }

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
