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
public partial class Client_BannerTop : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblDate.Text = Tool.GetCurrentDateTimeDay("vi-VN");
        ViewMenuTop();
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

    private void ViewMenuTop()
    {
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("Bannertop_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            MenuLinksBSO _menulink = new MenuLinksBSO();
            table = _menulink.GetHotMenuLinks(hddValue.Value, Convert.ToInt32(hddRecord.Value),  Language.language);
            AspNetCache.SetCacheWithTime("Bannertop_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("Bannertop_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }

        rptAdv.DataSource = table;
        rptAdv.DataBind();
    }

    //protected void rptAdv_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{

        //LinkButton btnLink = (LinkButton)e.Item.FindControl("btnLink");
        //btnLink.ToolTip = DataBinder.Eval(e.Item.DataItem, "MenuLinksName").ToString();

        //string Imgthumb = DataBinder.Eval(e.Item.DataItem, "MenuLinksIcon").ToString();
        //Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlICON");
        //if (Imgthumb != "")
        //    ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Upload/MenuLinks/" + Imgthumb + "' width='" + DataBinder.Eval(e.Item.DataItem, "Width").ToString() + "' height='" + DataBinder.Eval(e.Item.DataItem, "Height").ToString() + "' alt='" + DataBinder.Eval(e.Item.DataItem, "MenuLinksName").ToString() + "' >";

    //}
    //protected void rptAdv_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    int mID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
    //    if (e.CommandName == "_link")
    //    {
    //        MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
    //        menuLinksBSO.MenuLinksClickUpdate(mID);

    //        Response.Redirect(menuLinksBSO.GetMenuLinksById(mID).MenuLinksUrl);

    //    }
    //}
}
