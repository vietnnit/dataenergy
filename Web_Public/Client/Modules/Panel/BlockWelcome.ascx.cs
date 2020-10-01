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
using ETO;
using BSO;
public partial class Client_BlockWelcome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewTextMarquee();
    }
    private void ViewTextMarquee()
    {
        ConfigBSO configBSO = new ConfigBSO();
        Config config = configBSO.GetAllConfig(Language.language);

        ltlTextMarquee.Text = config.Intro_desc;
        //DataTable table = new DataTable();
        //table.Columns.Add("data");
        //DataRow datarow = table.NewRow();
        //DataRow datarow1 = table.NewRow();
        //datarow["data"] = config.Intro_desc;
        //datarow1["data"] = config.Intro_desc;

        //table.Rows.Add(datarow);
        //table.Rows.Add(datarow1);

        //Rotator1.DataSource = table;
        //Rotator1.DataBind();

    }
}