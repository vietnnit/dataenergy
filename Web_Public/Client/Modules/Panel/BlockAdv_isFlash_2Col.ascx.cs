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
public partial class Client_BlockAdv_isFlash_2Col : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewBrand();
    }
    private void ViewBrand()
    {

        if (AspNetCache.CheckCache("BlockAdv_isFlash_2Col_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            MenuLinksBSO _menulink = new MenuLinksBSO();
            DataTable table = _menulink.GetHotMenuLinks(hddValue.Value, Language.language);

            string strAdv = "";

            if (table.Rows.Count > 0)
            {
                for(int i=0; i<table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    strAdv += "<div style='margin-bottom:10px;'>";

                    if (Convert.ToBoolean(row["isFlash"].ToString()))
                    {
                        //is Flash
                        strAdv += "<object width='"+row["width"]+"' height='"+row["height"]+"'>";
                        strAdv += "<param name='Movie' value='" + row["FileName"] + "'>";
                        strAdv += "<param name='play' value='true'>";
                        strAdv += "<param name='quality' value='high'>";
                        strAdv += "<param name='wmode' value='transparent'>";
                        strAdv += "<param name='loop' value='true'>";
                        strAdv += "<param name='menu' value='false'><embed src='" + row["FileName"] + "' width='"+row["width"]+"' height='"+row["height"]+"' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer' quality='high' wmode='transparent' loop='true' menu='false'></object>";
                    }
                    else
                    {
                        strAdv += "<a href='" + row["MenuLinksUrl"] + "' target='" + row["Target"] + " title='" + row["MenuLinksName"] + "'>";
                        strAdv += "<img src='" + row["MenuLinksIcon"] + " width='" + row["Width"] + " height='" + row["Height"] + "' alt='" + row["MenuLinksName"] + "' />";
                        strAdv += "</a>";
                    }
    
                    strAdv += "<div class='clear'>";
                    strAdv += "</div>";
                    strAdv += "</div>";
                }
            }

            AspNetCache.SetCacheWithTime("BlockAdv_isFlash_2Col_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), strAdv, 150);
            ltlAdv.Text = strAdv;
        }
        else
        {
            ltlAdv.Text = (string)AspNetCache.GetCache("BlockAdv_isFlash_2Col_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }

    }

  
}
