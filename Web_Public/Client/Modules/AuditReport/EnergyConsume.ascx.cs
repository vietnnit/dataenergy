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

public partial class Client_Module_DataEngery_EnergyConsume : System.Web.UI.UserControl
{
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
            BindFuel();
            BindData();
            if (ReportId > 0)
            {
                txtCustommerCode.Text = CustomerCode;
                ltAuditYear2.Text = ltAuditYear.Text = ltDataYear.Text = (ReportYear - 1).ToString();
                BindFuelConsume();
                BindElectricConsume();
                BindSelf();
                btnAddFuel.Visible = btnAddFuel.Visible = btnAddFuelFuture.Visible = btnDeleteSelf.Visible = btnSaveElectrictConsume.Visible = btnSaveFuel.Visible = btnSaveSelf.Visible = lbtSelfElectrict.Visible = AllowEdit;
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
            sb.Append("<table class='table table-bordered table-hover mbn' width='100%'>");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th rowspan='2' class='text-center'>Tháng</th>");
            sbSub.Append("<tr>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sb.Append("<th colspan='2' class='text-center'>" + ds.Tables[0].Rows[i]["FuelName"] + "</th>");
                sbSub.Append("<th class='text-center'>Khối lượng" + "<br/><i>(" + ds.Tables[0].Rows[i]["MeasurementName"] + ")</i>" + "</th>");
                sbSub.Append("<th class='text-center'>Chi phí <br/><i>(nghìn đồng)</i></th>");
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
                    if (dr.Count() > 0)
                    {
                        for (int t = 0; t < dr.Count(); t++)
                        {
                            sbData.Append("<td class='text-right'>" + Tool.ConvertDecimalToString(dr[t]["Quantity"], 2) + "</td>");
                            sbData.Append("<td class='text-right'>" + Tool.ConvertDecimalToString(dr[t]["Cost"], 0) + "</td>");
                        }
                    }
                    else
                    {
                        sbData.Append("<td class='text-right'>-</td>");
                        sbData.Append("<td class='text-right'>-</td>");
                    }

                }
                sbData.Append("</tr>");
            }
            sb.Append(sbData.ToString());
            sb.Append("</table>");
            ltOtherEneryConsume.Text = sb.ToString();
        }

    }
    void BindFuelConsume()
    {
        OtherFuelConsumeService consumseService = new OtherFuelConsumeService();
        int FuelId = 0;
        if (ddlFuel.SelectedIndex > 0)
            FuelId = Convert.ToInt32(ddlFuel.SelectedValue);
        DataTable dt = consumseService.GetDataByFuel(ReportId, FuelId);

        if (dt != null && dt.Rows.Count <= 0)
        {
            for (int i = 1; i <= 12; i++)
            {
                DataRow dr = dt.NewRow();
                //dr["Quantity"] = 0;
                //dr["Cost"] = 0;
                dt.Rows.Add(dr);
            }
        }
        else
        {
            try
            {
                ddlMeasure.SelectedValue = dt.Rows[0]["MeasurementId"].ToString();
            }
            catch { }
        }
        rptDataFuel.DataSource = dt;
        rptDataFuel.DataBind();
    }



    protected void btnDeleteFuelConsume_Click(object sender, EventArgs e)
    {
        int FuelId = Convert.ToInt32(ddlFuel.SelectedValue);
        OtherFuelConsumeService otherService = new OtherFuelConsumeService();
        if (otherService.DeleteByFuel(ReportId, FuelId) >= 0)
        {
            ltErrConsume.Text = "Xóa thành công";
            BindFuelConsume();
            BindData();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogFuelConsume();", true);
        }
    }
    protected void btnDeleteElectrictConsume_Click(object sender, EventArgs e)
    {
        ElectrictConsumeService otherService = new ElectrictConsumeService();
        if (otherService.DeleteByReport(ReportId, false) >= 0)
        {
            ltErrElectrictConsume.Text = "Xóa thành công";
            BindElectricConsume();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectrictConsume();", true);
        }

    }
    protected void btnDeleteSelf_Click(object sender, EventArgs e)
    {
        ElectrictConsumeService otherService = new ElectrictConsumeService();
        if (otherService.DeleteByReport(ReportId, true) >= 0)
        {
            ltErrElectrictConsume.Text = "Xóa thành công";
            BindElectricConsume();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectrictConsume();", true);
        }

    }

    #region Nhap muc nhien lieu hang nam

    void BindFuel()
    {
        ddlFuel.Items.Clear();
        IList<Fuel> list = new List<Fuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Fuel_All))
        {
            list = new FuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Fuel_All, list);
        }
        else
            list = (IList<Fuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Fuel_All);
        //int GroupId = 0;
        //if (ddlFuelType.SelectedIndex > 0)
        //    GroupId = Convert.ToInt32(ddlFuelType.SelectedValue);

        //ddlFuelType.DataSource = list;
        var listSearch = from o in list orderby o.FuelName ascending select o;
        ddlFuel.DataSource = listSearch;
        ddlFuel.DataValueField = "Id";
        ddlFuel.DataTextField = "FuelName";
        ddlFuel.DataBind();
        ddlFuel.Items.Insert(0, new ListItem("---Chọn nhiên liệu---", ""));
        if (ddlFuel.Items.Count == 2)
            ddlFuel.SelectedIndex = 1;
        BindMeasurement();
    }

    void BindMeasurement()
    {
        ddlMeasure.Items.Clear();
        DataTable list = new DataTable();
        if (ddlFuel.SelectedIndex > 0)
        {
            list = new MeasurementFuelService().GetListMeasurement(Convert.ToInt32(ddlFuel.SelectedValue));
        }

        ddlMeasure.DataSource = list;
        ddlMeasure.DataValueField = "Id";
        ddlMeasure.DataTextField = "MeasurementName";
        ddlMeasure.DataBind();
        ddlMeasure.Items.Insert(0, new ListItem("---Chọn đơn vị tính---", ""));
        if (ddlMeasure.Items.Count == 2)
        {
            ddlMeasure.SelectedIndex = 1;

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

        rptElecttrictInput.DataSource = dt;
        rptElecttrictInput.DataBind();
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

        rptSelfInput.DataSource = dt;
        rptSelfInput.DataBind();
    }
    protected void btnSaveSelf_Click(object sender, EventArgs e)
    {
        ElectrictConsumeService otherService = new ElectrictConsumeService();
        if (otherService.DeleteByReport(ReportId, true) >= 0)
        {
            for (int i = 1; i <= 12; i++)
            {
                ElectrictConsume other = new ElectrictConsume();
                try
                {
                    string strNormal = Request.Form["txtNormalNoS" + i];
                    string strPeak = Request.Form["txtPeakNoS" + i];
                    string strLow = Request.Form["txtLowNoS" + i];
                    string strTotal = Request.Form["txtElectrictTotalS" + i];
                    string strCost = Request.Form["txtCostTotalS" + i];

                    if (strNormal != null && strNormal.Trim() != "")
                        other.NormalNo = Convert.ToInt64(strNormal.Trim());
                    if (strPeak != null && strPeak.Trim() != "")
                        other.PeakNo = Convert.ToInt64(strPeak.Trim());
                    if (strLow != null && strLow.Trim() != "")
                        other.LowNo = Convert.ToInt64(strLow.Trim());
                    if (strTotal != null && strTotal.Trim() != "")
                        other.ElectrictTotal = Convert.ToInt64(strTotal.Trim());
                    if (strCost != null && strCost.Trim() != "")
                        other.CostTotal = Convert.ToInt64(strCost.Trim());
                }
                catch (Exception ex)
                {}
                other.FuelId = 1;//Nhien lieu dien
                other.AuditReportId = ReportId;
                other.Month = i;
                other.Year = ReportYear;
                other.IsSelf = true;
                otherService.Insert(other);

            }
            BindSelf();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSelfConsume();", true);
        }
    }

    protected void btnSaveElectrictConsume_Click(object sender, EventArgs e)
    {
        ElectrictConsumeService otherService = new ElectrictConsumeService();
        if (otherService.DeleteByReport(ReportId, false) >= 0)
        {
            for (int i = 1; i <= 12; i++)
            {
                ElectrictConsume other = new ElectrictConsume();
                try
                {
                    string strNormal = Request.Form["txtNormalNo" + i];
                    string strPeak = Request.Form["txtPeakNo" + i];
                    string strLow = Request.Form["txtLowNo" + i];
                    string strTotal = Request.Form["txtElectrictTotal" + i];
                    string strCost = Request.Form["txtCostTotal" + i];

                    if (strNormal != null && strNormal.Trim() != "")
                        other.NormalNo = Convert.ToInt64(strNormal.Trim());
                    if (strPeak != null && strPeak.Trim() != "")
                        other.PeakNo = Convert.ToInt64(strPeak.Trim());
                    if (strLow != null && strLow.Trim() != "")
                        other.LowNo = Convert.ToInt64(strLow.Trim());
                    if (strTotal != null && strTotal.Trim() != "")
                        other.ElectrictTotal = Convert.ToInt64(strTotal.Trim());
                    if (strCost != null && strCost.Trim() != "")
                        other.CostTotal = Convert.ToInt64(strCost.Trim());
                }
                catch (Exception ex)
                { }
                other.FuelId = 1;//Nhien lieu dien
                other.AuditReportId = ReportId;
                other.Month = i;
                other.IsSelf = false;
                other.Year = ReportYear;
                otherService.Insert(other);

            }
            BindElectricConsume();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogElectrictConsume();", true);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindCMIS();
        ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogCMIS();", true);
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
       // DataSet ds = new WSCMIS.Service_CapDien().spGetCustomerInforByMoit(txtCustommerCode.Text, ReportYear - 1);
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    ElectrictConsumeService otherService = new ElectrictConsumeService();
        //    otherService.DeleteByReport(ReportId, false);
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        ElectrictConsume other = new ElectrictConsume();
        //        other.NormalNo = Convert.ToInt32(ds.Tables[0].Rows[i]["KWH_BT"]);
        //        other.PeakNo = Convert.ToInt32(ds.Tables[0].Rows[i]["KWH_CD"]);
        //        other.LowNo = Convert.ToInt32(ds.Tables[0].Rows[i]["KWH_TD"]);
        //        other.ElectrictTotal = other.NormalNo + other.PeakNo + other.LowNo;
        //        other.CostTotal = Convert.ToInt32(ds.Tables[0].Rows[i]["TIEN_BT"]) + Convert.ToInt32(ds.Tables[0].Rows[i]["TIEN_CD"]) + Convert.ToInt32(ds.Tables[0].Rows[i]["TIEN_TD"]);
        //        other.AuditReportId = ReportId;
        //        other.Month = Convert.ToInt32(ds.Tables[0].Rows[i]["THANG"]); ;
        //        other.IsSelf = false;
        //        other.Year = ReportYear;
        //        otherService.Insert(other);
        //    }
        //}
        BindElectricConsume();
    }

    void BindCMIS()
    {
       // DataSet ds = new WSCMIS.Service_CapDien().spGetCustomerInforByMoit(txtCustommerCode.Text, ReportYear - 1);
        //rptCMIS.DataSource = ds;
        //rptCMIS.DataBind();

    }
    protected void btnSaveFuel_Click(object sender, EventArgs e)
    {
        int FuelId = Convert.ToInt32(ddlFuel.SelectedValue);
        int MeasureId = Convert.ToInt32(ddlMeasure.SelectedValue);
        OtherFuelConsumeService otherService = new OtherFuelConsumeService();
        if (otherService.DeleteByFuel(ReportId, FuelId) >= 0)
        {
            for (int i = 1; i <= 12; i++)
            {

                string strQuantity = Request.Form["txtQuantity" + i];
                string strCost = Request.Form["txtCost" + i];
                OtherFuelConsume other = new OtherFuelConsume();
                try
                {
                    if (strQuantity != null && strQuantity.Trim() != "")
                        other.Quantity = Convert.ToDecimal(strQuantity.Trim());
                    if (strCost != null && strCost.Trim() != "")
                        other.Cost = Convert.ToDecimal(strCost.Trim());
                }
                catch (Exception ex)
                {

                }
                other.FuelId = FuelId;
                other.AuditReportId = ReportId;
                other.MonthUsed = i;
                other.MeasurementId = MeasureId;
                otherService.Insert(other);
            }
            BindData();
            BindFuelConsume();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogFuelConsume();", true);
        }
    }

    protected void ddlMeasure_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindFuelConsume();
        //ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogFuelConsume();", true);
    }
    protected void ddlFuelType_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindFuel();
        ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogFuelConsume();", true);
    }
    protected void ddlFuel_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMeasurement();
        BindFuelConsume();
        ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogFuelConsume();", true);

    }
    #endregion
}