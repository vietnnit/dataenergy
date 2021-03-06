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

public partial class Admin_Controls_Changepass : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
            initControl();

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
    }
    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion
    protected void initControl()
    {
        string adminName = Session["Admin_Username"].ToString();
        AdminBSO adminBSO = new AdminBSO();
        Admin admin = adminBSO.GetAdminById(adminName);
        /* if (admin.AdminLoginType)
         {
             News_Pass.ReadOnly = false;
             Re_Pass.ReadOnly = false;
         }
         else
         {
             News_Pass.ReadOnly = true;
             Re_Pass.ReadOnly = true;
             CompareValidator1.Visible = false;
             CompareValidator2.Visible = false;
             RequiredFieldValidator1.Visible = false;
             RequiredFieldValidator2.Visible = false;
         }*/

        hddAdminLoginType.Value = Convert.ToString(admin.AdminLoginType);
        txtAdminUser.Text = adminName;
        txtAdminEmail.Text = admin.AdminEmail;
        hddRoles_ID.Value = admin.RolesID.ToString();
        hddActied.Value = admin.AdminActive.ToString();
        txtFullName.Text = admin.AdminFullName;
        hdd_Created.Value = admin.AdminCreated.ToString();
        hdd_log.Value = admin.AdminLog.ToString();
        hddPermission.Value = admin.AdminPermission;

        hddAddress.Value = admin.AdminAddress;
        hddBirth.Value = admin.AdminBirth.ToString();
        hddSex.Value = admin.AdminSex.ToString();
        hddNickYahoo.Value = admin.AdminNickYahoo;
        hddNickSkype.Value = admin.AdminNickSkype;
        hddPhone.Value = admin.AdminPhone;
        hddImageThumb.Value = admin.AdminAvatar;



    }

    #region ReceiveHtml
    protected Admin ReceiveHtml()
    {
        SecurityBSO securityBSO = new SecurityBSO();
        Admin admin = new Admin();
        admin.AdminName = txtAdminUser.Text;
        admin.AdminEmail = txtAdminEmail.Text;
        admin.AdminLoginType = Convert.ToBoolean(hddAdminLoginType.Value);
        if (admin.AdminLoginType)
        {
            admin.AdminPass = securityBSO.EncPwd(News_Pass.Text.Trim());
        }
        else
        {
            admin.AdminPass = "";
        }
        admin.AdminPass = securityBSO.EncPwd(News_Pass.Text.Trim());
        admin.RolesID = Convert.ToInt32(hddRoles_ID.Value);
        admin.AdminActive = Convert.ToBoolean(hddActied.Value);

        admin.AdminFullName = (txtFullName.Text != "") ? txtFullName.Text.Trim() : "";

        admin.AdminCreated = Convert.ToDateTime(hdd_Created.Value);
        admin.AdminLog = Convert.ToDateTime(hdd_log.Value);
        admin.AdminPermission = (hddPermission.Value != "") ? hddPermission.Value : "";

        admin.AdminAddress = hddAddress.Value;
        admin.AdminPhone = hddPhone.Value;
        admin.AdminNickYahoo = hddNickYahoo.Value;
        admin.AdminNickSkype = hddNickSkype.Value;
        admin.AdminAvatar = hddImageThumb.Value;
        admin.AdminSex = Convert.ToBoolean(hddSex.Value);
        admin.AdminBirth = Convert.ToDateTime(hddBirth.Value);



        return admin;
    }
    #endregion

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            AdminBSO adminBSO = new AdminBSO();
            int ret = adminBSO.ChangePass(new SecurityBSO().EncPwd(News_Pass.Text.Trim()), new SecurityBSO().EncPwd(txtOldPass.Text.Trim()), m_UserValidation.UserId);
            if (ret > 0)
                clientview.Text = "<div class='alert alert-sm alert-success bg-gradient'>Đổi mật khẩu thành công !</div>";
            else
            {
                clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Đổi mật khẩu không thành công. Vui lòng thử lại hoặc liên hệ bộ phận quản trị !</div>";
            }
            initControl();
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }
}
