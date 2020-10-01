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
using System.IO;
public partial class Client_Admin_EditPageLayout : System.Web.UI.UserControl
{
    //string strParentFolder = "";
    //static DataTable tb;
    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        if (!String.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);

        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);
        if (!IsPostBack)
        {
            ViewPageLayout();
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

    #region BindDropDownList
    protected void BindDropDownList()
    {
        SYS_TemplatePageBSO _tempateBSO = new SYS_TemplatePageBSO();
        DataTable table = _tempateBSO.GetSYS_TemplatePageAll(Language.language);
        commonBSO commonBSO = new commonBSO();
        ddlTemplate.Items.Clear();
        commonBSO.FillToDropDown(ddlTemplate, table, "~ Chọn Template ~", "0", "TemplateName", "Id", "");
    }
    #endregion

    #region ViewPageLayout
    private void ViewPageLayout()
    {
        SYS_PageLayoutBSO _pageBSO = new SYS_PageLayoutBSO();
        DataTable table = _pageBSO.GetSYS_PageLayoutAllTemplate(Language.language);

        commonBSO commonBSO = new commonBSO();
        commonBSO.FillToGridView(grvPageLayout, table);
    }
    #endregion

    #region initControl
    private void initControl(int Id)
    {
        if (Id > 0)
        {
            btn_add.Visible = false;
            btn_edit.Visible = true;

            btn_add1.Visible = false;
            btn_add2.Visible = false;
            btn_edit1.Visible = true;
            try
            {
                SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
                SYS_PageLayout _pageLayout = _pageLayoutBSO.GetSYS_PageLayoutById(Id);


                hddID.Value = Convert.ToString(_pageLayout.Id);
               
                txtName.Text = _pageLayout.PageName;
                txtSlug.Text = _pageLayout.SlugPageName;
                txtOrder.Text = _pageLayout.Orders.ToString();
                BindDropDownList();
                ddlTemplate.SelectedValue = Convert.ToString(_pageLayout.TemplateId);

            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            BindDropDownList();
            btn_edit.Visible = false;
            btn_add.Visible = true;

            btn_edit1.Visible = false;
            btn_add1.Visible = true;
            btn_add2.Visible = true;

        }
    }
    #endregion

    #region ReceiveHtml
    private SYS_PageLayout ReceiveHtml()
    {

        SYS_PageLayout _pageLayout = new SYS_PageLayout();
        _pageLayout.Id = (hddID.Value != "") ? Convert.ToInt32(hddID.Value) : 0;
        _pageLayout.PageName = txtName.Text;
        _pageLayout.SlugPageName = txtSlug.Text;
        _pageLayout.Orders = (txtOrder.Text != "") ? Convert.ToInt32(txtOrder.Text) : 0;
        if (ddlTemplate.SelectedIndex > 0)
        {
            _pageLayout.TemplateId = Convert.ToInt32(ddlTemplate.SelectedValue);
        }
        _pageLayout.Language = Language.language;

        return _pageLayout;
    }
    #endregion

    protected void grvPageLayout_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPageLayout.PageIndex = e.NewPageIndex;

        ViewPageLayout();
    }
    protected void grvPageLayout_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument.ToString());
        string nName = e.CommandName.ToLower();
        switch (nName)
        {
            case "_edit":
                Response.Redirect("~/Homepage.aspx?dll=EditPageLayout&id=" + Id );
                break;

            case "_delete":
                SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
                _pageLayoutBSO.DeleteSYS_PageLayout(Id);

                ViewPageLayout();
                break;
            case "_widget":
                break;
        }
    }
    protected void grvPageLayout_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton image_del = (LinkButton)e.Row.FindControl("btn_delete");
            image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

            LinkButton image_config = (LinkButton)e.Row.FindControl("btn_widget");
            image_config.Attributes.Add("onclick", "javascript:window.open('" + ResolveUrl("~/") + "Client/Admin/AdminPopup.aspx?dll=EditWidgetPageLayoutbyPage&group=" + DataBinder.Eval(e.Row.DataItem, "Id") + "','_blank','width=980,height=650');return false;");
        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        try
        {
            
                SYS_PageLayout _pageLayout = new SYS_PageLayout();
                _pageLayout = ReceiveHtml();


                SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
                int id = _pageLayoutBSO.CreateSYS_PageLayoutGet(_pageLayout);

                ViewPageLayout();
                clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";
                initControl(id);

          
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
           
                SYS_PageLayout _pageLayout = new SYS_PageLayout();
                _pageLayout = ReceiveHtml();


                SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
                int id = _pageLayoutBSO.CreateSYS_PageLayoutGet(_pageLayout);

                ViewPageLayout();
                clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Thêm mới thành công !</div>";

           
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
            SYS_PageLayout _pageLayout = new SYS_PageLayout();
            _pageLayout = ReceiveHtml();

            SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
            _pageLayoutBSO.UpdateSYS_PageLayout(_pageLayout);

            ViewPageLayout();
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
            initControl(_pageLayout.Id);
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
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

    protected void btn_Order_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvPageLayout.Rows)
        {
            TextBox textOrder = (TextBox)row.FindControl("txtPageOrder");
            int cOrder = Convert.ToInt32(textOrder.Text);
            int ID = Convert.ToInt32(row.Cells[0].Text);
            SYS_PageLayoutBSO _pageLayoutBSO = new SYS_PageLayoutBSO();
            _pageLayoutBSO.SYS_PageLayoutUpOrder(ID, cOrder);
        }
        clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật thành công !</div>";
        ViewPageLayout();
        AspNetCache.Reset();

    }

    protected void btn_sysn_Click(object sender, EventArgs e)
    {
        
    }

}
