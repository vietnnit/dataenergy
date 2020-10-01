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


public partial class Client_Admin_DataEnergy_UnConfirmAuditReportList : System.Web.UI.UserControl
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
    UserValidation memVal = new UserValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArea();
            BindDistrict();
            if (memVal.IsSigned())
            {
                Tool.BindYear(ddlYear, "Tất cả", "");
                BindData();
            }
            else
                Response.Redirect(ResolveUrl("~"));
        }

    }

    private void BindData()
    {
        ePower.Core.PagingInfo paging = new ePower.Core.PagingInfo(PageSize, CurrentPage);
        if (memVal.OrgId > 0)
        {
            int AuditYear = 0;
            if (ddlYear.SelectedIndex > 0)
                AuditYear = Convert.ToInt32(ddlYear.SelectedValue);
            int AreaId = 0;
            if (ddlArea.SelectedIndex > 0)
                AreaId = Convert.ToInt32(ddlArea.SelectedValue);
            int DistrictId = 0;
            if (ddlDistrict.SelectedIndex > 0)
                DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
            DataTable list = new AuditReportService().FindList(AreaId, 0, memVal.OrgId, 0, 0, DistrictId, Convert.ToInt32(AuditReportStatus.SENT), AuditYear, txtKeyword.Text.Trim(), paging);
            rptAuditReport.DataSource = list;
            rptAuditReport.DataBind();
            if (list != null && list.Rows.Count > 0)
            {
                Paging.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
                Paging.PageSize = PageSize;
                Paging.DataLoad();
                Paging2.TotalRecord = Convert.ToInt32(list.Rows[0]["Total"]);
                Paging2.PageSize = PageSize;
                Paging2.DataLoad();
                if (Paging.TotalPages > 1)
                {
                    ltNotice.Text = "Có " + list.Rows.Count + " trong tổng số " + list.Rows[0]["Total"] + " báo cáo";
                    Paging2.Visible = Paging.Visible = true;
                }
                else
                {
                    ltNotice.Text = "Có tổng số " + list.Rows[0]["Total"] + " báo cáo";
                    Paging2.Visible = Paging.Visible = false;
                }
            }
            else
            {
                Paging2.Visible = Paging.Visible = false;
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
        AuditReportService faqsBSO = new AuditReportService();
        AuditReport report = faqsBSO.FindByKey(Convert.ToInt32(btnDelete.CommandArgument));
        if (report != null && report.Status > 0)
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

    void BindDistrict()
    {
        ddlDistrict.Items.Clear();
        if (memVal.OrgId > 0)
        {
            Organization org = new OrganizationService().FindByKey(memVal.OrgId);
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
    protected void btnAddReport_Click(object sender, EventArgs e)
    {
        if (memVal.OrgId > 0)
        {
            AuditReport report = new AuditReport();
            report.EnterpriseId = Convert.ToInt32(memVal.OrgId);
            report.AuditYear = Convert.ToInt32(ddlAuditYear.SelectedValue);
            report.DataYear = Convert.ToInt32(ddlDataYear.SelectedValue);
            report.AuditConsultancyName = txtAuditConsultant.Text.Trim();
            report.Address = txtAddress.Text.Trim();
            report.AuditorName = txtAuditor.Text.Trim();
            report.AuditingScope = txtAuditScope.Text.Trim();
            report.ShiftNo = Convert.ToInt32(rbtShiftNo.SelectedValue);
            int ret = new AuditReportService().Insert(report);
            if (ret > 0)
            {
                Response.Redirect(ResolveUrl("~") + "bao-cao-so-kiem-toan-nl-" + ret + ".aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "addReport", "ShowDialogAuditReport();", true);
            }

        }
    }


    public void Paging_Click(object sender, CommandEventArgs e)
    {
        CurrentPage = Convert.ToInt32(e.CommandArgument);
        BindData();
    }
    protected void rptAuditReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            Literal ltEdit = (Literal)e.Item.FindControl("ltEdit");
            LinkButton lbtDownload = (LinkButton)e.Item.FindControl("lbtDownload");
            if (item != null && item["PathFile"] != null && item["PathFile"].ToString() != "")
            {
                lbtDownload.Visible = true;
            }
            else
                lbtDownload.Visible = false;

            ltEdit.Text = "<a class='' href='" + ResolveUrl("~") + "Admin/ViewAuditReport/" + item["Id"] + "/Default.aspx'><i class='fa fa-search'></i></a>";
        }
    }

    protected void rptAuditReport_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("WordComment"))
        {

        }
    }

    protected void lbtDownload_Click(object sender, EventArgs e)
    {
        LinkButton lbtDownload = (LinkButton)sender;
        AuditReport report = new AuditReportService().FindByKey(Convert.ToInt32(lbtDownload.CommandArgument));
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
            Response.WriteFile(path);
            Response.End();
        }
    }
}
