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
public partial class Client_HotNewSlider : System.Web.UI.UserControl
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
                }

            //int groupcate2 = 0;
            //if (!String.IsNullOrEmpty(hddValue2.Value))
            //    if (int.TryParse(hddValue2.Value.Replace(",", ""), out groupcate2))
            //    {
            //        ViewNews(groupcate2);
            //    }
        }
    }


    private void ViewNewsHot(int groupcate)
    {
      //  string strCate = GetCateParentIDArrayByID(cateID, groupcate);
        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("Table_Mainhome_ltlHotNewsSlider_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            table = newsGroupBSO.GetNewsGroupHot(Language.language, Convert.ToInt32(hddRecord.Value), "1", groupcate);
            AspNetCache.SetCacheWithTime("Table_Mainhome_ltlHotNewsSlider_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("Table_Mainhome_ltlHotNewsSlider_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }


       // string strHotNewsSlider = "";
        DataTable table01 = table.Clone();
        DataTable table02 = table.Clone();

        if (table.Rows.Count > 0)
        {
            for (int j = 0; j < table.Rows.Count; j++)
            {
                DataRow dataRow = table.Rows[j];
                if (j < Convert.ToInt32(hddRecord.Value)-3)
                    table01.ImportRow(dataRow);
                else
                    table02.ImportRow(dataRow);


            }

            rptLListNews.DataSource = table02;
            rptLListNews.DataBind();

            rptHotNews.DataSource = table01;
            rptHotNews.DataBind();

            //rptHotNewsPage.DataSource = table01;
            //rptHotNewsPage.DataBind();

            //for (int j = 0; j < table.Rows.Count; j++)
            //{
            //    DataRow dataRow = table.Rows[j];

            //    strHotNewsSlider += "<li>";
               

            //    strHotNewsSlider += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";
                
            //    if (dataRow["ImageThumb"].ToString() != "")
            //        strHotNewsSlider += "<img src='" + Utils.getURLThumbImage(dataRow["ImageThumb"].ToString(), 220) + "'  alt='" + dataRow["Title"] + "'>";
            //    else
            //        strHotNewsSlider += "<img src='" + Utils.getURLThumbImage(ResolveUrl("~/") + "images/img_logo.jpg", 220) + "' alt='" + dataRow["Title"] + "'>";

            //    //strHotNewsSlider += dataRow["Title"].ToString();

            //    strHotNewsSlider += "</a>";

            //    //strHotNewsSlider += "<div class='clear'>";
            //    //strHotNewsSlider += "</div>";
            //    //strHotNewsSlider += "<div class='margin-9t'>";
            //    //strHotNewsSlider += "</div>";

            //    //strHotNewsSlider += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";
                
            //    //strHotNewsSlider += "</a>";
               
            //    strHotNewsSlider += "</li>";
            //}
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