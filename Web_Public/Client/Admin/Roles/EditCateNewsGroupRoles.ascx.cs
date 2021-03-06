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
using DAO;
using Telerik.Web.UI;
public partial class Client_Admin_EditCateNewsGroupRoles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        hddCateNewsGroupID.Value = Convert.ToString(Id);

        if (!IsPostBack)
        {
            CateNewsGroupBSO _catenewGroupBSO = new CateNewsGroupBSO();
            CateNewsGroup _catenewGroups = _catenewGroupBSO.GetCateNewsGroupById(Id);
            HddGroupCate.Value = Convert.ToString(_catenewGroups.GroupCate);
            ltlTitle.Text = _catenewGroups.CateNewsGroupName;
            initControl(Id);
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

    #region initControl
    protected void initControl(int Id)
    {
        if (Id > 0)
        {
            ViewRolesAll();
            VierPermissionID();
        }
        else
        {
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lỗi: Lựa chọn người dùng trước khi thêm quyền </div>";
        }
    }
    #endregion

    #region ViewRolesAll
    private void ViewRolesAll()
    {
        RolesBSO rolesBSO = new RolesBSO();
        DataTable table = rolesBSO.GetAllRoles();
        DataView dataView = new DataView(table);
        dataView.RowFilter = "Roles_Name not in ('adminsys32','Administrators')";
        DataTable dataTable = dataView.ToTable();

        grvRoles.DataSource = dataTable;
        grvRoles.DataBind();

    }
    #endregion


    protected void btn_add_Click(object sender, EventArgs e)
    {
        DataTable datatable = CateNewsGroupID();

        try
        {
            CateNewsGroupPermissionBSO _catenewGroupPermissionBSO = new CateNewsGroupPermissionBSO();

            DataTable table1 = _catenewGroupPermissionBSO.GetCateNewsGroupPermissionByCateID(Convert.ToInt32(hddCateNewsGroupID.Value));

            if (table1.Rows.Count > 0)
                _catenewGroupPermissionBSO.DeleteCateNewsGroupPermissionCateID(Convert.ToInt32(hddCateNewsGroupID.Value));

            CateNewsGroupPermission cateNewsPermission = new CateNewsGroupPermission();

            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow subrow in datatable.Rows)
                {
                    cateNewsPermission.CateNewsGroupID = Convert.ToInt32(hddCateNewsGroupID.Value);
                    cateNewsPermission.RolesID = Convert.ToInt32(subrow["Roles_ID"].ToString()); 
                    //cateNewsPermission.Permission = subrow["Permission"].ToString();
                    cateNewsPermission.Permission = "";
                    cateNewsPermission.UserName = Session["Admin_UserName"].ToString();
                    cateNewsPermission.Created = DateTime.Now;
                    cateNewsPermission.Language = Language.language;

                    _catenewGroupPermissionBSO.CreateCateNewsGroupPermission(cateNewsPermission);
                    error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công! </div>";

                }


            }


        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }


    #region VierPermissionID
    private void VierPermissionID()
    {
        CateNewsGroupPermissionBSO cateNewsPermissionBSO = new CateNewsGroupPermissionBSO();
        CateNewsGroupPermission cateNewsPermission = new CateNewsGroupPermission();

        foreach (GridViewRow rows in grvRoles.Rows)
        {
            CheckBox chkId = (CheckBox)rows.Cells[0].FindControl("chkId");

            if (cateNewsPermissionBSO.CheckExitPermission(Convert.ToInt32(rows.Cells[0].Text), Convert.ToInt32(hddCateNewsGroupID.Value)))
            {
                chkId.Checked = true;
            }
        }
    }
    #endregion

    #region CateNewsGroupID
    private DataTable CateNewsGroupID()
    {
        DataTable datatable = new DataTable();
        datatable.Columns.Add("Roles_ID");

        foreach (GridViewRow rows in grvRoles.Rows)
        {
            CheckBox chkId = (CheckBox)rows.Cells[0].FindControl("chkId");

            if (chkId.Checked)
            {
                DataRow datarow = datatable.NewRow();
                datarow["Roles_ID"] = rows.Cells[0].Text;
                datatable.Rows.Add(datarow);
            }
        }
        return datatable;
    }

    #endregion

    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ListCateNewsGroup/Default.aspx");
    }
}
