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
public partial class Homepage : System.Web.UI.Page
{

    UserValidation m_UserValidation = new UserValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
        if (cookie_lang == null || cookie_lang["Lang"] == null || cookie_lang["Lang"] == string.Empty)
        {
            cookie_lang = new HttpCookie("LangInfo_CMS");
            cookie_lang["Lang"] = "vi-VN";
            cookie_lang.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie_lang);
        }
        Language.language = cookie_lang["Lang"].ToString();
        Session["Lang"] = cookie_lang["Lang"].ToString();

        ETO.Config config = new ETO.Config();
        if (AspNetCache.CheckCache("Config_" + Language.language) == false)
        {
            ConfigBSO configBSO = new ConfigBSO();

            config = configBSO.GetAllConfig(Language.language);
            AspNetCache.SetCacheWithTime("Config_" + Language.language, config, 150);
        }
        else
        {
            config = (ETO.Config)AspNetCache.GetCache("Config_" + Language.language);
        }
        Page.Title = config.Titleweb;

        ModulesBSO _moduleBSO = new ModulesBSO();
        Modules _module = new Modules();

        //string _userName = "";
        //HttpCookie cookie = Request.Cookies["UserInfor_EVNTIT"];
        //if (cookie != null && cookie["UserName"] != null && cookie["UserName"].Trim() != string.Empty)
        //{
        //    _userName = cookie["UserName"];
        //}   
        //_userName = //(string)AspNetCache.GetCache(GetIpAddress());

        //Session["Admin_Username"] = _userName;

        //if (Session["Admin_Username"] == null)
        //{
        //    if (!string.IsNullOrEmpty(Request["dll"]))
        //    {
        //        if (Request["dll"].Equals("login"))
        //            Response.Redirect("~/Admin/Login.aspx");
        //         //   PlaceHolder1.Controls.Add(LoadControl("Client/Admin/Login.ascx"));
        //        else
        //            Response.Redirect("~/Default.aspx");
        //    }
        //    else
        //        Response.Redirect("~/Default.aspx");
        //}
        if (!this.m_UserValidation.IsSigned())
        {
            if (!string.IsNullOrEmpty(Request["dll"]) && Request["dll"].Equals("login"))
            {
                Response.Redirect("~/Admin/Login.aspx");
            }
            else
                Response.Redirect("~/Default.aspx");
        }
        else
        {
            Session["Admin_Username"] = m_UserValidation.UserName;

            if (!string.IsNullOrEmpty(Request["dll"]))
            {
                if (CheckExit(Request["dll"].ToString()))
                {
                    bool levelAdmin = CheckLevelAdmin(Request["dll"].ToString(), Session["Admin_UserName"].ToString());
                    if (levelAdmin == true)
                    {
                        _module = _moduleBSO.GetModulesBySlug(Request["dll"].ToString());

                        PlaceHolder1.Controls.Add(LoadControl("Client/Admin/" + _module.ModulesDir + "/" + _module.ModulesUrl + ".ascx"));
                    }
                    else
                        if (Request["dll"].Equals("login"))
                            // PlaceHolder1.Controls.Add(LoadControl("Client/Admin/Login.ascx"));
                            Response.Redirect("~/Admin/Login.aspx");
                        else
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                }
                else
                {
                    if (Request["dll"].Equals("login"))
                        // PlaceHolder1.Controls.Add(LoadControl("Client/Admin/Login.ascx"));
                        Response.Redirect("~/Admin/Login.aspx");
                    else
                    {
                        Response.Redirect("~/Admin/home/Default.aspx");
                    }
                }

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

    }


    private bool CheckLevelAdmin(string url, string sStrAdmin)
    {
        bool levelAdmin = false;
        ModulesBSO modulesBSO = new ModulesBSO();
        levelAdmin = modulesBSO.CheckLevelModulesRoles(url, sStrAdmin);

        return levelAdmin;
    }

    private bool CheckExit(string url)
    {
        bool exit = false;
        ModulesBSO modulesBSO = new ModulesBSO();
        exit = modulesBSO.CheckExist(url);

        return exit;
    }

}
