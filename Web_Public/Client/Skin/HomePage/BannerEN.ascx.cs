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
public partial class Client_BannerEN : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{

        //    HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
        //    if (cookie_lang != null && cookie_lang["Lang"] != null && cookie_lang["Lang"].Trim() != string.Empty)
        //    {
        //        //if (cookie_lang["Lang"].ToString().Equals("vi-VN"))
        //        //    lang.Text = "<img src='" + ResolveUrl("~/") + "CSS_Admin/images/vietnamese.png' width='24' id='hlLanguage' onmouseover='DoPopup(\"hlLanguage\",\"divLanguage\")' onmouseout='KillPopup(\"divLanguage\")' >";
        //        //if (cookie_lang["Lang"].ToString().Equals("en-US"))
        //        //    lang.Text = "<img src='" + ResolveUrl("~/") + "CSS_Admin/images/english.png' width='24' id='hlLanguage' onmouseover='DoPopup(\"hlLanguage\",\"divLanguage\")' onmouseout='KillPopup(\"divLanguage\")' >";

        //        if (cookie_lang["Lang"].ToString().Equals("vi-VN"))
        //        {
        //            ltlVN.Text = "<img src='" + ResolveUrl("~/") + "CSS_Admin/images/vietnamese.png' width='33' >";
        //            ltlEn.Text = "<img src='" + ResolveUrl("~/") + "CSS_Admin/images/english_disable.png' width='33' >";
        //        }
        //        if (cookie_lang["Lang"].ToString().Equals("en-US"))
        //        {
        //            ltlVN.Text = "<img src='" + ResolveUrl("~/") + "CSS_Admin/images/vietnamese_disable.png' width='33' >";
        //            ltlEn.Text = "<img src='" + ResolveUrl("~/") + "CSS_Admin/images/english.png' width='33' >";
        //        }

        //    }


        //}
    }
    //protected void btn_lang_vi(object sender, EventArgs e)
    //{
    //    HttpCookie cookie_lang = new HttpCookie("LangInfo_CMS");
    //    cookie_lang["Lang"] = "vi-VN";
    //    cookie_lang.Expires = DateTime.Now.AddDays(1);
    //    Response.Cookies.Add(cookie_lang);

    //    Language.language = cookie_lang["Lang"].ToString();
    //    AspNetCache.Reset();
    //    Response.Redirect("~/Default.aspx");
    //}
    //protected void btn_lang_en(object sender, EventArgs e)
    //{
    //    HttpCookie cookie_lang = new HttpCookie("LangInfo_CMS");
    //    cookie_lang["Lang"] = "en-US";
    //    cookie_lang.Expires = DateTime.Now.AddDays(1);
    //    Response.Cookies.Add(cookie_lang);

    //    Language.language = cookie_lang["Lang"].ToString();
    //    AspNetCache.Reset();
    //    Response.Redirect("~/Default.aspx");
    //}
}
