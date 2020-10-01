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


public partial class Client_Admin_DataEnergy_ViewReportFuel : System.Web.UI.UserControl
{
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

    protected int activeTab
    {
        get
        {
            if (ViewState["activeTab"] != null && ViewState["activeTab"].ToString() != "")
                return (int)ViewState["activeTab"];
            else
                return 0;
        }
        set { ViewState["activeTab"] = value; }
    }
    MemberValidation memVal = new MemberValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCreated.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtApprovedDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["ReportId"]))
                int.TryParse(Request["ReportId"].Replace(",", ""), out Id);
            ReportId = Id;
            BindYear();
            BindArea();
            BindSubArea();
            BindProvince();
            BindDistrict();
            BindDistrictReporter();
            BindEnterprise();
            BindData();
        }

    }


    void BindYear()
    {
        for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 20; i--)
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        ddlYear.Items.Insert(0, new ListItem("---Chọn năm---"));
        ddlYear.SelectedValue = (DateTime.Now.Year - 1).ToString();
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
            ddlArea.Items.Insert(0, new ListItem("---Chọn lĩnh vực---", ""));
        }
        else
        {
            ddlArea.DataSource = null;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("---Chọn lĩnh vực---", ""));

        }
    }
    void BindSubArea()
    {
        ddlSubArea.Items.Clear();
        IList<Area> list = new List<Area>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Area_All))
        {
            list = new AreaService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Area_All, list);
        }
        else
            list = (IList<Area>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Area_All);
        if (list != null && list.Count > 0 && ddlArea.SelectedIndex > 0)
        {
            int ParentId = Convert.ToInt32(ddlArea.SelectedValue);
            var listSearch = from o in list where o.ParentId == ParentId orderby o.SortOrder ascending select o;
            ddlSubArea.DataSource = listSearch;
            ddlSubArea.DataTextField = "AreaName";
            ddlSubArea.DataValueField = "Id";
            ddlSubArea.DataBind();
            ddlSubArea.Items.Insert(0, new ListItem("---Chọn Phân ngành---", ""));
        }
        else
        {
            ddlSubArea.DataSource = null;
            ddlSubArea.DataTextField = "AreaName";
            ddlSubArea.DataValueField = "Id";
            ddlSubArea.DataBind();
            ddlSubArea.Items.Insert(0, new ListItem("---Chọn Phân ngành---", ""));
        }
    }
    void BindProvince()
    {
        IList<Province> list = new List<Province>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Provice_All))
        {
            list = new ProvinceService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Provice_All, list);
        }
        else
            list = (IList<Province>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Provice_All);
        ddlProvince.DataSource = list;
        ddlProvince.DataTextField = "ProvinceName";
        ddlProvince.DataValueField = "Id";
        ddlProvince.DataBind();
        ddlProvince.Items.Insert(0, new ListItem("---Chọn Tỉnh/TP---"));

        ddlProvinceReporter.DataSource = list;
        ddlProvinceReporter.DataTextField = "ProvinceName";
        ddlProvinceReporter.DataValueField = "Id";
        ddlProvinceReporter.DataBind();
        ddlProvinceReporter.Items.Insert(0, new ListItem("---Chọn Tỉnh/TP---"));
    }

    void BindEnterprise()
    {
        if (memVal.OrgId > 0)
        {
            Enterprise enter = new Enterprise();
            enter = new EnterpriseService().FindByKey(Convert.ToInt32(memVal.OrgId));
            if (enter != null)
            {
                txtEnterpriseName.Text = enter.Title;
                if (enter.AreaId > 0)
                {
                    ddlArea.SelectedValue = enter.AreaId.ToString();
                    BindSubArea();
                }
                if (enter.SubAreaId > 0)
                    ddlSubArea.SelectedValue = enter.SubAreaId.ToString();
                if (enter.ProvinceId > 0)
                    ddlProvince.SelectedValue = enter.ProvinceId.ToString();
                if (enter.DistrictId > 0)
                    ddlDistrict.SelectedValue = enter.DistrictId.ToString();
                txtAddress.Text = enter.Address;
                txtEmail.Text = enter.Email;
                txtFax.Text = enter.Fax;
                txtPhone.Text = enter.Phone;
                txtReportName.Text = enter.ManPerson;
                if (enter.ManProvinceId > 0)
                    ddlProvinceReporter.SelectedValue = enter.ManProvinceId.ToString();
                if (enter.ManDistrictId > 0)
                    ddlDistrictReporter.SelectedValue = enter.ManDistrictId.ToString();
                txtAddressReporter.Text = enter.ManAddress;
                txtEmail.Text = enter.ManEmail;
                txtFaxReporter.Text = enter.ManFax;
                txtPhoneReporter.Text = enter.ManPhone;
                txtMST.Text = enter.TaxCode;
            }
        }
    }
    private void BindData()
    {
        if (ReportId > 0)
        {
            try
            {
                ReportFuel faqs = new ReportFuel();
                ReportFuelService faqsBSO = new ReportFuelService();
                faqs = faqsBSO.FindByKey(ReportId);

                if (memVal.OrgId > 0 && faqs.EnterpriseId != Convert.ToInt32(memVal.OrgId))//Neu                     
                    Response.Redirect(ResolveUrl("~"));

                txtReportName.Text = faqs.ReporterName;
                txtCreated.Text = String.Format("{0:dd/MM/yyyy}", faqs.ReportDate);//DateTime.Parse(faqs.PostDate.ToString()).ToString("dd/MM/yyyy hh:mm", ci); // faqs.PostDate.ToString();               

                if (faqs.EnterpriseId > 0)
                {
                    Enterprise enter = new EnterpriseService().FindByKey(faqs.EnterpriseId);
                    if (enter.ManProvinceId > 0)
                        ddlProvinceReporter.SelectedValue = enter.ManProvinceId.ToString();
                    if (enter.ManDistrictId > 0)
                        ddlProvinceReporter.SelectedValue = enter.ManDistrictId.ToString();
                    if (faqs.AreaId > 0)
                    {
                        ddlArea.SelectedValue = enter.AreaId.ToString();
                        BindSubArea();
                    }
                    if (faqs.SubAreaId > 0)
                        ddlSubArea.SelectedValue = enter.SubAreaId.ToString();
                    if (faqs.ProviceId > 0)
                        ddlProvince.SelectedValue = enter.ProvinceId.ToString();
                    if (faqs.DistrictId > 0)
                        ddlDistrict.SelectedValue = enter.DistrictId.ToString();

                    txtAddressReporter.Text = enter.ManAddress;
                    txtReportName.Text = enter.ManPerson;
                    txtFaxReporter.Text = enter.ManFax;
                    txtEmail.Text = enter.Email;
                    txtFax.Text = enter.Fax;
                    txtPhone.Text = enter.Phone;
                    txtAddress.Text = enter.Address;
                }
                if (faqs.AreaId > 0)
                    ddlArea.SelectedValue = faqs.AreaId.ToString();
                if (faqs.SubAreaId > 0)
                    ddlSubArea.SelectedValue = faqs.SubAreaId.ToString();
                if (faqs.ProviceId > 0)
                    ddlProvinceReporter.SelectedValue = faqs.ProviceId.ToString();
                if (faqs.DistrictId > 0)
                    ddlDistrictReporter.SelectedValue = faqs.DistrictId.ToString();
                txtAddressReporter.Text = faqs.Address;
                txtReportName.Text = faqs.ReporterName;
                txtEmail.Text = faqs.Email;
                txtFaxReporter.Text = faqs.Fax;
                txtPhoneReporter.Text = faqs.Phone;
                if (faqs.Year > 0)
                    ddlYear.SelectedValue = faqs.Year.ToString();
                BindReportDetail();
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            Enterprise enter = new EnterpriseService().FindByKey(1);
            if (enter.ManProvinceId > 0)
                ddlProvinceReporter.SelectedValue = enter.ManProvinceId.ToString();
            if (enter.ManDistrictId > 0)
                ddlProvinceReporter.SelectedValue = enter.ManDistrictId.ToString();
            txtAddressReporter.Text = enter.ManAddress;
            txtReportName.Text = enter.ManPerson;
            txtFaxReporter.Text = enter.ManFax;
            txtPhoneReporter.Text = enter.ManPhone;
            txtEmail.Text = enter.Email;
            txtAddress.Text = enter.Address;
            txtPhone.Text = enter.Phone;
            if (enter.AreaId > 0)
                ddlArea.SelectedValue = enter.AreaId.ToString();
            if (enter.SubAreaId > 0)
                ddlSubArea.SelectedValue = enter.SubAreaId.ToString();
            if (enter.ProvinceId > 0)
                ddlProvince.SelectedValue = enter.ProvinceId.ToString();
            if (enter.DistrictId > 0)
                ddlDistrict.SelectedValue = enter.DistrictId.ToString();
        }

    }

    void BindReportDetail()
    {
        DataTable dtCurrent = new ReportFuelDetailService().GetNoFuelDetailByReport(ReportId, false);
        rptNoFuelCurrent.DataSource = dtCurrent;
        rptNoFuelCurrent.DataBind();
        DataTable dtFuture = new ReportFuelDetailService().GetNoFuelDetailByReport(ReportId, true);
        rptNoFuelFuture.DataSource = dtFuture;
        rptNoFuelFuture.DataBind();
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ReportFuelService faqsBSO = new ReportFuelService();
            ReportFuel faqs = faqsBSO.FindByKey(ReportId);
            faqs.ApprovedSatus = true;
            faqs.AprovedDate = DateTime.Now;
            faqs.ConfirmedDate = Convert.ToDateTime(txtApprovedDate.Text.Trim());
            faqs.Id = ReportId;
            //faqs.ApproverId=m_
            if (faqsBSO.Update(faqs) != null)
            {
                this.Page.RegisterClientScriptBlock("Close", "<script>window.close(); window.opener.location.reload(false); </script>");
            }
            else
                clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Gửi báo cáo không thành công !</div>";
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
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
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubArea();
    }
    void BindDistrictReporter()
    {
        IList<District> list = new List<District>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_District_All))
        {
            list = new DistrictService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_District_All, list);
        }
        else
            list = (IList<District>)AspNetCache.GetCache(Constants.Cache_ReportFuel_District_All);
        if (ddlProvinceReporter.SelectedIndex > 0)
        {
            var listSearch = from o in list where o.ProvinceId == Convert.ToInt32(ddlProvinceReporter.SelectedValue) orderby o.DistrictName ascending select o;
            ddlDistrictReporter.DataSource = listSearch;
            ddlDistrictReporter.DataTextField = "DistrictName";
            ddlDistrictReporter.DataValueField = "Id";
            ddlDistrictReporter.DataBind();
            ddlDistrictReporter.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---", ""));
        }
        else
        {
            ddlDistrictReporter.DataSource = list;
            ddlDistrictReporter.DataTextField = "DistrictName";
            ddlDistrictReporter.DataValueField = "Id";
            ddlDistrictReporter.DataBind();
            ddlDistrictReporter.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---", ""));
        }
    }
    void BindDistrict()
    {
        IList<District> list = new List<District>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_District_All))
        {
            list = new DistrictService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_District_All, list);
        }
        else
            list = (IList<District>)AspNetCache.GetCache(Constants.Cache_ReportFuel_District_All);
        if (ddlProvince.SelectedIndex > 0)
        {
            var listSearch = from o in list where o.ProvinceId == Convert.ToInt32(ddlProvince.SelectedValue) orderby o.DistrictName ascending select o;
            ddlDistrict.DataSource = listSearch;
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "Id";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---", ""));
        }
        else
        {
            ddlDistrict.DataSource = list;
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "Id";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("---Chọn Quận/Huyện---", ""));
        }

    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDistrict();
    }
    protected void ddlProvinceReporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDistrictReporter();
    }
    protected void lbtDownload_Click(object sender, EventArgs e)
    {
        ReportFuel report = new ReportFuelService().FindByKey(ReportId);
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
}
