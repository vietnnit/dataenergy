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
using DAO;
using BSO;
using ePower.DE.Service;
using System.Collections.Generic;
using ePower.DE.Domain;
using ReportEF;
using System.Linq;

public partial class Client_Modules_MemberLogin : System.Web.UI.UserControl
{
    MemberValidation memberVal = new MemberValidation();
    string ReturnUrl
    {
        get
        {
            if (ViewState["ReturnUrl"] != null)
                return ViewState["ReturnUrl"].ToString();
            else return "";

        }
        set { ViewState["ReturnUrl"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Request.QueryString["RetUrl"] != null && Request.QueryString["RetUrl"] != "")
            //    ReturnUrl = Request.QueryString["RetUrl"];
            //HttpCookie cookie = Request.Cookies["UserInfor_EVNTIT"];
            //if (m_UserValidation.IsSigned())
            //{
            //    if (ReturnUrl != "")
            //        Response.Redirect("~" + ReturnUrl);
            //    else
            //        Response.Redirect("~");
            //}
            //else
            //{
            //    string err = Request.QueryString.Get("error");
            //    if (err == "1")
            //        error.Text = Resources.resource.Login_Err;
            //    if (err == "2")
            //        error.Text = Resources.resource.Login_Err_Exit;
            //}
            if (memberVal.IsSigned())
            {
                //error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Đã đăng nhập thành công</div>";
                plUser.Visible = true;
                plLogin.Visible = false;
                lblTitle.Text = "Thông tin doanh nghiệp";
                ReportModels reportModels = new ReportModels();
                var eInfo = reportModels.DE_Enterprise.First(o => o.Id == memberVal.OrgId);
                if (string.IsNullOrEmpty(eInfo.TaxCode))
                    ltAccountName.Text = memberVal.UserName;
                else
                    ltAccountName.Text = eInfo.TaxCode;

                BindUserName(memberVal.OrgId);

            }
            else
            {
                plUser.Visible = false;
                plLogin.Visible = true;
                lblTitle.Text = "Doanh nghiệp đăng nhập";
            }

        }


    }

    private void BindUserName(int OrgId)
    {
        if (OrgId > 0)
        {
            EnterpriseService objlogic = new EnterpriseService();
            Enterprise obj = new Enterprise();
            obj = objlogic.FindByKey(OrgId);
            if (obj != null)
            {
                lblName.Text = obj.Title;

                lblEmail.Text = obj.Email;
                lblAddress.Text = obj.Address;
                lblTel.Text = obj.Phone;

            }
        }

    }
    protected void btnMember_Click(object sender, EventArgs e)
    {
        if (txtAdminUser11.Text != "" && txtAdminPass11.Text != "")
        {
            MemberService adminBSO = new MemberService();

            IList<ePower.DE.Domain.Member> list = adminBSO.MemberLogin(txtAdminUser11.Text.Trim(), new SecurityBSO().EncPwd(txtAdminPass11.Text));

            if (list != null && list.Count > 0)
            {
                memberVal.SignIn(list[0].AccountName, list[0].Id.ToString(), list[0].EnterpriseId.ToString(), true, this.Session.SessionID);
                if (list[0].EnterpriseId > 0)
                {
                    ePower.DE.Domain.Enterprise enter = new EnterpriseService().FindByKey(list[0].EnterpriseId);
                    if (enter.IsConfirm)
                    {
                        Response.Redirect(ResolveUrl("~") + "Doanh-nghiep.aspx");
                    }
                    else
                    {
                        Response.Redirect(ResolveUrl("~") + "thong-tin-doanh-nghiep.aspx");
                    }
                }
            }
            else
            {
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient p5 mbn '>Tài khoản hoặc mật khẩu không đúng.<br/>Vui lòng kiểm tra lại</div>";
            }

        }
        else
        {
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient  p5 mbn '>Tài khoản hoặc mật khẩu không đúng.<br/>Vui lòng kiểm tra lại</div>";
        }
    }
    protected void btn_signout_Click(object sender, EventArgs e)
    {
        memberVal.SignOut();
        Response.Redirect("~/Default.aspx");
    }

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        if (CheckUserName(txtAdminUser11.Text.Trim()) == true)
        {
            AdminBSO adminBSO = new AdminBSO();
            //Admin admin = adminBSO.GetAdminById(txtAdminUser.Text.Trim());

            Admin objUser = adminBSO.GetAdminByAccountPass(txtAdminUser11.Text.Trim(), txtAdminPass11.Text.Trim());

            if (objUser != null)
            {
                if (objUser.AdminActive == false)
                {
                    error.Text = "<div class='alert alert-sm alert-danger bg-gradient p5 mbn '>Tài khoản này chưa được kích hoạt! Xin liên hệ với quản trị hệ thống.</div>";
                }
                else
                {

                    //m_UserValidation.SignIn(txtAdminUser11.Text.Trim(), objUser.AdminID.ToString(), objUser.AdminOrganizationId, Session.SessionID,false);

                    Session["Admin_Username"] = txtAdminUser11.Text.Trim();
                    adminBSO.UpdateAdminLog(Session["Admin_Username"].ToString(), DateTime.Now);

                    HttpCookie cookie_lang = Request.Cookies["LangInfo_CMS"];
                    cookie_lang = new HttpCookie("LangInfo_CMS");
                    cookie_lang["Lang"] = "vi-VN";
                    Response.Cookies.Add(cookie_lang);

                    Language.language = "vi-VN";

                    Response.Redirect("~/Admin/home/Default.aspx");
                }
            }
            else
            {
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient p5 mbn '>Lỗi: Tài khoản hoặc mật khẩu không đúng! Xin vui lòng nhập lại.</div>";
            }

        }
        else
        {
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient p5 mbn '>Lỗi: Tài khoản không tồn tại! Xin vui lòng nhập lại.</div>";
        }
    }

    #region CheckUserName
    public bool CheckUserName(string username)
    {
        AdminBSO adminBSO = new AdminBSO();
        return adminBSO.CheckUserName(username);
    }
    #endregion
}
