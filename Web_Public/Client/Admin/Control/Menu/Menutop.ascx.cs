using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;

public partial class Control_Modules_Menu_Menutop : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (m_UserValidation.IsSigned())
            {
                welcomAdmin.Text = "<span class='hidden-sm hidden-xs'>Xin chào, </span>" + m_UserValidation.UserName;
            }

            HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
            if (cookie_lang != null && cookie_lang["Lang"] != null && cookie_lang["Lang"].Trim() != string.Empty)
            {
                if (cookie_lang["Lang"].ToString().Equals("vi-VN"))
                    lang.Text = "<span class='flag-xs flag-vn mr5'></span><span class='hidden-sm hidden-xs'>Tiếng Việt</span>";
                else
                    if (cookie_lang["Lang"].ToString().Equals("en-US"))
                        lang.Text = "<span class='flag-xs flag-us mr5'></span><span class='hidden-sm hidden-xs'>English</span>";
            }


        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        m_UserValidation.SignOut();
        Session.RemoveAll();
        Session.Abandon();

        Response.Redirect("~/Default.aspx");
    }
    protected void lbSignInOrther_Click(object sender, EventArgs e)
    {
        m_UserValidation.SignOut();
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("~/Admin/login.aspx");
    }
    protected void linkRemoveCache_Click(object sender, EventArgs e)
    {

        AspNetCache.Reset();
    }

    protected void btn_lang_vi(object sender, EventArgs e)
    {
        HttpCookie cookie_lang = new HttpCookie("LangInfo_CMS");
        cookie_lang["Lang"] = "vi-VN";
        cookie_lang.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(cookie_lang);

        Language.language = cookie_lang["Lang"].ToString();
        AspNetCache.Reset();
        Response.Redirect("~/Admin/home/Default.aspx");
    }
    protected void btn_lang_en(object sender, EventArgs e)
    {
        HttpCookie cookie_lang = new HttpCookie("LangInfo_CMS");
        cookie_lang["Lang"] = "en-US";
        cookie_lang.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(cookie_lang);

        Language.language = cookie_lang["Lang"].ToString();
        AspNetCache.Reset();
        Response.Redirect("~/Admin/home/Default.aspx");
    }
}
