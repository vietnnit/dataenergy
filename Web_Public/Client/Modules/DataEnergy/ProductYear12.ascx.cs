﻿using System;
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
using Telerik.Web.Data.Extensions;
using ReportEF;
using System.Globalization;

public partial class Client_Modules_DataEnergy_ProductYear12 : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
    MemberValidation memVal = new MemberValidation();

    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
    NumberStyles style = NumberStyles.Number;

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
    int PlanId
    {
        get
        {
            if (ViewState["PlanId"] != null && ViewState["PlanId"].ToString() != "")
                return Convert.ToInt32(ViewState["PlanId"]);
            else
                return 0;
        }
        set { ViewState["PlanId"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AllowEdit = true;
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["ReportId"]))
                int.TryParse(Request["ReportId"].Replace(",", ""), out Id);
            ReportId = Id;
            BindProduct();
            BindMeasurement();
            BindFuelFuture();
            BindUsingElectrictFuture();
            BindData();
            BindFuel();
            BindSolution();
            BindResultTKNL();
            BindPlanTKNL();
            BindUsingEnerySystem();
            BindProductCapacity();
            BindProductCapacityPlan();
        }
    }


    //===========================================================================update===============================================

    //Tạo danh sách sản phẩm tĩnh nếu chưa tồn tại

    protected void rptProductResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltTieuThuNLTheoSP = (Literal)e.Item.FindControl("ltTieuThuNLTheoSP");
            HiddenField hdTieuThuNLTheoSP = (HiddenField)e.Item.FindControl("hdTieuThuNLTheoSP");
            int _ProductCapacityId = Convert.ToInt32(hdTieuThuNLTheoSP.Value);
            ReportModels rp = new ReportModels();
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
                tmp += string.Format("{0}: {1}({2})<br/>", item.FuelName, item.ConsumeQty, item.MeasurementName);
            }
            ltTieuThuNLTheoSP.Text = tmp;
        }
    }

    //Binding
    private void BindProductCapacity()
    {
        //ReportModels rp = new ReportModels();
        //var data = (from a in rp.DE_Product
        //            join b in rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == false) on a.Id equals b.ProductId into ab
        //            from c in ab.DefaultIfEmpty()
        //            join d in rp.DE_GroupFuel on a.GroupFuel equals d.Id
        //            where a.EnterpriseId == memVal.OrgId && a.IsProduct == false
        //            orderby a.ProductName ascending
        //            select new
        //            {
        //                ProductId = a.Id,
        //                ProductName = a.ProductName,
        //                NhietTriThap = a.NhietTriThap == null ? 0 : a.NhietTriThap,
        //                GroupFuelName = d.Title,
        //                MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
        //            }).ToList();

        //rptProductResult.DataSource = data;
        //rptProductResult.DataBind();

        ProductCapacityService productCapacityService = new ProductCapacityService();
        DataTable tbl = new DataTable();
        tbl = productCapacityService.GetDataCapacity(ReportId, false);
        rptProductResult.DataSource = tbl;
        rptProductResult.DataBind();
    }


    void BindData()
    {
        //btnAddDevice.Visible = btnAddPlan.Visible = btnAddPlanDeviceNext.Visible = btnAddPlanNext.Visible = btnAddSolution.Visible = btnAddSolution2.Visible = AllowEdit;

        ReportModels rp = new ReportModels();
        var data = rp.DE_ReportFuel.FirstOrDefault(x => x.Id == ReportId && x.ReportType == ReportKey.PLAN);
        if (data != null)
        {
            ltReportYear.Text = (data.Year - 1).ToString();
            ltReportNext.Text = (data.Year).ToString();
            ltSolutionResult.Text = (data.Year - 1).ToString();
            ltSolutionNextYear.Text = data.Year.ToString();
            ltDuKienMucTieuThuNangLuong.Text = "2. Dự kiến mức tiêu thụ năng lượng năm " + (data.Year).ToString();
        }
    }

    //2. Sử dụng nhiên liệu
    #region 2. Sử dụng nhiên liệu

    //a. Sử dụng nhiên liệu
    protected void btAddFuelFuture_Click(object sender, EventArgs e)
    {
        btAddFuelFuture.Visible = false;
        btAddFuelFutureUpdate.Visible = true;
        btAddFuelFutureCancel.Visible = true;
        foreach (RepeaterItem ri in rptFuelFuture.Items)
        {
            TextBox txtNoFuel = ri.FindControl("txtNoFuel") as TextBox;
            txtNoFuel.ReadOnly = false;

            TextBox txtReason = ri.FindControl("txtReason") as TextBox;
            txtReason.ReadOnly = false;
        }
    }

    protected void btAddFuelFutureCancel_Click(object sender, EventArgs e)
    {
        btAddFuelFuture.Visible = true;
        btAddFuelFutureUpdate.Visible = false;
        btAddFuelFutureCancel.Visible = false;

        foreach (RepeaterItem ri in rptFuelFuture.Items)
        {
            TextBox txtNoFuel = ri.FindControl("txtNoFuel") as TextBox;
            txtNoFuel.ReadOnly = true;

            TextBox txtReason = ri.FindControl("txtReason") as TextBox;
            txtReason.ReadOnly = true;
        }
    }

    protected void btAddFuelFutureUpdate_Click(object sender, EventArgs e)
    {
        ReportModels rp = new ReportModels();
        var listFuelDetail = rp.DE_ReportFuelDetail.Where(x => x.ReportId == ReportId && x.IsNextYear == true).ToList();

        foreach (RepeaterItem ri in rptFuelFuture.Items)
        {
            TextBox txtNoFuel = ri.FindControl("txtNoFuel") as TextBox;
            TextBox txtReason = ri.FindControl("txtReason") as TextBox;
            HiddenField hdFuelId = ri.FindControl("hdFuelId") as HiddenField;

            int _FuelId = Convert.ToInt32(hdFuelId.Value);

            decimal tmpDecimal = 0;
            if (txtNoFuel.Text != "")
                decimal.TryParse(txtNoFuel.Text, style, culture, out tmpDecimal);

            var _existedFuel = listFuelDetail.FirstOrDefault(o => o.FuelId == _FuelId);
            if (_existedFuel != null)
            {
                _existedFuel.NoFuel = tmpDecimal;
                _existedFuel.Reason = txtReason.Text.Trim();
            }
            else
            {
                HiddenField hdGroupFuelId = ri.FindControl("hdGroupFuelId") as HiddenField;
                HiddenField hdMeasurementId = ri.FindControl("hdMeasurementId") as HiddenField;
                var _insertd = new DE_ReportFuelDetail
                {
                    FuelId = _FuelId,
                    NoFuel = tmpDecimal,
                    ReportId = ReportId,
                    EnterpriseId = memVal.OrgId,
                    Year = ReportYear,
                    IsNextYear = true,
                    Reason = txtReason.Text.Trim(),
                    GroupFuelId = Convert.ToInt32(hdMeasurementId.Value),
                    MeasurementId = Convert.ToInt32(hdMeasurementId.Value),
                };
                rp.DE_ReportFuelDetail.Add(_insertd);
            }
        }

        //SaveChanges
        rp.SaveChanges();

        btAddFuelFuture.Visible = true;
        btAddFuelFutureUpdate.Visible = false;
        btAddFuelFutureCancel.Visible = false;

        foreach (RepeaterItem ri in rptFuelFuture.Items)
        {
            TextBox txtNoFuel = ri.FindControl("txtNoFuel") as TextBox;
            txtNoFuel.ReadOnly = true;

            TextBox txtReason = ri.FindControl("txtReason") as TextBox;
            txtReason.ReadOnly = true;
        }
    }

    private void BindFuelFuture()
    {
        ReportModels rp = new ReportModels();
        var data = (from a in rp.DE_Fuel
                    join b in rp.DE_ReportFuelDetail.Where(x => x.ReportId == ReportId && x.IsNextYear == true) on a.Id equals b.FuelId into ab
                    from c in ab.DefaultIfEmpty()
                    join d in rp.DE_GroupFuel on a.GroupFuelId equals d.Id
                    join e in rp.DE_Measurement on a.MeasurementId equals e.Id
                    where d.GroupCode != ReportKey.FuelGroupKey_POWER
                    orderby a.FuelOrder ascending
                    select new
                    {
                        FuelId = a.Id,
                        FuelName = a.FuelName,
                        MeasurementName = e.MeasurementName,
                        NoFuel = c.NoFuel,
                        Reason = c.Reason,
                        GroupFuelId = d.Id,
                        MeasurementId = a.MeasurementId
                    }).ToList();

        rptFuelFuture.DataSource = data;
        rptFuelFuture.DataBind();
    }


    //b. Sử dụng điện
    protected void btAddElectrictFuture_Click(object sender, EventArgs e)
    {
        btAddElectrictFuture.Visible = false;
        btAddElectrictFutureUpdate.Visible = true;
        btAddElectrictFutureCancel.Visible = true;

        txtUsingElectrictFuture_InstalledCapacity.ReadOnly = false;
        txtUsingElectrictFuture_Quantity.ReadOnly = false;
        txtUsingElectrictFuture_CongSuatBanRa.ReadOnly = false;
        txtUsingElectrictFuture_SanLuongBanRa.ReadOnly = false;

        foreach (RepeaterItem ri in rptUsingElectrictFuture.Items)
        {
            TextBox txtInstalledCapacity = ri.FindControl("txtInstalledCapacity") as TextBox;
            txtInstalledCapacity.ReadOnly = false;

            TextBox txtProduceQty = ri.FindControl("txtProduceQty") as TextBox;
            txtProduceQty.ReadOnly = false;
        }
    }

    protected void btAddElectrictFutureCancel_Click(object sender, EventArgs e)
    {
        btAddElectrictFuture.Visible = true;
        btAddElectrictFutureUpdate.Visible = false;
        btAddElectrictFutureCancel.Visible = false;

        txtUsingElectrictFuture_InstalledCapacity.ReadOnly = true;
        txtUsingElectrictFuture_Quantity.ReadOnly = true;
        txtUsingElectrictFuture_CongSuatBanRa.ReadOnly = true;
        txtUsingElectrictFuture_SanLuongBanRa.ReadOnly = true;

        foreach (RepeaterItem ri in rptUsingElectrictFuture.Items)
        {
            TextBox txtInstalledCapacity = ri.FindControl("txtInstalledCapacity") as TextBox;
            txtInstalledCapacity.ReadOnly = true;

            TextBox txtProduceQty = ri.FindControl("txtProduceQty") as TextBox;
            txtProduceQty.ReadOnly = true;
        }
    }

    protected void btAddElectrictFutureUpdate_Click(object sender, EventArgs e)
    {
        ReportModels rp = new ReportModels();
        //DE_UsingElectrict
        var checkUsingElectrict = rp.DE_UsingElectrict.Any(x => x.ReportId == ReportId && x.IsPlan == true);
        var _usingElectrict = new DE_UsingElectrict();
        if (checkUsingElectrict == true)
            _usingElectrict = rp.DE_UsingElectrict.FirstOrDefault(x => x.ReportId == ReportId && x.IsPlan == true);
        else
        {
            _usingElectrict.ReportId = ReportId;
            _usingElectrict.IsPlan = true;
            _usingElectrict.ReportYear = ReportYear;
            _usingElectrict.FuelId = 0;
        }

        if (txtUsingElectrictFuture_InstalledCapacity.Text.Trim() != "")
            _usingElectrict.InstalledCapacity = Convert.ToDecimal(txtUsingElectrictFuture_InstalledCapacity.Text.Trim(), culture);

        if (txtUsingElectrictFuture_Quantity.Text.Trim() != "")
            _usingElectrict.Quantity = Convert.ToDecimal(txtUsingElectrictFuture_Quantity.Text.Trim(), culture);

        if (txtUsingElectrictFuture_CongSuatBanRa.Text.Trim() != "")
            _usingElectrict.CongSuatBan = Convert.ToDecimal(txtUsingElectrictFuture_CongSuatBanRa.Text.Trim(), culture);

        if (txtUsingElectrictFuture_SanLuongBanRa.Text.Trim() != "")
            _usingElectrict.SanLuongBan = Convert.ToDecimal(txtUsingElectrictFuture_SanLuongBanRa.Text.Trim(), culture);
        if (checkUsingElectrict == false)
            rp.DE_UsingElectrict.Add(_usingElectrict);

        //DE_ElectrictProduce
        var checkElectrictSelfProduce = rp.DE_ElectrictProduce.Any(x => x.ReportId == ReportId);

        if (checkElectrictSelfProduce == true) //Update DE_ElectrictProduce
        {
            var tempData = rp.DE_ElectrictProduce.Where(x => x.ReportId == ReportId).ToList();
            foreach (RepeaterItem ri in rptUsingElectrictFuture.Items)
            {
                TextBox txtInstalledCapacity = ri.FindControl("txtInstalledCapacity") as TextBox;
                TextBox txtProduceQty = ri.FindControl("txtProduceQty") as TextBox;
                HiddenField hdTechKey = ri.FindControl("hdTechKey") as HiddenField;
                var tmp = tempData.FirstOrDefault(x => x.TechKey == hdTechKey.Value);
                if (tmp != null)
                {
                    if (txtInstalledCapacity.Text.Trim() != "")
                        tmp.InstalledCapacity = Convert.ToDecimal(txtInstalledCapacity.Text.Trim(), culture);
                    if (txtProduceQty.Text.Trim() != "")
                        tmp.ProduceQty = Convert.ToDecimal(txtProduceQty.Text.Trim(), culture);
                }
            }
        }
        else //Insert DE_ElectrictProduce
        {
            foreach (RepeaterItem ri in rptUsingElectrictFuture.Items)
            {
                TextBox txtInstalledCapacity = ri.FindControl("txtInstalledCapacity") as TextBox;
                TextBox txtProduceQty = ri.FindControl("txtProduceQty") as TextBox;
                HiddenField hdTechKey = ri.FindControl("hdTechKey") as HiddenField;
                DE_ElectrictProduce _usingElectrictInserted = new DE_ElectrictProduce();
                _usingElectrictInserted.ReportId = ReportId;
                _usingElectrictInserted.ReportYear = ReportYear;
                _usingElectrictInserted.TechKey = hdTechKey.Value;
                _usingElectrictInserted.IsPlan = true;

                if (txtInstalledCapacity.Text.Trim() != "")
                    _usingElectrictInserted.InstalledCapacity = Convert.ToDecimal(txtInstalledCapacity.Text.Trim(), culture);
                if (txtProduceQty.Text.Trim() != "")
                    _usingElectrictInserted.ProduceQty = Convert.ToDecimal(txtProduceQty.Text.Trim(), culture);
                rp.DE_ElectrictProduce.Add(_usingElectrictInserted);
            }
        }
        rp.SaveChanges();

        btAddElectrictFutureCancel_Click(sender, e);
    }

    private void BindUsingElectrictFuture()
    {
        ReportModels rp = new ReportModels();
        //DE_UsingElectrict
        var data = rp.DE_UsingElectrict.FirstOrDefault(o => o.ReportId == ReportId && o.IsPlan == true);
        if (data != null)
        {
            txtUsingElectrictFuture_InstalledCapacity.Text = data.InstalledCapacity != null ? data.InstalledCapacity.ToString() : "0";
            txtUsingElectrictFuture_Quantity.Text = data.Quantity != null ? data.Quantity.ToString() : "0";
            txtUsingElectrictFuture_CongSuatBanRa.Text = data.CongSuatBan != null ? data.CongSuatBan.ToString() : "0";
            txtUsingElectrictFuture_SanLuongBanRa.Text = data.SanLuongBan != null ? data.SanLuongBan.ToString() : "0";
        }

        //DE_ElectrictProduce
        var _eSelfProduce = (from a in rp.DE_ElectrictTechnology
                             join b in rp.DE_ElectrictProduce.Where(x => x.ReportId == ReportId && x.IsPlan == true) on a.TechKey equals b.TechKey into ab
                             from c in ab.DefaultIfEmpty()
                             orderby a.TechDesc ascending
                             select new
                             {
                                 TechKey = a.TechKey,
                                 TechName = a.TechName,
                                 InstalledCapacity = c.InstalledCapacity != null ? c.InstalledCapacity : 0,
                                 ProduceQty = c.ProduceQty,
                             }).ToList();

        rptUsingElectrictFuture.DataSource = _eSelfProduce;
        rptUsingElectrictFuture.DataBind();
    }

    #endregion

    //3. Giải pháp tiết kiệm năng lương
    #region 3. Giải pháp tiết kiệm năng lương
    private void BindResultTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(memVal.OrgId, ReportId, false, false);
        rptResultTKNL.DataSource = tbl;
        rptResultTKNL.DataBind();
    }

    protected void rptResultTKNL_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            BindResultTKNL();
        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            //btnDelete.Visible = AllowEdit;
            btnDelete.Visible = true;
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            rpt = rptbso.FindByKey(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            hddkhtknl.Value = rpt.Id.ToString();
            txtMucDichGPTT.Text = rpt.MucTieuGP;
            txtMucTietKiemNLTT.Text = rpt.MucTKThucTe;
            if (rpt.IdGiaPhap > 0)
                ddlSolution2.SelectedValue = rpt.IdGiaPhap.ToString();
            txtTKCPThucTe.Text = rpt.MucTKCPThucTe;
            txtChiPhiThucTe.Text = rpt.CPThucTe;
            txtGhiChuTT.Text = rpt.GhiChuTT;
            txtTuongDuongTT.Text = rpt.TuongDuongTT;
            if (!string.IsNullOrEmpty(rpt.HeThongSuDung))
                ddlUseSysName.SelectedValue = rpt.HeThongSuDung;

            if (rpt.LoaiNhienLieu > 0)
            {
                ddlFuelType2.SelectedValue = rpt.LoaiNhienLieu.ToString();
                BindMeasurement2();
            }
            if (rpt.MeasurementId > 0)
                ddlMeasure2.SelectedValue = rpt.MeasurementId.ToString();
            txtLoiIchKhacTT.Text = rpt.LoiIchKhacTT;
            //try
            //{
            //    txtKhaNangTKNL.Text = rpt.KhaNangThucHien;
            //}
            //catch { }
            //txtTKNLMucTieuDukien.Text = rpt.MucTietKiemDuKien;
            hddkhtknl.Value = rpt.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkhd", "ShowDialogSolutionResultOne(" + hddkhtknl.Value + ");", true);
        }
    }


    protected void BindUsingEnerySystem()
    {
        ReportModels reportModels = new ReportModels();
        var res = reportModels.DE_UsingSystem.Where(o => o.SysState == 0 && o.SysGroup == ddlPhanLoaiHeThong.SelectedValue).ToList();

        ddlUseSysName.DataValueField = "SysCode";
        ddlUseSysName.DataTextField = "SysName";
        ddlUseSysName.DataSource = res;
        ddlUseSysName.DataBind();

        ddlUseSysNamePlan.DataValueField = "SysCode";
        ddlUseSysNamePlan.DataTextField = "SysName";
        ddlUseSysNamePlan.DataSource = res;
        ddlUseSysNamePlan.DataBind();
    }
    void BindMeasurement()
    {
        ddlMeasure.Items.Clear();
        DataTable list = new DataTable();
        if (ddlFuelType.SelectedIndex > 0)
        {
            list = new MeasurementFuelService().GetListMeasurement(Convert.ToInt32(ddlFuelType.SelectedValue));
        }

        ddlMeasure.DataSource = list;
        ddlMeasure.DataValueField = "Id";
        ddlMeasure.DataTextField = "MeasurementName";
        ddlMeasure.DataBind();
        ddlMeasure.Items.Insert(0, new ListItem("---Chọn đơn vị---", ""));
        if (ddlMeasure.Items.Count == 2)
        {
            ddlMeasure.SelectedIndex = 1;
        }
    }
    void BindMeasurement2()
    {
        ddlMeasure2.Items.Clear();
        DataTable list = new DataTable();
        if (ddlFuelType2.SelectedIndex > 0)
        {
            list = new MeasurementFuelService().GetListMeasurement(Convert.ToInt32(ddlFuelType2.SelectedValue));
        }

        ddlMeasure2.DataSource = list;
        ddlMeasure2.DataValueField = "Id";
        ddlMeasure2.DataTextField = "MeasurementName";
        ddlMeasure2.DataBind();
        ddlMeasure2.Items.Insert(0, new ListItem("---Chọn đơn vị---", ""));
        if (ddlMeasure2.Items.Count == 2)
        {
            ddlMeasure2.SelectedIndex = 1;
        }
    }

    void BindFuel()
    {
        ReportModels rp = new ReportModels();
        var list = rp.DE_Fuel.OrderBy(o => o.FuelOrder).ToList();

        int GroupId = 0;
        if (ddlFuelType.SelectedIndex > 0)
            GroupId = Convert.ToInt32(ddlFuelType.SelectedValue);

        var listSearch = from o in list where o.GroupFuelId == GroupId || GroupId == 0 select o;

        ddlFuelType.DataSource = listSearch;
        ddlFuelType.DataValueField = "Id";
        ddlFuelType.DataTextField = "FuelName";
        ddlFuelType.DataBind();
        ddlFuelType.Items.Insert(0, new ListItem("---Chọn loại nhiên liệu---", ""));

        ddlFuelType2.DataSource = listSearch;
        ddlFuelType2.DataValueField = "Id";
        ddlFuelType2.DataTextField = "FuelName";
        ddlFuelType2.DataBind();
        ddlFuelType2.Items.Insert(0, new ListItem("---Chọn loại nhiên liệu---", ""));


        ddlProductFuel.DataSource = listSearch;
        ddlProductFuel.DataValueField = "Id";
        ddlProductFuel.DataTextField = "FuelName";
        ddlProductFuel.DataBind();
        ddlProductFuel.Items.Insert(0, new ListItem("---Chọn loại năng lượng---", ""));

        ddlLoaiNangLuong.DataSource = listSearch;
        ddlLoaiNangLuong.DataValueField = "Id";
        ddlLoaiNangLuong.DataTextField = "FuelName";
        ddlLoaiNangLuong.DataBind();
        ddlLoaiNangLuong.Items.Insert(0, new ListItem("---Chọn loại năng lượng---", ""));
    }

    protected void ddlFuel2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMeasurement2();
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "ShowDialogSolutionResultOne('" + hddkhtknl.Value + "');", true);
    }
    protected void ddlPhanLoaiHeThong_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindUsingEnerySystem();
    }
    protected void ddlPhanLoaiHeThongPlan_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReportModels reportModels = new ReportModels();
        var res = reportModels.DE_UsingSystem.Where(o => o.SysState == 0 && o.SysGroup == ddlPhanLoaiHeThongPlan.SelectedValue).ToList();
        ddlUseSysNamePlan.DataValueField = "SysCode";
        ddlUseSysNamePlan.DataTextField = "SysName";
        ddlUseSysNamePlan.DataSource = res;
        ddlUseSysNamePlan.DataBind();
    }
    protected void ddlFuel_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindMeasurement();
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "ShowDialogSolutionPlanOne('" + hddkhtknl.Value + "');", true);
    }
    void BindSolution()
    {
        ddlSolution2.Items.Clear();

        GiaiPhapService gps = new GiaiPhapService();
        DataTable lst = gps.GetGiaiPhepByEnerprise(memVal.OrgId);

        ddlSolution.Items.Clear();
        ddlSolution.DataSource = lst;
        ddlSolution.DataBind();
        ddlSolution.Items.Insert(0, new ListItem("---Chọn giải pháp---", ""));

        ddlSolution2.DataSource = lst;
        ddlSolution2.DataBind();
        ddlSolution2.Items.Insert(0, new ListItem("---Chọn giải pháp---", ""));
    }
    private void BindPlanTKNL()
    {
        PlanTKNLService plangpservice = new PlanTKNLService();
        DataTable tbl = new DataTable();
        tbl = plangpservice.GetPlanTKNLEnerprise(memVal.OrgId, ReportId, false, true);
        rptSolutionPlan.DataSource = tbl;
        rptSolutionPlan.DataBind();
    }
    protected void rptPlanTKNL_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            rptbso.Delete(int.Parse(btnDelete.CommandArgument));
            BindPlanTKNL();
        }
        else if (e.CommandName.Equals("edit"))
        {
            PlanTKNL rpt = new PlanTKNL();
            PlanTKNLService rptbso = new PlanTKNLService();
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            rpt = rptbso.FindByKey(int.Parse(btnEdit.CommandArgument));
            txtmuctieuTKNL.Text = rpt.MucTieuGP;
            txtchiphidukienTKNL.Text = rpt.ChiPhiDuKien;
            if (rpt.IdGiaPhap > 0)
                ddlSolution.SelectedValue = rpt.IdGiaPhap.ToString();
            //try
            //{
            //    ddlCamKet.SelectedValue = rpt.MucCamKet;
            //}
            //catch { }
            if (rpt.LoaiNhienLieu > 0)
            {
                ddlFuelType.SelectedValue = rpt.LoaiNhienLieu.ToString();
                BindMeasurement();
            }
            if (rpt.MeasurementId > 0)
                ddlMeasure.SelectedValue = rpt.MeasurementId.ToString();
            txtGhiChu.Text = rpt.GhiChu;
            txtLoiIchKhac.Text = rpt.LoiIchKhac;
            txtThanhTien.Text = rpt.ThanhTien;
            txtTuongDuong.Text = rpt.TuongDuong;

            //txtKhaNangTKNL.Text = rpt.KhaNangThucHien;

            txtTKNLMucTieuDukien.Text = rpt.MucTietKiemDuKien;
            hddkhtknl.Value = rpt.Id.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkhd", "ShowDialogSolutionPlanOne(" + hddkhtknl.Value + ");", true);
        }
    }

    public void btnSaveSolutionResult_Click(object sender, EventArgs e)
    {
        PlanTKNLService planser = new PlanTKNLService();
        PlanTKNL plantknl = new PlanTKNL();
        plantknl.NamBatDau = ReportYear;
        plantknl.NamKetThuc = ReportYear;
        plantknl.CPThucTe = txtChiPhiThucTe.Text;
        plantknl.MucTieuGP = txtMucDichGPTT.Text;
        plantknl.MucTKCPThucTe = txtTKCPThucTe.Text;
        plantknl.MucTKThucTe = txtMucTietKiemNLTT.Text;
        plantknl.CPThucTe = txtChiPhiThucTe.Text.Trim();
        plantknl.LoiIchKhacTT = txtLoiIchKhacTT.Text.Trim();
        plantknl.TuongDuongTT = txtTuongDuongTT.Text.Trim();
        plantknl.GhiChuTT = txtGhiChuTT.Text.Trim();
        plantknl.IsFiveYear = false;
        plantknl.IsPlan = false;
        plantknl.ReportId = ReportId;
        plantknl.IdPlan = ReportId;
        plantknl.EnterpriseId = memVal.OrgId;
        plantknl.HeThongSuDung = ddlUseSysName.SelectedValue;
        if (ddlSolution2.SelectedIndex > 0)
            plantknl.IdGiaPhap = Convert.ToInt32(ddlSolution2.SelectedValue);
        if (ddlFuelType2.SelectedIndex > 0)
            plantknl.LoaiNhienLieu = Convert.ToInt32(ddlFuelType2.SelectedValue);
        if (ddlMeasure2.SelectedIndex > 0)
            plantknl.MeasurementId = Convert.ToInt32(ddlMeasure2.SelectedValue);

        if (hddkhtknl.Value != "" && Convert.ToInt32(hddkhtknl.Value) > 0)
        {
            plantknl.Id = Convert.ToInt32(hddkhtknl.Value);
            if (planser.Update(plantknl) != null)
            {
                BindResultTKNL();
                hddkhtknl.Value = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSolutionResultOne(" + hddkhtknl.Value + ");", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            }
        }
        else
        {
            int i = planser.Insert(plantknl);
            if (i > 0)
            {
                BindResultTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSolutionResultOne();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Thêm mới kê hoạch không thành công. Vui lòng thử lại!');", true);
            }
        }
    }

    public void btnSavePlan_Click(object sender, EventArgs e)
    {
        PlanTKNLService planser = new PlanTKNLService();
        PlanTKNL plantknl = new PlanTKNL();
        plantknl.NamBatDau = ReportYear + 1;
        plantknl.NamKetThuc = ReportYear + 1;
        plantknl.ThanhTien = txtThanhTien.Text.Trim();
        plantknl.ChiPhiDuKien = txtchiphidukienTKNL.Text;
        plantknl.MucTieuGP = txtmuctieuTKNL.Text;
        //plantknl.KhaNangThucHien = txtKhaNangTKNL.Text;
        //plantknl.MucCamKet = ddlCamKet.SelectedValue;
        plantknl.MucTietKiemDuKien = txtTKNLMucTieuDukien.Text;
        plantknl.LoiIchKhac = txtLoiIchKhac.Text.Trim();
        plantknl.TuongDuong = txtTuongDuong.Text.Trim();
        plantknl.GhiChu = txtGhiChu.Text.Trim();
        plantknl.IsFiveYear = false;
        plantknl.IsPlan = true;
        plantknl.HeThongSuDung = ddlUseSysNamePlan.SelectedValue;

        plantknl.EnterpriseId = memVal.OrgId;
        if (ddlSolution.SelectedIndex > 0)
            plantknl.IdGiaPhap = Convert.ToInt32(ddlSolution.SelectedValue);
        if (ddlFuelType.SelectedIndex > 0)
            plantknl.LoaiNhienLieu = Convert.ToInt32(ddlFuelType.SelectedValue);
        if (ddlMeasure.SelectedIndex > 0)
            plantknl.MeasurementId = Convert.ToInt32(ddlMeasure.SelectedValue);
        plantknl.IdPlan = ReportId;
        plantknl.ReportId = ReportId;
        if (hddkhtknl.Value != "" && Convert.ToInt32(hddkhtknl.Value) > 0)
        {
            plantknl.Id = Convert.ToInt32(hddkhtknl.Value);
            if (planser.Update(plantknl) != null)
            {
                BindPlanTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSolutionPlanOne(" + hddkhtknl.Value + ");", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
            }
        }
        else
        {
            int i = planser.Insert(plantknl);
            if (i > 0)
            {
                BindPlanTKNL();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "ShowDialogSolutionPlanOne(0);", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Thêm mới kê hoạch không thành công. Vui lòng thử lại!');", true);
            }
        }

    }
    #endregion

    public void btnSaveProductPlan_Click(object sender, EventArgs e)
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        ProductCapacity productCapacity = new ProductCapacity();
        int _ProductId = Convert.ToInt32(ddlProductPlan.SelectedValue);

        if (txtQtyByDesignPlan.Text != "")
            productCapacity.DesignQuantity = Convert.ToDecimal(txtQtyByDesignPlan.Text);
        if (txtMaxQtyPlan.Text.Trim() != "")
            productCapacity.MaxQuantity = Convert.ToDecimal(txtMaxQtyPlan.Text.Trim());
        productCapacity.IsPlan = true;
        if (txtRateOfRevenue.Text.Trim() != "")
            productCapacity.RateOfRevenue = Convert.ToDecimal(txtRateOfRevenue.Text.Trim());
        if (txtRateOfCost.Text.Trim() != "")
            productCapacity.RateOfCost = Convert.ToDecimal(txtRateOfCost.Text.Trim());
        productCapacity.ProductId = _ProductId;
        productCapacity.ReportId = ReportId;
        productCapacity.ReportYear = ReportYear;

        ReportModels rp = new ReportModels();
        var check = rp.DE_ProductCapacity.FirstOrDefault(o => o.ReportId == ReportId && o.IsPlan == true && o.ProductId == _ProductId);
        if (check != null)
            hdnId.Value = check.Id.ToString();

        int i = 0;
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0)
        {
            productCapacity.Id = Convert.ToInt32(hdnId.Value);
            productCapacity = productCapacityService.Update(productCapacity);
            if (productCapacity != null) i = 1;
        }
        else
        {
            i = productCapacityService.Insert(productCapacity);
        }

        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "AddProductQtyPlan(" + hdnId.Value + ");", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindProductCapacityPlan();
        }

    }

    public void btnSaveProductYear_Click(object sender, EventArgs e)
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        ProductCapacity productCapacity = new ProductCapacity();
        int _ProductId = Convert.ToInt32(ddlProduct.SelectedValue);

        if (txtQtyByDesign.Text != "")
            productCapacity.DesignQuantity = Convert.ToDecimal(txtQtyByDesign.Text);
        if (txtMaxQty.Text.Trim() != "")
            productCapacity.MaxQuantity = Convert.ToDecimal(txtMaxQty.Text.Trim());

        if (txtTieuThuTheoSP.Text.Trim() != "")
            productCapacity.TieuThuNLTheoSP = Convert.ToDecimal(txtTieuThuTheoSP.Text.Trim());

        if (txtDoanhThuTheoSP.Text.Trim() != "")
            productCapacity.DoanhThuTheoSP = Convert.ToDecimal(txtDoanhThuTheoSP.Text.Trim());

        productCapacity.IsPlan = false;
        productCapacity.ProductId = _ProductId;
        productCapacity.ReportId = ReportId;
        productCapacity.ReportYear = ReportYear;

        ReportModels rp = new ReportModels();
        var oldData = rp.DE_ProductCapacity.FirstOrDefault(x => x.ReportId == ReportId && x.ProductId == _ProductId && x.IsPlan == false);
        if (oldData != null)
            hdnId.Value = oldData.Id.ToString();

        int i = 0;
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0) //Cần sửa lại đoạn này
        {
            productCapacity.Id = Convert.ToInt32(hdnId.Value);
            productCapacity = productCapacityService.Update(productCapacity);

            if (txtTieuThuTheoSP.Text != "" && ddlLoaiNangLuong.SelectedIndex > 0 && ddlLoaiNangLuong_DVT.SelectedIndex >= 0)
            {
                InsertUpdate_ProductCapacityFuel(productCapacity.Id);
            }

            if (productCapacity != null) i = 1;
        }
        else
        {
            i = productCapacityService.Insert(productCapacity);

            if (txtTieuThuTheoSP.Text != "" && ddlLoaiNangLuong.SelectedIndex > 0 && ddlLoaiNangLuong_DVT.SelectedIndex >= 0 && i > 0)
            {
                InsertUpdate_ProductCapacityFuel(i);
            }
        }
        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "AddProductQty(" + hdnId.Value + ");", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindProductCapacity();
        }
    }

    private void InsertUpdate_ProductCapacityFuel(int _ProductCapacityId)
    {
        int _fuelId = Convert.ToInt32(ddlLoaiNangLuong.SelectedValue);
        int _meId = Convert.ToInt32(ddlLoaiNangLuong_DVT.SelectedValue);
        ReportModels rp = new ReportModels();
        if (rp.DE_ProductCapacityFuel.Any(o => o.ProductCapacityId == _ProductCapacityId && o.FuelId == _fuelId && o.MeasurementId == _meId)) //update
        {
            var _fuel = rp.DE_ProductCapacityFuel.FirstOrDefault(o => o.ProductCapacityId == _ProductCapacityId && o.FuelId == _fuelId && o.MeasurementId == _meId);
            if (_fuel != null)
                _fuel.ConsumeQty = Convert.ToDecimal(txtTieuThuTheoSP.Text);
            rp.SaveChanges();
        }
        else //Insert
        {
            var _insertedFuel = new DE_ProductCapacityFuel();
            _insertedFuel.ProductCapacityId = _ProductCapacityId;
            _insertedFuel.FuelId = _fuelId;
            _insertedFuel.MeasurementId = _meId;
            _insertedFuel.ConsumeQty = Convert.ToDecimal(txtTieuThuTheoSP.Text);
            rp.DE_ProductCapacityFuel.Add(_insertedFuel);
            rp.SaveChanges();
        }
    }

    private void BindProductCapacityPlan()
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        DataTable tbl = new DataTable();
        tbl = productCapacityService.GetDataCapacity(ReportId, true);
        rptProductPlan.DataSource = tbl;
        rptProductPlan.DataBind();
    }

    public void btnSaveProduct_Click(object sender, EventArgs e)
    {
        ProductService productService = new ProductService();
        Product product = new Product();
        product.ProductName = txtProductName.Text.Trim();
        if (txtYearStart.Text.Trim() != "")
            product.YearStart = Convert.ToInt32(txtYearStart.Text.Trim());
        if (txtYearEnd.Text.Trim() != "")
            product.YearEnd = Convert.ToInt32(txtYearEnd.Text.Trim());
        product.Quantity = Convert.ToInt32(txtDesignQty.Text.Trim());
        product.Measurement = txtMeasurement.Text.Trim();
        product.Note = txtDescription.Text.Trim();
        product.EnterpriseId = memVal.OrgId;
        product.IsProduct = true;
        if (ddlProductFuel.SelectedIndex > 0)
            product.FuelId = Convert.ToInt32(ddlProductFuel.SelectedValue);

        int i = productService.Insert(product);
        if (i <= 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "AddProductQty();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindProduct();
        }
    }

    void BindProduct()
    {
        ddlProduct.Items.Clear();
        IList<Product> list = new List<Product>();

        list = new ProductService().GetListByEnterprise(memVal.OrgId);

        if (list != null && list.Count > 0)
        {
            var listSearch = from o in list where o.IsProduct == true orderby o.ProductName ascending select o;
            ddlProduct.DataSource = listSearch;
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("---Chọn sản phẩm---", ""));

            ddlProductPlan.DataSource = listSearch;
            ddlProductPlan.DataValueField = "Id";
            ddlProductPlan.DataTextField = "ProductName";
            ddlProductPlan.DataBind();
            ddlProductPlan.Items.Insert(0, new ListItem("---Chọn sản phẩm---", ""));
        }
    }
    private void Load_ProductCapacity(int ProductCapacityId)
    {
        ProductCapacity productCapacity = new ProductCapacity();
        ProductCapacityService productCapacityService = new ProductCapacityService();
        productCapacity = productCapacityService.FindByKey(ProductCapacityId);
        if (productCapacity != null)
        {
            try
            {
                txtMaxQty.Text = productCapacity.MaxQuantity.ToString();
                ddlProduct.SelectedValue = productCapacity.ProductId.ToString();
                Product product = new Product();
                ProductService productService = new ProductService();
                product = productService.FindByKey(productCapacity.ProductId);
                ltMeasurement.Text = product.Measurement;
                txtQtyByDesign.Text = product.Quantity.ToString();
                ltMearsurement2.Text = "(" + product.Measurement + ")";
                txtDoanhThuTheoSP.Text = productCapacity.DoanhThuTheoSP.ToString();

                ReportModels rp = new ReportModels();
                if (rp.DE_ProductCapacityFuel.Any(o => o.ProductCapacityId == ProductCapacityId))
                {
                    var data = rp.DE_ProductCapacityFuel.FirstOrDefault(o => o.ProductCapacityId == ProductCapacityId);
                    if (data != null)
                    {
                        ddlLoaiNangLuong.SelectedValue = data.FuelId.ToString();
                        var meList = (from a in rp.DE_Measurement join b in rp.DE_MeasurementFuel on a.Id equals b.MeasurementId where b.FuelId == data.FuelId select a).ToList();
                        Binding_ddlLoaiNangLuong_DVT(meList);

                        ddlLoaiNangLuong_DVT.SelectedValue = data.MeasurementId.ToString();
                        txtTieuThuTheoSP.Text = data.ConsumeQty.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProduct.SelectedIndex > 0)
        {
            Product product = new Product();
            ProductService productService = new ProductService();
            int _ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
            product = productService.FindByKey(_ProductId);
            ltMeasurement.Text = product.Measurement;
            txtQtyByDesign.Text = product.Quantity.ToString();
            ltMearsurement2.Text = "(" + product.Measurement + ")";

            //Nếu đã nhập sản phẩm này lúc trước => cần load lại dữ liệu đã nhập
            ReportModels rp = new ReportModels();
            if (rp.DE_ProductCapacity.Any(o => o.ReportId == ReportId && o.ProductId == _ProductId && o.IsPlan == false))
            {
                var oldData = rp.DE_ProductCapacity.FirstOrDefault(o => o.ReportId == ReportId && o.ProductId == _ProductId && o.IsPlan == false);
                if (oldData != null)
                {
                    Load_ProductCapacity(oldData.Id);
                }
            }
            else
            {
                txtQtyByDesign.Text = "";
                ltMeasurement.Text = "";
                ltMearsurement2.Text = "";
                txtTieuThuTheoSP.Text = "";
                txtMaxQty.Text = "";
                txtDoanhThuTheoSP.Text = "";
            }
        }
        else
        {
            txtQtyByDesign.Text = "";
            ltMeasurement.Text = "";
            ltMearsurement2.Text = "";
            txtTieuThuTheoSP.Text = "";
            txtMaxQty.Text = "";
            txtDoanhThuTheoSP.Text = "";
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "AddProductQty(0);", true);
    }
    private void Binding_ddlLoaiNangLuong_DVT(List<DE_Measurement> data)
    {
        ddlLoaiNangLuong_DVT.DataValueField = "Id";
        ddlLoaiNangLuong_DVT.DataTextField = "MeasurementName";
        ddlLoaiNangLuong_DVT.DataSource = data;
        ddlLoaiNangLuong_DVT.DataBind();

        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0) //load dữ liệu đã có
        {
            ReportModels rp = new ReportModels();
            int _selectedFuel = Convert.ToInt32(ddlLoaiNangLuong.SelectedValue);
            int _ProductCapacityId = Convert.ToInt32(hdnId.Value);
            var oldData = rp.DE_ProductCapacityFuel.FirstOrDefault(o => o.ProductCapacityId == _ProductCapacityId && o.FuelId == _selectedFuel);
            if (oldData != null)
            {
                ddlLoaiNangLuong_DVT.SelectedValue = oldData.MeasurementId.ToString();
                txtTieuThuTheoSP.Text = oldData.ConsumeQty.ToString();
            }
            else
            {
                txtTieuThuTheoSP.Text = "";
            }
        }
        else // dữ liệu mới
        {

        }
    }
    protected void ddlLoaiNangLuong_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLoaiNangLuong.SelectedIndex == 0)
        {
            ddlLoaiNangLuong_DVT.Items.Clear();
            txtTieuThuTheoSP.Text = "";
            return;
        }

        ReportModels rp = new ReportModels();
        int _selectedFuel = Convert.ToInt32(ddlLoaiNangLuong.SelectedValue);
        var data = (from a in rp.DE_Measurement join b in rp.DE_MeasurementFuel on a.Id equals b.MeasurementId where b.FuelId == _selectedFuel select a).ToList();
        Binding_ddlLoaiNangLuong_DVT(data);
        int _pId = 0;


        if (ddlProduct.SelectedIndex > 0)
            _pId = Convert.ToInt32(ddlProduct.SelectedValue);

        var pcc = rp.DE_ProductCapacity.FirstOrDefault(x => x.ReportId == ReportId && x.IsPlan == false && x.ProductId == _pId);


        // if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0) //load dữ liệu đã có
        if (pcc != null)
        {
            //int _ProductCapacityId = Convert.ToInt32(hdnId.Value);
            int _ProductCapacityId = pcc.Id;

            var oldData = rp.DE_ProductCapacityFuel.FirstOrDefault(o => o.ProductCapacityId == _ProductCapacityId && o.FuelId == _selectedFuel);
            if (oldData != null)
            {
                ddlLoaiNangLuong_DVT.SelectedValue = oldData.MeasurementId.ToString();
                txtTieuThuTheoSP.Text = oldData.ConsumeQty.ToString();
            }
            else
            {
                txtTieuThuTheoSP.Text = "";
            }
        }
        else // dữ liệu mới
        {
            txtQtyByDesign.Text = string.Empty;
            txtMaxQty.Text = string.Empty;
            txtTieuThuTheoSP.Text = string.Empty;
            txtDoanhThuTheoSP.Text = string.Empty;
        }
    }

    protected void ddlLoaiNangLuong_DVT_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _selectedMearsement = Convert.ToInt32(ddlLoaiNangLuong_DVT.SelectedValue);
        if (hdnId.Value != "" && Convert.ToInt32(hdnId.Value) > 0) //load dữ liệu đã có
        {
            ReportModels rp = new ReportModels();
            int _selectedFuel = Convert.ToInt32(ddlLoaiNangLuong.SelectedValue);
            int _ProductCapacityId = Convert.ToInt32(hdnId.Value);
            var oldData = rp.DE_ProductCapacityFuel.FirstOrDefault(o => o.ProductCapacityId == _ProductCapacityId && o.FuelId == _selectedFuel && o.MeasurementId == _selectedMearsement);
            txtTieuThuTheoSP.Text = oldData.ConsumeQty.ToString();
        }
        else // dữ liệu mới
        {

        }
    }


    protected void rptProductResult_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            ProductCapacityService rptbso = new ProductCapacityService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            long i = rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (i > 0)
                BindProductCapacity();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            btnEdit.Visible = AllowEdit;
            ProductCapacity productCapacity = new ProductCapacity();
            ProductCapacityService productCapacityService = new ProductCapacityService();
            int ProductCapacityId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            productCapacity = productCapacityService.FindByKey(ProductCapacityId);
            Load_ProductCapacity(ProductCapacityId);
            hdnId.Value = ProductCapacityId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "AddProductQty(" + hdnId.Value + ");", true);
        }
    }
    protected void rptProductPlan_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //DataRowView item = (DataRowView)e.Item.DataItem;
            //if (item["NoFuel_TOE"] != DBNull.Value)
            //{
            //    No_TOE_Future = No_TOE_Future + Convert.ToDecimal(item["NoFuel_TOE"]);
            //}
            LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
            btnDelete.Visible = AllowEdit;
            btnEdit.Visible = AllowEdit;

            //btnEdit.Attributes.Add("onclick", "javascript:UpdateFuel(" + btnEdit.CommandArgument + ",false); return false;");

        }
    }

    protected void rptProductPlan_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            ProductCapacityService rptbso = new ProductCapacityService();
            LinkButton btnDelete = (LinkButton)e.CommandSource;
            btnDelete.Visible = AllowEdit;
            long i = rptbso.Delete(int.Parse(((LinkButton)e.CommandSource).CommandArgument));
            if (i > 0)
                BindProductCapacityPlan();
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "alert('Xóa không thành không. Vui lòng thử lại');", true);
        }
        else if (e.CommandName.Equals("edit"))
        {
            LinkButton btnEdit = (LinkButton)e.CommandSource;
            btnEdit.Visible = AllowEdit;
            ProductCapacity productCapacity = new ProductCapacity();
            ProductCapacityService productCapacityService = new ProductCapacityService();
            int ProductCapacityId = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            productCapacity = productCapacityService.FindByKey(ProductCapacityId);
            if (productCapacity != null)
            {
                try
                {
                    txtMaxQtyPlan.Text = productCapacity.MaxQuantity.ToString();
                    txtQtyByDesignPlan.Text = productCapacity.DesignQuantity.ToString();
                    txtRateOfCost.Text = productCapacity.RateOfCost.ToString();
                    txtRateOfRevenue.Text = productCapacity.RateOfRevenue.ToString();
                    ddlProductPlan.SelectedValue = productCapacity.ProductId.ToString();
                    txtDoanhThuTheoSP.Text = productCapacity.DoanhThuTheoSP.ToString();
                    Product product = new Product();
                    ProductService productService = new ProductService();
                    product = productService.FindByKey(productCapacity.ProductId);
                    ltMeasurementPlan.Text = "(" + product.Measurement + ")";
                }
                catch { }
            }
            hdnId.Value = ProductCapacityId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "AddProductQtyPlan(" + hdnId.Value + ");", true);
        }
    }

    protected void ddlProductPlan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProductPlan.SelectedIndex > 0)
        {
            Product product = new Product();
            ProductService productService = new ProductService();
            product = productService.FindByKey(Convert.ToInt32(ddlProductPlan.SelectedValue));
            ltMeasurementPlan.Text = product.Measurement;
        }
        else
        {
            ltMeasurementPlan.Text = "";
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "AddProductQtyPlan(0);", true);
    }

    public void btnSaveSolution_Click(object sender, EventArgs e)
    {
        GiaiPhap gp = new GiaiPhap();
        GiaiPhapService gpser = new GiaiPhapService();
        gp.EnterpriseId = Convert.ToInt32(memVal.OrgId);
        if (txtnamegp.Text != "")
        {
            gp.MoTa = txtmotagp.Text;
            gp.TenGiaiPhap = txtnamegp.Text;
            if (gpser.Insert(gp) > 0)
            {
                ltNoticeSolution.Text = "Lưu giải pháp mới thành công";
                BindSolution();
            }
            else
                ltNoticeSolution.Text = "Không lưu được giải pháp mới. Vui lòng thử lại";

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showGP", "showgiaiphap();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ac", "alert('Chưa nhập tên giải pháp!');", true);
        }
    }
}