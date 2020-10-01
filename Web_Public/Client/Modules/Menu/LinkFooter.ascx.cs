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
public partial class Client_LinkFooter : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewMenuTop();
        }
       
    }

    private void ViewMenuTop()
    {
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("MenuFooter_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            MenuLinksBSO _menulink = new MenuLinksBSO();
            table = _menulink.GetHotMenuLinks(hddValue.Value, Language.language);
            AspNetCache.SetCacheWithTime("MenuFooter_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("MenuFooter_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }

        rptAdv.DataSource = table;
        rptAdv.DataBind();
    }


}
