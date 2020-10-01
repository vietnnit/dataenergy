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
public partial class Client_BlockAdv_1Col : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewBrand();
    }
    private void ViewBrand()
    {
        MenuLinksBSO _menulink = new MenuLinksBSO();
        DataTable table = new DataTable();

        if (AspNetCache.CheckCache("BlockAdv_1Col_" + hddValue.Value + "_" + Language.language.Replace("-", "_")) == false)
        {
            table = _menulink.GetHotMenuLinks(hddValue.Value, Language.language);
            AspNetCache.SetCacheWithTime("BlockAdv_1Col_" + hddValue.Value + "_" + Language.language.Replace("-", "_"), table, 150);
        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("BlockAdv_1Col_" + hddValue.Value + "_" + Language.language.Replace("-", "_"));
        }

        rptAdv.DataSource = table;
        rptAdv.DataBind();

    }
    protected void rptAdv_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        LinkButton btnLink = (LinkButton)e.Item.FindControl("btnLink");
        btnLink.ToolTip = DataBinder.Eval(e.Item.DataItem, "MenuLinksName").ToString();
        //  btnLink.Attributes.Add("onclick", "javascript:window.open('" + DataBinder.Eval(e.Item.DataItem, "MenuLinksUrl") + "','_blank','width=1024,height=600');return false;");


        //btnLink.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/News/ViewNewsGroup.aspx?Id=" + DataBinder.Eval(e.Item.DataItem, "NewsGroupID") + "','_blank','width=800,height=600');return false;");


        string Imgthumb = DataBinder.Eval(e.Item.DataItem, "MenuLinksIcon").ToString();
        Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlICON");
        if (Imgthumb != "")
            ltlImageThumb.Text = @"<img src='" + Imgthumb + "' width='" + DataBinder.Eval(e.Item.DataItem, "Width").ToString() + "' height='" + DataBinder.Eval(e.Item.DataItem, "Height").ToString() + "' alt='" + DataBinder.Eval(e.Item.DataItem, "MenuLinksName").ToString() + "' >";

    }
    protected void rptAdv_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int mID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
        if (e.CommandName == "_link")
        {
            MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
            menuLinksBSO.MenuLinksClickUpdate(mID);

            Response.Redirect(menuLinksBSO.GetMenuLinksById(mID).MenuLinksUrl);

        }
    }

}