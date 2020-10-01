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

using ETO;
using BSO;
public partial class Client_HotNewbyGroupScroll : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int groupcate = 0;
            if (!String.IsNullOrEmpty(hddValue.Value))
                if (int.TryParse(hddValue.Value.Replace(",", ""), out groupcate))
                {
                    ViewNewsHot(groupcate);

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


    private void ViewNewsHot(int groupcate)
    {
      //  string strCate = GetCateParentIDArrayByID(cateID, groupcate);
        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("Table_Mainhome_ltlHotNewsSlider_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            string strCate = GetCateParentIDArrayByID(0, groupcate);

            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            table = newsgroupBSO.GetNewsGroupByCateHomeList(strCate, groupcate, "1", Convert.ToInt32(hddRecord.Value), "1");

            //NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            ////table = newsGroupBSO.GetNewsGroupHot(Convert.ToInt32(hddRecord.Value), Language.language, "1");
            //table = newsGroupBSO.GetNewsGroupHot(Language.language, Convert.ToInt32(hddRecord.Value), "1", groupcate);
            AspNetCache.SetCacheWithTime("Table_Mainhome_ltlHotNewsSlider_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("Table_Mainhome_ltlHotNewsSlider_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }


       // string strHotNewsSlider = "";


        if (table.Rows.Count > 0)
        {
            rptLListNews.DataSource = table;
            rptLListNews.DataBind();
            
        }

        //ltlHotNewsSlider.Text = strHotNewsSlider;
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