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
public partial class Client_NewsPageDetail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            if (!int.TryParse(Request["Id"].Replace(",", ""), out Id))
                Response.Redirect("~/Default.aspx");

        int gId = 0;
        if (!String.IsNullOrEmpty(Request["g"]))
            if (!int.TryParse(Request["g"].Replace(",", ""), out gId))
                Response.Redirect("~/Default.aspx");

        hddGroupCate.Value = Convert.ToString(gId);
        if (!IsPostBack)
            ViewNewsGroupDetail(Id);
    }
    private void ViewNewsGroupDetail(int Id)
    {
        CateNewsGroupBSO cateNewsgroupBSO = new CateNewsGroupBSO();
        NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
        NewsGroup newsgroup = newsgroupBSO.GetNewsGroupById(Id);
        if (newsgroup == null)
            Response.Redirect("~/Default.aspx");
        commonBSO commonBSO = new commonBSO();
        //Kiem tra neu phan quyen truy cap chuyen muc nay
        DataTable dtCheckRole = commonBSO.CreateDataView("SELECT FROM tblRoleCate WHERE CateId=" + newsgroup.CateNewsID);

        if (dtCheckRole != null && dtCheckRole.Rows.Count > 0)
        {
            UserValidation m_UserValidation = new UserValidation();

            if (m_UserValidation.IsSigned())
            {
                DataTable dtGroupRole = new AdminRolesBSO().GetAdminRolesByUserName(m_UserValidation.UserName);
                if (dtGroupRole != null && dtGroupRole.Rows.Count > 0)
                {
                    DataTable dtRoleCate = commonBSO.CreateDataView("SELECT Id FROM tblRoleCate WHERE GroupId IN (SELECT RolesID FROM tblAdminRoles WHERE Admin_UserName = '" + m_UserValidation.UserName + "') AND CateId=" + newsgroup.CateNewsID);
                    if (dtRoleCate != null && dtRoleCate.Rows.Count > 0)
                    {
                        //Da dang nhap va co quyen xem
                    }
                    else
                    {
                        //Da dang nhap nhung khong co quyen truy cap, chuyen ve trang thong bao;
                        content_notice.Visible = true;
                        content_news.Visible = false;
                    }

                }
            }
            else
            {
                //Yeu cau dang nhap
                Response.Redirect(ResolveUrl("~") + "Dang-nhap.aspx?RetUrl=" + Request.RawUrl);
            }
        }
        ltlTitle.Text = newsgroup.Title;
        //LabelDate.Text = newsgroup.PostDate.ToString("dd/MM/yyyy");// Convert.ToString(newsgroup.PostDate);
        ltlDescribe.Text = newsgroup.ShortDescribe;
        FullDescirbe.Text = newsgroup.FullDescribe;
        LabelAuthor.Text = newsgroup.Author;
        txtNewsGroupID.Value = Convert.ToString(newsgroup.NewsGroupID);

        newsgroupBSO.NewsGroupClickUpdate(Id);
        NewsGroupFollow(newsgroup.NewsGroupID, newsgroup.CateNewsID);


        CateNewsBSO catenewsBSO = new CateNewsBSO();
        CateNews catenews = catenewsBSO.GetCateNewsById(newsgroup.CateNewsID);
        CateNewsGroup cateNewsGroup = cateNewsgroupBSO.GetCateNewsGroupByGroupCate(catenews.GroupCate, Language.language);

        title_name.Text = "<a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(catenews.CateNewsID) + "/" + GetString(catenews.CateNewsName) + "-" + catenews.GroupCate + "-" + catenews.CateNewsID + ".aspx'>" + catenews.CateNewsName + "</a>";

        string cate = "<a href='" + ResolveUrl("~/") + "c2/" + cateNewsgroupBSO.GetSlugById(cateNewsGroup.CateNewsGroupID) + "/" + GetString(cateNewsGroup.CateNewsGroupName) + "-" + catenews.GroupCate + ".aspx' class='content_Text_Cat'>";
        string s1 = "";
        while (catenews.ParentNewsID != 0)
        {
            int pId = catenews.ParentNewsID;
            catenews = catenewsBSO.GetCateNewsById(pId);
            s1 = "<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'><a href='" + ResolveUrl("~/") + "c3/" + catenewsBSO.GetSlugByCateId(catenews.CateNewsID) + "/" + GetString(catenews.CateNewsName) + "-" + catenews.GroupCate + "-" + catenews.CateNewsID + ".aspx' class='content_Text_Cat'>" + catenews.CateNewsName + "</a>" + s1;
        }

        cate += cateNewsGroup.CateNewsGroupName.ToString(); //Sửa lại
        cate += "</a>";
        cate += s1;
        title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.T_home + "</a><img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'> ";
        title_cate.Text += cate;

        if (!String.IsNullOrEmpty(Request["error"]))
            error.Text = "<div class='error_register_text'>" + Resources.resource.T_Comment_Error1 + "</div>";

        if (!newsgroup.IsComment)
        {
            btnComment.Visible = false;
            CommentPanel.Visible = false;

        }
        else
        {
            btnComment.Visible = true;
            CommentPanel.Visible = true;
            GetNewsCommentById(Id);

        }


        //ViewRegister(Id);

        //ltlFb_like.Text = "<div class='fb-like' data-href='http://http://tuyensinhtructuyen.edu.vn/ts/" + GetString(newsgroup.Title) + "-" + newsgroup.GroupCate + "-" + newsgroup.NewsGroupID + ".aspx' data-send='true' data-width='670' data-height='65' data-show-faces='true'></div>";
        //ltlFb_comment.Text = "<div class='fb-comments' data-href='http://http://tuyensinhtructuyen.edu.vn/ts/" + GetString(newsgroup.Title) + "-" + newsgroup.GroupCate + "-" + newsgroup.NewsGroupID + ".aspx' data-num-posts='10' data-width='670'></div>";

        Page.Title = newsgroup.Title;
        HtmlMeta _desrip = new HtmlMeta();
        _desrip.Name = "description";
        _desrip.Content = Tool.StripTagsCharArray(newsgroup.ShortDescribe) + " ; " + newsgroup.Title + " , " + (newsgroup.Tags) + " , " + newsgroup.Keyword;

        Page.Header.Controls.Add(_desrip);

        System.Web.UI.HtmlControls.HtmlMeta _keyWords = new HtmlMeta();
        _keyWords.Name = "keywords";
        _keyWords.Content = newsgroup.Keyword ;

        Page.Header.Controls.Add(_keyWords);
    }

    //private void ViewRegister(int Id)
    //{
    //    NewsRegisterBSO newsregisterBSO = new NewsRegisterBSO();
    //    NewsRegister newsregister = newsregisterBSO.GetNewsRegisterByParentNewsId(Id);
    //    if (newsregister == null)
    //        ltlNewsRegister_link.Visible = false;
    //    else
    //        ltlNewsRegister_link.Text = "<div style='text-align:center;'><a href='" + ResolveUrl("~/") + "dang-ky/" + GetString(newsregister.Title) + "-" + newsregister.GroupCate + "-" + newsregister.NewsRegisterID + ".aspx'><img src='" + ResolveUrl("~/") + "images/btn_dangky.png' style='border-width:0px;'></a></div>";

    //}
    private void NewsGroupFollow(int Id, int cId)
    {
        NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
        DataTable table = newsgroupBSO.NewsGroupFollow(Id, cId, 10, "1");
        if (table.Rows.Count > 0)
            newsOther.Visible = true;
        else
            newsOther.Visible = false;

        DataListNews.DataSource = table;
        DataListNews.DataBind();
    }
    protected void Send_email(object sender, EventArgs e)
    {
        Response.Redirect("~/MailNews/" + txtNewsGroupID.Value + "/Default.aspx");
    }
    protected void Print(object sender, EventArgs e)
    {
        Response.Redirect("~/News/PrintNews/" + txtNewsGroupID.Value + "/Default.aspx");
    }

    private void GetNewsCommentById(int cId)
    {
        NewsCommentBSO newsCommentBSO = new NewsCommentBSO();

        DataTable table = newsCommentBSO.GetNewsCommentByNewsID(cId);

        if (table.Rows.Count > 0)
            lblComment.Text = table.Rows.Count.ToString() + " "+ Resources.resource.T_Comment2;
        else
            lblComment.Text = "";


        DataListProductComment.DataSource = table;
        DataListProductComment.DataBind();


    }

    #region ReceiveHtml
    protected NewsComment ReceiveHtml()
    {


        NewsComment newsComment = new NewsComment();
        newsComment.CommentNewsID = 0;
        newsComment.NewsID = Convert.ToInt32(txtNewsGroupID.Value);
        newsComment.Title = txtTitle.Text;
        newsComment.Content = txtContent.Text;

        newsComment.FullName = txtFullName.Text;
        newsComment.Email = txtEmail.Text;
        newsComment.DateCreated = DateTime.Now;
        newsComment.Actived = false;
        newsComment.GroupCate = Convert.ToInt32(hddGroupCate.Value);
        newsComment.ApprovalDate = DateTime.Now;
        newsComment.ApprovalUserName = "";

        return newsComment;
    }
    #endregion

    protected void Send_Click(object sender, EventArgs e)
    {

        NewsComment newsComment = ReceiveHtml();
        if (txtCapcha.Text.ToLower() == Session["Random"].ToString().ToLower())
        {
            NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
            newsCommentBSO.CreateNewsComment(newsComment);

            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);

            string strBody = Resources.resource.T_Comment_email_title + config.WebName + " (" + config.WebDomain + ") : <br>";
            strBody += "<b>" + Resources.resource.T_Comment_Title + ": </b> " + newsComment.Title + "<br>";
            strBody += "<b>" + Resources.resource.T_Comment_Name + " : </b> " + newsComment.FullName + "<br>";

            strBody += "<b>" + Resources.resource.T_Comment_Email + " : </b> " + newsComment.Email + "<br>";
            strBody += "<b>" + Resources.resource.T_Comment_ID + " : </b> " + newsComment.NewsID + "<br>";
            strBody += "<b>" + Resources.resource.T_Comment_Content + " : </b> <br>" + newsComment.Content + "<br>";

            NewsGroupBSO newsBSO = new NewsGroupBSO();
            NewsGroup news = newsBSO.GetNewsGroupById(newsComment.NewsID);

            strBody += "<b>Title : </b>  <a href='" + config.WebDomain + "/d4/news/" + GetString(news.Title) + "-" + hddGroupCate.Value + "-" + newsComment.NewsID + ".aspx'>" + news.Title + "</a><br>";

            MailBSO mailBSO = new MailBSO();
            mailBSO.EmailFrom = newsComment.Email;




            mailBSO.EmailFrom = config.Email_from;

            string strObj = Resources.resource.T_Comment_email_title + config.WebName + " (" + config.WebDomain + ") - Date: " + DateTime.Now.ToString("dd:MM:yyyy");
            mailBSO.SendMail(config.Email_to, strObj, strBody);



            int Id = Convert.ToInt32(txtNewsGroupID.Value);
            Response.Redirect("~/d5/news/" + GetString(news.Title) + "-" + hddGroupCate.Value + "-" + Id + "-2.aspx");
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
