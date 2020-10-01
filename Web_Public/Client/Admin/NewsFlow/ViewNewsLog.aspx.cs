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
public partial class Client_Admin_ViewNewsLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!IsPostBack)
            ViewNews(Id);
    }

    #region ViewNews
    private void ViewNews(int Id)
    {
        NewsLogBSO newsLogBSO = new NewsLogBSO();
        NewsLog newsLog = newsLogBSO.GetNewsLogById(Id);
        if (newsLog != null)
        {
            ltlTitle.Text = newsLog.Title;
            LabelDate.Text = newsLog.PostDate.ToString("dd/MM/yyyy");// Convert.ToString(newsLog.PostDate);
            ltlDescribe.Text = newsLog.ShortDescribe;
            FullDescirbe.Text = newsLog.FullDescribe;
            LabelAuthor.Text = newsLog.Author;

            //if (newsLog.ImageThumb != "")
            //    ltlImageThumb.Text = @"<img src='" + ResolveUrl("~/") + "Upload/newsLog/newsLogThumb/" + newsLog.ImageThumb + "' align='left' class='border_image' width='250'  >";

        }
    }
    #endregion
}
