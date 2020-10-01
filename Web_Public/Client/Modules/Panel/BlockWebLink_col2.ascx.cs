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
public partial class Client_BlockWebLink_col2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewWeblink();
        }
    }
    private void ViewWeblink()
    {
        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("HTML_WebLink_col2_" + hddValue.Value) == false)
        {
            MenuLinksBSO menulinksBSO = new MenuLinksBSO();
            table = menulinksBSO.GetHotMenuLinks(hddValue.Value, Convert.ToInt32(hddRecord.Value) , Language.language);

            AspNetCache.SetCache("HTML_WebLink_col2_" + hddValue.Value, table);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("HTML_WebLink_col2_" + hddValue.Value);
        }
        rptWebLink.DataSource = table;
        rptWebLink.DataBind();
    }
}
