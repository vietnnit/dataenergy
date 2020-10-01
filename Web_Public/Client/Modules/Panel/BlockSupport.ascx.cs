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
using BSO;
public partial class Client_BlockSupport : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewSupport();
    }
    private void ViewSupport()
    {
        ConfigBSO configBSO = new ConfigBSO();
        Config config = configBSO.GetAllConfig(Language.language);
        ltlSupport.Text = config.Support;
    }
}
