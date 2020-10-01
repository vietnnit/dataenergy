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
public partial class Client_NewsbyGroup_list2_4col : System.Web.UI.UserControl
{
    PagingInfo _page = new PagingInfo(20, 1, true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int groupcate = 0;
            if (!String.IsNullOrEmpty(hddValue.Value))
                if (int.TryParse(hddValue.Value.Replace(",", ""), out groupcate))
                {

                    GetNewsGroup(groupcate);

                    if (AspNetCache.CheckCache("HTML_ltlTitle_mainhome_news_by_group_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
                    {
                        CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
                        CateNewsGroup cateNewGroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(groupcate, Language.language);
                        string strTitle = "";
                        if (cateNewGroup != null)
                            strTitle = "<a href='" + ResolveUrl("~/") + "c2/" + cateNewsgroupBSO.GetSlugById(cateNewGroup.CateNewsGroupID) + "/" + GetString(cateNewGroup.CateNewsGroupName) + "-" + groupcate + ".aspx' title='" + cateNewGroup.CateNewsGroupName + "'>" + cateNewGroup.CateNewsGroupName + "</a>";
                        AspNetCache.SetCacheWithTime("HTML_ltlTitle_mainhome_news_by_group_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), strTitle, 150);
                        ltlTitle.Text = strTitle;

                    }
                    else
                    {
                        ltlTitle.Text = (string)AspNetCache.GetCache("HTML_ltlTitle_mainhome_news_by_group_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
                    }
                }
        }
    }


    void GetNewsGroup(int groupcate)
    {
        int nRecord = 0;
        if (!String.IsNullOrEmpty(hddRecord.Value))
            if (int.TryParse(hddRecord.Value, out nRecord))
                _page = new PagingInfo(nRecord, 1, true);
            else
                _page = new PagingInfo(nRecord, 1, true);


        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("Client_NewsbyGroup_Thumb" + groupcate + "_" + Language.language.Replace("-", "_")) == false)
        {
            string strCate = GetCateParentIDArrayByID(0, groupcate);

            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            table = newsgroupBSO.GetNewsGroupPaging(Language.language, groupcate, -1, strCate, 1, 1, -1, 1, 0, _page);

            AspNetCache.SetCacheWithTime("Client_NewsbyGroup_Thumb" + groupcate + "_" + Language.language.Replace("-", "_"), table, 150);


        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("Client_NewsbyGroup_Thumb" + groupcate + "_" + Language.language.Replace("-", "_"));
        }


        string strHotNewsCate = "";
        string text1 = "";

        if (table.Rows.Count > 0)
        {
            DateTime dtNow = DateTime.Now;

            for (int j = 0; j < table.Rows.Count; j++)
            {
                DataRow dataRow = table.Rows[j];

                //if (j < 4)
                //{
                strHotNewsCate += "<div class='col-md-3 col-lg-3 col-sm-6 col-xs-6 mb10'>";
                strHotNewsCate += "<div class='thumbnail no-thumbnail thumbnail-style thumbnail-kenburn height-250-fix'>";


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

        DataTable table1 = new DataTable();
        CateNewsBSO cateNewsBSO = new CateNewsBSO();

        if (AspNetCache.CheckCache("HTML_ltlCateSubMainHome_by_group_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {

            table1 = cateNewsBSO.getCateClientGroup(0, Language.language, groupcate, 5);
            AspNetCache.SetCacheWithTime("HTML_ltlCateSubMainHome_by_group_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table1, 150);

        }
        else
        {
            table1 = (DataTable)AspNetCache.GetCache("HTML_ltlCateSubMainHome_by_group_list_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
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