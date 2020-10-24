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
using System.IO;


public partial class Client_Modules_DataEnergy_MyReport : System.Web.UI.UserControl
{
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
    private int CurrentPageApp
    {
        get
        {
            if (ViewState["CurrentPageApp"] != null)
                return Convert.ToInt32(ViewState["CurrentPageApp"].ToString());
            else
                return 1;
        }
        set
        {
            ViewState["CurrentPageApp"] = value;
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
    MemberValidation memVal = new MemberValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (memVal.IsSigned())
            {
                //BindYear();
                Tool.BindYear(ddlYear, "Chọn năm", "");
                BindData();
                BindDataApproved();
            }
            else
                Response.Redirect(ResolveUrl("~"));
        }

    }
    void BindYear()
    {
        IList<EnterpriseYear> list = new List<EnterpriseYear>();
        list = new EnterpriseYearService().GetYearByEnterprise(memVal.OrgId);
        ddlYear.DataSource = list;
        ddlYear.DataTextField = "Year";
        ddlYear.DataValueField = "Year";
        ddlYear.DataBind();
        ddlYear.Items.Insert(0, new ListItem("---Chọn năm---"));
        if (list.Count > 0)
            ddlYear.SelectedIndex = 2;
    }
    private void BindData()
    {
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        if (memVal.OrgId > 0)
        {
            //DataTable list = new ReportFuelService().FindList(false, 0, 0, 0, memVal.OrgId, 0, 0, -1, false, 0, null, null, "", paging);
            DataTable list = new ReportFuelService().FindListWithType(false, 0, 0, 0, memVal.OrgId, 0, 0, -1, false, 0, null, null, "", paging, ReportKey.PLAN);
            rptReport.DataSource = list;
            rptReport.DataBind();
            if (list.Rows.Count > 0)
            {
                Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
                Paging.PageSize = PageSize;
                Paging.DataLoad();
                if (Paging.TotalPages > 1)
                {
                    Paging.Visible = true;
                }
                else
                {
                    Paging.Visible = false;
                }
            }
            else
            {
                Paging.Visible = false;
            }
        }
    }
    private void BindDataApproved()
    {

        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPageApp);
        if (memVal.OrgId > 0)
        {
            //DataTable list = new ReportFuelService().FindList(false, 0, 0, 0, memVal.OrgId, 0, 0, -1, true, 0, null, null, "", paging);
            DataTable list = new ReportFuelService().FindListWithType(false, 0, 0, 0, memVal.OrgId, 0, 0, -1, true, 0, null, null, "", paging, ReportKey.PLAN);
            rptApproved.DataSource = list;
            rptApproved.DataBind();
            if (list.Rows.Count > 0)
            {
                PagingApproved.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
                PagingApproved.PageSize = PageSize;
                PagingApproved.DataLoad();
                if (PagingApproved.TotalPages > 1)
                {
                    PagingApproved.Visible = true;
                }
                else
                {
                    PagingApproved.Visible = false;
                }
            }
            else
            {
                PagingApproved.Visible = false;
            }
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btnDelete = (LinkButton)sender;
        ReportFuelService faqsBSO = new ReportFuelService();
        ReportFuel report = faqsBSO.FindByKey(Convert.ToInt32(btnDelete.CommandArgument));
        if (report != null && report.SendSatus < 1)
        {
            if (faqsBSO.Delete(Convert.ToInt32(btnDelete.CommandArgument)) > 0)
                BindData();
            else
            {
                Tool.Message(this.Page, "Xóa không thành công. Vui lòng thử lại");
            }
        }
        else
        {
            Tool.Message(this.Page, "Báo cáo đã được gửi đi đang được duyệt, bạn không thể xóa báo cáo này.");
        }
    }

    protected void btnAddReport_Click(object sender, EventArgs e)
    {
        ltErr.Text = "";
        if (memVal.OrgId > 0)
        {
            ReportFuelService reportService = new ReportFuelService();
            int ReportYear = Convert.ToInt32(ddlYear.SelectedValue);
            //int iReportNo = reportService.CheckReport(ReportYear, memVal.OrgId);
            int iReportNo = reportService.CheckReportWithType(ReportYear, memVal.OrgId, ReportKey.PLAN);
            if (iReportNo > 0)
            {
                ltErr.Text = "<span style='color:red'>Đã có báo cáo hàng năm của năm " + ddlYear.SelectedValue + ". Vui lòng chọn năm báo cáo khác.</span>";
                //ScriptManager.RegisterStartupScript(this, GetType(), "addReport", "alert('Đã có báo cáo cho năm " + ddlYear.SelectedValue + ". Vui lòng chọn năm báo cáo khác');ShowDialogInitReport();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "addReport", "ShowDialogInitReport();", true);
            }
            else
            {
                ReportFuel report = new ReportFuel();
                report.EnterpriseId = Convert.ToInt32(memVal.OrgId);
                Enterprise enter = new EnterpriseService().FindByKey(report.EnterpriseId);
                if (enter != null)
                {
                    if (enter.ProvinceId > 0)
                        report.ProviceId = enter.ProvinceId;
                    if (enter.DistrictId > 0)
                        report.DistrictId = enter.DistrictId;
                    if (enter.AreaId > 0)
                        report.AreaId = enter.AreaId;
                    if (enter.SubAreaId > 0)
                        report.SubAreaId = enter.SubAreaId;
                    report.ReporterName = enter.ManPerson;
                    IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

                    report.ReportDate = DateTime.Now;
                    report.Address = enter.Address;
                    report.Email = enter.Email;
                    report.Phone = enter.Phone;
                    report.Fax = enter.Fax;
                    report.ParentName = enter.ParentName;
                    report.TaxCode = enter.TaxCode;
                    report.FaxParent = enter.ManFax;
                    report.PhoneParent = enter.ManPhone;
                    report.EmailParent = enter.ManEmail;
                    report.AddressParent = enter.ManAddress;
                    report.ProvinceParentId = enter.ManProvinceId;
                    report.DistrictParentId = enter.ManDistrictId;
                    report.CompanyName = enter.Title;
                    report.Responsible = enter.ManPerson;
                    report.ReportType = ReportKey.PLAN;
                    if (enter != null)
                    {
                        report.OrganizationId = enter.OrganizationId;
                    }
                }
                if (ddlYear.SelectedIndex > 0)
                    report.Year = Convert.ToInt32(ddlYear.SelectedValue);
                report.IsFiveYear = false;
                int ret = reportService.Insert(report);
                if (ret > 0)
                {
                    //Plan plan = new Plan();
                    //plan.CreateByUser = memVal.UserId;
                    //plan.CreateDate = DateTime.Now;
                    //plan.BeginYear = faqs.Year + 1;
                    //plan.EndYear = faqs.Year + 6;
                    //plan.EnterpriseId = faqs.EnterpriseId;
                    //plan.ReportId = ret;
                    //plan.ReportDate = faqs.ReportDate;
                    //new PlanService().Insert(plan);
                    EnterpriseYearService yearService = new EnterpriseYearService();
                    if (yearService.UpdateTOE(memVal.OrgId, report.Year, ret, 0, 0) <= 0)
                    {
                        EnterpriseYear year = new EnterpriseYear();
                        year.EnterpriseId = memVal.OrgId;
                        year.Year = report.Year;
                        year.No_TOE = 0;
                        year.NoTOE_Plan = 0;
                        year.IsKey = true;
                        yearService.Insert(year);
                    }
                    Response.Redirect(ResolveUrl("~") + "bao-cao-so-lieu-hang-nam-r" + ret + ".aspx");
                }
                else
                {
                    ltErr.Text = "Chưa tạo được báo cáo. Vui lòng thử lại.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "addReport", "ShowDialogInitReport();", true);
                }
            }
        }
    }

    protected void rptReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            Literal ltEdit = (Literal)e.Item.FindControl("ltEdit");
            if (Convert.ToBoolean(item["ApprovedSatus"]))
            {
                btnDelete.Visible = false;
            }
            else
            {
                int iStatus = Convert.ToInt32(item["SendSatus"]);

                if (iStatus == 5 || iStatus == 1 || iStatus == 2 || iStatus == 4)
                {
                    btnDelete.Visible = false;
                    ltEdit.Text = "<a href='" + ResolveUrl("~") + "bao-cao-so-lieu-hang-nam-r" + item["Id"] + ".aspx'><i class='fa fa-search'></i></a>";
                }
                else
                {
                    if (iStatus == 0)
                    {
                        btnDelete.Visible = true;
                        ltEdit.Text = "<a href='" + ResolveUrl("~") + "bao-cao-so-lieu-hang-nam-r" + item["Id"] + ".aspx'><i class='fa fa-edit'></i></a>";
                    }
                    else
                    {
                        btnDelete.Visible = false;
                        ltEdit.Text = "<a href='" + ResolveUrl("~") + "bao-cao-so-lieu-hang-nam-r" + item["Id"] + ".aspx'><i class='fa fa-edit'></i></a>";
                    }
                }
            }
        }
    }
    public void PagingApp_Click(object sender, CommandEventArgs e)
    {
        CurrentPageApp = Convert.ToInt32(e.CommandArgument);
        BindDataApproved();

    }
    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();
    }

    protected void rptReport_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
