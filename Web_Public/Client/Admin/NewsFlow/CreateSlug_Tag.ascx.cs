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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
public partial class Client_Admin_CreateSlug_Tag : System.Web.UI.UserControl
{
    PagingInfo _page = new PagingInfo(20, 1, true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);


        if (!IsPostBack)
        {

            ViewNewsGroup(-1);

        }

    }

    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
        litModules.Text = modules.ModulesName;
    }
    #endregion


    #region ViewNewsGroup
    private void ViewNewsGroup(int group)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        DataTable table = new DataTable();


        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);


        table = newsGroupBSO.GetNewsGroupPaging(Language.language, group, _page);


        if (table.Rows.Count > 0)
        {
            TotalRecord = Convert.ToInt32(table.Rows[0]["Total"].ToString());
            SetAttributeGvArticle(Convert.ToInt32(table.Rows[0]["Total"].ToString()));
            commonBSO.FillToGridView(grvNewsGroup, table);

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
            grvNewsGroup.DataSource = null;
            grvNewsGroup.DataBind();
            Paging.Visible = false;
        }


    }
    #endregion



    protected void btn_slug_click(object sender, EventArgs e)
    {
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        CateNewsGroupBSO _catenewsgroupBSO = new CateNewsGroupBSO();
        CateNewsBSO _catenewsBSO = new CateNewsBSO();
        NewsGroup newsGroup = new NewsGroup();
        DataTable table = newsGroupBSO.GetNewsGroupAll(Language.language);      


        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                newsGroup = newsGroupBSO.GetNewsGroupById(Convert.ToInt32(table.Rows[i]["NewsGroupID"].ToString()));
                newsGroup.Slug = GetString(newsGroup.Title);

                newsGroup.Tags = _catenewsBSO.GetCateNewsById(newsGroup.CateNewsID).CateNewsName.Replace(",", "");
                newsGroup.Tags += "," + _catenewsgroupBSO.GetCateNewsGroupByGroupCate(newsGroup.GroupCate, Language.language).CateNewsGroupName.Replace(",", "");

                newsGroup.Keyword = _catenewsBSO.GetCateNewsById(newsGroup.CateNewsID).CateNewsName.Replace(",", "");
                newsGroup.Keyword += "," + _catenewsgroupBSO.GetCateNewsGroupByGroupCate(newsGroup.GroupCate, Language.language).CateNewsGroupName.Replace(",", "");

                newsGroupBSO.UpdateNewsGroup(newsGroup);                

            }
            clientview.Text = "Xử lý OK";
            ViewNewsGroup(-1);
        }

    }

    protected void btn_img_click(object sender, EventArgs e)
    {
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        NewsGroup newsGroup = new NewsGroup();
        DataTable table = newsGroupBSO.GetNewsGroupAll(Language.language);


        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                newsGroup = newsGroupBSO.GetNewsGroupById(Convert.ToInt32(table.Rows[i]["NewsGroupID"].ToString()));
                //   newsGroup.ShortDescribe = newsGroup.ShortDescribe.Replace("src=\"/Portals/0/", "src=\"/UserFile/images/");
                newsGroup.FullDescribe = newsGroup.FullDescribe.Replace("src=\"/upload/image/", "src=\"/UserFile/images/");

                newsGroupBSO.UpdateNewsGroup(newsGroup);




            }
            clientview.Text = "Xử lý OK";
            ViewNewsGroup(-1);
        }

    }

    protected void btn_img1_click(object sender, EventArgs e)
    {
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        NewsGroup newsGroup = new NewsGroup();
        DataTable table = newsGroupBSO.GetNewsGroupAll(Language.language);


        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                newsGroup = newsGroupBSO.GetNewsGroupById(Convert.ToInt32(table.Rows[i]["NewsGroupID"].ToString()));
                newsGroup.ShortDescribe = newsGroup.ShortDescribe.Replace("[img src", "<br/><img src");
                newsGroup.FullDescribe = newsGroup.FullDescribe.Replace("[img src", "<br/><img src");

                newsGroup.ShortDescribe = newsGroup.ShortDescribe.Replace("\"]", "\"/><br/>");
                newsGroup.FullDescribe = newsGroup.FullDescribe.Replace("\"]", "\"/><br/>");
                newsGroupBSO.UpdateNewsGroup(newsGroup);




            }
            clientview.Text = "Xử lý OK";
            ViewNewsGroup(-1);
        }

    }
    protected void btn_img2_click(object sender, EventArgs e)
    {
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        NewsGroup newsGroup = new NewsGroup();
        DataTable table = newsGroupBSO.GetNewsGroupAll(Language.language);

        //newsGroup = newsGroupBSO.GetNewsGroupById(7202);
        //string filename = FetchLinksFromSource(newsGroup.FullDescribe);

        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                newsGroup = newsGroupBSO.GetNewsGroupById(Convert.ToInt32(table.Rows[i]["NewsGroupID"].ToString()));
                //newsGroup.ShortDescribe = newsGroup.ShortDescribe.Replace("href=\"images/stories/", "href=\"/UserFile/images/stories/");
                newsGroup.FullDescribe = newsGroup.FullDescribe.Replace("src=\"/upload/image/", "src=\"/UserFile/images/");

                //newsGroup.ImageThumb = FetchLinksFromSource(newsGroup.FullDescribe);
                //newsGroup.ImageLarge = FetchLinksFromSource(newsGroup.FullDescribe);
                newsGroupBSO.UpdateNewsGroup(newsGroup);

            }
            clientview.Text = "Xử lý OK";
            ViewNewsGroup(-1);
        }

    }
    protected void btn_down_click(object sender, EventArgs e)
    {
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        NewsGroup newsGroup = new NewsGroup();
        DataTable table = newsGroupBSO.GetNewsGroupAll(Language.language);

        //newsGroup = newsGroupBSO.GetNewsGroupById(9163);
        //string filename = FetchLinksFromSource(newsGroup.FullDescribe);

        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            //for (int i = 0; i < 1000; i++)
            {
                newsGroup = newsGroupBSO.GetNewsGroupById(Convert.ToInt32(table.Rows[i]["NewsGroupID"].ToString()));
                //newsGroup.ShortDescribe = newsGroup.ShortDescribe.Replace("href=\"images/stories/", "href=\"/UserFile/images/stories/");
                //newsGroup.FullDescribe = newsGroup.FullDescribe.Replace("href=\"images/stories/", "href=\"/UserFile/images/stories/");

                //newsGroup = newsGroupBSO.GetNewsGroupById(8960);

                string fileurl = GetSource(newsGroup.FullDescribe);
                if (fileurl != "")
                {
                    string strRealname = Path.GetFileName(fileurl);
                    string exts = Path.GetExtension(fileurl);

                    WebClient webClient = new WebClient();
                    //webClient.DownloadFile(Request.PhysicalApplicationPath.Replace(@"\", "/") + fileurl, Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + strRealname + exts);
                    string url1 = "";
                    if (fileurl.IndexOf("http://") == -1)
                    {
                        url1 = "http://ussh.vnu.edu.vn/" + fileurl.Replace(@"UserFile/Images/News/img/", "wp-content/uploads/");
                        url1 = url1.Replace(@"UserFile/images/News/img/", "wp-content/uploads/");
                        url1 = url1.Replace("//wp-content", "/wp-content");
                        url1 = url1.Replace("//uploads", "/wp-content/uploads");
                        url1 = url1.Replace("[siteurl]/", "");
                        url1 = url1.Replace("http://ussh.vnu.edu.vn//UserFile", "http://203.190.160.247:8321/UserFile");
                    }
                    else
                        url1 = fileurl;
                    //string url1 = Request.PhysicalApplicationPath.Replace(@"\", "/") + fileurl;
                    //if (!File.Exists(Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts))
                    //{
                    //Stream mystream;
                    //HttpWebRequest wreq;
                    //HttpWebResponse wresp;

                    //wreq = (HttpWebRequest)WebRequest.Create(url1);
                    //wreq.AllowWriteStreamBuffering = true;
                    //wreq.Timeout = 6000; // =6s //set timeout download images from server other

                    //wresp = (HttpWebResponse)wreq.GetResponse();

                    //if ((mystream = wresp.GetResponseStream()) != null)
                    //{
                    if (!File.Exists(Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts))
                    {
                        webClient.DownloadFile(url1, Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts);
                        newsGroup.ImageThumb = newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts;
                        newsGroup.ImageLarge = newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts;
                        newsGroupBSO.UpdateNewsGroup(newsGroup);
                    }
                    //}
                    //}

                }

            }
            clientview.Text = "Xử lý OK";
            ViewNewsGroup(-1);
        }

    }

    protected void btn_down_thumb_click(object sender, EventArgs e)
    {
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        NewsGroup newsGroup = new NewsGroup();
        DataTable table = newsGroupBSO.GetNewsGroupAll(Language.language);

        //newsGroup = newsGroupBSO.GetNewsGroupById(9163);
        //string filename = FetchLinksFromSource(newsGroup.FullDescribe);

        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            //for (int i = 0; i < 1000; i++)
            {
                newsGroup = newsGroupBSO.GetNewsGroupById(Convert.ToInt32(table.Rows[i]["NewsGroupID"].ToString()));
                //newsGroup.ShortDescribe = newsGroup.ShortDescribe.Replace("href=\"images/stories/", "href=\"/UserFile/images/stories/");
                //newsGroup.FullDescribe = newsGroup.FullDescribe.Replace("href=\"images/stories/", "href=\"/UserFile/images/stories/");

                //newsGroup = newsGroupBSO.GetNewsGroupById(8960);
                string fileurl = newsGroup.ImageThumb;
                if (fileurl != "")
                {
                    string strRealname = Path.GetFileName(fileurl);
                    string exts = Path.GetExtension(fileurl);

                    WebClient webClient = new WebClient();

                    string url1 = "http://localhost:98/Upload/NewsGroup/NewsGroupThumb/" + fileurl;

                    if (!File.Exists(Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts))
                    {
                        try
                        {
                            webClient.DownloadFile(url1, Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts);
                        }
                        catch
                        {
                        }
                        newsGroup.ImageThumb = newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts;
                        newsGroup.ImageLarge = newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts;
                        newsGroupBSO.UpdateNewsGroup(newsGroup);
                    }
                }

                //string fileurl = GetSource(newsGroup.FullDescribe);
                //if (fileurl != "")
                //{
                //    string strRealname = Path.GetFileName(fileurl);
                //    string exts = Path.GetExtension(fileurl);

                //    WebClient webClient = new WebClient();
                //    //webClient.DownloadFile(Request.PhysicalApplicationPath.Replace(@"\", "/") + fileurl, Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + strRealname + exts);
                //    string url1 = "";
                //    if (fileurl.IndexOf("http://") == -1)
                //    {
                //        url1 = "http://ussh.vnu.edu.vn/" + fileurl.Replace(@"UserFile/Images/News/img/", "wp-content/uploads/");
                //        url1 = url1.Replace(@"UserFile/images/News/img/", "wp-content/uploads/");
                //        url1 = url1.Replace("//wp-content", "/wp-content");
                //        url1 = url1.Replace("//uploads", "/wp-content/uploads");
                //        url1 = url1.Replace("[siteurl]/", "");
                //        url1 = url1.Replace("http://ussh.vnu.edu.vn//UserFile", "http://203.190.160.247:8321/UserFile");
                //    }
                //    else
                //        url1 = fileurl;
                //    //string url1 = Request.PhysicalApplicationPath.Replace(@"\", "/") + fileurl;
                //    //if (!File.Exists(Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts))
                //    //{
                //    //Stream mystream;
                //    //HttpWebRequest wreq;
                //    //HttpWebResponse wresp;

                //    //wreq = (HttpWebRequest)WebRequest.Create(url1);
                //    //wreq.AllowWriteStreamBuffering = true;
                //    //wreq.Timeout = 6000; // =6s //set timeout download images from server other

                //    //wresp = (HttpWebResponse)wreq.GetResponse();

                //    //if ((mystream = wresp.GetResponseStream()) != null)
                //    //{
                //    if (!File.Exists(Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts))
                //    {
                //        webClient.DownloadFile(url1, Request.PhysicalApplicationPath.Replace(@"\", "/") + "Upload/NewsGroup/Gets/" + newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts);
                //        newsGroup.ImageThumb = newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts;
                //        newsGroup.ImageLarge = newsGroup.NewsGroupID + "-" + GetString(Tool.SubString(Tool.StripTagsCharArray(newsGroup.Title), 50)) + exts;
                //        newsGroupBSO.UpdateNewsGroup(newsGroup);
                //    }
                //    //}
                //    //}

                //}

            }
            clientview.Text = "Xử lý OK";
            ViewNewsGroup(-1);
        }

    }
    //Strip font HTML
    protected void btn_html_click(object sender, EventArgs e)
    {
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        NewsGroup newsGroup = new NewsGroup();
        DataTable table = newsGroupBSO.GetNewsGroupAll(Language.language);


        if (table.Rows.Count > 0)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                newsGroup = newsGroupBSO.GetNewsGroupById(Convert.ToInt32(table.Rows[i]["NewsGroupID"].ToString()));
                //if (newsGroup.FullDescribe.IndexOf("<!--more-->") != -1)
                //{
                //    newsGroup.ShortDescribe = newsGroup.FullDescribe.Substring(0, newsGroup.FullDescribe.IndexOf("<!--more-->"));
                //}
                //newsGroup.FullDescribe = newsGroup.FullDescribe.Replace("^<p>&nbsp;</p>", "");
                //string regex = @"<p[^>]*>(\s|& nbsp;)*</p>";
                //string regex = @"&#160;";
                //newsGroup.FullDescribe = Regex.Replace(newsGroup.FullDescribe, regex, "").Trim();
                //newsGroup.FullDescribe = Regex.Match(newsGroup.FullDescribe, "^<p>&nbsp;</p>").ToString();
                //newsGroup.ShortDescribe = Regex.Replace(newsGroup.ShortDescribe, regex, "").Trim();
                //   string text = x;
                string patternfont = @"font-size\s*?:.*?(;|(?=""|'|;))";
                string cleanedHtmlfontFull = Regex.Replace(newsGroup.FullDescribe, patternfont, string.Empty);

                //cleanedHtmlfontFull = Regex.Replace(cleanedHtmlfontFull, "(line-height|font-family|font-size)\\s:.*?;?", String.Empty);
                cleanedHtmlfontFull = Regex.Replace(cleanedHtmlfontFull, @"font-family\s*?:.*?(;|(?=""|'|;))", String.Empty);
                newsGroup.FullDescribe = cleanedHtmlfontFull;

                string cleanedHtmlfontDes = Regex.Replace(newsGroup.ShortDescribe, patternfont, string.Empty);
                cleanedHtmlfontDes = Regex.Replace(cleanedHtmlfontDes, @"font-family\s*?:.*?(;|(?=""|'|;))", String.Empty);
                newsGroup.ShortDescribe = cleanedHtmlfontDes;
                
                //newsGroup.ShortDescribe = Tool.StripTagsCharArray(newsGroup.ShortDescribe);
                newsGroupBSO.UpdateNewsGroup(newsGroup);




            }
            clientview.Text = "Xử lý OK";
            ViewNewsGroup(-1);
        }

    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {

        string CurrentPage = e.CommandArgument.ToString();
        hdnPage.Value = CurrentPage;
        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);
        ViewNewsGroup(-1);

    }
    private void SetAttributeGvArticle(int totalRecord)
    {

        Paging.PageSize = Convert.ToInt32(_page.PageSize);
        Paging.TotalRecord = totalRecord;
        Paging.CurrentPage = grvNewsGroup.PageIndex + Convert.ToInt32(hdnPage.Value);
        Paging.TotalNumberPaging = 20;
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

    public string FetchLinksFromSource(string htmlSource)
    {
        string filename = "";
        string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
        MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        foreach (Match m in matchesImgSrc)
        {
            string href = m.Groups[1].Value;
            if (href != "" && href != string.Empty)
            {
                if (href.LastIndexOf("/") != -1)
                {
                    filename = href.Substring(href.LastIndexOf("/") + 1);
                    break;
                }
            }
        }
        return filename;
    }
    public string GetSource(string htmlSource)
    {
        string filename = "";
        string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
        MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        foreach (Match m in matchesImgSrc)
        {
            string href = m.Groups[1].Value;
            if (href != "" && href != string.Empty)
            {
                if (href.LastIndexOf("/") != -1)
                {
                    filename = href;
                    break;
                }
            }
        }
        return filename;
    }
}
