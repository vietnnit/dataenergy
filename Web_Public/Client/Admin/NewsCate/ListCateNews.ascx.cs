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

public partial class Admin_Controls_ListCateNews : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        int group = 0;
        if (!String.IsNullOrEmpty(Request["group"]))
            if (!int.TryParse(Request["group"].Replace(",", ""), out group))
                Response.Redirect("~/Admin/home/Default.aspx");

        if (group == 0)
            Response.Redirect("~/Admin/home/Default.aspx");
        else
        {
            hddGroup.Value = Convert.ToString(group);

            if (!IsPostBack)
            {
                ViewCateGroup(group);

            }
        }
    }

    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion

    #region ViewCateGroup
    private void ViewCateGroup(int group)
    {
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.GetCateGroupRolesWithPage(Language.language,group,Session["Admin_UserName"].ToString());
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvCateNews, table);

    }
    #endregion



    protected void grvCateNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvCateNews.PageIndex = e.NewPageIndex;
        ViewCateGroup(Convert.ToInt32(hddGroup.Value));
    }
    protected void grvCateNews_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        string nName = e.CommandName.ToLower();
        switch (nName)
        {
            case "rules":
                Response.Redirect("~/Admin/editcatenewsroles/" + Id + "/Default.aspx");
                break;

            case "_edit":
                Response.Redirect("~/Admin/editcatenews/" + hddGroup.Value + "/" + Id + "/Default.aspx");
                break;

            case "_move":
                Response.Redirect("~/Admin/editcatenewsmove/" + hddGroup.Value + "/" + Id + "/Default.aspx");
                break;

            case "_delete":
                CateNewsBSO catenewsBSO = new CateNewsBSO();
                catenewsBSO.DeleteCateNewsAll(Id, Language.language);
                ViewCateGroup(Convert.ToInt32(hddGroup.Value));
                AspNetCache.Reset();
                break;
        }
    }
    protected void grvCateNews_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gridViewRow = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

            //TextBox txttextbox = (TextBox)e.Row.FindControl("txtCateNewsOrder");

            //int parentId = Convert.ToInt32(e.Row.Cells[1].Text);
            //if (parentId != 0)
            //    txttextbox.Visible = false;
        
        }
                   
    }
    protected void btn_Order_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvCateNews.Rows)
        {
            TextBox textOrder = (TextBox)row.FindControl("txtCateNewsOrder");
            int cOrder = Convert.ToInt32(textOrder.Text);
            int cateID = Convert.ToInt32(row.Cells[0].Text);
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            catenewsBSO.CateNewsUpOrder(cateID, cOrder);
        }
        ViewCateGroup(Convert.ToInt32(hddGroup.Value));
        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
        AspNetCache.Reset();
    }

    protected void btn_create_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Group/editcatenews/" + hddGroup.Value + "/Default.aspx");

    }

}
