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

public partial class Client_Admin_EditNews : System.Web.UI.UserControl
{
    PagingInfo _page = new PagingInfo(10, 1, true);
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        int subId = 0;
        if (!string.IsNullOrEmpty(Request["subid"]))
            int.TryParse(Request["subid"].Replace(",", ""), out subId);

        int group = -1;

        if (!IsPostBack)
        {
            initEditor();
            hddGroup.Value = Convert.ToString(group);
            BindToCateNewsGroup();

            if (subId > 0)
                initControl(Id, subId);
            else
                initControl(Id);
        }

    }
    #region NavigationTitle
    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #endregion

    private void initEditor()
    {
        //txtRadShort.config.toolbar = "Full";
        //txtRadShort.config.toolbar = new object[]
        //{
        //    new object[] { "Source" },
        //    new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },
        //    new object[] { "NumberedList", "BulletedList", "-", "Outdent", "Indent" },
        //    "/",
        //    new object[] { "Styles", "Format", "Font", "FontSize", "TextColor", "BGColor", "-", "About" },
        //};

        //txtRadFull.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        //txtRadFull.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        //txtRadFull.config.format_div = @"{ element : 'div' }";

        txtRadFull.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        txtRadFull.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        txtRadFull.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        txtRadFull.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        txtRadFull.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        txtRadFull.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        txtRadFull.config.entities = false;
        //txtRadFull.config.filebrowserWindowWidth = '1000',
        //txtRadFull.config.filebrowserWindowHeight = '700'
    }
    #region initControl
    private void initControl(int Id)
    {
        //txtRadShort.DisableFilter(Telerik.Web.UI.EditorFilters.ConvertCharactersToEntities);
        //txtRadFull.DisableFilter(Telerik.Web.UI.EditorFilters.ConvertCharactersToEntities);
        AdminBSO adminBSO = new AdminBSO();
        Admin admin = new Admin();
        if (Id > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_add2.Visible = false;
            btn_edit1.Visible = true;
            try
            {
                NewsGroup newsgroup = new NewsGroup();
                NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
                newsgroup = newsgroupBSO.GetNewsGroupById(Id);
                hddNewsGroupID.Value = Convert.ToString(newsgroup.NewsGroupID);
                ddlCateNews.SelectedValue = Convert.ToString(newsgroup.CateNewsID);
                hddParentNewsID.Value = Convert.ToString(newsgroup.ParentNewsID);

                //rdbGroupCate.SelectedValue = Convert.ToString(newsgroup.GroupCate); //Thêm

                txtTitle.Text = newsgroup.Title;
                txtRadShort.Text = System.Net.WebUtility.HtmlDecode(newsgroup.ShortDescribe);
                txtRadFull.Text = newsgroup.FullDescribe;
                hddImageThumb.Value = newsgroup.ImageThumb;
                hddImageLarge.Value = newsgroup.ImageLarge;

                txtimage4_3.Text = newsgroup.ImageThumb;
                txtimage16_9.Text = newsgroup.ImageLarge;

                if (newsgroup.ImageThumb != "")
                    img_thumb.Text = "<img src='" + newsgroup.ImageThumb + "' width='48px' valign='middle'>";
                if (newsgroup.ImageLarge != "")
                    img_large.Text = "<img src='" + newsgroup.ImageLarge + "' width='48px' valign='middle'>";

                hddFileName.Value = newsgroup.FileName;

                txtAuthor.Text = newsgroup.Author;
                txtRadDate.Text = String.Format("{0:dd/MM/yyyy HH:mm}", newsgroup.PostDate);//DateTime.Parse(newsgroup.PostDate.ToString()).ToString("dd/MM/yyyy hh:mm", ci); // newsgroup.PostDate.ToString();
                hddPostDate.Value = String.Format("{0:dd/MM/yyyy HH:mm}", newsgroup.PostDate); // "9/3/2008 16:05:07" .ToString();
                
                hddRelationTotal.Value = Convert.ToString(newsgroup.RelationTotal);
                rdbStatus.Checked = newsgroup.Status;
                rdbIshot.Checked = newsgroup.Ishot;
                rdbIshome.Checked = newsgroup.Ishome;


                hddCommentTotal.Value = Convert.ToString(newsgroup.CommentTotal);
                hddIsView.Value = Convert.ToString(newsgroup.Isview);
                hddCreateUserName.Value = newsgroup.CreatedUserName;
                hddApprovalUserName.Value = newsgroup.ApprovalUserName;
                hddApprovalDate.Value = Convert.ToString(newsgroup.ApprovalDate);

                txtKeywords.Text = newsgroup.Keyword;
                txtTags.Text = newsgroup.Tags;
                txtSlug.Text = newsgroup.Slug;

                rdbComment.Checked = newsgroup.IsComment;

                admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                {
                    rdbApproval.Checked = newsgroup.IsApproval;
                    rdbApproval.Enabled = true;
                }
                else
                {
                    rdbApproval.Checked = newsgroup.IsApproval;
                    rdbApproval.Enabled = false;
                }

                hddGroup.Value = newsgroup.GroupCate.ToString();
                BindToCateNews(newsgroup.GroupCate);
                ddlCateNewsGroup.SelectedValue = hddGroup.Value;
                ddlCateNews.SelectedValue = Convert.ToString(newsgroup.CateNewsID);

                rdbTypeNews.Checked = newsgroup.TypeNews;

                txtShortTitle.Text = newsgroup.ShortTitle;
                chkUrl.Checked = newsgroup.isUrl;
                txtUrl.Text = newsgroup.Url;
                if (newsgroup.isUrl)
                {
                    txtUrl.Visible = true;
                    panelUrl.Visible = true;
                }
                else
                {
                    txtUrl.Visible = false;
                    panelUrl.Visible = false;
                }

                hddisDelete.Value = newsgroup.isDelete.ToString();

                BindListCate(newsgroup.NewsGroupID); //MultiCate
                ViewNewsLog(newsgroup.NewsGroupID);

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            txtRadDate.Text = String.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now);//DateTime.Parse(newsgroup.PostDate.ToString()).ToString("dd/MM/yyyy hh:mm", ci); // newsgroup.PostDate.ToString();
            hddPostDate.Value = String.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now); // "9/3/2008 16:05:07" .ToString();
            
            txtUrl.Visible = false;
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_add2.Visible = true;
            btn_edit1.Visible = false;
            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
            {
                rdbApproval.Enabled = true;
            }
            else
            {

                rdbApproval.Enabled = false;
            }
            txtUrl.Visible = false;
            panelUrl.Visible = false;
            chkUrl.Checked = false;
        }
    }

    private void initControl(int Id, int subId)
    {
        AdminBSO adminBSO = new AdminBSO();
        Admin admin = new Admin();
        if (Id > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;
            btn_add2.Visible = false;
            btn_add1.Visible = false;
            btn_edit1.Visible = true;
            try
            {
                NewsLog newsgroup = new NewsLog();
                NewsLogBSO newsgroupBSO = new NewsLogBSO();
                newsgroup = newsgroupBSO.GetNewsLogById(subId);

                //NewsGroup newsgroup = new NewsGroup();
                //NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
                //newsgroup = newsgroupBSO.GetNewsGroupById(Id);
                hddNewsGroupID.Value = Convert.ToString(newsgroup.NewsGroupID);
                ddlCateNews.SelectedValue = Convert.ToString(newsgroup.CateNewsID);
                hddParentNewsID.Value = Convert.ToString(newsgroup.ParentNewsID);

                //rdbGroupCate.SelectedValue = Convert.ToString(newsgroup.GroupCate); //Thêm

                txtTitle.Text = newsgroup.Title;
                txtRadShort.Text = System.Net.WebUtility.HtmlDecode(newsgroup.ShortDescribe);
                txtRadFull.Text = newsgroup.FullDescribe;
                hddImageThumb.Value = newsgroup.ImageThumb;
                hddImageLarge.Value = newsgroup.ImageLarge;

                txtimage4_3.Text = newsgroup.ImageThumb;
                txtimage16_9.Text = newsgroup.ImageLarge;

                if (newsgroup.ImageThumb != "")
                    img_thumb.Text = "<img src='" + newsgroup.ImageThumb + "' width='48px' valign='middle'>";
                if (newsgroup.ImageLarge != "")
                    img_large.Text = "<img src='" + newsgroup.ImageLarge + "' width='48px' valign='middle'>";


                hddFileName.Value = newsgroup.FileName;

                txtAuthor.Text = newsgroup.Author;
                txtRadDate.Text = String.Format("{0:dd/MM/yyyy HH:mm}", newsgroup.PostDate);//DateTime.Parse(newsgroup.PostDate.ToString()).ToString("dd/MM/yyyy hh:mm", ci); // newsgroup.PostDate.ToString();
                hddPostDate.Value = String.Format("{0:dd/MM/yyyy HH:mm}", newsgroup.PostDate); // "9/3/2008 16:05:07" .ToString();
                hddRelationTotal.Value = Convert.ToString(newsgroup.RelationTotal);
                rdbStatus.Checked = newsgroup.Status;
                rdbIshot.Checked = newsgroup.Ishot;
                rdbIshome.Checked = newsgroup.Ishome;


                hddCommentTotal.Value = Convert.ToString(newsgroup.CommentTotal);
                hddIsView.Value = Convert.ToString(newsgroup.Isview);
                hddCreateUserName.Value = newsgroup.CreatedUserName;
                hddApprovalUserName.Value = newsgroup.ApprovalUserName;
                hddApprovalDate.Value = Convert.ToString(newsgroup.ApprovalDate);

                txtKeywords.Text = newsgroup.Keyword;
                txtTags.Text = newsgroup.Tags;
                txtSlug.Text = newsgroup.Slug;

                rdbComment.Checked = newsgroup.IsComment;

                rdbApproval.Checked = newsgroup.IsApproval;

                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                {
                    rdbApproval.Enabled = true;
                }
                else
                {
                    rdbApproval.Enabled = false;
                }

                //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                //if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                //{
                //    rdbApproval.Checked = newsgroup.IsApproval;
                //    rdbApproval.Enabled = true;
                //}
                //else
                //{
                //    rdbApproval.Checked = newsgroup.IsApproval;
                //    rdbApproval.Enabled = false;
                //}

                hddGroup.Value = newsgroup.GroupCate.ToString();
                BindToCateNews(newsgroup.GroupCate);
                ddlCateNewsGroup.SelectedValue = hddGroup.Value;
                ddlCateNews.SelectedValue = Convert.ToString(newsgroup.CateNewsID);

                rdbTypeNews.Checked = newsgroup.TypeNews;

                txtShortTitle.Text = newsgroup.ShortTitle;
                chkUrl.Checked = newsgroup.isUrl;
                txtUrl.Text = newsgroup.Url;
                if (newsgroup.isUrl)
                {
                    txtUrl.Visible = true;
                    panelUrl.Visible = true;
                }
                else
                {
                    txtUrl.Visible = false;
                    panelUrl.Visible = false;
                }
                hddisDelete.Value = newsgroup.isDelete.ToString();
                BindListCate(newsgroup.NewsGroupID); //MultiCate
                ViewNewsLog(newsgroup.NewsGroupID);

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            txtRadDate.Text = String.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now);//DateTime.Parse(newsgroup.PostDate.ToString()).ToString("dd/MM/yyyy hh:mm", ci); // newsgroup.PostDate.ToString();
            hddPostDate.Value = String.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now); // "9/3/2008 16:05:07" .ToString();

            txtUrl.Visible = false;
            btn_add.Visible = true;
            btn_edit.Visible = false;
            btn_add2.Visible = true;
            btn_add1.Visible = true;
            btn_edit1.Visible = false;
            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
            {
                rdbApproval.Enabled = true;
            }
            else
            {
                rdbApproval.Enabled = false;
            }
            txtUrl.Visible = false;
            panelUrl.Visible = false;
            chkUrl.Checked = false;

        }
    }
   
    #endregion

    #region ReceiveHtml
    private NewsGroup ReceiveHtml()
    {
        //ConfigBSO configBSO = new ConfigBSO();
        //Config config = configBSO.GetAllConfig(Language.language);
        //int thumb_w = Convert.ToInt32(config.New_thumb_w);
        //int thumb_h = Convert.ToInt32(config.New_thumb_h);

        //commonBSO commonBSO = new commonBSO();
        //string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/NewsGroup/NewsGroupThumb/";
        //string image_thumb = commonBSO.UploadImage(file_image_thumb, path_thumb, thumb_w, thumb_h, GetString(txtTitle.Text));

        //int large_w = Convert.ToInt32(config.New_large_w);
        //int large_h = Convert.ToInt32(config.New_large_h);
        //string path_large = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/NewsGroup/NewsGroupLarge/";
        //string image_large = commonBSO.UploadImage(file_image_large, path_large, large_w, large_h, GetString(txtTitle.Text));

        //string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/NewsGroup/Files/";
        //// string file_upload = commonBSO.UploadFile(file_attached, path, 1800000000000);
        string file_upload = "";


        NewsGroup newsgroup = new NewsGroup();
        newsgroup.NewsGroupID = (hddNewsGroupID.Value != "") ? Convert.ToInt32(hddNewsGroupID.Value) : 0;
        newsgroup.CateNewsID = Convert.ToInt32(ddlCateNews.SelectedValue);
        newsgroup.ParentNewsID = (hddParentNewsID.Value != "") ? Convert.ToInt32(hddParentNewsID.Value) : 0;
        //newsgroup.GroupCate = Convert.ToInt32(hddGroup.Value);
        newsgroup.GroupCate = Convert.ToInt32(ddlCateNewsGroup.SelectedValue);

        newsgroup.Title = txtTitle.Text;
        newsgroup.ShortDescribe = txtRadShort.Text;
        newsgroup.FullDescribe = txtRadFull.Text;
        newsgroup.ImageThumb = (txtimage4_3.Text != "") ? txtimage4_3.Text : hddImageThumb.Value;
        newsgroup.ImageLarge = (txtimage16_9.Text != "") ? txtimage16_9.Text : hddImageLarge.Value;
        newsgroup.FileName = (file_upload != "") ? file_upload : hddFileName.Value;

        newsgroup.Author = txtAuthor.Text;
        IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
        newsgroup.PostDate = DateTime.ParseExact(txtRadDate.Text, "dd/MM/yyyy HH:mm", culture);

        newsgroup.RelationTotal = (hddRelationTotal.Value != "") ? Convert.ToInt32(hddRelationTotal.Value) : 0;
        newsgroup.Status = rdbStatus.Checked;
        newsgroup.Language = Language.language;
        newsgroup.Ishot = rdbIshot.Checked;
        newsgroup.Ishome = rdbIshome.Checked;

        newsgroup.TypeNews = rdbTypeNews.Checked;

        newsgroup.IsComment = rdbComment.Checked;

        newsgroup.Isview = (hddIsView.Value != "") ? Convert.ToInt32(hddIsView.Value) : 0;
        newsgroup.CommentTotal = (hddCommentTotal.Value != "") ? Convert.ToInt32(hddCommentTotal.Value) : 0;

        newsgroup.CreatedUserName = (hddCreateUserName.Value != "") ? hddCreateUserName.Value : Session["Admin_UserName"].ToString();

        newsgroup.Keyword = txtKeywords.Text;
        newsgroup.Tags = txtTags.Text;
        newsgroup.Slug = (txtSlug.Text != "") ? GetString(txtTitle.Text) : txtSlug.Text;

        newsgroup.IsApproval = rdbApproval.Checked;

        if (hddApprovalUserName.Value != "")
        {
            newsgroup.ApprovalUserName = hddApprovalUserName.Value;
            newsgroup.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
        }
        else
            if (rdbApproval.Checked)
            {
                newsgroup.ApprovalUserName = Session["Admin_UserName"].ToString();
                newsgroup.ApprovalDate = DateTime.Now;
            }
            else
            {
                newsgroup.ApprovalUserName = "";
                newsgroup.ApprovalDate = DateTime.Now;
            }
        newsgroup.ShortTitle = (txtShortTitle.Text != "") ? txtShortTitle.Text : txtTitle.Text;
        newsgroup.isUrl = chkUrl.Checked;
        newsgroup.Url = txtUrl.Text;
        newsgroup.isDelete = (hddisDelete.Value != "") ? Convert.ToBoolean(hddisDelete.Value) : false;

        return newsgroup;

    }
    #endregion


    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            NewsGroup newsgroup = ReceiveHtml();
            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            int _newsgroupID = newsgroupBSO.CreateNewsGroupGet(newsgroup);

          

            add_NewsCate(_newsgroupID);

            NewsLogBSO newsLogBSO = new NewsLogBSO();
            NewsLog _newsLog = newsLogBSO.GetNewsLog(newsgroup, Session["Admin_UserName"].ToString(), DateTime.Now, 0);
            int _newsLogID = newsLogBSO.CreateNewsLog(_newsLog);

            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            initControl(_newsgroupID);
            AspNetCache.Reset();
            ViewNewsLog(_newsgroupID);
            //Response.Redirect("~/Admin/Group/listnewsgroup/" + hddGroup.Value + "/Default.aspx");
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }

    protected void btn_add_Click_more(object sender, EventArgs e)
    {
        try
        {
            NewsGroup newsgroup = ReceiveHtml();
            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            int _newsgroupID = newsgroupBSO.CreateNewsGroupGet(newsgroup);


           
            //Add NewsCate
            add_NewsCate(_newsgroupID);

            NewsLogBSO newsLogBSO = new NewsLogBSO();
            NewsLog _newsLog = newsLogBSO.GetNewsLog(newsgroup, Session["Admin_UserName"].ToString(), DateTime.Now, 0);
            int _newsLogID = newsLogBSO.CreateNewsLog(_newsLog);


            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            AspNetCache.Reset();
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }

    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {
            NewsGroup newsgroup = ReceiveHtml();
            NewsGroupBSO newsgroupBSO = new NewsGroupBSO();
            newsgroupBSO.UpdateNewsGroup(newsgroup);

        
            //Add NewsCate
            NewsCateBSO _newscateBSO = new NewsCateBSO();
            DataTable tblNewsCate = _newscateBSO.GetNewsCateByNewsGroupID(newsgroup.NewsGroupID);
            if (tblNewsCate.Rows.Count > 0)
                _newscateBSO.DeleteNewsCatebyNewsID(newsgroup.NewsGroupID);

            add_NewsCate(newsgroup.NewsGroupID);

            NewsLogBSO newsLogBSO = new NewsLogBSO();
            NewsLog _newsLog = newsLogBSO.GetNewsLog(newsgroup, Session["Admin_UserName"].ToString(), DateTime.Now, 0);
            int _newsLogID = newsLogBSO.CreateNewsLog(_newsLog);

            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
            initControl(newsgroup.NewsGroupID);
            ViewNewsLog(newsgroup.NewsGroupID);
            AspNetCache.Reset();
            //ViewCateNews(Convert.ToInt32(hddGroup.Value));
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }

    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/listnews/Default.aspx");

    }
    protected void btn_create_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/editnews/Default.aspx");

    }

    protected void BindToCateNewsGroup()
    {

        DataTable datatable = new DataTable();

        CateNewsGroupBSO _catenewsgroupBSO = new CateNewsGroupBSO();
        datatable = _catenewsgroupBSO.GetCateNewsGroupNewAll(Language.language, Session["Admin_UserName"].ToString());


        ddlCateNewsGroup.DataTextField = "CateNewsGroupName";
        ddlCateNewsGroup.DataValueField = "GroupCate";
        ddlCateNewsGroup.DataSource = datatable;
        ddlCateNewsGroup.DataBind();

        ddlCateNewsGroup.SelectedValue = datatable.Rows[0]["GroupCate"].ToString();
        BindToCateNews(Convert.ToInt32(datatable.Rows[0]["GroupCate"].ToString()));

        lboGroupCate.DataTextField = "CateNewsGroupName";
        lboGroupCate.DataValueField = "GroupCate";
        lboGroupCate.DataSource = datatable;
        lboGroupCate.DataBind();

        if (datatable.Rows.Count > 0)
        {
            lboGroupCate.SelectedValue = datatable.Rows[0]["GroupCate"].ToString();
        }

    }


    protected void BindToCateNews(int _group)
    {


        ddlCateNews.Items.Clear();
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, _group, Session["Admin_UserName"].ToString());

        ddlCateNews.DataTextField = "CateNewsName";
        ddlCateNews.DataValueField = "CateNewsID";
        ddlCateNews.DataSource = table;
        ddlCateNews.DataBind();

        if (table.Rows.Count > 0)
        {
            ddlCateNews.SelectedValue = table.Rows[0]["CateNewsID"].ToString();
        }

        //commonBSO commonBSO = new commonBSO();
        //commonBSO.FillToCheckBoxList(chkCateNews, table, "CateNewsName", "CateNewsID");

    }

    protected void BindToCateNewsLBO(int _group)
    {


        lboCateNews.Items.Clear();
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, _group, Session["Admin_UserName"].ToString());

        string strId = ListCate();
        if (strId != "")
            strId = strId.Remove(strId.LastIndexOf(",")).Replace(",", "','");
        DataView view = new DataView(table);
        view.RowFilter = "CateNewsID not in ('" + strId + "')";

        lboCateNews.DataTextField = "CateNewsName";
        lboCateNews.DataValueField = "CateNewsID";
        lboCateNews.DataSource = view.ToTable();
        lboCateNews.DataBind();

    }

    protected void ddlCateNewsGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindToCateNews(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
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
    protected void btnTags_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text != "")
        {
            CateNewsGroupBSO _catenewsgroupBSO = new CateNewsGroupBSO();

            txtSlug.Text = GetString(txtTitle.Text);

            if (txtTags.Text == "")
            {
                txtTags.Text = ddlCateNews.SelectedItem.Text.Replace(",", "");
                txtTags.Text += "," + ddlCateNewsGroup.SelectedItem.Text.Replace(",", "");
            }
            if (txtKeywords.Text == "")
            {
                txtKeywords.Text = ddlCateNews.SelectedItem.Text.Replace(",", "");
                txtKeywords.Text += "," + ddlCateNewsGroup.SelectedItem.Text.Replace(",", "");
            }
        }


    }

    protected void chkUrl_CheckedChanged(object sender, EventArgs e)
    {
        if (chkUrl.Checked)
        {
            txtUrl.Visible = true;
            panelUrl.Visible = true;
        }
        else
        {
            txtUrl.Visible = false;
            panelUrl.Visible = false;
        }

    }

    #region CheckedList
    //private string CheckedList()
    //{
    //    string strID = "";
    //    foreach (ListItem items in chkCateNews.Items)
    //    {
    //        if (items.Selected)
    //            strID += items.Value + ",";
    //    }
    //    return strID;
    //}

    //private void BindChecklist(int newsgroupID)
    //{
    //    NewsCateBSO newsCateBSO = new NewsCateBSO();
    //    DataTable table = newsCateBSO.GetNewsCateByNewsGroupID(newsgroupID);
    //    if (table.Rows.Count > 0)
    //    {
    //        for (int i = 0; i < table.Rows.Count; i++)
    //        {
    //            DataRow row = table.Rows[i];
    //            foreach (ListItem items in chkCateNews.Items)
    //            {
    //                if (items.Value.Equals(row["CateNewsID"].ToString()))
    //                    items.Selected = true;
    //            }
    //        }
    //    }

    //}

    #endregion

    protected void add_Tags(string _newsTags, int _newsgroupID)
    {
        

    }

    protected void add_NewsCate(int _newsgroupID)
    {
        NewsCateBSO _newscateBSO = new NewsCateBSO();
        NewsCate _newsCate = new NewsCate();

        foreach (ListItem items in lboCateSelect.Items)
        {
            _newsCate.CateNewsID = Convert.ToInt32(items.Value);
            _newsCate.NewsGroupID = _newsgroupID;

            int i = _newscateBSO.CreateNewsCateGet(_newsCate);

            //strID += items.Value + ",";
        }

        //foreach (ListItem items in lboCateSelect.Items)
        //{
        //    if (items.Selected)
        //    {
        //        _newsCate.CateNewsID = Convert.ToInt32(items.Value);
        //        _newsCate.NewsGroupID = _newsgroupID;

        //        int i = _newscateBSO.CreateNewsCateGet(_newsCate);

        //    }
        //}
    }


    protected void lboGroupCate_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindToCateNewsLBO(Convert.ToInt32(lboGroupCate.SelectedValue));
    }

    protected void btn_add_list(object sender, EventArgs e)
    {
        if (lboCateNews.SelectedIndex >= 0)
        {
            lboCateSelect.Items.Add(new ListItem(lboCateNews.SelectedItem.Text, lboCateNews.SelectedValue));
            lboCateNews.Items.Remove(new ListItem(lboCateNews.SelectedItem.Text, lboCateNews.SelectedValue));
        }

    }

    protected void btn_remove_list(object sender, EventArgs e)
    {
        if (lboCateSelect.SelectedIndex >= 0)
            lboCateSelect.Items.Remove(new ListItem(lboCateSelect.SelectedItem.Text, lboCateSelect.SelectedValue));
    }

    #region ListCate
    private string ListCate()
    {
        string strID = "";
        foreach (ListItem items in lboCateSelect.Items)
        {
            strID += items.Value + ",";
        }
        return strID;
    }

    private void BindListCate(string _value)
    {
        if (_value != "")
        {
            lboCateSelect.Items.Clear();
            _value = _value.Replace(" ", "").Trim();
            _value = (!_value.Substring(_value.Length - 1, 1).Equals(",")) ? _value + "," : _value;

            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateNewsBystrId(_value);

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    lboCateSelect.Items.Add(new ListItem(row["CateNewsName"].ToString(), row["CateNewsID"].ToString()));
                }
            }
        }

    }

    private void BindListCate(int newsgroupID)
    {
        NewsCateBSO newsCateBSO = new NewsCateBSO();
        DataTable table = newsCateBSO.GetNewsCateByNewsGroupID(newsgroupID);
        string strID = "";
        if (table.Rows.Count > 0)
        {

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                strID += row["CateNewsID"].ToString() + ",";
            }
        }
        if (strID != "")
        {
            lboCateSelect.Items.Clear();
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table1 = catenewsBSO.GetCateNewsBystrId(strID);

            if (table1.Rows.Count > 0)
            {
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    DataRow row = table1.Rows[i];
                    lboCateSelect.Items.Add(new ListItem(row["CateNewsName"].ToString(), row["CateNewsID"].ToString()));
                }
            }
        }

    }

    #endregion

    protected void txtRadShort_TextChanged(object sender, EventArgs e)
    {
        if (Tool.CountWords2(Tool.StripTagsCharArray(txtRadShort.Text)) > 60)
        {
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Mô tả tin quá 60 từ !</div>";
        }
    }

    protected void grvNewsLog_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        NewsLogBSO newsLogBSO = new NewsLogBSO();
        NewsLog newslog = newsLogBSO.GetNewsLogById(Id);

        string nName = e.CommandName.ToLower();
        AdminBSO adminBSO = new AdminBSO();
        Admin admin = new Admin();
        switch (nName)
        {


            case "_view":
                break;
            case "_edit":
                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    // Response.Redirect("~/Admin/editnewslog/" + Id + "/Default.aspx");
                    Response.Redirect("~/Admin/s/EditNewsbyUser/" + hddNewsGroupID.Value + "/" + Id + "/Default.aspx");
                }
                break;

            case "_delete":
                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    newsLogBSO.DeleteNewsLog(Id, -1);
                    ViewNewsLog(Convert.ToInt32(hddNewsGroupID.Value));
                    AspNetCache.Reset();
                }


                break;
        }
    }

    protected void grvNewsLog_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            LinkButton image_view = (LinkButton)e.Row.FindControl("btn_view");
            image_view.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/NewsFlow/ViewNewsLog.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "NewsLogID") + "','_blank','width=800,height=600');return false;");


            LinkButton image_edit = (LinkButton)e.Row.FindControl("btn_edit");

            AdminBSO adminBSO = new AdminBSO();

            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
            {
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
            }
            else
            {
                image_edit.Attributes.Add("onclick", "javascript:return alert('Bạn không có đủ quyền ???');");
                image_del.Attributes.Add("onclick", "javascript:return alert('Bạn không có đủ quyền ???');");
            }


        }
    }

    #region ViewNewsLog
    private void ViewNewsLog(int newsGroupID)
    {
        commonBSO commonBSO = new commonBSO();
        NewsLogBSO newsLogBSO = new NewsLogBSO();
        DataTable table = new DataTable();


        _page = new PagingInfo(10, Convert.ToInt32(hdnPage.Value), true);
        table = newsLogBSO.GetNewsLogPaging(Language.language, newsGroupID, _page);


        if (table.Rows.Count > 0)
        {
            TotalRecord = Convert.ToInt32(table.Rows[0]["Total"].ToString());
            SetAttributeGvArticle(Convert.ToInt32(table.Rows[0]["Total"].ToString()));
            commonBSO.FillToGridView(grvNewsLog, table);

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
            grvNewsLog.DataSource = null;
            grvNewsLog.DataBind();
            Paging.Visible = false;
        }

    }
    #endregion

    public void Paging_Click(object sender, CommandEventArgs e)
    {

        string CurrentPage = e.CommandArgument.ToString();
        hdnPage.Value = CurrentPage;
        _page = new PagingInfo(10, Convert.ToInt32(hdnPage.Value), true);
        ViewNewsLog(Convert.ToInt32(hddNewsGroupID.Value));

    }
    private void SetAttributeGvArticle(int totalRecord)
    {

        Paging.PageSize = Convert.ToInt32(_page.PageSize);
        Paging.TotalRecord = totalRecord;
        Paging.CurrentPage = grvNewsLog.PageIndex + Convert.ToInt32(hdnPage.Value);
        Paging.TotalNumberPaging = 10;
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
}
