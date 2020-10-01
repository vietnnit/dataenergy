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
public partial class Client_NewsbyCate_list1_3 : System.Web.UI.UserControl
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

                        string strTitle = "<a href='" + ResolveUrl("~/") + "c3/" + cateNewsBSO.GetSlugByCateId(cateNews.CateNewsID) + "/" + GetString(cateNews.CateNewsName) + "-" + groupcate + "-" + cateID + ".aspx' title='" + cateNews.CateNewsName + "'>" + cateNews.ShortName + "</a>";
                        lblTitle.Text = strTitle;
                    }
                }
        }

    }


    void GetNewsGroup(int cateID, int groupcate)
    {
        string strCate = GetCateParentIDArrayByID(cateID, groupcate);
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("HTML_ltlNews_MainHome_by_cate_list1_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            table = newsgroupBSO.GetNewsGroupByCateHomeList(strCate, groupcate, "1", Convert.ToInt32(hddRecord.Value), "1");
            AspNetCache.SetCacheWithTime("HTML_ltlNews_MainHome_by_cate_list1_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("HTML_ltlNews_MainHome_by_cate_list1_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }


        string strHotNewsCate = "";

        if (table.Rows.Count > 0)
        {
            DateTime dtNow = DateTime.Now;

            DataRow dataRow0 = table.Rows[0];
            strHotNewsCate += "<div class='thumbnail no-thumbnail thumbnail-style thumbnail-kenburn'>";

            
            strHotNewsCate += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow0["Title"]) + "-" + dataRow0["GroupCate"] + "-" + dataRow0["NewsGroupID"].ToString() + ".aspx' title='" + dataRow0["Title"] + "'>";
            strHotNewsCate += "<div class='embed-image ratio-16-9'>";
            if (dataRow0["ImageThumb"].ToString() != "")

                strHotNewsCate += "<img class='img-responsive' src='" + Utils.getURLThumbImage(dataRow0["ImageThumb"].ToString(), 330) + "' alt='" + dataRow0["Title"] + "'>";
            else

                strHotNewsCate += "<img class='img-responsive' src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 330) + "'  alt='" + dataRow0["Title"] + "'>";
            strHotNewsCate += "</div>";
            strHotNewsCate += "</a>";
                       
            strHotNewsCate += "<div class='caption'>";
            strHotNewsCate += "<h3 class='title-news'>";
            strHotNewsCate += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow0["Title"]) + "-" + dataRow0["GroupCate"] + "-" + dataRow0["NewsGroupID"].ToString() + ".aspx' title='" + dataRow0["Title"] + "'>";

            strHotNewsCate += dataRow0["Title"].ToString();
            strHotNewsCate += "</a>";
            strHotNewsCate += "<span style='color: #6D6D6D; font-size: 12px;'> (" + Convert.ToDateTime(dataRow0["PostDate"]).ToString("dd/MM/yyyy") + ")</span>";
            strHotNewsCate += "</h3>";
            strHotNewsCate += "</div>";

            strHotNewsCate += "</div>";

            strHotNewsCate += "<div class='boxnew-linkother'>";
            strHotNewsCate += "<ul>";

            for (int j = 1; j < table.Rows.Count; j++)
            {
                DataRow dataRow = table.Rows[j];

                strHotNewsCate += "<li class='ter'>";
                strHotNewsCate += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";
                strHotNewsCate += dataRow["Title"].ToString();
                strHotNewsCate += " <span style='color:#6D6D6D; font-size: 12px;font-style:italic;'>(" + Convert.ToDateTime(dataRow["PostDate"]).ToString("dd/MM/yyyy") + ")</span>";
                strHotNewsCate += "</a>";

                strHotNewsCate += "</li>";
            }
            strHotNewsCate += "</ul></div>";
           


        }
        ltlNewsCateMainHome.Text = strHotNewsCate;

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