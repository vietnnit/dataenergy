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
using DAO;
using BSO;
using Telerik.Web.UI;
using System.Collections.Generic;


public partial class Admin_Controls_EditWidgetPageLayoutbyPage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"], out ID);

        int _pageLayout = 0;
        if (!string.IsNullOrEmpty(Request["group"]))
            int.TryParse(Request["group"], out _pageLayout);

        hddPageLayout.Value = Convert.ToString(_pageLayout);

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            initControl(ID);
            ViewWidgetAll(_pageLayout);
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

    #region initControl
    protected void initControl(int ID)
    {
        if (ID > 0)
        {
            txtID.Value = Convert.ToString(ID);
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_add2.Visible = false;
            btn_edit1.Visible = true;

            try
            {
                SYS_WidgetPageLayoutBSO _widgetPageLayoutBSO = new SYS_WidgetPageLayoutBSO();
                SYS_WidgetPageLayout _widgetPageLayout = _widgetPageLayoutBSO.GetSYS_WidgetPageLayoutById(ID);

               // Bind_ddlPageLayout();
               // ddlPageLayout.SelectedValue = Convert.ToString(_widgetPageLayout.PageLayoutId);
                hddPageLayout.Value = Convert.ToString(_widgetPageLayout.PageLayoutId);

                GetRegion(_widgetPageLayout.PageLayoutId);
                ddlRegion.SelectedValue = _widgetPageLayout.RegionId;

                Bind_ddlWidgetType();
                Bind_ddlWidget(0);
                ddlWidget.SelectedValue = Convert.ToString(_widgetPageLayout.WidgetId);

                txtWidgetTitle.Text = _widgetPageLayout.Title;
                hddIcon.Value = _widgetPageLayout.Icon;
                //if (_widgetPageLayout.Icon != "")
                //    ltl_icon.Text = "<img src='" + ResolveUrl("~/") + "Upload/Widgets/Icons/" + _widgetPageLayout.Icon + "' width='48px'>";
                chkStatus.Checked = _widgetPageLayout.Status;

                hddRadInfo.Value = _widgetPageLayout.Info;
                hddRadHTML.Value = _widgetPageLayout.HTML;
                hddRecord.Value = _widgetPageLayout.Record.ToString();
                hddRecord2.Value = _widgetPageLayout.Record2.ToString();
                hddValue.Value = _widgetPageLayout.Value;
                hddValue2.Value = _widgetPageLayout.Value2;
                hddOrders.Value = _widgetPageLayout.Orders.ToString();
            }
            catch (Exception ex)
            {
                error.Text = ex.Message.ToString();
            }
        }
        else
        {
           // Bind_ddlPageLayout();
            Bind_ddlWidgetType();
            Bind_ddlWidget(0);
            txtID.Value = "";
            GetRegion(Convert.ToInt32(hddPageLayout.Value));
           // ddlPageLayout.SelectedIndex = 0;
            btn_add.Visible = true;
            btn_edit.Visible = false;

            btn_add1.Visible = true;
            btn_add2.Visible = true;
            btn_edit1.Visible = false;

        }
    }
    #endregion

    //#region Bind_ddlPageLayout
    //protected void Bind_ddlPageLayout()
    //{
    //    SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
    //    DataTable table = _pageLayoutBSO.GetSYS_PageLayoutAll(Language.language);
    //    commonBSO commonBSO = new commonBSO();
    //    ddlPageLayout.Items.Clear();
    //    commonBSO.FillToDropDown(ddlPageLayout, table, "~ Chọn trang ~", "0", "PageName", "Id", "");
    //}
    //#endregion

    #region Bind_ddlWidgetType
    protected void Bind_ddlWidgetType()
    {
        SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
        DataTable table = _widgetTypeBSO.GetSYS_WidgetTypeAll();
        commonBSO commonBSO = new commonBSO();
        ddlWidgetType.Items.Clear();
        commonBSO.FillToDropDown(ddlWidgetType, table, "~ Tất cả ~", "0", "WidgetTypeName", "Id", "");
    }
    #endregion

    #region Bind_ddlWidget
    protected void Bind_ddlWidget(int _widgetType)
    {
        SYS_WidgetBSO _widgetBSO = new SYS_WidgetBSO();
        DataTable table = new DataTable();
        if (_widgetType == 0)
            table = _widgetBSO.GetSYS_WidgetAllFull();
        else
            table = _widgetBSO.GetSYS_WidgetByType(_widgetType);

        commonBSO commonBSO = new commonBSO();
        ddlWidget.Items.Clear();
        commonBSO.FillToDropDown(ddlWidget, table, "", "", "WidgetName", "Id", "");
    }
    #endregion

    #region AddNews
    protected void Add()
    {
        SYS_WidgetPageLayoutBSO _widgetPageLayoutBSO = new SYS_WidgetPageLayoutBSO();
        SYS_WidgetPageLayout _widgetPageLayout = ReceiveHtml();
        try
        {
            int id = _widgetPageLayoutBSO.CreateSYS_WidgetPageLayoutGet(_widgetPageLayout);
            error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Thêm mới thành công !</div>";
            initControl(id);
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }

    }
    #endregion

    #region Edit
    protected void Edit()
    {
        SYS_WidgetPageLayoutBSO _widgetPageLayoutBSO = new SYS_WidgetPageLayoutBSO();
        SYS_WidgetPageLayout _widgetPageLayout = ReceiveHtml();
        try
        {
            _widgetPageLayoutBSO.UpdateSYS_WidgetPageLayout(_widgetPageLayout);
            error.Text = "<div style='color:#ff0000;font:bold 12px Arial;padding:5px 0;'>Cập nhật thành công !</div>";
            initControl(_widgetPageLayout.Id);
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }
    }
    #endregion

    #region ReceiveHtml
    public SYS_WidgetPageLayout ReceiveHtml()
    {
        SYS_WidgetPageLayout _widgetPageLayout = new SYS_WidgetPageLayout();

        //string path = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Widgets/Icons/";
        //commonBSO commonBSO = new commonBSO();
        //ConfigBSO configBSO = new ConfigBSO();
        //Config _config = configBSO.GetAllConfig(Language.language);

        //string icon_upload = commonBSO.UploadImage(uploadIcon, path, Convert.ToInt32(_config.New_thumb_w), Convert.ToInt32(_config.New_thumb_h));

        _widgetPageLayout.Id = (txtID.Value != "") ? Convert.ToInt32(txtID.Value) : 0;
       // _widgetPageLayout.PageLayoutId = (ddlPageLayout.SelectedValue != "") ? Convert.ToInt32(ddlPageLayout.SelectedValue) : 0;
        _widgetPageLayout.PageLayoutId = (hddPageLayout.Value != "") ? Convert.ToInt32(hddPageLayout.Value) : 0;
        _widgetPageLayout.WidgetId = (ddlWidget.SelectedValue != "") ? Convert.ToInt32(ddlWidget.SelectedValue) : 0;

        _widgetPageLayout.RegionId = (ddlRegion.SelectedValue != "") ? ddlRegion.SelectedValue : "";

        _widgetPageLayout.Title = (txtWidgetTitle.Text != "") ? txtWidgetTitle.Text.Trim() : "";
        _widgetPageLayout.Orders = (hddOrders.Value != "") ? Convert.ToInt32(hddOrders.Value) : 0;
        _widgetPageLayout.Status = chkStatus.Checked;
        _widgetPageLayout.Icon = "";

        _widgetPageLayout.Info = (hddRadInfo.Value != "") ? hddRadInfo.Value.Trim() : "";
        _widgetPageLayout.HTML = (hddRadHTML.Value != "") ? hddRadHTML.Value.Trim() : "";
        _widgetPageLayout.Value = (hddValue.Value != "") ? hddValue.Value.Trim() : "0";
        _widgetPageLayout.Value2 = (hddValue2.Value != "") ? hddValue2.Value.Trim() : "0";
        _widgetPageLayout.Record = (hddRecord.Value != "") ? Convert.ToInt32(hddRecord.Value) : 5;
        _widgetPageLayout.Record2 = (hddRecord2.Value != "") ? Convert.ToInt32(hddRecord2.Value) : 5;

        _widgetPageLayout.Language = Language.language;

        return _widgetPageLayout;
    }
    #endregion

    protected void btn_add_Click(object sender, EventArgs e)
    {
        Add();
        AspNetCache.Reset();
        ViewWidgetAll(Convert.ToInt32(hddPageLayout.Value));
    }
    protected void btn_add_Click_more(object sender, EventArgs e)
    {
        SYS_WidgetPageLayoutBSO _widgetPageLayoutBSO = new SYS_WidgetPageLayoutBSO();
        SYS_WidgetPageLayout _widgetPageLayout = ReceiveHtml();
        try
        {
            int id = _widgetPageLayoutBSO.CreateSYS_WidgetPageLayoutGet(_widgetPageLayout);
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
            AspNetCache.Reset();
            ViewWidgetAll(Convert.ToInt32(hddPageLayout.Value));
        }
        catch (Exception ex)
        {
            error.Text = ex.Message.ToString();
        }

    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        Edit();
        AspNetCache.Reset();
        ViewWidgetAll(Convert.ToInt32(hddPageLayout.Value));
    }

    protected void ddlWidgetType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_ddlWidget(Convert.ToInt32(ddlWidgetType.SelectedValue));
    }

    #region ViewWidgetAll
    private void ViewWidgetAll()
    {
        SYS_WidgetPageLayoutBSO _widgetPageLayoutBSO = new SYS_WidgetPageLayoutBSO();
        DataTable table = _widgetPageLayoutBSO.GetSYS_WidgetPageLayoutFullAll(Language.language);
        RadGrid1.DataSource = table;
        RadGrid1.DataBind();
    }
    private void ViewWidgetAll(int _pageLayout)
    {
        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
        DataTable table = new DataTable();
        if(_pageLayout !=0)
            table = _widgetBSO.GetSYS_WidgetPageLayoutFullAll(_pageLayout, Language.language);
        RadGrid1.DataSource = table;
        RadGrid1.DataBind();
    }

    #endregion


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
            image_preview.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/Skins/ViewWidgetPreview.aspx?Id=" + DataBinder.Eval(e.Item.DataItem, "Id") + "','_blank','width=1280,height=565');return false;");
            
        }
    }


    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        int Id = 0;

        if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
            Id = Convert.ToInt32(e.CommandArgument.ToString());

        string nName = e.CommandName.ToLower();
        switch (nName)
        {
            case "_edit":
                Response.Redirect("~/Client/Admin/AdminPopup.aspx?dll=EditWidgetPageLayoutbyPage&group=" + hddPageLayout.Value + "&id=" + Id);
                break;
            case "_delete":
                SYS_WidgetPageLayoutBSO _widgetPageLayoutBSO = new SYS_WidgetPageLayoutBSO();
                _widgetPageLayoutBSO.DeleteSYS_WidgetPageLayout(Id);
                AspNetCache.Reset();
                ViewWidgetAll(Convert.ToInt32(hddPageLayout.Value));
                break;
            case "_config":
                break;
            case "_preview":
                break;
        }
    }

    protected void btn_Order_Click(object sender, EventArgs e)
    {
        SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();

        foreach (GridItem row in RadGrid1.Items)
        {
            TextBox textOrder = (TextBox)row.FindControl("txtOrder");
            int cOrder = Convert.ToInt32(textOrder.Text);
            int ID = Convert.ToInt32(row.Cells[4].Text);

            _widgetBSO.SYS_WidgetPageLayoutUpOrder(ID, cOrder);

        }
        error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật Thành công !</div>";
        AspNetCache.Reset();
        ViewWidgetAll(Convert.ToInt32(hddPageLayout.Value));
    }

    protected void btn_Del_Click(object sender, EventArgs e)
    {
        if (WidgetPageLayoutID() != "")
        {
            SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
            _widgetBSO.DeleteSYS_WidgetPageLayout(WidgetPageLayoutID());
        }
        AspNetCache.Reset();
        ViewWidgetAll(Convert.ToInt32(hddPageLayout.Value));
    }

    #region WidgetPageLayoutID
    private string WidgetPageLayoutID()
    {
        string _widgetPageLayoutID = "";
        foreach (GridItem row in RadGrid1.Items)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("chkId");
            if (checkbox.Checked)
                _widgetPageLayoutID += row.Cells[4].Text + ",";
        }
        return _widgetPageLayoutID;
    }

    #endregion

    //protected void btn_PageLayout_Click(object sender, EventArgs e)
    //{
    //    SYS_WidgetPageLayoutBSO _widgetBSO = new SYS_WidgetPageLayoutBSO();
    //    DataTable table = new DataTable();
    //    if (ddlPageLayout.SelectedValue == "0")
    //        table = _widgetBSO.GetSYS_WidgetPageLayoutFullAll(Language.language);
    //    else
    //        table = _widgetBSO.GetSYS_WidgetPageLayoutFullAll(Convert.ToInt32(ddlPageLayout.SelectedValue), Language.language);
    //    RadGrid1.DataSource = table;
    //    RadGrid1.DataBind();
    //}

    protected void btn_create_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Client/Admin/AdminPopup.aspx?dll=EditWidgetPageLayoutbyPage&group=" + hddPageLayout.Value);
    }

    private void GetRegion(int PageLayoutId)
    {
        List<ControlData> _list = new List<ControlData>();
        try
        {
          //  int PageLayoutId = TypeHelper.ToInt32(ddlPageLayout.SelectedValue);

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

    //protected void ddlPageLayout_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GetRegion();
    //}
}
