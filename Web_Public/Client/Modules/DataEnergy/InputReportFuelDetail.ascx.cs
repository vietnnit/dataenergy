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
using ETO;
using ePower.DE.Domain;
using BSO;
using ePower.DE.Service;
using System.Collections.Generic;
using System.Text;

public partial class Client_Modules_DataEnergy_InputReportFuelDetail : System.Web.UI.UserControl
{
    public int ReportId
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
    public int ReportDetailId
    {
        get
        {
            if (ViewState["ReportDetailId"] != null && ViewState["ReportDetailId"].ToString() != "")
                return (int)ViewState["ReportDetailId"];
            else
                return 0;
        }
        set { ViewState["ReportDetailId"] = value; }
    }

    int EnterpriseId
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
    public int isnext
    {
        get
        {
            if (ViewState["isnext"] != null && ViewState["isnext"].ToString() != "")
                return (int)ViewState["isnext"];
            else
                return 0;
        }
        set { ViewState["isnext"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //int IdDetail = 0;
            //if (!string.IsNullOrEmpty(Request["FuelId"]))
            //    int.TryParse(Request["FuelId"].Replace(",", ""), out IdDetail);
            //ReportDetailId = IdDetail;
            //bool isne = false;
            //if (!string.IsNullOrEmpty(Request["isnext"]))
            //    bool.TryParse(Request["isnext"].Replace(",", ""), out isne);
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["Id"]))
                int.TryParse(Request["Id"].Replace(",", ""), out Id);
            ReportId = Id;
            BindGroupFuel();
            BindFuel();
            BindMeasurement();
            BindData();
            //isnext = isne;
            if (isnext > 0)
                ltTitle.Text = "Mức tiêu thụ nhiên liệu dự kiến năm " + (ReportYear + 1);
            else
                ltTitle.Text = "Mức tiêu thụ nhiên liệu năm " + ReportYear;
        }

    }
    void BindGroupFuel()
    {
        IList<GroupFuel> list = new List<GroupFuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_GroupFuel_All))
        {
            list = new GroupFuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_GroupFuel_All, list);
        }
        else
            list = (IList<GroupFuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_GroupFuel_All);
        ddlFuelType.DataSource = list;
        ddlFuelType.DataValueField = "Id";
        ddlFuelType.DataTextField = "Title";
        ddlFuelType.DataBind();
        ddlFuelType.Items.Insert(0, new ListItem("---Chọn loại nhiên liệu---", ""));
    }
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
        int GroupId = 0;
        if (ddlFuelType.SelectedIndex > 0)
            GroupId = Convert.ToInt32(ddlFuelType.SelectedValue);

        ddlFuelType.DataSource = list;
        var listSearch = from o in list where o.GroupFuelId == GroupId || GroupId == 0 select o;
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
        IList<MeasurementFuel> list = new List<MeasurementFuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Measurement_All))
        {
            list = new MeasurementFuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Measurement_All, list);
        }
        else
            list = (IList<MeasurementFuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Measurement_All);
        int FuelId = 0;
        if (ddlFuel.SelectedIndex > 0)
            FuelId = Convert.ToInt32(ddlFuel.SelectedValue);

        var listSearch = from o in list where o.FuelId == FuelId || FuelId == 0 select o;
        ddlMeasure.DataSource = listSearch;
        ddlMeasure.DataValueField = "Id";
        ddlMeasure.DataTextField = "MeasurementName";
        ddlMeasure.DataBind();
        ddlMeasure.Items.Insert(0, new ListItem("---Chọn đơn vị tính---", ""));
        if (ddlMeasure.Items.Count == 2)
        {
            ddlMeasure.SelectedIndex = 1;
            BindTOE();
        }
    }
    private void BindData()
    {
        if (ReportId > 0)
        {
            try
            {
                ReportFuel faqs = new ReportFuel();
                ReportFuelService faqsBSO = new ReportFuelService();
                faqs = faqsBSO.FindByKey(ReportId);
                EnterpriseId = faqs.EnterpriseId;
                ReportYear = faqs.Year;
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }
        else
        {
            if (ReportDetailId > 0)
            {
                ReportFuelDetail reportDetail = new ReportFuelDetailService().FindByKey(ReportDetailId);
                if (reportDetail != null)
                {
                    ddlFuelType.SelectedValue = reportDetail.GroupFuelId.ToString();
                    ddlFuel.SelectedValue = reportDetail.FuelId.ToString();
                    ddlMeasure.SelectedValue = reportDetail.MeasurementId.ToString();
                    txtPropose.Text = reportDetail.Reason;
                    txtNoFuel.Text = reportDetail.NoFuel.ToString();
                    txtPrice.Text = reportDetail.Price.ToString();
                    txtNoTOE.Text = reportDetail.No_RateTOE.ToString();
                    ReportFuel faqs = new ReportFuel();
                    ReportFuelService faqsBSO = new ReportFuelService();
                    faqs = faqsBSO.FindByKey(reportDetail.ReportId);
                    EnterpriseId = faqs.EnterpriseId;
                    ReportYear = faqs.Year;
                    ReportId = reportDetail.ReportId;
                    isnext = reportDetail.IsNextYear == true ? 1 : 0;
                }
            }
        }

    }


    #region ReceiveHtml
    private ReportFuelDetail ReceiveHtml()
    {
        ReportFuelDetail rep = new ReportFuelDetail();
        if (ddlFuel.SelectedIndex > 0)
            rep.FuelId = Convert.ToInt32(ddlFuel.SelectedValue);
        if (ddlFuel.SelectedIndex > 0)
            rep.GroupFuelId = Convert.ToInt32(ddlFuelType.SelectedValue);
        if (ddlMeasure.SelectedIndex > 0)
            rep.MeasurementId = Convert.ToInt32(ddlMeasure.SelectedValue);
        if (txtNoFuel.Text.Trim() != "")
            rep.NoFuel = Convert.ToDecimal(txtNoFuel.Text.Trim());
        if (txtNoTOE.Text.Trim() != "")
            rep.No_RateTOE = Convert.ToDecimal(txtNoTOE.Text.Trim());
        rep.Reason = txtPropose.Text.Trim();
        if (txtPrice.Text.Trim() != "")
            rep.Price = Convert.ToInt32(txtPrice.Text.Trim());
        rep.IsNextYear = (isnext == 1);
        rep.Year = ReportYear;
        rep.ReportId = ReportId;
        rep.EnterpriseId = EnterpriseId;
        rep.NoFuel_TOE = rep.NoFuel * rep.No_RateTOE;
        return rep;

    }
    #endregion


    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            ReportFuelDetail faqs = ReceiveHtml();
            ReportFuelDetailService faqsBSO = new ReportFuelDetailService();
            if (ReportDetailId > 0)
            {
                //faqs = faqsBSO.FindByKey(ReportDetailId);
                faqs.Id = ReportDetailId;
                if (faqsBSO.Update(faqs) != null)
                    clientview.Text = "<div class='alert alert-sm alert-success bg-gradient'>Lưu thông tin Thành công !</div>";
                else
                    clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lưu thông tin không Thành công !</div>";
            }
            else
            {
                if (faqsBSO.Insert(faqs) > 0)
                    clientview.Text = "<div class='alert alert-sm alert-success bg-gradient'>Lưu thông tin Thành công !</div>";
                else
                    clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lưu thông tin không Thành công !</div>";
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
        Response.Redirect("~/Admin/editReportFuel/Default.aspx");

    }

    protected void ddlMeasure_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTOE();
        ScriptManager.RegisterStartupScript(this, GetType(), "ad", "addReportNext(" + ReportDetailId + "," + isnext + ");", true);
    }
    protected void ddlFuelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFuel();
        ScriptManager.RegisterStartupScript(this, GetType(), "ad", "addReportNext(" + ReportDetailId + "," + isnext + ");", true);
    }
    protected void ddlFuel_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMeasurement();
        ScriptManager.RegisterStartupScript(this, GetType(), "ad", "addReportNext(" + ReportDetailId + "," + isnext + ");", true);
    }
    void BindTOE()
    {
        rvNoTOE.MaximumValue = "10";
        rvNoTOE.MinimumValue = "0";
        rvNoTOE.Text = "Nhập hệ số chuyển đổi từ 0 đến 10";
        txtNoTOE.Enabled = false;
        if (ddlMeasure.SelectedIndex > 0)
        {
            MeasurementFuel mea = new MeasurementFuelService().FindByKey(Convert.ToInt32(ddlMeasure.SelectedValue));
            if (mea != null)
            {
                if (mea.From_TOE<mea.To_TOE)
                {
                    txtNoTOE.Text = mea.TOE.ToString();
                    txtNoTOE.Enabled = false;
                }
                else
                {
                    txtNoTOE.Enabled = true;
                    rvNoTOE.Text = "Nhập hệ số chuyển đổi từ " + mea.From_TOE + " đến " + mea.To_TOE;
                    rvNoTOE.MaximumValue = mea.To_TOE.ToString();
                    rvNoTOE.MinimumValue = mea.From_TOE.ToString();
                }
            }

        }
    }
}
