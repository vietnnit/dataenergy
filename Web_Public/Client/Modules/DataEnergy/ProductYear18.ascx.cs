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
using Telerik.Web.Data.Extensions;
using ReportEF;
using System.Globalization;

public partial class Client_Modules_DataEnergy_ProductYear18 : System.Web.UI.UserControl
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
            int Id = 0;
            if (!string.IsNullOrEmpty(Request["ReportId"]))
                int.TryParse(Request["ReportId"].Replace(",", ""), out Id);
            ReportId = Id;
            
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
        }
    }


    //===========================================================================update===============================================

    //Tạo danh sách sản phẩm tĩnh nếu chưa tồn tại
    public void btnSaveProduct_Click(object sender, EventArgs e)
    {
        ProductService productService = new ProductService();
        Product product = new Product();
        product.ProductName = txtProductName.Text.Trim();

        product.YearStart = DateTime.Now.Year;
        product.YearEnd = DateTime.Now.Year;
        product.Quantity = 0;
        product.Measurement = txtMeasurement.Text.Trim();
        product.Note = txtProductName.Text.Trim();
        product.EnterpriseId = memVal.OrgId;
        product.IsProduct = false;
        product.FuelId = 0;
        product.ProductOrder = 10;
        int i = productService.Insert(product);
        BindProductCapacity();
    }
    //Last year
    protected void btnAddProductResult_Click(object sender, EventArgs e)
    {
        btnAddProductResult.Visible = false;
        btnUpdateProductResult.Visible = true;
        btnCancelProductResult.Visible = true;

        foreach (RepeaterItem ri in rptProductResult.Items)
        {
            TextBox txtMaxQuantity = ri.FindControl("txtMaxQuantity") as TextBox;
            txtMaxQuantity.ReadOnly = false;
        }
    }
    protected void btnUpdateProductResult_Click(object sender, EventArgs e)
    {
        ReportModels rp = new ReportModels();
        if (rp.DE_ProductCapacity.Any(x => x.ReportId == ReportId && x.IsPlan == false)) //Update
        {
            var tempData = rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == false).ToList();
            foreach (RepeaterItem ri in rptProductResult.Items)
            {
                TextBox txtMaxQuantity = ri.FindControl("txtMaxQuantity") as TextBox;
                HiddenField hdProductId = ri.FindControl("hdProductId") as HiddenField;
                int ProductId = Convert.ToInt32(hdProductId.Value);
                var pcInfo = tempData.FirstOrDefault(x => x.ProductId == ProductId);
                decimal tmpDecimal = 0;
                if (decimal.TryParse(txtMaxQuantity.Text, style, culture, out tmpDecimal))
                    pcInfo.MaxQuantity = tmpDecimal;
                else
                    pcInfo.MaxQuantity = 0;
            }

            rp.SaveChanges();
        }
        else //Insert
        {
            foreach (RepeaterItem ri in rptProductResult.Items)
            {
                DE_ProductCapacity pcInfo = new DE_ProductCapacity();
                TextBox txtMaxQuantity = ri.FindControl("txtMaxQuantity") as TextBox;
                HiddenField hdProductId = ri.FindControl("hdProductId") as HiddenField;
                int ProductId = Convert.ToInt32(hdProductId.Value);
                pcInfo.ProductId = ProductId;
                pcInfo.ReportId = ReportId;
                pcInfo.IsPlan = false;
                pcInfo.ReportYear = ReportYear;

                decimal tmpDecimal = 0;
                if (decimal.TryParse(txtMaxQuantity.Text, style, culture, out tmpDecimal))
                    pcInfo.MaxQuantity = tmpDecimal;
                else
                    pcInfo.MaxQuantity = 0;
                rp.DE_ProductCapacity.Add(pcInfo);
            }
            rp.SaveChanges();
        }

        btnAddProductResult.Visible = true;
        btnUpdateProductResult.Visible = false;
        btnCancelProductResult.Visible = false;

        foreach (RepeaterItem ri in rptProductResult.Items)
        {
            TextBox txtMaxQuantity = ri.FindControl("txtMaxQuantity") as TextBox;
            txtMaxQuantity.ReadOnly = true;
        }
    }
    protected void btnCancelProductResult_Click(object sender, EventArgs e)
    {
        btnAddProductResult.Visible = true;
        btnUpdateProductResult.Visible = false;
        btnCancelProductResult.Visible = false;
        foreach (RepeaterItem ri in rptProductResult.Items)
        {
            TextBox txtMaxQuantity = ri.FindControl("txtMaxQuantity") as TextBox;
            txtMaxQuantity.ReadOnly = true;
        }
    }

    //Current year
    protected void btnAddProductNextResult_Click(object sender, EventArgs e)
    {
        btnAddProductNextResult.Visible = false;
        btnAddProductNextResultUpdate.Visible = true;
        btnAddProductNextResultCancel.Visible = true;
        foreach (RepeaterItem ri in rptProductPlan.Items)
        {
            TextBox txtMaxQuantity = ri.FindControl("txtMaxQuantity") as TextBox;
            txtMaxQuantity.ReadOnly = false;

            TextBox txtDesignQuantity = ri.FindControl("txtDesignQuantity") as TextBox;
            txtDesignQuantity.ReadOnly = false;
        }
    }

    protected void btnAddProductNextResultCancel_Click(object sender, EventArgs e)
    {
        btnAddProductNextResult.Visible = true;
        btnAddProductNextResultUpdate.Visible = false;
        btnAddProductNextResultCancel.Visible = false;
        foreach (RepeaterItem ri in rptProductPlan.Items)
        {
            TextBox txtMaxQuantity = ri.FindControl("txtMaxQuantity") as TextBox;
            txtMaxQuantity.ReadOnly = true;

            TextBox txtDesignQuantity = ri.FindControl("txtDesignQuantity") as TextBox;
            txtDesignQuantity.ReadOnly = true;
        }
    }

    protected void btnAddProductNextResultUpdate_Click(object sender, EventArgs e)
    {
        ReportModels rp = new ReportModels();
        if (rp.DE_ProductCapacity.Any(x => x.ReportId == ReportId && x.IsPlan == true)) //Update
        {
            var tempData = rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == true).ToList();
            foreach (RepeaterItem ri in rptProductPlan.Items)
            {
                TextBox txtMaxQuantity = ri.FindControl("txtMaxQuantity") as TextBox;
                TextBox txtDesignQuantity = ri.FindControl("txtDesignQuantity") as TextBox;
                HiddenField hdProductId = ri.FindControl("hdProductId") as HiddenField;
                int ProductId = Convert.ToInt32(hdProductId.Value);
                var pcInfo = tempData.FirstOrDefault(x => x.ProductId == ProductId);
                decimal tmpDecimal = 0;

                if (decimal.TryParse(txtMaxQuantity.Text, style, culture, out tmpDecimal))
                    pcInfo.MaxQuantity = tmpDecimal;
                else
                    pcInfo.MaxQuantity = 0;

                if (decimal.TryParse(txtDesignQuantity.Text, style, culture, out tmpDecimal))
                    pcInfo.DesignQuantity = tmpDecimal;
                else
                    pcInfo.DesignQuantity = 0;
            }

            rp.SaveChanges();
        }
        else //Insert
        {
            foreach (RepeaterItem ri in rptProductPlan.Items)
            {
                DE_ProductCapacity pcInfo = new DE_ProductCapacity();
                TextBox txtMaxQuantity = ri.FindControl("txtMaxQuantity") as TextBox;
                TextBox txtDesignQuantity = ri.FindControl("txtDesignQuantity") as TextBox;
                HiddenField hdProductId = ri.FindControl("hdProductId") as HiddenField;
                int ProductId = Convert.ToInt32(hdProductId.Value);
                pcInfo.ProductId = ProductId;
                pcInfo.ReportId = ReportId;
                pcInfo.IsPlan = true;
                pcInfo.ReportYear = ReportYear;

                decimal tmpDecimal = 0;
                if (decimal.TryParse(txtMaxQuantity.Text, style, culture, out tmpDecimal))
                    pcInfo.MaxQuantity = tmpDecimal;
                else
                    pcInfo.MaxQuantity = 0;

                if (decimal.TryParse(txtDesignQuantity.Text, style, culture, out tmpDecimal))
                    pcInfo.DesignQuantity = tmpDecimal;
                else
                    pcInfo.DesignQuantity = 0;

                rp.DE_ProductCapacity.Add(pcInfo);
            }
            rp.SaveChanges();
        }

        btnAddProductNextResultCancel_Click(sender, e);
    }


    //Binding
    private void BindProductCapacity()
    {
        ReportModels rp = new ReportModels();
        var data = (from a in rp.DE_Product
                    join b in rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == false) on a.Id equals b.ProductId into ab
                    from c in ab.DefaultIfEmpty()
                    where a.EnterpriseId == memVal.OrgId
                    orderby a.ProductOrder ascending
                    select new
                    {
                        ProductId = a.Id,
                        ProductName = a.ProductName,
                        Measurement = a.Measurement,
                        MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString())
                        //DesignQuantity = (c == null ? string.Empty : c.DesignQuantity.ToString())
                    }).ToList();

        rptProductResult.DataSource = data;
        rptProductResult.DataBind();


        var dataNextYear = (from a in rp.DE_Product
                            join b in rp.DE_ProductCapacity.Where(x => x.ReportId == ReportId && x.IsPlan == true) on a.Id equals b.ProductId into ab
                            from c in ab.DefaultIfEmpty()
                            where a.EnterpriseId == memVal.OrgId
                            orderby a.ProductOrder ascending
                            select new
                            {
                                ProductId = a.Id,
                                ProductName = a.ProductName,
                                Measurement = a.Measurement,
                                MaxQuantity = (c == null ? string.Empty : c.MaxQuantity.ToString()),
                                DesignQuantity = (c == null ? string.Empty : c.DesignQuantity.ToString())
                            }).ToList();

        rptProductPlan.DataSource = dataNextYear;
        rptProductPlan.DataBind();

    }
    void BindData()
    {
        ReportModels rp = new ReportModels();
        var data = rp.DE_ReportFuel.FirstOrDefault(x => x.Id == ReportId && x.ReportType == ReportKey.PLAN);
        if (data != null)
        {
            ltReportYear.Text = (data.Year - 1).ToString();
            ltSolutionResult.Text = (data.Year - 1).ToString();
            ltReportNext.Text = data.Year.ToString();
            ltSolutionNextYear.Text = data.Year.ToString();
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

    protected void rptResultTB_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
        //    LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
        //    btnDelete.Visible = AllowEdit;
        //    btnEdit.Visible = AllowEdit;
        //}
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
    //protected void rptResultTB_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        LinkButton btnDelete = (LinkButton)e.Item.FindControl("btnDelete");
    //        LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEdit");
    //        btnDelete.Visible = AllowEdit;
    //        btnEdit.Visible = AllowEdit;
    //    }
    //}
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
}