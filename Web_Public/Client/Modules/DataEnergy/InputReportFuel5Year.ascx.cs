﻿using System;
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

public partial class Client_Modules_DataEnergy_InputReportFuel5Year : System.Web.UI.UserControl
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
            GetNangLucSX();
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

                    ucInputPlan5Year.ReportYear = report.Year;
                    ucInputPlan5Year.AllowEdit = AllowEdit;
                    ucInputPlan5Year.ReportId = ReportId;

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
                    if (report.OwnerId != null)
                    {
                        if (report.OwnerId == 0)
                            ltOwner.Text = "Thành phần kinh tế khác";
                        else
                            ltOwner.Text = "Doanh nghiệp nhà nước";
                    }
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
        int _year = Convert.ToInt32(ddlYear.SelectedItem.Text);
        ltReportYear.Text = string.Format("{0} - {1}", _year, _year + 4);
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
            ex.WriteToMergeField("BC_NextYear1", NextYear);
            ex.WriteToMergeField("BC_NextYear2", NextYear);
            ex.WriteToMergeField("BC_NextYear3", NextYear);
            ex.WriteToMergeField("BC_Year1", NextYear);
            ex.WriteToMergeField("BC_Year_1", (iCurrentYear - 1).ToString());
            ex.WriteToMergeField("BC_Year_11", (iCurrentYear - 1).ToString());
            ex.WriteToMergeField("BC_Year_111", (iCurrentYear - 1).ToString());


            //ex.WriteToMergeField("BC_NextYear3", NextYear);
        }
        if (dtinfo.Rows[0]["Responsible"] != DBNull.Value)
        {
            ex.WriteToMergeField("BC_ChiuTrachNhiem", dtinfo.Rows[0]["Responsible"].ToString());
        }
        else
            ex.WriteToMergeField("BC_ChiuTrachNhiem", "");

        //if (dtinfo.Rows[0]["ReportDate"] != DBNull.Value)
        //{
        //    ex.WriteToMergeField("BC_NgayLap", Convert.ToDateTime(dtinfo.Rows[0]["ReportDate"]).ToString("dd/MM/yyyy"));
        //    ex.WriteToMergeField("BC_NgayBC", Convert.ToDateTime(dtinfo.Rows[0]["ReportDate"]).ToString("dd/MM/yyyy"));
        //}
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

        //usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, false);
        usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, true);
        if (usingElectrict != null)
        {
            //Su dung dien 2
            //if (usingElectrict.Quantity > 0)
            //    ex.WriteToMergeField("QuantityResult2", usingElectrict.Quantity.ToString());
            //else
            //    ex.WriteToMergeField("QuantityResult2", "");
            //if (usingElectrict.InstalledCapacity > 0)
            //    ex.WriteToMergeField("InstalledCapacityResult2", usingElectrict.InstalledCapacity.ToString());
            //else
            //    ex.WriteToMergeField("InstalledCapacityResult2", "");
            //if (usingElectrict.Capacity > 0)
            //    ex.WriteToMergeField("CapacityResult2", usingElectrict.Capacity.ToString());
            //else
            //    ex.WriteToMergeField("CapacityResult2", "");
            //if (usingElectrict.BuyCost > 0)
            //    ex.WriteToMergeField("BuyCostResult2", usingElectrict.BuyCost.ToString());
            //else
            //    ex.WriteToMergeField("BuyCostResult2", "");
            //if (usingElectrict.BuyCost > 0 && usingElectrict.Capacity > 0)
            //    ex.WriteToMergeField("BuyPriceResult2", Math.Round((usingElectrict.BuyCost / (usingElectrict.Capacity * 1000)), 0).ToString());
            //else
            //    ex.WriteToMergeField("BuyPriceResult2", "");
            //if (usingElectrict.ProduceQty > 0)
            //    ex.WriteToMergeField("ProduceQtyResult2", usingElectrict.ProduceQty.ToString());
            //else
            //    ex.WriteToMergeField("ProduceQtyResult2", "");
            //if (usingElectrict.Technology != null)
            //    ex.WriteToMergeField("TechnologyResult2", usingElectrict.Technology.ToString());
            //else
            //    ex.WriteToMergeField("TechnologyResult2", "");
            //if (usingElectrict.FuelId > 0)
            //{

            //    Fuel fuel = new Fuel();

            //    fuel = new FuelService().FindByKey(usingElectrict.FuelId);
            //    if (fuel != null)
            //    {
            //        ex.WriteToMergeField("FuelNameResult2", fuel.FuelName);
            //        ex.WriteToMergeField("FuelNameResult", fuel.FuelName);
            //    }
            //    else
            //    {
            //        ex.WriteToMergeField("FuelNameResult2", "");
            //        ex.WriteToMergeField("FuelNameResult", "");
            //    }
            //}
            //else
            //{
            //    ex.WriteToMergeField("FuelNameResult2", "");
            //    ex.WriteToMergeField("FuelNameResult", "");
            //}
            //if (usingElectrict.PriceProduce > 0)
            //    ex.WriteToMergeField("PriceProduceResult2", usingElectrict.PriceProduce.ToString());
            //else
            //    ex.WriteToMergeField("PriceProduceResult2", "");


            //Su dung dien 1
            if (usingElectrict.Capacity > 0)
                ex.WriteToMergeField("QuantityResult", usingElectrict.Capacity.ToString());
            else
                ex.WriteToMergeField("QuantityResult", "");

            if (usingElectrict.InstalledCapacity > 0)
                ex.WriteToMergeField("CapacityResult", usingElectrict.InstalledCapacity.ToString());
            else
                ex.WriteToMergeField("CapacityResult", "");


            //if (usingElectrict.Capacity > 0)
            //    ex.WriteToMergeField("CapacityResult", usingElectrict.Capacity.ToString());
            //else
            //    ex.WriteToMergeField("CapacityResult", "");
            //if (usingElectrict.BuyCost > 0)
            //    ex.WriteToMergeField("BuyCostResult", usingElectrict.BuyCost.ToString());
            //else
            //    ex.WriteToMergeField("BuyCostResult", "");

            //if (usingElectrict.BuyCost > 0 && usingElectrict.Capacity > 0)
            //    ex.WriteToMergeField("BuyPriceResult", Math.Round((usingElectrict.BuyCost / (usingElectrict.Capacity * 1000)), 0).ToString());
            //else
            //    ex.WriteToMergeField("BuyPriceResult", "");
            //if (usingElectrict.ProduceQty > 0)
            //    ex.WriteToMergeField("ProduceQtyResult", usingElectrict.ProduceQty.ToString());
            //else
            //    ex.WriteToMergeField("ProduceQtyResult", "");
            //if (usingElectrict.Technology != null)
            //    ex.WriteToMergeField("TechnologyResult", usingElectrict.Technology.ToString());
            //else
            //    ex.WriteToMergeField("TechnologyResult", "");
            //if (usingElectrict.FuelId > 0)
            //    ex.WriteToMergeField("FuelNameResult", usingElectrict.FuelId.ToString());
            //else
            //    ex.WriteToMergeField("FuelNameResult", "");

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


        //usingElectrict = new UsingElectrict();

        //usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, true);
        //if (usingElectrict != null)
        //{
        //    //Su dung dien 2
        //    if (usingElectrict.Quantity > 0)
        //        ex.WriteToMergeField("QuantityPlan", usingElectrict.Quantity.ToString());
        //    else
        //        ex.WriteToMergeField("QuantityPlan", "");
        //    if (usingElectrict.InstalledCapacity > 0)
        //        ex.WriteToMergeField("InstalledCapacityPlan", usingElectrict.InstalledCapacity.ToString());
        //    else
        //        ex.WriteToMergeField("InstalledCapacityPlan", "");
        //    if (usingElectrict.Capacity > 0)
        //        ex.WriteToMergeField("CapacityPlan", usingElectrict.Capacity.ToString());
        //    else
        //        ex.WriteToMergeField("CapacityPlan", "");
        //    if (usingElectrict.BuyCost > 0)
        //        ex.WriteToMergeField("BuyCostPlan", usingElectrict.BuyCost.ToString());
        //    else
        //        ex.WriteToMergeField("BuyCostPlan", "");

        //    if (usingElectrict.BuyCost > 0 && usingElectrict.Capacity > 0)
        //    {
        //        decimal buypricePlan = Math.Round(usingElectrict.BuyCost / usingElectrict.Capacity, 2);
        //        ex.WriteToMergeField("BuyPricePlan", buypricePlan.ToString());
        //    }
        //    else
        //    {
        //        ex.WriteToMergeField("BuyPricePlan", " ");
        //    }

        //    if (usingElectrict.ProduceQty > 0)
        //        ex.WriteToMergeField("ProduceQtyPlan", usingElectrict.ProduceQty.ToString());
        //    else
        //        ex.WriteToMergeField("ProduceQtyPlan", "");
        //    if (usingElectrict.Technology != null)
        //        ex.WriteToMergeField("TechnologyPlan", usingElectrict.Technology.ToString());
        //    else
        //        ex.WriteToMergeField("TechnologyPlan", "");
        //    if (usingElectrict.FuelId > 0)
        //    {
        //        Fuel fuel = new Fuel();

        //        fuel = new FuelService().FindByKey(usingElectrict.FuelId);
        //        if (fuel != null)
        //        {
        //            ex.WriteToMergeField("FuelNamePlan", fuel.FuelName);

        //        }
        //        else
        //        {
        //            ex.WriteToMergeField("FuelNamePlan", "");

        //        }
        //    }
        //    else
        //    {
        //        ex.WriteToMergeField("FuelNamePlan", "");
        //    }
        //    if (usingElectrict.PriceProduce > 0)
        //        ex.WriteToMergeField("PriceProducePlan", usingElectrict.PriceProduce.ToString());
        //    else
        //        ex.WriteToMergeField("PriceProducePlan", "");
        //}
        //else
        //{
        //    ex.WriteToMergeField("QuantityPlan", "");
        //    ex.WriteToMergeField("InstalledCapacityPlan", "");
        //    ex.WriteToMergeField("CapacityPlan", "");
        //    ex.WriteToMergeField("BuyCostPlan", "");
        //    ex.WriteToMergeField("ProduceQtyPlan", "");
        //    ex.WriteToMergeField("TechnologyPlan", "");
        //    ex.WriteToMergeField("FuelNamePlan", "");
        //    ex.WriteToMergeField("PriceProducePlan", "");
        //    ex.WriteToMergeField("BuyPricePlan", " ");
        //}

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
        ProductCapacityService productCapacityService = new ProductCapacityService();
        DataTable tblProductResult = new DataTable();
        tblProductResult = productCapacityService.GetDataCapacity(ReportId, false);
        //Thêm cột tính lại giá trị tiêu thụ năng lượng theo sp
        tblProductResult.Columns.Add("TTNLTHEOSP", typeof(string));

        ReportModels rp = new ReportModels();
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
                            b.MeasurementName
                        }).ToList();

            string tmp = string.Empty;
            foreach (var item in data)
            {
                tmp += string.Format("{0}: {1}({2})\n", item.FuelName, item.ConsumeQty, item.MeasurementName);
            }

            r["TTNLTHEOSP"] = tmp;
        }

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
        // dsg.Tables.Add(dst); 
        //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
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
        //string temp = "TempReport/Template_5nam" + ddlReportType5.SelectedValue + ".docx";
        string temp = "TempReport/Template_5nam_new" + ddlReportType5.SelectedValue + ".docx";
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
            ex.WriteToMergeField("BC_TenCoSoX", or.Title);
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
            int NamKT = NamBD + 4;
            ex.WriteToMergeField("BC_NamBD", NamBD.ToString());
            ex.WriteToMergeField("BC_NamKT", NamKT.ToString());
            ex.WriteToMergeField("BC_NamBD1", NamBD.ToString());
            //ex.WriteToMergeField("BC_NamKT1", NamKT.ToString());
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
            //ex.WriteToMergeField("BC_NgayBC", Convert.ToDateTime(dtinfo.Rows[0]["ReportDate"]).ToString("dd/MM/yyyy"));
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
        ReportModels rp = new ReportModels();
        int _baseReportYear = ReportYear - 1;
        var oldData = rp.DE_ReportFuel.FirstOrDefault(o => o.Year == ReportYear && o.EnterpriseId == memVal.OrgId && o.IsFiveYear == false && o.ReportType == ReportKey.PLAN);

        if (oldData != null)
            tblProductResult = productCapacityService.GetDataCapacity(oldData.Id, false);

        //tblProductResult = productCapacityService.GetDataCapacity(ReportId, false);


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

        DataTable dtFiveYear = GetKQThucHienKeHoach();
        int colcount = 1;
        for (var j = ReportYear - 5; j < ReportYear; j++)
        {
            dtFiveYear.Columns[j.ToString()].ColumnName = string.Format("Nam{0}", colcount);
            colcount++;
        }
        dtFiveYear.AcceptChanges();

        dshientai.Tables.Add(dtFiveYear);
        dshientai.Tables[4].TableName = "tbl5";
        dshientai.Merge(dthientai);

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
                    Response.Redirect(ResolveUrl("~") + "doanh-nghiep-5-nam.aspx");
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

    DataTable GetKQThucHienKeHoach()
    {
        StringBuilder sb = new StringBuilder();
        DataTable tbl = new DataTable();
        tbl.Columns.Add("Year", typeof(string));
        for (int i = ReportYear - 5; i < ReportYear; i++)
            tbl.Columns.Add(i.ToString(), typeof(string));
        var firstRow = tbl.NewRow();

        foreach (DataColumn col in tbl.Columns)
        {
            firstRow["Year"] = "Năm";
            for (int i = ReportYear - 5; i < ReportYear; i++)
                firstRow[i.ToString()] = i;
        }


        DataTable dtSolution = new DataTable();
        int _startPlanYear = ReportYear - 4;
        ReportModels rp = new ReportModels();
        var Solution5Year = (from a in rp.DE_GiaiPhap
                             join b in rp.DE_PlanTKNL on a.Id equals b.IdGiaPhap
                             join c in rp.DE_ReportFuel on b.IdPlan equals c.Id
                             where c.EnterpriseId == memVal.OrgId && c.ReportType == ReportKey.PLAN && b.IsPlan == true
                             && c.Year >= _startPlanYear && c.Year <= ReportYear
                             orderby c.Year
                             select new
                             {
                                 DE_GiaiPhap = a,
                                 DE_PlanTKNL = b,
                                 DE_ReportFuel = c
                             }).ToList();

        int _startResultYear = ReportYear - 5;

        var Result5Year = (from a in rp.DE_GiaiPhap
                           join b in rp.DE_PlanTKNL on a.Id equals b.IdGiaPhap
                           join c in rp.DE_ReportFuel on b.IdPlan equals c.Id
                           where c.EnterpriseId == memVal.OrgId && c.ReportType == ReportKey.PLAN && b.IsPlan == false
                           && c.Year >= _startResultYear && c.Year <= ReportYear && a.IsDelete == false
                           orderby c.Year
                           select new
                           {
                               DE_GiaiPhap = a,
                               DE_PlanTKNL = b,
                               DE_ReportFuel = c
                           }).ToList();

        var ListSol = Solution5Year.Select(o => new { o.DE_GiaiPhap.Id, o.DE_GiaiPhap.TenGiaiPhap }).Distinct().ToList();

        int _counter = 1;

        foreach (var sol in ListSol)
        {
            var plan = Solution5Year.Where(o => o.DE_GiaiPhap.Id == sol.Id);
            var result = Result5Year.Where(o => o.DE_GiaiPhap.Id == sol.Id);

            var row1 = tbl.NewRow();
            row1["Year"] = string.Format("Giải pháp {0}: {1}", _counter, sol.TenGiaiPhap);


            var row2 = tbl.NewRow();
            row2["Year"] = "Mức tiết kiệm năng lượng - Dự kiến theo kế hoạch (kWh)";

            var row3 = tbl.NewRow();
            row3["Year"] = "Mức tiết kiệm năng lượng - Thực tế đạt được	(kWh)";

            var row4 = tbl.NewRow();
            row4["Year"] = "Mức tiết kiệm năng lượng - Dự kiến theo kế hoạch (%)";

            var row5 = tbl.NewRow();
            row5["Year"] = "Mức tiết kiệm năng lượng - Thực tế đạt được	(%)";

            var row6 = tbl.NewRow();
            row6["Year"] = "Mức tiết kiệm chi phí - Dự kiến theo kế hoạch (Triệu đồng)";

            var row7 = tbl.NewRow();
            row7["Year"] = "Mức tiết kiệm chi phí - Thực tế đạt được (Triệu đồng)";

            var row8 = tbl.NewRow();
            row8["Year"] = "Chi phí - Dự kiến theo kế họach	(Triệu đồng)";

            var row9 = tbl.NewRow();
            row9["Year"] = "Chi phí - Thực tế thực hiện (Triệu đồng)";

            tbl.Rows.Add(row1);
            tbl.Rows.Add(row2);
            tbl.Rows.Add(row3);
            tbl.Rows.Add(row4);
            tbl.Rows.Add(row5);
            tbl.Rows.Add(row6);
            tbl.Rows.Add(row7);
            tbl.Rows.Add(row8);
            tbl.Rows.Add(row9);


            //Mức tiết kiệm năng lượng - Dự kiến theo kế hoạch (kWh)
            foreach (var p in plan)
            {
                foreach (DataColumn col in tbl.Columns)
                    if ((p.DE_ReportFuel.Year).ToString() == col.ColumnName)
                    {
                        row2[col.ColumnName] = p.DE_PlanTKNL.MucTietKiemDuKien != null ? p.DE_PlanTKNL.MucTietKiemDuKien : "";
                        row4[col.ColumnName] = p.DE_PlanTKNL.TuongDuong != null ? p.DE_PlanTKNL.TuongDuong : "";
                        row6[col.ColumnName] = p.DE_PlanTKNL.TKCPDuKien != null ? p.DE_PlanTKNL.TKCPDuKien : "";
                        row8[col.ColumnName] = p.DE_PlanTKNL.ChiPhiDuKien != null ? p.DE_PlanTKNL.ChiPhiDuKien : "";
                    }

            }

            //Mức tiết kiệm năng lượng - Thực tế đạt được	(kWh)
            foreach (var re in result)
            {
                foreach (DataColumn col in tbl.Columns)
                    if ((re.DE_ReportFuel.Year - 1).ToString() == col.ColumnName)
                    {
                        row3[col.ColumnName] = re.DE_PlanTKNL.MucTKThucTe != null ? re.DE_PlanTKNL.MucTKThucTe : "";
                        row5[col.ColumnName] = re.DE_PlanTKNL.TuongDuongTT != null ? re.DE_PlanTKNL.TuongDuongTT : "";
                        row7[col.ColumnName] = re.DE_PlanTKNL.MucTKCPThucTe != null ? re.DE_PlanTKNL.MucTKCPThucTe : "";
                        row9[col.ColumnName] = re.DE_PlanTKNL.CPThucTe != null ? re.DE_PlanTKNL.CPThucTe : "";
                    }

            }

            _counter++;
        }
        DataRow fRow = tbl.NewRow();
        fRow["Year"] = "Năm";
        for (int k = ReportYear - 5; k < ReportYear; k++)
            fRow[k.ToString()] = k.ToString();
        tbl.Rows.InsertAt(fRow, 0);
        return tbl;
    }

    private void GetNangLucSX()
    {
        ReportModels rp = new ReportModels();
        var en = rp.DE_Enterprise.FirstOrDefault(o => o.Id == memVal.OrgId);
        var data = (from a in rp.DE_Enterprise
                    join b in rp.DE_BaocaoLinhVuc on a.ReportTemplate equals b.AutoId
                    where a.Id == memVal.OrgId
                    select b).FirstOrDefault();
        var loadTemp = rp.DE_BaocaoLinhVuc.FirstOrDefault(x => x.PhanLoaiBC == ReportKey.PLAN5 && x.IdLinhVuc == data.IdLinhVuc);
        string BCTemp = loadTemp.TemplateBC.ToUpper();
        //////////////////////////////////
        switch (BCTemp)
        {
            case "BC2.1.DOCX":
                ltRp5_NangLucSXNamCoSo.Text = CreateReport21();
                break;
            case "BC2.2.DOCX":
                ltRp5_NangLucSXNamCoSo.Text = CreateReport22();
                break;
            case "BC2.3.DOCX":
                ltRp5_NangLucSXNamCoSo.Text = CreateReport23();
                break;
            case "BC2.4.DOCX":
                ltRp5_NangLucSXNamCoSo.Text = CreateReport24();
                break;
            case "BC2.5.DOCX":
                ltRp5_NangLucSXNamCoSo.Text = CreateReport25();
                break;
            case "BC2.6.DOCX":
                ltRp5_NangLucSXNamCoSo.Text = CreateReport26();
                break;

        }
    }

    private string CreateReport21()
    {
        try
        {
            string table = string.Empty;
            table += "<table class='table table-bordered table-hover mbn' width='100%'>";
            table += "<thead>";
            table += "<tr class='primary fs12'>";
            table += "<th>Tên sản phẩm</th>";
            table += "<th style='width: 10%'>Đơn vị đo</th>";
            table += "<th style='width: 20%'>Theo thiết kế</th>";
            table += "<th style='width: 20%'>Mức sản xuất hiện tại</th>";
            table += "<th style='width: 20%'>Tiêu thụ năng lượng theo sản phẩm</th>";
            table += "<th style='width: 20%'>Doanh thu</th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tbody>";

            ReportModels rp = new ReportModels();
            //Lấy dữ liệu báo cáo năm hiện tại
            var dataCurrentYear = rp.DE_ReportFuel.FirstOrDefault(x => x.EnterpriseId == memVal.OrgId && x.Year == ReportYear
                                                                    && x.IsFiveYear == false && x.ReportType == ReportKey.PLAN);
            if (dataCurrentYear == null)
            {
                return "Chưa cập nhật dữ liệu báo cáo kế hoạch năm";
            }

            ProductCapacityService productCapacityService = new ProductCapacityService();
            DataTable tbl = new DataTable();
            tbl = productCapacityService.GetDataCapacity(dataCurrentYear.Id, false);

            //Load data
            table += "";
            foreach (DataRow item in tbl.Rows)
            {
                table += "<tr>";
                table += string.Format("<td>{0}</td>", item["ProductName"].ToString());
                table += string.Format("<td>{0}</td>", item["Measurement"].ToString());
                table += string.Format("<td>{0}</td>", item["DesignQuantity"].ToString());
                table += string.Format("<td>{0}</td>", item["MaxQuantity"].ToString());
                table += string.Format("<td>{0}</td>", item["DoanhThuTheoSP"].ToString());
                table += "</tr>";
            }

            table += "</tbody>";
            table += "</table>";
            return table;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private string CreateReport22()
    {
        try
        {
            string table = string.Empty;
            table += "<div class='margin-bottom-10'>";
            table += "<table class='table table-bordered table-hover mbn' width='100%'>";
            table += "<thead>";
            table += "<tr class='primary fs12'>";
            table += "<th>Nhiên liệu sử dụng</th>";
            table += "<th style='width: 20%'>Loại nhiên liệu</th>";
            table += "<th style='width: 20%'>Khối lượng SD/năm</th>";
            table += "<th style='width: 20%'>Nhiệt trị thấp (kJ/kg)</th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tbody>";

            ReportModels rp = new ReportModels();
            //Lấy dữ liệu báo cáo năm hiện tại
            var dataCurrentYear = rp.DE_ReportFuel.FirstOrDefault(x => x.EnterpriseId == memVal.OrgId && x.Year == ReportYear
                                                                    && x.IsFiveYear == false && x.ReportType == ReportKey.PLAN);
            if (dataCurrentYear == null)
            {
                return "Chưa cập nhật dữ liệu báo cáo kế hoạch năm";
            }

            var data = (from a in rp.DE_Product
                        join b in rp.DE_ProductCapacity.Where(x => x.ReportId == dataCurrentYear.Id && x.IsPlan == false) on a.Id equals b.ProductId into ab
                        from c in ab.DefaultIfEmpty()
                        join d in rp.DE_GroupFuel on a.GroupFuel equals d.Id
                        where a.EnterpriseId == memVal.OrgId && a.IsProduct == false
                        && a.ProductType13 == ReportKey.ProductKey_131
                        orderby a.ProductName ascending
                        select new
                        {
                            ProductId = a.Id,
                            ProductName = a.ProductName,
                            NhietTriThap = a.NhietTriThap == null ? 0 : a.NhietTriThap,
                            GroupFuelName = d.Title,
                            MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                        }).ToList();

            //Load data
            table += "";
            foreach (var item in data)
            {
                table += "<tr>";
                table += string.Format("<td>{0}</td>", item.ProductName);
                table += string.Format("<td>{0}</td>", item.GroupFuelName);
                table += string.Format("<td>{0}</td>", item.MaxQuantity);
                table += string.Format("<td>{0}</td>", item.NhietTriThap);
                table += "</tr>";
            }

            table += "</tbody>";
            table += "</table>";
            table += "</div>";

            //table 2
            table += "<div class='margin-bottom-10'>";
            table += "<table class='table table-bordered table-hover mbn' width='100%'>";
            table += "<thead>";
            table += "<tr class='primary fs12'>";
            table += "<th>Số tổ máy</th>";
            table += "<th style='width: 20%'>Công suất(MW)</th>";
            table += "<th style='width: 20%'>Hiệu suất thiết kế</th>";
            table += "<th style='width: 20%'>Hiệu suất vận hành trung bình</th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tbody>";

            //Load data
            table += "";
            var data1 = (from a in rp.DE_Product
                         join b in rp.DE_ProductCapacity.Where(x => x.ReportId == dataCurrentYear.Id && x.IsPlan == false) on a.Id equals b.ProductId into ab
                         from c in ab.DefaultIfEmpty()
                         where a.EnterpriseId == memVal.OrgId
                         && a.IsProduct == true
                         && a.ProductType13 == ReportKey.ProductKey_132
                         orderby a.ProductName ascending
                         select new
                         {
                             ProductId = a.Id,
                             ProductName = a.ProductName,
                             CongSuat13 = (c == null ? string.Empty : c.CongSuat13.ToString()),
                             DesignQuantity = (c == null ? string.Empty : c.DesignQuantity.ToString()),
                             MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                         }).ToList();

            foreach (var item in data1)
            {
                table += "<tr>";
                table += string.Format("<td>{0}</td>", item.ProductName);
                table += string.Format("<td>{0}</td>", item.CongSuat13);
                table += string.Format("<td>{0}</td>", item.DesignQuantity);
                table += string.Format("<td>{0}</td>", item.MaxQuantity);
                table += "</tr>";
            }

            table += "</tbody>";
            table += "</table>";
            table += "</div>";


            return table;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string CreateReport23()
    {
        try
        {
            string table = string.Empty;
            table += "<table class='table table-bordered table-hover mbn' width='100%'>";
            table += "<thead>";
            table += "<tr class='primary fs12'>";
            table += "<th>Thông tin</th>";
            table += "<th style='width: 15%'></th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tbody>";

            ReportModels rp = new ReportModels();
            //Lấy dữ liệu báo cáo năm hiện tại
            var dataCurrentYear = rp.DE_ReportFuel.FirstOrDefault(x => x.EnterpriseId == memVal.OrgId && x.Year == ReportYear
                                                                    && x.IsFiveYear == false && x.ReportType == ReportKey.PLAN);
            if (dataCurrentYear == null)
            {
                return "Chưa cập nhật dữ liệu báo cáo kế hoạch năm";
            }

            var data = (from a in rp.DE_Product
                        join b in rp.DE_ProductCapacity.Where(x => x.ReportId == dataCurrentYear.Id && x.IsPlan == false) on a.Id equals b.ProductId into ab
                        from c in ab.DefaultIfEmpty()
                        where a.EnterpriseId == memVal.OrgId
                        orderby a.ProductName ascending
                        select new
                        {
                            ProductId = a.Id,
                            ProductName = a.ProductName,
                            Measurement = a.Measurement != null ? a.Measurement : string.Empty,
                            DataReport1415 = c.DataReport1415,
                            MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                        }).ToList();

            //Load data
            table += "";
            foreach (var item in data)
            {
                table += "<tr>";
                table += string.Format("<td>{0}</td>", item.ProductName);
                table += string.Format("<td>{0}{1}</td>", item.DataReport1415, item.Measurement);
                table += "</tr>";
            }

            table += "</tbody>";
            table += "</table>";
            return table;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private string CreateReport24()
    {
        try
        {
            string table = string.Empty;
            table += "<table class='table table-bordered table-hover mbn' width='100%'>";
            table += "<thead>";
            table += "<tr class='primary fs12'>";
            table += "<th>Loại phương tiện</th>";
            table += "<th style='width: 15%'>Số lượng(chiếc)</th>";
            table += "<th style='width: 15%'>Loại nhiên liệu</th>";
            table += "<th style='width: 15%'>H.khách x km</th>";
            table += "<th style='width: 15%'>Tấn x km</th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tbody>";

            ReportModels rp = new ReportModels();
            //Lấy dữ liệu báo cáo năm hiện tại
            var dataCurrentYear = rp.DE_ReportFuel.FirstOrDefault(x => x.EnterpriseId == memVal.OrgId && x.Year == ReportYear
                                                                    && x.IsFiveYear == false && x.ReportType == ReportKey.PLAN);
            if (dataCurrentYear == null)
            {
                return "Chưa cập nhật dữ liệu báo cáo kế hoạch năm";
            }

            var data = (from a in rp.DE_Product
                        join b in rp.DE_ProductCapacity.Where(x => x.ReportId == dataCurrentYear.Id && x.IsPlan == false) on a.Id equals b.ProductId into ab
                        from c in ab.DefaultIfEmpty()
                        join d in rp.DE_Fuel on a.FuelId equals d.Id
                        where a.EnterpriseId == memVal.OrgId
                        orderby a.ProductName ascending
                        select new
                        {
                            ProductId = a.Id,
                            ProductName = a.ProductName,
                            Measurement = a.Measurement,
                            FuelName = d.FuelName,
                            MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString()),
                            NangLucVanChuyenNguoi = (c == null ? string.Empty : c.NangLucVanChuyenNguoi.ToString()),
                            NangLucVanChuyenHang = (c == null ? string.Empty : c.NangLucVanChuyenHang.ToString())
                        }).ToList();

            //Load data
            table += "";
            foreach (var item in data)
            {
                table += "<tr>";
                table += string.Format("<td>{0}</td>", item.ProductName);
                table += string.Format("<td>{0}</td>", item.Measurement);
                table += string.Format("<td>{0}</td>", item.FuelName);
                table += string.Format("<td>{0}</td>", item.NangLucVanChuyenNguoi);
                table += string.Format("<td>{0}</td>", item.NangLucVanChuyenHang);
                
                table += "</tr>";
            }

            table += "</tbody>";
            table += "</table>";
            return table;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private string CreateReport25()
    {
        try
        {
            string table = string.Empty;
            table += "<table class='table table-bordered table-hover mbn' width='100%'>";
            table += "<thead>";
            table += "<tr class='primary fs12'>";
            table += "<th>Loại phương tiện</th>";
            table += "<th style='width: 20%'>Số lượng thực tế(chiếc)</th>";
            table += "<th style='width: 20%'>Loại nhiên liệu/năng lượng</th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tbody>";

            ReportModels rp = new ReportModels();
            //Lấy dữ liệu báo cáo năm hiện tại
            var dataCurrentYear = rp.DE_ReportFuel.FirstOrDefault(x => x.EnterpriseId == memVal.OrgId && x.Year == ReportYear
                                                                    && x.IsFiveYear == false && x.ReportType == ReportKey.PLAN);
            if (dataCurrentYear == null)
            {
                return "Chưa cập nhật dữ liệu báo cáo kế hoạch năm";
            }

            var data = (from a in rp.DE_Product
                        join b in rp.DE_ProductCapacity.Where(x => x.ReportId == dataCurrentYear.Id && x.IsPlan == false) on a.Id equals b.ProductId into ab
                        from c in ab.DefaultIfEmpty()
                        join d in rp.DE_Fuel on a.FuelId equals d.Id
                        where a.EnterpriseId == memVal.OrgId
                        orderby a.ProductName ascending
                        select new
                        {
                            ProductId = a.Id,
                            ProductName = a.ProductName,
                            Measurement = a.Measurement,
                            FuelName = d.FuelName,
                            DesignQuantity = (c == null ? string.Empty : c.DesignQuantity.ToString()),
                            MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                        }).ToList();

            //Load data
            table += "";
            foreach (var item in data)
            {
                table += "<tr>";
                table += string.Format("<td>{0}</td>", item.ProductName);
                table += string.Format("<td>{0}</td>", item.MaxQuantity);
                table += string.Format("<td>{0}</td>", item.FuelName);
                table += "</tr>";
            }

            table += "</tbody>";
            table += "</table>";
            return table;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private string CreateReport26()
    {
        try
        {
            string table = string.Empty;
            table += "<table class='table table-bordered table-hover mbn' width='100%'>";
            table += "<thead>";
            table += "<tr class='primary fs12'>";
            table += "<th>Hạng mục</th>";
            table += "<th style='width: 20%'>Đơn vị đo</th>";
            table += "<th style='width: 20%'>Số lượng</th>";
            table += "</tr>";
            table += "</thead>";
            table += "<tbody>";

            ReportModels rp = new ReportModels();
            //Lấy dữ liệu báo cáo năm hiện tại
            var dataCurrentYear = rp.DE_ReportFuel.FirstOrDefault(x => x.EnterpriseId == memVal.OrgId && x.Year == ReportYear
                                                                    && x.IsFiveYear == false && x.ReportType == ReportKey.PLAN);
            if (dataCurrentYear == null)
            {
                return "Chưa cập nhật dữ liệu báo cáo kế hoạch năm";
            }

            var data = (from a in rp.DE_Product
                        join b in rp.DE_ProductCapacity.Where(x => x.ReportId == dataCurrentYear.Id && x.IsPlan == false) on a.Id equals b.ProductId into ab
                        from c in ab.DefaultIfEmpty()
                        where a.EnterpriseId == memVal.OrgId
                        orderby a.ProductOrder ascending
                        select new
                        {
                            ProductId = a.Id,
                            ProductName = a.ProductName,
                            Measurement = a.Measurement,
                            MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                        }).ToList();

            //Load data
            table += "";
            foreach (var item in data)
            {
                table += "<tr>";
                table += string.Format("<td>{0}</td>", item.ProductName);
                table += string.Format("<td>{0}</td>", item.Measurement);
                table += string.Format("<td>{0}</td>", item.MaxQuantity);
                table += "</tr>";
            }

            table += "</tbody>";
            table += "</table>";
            return table;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}





