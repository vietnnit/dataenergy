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

public partial class HomePage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            form3.Action = Request.RawUrl;
            //lblDate.Text = "Ng�y " + DateTime.Now.ToString("dd/MM/yyy hh:mm tt");

        }
    }

    protected void linkRemoveCache_Click(object sender, EventArgs e)
    {

        AspNetCache.Reset();
    }
}
