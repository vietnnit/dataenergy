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
using DAO;
public partial class Client_PrintNewsGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request.QueryString.Get("Id")))
            int.TryParse(Request.QueryString.Get("Id"), out Id);
        //     int.TryParse(Request.QueryString.Get("Id").Replace(",", ""), out Id);
        initPrint(Id);
    }

    #region initPrint
    protected void initPrint(int Id)
    {
        NewsGroupBSO newsBSO = new NewsGroupBSO();
        NewsGroup news = newsBSO.GetNewsGroupById(Id);
        if (news != null)
        {
            ltlTitle.Text = news.Title;
            LabelDate.Text = news.PostDate.ToString("dd/MM/yyyy");// Convert.ToString(news.PostDate);
            //ltlDescribe.Text = news.ShortDescribe;
            FullDescirbe.Text = news.FullDescribe;
            LabelAuthor.Text = news.Author;
            txtNewsGroupID.Value = Convert.ToString(news.NewsGroupID);
            //if (news.ImageThumb != "")
            //    ltlImageThumb.Text = @"<img src='../Upload/NewsGroup/NewsGroupThumb/" + news.ImageThumb + "' align='left' class='border_image' width='250'  >";
            Page.Title = GetString(news.Title);
        }

    }
    #endregion


    protected void btn_finish(object sender, EventArgs e)
    {
        NewsGroupBSO newsBSO = new NewsGroupBSO();
        NewsGroup news = newsBSO.GetNewsGroupById(Convert.ToInt32(Request.QueryString.Get("Id")));

        Response.Redirect(ResolveUrl("~/")+ "d4/" + GetString(news.Title) + "-" + news.GroupCate + "-" + news.NewsGroupID + ".aspx");
    }

    protected void btn_print(object sender, EventArgs e)
    {
        //  Session["ctrl"] = Panel1;
        //  ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintOrder.aspx','PrintMe','height=600px,width=800px,scrollbars=1');</script>");
        //    Control ctrl = (Control)Session["ctrl"];
        //   PrintHelper.PrintWebControl();

        Session["ctrl"] = Panel_NewsGroup;
        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintNewsPreview.aspx','PrintMe','height=700px,width=810px,scrollbars=1');</script>");
    }

    protected string GetString(object _txt)
    {
        if (_txt != null)
        {
            Utils objUtil = new Utils();
            return objUtil.Getstring(_txt.ToString());
        }
        return "";
    }
}
