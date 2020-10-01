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
using System.Text;

public partial class Client_Admin_DataEngery_ViewPlan5Year : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();

    int PlanId
    {
        get
        {
            if (ViewState["PlanId"] != null && ViewState["PlanId"] != "")
                return Convert.ToInt32(ViewState["PlanId"]);
            else
                return 0;
        }
        set { ViewState["PlanId"] = value; }
    }
    public int ReportId
    {
        get
        {
            if (ViewState["ReportId"] != null && ViewState["ReportId"] != "")
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
            if (ViewState["ReportYear"] != null && ViewState["ReportYear"] != "")
                return Convert.ToInt32(ViewState["ReportYear"]);
            else
                return 0;
        }
        set { ViewState["ReportYear"] = value; }
    }
    public bool AllowEdit
    {
        get
        {
            if (ViewState["AllowEdit"] != null && ViewState["AllowEdit"] != "")
                return Convert.ToBoolean(ViewState["AllowEdit"]);
            else
                return false;
        }
        set { ViewState["AllowEdit"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindPlanTKNL();
            BindThietBi();
            BindResultTB();
            BindResultTKNL();
        }
    }

    void BindData()
    {
        //ReportFuel report = new ReportFuelService().FindByKey(ReportId);
        //if (report != null)
        //{
        ltNextPeriod.Text = ("I. Kế hoạch, mục tiêu tiết kiệm và sử dụng hiệu quả năng lượng trong 5 năm tới (" + (ReportYear + 1).ToString() + " - " + (ReportYear + 6).ToString() + ")").ToUpper();
        ltPeriod.Text = ("II. Kết quả thực hiện kế hoạch 5 năm (" + (ReportYear - 5).ToString() + " - " + ReportYear.ToString() + ")").ToUpper();
        //}

    }
    void BindThietBi()
    {
        PlanTBService plangpservice = new PlanTBService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTBEnterprise(0, ReportId, true, true);
        rptKHBoSungTB.DataSource = tbl;
        rptKHBoSungTB.DataBind();
    }
    void BindResultTB()
    {
        PlanTBService plangpservice = new PlanTBService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTBEnterprise(0, ReportId, true, false);
        rptKetQuaTB.DataSource = tbl;
        rptKetQuaTB.DataBind();
    }
    private void BindPlanTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(0, ReportId, true, true);
        cpRepeater.DataSource = tbl;
        cpRepeater.DataBind();
        //PlanTKNLService plangpservice = new PlanTKNLService();
        //DataTable tbl = new DataTable();
        //tbl = plangpservice.GetPlanTKNLEnerprise(memVal.OrgId, ReportId, true, true);

        //StringBuilder sb = new StringBuilder();        
        //StringBuilder sbHeader = new StringBuilder();
        //sbHeader.Append("<tr>");
        //sbHeader.Append("<th>Năm</th>");
        //for (int i = 4; i >= 0; i++)
        //{
        //    sbHeader.Append("<th>" + (ReportYear - i).ToString() + "</th>");
        //    DataRow[] dr = tbl.Select("Nam=" + (ReportYear - i));
        //    if (dr != null && dr.Count() > 0)
        //    {
        //        for (int j = 0; j < dr.Count(); j++)
        //        {
        //            sb.Append("<tr><td colspan='5'>" + dr[j]["TenGiaiPhap"] + "</td></tr>");
        //            sb.Append("<tr><td colspan='5'>" + dr[j]["TenGiaiPhap"] + "</td></tr>");
        //        }
        //    }

        //}
        //sbHeader.Append("</tr>");
    }
    private void BindResultTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(0, ReportId, true, false);

        rptKetQuaTKNL.DataSource = tbl;
        rptKetQuaTKNL.DataBind();

    }

    protected void btnsearch_click(object sender, EventArgs e)
    {
        BindPlanTKNL();
    }

}