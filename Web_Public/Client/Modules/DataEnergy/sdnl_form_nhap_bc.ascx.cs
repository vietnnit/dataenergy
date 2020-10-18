using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportEF;
using ReportBUS;
using ReportBUS.CustomModels;
using System.Web.Script.Serialization;
using ePower.DE.Service;
using ePower.DE.Domain;
using System.Data;

public partial class Client_Modules_DataEnergy_sdnl_form_nhap_bc : System.Web.UI.UserControl
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
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["ReportId"]))
                int.TryParse(Request["ReportId"].Replace(",", ""), out Id);
            ReportId = Id;

            BindReportInfo();
            BindFuel();
            BindReportDetail();
        }
    }

    private void BindReportInfo()
    {
        if (ReportId > 0)
        {
            ReportFuel report = new ReportFuel();
            ReportFuelService reportBSO = new ReportFuelService();
            report = reportBSO.FindByKey(ReportId);
            if (report != null)
            {
                ltDataCurrentTitle.Text = "Nhiên liệu tiêu thụ năm " + (report.Year);
            }
        }
    }

    void BindReportDetail()
    {
        DataTable dtCurrent = new ReportFuelDetailService().GetNoFuelDetailByReport(ReportId, false);
        rptNoFuelCurrent.DataSource = dtCurrent;
        rptNoFuelCurrent.DataBind();
        ltTotal_TOE.Text = "Tổng năng lượng tiêu thụ quy đổi ra TOE: <span style='color:red'>" + Tool.ConvertDecimalToString(No_TOE, 2) + "</span>";
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        LinkButton btnDelete = (LinkButton)sender;
        ReportFuelDetailService faqsBSO = new ReportFuelDetailService();
        faqsBSO.Delete(Convert.ToInt32(btnDelete.CommandArgument));
        BindReportDetail();
    }
    protected void btnEditDetail_Click(object sender, EventArgs e)
    {
        LinkButton btnEdit = (LinkButton)sender;
        if (btnEdit != null)
        {
            hdnDetailId.Value = btnEdit.CommandArgument;
            BindDataDetail();
            ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "updateReportDetail(" + hdnNextYear.Value + ");", true);
        }
    }

    private void BindDataDetail()
    {

        if (hdnDetailId.Value != "")
        {
            ReportFuelDetail reportDetail = new ReportFuelDetailService().FindByKey(Convert.ToInt32(hdnDetailId.Value));
            if (reportDetail != null)
            {
                try
                {
                    if (reportDetail.FuelId > 0)
                    {
                        ddlFuel.SelectedValue = reportDetail.FuelId.ToString();
                        BindMeasurement();
                    }
                    if (reportDetail.MeasurementId > 0)
                    {
                        ddlMeasure.SelectedValue = reportDetail.MeasurementId.ToString();
                        BindTOE();
                    }
                }
                catch { }
                txtPropose.Text = reportDetail.Reason;
                if (reportDetail.NoFuel > 0)
                    txtNoFuel.Text = reportDetail.NoFuel.ToString();
                if (reportDetail.Price > 0)
                    txtPrice.Text = reportDetail.Price.ToString();

                if (reportDetail.No_RateTOE > 0)
                    txtNoTOE.Text = Tool.ConvertDecimalToString(reportDetail.No_RateTOE);
                hdnNextYear.Value = reportDetail.IsNextYear ? "1" : "0";

                if (reportDetail.IsNextYear)
                    ltTitle.Text = "Mức nhiên liệu tiêu thụ dự kiến năm " + (reportDetail.Year + 1).ToString();
                else
                    ltTitle.Text = "Mức nhiên liệu tiêu thụ năm " + reportDetail.Year;
            }
        }

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
            BindTOE();
        }
    }
    void BindTOE()
    {

        txtNoTOE.Enabled = false;
        if (ddlMeasure.SelectedIndex > 0)
        {

            DataTable mea = new MeasurementFuelService().GetTOE(Convert.ToInt32(ddlFuel.SelectedValue), Convert.ToInt32(ddlMeasure.SelectedValue));
            if (mea != null && mea.Rows.Count > 0)
            {

                txtNoTOE.Text = TypeHelper.ToDecimal(mea.Rows[0]["TOE"].ToString()).ToString();
                txtNoTOE.Enabled = false;
                if (mea.Rows[0]["From_TOE"].ToString() != mea.Rows[0]["To_TOE"].ToString())
                {
                    rvNoTOE.Enabled = true;
                    txtNoTOE.Enabled = true;
                    //rvNoTOE.Text = "Nhập hệ số chuyển đổi từ " + mea.From_TOE + " đến " + mea.To_TOE;
                    rvNoTOE.MaximumValue = mea.Rows[0]["To_TOE"].ToString();
                    rvNoTOE.MinimumValue = mea.Rows[0]["From_TOE"].ToString();
                    rvNoTOE.Text = string.Format("Nhập hệ số chuyển đổi từ {0} đến {1}", TypeHelper.ToDecimal(mea.Rows[0]["From_TOE"].ToString()), TypeHelper.ToDecimal(mea.Rows[0]["To_TOE"].ToString()));

                }
                else
                {
                    txtNoTOE.Enabled = false;
                    if (mea.Rows[0]["TOE"] != DBNull.Value)
                    {
                        rvNoTOE.Enabled = false;
                        rvNoTOE.MaximumValue = mea.Rows[0]["TOE"].ToString();
                        rvNoTOE.MinimumValue = rvNoTOE.MaximumValue;
                        rvNoTOE.Text = "Nhập hệ số chuyển đổi từ " + rvNoTOE.MinimumValue;
                    }

                }
            }

        }
    }
    protected void ddlFuel_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtNoTOE.Enabled = false;
        txtNoTOE.Text = "";
        BindMeasurement();

        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "updateReportDetail('" + hdnNextYear.Value + "');", true);

    }
    protected void ddlMeasure_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTOE();
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "updateReportDetail(" + hdnNextYear.Value + ");", true);
    }
    private ReportFuelDetail ReceiveHtmlDetail()
    {
        ReportFuelDetail rep = new ReportFuelDetail();
        if (ddlFuel.SelectedIndex > 0)
            rep.FuelId = Convert.ToInt32(ddlFuel.SelectedValue);
        if (rep.FuelId > 0)
        {
            Fuel fuel = new FuelService().FindByKey(rep.FuelId);
            if (fuel != null)
            {
                rep.GroupFuelId = fuel.GroupFuelId;
            }
        }
        //if (ddlFuel.SelectedIndex > 0)
        //    rep.GroupFuelId = Convert.ToInt32(ddlFuelType.SelectedValue);
        if (ddlMeasure.SelectedIndex > 0)
            rep.MeasurementId = Convert.ToInt32(ddlMeasure.SelectedValue);
        if (txtNoFuel.Text.Trim() != "")
            rep.NoFuel = Convert.ToDecimal(txtNoFuel.Text.Trim());
        if (txtNoTOE.Text.Trim() != "")
            rep.No_RateTOE = Convert.ToDecimal(txtNoTOE.Text.Trim());
        rep.Reason = txtPropose.Text.Trim();

        if (txtPrice.Text.Trim() != "")
            rep.Price = Convert.ToDecimal(txtPrice.Text.Trim());
        rep.IsNextYear = (hdnNextYear.Value == "1");
        rep.Year = ReportYear;
        rep.ReportId = ReportId;
        rep.EnterpriseId = memVal.OrgId;
        rep.NoFuel_TOE = rep.NoFuel * rep.No_RateTOE;
        return rep;

    }
    protected void btnSaveFuel_Click(object sender, EventArgs e)
    {
        try
        {
            ReportFuelDetail faqs = ReceiveHtmlDetail();
            ReportFuelDetailService faqsBSO = new ReportFuelDetailService();
            if (hdnDetailId.Value != "")
            {
                //faqs = faqsBSO.FindByKey(ReportDetailId);
                faqs.Id = Convert.ToInt32(hdnDetailId.Value);
                if (faqsBSO.Update(faqs) != null)
                {
                    clientview.Text = "<div class='alert alert-sm alert-success bg-gradient'>Lưu thông tin Thành công !</div>";
                    if (hdnNextYear.Value == "0")
                        BindReportDetail();
                }
                else
                {
                    clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lưu thông tin không Thành công !</div>";
                }
            }
            else
            {
                if (faqsBSO.Insert(faqs) > 0)
                {
                    clientview.Text = "<div class='alert alert-sm alert-success bg-gradient'>Lưu thông tin Thành công !</div>";
                    if (hdnNextYear.Value == "0")
                        BindReportDetail();
                }
                else
                    clientview.Text = "<div class='alert alert-sm alert-danger bg-gradient'>Lưu thông tin không Thành công !</div>";
            }
        }
        catch (Exception ex)
        {
            clientview.Text = ex.Message.ToString();
        }
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

    protected void btnExportWord_Click(object sender, EventArgs e)
    {
        #region get data
        WordExtend ex = new WordExtend();
        string temp = "TempReport/TemMauBaoCao1_1.doc";
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
        }
        else
            ex.WriteToMergeField("BC_TenCoSo", "");

        if (dtinfo.Rows[0]["Year"] != DBNull.Value)
        {
            int iCurrentYear = Convert.ToInt32(dtinfo.Rows[0]["Year"]);
            string NextYear = dtinfo.Rows[0]["Year"].ToString();
            ex.WriteToMergeField("BC_NextYear", NextYear);
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

        //ex.WriteToMergeField("BC_Owner", ltOwner.Text);
        ex.WriteToMergeField("BC_Owner", "");

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

        DataTable dthientai = new DataTable();
        DataSet dshientai = new DataSet("tbl1");
        
        DataTable tblProductResult = CreateFuelData();
        dshientai.Merge(tblProductResult);
        dshientai.Tables[0].TableName = "tbl1";
        dshientai.Merge(dthientai);
        ex.WriteDataSetToMergeField(dshientai);
        #endregion
        ex.Save(Server.MapPath(ResolveUrl("~") + "TempReport/" + memVal.UserName + ".Bao-cao-hang-nam-" + dtinfo.Rows[0]["Year"] + ".doc"));
        HttpContext.Current.Response.Redirect(string.Format("~/Download.aspx?fp={0}&fn={1}",
              System.IO.Path.GetFileName(Server.MapPath(ResolveUrl("~") + "TempReport/" + memVal.UserName + ".Bao-cao-hang-nam-" + dtinfo.Rows[0]["Year"] + ".doc")),
              ""
          ));
    }

    private DataTable CreateFuelData()
    {
        DataTable dtCurrent = new ReportFuelDetailService().GetNoFuelDetailByReport(ReportId, false);

        ReportModels rp = new ReportModels();
        var allFuel = (from a in rp.DE_Fuel
                       join b in rp.DE_Measurement on a.MeasurementId equals b.Id
                       select new
                       {
                           a.Id,
                           a.GroupFuelId,
                           a.FuelName,
                           b.MeasurementName
                       }).ToList();
        DataTable res = new DataTable();
        res.Columns.Add("stt", typeof(string));
        res.Columns.Add("FuelName", typeof(string));
        res.Columns.Add("MeasurementName", typeof(string));
        res.Columns.Add("NoFuel", typeof(string));
        res.Columns.Add("Reason", typeof(string));
        int i = 1;
        foreach (var item in allFuel)
        {
            DataRow r = res.NewRow();
            r["stt"] = i.ToString();
            r["FuelName"] = item.FuelName;
            r["MeasurementName"] = item.MeasurementName;

            bool check = false;
            foreach (DataRow x in dtCurrent.Rows)
            {
                if (x["FuelId"].ToString() == item.Id.ToString())
                {
                    check = true;
                    r["NoFuel"] = x["NoFuel"];
                    r["Reason"] = x["Reason"];
                    break;
                }
            }
            if(check==false)
            {
                r["NoFuel"] = "";
                r["Reason"] = "";
            }    
            res.Rows.Add(r);
            i++;
        }
        return res;
    }
}