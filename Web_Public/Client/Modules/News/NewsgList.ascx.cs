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
public partial class Client_NewsgList : System.Web.UI.UserControl
{
    private PagingInfo _page = new PagingInfo(10, 1, true);
    protected void Page_Load(object sender, EventArgs e)
    {
        int cId = 0;
        if (!String.IsNullOrEmpty(Request["cid"]))
            int.TryParse(Request["cid"], out cId);
        int gId = 0;
        if (!String.IsNullOrEmpty(Request["g"]))
            int.TryParse(Request["g"], out gId);

        hddGroupCate.Value = Convert.ToString(gId);
        hddCateID.Value = Convert.ToString(cId);

        if (!IsPostBack)
        {

            CateNewsGroupBSO cateNewsGroupBso = new CateNewsGroupBSO();
            CateNewsBSO cateNewsBso = new CateNewsBSO();
            CateNews cateNewsById = cateNewsBso.GetCateNewsById(cId);

            CateNewsGroup groupByGroupCate = cateNewsGroupBso.GetCateNewsGroupByGroupCate(gId, Language.language);

            if (groupByGroupCate != null && cateNewsById != null)
            {

                GetHotNewsGroup(cId, gId);
                GetCateParentNewsGroup(cId, gId);

                title_name.Text = cateNewsById.CateNewsName;

                string cate = "<a href='" + ResolveUrl("~/") + "c2/" + cateNewsGroupBso.GetSlugById(groupByGroupCate.CateNewsGroupID) + "/" + GetString(groupByGroupCate.CateNewsGroupName) + "-" + cateNewsById.GroupCate + ".aspx' class='content_Text_Cat' title='" + groupByGroupCate.CateNewsGroupName + "'>";
                string s1 = "";
                while (cateNewsById.ParentNewsID != 0)
                {
                    int parentNewsId = cateNewsById.ParentNewsID;
                    cateNewsById = cateNewsBso.GetCateNewsById(parentNewsId);
                    s1 = "<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png' ><a href='" + ResolveUrl("~/") + "c3/" + cateNewsBso.GetSlugByCateId(cateNewsById.CateNewsID) + "/" + GetString(cateNewsById.CateNewsName) + "-" + cateNewsById.GroupCate + "-" + cateNewsById.CateNewsID + ".aspx' class='content_Text_Cat' title='" + cateNewsById.CateNewsName + "'>" + cateNewsById.CateNewsName + "</a>" + s1;
                }

                cate += groupByGroupCate.CateNewsGroupName.ToString() + "</a> " + s1;
                title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.T_home + "</a> <img src='" + ResolveUrl("~/") + "images/icon_arrows1.png' >";
                title_cate.Text += cate;

                Page.Title = cateNewsById.CateNewsName ;

                System.Web.UI.HtmlControls.HtmlMeta _descrip = new HtmlMeta();
                _descrip.Name = "description";
                _descrip.Content = cateNewsById.CateNewsName ;

                Page.Header.Controls.Add(_descrip);

                System.Web.UI.HtmlControls.HtmlMeta _keyWords = new HtmlMeta();
                _keyWords.Name = "keywords";
                _keyWords.Content = GetString(cateNewsById.CateNewsName) ;

                Page.Header.Controls.Add(_keyWords);
            }
            else if (cId == 0)
            {
                if (groupByGroupCate != null)
                {
                    GetHotNewsGroup(cId, gId);
                    GetCateParentNewsGroup(cId, gId);

                    //title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>TRANG CHỦ</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";

                    title_name.Text = groupByGroupCate.CateNewsGroupName;


                    Page.Title = title_name.Text;

                    System.Web.UI.HtmlControls.HtmlMeta _descrip = new HtmlMeta();
                    _descrip.Name = "description";
                    _descrip.Content = title_name.Text;

                    Page.Header.Controls.Add(_descrip);

                    System.Web.UI.HtmlControls.HtmlMeta _keyWords = new HtmlMeta();
                    _keyWords.Name = "keywords";
                    _keyWords.Content = GetString(title_name.Text);

                    Page.Header.Controls.Add(_keyWords);
                }
            }
        }


    }

    private void GetHotNewsGroup(int cId, int gId)
    {
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        DataTable dataTable = new DataTable();
        if (!AspNetCache.CheckCache("HTML_ltlHotNewsCateGroup_Group1_" + gId + "_" + cId))
        {
            string strCate = this.GetCateParentIDArrayByID(cId, gId);
            dataTable = newsGroupBSO.GetNewsGroupByCateHot(strCate, gId, "1", 4, "1", "1");

            AspNetCache.SetCacheWithTime("HTML_ltlHotNewsCateGroup_Group1_" + gId + "_" + cId, dataTable, 150);
        }
        else
            dataTable = (DataTable)AspNetCache.GetCache("HTML_ltlHotNewsCateGroup_Group1_" + gId + "_" + cId);

        string text = "";
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow = dataTable.Rows[0];
            text += "<div class='box-content-main' style='padding:10px 0 0 0;'>";
            text += "<div class='box-hotnews'>";

            text += "<div class='headline'>";
            text += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";

            if (dataRow["ImageLarge"].ToString() != "")
            {
                text += "<img src='" + Utils.getURLThumbImage(dataRow["ImageLarge"].ToString(), 310) + "' width='300px' height='170px' alt='" + dataRow["Title"] + "'>";
            }
            else if (dataRow["ImageThumb"].ToString() != "")
            {
                text += "<img src='" + Utils.getURLThumbImage(dataRow["ImageThumb"].ToString(), 310) + "' width='300px' height='170px' alt='" + dataRow["Title"] + "'>";
            }

            text += "</a>";
            text += "</div>";
            text += "<div class='hotnews1-slider' style='margin-left: 320px;'>";
            text += "<div class='text-first'>";
            text += "<span>";

            text += "<a class='header-first' href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow["Title"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["NewsGroupID"].ToString() + ".aspx' title='" + dataRow["Title"] + "'>";

            text += dataRow["Title"].ToString();
            text += "</a></span> &nbsp;";
            text += "<span style='color:#6D6D6D; font-size: 12px;'>(" + Convert.ToDateTime(dataRow["PostDate"]).ToString("dd/MM/yyyy") + ")</span>";
            text += "<div class='richtext'>";
            text += "<p>";
            text += Tool.SubString(Tool.StripTagsCharArray(dataRow["ShortDescribe"].ToString()), 350);
            text += "</p>";
            text += "</div>";
            text += "</div>";
            for (int i = 1; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow2 = dataTable.Rows[i];
                text += "<div class='text-next'>";

                text += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow2["Title"]) + "-" + dataRow2["GroupCate"] + "-" + dataRow2["NewsGroupID"].ToString() + ".aspx' title='" + dataRow2["Title"] + "'>";

                text += dataRow2["Title"].ToString();
                text += "</a>";
                text += "</div>";
            }
            text += "</div>";
            text += "<div class='clear'></div>";
            text += "</div>";
            text += "</div>";
        }

        ltlHotNewsGroup.Text = text;

    }

    private void GetCateParentNewsGroup(int cId, int gId)
    {
        _page = new PagingInfo(15, Convert.ToInt32(hdnPage.Value), true);
        string strCate = this.GetCateParentIDArrayByID(cId, gId);

        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        DataTable newsGroupPaging = newsGroupBSO.GetNewsGroupPagingApproved(Language.language, Convert.ToInt32(hddGroupCate.Value), strCate, _page, 1, 1, 0, 1);
        if (newsGroupPaging.Rows.Count > 0)
        {
            TotalRecord = Convert.ToInt32(newsGroupPaging.Rows[0]["Total"].ToString());
            SetAttributeGvArticle(Convert.ToInt32(newsGroupPaging.Rows[0]["Total"].ToString()));
            rptListNewsGroup.DataSource = newsGroupPaging;
            rptListNewsGroup.DataBind();
            Paging.DataLoad();
            if (TotalPage(Convert.ToInt32(newsGroupPaging.Rows[0]["Total"].ToString())) <= 1L)
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
            panelDate.Visible = false;
        }


        CateNewsBSO cateNewsBSO = new CateNewsBSO();
        DataTable cateClientGroup = cateNewsBSO.getCateClientGroup(cId, Language.language, gId, 5);
        if (cateClientGroup.Rows.Count > 0)
        {
            tintuc_col1.Attributes.Add("class", "tintuc-col1");
            ViewListCate(cId, gId);
        }
        else
        {
            tintuc_col1.Attributes.Add("class", "tintuc-col-main");
            listNewsCatePanel.Visible = false;
        }


        PagingInfo paging = new PagingInfo(15, (Convert.ToInt32(hdnPage.Value) + 1), true);
        DataTable newsGroupPaging2 = newsGroupBSO.GetNewsGroupPagingApproved(Language.language, Convert.ToInt32(hddGroupCate.Value), strCate, paging, 1, 1, 0, 1);
        if (newsGroupPaging2.Rows.Count > 0)
        {
            newsOther.Visible = true;
            rptListNewsOther.DataSource = newsGroupPaging2;
            rptListNewsOther.DataBind();
            return;
        }
        newsOther.Visible = false;
    }

    private void ViewListCate(int cId, int gId)
    {
        if (!AspNetCache.CheckCache("HTML_ltlListNewsCatebyCate_" + gId + "_" + cId))
        {
            CateNewsBSO cateNewsBSO = new CateNewsBSO();
            DataTable cateClientGroup = cateNewsBSO.getCateClientGroup(cId, Language.language, gId, 6);
            string text = "";
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            DataTable dataTable = new DataTable();
            if (cateClientGroup.Rows.Count > 0 && cateClientGroup != null)
            {
                listNewsCatePanel.Visible = true;
                for (int i = 0; i < cateClientGroup.Rows.Count; i++)
                {
                    DataRow dataRow = cateClientGroup.Rows[i];
                    string cateParentIDArrayByID = GetCateParentIDArrayByID(Convert.ToInt32(dataRow["CateNewsID"]), gId);
                    dataTable = newsGroupBSO.GetNewsGroupByCateHomeList(cateParentIDArrayByID, gId, "1", 5, "1");

                    if (dataTable.Rows.Count > 0)
                    {
                        text += "<div class='r-ro'>";
                        text += "<div class='box-list-content-cate'>";
                        text += "<h2 class='h2'>";

                        text += "<a class='h2-cate' href='" + ResolveUrl("~/") + "c3/" + cateNewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"].ToString().Trim()) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx' title='" + dataRow["CateNewsName"].ToString().Trim() + "'>";
                        text += "<span>" + Tool.SubString(Tool.StripTagsCharArray(dataRow["CateNewsName"].ToString().Trim()), 20) + "</span></a>";

                        text += "</h2>";
                        text += "<div class='box-content-main-col-a'>";


                        DataRow dataRow2 = dataTable.Rows[0];
                        text += "<div class='box-tintuc-first'>";
                        text += "<div class='box-tintuc-image'>";

                        text += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow2["Title"]) + "-" + dataRow2["GroupCate"] + "-" + dataRow2["NewsGroupID"].ToString() + ".aspx' title='" + dataRow2["Title"] + "'>";
                        if (dataRow2["ImageLarge"].ToString() != "")
                        {

                            text += "<img class='box-tintuc-landscape' src='" + Utils.getURLThumbImage(dataRow2["ImageLarge"].ToString(), 175) + "' width='175px' height='110px' alt='" + dataRow2["Title"] + "'>";

                        }
                        else if (dataRow2["ImageThumb"].ToString() != "")
                        {

                            text += "<img class='box-tintuc-landscape' src='" + Utils.getURLThumbImage(dataRow2["ImageThumb"].ToString(), 175) + "' width='175px' height='110px' alt='" + dataRow2["Title"] + "'>";

                        }
                        //else
                        //{

                        //    text += "<img class='box-tintuc-landscape' src='" + ResolveUrl("~/") + "images/img_logo.jpg' width='205px' height='120px' alt='" + dataRow2["Title"] + "'>";

                        //}
                        text += "</a>";
                        text += "</div>";
                        text += "<div class='clear'></div>";
                        text += "<div class='box-tintuc-linkabs'>";

                        text += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow2["Title"]) + "-" + dataRow2["GroupCate"] + "-" + dataRow2["NewsGroupID"].ToString() + ".aspx' title='" + dataRow2["Title"] + "'>";

                        text += dataRow2["Title"].ToString();
                        text += "</a>";
                        text += "</div>";
                        text += "</div>";
                        text += "<div class='box-tintuc-linkother'>";
                        text += "<ul>";
                        for (int j = 1; j < dataTable.Rows.Count; j++)
                        {
                            DataRow dataRow3 = dataTable.Rows[j];
                            text += "<li class='ter'>";

                            text += "<a href='" + ResolveUrl("~/") + "d4/news/" + GetString(dataRow3["Title"]) + "-" + dataRow3["GroupCate"] + "-" + dataRow3["NewsGroupID"].ToString() + ".aspx' title='" + dataRow3["Title"] + "'>";

                            text += dataRow3["Title"].ToString();
                            text += "</a>";
                            text += "</li>";
                        }
                        text += "</ul></div>";

                        text += "</div>";
                        text += "</div>";
                        text += "</div>";
                    }
                }
            }
            else
            {
                listNewsCatePanel.Visible = false;
            }
            AspNetCache.SetCacheWithTime("HTML_ltlListNewsCatebyGroup_" + gId, text, 150.0);
            ltlListNewsCate.Text = text;

        }
        else
            ltlListNewsCate.Text = (string)AspNetCache.GetCache("HTML_ltlListNewsCatebyGroup_" + gId);

        if (ltlListNewsCate.Text != "")
        {
            tintuc_col1.Attributes.Add("class", "tintuc-col1");
            //   ViewListCate(cId, gId);
        }
        else
        {
            tintuc_col1.Attributes.Add("class", "tintuc-col-main");
            listNewsCatePanel.Visible = false;
        }
    }



    private string GetCateParentIDArrayByID(int cID, int gID)
    {
        string strArrayID = Convert.ToString(cID) + ",";

        CateNewsBSO cateNewsBSO = new CateNewsBSO();
        DataTable table1 = cateNewsBSO.GetCateParentGroupAll(cID, Language.language, gID);

        if (table1.Rows.Count > 0)
        {
            foreach (DataRow subrow in table1.Rows)
            {
                //    strArrayID += subrow["CateNewsID"].ToString() + ",";
                strArrayID += GetCateParentIDArrayByID(Convert.ToInt32(subrow["CateNewsID"].ToString()), gID);
            }

        }

        return strArrayID;

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

    public void Paging_Click(object sender, CommandEventArgs e)
    {

        string CurrentPage = e.CommandArgument.ToString();
        hdnPage.Value = CurrentPage;
        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);
        GetCateParentNewsGroup(Convert.ToInt32(hddCateID.Value), Convert.ToInt32(hddGroupCate.Value));

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

    protected void btn_search_Click(object sender, EventArgs e)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();

        string _finter = "";

        _page = new PagingInfo(15, Convert.ToInt32(hdnPage.Value), true);

        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

        _finter += " And Language = '" + Language.language + "'";
        if (hddGroupCate.Value != "")
            _finter += " And GroupCate = " + hddGroupCate.Value;

        if (hddCateID.Value != "" && hddCateID.Value != "0")
        {
            string strCate = this.GetCateParentIDArrayByID(Convert.ToInt32(hddCateID.Value), Convert.ToInt32(hddGroupCate.Value));
            _finter += " And CateNewsID in ('" + strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','") + "')";
        }

        // DateTime TheDateFrom;
        if (dateFrom.Text != "" && dateFrom.Text != string.Empty)
            _finter += " AND PostDate >= '" + DateTime.Parse(dateFrom.Text).ToString("M/d/yyyy hh:mm:ss tt", ci) + "'";

        // DateTime TheDateTo;
        if (dateTo.Text != "" && dateTo.Text != string.Empty)
            _finter += " AND PostDate <= '" + DateTime.Parse(dateTo.Text).ToString("M/d/yyyy hh:mm:ss tt", ci) + "'";

        DataTable table = newsGroupBSO.NewsGroupSearchPaging(_finter, _page);
        newsOther.Visible = false;
        if (table.Rows.Count > 0)
        {
            TotalRecord = Convert.ToInt32(table.Rows[0]["Total"].ToString());
            SetAttributeGvArticle(Convert.ToInt32(table.Rows[0]["Total"].ToString()));
            rptListNewsGroup.DataSource = table;
            rptListNewsGroup.DataBind();

            Paging.DataLoad();
            if (TotalPage(Convert.ToInt32(table.Rows[0]["Total"].ToString())) <= 1)
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
            rptListNewsGroup.DataSource = null;
            rptListNewsGroup.DataBind();
            Paging.Visible = false;
        }

    }
}
