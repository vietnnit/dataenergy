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
public partial class Admin_Controls_ListRoles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
            ViewRoles();
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
    protected void ViewRoles()
    {
        RolesBSO rolesBSO = new RolesBSO();
        DataTable table = rolesBSO.GetAllRoles();
        DataView dataView = new DataView(table);
        dataView.RowFilter = "Roles_Name not in ('adminsys32','Administrators')";
        DataTable dataTable = dataView.ToTable();
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvRoles, dataTable);
        
    }
    #endregion
    protected void grvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rId = Convert.ToInt32(e.CommandArgument.ToString());
        string rName = e.CommandName.ToLower().Trim();
        switch (rName)
        {
            case "department":
                Response.Redirect("~/Admin/Editns_departmentpermission/" + rId + "/Default.aspx");
                break;
            case "user":
                Response.Redirect("~/Admin/EditRolesAddUser/" + rId + "/Default.aspx");
                break;
            case "rules":
                Response.Redirect("~/Admin/EditCateNewsPermission/" + rId + "/Default.aspx");
                break;
            case "rules0":
                Response.Redirect("~/Admin/EditCateNewsGroupPermission/" + rId + "/Default.aspx");
                break;
            case "module":
                Response.Redirect("~/Admin/EditRolesModule/" + rId + "/Default.aspx");
                break;
            case "_edit":
                Response.Redirect("~/Admin/EditRoles/" + rId + "/Default.aspx");
                break;
            case "_delete":
                RolesBSO rolesBSO = new RolesBSO();
                rolesBSO.DeleteRoles(rId);
                ViewRoles();
                break;

        }
    }
    protected void grvRoles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_Delete");
            image_del.Attributes.Add("onclick", "return confirm('Bạn có muốn chắc chắn xóa không ??')");
        }
    }
}
