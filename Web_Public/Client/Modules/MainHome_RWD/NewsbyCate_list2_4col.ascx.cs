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
public partial class Client_NewsbyCate_list2_4col : System.Web.UI.UserControl
{
    PagingInfo _page = new PagingInfo(20, 1, true);
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
        int nRecord = 0;
        if (!String.IsNullOrEmpty(hddRecord.Value))
            if (int.TryParse(hddRecord.Value, out nRecord))
                _page = new PagingInfo(nRecord, 1, true);
            else
                _page = new PagingInfo(nRecord, 1, true);


        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("Client_NewsbyCate_list2_2col" + groupcate + "_" + cateID + "_" + Language.language.Replace("-", "_")) == false)
        {
            string strCate = GetCateParentIDArrayByID(cateID, groupcate);

            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            table = newsgroupBSO.GetNewsGroupPaging(Language.language, groupcate, -1, strCate, 1, 1, -1, 1, 0, _page);

            AspNetCache.SetCacheWithTime("Client_NewsbyCate_list2_2col" + groupcate + "_" + cateID + "_" + Language.language.Replace("-", "_"), table, 150);


        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("Client_NewsbyCate_list2_2col" + groupcate + "_" + cateID + "_" + Language.language.Replace("-", "_"));
        }



        string strHotNewsCate = "";

        if (table.Rows.Count > 0)
        {
            DateTime dtNow = DateTime.Now;

            for (int j = 0; j < table.Rows.Count; j++)
            {
                DataRow dataRow = table.Rows[j];

                //if (j < 4)
                //{
                    strHotNewsCate += "<div class='col-md-3 col-lg-3 col-sm-6 col-xs-6  prn pln'>";
                    strHotNewsCate += "<div class='thumbnail no-thumbnail thumbnail-style thumbnail-kenburn'>";


                    strHotNewsCate += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";
                    strHotNewsCate += "<div class='embed-image ratio-16-9'>";
                    if (dataRow["ImageThumb"].ToString() != "")

                        strHotNewsCate += "<img class='img-responsive' src='" + Utils.getURLThumbImage(dataRow["ImageThumb"].ToString(), 330) + "' alt='" + dataRow["Title"] + "'>";
                    else

                        strHotNewsCate += "<img class='img-responsive' src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 330) + "'  alt='" + dataRow["Title"] + "'>";
                    strHotNewsCate += "</div>";
                    strHotNewsCate += "</a>";

                    strHotNewsCate += "<div class='caption'>";
                    strHotNewsCate += "<h3 class='title-news13'>";
                    strHotNewsCate += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";

                    strHotNewsCate += dataRow["Title"].ToString();
                    strHotNewsCate += "</a>";


                    //strHotNewsCate += "<span style='color: #6D6D6D; font-size: 12px;'> (" + Convert.ToDateTime(dataRow["PostDate"]).ToString("dd/MM/yyyy") + ")</span>";
                    strHotNewsCate += "</h3>";
                    //strHotNewsCate += "<ul class='list-unstyled list-inline title-date'>";
                    //strHotNewsCate += "<li><i class='fa fa-calendar'></i> " + Convert.ToDateTime(dataRow["PostDate"]).ToString("dd/MM/yyyy") + "</li>";
                    //strHotNewsCate += "</ul>";
                    strHotNewsCate += "</div>";

                    strHotNewsCate += "</div>";


                    strHotNewsCate += "</div>";
                //}
                //else
                //{
                //    strHotNewsCate += "<div class='linkother'>";
                //    strHotNewsCate += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";
                //    strHotNewsCate += dataRow["Title"].ToString();
                //    //strHotNewsCate += " <span style='color:#6D6D6D; font-size: 12px;font-style:italic;'>(" + Convert.ToDateTime(dataRow["PostDate"]).ToString("dd/MM/yyyy") + ")</span>";
                //    strHotNewsCate += "</a>";

                //    strHotNewsCate += "</div>";
                //}

            }
            //strHotNewsCate += "</ul></div>";
            //strHotNewsCate += "</div>";


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