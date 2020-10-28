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
using System.Collections.Generic;
using System.Text;
using ETO;
using BSO;
using ePower.DE.Domain;
using ePower.DE.Service;
using PR.Domain;
using PR.Service;


public partial class Client_Admin_DataEnergy_ListReportWaittingApproved : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] != null)
                return Convert.ToInt32(ViewState["CurrentPage"].ToString());
            else
                return 1;
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    private int PageSize
    {
        get
        {
            if (ViewState["PageSize"] != null)
                return Convert.ToInt32(ViewState["PageSize"].ToString());
            else
                return 20;
        }
        set
        {
            ViewState["PageSize"] = value;
        }
    }
    int ReportId
    {
        get
        {
            if (ViewState["ReportId"] != null && ViewState["ReportId"].ToString() != "")
                return (int)ViewState["ReportId"];
            else
                return 0;
        }
        set { ViewState["ReportId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["Id"]))
                int.TryParse(Request["Id"].Replace(",", ""), out Id);
            ReportId = Id;
            if (!string.IsNullOrEmpty(Request["dll"]))
                NavigationTitle(Request["dll"]);

            txtNgayXacNhan.Text = DateTime.Today.ToString("dd/MM/yyyy");
            BindYear();
            BindArea();
            BindDistrict();
            BindPhanLoaiBaoCao();
            BindData();
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
    void BindYear()
    {
        for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 20; i--)
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        ddlYear.Items.Insert(0, new ListItem("---Tất cả---"));
        //ddlYear.SelectedValue = (DateTime.Now.Year - 1).ToString();
    }
    void BindDistrict()
    {
        ddlDistrict.Items.Clear();
        if (m_UserValidation.OrgId > 0)
        {
            Organization org = new OrganizationService().FindByKey(m_UserValidation.OrgId);
            if (org != null)
            {
                IList<District> list = new List<District>();
                if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_District_All))
                {
                    list = new DistrictService().FindAll();
                    AspNetCache.SetCache(Constants.Cache_ReportFuel_District_All, list);
                }
                else
                    list = (IList<District>)AspNetCache.GetCache(Constants.Cache_ReportFuel_District_All);
                var listSearch = from o in list where o.ProvinceId == org.ProvinceId orderby o.DistrictName ascending select o;
                ddlDistrict.DataSource = listSearch;
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("---Tất cả---", ""));
            }
        }

    }
    void BindArea()
    {
        IList<Area> list = new List<Area>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Area_All))
        {
            list = new AreaService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Area_All, list);
        }
        else
            list = (IList<Area>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Area_All);
        if (list != null && list.Count > 0)
        {
            var listSearch = from o in list where o.ParentId == 0 || o.ParentId == null orderby o.SortOrder ascending select o;
            ddlArea.DataSource = listSearch;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("---Tất cả---", ""));
        }
        else
        {
            ddlArea.DataSource = null;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("---Tất cả---", ""));

        }
    }

    private void BindData()
    {
        ReportFuelService comBSO = new ReportFuelService();
        DataTable list = new DataTable();
        int AreaId = 0;
        int SubAreaId = 0;
        int Year = 0;
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);
        if (ddlArea.SelectedIndex > 0)
            AreaId = Convert.ToInt32(ddlArea.SelectedValue);
        int DistrictId = 0;
        if (ddlDistrict.SelectedIndex > 0)
            DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);

        //list = comBSO.FindWaittingList(false, AreaId, SubAreaId, m_UserValidation.OrgId, 0, 0, DistrictId, 1, false, Year, null, null, txtKeyword.Text.Trim(), paging);
        list = comBSO.FindWaittingListWithType(false, AreaId, SubAreaId, m_UserValidation.OrgId, 0, 0, DistrictId, 1, false, Year, null, null, txtKeyword.Text.Trim(), ddlPhanLoaiBC.SelectedValue, paging);
        if (list != null && list.Rows.Count > 0)
        {
            paging.RowsCount = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
            Paging.DataLoad();
            if (paging.PagesCount <= 1)
            {
                ltNotice.Text = "Có tổng số " + paging.RowsCount + " báo cáo";
                Paging.Visible = false;
            }
            else
            {
                ltNotice.Text = "Có" + list.Rows.Count + " trong tổng số " + paging.RowsCount + " báo cáo";
                Paging.Visible = true;
            }
        }
        else
        {
            ltNotice.Text = "";
            Paging.Visible = false;
        }
        rptNoFuelCurrent.DataSource = list;

        rptNoFuelCurrent.DataBind();
    }

    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindData();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clientview.Text = "";
        if (hdnValueId.Value != "")
        {
            int report = Convert.ToInt32(hdnValueId.Value);
            if (report > 0)
            {
                //ReportFuel reportFuel = new ReportFuel();
                //reportFuel = new ReportFuelService().FindByKey(report);
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

                //reportFuel.ConfirmedDate = DateTime.ParseExact(txtNgayXacNhan.Text, "dd/MM/yyyy", culture);
                //reportFuel.ApprovedSatus = true;//Da tiep nhan
                //reportFuel.AprovedDate = DateTime.Now;
                if (new ReportFuelService().ApproveReport(report, DateTime.ParseExact(txtNgayXacNhan.Text, "dd/MM/yyyy", culture), true) != null)
                {
                    BindData();
                    //clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lưu thông tin không Thành công !</div>";
                }
                else
                {
                    clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lưu thông tin không Thành công !</div>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ad", "showforms(" + hdnValueId.Value + ");", true);
                }
            }
            else
            {
                clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Vui lòng chọn báo cáo!</div>";
                ScriptManager.RegisterStartupScript(this, GetType(), "ad", "showforms(" + hdnValueId.Value + ");", true);
            }
        }
        else
        {
            clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Vui lòng chọn báo cáo!</div>";
            ScriptManager.RegisterStartupScript(this, GetType(), "ad", "showforms(" + hdnValueId.Value + ");", true);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        BindData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
    }

    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ListReportForProvince/Default.aspx");

    }
    protected void btn_new_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/editReportFuel/Default.aspx");

    }

    protected void rptNoFuelFuture_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            //LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            //LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");

        }
    }
    protected void rptNoFuelCurrent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            //LinkButton lbtDownload = (LinkButton)e.Item.FindControl("lbtDownload");
            //if (item["PathFile"] != null && item["PathFile"].ToString() != "")
            //    lbtDownload.Visible = true;
            //else
            //    lbtDownload.Visible = false;

        }
    }
    protected void lbtDownload_Click(object sender, EventArgs e)
    {
        LinkButton lbtDownload = (LinkButton)sender;
        ReportFuel report = new ReportFuelService().FindByKey(Convert.ToInt32(lbtDownload.CommandArgument));
        if (report != null && report.PathFile != "")
        {
            string Filpath = Server.MapPath("~/UserFile/Report/" + report.PathFile);
            DownLoad(Filpath);
        }
    }

    public void DownLoad(string FName)
    {
        string path = FName;
        System.IO.FileInfo file = new System.IO.FileInfo(path);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name); Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream"; // download […]
        }
    }

    public string GetUrl(string input, int id)
    {
        string url = "";
        switch (input.ToUpper())
        {
            case ReportKey.ANNUAL:
                url = ResolveUrl("~") + "Admin/ViewReportDetailAnnual/" + id.ToString() + "/Default.aspx";
                break;
            case ReportKey.PLAN:
                url = ResolveUrl("~") + "Admin/ViewReportDetailPlan/" + id.ToString() + "/Default.aspx";
                break;
            case ReportKey.PLAN5:
                url = ResolveUrl("~") + "Admin/ViewReportDetailPlan5Year/" + id.ToString() + "/Default.aspx";
                break;

        }
        return url;
    }
    private void BindPhanLoaiBaoCao()
    {
        List<ListItem> items = new List<ListItem>();
        //items.Add(new ListItem("----Tất cả-----", ""));
        //items.Add(new ListItem("SDNL hàng năm", ReportKey.ANNUAL));
        //items.Add(new ListItem("Kế hoạch hàng năm", ReportKey.PLAN));
        //items.Add(new ListItem("Kế hoạch 5 năm", ReportKey.PLAN5));
        ddlPhanLoaiBC.DataValueField = "value";
        ddlPhanLoaiBC.DataTextField = "text";
        ddlPhanLoaiBC.Items.Add(new ListItem("----Tất cả-----", ""));
        ddlPhanLoaiBC.Items.Add(new ListItem("SDNL hàng năm", ReportKey.ANNUAL));
        ddlPhanLoaiBC.Items.Add(new ListItem("Kế hoạch hàng năm", ReportKey.PLAN));
        ddlPhanLoaiBC.Items.Add(new ListItem("Kế hoạch 5 năm", ReportKey.PLAN5));
        
        //ddlPhanLoaiBC.DataSource = items;
        //ddlPhanLoaiBC.DataBind();
    }
}
