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

    protected decimal TotalCO2
    {
        get
        {
            if (ViewState["TotalCO2"] != null)
                return Convert.ToDecimal(ViewState["TotalCO2"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TotalCO2"] = value;
        }
    }
    protected decimal TotalTOE
    {
        get
        {
            if (ViewState["TotalTOE"] != null)
                return Convert.ToDecimal(ViewState["TotalTOE"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TotalTOE"] = value;
        }
    }
    protected decimal TotalCO2S
    {
        get
        {
            if (ViewState["TotalCO2S"] != null)
                return Convert.ToDecimal(ViewState["TotalCO2S"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TotalCO2S"] = value;
        }
    }
    protected decimal TotalTOES
    {
        get
        {
            if (ViewState["TotalTOES"] != null)
                return Convert.ToDecimal(ViewState["TotalTOES"].ToString());
            else
                return 0;
        }
        set
        {
            ViewState["TotalTOES"] = value;
        }
    }
    protected string DataTOE
    {
        get
        {
            if (ViewState["DataTOE"] != null)
                return ViewState["DataTOE"].ToString();
            else
                return "";
        }
        set
        {
            ViewState["DataTOE"] = value;
        }
    }
    protected string DataSaveTOE
    {
        get
        {
            if (ViewState["DataSaveTOE"] != null)
                return ViewState["DataSaveTOE"].ToString();
            else
                return "";
        }
        set
        {
            ViewState["DataSaveTOE"] = value;
        }
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
                BindOtherConsume();
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

                    ucElectrictSystem.ReportId = ReportId;

                    ucAuditSolution.ReportYear = report.AuditYear;

                    ucAuditSolution.ReportId = ReportId;

                    ucAuditProduct.ReportYear = report.AuditYear;

                    ucAuditProduct.ReportId = ReportId;

                    ucAuditOperationArea.ReportYear = report.AuditYear;

                    ucAuditOperationArea.ReportId = ReportId;

                    ucAuditDevice.ReportYear = report.AuditYear;

                    ucAuditDevice.ReportId = ReportId;
                    
                    ucEnergyConsume.ReportYear = report.AuditYear;

                    ucEnergyConsume.ReportId = ReportId;

                    ucEnergyQuota.ReportYear = report.AuditYear;

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

            }
        }
    }
    void BindOtherConsume()
    {
        DataSet ds = new DataSet();
        ds = new AuditReportService().GetTOEByAuditReport(ReportId);
        TotalCO2 = ds.Tables[0].Select().Sum(p => Convert.ToDecimal(p["NoCO2"]));        
        ltTotaCO2.Text = Tool.ConvertDecimalToString(TotalCO2, 2);
        TotalTOE = ds.Tables[0].Select().Sum(p => Convert.ToDecimal(p["NoTOE"]));
        ltTotalTOE.Text = Tool.ConvertDecimalToString(TotalTOE, 2);
        rptFuelConsume.DataSource = ds.Tables[0];
        rptFuelConsume.DataBind();

        TotalCO2S = ds.Tables[1].Select().Sum(p => Convert.ToDecimal(p["NoCO2"]));
        
        ltTotalCO2S.Text = Tool.ConvertDecimalToString(TotalCO2S, 2);
        TotalTOES = ds.Tables[1].Select().Sum(p => Convert.ToDecimal(p["NoTOE"]));

        ltTotalTOES.Text = Tool.ConvertDecimalToString(TotalTOES, 2);
        rptSaveFuel.DataSource = ds.Tables[1];
        rptSaveFuel.DataBind();
        if (TotalTOE > 0)
            ltRateSave.Text = (Math.Round((TotalTOES * 100) / TotalTOE, 1)) + "%";
        else
            ltRateSave.Text = Math.Round((TotalTOES * 100), 1).ToString()+"%";
    
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

        }
    }
    protected void rptFuelConsume_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                DataTOE = DataTOE + "['" + item["FuelName"] + "', " + Math.Round(Convert.ToDecimal(item["NoTOE"]), 2).ToString().Replace(',', '.') + "],";

            }
        }
    }

    protected void rptSaveFuel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView item = (DataRowView)e.Item.DataItem;
            if (item != null)
            {
                DataSaveTOE = DataSaveTOE + "['" + item["FuelName"] + "', " + Math.Round(Convert.ToDecimal(item["NoTOE"]), 2).ToString().Replace(',', '.') + "],";

            }
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
