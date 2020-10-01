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
public partial class Client_Admin_ListNews : System.Web.UI.UserControl
{
    PagingInfo _page = new PagingInfo(20, 1, true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        AdminBSO adminBSO = new AdminBSO();
        //Admin admin = new Admin();
        //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

        if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
        {
            btn_editpage.Visible = true;
            btn_enable.Visible = true;
            btn_disable.Visible = true;
            btn_delall.Visible = true;

        }
        else
        {
            btn_editpage.Visible = false;
            btn_enable.Visible = false;
            btn_disable.Visible = false;
            btn_delall.Visible = false;
        }

        if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Approval"))
        {
            btn_enable_approval.Visible = true;
            btn_disable_approval.Visible = true;

        }
        else
        {
            btn_enable_approval.Visible = false;
            btn_disable_approval.Visible = false;
        }

        int group = -1;
        //if (!String.IsNullOrEmpty(Request["group"]))
        //    if (!int.TryParse(Request["group"].Replace(",", ""), out group))
        //        Response.Redirect("~/Admin/home/Default.aspx");


        hddGroup.Value = Convert.ToString(group);

        if (!IsPostBack)
        {
            BindControl(group);
            ViewNewsGroup(group);

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


    #region ViewNewsGroup
    private void ViewNewsGroup(int group)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        DataTable table = new DataTable();


        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);

        if (!Session["Admin_UserName"].Equals("administrator"))
        {
            string strCate = GetCateParentIDArrayByID();
            if (strCate != "")
                table = newsGroupBSO.GetNewsGroupPaging(Language.language, group, strCate, _page);
        }
        else
        {
            table = newsGroupBSO.GetNewsGroupPaging(Language.language, group, _page);
        }

        if (table.Rows.Count > 0)
        {
            TotalRecord = Convert.ToInt32(table.Rows[0]["Total"].ToString());
            SetAttributeGvArticle(Convert.ToInt32(table.Rows[0]["Total"].ToString()));
           // commonBSO.FillToGridView(grvNewsGroup, table);
            grvNewsGroup.DataSource = table;
            grvNewsGroup.DataBind();

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

    private string GetCateParentIDArrayByID(int group)
    {
        
        string strArrayID = "";

        CateNewsBSO cateNewsBSO = new CateNewsBSO();
        DataTable table1 = new DataTable();

        if (group != -1)
        {
            table1 = cateNewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
        }
        else
        {
            table1 = cateNewsBSO.GetCateRoles(Language.language, Session["Admin_UserName"].ToString());
        }

        if (table1.Rows.Count > 0)
        {
            foreach (DataRow subrow in table1.Rows)
            {
                strArrayID += subrow["CateNewsID"].ToString() + ",";
            }

        }

        return strArrayID;

    }

    private string GetCateParentIDArrayByID()
    {
        string strArrayID = "";

        CateNewsBSO cateNewsBSO = new CateNewsBSO();
        DataTable table1 = cateNewsBSO.GetCateRoles(Language.language, Session["Admin_UserName"].ToString());

        if (table1.Rows.Count > 0)
        {
            foreach (DataRow subrow in table1.Rows)
            {
                strArrayID += subrow["CateNewsID"].ToString() + ",";
            }

        }

        return strArrayID;

    }

    #region BindControl
    private void BindControl(int group)
    {
        ddlCateNewsSearch.Items.Clear();
        CateNewsGroupBSO catenewsGroupBSO = new CateNewsGroupBSO();
        DataTable table = catenewsGroupBSO.GetCateNewsGroupNewAll(Language.language, Session["Admin_UserName"].ToString());
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToDropDown(ddlCateNewsGroup, table, "~~ Trong tất cả ~~", "-1", "CateNewsGroupName", "GroupCate", "");

        ddlType.Items.Clear();
        ddlType.Items.Add(new ListItem("-- Tất cả --", "0"));
        ddlType.Items.Add(new ListItem("Tiêu đề", "1"));
        ddlType.Items.Add(new ListItem("Mô tả tin", "2"));
        ddlType.SelectedValue = "1";

        ddlTypeApproved.Items.Clear();
        ddlTypeApproved.Items.Add(new ListItem("-- Tất cả --", "0"));
        ddlTypeApproved.Items.Add(new ListItem("Bài chờ duyệt", "1"));
        ddlTypeApproved.Items.Add(new ListItem("Bài đã xuất bản", "2"));
        ddlTypeApproved.Items.Add(new ListItem("Bài đã khóa", "3"));
        ddlTypeApproved.SelectedValue = "0";
    }

    private void ViewCateNews(int group)
    {
        ddlCateNewsSearch.Items.Clear();
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToDropDown(ddlCateNewsSearch, table, "~~ Trong tất cả ~~", "0", "CateNewsName", "CateNewsID", "");
    }
    #endregion

    #region NewsGroupID
    private string NewsGroupID()
    {
        string newsGroupId = "";
        foreach (GridViewRow rows in grvNewsGroup.Rows)
        {
            CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
            if (checkbox.Checked)
                newsGroupId += rows.Cells[0].Text + ",";
        }
        return newsGroupId;
    }

    #endregion

    protected void grvNewsGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        NewsGroup newsgroup = newsGroupBSO.GetNewsGroupById(Id);

        string nName = e.CommandName.ToLower();
        AdminBSO adminBSO = new AdminBSO();
        Admin admin = new Admin();
        switch (nName)
        {
            case "_listfiles":
                //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());
                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    Response.Redirect("~/Admin/listnewsfiles/" + Id + "/Default.aspx");
                }
                break;

            case "_addfiles":
                //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());
                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    Response.Redirect("~/Admin/editnewsfiles/" + Id + "/0/Default.aspx");
                }
                break;

            case "_relation":
                //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());
                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    Response.Redirect("~/Admin/EditNewsRelation/" + Id + "/Default.aspx");
                }
                break;

            case "_view":
                break;
            case "_edit":

                //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());
                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {
                    Response.Redirect("~/Admin/editnews/"+ Id + "/Default.aspx");
                }
                break;

            case "_delete":
                //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

                if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
                {

                    //newsGroupBSO.DeleteNewsGroup(Id);
                    newsGroupBSO.UpdateNewsGroupisDelete(Id, "1");
                    ViewNewsGroup(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));

                    //NewsCateBSO newscateBSO = new NewsCateBSO();

                    //if (newscateBSO.GetNewsCateByNewsGroupID(Id).Rows.Count > 0)
                    //    newscateBSO.DeleteNewsCatebyNewsID(Id);

                    AspNetCache.Reset();

                }


                break;
        }
    }
    protected void grvNewsGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            LinkButton image_view = (LinkButton)e.Row.FindControl("btn_view");
            image_view.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/NewsFlow/ViewNewsGroup.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "NewsGroupID") + "','_blank','width=800,height=600');return false;");


            LinkButton image_edit = (LinkButton)e.Row.FindControl("btn_edit");
            LinkButton image_relation = (LinkButton)e.Row.FindControl("btn_releation");

            LinkButton image_files = (LinkButton)e.Row.FindControl("btn_files");
            LinkButton image_listfiles = (LinkButton)e.Row.FindControl("btn_listfiles");

            LinkButton link_Title = (LinkButton)e.Row.FindControl("linkTitle");

            AdminBSO adminBSO = new AdminBSO();
            //Admin admin = new Admin();
            //admin = adminBSO.GetAdminById(Session["Admin_UserName"].ToString());

            if (Session["Admin_UserName"].ToString().Equals("administrator") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Edit") || adminBSO.CheckPermission(Session["Admin_UserName"].ToString(), "Write"))
            {
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
            }
            else
            {
                image_edit.Attributes.Add("onclick", "javascript:return alert('Bạn không có đủ quyền ???');");
                image_del.Attributes.Add("onclick", "javascript:return alert('Bạn không có đủ quyền ???');");
                image_relation.Attributes.Add("onclick", "javascript:return alert('Bạn không có đủ quyền ???');");
                image_files.Attributes.Add("onclick", "javascript:return alert('Bạn không có đủ quyền ???');");
                image_listfiles.Attributes.Add("onclick", "javascript:return alert('Bạn không có đủ quyền ???');");
                link_Title.Attributes.Add("onclick", "javascript:return alert('Bạn không có đủ quyền ???');");
            }


        }
    }
    protected void grvNewsGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvNewsGroup.PageIndex = e.NewPageIndex;
        ViewNewsGroup(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
    }
    protected void btn_enable_Click(object sender, EventArgs e)
    {
        if (NewsGroupID() != "")
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            newsGroupBSO.UpdateNewsGroup(NewsGroupID(), "1");
        }
        ViewNewsGroup(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
        AspNetCache.Reset();
    }
    protected void btn_disable_Click(object sender, EventArgs e)
    {
        if (NewsGroupID() != "")
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            newsGroupBSO.UpdateNewsGroup(NewsGroupID(), "0");
        }
        ViewNewsGroup(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
        AspNetCache.Reset();
    }
    protected void btn_enable_approval_Click(object sender, EventArgs e)
    {
        if (NewsGroupID() != "")
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            newsGroupBSO.UpdateNewsGroupApproval(NewsGroupID(), "1", Session["Admin_UserName"].ToString(), DateTime.Now);
        }
        ViewNewsGroup(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
        AspNetCache.Reset();
    }
    protected void btn_disable_approval_Click(object sender, EventArgs e)
    {
        if (NewsGroupID() != "")
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            newsGroupBSO.UpdateNewsGroupApproval(NewsGroupID(), "0", Session["Admin_UserName"].ToString(), DateTime.Now);
        }
        ViewNewsGroup(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
        AspNetCache.Reset();
    }
    protected void btn_delall_Click(object sender, EventArgs e)
    {
        if (NewsGroupID() != "")
        {
            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            //newsGroupBSO.DeleteNewsGroup(NewsGroupID());
            newsGroupBSO.UpdateNewsGroupisDelete(NewsGroupID(), "1");
        }
        ViewNewsGroup(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
        AspNetCache.Reset();
    }


    protected void btn_comment_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/listnewscomment/Default.aspx");

    }
    protected void btn_edit_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/editnews/Default.aspx");

    }
    //protected void btn_register_click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Admin/Group/listnewsregister/" + ddlCateNewsGroup.SelectedValue + "/Default.aspx");

    //}

    public void Paging_Click(object sender, CommandEventArgs e)
    {

        string CurrentPage = e.CommandArgument.ToString();
        hdnPage.Value = CurrentPage;
        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);
        ViewNewsGroup(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));

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
    protected void ddlCateNewsGroupSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        DataTable table = new DataTable();


        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);


        if (!Session["Admin_UserName"].Equals("administrator"))
        {
            string strCate = GetCateParentIDArrayByID(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
            if (strCate != "")
                table = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(ddlCateNewsGroup.SelectedValue), strCate, _page);
        }
        else
        {
            table = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(ddlCateNewsGroup.SelectedValue), _page);
        }
     

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

        ViewCateNews(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
    }


    protected void ddlCateNewsSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        DataTable table = new DataTable();


        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);

        if (ddlCateNewsSearch.SelectedValue == "0")
        {
            if (!Session["Admin_UserName"].Equals("administrator"))
            {
                string strCate = GetCateParentIDArrayByID(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
                if (strCate != "")
                    table = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(ddlCateNewsGroup.SelectedValue), strCate, _page);
            }
            else
            {
                table = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(ddlCateNewsGroup.SelectedValue), _page);
            }
        }
        else
            table = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(ddlCateNewsGroup.SelectedValue), Convert.ToInt32(ddlCateNewsSearch.SelectedValue), _page);

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

    protected void btn_search_Click(object sender, EventArgs e)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();

        string _finter = "";

        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);

        if (txtKeyword.Text != "")
        {
            if (ddlType.SelectedValue == "1")
                _finter += " AND Title like N'%" + Tool.safeString(txtKeyword.Text) + "%'";
            else if (ddlType.SelectedValue == "2")
                _finter += " AND ShortDescribe like N'%" + Tool.safeString(txtKeyword.Text) + "%'";
            else if (ddlType.SelectedValue == "0")
                _finter += " AND (Title like N'%" + Tool.safeString(txtKeyword.Text) + "%' OR ShortDescribe like N'%" + Tool.safeString(txtKeyword.Text) + "%')";
        }

        _finter += " And Language = '" + Language.language + "'";

        if (ddlCateNewsGroup.SelectedValue != "-1" && ddlCateNewsGroup.SelectedIndex > 0)
            _finter += " And GroupCate = " + ddlCateNewsGroup.SelectedValue;

        if (ddlCateNewsSearch.SelectedValue != "0" && ddlCateNewsSearch.SelectedIndex > 0)
            _finter += " And CateNewsID = " + ddlCateNewsSearch.SelectedValue;
        else
            if (!Session["Admin_UserName"].Equals("administrator"))
            {
                string strCate = GetCateParentIDArrayByID(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
                if (strCate != "")
                    _finter += " AND [CateNewsID] in('" + strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','") + "')";
                   // _finter += " AND [CateNewsID] in('" + @strCate + "')";
            }

        IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

        if (txtStartDateTime.Text != "")
            _finter += " AND PostDate >= '" + DateTime.ParseExact(txtStartDateTime.Text, "dd/MM/yyyy HH:mm", culture) + "'";

        if (txtEndDateTime.Text != "")
            _finter += " AND PostDate <= '" + DateTime.ParseExact(txtEndDateTime.Text, "dd/MM/yyyy HH:mm", culture) + "'";

        if (ddlTypeApproved.SelectedValue == "1")
            _finter += " AND isApproval = 0";
        else if (ddlTypeApproved.SelectedValue == "2")
            _finter += " AND isApproval = 1 AND status = 1";
        else if (ddlTypeApproved.SelectedValue == "3")
            _finter += " AND status = 0";

        _finter += " AND isDelete = 0";

        DataTable table = newsGroupBSO.NewsGroupSearchPaging(_finter, _page);

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

    protected void ddlTypeApproved_SelectedIndexChanged(object sender, EventArgs e)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();

        string _finter = "";

        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);

        if (txtKeyword.Text != "")
        {
            if (ddlType.SelectedValue == "1")
                _finter += " AND Title like N'%" + Tool.safeString(txtKeyword.Text) + "%'";
            else if (ddlType.SelectedValue == "2")
                _finter += " AND ShortDescribe like N'%" + Tool.safeString(txtKeyword.Text) + "%'";
            else if (ddlType.SelectedValue == "0")
                _finter += " AND (Title like N'%" + Tool.safeString(txtKeyword.Text) + "%' OR ShortDescribe like N'%" + Tool.safeString(txtKeyword.Text) + "%')";
        }

        _finter += " And Language = '" + Language.language + "'";

        if (ddlCateNewsGroup.SelectedValue != "-1" && ddlCateNewsGroup.SelectedIndex > 0)
            _finter += " And GroupCate = " + ddlCateNewsGroup.SelectedValue;

        if (ddlCateNewsSearch.SelectedValue != "0" && ddlCateNewsSearch.SelectedIndex > 0)
            _finter += " And CateNewsID = " + ddlCateNewsSearch.SelectedValue;
        else
            if (!Session["Admin_UserName"].Equals("administrator"))
            {
                string strCate = GetCateParentIDArrayByID(Convert.ToInt32(ddlCateNewsGroup.SelectedValue));
                if (strCate != "")
                    _finter += " AND [CateNewsID] in('" + strCate.Remove(strCate.LastIndexOf(",")).Replace(",", "','") + "')";
            }

        IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

        if (txtStartDateTime.Text != "")
            _finter += " AND PostDate >= '" + DateTime.ParseExact(txtStartDateTime.Text, "dd/MM/yyyy HH:mm", culture) + "'";

        if (txtEndDateTime.Text != "")
            _finter += " AND PostDate <= '" + DateTime.ParseExact(txtEndDateTime.Text, "dd/MM/yyyy HH:mm", culture) + "'";

        if (ddlTypeApproved.SelectedValue == "1")
            _finter += " AND isApproval = 0";
        else if (ddlTypeApproved.SelectedValue == "2")
            _finter += " AND isApproval = 1 AND status = 1";
        else if (ddlTypeApproved.SelectedValue == "3")
            _finter += " AND status = 0";
        
        _finter += " AND isDelete = 0";

        DataTable table = newsGroupBSO.NewsGroupSearchPaging(_finter, _page);

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
}
