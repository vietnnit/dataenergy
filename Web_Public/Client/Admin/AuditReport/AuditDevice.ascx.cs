using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using ePower.DE.Domain;
using ePower.DE.Service;
using PR.Domain;
using PR.Service;
using System.Data;

public partial class Client_Admin_AuditReport_AuditDevice : System.Web.UI.UserControl
{
    MemberValidation memVal = new MemberValidation();
    public int ReportId
    {
        get
        {
            if (ViewState["ReportId"] != null && ViewState["ReportId"].ToString() != "")
                return Convert.ToInt32(ViewState["ReportId"]);
            else
                return 0;
        }
        set { ViewState["ReportId"] = value; }
    }
    public int ReportYear
    {
        get
        {
            if (ViewState["ReportYear"] != null && ViewState["ReportYear"].ToString() != "")
                return Convert.ToInt32(ViewState["ReportYear"]);
            else
                return 0;
        }
        set { ViewState["ReportYear"] = value; }
    }
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {                     
            if (ReportId > 0)
            {              
                BindElectricMotors();
                BindFurnaces();
                BindCompressor();
                BindBoiler();
            }
        }
    }

    void BindData()
    {
        Enterprise enter = new Enterprise();
        if (memVal.OrgId > 0)
        {
            enter = new EnterpriseService().FindByKey(memVal.OrgId);
            if (enter != null)
            {
                ///ltActiveYear.Text = enter.ActiveYear.ToString();
            }
        }
        //btnAddProductPlan.Visible = btnAddProductNext.Visible = btnAddProductNextResult.Visible = btnAddProductResult.Visible = AllowEdit; ;

    }

   
    private void BindCompressor()
    {
        CompressorService productConsumeService = new CompressorService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetCompressorByReport(ReportId);
        rptCompressor.DataSource = tbl;
        rptCompressor.DataBind();
    }
    private void BindBoiler()
    {
        BoilerService productConsumeService = new BoilerService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetBoilerList(ReportId);
        rptBoiler.DataSource = tbl;
        rptBoiler.DataBind();
    }
    private void BindFurnaces()
    {
        FurnacesService productConsumeService = new FurnacesService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetFurnacesByReport(ReportId);
        rptFurnaces.DataSource = tbl;
        rptFurnaces.DataBind();
    }
    private void BindElectricMotors()
    {
        ElectricMotorsService productConsumeService = new ElectricMotorsService();
        DataTable tbl = new DataTable();
        tbl = productConsumeService.GetElectricMotorsByReport(ReportId);
        rptElectricMotors.DataSource = tbl;
        rptElectricMotors.DataBind();
    }
  
   
}