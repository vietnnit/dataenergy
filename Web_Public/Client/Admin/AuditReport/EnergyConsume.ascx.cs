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

public partial class Client_Admin_DataEngery_EnergyConsume : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
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
    public string CustomerCode
    {
        get
        {
            if (ViewState["CustomerCode"] != null && ViewState["CustomerCode"].ToString() != "")
                return ViewState["CustomerCode"].ToString();
            else
                return "";
        }
        set { ViewState["CustomerCode"] = value; }
    }
    public bool AllowEdit
    {
        get
        {
            if (ViewState["AllowEdit"] != null && ViewState["AllowEdit"].ToString() != "")
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
            if (ReportId > 0)
            {
                BindElectricConsume();
                BindSelf();
                txtCustommerCode.Text = CustomerCode;
            }
        }
    }

    void BindData()
    {
        OtherFuelConsumeService consumseService = new OtherFuelConsumeService();
        DataSet ds = consumseService.GetAuditFuel(ReportId);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbSub = new StringBuilder();
            StringBuilder sbData = new StringBuilder();
            sb.Append("<table class='table table-bordered table-hover mbn'>");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th rowspan='2' style='width:30px'>Tháng</th>");
            sbSub.Append("<tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sb.Append("<th colspan='2'>" + ds.Tables[0].Rows[i]["FuelName"] + "</th>");
                sbSub.Append("<th style='width:150px'>Khối lượng <i>(" + (ds.Tables[0].Rows[i]["MeasurementName"]) + ")</i></th>");
                sbSub.Append("<th style='width:150px'>Chi phí <i>(nghìn đồng)</i></th>");
            }
            sbSub.Append("</tr>");
            sb.Append("</tr>");
            sb.Append(sbSub.ToString());
            sb.Append("</thead>");
            for (int j = 1; j <= 12; j++)
            {
                sbData.Append("<tr>");
                sbData.Append("<td class='text-center'>" + j + "</td>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow[] dr = ds.Tables[1].Select("FuelId=" + ds.Tables[0].Rows[i]["Id"].ToString() + " AND MonthUsed=" + j);
                    for (int t = 0; t < dr.Count(); t++)
                    {
                        sbData.Append("<td class='text-right'>" + Tool.ConvertDecimalToString(dr[t]["Quantity"], 2) + "</td>");
                        sbData.Append("<td class='text-right'>" + Tool.ConvertDecimalToString(dr[t]["Cost"], 0) + "</td>");
                    }
                }
                sbData.Append("</tr>");
            }
            sb.Append(sbData.ToString());
            sb.Append("</table>");
            ltOtherEneryConsume.Text = sb.ToString();
        }
    }

    void BindElectricConsume()
    {
        DataTable dt = new ElectrictConsumeService().GetElectrictConsume(ReportId, false);

        if (dt != null && dt.Rows.Count == 0)
        {
            for (int i = 1; i <= 12; i++)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
        }
        rptElectrictConsume.DataSource = dt;
        rptElectrictConsume.DataBind();
    }

    void BindSelf()
    {
        DataTable dt = new ElectrictConsumeService().GetElectrictConsume(ReportId, true);
        if (dt != null && dt.Rows.Count == 0)
        {
            for (int i = 1; i <= 12; i++)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
        }
        rptDataSelf.DataSource = dt;
        rptDataSelf.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindCMIS();
        ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogCMIS();", true);
    }

    void BindCMIS()
    {
        //DataSet ds = new WSCMIS.Service_CapDien().spGetCustomerInforByMoit(txtCustommerCode.Text, ReportYear - 1);
        //rptCMIS.DataSource = ds;
        //rptCMIS.DataBind();

    }
}