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

public partial class Client_Admin_ListCateNewsGroup : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            ViewCateGroup();
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
    private void ViewCateGroup()
    {
        CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
        DataTable table = catenewsGroupBSO.GetCateNewsGroupAll(Language.language, Session["Admin_UserName"].ToString());
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvCateNewsGroup, table);

    }
    #endregion


    protected void grvCateNewsGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvCateNewsGroup.PageIndex = e.NewPageIndex;
        ViewCateGroup();
    }
    protected void grvCateNewsGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
        CateNewsGroup _catenewgroup = catenewsGroupBSO.GetCateNewsGroupById(Id);
        string nName = e.CommandName.ToLower();
        switch (nName)
        {
            case "rules":
                Response.Redirect("~/Admin/editcatenewsgrouproles/" + Id + "/Default.aspx");
                break;

            case "_edit":
                Response.Redirect("~/Admin/editcatenewsgroup/" + Id + "/Default.aspx");
                break;
            case "_listcate":
                Response.Redirect("~/Admin/Group/listcatenews/" + _catenewgroup.GroupCate + "/Default.aspx");
                break;
            case "_delete":
   
                catenewsGroupBSO.DeleteCateNewsGroup(Id);
                ViewCateGroup();
                AspNetCache.Reset();
                break;
        }
    }
    protected void grvCateNewsGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gridViewRow = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

 

        }

    }
    protected void btn_Order_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvCateNewsGroup.Rows)
        {
            TextBox textOrder = (TextBox)row.FindControl("txtOrder");
            TextBox textMenu = (TextBox)row.FindControl("txtMenu");
            int cOrder = Convert.ToInt32(textOrder.Text);
            int _menu = Convert.ToInt32(textMenu.Text);
            int cateID = Convert.ToInt32(row.Cells[0].Text);
            CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
            catenewsGroupBSO.CateNewsGroupUpOrder(cateID, cOrder);
            catenewsGroupBSO.CateNewsGroupUpMenu(cateID, _menu);
        }
        ViewCateGroup();
        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
       AspNetCache.Reset();
    }

}
