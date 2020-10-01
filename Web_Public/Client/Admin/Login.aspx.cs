using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using ETO;
using DAO;
using BSO;
using System.Security.Cryptography;

public partial class Client_Admin_Login : System.Web.UI.Page
{
    UserValidation m_UserValidation = new UserValidation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SecurityBSO securityBSO = new SecurityBSO();            
            //ltTitle.Text = securityBSO.EncPwd("abc123");
            //BindYear();
            if (this.m_UserValidation.IsSigned())
                this.Response.Redirect("~/Admin/home/Default.aspx");
        }
    }

    #region CheckLogin
    public bool CheckLogin()
    {
        AdminBSO adminBSO = new AdminBSO();
        return adminBSO.CheckLoginAdmin(txtAdminUser.Text.Trim(), txtAdminPass.Text.Trim());
    }
    #endregion

    #region CheckUserName
    public bool CheckUserName()
    {
        AdminBSO adminBSO = new AdminBSO();
        return adminBSO.CheckUserName(txtAdminUser.Text.Trim());
    }
    #endregion

    protected void BindYear()
    {
        for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 20; i--)
            ddlYear.Items.Add(new ListItem("Năm " + i, i.ToString()));        
        ddlYear.SelectedValue = (DateTime.Now.Year - 1).ToString();
    }
    protected void btn_sumit1_Click1(object sender, EventArgs e)
    {
        if (CheckUserName() == true)
        {
            AdminBSO adminBSO = new AdminBSO();            
            Admin objUser = adminBSO.GetAdminByAccountPass(txtAdminUser.Text.Trim(), txtAdminPass.Text.Trim());

            if (objUser != null)
            {
                if (objUser.AdminActive == false)
                {
                    Tool.Message(this.Page, "Tài khoản này chưa được kích hoạt! Xin liên hệ với quản trị hệ thống");
                    return;
                }
                else
                {

                    m_UserValidation.SignIn(txtAdminUser.Text.Trim(), objUser.AdminID.ToString(), objUser.AdminOrganizationId, Session.SessionID, ((objUser.AdminName == "administrator") ? true : false));

                    Session["Admin_Username"] = txtAdminUser.Text.Trim();
                    adminBSO.UpdateAdminLog(Session["Admin_Username"].ToString(), DateTime.Now);

                    HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
                    cookie_lang = new HttpCookie("LangInfo_CMS");
                    cookie_lang["Lang"] = ddlLanguage.SelectedValue.ToString();
                    cookie_lang.Expires = DateTime.Now.AddDays(60);
                    Response.Cookies.Add(cookie_lang);

                    Language.language = ddlLanguage.SelectedValue.ToString();

                    Response.Redirect("~/Admin/home/Default.aspx");
                }
            }
            else
            {
                Tool.Message(this.Page, "Lỗi: Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
                return;
            }

        }
        else
        {
            Tool.Message(this.Page, "Lỗi: Tài khoản không tồn tại! Xin vui lòng nhập lại");
            return;

        }
    }
}
