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

public partial class Client_Module_DataEngery_ProductYear : System.Web.UI.UserControl
{
    UserValidation m_UserValidation = new UserValidation();
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
            BindProduct();
            BindFuel();
            BindData();
            if (ReportId > 0)
            {
                BindInfrastructure();
                BindProductCapacity();
                BindProductCapacityPlan();
                BindElectrictPlan();
                BindElectrictResult();
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
                ltActiveYear.Text = enter.ActiveYear.ToString();
            }
        }
        ltReportYear.Text = string.Format("(Năng lực sản xuất năm <b>{0}</b>)", (ReportYear - 1));
        ltReportNext.Text = ReportYear.ToString();
        //ReportFuel report = new ReportFuelService().FindByKey(ReportId);
        //if (report != null)
        //{
        //ltOldYear.Text = ("I. Kết quả thực hiện năm " + ReportYear.ToString()).ToUpper();
        //ltNextYear.Text = ("II. Kế hoạch thực hiện năm " + (ReportYear + 1).ToString()).ToUpper();
        //}
        btnAddProductPlan.Visible = btnAddProductNext.Visible = btnAddProductNextResult.Visible = btnAddProductResult.Visible = btnEditElecttrict.Visible = btnEditElectrictPlan.Visible = btnEditInfo.Visible = AllowEdit; ;

    }
    void BindFuel()
    {
        ddlFuel.Items.Clear();
        ddlFuelPlan.Items.Clear();
        IList<Fuel> list = new List<Fuel>();
        if (!AspNetCache.CheckCache(Constants.Cache_ReportFuel_Fuel_All))
        {
            list = new FuelService().FindAll();
            AspNetCache.SetCache(Constants.Cache_ReportFuel_Fuel_All, list);
        }
        else
            list = (IList<Fuel>)AspNetCache.GetCache(Constants.Cache_ReportFuel_Fuel_All);
        int GroupId = 0;
        if (ddlFuel.SelectedIndex > 0)
            GroupId = Convert.ToInt32(ddlFuel.SelectedValue);

        var listSearch = from o in list where o.GroupFuelId == GroupId || GroupId == 0 select o;
        ddlFuel.DataSource = listSearch;
        ddlFuel.DataValueField = "Id";
        ddlFuel.DataTextField = "FuelName";
        ddlFuel.DataBind();
        ddlFuel.Items.Insert(0, new ListItem("---Chọn loại nhiên liệu---", ""));

        ddlFuelPlan.DataSource = listSearch;
        ddlFuelPlan.DataValueField = "Id";
        ddlFuelPlan.DataTextField = "FuelName";
        ddlFuelPlan.DataBind();
        ddlFuelPlan.Items.Insert(0, new ListItem("---Chọn loại nhiên liệu---", ""));

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

    protected void rptProductResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                }
                catch { }
            }
            hdnId.Value = ProductCapacityId.ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "AddProductQty(" + hdnId.Value + ");", true);
        }
    }
    public void btnSaveDevice_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    PlanTB plantb = new PlanTB();
        //    PlanTBService plantbservice = new PlanTBService();
        //    if (hddkhTB.Value != "")
        //    {
        //        plantb = plantbservice.FindByKey(Convert.ToInt32(hddkhTB.Value));
        //        if (ddlCacThucLD.SelectedIndex > 0)
        //            plantb.CachLapDat = ddlCacThucLD.SelectedValue;
        //        plantb.EnterpriseId = Convert.ToInt32(memVal.OrgId);
        //        plantb.NameTB = txtTenTB.Text;
        //        plantb.TinhNang = txtTinhNangTB.Text;
        //        plantb.LyDo = txtlydoTB.Text;
        //        plantb.Nam = (ReportYear + 1);//Convert.ToInt32(txtnamTB.Text);
        //        if (ddlKhaNangTB.SelectedIndex > 0)
        //            plantb.KhaNang = ddlKhaNangTB.SelectedValue;
        //        plantb.CamKet = txtCamKetTB.Text.Trim();
        //        plantb.IdPlan = ReportId;
        //        plantb.IsFiveYear = false;
        //        plantb.IsPlan = true;
        //        plantb.IsNew = false;
        //        int i = plantbservice.Update(plantb).Id;
        //        if (i > 0)
        //        {

        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
        //        }

        //    }
        //    else
        //    {
        //        //plantb.CamKet = txtMucCamKetTB.Text;
        //        if (ddlCacThucLD.SelectedIndex > 0)
        //            plantb.CachLapDat = ddlCacThucLD.SelectedValue;
        //        plantb.EnterpriseId = Convert.ToInt32(memVal.OrgId);
        //        plantb.NameTB = txtTenTB.Text;
        //        plantb.TinhNang = txtTinhNangTB.Text;
        //        plantb.LyDo = txtlydoTB.Text;
        //        plantb.Nam = ReportYear + 1;//Convert.ToInt32(txtnamTB.Text);
        //        if (ddlKhaNangTB.SelectedIndex > 0)
        //            plantb.KhaNang = ddlKhaNangTB.SelectedValue;
        //        plantb.CamKet = txtCamKetTB.Text.Trim();
        //        plantb.IsFiveYear = false;
        //        plantb.IsPlan = true;
        //        plantb.IsNew = false;
        //        plantb.IdPlan = ReportId;
        //        int i = plantbservice.Insert(plantb);
        //        if (i > 0)
        //        {

        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "showtb", "showgiaiphapTB('1');", true);
        //            ScriptManager.RegisterStartupScript(this, GetType(), "showx", "alert('Cập nhật không thành công!');", true);

        //        }
        //    }
        //}
        //catch (Exception)
        //{

        //    throw;
        //}

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
    public void btnSaveProductYear_Click(object sender, EventArgs e)
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        ProductCapacity productCapacity = new ProductCapacity();

        if (txtQtyByDesign.Text != "")
            productCapacity.DesignQuantity = Convert.ToDecimal(txtQtyByDesign.Text);
        if (txtMaxQty.Text.Trim() != "")
            productCapacity.MaxQuantity = Convert.ToDecimal(txtMaxQty.Text.Trim());
        productCapacity.IsPlan = false;
        productCapacity.ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
        productCapacity.ReportId = ReportId;
        productCapacity.ReportYear = ReportYear;

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
            ScriptManager.RegisterStartupScript(this, GetType(), "showgpkh", "AddProductQty(" + hdnId.Value + ");", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công. Vui lòng thử lại!');", true);
        }
        else
        {
            BindProductCapacity();
        }

    }

    public void btnSaveProductPlan_Click(object sender, EventArgs e)
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        ProductCapacity productCapacity = new ProductCapacity();
        if (txtQtyByDesign.Text != "")
            productCapacity.DesignQuantity = Convert.ToDecimal(txtQtyByDesign.Text);
        if (txtMaxQtyPlan.Text.Trim() != "")
            productCapacity.MaxQuantity = Convert.ToDecimal(txtMaxQtyPlan.Text.Trim());
        productCapacity.IsPlan = true;
        if (txtRateOfRevenue.Text.Trim() != "")
            productCapacity.RateOfRevenue = Convert.ToDecimal(txtRateOfRevenue.Text.Trim());
        if (txtRateOfCost.Text.Trim() != "")
            productCapacity.RateOfCost = Convert.ToDecimal(txtRateOfCost.Text.Trim());
        productCapacity.ProductId = Convert.ToInt32(ddlProductPlan.SelectedValue);
        productCapacity.ReportId = ReportId;
        productCapacity.ReportYear = ReportYear;

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
                    txtRateOfCost.Text = productCapacity.RateOfCost.ToString();
                    txtRateOfRevenue.Text = productCapacity.RateOfRevenue.ToString();
                    ddlProductPlan.SelectedValue = productCapacity.ProductId.ToString();
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

    public void btnSaveSolution_Click(object sender, EventArgs e)
    {
        //GiaiPhap gp = new GiaiPhap();
        //GiaiPhapService gpser = new GiaiPhapService();
        //gp.EnterpriseId = Convert.ToInt32(memVal.OrgId);
        //if (txtProductName.Text != "")
        //{
        //    gp.MoTa = txtNote.Text;
        //    gp.TenGiaiPhap = txtProductName.Text;
        //    if (gpser.Insert(gp) > 0)
        //    {
        //        ltNoticeSolution.Text = "Lưu sản phẩm mới thành công";
        //        BindSolution();
        //    }
        //    else
        //        ltNoticeSolution.Text = "Không lưu được sản phẩm mới. Vui lòng thử lại";

        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "showGP", "showgiaiphap();", true);
        //    ScriptManager.RegisterStartupScript(this, GetType(), "ac", "alert('Chưa nhập tên sản phẩm!');", true);
        //}
    }

    void BindInfrastructure()
    {
        Infrastructure infra = new Infrastructure();
        InfrastructureService infraService = new InfrastructureService();

        infra = infraService.GetInfrastructureByReport(ReportId);
        if (infra != null)
        {
            ltProduceArea.Text = infra.ProduceAreaNo.ToString();
            ltOfficeArea.Text = infra.OfficeAreaNo.ToString();
            ltProduceEmployeeNo.Text = infra.ProduceEmployeeNo.ToString();
            ltOfficeEmployeeNo.Text = infra.OfficeEmployeeNo.ToString();
            txtProduceArea.Text = infra.ProduceAreaNo.ToString();
            txtOfficeArea.Text = infra.OfficeAreaNo.ToString();
            txtProduceEmployeeNo.Text = infra.ProduceEmployeeNo.ToString();
            txtOficeEmployeeNo.Text = infra.OfficeEmployeeNo.ToString();
        }
    }
    void BindElectrictResult()
    {
        UsingElectrict usingElectrict = new UsingElectrict();
        UsingElectrictService usingElectrictService = new UsingElectrictService();
        try
        {
            usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, false);
            if (usingElectrict != null)
            {
                if (usingElectrict.InstalledCapacity > 0)
                {
                    ltInstalledResult.Text = usingElectrict.InstalledCapacity.ToString() + "(kV)";
                    txtInstalledCapacity.Text = usingElectrict.InstalledCapacity.ToString();
                }
                else
                    ltInstalledResult.Text = "";
                if (usingElectrict.Capacity > 0)
                {
                    txtCapacity.Text = usingElectrict.Capacity.ToString();
                    ltCapacityResult.Text = usingElectrict.Capacity.ToString() + "(kV)";
                }
                else
                    ltCapacityResult.Text = "";
                if (usingElectrict.AvgPrice > 0)
                {
                    ltPriceAvgResult.Text = usingElectrict.AvgPrice.ToString() + "(đồng/kW)";
                    txtAvgPrice.Text = Tool.ConvertDecimalToString(usingElectrict.AvgPrice);
                }
                if (usingElectrict.PriceBuy > 0)
                {
                    ltPriceBuy.Text = usingElectrict.PriceBuy.ToString() + "(đồng/kWh)";
                    txtPriceBuy.Text = Tool.ConvertDecimalToString(usingElectrict.PriceBuy);
                }
                if (usingElectrict.ProduceQty > 0)
                {
                    ltQuantityProduceResult.Text = usingElectrict.ProduceQty.ToString() + "(10<sup>6</sup> kWh/năm)";
                    txtProduceQty.Text = usingElectrict.ProduceQty.ToString();
                }
                else
                    ltQuantityProduceResult.Text = "";
                if (usingElectrict.Technology != null)
                    ltTechnologyResult.Text = usingElectrict.Technology.ToString();

                if (usingElectrict.Quantity > 0)
                {
                    ltQuantityResult.Text = usingElectrict.Quantity.ToString() + "(10<sup>6</sup> kWh/năm)";
                    txtQuantity.Text = usingElectrict.Quantity.ToString();
                }
                else
                    ltQuantityResult.Text = "";
                Fuel fuel = new Fuel();
                if (usingElectrict.FuelId > 0)
                {
                    fuel = new FuelService().FindByKey(usingElectrict.FuelId);
                    if (fuel != null)
                    {
                        ddlFuel.SelectedValue = usingElectrict.FuelId.ToString();
                        ltFuelResult.Text = fuel.FuelName;
                    }

                }
                else
                    ddlFuel.SelectedIndex = 0;

            }
        }
        catch { }
    }
    void BindElectrictPlan()
    {
        try
        {
            UsingElectrict usingElectrict = new UsingElectrict();
            UsingElectrictService usingElectrictService = new UsingElectrictService();

            usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, true);
            if (usingElectrict != null)
            {
                if (usingElectrict.InstalledCapacity > 0)
                {
                    ltInstalledCapacityPlan.Text = usingElectrict.InstalledCapacity.ToString() + "(kV)";
                    txtInstalledCapacityPlan.Text = usingElectrict.InstalledCapacity.ToString();
                }
                else
                    ltInstalledCapacityPlan.Text = "";
                if (usingElectrict.Capacity > 0)
                {
                    txtCapacityPlan.Text = usingElectrict.Capacity.ToString();
                    ltCapacityPlan.Text = usingElectrict.Capacity.ToString() + "(kV)";
                }
                else
                    ltCapacityPlan.Text = "";
                if (usingElectrict.PriceBuy > 0)
                {
                    txtCostPlan.Text = Tool.ConvertDecimalToString(usingElectrict.PriceBuy);
                    ltPriceBuyPlan.Text = usingElectrict.PriceBuy.ToString() + "(đồng/kWh)";
                }
                else
                    ltPriceBuyPlan.Text = "";
                if (usingElectrict.ProduceQty > 0)
                {
                    txtProduceQtyPlan.Text = usingElectrict.ProduceQty.ToString();
                    ltQuantityProducePlan.Text = usingElectrict.ProduceQty.ToString() + "(10<sup>6</sup> kWh/năm)";
                }
                else
                    ltQuantityProducePlan.Text = "";
                if (usingElectrict.Technology != null)
                    ltTecnologyPlan.Text = usingElectrict.Technology.ToString();

                else
                    ltFuelPlan.Text = "";
                if (usingElectrict.Quantity > 0)
                {
                    txtElectrictQuantityPlan.Text = usingElectrict.Quantity.ToString();
                    ltQuantityElectrictPlan.Text = usingElectrict.Quantity.ToString() + "(10<sup>6</sup> kWh/năm)";
                }
                else
                    ltQuantityElectrictPlan.Text = "";
                if (usingElectrict.PriceProduce > 0)
                {
                    txtPriceProducePlan.Text = usingElectrict.PriceProduce.ToString();
                    ltPriceProducePlan.Text = usingElectrict.PriceProduce.ToString() + "(đồng/kWh)"; ;
                }
                else
                    ltPriceProducePlan.Text = "";

                Fuel fuel = new Fuel();
                if (usingElectrict.FuelId > 0)
                {
                    fuel = new FuelService().FindByKey(usingElectrict.FuelId);
                    if (fuel != null)
                    {
                        ddlFuelPlan.SelectedValue = usingElectrict.FuelId.ToString();
                        ltFuelPlan.Text = fuel.FuelName;
                    }
                }
            }
        }
        catch { }
    }
    private void BindProductCapacity()
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        DataTable tbl = new DataTable();
        tbl = productCapacityService.GetDataCapacity(ReportId, false);
        rptProductResult.DataSource = tbl;
        rptProductResult.DataBind();
    }
    private void BindProductCapacityPlan()
    {
        ProductCapacityService productCapacityService = new ProductCapacityService();
        DataTable tbl = new DataTable();
        tbl = productCapacityService.GetDataCapacity(ReportId, true);
        rptProductPlan.DataSource = tbl;
        rptProductPlan.DataBind();
    }
    protected void btnSaveElectrict_Click(object sender, EventArgs e)
    {
        try
        {
            UsingElectrict usingElectrict = new UsingElectrict();
            UsingElectrictService usingElectrictService = new UsingElectrictService();
            usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, false);
            if (usingElectrict == null)
            {
                usingElectrict = new UsingElectrict();
                usingElectrict.ReportId = ReportId;
                if (txtCapacity.Text.Trim() != "")
                    usingElectrict.Capacity = Convert.ToDecimal(txtCapacity.Text);
                else
                    usingElectrict.Capacity = 0;
                if (txtQuantity.Text.Trim() != "")
                    usingElectrict.Quantity = Convert.ToDecimal(txtQuantity.Text);
                else
                    usingElectrict.Quantity = 0;
                if (txtAvgPrice.Text.Trim() != "")
                    usingElectrict.AvgPrice = Convert.ToDecimal(txtAvgPrice.Text);
                else
                    usingElectrict.AvgPrice = 0;
                if (txtAvgPrice.Text.Trim() != "")
                    usingElectrict.AvgPrice = Convert.ToDecimal(txtAvgPrice.Text);
                else
                    usingElectrict.AvgPrice = 0;
                if (txtPriceBuy.Text.Trim() != "")
                    usingElectrict.PriceBuy = Convert.ToDecimal(txtPriceBuy.Text);
                else
                    usingElectrict.PriceBuy = 0;

                if (txtInstalledCapacity.Text.Trim() != "")
                    usingElectrict.InstalledCapacity = Convert.ToDecimal(txtInstalledCapacity.Text);
                else
                    usingElectrict.InstalledCapacity = 0;
                if (txtProduceQty.Text.Trim() != "")
                    usingElectrict.ProduceQty = Convert.ToDecimal(txtProduceQty.Text);
                else
                    usingElectrict.ProduceQty = 0;
                usingElectrict.Technology = txtTenologyElectrict.Text;
                if (ddlFuel.SelectedIndex > 0)
                    usingElectrict.FuelId = Convert.ToInt32(ddlFuel.SelectedValue);
                else
                    usingElectrict.FuelId = 0;
                usingElectrict.IsPlan = false;
                int i = usingElectrictService.Insert(usingElectrict);
                if (i > 0)
                {
                    if (usingElectrict.InstalledCapacity > 0)
                        ltInstalledResult.Text = usingElectrict.InstalledCapacity.ToString() + "(kV)";
                    else
                        ltInstalledResult.Text = "";
                    if (usingElectrict.Capacity > 0)
                        ltCapacityResult.Text = usingElectrict.Capacity.ToString() + "(kV)";
                    else
                        ltCapacityResult.Text = "";
                    if (usingElectrict.AvgPrice > 0)
                        ltPriceAvgResult.Text = usingElectrict.AvgPrice.ToString() + "(đồng/kW)";
                    if (usingElectrict.PriceBuy > 0)
                        ltPriceBuy.Text = usingElectrict.PriceBuy.ToString() + "(đồng/kWh)";
                    if (usingElectrict.ProduceQty > 0)
                        ltQuantityProduceResult.Text = usingElectrict.ProduceQty.ToString() + "(10<sup>6</sup> kWh/năm)";
                    else
                        ltQuantityProduceResult.Text = "";
                    ltTechnologyResult.Text = usingElectrict.Technology.ToString();
                    if (ddlFuel.SelectedIndex > 0)
                        ltFuelResult.Text = ddlFuel.SelectedItem.Text;
                    else
                        ltFuelResult.Text = "";
                    if (usingElectrict.Quantity > 0)
                        ltQuantityResult.Text = usingElectrict.Quantity.ToString() + "(10<sup>6</sup> kWh/năm)";
                    else
                        ltQuantityResult.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "UpdateElectrict();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
                }
            }
            else
            {
                usingElectrict.ReportId = ReportId;
                if (txtCapacity.Text.Trim() != "")
                    usingElectrict.Capacity = Convert.ToDecimal(txtCapacity.Text);
                else
                    usingElectrict.Capacity = 0;
                if (txtQuantity.Text.Trim() != "")
                    usingElectrict.Quantity = Convert.ToDecimal(txtQuantity.Text);
                else
                    usingElectrict.Quantity = 0;
                if (txtPriceBuy.Text.Trim() != "")
                    usingElectrict.PriceBuy = Convert.ToDecimal(txtPriceBuy.Text);
                else
                    usingElectrict.PriceBuy = 0;
                if (txtAvgPrice.Text.Trim() != "")
                    usingElectrict.AvgPrice = Convert.ToDecimal(txtAvgPrice.Text);
                else
                    usingElectrict.AvgPrice = 0;
                if (txtInstalledCapacity.Text.Trim() != "")
                    usingElectrict.InstalledCapacity = Convert.ToDecimal(txtInstalledCapacity.Text);
                else
                    usingElectrict.InstalledCapacity = 0;
                if (txtProduceQty.Text.Trim() != "")
                    usingElectrict.ProduceQty = Convert.ToDecimal(txtProduceQty.Text);
                else
                    usingElectrict.ProduceQty = 0;
                usingElectrict.Technology = txtTenologyElectrict.Text;
                if (ddlFuel.SelectedIndex > 0)
                    usingElectrict.FuelId = Convert.ToInt32(ddlFuel.SelectedValue);
                else
                    usingElectrict.FuelId = 0;
                usingElectrict.IsPlan = false;

                if (usingElectrictService.Update(usingElectrict) != null)
                {
                    if (usingElectrict.InstalledCapacity > 0)
                        ltInstalledResult.Text = usingElectrict.InstalledCapacity.ToString();
                    if (usingElectrict.Capacity > 0)
                        ltCapacityResult.Text = usingElectrict.Capacity.ToString();

                    if (usingElectrict.ProduceQty > 0)
                        ltQuantityProduceResult.Text = usingElectrict.ProduceQty.ToString();
                    ltTechnologyResult.Text = usingElectrict.Technology.ToString();
                    if (ddlFuel.SelectedIndex > 0)
                        ltFuelResult.Text = ddlFuel.SelectedItem.Text;
                    ltQuantityResult.Text = usingElectrict.Quantity.ToString();

                    if (usingElectrict.InstalledCapacity > 0)
                        ltInstalledResult.Text = usingElectrict.InstalledCapacity.ToString();
                    else
                        ltInstalledResult.Text = "";
                    if (usingElectrict.Capacity > 0)
                    {
                        ltCapacityResult.Text = usingElectrict.Capacity.ToString();
                        ltPriceAvgResult.Text = Math.Round((usingElectrict.BuyCost / (usingElectrict.Capacity * 1000)), 0).ToString();
                    }
                    else
                    {
                        ltCapacityResult.Text = "";
                        ltPriceAvgResult.Text = "";
                    }

                    if (usingElectrict.AvgPrice > 0)
                        ltPriceAvgResult.Text = usingElectrict.AvgPrice.ToString() + "(đồng/kW)";
                    if (usingElectrict.PriceBuy > 0)
                        ltPriceBuy.Text = usingElectrict.PriceBuy.ToString() + "(đồng/kWh)";
                    if (usingElectrict.ProduceQty > 0)
                        ltQuantityProduceResult.Text = usingElectrict.ProduceQty.ToString();
                    else
                        ltQuantityProduceResult.Text = "";
                    ltTechnologyResult.Text = usingElectrict.Technology.ToString();
                    if (ddlFuel.SelectedIndex > 0)
                        ltFuelResult.Text = ddlFuel.SelectedItem.Text;
                    else
                        ltFuelResult.Text = "";
                    if (usingElectrict.Quantity > 0)
                        ltQuantityResult.Text = usingElectrict.Quantity.ToString();
                    else
                        ltQuantityResult.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "UpdateElectrict();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
                }
            }
        }
        catch (Exception ex)
        { }
    }

    public void btnSaveElectrictPlan_Click(object sender, EventArgs e)
    {
        try
        {
            UsingElectrict usingElectrict = new UsingElectrict();
            UsingElectrictService usingElectrictService = new UsingElectrictService();
            usingElectrict = usingElectrictService.GetUsingElectrictByReport(ReportId, true);
            if (usingElectrict == null)
            {
                usingElectrict = new UsingElectrict();
                usingElectrict.ReportId = ReportId;
                if (txtCapacityPlan.Text.Trim() != "")
                    usingElectrict.Capacity = Convert.ToDecimal(txtCapacityPlan.Text);
                else
                    usingElectrict.Capacity = 0;
                if (txtElectrictQuantityPlan.Text.Trim() != "")
                    usingElectrict.Quantity = Convert.ToDecimal(txtElectrictQuantityPlan.Text);
                else
                    usingElectrict.Quantity = 0;
                if (txtCostPlan.Text.Trim() != "")
                    usingElectrict.BuyCost = Convert.ToDecimal(txtCostPlan.Text);
                else
                    usingElectrict.BuyCost = 0;
                if (txtInstalledCapacityPlan.Text.Trim() != "")
                    usingElectrict.InstalledCapacity = Convert.ToDecimal(txtInstalledCapacityPlan.Text);
                else
                    usingElectrict.InstalledCapacity = 0;
                if (txtProduceQtyPlan.Text.Trim() != "")
                    usingElectrict.ProduceQty = Convert.ToDecimal(txtProduceQtyPlan.Text);
                else
                    usingElectrict.ProduceQty = 0;
                usingElectrict.Technology = txtTenologyPlan.Text;
                if (ddlFuelPlan.SelectedIndex > 0)
                    usingElectrict.FuelId = Convert.ToInt32(ddlFuelPlan.SelectedValue);
                else
                    usingElectrict.FuelId = 0;
                if (txtPriceProducePlan.Text.Trim() != "")
                    usingElectrict.PriceProduce = Convert.ToDecimal(txtPriceProducePlan.Text);
                else
                    usingElectrict.PriceProduce = 0;
                usingElectrict.IsPlan = true;
                int i = usingElectrictService.Insert(usingElectrict);
                if (i > 0)
                {
                    if (usingElectrict.InstalledCapacity > 0)
                        ltInstalledCapacityPlan.Text = usingElectrict.InstalledCapacity.ToString() + "(kV)";
                    else
                        ltInstalledCapacityPlan.Text = "";
                    if (usingElectrict.Capacity > 0)
                        ltCapacityPlan.Text = usingElectrict.Capacity.ToString() + "(kV)";
                    else
                        ltCapacityPlan.Text = "";
                    if (usingElectrict.BuyCost > 0)
                        ltPriceBuyPlan.Text = usingElectrict.BuyCost.ToString() + "(đồng/kWh)";
                    else
                        ltPriceBuyPlan.Text = "";
                    if (usingElectrict.ProduceQty > 0)
                        ltQuantityProducePlan.Text = usingElectrict.ProduceQty.ToString() + "(10<sup>6</sup> kWh/năm)";
                    else
                        ltQuantityProducePlan.Text = "";

                    ltTecnologyPlan.Text = usingElectrict.Technology.ToString();
                    if (ddlFuelPlan.SelectedIndex > 0)
                        ltFuelPlan.Text = ddlFuelPlan.SelectedItem.Text;
                    else
                        ltFuelPlan.Text = "";
                    if (usingElectrict.Quantity > 0)
                        ltQuantityElectrictPlan.Text = usingElectrict.Quantity.ToString() + "(10<sup>6</sup> kWh/năm)";
                    else
                        ltQuantityElectrictPlan.Text = "";
                    if (usingElectrict.PriceProduce > 0)
                        ltPriceProducePlan.Text = usingElectrict.PriceProduce.ToString() + "(đồng/kWh)";
                    else
                        ltPriceProducePlan.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "UpdateElectrictPlan();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
                }
            }
            else
            {
                usingElectrict.ReportId = ReportId;
                if (txtCapacityPlan.Text.Trim() != "")
                    usingElectrict.Capacity = Convert.ToDecimal(txtCapacityPlan.Text);
                else
                    usingElectrict.Capacity = 0;
                if (txtElectrictQuantityPlan.Text.Trim() != "")
                    usingElectrict.Quantity = Convert.ToDecimal(txtElectrictQuantityPlan.Text);
                else
                    usingElectrict.Quantity = 0;
                if (txtCostPlan.Text.Trim() != "")
                    usingElectrict.BuyCost = Convert.ToDecimal(txtCostPlan.Text);
                else
                    usingElectrict.BuyCost = 0;
                if (txtInstalledCapacityPlan.Text.Trim() != "")
                    usingElectrict.InstalledCapacity = Convert.ToDecimal(txtInstalledCapacityPlan.Text);
                else
                    usingElectrict.InstalledCapacity = 0;
                if (txtProduceQtyPlan.Text.Trim() != "")
                    usingElectrict.ProduceQty = Convert.ToDecimal(txtProduceQtyPlan.Text);
                else
                    usingElectrict.ProduceQty = 0;
                if (txtPriceProducePlan.Text.Trim() != "")
                    usingElectrict.PriceProduce = Convert.ToDecimal(txtPriceProducePlan.Text);
                else
                    usingElectrict.PriceProduce = 0;
                usingElectrict.Technology = txtTenologyPlan.Text;

                if (ddlFuelPlan.SelectedIndex > 0)
                    usingElectrict.FuelId = Convert.ToInt32(ddlFuelPlan.SelectedValue);
                else
                    usingElectrict.FuelId = 0;
                usingElectrict.IsPlan = true;

                if (usingElectrictService.Update(usingElectrict) != null)
                {
                    if (usingElectrict.InstalledCapacity > 0)
                        ltInstalledCapacityPlan.Text = usingElectrict.InstalledCapacity.ToString() + "(kV)";
                    else
                        ltInstalledCapacityPlan.Text = "";
                    if (usingElectrict.Capacity > 0)
                        ltCapacityPlan.Text = usingElectrict.Capacity.ToString() + "(kV)";
                    else
                        ltCapacityPlan.Text = "";
                    if (usingElectrict.BuyCost > 0)
                        ltPriceBuyPlan.Text = usingElectrict.BuyCost.ToString() + "(đồng/kWh)";
                    else
                        ltPriceBuyPlan.Text = "";
                    if (usingElectrict.ProduceQty > 0)
                        ltQuantityProducePlan.Text = usingElectrict.ProduceQty.ToString() + "(10<sup>6</sup> kWh/năm)";
                    else
                        ltQuantityProducePlan.Text = "";

                    ltTecnologyPlan.Text = usingElectrict.Technology.ToString();
                    if (ddlFuelPlan.SelectedIndex > 0)
                        ltFuelPlan.Text = ddlFuelPlan.SelectedItem.Text;
                    else
                        ltFuelPlan.Text = "";
                    if (usingElectrict.Quantity > 0)
                        ltQuantityElectrictPlan.Text = usingElectrict.Quantity.ToString() + "(10<sup>6</sup> kWh/năm)";
                    else
                        ltQuantityElectrictPlan.Text = "";
                    if (usingElectrict.PriceProduce > 0)
                        ltPriceProducePlan.Text = usingElectrict.PriceProduce.ToString() + "(đồng/kWh)";
                    else
                        ltPriceProducePlan.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "UpdateElectrictPlan();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
                }
            }
        }
        catch (Exception ex)
        { }
    }
    public void btnSaveInfo_Click(object sender, EventArgs e)
    {
        try
        {
            Infrastructure infra = new Infrastructure();
            InfrastructureService infraService = new InfrastructureService();
            if (ReportId > 0)
            {
                infra = infraService.GetInfrastructureByReport(ReportId);
                if (infra != null)
                {
                    if (txtProduceEmployeeNo.Text.Trim() != "")
                        infra.ProduceEmployeeNo = Convert.ToInt32(txtProduceEmployeeNo.Text.Trim());
                    if (txtOficeEmployeeNo.Text.Trim() != "")
                        infra.OfficeEmployeeNo = Convert.ToInt32(txtOficeEmployeeNo.Text.Trim());
                    if (txtProduceArea.Text.Trim() != "")
                        infra.ProduceAreaNo = Convert.ToInt32(txtProduceArea.Text.Trim());
                    if (txtOfficeArea.Text.Trim() != "")
                        infra.OfficeAreaNo = Convert.ToInt32(txtOfficeArea.Text.Trim());
                    infra = infraService.Update(infra);
                    if (infra != null)
                    {
                        ltProduceArea.Text = infra.ProduceAreaNo.ToString();
                        ltOfficeArea.Text = infra.OfficeAreaNo.ToString();
                        ltProduceEmployeeNo.Text = infra.ProduceEmployeeNo.ToString();
                        ltOfficeEmployeeNo.Text = infra.OfficeEmployeeNo.ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "UpdateInfratructure();", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
                    }

                }
                else
                {
                    infra = new Infrastructure();
                    infra.ReportId = ReportId;
                    if (txtProduceEmployeeNo.Text.Trim() != "")
                        infra.ProduceEmployeeNo = Convert.ToInt32(txtProduceEmployeeNo.Text.Trim());
                    if (txtOficeEmployeeNo.Text.Trim() != "")
                        infra.OfficeEmployeeNo = Convert.ToInt32(txtOficeEmployeeNo.Text.Trim());
                    if (txtProduceArea.Text.Trim() != "")
                        infra.ProduceAreaNo = Convert.ToInt32(txtProduceArea.Text.Trim());
                    if (txtOfficeArea.Text.Trim() != "")
                        infra.OfficeAreaNo = Convert.ToInt32(txtOfficeArea.Text.Trim());
                    int i = infraService.Insert(infra);
                    if (i > 0)
                    {
                        ltProduceArea.Text = infra.ProduceAreaNo.ToString();
                        ltOfficeArea.Text = infra.OfficeAreaNo.ToString();
                        ltProduceEmployeeNo.Text = infra.ProduceEmployeeNo.ToString();
                        ltOfficeEmployeeNo.Text = infra.OfficeEmployeeNo.ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "UpdateInfratructure();", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
                    }

                }

            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showkhd", "UpdateInfratructure();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "message", "alert('Cập nhật không thành công!');", true);
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
    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProduct.SelectedIndex > 0)
        {
            Product product = new Product();
            ProductService productService = new ProductService();
            product = productService.FindByKey(Convert.ToInt32(ddlProduct.SelectedValue));
            ltMeasurement.Text = product.Measurement;
            txtQtyByDesign.Text = product.Quantity.ToString();
            ltMearsurement2.Text = "(" + product.Measurement + ")";
        }
        else
        {
            txtQtyByDesign.Text = "";
            ltMeasurement.Text = "";
            ltMearsurement2.Text = "";

        }
        ScriptManager.RegisterStartupScript(this, GetType(), "showformDetail", "AddProductQty(0);", true);
    }
}