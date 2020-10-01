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

public partial class Client_Admin_BlockWelCome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {

            HttpCookie cookie = Request.Cookies["UserInfor_EVNTIT"];
            if (cookie != null && cookie["UserName"] != null && cookie["UserName"].Trim() != string.Empty)
            {
                welcomAdmin.Text = cookie["UserName"].Trim();
            }   

          
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        HttpCookie cookie = HttpContext.Current.Request.Cookies["UserInfor_EVNTIT"];
        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddDays(-10);
            cookie.Value = "";
            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        Session.RemoveAll();
        Session.Abandon();

        Response.Redirect("~/Default.aspx");
    }

   
}
