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
using log4net;

public partial class Client_Modules_AuditReport_InputAuditReport : System.Web.UI.UserControl
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
    MemberValidation memVal = new MemberValidation();
    private static readonly ILog log = LogManager.GetLogger(typeof(Client_Modules_AuditReport_InputAuditReport));
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!memVal.IsSigned())
                Response.Redirect(ResolveUrl("~"));
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["AuditReportId"]))
                int.TryParse(Request["AuditReportId"].Replace(",", ""), out Id);
            ReportId = Id;

            int activeId = 0;
            if (!string.IsNullOrEmpty(Request["activetab"]))
                int.TryParse(Request["activetab"].Replace(",", ""), out activeId);
            activeTab = activeId;
            Tool.BindYear(ddlAuditYear, "Chọn năm", "");
            Tool.BindYear(ddlDataYear, "Chọn năm", "");
            if (ReportId > 0)
            {
                BindReportInfo();
                BindEquipment();
                BindReportFile();
                BindLog();
            }
        }

    }

    #region initControl


    void BindLog()
    {
        IList<ReportLog> list = new List<ReportLog>();
        list = new ReportLogService().GetLogByReport(ReportId, Convert.ToInt32(LogType.AUDITREPORT));
        rptLog.DataSource = list;
        rptLog.DataBind();
    }
    void BindEquipment()
    {
        DataTable dt = new DataTable();
        dt = new TestEquipmentService().GetList(ReportId);
        rptEquipment.DataSource = dt;
        rptEquipment.DataBind();
    }
    void BindReportFile()
    {
        IList<ReportAttachFile> list = new List<ReportAttachFile>();
        list = new ReportAttachFileService().GetFileByReport(ReportId, Convert.ToInt32(LogType.AUDITREPORT));
        rptReportFile.DataSource = list;
        rptReportFile.DataBind();
    }

    private void BindReportInfo()
    {
        if (ReportId > 0)
        {
            btn_edit2.Visible = true;
            AllowEdit = true;
            try
            {
                AuditReport report = new AuditReport();
                AuditReportService reportBSO = new AuditReportService();
                report = reportBSO.FindByKey(ReportId);
                if (report != null)
                {
                    if (memVal.OrgId > 0)
                    {
                        Enterprise enter = new EnterpriseService().FindByKey((memVal.OrgId));
                        if (enter != null)
                            ucEnergyConsume.CustomerCode = enter.CustomerCode;
                    }
                    if (report.Status == 0 || report.Status == 2)
                    {
                        AllowEdit = true;
                    }
                    else
                    {
                        AllowEdit = false;
                    }
                    btnAddPlan.Visible = btnSaveEquipment.Visible = btnEditBasicInfo.Visible = btnSend.Visible = btn_edit2.Visible = AllowEdit;

                    txtAuditConsultant.Text = report.AuditConsultancyName;
                    txtAddress.Text = report.Address;
                    txtAuditor.Text = report.AuditorName;
                    txtAuditScope.Text = report.AuditingScope;
                    rbtShiftNo.SelectedValue = report.ShiftNo.ToString();
                    ddlAuditYear.SelectedValue = report.AuditYear.ToString();
                    ddlDataYear.SelectedValue = report.DataYear.ToString();
                    txtAuditorCode.Text = report.AuditorCode;
                    txtMST.Text = report.TaxNo;
                    if (report.PathFile != "")
                    {
                        lbtDownload.Text = report.PathFile;
                        lbtDownload.Visible = true;
                        ltAttach.Text = report.PathFile;
                    }
                    else
                    {
                        lbtDownload.Visible = false;
                        ltAttach.Text = "Chọn file đính kèm";
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

                    ucAuditDevice.ReportYear = report.AuditYear;
                    ucAuditDevice.AllowEdit = AllowEdit;
                    ucAuditDevice.ReportId = ReportId;

                    if (memVal.OrgId > 0 && report.EnterpriseId != memVal.OrgId)//Neu                     
                        Response.Redirect(ResolveUrl("~"));
                    AuditYearReport = report.AuditYear;
                    ltAuditYear.Text = AuditYearReport.ToString();
                    BindInfoLabel();
                }
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
    }
    void BindInfoLabel()
    {
        ltAuditYear.Text = ddlAuditYear.SelectedItem.Text;
        ltDataYear.Text = ddlDataYear.SelectedItem.Text;

        ltAuditUnit.Text = txtAuditConsultant.Text.Trim();
        ltAuditAddress.Text = txtAddress.Text.Trim();

        ltAuditor.Text = txtAuditor.Text;
        ltAuditScope.Text = txtAuditScope.Text;
        ltShiftNo1.Text = "";
        ltShiftNo2.Text = "";
        ltShiftNo3.Text = "";
        if (rbtShiftNo.SelectedIndex == 0)
            ltShiftNo1.Text = "X";
        else
        {
            if (rbtShiftNo.SelectedIndex == 1)
                ltShiftNo2.Text = "X";
            else
                ltShiftNo3.Text = "X";
        }

        ltAuditorCode.Text = txtAuditorCode.Text;
        ltTaxCode.Text = txtMST.Text.Trim();
    }

    #endregion

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
        if (e.CommandName.Equals("delete"))
        {
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            TestEquipmentService rptbso = new TestEquipmentService();
            if (rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument)) > 0)
            {
                BindEquipment();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Không xóa được. Vui lòng thử lại.');", true);
            }
        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            TestEquipment equip = new TestEquipment();
            TestEquipmentService rptbso = new TestEquipmentService();
            equip = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            hdnDetailId.Value = equip.Id.ToString();
            if (equip.Quantity > 0)
                txtQuantity.Text = equip.Quantity.ToString();
            //txtMeasurement.Text = equip.Measurement;
            txtEquipmentName.Text = equip.DeviceName;
            txtMadeIn.Text = equip.MadeIn;
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogEquipment();", true);
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
    protected void btnSaveEquipment_Click(object sender, EventArgs e)
    {
        TestEquipmentService testEquipmentService = new TestEquipmentService();
        TestEquipment testEquipment = new TestEquipment();
        testEquipment.AuditReportId = ReportId;
        testEquipment.DeviceName = txtEquipmentName.Text.Trim();
        testEquipment.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
        //testEquipment.Measurement = txtMeasurement.Text.Trim();
        testEquipment.MadeIn = txtMadeIn.Text.Trim();
        testEquipment.SerialNo = txtSerialNumber.Text.Trim();

        if (hdnDetailId.Value != "" && Convert.ToInt32(hdnDetailId.Value) > 0)
        {
            testEquipment.Id = Convert.ToInt32(hdnDetailId.Value);
            if (testEquipmentService.Update(testEquipment) != null)
            {
                BindEquipment();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogEquipment();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            }
        }
        else
        {
            int i = testEquipmentService.Insert(testEquipment);
            if (i > 0)
            {
                BindEquipment();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogAddEquipment();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Thêm mới kê hoạch không thành công. Vui lòng thử lại!');", true);
            }
        }
    }
    protected void btn_Send_Click(object sender, EventArgs e)
    {
        try
        {
            AuditReportService faqsBSO = new AuditReportService();

            if (ReportId > 0)
            {
                if (lbtDownload.Text == "" && !fAttachResend.HasFile)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "ShowDialogSend();alert('Vui lòng chọn file đính kèm.');", true);
                }
                else
                {
                    string strPath = Server.MapPath("~/UserFile/Report/");
                    if (fAttachResend.HasFile)
                    {
                        try
                        {
                            Random rand = new Random();
                            string strFilename = "";
                            strFilename = "BCKT_" + memVal.UserName + "_" + AuditYearReport + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttachResend.FileName).ToLower();
                            if (System.IO.File.Exists(strPath + strFilename))
                            {
                                strFilename = "BCKT_" + memVal.UserName + "_" + AuditYearReport + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttachResend.FileName).ToLower();
                            }
                            fAttachResend.PostedFile.SaveAs(strPath + strFilename);

                            ReportAttachFile reportAtt = new ReportAttachFile();
                            reportAtt.ReportId = ReportId;
                            reportAtt.PathFile = strFilename;
                            reportAtt.Created = DateTime.Now;
                            reportAtt.ActionName = "DN đã gửi báo cáo cho SCT";
                            reportAtt.Comment = txtContent.Text;
                            reportAtt.UserId = memVal.UserId;
                            reportAtt.UserName = memVal.UserName;
                            reportAtt.ReportType = Convert.ToInt32(LogType.AUDITREPORT);
                            new ReportAttachFileService().Insert(reportAtt);
                            if (faqsBSO.UpdateStatusFile(ReportId, 1, strFilename) > 0)
                            {
                                ReportLog log = new ReportLog();
                                log.ActionName = "DN đã gửi báo cáo cho SCT";
                                log.Comment = txtContent.Text;
                                log.ReportId = ReportId;
                                log.Created = DateTime.Now;
                                log.MemberId = memVal.UserId;
                                log.UserName = memVal.UserName;
                                log.Status = "Đã gửi báo cáo";
                                log.LogType = Convert.ToInt32(LogType.AUDITREPORT);
                                new ReportLogService().Insert(log);
                                Response.Redirect(ResolveUrl("~/Danh-sach-bao-cao-ktnl.aspx"));
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "ShowDialogSend();alert('Chưa gửi được báo cáo. Vui lòng kiểm tra lại.');", true);
                            }
                        }
                        catch (Exception ex) {
                            log.Error("Loi Attach file: ", ex);
                            ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "ShowDialogSend();alert('Chưa gửi được báo cáo. Vui lòng kiểm tra lại.');", true); return; 
                        }
                    }
                    else
                    {
                        if (faqsBSO.UpdateStatus(ReportId, 1) > 0)
                        {
                            Response.Redirect(ResolveUrl("~/Danh-sach-bao-cao-ktnl.aspx"));
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "ShowDialogSend();alert('Chưa gửi được báo cáo. Vui lòng kiểm tra lại.');", true);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }
    protected void btnEditInfo_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "showformInfo", "ShowDialogAuditReport();", true);
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {
            AuditReportService reportBSO = new AuditReportService();
            AuditReport report = new AuditReport();
            report = reportBSO.FindByKey(ReportId);
            if (report != null)
            {
                report.EnterpriseId = Convert.ToInt32(memVal.OrgId);
                report.AuditYear = Convert.ToInt32(ddlAuditYear.SelectedValue);
                report.DataYear = Convert.ToInt32(ddlDataYear.SelectedValue);
                report.AuditConsultancyName = txtAuditConsultant.Text.Trim();
                report.Address = txtAddress.Text.Trim();
                report.AuditorName = txtAuditor.Text.Trim();
                report.AuditingScope = txtAuditScope.Text.Trim();
                report.ShiftNo = Convert.ToInt32(rbtShiftNo.SelectedValue);
                report.AuditorCode = txtAuditorCode.Text.Trim();
                report.TaxNo = txtMST.Text.Trim();
                report.Id = ReportId;
                string strPath = Server.MapPath("~/UserFile/Report/");
                string strFilename = "";
                if (fAttach.HasFile)
                {
                    Random rand = new Random();
                    strFilename = memVal.UserName + "_BCKT_" + AuditYearReport + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttach.FileName).ToLower();
                    if (System.IO.File.Exists(strPath + strFilename))
                    {
                        strFilename = memVal.UserName + "_BCKT_" + AuditYearReport + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttach.FileName).ToLower();
                    }
                    fAttach.PostedFile.SaveAs(strPath + strFilename);
                    ReportAttachFile reportAtt = new ReportAttachFile();
                    reportAtt.ReportId = ReportId;
                    reportAtt.PathFile = strFilename;
                    reportAtt.Created = DateTime.Now;
                    reportAtt.ActionName = "DN đã gửi kèm file báo cáo";
                    reportAtt.Comment = txtContent.Text;
                    reportAtt.UserId = memVal.UserId;
                    reportAtt.UserName = memVal.UserName;
                    reportAtt.ReportType = Convert.ToInt32(LogType.AUDITREPORT);
                    new ReportAttachFileService().Insert(reportAtt);
                }
                report.PathFile = strFilename;
                if (reportBSO.Update(report) != null)
                {
                    clientview.Text = "<div class='alert alert-sm alert-success bg-gradient'>Cập nhật Thành công !</div>";
                    BindInfoLabel();
                    lbtDownload.Text = strFilename;
                    ltAttach.Text = strFilename;
                }
                else
                    clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật không Thành công !</div>";
            }
        }
        catch (Exception ex)
        {
            log.Error("Loi khong cap nhat duoc bao cao: ", ex);
        }
    }
}
