using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using BSO;
using Telerik.Web.UI;
public partial class Admin_Controls_EditRolesModule : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        hddRoles_ID.Value = Convert.ToString(Id);

        if (!IsPostBack)
        {
            RolesBSO rolesBSO = new RolesBSO();
            IRoles roles = rolesBSO.GetRolesById(Id);
            ltlTitle.Text = roles.RolesName;

            initControl(Id);
            initControlCate(Id);
            initControlCateNews(Id);
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
    protected void initControl(int ID)
    {
        if (ID > 0)
        {
            //btn_add.Visible = false;
            //btn_edit.Visible = true;

            //btn_add1.Visible = false;
            //btn_edit1.Visible = true;

            hddRoles_ID.Value = Convert.ToString(ID);
            try
            {
                RolesBSO rolesBSO = new RolesBSO();
                IRoles roles = rolesBSO.GetRolesById(ID);
                txtRolesName.Text = roles.RolesName;

                if (Session["Admin_UserName"].ToString().Equals("administrator"))
                    ViewModules();
                else
                    ViewModules(Session["Admin_UserName"].ToString());

                string sModules = roles.RolesModules;
                if (!sModules.Equals(""))
                {
                    string[] sSlip = sModules.Split(new char[] { ',' });
                    foreach (string s in sSlip)
                    {
                        foreach (ListItem items in chklist.Items)
                        {
                            if (items.Value == s)
                                items.Selected = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        else
        {
            hddRoles_ID.Value = "";
            //btn_add.Visible = true;
            //btn_edit.Visible = false;

            btn_add1.Visible = true;
            //btn_edit1.Visible = false;
            ViewModules();
        }
    }

    protected void initControlCate(int Id)
    {
        if (Id > 0)
        {
            ViewCateAll();
            VierPermissionID();
        }
        else
        {
            errorCate.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lỗi: Lựa chọn Nhóm người dùng trước khi phân quyền</div>";
        }
    }
    protected void initControlCateNews(int Id)
    {
        if (Id > 0)
        {
            ViewCateNewsAll();
            VierPermissionCateID();
        }
        else
        {
            error_catenews.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lỗi: Lựa chọn Nhóm người dùng trước khi phân quyền </div>";
        }
    }
    #endregion

    #region Viewmodules
    public void ViewModules()
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        DataTable table = modulesBSO.MixModules();
        DataView dataView = new DataView(table);
        // dataView.RowFilter = "Slug <> 'listmodules' and Slug <> 'editmodules' ";
        dataView.RowFilter = "Slug not in ('listmodules','editmodules')";
        DataTable dataTable = dataView.ToTable();
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToCheckBoxList(chklist, dataTable, "Modules_Name", "Slug");


    }
    public void ViewModules(string username)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        DataTable table = modulesBSO.MixModules();
        DataView dataView = new DataView(table);

        AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
        string strRoles = adminRolesBSO.GetRoles(username);
        RolesBSO rolesBSO = new RolesBSO();
        DataTable table1 = rolesBSO.GetRolesbyStrRolesID(strRoles);

        string strModules = "";

        if (table1.Rows.Count > 0)
        {
            foreach (DataRow row in table1.Rows)
            {
                strModules += row["Roles_Modules"].ToString();
            }
        }

        if (!strModules.Equals(""))
        {
            string sSlip = strModules.Remove(strModules.LastIndexOf(",")).Replace(",", "','");
            dataView.RowFilter = "Slug not in ('listmodules','editmodules') and Slug in ('" + sSlip + "')";
        }
        else
            dataView.RowFilter = "Slug not in ('listmodules','editmodules') ";

        DataTable dataTable = dataView.ToTable();
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToCheckBoxList(chklist, dataTable, "Modules_Name", "Slug");


    }
    #endregion

    #region CheckedList
    public string CheckedList()
    {
        string strID = "";
        foreach (ListItem items in chklist.Items)
        {
            if (items.Selected)
                strID += items.Value + ",";
        }
        return strID;
    }
    #endregion

    #region ReceiveHtml
    public IRoles ReceiveHtml()
    {
        IRoles roles = new IRoles();
        roles.RolesID = (hddRoles_ID.Value != "") ? Convert.ToInt32(hddRoles_ID.Value) : 0;
        roles.RolesName = (txtRolesName.Text != "") ? txtRolesName.Text.Trim() : "";
        roles.RolesModules = (CheckedList() != "") ? CheckedList() : "";

        return roles;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        RolesBSO rolesBSO = new RolesBSO();
        IRoles roles = ReceiveHtml();
        try
        {
            if (CheckedList().Equals(""))
            {
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Loi : Xin hay lua chon it nhat 1 quyen </div>";
            }
            else
            {
                if (hddRoles_ID.Value != "")
                {
                    if (rolesBSO.UpdateRoles(roles) > 0)
                        error.Text = error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật Thành công !</div>";
                    else
                    {
                        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lưu thông tin không thành công</div>";
                    }
                }
                else
                {
                    int id = rolesBSO.CreateRoles(roles);
                    error.Text = error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới Thành công !</div>";
                    initControl(id);
                }
            }

        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        RolesBSO rolesBSO = new RolesBSO();
        IRoles roles = ReceiveHtml();
        try
        {
            if (CheckedList().Equals(""))
            {
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Loi : Xin hay lua chon it nhat 1 quyen </div>";
            }
            else
            {
                rolesBSO.UpdateRoles(roles);
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật Thành công !</div>";
                initControl(roles.RolesID);
            }

        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }



    #region ViewCateAll
    private void ViewCateAll()
    {
        CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
        DataTable table = catenewsGroupBSO.GetCateNewsGroupAll(Language.language, Session["Admin_UserName"].ToString());
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToCheckBoxList(chkListCate, table, "CateNewsGroupName", "CateNewsGroupID");

    }
    #endregion

    protected void btn_add_cate_Click(object sender, EventArgs e)
    {
        DataTable datatable = CateNewsGroupID();

        try
        {
            CateNewsGroupPermissionBSO catenewPermissionBSO = new CateNewsGroupPermissionBSO();

            DataTable table1 = catenewPermissionBSO.GetCateNewsGroupPermissionByRoles(Convert.ToInt32(hddRoles_ID.Value), Language.language);

            if (table1.Rows.Count > 0)
                catenewPermissionBSO.DeleteCateNewsGroupPermissionRoles(Convert.ToInt32(hddRoles_ID.Value), Language.language);

            CateNewsGroupPermission _cateNewsGroupPermission = new CateNewsGroupPermission();

            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow subrow in datatable.Rows)
                {
                    _cateNewsGroupPermission.CateNewsGroupID = Convert.ToInt32(subrow["CateNewsGroupID"].ToString());
                    _cateNewsGroupPermission.RolesID = Convert.ToInt32(hddRoles_ID.Value);
                    _cateNewsGroupPermission.Permission = "";
                    _cateNewsGroupPermission.UserName = Session["Admin_UserName"].ToString();
                    _cateNewsGroupPermission.Created = DateTime.Now;
                    _cateNewsGroupPermission.Language = Language.language;

                    catenewPermissionBSO.CreateCateNewsGroupPermission(_cateNewsGroupPermission);
                    errorCate.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
                    //  initControl(_cateNewsGroupPermission.RolesID);

                }
            }
        }
        catch (Exception ex)
        {
            errorCate.Text = ex.Message.ToString();
        }
    }


    #region VierPermissionID
    private void VierPermissionID()
    {

        CateNewsGroupPermissionBSO _cateNewsGroupPermissionBSO = new CateNewsGroupPermissionBSO();
        CateNewsGroupPermission _cateNewsGroupPermission = new CateNewsGroupPermission();

        foreach (ListItem items in chkListCate.Items)
        {
            if (_cateNewsGroupPermissionBSO.CheckExitPermission(Convert.ToInt32(hddRoles_ID.Value), Convert.ToInt32(items.Value)))
            {
                items.Selected = true;
            }
        }

    }
    #endregion

    #region CateNewsGroupID
    private DataTable CateNewsGroupID()
    {
        DataTable datatable = new DataTable();
        datatable.Columns.Add("CateNewsGroupID");

        foreach (ListItem items in chkListCate.Items)
        {
            if (items.Selected)
            {
                DataRow datarow = datatable.NewRow();
                datarow["CateNewsGroupID"] = items.Value;
                datatable.Rows.Add(datarow);
            }
        }

        return datatable;
    }

    #endregion


    //CateNewsPermission

    #region ViewCateNewsAll
    private void ViewCateNewsAll()
    {
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.GetCateNewsNamePermission(Language.language, Session["Admin_UserName"].ToString());
        //chkCateNews.DataSource = table;
        //chkCateNews.DataTextField = "CateNewsName";
        //chkCateNews.DataValueField = "CateNewsID";
        //chkCateNews.DataBind();
        //commonBSO commonBSO = new commonBSO();
        //commonBSO.FillToCheckBoxList(chkCateNews, table, "CateNewsName", "CateNewsID");
        RadGrid1.DataSource = table;
        RadGrid1.DataBind();
    }
    #endregion

    protected void btn_add_catenews_Click(object sender, EventArgs e)
    {
        DataTable datatable = CateNewsID();

        try
        {
            CateNewsPermissionBSO catenewPermissionBSO = new CateNewsPermissionBSO();

            DataTable table1 = catenewPermissionBSO.GetCateNewsPermissionByRoles(Convert.ToInt32(hddRoles_ID.Value), Language.language);

            if (table1.Rows.Count > 0)
                catenewPermissionBSO.DeleteCateNewsPermissionRoles(Convert.ToInt32(hddRoles_ID.Value), Language.language);

            CateNewsPermission cateNewsPermission = new CateNewsPermission();

            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow subrow in datatable.Rows)
                {
                    cateNewsPermission.CateNewsID = Convert.ToInt32(subrow["CateNewsID"].ToString());
                    cateNewsPermission.RolesID = Convert.ToInt32(hddRoles_ID.Value);
                    cateNewsPermission.Permission = "";
                    cateNewsPermission.UserName = Session["Admin_UserName"].ToString();
                    cateNewsPermission.Created = DateTime.Now;
                    cateNewsPermission.Language = Language.language;
                    catenewPermissionBSO.CreateCateNewsPermission(cateNewsPermission);

                    error_catenews.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
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

    #region VierPermissionCateID
    private void VierPermissionCateID()
    {
        CateNewsPermissionBSO cateNewsPermissionBSO = new CateNewsPermissionBSO();
        CateNewsPermission cateNewsPermission = new CateNewsPermission();

        foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
        {
            CheckBox chkId = (CheckBox)dataItem.FindControl("chkId");

            if (cateNewsPermissionBSO.CheckExitPermission(Convert.ToInt32(hddRoles_ID.Value), Convert.ToInt32(dataItem["CateNewsID"].Text)))
            {
                chkId.Checked = true;
            }

        }


    }
    #endregion

    #region CateNewsID
    private DataTable CateNewsID()
    {
        DataTable datatable = new DataTable();
        datatable.Columns.Add("CateNewsID");
        foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
        {
            CheckBox chkId = (CheckBox)dataItem.FindControl("chkId");
            if (chkId.Checked)
            {
                DataRow datarow = datatable.NewRow();
                datarow["CateNewsID"] = dataItem["CateNewsID"].Text;

                datatable.Rows.Add(datarow);
            }

        }

        return datatable;
    }

    #endregion
}
