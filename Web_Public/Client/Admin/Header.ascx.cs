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

public partial class Client_Admin_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin_Username"] != null)
        {
            lblLogin.Text = "Quản trị";
        }
        else
        {
            lblLogin.Text = "Đăng nhập";
        }

        if (!string.IsNullOrEmpty(Request["dll"]))
        {
            if (Request["dll"].Equals("login"))
                div_welcome.Visible = false;
            else
                div_welcome.Visible = true;
        }
    }

    protected void linkRemoveCache_Click(object sender, EventArgs e)
    {

        AspNetCache.Reset();
    }

}
