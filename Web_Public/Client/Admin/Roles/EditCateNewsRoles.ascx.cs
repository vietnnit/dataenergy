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
public partial class Client_Admin_EditCateNewsRoles : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        hddCateNewsID.Value = Convert.ToString(Id);

        if (!IsPostBack)
        {
            CateNewsBSO catenewBSO = new CateNewsBSO();
            CateNews catenews = catenewBSO.GetCateNewsById(Id);
            HddGroupCate.Value = Convert.ToString(catenews.GroupCate);
            ltlTitle.Text = catenews.CateNewsName;
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
        DataTable datatable = CateNewsID();

        try
        {
            CateNewsPermissionBSO catenewPermissionBSO = new CateNewsPermissionBSO();

            DataTable table1 = catenewPermissionBSO.GetCateNewsPermissionByCateID(Convert.ToInt32(hddCateNewsID.Value));

            if (table1.Rows.Count > 0)
                catenewPermissionBSO.DeleteCateNewsPermissionCateID(Convert.ToInt32(hddCateNewsID.Value));

            CateNewsPermission cateNewsPermission = new CateNewsPermission();

            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow subrow in datatable.Rows)
                {
                    cateNewsPermission.CateNewsID = Convert.ToInt32(hddCateNewsID.Value);
                    cateNewsPermission.RolesID = Convert.ToInt32(subrow["Roles_ID"].ToString()); 
                    //cateNewsPermission.Permission = subrow["Permission"].ToString();
                    cateNewsPermission.Permission = "";
                    cateNewsPermission.UserName = Session["Admin_UserName"].ToString();
                    cateNewsPermission.Created = DateTime.Now;
                    cateNewsPermission.Language = Language.language;

                    catenewPermissionBSO.CreateCateNewsPermission(cateNewsPermission);
                    error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";

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
        //PermissionBSO permissionBSO = new PermissionBSO();
        //DataTable table = permissionBSO.GetPermissionAll();
        //DataView dataView = new DataView(table);
        //dataView.Sort = "PermissionID ASC";
        //DataTable dataTable = dataView.ToTable();
        //commonBSO commonBSO = new commonBSO();

        CateNewsPermissionBSO cateNewsPermissionBSO = new CateNewsPermissionBSO();
        CateNewsPermission cateNewsPermission = new CateNewsPermission();

        foreach (GridViewRow rows in grvRoles.Rows)
        {
            CheckBox chkId = (CheckBox)rows.Cells[0].FindControl("chkId");

            //commonBSO.FillToCheckBoxList(chklist, dataTable, "PermissionName", "Value");

            if (cateNewsPermissionBSO.CheckExitPermission(Convert.ToInt32(rows.Cells[0].Text), Convert.ToInt32(hddCateNewsID.Value)))
            {

                //Permission
                //cateNewsPermission = cateNewsPermissionBSO.GetCateNewsPermission(Convert.ToInt32(dataItem["Roles_ID"].Text), Convert.ToInt32(hddCateNewsID.Value));

                //if (cateNewsPermission != null)
                //{
                //    string sPermission = cateNewsPermission.Permission;
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

                //CateID
                chkId.Checked = true;
            }

        }


    }
    #endregion

    #region CateNewsID
    private DataTable CateNewsID()
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

    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Group/ListCateNews/" + HddGroupCate.Value + "/Default.aspx");

    }
}
