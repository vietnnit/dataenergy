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
public partial class Client_NewsTagsList : System.Web.UI.UserControl
{
    PagingInfo _page = new PagingInfo(20, 1, true);

    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["g"]))
            int.TryParse(Request["g"], out Id);

        hddTags.Value = Convert.ToString(Id);

        if (!IsPostBack)
        {
            GetNewsTagsList(Id);

        }
    }
    private void GetNewsTagsList(int Id)
    {

        DataTable table1 = new DataTable();
        DateTime dtNow = DateTime.Now;

        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);

        NewsGroupBSO newsgroupBSO = new NewsGroupBSO();

        table1 = newsgroupBSO.GetNewsGroupPagingbyTagsApproved(Id, _page);


        if (table1.Rows.Count > 0)
        {
            TotalRecord = Convert.ToInt32(table1.Rows[0]["Total"].ToString());
            SetAttributeGvArticle(Convert.ToInt32(table1.Rows[0]["Total"].ToString()));

            rptListNewsGroup.DataSource = table1;
            rptListNewsGroup.DataBind();

            Paging.DataLoad();
            if (TotalPage(Convert.ToInt32(table1.Rows[0]["Total"].ToString())) <= 1)
            {
                Paging.Visible = false;
            }
            else
            {
                Paging.Visible = true;
            }
        }
        else
        {
            SetAttributeGvArticle(0);
            Paging.Visible = false;
        }

     //   ltlListCateNews.Text = text1;


        //title_cate.Text = "&nbsp;";

    
    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {

        string CurrentPage = e.CommandArgument.ToString();
        hdnPage.Value = CurrentPage;
        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);
        GetNewsTagsList(Convert.ToInt32(hddTags.Value));

    }
    private void SetAttributeGvArticle(int totalRecord)
    {

        Paging.PageSize = Convert.ToInt32(_page.PageSize);
        Paging.TotalRecord = totalRecord;
        Paging.CurrentPage = Convert.ToInt32(hdnPage.Value);
        Paging.TotalNumberPaging = 5;
    }

    private long TotalPage(int total)
    {
        if (total % _page.PageSize == 0)
        {
            return total / _page.PageSize;
        }
        else
        {
            return total / _page.PageSize + 1;
        }
        //    return 0;
    }
    private int TotalRecord
    {
        get
        {
            if (ViewState["TotalRecord"] != null)
                return Convert.ToInt32(ViewState["TotalRecord"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TotalRecord"] = value;
        }
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
