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
public partial class Client_AboutListTab : System.Web.UI.UserControl
{
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

                //GetHotNewsGroup(cId, gId);
                ViewListCate(cId, gId);

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
                title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>"+Resources.resource.T_home+"</a> <img src='" + ResolveUrl("~/") + "images/icon_arrows1.png' >";
                title_cate.Text += cate;

                Page.Title = cateNewsById.CateNewsName ;

                System.Web.UI.HtmlControls.HtmlMeta _descrip = new HtmlMeta();
                _descrip.Name = "description";
                _descrip.Content = cateNewsById.CateNewsName;

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
                    //GetHotNewsGroup(cId, gId);
                    ViewListCate(cId, gId);

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



    //private void GetCateParentNewsGroup(int cId, int gId)
    //{
    //    string strCate = this.GetCateParentIDArrayByID(cId, gId);

    //    NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
    //    DataTable newsGroupPaging = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(hddGroupCate.Value), strCate, _page);
    //    if (newsGroupPaging.Rows.Count > 0)
    //    {
    //        TotalRecord = Convert.ToInt32(newsGroupPaging.Rows[0]["Total"].ToString());
    //        SetAttributeGvArticle(Convert.ToInt32(newsGroupPaging.Rows[0]["Total"].ToString()));
    //        rptListNewsGroup.DataSource = newsGroupPaging;
    //        rptListNewsGroup.DataBind();
    //        Paging.DataLoad();
    //        if (TotalPage(Convert.ToInt32(newsGroupPaging.Rows[0]["Total"].ToString())) <= 1L)
    //        {
    //            Paging.Visible = false;
    //        }
    //        else
    //        {
    //            Paging.Visible = true;
    //        }
    //    }
    //    else
    //    {
    //        SetAttributeGvArticle(0);
    //        Paging.Visible = false;
    //    }


    //    //CateNewsBSO cateNewsBSO = new CateNewsBSO();
    //    //DataTable cateClientGroup = cateNewsBSO.getCateClientGroup(cId, Language.language, gId, 5);
    //    //if (cateClientGroup.Rows.Count > 0)
    //    //{
    //    //    tintuc_col1.Attributes.Add("class", "tintuc-col1");
    //    //    ViewListCate(cId, gId);
    //    //}
    //    //else
    //    //{
    //    //    tintuc_col1.Attributes.Add("class", "tintuc-col-main");
    //    //}


    //    PagingInfo paging = new PagingInfo(10, (Convert.ToInt32(hdnPage.Value) + 1), true);
    //    DataTable newsGroupPaging2 = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(hddGroupCate.Value), paging);
    //    if (newsGroupPaging2.Rows.Count > 0)
    //    {
    //        newsOther.Visible = true;
    //        rptListNewsOther.DataSource = newsGroupPaging2;
    //        rptListNewsOther.DataBind();
    //        return;
    //    }
    //    newsOther.Visible = false;
    //}

    private void ViewListCate(int cId, int gId)
    {
        //Cate
        CateNewsBSO cateNewsBSO = new CateNewsBSO();
        DataTable tblCateClient = new DataTable();
        if (!AspNetCache.CheckCache("tblCateClient_" + gId + "_" + cId))
        {

            
            tblCateClient = cateNewsBSO.getCateClientGroupUrl(cId, Language.language, gId, 4);
            AspNetCache.SetCacheWithTime("tblCateClient_" + gId + "_" + cId, tblCateClient, 150.0);
        }
        else
            tblCateClient = (DataTable)AspNetCache.GetCache("tblCateClient_" + gId + "_" + cId);

        string strCateSub = "";
        if (tblCateClient.Rows.Count > 0)
        {
            strCateSub += "<div class='r-ro'>";
            for (int i = 0; i < tblCateClient.Rows.Count; i++)
            {
                DataRow dataRow = tblCateClient.Rows[i];
                if (Convert.ToBoolean(dataRow["isUrl"]))
                {
                    strCateSub += "<a class='catelink' href='" + dataRow["Url"] + "' title='" + dataRow["CateNewsName"] + "'>" + dataRow["ShortName"] + "</a>";
                }
                else
                {
                    strCateSub += "<a class='catelink' href='" + ResolveUrl("~/") + "c3/" + cateNewsBSO.GetSlugByCateId(Convert.ToInt32(dataRow["CateNewsID"])) + "/" + GetString(dataRow["CateNewsName"]) + "-" + dataRow["GroupCate"] + "-" + dataRow["CateNewsID"].ToString() + ".aspx' title='" + dataRow["CateNewsName"] + "'>" + dataRow["ShortName"] + "</a>";
                }
                //if (i < tblCateClient.Rows.Count - 1)
                //    strCateSub += "<span class='catelink-line'> </span>";
            }
            strCateSub += "</div>";
            ltlCateLink.Text = strCateSub;
        }
        else
            ltlCateLink.Visible = false;
        //GetNews

        DataTable table = new DataTable();

        if (!AspNetCache.CheckCache("HTML_AboutTabListbyCate_" + gId + "_" + cId))
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            if (cId == 0)
                table = newsGroupBSO.GetNewsGroupHot(Language.language,"1",gId);
            else
                table = newsGroupBSO.GetNewsGroupByCateHotAll(cId, gId, "1", "1", "1");
            AspNetCache.SetCacheWithTime("HTML_AboutTabListbyCate_" + gId + "_" + cId, table, 150.0);
        }
        else
            table = (DataTable)AspNetCache.GetCache("HTML_AboutTabListbyCate_" + gId + "_" + cId);


        if (table.Rows.Count > 0)
        {
            DataTable tableHot = table.Clone();
            DataTable tableOther = table.Clone();

            //SubCate
            if (tblCateClient.Rows.Count == 0 || tblCateClient == null)
            {

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (i < 4)
                        tableHot.ImportRow(table.Rows[i]);
                    else
                        tableOther.ImportRow(table.Rows[i]);
                }

                string strTabNews = "";
                if (tableHot.Rows.Count > 0)
                {
                    strTabNews += "<div class='tab_title-tabdetail'>";
                    strTabNews += "<ul id='detailtabs' class='tabdetail'>";
                    for (int i = 0; i < tableHot.Rows.Count; i++)
                    {
                        DataRow row = tableHot.Rows[i];
                        strTabNews += "<li><a href='' rel='detail_news_" + i + "' class='selected'>";
                        strTabNews += row["ShortTitle"];
                        strTabNews += "</a></li>";
                    }
                    strTabNews += "</ul>";
                    strTabNews += "</div> ";


                    for (int i = 0; i < tableHot.Rows.Count; i++)
                    {
                        DataRow row = tableHot.Rows[i];
                        strTabNews += "<div id='detail_news_" + i + "' class='tabcontent-detail'>";
                        strTabNews += "<div class='main-tab-vanban-detail'>";
                        strTabNews += row["FullDescribe"];
                        strTabNews += "</div>";

                        strTabNews += "</div>";
                    }
                }

                newsTabList.Text = strTabNews;
            }
            else //CateParent
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (i < 1)
                        tableHot.ImportRow(table.Rows[i]);
                    else
                        tableOther.ImportRow(table.Rows[i]);
                }

                string newsdetail = "";
                if (tableHot.Rows.Count > 0)
                {
                    DataRow row = tableHot.Rows[0];

                    newsdetail += "<h1 class='news-title-detail'>";
                    newsdetail += row["Title"];
                    newsdetail += "</h1>";
                    newsdetail += "<div class='news-detail-ct'>";
                    newsdetail += "<p>";
                    newsdetail += row["FullDescribe"];
                    newsdetail += "</p>";
                    newsdetail += "</div>";
                }
                newsTabList.Text = newsdetail;
            }



            if (tableOther.Rows.Count > 0)
            {
                newsOther.Visible = true;
                rptListNewsOther.DataSource = tableOther;
                rptListNewsOther.DataBind();
            }
            else
            {
                newsOther.Visible = false;
            }
        }
        else
        {
            newsOther.Visible = false;
        }

        DataTable table1 = new DataTable();

        if (!AspNetCache.CheckCache("HTML_AboutTabListbyCate1_" + gId + "_" + cId))
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            if (cId == 0)
                table1 = newsGroupBSO.GetNewsGroupHot(Language.language, "1", "0", gId);
            else
                table1 = newsGroupBSO.GetNewsGroupByCateHotAll(cId, gId, "1", "1", "0");

            AspNetCache.SetCacheWithTime("HTML_AboutTabListbyCate1_" + gId + "_" + cId, table1, 150.0);
        }
        else
            table1 = (DataTable)AspNetCache.GetCache("HTML_AboutTabListbyCate1_" + gId + "_" + cId);

        if (table1.Rows.Count > 0)
        {
            newsOther1.Visible = true;
            rptNewsOther1.DataSource = table1;
            rptNewsOther1.DataBind();
        }
        else
        {
            newsOther1.Visible = false;
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

    //public void Paging_Click(object sender, CommandEventArgs e)
    //{

    //    string CurrentPage = e.CommandArgument.ToString();
    //    hdnPage.Value = CurrentPage;
    //    _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);
    //    GetCateParentNewsGroup(Convert.ToInt32(hddCateID.Value), Convert.ToInt32(hddGroupCate.Value));

    //}
    //private void SetAttributeGvArticle(int totalRecord)
    //{

    //    Paging.PageSize = Convert.ToInt32(_page.PageSize);
    //    Paging.TotalRecord = totalRecord;
    //    Paging.CurrentPage = Convert.ToInt32(hdnPage.Value);
    //    Paging.TotalNumberPaging = 20;
    //}

    //private long TotalPage(int total)
    //{
    //    if (total % _page.PageSize == 0)
    //    {
    //        return total / _page.PageSize;
    //    }
    //    else
    //    {
    //        return total / _page.PageSize + 1;
    //    }
    //    //    return 0;
    //}
    //private int TotalRecord
    //{
    //    get
    //    {
    //        if (ViewState["TotalRecord"] != null)
    //            return Convert.ToInt32(ViewState["TotalRecord"].ToString());
    //        else
    //            return 0;
    //    }
    //    set
    //    {
    //        ViewState["TotalRecord"] = value;
    //    }
    //}

    //protected void btn_search_Click(object sender, EventArgs e)
    //{
    //    commonBSO commonBSO = new commonBSO();
    //    NewsGroupBSO newsGroupBSO = new NewsGroupBSO();

    //    string _finter = "";

    //    _page = new PagingInfo(15, Convert.ToInt32(hdnPage.Value), true);

    //    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

    //    _finter += " And Language = '" + Language.language + "'";
    //    if (hddGroupCate.Value != "")
    //        _finter += " And GroupCate = " + hddGroupCate.Value;

    //    if (hddCateID.Value != "" && hddCateID.Value != "0")
    //    {
    //        string strCate = this.GetCateParentIDArrayByID(Convert.ToInt32(hddCateID.Value), Convert.ToInt32(hddGroupCate.Value));
    //        _finter += " And CateNewsID in ('" + strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','") +"')";
    //    }

    //    // DateTime TheDateFrom;
    //    if (dateFrom.Text != "" && dateFrom.Text != string.Empty)
    //        _finter += " AND PostDate >= '" + DateTime.Parse(dateFrom.Text).ToString("M/d/yyyy hh:mm:ss tt", ci) + "'";

    //    // DateTime TheDateTo;
    //    if (dateTo.Text != "" && dateTo.Text != string.Empty)
    //        _finter += " AND PostDate <= '" + DateTime.Parse(dateTo.Text).ToString("M/d/yyyy hh:mm:ss tt", ci) + "'";

    //    DataTable table = newsGroupBSO.NewsGroupSearchPaging(_finter, _page);
    //    newsOther.Visible = false;
    //    if (table.Rows.Count > 0)
    //    {
    //        TotalRecord = Convert.ToInt32(table.Rows[0]["Total"].ToString());
    //        SetAttributeGvArticle(Convert.ToInt32(table.Rows[0]["Total"].ToString()));
    //        rptListNewsGroup.DataSource = table;
    //        rptListNewsGroup.DataBind();

    //        Paging.DataLoad();
    //        if (TotalPage(Convert.ToInt32(table.Rows[0]["Total"].ToString())) <= 1)
    //        {
    //            Paging.Visible = false;
    //        }
    //        else
    //        {
    //            Paging.Visible = true;
    //        }
    //    }
    //    else
    //    {
    //        SetAttributeGvArticle(0);
    //        rptListNewsGroup.DataSource = null;
    //        rptListNewsGroup.DataBind();
    //        Paging.Visible = false;
    //    }

    //}
}
