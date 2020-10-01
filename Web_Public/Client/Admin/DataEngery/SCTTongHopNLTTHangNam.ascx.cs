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
using Aspose.Cells;
using System.IO;

public partial class Client_Admin_DataEngery_SCTTongHopNLTTHangNam : System.Web.UI.UserControl
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
        int Id = 0;
        if (!string.IsNullOrEmpty(Request["Id"]))
            int.TryParse(Request["Id"].Replace(",", ""), out Id);
        ReportId = Id;
        if (!string.IsNullOrEmpty(Request["dll"]))
            NavigationTitle(Request["dll"]);

        if (!IsPostBack)
        {
            Tool.BindYear(ddlYear, "Tất cả", "");
            BindArea();
            //BindSubArea();
            //BindProvince();
            int ProvinceId = BindDistrict();
            ViewState["ProvinceId"] = ProvinceId;
            //BindEnterprise();
            //BindOrganization();
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

    void BindArea()
    {
        IList<ePower.DE.Domain.Area> list = new List<ePower.DE.Domain.Area>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Area_All))
        {
            list = new AreaService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Area_All, list);
        }
        else
            list = (IList<ePower.DE.Domain.Area>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Area_All);
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
    //void BindSubArea()
    //{
    //    ddlSubArea.Items.Clear();
    //    IList<ePower.DE.Domain.Area> list = new List<ePower.DE.Domain.Area>();
    //    if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Area_All))
    //    {
    //        list = new AreaService().FindAll();
    //        AspNetCache.SetCache(Constants.Cache_ReportFuel_Area_All, list);
    //    }
    //    else
    //        list = (IList<ePower.DE.Domain.Area>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Area_All);
    //    if (list != null && list.Count > 0)
    //    {
    //        if (ddlArea.SelectedIndex > 0)
    //        {
    //            int ParentId = Convert.ToInt32(ddlArea.SelectedValue);
    //            var listSearch = from o in list where o.ParentId == ParentId orderby o.AreaName, o.SortOrder ascending select o;
    //            ddlSubArea.DataSource = listSearch;
    //            ddlSubArea.DataTextField = "AreaName";
    //            ddlSubArea.DataValueField = "Id";
    //            ddlSubArea.DataBind();
    //            ddlSubArea.Items.Insert(0, new ListItem("---Tất cả---", ""));
    //        }
    //        else
    //        {
    //            var listSearch = from o in list where o.ParentId != null && o.ParentId > 0 orderby o.AreaName ascending, o.SortOrder ascending select o;
    //            ddlSubArea.DataSource = listSearch;
    //            ddlSubArea.DataTextField = "AreaName";
    //            ddlSubArea.DataValueField = "Id";
    //            ddlSubArea.DataBind();
    //            ddlSubArea.Items.Insert(0, new ListItem("---Tất cả---", ""));
    //        }
    //    }
    //    else
    //    {
    //        ddlSubArea.DataSource = null;
    //        ddlSubArea.DataTextField = "AreaName";
    //        ddlSubArea.DataValueField = "Id";
    //        ddlSubArea.DataBind();
    //        ddlSubArea.Items.Insert(0, new ListItem("---Tất cả---", ""));
    //    }
    //}
    //void BindProvince()
    //{
    //    IList<Province> list = new List<Province>();
    //    if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Provice_All))
    //    {
    //        list = new ProvinceService().FindAll();
    //        AspNetCache.SetCache(Constants.Cache_ReportFuel_Provice_All, list);
    //    }
    //    else
    //        list = (IList<Province>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Provice_All);
    //    ddlProvince.DataSource = list;
    //    ddlProvince.DataTextField = "ProvinceName";
    //    ddlProvince.DataValueField = "Id";
    //    ddlProvince.DataBind();
    //    ddlProvince.Items.Insert(0, new ListItem("---Chọn Tỉnh/TP---"));

    //    ddlProvinceReporter.DataSource = list;
    //    ddlProvinceReporter.DataTextField = "ProvinceName";
    //    ddlProvinceReporter.DataValueField = "Id";
    //    ddlProvinceReporter.DataBind();
    //    ddlProvinceReporter.Items.Insert(0, new ListItem("---Chọn Tỉnh/TP---"));
    //}
    int BindDistrict()
    {
        int ProvinceId = 0;
        ddlDistrict.Items.Clear();
        if (m_UserValidation.OrgId > 0)
        {
            Organization org = new OrganizationService().FindByKey(m_UserValidation.OrgId);
            ProvinceId = org.ProvinceId;
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
                var listSearch = from o in list where o.ProvinceId == m_UserValidation.OrgId orderby o.DistrictName ascending select o;
                ddlDistrict.DataSource = listSearch;
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("---Tất cả---", ""));
            }
        }
        return ProvinceId;

    }
    //void BindEnterprise()
    //{
    //    int EnterpriseId = 1;
    //    Enterprise enter = new Enterprise();
    //    enter = new EnterpriseService().FindByKey(EnterpriseId);
    //    if (enter != null)
    //    {
    //        txtEnterpriseName.Text = enter.Title;
    //        if (enter.SubAreaId > 0)
    //            ddlSubArea.SelectedValue = enter.SubAreaId.ToString();
    //        if (enter.AreaId > 0)
    //            ddlArea.SelectedValue = enter.AreaId.ToString();
    //        if (enter.ProvinceId > 0)
    //            ddlProvince.SelectedValue = enter.ProvinceId.ToString();
    //        if (enter.DistrictId > 0)
    //            ddlDistrict.SelectedValue = enter.DistrictId.ToString();
    //        txtAddress.Text = enter.Address;
    //        txtEmail.Text = enter.Email;
    //        txtFax.Text = enter.Fax;
    //        txtPhone.Text = enter.Phone;
    //        txtReportName.Text = enter.ManPerson;
    //        if (enter.ManProvinceId > 0)
    //            ddlProvinceReporter.SelectedValue = enter.ManProvinceId.ToString();
    //        if (enter.ManDistrictId > 0)
    //            ddlDistrictReporter.SelectedValue = enter.ManDistrictId.ToString();
    //        txtAddressReporter.Text = enter.ManAddress;
    //        txtEmail.Text = enter.ManEmail;
    //        txtFaxReporter.Text = enter.ManFax;
    //        txtPhoneReporter.Text = enter.ManPhone;
    //    }
    //}
    //void BindOrganization()
    //{
    //    IList<Organization> list = new List<Organization>();
    //    if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Organization_All))
    //    {
    //        list = new OrganizationService().FindAll();
    //        AspNetCache.SetCache(Constants.Cache_ReportFuel_Organization_All, list);
    //    }
    //    else
    //        list = (IList<Organization>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Organization_All);
    //    ddlOrg.DataSource = list;
    //    ddlOrg.DataTextField = "Title";
    //    ddlOrg.DataValueField = "Id";
    //    ddlOrg.DataBind();
    //    ddlOrg.Items.Insert(0, new ListItem("---Tất cả---", ""));
    //}
    private void BindData()
    {
        int ProvinceId = Convert.ToInt32(ViewState["ProvinceId"]);
        ltData.Text = "";
        //IList<Fuel> listFuel = new List<Fuel>();
        //if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Fuel_All))
        //{
        //    listFuel = new FuelService().FindAll();
        //    AspNetCache.SetCache(Constants.Cache_ReportFuel_Fuel_All, listFuel);
        //}
        //else
        //    listFuel = (IList<Fuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Fuel_All);


        ReportFuelService comBSO = new ReportFuelService();
        DataTable list = new DataTable();
        int AreaId = 0;
        int DistrictId = 0;
        int Year = 0;

        if (ddlArea.SelectedIndex > 0)
            AreaId = Convert.ToInt32(ddlArea.SelectedValue);
        if (ddlDistrict.SelectedIndex > 0)
            DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);

        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        list = comBSO.TongHopMucNLTT(false, AreaId, 0, m_UserValidation.OrgId, 0, ProvinceId, 0, -1, true, Year, null, null, txtKeyword.Text.Trim(), paging);
        if (list == null)
            return;
        CreateList(list);



        if (list != null && list.Rows.Count > 0)
        {

            paging.RowsCount = list.Rows.Count;
            Paging.PageSize = PageSize;
            Paging.CurrentPage = CurrentPage;
            Paging.TotalRecord = list.Rows.Count;
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
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindSubArea();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        int ProvinceId = Convert.ToInt32(ViewState["ProvinceId"]);
        ReportFuelService comBSO = new ReportFuelService();
        DataTable list = new DataTable();
        int AreaId = 0;
        int SubAreaId = 0;
        int Year = 0;
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(2000, CurrentPage);
        list = comBSO.TongHopMucNLTT(false, AreaId, 0, m_UserValidation.OrgId, 0, ProvinceId, 0, -1, true, Year, null, null, txtKeyword.Text.Trim(), paging);
        if (list == null)
            return;
        else
            ExportExcel(list);

    }
    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindData();

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
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");

        }
    }
    protected void rptNoFuelCurrent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",true); return false;");

        }
    }

    private static string GetHeader(string tableHeader)
    {
        string res = string.Empty;
        switch (tableHeader)
        {
            case "Title":
                res = "Tên DN";
                break;
            case "Address":
                res = "Địa chỉ";
                break;
            case "ParentAreaName":
                res = "Lĩnh vực";
                break;
            case "AreaName":
                res = "Ngành nghề";
                break;
            case "TOE":
                res = "Năng lượng tiêu thụ quy đổi (TOE)";
                break;
            default:
                res = tableHeader;
                break;
        }
        return res;
    }

    private void CreateList(DataTable src)
    {
        string table = string.Empty;
        table += "<table class='table table-bordered table-hover mbn' width='100%'>";
        table += "<tr class='primary fs12'>";
        table += "";
        //Create header table += "";
        int TotalColumn = 0;
        foreach (DataColumn col in src.Columns)
        {
            TotalColumn++;
            string name = GetHeader(col.ColumnName);
            switch (name)
            {
                case "Title":
                    table += string.Format(" <th style='width: 35%'>{0}</th>", name);
                    break;
                case "Address":
                    table += string.Format(" <th style='width: 10%'>{0}</th>", name);
                    break;
                case "ParentAreaName":
                    table += string.Format(" <th style='width: 10%'>{0}</th>", name);
                    break;
                case "AreaName":
                    table += string.Format(" <th style='width: 10%'>{0}</th>", name);
                    break;
                case "TOE":
                    table += string.Format(" <th style='width: 10%'>{0}</th>", name);
                    break;
                default:
                    table += string.Format(" <th>{0}</th>", name);
                    break;
            }
        }
        table += "</tr>";
        //content
        if (src != null)
        {

            foreach (DataRow row in src.Rows)
            {
                table += "<tr>";
                for (int i = 0; i < TotalColumn; i++)
                    table += string.Format("<td>{0}</td>", row[i]);
                table += "</tr>";
            }

        }
        table += "</table>";
        ltReportView.Text = table;
    }

    private void ExportExcel(DataTable src)
    {
        if (src == null)
            return;
        string temp_path = Server.MapPath("~/Client/Admin/DataEngery/TongHopNLTTHangNam.xls");
        Workbook _Excell = new Workbook();
        _Excell.Open(temp_path);
        Worksheet _Sheet = _Excell.Worksheets[0];


        #region Build Sheet
        int rowStart = 1;
        int TotalColumn = 0;
        int ColIndex = 0;
        //Excel header
        foreach (DataColumn col in src.Columns)
        {
            TotalColumn++;
            string name = GetHeader(col.ColumnName);
            _Sheet.Cells[rowStart, ColIndex].PutValue(name);
            ColIndex++;
        }
        rowStart++;

        //content
        if (src != null)
        {
            foreach (DataRow row in src.Rows)
            {
                for (int i = 0; i < TotalColumn; i++)
                {
                    _Sheet.Cells[rowStart, i].PutValue(row[i].ToString());
                }
                rowStart++;
            }
        }

        _Sheet.AutoFitRows();
        _Excell.Save("TongHopNLTTHangNam.xls", SaveType.OpenInBrowser, FileFormatType.Default, this.Response);
        #endregion
    }
}