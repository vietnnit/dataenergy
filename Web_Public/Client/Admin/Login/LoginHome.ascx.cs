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
using BSO;
using ETO;
using ePower.Core;
using ePower.Core.Web;

public partial class Admin_LoginHome : System.Web.UI.UserControl
{
    private ICultureResolver cultureResolver = new DefaultWebCultureResolver();
    UserValidation m_UserValidation = new UserValidation();
    //string isLDAP = ConfigurationManager.AppSettings.Get["isLDAP"].ToString();
    //string ConnString = ConfigurationManager.AppSettings.Get("Connection_String_Eoffice");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginCount"] == null)
        {
            Session["LoginCount"] = "0";
            capcha_panel.Visible = false;
        }
        else
            if (Convert.ToInt32(Session["LoginCount"].ToString()) > 3)
                capcha_panel.Visible = true;
            else
                capcha_panel.Visible = false;

        if (!IsPostBack)
        {

            if (m_UserValidation.IsSigned())
            {
                Response.Redirect(ResolveUrl("~/") + "Default.aspx");
            }
        }
    }
    private string GetIpAddress()
    {
        return HttpContext.Current.Request.UserHostAddress;
    }

    protected void btn_sumit_Click(object sender, EventArgs e)
    {
        AdminBSO adminBSO = new AdminBSO();
        if (Session["LoginCount"] != null)
            Session["LoginCount"] = Convert.ToInt32(Session["LoginCount"].ToString()) + 1;
        int n = Convert.ToInt32(Session["LoginCount"].ToString());
        if (!txtAdminUser.Text.Contains("\\"))
        {

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
                    //ducnmi - capcha
                    if (Convert.ToInt32(Session["LoginCount"].ToString()) > 3)
                    {
                        if (Session["Random"] != null && txtCapcha.Text.ToLower() == Session["Random"].ToString().ToLower())
                        {
                            Session["LoginCount"] = null;
                        }
                        else
                        {
                            Tool.Message(this.Page, "Mã xác nhận sai!");
                            return;
                        }

                    }

                    m_UserValidation.SignIn(txtAdminUser.Text.Trim(), objUser.AdminID.ToString(), objUser.AdminOrganizationId, Session.SessionID, ((objUser.AdminName == "administrator") ? true : false));

                    if (Request.QueryString["url"] != null && Request.QueryString["url"] != string.Empty)
                        Response.Redirect((Request.QueryString["url"]));
                    else
                        Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                Tool.Message(this.Page, "Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
                return;
            }
        }
        else
        {
            if (ConfigurationManager.AppSettings.Get("isLDAP").ToString() == "1")
            {
                //Path to your LDAP directory server
                string adPath = ConfigurationManager.AppSettings.Get("LdapDomain").ToString();

                LdapAuthentication adAuth = new LdapAuthentication(adPath);
                try
                {
                    if (txtAdminUser.Text.IndexOf("\\") > 0)
                    {
                        string domainName = txtAdminUser.Text.Substring(0, txtAdminUser.Text.IndexOf("\\"));
                        if (adAuth.IsAuthenticated(txtAdminUser.Text.Substring(0, txtAdminUser.Text.IndexOf("\\")), txtAdminUser.Text.Substring(txtAdminUser.Text.IndexOf("\\") + 1), txtAdminPass.Text))
                        {
                            Admin user = adminBSO.GetAdminById(txtAdminUser.Text.Trim());
                            if (user != null)
                            {
                                //ducnmi - capcha
                                if (Convert.ToInt32(Session["LoginCount"].ToString()) > 3)
                                {
                                    if (txtCapcha.Text.ToLower() == Session["Random"].ToString().ToLower())
                                    {
                                        Session["LoginCount"] = null;
                                    }
                                    else
                                    {
                                        Tool.Message(this.Page, "Mã xác nhận sai!");
                                        return;
                                    }

                                }

                                m_UserValidation.SignIn(txtAdminUser.Text.Trim(), user.AdminID.ToString(), user.AdminOrganizationId, Session.SessionID, ((user.AdminName == "administrator") ? true : false));
                                //string groups = adAuth.GetGroups();
                                ////Create the ticket, and add the groups.
                                //bool isCookiePersistent = true;
                                //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                                //          txtAdminUser.Text.Substring(txtAdminUser.Text.IndexOf("\\") + 1), DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, groups);

                                ////Encrypt the ticket.
                                //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                                ////Create a cookie, and then add the encrypted ticket to the cookie as data.
                                //HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                                //if (true == isCookiePersistent)
                                //    authCookie.Expires = authTicket.Expiration;

                                ////Add the cookie to the outgoing cookies collection.
                                //Response.Cookies.Add(authCookie);

                                if (Request.QueryString["url"] != null && Request.QueryString["url"] != string.Empty)
                                    Response.Redirect((Request.QueryString["url"]));
                                else
                                    Response.Redirect(Request.RawUrl);
                            }
                            else
                            {
                                Tool.Message(this.Page, "Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
                                return;
                            }
                        }
                        else
                        {
                            Tool.Message(this.Page, "Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Tool.Message(this.Page, "Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
                    return;
                }
            }
            else
            {
                string sTen_TCap = this.Get_DomainAccount();

                if (sTen_TCap != "")
                {
                    string text1 = this.txtAdminUser.Text;
                    string str = "";
                    str = text1;
                    string[] strArray = text1.Split(new char[1] { '\\' });
                    string lpszDomain;
                    string lpszUsername;
                    if (strArray.Length == 2)
                    {
                        lpszDomain = strArray[0];
                        lpszUsername = strArray[1];
                    }
                    else
                    {
                        lpszDomain = ((object)ConfigurationManager.AppSettings.Get("DomainName")).ToString();
                        lpszUsername = text1;
                    }

                    //Tool.Message(this.Page, "TK1: " + lpszDomain +"\\"+lpszUsername );

                    Admin user = adminBSO.GetAdminById(txtAdminUser.Text.Trim());
                    // User user = new UserService().FindByUserName(this.txtAdminUser.Text);
                    if (user != null)
                    {
                        //ducnmi - capcha
                        if (Convert.ToInt32(Session["LoginCount"].ToString()) > 3)
                        {
                            if (txtCapcha.Text.ToLower() == Session["Random"].ToString().ToLower())
                            {
                                Session["LoginCount"] = null;
                            }
                            else
                            {
                                Tool.Message(this.Page, "Mã xác nhận sai!");
                                return;
                            }

                        }

                        m_UserValidation.SignIn(txtAdminUser.Text.Trim(), user.AdminID.ToString(), user.AdminOrganizationId, Session.SessionID, ((user.AdminName == "administrator") ? true : false));


                        if (Request.QueryString["url"] != null && Request.QueryString["url"] != string.Empty)
                            Response.Redirect((Request.QueryString["url"]));
                        else
                            Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        Tool.Message(this.Page, "Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
                        return;
                    }
                }
                else
                {
                    Tool.Message(this.Page, "Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại");
                    return;
                }
            }
        }
    }
    //Lost password
    protected void btnGetPass_Click(object sender, EventArgs e)
    {
        //if (txtAdminUser.Text.Trim() == "")
        //{
        //    Tool.Message(this.Page, "Xin vui lòng nhập tên tài khoản để thực hiện chức năng này");
        //    return;
        //}
        //UserService objLogic = new UserService();
        //Guid g = Guid.NewGuid();
        //string newpass = g.ToString().Replace("-", "").PadLeft(10);
        //User objUser = objLogic.LostPassword(txtAdminUser.Text.Trim(), newpass, true);
        //if (objUser != null)
        //{
        //    if (objUser.Email != null && objUser.Email != "")
        //    {
        //        //Tool objTool = new Tool();
        //        //objTool.SendMail(objUser.Email, "", "Thông báo", "Acount:" + objUser.Account + " pass:" + objUser.Pass);
        //        Tool.Message(this.Page, "Đã gửi thông tin tài khoản của bạn vào Email:" + objUser.Email);
        //    }
        //    else
        //    {
        //        Tool.Message(this.Page, "Bạn không có địa chỉ Email nên hệ thống không thực hiện gửi mật khẩu được. Đề nghị liên hệ với quản trị hệ thống để cấp lại mật khẩu. Điện thoại: 04.2222 5210 (674)");
        //        return;
        //    }
        //}
        //else
        //{
        //    Tool.Message(this.Page, "Tài khoản này không tồn tại.");
        //    return;
        //}
    }
    private string Get_DomainAccount()
    {
        string text1 = this.txtAdminUser.Text;
        string str = "";
        str = text1;
        string[] strArray = text1.Split(new char[1] { '\\' });
        string lpszDomain;
        string lpszUsername;
        if (strArray.Length == 2)
        {
            lpszDomain = strArray[0];
            lpszUsername = strArray[1];
        }
        else
        {
            lpszDomain = ((object)ConfigurationManager.AppSettings.Get("DomainName")).ToString();
            lpszUsername = text1;
        }
        string text2 = this.txtAdminPass.Text;
        IntPtr pExistingTokenHandle = new IntPtr(0);
        if (CheckAcc.LogonUser(lpszUsername, lpszDomain, text2, 3, 0, ref pExistingTokenHandle))
        {
            if (int.Parse(((object)ConfigurationManager.AppSettings.Get("Multi_Domain_Trusted")).ToString()) == 1)
                lpszUsername = lpszDomain + "\\" + lpszUsername;
        }
        else
            lpszUsername = "";
        return lpszUsername;
    }

}
