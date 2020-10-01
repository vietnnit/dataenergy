using System;
using System.Collections;
using System.Linq;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Collections.Generic;
using ePower.DE.Service;
using ePower.DE.Domain;
using System.Data;
using System.Web.UI;
public partial class Client_Admin_ListDEOrganization : System.Web.UI.UserControl
{
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] != null)
                return Convert.ToInt32(ViewState["CurrentPage"].ToString());
            else
                return 1;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    private int PageSize
    {
        get
        {
            if (ViewState["PageSize"] != null)
                return Convert.ToInt32(ViewState["PageSize"].ToString());
            else
                return 20;
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        if (!IsPostBack)
        {
            BindProvince();
            BindData();
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


    #region ViewNewsGroup
    private void BindData()
    {
        OrganizationService comBSO = new OrganizationService();
        DataTable list = new DataTable();
        int provinceId = 0;
        if (ddlProvinceSearch.SelectedIndex > 0)
            provinceId = Convert.ToInt32(ddlProvinceSearch.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        list = comBSO.FindOrganizationList(txtKeyword.Text.Trim(), provinceId, paging, true);
        if (list != null && list.Rows.Count > 0)
        {
            paging.RowsCount = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.DataLoad();
            if (paging.PagesCount <= 1)
            {
                ltrTotal.Text = "Có tổng số " + paging.RowsCount + " đơn vị";
                Paging.Visible = false;
            }
            else
            {
                int st = (CurrentPage - 1) * PageSize + 1;
                long end = CurrentPage * PageSize;
                if (end > paging.RowsCount)
                    end = paging.RowsCount;
                ltrTotal.Text = "Đang xem trang " + CurrentPage + ". Hiển thị từ " + st + " - " + end + " trên tổng số " + paging.RowsCount + " đơn vị";
                Paging.Visible = true;
            }

        }
        else
        {
            ltrTotal.Text = "";
            Paging.Visible = false;
        }
        grvOrg.DataSource = list;
        grvOrg.DataBind();
    }
    #endregion


    void BindProvince()
    {
        IList<Province> list = new List<Province>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Provice_All))
        {
            list = new ProvinceService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Provice_All, list);
        }
        else
            list = (IList<Province>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Provice_All);

        ddlProvince.DataSource = list;
        ddlProvince.DataTextField = "ProvinceName";
        ddlProvince.DataValueField = "Id";
        ddlProvince.DataBind();
        ddlProvince.Items.Insert(0, new ListItem("---Chọn Tỉnh/TP---"));

        ddlProvinceSearch.DataSource = list;
        ddlProvinceSearch.DataTextField = "ProvinceName";
        ddlProvinceSearch.DataValueField = "Id";
        ddlProvinceSearch.DataBind();
        ddlProvinceSearch.Items.Insert(0, new ListItem("---Tất cả---"));
    }


    protected void btnCreateUser_Click(object sender, EventArgs e)
    {
        OrganizationService comBSO = new OrganizationService();
        IList<Organization> list = new List<Organization>();
        list = comBSO.FindAll();
        SecurityBSO securityBSO = new SecurityBSO();
        AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
        AdminBSO adminBSO = new AdminBSO();
        Utils objUtil = new Utils();

        foreach (Organization org in list)
        {

            Admin admin = new Admin();

            admin.AdminLoginType = false;
            admin.AdminPass = securityBSO.EncPwd("123456");
            admin.AdminName = "SCT." + Utils.UCS2Convert(org.Title).Replace(" ", "").Replace("-", "").ToUpper(); ;
            admin.AdminEmail = org.Email;

            //}


            // admin.RolesID = (ddlRoles.SelectedValue != "") ? Convert.ToInt32(ddlRoles.SelectedValue) : 0;
            admin.RolesID = 1;
            admin.AdminActive = true;
            admin.AdminFullName = "Sở công thương" + org.Title;

            admin.AdminCreated = DateTime.Now;
            admin.AdminLog = DateTime.Now;
            //admin.AdminPermission = "";
            admin.AdminPermission = "Read,";

            admin.AdminAddress = "";
            admin.AdminPhone = org.Phone;
            admin.AdminNickYahoo = "";
            admin.AdminNickSkype = "";
            admin.AdminAvatar = "";
            admin.AdminSex = true;
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            admin.AdminBirth = DateTime.Now;
            if (org.Email != null && org.Email != "")
                admin.AdminEmail = org.Email;
            else
                admin.AdminEmail = "sct" + "@" + admin.AdminName.ToLower() + ".gov.vn";

            admin.AdminOrganizationId = org.Id;
            int id = adminBSO.CreateAdmin(admin);

            AdminRoles adminRoles = new AdminRoles();
            adminRoles.RolesID = 14;
            adminRoles.AdminUserName = admin.AdminName;
            adminRoles.UserName = Session["Admin_UserName"].ToString();
            //adminRoles.Permission = subrow["Permission"].ToString();
            adminRoles.Permission = "";
            adminRoles.Created = DateTime.Now;

            adminRolesBSO.CreateAdminRoles(adminRoles);
        }
    }

    protected void btn_Order_Click(object sender, EventArgs e)
    {
        if (grvOrg.Rows != null && grvOrg.Rows.Count > 2)
        {
            OrganizationService comBSO = new OrganizationService();
            foreach (GridViewRow row in grvOrg.Rows)
            {
                TextBox textOrder = (TextBox)row.FindControl("txtOrder");
                if (textOrder != null && textOrder.Text != "" && textOrder.Text.Trim() != "")
                {
                    int pID = Convert.ToInt32(row.Cells[0].Text);
                    int pOrder = 0;
                    try
                    {

                        pOrder = Convert.ToInt32(textOrder.Text);
                        Organization objOrganization = new Organization();
                        objOrganization = comBSO.FindByKey(pID);
                        if (objOrganization != null)
                        {
                            objOrganization.SortOrder = pOrder;
                            comBSO.Update(objOrganization);
                        }
                    }
                    catch { }
                }
            }
            BindData();
        }
    }

    protected void grvOrg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int iEditId = 0;
        iEditId = Convert.ToInt32(e.CommandArgument.ToString());
        string aName = e.CommandName.ToLower();
        if (iEditId > 0)
        {
            OrganizationService objlogic = new OrganizationService();
            if (aName.Contains("_edit"))
            {
                Organization obj = new Organization();
                obj = objlogic.FindByKey(iEditId);
                if (obj != null)
                {
                    hdnEditId.Value = iEditId.ToString();
                    txtTitle.Text = obj.Title;
                    txtSorOrder.Text = obj.SortOrder.ToString();
                    txtAddress.Text = obj.Address;
                    txtPhone.Text = obj.Phone;
                    txtEmail.Text = obj.Email;
                    txtNote.Text = obj.Note;
                    if (obj.ProvinceId > 0)
                        ddlProvince.SelectedValue = obj.ProvinceId.ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updateorg();", true);
                }
            }
            else if (aName.Contains("_delete"))
            {
                Organization obj = new Organization();
                obj = objlogic.FindByKey(iEditId);
                if (obj != null)
                {
                    obj.IsDelete = true;
                    if (objlogic.Update(obj) != null)
                    {
                        BindData();
                    }
                }
            }
        }
    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        OrganizationService objService = new OrganizationService();
        Organization objOrganization = new Organization();
        int fId = 0;
        if (hdnEditId.Value != "")
        {
            try
            {
                fId = Convert.ToInt32(hdnEditId.Value.Trim());
            }
            catch
            { }
        }
        objOrganization.Title = txtTitle.Text.Trim();
        if (ddlProvince.SelectedValue != "")
            objOrganization.ProvinceId = Convert.ToInt32(ddlProvince.SelectedValue);
        int fOrder = 0;
        try
        {
            fOrder = Convert.ToInt32(txtSorOrder.Text);
            objOrganization.SortOrder = fOrder;
        }
        catch { }
        if (txtAddress.Text != "")
            objOrganization.Address = txtAddress.Text.Trim();
        if (txtPhone.Text != "")
            objOrganization.Phone = txtPhone.Text.Trim();
        if (txtEmail.Text != "")
            objOrganization.Email = txtEmail.Text.Trim();
        if (txtNote.Text != "")
            objOrganization.Note = txtNote.Text.Trim();
        if (fId > 0)
        {
            objOrganization.Id = fId;
            if (objService.Update(objOrganization) != null)
            {
                BindData();
                hdnEditId.Value = "0";
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showform", "updateorg();", true);
        }
        else
        {
            objOrganization.IsDelete = false;
            objOrganization.IsActive = true;
            if (objService.Insert(objOrganization) > 0)
            {
                BindData();
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showform", "addorg();", true);
        }
    }
}
