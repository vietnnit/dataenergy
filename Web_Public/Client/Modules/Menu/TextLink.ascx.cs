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
public partial class Client_TextLink : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewCopy(Language.language);

    }
    private void ViewCopy(string lang)
    {
  
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

        ltlLink.Text = config.Info2;
    }
}