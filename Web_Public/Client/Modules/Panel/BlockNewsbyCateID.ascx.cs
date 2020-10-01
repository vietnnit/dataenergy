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
public partial class Client_BlockNewsbyCateID : System.Web.UI.UserControl
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
                    int groupcate = cateNews.GroupCate;
                    GetNewsGroup(cateID, groupcate);

                    if (cateID != 0 && cateNews != null)
                    {
                        //lblIcon.Text = "<a href='" + ResolveUrl("~/") + "ts-dm/" + GetString(cateNews.CateNewsName) + "-" + groupcate + "-" + cateID + ".aspx' title='" + cateNews.CateNewsName + "'>" + "<img class='is_img onLaw2-icon1 onLaw1-Submit-Arrow' src='" + ResolveUrl("~/") + "images/invis.gif' style='border-width: 0px;'>" + "</a>";
                        lblTitle.Text = "<a href='" + ResolveUrl("~/") + "c3/" + cateNewsBSO.GetSlugByCateId(cateNews.CateNewsID) + "/" + GetString(cateNews.CateNewsName) + "-" + groupcate + "-" + cateID + ".aspx' title='" + cateNews.CateNewsName + "'>" + cateNews.CateNewsName + "</a>";
                    }
                }
        }

    }


    void GetNewsGroup(int cateID, int groupcate)
    {
        string strCate = GetCateParentIDArrayByID(cateID, groupcate);

        if (AspNetCache.CheckCache("HTML_ltlBlockNewsbyCateID_" + hddValue.Value) == false)
        {
            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            DataTable table = newsgroupBSO.GetNewsGroupByCateHot(strCate, groupcate, "1", Convert.ToInt32(hddRecord.Value),"1", "1");

            
            string text1 = "";

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow dataRow = table.Rows[i];
                    text1 += "<div class='news-list'>";
                    text1 += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";
                    text1 += "<span>";
                    
                    if (dataRow["ImageThumb"].ToString() != "")
                        text1 += "<img class='is_img' src='" + Utils.getURLThumbImage(dataRow["ImageThumb"].ToString(),65) + "' style='border-width: 0px;' alt='" + dataRow["Title"] + "'>";
                    else
                        text1 += "<img class='is_img' src='" + ResolveUrl("~/") + "images/img_logo.jpg' style='border-width: 0px;' alt='" + dataRow["Title"] + "'>";
                    text1 += dataRow["Title"];
                    text1 += "</span>" + "</a>";
                    text1 += "<div class='clear'></div>" + "</div>";
                }

            }


            AspNetCache.SetCacheWithTime("HTML_ltlBlockNewsbyCateID_" + hddValue.Value, text1, 150);
            ltlHotNewsSlider.Text = text1;

        }
        else
        {
            ltlHotNewsSlider.Text = (string)AspNetCache.GetCache("HTML_ltlBlockNewsbyCateID_" + hddValue.Value);
        }



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