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
public partial class Client_Admin_EditNewsRelation : System.Web.UI.UserControl
{
    PagingInfo _page = new PagingInfo(20, 1, true);
    PagingInfo _page2 = new PagingInfo(20, 1, true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        int group = -1;

        hddGroup.Value = group.ToString();


        if (Id == 0)
            Response.Redirect("~/Admin/home/Default.aspx");
        else
        {
            hddNewsID.Value = Convert.ToString(Id);

            if (!IsPostBack)
            {
                BindControl();
                ViewNewsGroup(-1);
                ViewNewsReleation(Id);

            }
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
    private void ViewNewsGroup(int gID)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        DataTable table = new DataTable();


        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);

        
        table = newsGroupBSO.GetNewsGroupPaging(Language.language, gID, _page);
        

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

    private void ViewNewsReleation(int newsID)
    {
        commonBSO commonBSO = new commonBSO();
        NewsRelationBSO _newsRelationBSO = new NewsRelationBSO();
        DataTable table = new DataTable();


        _page2 = new PagingInfo(20, Convert.ToInt32(hdnPage2.Value), true);


        table = _newsRelationBSO.GetNewsRelationPaging(Language.language, newsID, _page2);


        if (table.Rows.Count > 0)
        {
            TotalRecord2 = Convert.ToInt32(table.Rows[0]["Total"].ToString());
            SetAttributeGvArticle2(Convert.ToInt32(table.Rows[0]["Total"].ToString()));
            commonBSO.FillToGridView(grvRelation, table);

            paging2.DataLoad();
            if (TotalPage2(Convert.ToInt32(table.Rows[0]["Total"].ToString())) <= 1)
            {
                paging2.Visible = false;
            }
            else
            {
                paging2.Visible = true;
            }
        }
        else
        {
            SetAttributeGvArticle2(0);
            grvRelation.DataSource = null;
            grvRelation.DataBind();
            paging2.Visible = false;
        }

    }
    #endregion

    private string GetCateParentIDArrayByID(int group)
    {
        string strArrayID = "";

        CateNewsBSO cateNewsBSO = new CateNewsBSO();
        DataTable table1 = cateNewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_UserName"].ToString());

        if (table1.Rows.Count > 0)
        {
            foreach (DataRow subrow in table1.Rows)
            {
                strArrayID += subrow["CateNewsID"].ToString() + ",";
                // strArrayID += GetCateParentIDArrayByID(Convert.ToInt32(subrow["CateNewsID"].ToString()));
            }

        }

        return strArrayID;

    }




    #region BindControl
    private void BindControl()
    {
        ddlCateNewsSearch.Items.Clear();
        CateNewsGroupBSO categroupBSO = new CateNewsGroupBSO();
        DataTable table = categroupBSO.GetCateNewsGroupNewAll(Language.language, Session["Admin_Username"].ToString());
        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToDropDown(ddlGroupCate, table, "~~ Trong tất cả ~~", "0", "CateNewsGroupName", "GroupCate", "");

        ddlType.Items.Clear();
        ddlType.Items.Add(new ListItem("--All--", "0"));
        ddlType.Items.Add(new ListItem("Tiêu đề", "1"));
        ddlType.Items.Add(new ListItem("Tin vắn", "2"));
        ddlType.SelectedValue = "1";
    }

    private void BindCateNews(int group)
    {
        ddlCateNewsSearch.Items.Clear();
        CateNewsBSO catenewsBSO = new CateNewsBSO();
        DataTable table = catenewsBSO.GetCateGroupRoles(Language.language, group, Session["Admin_Username"].ToString());
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

    private string NewsGroupID_Relation()
    {
        string newsGroupId = "";
        foreach (GridViewRow rows in grvRelation.Rows)
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
        
    }

    
    protected void grvNewsGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton image_view = (LinkButton)e.Row.FindControl("btn_view");
            image_view.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/News/ViewNewsGroup.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "NewsGroupID") + "','_blank','width=800,height=600');return false;");

        }
    }

    protected void grvRelation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        NewsRelationBSO _newsRelationBSO = new NewsRelationBSO();
        NewsRelation _newsRelation = _newsRelationBSO.GetNewsRelationByID(Id, Convert.ToInt32(hddNewsID.Value));

        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        NewsGroup newsgroup = newsGroupBSO.GetNewsGroupById(Id);

        string nName = e.CommandName.ToLower();
        AdminBSO adminBSO = new AdminBSO();
        Admin admin = new Admin();
        switch (nName)
        {
            case "_view":
                break;
            case "_edit":
                 Response.Redirect("~/Admin/editnewsbyuser/" + newsgroup.GroupCate + "/" + Id + "/Default.aspx");
                break;

            case "_delete":
                  _newsRelationBSO.DeleteNewsRelation(_newsRelation.Id);
                  ViewNewsReleation(Convert.ToInt32(hddNewsID.Value));
                  AspNetCache.Reset();

                break;
        }
    }
    protected void grvRelation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");

            LinkButton image_view = (LinkButton)e.Row.FindControl("btn_view");
            image_view.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/News/ViewNewsGroup.aspx?Id=" + DataBinder.Eval(e.Row.DataItem, "NewsGroupID") + "','_blank','width=800,height=600');return false;");

            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
           
        }
    }
    protected void grvNewsGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvNewsGroup.PageIndex = e.NewPageIndex;
        ViewNewsGroup(-1);
    }
   
    protected void btn_delall_Click(object sender, EventArgs e)
    {
        if (NewsGroupID_Relation() != "")
        {
            NewsRelationBSO _newsRelationBSO = new NewsRelationBSO();
            _newsRelationBSO.DeleteNewsRelation(NewsGroupID_Relation(), Convert.ToInt32(hddNewsID.Value));
        }
        ViewNewsReleation(Convert.ToInt32(hddNewsID.Value));
        AspNetCache.Reset();
    }



    protected void btn_add_Click(object sender, EventArgs e)
    {
        NewsRelationBSO _newsRelationBSO = new NewsRelationBSO();
        NewsRelation _newsRelation = new NewsRelation();
        foreach (GridViewRow rows in grvNewsGroup.Rows)
        {
            CheckBox checkbox = (CheckBox)rows.Cells[0].FindControl("chkId");
            if (checkbox.Checked)
            {
                _newsRelation = _newsRelationBSO.GetNewsRelationByID(Convert.ToInt32(rows.Cells[0].Text), Convert.ToInt32(hddNewsID.Value));

                if (_newsRelation == null)
                {
                    _newsRelation = new NewsRelation();
                    _newsRelation.NewsGroupID = Convert.ToInt32(rows.Cells[0].Text);
                    _newsRelation.NewsID = Convert.ToInt32(hddNewsID.Value);

                    int i = _newsRelationBSO.CreateNewsRelationGet(_newsRelation);
                }

            }
        }

        ViewNewsReleation(Convert.ToInt32(hddNewsID.Value));
        clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
        AspNetCache.Reset();
    }
    //protected void btn_register_click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Admin/Group/listnewsregister/" + hddGroup.Value + "/Default.aspx");

    //}

    public void Paging_Click2(object sender, CommandEventArgs e)
    {

        string CurrentPage = e.CommandArgument.ToString();
        hdnPage2.Value = CurrentPage;
        _page2 = new PagingInfo(20, Convert.ToInt32(hdnPage2.Value), true);
        ViewNewsReleation(Convert.ToInt32(hddNewsID.Value));

    }
    private void SetAttributeGvArticle2(int totalRecord)
    {

        paging2.PageSize = Convert.ToInt32(_page2.PageSize);
        paging2.TotalRecord = totalRecord;
        paging2.CurrentPage = grvRelation.PageIndex + Convert.ToInt32(hdnPage2.Value);
        paging2.TotalNumberPaging = 10;
    }

    private long TotalPage2(int total)
    {
        if (total % _page2.PageSize == 0)
        {
            return total / _page2.PageSize;
        }
        else
        {
            return total / _page2.PageSize + 1;
        }
        //    return 0;
    }
    private int TotalRecord2
    {
        get
        {
            if (ViewState["TotalRecord2"] != null)
                return Convert.ToInt32(ViewState["TotalRecord2"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TotalRecord2"] = value;
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

    protected void ddlCateNewsSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        DataTable table = new DataTable();


        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);

        if (ddlCateNewsSearch.SelectedValue == "0")
        {

            table = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(ddlGroupCate.SelectedValue), _page);
           
        }
        else
            table = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(ddlGroupCate.SelectedValue), Convert.ToInt32(ddlCateNewsSearch.SelectedValue), _page);

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

    protected void ddlGroupCate_SelectedIndexChanged(object sender, EventArgs e)
    {
        commonBSO commonBSO = new commonBSO();
        NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
        DataTable table = new DataTable();


        _page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);

        if (ddlGroupCate.SelectedValue == "0")
        {
           table = newsGroupBSO.GetNewsGroupPaging(Language.language, -1 , _page);
          
        }
        else
            table = newsGroupBSO.GetNewsGroupPaging(Language.language, Convert.ToInt32(ddlGroupCate.SelectedValue), _page);

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

        BindCateNews(Convert.ToInt32(ddlGroupCate.SelectedValue));
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

        if (ddlGroupCate.SelectedValue != "0")
            _finter += " And GroupCate = " + ddlGroupCate.SelectedValue;

        if (ddlCateNewsSearch.SelectedValue != "0" && ddlCateNewsSearch.SelectedValue != string.Empty)
            _finter += " And CateNewsID = " + ddlCateNewsSearch.SelectedValue;

        IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

        if (txtStartDateTime.Text != "")
            _finter += " AND PostDate >= '" + DateTime.ParseExact(txtStartDateTime.Text, "dd/MM/yyyy HH:mm", culture) + "'";

        if (txtEndDateTime.Text != "")
            _finter += " AND PostDate <= '" + DateTime.ParseExact(txtEndDateTime.Text, "dd/MM/yyyy HH:mm", culture) + "'";

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