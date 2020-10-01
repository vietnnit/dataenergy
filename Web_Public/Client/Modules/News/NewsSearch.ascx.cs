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
public partial class Client_NewsSearch : System.Web.UI.UserControl
{
    PagingInfo _page = new PagingInfo(20, 1, true);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["keyword"] != null)
        {
            ViewNewsResult(Session["keyword"].ToString());

            Page.Title = Session["keyword"].ToString();

            System.Web.UI.HtmlControls.HtmlMeta _descrip = new HtmlMeta();
            _descrip.Name = "description";
            _descrip.Content = Session["keyword"].ToString();

            Page.Header.Controls.Add(_descrip);

            System.Web.UI.HtmlControls.HtmlMeta _keyWords = new HtmlMeta();
            _keyWords.Name = "keywords";
            _keyWords.Content = Session["keyword"].ToString();

            Page.Header.Controls.Add(_keyWords);
        }
        else
        {
            Page.Title = Resources.resource.T_Search_text1;

            System.Web.UI.HtmlControls.HtmlMeta _descrip = new HtmlMeta();
            _descrip.Name = "description";
            _descrip.Content = Resources.resource.T_Search_text1;

            Page.Header.Controls.Add(_descrip);

            System.Web.UI.HtmlControls.HtmlMeta _keyWords = new HtmlMeta();
            _keyWords.Name = "keywords";
            _keyWords.Content = Resources.resource.T_Search_text1;

            Page.Header.Controls.Add(_keyWords);
        }



    }
    private void ViewNewsResult(string keyword)
    {
        int gId = 0;
        if (!String.IsNullOrEmpty(Request["gId"]))
            int.TryParse(Request["gId"], out gId);

        int cId = 0;
        if (!String.IsNullOrEmpty(Request["cId"]))
            int.TryParse(Request["cId"], out cId);


        string _finter = "";
        NewsGroupBSO newsBSO = new NewsGroupBSO();

        if (keyword.Trim() != "" && GetString(keyword) == Request["keyword_news"].ToString())
        {

            string[] _keyws = keyword.Split(' ');
            if (_keyws != null)
            {
                if (_keyws.Length > 0)
                {

                    foreach (string _key in _keyws)
                    {
                        _finter += " AND (Title like N'%" + _key + "%'";
                        _finter += " or Keyword like N'%" + _key + "%'";
                        _finter += " or ShortDescribe like N'%" + _key + "%'" + ")";
                    }
                    _finter += " And isDelete=0 And Status =1 And IsApproval=1 And ParentNewsID=0 " + " AND Language = '" + Language.language + "'";
                    if (gId != 0)
                        _finter += " And GroupCate = " + gId;

                    if (cId != 0)
                        _finter += " And CateNewsID = " + cId;

                    DateTime dtNow = DateTime.Now;


                    _page = new PagingInfo(10, Convert.ToInt32(hdnPage.Value), true);

                    DataTable _tb = newsBSO.NewsGroupSearchPaging(_finter, _page);
                    if (_tb != null)
                    {
                        if (_tb.Rows.Count > 0)
                        {
                            TotalRecord = Convert.ToInt32(_tb.Rows[0]["Total"].ToString());
                            SetAttributeGvArticle(Convert.ToInt32(_tb.Rows[0]["Total"].ToString()));

                            rptListNewsGroup.DataSource = _tb;
                            rptListNewsGroup.DataBind();

                            Paging.DataLoad();
                            if (TotalPage(Convert.ToInt32(_tb.Rows[0]["Total"].ToString())) <= 1)
                            {
                                Paging.Visible = false;
                                box_paging.Visible = false;
                            }
                            else
                            {
                                Paging.Visible = true;
                                box_paging.Visible = true;
                            }
                        }
                        else
                        {

                            SetAttributeGvArticle(0);
                            Paging.Visible = false;
                            box_paging.Visible = false;
                            ltlResult.Text = "<div class='alert alert-danger fade in'>" + Resources.resource.T_Search_no_result + "</div>";
                        }
                    }
                }
            }
        }
        else
        {
            Session.Remove("keyword");
        }


    }
    

    public void Paging_Click(object sender, CommandEventArgs e)
    {

        string CurrentPage = e.CommandArgument.ToString();
        hdnPage.Value = CurrentPage;
        _page = new PagingInfo(10, Convert.ToInt32(hdnPage.Value), true);
        ViewNewsResult(Session["keyword"].ToString());

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
