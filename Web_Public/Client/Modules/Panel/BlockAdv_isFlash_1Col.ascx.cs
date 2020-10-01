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
public partial class Client_BlockAdv_isFlash_1Col : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewBrand();
    }
    private void ViewBrand()
    {
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("BlockAdv_isFlash_1Col_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            MenuLinksBSO _menulink = new MenuLinksBSO();
            table = _menulink.GetHotMenuLinks(hddValue.Value, Language.language);

            AspNetCache.SetCacheWithTime("BlockAdv_isFlash_1Col_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("BlockAdv_isFlash_1Col_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }

        string strAdv = "";

        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];

                strAdv += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-bottom-10px'>";

                if (Convert.ToBoolean(row["isFlash"].ToString()))
                {
                    //is Flash
                    strAdv += "<object width='" + row["width"] + "' height='" + row["height"] + "'>";
                    strAdv += "<param name='Movie' value='" + row["FileName"] + "'>";
                    strAdv += "<param name='play' value='true'>";
                    strAdv += "<param name='quality' value='high'>";
                    strAdv += "<param name='wmode' value='transparent'>";
                    strAdv += "<param name='loop' value='true'>";
                    strAdv += "<param name='menu' value='false'><embed src='" + row["FileName"] + "' width='" + row["width"] + "' height='" + row["height"] + "' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer' quality='high' wmode='transparent' loop='true' menu='false'></object>";
                }
                else
                {
                    strAdv += "<a href='" + row["MenuLinksUrl"] + "' target='" + row["Target"] + " title='" + row["MenuLinksName"] + "'>";
                    strAdv += "<img src='" + row["MenuLinksIcon"] + "' alt='" + row["MenuLinksName"] + "' />";
                    strAdv += "</a> <br/>";
                    strAdv += "<a href='" + row["MenuLinksUrl"] + "' target='" + row["Target"] + " title='" + row["MenuLinksName"] + "' class='mt10 ml10 btn btn-sm rounded btn-info'>";
                    strAdv += "Xem chi tiết <i class='fa  fa-long-arrow-right'></i>";
                    strAdv += "</a>";
                }

                strAdv += "</div>";
            }
        }

        ltlAdv.Text = strAdv;

    }


}