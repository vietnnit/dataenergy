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
public partial class Client_BlockNewsbyStrID : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           
            GetNewsGroup();

            
            //lblIcon.Text = "<a href='#' title='Tin nổi bật'>" + "<img class='is_img onLaw2-icon1 onLaw1-Submit-Arrow' src='" + ResolveUrl("~/") + "images/invis.gif' style='border-width: 0px;'>" + "</a>";
            //lblTitle.Text = "Tin nổi bật";
            
        }

    }


    private void GetNewsGroup()
    {

        string value = "";
        if (hddValue.Value.Length > 25)
            value = hddValue.Value.ToString().Replace(",", "_").Substring(0, 25);
        else
            value = hddValue.Value.ToString().Replace(",", "_");

        if (AspNetCache.CheckCache("HTML_ltlBlockNewsbystrID_" + hddValue.Value) == false)
        {
            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            DataTable table = newsgroupBSO.GetNewsGroupByListNewsID(Language.language, hddValue.Value, "1", "1");

            string strNewsCateSlider = "";
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
            ltlHotNewsSlider.Text = strNewsCateSlider;

        }
        else
        {
            ltlHotNewsSlider.Text = (string)AspNetCache.GetCache("HTML_ltlBlockNewsbyCateID" + hddValue.Value);
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