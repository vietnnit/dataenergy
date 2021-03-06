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
public partial class Client_Admin_EditCateNewsGroupPermission : System.Web.UI.UserControl
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
            ViewPermissionID();
        }
        else
        {
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lỗi: Lựa chọn Nhóm người dùng trước khi phân quyền </div>";
        }
    }
    #endregion

    #region ViewCateAll
    private void ViewCateAll()
    {
        CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
        DataTable dtGroupCate = catenewsGroupBSO.GetCateNewsGroupAll(Language.language, Session["Admin_UserName"].ToString());
        commonBSO commonBSO = new commonBSO();
        DataTable dtRole = commonBSO.CreateDataView("SELECT * FROM tblRoleCate WHERE GroupId=" + hddRoles.Value);//Lay danh danh chuyen muc nhom quyen dc truy cap
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        for (int i = 0; i < dtGroupCate.Rows.Count; i++)
        {
            ListItem item = new ListItem(dtGroupCate.Rows[i]["CateNewsGroupName"].ToString(), dtGroupCate.Rows[i]["CateNewsGroupID"].ToString());
            chklist.Items.Add(item);
            DataTable dtCateAll = commonBSO.CreateDataView("SELECT * FROM tblCateNews WHERE GroupCate=" + dtGroupCate.Rows[i]["GroupCate"]);

            if (dtCateAll != null && dtCateAll.Rows.Count > 0)
            {
                BindCate(0, dtCateAll, dtRole, 1);
            }
            //commonBSO.FillToCheckBoxList(chklist, table, "CateNewsGroupName", "CateNewsGroupID");
        }

    }
    void BindCate(int CateParentId, DataTable dtCate, DataTable dtRoleGroup, int level)
    {
        DataRow[] drData = dtCate.Select("ParentNewsID=" + CateParentId);
        if (drData.Length > 0)
        {
            string prefix = "";
            for (int i = 0; i < level; i++)
                prefix = prefix + "--- ";
            for (int i = 0; i < drData.Length; i++)
            {
                ListItem item = new ListItem(prefix + drData[i]["CateNewsName"].ToString(), drData[i]["CateNewsID"].ToString());
                if (dtRoleGroup != null && dtRoleGroup.Rows.Count > 0)
                {
                    DataRow[] drRole = dtRoleGroup.Select("CateId=" + drData[i]["CateNewsID"]);
                    if (drRole != null && drRole.Length > 0)
                        item.Selected = true;
                }
                chklist.Items.Add(item);
                BindCate(Convert.ToInt32(drData[i]["CateNewsID"]), dtCate, dtRoleGroup, level + 1);
            }
        }
    }
    #endregion



    protected void btn_add_Click(object sender, EventArgs e)
    {
        //DataTable datatable = CateNewsGroupID();

        //try
        //{
        //    CateNewsGroupPermissionBSO catenewPermissionBSO = new CateNewsGroupPermissionBSO();

        //    DataTable table1 = catenewPermissionBSO.GetCateNewsGroupPermissionByRoles(Convert.ToInt32(hddRoles.Value), Language.language);

        //    if (table1.Rows.Count > 0)
        //        catenewPermissionBSO.DeleteCateNewsGroupPermissionRoles(Convert.ToInt32(hddRoles.Value), Language.language);

        //    CateNewsGroupPermission _cateNewsGroupPermission = new CateNewsGroupPermission();

        //    if (datatable.Rows.Count > 0)
        //    {
        //        foreach (DataRow subrow in datatable.Rows)
        //        {
        //            _cateNewsGroupPermission.CateNewsGroupID = Convert.ToInt32(subrow["CateNewsGroupID"].ToString());
        //            _cateNewsGroupPermission.RolesID = Convert.ToInt32(hddRoles.Value);
        //            _cateNewsGroupPermission.Permission = "";
        //            _cateNewsGroupPermission.UserName = Session["Admin_UserName"].ToString();
        //            _cateNewsGroupPermission.Created = DateTime.Now;
        //            _cateNewsGroupPermission.Language = Language.language;

        //            catenewPermissionBSO.CreateCateNewsGroupPermission(_cateNewsGroupPermission);

        //            error.Text = "<div class='alert alert-sm alert-success bg-gradient'>Cập nhật thành công !</div>";
        //            ////  initControl(_cateNewsGroupPermission.RolesID);

        //        }


        //    }


        //}
        //catch (Exception ex)
        //{
        //    error.Text = ex.Message.ToString();
        //}
        commonBSO commonBSO = new commonBSO();
        commonBSO.CreateDataView("DELETE FROM tblRoleCate WHERE GroupId=" + hddRoles.Value);
        foreach (ListItem item in chklist.Items)
        {
            if (item.Selected && item.Text.Contains("---"))
            {
                RoleCate roleCate = new RoleCate();
                roleCate.CateId = Convert.ToInt32(item.Value);
                roleCate.GroupId = Convert.ToInt32(hddRoles.Value);
                new RoleCateService().Insert(roleCate);
            }
        }
        error.Text = "<div class='alert alert-sm alert-success bg-gradient'>Cập nhật thành công !</div>";
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }



    #region ViewPermissionID
    private void ViewPermissionID()
    {

        CateNewsGroupPermissionBSO _cateNewsGroupPermissionBSO = new CateNewsGroupPermissionBSO();
        CateNewsGroupPermission _cateNewsGroupPermission = new CateNewsGroupPermission();

        foreach (ListItem items in chklist.Items)
        {
            if (_cateNewsGroupPermissionBSO.CheckExitPermission(Convert.ToInt32(hddRoles.Value), Convert.ToInt32(items.Value)))
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

        foreach (ListItem items in chklist.Items)
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




}
