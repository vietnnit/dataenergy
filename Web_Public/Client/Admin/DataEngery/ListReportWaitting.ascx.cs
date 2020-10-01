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


public partial class Client_Admin_DataEnergy_ListReportWaitting : System.Web.UI.UserControl
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
            txtNgayTiepNhan.Text = DateTime.Today.ToString("dd/MM/yyyy");
            BindYear();
            //BindArea();
            //BindSubArea();
            //BindProvince();
            //BindDistrict();
            //BindEnterprise();            
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
            ddlYear.Items.Add(new ListItem("Năm " + i, i.ToString()));
        ddlYear.Items.Insert(0, new ListItem("---Tất cả---"));
        //ddlYear.SelectedValue = (DateTime.Now.Year - 1).ToString();
    }
    //void BindArea()
    //{
    //    IList<ProjectArea> list = new List<ProjectArea>();
    //    if (!AspNetCache.CheckCache(Constants.Cache_Project_Area_All))
    //    {
    //        list = new ProjectAreaService().FindAll();
    //        AspNetCache.SetCache(Constants.Cache_Project_Area_All, list);
    //    }
    //    else
    //        list = (IList<ProjectArea>)AspNetCache.GetCache(Constants.Cache_Project_Area_All);
    //    ddlArea.DataSource = list;
    //    ddlArea.DataTextField = "AreaName";
    //    ddlArea.DataValueField = "Id";
    //    ddlArea.DataBind();
    //    ddlArea.Items.Insert(0, new ListItem("---Chọn lĩnh vực---"));
    //}
    //void BindSubArea()
    //{
    //    IList<ProjectArea> list = new List<ProjectArea>();
    //    if (!AspNetCache.CheckCache(Constants.Cache_Project_Area_All))
    //    {
    //        list = new ProjectAreaService().FindAll();
    //        AspNetCache.SetCache(Constants.Cache_Project_Area_All, list);
    //    }
    //    else
    //        list = (IList<ProjectArea>)AspNetCache.GetCache(Constants.Cache_Project_Area_All);
    //    ddlSubArea.DataSource = list;
    //    ddlSubArea.DataTextField = "AreaName";
    //    ddlSubArea.DataValueField = "Id";
    //    ddlSubArea.DataBind();
    //    ddlSubArea.Items.Insert(0, new ListItem("---Chọn phân ngành---"));
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
    //void BindDistrict()
    //{
    //    IList<District> list = new List<District>();
    //    if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_District_All))
    //    {
    //        list = new DistrictService().FindAll();
    //        AspNetCache.SetCache(Constants.Cache_ReportFuel_District_All, list);
    //    }
    //    else
    //        list = (IList<District>)AspNetCache.GetCache(Constants.Cache_ReportFuel_District_All);
    //    ddlDistrict.DataSource = list;
    //    ddlDistrict.DataTextField = "DistrictName";
    //    ddlDistrict.DataValueField = "Id";
    //    ddlDistrict.DataBind();
    //    ddlDistrict.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---"));

    //    ddlDistrictReporter.DataSource = list;
    //    ddlDistrictReporter.DataTextField = "DistrictName";
    //    ddlDistrictReporter.DataValueField = "Id";
    //    ddlDistrictReporter.DataBind();
    //    ddlDistrictReporter.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---"));
    //}
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

    private void BindData()
    {
        ReportFuelService comBSO = new ReportFuelService();
        DataTable list = new DataTable();
        int AreaId = 0;
        int SubAreaId = 0;
        int Year = 0;
        if (ddlYear.SelectedIndex > 0)
            Year = Convert.ToInt32(ddlYear.SelectedValue);
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        Admin admin = new AdminBSO().GetAdminById(m_UserValidation.UserId);
        list = comBSO.FindList(false, AreaId, SubAreaId, admin.AdminOrganizationId, 0, 0, 0, 1, false, Year, null, null, "", paging);
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
                ltNotice.Text = "Có " + list.Rows.Count + " trong tổng số " + paging.RowsCount + " báo cáo";
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

                ReportFuel reportFuel = new ReportFuel();
                reportFuel = new ReportFuelService().FindByKey(report);
                reportFuel.ReceivedDate = Convert.ToDateTime(txtNgayTiepNhan.Text.Trim());
                reportFuel.SendSatus = 2;//Da tiep nhan                
                if (new ReportFuelService().Update(reportFuel) != null)
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
}
