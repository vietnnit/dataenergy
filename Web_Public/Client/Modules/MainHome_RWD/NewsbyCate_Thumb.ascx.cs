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
public partial class Client_NewsbyCate_Thumb : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int cateID = 0;
            if (!String.IsNullOrEmpty(hddValue.Value))
                if (int.TryParse(hddValue.Value.Replace(",", ""), out cateID))
                {
                    CateNewsBSO cateNewsBSO = new CateNewsBSO();
                    CateNews cateNews = cateNewsBSO.GetCateNewsById(cateID);

                    if (cateID != 0 && cateNews != null)
                    {
                        int groupcate = cateNews.GroupCate;
                        GetNewsGroup(cateID, groupcate);

                        ltlTitle.Text = "<a class='h2-cate' href='" + ResolveUrl("~/") + "c3/" + cateNewsBSO.GetSlugByCateId(cateNews.CateNewsID) + "/" + GetString(cateNews.CateNewsName) + "-" + groupcate + "-" + cateID + ".aspx' title='" + cateNews.CateNewsName + "'><span>" + cateNews.ShortName + "</span></a>";
                       
                    }
                }


        }
    }


    void GetNewsGroup(int cateID, int groupcate)
    {
        
        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("HTML_ltlNews_MainHome_by_cate_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            string strCate = GetCateParentIDArrayByID(cateID, groupcate);

            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            table = newsgroupBSO.GetNewsGroupByCateHomeList(strCate, groupcate, "1", Convert.ToInt32(hddRecord.Value), "1");

            AspNetCache.SetCacheWithTime("HTML_ltlNews_MainHome_by_cate_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table, 150);


        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("HTML_ltlNews_MainHome_by_cate_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }

        string strNewsCateSlider = "";
        string text1 = "";

        if (table.Rows.Count > 0)
        {
            DateTime dtNow = DateTime.Now;
            DataRow dataRow0 = table.Rows[0];
            text1 += "<div class='col-lg-3 col-md-4 col-sm-6 col-xs-12'>";
            text1 += "<div class='box-news-thumb'>";
            text1 += "<div class='thumbnail no-thumbnail thumbnail-style thumbnail-kenburn'>";
            text1 += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow0["Title"]) + "-" + dataRow0["GroupCate"] + "-" + dataRow0["NewsGroupID"].ToString() + ".aspx' title='" + dataRow0["Title"] + "'>";
            text1 += "<div class='embed-image ratio-16-9'>";
            if (dataRow0["ImageThumb"].ToString() != "")

                text1 += "<img class='img-responsive' src='" + Utils.getURLThumbImage(dataRow0["ImageThumb"].ToString(), 330) + "' alt='" + dataRow0["Title"] + "'>";
            else

                text1 += "<img class='img-responsive' src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 330) + "'  alt='" + dataRow0["Title"] + "'>";
            text1 += "</div>";
            text1 += "</a>";
            

            text1 += "<div class='caption'>";
            text1 += "<h3 class='title-news'>";
            text1 += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow0["Title"]) + "-" + dataRow0["GroupCate"] + "-" + dataRow0["NewsGroupID"].ToString() + ".aspx' title='" + dataRow0["Title"] + "'>";

            text1 += dataRow0["Title"].ToString();
            if (Convert.ToDateTime(dataRow0["PostDate"].ToString()).Date >= dtNow.Date)
                text1 += "<span class='fs12 fa fa-star text-danger pl5'></span>";
            text1 += "</a> <br/>";
            text1 += "<span style='color: #6D6D6D; font-size: 12px;'> (" + Convert.ToDateTime(dataRow0["PostDate"]).ToString("dd/MM/yyyy") + ")</span>";
            text1 += "</h3>";
            text1 += "</div>";
            text1 += "</div>";
            text1 += "</div>";
            text1 += "</div>";

            int col = 0;
            int dem = 0;
            for (int i = 1; i < table.Rows.Count; i++)
            {
                DataRow dataRow = table.Rows[i];
                
                if (dem == 0)
                {
                    col++;
                    text1 += "<div class='col-lg-3 col-md-4 col-sm-6 col-xs-12 " + ((col == 3) ? "hidden-md" : "") + "'>";
                    text1 += "<ul class='news-thumb-list'>";
                }
                text1 += "<li>";

                text1 += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";

                if (dataRow["ImageThumb"].ToString() != "")

                    text1 += "<img src='" + Utils.getURLThumbImage(dataRow["ImageThumb"].ToString(), 100) + "' alt='" + dataRow["Title"] + "' width='100px' class='image loaded'>";
                else

                    text1 += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 100) + "'  alt='" + dataRow["Title"] + "' width='100px' class='image loaded'>";

                text1 += "<div class='caption'>";
                text1 += "<span class='title'>";
                text1 += dataRow["Title"].ToString();
                text1 += "</span>";
                text1 += "<span class='sourcename'> (" + Convert.ToDateTime(dataRow["PostDate"]).ToString("dd/MM/yyyy") + ")</span>";
                text1 += "</div>";
                text1 += "</a>";
                text1 += "</li>";

                dem++;
               
                if (dem == 3)
                {
                    text1 += "</ul>";
                    text1 += "</div>";
                    dem = 0;
                }
            }

            if (dem > 0)
            {
                text1 += "</ul>";
                text1 += "</div>";
                dem = 0;
            }

            strNewsCateSlider += text1;

        }


        ltlNewsCateMainHome.Text = strNewsCateSlider;

        DataTable table1 = new DataTable();
        CateNewsBSO cateNewsBSO = new CateNewsBSO();

        if (AspNetCache.CheckCache("HTML_ltlCateSubMainHome_by_cate_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {

            table1 = cateNewsBSO.getCateClientGroup(cateID, Language.language, groupcate, 5);
            AspNetCache.SetCacheWithTime("HTML_ltlCateSubMainHome_by_cate_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table1, 150);

        }
        else
        {
            table1 = (DataTable)AspNetCache.GetCache("HTML_ltlCateSubMainHome_by_cate_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }


        string strCateSub = "";
        if (table1.Rows.Count > 0)
        {
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                DataRow dataRow = table1.Rows[i];
                strCateSub += "<li><a href='" + ResolveUrl("~/") + "c3/" + cateNewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx' title='" + dataRow["CateNewsName"] + "'>" + dataRow["CateNewsName"] + "</a></li>";

            }

        }


        ltlCateSub.Text = strCateSub;


    }

    private string GetCateParentIDArrayByID(int cID, int group)
    {
        string strArrayID = Convert.ToString(cID) + ",";

        CateNewsBSO cateNewsBSO = new CateNewsBSO();
        DataTable table1 = cateNewsBSO.GetCateParentGroupAll(cID, Language.language, group);
        DataTable table2 = new DataTable();
        if (table1.Rows.Count > 0)
        {
            foreach (DataRow subrow in table1.Rows)
            {
                strArrayID += GetCateParentIDArrayByID(Convert.ToInt32(subrow["CateNewsID"].ToString()), group);

            }

        }

        return strArrayID;

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