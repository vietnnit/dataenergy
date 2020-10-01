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
using DAO;
using BSO;
public partial class Client_Admin_EditNewsComment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        int group = 0;
        if (!String.IsNullOrEmpty(Request["group"]))
            int.TryParse(Request["group"].Replace(",", ""), out group);

        hddGroup.Value = Convert.ToString(group);
        if (!IsPostBack)
        {
            initEditor();
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
        txtContent.config.toolbar = new object[]
        {
            new object[] { "Source" },
            new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },
            new object[] { "NumberedList", "BulletedList", "-", "Outdent", "Indent" },
            "/",
            new object[] { "Styles", "Format", "Font", "FontSize", "TextColor", "BGColor", "-", "About" },
        };

        //txtRadFull.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        //txtRadFull.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        //txtRadFull.config.format_div = @"{ element : 'div' }";

        txtContent.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        txtContent.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        txtContent.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        txtContent.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        txtContent.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        txtContent.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        txtContent.config.entities = false;
        //txtRadFull.config.filebrowserWindowWidth = '1000',
        //txtRadFull.config.filebrowserWindowHeight = '700'
    }

    #region initControl
    protected void initControl(int Id)
    {
        //txtContent.DisableFilter(Telerik.Web.UI.EditorFilters.ConvertCharactersToEntities);

        AdminBSO adminBSO = new AdminBSO();
        Admin admin = new Admin();
        if (Id > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_edit1.Visible = true;

            hddCommentID.Value = Convert.ToString(Id);
            try
            {
                NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
                NewsComment newsComment = newsCommentBSO.GetNewsCommentById(Id);
                txtTitle.Text = newsComment.Title;
                txtFullName.Text = newsComment.FullName;
                hddNewsID.Value = Convert.ToString(newsComment.NewsID);
                txtContent.Text = newsComment.Content;
                txtDateCreated.Text = String.Format("{0:dd/MM/yyyy HH:mm}", newsComment.DateCreated);//DateTime.Parse(newsgroup.PostDate.ToString()).ToString("dd/MM/yyyy hh:mm", ci); // newsgroup.PostDate.ToString();
                hddPostDate.Value = String.Format("{0:dd/MM/yyyy HH:mm}", newsComment.DateCreated); // "9/3/2008 16:05:07" .ToString();
               
                txtEmail.Text = newsComment.Email;
                //       rdbActive.SelectedValue = newsComment.Actived.ToString();
                hddGroup.Value = newsComment.GroupCate.ToString();

                hddApprovalUserName.Value = newsComment.ApprovalUserName;
                hddApprovalDate.Value = Convert.ToString(newsComment.ApprovalDate);

                admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
                {
                    rdbActive.Checked = newsComment.Actived;
                    rdbActive.Enabled = true;
                }
                else
                {
                    rdbActive.Checked = newsComment.Actived;
                    rdbActive.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_edit1.Visible = false;
            //     hddNewsID = 0;
            txtDateCreated.Text = String.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now);//DateTime.Parse(newsgroup.PostDate.ToString()).ToString("dd/MM/yyyy hh:mm", ci); // newsgroup.PostDate.ToString();
            hddPostDate.Value = String.Format("{0:dd/MM/yyyy HH:mm}", DateTime.Now); // "9/3/2008 16:05:07" .ToString();
             
            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
            {

                rdbActive.Enabled = true;
            }
            else
            {

                rdbActive.Enabled = false;
            }
        }
    }
    #endregion

    #region ReceiveHtml
    protected NewsComment ReceiveHtml()
    {


        NewsComment newsComment = new NewsComment();
        newsComment.CommentNewsID = (hddCommentID.Value != "") ? Convert.ToInt32(hddCommentID.Value) : 0;
        newsComment.NewsID = (hddNewsID.Value != "") ? Convert.ToInt32(hddNewsID.Value) : 0;
        newsComment.Title = txtTitle.Text;
        newsComment.Content = txtContent.Text;

        newsComment.FullName = txtFullName.Text;
        newsComment.Email = txtEmail.Text;
        IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
        newsComment.DateCreated = DateTime.ParseExact(txtDateCreated.Text, "dd/MM/yyyy HH:mm", culture);

        //    newsComment.Actived = Convert.ToBoolean(rdbActive.SelectedItem.Value);
        newsComment.GroupCate = Convert.ToInt32(hddGroup.Value);

        newsComment.Actived = rdbActive.Checked;
        if (hddApprovalUserName.Value != "")
        {
            newsComment.ApprovalUserName = hddApprovalUserName.Value;
            newsComment.ApprovalDate = Convert.ToDateTime(hddApprovalDate.Value);
        }
        else
            if (rdbActive.Checked)
            {
                newsComment.ApprovalUserName = Session["Admin_UserName"].ToString();
                newsComment.ApprovalDate = DateTime.Now;
            }
            else
            {
                newsComment.ApprovalUserName = "";
                newsComment.ApprovalDate = DateTime.Now;
            }

        return newsComment;
    }
    #endregion
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            NewsComment newsComment = ReceiveHtml();
            NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
           int id =  newsCommentBSO.CreateNewsCommentGet(newsComment);
          //  clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
           clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            initControl(id);

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
            NewsComment newsComment = ReceiveHtml();
            NewsCommentBSO newsCommentBSO = new NewsCommentBSO();
            newsCommentBSO.UpdateNewsComment(newsComment);
            //clientview.Text = String.Format(Resources.StringAdmin.UpdateSuccessful, "Nhận xét", newsComment.Title);
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
            initControl(newsComment.CommentNewsID);
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }

    protected void btn_list(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Group/listnewscomment/" + hddGroup.Value +"/Default.aspx");
    }
    protected void btn_editcomment(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Group/editnewscomment/" + hddGroup.Value +"/Default.aspx");

    }
}
