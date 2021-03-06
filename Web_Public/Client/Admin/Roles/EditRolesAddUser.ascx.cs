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
public partial class Client_Admin_EditRolesAddUser : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        hddRoles.Value = Convert.ToString(Id);

        if (!IsPostBack)
        {
            RolesBSO rolesBSO = new RolesBSO();
            IRoles roles = rolesBSO.GetRolesById(Id);
            ltlTitle.Text = roles.RolesName;

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
            ViewCateAll();
            VierUserRoles();
        }
        else
        {
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lỗi: Lựa chọn Nhóm người dùng trước khi thêm tài khoản </div>";
        }
    }
    #endregion

    #region ViewCateAll
    private void ViewCateAll()
    {
        AdminBSO adminBSO = new AdminBSO();
        DataTable datatable = adminBSO.GetAllAdmin();
        DataView dataView = new DataView(datatable);

        dataView.RowFilter = "Admin_Username not in ('administrator','Administrator')";
        dataView.Sort = "Admin_UserName Asc";
        DataTable table = dataView.ToTable();

        grvUser.DataSource = table;
        grvUser.DataBind();

    }
    #endregion







    protected void btn_add_Click(object sender, EventArgs e)
    {
        DataTable datatable = GetUserGrid();

        try
        {
            AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
            DataTable table1 = adminRolesBSO.GetAdminRolesByRoles(Convert.ToInt32(hddRoles.Value));

            if (table1.Rows.Count > 0)
                adminRolesBSO.DeleteAdminRolesRoles(Convert.ToInt32(hddRoles.Value));

            AdminRoles adminRoles = new AdminRoles();

            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow subrow in datatable.Rows)
                {
                    adminRoles.AdminUserName = subrow["Admin_UserName"].ToString();
                    adminRoles.RolesID = Convert.ToInt32(hddRoles.Value);
                    adminRoles.UserName = Session["Admin_UserName"].ToString();
                    //adminRoles.Permission = subrow["Permission"].ToString();
                    adminRoles.Permission = "";
                    adminRoles.Created = DateTime.Now;

                    adminRolesBSO.CreateAdminRoles(adminRoles);

                    error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
                    //initControl(adminRoles.AdminRolesID);

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


        foreach (GridViewRow rows in grvUser.Rows)
        {
            //CheckBoxList chklist = (CheckBoxList)dataItem.FindControl("chklist");
            CheckBox chkId = (CheckBox)rows.Cells[0].FindControl("chkId");

            //commonBSO.FillToCheckBoxList(chklist, dataTable, "PermissionName", "Value");

            if (adminRolesBSO.CheckExitRolesUser(Convert.ToInt32(hddRoles.Value), rows.Cells[2].Text))
            {
                //Permission
                //adminRoles = adminRolesBSO.GetAdminRoles(Convert.ToInt32(hddRoles.Value), dataItem["Admin_UserName"].Text);

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
        datatable.Columns.Add("Admin_UserName");
        //datatable.Columns.Add("Permission");

        foreach (GridViewRow rows in grvUser.Rows)
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
                datarow["Admin_UserName"] = rows.Cells[2].Text;
                //datarow["Permission"] = strID;

                datatable.Rows.Add(datarow);
            }

        }

        return datatable;
    }

    #endregion
}
