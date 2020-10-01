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
public partial class Client_BannerTPSlider : System.Web.UI.UserControl
{
    public static int _height = 230;

    protected void Page_Load(object sender, EventArgs e)
    {
        //GetHeight();
        ViewBanner();
    }

    //private void GetHeight()
    //{
    //    DataTable table = new DataTable();

    //    if (AspNetCache.CheckCache("tbl_BannerSlider_Root_" + hddValue.Value) == false)
    //    {
    //        MenuLinksBSO menulinksBSO = new MenuLinksBSO();
    //        table = menulinksBSO.GetRootMenuLinks(hddValue.Value, Language.language);
    //        AspNetCache.SetCache("tbl_BannerSlider_Root_" + hddValue.Value, table);

    //    }
    //    else
    //    {
    //        table = (DataTable)AspNetCache.GetCache("tbl_BannerSlider_Root_" + hddValue.Value);
    //    }

    //    if (table.Rows.Count > 0)
    //    {
    //        DataRow row = table.Rows[0];
    //        _height = Convert.ToInt32(row["Height"].ToString());
    //    }
    //}
    private void ViewBanner()
    {
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("tbl_BannerSlider_Main_" + hddValue.Value) == false)
        {
            MenuLinksBSO menulinksBSO = new MenuLinksBSO();
            table = menulinksBSO.GetHotMenuLinks(hddValue.Value, Language.language);
            AspNetCache.SetCache("tbl_BannerSlider_Main_" + hddValue.Value, table);

        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("tbl_BannerSlider_Main_" + hddValue.Value);
        }

        //string strBannerLarger = "";
        //string strBannerThumb = "";
        if (table.Rows.Count > 0)
        {
            rptSlider.DataSource = table;
            rptSlider.DataBind();
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    DataRow row = table.Rows[i];

            //    strBannerLarger += "<div class='item " + ((i == 0) ? "active" : "") + "'>";

            //    strBannerLarger += "<img src='" + Utils.getURLThumbImage(row["MenuLinksIcon"].ToString(), Convert.ToInt32(row["Width"])) + "' alt='" + row["MenuLinksName"] + "' > ";
            //    if (row["MenuLinksHelp"].ToString() != "")
            //    {

            //        strBannerLarger += "<div class='container'>";
            //          strBannerLarger += "<div class='carousel-caption'>";
                   
            //        strBannerLarger += "<a href='" + row["MenuLinksUrl"] + "' target='" + row["Target"] + "'>";
            //         strBannerLarger += "<h1>" + row["MenuLinksName"] + "</h1>";
            //         strBannerLarger += "</a>";
            //         strBannerLarger += "<p class='blurb whitealpha hidden-xs'>";
            //        strBannerLarger += row["MenuLinksHelp"] + "";
            //        strBannerLarger += "</p>";
                     
            //        //if (row["MenuLinksUrl"].ToString() != "" & row["MenuLinksUrl"].ToString() != "#")
            //        //{
            //        //    strBannerLarger += "<p>";
            //        //    strBannerLarger += "<a class='btn btn-lg btn-primary'  role='button' href='" + row["MenuLinksUrl"] + "' target='" + row["Target"] + "'>Chi tiết... </a>";
            //        //    strBannerLarger += "</p>";
            //        //}
                   
            //        strBannerLarger += "</div>";
            //        strBannerLarger += "</div>";
                  
            //    }
            //    strBannerLarger += "</div>";
            //    // strBannerThumb += "<li><img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "Upload/MenuLinks/" + row["MenuLinksIcon"] , 70) + "' /></li>";
            //    //strBannerThumb += "<li><img src='" + ResolveUrl("~/") + "img.ashx?url=" + ResolveUrl("~/") + "Upload/MenuLinks/" + row["MenuLinksIcon"] + "&w=70' /></li>";
            //    strBannerThumb += "<li data-target='#sliderBanner' data-slide-to='" + i + "' " + ((i == 0) ? "class='active'" : "") + " ></li>";
            //}
        }
        //ltlBannerLarger.Text = strBannerLarger;
        //ltlBannerThumb.Text = strBannerThumb;
    }

}
