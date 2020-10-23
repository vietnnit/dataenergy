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


public partial class Client_Admin_DataEnergy_ViewReportDetailAnnual : System.Web.UI.UserControl
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
    decimal No_TOE
    {
        get
        {
            if (ViewState["No_TOE"] != null && ViewState["No_TOE"].ToString() != "")
                return (decimal)ViewState["No_TOE"];
            else
                return 0;
        }
        set { ViewState["No_TOE"] = value; }
    }
    decimal No_TOE_Future
    {
        get
        {
            if (ViewState["No_TOE_Future"] != null && ViewState["No_TOE_Future"].ToString() != "")
                return (decimal)ViewState["No_TOE_Future"];
            else
                return 0;
        }
        set { ViewState["No_TOE_Future"] = value; }
    }
    public int ReportYear
    {
        get
        {
            if (ViewState["ReportYear"] != null && ViewState["ReportYear"].ToString() != "")
                return (int)ViewState["ReportYear"];
            else
                return 0;
        }
        set { ViewState["ReportYear"] = value; }
    }
    public int EnterpriseId
    {
        get
        {
            if (ViewState["EnterpriseId"] != null && ViewState["EnterpriseId"].ToString() != "")
                return (int)ViewState["EnterpriseId"];
            else
                return 0;
        }
        set { ViewState["EnterpriseId"] = value; }
    }
    UserValidation memVal = new UserValidation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["dll"]))
                NavigationTitle(Request["dll"]);
            txtApprovedDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["Id"]))
                int.TryParse(Request["Id"].Replace(",", ""), out Id);
            ReportId = Id;
            BindData();

        }

    }

    private void NavigationTitle(string url)
    {
        ModulesBSO modulesBSO = new ModulesBSO();
        Modules modules = modulesBSO.GetModulesByUrl(url);
        litModules.Text = modules.ModulesName;
    }
    #region initControl

    private void BindData()
    {
        if (ReportId > 0)
        {
            try
            {
                ReportFuel report = new ReportFuel();
                ReportFuelService reportBSO = new ReportFuelService();
                report = reportBSO.FindByKey(ReportId);
                if (report != null)
                {
                    EnterpriseId = report.EnterpriseId;
                    if (report.SendSatus == 1)
                    {
                        //tam comment vao de ko bi chuyen trang thai bao cao
                        //reportBSO.UpdateStatusEnterprise(ReportId, 2);//Chuyen sang trang thai dang xu ly   
                        ReportLog log = new ReportLog();
                        log.ActionName = "Phê duyệt báo cáo";
                        log.Comment = txtmota.Text;
                        log.ReportId = ReportId;
                        log.Created = DateTime.Now;
                        log.MemberId = memVal.UserId;
                        log.UserName = memVal.UserName;
                        log.Status = "Đã tiếp nhận và đang thực hiện phê duyệt";
                        new ReportLogService().Insert(log);
                    }

                    if (report.ApprovedSatus)
                    {
                        btnExecutedApproved.Visible = false;
                        btnDelince.Visible = false;
                        btnExecutedApproved2.Visible = false;
                        btnDelince2.Visible = false;
                        lbtSendFeeback.Visible = false;
                    }
                    else
                    {
                        lbtSendFeeback.Visible = true;
                        if (report.SendSatus == 3)
                        {
                            btnExecutedApproved.Visible = false;
                            btnDelince.Visible = false;
                            btnExecutedApproved2.Visible = false;
                            btnDelince2.Visible = false;
                        }
                    }
                    ReportYear = report.Year;
                    //ucViewPlanOneYear.ReportId = ReportId;
                    //ucViewPlanOneYear.ReportYear = ReportYear;

                    //ucProduct.ReportId = ReportId;
                    //ucProduct.ReportYear = ReportYear;

                    //ucViewPlan5Year.ReportId = ReportId;
                    //ucViewPlan5Year.ReportYear = ReportYear;
                    ltEnterpriseName.Text = report.ReporterName;
                    if (report.OwnerId == 0)
                        ltOwner.Text = "";
                    else
                        ltOwner.Text = "";
                    ltDataCurrentTitle.Text = "1. Nhiên liệu tiêu thụ năm " + (report.Year - 1);
                    ltDataNextYearTitle.Text = "2. Nhiên liệu tiêu thụ dự kiến năm " + report.Year.ToString();
                    //BindReportDetail();
                    //BindReportDetailNext();
                    //ltReportYear.Text = ddlYear.SelectedItem.Text;
                    ltReportDate.Text = report.ReportDate.ToString("dd/MM/yyyy");
                    ltEnterpriseName.Text = report.CompanyName;
                    ltAreaName.Text = "------";
                    if (report.AreaId > 0)
                    {
                        Area area = new Area();
                        area = new AreaService().FindByKey(report.AreaId);
                        if (area != null)
                            ltAreaName.Text = area.AreaName;
                    }
                    ltSubAreaName.Text = "------";
                    if (report.SubAreaId > 0)
                    {
                        Area area = new Area();
                        area = new AreaService().FindByKey(report.SubAreaId);
                        if (area != null)
                            ltSubAreaName.Text = area.AreaName;
                    }
                    ltProvinceName.Text = "------";
                    if (report.ProviceId > 0)
                    {
                        Province area = new Province();
                        area = new ProvinceService().FindByKey(report.ProviceId);
                        if (area != null)
                            ltProvinceName.Text = area.ProvinceName;
                    }
                    ltDistrictName.Text = "------";
                    if (report.DistrictId > 0)
                    {
                        District area = new District();
                        area = new DistrictService().FindByKey(report.DistrictId);
                        if (area != null)
                            ltDistrictName.Text = area.DistrictName;
                    }
                    ltTaxNo.Text = report.TaxCode;
                    ltAddress.Text = report.Address;
                    ltEmail.Text = report.Email;
                    ltFaxNo.Text = report.Fax;
                    ltPhoneNumber.Text = report.Phone;
                    ltResponsible.Text = report.Responsible;
                    ltReporterName.Text = report.ReporterName;

                    ltParentName.Text = report.ParentName;
                    ltProvinceParent.Text = "------";
                    if (report.ProvinceParentId > 0)
                    {
                        Province area = new Province();
                        area = new ProvinceService().FindByKey(report.ProvinceParentId);
                        if (area != null)
                            ltProvinceParent.Text = area.ProvinceName;
                    }

                    //ltDistrictParent.Text = ddlDistrictReporter.SelectedItem.Text;
                    ltDistrictParent.Text = "------";
                    if (report.DistrictParentId > 0)
                    {
                        District area = new District();
                        area = new DistrictService().FindByKey(report.DistrictParentId);
                        if (area != null)
                            ltDistrictParent.Text = area.DistrictName;
                    }

                    ltEmailParent.Text = report.EmailParent;
                    ltFaxParent.Text = report.FaxParent;
                    ltAddressParent.Text = report.AddressParent;
                    ltPhoneParent.Text = report.PhoneParent;

                    BindReportDetail_11();
                    BindLog();
                    BindReportFile();
                }
            }
            catch (Exception ex)
            {
                //clientview.Text = ex.Message.ToString();
            }
        }

    }
    void BindLog()
    {
        IList<ReportLog> list = new List<ReportLog>();
        list = new ReportLogService().GetLogByReport(ReportId, Convert.ToInt32(LogType.ANNUALREPORT));
        rptLog.DataSource = list;
        rptLog.DataBind();
    }
    void BindReportFile()
    {
        IList<ReportAttachFile> list = new List<ReportAttachFile>();
        list = new ReportAttachFileService().GetFileByReport(ReportId, Convert.ToInt32(LogType.ANNUALREPORT));
        rptReportFile.DataSource = list;
        rptReportFile.DataBind();
    }
    void BindReportDetail()
    {
        DataTable dtCurrent = new ReportFuelDetailService().GetNoFuelDetailByReport(ReportId, false);
        rptNoFuelCurrent.DataSource = dtCurrent;
        rptNoFuelCurrent.DataBind();
        ltTotal_TOE.Text = "Tổng năng lượng tiêu thụ quy đổi ra TOE: <span style='color:red'>" + No_TOE + "</span>";
    }
    void BindReportDetailNext()
    {
        DataTable dtFuture = new ReportFuelDetailService().GetNoFuelDetailByReport(ReportId, true);
        rptNoFuelFuture.DataSource = dtFuture;
        rptNoFuelFuture.DataBind();
        ltTotal_TOE_Future.Text = "Tổng năng lượng tiêu thụ dự kiến quy đổi ra TOE: <span style='color:red'>" + No_TOE_Future + "</span>";
    }
    #endregion


    protected void btnApproved_Click(object sender, EventArgs e)
    {
        try
        {
            ReportFuelService faqsBSO = new ReportFuelService();
            if (rblApproved.SelectedIndex == 1)
            {
                ReportLog log = new ReportLog();
                log.ActionName = "Phê duyệt báo cáo";
                log.Comment = txtmota.Text;
                log.ReportId = ReportId;
                log.Created = DateTime.Now;
                log.MemberId = memVal.UserId;
                log.UserName = memVal.UserName;
                log.Status = "Yêu cầu bổ sung, hiệu chỉnh";
                log.LogType = Convert.ToInt32(LogType.ANNUALREPORT);
                new ReportLogService().Insert(log);
                if (faqsBSO.UpdateStatusEnterprise(ReportId, 3) > 0)
                {

                    if (fAttachApp.HasFile)
                    {
                        string strPath = Server.MapPath("~/UserFile/Report/");
                        try
                        {
                            string strFilename = "";
                            strFilename = memVal.UserName + "_" + ReportYear + "_" + new Random(10).Next(100) + System.IO.Path.GetExtension(fAttachApp.FileName).ToLower();
                            if (System.IO.File.Exists(strPath + strFilename))
                            {
                                strFilename = memVal.UserName + "_" + ReportYear + "_" + new Random(10).Next(100) + System.IO.Path.GetExtension(fAttachApp.FileName).ToLower();
                            }
                            fAttachApp.PostedFile.SaveAs(strPath + strFilename);

                            ReportAttachFile reportAtt = new ReportAttachFile();
                            reportAtt.ReportId = ReportId;
                            reportAtt.PathFile = strFilename;
                            reportAtt.Created = DateTime.Now;
                            reportAtt.ActionName = "SCT đã tải file báo cáo";
                            reportAtt.Comment = txtmota.Text;
                            reportAtt.UserName = memVal.UserName;
                            reportAtt.UserId = memVal.UserId;
                            reportAtt.ReportType = Convert.ToInt32(LogType.ANNUALREPORT);
                            if (new ReportAttachFileService().Insert(reportAtt) > 0)
                            {
                                BindReportFile();
                            }
                        }
                        catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "sendreport();", true); return; }
                    }
                    Response.Redirect(ResolveUrl("~") + "Admin/ListReportProcessing/Default.aspx");
                }


            }
            else
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                if (faqsBSO.ApproveReport(ReportId, DateTime.ParseExact(txtApprovedDate.Text, "dd/MM/yyyy", culture), (rblApproved.SelectedIndex == 0)) > 0)
                {
                    IList<GroupFuel> listGroupFuel = new List<GroupFuel>();
                    if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_GroupFuel_All))
                    {
                        listGroupFuel = new GroupFuelService().FindAll();
                        AspNetCache.SetCache(Constants.Cache_ReportFuel_GroupFuel_All, listGroupFuel);
                    }
                    else
                        listGroupFuel = (IList<GroupFuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_GroupFuel_All);

                    ReportFuelService comBSO = new ReportFuelService();
                    DataTable listDetail = new ReportFuelDetailService().GetTOEByReport(ReportId);
                    decimal SumTOE = 0;
                    decimal SumTOEP = 0;
                    if (listDetail != null && listDetail.Rows.Count > 0)
                    {
                        if (listDetail.Rows.Count > 2)
                        {
                            SumTOE = Convert.ToDecimal(listDetail.Rows[0]["NoFuel_TOE"]);
                            SumTOEP = Convert.ToDecimal(listDetail.Rows[1]["NoFuel_TOE"]);
                        }
                        else
                        {
                            if (Convert.ToBoolean(listDetail.Rows[0]["IsNextYear"]))
                                SumTOEP = Convert.ToDecimal(listDetail.Rows[0]["NoFuel_TOE"]);
                            else
                                SumTOE = Convert.ToDecimal(listDetail.Rows[0]["NoFuel_TOE"]);
                        }

                    }
                    EnterpriseYearService enterService = new EnterpriseYearService();
                    int i = enterService.UpdateTOE(EnterpriseId, ReportYear, ReportId, SumTOE, SumTOEP);
                    if (i == 0)
                    {
                        EnterpriseYear enterYear = new EnterpriseYear();
                        enterYear.IsKey = false;
                        enterYear.No_TOE = SumTOE;
                        enterYear.NoTOE_Plan = SumTOEP;
                        enterYear.Year = ReportYear;
                        enterYear.EnterpriseId = EnterpriseId;
                        enterYear.ReportId = ReportId;
                        enterService.Insert(enterYear);
                    }

                    ReportLog log = new ReportLog();
                    log.ActionName = "Phê duyệt báo cáo";
                    log.Comment = txtmota.Text;
                    log.ReportId = ReportId;
                    log.Created = DateTime.Now;
                    log.MemberId = memVal.UserId;
                    log.UserName = memVal.UserName;
                    log.Status = "Đã duyệt báo cáo";
                    log.LogType = Convert.ToInt32(LogType.ANNUALREPORT);
                    new ReportLogService().Insert(log);
                    Response.Redirect(ResolveUrl("~") + "Admin/ListReportProcessing/Default.aspx");
                }
                else
                {
                    //clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Xảy ra lỗi chưa phê duyệt được báo cáo. Vui lòng thử lại!</div>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "approvedReport();", true);
                }
            }
        }
        catch (Exception ex)
        {
            //clientview.Text = ex.Message.ToString();
        }
    }
    protected void btnDelince_Click(object sender, EventArgs e)
    {
        try
        {
            ReportFuelService faqsBSO = new ReportFuelService();
            ReportFuel faqs = faqsBSO.FindByKey(ReportId);
            faqs.ApprovedSatus = false;
            faqs.SendSatus = 2;
            faqs.AprovedDate = DateTime.Now;
            faqs.Id = ReportId;

            if (faqsBSO.Update(faqs) != null)
            {
                Response.Redirect(ResolveUrl("~") + "Admin/Admin/ListReportWaittingApproved/Default.aspx");
            }
            else
            {
                //clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Xảy ra lỗi chưa phê duyệt được báo cáo. Vui lòng thử lại!</div>";
                ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "approvedReport();", true);
            }
        }
        catch (Exception ex)
        {
            //clientview.Text = ex.Message.ToString();
        }
    }
    protected void rptNoFuelFuture_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item["NoFuel_TOE"] != DBNull.Value)
            {
                No_TOE_Future = No_TOE_Future + Convert.ToDecimal(item["NoFuel_TOE"]);
            }


            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");

        }
    }
    protected void rptNoFuelCurrent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item["NoFuel_TOE"] != DBNull.Value)
            {
                No_TOE = No_TOE + Convert.ToDecimal(item["NoFuel_TOE"]);
            }

            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",true); return false;");            

        }
    }
    protected void btnSaveFeedback_Click(object sender, EventArgs e)
    {
        ReportLog log = new ReportLog();
        log.ActionName = "DN gửi ý kiến";
        log.Comment = txtFeedback.Text;
        log.ReportId = ReportId;
        log.Created = DateTime.Now;
        log.MemberId = memVal.UserId;
        log.UserName = memVal.UserName;
        log.Status = "Gửi ý kiến";
        log.LogType = Convert.ToInt32(LogType.ANNUALREPORT);
        if (new ReportLogService().Insert(log) > 0)
        {
            if (fAttachFeedback.HasFile)
            {
                string strPath = Server.MapPath("~/UserFile/Report/");
                try
                {
                    string strFilename = "";
                    strFilename = memVal.UserName + "_" + ReportYear + "_" + new Random(10).Next(100) + System.IO.Path.GetExtension(fAttachFeedback.FileName).ToLower();
                    if (System.IO.File.Exists(strPath + strFilename))
                    {
                        strFilename = memVal.UserName + "_" + ReportYear + "_" + new Random(10).Next(100) + System.IO.Path.GetExtension(fAttachFeedback.FileName).ToLower();
                    }
                    fAttachFeedback.PostedFile.SaveAs(strPath + strFilename);

                    ReportAttachFile reportAtt = new ReportAttachFile();
                    reportAtt.ReportId = ReportId;
                    reportAtt.PathFile = strFilename;
                    reportAtt.Created = DateTime.Now;
                    reportAtt.ActionName = "SCT đã tải file báo cáo";
                    reportAtt.Comment = txtFeedback.Text;
                    reportAtt.UserName = memVal.UserName;
                    reportAtt.UserId = memVal.UserId;
                    reportAtt.ReportType = Convert.ToInt32(LogType.ANNUALREPORT);
                    if (new ReportAttachFileService().Insert(reportAtt) > 0)
                    {
                        BindReportFile();
                    }
                }
                catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "sendreport();", true); return; }
            }
            BindLog();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "sendFeedback", "ShowDialogFeedback();aler('Gửi không thành công, vui lòng thử lại.')", true);
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        #region get data
        WordExtend ex = new WordExtend();
        string temp = "TempReport/TemMauBaoCao" + drpmaubaocao.SelectedValue + ".doc";
        ex.OpenFile(Server.MapPath(ResolveUrl("~") + temp));
        Enterprise or = new Enterprise();
        EnterpriseService orser = new EnterpriseService();
        or = orser.FindByKey(Convert.ToInt32(memVal.OrgId));

        DataTable dtinfo = new DataTable();
        ex.WriteToMergeField("BC_MaDN", "");
        if (memVal.OrgId > 0)
        {
            dtinfo = new ReportFuelService().GetInfoReportFuel(ReportId);
        }

        if (or != null)
        {
            ex.WriteToMergeField("BC_Title", or.Title);
            ex.WriteToMergeField("BC_TenCoSo", or.Title);
            ex.WriteToMergeField("BC_TenCoSo1", or.Title);
            ex.WriteToMergeField("BC_TenCoSo2", or.Title);
        }
        else
            ex.WriteToMergeField("BC_TenCoSo", "");
        if (dtinfo.Rows[0]["Year"] != DBNull.Value)
        {
            string NextYear = (Convert.ToInt32(dtinfo.Rows[0]["Year"]) + 1).ToString();
            ex.WriteToMergeField("BC_NextYear", NextYear);
            ex.WriteToMergeField("BC_NextYear1", NextYear);
            ex.WriteToMergeField("BC_NextYear2", NextYear);
            ex.WriteToMergeField("BC_Year", dtinfo.Rows[0]["Year"].ToString());
            ex.WriteToMergeField("BC_Year1", dtinfo.Rows[0]["Year"].ToString());
        }
        if (dtinfo.Rows[0]["Responsible"] != DBNull.Value)
        {
            ex.WriteToMergeField("BC_ChiuTrachNhiem", dtinfo.Rows[0]["Responsible"].ToString());
        }
        else
            ex.WriteToMergeField("BC_ChiuTrachNhiem", "");

        if (dtinfo.Rows[0]["ReportDate"] != DBNull.Value)
        {
            ex.WriteToMergeField("BC_NgayLap", Convert.ToDateTime(dtinfo.Rows[0]["ReportDate"]).ToString("dd/MM/yyyy"));
            ex.WriteToMergeField("BC_NgayBC", Convert.ToDateTime(dtinfo.Rows[0]["ReportDate"]).ToString("dd/MM/yyyy"));
        }
        if (dtinfo.Rows[0]["ReceivedDate"] != DBNull.Value)
            ex.WriteToMergeField("BC_NgayNhan", Convert.ToDateTime(dtinfo.Rows[0]["ReceivedDate"]).ToString("dd/MM/yyyy"));
        else
            ex.WriteToMergeField("BC_NgayNhan", "");
        if (dtinfo.Rows[0]["ConfirmedDate"] != DBNull.Value)
            ex.WriteToMergeField("BC_NgayXacNhan", Convert.ToDateTime(dtinfo.Rows[0]["ConfirmedDate"]).ToString("dd/MM/yyyy"));
        else
            ex.WriteToMergeField("BC_NgayXacNhan", "");
        if (dtinfo.Rows[0]["SubAreaName"] != DBNull.Value)
            ex.WriteToMergeField("BC_PhanNganh", dtinfo.Rows[0]["SubAreaName"].ToString());
        else
            ex.WriteToMergeField("BC_PhanNganh", "");

        if (dtinfo.Rows[0]["TaxCode"] != DBNull.Value)
            ex.WriteToMergeField("BC_TaxCode", dtinfo.Rows[0]["TaxCode"].ToString());
        else
            ex.WriteToMergeField("BC_TaxCode", "");

        ex.WriteToMergeField("BC_Owner", ltOwner.Text);

        if (or.Address != null)
            ex.WriteToMergeField("BC_DiaChi", or.Address);
        if (dtinfo.Rows[0]["DistrictName"] != DBNull.Value)
            ex.WriteToMergeField("BC_Huyen", dtinfo.Rows[0]["DistrictName"].ToString());
        else
            ex.WriteToMergeField("BC_Huyen", "");
        if (dtinfo.Rows[0]["ProvinceName"] != DBNull.Value)
            ex.WriteToMergeField("BC_Tinh", dtinfo.Rows[0]["ProvinceName"].ToString());
        else
            ex.WriteToMergeField("BC_Tinh", "");
        if (dtinfo.Rows[0]["ReporterName"] != DBNull.Value)
            ex.WriteToMergeField("BC_NguoiBC", dtinfo.Rows[0]["ReporterName"].ToString());
        else
            ex.WriteToMergeField("BC_NguoiBC", "");

        if (dtinfo.Rows[0]["Fax"] != DBNull.Value)
            ex.WriteToMergeField("BC_Fax", dtinfo.Rows[0]["Fax"].ToString());
        else
            ex.WriteToMergeField("BC_Fax", "");
        if (dtinfo.Rows[0]["Email"] != DBNull.Value)
            ex.WriteToMergeField("BC_Email", dtinfo.Rows[0]["Email"].ToString());
        else
            ex.WriteToMergeField("BC_Email", "");

        if (dtinfo.Rows[0]["Phone"] != DBNull.Value)
            ex.WriteToMergeField("BC_DienThoai", dtinfo.Rows[0]["Phone"].ToString());
        else
            ex.WriteToMergeField("BC_DienThoai", "");
        if (dtinfo.Rows[0]["ParentName"] != DBNull.Value)
            ex.WriteToMergeField("BC_TenCtyMe", dtinfo.Rows[0]["ParentName"].ToString());
        else
            ex.WriteToMergeField("BC_TenCtyMe", "");

        if (dtinfo.Rows[0]["AddressParent"] != null)
            ex.WriteToMergeField("BC_DiaChiP", dtinfo.Rows[0]["AddressParent"].ToString());
        else
            ex.WriteToMergeField("BC_DiaChiP", "");

        if (dtinfo.Rows[0]["DistrictNameP"] != null)
            ex.WriteToMergeField("BC_HuyenP", dtinfo.Rows[0]["DistrictNameP"].ToString());
        else
            ex.WriteToMergeField("BC_HuyenP", "");

        if (dtinfo.Rows[0]["ProvinceNameP"] != DBNull.Value)
            ex.WriteToMergeField("BC_TinhP", dtinfo.Rows[0]["ProvinceNameP"].ToString());
        else
            ex.WriteToMergeField("BC_TinhP", "");

        if (dtinfo.Rows[0]["PhoneParent"] != DBNull.Value)
            ex.WriteToMergeField("BC_DienThoaiP", dtinfo.Rows[0]["PhoneParent"].ToString());
        else
            ex.WriteToMergeField("BC_DienThoaiP", "");

        if (dtinfo.Rows[0]["FaxParent"] != DBNull.Value)
            ex.WriteToMergeField("BC_FaxP", dtinfo.Rows[0]["FaxParent"].ToString());
        else
            ex.WriteToMergeField("BC_FaxP", "");
        if (dtinfo.Rows[0]["EmailParent"] != DBNull.Value)
            ex.WriteToMergeField("BC_EmailP", dtinfo.Rows[0]["EmailParent"].ToString());
        else
            ex.WriteToMergeField("BC_EmailP", "");

        if (or.ActiveYear > 0)
            ex.WriteToMergeField("ActiveYear", or.ActiveYear.ToString());
        else
            ex.WriteToMergeField("ActiveYear", "");

        Infrastructure infra = new Infrastructure();
        InfrastructureService infraService = new InfrastructureService();

        infra = infraService.GetInfrastructureByReport(ReportId);
        if (infra != null)
        {
            if (infra.ProduceAreaNo > 0)
                ex.WriteToMergeField("ProduceAreaNo", infra.ProduceAreaNo.ToString());
            else
                ex.WriteToMergeField("ProduceAreaNo", "");
            if (infra.OfficeAreaNo > 0)
                ex.WriteToMergeField("OfficeAreaNo", infra.OfficeAreaNo.ToString());
            else
                ex.WriteToMergeField("OfficeAreaNo", "");
            if (infra.ProduceEmployeeNo > 0)
                ex.WriteToMergeField("ProduceEmployeeNo", infra.ProduceEmployeeNo.ToString());
            else
                ex.WriteToMergeField("ProduceEmployeeNo", "");
            if (infra.OfficeEmployeeNo > 0)
                ex.WriteToMergeField("OfficeEmployeeNo", infra.OfficeEmployeeNo.ToString());
            else
                ex.WriteToMergeField("OfficeEmployeeNo", "");
        }
        else
        {
            ex.WriteToMergeField("ProduceAreaNo", "");
            ex.WriteToMergeField("OfficeAreaNo", "");
            ex.WriteToMergeField("ProduceEmployeeNo", "");
            ex.WriteToMergeField("OfficeEmployeeNo", "");
        }


        UsingElectrict usingElectrict = new UsingElectrict();
        UsingElectrictService usingElectrictService = new UsingElectrictService();

        usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, false);
        if (usingElectrict != null)
        {
            //Su dung dien 2
            if (usingElectrict.Quantity > 0)
                ex.WriteToMergeField("QuantityResult2", usingElectrict.Quantity.ToString());
            else
                ex.WriteToMergeField("QuantityResult2", "");
            if (usingElectrict.InstalledCapacity > 0)
                ex.WriteToMergeField("InstalledCapacityResult2", usingElectrict.InstalledCapacity.ToString());
            else
                ex.WriteToMergeField("InstalledCapacityResult2", "");
            if (usingElectrict.Capacity > 0)
                ex.WriteToMergeField("CapacityResult2", usingElectrict.Capacity.ToString());
            else
                ex.WriteToMergeField("CapacityResult2", "");
            if (usingElectrict.BuyCost > 0)
                ex.WriteToMergeField("BuyCostResult2", usingElectrict.BuyCost.ToString());
            else
                ex.WriteToMergeField("BuyCostResult2", "");
            if (usingElectrict.BuyCost > 0 && usingElectrict.Capacity > 0)
                ex.WriteToMergeField("BuyPriceResult2", Math.Round((usingElectrict.BuyCost / (usingElectrict.Capacity * 1000)), 0).ToString());
            else
                ex.WriteToMergeField("BuyPriceResult2", "");
            if (usingElectrict.ProduceQty > 0)
                ex.WriteToMergeField("ProduceQtyResult2", usingElectrict.ProduceQty.ToString());
            else
                ex.WriteToMergeField("ProduceQtyResult2", "");
            if (usingElectrict.Technology != null)
                ex.WriteToMergeField("TechnologyResult2", usingElectrict.Technology.ToString());
            else
                ex.WriteToMergeField("TechnologyResult2", "");
            if (usingElectrict.FuelId > 0)
            {

                Fuel fuel = new Fuel();

                fuel = new FuelService().FindByKey(usingElectrict.FuelId);
                if (fuel != null)
                {
                    ex.WriteToMergeField("FuelNameResult2", fuel.FuelName);
                    ex.WriteToMergeField("FuelNameResult", fuel.FuelName);
                }
                else
                {
                    ex.WriteToMergeField("FuelNameResult2", "");
                    ex.WriteToMergeField("FuelNameResult", "");
                }
            }
            else
            {
                ex.WriteToMergeField("FuelNameResult2", "");
                ex.WriteToMergeField("FuelNameResult", "");
            }
            if (usingElectrict.PriceProduce > 0)
                ex.WriteToMergeField("PriceProduceResult2", usingElectrict.PriceProduce.ToString());
            else
                ex.WriteToMergeField("PriceProduceResult2", "");


            //Su dung dien 1
            if (usingElectrict.Quantity > 0)
                ex.WriteToMergeField("QuantityResult", usingElectrict.Quantity.ToString());
            else
                ex.WriteToMergeField("QuantityResult", "");
            if (usingElectrict.InstalledCapacity > 0)
                ex.WriteToMergeField("InstalledCapacityResult", usingElectrict.InstalledCapacity.ToString());
            else
                ex.WriteToMergeField("InstalledCapacityResult", "");
            if (usingElectrict.Capacity > 0)
                ex.WriteToMergeField("CapacityResult", usingElectrict.Capacity.ToString());
            else
                ex.WriteToMergeField("CapacityResult", "");
            if (usingElectrict.BuyCost > 0)
                ex.WriteToMergeField("BuyCostResult", usingElectrict.BuyCost.ToString());
            else
                ex.WriteToMergeField("BuyCostResult", "");
            if (usingElectrict.BuyCost > 0 && usingElectrict.Capacity > 0)
                ex.WriteToMergeField("BuyPriceResult", Math.Round((usingElectrict.BuyCost / (usingElectrict.Capacity * 1000)), 0).ToString());
            else
                ex.WriteToMergeField("BuyPriceResult", "");
            if (usingElectrict.ProduceQty > 0)
                ex.WriteToMergeField("ProduceQtyResult", usingElectrict.ProduceQty.ToString());
            else
                ex.WriteToMergeField("ProduceQtyResult", "");
            if (usingElectrict.Technology != null)
                ex.WriteToMergeField("TechnologyResult", usingElectrict.Technology.ToString());
            else
                ex.WriteToMergeField("TechnologyResult", "");
            if (usingElectrict.FuelId > 0)
                ex.WriteToMergeField("FuelNameResult", usingElectrict.FuelId.ToString());
            else
                ex.WriteToMergeField("FuelNameResult", "");
        }
        else
        {
            ex.WriteToMergeField("QuantityResult2", "");
            ex.WriteToMergeField("InstalledCapacityResult2", "");
            ex.WriteToMergeField("CapacityResult2", "");
            ex.WriteToMergeField("BuyCostResult2", "");
            ex.WriteToMergeField("ProduceQtyResult2", "");
            ex.WriteToMergeField("TechnologyResult2", "");
            ex.WriteToMergeField("FuelNameResult2", "");
            ex.WriteToMergeField("PriceProduceResult2", "");


            ex.WriteToMergeField("QuantityResult", "");
            ex.WriteToMergeField("InstalledCapacityResult", "");
            ex.WriteToMergeField("CapacityResult", "");
            ex.WriteToMergeField("BuyCostResult", "");
            ex.WriteToMergeField("ProduceQtyResult", "");
            ex.WriteToMergeField("TechnologyResult", "");
            ex.WriteToMergeField("FuelNameResult", "");
        }


        usingElectrict = new UsingElectrict();

        usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, true);
        if (usingElectrict != null)
        {
            //Su dung dien 2
            if (usingElectrict.Quantity > 0)
                ex.WriteToMergeField("QuantityPlan", usingElectrict.Quantity.ToString());
            else
                ex.WriteToMergeField("QuantityPlan", "");
            if (usingElectrict.InstalledCapacity > 0)
                ex.WriteToMergeField("InstalledCapacityPlan", usingElectrict.InstalledCapacity.ToString());
            else
                ex.WriteToMergeField("InstalledCapacityPlan", "");
            if (usingElectrict.Capacity > 0)
                ex.WriteToMergeField("CapacityPlan", usingElectrict.Capacity.ToString());
            else
                ex.WriteToMergeField("CapacityPlan", "");
            if (usingElectrict.BuyCost > 0)
                ex.WriteToMergeField("BuyCostPlan", usingElectrict.BuyCost.ToString());
            else
                ex.WriteToMergeField("BuyCostPlan", "");

            if (usingElectrict.BuyCost > 0)
                ex.WriteToMergeField("BuyPricePlan", usingElectrict.BuyCost.ToString());
            else
                ex.WriteToMergeField("BuyPricePlan", "");

            if (usingElectrict.ProduceQty > 0)
                ex.WriteToMergeField("ProduceQtyPlan", usingElectrict.ProduceQty.ToString());
            else
                ex.WriteToMergeField("ProduceQtyPlan", "");
            if (usingElectrict.Technology != null)
                ex.WriteToMergeField("TechnologyPlan", usingElectrict.Technology.ToString());
            else
                ex.WriteToMergeField("TechnologyPlan", "");
            if (usingElectrict.FuelId > 0)
            {
                Fuel fuel = new Fuel();

                fuel = new FuelService().FindByKey(usingElectrict.FuelId);
                if (fuel != null)
                {
                    ex.WriteToMergeField("FuelNamePlan", fuel.FuelName);

                }
                else
                {
                    ex.WriteToMergeField("FuelNamePlan", "");

                }
            }
            else
            {
                ex.WriteToMergeField("FuelNamePlan", "");
            }
            if (usingElectrict.PriceProduce > 0)
                ex.WriteToMergeField("PriceProducePlan", usingElectrict.PriceProduce.ToString());
            else
                ex.WriteToMergeField("PriceProducePlan", "");
        }
        else
        {
            ex.WriteToMergeField("QuantityPlan", "");
            ex.WriteToMergeField("InstalledCapacityPlan", "");
            ex.WriteToMergeField("CapacityPlan", "");
            ex.WriteToMergeField("BuyCostPlan", "");
            ex.WriteToMergeField("ProduceQtyPlan", "");
            ex.WriteToMergeField("TechnologyPlan", "");
            ex.WriteToMergeField("FuelNamePlan", "");
            ex.WriteToMergeField("PriceProducePlan", "");
        }

        DataTable dthientai = new DataTable();
        DataTable dtdukien = new DataTable();

        DataSet dshientai = new DataSet("tbl1");

        DataTable dt = new DataTable();

        dt = new ReportFuelDetailService().GetNoFuelDetailByReport(ReportId, false);

        dt.Columns.Add("dvnhietnang", typeof(string));
        dt.Columns.Add("dvnhieulieu", typeof(string));
        dthientai = dt.Clone();
        foreach (DataRow item in dt.Rows)
        {

            DataRow workRow = null;
            workRow = dthientai.NewRow();
            workRow = item;
            if (workRow["MeasurementName"].ToString().Contains("Mét khối"))
            {
                workRow["dvnhietnang"] = "kJ/m3";
            }
            else
            {
                workRow["dvnhietnang"] = "kJ/kg";
            }
            if (workRow["MeasurementName"].ToString().Contains("tấn") || workRow["MeasurementName"].ToString().Contains("Klg"))
            {
                workRow["dvnhieulieu"] = "kJ/tấn";
            }
            else
            {
                workRow["dvnhieulieu"] = "đ/m3";
            }
            workRow.AcceptChanges();
            dthientai.AcceptChanges();
            dthientai.ImportRow(workRow);
        }
        dt = new ReportFuelDetailService().GetNoFuelDetailByReport(ReportId, true);
        dt.Columns.Add("dvnhietnang", typeof(string));
        dt.Columns.Add("dvnhieulieu", typeof(string));
        dtdukien = dt.Clone();
        foreach (DataRow item in dt.Rows)
        {

            DataRow workRow = null;
            workRow = dtdukien.NewRow();
            workRow = item;
            if (workRow["MeasurementName"].ToString().Contains("Mét khối"))
            {
                workRow["dvnhietnang"] = "kJ/m3";
            }
            else
            {
                workRow["dvnhietnang"] = "kJ/kg";
            }
            if (workRow["MeasurementName"].ToString().Contains("tấn") || workRow["MeasurementName"].ToString().Contains("Klg"))
            {
                workRow["dvnhieulieu"] = "kJ/tấn";
            }
            else
            {
                workRow["dvnhieulieu"] = "đ/m3";
            }
            workRow.AcceptChanges();
            dtdukien.ImportRow(workRow);
            dtdukien.AcceptChanges();

        }
        ProductCapacityService productCapacityService = new ProductCapacityService();
        DataTable tblProductResult = new DataTable();
        tblProductResult = productCapacityService.GetDataCapacity(ReportId, false);
        dshientai.Merge(tblProductResult);
        dshientai.Tables[0].TableName = "tbl1";

        dshientai.Merge(dthientai);

        dshientai.Tables[1].TableName = "tbl2";
        //ex.WriteDataSetToMergeField(dshientai);

        DataTable tblProductPlan = new DataTable();
        tblProductPlan = productCapacityService.GetDataCapacity(ReportId, true);
        dshientai.Merge(tblProductPlan);
        dshientai.Tables[2].TableName = "tbl3";

        dshientai.Merge(dtdukien);
        dshientai.Tables[3].TableName = "tbl4";
        //ex.WriteDataSetToMergeField(dshientai);


        DataSet dsData = new DataSet();
        PlanTBService plangpservice = new PlanTBService();
        PlanTKNLService plangTKNLservice = new PlanTKNLService();
        DataTable tblGPTKNLPlan = new DataTable();
        tblGPTKNLPlan = plangTKNLservice.GetPlanTKNLEnerprise(Convert.ToInt32(memVal.OrgId), ReportId, false, true);
        dshientai.Merge(tblGPTKNLPlan);
        dshientai.Tables[4].TableName = "tbl5";

        DataTable tblTBPlan = new DataTable();
        tblTBPlan = plangpservice.GetPlanTBEnterprise(memVal.OrgId, ReportId, false, true);
        dshientai.Merge(tblTBPlan);
        dshientai.Tables[5].TableName = "tbl6";

        dshientai.Merge(tblProductPlan.Copy());
        dshientai.Tables[6].TableName = "tbl7";

        dshientai.Merge(dthientai.Copy());
        dshientai.Tables[7].TableName = "tbl8";

        DataTable tblGPTKNLResult = new DataTable();
        tblGPTKNLResult = plangTKNLservice.GetPlanTKNLEnerprise(Convert.ToInt32(memVal.OrgId), ReportId, false, false);
        dshientai.Merge(tblGPTKNLResult);
        dshientai.Tables[8].TableName = "tbl9";
        DataTable tblTBResult = new DataTable();
        tblTBResult = plangpservice.GetPlanTBEnterprise(memVal.OrgId, ReportId, false, false);
        dshientai.Merge(tblTBResult);
        dshientai.Tables[9].TableName = "tbl10";

        dshientai.Tables.Add(tblTBResult.Copy());
        dshientai.Tables[10].TableName = "tbl11";

        ex.WriteDataSetToMergeField(dshientai);
        // dsg.Tables.Add(dst); 
        //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
        #endregion
        ex.Save(Server.MapPath(ResolveUrl("~") + "TempReport/" + memVal.UserName + ".Bao-cao-hang-nam-" + dtinfo.Rows[0]["Year"] + ".doc"));
        HttpContext.Current.Response.Redirect(string.Format("~/Download.aspx?fp={0}&fn={1}",
              System.IO.Path.GetFileName(Server.MapPath(ResolveUrl("~") + "TempReport/" + memVal.UserName + ".Bao-cao-hang-nam-" + dtinfo.Rows[0]["Year"] + ".doc")),
              ""
          ));
    }
    protected void lbtDownload_Click(object sender, EventArgs e)
    {
        LinkButton btnDownload = (LinkButton)sender;
        if (btnDownload != null && btnDownload.CommandArgument != null && btnDownload.CommandArgument != "")
        {
            int ReportFileId = Convert.ToInt32(btnDownload.CommandArgument);
            if (ReportFileId > 0)
            {
                ReportAttachFile reportAt = new ReportAttachFileService().FindByKey(ReportFileId);
                if (reportAt != null && reportAt.PathFile != "")
                {
                    string Filpath = Server.MapPath("~/UserFile/Report/" + reportAt.PathFile);
                    DownLoad(Filpath);
                }
            }
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

    #region Report 1.1
    void BindReportDetail_11()
    {
        DataTable dtCurrent = new ReportFuelDetailService().GetNoFuelDetailByReport(ReportId, false);
        rptNoFuelCurrent_11.DataSource = dtCurrent;
        rptNoFuelCurrent_11.DataBind();
        ltTotal_TOE.Text = "Tổng năng lượng tiêu thụ quy đổi ra TOE: <span style='color:red'>" + Tool.ConvertDecimalToString(No_TOE, 2) + "</span>";
    }
    protected void rptNoFuelCurrent_11_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemIndex == 0) No_TOE = 0;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            HiddenField hdDenotation = (HiddenField)e.Item.FindControl("hdDenotation");
            int _denotation = Convert.ToInt32(hdDenotation.Value);
            if (item["NoFuel_TOE"] != DBNull.Value)
            {
                //No_TOE = No_TOE + Convert.ToDecimal(item["NoFuel_TOE"]);
                No_TOE = No_TOE + Convert.ToDecimal(item["NoFuel_TOE"]) * _denotation;
            }

            //LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            //LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");

            //btnDelete.Visible = false;
            //btnEdit.Visible = false;
        }
    }
    #endregion
}
