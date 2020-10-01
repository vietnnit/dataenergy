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
using System.Threading;
using System.Globalization;
using ETO;
using BSO;
public partial class _Default : System.Web.UI.Page
{
    #region Properties

    /// <summary>
    /// Get Go
    /// </summary>
    private string Go
    {
        get
        {
            if (!string.IsNullOrEmpty(Request["go"]))
                return Request["go"].ToString();
            else
                return "";
        }
    }

    private string g
    {
        get
        {
            if (!string.IsNullOrEmpty(Request["g"]))
                return Request["g"].ToString();
            else
                return "";
        }
    }

    private string m
    {
        get
        {
            if (!string.IsNullOrEmpty(Request["m"]))
                return Request["m"].ToString();
            else
                return "";
        }
    }
    #endregion

    void Page_PreInit(object sender, EventArgs e)
    {
        HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
        if (cookie_lang == null)
        {
            cookie_lang = new HttpCookie("LangInfo_CMS");
            cookie_lang["Lang"] = "vi-VN";
            cookie_lang.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie_lang);
        }
        Language.language = cookie_lang["Lang"].ToString();

        string strPage = Request.QueryString["go"];
        MasterPageFile = "~/Client/Skin/Template/" + Utils.LoadMasterPage(ResolveUrl("~"), strPage, this.Page.Request, this.Page, PlaceHolder, Language.language);
        // MasterPageFile = "~/Client/Skin/Template/ListPage.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!IsPostBack)
        //{
        //    string strUrl = Request.Url.AbsoluteUri;
        //    if (!strUrl.Contains("http://http://tuyensinhtructuyen.edu.vn"))
        //    {
        //        Response.Redirect("http://http://tuyensinhtructuyen.edu.vn");
        //    }
        //}

        //if (isMobileBrowser())
        //{
        //    if (!m.ToString().Equals("true"))
        //    {
        //        string url = Request.RawUrl.ToString();

        //        Response.Redirect("http://m.http://tuyensinhtructuyen.edu.vn" + url);
        //    }
        //}

        HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
        if (cookie_lang == null)
        {
            cookie_lang = new HttpCookie("LangInfo_CMS");
            cookie_lang["Lang"] = "vi-VN";
            cookie_lang.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie_lang);
        }
        Language.language = cookie_lang["Lang"].ToString();

        Config config = new Config();
        if (AspNetCache.CheckCache("Config_" + Language.language) == false)
        {
            ConfigBSO configBSO = new ConfigBSO();

            config = configBSO.GetAllConfig(Language.language);
            AspNetCache.SetCacheWithTime("Config_" + Language.language, config, 150);
        }
        else
        {
            config = (Config)AspNetCache.GetCache("Config_" + Language.language);
        }

        Page.Title = config.Titleweb;
        //}
        //string strPage = Request.QueryString["go"];
        string strPage = Request.QueryString["go"];
        Utils.AddWidgetPage(ResolveUrl("~"), strPage, this.Page.Request, this.Page, PlaceHolder);
        //Utils.GetNavigation(Request.QueryString["go"], Request.QueryString["g"], Request.QueryString["cid"], Request.QueryString["id"], ResolveUrl("~"));


    }
    protected override void InitializeCulture()
    {
        HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
        string lang = (cookie_lang != null && cookie_lang["Lang"] != null && cookie_lang["Lang"].Trim() != string.Empty) ? cookie_lang["Lang"].ToString() : "vi-VN";

        if (lang != null && lang != "")
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
        }
    }

    private void GetHitCounter()
    {
        HitCounterBSO hitcounterBSO = new HitCounterBSO();
        long hitcounter = hitcounterBSO.GetHitCounter();
        hitcounterBSO.UpdateHitCounter(hitcounter + 1);
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
