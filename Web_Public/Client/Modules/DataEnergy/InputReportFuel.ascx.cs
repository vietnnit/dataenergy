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
using ReportEF;

public partial class Client_Modules_DataEnergy_InputReportFuel : System.Web.UI.UserControl
{
    string specifier = "0";
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtReportDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["ReportId"]))
                int.TryParse(Request["ReportId"].Replace(",", ""), out Id);
            ReportId = Id;

            int activeId = 0;
            if (!string.IsNullOrEmpty(Request["activetab"]))
                int.TryParse(Request["activetab"].Replace(",", ""), out activeId);
            activeTab = activeId;
            Tool.BindYear(ddlYear, "Chọn năm", "");
            BindArea();
            BindSubArea();
            BindProvince();
            BindDistrict();
            BindDistrictReporter();
            BindEnterprise();
            BindReportInfo();
            BindLog();
            BindReportFile();
        }

    }

    #region initControl

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
    void BindSubArea()
    {
        try
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
        catch { }
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
        if (ReportId <= 0)
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
                    txtMST.Text = enter.TaxCode;
                    txtAddress.Text = enter.Address;
                    txtEmail.Text = enter.Email;
                    txtFax.Text = enter.Fax;
                    txtPhone.Text = enter.Phone;

                    txtReportName.Text = enter.ManPerson;
                    if (enter.ManProvinceId > 0)
                        ddlProvinceReporter.SelectedValue = enter.ManProvinceId.ToString();
                    if (enter.ManDistrictId > 0)
                        ddlDistrictReporter.SelectedValue = enter.ManDistrictId.ToString();
                    txtParentName.Text = enter.ParentName;
                    txtAddressReporter.Text = enter.ManAddress;
                    txtEmailReporter.Text = enter.ManEmail;
                    txtFaxReporter.Text = enter.ManFax;
                    txtPhoneReporter.Text = enter.ManPhone;

                }
            }
        }
    }
    private void BindReportInfo()
    {
        if (ReportId > 0)
        {
            btn_edit2.Visible = true;
            AllowEdit = true;
            try
            {
                ReportFuel report = new ReportFuel();
                ReportFuelService reportBSO = new ReportFuelService();
                report = reportBSO.FindByKey(ReportId);
                if (report != null)
                {
                    if (report.ApprovedSatus)
                    {
                        lbtSendFeeback.Visible = false;
                        btnEditBasicInfo.Visible = false;
                        btnSend.Visible = false;
                        btnReSend.Visible = false;
                        btnSaveResend.Visible = false;
                        btnSaveSend.Visible = false;
                        btn_edit2.Visible = false;
                        AllowEdit = false;
                    }
                    else
                    {
                        lbtSendFeeback.Visible = true;
                        if (report.SendSatus == 5 || report.SendSatus == 1 || report.SendSatus == 2 || report.SendSatus == 4)
                        {
                            btnEditBasicInfo.Visible = false;
                            btnSend.Visible = false;
                            btnReSend.Visible = false;
                            btnSaveResend.Visible = false;
                            btnSaveSend.Visible = false;
                            btn_edit2.Visible = false;
                            AllowEdit = false;
                        }
                        else
                        {
                            if (report.SendSatus == 0)
                            {
                                btnEditBasicInfo.Visible = true;
                                btnSend.Visible = true;
                                btnSaveSend.Visible = true;
                                btnReSend.Visible = false;
                                btnSaveResend.Visible = false;

                            }
                            else
                            {
                                btnEditBasicInfo.Visible = true;
                                btnSend.Visible = false;
                                btnSaveSend.Visible = false;
                                btnReSend.Visible = true;
                                btnSaveResend.Visible = true;
                            }
                        }
                    }

                    if (memVal.OrgId > 0 && report.EnterpriseId != Convert.ToInt32(memVal.OrgId))//Neu                     
                        Response.Redirect(ResolveUrl("~"));
                    ReportYear = report.Year;
                    txtReportName.Text = report.ReporterName;
                    if (report.SendDate != null && report.SendDate.Year > 1)
                        txtReportDate.Text = String.Format("{0:dd/MM/yyyy}", report.SendDate);//DateTime.Parse(faqs.PostDate.ToString()).ToString("dd/MM/yyyy hh:mm", ci); // faqs.PostDate.ToString();               

                    txtEnterpriseName.Text = report.CompanyName;
                    txtResponsible.Text = report.Responsible;
                    txtMST.Text = report.TaxCode;
                    if (report.ProvinceParentId > 0)
                    {
                        ddlProvinceReporter.SelectedValue = report.ProvinceParentId.ToString();
                        BindDistrictReporter();
                    }
                    if (report.DistrictParentId > 0)
                    {
                        ddlDistrictReporter.SelectedValue = report.DistrictParentId.ToString();
                    }
                    if (report.AreaId > 0)
                    {
                        ddlArea.SelectedValue = report.AreaId.ToString();
                        BindSubArea();
                    }
                    if (report.SubAreaId > 0)
                        ddlSubArea.SelectedValue = report.SubAreaId.ToString();
                    if (report.ProviceId > 0)
                    {
                        ddlProvince.SelectedValue = report.ProviceId.ToString();
                        BindDistrict();
                    }
                    if (report.DistrictId > 0)
                        ddlDistrict.SelectedValue = report.DistrictId.ToString();
                    txtFax.Text = report.Fax;
                    if (report.Address != null && report.Address.Trim() != "")
                        txtAddress.Text = report.Address;
                    if (report.ReporterName != null && report.ReporterName.Trim() != "")
                        txtReportName.Text = report.ReporterName;
                    if (report.Email != null && report.Email.Trim() != "")
                        txtEmail.Text = report.Email;
                    if (report.Phone != null && report.Phone.Trim() != "")
                        txtPhone.Text = report.Phone;

                    if (report.ParentName != null && report.ParentName.Trim() != "")
                        txtParentName.Text = report.ParentName;
                    if (report.AddressParent != null && report.AddressParent.Trim() != "")
                        txtAddressReporter.Text = report.AddressParent;
                    if (report.FaxParent != null && report.FaxParent.Trim() != "")
                        txtFaxReporter.Text = report.FaxParent;
                    if (report.PhoneParent != null && report.PhoneParent.Trim() != "")
                        txtPhoneReporter.Text = report.PhoneParent;
                    txtEmailReporter.Text = report.EmailParent;
                    if (report.OwnerId > 0)
                        ddlOwner.SelectedValue = report.OwnerId.ToString();

                    if (report.Year > 0)
                        ddlYear.SelectedValue = report.Year.ToString();
                    //if (report.OwnerId != null)
                    //{
                    if (report.OwnerId == 0)
                        ltOwner.Text = "Thành phần kinh tế khác";
                    else
                        ltOwner.Text = "Doanh nghiệp nhà nước";
                    //}
                    ReportModels reportModels = new ReportModels();
                    var deEnterprise = reportModels.DE_Enterprise.FirstOrDefault(o => o.Id == report.EnterpriseId);
                    int _MoHinhQLNL = deEnterprise.MoHinhQLNL.Value;
                    switch (_MoHinhQLNL)
                    {
                        case 0:
                            cbMoHinhQLNL_ChuaAD.Checked = true;
                            break;
                        case 1:
                            cbMoHinhQLNL_DaAD.Checked = true;
                            break;
                        case 2:
                            cbMoHinhQLNL_DaAD_ISO.Checked = true;
                            break;
                    }
                    cbMoHinhQLNL_ChuaAD.Enabled = false;
                    cbMoHinhQLNL_DaAD.Enabled = false;
                    cbMoHinhQLNL_DaAD_ISO.Enabled = false;

                    BindInfoLabel();
                }
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            Enterprise enter = new EnterpriseService().FindByKey(memVal.OrgId);
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
    void BindInfoLabel()
    {
        ltReportYear.Text = ddlYear.SelectedItem.Text;
        ltReportDate.Text = txtReportDate.Text;
        ltEnterpriseName.Text = txtEnterpriseName.Text.Trim();
        ltAreaName.Text = ddlArea.SelectedItem.Text;
        if (ddlSubArea.SelectedIndex > 0)
            ltSubAreaName.Text = ddlSubArea.SelectedItem.Text;
        else
            ltSubAreaName.Text = "------";
        if (ddlProvince.SelectedIndex > 0)
            ltProvinceName.Text = ddlProvince.SelectedItem.Text;
        else
            ltProvinceName.Text = "------";
        if (ddlDistrict.SelectedIndex > 0)
            ltDistrictName.Text = ddlDistrict.SelectedItem.Text;
        else
            ltDistrictName.Text = "------";
        ltTaxNo.Text = txtMST.Text;
        ltAddress.Text = txtAddress.Text;
        ltEmail.Text = txtEmail.Text;
        ltFaxNo.Text = txtFax.Text;
        ltPhoneNumber.Text = txtPhone.Text;
        ltResponsible.Text = txtResponsible.Text;
        ltReporter.Text = txtReportName.Text;

        ltParentName.Text = txtParentName.Text;
        if (ddlProvinceReporter.SelectedIndex > 0)
            ltProvinceParent.Text = ddlProvinceReporter.SelectedItem.Text;
        else
            ltProvinceParent.Text = "------";
        if (ddlDistrictReporter.SelectedIndex > 0)
            ltDistrictParent.Text = ddlDistrictReporter.SelectedItem.Text;
        else
            ltDistrictParent.Text = "------";
        ltEmailParent.Text = txtEmailReporter.Text;
        ltFaxParent.Text = txtFaxReporter.Text;
        ltAddressParent.Text = txtAddressReporter.Text;
        ltPhoneParent.Text = txtPhoneReporter.Text;
    }

    #endregion
    private ReportFuel ReceiveHtml()
    {
        ReportFuel faqs = new ReportFuel();
        faqs.ProviceId = Convert.ToInt32(ddlProvinceReporter.SelectedValue);
        faqs.DistrictId = Convert.ToInt32(ddlDistrictReporter.SelectedValue);
        faqs.AreaId = Convert.ToInt32(ddlArea.SelectedValue);
        faqs.SubAreaId = Convert.ToInt32(ddlSubArea.SelectedValue);
        faqs.ReporterName = txtReportName.Text;
        IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
        faqs.ReportDate = DateTime.ParseExact(txtReportDate.Text, "dd/MM/yyyy", culture);
        faqs.ReporterName = txtReportName.Text;
        faqs.Address = txtAddressReporter.Text;
        faqs.Email = txtEmail.Text;
        faqs.Phone = txtPhoneReporter.Text;
        faqs.Fax = txtFaxReporter.Text;

        if (memVal.OrgId > 0)
        {
            faqs.EnterpriseId = Convert.ToInt32(memVal.OrgId);
            Enterprise enter = new EnterpriseService().FindByKey(faqs.EnterpriseId);
            if (enter != null)
            {
                faqs.OrganizationId = enter.OrganizationId;
            }
        }
        if (ddlYear.SelectedIndex > 0)
            faqs.Year = Convert.ToInt32(ddlYear.SelectedValue);
        return faqs;

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
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            ReportFuel faqs = ReceiveHtml();
            ReportFuelService faqsBSO = new ReportFuelService();
            int ret = faqsBSO.Insert(faqs);
            if (ret > 0)
            {
                Response.Redirect(ResolveUrl("~") + "bao-cao-so-lieu-hang-nam.aspx?Id=" + ret + "&activetab=1");
                clientview.Text = "<div class='alert alert-sm alert-success bg-gradient'>Lưu thông tin Thành công !</div>";
            }
            else
                clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lưu thông tin không Thành công !</div>";
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btnDelete = (LinkButton)sender;
        ReportFuelDetailService faqsBSO = new ReportFuelDetailService();
        faqsBSO.Delete(Convert.ToInt32(btnDelete.CommandArgument));

    }
    protected void btnExportWord_Click(object sender, EventArgs e)
    {
        #region get data
        ReportModels rp = new ReportModels();
        //var en = rp.DE_Enterprise.First(x => x.Id == memVal.OrgId);
        string ReportTemplate = GetReportTemp(ReportId, false, memVal.OrgId);

        //var reportTemp = (from a in rp.DE_Enterprise
        //                  join b in rp.DE_BaocaoLinhVuc on a.ReportTemplate equals b.AutoId
        //                  where a.Id == memVal.OrgId
        //                  select b).FirstOrDefault();
        //if (reportTemp == null)
        //    throw new Exception("Doanh nghiệp chưa cập nhật lĩnh vực hoạt động");

        //string temp = "TempReport/" + reportTemp.TemplateBC.Trim();
        string temp = "TempReport/" + ReportTemplate;

        WordExtend ex = new WordExtend();
        ex.OpenFile(Server.MapPath(ResolveUrl("~") + temp));
        Enterprise or = new Enterprise();
        EnterpriseService orser = new EnterpriseService();
        or = orser.FindByKey(Convert.ToInt32(memVal.OrgId));

        DataTable dtinfo = new DataTable();
        ex.WriteToMergeField("BC_MaDN", memVal.UserName);
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

            //Mô hình quản lý năng lượng
            string emptyBoxImgUrl = Server.MapPath(ResolveUrl("~") + "TempReport/icons/unchecked-checkbox.png");
            string checkedBoxImgUrl = Server.MapPath(ResolveUrl("~") + "TempReport/icons/checked-checkbox.png");

            switch (or.MoHinhQLNL)
            {
                case 0:
                    ex.BoolmarkInsertImage("QLNL_AD1", emptyBoxImgUrl);
                    ex.BoolmarkInsertImage("QLNL_AD2", emptyBoxImgUrl);
                    ex.BoolmarkInsertImage("QLNL_AD3", emptyBoxImgUrl);
                    break;
                case 1:
                    ex.BoolmarkInsertImage("QLNL_AD1", emptyBoxImgUrl);
                    ex.BoolmarkInsertImage("QLNL_AD2", checkedBoxImgUrl);
                    ex.BoolmarkInsertImage("QLNL_AD3", emptyBoxImgUrl);
                    break;
                case 2:
                    ex.BoolmarkInsertImage("QLNL_AD1", emptyBoxImgUrl);
                    ex.BoolmarkInsertImage("QLNL_AD2", emptyBoxImgUrl);
                    ex.BoolmarkInsertImage("QLNL_AD3", checkedBoxImgUrl);
                    break;
                default:
                    ex.BoolmarkInsertImage("QLNL_AD1", emptyBoxImgUrl);
                    ex.BoolmarkInsertImage("QLNL_AD2", emptyBoxImgUrl);
                    ex.BoolmarkInsertImage("QLNL_AD3", emptyBoxImgUrl);
                    break;
            }
        }
        else
            ex.WriteToMergeField("BC_TenCoSo", "");



        if (dtinfo.Rows[0]["Year"] != DBNull.Value)
        {
            int iCurrentYear = Convert.ToInt32(dtinfo.Rows[0]["Year"]);
            string NextYear = dtinfo.Rows[0]["Year"].ToString();
            ex.WriteToMergeField("BC_NextYear", NextYear);

            if (ReportTemplate == ReportKeyTemplate.ANNUAL17 || ReportTemplate == ReportKeyTemplate.ANNUAL18)
            {
                ex.WriteToMergeField("BC_NextYear1", (iCurrentYear - 1).ToString());
                ex.WriteToMergeField("BC_NextYear3", "");
            }

            if (ReportTemplate == ReportKeyTemplate.ANNUAL18)
            {
                ex.WriteToMergeField("BC_NextYear1", "");
                ex.WriteToMergeField("BC_NextYear3", "");
            }

            if (ReportTemplate == ReportKeyTemplate.ANNUAL12)
            {
                ex.WriteToMergeField("BC_NextYear3", iCurrentYear.ToString());
            }

            if (ReportTemplate == ReportKeyTemplate.ANNUAL13)
            {
                ex.WriteToMergeField("BC_NextYear3", iCurrentYear.ToString());
            }


            ex.WriteToMergeField("BC_NextYear2", NextYear);
            ex.WriteToMergeField("BC_Year1", NextYear);
            ex.WriteToMergeField("BC_Year_1", (iCurrentYear - 1).ToString());
            ex.WriteToMergeField("BC_Year_11", (iCurrentYear - 1).ToString());
            ex.WriteToMergeField("BC_Year_111", (iCurrentYear - 1).ToString());
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



        if (dtinfo.Rows[0]["EmailParent"] != DBNull.Value)
            ex.WriteToMergeField("BC_EmailP", dtinfo.Rows[0]["EmailParent"].ToString());
        else
            ex.WriteToMergeField("BC_EmailP", "");

        if (dtinfo.Rows[0]["FaxParent"] != DBNull.Value)
            ex.WriteToMergeField("BC_FaxP", dtinfo.Rows[0]["FaxParent"].ToString());
        else
            ex.WriteToMergeField("BC_FaxP", "");


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

        usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, true);
        if (usingElectrict != null)
        {
            //Su dung dien 1
            if (usingElectrict.Quantity > 0)
                ex.WriteToMergeField("QuantityResult", usingElectrict.Quantity.ToString());
            else
                ex.WriteToMergeField("QuantityResult", "");

            if (usingElectrict.InstalledCapacity > 0)
                ex.WriteToMergeField("CapacityResult", usingElectrict.InstalledCapacity.ToString());
            else
                ex.WriteToMergeField("CapacityResult", "");

            if (usingElectrict.CongSuatBan > 0)
                ex.WriteToMergeField("CongSuatBan", usingElectrict.CongSuatBan.ToString());
            else
                ex.WriteToMergeField("CongSuatBan", "");

            if (usingElectrict.SanLuongBan > 0)
                ex.WriteToMergeField("SanLuongBan", usingElectrict.SanLuongBan.ToString());
            else
                ex.WriteToMergeField("SanLuongBan", "");
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
            ex.WriteToMergeField("BuyPriceResult2", "");

            ex.WriteToMergeField("QuantityResult", "");
            ex.WriteToMergeField("InstalledCapacityResult", "");
            ex.WriteToMergeField("CapacityResult", "");
            ex.WriteToMergeField("BuyCostResult", "");
            ex.WriteToMergeField("ProduceQtyResult", "");
            ex.WriteToMergeField("TechnologyResult", "");
            ex.WriteToMergeField("FuelNameResult", "");
            ex.WriteToMergeField("BuyPriceResult", "");

            ex.WriteToMergeField("CongSuatBan", "");
            ex.WriteToMergeField("SanLuongBan", "");
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
        dt.Columns.Add("stt", typeof(string));
        dtdukien = dt.Clone();
        int counter = 0;
        foreach (DataRow item in dt.Rows)
        {
            counter++;
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
            workRow["stt"] = counter.ToString();
            workRow.AcceptChanges();
            dtdukien.ImportRow(workRow);
            dtdukien.AcceptChanges();

        }

        //tblProductResult
        DataTable tblProductResult = new DataTable();
        tblProductResult = GetDataTbl1(ReportId, false, memVal.OrgId);
        dshientai.Merge(tblProductResult);
        dshientai.Tables[0].TableName = "tbl1";

        //Nếu là biểu mẫu 1.3
        DataTable tbl2 = new DataTable();
        if (ReportTemplate == ReportKeyTemplate.ANNUAL13)
        {
            tbl2 = GetData132(ReportId, false, memVal.OrgId);
            dshientai.Merge(tbl2);
        }
        else
            dshientai.Merge(dthientai);

        dshientai.Tables[1].TableName = "tbl2";

        //tblProductPlan
        DataTable tblProductPlan = new DataTable();
        if (ReportTemplate == ReportKeyTemplate.ANNUAL13)
            tblProductPlan = GetData133(ReportId, true, memVal.OrgId);
        else
            tblProductPlan = GetDataTbl1(ReportId, true, memVal.OrgId);
        dshientai.Merge(tblProductPlan);
        dshientai.Tables[2].TableName = "tbl3";

        dshientai.Merge(dtdukien);
        dshientai.Tables[3].TableName = "tbl4";

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
        DataTable tblTBResultR = tblTBResult.Clone();
        tblTBResultR.Columns.Add(new DataColumn("CoTH"));
        DataTable tblTBResultP = tblTBResult.Clone();
        tblTBResultP.Columns.Add(new DataColumn("CoTH"));
        if (tblTBResult != null && tblTBResult.Rows.Count > 0)
        {
            for (int i = 0; i < tblTBResult.Rows.Count; i++)
            {
                if (tblTBResult.Rows[i]["IsNew"] != DBNull.Value && Convert.ToBoolean(tblTBResult.Rows[i]["IsNew"]))
                {
                    DataRow dr = tblTBResultR.NewRow();
                    dr["IsNew"] = tblTBResult.Rows[i]["IsNew"];
                    dr["NameTB"] = tblTBResult.Rows[i]["NameTB"];
                    dr["TinhNang"] = tblTBResult.Rows[i]["TinhNang"];
                    dr["CachLapDat"] = tblTBResult.Rows[i]["CachLapDat"];
                    dr["LyDoLapDat"] = tblTBResult.Rows[i]["LyDoLapDat"];
                    dr["KhaNang"] = tblTBResult.Rows[i]["KhaNang"];
                    dr["CamKet"] = tblTBResult.Rows[i]["CamKet"];
                    dr["Nam"] = tblTBResult.Rows[i]["Nam"];
                    if (tblTBResult.Rows[i]["IsExecuted"] != DBNull.Value && Convert.ToBoolean(tblTBResult.Rows[i]["IsExecuted"]))
                    {
                        dr["CoTH"] = "Có";
                    }
                    else
                    {
                        dr["CoTH"] = "Không";
                    }
                    tblTBResultR.Rows.Add(dr);
                }
                else
                {
                    DataRow dr = tblTBResultP.NewRow();
                    dr["IsNew"] = tblTBResult.Rows[i]["IsNew"];
                    dr["NameTB"] = tblTBResult.Rows[i]["NameTB"];
                    dr["TinhNang"] = tblTBResult.Rows[i]["TinhNang"];
                    dr["CachLapDat"] = tblTBResult.Rows[i]["CachLapDat"];
                    dr["LyDoLapDat"] = tblTBResult.Rows[i]["LyDoLapDat"];
                    dr["KhaNang"] = tblTBResult.Rows[i]["KhaNang"];
                    dr["CamKet"] = tblTBResult.Rows[i]["CamKet"];
                    dr["Nam"] = tblTBResult.Rows[i]["Nam"];
                    if (tblTBResult.Rows[i]["IsExecuted"] != DBNull.Value && Convert.ToBoolean(tblTBResult.Rows[i]["IsExecuted"]))
                    {
                        dr["CoTH"] = "Có";
                    }
                    else
                    {
                        dr["CoTH"] = "Không";
                    }
                    tblTBResultP.Rows.Add(dr);
                }
            }
        }
        dshientai.Merge(tblTBResultP);
        dshientai.Tables[9].TableName = "tbl10";

        dshientai.Tables.Add(tblTBResultR);
        dshientai.Tables[10].TableName = "tbl11";


        DataTable dtDienTuSX = GetDienTuSanXuat();
        dshientai.Tables.Add(dtDienTuSX);
        dshientai.Tables[11].TableName = "tbl12";
        dshientai.Merge(dtDienTuSX);

        //Tính toán điện tổng điện tự sx
        decimal _InstalledCapacityResult = 0;
        decimal _ProduceQtyResult = 0;
        decimal _temp = 0;
        foreach (DataRow r in dtDienTuSX.Rows)
        {
            _temp = 0;
            if (decimal.TryParse(r["CongSuatLapDat"].ToString(), out _temp))
                _InstalledCapacityResult += _temp;
            _temp = 0;
            if (decimal.TryParse(r["DienNangSanXuat"].ToString(), out _temp))
                _ProduceQtyResult += _temp;
        }

        if (_InstalledCapacityResult > 0)
            ex.WriteToMergeField("InstalledCapacityResult", _InstalledCapacityResult.ToString());
        else
            ex.WriteToMergeField("InstalledCapacityResult", "");

        if (_ProduceQtyResult > 0)
            ex.WriteToMergeField("ProduceQtyResult", _ProduceQtyResult.ToString());
        else
            ex.WriteToMergeField("ProduceQtyResult", "");


        ex.WriteDataSetToMergeField(dshientai);
        #endregion
        ex.Save(Server.MapPath(ResolveUrl("~") + "TempReport/" + memVal.UserName + ".Bao-cao-hang-nam-" + dtinfo.Rows[0]["Year"] + ".doc"));
        HttpContext.Current.Response.Redirect(string.Format("~/Download.aspx?fp={0}&fn={1}",
              System.IO.Path.GetFileName(Server.MapPath(ResolveUrl("~") + "TempReport/" + memVal.UserName + ".Bao-cao-hang-nam-" + dtinfo.Rows[0]["Year"] + ".doc")),
              ""
          ));
    }
    protected void btnExport5_Click(object sender, EventArgs e)
    {
        #region get data
        WordExtend ex = new WordExtend();
        string temp = "TempReport/Template_5nam" + ddlReportType5.SelectedValue + ".docx";
        ex.OpenFile(Server.MapPath(ResolveUrl("~") + temp));
        Enterprise or = new Enterprise();
        EnterpriseService orser = new EnterpriseService();
        or = orser.FindByKey(Convert.ToInt32(memVal.OrgId));

        DataTable dtinfo = new DataTable();
        ex.WriteToMergeField("BC_MaDN", memVal.UserName);
        if (memVal.OrgId > 0)
        {
            dtinfo = new ReportFuelService().GetInfoReportFuel(ReportId);
        }

        if (or != null)
        {
            ex.WriteToMergeField("BC_Title", or.Title);
            ex.WriteToMergeField("BC_TenCoSo", or.Title);
            ex.WriteToMergeField("BC_TenCoSo1", or.Title);
        }
        else
        {
            ex.WriteToMergeField("BC_Title", "");
            ex.WriteToMergeField("BC_TenCoSo", "");
            ex.WriteToMergeField("BC_TenCoSo1", "");
        }
        if (dtinfo.Rows[0]["Year"] != DBNull.Value)
        {
            int NamBD = Convert.ToInt32(dtinfo.Rows[0]["Year"]);
            int NamKT = NamBD + 5;
            ex.WriteToMergeField("BC_NamBD", NamBD.ToString());
            ex.WriteToMergeField("BC_NamKT", NamKT.ToString());
            ex.WriteToMergeField("BC_NamBD1", NamBD.ToString());
            ex.WriteToMergeField("BC_NamKT1", NamKT.ToString());
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
        //if (dtinfo.Rows[0]["ReporterName"] != DBNull.Value)
        //    ex.WriteToMergeField("BC_NguoiBC", dtinfo.Rows[0]["ReporterName"].ToString());
        //else
        //    ex.WriteToMergeField("BC_NguoiBC", "");

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
        //if (dtinfo.Rows[0]["EmailParent"] != DBNull.Value)
        //    ex.WriteToMergeField("BC_EmailP", dtinfo.Rows[0]["EmailParent"].ToString());
        //else
        //    ex.WriteToMergeField("BC_EmailP", "");

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

            if (usingElectrict.FuelId > 0)
            {

                Fuel fuel = new Fuel();

                fuel = new FuelService().FindByKey(usingElectrict.FuelId);
                if (fuel != null)
                {
                    ex.WriteToMergeField("FuelNameResult", fuel.FuelName);
                }
                else
                {
                    ex.WriteToMergeField("FuelNameResult", "");
                }
            }
            else
            {

                ex.WriteToMergeField("FuelNameResult", "");
            }



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
            {
                ex.WriteToMergeField("BuyPriceResult", Math.Round((usingElectrict.BuyCost / (usingElectrict.Capacity * 1000)), 0).ToString());
            }
            else
                ex.WriteToMergeField("BuyPriceResult", " ");
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
            ex.WriteToMergeField("QuantityResult", "");
            ex.WriteToMergeField("InstalledCapacityResult", "");
            ex.WriteToMergeField("CapacityResult", "");
            ex.WriteToMergeField("BuyCostResult", "");
            ex.WriteToMergeField("ProduceQtyResult", "");
            ex.WriteToMergeField("TechnologyResult", "");
            ex.WriteToMergeField("FuelNameResult", "");
            ex.WriteToMergeField("BuyPriceResult", "");

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

        DataTable dtPlanTB = new DataTable();
        dtPlanTB = new PlanTBService().GetPlanTBEnterprise(memVal.OrgId, ReportId, true, true);
        DataTable dtPlanTKNL = new DataTable();
        dtPlanTKNL = new PlanTKNLService().GetPlanTKNLEnerprise(memVal.OrgId, ReportId, true, true);

        dshientai.Tables.Add(dtPlanTKNL.Copy());
        dshientai.Tables[2].TableName = "tbl3";
        dshientai.Tables.Add(dtPlanTB.Copy());
        dshientai.Tables[3].TableName = "tbl4";
        ex.WriteDataSetToMergeField(dshientai);

        #endregion
        ex.Save(Server.MapPath(ResolveUrl("~") + "TempReport/" + memVal.UserName + ".Bao-cao-5-nam-" + dtinfo.Rows[0]["Year"] + ".docx"));
        HttpContext.Current.Response.Redirect(string.Format("~/Download.aspx?fp={0}&fn={1}",
              System.IO.Path.GetFileName(Server.MapPath(ResolveUrl("~") + "TempReport/" + memVal.UserName + ".Bao-cao-5-nam-" + dtinfo.Rows[0]["Year"] + ".docx")),
              ""
          ));
    }

    protected void btnReSend_Click(object sender, EventArgs e)
    {
        try
        {
            //ReportFuel faqs = ReceiveHtml();

            ReportFuelService faqsBSO = new ReportFuelService();

            if (ReportId > 0)
            {
                string strPath = Server.MapPath("~/UserFile/Report/");

                if (fAttachResend.HasFile)
                {
                    try
                    {
                        Random rand = new Random();
                        string strFilename = "";
                        strFilename = memVal.UserName + "_BC1_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttach.FileName).ToLower();
                        if (System.IO.File.Exists(strPath + strFilename))
                        {
                            strFilename = memVal.UserName + "_BC1_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttach.FileName).ToLower();
                        }
                        fAttach.PostedFile.SaveAs(strPath + strFilename);

                        ReportAttachFile reportAtt = new ReportAttachFile();
                        reportAtt.ReportId = ReportId;
                        reportAtt.PathFile = strFilename;
                        reportAtt.Created = DateTime.Now;
                        reportAtt.ActionName = "Đã cập nhật, bổ sung tài liệu";
                        reportAtt.Comment = txtNote.Text;
                        reportAtt.UserId = memVal.UserId;
                        reportAtt.UserName = memVal.UserName;
                        reportAtt.ReportType = Convert.ToInt32(LogType.ANNUALREPORT);
                        new ReportAttachFileService().Insert(reportAtt);
                    }
                    catch (Exception ex) { }
                }

                if (fAttachResend5.HasFile)
                {
                    try
                    {
                        Random rand = new Random();
                        string strFilename = "";
                        strFilename = memVal.UserName + "_BC5_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttachResend5.FileName).ToLower();
                        if (System.IO.File.Exists(strPath + strFilename))
                        {
                            strFilename = memVal.UserName + "_BC5_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttachResend5.FileName).ToLower();
                        }
                        fAttachResend5.PostedFile.SaveAs(strPath + strFilename);


                        ReportAttachFile reportAtt = new ReportAttachFile();
                        reportAtt.ReportId = ReportId;
                        reportAtt.PathFile = strFilename;
                        reportAtt.Created = DateTime.Now;
                        reportAtt.ActionName = "Đã cập nhật, bổ sung tài liệu";
                        reportAtt.Comment = txtNote.Text;
                        reportAtt.UserId = memVal.UserId;
                        reportAtt.UserName = memVal.UserName;
                        reportAtt.ReportType = Convert.ToInt32(LogType.ANNUALREPORT);
                        new ReportAttachFileService().Insert(reportAtt);
                    }
                    catch (Exception ex) { }
                }

                if (faqsBSO.UpdateStatusEnterprise(ReportId, 4) > 0)//Da bo sung hieu chinh
                {
                    ReportLog log = new ReportLog();
                    log.ActionName = "Đã cập nhật, bổ sung tài liệu";
                    log.Comment = txtNote.Text;
                    log.ReportId = ReportId;
                    log.Created = DateTime.Now;
                    log.MemberId = memVal.UserId;
                    log.UserName = memVal.UserName;
                    log.Status = "Đã bổ sung, hiệu chỉnh báo cáo";
                    log.LogType = Convert.ToInt32(LogType.ANNUALREPORT);
                    new ReportLogService().Insert(log);

                    clientview.Text = "<div class='alert alert-sm alert-success bg-gradient'>Lưu thông tin Thành công !</div>";
                    Response.Redirect(ResolveUrl("~") + "Doanh-nghiep.aspx");
                }
                else
                {
                    clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lưu thông tin không Thành công !</div>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "ShowDialogResend();", true);
                }


            }
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
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
                    Random rand = new Random();
                    string strFilename = "";
                    strFilename = memVal.UserName + "_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttachFeedback.FileName).ToLower();
                    if (System.IO.File.Exists(strPath + strFilename))
                    {
                        strFilename = memVal.UserName + "_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttachFeedback.FileName).ToLower();
                    }
                    fAttachFeedback.PostedFile.SaveAs(strPath + strFilename);

                    ReportAttachFile reportAtt = new ReportAttachFile();
                    reportAtt.ReportId = ReportId;
                    reportAtt.PathFile = strFilename;
                    reportAtt.Created = DateTime.Now;
                    reportAtt.ActionName = "DN đã tải file báo cáo";
                    reportAtt.Comment = txtFeedback.Text;
                    reportAtt.UserName = memVal.UserName;
                    reportAtt.UserId = memVal.UserId;
                    reportAtt.ReportType = Convert.ToInt32(LogType.ANNUALREPORT);
                    if (new ReportAttachFileService().Insert(reportAtt) > 0)
                    {
                        BindReportFile();
                    }
                }
                catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "ShowDialogFeedback();", true); return; }
            }
            BindLog();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "sendFeedback", "ShowDialogFeedback();aler('Gửi không thành công, vui lòng thử lại.')", true);
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            ReportFuelService faqsBSO = new ReportFuelService();

            if (ReportId > 0)
            {
                string strPath = Server.MapPath("~/UserFile/Report/");
                if (fAttach.HasFile)
                {
                    try
                    {
                        Random rand = new Random();
                        string strFilename = "";
                        strFilename = memVal.UserName + "_BC1_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttach.FileName).ToLower();
                        if (System.IO.File.Exists(strPath + strFilename))
                        {
                            strFilename = memVal.UserName + "_BC1_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttach.FileName).ToLower();
                        }
                        fAttach.PostedFile.SaveAs(strPath + strFilename);

                        ReportAttachFile reportAtt = new ReportAttachFile();
                        reportAtt.ReportId = ReportId;
                        reportAtt.PathFile = strFilename;
                        reportAtt.Created = DateTime.Now;
                        reportAtt.ActionName = "DN đã gửi báo cáo cho SCT";
                        reportAtt.Comment = txtContent.Text;
                        reportAtt.UserId = memVal.UserId;
                        reportAtt.UserName = memVal.UserName;
                        reportAtt.ReportType = Convert.ToInt32(LogType.ANNUALREPORT);
                        new ReportAttachFileService().Insert(reportAtt);
                    }
                    catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "ShowDialogSend();", true); return; }
                }

                if (fAttach5year.HasFile)
                {
                    try
                    {
                        Random rand = new Random();
                        string strFilename = "";
                        strFilename = memVal.UserName + "_BC5_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttach5year.FileName).ToLower();
                        if (System.IO.File.Exists(strPath + strFilename))
                        {
                            strFilename = memVal.UserName + "_BC5_" + ReportYear + "_" + rand.Next(100) + System.IO.Path.GetExtension(fAttach5year.FileName).ToLower();
                        }
                        fAttach5year.PostedFile.SaveAs(strPath + strFilename);


                        ReportAttachFile reportAtt = new ReportAttachFile();
                        reportAtt.ReportId = ReportId;
                        reportAtt.PathFile = strFilename;
                        reportAtt.Created = DateTime.Now;
                        reportAtt.ActionName = "DN đã gửi báo cáo cho SCT";
                        reportAtt.Comment = txtContent.Text;
                        reportAtt.UserId = memVal.UserId;
                        reportAtt.UserName = memVal.UserName;
                        reportAtt.ReportType = Convert.ToInt32(LogType.ANNUALREPORT);
                        new ReportAttachFileService().Insert(reportAtt);
                    }
                    catch (Exception ex) { ScriptManager.RegisterStartupScript(this, GetType(), "sendreport", "ShowDialogSend();", true); return; }
                }

                if (faqsBSO.UpdateStatusEnterprise(ReportId, 1) != null)
                {
                    ReportLog log = new ReportLog();
                    log.ActionName = "DN đã gửi báo cáo cho SCT";
                    log.Comment = txtNote.Text;
                    log.ReportId = ReportId;
                    log.Created = DateTime.Now;
                    log.MemberId = memVal.UserId;
                    log.UserName = memVal.UserName;
                    log.Status = "Đã gửi báo cáo";
                    log.LogType = Convert.ToInt32(LogType.ANNUALREPORT);
                    new ReportLogService().Insert(log);
                    Response.Redirect(ResolveUrl("~") + "Doanh-nghiep.aspx");
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
        ScriptManager.RegisterStartupScript(this, GetType(), "showformInfo", "showformInfo();", true);
    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        try
        {
            ReportFuelService reportBSO = new ReportFuelService();
            ReportFuel report = reportBSO.FindByKey(ReportId);
            if (report != null)
            {
                if (ddlProvince.SelectedIndex > 0)
                    report.ProviceId = Convert.ToInt32(ddlProvince.SelectedValue);
                if (ddlDistrict.SelectedIndex > 0)
                    report.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                if (ddlArea.SelectedIndex > 0)
                    report.AreaId = Convert.ToInt32(ddlArea.SelectedValue);
                if (ddlSubArea.SelectedIndex > 0)
                    report.SubAreaId = Convert.ToInt32(ddlSubArea.SelectedValue);
                report.ReporterName = txtReportName.Text;
                IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
                report.ReportDate = DateTime.ParseExact(txtReportDate.Text, "dd/MM/yyyy", culture);
                report.ReporterName = txtReportName.Text;
                report.Address = txtAddress.Text;
                report.Email = txtEmail.Text;
                report.Phone = txtPhone.Text;
                report.Fax = txtFax.Text;
                report.TaxCode = txtMST.Text.Trim();
                report.Responsible = txtResponsible.Text.Trim();
                report.ParentName = txtParentName.Text.Trim();
                if (ddlProvinceReporter.SelectedIndex > 0)
                    report.ProvinceParentId = Convert.ToInt32(ddlProvinceReporter.SelectedValue);
                else
                    report.ProvinceParentId = 0;
                if (ddlDistrictReporter.SelectedIndex > 0)
                    report.DistrictParentId = Convert.ToInt32(ddlDistrictReporter.SelectedValue);
                else
                    report.DistrictParentId = 0;
                report.EmailParent = txtEmailReporter.Text.Trim();
                report.AddressParent = txtAddressReporter.Text.Trim();
                report.PhoneParent = txtPhoneReporter.Text.Trim();
                report.FaxParent = txtFaxReporter.Text.Trim();
                report.OwnerId = Convert.ToInt32(ddlOwner.SelectedValue);
                if (memVal.OrgId > 0)
                {
                    report.EnterpriseId = memVal.OrgId;
                    Enterprise enter = new EnterpriseService().FindByKey(report.EnterpriseId);
                    if (enter != null)
                    {
                        report.OrganizationId = enter.OrganizationId;
                    }
                }
                if (ddlYear.SelectedIndex > 0)
                    report.Year = Convert.ToInt32(ddlYear.SelectedValue);
                report.SendSatus = 0;
                report.Id = ReportId;
                if (reportBSO.Update(report) != null)
                {
                    clientview.Text = "<div class='alert alert-sm alert-success bg-gradient'>Cập nhật Thành công !</div>";
                    BindInfoLabel();
                }
                else
                    clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Cập nhật không Thành công !</div>";
            }
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
    }

    protected void btn_list_click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/listfaqs/Default.aspx");

    }
    protected void btn_new_click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~") + "bao-cao-so-lieu-hang-nam.aspx");

    }

    protected void rptNoFuelFuture_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemIndex == 0) No_TOE_Future = 0;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item["NoFuel_TOE"] != DBNull.Value)
            {
                No_TOE_Future = No_TOE_Future + Convert.ToDecimal(item["NoFuel_TOE"]);
            }
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;

            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");

        }
    }
    protected void rptNoFuelCurrent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemIndex == 0) No_TOE = 0;
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item["NoFuel_TOE"] != DBNull.Value)
            {
                No_TOE = No_TOE + Convert.ToDecimal(item["NoFuel_TOE"]);
            }
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;
            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",true); return false;");            

        }
    }
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubArea();
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "showformInfo('" + hdnNextYear.Value + "');", true);
    }
    void BindDistrictReporter()
    {
        ddlDistrictReporter.Items.Clear();
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
        ddlDistrict.Items.Clear();
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
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "showformInfo();", true);
    }
    protected void ddlProvinceReporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDistrictReporter();
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "showformInfo();", true);
    }

    private DataTable GetDienTuSanXuat()
    {
        try
        {
            DataTable res = new DataTable();
            res.Columns.Add("TenNhienLieu", typeof(string));
            res.Columns.Add("CongSuatLapDat", typeof(string));
            res.Columns.Add("DienNangSanXuat", typeof(string));

            ReportModels reportModels = new ReportModels();
            var data = (from a in reportModels.DE_ElectrictTechnology
                        join b in reportModels.DE_ElectrictProduce
                        on a.TechKey equals b.TechKey
                        where b.ReportId == ReportId
                        select new { TenNhienLieu = a.TechName, CongSuatLapDat = b.InstalledCapacity, DienNangSanXuat = b.ProduceQty }
                        ).Distinct().ToList();
            int counter = 1;
            foreach (var item in data)
            {
                DataRow row = res.NewRow();
                row["TenNhienLieu"] = string.Format("{0}.{1}", counter, item.TenNhienLieu);
                row["CongSuatLapDat"] = item.CongSuatLapDat.ToString();
                row["DienNangSanXuat"] = item.DienNangSanXuat.ToString();
                res.Rows.Add(row);
                counter++;
            }
            return res;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private string GetReportTemp(int ReportId, bool IsPlan, int OrgId)
    {
        ReportModels rp = new ReportModels();
        DataTable tblProductResult = new DataTable();
        var reportTemp = (from a in rp.DE_Enterprise
                          join b in rp.DE_BaocaoLinhVuc on a.ReportTemplate equals b.AutoId
                          where a.Id == memVal.OrgId
                          select b).FirstOrDefault();
        if (reportTemp == null)
            throw new Exception("Doanh nghiệp chưa cập nhật lĩnh vực hoạt động");
        string tmp = reportTemp.TemplateBC.ToUpper();
        return tmp;
    }

    private DataTable GetDataTbl1(int ReportId, bool IsPlan, int OrgId)
    {
        DataTable tblProductResult = new DataTable();
        var Template = GetReportTemp(ReportId, IsPlan, OrgId);
        switch (Template)
        {
            case "BC1.8.DOCX":
                tblProductResult = GetData18(ReportId, IsPlan);
                break;
            case "BC1.7.DOCX":
                tblProductResult = GetData17(ReportId, IsPlan, OrgId);
                break;
            case "BC1.6.DOCX":
                tblProductResult = GetData16(ReportId, IsPlan, OrgId);
                break;
            case "BC1.5.DOCX":
                tblProductResult = GetData15(ReportId, IsPlan, OrgId);
                break;
            case "BC1.4.DOCX":
                tblProductResult = GetData14(ReportId, IsPlan, OrgId);
                break;
            case "BC1.3.DOCX":
                tblProductResult = GetData131(ReportId, IsPlan, OrgId);
                break;
            case "BC1.2.DOCX":
                tblProductResult = GetData12(ReportId, IsPlan, OrgId);
                break;
        }
        return tblProductResult;
    }

    private DataTable GetData18(int ReportId, bool IsPlan)
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        return productCapacityService.GetDataCapacity(ReportId, IsPlan);
    }

    private DataTable GetData17(int ReportId, bool IsPlan, int OrgId)
    {
        ReportModels rp = new ReportModels();
        DataTable tblProductResult = new DataTable();
        tblProductResult.Columns.Add("ProductName", typeof(string));
        tblProductResult.Columns.Add("Measurement", typeof(string));
        tblProductResult.Columns.Add("FuelName", typeof(string));
        tblProductResult.Columns.Add("DesignQuantity", typeof(decimal));
        tblProductResult.Columns.Add("MaxQuantity", typeof(decimal));

        var data = (from a in rp.DE_Product
                    join b in rp.DE_ProductCapacity on a.Id equals b.ProductId
                    join c in rp.DE_Fuel on a.FuelId equals c.Id
                    where b.ReportId == ReportId && b.IsPlan == IsPlan && a.EnterpriseId == OrgId
                    orderby a.ProductOrder ascending
                    select new
                    {
                        ProductName = a.ProductName,
                        MaxQuantity = b.MaxQuantity,
                        Measurement = a.Measurement,
                        DesignQuantity = b.DesignQuantity == null ? 0 : b.DesignQuantity,
                        FuelName = c.FuelName
                    }).ToList();

        foreach (var item in data)
        {
            var row = tblProductResult.NewRow();
            row["ProductName"] = item.ProductName;
            row["Measurement"] = item.Measurement;
            row["MaxQuantity"] = item.MaxQuantity;
            row["DesignQuantity"] = item.DesignQuantity;
            row["FuelName"] = item.FuelName;
            tblProductResult.Rows.Add(row);
        }
        return tblProductResult;
    }

    private DataTable GetData16(int ReportId, bool IsPlan, int OrgId)
    {
        ReportModels rp = new ReportModels();
        DataTable tblProductResult = new DataTable();
        tblProductResult.Columns.Add("ProductName", typeof(string));
        tblProductResult.Columns.Add("MaxQuantity", typeof(decimal));
        tblProductResult.Columns.Add("FuelName", typeof(decimal));
        tblProductResult.Columns.Add("NangLucVanChuyenNguoi", typeof(string));
        tblProductResult.Columns.Add("NangLucVanChuyenHang", typeof(string));

        var data = (from a in rp.DE_Product
                    join b in rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == IsPlan) on a.Id equals b.ProductId into ab
                    from c in ab.DefaultIfEmpty()
                    join d in rp.DE_Fuel on a.FuelId equals d.Id
                    where a.EnterpriseId == OrgId
                    orderby a.ProductName ascending
                    select new
                    {
                        ProductName = a.ProductName,
                        FuelName = d.FuelName,
                        MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString()),
                        NangLucVanChuyenNguoi = (c == null ? string.Empty : c.NangLucVanChuyenNguoi.ToString()),
                        NangLucVanChuyenHang = (c == null ? string.Empty : c.NangLucVanChuyenHang.ToString())
                    }).ToList();

        foreach (var item in data)
        {
            var row = tblProductResult.NewRow();
            row["ProductName"] = item.ProductName;
            row["MaxQuantity"] = item.MaxQuantity;
            row["FuelName"] = item.FuelName;
            row["NangLucVanChuyenHang"] = item.NangLucVanChuyenNguoi;
            row["NangLucVanChuyenHang"] = item.NangLucVanChuyenHang;
            tblProductResult.Rows.Add(row);
        }
        return tblProductResult;
    }

    private DataTable GetData15(int ReportId, bool IsPlan, int OrgId)
    {
        ReportModels rp = new ReportModels();
        DataTable tblProductResult = new DataTable();
        tblProductResult.Columns.Add("ProductName", typeof(string));
        tblProductResult.Columns.Add("Measurement", typeof(string));
        tblProductResult.Columns.Add("DataReport1415", typeof(string));
        tblProductResult.Columns.Add("MaxQuantity", typeof(string));

        var data = (from a in rp.DE_Product
                    join b in rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == IsPlan) on a.Id equals b.ProductId into ab
                    from c in ab.DefaultIfEmpty()
                    where a.EnterpriseId == OrgId
                    orderby a.ProductName ascending
                    select new
                    {
                        ProductName = a.ProductName,
                        Measurement = a.Measurement != null ? a.Measurement : string.Empty,
                        DataReport1415 = c.DataReport1415,
                        MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                    }).ToList();

        foreach (var item in data)
        {
            var row = tblProductResult.NewRow();
            row["ProductName"] = item.ProductName;
            row["Measurement"] = item.Measurement;
            row["DataReport1415"] = item.DataReport1415;
            row["MaxQuantity"] = item.MaxQuantity;
            tblProductResult.Rows.Add(row);
        }
        return tblProductResult;
    }

    private DataTable GetData14(int ReportId, bool IsPlan, int OrgId)
    {
        ReportModels rp = new ReportModels();
        DataTable tblProductResult = new DataTable();
        tblProductResult.Columns.Add("ProductName", typeof(string));
        tblProductResult.Columns.Add("Measurement", typeof(string));
        tblProductResult.Columns.Add("DataReport1415", typeof(string));
        tblProductResult.Columns.Add("MaxQuantity", typeof(string));

        var data = (from a in rp.DE_Product
                    join b in rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == IsPlan) on a.Id equals b.ProductId into ab
                    from c in ab.DefaultIfEmpty()
                    where a.EnterpriseId == OrgId
                    orderby a.ProductName ascending
                    select new
                    {
                        ProductName = a.ProductName,
                        Measurement = a.Measurement != null ? a.Measurement : string.Empty,
                        DataReport1415 = c.DataReport1415,
                        MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                    }).ToList();

        foreach (var item in data)
        {
            var row = tblProductResult.NewRow();
            row["ProductName"] = item.ProductName;
            row["Measurement"] = item.Measurement;
            row["DataReport1415"] = item.DataReport1415;
            row["MaxQuantity"] = item.MaxQuantity;
            tblProductResult.Rows.Add(row);
        }
        return tblProductResult;
    }

    private DataTable GetData12(int ReportId, bool IsPlan, int OrgId)
    {
        ReportModels rp = new ReportModels();
        ProductCapacityService productCapacityService = new ProductCapacityService();
        DataTable tblProductResult = new DataTable();
        tblProductResult = productCapacityService.GetDataCapacity(ReportId, IsPlan);
        //Thêm cột tính lại giá trị tiêu thụ năng lượng theo sp
        tblProductResult.Columns.Add("TTNLTHEOSP", typeof(string));

        foreach (DataRow r in tblProductResult.Rows)
        {
            int _ProductCapacityId = (int)r["Id"];
            var data = (from a in rp.DE_ProductCapacityFuel
                        join b in rp.DE_Measurement on a.MeasurementId equals b.Id
                        join c in rp.DE_Fuel on a.FuelId equals c.Id
                        where a.ProductCapacityId == _ProductCapacityId
                        select new
                        {
                            c.FuelName,
                            a.ConsumeQty,
                            b.MeasurementName,
                        }).ToList();

            string tmp = string.Empty;
            foreach (var item in data)
            {
                tmp += string.Format("{0}: {1}({2})\n", item.FuelName, item.ConsumeQty, item.MeasurementName);
            }

            r["TTNLTHEOSP"] = tmp;
        }
        //tblProductResult.Columns["MucTieuGP"].ColumnName = "GhiChu";
        //tblProductResult.AcceptChanges();
        return tblProductResult;
    }

    private DataTable GetData131(int ReportId, bool IsPlan, int OrgId)
    {
        ReportModels rp = new ReportModels();
        DataTable tblProductResult = new DataTable();
        tblProductResult.Columns.Add("ProductName", typeof(string));
        tblProductResult.Columns.Add("NhietTriThap", typeof(string));
        tblProductResult.Columns.Add("GroupFuelName", typeof(string));
        tblProductResult.Columns.Add("MaxQuantity", typeof(string));

        var data = (from a in rp.DE_Product
                    join b in rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == false) on a.Id equals b.ProductId into ab
                    from c in ab.DefaultIfEmpty()
                    join d in rp.DE_GroupFuel on a.GroupFuel equals d.Id
                    where a.EnterpriseId == memVal.OrgId && a.IsProduct == IsPlan
                    && a.ProductType13 == ReportKey.ProductKey_131
                    orderby a.ProductName ascending
                    select new
                    {
                        ProductName = a.ProductName,
                        NhietTriThap = a.NhietTriThap == null ? 0 : a.NhietTriThap,
                        GroupFuelName = d.Title,
                        MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                    }).ToList();

        foreach (var item in data)
        {
            var row = tblProductResult.NewRow();
            row["ProductName"] = item.ProductName;
            row["NhietTriThap"] = item.NhietTriThap.ToString();
            row["GroupFuelName"] = item.GroupFuelName;
            row["MaxQuantity"] = item.MaxQuantity;
            tblProductResult.Rows.Add(row);
        }

        return tblProductResult;
    }
    private DataTable GetData132(int ReportId, bool IsPlan, int OrgId)
    {
        ReportModels rp = new ReportModels();
        DataTable tblProductResult = new DataTable();

        tblProductResult.Columns.Add("ProductNameOdd", typeof(string));
        tblProductResult.Columns.Add("CongSuat13Odd", typeof(string));
        tblProductResult.Columns.Add("DesignQuantityOdd", typeof(string));
        tblProductResult.Columns.Add("MaxQuantityOdd", typeof(string));

        tblProductResult.Columns.Add("ProductNameEven", typeof(string));
        tblProductResult.Columns.Add("CongSuat13Even", typeof(string));
        tblProductResult.Columns.Add("DesignQuantityEven", typeof(string));
        tblProductResult.Columns.Add("MaxQuantityEven", typeof(string));

        var data = (from a in rp.DE_Product
                    join b in rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == false) on a.Id equals b.ProductId into ab
                    from c in ab.DefaultIfEmpty()
                    where a.EnterpriseId == memVal.OrgId
                    && a.IsProduct == true
                    && a.ProductType13 == ReportKey.ProductKey_132
                    orderby a.ProductName ascending
                    select new
                    {
                        ProductName = a.ProductName,
                        CongSuat13 = (c == null ? string.Empty : c.CongSuat13.ToString()),
                        DesignQuantity = (c == null ? string.Empty : c.DesignQuantity.ToString()),
                        MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                    }).ToList();

        var rowCount = data.Count;
        if (rowCount == 0)
            return tblProductResult;

        if (rowCount == 1)
        {
            var row = tblProductResult.NewRow();
            var item = data[0];
            row["ProductNameOdd"] = item.ProductName;
            row["CongSuat13Odd"] = item.CongSuat13.ToString();
            row["DesignQuantityOdd"] = item.DesignQuantity;
            row["MaxQuantityOdd"] = item.MaxQuantity;

            row["ProductNameEven"] = string.Empty;
            row["CongSuat13Even"] = string.Empty;
            row["DesignQuantityEven"] = string.Empty;
            row["MaxQuantityEven"] = string.Empty;
            tblProductResult.Rows.Add(row);

            return tblProductResult;
        }

        var loopCounter = 0;
        if (rowCount % 2 != 0)
            loopCounter = rowCount - 1;
        else
            loopCounter = rowCount;

        //counter>=2
        int index = 0;
        while (index < loopCounter)
        {
            var row = tblProductResult.NewRow();
            var item1 = data[index];
            row["ProductNameOdd"] = item1.ProductName;
            row["CongSuat13Odd"] = item1.CongSuat13.ToString();
            row["DesignQuantityOdd"] = item1.DesignQuantity;
            row["MaxQuantityOdd"] = item1.MaxQuantity;

            var item2 = data[index + 1];
            row["ProductNameEven"] = item2.ProductName;
            row["CongSuat13Even"] = item2.CongSuat13.ToString();
            row["DesignQuantityEven"] = item2.DesignQuantity;
            row["MaxQuantityEven"] = item2.MaxQuantity;
            tblProductResult.Rows.Add(row);

            index = index + 2;
        }

        if (loopCounter < rowCount) //Lấy dòng lẻ cuối cùng
        {
            var row = tblProductResult.NewRow();
            var item = data[loopCounter];
            row["ProductNameOdd"] = item.ProductName;
            row["CongSuat13Odd"] = item.CongSuat13.ToString();
            row["DesignQuantityOdd"] = item.DesignQuantity;
            row["MaxQuantityOdd"] = item.MaxQuantity;

            row["ProductNameEven"] = string.Empty;
            row["CongSuat13Even"] = string.Empty;
            row["DesignQuantityEven"] = string.Empty;
            row["MaxQuantityEven"] = string.Empty;
            tblProductResult.Rows.Add(row);
        }

        return tblProductResult;
    }

    private DataTable GetData133(int ReportId, bool IsPlan, int OrgId)
    {
        ReportModels rp = new ReportModels();
        DataTable tblProductResult = new DataTable();
        tblProductResult.Columns.Add("ProductName", typeof(string));
        tblProductResult.Columns.Add("Measurement", typeof(string));
        tblProductResult.Columns.Add("DesignQuantity", typeof(string));
        tblProductResult.Columns.Add("MaxQuantity", typeof(string));

        var data = (from a in rp.DE_Product
                    join b in rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == true) on a.Id equals b.ProductId into ab
                    from c in ab.DefaultIfEmpty()
                    join d in rp.DE_Measurement on a.MeasurementId equals d.Id
                    where a.EnterpriseId == memVal.OrgId && a.IsProduct == true
                    && a.ProductType13 == ReportKey.ProductKey_133
                    orderby a.ProductName ascending
                    select new
                    {
                        ProductName = a.ProductName,
                        MeasurementName = d.MeasurementName,
                        MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString()),
                        DesignQuantity = (c == null ? string.Empty : c.DesignQuantity.ToString())
                    }).ToList();

        foreach (var item in data)
        {
            var row = tblProductResult.NewRow();
            row["ProductName"] = item.ProductName;
            row["Measurement"] = item.MeasurementName;
            row["DesignQuantity"] = item.DesignQuantity;
            row["MaxQuantity"] = item.MaxQuantity;
            tblProductResult.Rows.Add(row);
        }
        return tblProductResult;
    }
}


