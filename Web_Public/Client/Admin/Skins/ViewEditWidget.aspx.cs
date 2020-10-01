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
public partial class ViewEditWidget : System.Web.UI.Page
{
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

        if (!string.IsNullOrEmpty(Request["type"]))
        {
            SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
            SYS_WidgetType _widgetType = _widgetTypeBSO.GetSYS_WidgetTypeById(Convert.ToInt32(Request["type"].ToString()));

            if (_widgetType != null)
            {
                if (_widgetType.WidgetControl != "")
                    PlaceHolder1.Controls.Add(LoadControl(ResolveUrl("~")+ _widgetType.WidgetDir + "/" + _widgetType.WidgetControl));
            }
        }

        
    }

}
