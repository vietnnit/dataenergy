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


public partial class Admin_Member_EditMember : System.Web.UI.UserControl
{
    int MemberId
    {
        get
        {
            if (ViewState["MemberId"] != null)
                return (int)ViewState["MemberId"];
            else
                return 0;
        }
        set { ViewState["MemberId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            BindOrganization();
            BindData();
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
        ddlOrg.Items.Clear();
        ddlOrg.DataSource = list;
        ddlOrg.DataTextField = "Title";
        ddlOrg.DataValueField = "Id";
        ddlOrg.DataBind();
        ddlOrg.Items.Insert(0, new ListItem("---Chọn đơn vị---", ""));
    }
    void BindEnterprise()
    {
        IList<Enterprise> list = new List<Enterprise>();
        int OrgId = 0;
        if (ddlOrg.SelectedIndex > 0)
            OrgId = Convert.ToInt32(ddlOrg.SelectedValue);
        list = new EnterpriseService().GetEnterpriseByOrg(OrgId);
        ddlEnterprise.Items.Clear();
        ddlEnterprise.DataSource = list;
        ddlEnterprise.DataTextField = "Title";
        ddlEnterprise.DataValueField = "Id";
        ddlEnterprise.DataBind();
        ddlEnterprise.Items.Insert(0, new ListItem("---Chọn doanh nghiệp---", ""));
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
    protected void BindData()
    {
        if (MemberId > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_edit1.Visible = true;

            try
            {
                MemberService adminBSO = new MemberService();
                ePower.DE.Domain.Member admin = adminBSO.FindByKey(MemberId);
                hddAdmin_Username.Value = admin.AccountName;
                txtAdminName.Text = admin.AccountName;
                txtAdminName.Enabled = false;
                hddPass.Value = admin.Password;

                txtFullName.Text = admin.FullName;
                txtAdminEmail.Text = admin.Email;

                rdbList.Checked = admin.IsActive;
                hdd_Created.Value = admin.Created.ToString();

                txtAddress.Text = admin.Address;

                txtPhone.Text = admin.Phone;

                if (admin.EnterpriseId > 0)
                    ddlOrg.SelectedValue = admin.EnterpriseId.ToString();

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

        }
    }
    #endregion



    #region ReceiveHtml
    public ePower.DE.Domain.Member ReceiveHtml()
    {
        SecurityBSO securityBSO = new SecurityBSO();
        ePower.DE.Domain.Member admin = new ePower.DE.Domain.Member();

        admin.Password = (txtAdminPass.Text != "") ? securityBSO.EncPwd(txtAdminPass.Text.Trim()) : hddPass.Value;
        admin.AccountName = txtAdminName.Text.Trim();
        admin.Email = (txtAdminEmail.Text != "") ? txtAdminEmail.Text.Trim() : "";

        admin.IsActive = rdbList.Checked;
        admin.FullName = (txtFullName.Text != "") ? txtFullName.Text.Trim() : "";


        admin.Address = (txtAddress.Text != "") ? txtAddress.Text.Trim() : "";
        admin.Phone = (txtPhone.Text != "") ? txtPhone.Text.Trim() : "";
        if (ddlEnterprise.SelectedIndex > 0)
            admin.EnterpriseId = Convert.ToInt32(ddlEnterprise.SelectedValue);

        return admin;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        ePower.DE.Domain.Member admin = ReceiveHtml();
        try
        {
            MemberService adminBSO = new MemberService();
            if (adminBSO.ExistAccount(admin.AccountName))
            {
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Tài khoản đã được đăng ký. Vui lòng đăng ký lại !</div>";
            }
            else
                if (adminBSO.ExistEmail(admin.Email))
                {
                    error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Địa chỉ Email đã được đăng ký. Vui lòng đăng ký lại !</div>";

                }
                else
                {

                    int id = adminBSO.Insert(admin);

                    if (id > 0)
                    {
                        error.Text = "<div class='alert alert-sm alert-success bg-gradient'>Thêm mới thành công !</div>";
                        Response.Redirect(ResolveUrl("~") + "Admin/ListMember.aspx");
                    }
                    else

                        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới không thành công !</div>";

                }
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }
    protected void ddlOrg_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindEnterprise();
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        ePower.DE.Domain.Member admin = ReceiveHtml();
        try
        {
            SecurityBSO securityBSO = new SecurityBSO();
            MemberService adminBSO = new MemberService();
            admin = adminBSO.FindByKey(MemberId);
            admin.Password = (txtAdminPass.Text != "") ? securityBSO.EncPwd(txtAdminPass.Text.Trim()) : hddPass.Value;
            admin.Email = (txtAdminEmail.Text != "") ? txtAdminEmail.Text.Trim() : "";

            admin.IsActive = rdbList.Checked;
            admin.FullName = (txtFullName.Text != "") ? txtFullName.Text.Trim() : "";


            admin.Address = (txtAddress.Text != "") ? txtAddress.Text.Trim() : "";
            admin.Phone = (txtPhone.Text != "") ? txtPhone.Text.Trim() : "";
            if (ddlEnterprise.SelectedIndex > 0)
                admin.EnterpriseId = Convert.ToInt32(ddlEnterprise.SelectedValue);

            if (adminBSO.Update(admin) != null)
            {
                Response.Redirect(ResolveUrl("~") + "Admin/ListMember.aspx");
                error.Text = "<div class='alert alert-sm alert-success bg-gradient'>Cập nhật thành công !</div>";
            }
            else
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật không thành công !</div>";

        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }

}
