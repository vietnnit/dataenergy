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
using DAO;
using BSO;
public partial class Admin_Controls_ListAdmin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            ViewRoles();
            ViewAdmin();

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

    #region ViewRoles
    public void ViewRoles()
    {
        ddlRoles.Items.Clear();
        RolesBSO rolesBSO = new RolesBSO();
        DataTable table = rolesBSO.GetAllRoles();
        DataView dataView = new DataView(table);
        dataView.RowFilter = "Roles_Name NOT IN ('adminsys32','Administrators')";
        DataTable dataTable = dataView.ToTable();

        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToDropDown(ddlRoles, dataTable, "~~ Trong tất cả các nhóm ~~", "0", "Roles_Name", "Roles_ID", "");

    }
    #endregion

    #region ViewAdmin
    protected void ViewAdmin()
    {
        AdminBSO adminBSO = new AdminBSO();
        DataTable table = adminBSO.GetAllAdminRoles();
        DataView dataView = new DataView(table);
        //dataView.RowFilter = "Admin_Username <> 'administrator' and Admin_Username <> 'Administrator'";
        dataView.RowFilter = "Admin_Username not in ('administrator','Administrator')";
        dataView.Sort = "Admin_Username ASC";
        DataTable dataTable = dataView.ToTable();
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvAdmin, dataTable);
    }
    #endregion

    protected void grvAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn chắc chắn muốn xóa ??');");

        }
    }
    protected void grvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string aId = e.CommandArgument.ToString();
        string aName = e.CommandName.ToLower();
        switch (aName)
        {
            case "user":
                Response.Redirect("~/Admins/editadminaddroles/" + aId + "/Default.aspx");
                break;
            case "_edit":
                Response.Redirect("~/Admins/editadmin/" + aId + "/Default.aspx");
                break;
            case "_delete":
                AdminBSO adminBSO = new AdminBSO();
                adminBSO.DeleteAdmin(Convert.ToInt32(aId));
                ViewAdmin();
                break;
        }
    }
    protected void grvAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btn_search_Click(object sender, EventArgs e)
    {

        int cId = Convert.ToInt32(ddlRoles.SelectedValue);

        DataTable dataTable = new DataTable();
        commonBSO commonBSO = new commonBSO();
        string SQL = "";
        SQL = "SELECT * FROM tblAdmin as a INNER JOIN tblAdminRoles as b ON a.Admin_Username = b.Admin_UserName Where a.Admin_Username not in ('administrator','Administrator')";

        if (txtKeyword.Text != "")
        {
            SQL += " and a.Admin_Username like '%' + '" + Tool.safeString(txtKeyword.Text) + "' + '%'";
        }
        if (cId != 0)
        {
            SQL += " and b.RolesID=" + cId;
        }
        SQL += " Order by a.Admin_Username ASC";
        dataTable = commonBSO.CreateDataView(SQL);
        commonBSO.FillToGridView(grvAdmin, dataTable);
    }
}
