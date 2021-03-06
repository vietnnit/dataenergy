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

public partial class Client_ContactSucceed : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //  ltlSucceed1.Text = "Bạn đã gửi thông tin liên hệ đến chúng tôi. Chúng tôi sẽ liên lạc lại với bạn trong thời gian sớm nhất. Cám ơn bạn đã quan tâm. Nhấn vào đây để về ";
        ltlSucceed1.Text = Resources.resource.Contact_succeed1;
        ltlSucceed2.Text = Resources.resource.Contact_succeed2; ;
        title_cate.Text = CateNavigator();
        title_name.Text = Resources.resource.T_Contact_Form;
    }

    private string CateNavigator()
    {
        //string url = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>TRANG CHỦ</a>  &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";
        string url = "&nbsp;";
        url = "<img src='" + ResolveUrl("~/") + "images/menutop_homepage.png' width='16' class='icon_home'><a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.T_home + "</a> ";
        return url;
    }
}
