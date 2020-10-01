using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;

public partial class Client_Skin_HomePage_Navigation : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblTitle.Text = Navigation.TitleName;
        TitleCate.Text = Navigation.TitleCate;
    }
}