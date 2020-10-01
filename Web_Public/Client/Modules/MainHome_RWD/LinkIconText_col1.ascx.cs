using System;
using System.Text;
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
public partial class Client_LinkIconText_col1 : System.Web.UI.UserControl
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
        if (AspNetCache.CheckCache("tbl_Link_notext_hover_col2_" + hddValue.Value) == false)
        {
            MenuLinksBSO menulinksBSO = new MenuLinksBSO();
            table = menulinksBSO.GetHotMenuLinks(hddValue.Value, Convert.ToInt32(hddRecord.Value), Language.language);
            AspNetCache.SetCache("tbl_Link_notext_hover_col2_" + hddValue.Value, table);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("tbl_Link_notext_hover_col2_" + hddValue.Value);
        }
        rptWeblink.DataSource = table;
        rptWeblink.DataBind();
    }
    protected void rptWeblink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal ltMenu = (Literal)e.Item.FindControl("ltMenu");
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DataTable table = new MenuLinksBSO().GetMenuByParent(Convert.ToInt32(dr["MenuLinksID"]));
            StringBuilder sb = new StringBuilder();
            if (table != null && table.Rows.Count > 0)
            {
                sb.Append("<li class=\"list-group-item list-toggle active\"><a aria-expanded=\"true\" data-toggle=\"collapse\" data-parent=\"#sidebar-nav" + dr["MenuLinksID"].ToString() + "\"");
                sb.Append("href=\"#collapse-typography" + dr["MenuLinksID"] + "\">" + dr["MenuLinksName"] + "</a>");

                sb.Append("<ul id=\"collapse-typography" + dr["MenuLinksID"] + "\" class=\"collapse in\" aria-expanded=\"true\">");
                foreach (DataRow drSub in table.Rows)
                {
                    sb.Append("<li><a href='" + drSub["MenuLinksUrl"] + "'>" + drSub["MenuLinksName"] + "</a></li>");
                }
                sb.Append("</ul>");
                sb.Append("</li>");
            }
            else
            {
                sb.Append("<li class='list-group-item'><a href='" + dr["MenuLinksUrl"] + "'>" + dr["MenuLinksName"] + "</a></li>");
            }
            ltMenu.Text = sb.ToString();
        }
    }
}
