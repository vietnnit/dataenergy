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

public partial class Client_Admin_EditAdminAddRoles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Id = "";
        if (!string.IsNullOrEmpty(Request["Id"]))
           Id = Request["Id"].Replace(",", "");
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        hddUserName.Value = Id;
        AdminBSO adminBSO = new AdminBSO();

        if (!IsPostBack)
        {
           
            ltlTitle.Text = adminBSO.GetAdminById(Convert.ToInt32(Id)).AdminName;
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
    protected void initControl(string Id)
    {
        if (Id != "")
        {
            ViewRolesAll();
            VierUserRoles();
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
        DataTable datatable = GetUserGrid();

        try
        {
            AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
            DataTable table1 = adminRolesBSO.GetAdminRolesByUserName(hddUserName.Value);

            if (table1.Rows.Count > 0)
                adminRolesBSO.DeleteAdminRolesUserName(hddUserName.Value);

            AdminRoles adminRoles = new AdminRoles();

            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow subrow in datatable.Rows)
                {
                    adminRoles.RolesID = Convert.ToInt32(subrow["Roles_ID"].ToString());
                    adminRoles.AdminUserName = hddUserName.Value;
                    adminRoles.UserName = Session["Admin_UserName"].ToString();
                    //adminRoles.Permission = subrow["Permission"].ToString();
                    adminRoles.Permission = "";
                    adminRoles.Created = DateTime.Now;

                    adminRolesBSO.CreateAdminRoles(adminRoles);
                    error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";

                }


            }


        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }


    #region VierUserRoles
    private void VierUserRoles()
    {
        //PermissionBSO permissionBSO = new PermissionBSO();
        //DataTable table = permissionBSO.GetPermissionAll();
        //DataView dataView = new DataView(table);
        //dataView.Sort = "PermissionID ASC";
        //DataTable dataTable = dataView.ToTable();
        //commonBSO commonBSO = new commonBSO();

        AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
        AdminRoles adminRoles = new AdminRoles();


        foreach (GridViewRow rows in grvRoles.Rows)
        {
            //CheckBoxList chklist = (CheckBoxList)dataItem.FindControl("chklist");
            CheckBox chkId = (CheckBox)rows.Cells[0].FindControl("chkId");

            //commonBSO.FillToCheckBoxList(chklist, dataTable, "PermissionName", "Value");

            if (adminRolesBSO.CheckExitRolesUser(Convert.ToInt32(rows.Cells[0].Text), hddUserName.Value))
            {

                //Permission
                //adminRoles = adminRolesBSO.GetAdminRoles(Convert.ToInt32(dataItem["Roles_ID"].Text), hddUserName.Value);

                //if (adminRoles != null)
                //{
                //    string sPermission = adminRoles.Permission;
                //    if (!sPermission.Equals(""))
                //    {
                //        string[] sSlip = sPermission.Split(new char[] { ',' });
                //        foreach (string s in sSlip)
                //        {
                //            foreach (ListItem items in chklist.Items)
                //            {
                //                if (items.Value == s)
                //                    items.Selected = true;
                //            }
                //        }
                //    }
                //}

                //Admin_ID
                chkId.Checked = true;
            }

        }


    }
    #endregion

    #region GetUserGrid
    private DataTable GetUserGrid()
    {
        DataTable datatable = new DataTable();
        datatable.Columns.Add("Roles_ID");
        //datatable.Columns.Add("Permission");

        foreach (GridViewRow rows in grvRoles.Rows)
        {
            CheckBox chkId = (CheckBox)rows.Cells[0].FindControl("chkId");
            //CheckBoxList chklist = (CheckBoxList)dataItem.FindControl("chklist");

            //string strID = "";
            //foreach (ListItem items in chklist.Items)
            //{
            //    if (items.Selected)
            //        strID += items.Value + ",";
            //}

            if (chkId.Checked)
            {
                DataRow datarow = datatable.NewRow();
                datarow["Roles_ID"] = rows.Cells[0].Text;
                //datarow["Permission"] = strID;

                datatable.Rows.Add(datarow);
            }

        }

        return datatable;
    }

    #endregion
}
