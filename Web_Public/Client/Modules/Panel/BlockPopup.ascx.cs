﻿using System;
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
using ETO;
using BSO;

public partial class Client_BlockPopup : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Viewpopup();
    }
    private void Viewpopup()
    {
        ConfigBSO configBSO = new ConfigBSO();
        Config config = configBSO.GetAllConfig(Language.language);
        ltlPopup.Text = config.Popup;
    }
}
