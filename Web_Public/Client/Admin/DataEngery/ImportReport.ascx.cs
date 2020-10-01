using System;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BSO;
using ETO;
using ePower.DE.Domain;
using ePower.DE.Service;
using PR.Domain;
using PR.Service;
using System.Data.OleDb;
using System.IO;
using log4net;

public partial class Client_Admin_DataEnergy_ImportReport : System.Web.UI.UserControl
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Client_Admin_DataEnergy_ImportReport));
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindOrg();
        }
    }
    void BindOrg()
    {
        IList<Organization> list = new List<Organization>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Organization_All))
        {
            list = new OrganizationService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Organization_All, list);
        }
        else
            list = (IList<Organization>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Organization_All);
        var listSearch = from o in list orderby o.Title ascending select o;
        ddlDonVi.DataSource = listSearch;
        ddlDonVi.DataTextField = "Title";
        ddlDonVi.DataValueField = "Id";
        ddlDonVi.DataBind();
        ddlDonVi.Items.Insert(0, new ListItem("---Chọn---", ""));
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        lterror.Text = "";

        if (flReport.HasFile)
        {
            string strext = Path.GetExtension(flReport.PostedFile.FileName).Substring(1);
            if (strext == "xls" || strext == "xlsx")
            {
                string fullfilename = "~/UserFile/" + flReport.FileName;
                if (File.Exists(Server.MapPath(fullfilename)))
                {
                    lterror.Text = "File đã tồn tại, vui lòng đổi tên khác";
                    return;
                }
                flReport.PostedFile.SaveAs(Server.MapPath(fullfilename));
                if (File.Exists(Server.MapPath(fullfilename)))
                {
                    log.Info("File: " + flReport.FileName);
                    DataTable dt = new DataTable();
                    string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", Server.MapPath(fullfilename));
                    string query = String.Format("select * from [{0}$]", "Sheet1");
                    SecurityBSO securityBSO = new SecurityBSO();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);

                    DataTable myTable = dataSet.Tables[0];
                    EnterpriseService comBSO = new EnterpriseService();
                    int rowi = 0;
                    foreach (DataRow drow in myTable.Rows)
                    {
                        rowi++;
                        log.Info("Dong thu: " + rowi);


                        try
                        {
                            ReportTemp2014 temp = new ReportTemp2014();
                            Enterprise enter = new Enterprise();
                            int eId = 0;
                            enter.Title = drow["Ten_DN"].ToString();
                            temp.Title = enter.Title;
                            log.Info("Doanh nghiep: " + enter.Title);
                            enter.OrganizationId = Convert.ToInt32(drow["SCT_ID"]);
                            temp.OrgId = enter.OrganizationId;
                            if (drow["DiaChi"] != DBNull.Value)
                            {
                                enter.Address = drow["DiaChi"].ToString();
                                temp.Address = enter.Address;
                            }
                            if (drow["LinhVuc_Id"] != DBNull.Value && drow["LinhVuc_Id"].ToString() != "")
                            {
                                temp.AreaId = Convert.ToInt32(drow["LinhVuc_Id"]);
                                enter.AreaId = temp.AreaId;
                            }
                            enter.ProvinceId = Convert.ToInt32(drow["TinhTP_ID"]);
                            enter.ManProvinceId = enter.ProvinceId;
                            enter.OrganizationId = Convert.ToInt32(drow["SCT_ID"]);
                            if (drow["Ma_DN"] != DBNull.Value && drow["Ma_DN"].ToString().Trim() != "")
                            {
                                eId = Convert.ToInt32(drow["Ma_DN"]);
                                //enter = comBSO.FindByKey(eId);

                            }
                            else
                            {

                                enter.ActiveYear = 2015;
                                enter.CustomerCode = "";
                                enter.TaxCode = "";
                                if (drow["PhanNganh"] != DBNull.Value && drow["PhanNganh"].ToString() != "")
                                {
                                    DataTable dtSub = new AreaService().getAreaByName(drow["PhanNganh"].ToString());
                                    if (dtSub != null && dtSub.Rows.Count > 0)
                                    {
                                        enter.SubAreaId = Convert.ToInt32(dtSub.Rows[0]["Id"]);
                                        temp.SubAreaId = enter.SubAreaId;
                                    }
                                    else
                                    {
                                        Area sub = new Area();
                                        sub.AreaName = drow["PhanNganh"].ToString();
                                        sub.ParentId = enter.AreaId;
                                        sub.IsStatus = 1;
                                        sub.SortOrder = 0;
                                        int subId = new AreaService().Insert(sub);
                                        temp.SubAreaId = subId;
                                        enter.SubAreaId = subId;
                                    }
                                    enter.Info = drow["PhanNganh"].ToString();
                                    temp.SubAreaName = drow["PhanNganh"].ToString();
                                }


                                eId = comBSO.Insert(enter);//Them doanh  nghiep
                                if (eId > 0)
                                {
                                    Organization org = new OrganizationService().FindByKey(enter.OrganizationId);
                                    //Tao tai khoan doanh nghiep
                                    Utils objUtil = new Utils();
                                    MemberService memberService = new MemberService();
                                    int STT = 0;
                                    STT = new EnterpriseService().GetNoAccount(enter.OrganizationId);
                                    STT++;
                                    ePower.DE.Domain.Member member = new ePower.DE.Domain.Member();
                                    member.EnterpriseId = eId;
                                    member.IsDelete = false;
                                    member.AccountName = "dn." + Utils.UCS2Convert(org.Title).Replace(" ", "").Replace("-", "").ToLower() + "." + STT.ToString("000");
                                    member.Password = securityBSO.EncPwd("abc123");
                                    int mId = memberService.Insert(member);
                                    if (mId < 0)
                                        log.Info("Khong tao duoc tai khoan");
                                }
                                else
                                {
                                    log.Info("Khong tao duoc DN");
                                }
                            }
                            if (eId > 0)
                            {
                                ReportFuel report = new ReportFuel();
                                ReportFuelService reportService = new ReportFuelService();
                                report.EnterpriseId = eId;
                                report.OrganizationId = enter.OrganizationId;
                                report.ReportDate = DateTime.Now;
                                report.CompanyName = enter.Title;
                                report.Address = enter.Address;
                                report.ApprovedSatus = true;
                                report.AprovedDate = DateTime.Now;
                                report.AreaId = enter.AreaId;
                                report.ConfirmedDate = DateTime.Now;
                                report.Created = DateTime.Now;
                                report.DistrictId = enter.DistrictId;
                                report.Email = enter.Email;
                                report.Fax = enter.Fax;
                                report.IsFiveYear = false;
                                report.IsDelete = false;
                                report.Phone = enter.Phone;
                                report.ReportDate = DateTime.Now;
                                report.SendSatus = 1;
                                report.Year = 2018;

                                report.SubAreaId = enter.SubAreaId;
                                report.Year = Convert.ToInt32(txtPlanYear.Text.Trim());
                                temp.EnterpriseId = eId;
                                int reportId = reportService.Insert(report);
                                if (reportId > 0)
                                {
                                    ReportFuelDetailService serviceDetail = new ReportFuelDetailService();
                                    ReportFuelDetail detail = new ReportFuelDetail();
                                    int detailid = 0;
                                    if (drow["Dien_kWh"] != DBNull.Value && drow["Dien_kWh"].ToString().Trim() != "")
                                    {
                                        temp.Dien_kWh = drow["Dien_kWh"].ToString();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 1;
                                        detail.MeasurementId = 1;
                                        detail.No_RateTOE = 0.0001543m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["Dien_kWh"] != DBNull.Value && drow["Dien_kWh"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["Dien_kWh"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them dien loi");
                                    }

                                    if (drow["ThanDa_Tan"] != DBNull.Value && drow["ThanDa_Tan"].ToString().Trim() != "")
                                    {
                                        detail = new ReportFuelDetail();
                                        temp.Than_Tan = drow["ThanDa_Tan"].ToString();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 2;
                                        detail.MeasurementId = 2;
                                        detail.No_RateTOE = 0.7m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["ThanDa_Tan"] != DBNull.Value && drow["ThanDa_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["ThanDa_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;

                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them than da_tan loi");
                                    }
                                    if (drow["Than12_Tan"] != DBNull.Value && drow["Than12_Tan"].ToString().Trim() != "")
                                    {
                                        detail = new ReportFuelDetail();
                                        temp.Than_Tan = drow["Than12_Tan"].ToString();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 3;
                                        detail.MeasurementId = 2;
                                        detail.No_RateTOE = 0.7m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["Than12_Tan"] != DBNull.Value && drow["Than12_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["Than12_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them than 12 loi");
                                    }
                                    if (drow["Than34_Tan"] != DBNull.Value && drow["Than34_Tan"].ToString().Trim() != "")
                                    {
                                        detail = new ReportFuelDetail();
                                        temp.Than_Tan = drow["Than34_Tan"].ToString();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 4;
                                        detail.MeasurementId = 2;
                                        detail.No_RateTOE = 0.6m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["Than34_Tan"] != DBNull.Value && drow["Than34_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["Than34_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them than34 loi");
                                    }
                                    if (drow["Than56_Tan"] != DBNull.Value && drow["Than56_Tan"].ToString().Trim() != "")
                                    {
                                        detail = new ReportFuelDetail();
                                        temp.Than_Tan = drow["Than56_Tan"].ToString();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 5;
                                        detail.MeasurementId = 2;
                                        detail.No_RateTOE = 0.5m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["Than56_Tan"] != DBNull.Value && drow["Than56_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["Than56_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them than56 loi");
                                    }
                                    if (drow["DO_Tan"] != DBNull.Value && drow["DO_Tan"].ToString().Trim() != "")
                                    {
                                        detail = new ReportFuelDetail();
                                        temp.DO_Tan = drow["DO_Tan"].ToString();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 6;
                                        detail.MeasurementId = 2;
                                        detail.No_RateTOE = 1.02m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["DO_Tan"] != DBNull.Value && drow["DO_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["DO_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them dau do_tan loi");
                                    }
                                    if (drow["DO_lit"] != DBNull.Value && drow["DO_lit"].ToString().Trim() != "")
                                    {
                                        temp.DO_lit = drow["DO_lit"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 6;
                                        detail.MeasurementId = 3;
                                        detail.No_RateTOE = 0.00088m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["DO_lit"] != DBNull.Value && drow["DO_lit"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["DO_lit"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them dauDO_lit loi");
                                    }

                                    if (drow["FO_Tan"] != DBNull.Value && drow["FO_Tan"].ToString().Trim() != "")
                                    {
                                        temp.FO_Tan = drow["FO_Tan"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 7;
                                        detail.MeasurementId = 2;
                                        detail.No_RateTOE = 0.99m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["FO_Tan"] != DBNull.Value && drow["FO_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["FO_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them dau FO_tan loi");
                                    }
                                    if (drow["FO_lit"] != DBNull.Value && drow["FO_lit"].ToString().Trim() != "")
                                    {
                                        temp.FO_lit = drow["FO_lit"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 7;
                                        detail.MeasurementId = 3;
                                        detail.No_RateTOE = 0.00094m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["FO_lit"] != DBNull.Value && drow["FO_lit"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["FO_lit"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them dau FO_Lit loi");
                                    }

                                    if (drow["Xang_Tan"] != DBNull.Value && drow["Xang_Tan"].ToString().Trim() != "")
                                    {
                                        temp.Xang_Tan = drow["Xang_Tan"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 11;
                                        detail.MeasurementId = 2;
                                        detail.No_RateTOE = 1.05m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["Xang_Tan"] != DBNull.Value && drow["Xang_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["Xang_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them xang_tan loi");
                                    }
                                    if (drow["Xang_lit"] != DBNull.Value && drow["Xang_lit"].ToString().Trim() != "")
                                    {
                                        temp.Xang_lit = drow["Xang_lit"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 11;
                                        detail.MeasurementId = 3;
                                        detail.No_RateTOE = 0.00083m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["Xang_lit"] != DBNull.Value && drow["Xang_lit"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["Xang_lit"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them xang_lit loi");
                                    }

                                    if (drow["Gas_Tan"] != DBNull.Value && drow["Gas_Tan"].ToString().Trim() != "")
                                    {
                                        temp.Gas_Tan = drow["Gas_Tan"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 10;
                                        detail.MeasurementId = 4;
                                        detail.No_RateTOE = 0.0009m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["Gas_Tan"] != DBNull.Value && drow["Gas_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["Gas_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them Gas_Tan loi");
                                    }

                                    if (drow["Khi_m3"] != DBNull.Value && drow["Khi_m3"].ToString().Trim() != "")
                                    {
                                        temp.Khi_M3 = drow["Khi_m3"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 10;
                                        detail.MeasurementId = 1;
                                        detail.No_RateTOE = 0.0009m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["Khi_m3"] != DBNull.Value && drow["Khi_m3"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["Khi_m3"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them Khi_m3 loi");
                                    }

                                    if (drow["LPG_Tan"] != DBNull.Value && drow["LPG_Tan"].ToString().Trim() != "")
                                    {
                                        temp.LPG_Tan = drow["LPG_Tan"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 8;
                                        detail.MeasurementId = 2;
                                        detail.No_RateTOE = 1.09m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["LPG_Tan"] != DBNull.Value && drow["LPG_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["LPG_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them LPG loi");
                                    }
                                    if (drow["NLPL_Tan"] != DBNull.Value && drow["NLPL_Tan"].ToString().Trim() != "")
                                    {
                                        temp.NLPL_Tan = drow["NLPL_Tan"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 12;
                                        detail.MeasurementId = 2;
                                        detail.No_RateTOE = 1.05m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["NLPL_Tan"] != DBNull.Value && drow["NLPL_Tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["NLPL_Tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them NLPL loi");
                                    }

                                    if (drow["Khac_tan"] != DBNull.Value && drow["Khac_tan"].ToString().Trim() != "")
                                    {
                                        temp.KhacSoDo = drow["Khac_tan"].ToString();
                                        detail = new ReportFuelDetail();
                                        detail.EnterpriseId = report.EnterpriseId;
                                        detail.FuelId = 1;
                                        detail.MeasurementId = 1;
                                        detail.No_RateTOE = 0.0002770000m;
                                        detail.Price = 0;
                                        detail.Year = 2017;
                                        if (drow["Khac_tan"] != DBNull.Value && drow["Khac_tan"].ToString() != "")
                                            detail.NoFuel = Convert.ToDecimal(drow["Khac_tan"]);
                                        detail.NoFuel_TOE = detail.No_RateTOE * detail.NoFuel;
                                        detail.ReportId = reportId;
                                        detailid = serviceDetail.Insert(detail);
                                        if (detailid <= 0)
                                            log.Info("Them khac loi");
                                    }

                                    if (drow["GhiChu"] != DBNull.Value && drow["GhiChu"].ToString().Trim() != "")
                                        temp.Note = drow["GhiChu"].ToString();

                                    EnterpriseYearService eYService = new EnterpriseYearService();
                                    EnterpriseYear ey = new EnterpriseYear();
                                    ey.EnterpriseId = eId;
                                    ey.ReportId = reportId;
                                    ey.Year = 2017;
                                    ey.IsKey = true;
                                    if (drow["No_TOE"] != DBNull.Value && drow["No_TOE"].ToString().Trim() != "")
                                    {
                                        ey.No_TOE = Convert.ToDecimal(drow["No_TOE"]);
                                    }
                                    temp.No_TOE = ey.No_TOE;
                                    temp.Year = 2017;
                                    int retTemp = new ReportTemp2014Service().Insert(temp);//Them bao cao tam
                                    ey.IsDelete = false;
                                    ey.Year = temp.Year;                                   
                                    int retempId = eYService.Insert(ey);//Them nam bao cao
                                    if (retempId <= 0)
                                        log.Info("Them bao cao loi loi");
                                }
                                else
                                    log.Info("Khong tao duoc bao cao");
                            }

                        }
                        catch (Exception ex)
                        {
                            log.Error("Loi import du lieu dong thu i: " + rowi, ex);
                        }
                    }
                }
                else
                {
                    lterror.Text = "Không upload được file";
                }
            }
            else
            {
                lterror.Text = "Chỉ chọn file Excel đuôi .xls và .xlsx";
            }
        }
        else
        {
            lterror.Text = "File không tồn tại";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {


    }

}