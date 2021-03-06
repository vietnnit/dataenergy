using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ETO;
using BSO;
using DAO;
using Telerik.Web.UI;
using System.Collections.Generic;
public partial class Client_Admin_CopyWidgetPage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        
      
        if (!IsPostBack)
        {
            Bind_ddlPageLayout();
          //  ViewWidgetAll();
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

    #region Bind_ddlPageLayout
    protected void Bind_ddlPageLayout()
    {
        SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
        DataTable table = _pageLayoutBSO.GetSYS_PageLayoutAll(Language.language);
        commonBSO commonBSO = new commonBSO();
        ddlPageLayout.Items.Clear();
        commonBSO.FillToDropDown(ddlPageLayout, table, "~ Chọn trang ~", "0", "PageName", "Id", "");

        ddlPageLayout2.Items.Clear();
        commonBSO.FillToDropDown(ddlPageLayout2, table, "~ Chọn trang ~", "0", "PageName", "Id", "");
    }
    #endregion

    protected void ddlPageLayout_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetRegion();
        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
        DataTable table = _widgetBSO.GetSYS_WidgetPageLayoutByAllRegionId(ddlRegion.SelectedValue, Convert.ToInt32(ddlPageLayout.SelectedValue),Language.language);
        RadGrid1.DataSource = table;
        RadGrid1.DataBind();
        
    }

    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
        DataTable table = _widgetBSO.GetSYS_WidgetPageLayoutByAllRegionId(ddlRegion.SelectedValue, Convert.ToInt32(ddlPageLayout.SelectedValue), Language.language);
        RadGrid1.DataSource = table;
        RadGrid1.DataBind();

        
    }

    protected void ddlPageLayout2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetRegion2();
        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
        DataTable table = _widgetBSO.GetSYS_WidgetPageLayoutByAllRegionId(ddlRegion2.SelectedValue, Convert.ToInt32(ddlPageLayout2.SelectedValue), Language.language);
        RadGrid2.DataSource = table;
        RadGrid2.DataBind();
        
    }

    protected void ddlRegion2_SelectedIndexChanged(object sender, EventArgs e)
    {
        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
        DataTable table = _widgetBSO.GetSYS_WidgetPageLayoutByAllRegionId(ddlRegion2.SelectedValue, Convert.ToInt32(ddlPageLayout2.SelectedValue), Language.language);
        RadGrid2.DataSource = table;
        RadGrid2.DataBind();


    }
    private void GetRegion()
    {
        List<ControlData> _list = new List<ControlData>();
        try
        {
            int PageLayoutId = TypeHelper.ToInt32(ddlPageLayout.SelectedValue);

            SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
            SYS_PageLayout _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutById(PageLayoutId);

            SYS_TemplatePageBSO _templateBSO = new SYS_TemplatePageBSO();
            SYS_TemplatePage _template = _templateBSO.GetSYS_TemplatePageById(_pageLayout.TemplateId);


            Control objControl = (Control)this.LoadControl(ResolveUrl("~/") + "Client/Skins/Templates/" + _template.TemplateControl);
            ControlCollection _controls = objControl.Controls;

            foreach (Control obj1 in _controls)
            {
                Type objType = obj1.GetType();
                if (obj1 != null)
                {
                    if (obj1.ID != null)
                    {
                        ControlData objData = new ControlData();
                        objData.Control = obj1.ID;
                        if (obj1 != null)
                        {
                            objData.Text = obj1.ID;
                            _list.Add(objData);
                        }
                    }
                }
            }

            ddlRegion.Items.Clear();
            ddlRegion.DataSource = _list;
            ddlRegion.DataTextField = "Text";
            ddlRegion.DataValueField = "Control";

            ddlRegion.DataBind();

        }
        catch
        {
            ddlRegion.Items.Clear();
            ddlRegion.DataSource = _list;
            ddlRegion.DataTextField = "Text";
            ddlRegion.DataValueField = "Control";
            ddlRegion.DataBind();
        }
    }

    private void GetRegion2()
    {
        List<ControlData> _list = new List<ControlData>();
        try
        {
            int PageLayoutId = TypeHelper.ToInt32(ddlPageLayout2.SelectedValue);

            SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
            SYS_PageLayout _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutById(PageLayoutId);

            SYS_TemplatePageBSO _templateBSO = new SYS_TemplatePageBSO();
            SYS_TemplatePage _template = _templateBSO.GetSYS_TemplatePageById(_pageLayout.TemplateId);


            Control objControl = (Control)this.LoadControl(ResolveUrl("~/") + "Client/Skins/Templates/" + _template.TemplateControl);
            ControlCollection _controls = objControl.Controls;

            foreach (Control obj1 in _controls)
            {
                Type objType = obj1.GetType();
                if (obj1 != null)
                {
                    if (obj1.ID != null)
                    {
                        ControlData objData = new ControlData();
                        objData.Control = obj1.ID;
                        if (obj1 != null)
                        {
                            objData.Text = obj1.ID;
                            _list.Add(objData);
                        }
                    }
                }
            }

            ddlRegion2.Items.Clear();
            ddlRegion2.DataSource = _list;
            ddlRegion2.DataTextField = "Text";
            ddlRegion2.DataValueField = "Control";

            ddlRegion2.DataBind();

        }
        catch
        {
            ddlRegion2.Items.Clear();
            ddlRegion2.DataSource = _list;
            ddlRegion2.DataTextField = "Text";
            ddlRegion2.DataValueField = "Control";
            ddlRegion2.DataBind();
        }
    }
    //#region initControl
    //protected void initControl(int Id)
    //{
    //    if (Id > 0)
    //    {
    //        ViewCateAll();
    //        VierPermissionID();
    //    }
    //    else 
    //    {
    //        error.Text = "Lỗi: Lựa chọn Nhóm người dùng trước khi phân quyền";
    //    }
    //}
    //#endregion

    #region ViewWidgetAll
    private void ViewWidgetAll1(int _pagelayout, string regionId)
    {
        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
        DataTable table = _widgetBSO.GetSYS_WidgetPageLayoutByAllRegionId(regionId, _pagelayout, Language.language);
        RadGrid1.DataSource = table;
        RadGrid1.DataBind();

    }
    private void ViewWidgetAll2(int _pagelayout, string regionId)
    {
        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
        DataTable table = _widgetBSO.GetSYS_WidgetPageLayoutByAllRegionId(regionId, _pagelayout, Language.language);
        RadGrid2.DataSource = table;
        RadGrid2.DataBind();

    }
    #endregion

    protected void btn_copy_Click(object sender, EventArgs e)
    {
        DataTable datatable = WidgetID();
        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
        SYS_WidgetPageLayout _widget = new SYS_WidgetPageLayout();
        try
        {
           
            if (datatable.Rows.Count > 0)
            {
                foreach (DataRow subrow in datatable.Rows)
                {
                    _widget = _widgetBSO.GetSYS_WidgetPageLayoutById(Convert.ToInt32(subrow["Id"].ToString()));
                    if (ddlPageLayout2.SelectedIndex > 0)
                    {
                        _widget.PageLayoutId = Convert.ToInt32(ddlPageLayout2.SelectedValue);
                        _widget.RegionId = ddlRegion2.SelectedValue;
                        _widgetBSO.CreateSYS_WidgetPageLayoutGet(_widget);
                    }

                }
                error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật Thành công !</div>";

                ViewWidgetAll2(Convert.ToInt32(ddlPageLayout2.SelectedValue), ddlRegion2.SelectedValue);
            }


        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }

    //protected void btn_add_Click(object sender, EventArgs e)
    //{
    //    DataTable datatable = CateNewsID();
        
    //    try
    //    {
    //        CateNewsPermissionBSO catenewPermissionBSO = new CateNewsPermissionBSO();

    //        DataTable table1 = catenewPermissionBSO.GetCateNewsPermissionByRoles(Convert.ToInt32(hddRoles.Value));
            
    //        if (table1.Rows.Count > 0)
    //            catenewPermissionBSO.DeleteCateNewsPermissionRoles(Convert.ToInt32(hddRoles.Value));

    //        CateNewsPermission cateNewsPermission = new CateNewsPermission();

    //        if (datatable.Rows.Count > 0)
    //        {
    //            foreach (DataRow subrow in datatable.Rows)
    //            {
    //                cateNewsPermission.CateNewsID = Convert.ToInt32(subrow["CateNewsID"].ToString());
    //                cateNewsPermission.RolesID = Convert.ToInt32(hddRoles.Value);
    //          //      cateNewsPermission.Permission = subrow["Permission"].ToString();
    //                cateNewsPermission.Permission = "";
    //                cateNewsPermission.UserName = Session["Admin_UserName"].ToString();
    //                cateNewsPermission.Created = DateTime.Now;

    //                catenewPermissionBSO.CreateCateNewsPermission(cateNewsPermission);

    //                error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thành công !</div>";
    //              //  initControl(cateNewsPermission.RolesID);
                    
    //            }

                
    //        }

            
    //    }
    //    catch (Exception ex)
    //    {
    //        error.Text = ex.Message.ToString();
    //    }
    //}

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        GridItem gridViewRow = e.Item;
        if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
        {
            LinkButton image_del = (LinkButton)e.Item.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

            LinkButton image_config = (LinkButton)e.Item.FindControl("btn_config");
            int _type = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "WidgetType").ToString());

            if (_type != 0)
            {
                image_config.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/Skins/ViewEditWidget.aspx?Id=" + DataBinder.Eval(e.Item.DataItem, "Id") + "&type=" + _type + "','_blank','width=980,height=650');return false;");
            }

            LinkButton image_preview = (LinkButton)e.Item.FindControl("btn_preview");
            image_preview.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/Skins/ViewWidgetPreview.aspx?Id=" + DataBinder.Eval(e.Item.DataItem, "Id") + "','_blank','width=1024,height=768');return false;");

        }
    }

    protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
    {
        GridItem gridViewRow = e.Item;
        if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
        {
            LinkButton image_del = (LinkButton)e.Item.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

            LinkButton image_config = (LinkButton)e.Item.FindControl("btn_config");
            int _type = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "WidgetType").ToString());

            if (_type != 0)
            {
                image_config.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/Skins/ViewEditWidget.aspx?Id=" + DataBinder.Eval(e.Item.DataItem, "Id") + "&type=" + _type + "','_blank','width=980,height=650');return false;");
            }

            LinkButton image_preview = (LinkButton)e.Item.FindControl("btn_preview");
            image_preview.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/Skins/ViewWidgetPreview.aspx?Id=" + DataBinder.Eval(e.Item.DataItem, "Id") + "','_blank','width=1024,height=768');return false;");

        }
    }


    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        string nName = e.CommandName.ToLower();
        switch (nName)
        {

            case "_edit":
                Response.Redirect("~/Homepage.aspx?dll=EditWidgetPageLayout&id=" + Id );
                break;
            case "_delete":
                 SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
                _widgetBSO.DeleteSYS_WidgetPageLayout(Id);
                ViewWidgetAll1(Convert.ToInt32(ddlPageLayout.SelectedValue), ddlRegion.SelectedValue);
                AspNetCache.Reset();
                break;
            case "_config":
                break;
        }
    }

    protected void RadGrid2_ItemCommand(object sender, GridCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        string nName = e.CommandName.ToLower();
        switch (nName)
        {

            case "_edit":
                Response.Redirect("~/Homepage.aspx?dll=EditWidgetPageLayout&id=" + Id );
                break;
            case "_delete":
                SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
                _widgetBSO.DeleteSYS_WidgetPageLayout(Id);
                ViewWidgetAll2(Convert.ToInt32(ddlPageLayout.SelectedValue), ddlRegion2.SelectedValue);
                AspNetCache.Reset();
                break;
            case "_config":
                break;
        }
    }


    protected void btn_Order_Click(object sender, EventArgs e)
    {
        foreach (GridItem row in RadGrid1.Items)
        {
            TextBox textOrder = (TextBox)row.FindControl("txtOrder");
            int cOrder = Convert.ToInt32(textOrder.Text);
            int ID = Convert.ToInt32(row.Cells[4].Text);

            SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
            _widgetBSO.SYS_WidgetPageLayoutUpOrder(ID, cOrder);

        }
        ViewWidgetAll1(Convert.ToInt32(ddlPageLayout.SelectedValue), ddlRegion.SelectedValue);
        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật Thành công !</div>";
        AspNetCache.Reset();
    }


    #region WidgetID
    private DataTable WidgetID()
    {
        DataTable datatable = new DataTable();
        datatable.Columns.Add("Id");
        //datatable.Columns.Add("Permission");

        //foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
        //{
        //    CheckBox chkId = (CheckBox)dataItem.FindControl("chkId");
            

        //    if (chkId.Checked)
        //    {
        //        DataRow datarow = datatable.NewRow();
        //        datarow["Id"] = dataItem["Id"].Text;

        //        datatable.Rows.Add(datarow);
        //    }

        //}

        foreach (GridItem row in RadGrid1.Items)
        {
            CheckBox chkId = (CheckBox)row.FindControl("chkId");
            if (chkId.Checked)
            {
                DataRow datarow = datatable.NewRow();
                datarow["Id"] = Convert.ToInt32(row.Cells[4].Text);

                datatable.Rows.Add(datarow);
            }
        }

        return datatable;
    }

    #endregion

    //protected void btn_search_Click(object sender, EventArgs e)
    //{
        //commonBSO commonBSO = new commonBSO();
        //NewsGroupBSO newsGroupBSO = new NewsGroupBSO();

        //string _finter = "";

        //_page = new PagingInfo(20, Convert.ToInt32(hdnPage.Value), true);

        //if (txtKeyword.Text != "")
        //{
        //    if (ddlType.SelectedValue == "1")
        //        _finter += " AND Title like N'%" + Tool.safeString(txtKeyword.Text) + "%'";
        //    else if (ddlType.SelectedValue == "2")
        //        _finter += " AND ShortDescribe like N'%" + Tool.safeString(txtKeyword.Text) + "%'";
        //    else if (ddlType.SelectedValue == "0")
        //        _finter += " AND (Title like N'%" + Tool.safeString(txtKeyword.Text) + "%' OR ShortDescribe like N'%" + Tool.safeString(txtKeyword.Text) + "%')";
        //}

        //_finter += " And Language = '" + Language.language + "'";
        //if (hddGroup.Value != "")
        //    _finter += " And GroupCate = " + hddGroup.Value;

        //if (ddlCateNewsSearch.SelectedValue != "0")
        //    _finter += " And CateNewsID = " + ddlCateNewsSearch.SelectedValue;
        //else
        //    if (!Session["Admin_UserName"].Equals("administrator"))
        //    {
        //        string strCate = GetCateParentIDArrayByID(Convert.ToInt32(hddGroup.Value));
        //        if (strCate != "")
        //            _finter += " AND [CateNewsID] in('" + @strCate + "')";
        //    }

        //if (txtStartDateTime.SelectedDate != null)
        //    _finter += " AND PostDate >= '" + txtStartDateTime.SelectedDate.Value.Date + "'";

        //if (txtEndDateTime.SelectedDate != null)
        //    _finter += " AND PostDate <= '" + txtEndDateTime.SelectedDate.Value.Date + "'";

        //DataTable table = newsGroupBSO.NewsGroupSearchPaging(_finter, _page);

        //if (table.Rows.Count > 0)
        //{
        //    TotalRecord = Convert.ToInt32(table.Rows[0]["Total"].ToString());
        //    SetAttributeGvArticle(Convert.ToInt32(table.Rows[0]["Total"].ToString()));
        //    commonBSO.FillToGridView(grvNewsGroup, table);

        //    Paging.DataLoad();
        //    if (TotalPage(Convert.ToInt32(table.Rows[0]["Total"].ToString())) <= 1)
        //    {
        //        Paging.Visible = false;
        //    }
        //    else
        //    {
        //        Paging.Visible = true;
        //    }
        //}
        //else
        //{
        //    SetAttributeGvArticle(0);
        //    grvNewsGroup.DataSource = null;
        //    grvNewsGroup.DataBind();
        //    Paging.Visible = false;
        //}


    //}

}
