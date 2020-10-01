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
public partial class Client_Modules_Link_Adv_slider : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewWeblink();
    }
    private void ViewWeblink()
    {
        DataTable table = new DataTable();
        if (AspNetCache.CheckCache("HTML_ltlAdvPartner_Main_"+hddValue.Value) == false)
        {
            MenuLinksBSO menulinksBSO = new MenuLinksBSO();
            table = menulinksBSO.GetHotMenuLinks(hddValue.Value, Language.language);

            AspNetCache.SetCacheWithTime("HTML_ltlAdvPartner_Main_" + hddValue.Value, table, 150);

        }
        else
        {
            table = (DataTable)AspNetCache.GetCache("HTML_ltlAdvPartner_Main_" + hddValue.Value);
        }
        rptWebLink.DataSource = table;
        rptWebLink.DataBind();
    }

    protected void rptWebLink_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        LinkButton btnLink = (LinkButton)e.Item.FindControl("btnLink");
        btnLink.ToolTip = DataBinder.Eval(e.Item.DataItem, "MenuLinksName").ToString();
        //  btnLink.Attributes.Add("onclick", "javascript:window.open('" + DataBinder.Eval(e.Item.DataItem, "MenuLinksUrl") + "','_blank','width=1024,height=600');return false;");


        //btnLink.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/News/ViewNewsGroup.aspx?Id=" + DataBinder.Eval(e.Item.DataItem, "NewsGroupID") + "','_blank','width=800,height=600');return false;");


        string Imgthumb = DataBinder.Eval(e.Item.DataItem, "MenuLinksIcon").ToString();
        Literal ltlImageThumb = (Literal)e.Item.FindControl("ltlICON");
        if (Imgthumb != "")
            ltlImageThumb.Text = @"<img src='" + Imgthumb + "' alt='" + DataBinder.Eval(e.Item.DataItem, "MenuLinksName").ToString() + "' >";


    }
    protected void rptWebLink_ItemCommand(object source, RepeaterCommandEventArgs e)
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