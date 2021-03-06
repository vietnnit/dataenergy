using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using BSO;

public partial class Admin_Controls_ListMenuLinks : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!Page.IsPostBack)
        {
            ViewMenuLinks();
            BindDropDownList();
        }

    }
    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        //imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
        litModules.Text = modules.ModulesName;
    }
    #endregion

    #region BindDropDownList
    protected void BindDropDownList()
    {
        MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
        //  DataTable table = menuLinksBSO.GetAllMenuLinks();
        DataTable table = menuLinksBSO.getCateClient(0,Language.language);
        commonBSO commonBSO = new commonBSO();
        ddlMenuLinks.Items.Clear();
        commonBSO.FillToDropDown(ddlMenuLinks, table, "~ Cấp độ menuLinks ~", "0", "MenuLinksName", "MenuLinksID", "");
    }
    #endregion


    public void ViewMenuLinks()
    {
        MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
        DataTable table = menuLinksBSO.MixMenuLinks(Language.language);
        grvMenuLink.DataSource = table;
        grvMenuLink.DataBind();

    }

    public void ViewMenuLinks(int _menulinkID)
    {
        MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
        DataTable table = menuLinksBSO.getCateClient(_menulinkID, Language.language);
        grvMenuLink.DataSource = table;
        grvMenuLink.DataBind();

    }

    protected void grvMenuLink_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int mID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
        string cName = e.CommandName.ToLower().Trim();
        switch (cName)
        {
            case "_edit":
                Response.Redirect("~/Admin/editmenulinks/" + mID +"/Default.aspx");
                break;
            case "_delete":
                MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
                menuLinksBSO.DeleteMenuLinks(mID);
                ViewMenuLinks();
                AspNetCache.Reset();
                break;
        }
    }


    protected void grvMenuLink_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
        }
    }

    protected void grvMenuLink_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


    protected void btn_Order_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvMenuLink.Rows)
        {
            TextBox textOrder = (TextBox)row.FindControl("txtMenuLinksOrder");
            int cOrder = Convert.ToInt32(textOrder.Text);
            int cateID = Convert.ToInt32(row.Cells[0].Text);
            MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
            menuLinksBSO.MenuLinksUpOrder(cateID, cOrder);
        }
        ViewMenuLinks();
        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
        AspNetCache.Reset();
    }


    protected void grvMenuLink_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvMenuLink.PageIndex = e.NewPageIndex;
        ViewMenuLinks();
    }

    //protected void btn_search_Click(object sender, EventArgs e)
    //{
    //    MenuLinksBSO menuLinksBSO = new MenuLinksBSO();
    //    DataTable table = menuLinksBSO.MixMenuLinks(Language.language);
    //    DataView view = new DataView(table);
    //    if (txtKeyword.Text != "")
    //    {
    //        view.RowFilter = "Position = '" + txtKeyword.Text + "'";
    //    }

        
    //    grvMenuLink.DataSource = view;
    //    grvMenuLink.DataBind();

  

    //}
    protected void ddlMenuLinks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMenuLinks.SelectedValue != "0")
            ViewMenuLinks(Convert.ToInt32(ddlMenuLinks.SelectedValue));
        else
            ViewMenuLinks();
    }
}
