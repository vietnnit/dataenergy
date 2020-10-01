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
            ViewMenuTop();
            int groupcate = 0;
            if (!String.IsNullOrEmpty(hddValue.Value))
                if (int.TryParse(hddValue.Value.Replace(",", ""), out groupcate))
                {
                    ViewNewsHot(groupcate);

                }

        }
    }

    private void ViewMenuTop()
    {
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("Bannertop_" + hddValue3.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            MenuLinksBSO _menulink = new MenuLinksBSO();
            table = _menulink.GetHotMenuLinks(hddValue3.Value, 1, Language.language);
            AspNetCache.SetCacheWithTime("Bannertop_" + hddValue3.Value + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("Bannertop_" + hddValue3.Value + "_" + Language.language.Replace("-", "_"));
        }

        rptAdv.DataSource = table;
        rptAdv.DataBind();
    }

    private void ViewNewsHot(int groupcate)
    {
        //  string strCate = GetCateParentIDArrayByID(cateID, groupcate);
        DataTable tableLeft = new DataTable();
        if (AspNetCache.CheckCache("Table_Mainhome_ltlHotNewsSlider_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            //table = newsGroupBSO.GetNewsGroupHot(Convert.ToInt32(hddRecord.Value), Language.language, "1");
            tableLeft = newsGroupBSO.GetNewsGroupHot(Language.language, Convert.ToInt32(hddRecord.Value), "1", groupcate);
            AspNetCache.SetCacheWithTime("Table_Mainhome_ltlHotNewsSlider_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), tableLeft, 150);
        }
        else
        {
            tableLeft = (DataTable)AspNetCache.GetCache("Table_Mainhome_ltlHotNewsSlider_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }

        DataTable tableRight = new DataTable();
        if (AspNetCache.CheckCache("Table_Mainhome_HotNewsRight_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            //table = newsGroupBSO.GetNewsGroupHot(Convert.ToInt32(hddRecord.Value), Language.language, "1");
            //tableRight = newsGroupBSO.GetNewsNoGroupCateHot(Language.language, Convert.ToInt32(hddRecord.Value), groupcate);
            AspNetCache.SetCacheWithTime("Table_Mainhome_HotNewsRight_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), tableRight, 150);
        }
        else
        {
            tableRight = (DataTable)AspNetCache.GetCache("Table_Mainhome_HotNewsRight_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }


        // string strHotNewsSlider = "";
        //DataTable table01 = table.Clone();
        //DataTable table02 = table.Clone();

        //if (table.Rows.Count > 0)
        //{
        //    for (int j = 0; j < table.Rows.Count; j++)
        //    {
        //        DataRow dataRow = table.Rows[j];
        //        if (j < Convert.ToInt32(hddRecord.Value) - 3)
        //            table01.ImportRow(dataRow);
        //        else
        //            table02.ImportRow(dataRow);


        //    }

        rptLListNews.DataSource = tableLeft;
        rptLListNews.DataBind();

        rptHotNews.DataSource = tableRight;
        rptHotNews.DataBind();

        //}

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