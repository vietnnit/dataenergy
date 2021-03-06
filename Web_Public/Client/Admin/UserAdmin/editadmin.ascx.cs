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
using System.Data.SqlClient;
using ETO;
using BSO;
using DAO;
using ePower.DE.Domain;
using System.Collections.Generic;
using ePower.DE.Service;


public partial class Admin_Controls_CreateAdmincontent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string aName = "";
        //if (!string.IsNullOrEmpty(Request["Id"]))
        //    aName = Request["Id"];

        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            txtBirth.Text = DateTime.Now.ToString("dd/MM/yyyy hh:MM");
            BindOrganization();
            initControl(Id);
            //ViewRoles();
        }
    }
    void BindOrganization()
    {
        IList<Organization> list = new List<Organization>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Organization_All))
        {
            list = new OrganizationService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Organization_All, list);
        }
        else
            list = (IList<Organization>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Organization_All);
        ddlOrg.DataSource = list;
        ddlOrg.DataTextField = "Title";
        ddlOrg.DataValueField = "Id";
        ddlOrg.DataBind();
        ddlOrg.Items.Insert(0, new ListItem("---Chọn đơn vị---", ""));
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
            hddAdmin_Id.Value = Id.ToString();
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_edit1.Visible = true;


            try
            {
                AdminBSO adminBSO = new AdminBSO();
                Admin admin = adminBSO.GetAdminById(Id);

                hddAdmin_Username.Value = admin.AdminName;
                txtAdminName.Text = admin.AdminName;
                txtAdminName.Enabled = false;
                hddPass.Value = admin.AdminPass;


                txtFullName.Text = admin.AdminFullName;
                txtAdminEmail.Text = admin.AdminEmail;

                rdbList.Checked = admin.AdminActive;
                hdd_Created.Value = admin.AdminCreated.ToString();
                hdd_log.Value = admin.AdminLog.ToString();

                ViewPermission();
                string sPermission = admin.AdminPermission;
                if (!sPermission.Equals(""))
                {
                    string[] sSlip = sPermission.Split(new char[] { ',' });
                    foreach (string s in sSlip)
                    {
                        foreach (ListItem items in chklist.Items)
                        {
                            if (items.Value == s)
                                items.Selected = true;
                        }
                    }
                }

                txtAddress.Text = admin.AdminAddress;
                txtBirth.Text = String.Format("{0:dd/MM/yyyy HH:mm}", admin.AdminBirth);
                rdbSex.Checked = admin.AdminSex;
                txtNickYahoo.Text = admin.AdminNickYahoo;
                txtNickSkype.Text = admin.AdminNickSkype;
                txtPhone.Text = admin.AdminPhone;

                rdbLoginType.Checked = admin.AdminLoginType;
                rdbLoginType.Enabled = false;


                hddImageThumb.Value = admin.AdminAvatar;
                if (admin.AdminOrganizationId > 0)
                    ddlOrg.SelectedValue = admin.AdminOrganizationId.ToString();
                txtimage4_3.Text = admin.AdminAvatar;

                if (admin.AdminAvatar != "")
                    img_thumb.Text = "<img src='" + admin.AdminAvatar + "' width='48px' valign='middle'>";

            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        else
        {
            hddAdmin_Id.Value = "0";
            hddAdmin_Username.Value = "";
            hdd_Created.Value = DateTime.Now.ToString();
            hdd_log.Value = DateTime.Now.ToString();
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_edit1.Visible = false;

            ViewPermission();
        }
    }
    #endregion



    #region ViewPermission
    public void ViewPermission()
    {
        PermissionBSO permissionBSO = new PermissionBSO();
        DataTable table = permissionBSO.GetPermissionAll();
        DataView dataView = new DataView(table);
        dataView.Sort = "PermissionID ASC";
        DataTable dataTable = dataView.ToTable();
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToCheckBoxList(chklist, dataTable, "PermissionName", "Value");


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
    public Admin ReceiveHtml()
    {
        SecurityBSO securityBSO = new SecurityBSO();
        Admin admin = new Admin();

        admin.AdminLoginType = rdbLoginType.Checked;


        admin.AdminID = (hddAdmin_Id.Value != "") ? Convert.ToInt32(hddAdmin_Id.Value) : 0;
        //if (rdbLoginType.SelectedItem.Value.Equals("True"))
        //{
        admin.AdminPass = (txtAdminPass.Text != "") ? securityBSO.EncPwd(txtAdminPass.Text.Trim()) : hddPass.Value;
        admin.AdminName = (txtAdminName.Text != "") ? txtAdminName.Text.Trim() : hddAdmin_Username.Value;
        admin.AdminEmail = (txtAdminEmail.Text != "") ? txtAdminEmail.Text.Trim() : "";

        //}


        // admin.RolesID = (ddlRoles.SelectedValue != "") ? Convert.ToInt32(ddlRoles.SelectedValue) : 0;
        admin.RolesID = 1;
        admin.AdminActive = rdbList.Checked;
        admin.AdminFullName = (txtFullName.Text != "") ? txtFullName.Text.Trim() : "";

        admin.AdminCreated = Convert.ToDateTime(hdd_Created.Value);
        admin.AdminLog = Convert.ToDateTime(hdd_log.Value);
        //admin.AdminPermission = "";
        admin.AdminPermission = (CheckedList() != "") ? CheckedList() : "";

        admin.AdminAddress = (txtAddress.Text != "") ? txtAddress.Text.Trim() : "";
        admin.AdminPhone = (txtPhone.Text != "") ? txtPhone.Text.Trim() : "";
        admin.AdminNickYahoo = (txtNickYahoo.Text != "") ? txtNickYahoo.Text.Trim() : "";
        admin.AdminNickSkype = (txtNickSkype.Text != "") ? txtNickSkype.Text.Trim() : "";
        admin.AdminAvatar = (txtimage4_3.Text != "") ? txtimage4_3.Text : hddImageThumb.Value;
        admin.AdminSex = rdbSex.Checked;
        IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
        admin.AdminBirth = DateTime.ParseExact(txtBirth.Text, "dd/MM/yyyy HH:mm", culture);
        if (ddlOrg.SelectedIndex > 0)
            admin.AdminOrganizationId = Convert.ToInt32(ddlOrg.SelectedValue);

        return admin;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        Admin admin = ReceiveHtml();
        try
        {
            AdminBSO adminBSO = new AdminBSO();
            if (adminBSO.CheckExist(admin.AdminName))
            {
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Tài khoản đã được đăng ký. Vui lòng đăng ký lại !</div>";
            }
            else
                if (adminBSO.CheckExistEmail(admin.AdminEmail))
                {
                    error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Địa chỉ Email đã được đăng ký. Vui lòng đăng ký lại !</div>";

                }
                else
                {
                    if (CheckedList().Equals(""))
                    {
                        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lỗi: Phải lựa chọn ít nhất 1 quyền !</div>";
                    }
                    else
                    {
                        int id = adminBSO.CreateAdmin(admin);

                        RolesBSO rolesBSO = new RolesBSO();
                        IRoles roles = rolesBSO.GetRolesByName("Guest");
                        AdminRolesBSO adminRolesBSO = new AdminRolesBSO();
                        AdminRoles adminRoles = new AdminRoles();

                        adminRoles.AdminUserName = admin.AdminName;
                        adminRoles.RolesID = roles.RolesID;
                        adminRoles.UserName = Session["Admin_UserName"].ToString();
                        adminRoles.Permission = "";
                        adminRoles.Created = DateTime.Now;
                        adminRolesBSO.CreateAdminRoles(adminRoles);

                        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
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
        Admin admin = ReceiveHtml();
        try
        {
            if (CheckedList().Equals(""))
            {
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lỗi: Phải lựa chọn ít nhất 1 quyền !</div>";
            }
            else
            {
                AdminBSO adminBSO = new AdminBSO();
                adminBSO.UpdateAdmin(admin);
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
                initControl(admin.AdminID);
            }
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }

}
