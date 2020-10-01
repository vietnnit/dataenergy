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

public partial class Client_Admin_ForgetPass : System.Web.UI.Page
{
    UserValidation m_UserValidation = new UserValidation();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (this.m_UserValidation.IsSigned())
        //        this.Response.Redirect("~/Admin/home/Default.aspx");
        //}
    }

    protected void btn_GetPass_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();

        AdminBSO adminBSO = new AdminBSO();
        Admin admin = adminBSO.GetAdminByEmail(email);

       
        if (admin != null)
        {
            SecurityBSO securityBSO = new SecurityBSO();
            string oldpass = admin.AdminPass;
            string newpass = securityBSO.DecPwd(oldpass);

            Config config = new Config();
            if (AspNetCache.CheckCache("Config_" + Language.language) == false)
            {
                ConfigBSO configBSO = new ConfigBSO();

                config = configBSO.GetAllConfig(Language.language);
                AspNetCache.SetCacheWithTime("Config_" + Language.language, config, 150);
            }
            else
            {
                config = (Config)AspNetCache.GetCache("Config_" + Language.language);
            }

            MailBSO mailBSO = new MailBSO();
            mailBSO.EmailFrom = config.Email_from;

            string subject = "Mật khẩu tài khoản quản trị - " + config.WebName;
            string body = "Chào bạn :  " + admin.AdminFullName + "<br>";
            body += "Hệ thống quản trị - " + config.WebName + " thông báo mật khẩu hệ thống của bạn: <br>";
            body += "Tài khoản Email đăng nhập của bạn :  " + admin.AdminEmail + "<br>";
            body += "Mật khẩu đăng nhập hệ thống của bạn :  " + newpass;

            if (mailBSO.SendMail(email, subject, body) == true)
            {
                Tool.Message(this.Page, "Thông tin tài khoản đã được gửi tới Email của bạn!");
                return;
            }
            else
            {
                Tool.Message(this.Page, "Hệ thống Mail lỗi! Không thể gửi được thông tin tài khoản, vui lòng thử lại sau.");
                return;
            }
        }
        else
        {
            Tool.Message(this.Page, "Xin lỗi! Chúng tôi không tìm thấy tài khoản của bạn trong hệ thống");
            return;
        }
    }

    //#region CheckLogin
    //public bool CheckLogin()
    //{
    //    AdminBSO adminBSO = new AdminBSO();
    //    return adminBSO.CheckLoginAdmin(txtAdminUser.Text.Trim(), txtAdminPass.Text.Trim());
    //}
    //#endregion

    //#region CheckUserName
    //public bool CheckUserName()
    //{
    //    AdminBSO adminBSO = new AdminBSO();
    //    return adminBSO.CheckUserName(txtAdminUser.Text.Trim());
    //}
    //#endregion

    //protected void btn_sumit1_Click1(object sender, EventArgs e)
    //{
    //    if (CheckUserName() == true)
    //    {
    //AdminBSO adminBSO = new AdminBSO();
    //        //Admin admin = adminBSO.GetAdminById(txtAdminUser.Text.Trim());

    //Admin objUser = adminBSO.GetAdminByAccountPass(txtAdminUser.Text.Trim(), txtAdminPass.Text.Trim());

    //        if (objUser != null)
    //        {
    //            if (objUser.AdminActive == false)
    //            {
    //                Tool.Message(this.Page, "Tài khoản này chưa được kích hoạt! Xin liên hệ với quản trị hệ thống");
    //                return;
    //            }
    //            else
    //            {

    //                m_UserValidation.SignIn(txtAdminUser.Text.Trim(), objUser.AdminID.ToString(), false, Session.SessionID, ((objUser.AdminName == "administrator") ? true : false));

    //                Session["Admin_Username"] = txtAdminUser.Text.Trim();
    //                adminBSO.UpdateAdminLog(Session["Admin_Username"].ToString(), DateTime.Now);

    //                HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
    //                cookie_lang = new HttpCookie("LangInfo_CMS");
    //                cookie_lang["Lang"] = ddlLanguage.SelectedValue.ToString();
    //                cookie_lang.Expires = DateTime.Now.AddDays(1);
    //                Response.Cookies.Add(cookie_lang);

    //                Language.language = ddlLanguage.SelectedValue.ToString();

    //                Response.Redirect("~/Admin/home/Default.aspx");
    //            }
    //        }
    //        else
    //        {
    //            Tool.Message(this.Page, "Lỗi: Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
    //            return;
    //        }

    //        //if (CheckLogin() == true)
    //        //{

    //        //    Session["Admin_Username"] = txtAdminUser.Text.Trim();


    //        //    HttpCookie cookie = Request.Cookies["UserInfor_EVNTIT"];
    //        //    HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
    //        //    if (cookie == null)
    //        //    {
    //        //        cookie = new HttpCookie("UserInfor_EVNTIT");
    //        //        cookie["UserName"] = txtAdminUser.Text.Trim();
    //        //        //cookie["Password"]= MD5.Create(txtAdminPass.Text);
    //        //        cookie.Expires = DateTime.Now.AddDays(1);
    //        //        Response.Cookies.Add(cookie);
    //        //        adminBSO.UpdateAdminLog(cookie["UserName"].ToString(), DateTime.Now);

    //        //        cookie_lang = new HttpCookie("LangInfo_CMS");
    //        //        cookie_lang["Lang"] = ddlLanguage.SelectedValue.ToString();
    //        //        cookie_lang.Expires = DateTime.Now.AddDays(1);
    //        //        Response.Cookies.Add(cookie_lang);

    //        //        Language.language = ddlLanguage.SelectedValue.ToString();

    //        //        Response.Redirect("~/Admin/home/Default.aspx");
    //        //    }
    //        //    else
    //        //    {

    //        //        adminBSO.UpdateAdminLog(cookie["UserName"].ToString(), DateTime.Now);
    //        //        Response.Redirect("~/Admin/home/Default.aspx");
    //        //    }

    //        //}
    //        //else
    //        //{
    //        //    Tool.Message(this.Page, "Lỗi: Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
    //        //    return;
    //        //}



    //    }
    //    else
    //    {
    //        Tool.Message(this.Page, "Lỗi: Tài khoản không tồn tại! Xin vui lòng nhập lại");
    //        return;

    //    }
    //}
}
