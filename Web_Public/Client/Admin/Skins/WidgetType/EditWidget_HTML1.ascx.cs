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


public partial class Admin_Controls_EditWidget_HTML1 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"], out ID);

        if (!string.IsNullOrEmpty(Request["type"]))
            NavigationTitle(Convert.ToInt32(Request["type"].ToString()));

        if (!IsPostBack)
        {
            initEditor();
            initControl(ID);
        }

    }
    #region NavigationTitle

    private void NavigationTitle(int type)
    {

        SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
        SYS_WidgetType _widgetType = _widgetTypeBSO.GetSYS_WidgetTypeById(Convert.ToInt32(Request["type"].ToString()));

        if (_widgetType != null)
        {
            litModules.Text = "Cấu hình " + _widgetType.WidgetTypeName;
        }
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

        txtRadInfo.config.filebrowserBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html";
        txtRadInfo.config.filebrowserImageBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Images";
        txtRadInfo.config.filebrowserFlashBrowseUrl = ResolveUrl("~/") + "ckfinder/ckfinder.html?type=Flash";
        txtRadInfo.config.filebrowserUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
        txtRadInfo.config.filebrowserImageUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
        txtRadInfo.config.filebrowserFlashUploadUrl = ResolveUrl("~/") + "ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";
        txtRadInfo.config.entities = false;
        txtRadInfo.config.autoParagraph = false;
        //txtRadFull.config.filebrowserWindowWidth = '1000',
        //txtRadFull.config.filebrowserWindowHeight = '700'

       
    }

    #region initControl
    protected void initControl(int ID)
    {
        if (ID > 0)
        {
            txtID.Value = Convert.ToString(ID);
            //btn_add.Visible = false;
            btn_edit.Visible = true;

            //btn_add1.Visible = false;
            //btn_add2.Visible = false;
            btn_edit1.Visible = true;

            try
            {
                SYS_WidgetPageLayoutBSO _widgetPageLayoutBSO = new SYS_WidgetPageLayoutBSO();
                SYS_WidgetPageLayout _widgetPageLayout = _widgetPageLayoutBSO.GetSYS_WidgetPageLayoutById(ID);

                Bind_ddlPageLayout();
                ddlPageLayout.SelectedValue = Convert.ToString(_widgetPageLayout.PageLayoutId);

                GetRegion();
                ddlRegion.SelectedValue = _widgetPageLayout.RegionId;

                //Bind_ddlWidgetType();
                Bind_ddlWidget(0);
                ddlWidget.SelectedValue = Convert.ToString(_widgetPageLayout.WidgetId);

                txtWidgetTitle.Text = _widgetPageLayout.Title;
                hddIcon.Value = _widgetPageLayout.Icon;
                //if (_widgetPageLayout.Icon != "")
                //    ltl_icon.Text = "<img src='" + ResolveUrl("~/") + "Upload/Widgets/Icons/" + _widgetPageLayout.Icon + "' width='48px'>";
                chkStatus.Checked = _widgetPageLayout.Status;

                txtRadInfo.Text = _widgetPageLayout.Info;
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
            Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");


            //Bind_ddlPageLayout();
            ////Bind_ddlWidgetType();
            //Bind_ddlWidget(0);
            //txtID.Value = "";
            //ddlPageLayout.SelectedIndex = 0;
            //btn_add.Visible = true;
            //btn_edit.Visible = false;

            //btn_add1.Visible = true;
            //btn_add2.Visible = true;
            //btn_edit1.Visible = false;

        }
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
    }
    #endregion

    //#region Bind_ddlWidgetType
    //protected void Bind_ddlWidgetType()
    //{
    //    SYS_WidgetTypeBSO _widgetTypeBSO = new SYS_WidgetTypeBSO();
    //    DataTable table = _widgetTypeBSO.GetSYS_WidgetTypeAll();
    //    commonBSO commonBSO = new commonBSO();
    //    ddlWidgetType.Items.Clear();
    //    commonBSO.FillToDropDown(ddlWidgetType, table, "~ Tất cả ~", "0", "WidgetTypeName", "Id", "");
    //}
    //#endregion

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
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
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
            error.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
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
        _widgetPageLayout.PageLayoutId = (ddlPageLayout.SelectedValue != "") ? Convert.ToInt32(ddlPageLayout.SelectedValue) : 0;
        _widgetPageLayout.WidgetId = (ddlWidget.SelectedValue != "") ? Convert.ToInt32(ddlWidget.SelectedValue) : 0;

        _widgetPageLayout.RegionId = (ddlRegion.SelectedValue != "") ? ddlRegion.SelectedValue : "";

        _widgetPageLayout.Title = (txtWidgetTitle.Text != "") ? txtWidgetTitle.Text.Trim() : "";
        _widgetPageLayout.Orders = (hddOrders.Value != "") ? Convert.ToInt32(hddOrders.Value) : 0;
        _widgetPageLayout.Status = chkStatus.Checked;
        _widgetPageLayout.Icon = (hddIcon.Value != "") ? hddIcon.Value : hddIcon.Value;

        _widgetPageLayout.Info = txtRadInfo.Text; //thêm
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

    protected void ddlPageLayout_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetRegion();
    }
}
