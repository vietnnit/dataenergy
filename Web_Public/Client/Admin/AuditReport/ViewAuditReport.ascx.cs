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
using System.Net;

public partial class Client_Admin_AuditReport_ViewAuditReport : System.Web.UI.UserControl
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
    public int AuditYearReport
    {
        get
        {
            if (ViewState["AuditYearReport"] != null && ViewState["AuditYearReport"].ToString() != "")
                return (int)ViewState["AuditYearReport"];
            else
                return 0;
        }
        set { ViewState["AuditYearReport"] = value; }
    }
    public bool AllowEdit
    {
        get
        {
            if (ViewState["AllowEdit"] != null && ViewState["AllowEdit"].ToString() != "")
                return (bool)ViewState["AllowEdit"];
            else
                return true;
        }
        set { ViewState["AllowEdit"] = value; }
    }
    UserValidation memVal = new UserValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["Id"]))
                int.TryParse(Request["Id"].Replace(",", ""), out Id);
            ReportId = Id;

            int activeId = 0;
            if (!string.IsNullOrEmpty(Request["activetab"]))
                int.TryParse(Request["activetab"].Replace(",", ""), out activeId);
            activeTab = activeId;
            if (ReportId > 0)
            {
                BindReportInfo();
                BindEquipment();
            }
        }

    }

    private void BindReportInfo()
    {
        if (ReportId > 0)
        {
            try
            {
                AuditReport report = new AuditReport();
                AuditReportService reportBSO = new AuditReportService();
                report = reportBSO.FindByKey(ReportId);
                if (report != null)
                {
                    if (report.Status == 1|| report.Status == 3)
                    {
                        btnSend.Visible = true;
                        btnConfirm.Visible = true;
                    }
                    else
                    {
                        btnSend.Visible = false;
                        btnConfirm.Visible = false;
                    }
                    if (report.PathFile != "")
                    {
                        lbtDownload.Text = report.PathFile;
                        lbtDownload.Visible = true;

                    }
                    else
                    {
                        lbtDownload.Visible = false;
                    }
                    if (report.EnterpriseId > 0)
                    {
                        Enterprise enter = new EnterpriseService().FindByKey((report.EnterpriseId));
                        if (enter != null)
                        {
                            ltEnterpriseName.Text = enter.Title;
                            ucEnergyConsume.CustomerCode = enter.CustomerCode;

                            ltAreaName.Text = "------";
                            if (enter.AreaId > 0)
                            {
                                Area area = new Area();
                                area = new AreaService().FindByKey(enter.AreaId);
                                if (area != null)
                                    ltAreaName.Text = area.AreaName;
                            }
                            ltSubAreaName.Text = "------";
                            if (enter.SubAreaId > 0)
                            {
                                Area area = new Area();
                                area = new AreaService().FindByKey(enter.SubAreaId);
                                if (area != null)
                                    ltSubAreaName.Text = area.AreaName;
                            }
                            ltProvinceName.Text = "------";
                            if (enter.ProvinceId > 0)
                            {
                                Province area = new Province();
                                area = new ProvinceService().FindByKey(enter.ProvinceId);
                                if (area != null)
                                    ltProvinceName.Text = area.ProvinceName;
                            }
                            ltDistrictName.Text = "------";
                            if (enter.DistrictId > 0)
                            {
                                District area = new District();
                                area = new DistrictService().FindByKey(enter.DistrictId);
                                if (area != null)
                                    ltDistrictName.Text = area.DistrictName;
                            }
                            ltTaxNo.Text = enter.TaxCode;
                            ltAddress.Text = enter.Address;
                            ltEmail.Text = enter.Email;
                            ltFaxNo.Text = enter.Fax;
                            ltPhoneNumber.Text = enter.Phone;
                            ltResponsible.Text = enter.ManPerson;

                            ltParentName.Text = enter.ParentName;
                            ltProvinceParent.Text = "------";
                            if (enter.ManProvinceId > 0)
                            {
                                Province area = new Province();
                                area = new ProvinceService().FindByKey(enter.ManProvinceId);
                                if (area != null)
                                    ltProvinceParent.Text = area.ProvinceName;
                            }

                            //ltDistrictParent.Text = ddlDistrictReporter.SelectedItem.Text;
                            ltDistrictParent.Text = "------";
                            if (enter.ManDistrictId > 0)
                            {
                                District area = new District();
                                area = new DistrictService().FindByKey(enter.ManDistrictId);
                                if (area != null)
                                    ltDistrictParent.Text = area.DistrictName;
                            }

                            ltEmailParent.Text = enter.ManEmail;
                            ltFaxParent.Text = enter.ManFax;
                            ltAddressParent.Text = enter.ManAddress;
                            ltPhoneParent.Text = enter.ManPhone;
                            ltCustomerCode.Text = enter.CustomerCode;
                        }
                    }
                    ucElectrictSystem.ReportYear = report.AuditYear;
                    ucElectrictSystem.AllowEdit = AllowEdit;
                    ucElectrictSystem.ReportId = ReportId;

                    ucAuditSolution.ReportYear = report.AuditYear;
                    ucAuditSolution.AllowEdit = AllowEdit;
                    ucAuditSolution.ReportId = ReportId;

                    ucAuditProduct.ReportYear = report.AuditYear;
                    ucAuditProduct.AllowEdit = AllowEdit;
                    ucAuditProduct.ReportId = ReportId;

                    ucAuditOperationArea.ReportYear = report.AuditYear;
                    ucAuditOperationArea.AllowEdit = AllowEdit;
                    ucAuditOperationArea.ReportId = ReportId;

                    ucEnergyConsume.ReportYear = report.AuditYear;
                    ucEnergyConsume.AllowEdit = AllowEdit;
                    ucEnergyConsume.ReportId = ReportId;

                    ucEnergyQuota.ReportYear = report.AuditYear;
                    ucEnergyQuota.AllowEdit = AllowEdit;
                    ucEnergyQuota.ReportId = ReportId;

                    //if (memVal.OrgId > 0 && report.Or != Convert.ToInt32(memVal.OrgId))//Neu                     
                    //    Response.Redirect(ResolveUrl("~"));
                    AuditYearReport = report.AuditYear;
                    ltAuditYear.Text = AuditYearReport.ToString();


                    ltAuditYear.Text = AuditYearReport.ToString();
                    ltDataYear.Text = report.DataYear.ToString();

                    ltAuditUnit.Text = report.AuditConsultancyName;
                    ltAuditAddress.Text = report.Address;

                    ltAuditor.Text = report.AuditorName;
                    ltAuditScope.Text = report.AuditingScope;
                    ltShiftNo1.Text = "";
                    ltShiftNo2.Text = "";
                    ltShiftNo3.Text = "";
                    if (report.ShiftNo == 0)
                        ltShiftNo1.Text = "X";
                    else
                    {
                        if (report.ShiftNo == 1)
                            ltShiftNo2.Text = "X";
                        else
                            ltShiftNo3.Text = "X";
                    }

                }
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
    }
    void BindLog()
    {
        IList<ReportLog> list = new List<ReportLog>();
        list = new ReportLogService().GetLogByReport(ReportId, Convert.ToInt32(LogType.AUDITREPORT));
        rptLog.DataSource = list;
        rptLog.DataBind();
    }
    void BindReportFile()
    {
        IList<ReportAttachFile> list = new List<ReportAttachFile>();
        list = new ReportAttachFileService().GetFileByReport(ReportId, Convert.ToInt32(LogType.AUDITREPORT));
        rptReportFile.DataSource = list;
        rptReportFile.DataBind();
    }

    void BindEquipment()
    {
        DataTable dt = new DataTable();
        dt = new TestEquipmentService().GetList(ReportId);
        rptEquipment.DataSource = dt;
        rptEquipment.DataBind();
    }

    protected void rptEquipment_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
        }
    }
    protected void rptEquipment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {

        try
        {
            AuditReportService faqsBSO = new AuditReportService();
            ReportLog log = new ReportLog();
            log.ActionName = "Xác nhận báo cáo";
            log.Comment = txtContent.Text;
            log.ReportId = ReportId;
            log.Created = DateTime.Now;
            log.MemberId = memVal.UserId;
            log.UserName = memVal.UserName;
            log.LogType = Convert.ToInt32(LogType.AUDITREPORT);
            if (rblApproved.SelectedIndex == 0)
            {
                log.Status = "Đã hoàn thành";
                new ReportLogService().Insert(log);

                if (faqsBSO.UpdateStatus(ReportId, Convert.ToInt32(AuditReportStatus.CONFIRMED)) > 0)
                {
                    Response.Redirect(ResolveUrl("~") + "Admin/UnConfirmAuditReportList/Default.aspx");
                }
            }
            else
            {
                log.Status = "Đang tiếp tục";
                new ReportLogService().Insert(log);
                if (faqsBSO.UpdateStatus(ReportId, Convert.ToInt32(AuditReportStatus.EDIT)) > 0)
                {
                    Response.Redirect(ResolveUrl("~") + "Admin/UnConfirmAuditReportList/Default.aspx");
                }
            }


        }
        catch (Exception ex)
        {
            //clientview.Text = ex.Message.ToString();
        }

    }
    protected void lbtDownload_Click(object sender, EventArgs e)
    {
        LinkButton btnDownload = (LinkButton)sender;
        if (btnDownload != null && btnDownload.Text != "")
        {
            string Filpath = Server.MapPath("~/UserFile/Report/" + btnDownload.Text);
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
